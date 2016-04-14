using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using HotKeys;


namespace ScreenDimmerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window configWindow;
        NotifyIcon systemTrayIcon;
        ContextMenu menu;
        MenuItem menuItem1;
                        
        public double prevOpacity;

        #region Setup

        public MainWindow()
        {
            InitializeComponent();

            InitializeSystemTrayIcon();

            Loaded += MainWindow_Loaded;

            menu = new ContextMenu();
            menuItem1 = new MenuItem();
            systemTrayIcon.ContextMenu = menu;             //Assign menu to tray icon
                        
            //Initialise contextmenu menu
            this.menu.MenuItems.AddRange(
                    new MenuItem[] { menuItem1 });

            // Initialize menuItem1
            menuItem1.Index = 0;
            menuItem1.Text = "E&xit";
            menuItem1.Click += new EventHandler(this.menuItem1_Click);
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            systemTrayIcon.Icon = null;
            System.Windows.Application.Current.Shutdown();            
        }

        // On source initialized, set window to be transparent to clicks
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            WindowsServices.SetWindowClickTransparent(hwnd);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RegisterGlobalHotKeys();
        }

        #endregion

        #region Global Hotkey Setup

        private void RegisterGlobalHotKeys()
        {
            // blackout
            RegisterHotKey(ModifierKeys.None, Keys.F3, F3Pressed);
            // darken
            RegisterHotKey(ModifierKeys.None, Keys.F8, F8Pressed);
            // lighten
            RegisterHotKey(ModifierKeys.None, Keys.F9, F9Pressed);
        }

        // registers hotkey input, and key press event. Returns hotkey if needed
        private HotKey RegisterHotKey(ModifierKeys modifierKeys, Keys key, Action keyPressEvent)
        {

            HotKey hKey = new HotKey(modifierKeys, key, this);
            hKey.HotKeyPressed += keyPressEvent;
            return hKey;
        }

        #endregion

        #region SystemTray Icon

        private void InitializeSystemTrayIcon()
        {
            // create new system tray icon, set icon and make visible.
            systemTrayIcon = new NotifyIcon();
            systemTrayIcon.Icon = ScreenDimmerWPF.Properties.Resources.sun;
            systemTrayIcon.Visible = true;

            // Adding event listener for system tray icon clicks
            systemTrayIcon.MouseClick +=
                new System.Windows.Forms.MouseEventHandler(SystemTrayIcon_MouseClick);
        }


        private void SystemTrayIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // on left click, if no config window, create config window. show.
            if (e.Button == MouseButtons.Left)
            {
                if (configWindow == null)
                {
                    configWindow = new Config(this);
                    configWindow.Closed += new EventHandler(Config_Closed);
                }

                configWindow.Show();
            }
        }
        
        // listening for config closed in order to set configWindow null
        private void Config_Closed(object sender, System.EventArgs e)
        {
            configWindow = null;
        }

        #endregion

        #region Global KeyPress Events

        // press f3 for blackout mode
        private void F3Pressed()
        {
            if (Opacity != 1)
            {
                prevOpacity = Opacity;  //store current opacity value
                Opacity = 1;            //blackout screen
            }
            else if (Opacity == 1)      // press F3 again to exit blackout mode
            {
                Opacity = prevOpacity;  //restore to previous opacity
            }
        }

        // press f8 to darken screen
        private void F8Pressed()
        {
            if (Opacity < .9)
            {
                Opacity += .1;      // make screen darker
            }
        }

        // press f9 to brighten screen
        private void F9Pressed()
        {
            if (Opacity > 0) // press F9
            {
                Opacity -= .1;      // make screen lighter
            }
        }

        #endregion

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScreenDimmerWPF
{
    /// <summary>
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : Window
    {

        // reference to black out window
        public Window mainWindow;

        public Config(Window mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            // sets new config window slider bar to current window opacity percentage
            slider.Value = mainWindow.Opacity * 100;

        }

        // defined in Config.xaml 
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;

            // reduce to 0-1, set black out window opacity
            if (mainWindow != null)
                mainWindow.Opacity = slider.Value / 100;
        }

        
    }
}

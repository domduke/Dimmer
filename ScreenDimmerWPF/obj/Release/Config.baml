   M S B A M L   `   `   `  ���� J  FScreenDimmerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ScreenDimmerWPFScreenDimmerWPF      ScreenDimmerWPF.Config   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:ScreenDimmerWPF       � Title$  Config��$	��100��$	��220�� � 
ResizeMode$ NoResize=� � Topmost .  � WindowStyle$
 none=�$��0q�$��0q�$
��Left=�$	��Top=� � WindowStartupLocation$ CenterScreen=����#00254D.���  J� Opacity$	 0.9Q� � ColumnDefinitions �� �� $��3* �.+��� -    ��Name$ slider��$
��Left=�$��1,26,0,0q�$	��Top=� � Maximum$ 90Q�	 � Cursor$	 Arrow��$	��183��
 � Value$
 25Q� �� IsDirectionReversed . $��2�� �� TickPlacement$ BottomRight=� �� TickFrequency$ 10Q��� -    ��Name$ label��$ ��Brightness                ��$
��Left=�$	��Top=�$��
16.2,0,0,0q�$��1��
���������Z�  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 290Q�   Opacity$	 0.5Q�   
BlurRadius$ 3Q�   ShadowDepth$ 1Q��� -    ��Name$ BrightnessLevel��$��1��$
��Left=�$��
139,13,0,0q�$
��Wrap=�$	��Top=�
����������� *prevOpacity+
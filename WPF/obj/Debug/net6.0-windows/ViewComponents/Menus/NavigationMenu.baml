   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewComponents.CustomControls!WPF.ViewComponents.CustomControls  5      -    'WPF.ViewComponents.Menus.NavigationMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I EUno.UI, Version=255.255.255.255, Culture=neutral, PublicKeyToken=nullR NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null>x,http://schemas.microsoft.com/winfx/2006/xaml       5      Nmc;http://schemas.openxmlformats.org/markup-compatibility/2006       5      Dd2http://schemas.microsoft.com/expression/blend/2008       5      Fcustom/clr-namespace:WPF.ViewComponents.CustomControls       5      .��5
      � .+�5   
   5   /WPF.ViewComponents.CustomControls.HamburgerMenu  -   5           Name$  hamburgerMenu��5      $��0��5      
������ ���#dbdbdb$��0 0 1 0q�5      
�������   FallbackOpenWidth$	 300Q�5         OpenCloseDuration$ 0:0:0.25D�5         IsOpen 5      �� *
isMenuOpen+ � 	Resources 5      9   3WPF.ViewComponents.CustomControls.HamburgerMenuItem �� 
TargetType �� Property �� Value   ButtonMenuFontSize  colorSecondary �� Triggers	 ]� 
Conditions
 �� Property �� Value N� EnterActions �� TargetProperty	 �� To g� Duration N� ExitActions P� Property P� Value��%�  '        �� 5      "  6   .�5      ��  � ��$ 20 10q�60   �� 5       � ��# �   61   �� 5       � ��# �  63   �� 5       � ��
 �����63    5      ]� 5      	 5       �� 5!   "   
 �@J�IsMouseOver$
 True��6D   �� 5"   "   
 �@d�	IsChecked$ FalseY�6B   ./�5$      ��  � ��
 �   �6;    5%      �� 5&   "   .��5'   &   �� .��5(   *   �� $( "Background.(SolidColorBrush.Color)�5)   -    #E1E2E15*   -   $ 0:0:0.1D�5+   -   5,   '   5-   #    5/      �� 50   "   .��51   &   �� .��52   *   �� $* $(Background).(SolidColorBrush.Color)�53   -    Transparent54   -   $ 0:0:0.1D�55   -   56   '   57   #   59      ]� 5;      	 5<      �� 5=   "   
 �@J�IsMouseOver$
 True��6D   �� 5>   "   
 �@d�	IsChecked$
 TrueY�6A    5@      �� 5A   "   .��5B   &   �� .��5C   *   �� $( "Background.(SolidColorBrush.Color)�5D   !    #132c335E   !   $ 0:0:0.1D�5F   !   5G   '   5H   #   5J      P� 5L       �@d�	IsChecked$
 TrueY�67   . �5M      ��  � �� �#132c336;   5N      P� 5P       �@d�	IsChecked$ FalseY�67   . �5Q      ��  � ��
 ���� 6;   5R      5U      5V         Content 5X      � 5Y       � RowDefinitions 5Z      �� 5[      $	��200 �6(   �� 5\      $��* �6(   .+�5_      �� -   5         ��Name$ 
stackPanel��5`      $��0��5a      $��2��5b      $��Center=�5c      $��Center=�5d      .+�5e         d� 	IsChecked$
 TrueY�5f   3   ��5e   3   �� *navigateHomeCommand+.��5g      �� $��Inicio��6(   5h        5i      ��63   �� *navigateProductCommand+.��5j      �� $��Producto��6(   5k        5l      ��63   �� *navigateProviderCommand+.��5m      �� $��	Proveedor��6(   5n        5o      ��63   �� *navigateEmployeeCommand+.��5p      �� $��Empleado��6(   5q      5r      �� 5t      $��0��5u      $	��113��5v      $	��110��5w      $��0 40 0 0q�5x      ���#E1E2E1$	��Top=�5z      $��Center=�5{      y�5|      �� *
isMenuOpen+   BooleanToVisibilityConverter �� 	Converter# [ ._�5}      �� $	��1.5q�5~      $"��/Resource/Image/cnm-icon.png��5      5�      5�      5�      5�      5�      
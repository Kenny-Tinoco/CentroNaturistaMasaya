   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      -    'WPF.ViewsComponent.Menus.NavigationMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      .��5
      � .+�5   
   5   /WPF.ViewsComponent.CustomControls.HamburgerMenu  -   5           Name$  hamburgerMenu��5      $��0��5      
������ ���#dbdbdb$��0 0 1 0q�5      
�������   FallbackOpenWidth$	 300Q�5         OpenCloseDuration$ 0:0:0.25D�5         IsOpen 5      �� *
isMenuOpen+ � 	Resources 5      9   3WPF.ViewsComponent.CustomControls.HamburgerMenuItem �� 
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
 TrueY�5f   3   ��5e   3   �� *navigateHomeCommand+.��5g      �� $��Inicio��6(   5h        5i      ��63   �� *navigateSaleCommand+.��5j      �� $��Venta��6(   5k   	     5l      ��6!   �� *navigatePurchaseCommand+.��5m   	   �� $��Compra��6   5n   	     5o      ��6!   �� *navigateConsultationCommand+.��5p   	   �� $��Consulta��6   5q   	     5r      ��6!   �� *navigateProductCommand+.��5s   	   �� $��Producto��6   5t   	     5u      ��6!   �� *navigateEmployeeCommand+.��5v      �� $��Empleado��6(   5w      5x      �� 5z      $��0��5{      $	��113��5|      $	��110��5}      $��0 40 0 0q�5~      ���#E1E2E1$	��Top=�5�      $��Center=�5�      y�5�      �� *
isMenuOpen+   BooleanToVisibilityConverter �� 	Converter# [ ._�5�      �� $	��1.5q�5�      $"��/Resource/Image/cnm-icon.png��5�      5�      5�      5�      5�      5�      
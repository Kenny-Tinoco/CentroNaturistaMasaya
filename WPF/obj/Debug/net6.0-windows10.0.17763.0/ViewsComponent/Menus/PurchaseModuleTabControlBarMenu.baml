   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WPF.ViewsComponent.MenusWPF.ViewsComponent.Menus  5      U/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      >    8WPF.ViewsComponent.Menus.PurchaseModuleTabControlBarMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:WPF.ViewsComponent.Menus     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5        � 	Resources  5          BooleanToVisibilityConverter9   3WPF.ViewsComponent.CustomControls.HamburgerMenuItem �� 
TargetType �� Property �� Value  CustomButtonFontSize  colorBlancoFondo6  0System.Windows.Controls.Ribbon.RibbonRadioButton �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions	 �� TargetProperty	
 �� To g� Duration N� ExitActions P� Property P� Value��%{  &	        '       �� 5      6!   �� 5      "  6
   .�5      ��  � ��$ 20 10q�5      �� 5       � ��# �  5      �� 5       � ��
 �   �5      �� 5       � ��# �  5      �� 5       �@ CornerRadius$ 6��5       5      ]� 5       5      �� 5       �@J�IsMouseOver$
 True��5   
   �� 5        �@d�	IsChecked$ FalseY�5!   
   ./�5#      ��  � ��
 �����5$       5%      �� 5&      .��5'   	   �� .��5(   
   �� $(	 "Background.(SolidColorBrush.Color)�6   
 #0c6e825)      $ 0:0:0.1D�5*      5+   
   5,   	    5.      �� 5/      .��50   	   �� .��51   
   �� $*	 $(Background).(SolidColorBrush.Color)�6   
 #E1E2E152      $ 0:0:0.1D�53      54   
   55   	   57      ]� 59       5:      �� 5;       �@J�IsMouseOver$
 True��5<   
   �� 5=       �@d�	IsChecked$
 TrueY�5>   
    5@      �� 5A      .��5B   	   �� .��5C   
   �� $(	 "Background.(SolidColorBrush.Color)�6   
 #132c335D      $ 0:0:0.1D�5E      5F   
   5G   	   5I      P� 5K       �@d�	IsChecked$
 TrueY�5L      . �5M      ��  � ��
 �����5N      �� 5O       � �� �#132c335P      5Q      P� 5S       �@d�	IsChecked$ FalseY�5T      . �5U      ��  � �� �#E1E2E15V      5W      5Z      5[      .��5]      � .+�5_      �� -   5         ��Name$ 
stackPanel��5_       �� Orientation$ 
Horizontal=�5`      .+�5b         d� 	IsChecked$
 TrueY�5c      ��5b      �� *navigateBuyProducts+.��5d      �� $��Compra de productos��6   5e        5f      $��	10 0 10 0q�5g      ��5f      �� *navigatePurchasePage+.��5h      �� $��Registros de Compras��6   5i        5j      ��6   �� *navigateProvider+.��5k      �� $��Proveedores��6   5l      5m      5o      5p      
   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      =    7WPF.ViewsComponent.Menus.ProductModuleTabControlBarMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5        � 	Resources  5	          BooleanToVisibilityConverter9   3WPF.ViewsComponent.CustomControls.HamburgerMenuItem �� 
TargetType �� Property �� Value  CustomButtonFontSize  colorBlancoFondo6  0System.Windows.Controls.Ribbon.RibbonRadioButton �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions	 �� TargetProperty	
 �� To g� Duration N� ExitActions P� Property P� Value  HamburgerMenuItemModal1  +System.Windows.Controls.Ribbon.RibbonButton �� 
TargetType �� Padding   CornerRadius �� CornerRadius��%:	  &	        '       &	 g    �� 5      6!   �� 5      "  6
   .�5      ��  � ��$ 20 10q�5      �� 5       � ��# �  5      �� 5       � ��
 �   �5      �� 5       � ��# �  5      �� 5       �@ CornerRadius$ 6��5       5      ]� 5       5      �� 5       �@J�IsMouseOver$
 True��5   
   �� 5       �@d�	IsChecked$ FalseY�5   
   ./�5!      ��  � ��
 �����5"       5#      �� 5$      .��5%   	   �� .��5&   
   �� $(	 "Background.(SolidColorBrush.Color)�6   
 #0c6e825'      $ 0:0:0.1D�5(      5)   
   5*   	    5,      �� 5-      .��5.   	   �� .��5/   
   �� $*	 $(Background).(SolidColorBrush.Color)�6   
 #E1E2E150      $ 0:0:0.1D�51      52   
   53   	   55      ]� 57       58      �� 59       �@J�IsMouseOver$
 True��5:   
   �� 5;       �@d�	IsChecked$
 TrueY�5<   
    5>      �� 5?      .��5@   	   �� .��5A   
   �� $(	 "Background.(SolidColorBrush.Color)�6   
 #132c335B      $ 0:0:0.1D�5C      5D   
   5E   	   5G      P� 5I       �@d�	IsChecked$
 TrueY�5J      . �5K      ��  � ��
 �����5L      �� 5M       � �� �#132c335N      5O      P� 5Q       �@d�	IsChecked$ FalseY�5R      . �5S      ��  � �� �#E1E2E15T      5U      5X      �� 5Z      "  5[      .�5\      ��  � ��$ 20 10q�5]      �� 5^       � ��# �  5_      �� 5`       � ��
 �   �5a      �� 5b       � ��# �  5c      �� 5d       �@ CornerRadius$ 6��5e      �� 5f       � �� 5g      �� 5h      "  6   .R�5i      �� # z��6   #��z��5j   	   #��z��5k   	   #��z��5l   	   # z 5m   	   ._�5n   	   �� #��z��6   5o   	   5p      5r       5s      ]� 5u       5v      �� 5w       �@J�IsMouseOver$
 True��5x   
   ./�5z      ��  � ��
 �����5{       5|      �� 5}      .��5~   	   �� .��5   
   �� $(	 "Background.(SolidColorBrush.Color)�6   
 #0c6e825�      $ 0:0:0.1D�5�      5�   
   5�   	    5�      �� 5�      .��5�   	   �� .��5�   
   �� $*	 $(Background).(SolidColorBrush.Color)�6   
 #E1E2E15�      $ 0:0:0.1D�5�      5�   
   5�   	   5�      5�      5�      .��5�      � .+�5�      �� -   5         ��Name$ 
stackPanel��5�       �� Orientation$ 
Horizontal=�5�      .+�5�         d� 	IsChecked$
 TrueY�5�      ��5�      �� *navigateStockPage+.��5�      �� $��
Existencia��6   5�        5�      $��	10 0 10 0q�5�      ��5�      �� *navigateProductPage+.��5�      �� $��Datos de Producto��6   5�        5�      #���  5�   	   ��5�      �� *navigatePresentationModal+.��5�      �� $��Presentaciones��6   5�      5�      5�      5�      
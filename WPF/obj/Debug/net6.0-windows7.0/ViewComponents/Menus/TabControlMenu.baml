   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewComponents.CustomControls!WPF.ViewComponents.CustomControls  5      0    *WPF.ViewComponents.Menus.TabControlBarMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewComponents.CustomControls     5        � 	Resources  5	          BooleanToVisibilityConverter9   3WPF.ViewComponents.CustomControls.HamburgerMenuItem �� 
TargetType �� Property �� Value  CustomButtonFontSize  colorBlancoFondo6  0System.Windows.Controls.Ribbon.RibbonRadioButton �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions	 �� TargetProperty	
 �� To g� Duration N� ExitActions P� Property P� Value  HamburgerMenuItemModal1  +System.Windows.Controls.Ribbon.RibbonButton �� 
TargetType �� Padding   CornerRadius �� CornerRadius��%�  &	        '       &	 7    �� 5   
   6'   �� 5   
   "  6   .�5      ��  � ��$ 20 10q�6(   �� 5       � ��# �  6)   �� 5       � ��
 �   �6+   �� 5       � ��# �  6+   �� 5       �@ CornerRadius$ 6��6-    5      ]� 5       5      �� 5       �@J�IsMouseOver$
 True��6<   �� 5       �@d�	IsChecked$ FalseY�6:   ./�5      ��  � ��
 �����63    5      �� 5      .��5      �� .��5   "   �� $(	 "Background.(SolidColorBrush.Color)�5   !   
 #0c6e825    !   $ 0:0:0.1D�5!   !   5"      5#       5%      �� 5&      .��5'      �� .��5(   "   �� $*	 $(Background).(SolidColorBrush.Color)�5)   !   
 #E1E2E15*   !   $ 0:0:0.1D�5+   !   5,      5-      5/      ]� 51       52      �� 53       �@J�IsMouseOver$
 True��6<   �� 54       �@d�	IsChecked$
 TrueY�6:    56      �� 57      .��58      �� .��59   "   �� $(	 "Background.(SolidColorBrush.Color)�5:   !   
 #132c335;   !   $ 0:0:0.1D�5<   !   5=      5>      5@      P� 5B       �@d�	IsChecked$
 TrueY�6/   . �5C      ��  � ��
 �����63   �� 5D       � �� �#132c3363   5E      P� 5G       �@d�	IsChecked$ FalseY�6/   . �5H      ��  � �� �#E1E2E163   5I      5L      �� 5N   
   "  6/   .�5O      ��  � ��$ 20 10q�6(   �� 5P       � ��# �  6)   �� 5Q       � ��
 �   �6+   �� 5R       � ��# �  6+   �� 5S       �@ CornerRadius$ 6��6-   �� 5T       � �� 5U      �� 5V      "  6&   .R�5W      �� # z��5X      #��z��5Y      #��z��5Z      #��z��5[      # z 5\      ._�5^      �� #��z��6-   5_      5`      5b       5c      ]� 5e       5f      �� 5g       �@J�IsMouseOver$
 True��6<   ./�5i      ��  � ��
 �����63    5j      �� 5k      .��5l      �� .��5m   "   �� $(	 "Background.(SolidColorBrush.Color)�5n   !   
 #0c6e825o   !   $ 0:0:0.1D�5p   !   5q      5r       5t      �� 5u      .��5v      �� .��5w   "   �� $*	 $(Background).(SolidColorBrush.Color)�5x   !   
 #E1E2E15y   !   $ 0:0:0.1D�5z   !   5{      5|      5~      5�      5�      .��5�      � .+�5�   
   �� -   5         ��Name$ 
stackPanel��5�       �� Orientation$ 
Horizontal=�5�      .+�5�         d� 	IsChecked$
 TrueY�5�   '   ��5�   '   �� *navigateStockPage+.��5�      �� $��
Existencia��6   5�        5�      $��	10 0 10 0q�5�   '   ��5�   '   �� *navigateProductPage+.��5�      �� $��Datos de Producto��6   5�        5�      #���  5�      ��5�      �� *navigatePresentationModal+.��5�      �� $��Presentaciones��6   5�      5�      5�      5�      
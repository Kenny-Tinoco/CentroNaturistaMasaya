   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF.ViewModelWPF.ViewModel  5   	   C&clr-namespace:WPF.ViewModel.ComponentsWPF.ViewModel.Components  5   	   A%clr-namespace:WPF.View.ProductWindowsWPF.View.ProductWindows  5   	   C&clr-namespace:WPF.ViewComponents.MenusWPF.ViewComponents.Menus  5	   	   ;"clr-namespace:WPF.View.HomeWindowsWPF.View.HomeWindows  5
   	   Q-clr-namespace:WPF.ViewComponents.UserControlsWPF.ViewComponents.UserControls  5   	   U/clr-namespace:WPF.ViewComponents.CustomControls!WPF.ViewComponents.CustomControls  5   	       WPF.View.Startup   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1	viewmodelclr-namespace:WPF.ViewModel     5   	   GcomponentsViewModels&clr-namespace:WPF.ViewModel.Components     5   	   EviewsProductWindows%clr-namespace:WPF.View.ProductWindows     5   	   =
viewsMenus&clr-namespace:WPF.ViewComponents.Menus     5	   	   ?viewsHomeWindows"clr-namespace:WPF.View.HomeWindows     5
   	   Fusercontrols-clr-namespace:WPF.ViewComponents.UserControls     5   	   Bcustom/clr-namespace:WPF.ViewComponents.CustomControls     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5   	   $	��700��5   	   $
��1300��5   	   .��5      �  � 	Resources 5   
    �� DataType6   0WPF.ViewModel.Components.ProductWindowsViewModel0   *WPF.View.ProductWindows.ProductWindowsView!   WPF.ViewModel.HomeViewModel#   WPF.View.HomeWindows.HomeView"   WPF.ViewModel.StockViewModel'   !WPF.View.ProductWindows.StockPage&    WPF.ViewModel.StockFormViewModel'   !WPF.View.ProductWindows.StockForm2	   ,WPF.ViewModel.ProductSelectionModalViewModel3
   -WPF.View.ProductWindows.ProductSelectionModal$   WPF.ViewModel.ProductViewModel)   #WPF.View.ProductWindows.ProductPage.   (WPF.ViewModel.PresentationModalViewModel/   )WPF.View.ProductWindows.PresentationModal)   #WPF.ViewModel.ProductModalViewModel*   $WPF.View.ProductWindows.ProductModal��%X  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5"      *,	 +)(�� �     5%      *, +)(�� ,    5(      *, +)(�� ^    5+      *, +)�� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      �� 5      "  6   .R�5         5!      �� 5"      " 	 6   .R�5#      
  5$      �� 5%      "  6   .R�5&        5'      �� 5(      "  6   .R�5)        5*      �� 5+      "  6   .R�5,        5-      5.       � ColumnDefinitions 5/   
   �� 50      $
��auto �6   �� 51      $��* �6    � RowDefinitions 53   
   �� 54      $
��auto �6   �� 55      $��* �6   .+�58   
   �� $��0��59      $��1��5:      $��2��5;         colorPrimary#���   5<      ._�5>      � $��40��6   $��10 0 0 0q�5?       5A      �� 5B      $
��auto �6'   �� 5C      $��* �6'   �� 5D      $
��auto �6'   .+�5G      �� -   5         ��Name$ cbToggleMenu��5G      $��38��5H      $��30��5I      $��2q�5J      $��0��5K      $��Center=�5L       d� 	IsChecked 5M      �� *$"navigationMenuViewModel.isMenuOpen+ �� Mode$ TwoWay=���5N      �� 5O      	 �� 
TargetType"	 ��6*   .R�5P      �� 
 ��Name$
 border��6%   $��1q�65   
������ ._�5Q   "   (� $��29��6*   $��28��65   .��5R   &   F� �������- ���@o@���@o@ $� ���-  $� ���- �����- @]� �@o@@]� �@o@�ا ���- �ا ���- @]� ���- ��[ ���-  z �@o@ z �@o@��[ ���- ��[ 	
������� �� Stretch$
 Fill=�5U   )   5V   #   5W       �� Triggers 5X      P� 5Y   "    P� Property �@J�IsMouseOver P� Value$
 true��6A   . �5Z   &   ��  �� 
TargetName$ border��6C    �� Property � �� �� Value
 �   �6W   �� 5[   &   $ border��6D    � ��
 �����6X   5\   #   P� 5]   "    � ��$
 true��6?   . �5^   &   �� $ border��6C    � ��
 ���� 6W   �� 5_   &   $ border��6D    � ��
 �����6X   5`   #   5b      5d      �� 5f      $��18(�5g      $��0��5h      $��3��5i      
�������$��Center=�5k      $��Center=�5l      $��Centro Naturista Masaya��5m      �� 5o      $��2��5p      $��0 0 4 0q�5q       �� Orientation$ 
Horizontal=�5r      $��Center=�5s      $��Right=�5t      .+�5v      4   .WPF.ViewComponents.UserControls.TitleBarButton     Icon$" /Resource/Image/minimize.png��5w         buttonParameter$ minimize��5y        CustomButtonMinimizeStyle   styleButton# [ 5z         buttonCommand 5x      �� *stateBarCommand+5z        5|      $��4 0 0 0q�5}      $ /Resource/Image/exit.png��5~      $
 exit��5�        CustomButtonExitStyle# [ 5�       5      �� *stateBarCommand+5�      5�      5�      5�      � 5�   
   $��0��5�      $��2��5�      $��0��5�        colorSecondary#���  5�      .+�5�      -   'WPF.ViewComponents.Menus.NavigationMenu   � DataContext 6(   �� *navigationMenuViewModel+5�      -   'WPF.ViewComponents.CustomControls.Modal  5�   
    K� ZIndex$ 1��6   $��0��5�      $��2��5�      $��0��5�      $��2��5�         IsOpen 5�      �� *isOpen+.��5�      �� ��6   �� *currentModalViewModel+5�       � 5�   
   $��1��5�      $��2��5�      $��1��5�        � NavigationUIVisibility$ Hidden=�5�      #���   5�      ��5�      �� *currentViewModel+5�      5�      
   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewComponents.CustomControls!WPF.ViewComponents.CustomControls  5      Q-clr-namespace:WPF.ViewComponents.UserControlsWPF.ViewComponents.UserControls  5      )    #WPF.View.ProductWindows.ProductPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I EUno.UI, Version=255.255.255.255, Culture=neutral, PublicKeyToken=nullR NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null>x,http://schemas.microsoft.com/winfx/2006/xaml       5      Nmc;http://schemas.openxmlformats.org/markup-compatibility/2006       5      Dd2http://schemas.microsoft.com/expression/blend/2008       5      Fcustom/clr-namespace:WPF.ViewComponents.CustomControls       5      JuserControls-clr-namespace:WPF.ViewComponents.UserControls       5      -   5          N�Name$
  root��5	       N� Title$ ProductPage��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��15 �6   �� 5      �� 5      $��15 �6    � RowDefinitions 5   
   �� 5      $��8 �6   �� 5      $
��auto �6   �� 5      $��40 �6   �� 5      �� 5      $��8 �6   .+�5   
   �� $��1��5      $
��Left=�5      $��
30,30,0,15q�5         StackPanelStyle#���   5       .+�5!      2   ,WPF.ViewComponents.UserControls.CustomButton     Title$ Nuevo Producto��5"         ImageSource$ /Resource/Image/plus.png��5$         buttonCommand 5#      �� *
addCommand+5$      5%      �� 5'   
   $��1��5(      $��Right=�5)      $��	0,0,30,15q�5*      #���   5+      .+�5,      ��  �� Orientation$ 
Horizontal=�6   .+�5-      /   )WPF.ViewComponents.UserControls.SearchBar     	BarHeight$ 30Q�5.      	   BarWidth$		 250Q�5/      $��0 0 20 0q�51      
   searchBarText
 50      �� *
searchText+ �� Mode$ TwoWay=�51      53      54      �� 56   
   $��2��57      $��1��58      $��SemiBold"�59       �� TextAlignment$ Center=�5:      $��Bottom=�5;        ProductWindowTitle#���  5<       ! ElementsDataGridTitleFontSize#���  5=      6   0WPF.ViewComponents.CustomControls.LoadingSpinner  5?   
   $��3��5@      $��1��5A         Diameter$	 100Q�5B         	Thickness$ 5Q�5D         Color
 �   �   	IsLoading 5C      �� *	IsLoading+5E      � 5G   
   $��3��5H      $��1��5I      y�5J      �� *	IsLoading+ ' #InverseBooleanToVisibilityConverter �� 	Converter# [ .+�5L      &   System.Windows.Controls.DataGrid  -   5          Name$ elementDataGrid��5M        ElementsDataGrid#���  5O      ��5N      �� *	catalogue+ � 	Resources 5Q        optionsCell  ButtonStyle �� Path �� RelativeSource �� AncestorType��%�  &	       �� 5R      .R�5S      �� $��Center=�5T      $ 
Horizontal=�5U      .+�5V      �� $��Editar��6%   #���  5Y   %   ���#2196F3��5W   %   �� $ DataContext.editCommand� �� "  ��5X   %   �� 5Z   %   �� 5[      $��Eliminar��6%   #���  5^   %   $��4 0 0 0q�5_   %   ���#F44336��5\   %   �� $ DataContext.deleteCommand� �� "  ��5]   %   �� 5`   %   5a      5b      5c         Columns 5d      0  *System.Windows.Controls.DataGridTextColumn  5e      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *	idProduct+  5f      $ Nombre��6)   $	 220 69    6E   �� *name+  5g      $ Descripción��6)   $ * 6>    6H   �� *description+  5h      $ Cantidad total��6)   $
 auto 6A    6N   �� *
quantity+4	  .System.Windows.Controls.DataGridTemplateColumn	  5i      $ Opciones��6-   $	 155 6?    	  CellTemplate# [ 6K   5k      5l      5m       5n       �� 
TargetType �� Property �� Value �� 
TargetType  ��Name! �� CornerRadius" �� Padding# J� SnapsToDevicePixels$ ��Name% �� Triggers& P� Property' P� Value( �� 
TargetName��%�  &	        &	 �     �� 5o   
   " ��5p      .�5q      ��  � ��$ 2��6)   �� 5r       � ��$ 1��6,   �� 5s       � ��$ Bottom=�62   �� 5t       � ��$ 32��6'   �� 5u       �@��Orientation$ 
Horizontal=�6,   5v      �� 5w   
   " ��5x      .�5y      ��  � ��$ 15(�6)   �� 5z       � ��
 �����6+   �� 5{       � ��$ Normal"�6+   �� 5|       � �� 5}      �� 5~      " ��6&   .R�5�      �� $  border��6!   #��z��5�      $! 4��5�      $" 8 0 8 0q�5�      
�������$	��0.6q�5�      $
# true��5�      ._�5�      �� $$ contentPresenter��6/   $|�False��5�   +   $��Center=�5�   +   $��1q�5�   +   $
��True��5�   +   $
# True��5�   +   $��Center=�5�   +   5�      % 5�      P� 5�      & �@J�IsMouseOver$
' true��6=   . �5�   "   �� $( border��6?    � ��
 �����6S   �� 5�   "   $( border��6@    � ��
 �   �6T   �� 5�   "    � ��
 �   �6?   5�      P� 5�      & � ��$
' true��6;   . �5�   "   �� $( border��6?    � ��
 �����6S   �� 5�   "   $( border��6@    � ��
 �   �6T   5�      5�      5�      5�      5�      5�      
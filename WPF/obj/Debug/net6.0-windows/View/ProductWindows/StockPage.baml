   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF.ViewComponents.UserControlsWPF.ViewComponents.UserControls  5      U/clr-namespace:WPF.ViewComponents.CustomControls!WPF.ViewComponents.CustomControls  5      '    !WPF.View.ProductWindows.StockPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I EUno.UI, Version=255.255.255.255, Culture=neutral, PublicKeyToken=nullR NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null>x,http://schemas.microsoft.com/winfx/2006/xaml       5      Nmc;http://schemas.openxmlformats.org/markup-compatibility/2006       5      Dd2http://schemas.microsoft.com/expression/blend/2008       5      JuserControls-clr-namespace:WPF.ViewComponents.UserControls       5      Fcustom/clr-namespace:WPF.ViewComponents.CustomControls       5      -   5          N�Name$
  root��5       N� Title$ 	StockPage��5       � 	Resources 5         StackPanelStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��5      .�5      ��  � ��$ 2��6)   �� 5       � ��$ 1��6,   �� 5       � ��$ Bottom=�62   �� 5       � ��$ 32��6'   �� 5       �@��Orientation$ 
Horizontal=�6,   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��15 �6   �� 5      �� 5      $��15 �6    � RowDefinitions 5   
   �� 5      $��8 �6   �� 5      $
��auto �6   �� 5       $��40 �6   �� 5!      �� 5"      $��8 �6   .+�5%   
   �� $��1��5&      $
��Left=�5'      $��
30,30,0,15q�5(      #���   5)      .+�5*      2   ,WPF.ViewComponents.UserControls.CustomButton     Title$ Agregar Existencia��5+      	   ImageSource$	 /Resource/Image/plus.png��5.      
   buttonCommand
 5,      �� *
addCommand+   buttonParameter 5-      �� *logic.entity+5.      5/      �� 51   
   $��1��52      $��Right=�53      $��	0,0,30,15q�54      #���   55      .+�56      ��  �� Orientation$ 
Horizontal=�6   .+�57      /   )WPF.ViewComponents.UserControls.SearchBar     	BarHeight$ 30Q�58         BarWidth$	 250Q�59      $��0 0 20 0q�5;         searchBarText 5:      �� *
searchText+ �� Mode$ TwoWay=�5;        5=      $ 	Modificar��5>      $	 /Resource/Image/edit.png��5?        5@      $ Eliminar��5A      $$	 /Resource/Image/remove-red.png��5B      5C      5D      �� 5F   
   $��2��5G      $��1��5H      $��SemiBold"�5I       �� TextAlignment$ Center=�5J      $��Bottom=�5K        StockWindowTitle#���  5L       ! ElementsDataGridTitleFontSize#���  5M      6   0WPF.ViewComponents.CustomControls.LoadingSpinner  5O   
   $��3��5P      $��1��5Q         Diameter$	 100Q�5R         	Thickness$ 5Q�5T         Color
 �   �   	IsLoading 5S      �� *	IsLoading+5U      � 5W   
   $��3��5X      $��1��5Y      y�5Z      �� *	IsLoading+ ' #InverseBooleanToVisibilityConverter �� 	Converter# [ .+�5\      &   System.Windows.Controls.DataGrid  -   5          Name$ elementDataGrid��5]        ElementsDataGrid#���  5_      ��5^      �� *dataGridSource+   Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5b      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *	idStock+  5c      $ Nombre��6)   $	 200 69    6E   �� *name+  5d      $ Descripción��6)   $ * 6>    6H   �� *description+  5e      $ Presentación��6)   $	 120 6?    6K   �� *presentation+  5f      $ Cantidad��6)   $
 auto 6;    6H   �� *
quantity+  5g      $ Precio��6)   $
 auto 69    6F   �� *price+  5h      $ Entrada��6)   $
 auto 6:    6G   �� *	entryDate+  5i      $ 	Caducidad��6)   $
 auto 6<    6I   �� *
expiration+5k      5l      5m      5n      
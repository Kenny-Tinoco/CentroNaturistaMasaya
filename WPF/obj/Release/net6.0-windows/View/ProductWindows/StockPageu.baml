   M S B A M L   `   `   `  ���� O  KMasayaNaturistCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:MasayaNaturistCenter.View.UserControls&MasayaNaturistCenter.View.UserControls  9    3MasayaNaturistCenter.View.ProductWindows.StockPageu   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     MuserControls4clr-namespace:MasayaNaturistCenter.View.UserControls     -     >�Name$
  root�� � 	Resources    DataGridSource �� Source  StackPanelStyle �� 
TargetType �� Property �� Value��%�   &	        &	      ��  �� *	stockList+�� " ��.���  � ��$ 2����  � ��$ 1����  � ��$ Bottom=���  � ��$ 32����  �@��Orientation$ 
Horizontal=�.��� 
������� � ColumnDefinitions �� $��15 ��� �� $��15 � � RowDefinitions �� $��40 ��� $��8 ��� $	��124 ��� $��40 ��� �� $��8 �.+�6   0MasayaNaturistCenter.View.UserControls.PageTitle  $��0��$��0��$��3��   Title$ 
Existencia��	   ImageSource$,	 &/View/Resource/Image/product-black.png���� $
��Left=�$��
30,30,0,15q�#���  .+�9   3MasayaNaturistCenter.View.UserControls.CustomButton  9   3MasayaNaturistCenter.View.UserControls.CustomButton
   CustomButtonClick$
 product_Click��   Title$ Producto��   ImageSource$&  /View/Resource/Image/product.png��  $
 presentation_Click��$ Presetación��$+ %/View/Resource/Image/presentation.png��  $
 addStock_Click��$ Agregar Existencia��$# /View/Resource/Image/plus.png���� $��Right=�$��	0,0,30,15q�#���  .+���  �� Orientation$ 
Horizontal=�.+�6   0MasayaNaturistCenter.View.UserControls.SearchBar  6   0MasayaNaturistCenter.View.UserControls.SearchBar   SearchBarTextChanged$ searchText_TextChanged��   	BarHeight$ 30Q�   BarWidth$	 250Q�   searchBarText �� *
searchText+ �� Mode$ TwoWay=�  $ 	Modificar��$# /View/Resource/Image/edit.png��  $ Eliminar��$) #/View/Resource/Image/remove-red.png���� $��3��$��1��$��SemiBold"�$��Center=�  StockWindowTitle#���   ! ElementsDataGridTitleFontSize#���  &   System.Windows.Controls.DataGrid  -     Name$ elementDataGrid��$��4��$��1��  ElementsDataGrid#���  ����  �� Source# [     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Código��   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *	idStock+  $ Nombre��$	 200	  �� *name+  $ Descripción��$ *	  �� *description+  $ Presentación��$	 120	  �� *presentation+  $ Cantidad��$
 auto	  �� *
quantity+  $ Precio��$
 auto	  �� *price+  $ 	Caducidad��$
 auto	  �� *entryDate.dateString+  $ Entrada��$
 auto	  �� *expiration.dateString+
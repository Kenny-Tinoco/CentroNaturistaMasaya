   M S B A M L   `   `   `  ���� O  KMasayaNaturistCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:MasayaNaturistCenter.UI.VentanaProducto'MasayaNaturistCenter.UI.VentanaProducto  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem ;    5MasayaNaturistCenter.UI.VentanaProducto.pPresentacion   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Glocal5clr-namespace:MasayaNaturistCenter.UI.VentanaProducto     9System&clr-namespace:System;assembly=mscorlib       N� 
Background
  ���� .���  � ColumnDefinitions �� $��15 ��� $��80 ��� �� $��80 ��� $��15 � � RowDefinitions �� $��40 ��� $��8 ��� $	��124 ��� �� $��40 ��� $��8 �.+��� -    ��Name$ btnAtras��$��1��$��3��$��4��$
��Left=�$��30��$
��auto��$
��10,0q�
������ 
������    styleButtonVolver#���   .����  �� Orientation$ 
Horizontal=�.+��� $L��F/MasayaNaturistCenter;component/Resource/Drawable/Image/back-black.png���� $��Volver��
���   �$��Center=�  fontSizeBotonVolver#���  $��0,0,8,0q��� $��0��$��0��$��5��
���   �$	��0.3q� �� CornerRadius$ 6��._��� $
��auto��$ 
Horizontal=�.+���   margenITitulo#���  $T��N/MasayaNaturistCenter;component/Resource/Drawable/Image/presentacion-negro.png���� $��Presentación��$��Center=�
���   �  fontSizeTituloVentana#���  $��DemiBold"��� -   $ 
btnAgregar��$��2��$��2��$��Bottom=�$
��Left=�$��32��$��
30,30,0,15q�  styleButtonVentanaProducto#���  .���� $ 
Horizontal=�.+��� $F��@/MasayaNaturistCenter;component/Resource/Drawable/Image/plus.png��$��30��$
��auto��$��1,1,3,1q�$��Center=��� $��Agregar Presentación��$��0,0,6,0q�$��16(�
�������$��Center=��� $��2��$��2��$��Right=�$��Bottom=�$ 
Horizontal=�$��	0,0,30,15q�.+��� $	��250��$��30��
�������$ 7��$	��0.5q�
���   �._��� $
��Left=�$��Center=�$ 
Horizontal=�.+��� $��20��$J��D/MasayaNaturistCenter;component/Resource/Drawable/Image/busqueda.png���� -    ��Name$ txtBusqueda��$��Buscar��$	��228��$��18(�$��Center=�
���   �
������ $��0q��� $��30,0,0,0q�$ 
Horizontal=�.+��� -   $ btnModificar��$��Center=�$
��Left=�$��0,0,10,0q�$��32��#���  ${�false��.���� $ 
Horizontal=�.+��� $F��@/MasayaNaturistCenter;component/Resource/Drawable/Image/edit.png��$��30��$
��auto��$��1,1,3,1q�$��Center=��� $��	Modificar��$��16(�
�������$��0,0,6,0q�$��Center=��� -   $ btnEliminar��$��Center=�$��Right=�#���  $��32��${�False������ *%#presentacionSelected.idPresentacion+���� *DeleteCommand+.���� $ 
Horizontal=�.+��� $O��I/MasayaNaturistCenter;component/Resource/Drawable/Image/eliminar-rojo.png��$��30��$
��auto��$��1,1,3,1q�$��Center=��� $��Eliminar��$��16(�
�������$��0,0,6,0q�$��Center=��� $��3��$��2��  
tituloVPPs#���    fontSizeTituloTabla#���  $��Center=�$	��Top=�$��SemiBold"�$��0,5,0,0q�&   System.Windows.Controls.DataGrid  -     Name$ dgPresentacion��$	��400��$��3��$��2��$��30,40,30,40q�   AutoGenerateColumns$ False��	   
IsReadOnly$
	 True��
�������
   CanUserAddRows$
 False��   CanUserResizeColumns$
 true��   CanUserResizeRows$ false��   CanUserSortColumns$ False��   HeadersVisibility$ Column=�   HorizontalGridLinesBrush
 �   � , (styleDataGridColumnHeaderVentanaProducto   ColumnHeaderStyle# �   # styleDataGridRowVentanaProducto   RowStyle# �     SelectionUnit$ FullRow=����� **(presentacionRecord.registrosPresentacion+ �� SelectedItem �� *presentacionSelected+ �� Mode$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *idPresentacion+  $ Nombre��$ *  �� *Nombre+ � 	Resources  	 height_width-Image 
 height_width-Button��%I   &		       &	
      &	      X�50Q�X�140Q�u�20,2,5,2q�
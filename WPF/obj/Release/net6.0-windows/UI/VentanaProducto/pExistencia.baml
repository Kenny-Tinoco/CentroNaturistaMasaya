   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   MasayaNaturistCenter9   3MasayaNaturistCenter.UI.VentanaProducto.pExistencia   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9System&clr-namespace:System;assembly=mscorlib       N� Title$  pExistencia��.���  � ColumnDefinitions �� $��15 ��� �� $��15 � � RowDefinitions �� $��40 ��� $��8 ��� $	��124 ��� �� $��8 �.+��� $��0��$��0��$��3��
���   �$	��0.3q� �� CornerRadius$ 6��._��� $
��auto�� �� Orientation$ 
Horizontal=�.+���    margenITitulo#���   $1��+/Resource/Drawable/Image/producto-negro.png���� $��Producto��$��Center=�
���   �  fontSizeTituloVentana#���  $��DemiBold"��� $��2��$��1��$��Bottom=�$
��Left=�$ 
Horizontal=�$��32��$��
30,30,0,15q�.+��� -    ��Name$ btnProducto��$��Center=�$��0,0,30,0q�  styleButtonVentanaProducto#���  .���� $ 
Horizontal=�.+��� $K��E/CentroNaturistaMasaya;component/Resource/Drawable/Image/producto.png��$��30��$
��auto��$��1,1,3,1q�$��Center=��� $��	Productos��$��0,0,6,0q�$��16(�
�������$��Center=��� -   $ btnPresentacion��$��Center=�$��0,0,30,0q�#���  .���� $ 
Horizontal=�.+��� $O��I/CentroNaturistaMasaya;component/Resource/Drawable/Image/presentacion.png��$��30��$
��auto��$��1,1,3,1q�$��Center=��� $��Presentaciones��$��0,0,6,0q�$��16(�
�������$��Center=��� -   $ btnAgregarExistencia��$��Center=�#���  .���� $ 
Horizontal=�.+��� $G��A/CentroNaturistaMasaya;component/Resource/Drawable/Image/plus.png��$��30��$
��auto��$��1,1,3,1q�$��Center=��� $��Agregar Existencia��$��0,0,6,0q�$��16(�
�������$��Center=��� $��2��$��1��$��Right=�$��Bottom=�$ 
Horizontal=�$��	0,0,30,15q�.+��� $	��250��$��30��
�������$ 7��$	��0.5q�
���   �._��� $
��Left=�$��Center=�$ 
Horizontal=�.+��� $��20��$K��E/CentroNaturistaMasaya;component/Resource/Drawable/Image/busqueda.png���� -    ��Name$ txtBusqueda��$��Buscar��$	��228��$��18(�$��Center=�
���   �
������ $��0q��� $��30,0,0,0q�$ 
Horizontal=�.+��� -   $ btnModificar��$��Center=�$
��Left=�$��0,0,10,0q�$��32��#���  .���� $ 
Horizontal=�.+��� $G��A/CentroNaturistaMasaya;component/Resource/Drawable/Image/edit.png��$��30��$
��auto��$��1,1,3,1q�$��Center=��� $��	Modificar��$��16(�
�������$��0,0,6,0q�$��Center=��� -   $ btnEliminar��$��Center=�$��Right=�#���  $��32��.���� $ 
Horizontal=�.+��� $P��J/CentroNaturistaMasaya;component/Resource/Drawable/Image/eliminar-rojo.png��$��30��$
��auto��$��1,1,3,1q�$��Center=��� $��Eliminar��$��16(�
�������$��0,0,6,0q�$��Center=��� $��3��$��1��  	tituloVPE#���    fontSizeTituloTabla#���  $��Center=�$��SemiBold"�$��0,5,0,0q�&   System.Windows.Controls.DataGrid  -     Name$ 
dgProducto��$��3��$��1��  ElementsDataGrid#���  ���� *	stockList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Cód.��
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 45 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	idStock+  $	 Nombre��$	
 200  �� *name+  $	 Descripción��$	
 300  �� *description+  $	 Presentación��$	
 120  �� *presentation+  $	 Cantidad��$
 70  �� *
quantity+  $	 Precio��$
 60  �� *price+  $	 	Caducidad��$
 *  �� *entryDate.dateString+  $	 
F. Entrada��$
 *  �� *expiration.dateString+ � 	Resources   height_width-Image  height_width-Button��%I   &	       &	      &	       X�50Q�X�140Q�u�20,2,5,2q�
   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   MasayaNaturistCenter?   9MasayaNaturistCenter.UI.VentanaProducto.agregarExistencia   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9System&clr-namespace:System;assembly=mscorlib     $	��600��  � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�.���� 
������    colorPrimary#���   $��3q� �� CornerRadius$ 	10 10 2 2��._�� $
��auto��  colorBlancoFondo#���   � RowDefinitions �� $��39 ��� $��10 ��� �� $��40 ��� $��10 � � ColumnDefinitions �� $��8 ��� �� $��8 �.+�� $��0��$��1��$��0��$��3��#���   .+���  �� Orientation$ 
Horizontal=�$��18 10 10 10q�.+���   width-heigthSize#���  $K��E/CentroNaturistaMasaya;component/Resource/Drawable/Image/producto.png���� -   $��txtTituloVentana��$��5 0 0 0q�  fontSizeVEmergente#���  $��SemiBold"�$��Center=�
��������� -    ��Name$ btnSalir��$��Right=�$��Center=�$��0,0,10,0q�  styleButtonSalir#���  .���� $H��B/CentroNaturistaMasaya;component/Resource/Drawable/Image/salir.png��$��30��$��30��� $��1��$��2��$��Center=� �� $��5 ��� $
��auto ��� $��12 ��� $
��auto ��� $��12 ��� $
��auto ��� $��5 �.+��� $��1��$��Producto��$
��16.5(�
���   �$��SemiBold"�.��� $��5q� �� $
��auto ��� $��* ��� $
��auto � �� �� $��20 ��� .+��� $��0��$��0��$ 
Horizontal=�.+��� $��	Código: ��
���   �  fontSizeTextBlock#���  $��Normal"�$��Center=��� -   $��
cbProducto�� �� Text$  ��
���   �#���  $��Center=�$��70��$��Normal"�$��Center=����� * productoRecord.nombresProducto+	 �� SelectedIndex	 �� *productoRecord.idProducto+�� $��2��$��0��$ 
Horizontal=�.+��� $��Nombre:��
���   �#���  $��Normal"�$��Center=��� -   
 ��Name$
 nombreProducto��
���   �
�������  fontSizeTextBox#���  $��Normal"� �� TextAlignment$ Center=�$��Center=�$	��280��$��5 0 0 0q����� *productoRecord.Nombre+ �� Mode$ TwoWay=��� $��0��$��3��$��2��.+��� $��Descripción:��
���   �#���  $��Normal"��� -   $��descripcionProducto��
�������
���   �#���  $��Disabled=�$
��Auto=�$
��Wrap=�$��Normal"�$��60��$��2q�����  �� Path$  productoRecord.Descripcion�$ TwoWay=��� $��3��$��Presentación��#���    styleGroupBox#���  $��SemiBold"�.��� $��5q� �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��$ 
Horizontal=�.+��� $��Código:��
���   �#���  $��Normal"�$ Center=��� -   $��cbPresentacion��$  ��
���   �#���  $��Center=�$��Normal"�$��70��$��Center=�$��5 0 0 0q����� *(&presentacionRecord.nombresPresentacion+	 �� *" presentacionRecord.idPesentacion+�� $��2��$ 
Horizontal=�$��Right=�.+��� $��Nombre:��
���   �#���  $��Normal"�$��Center=��� -   $��nombrePresentacion��$��Normal"�
���   �
�������$	��120��$ Center=�$��Center=�#���  $��5 0 0 0q����� $ presentacionRecord.Nombre�$ TwoWay=��� $��5��$��
Existencia��#���  #���  $��SemiBold"�.��� $��5q� �� $
��auto ��� $��* ��� $
��auto � �� �� $��20 ��� .+��� $��0��$��0��$ 
Horizontal=�.+��� $��Precio:��
���   �#���  $��Normal"�$��0 0 5 0q�$��Center=��� -    ��Name$ precio��
���   �$��Normal"�#���  $��Stretch=�$��Center=�$��98���� $��0��$��2��$ 
Horizontal=�.+��� $��	Cantidad:��
���   �#���  $��Normal"�$��Center=��� $ 
Horizontal=�$��Center=�
�������$��5 0 0 0q�.+��� -	   $ SpinBox_Text��$��0��${�false��
���   �#���  $��Normal"�$��Center=�$��50��
�������$��0q�$��Center=��� -
    ��Name$ SpinBox�� �� Orientation$ Vertical=� J� RenderTransformOrigin$ 0.5,0.5&�$��24��$��Center=�z���  �� ScaleY$ -1Q��� $��2��$��0��$ 
Horizontal=�.+��� $��F. Entrada:��
���   �#���  $��Normal"�$��Center=�(  "System.Windows.Controls.DatePicker  -   $��fechaEntrada��#���  
���   �$��Normal"�  styleDatePicker#���  $��5,0,0,1q�$��Center=�$	��195���� $��2��$��2��$ 
Horizontal=�.+��� $��
Caducidad:��
���   �#���  $��Normal"�$��Center=�  -   $��	caducidad��#���  
���   �$��Normal"�#���  $��Center=�$��5 0 0 0q��� -   $ 
btnGuardar��$��3��$��1��$��Center=�$��Center=� 	 styleButtonVentanaProducto#��� 	 ${�False������ *SaveCommand+.���� $ 
Horizontal=�.+��� $��30��$J��D/CentroNaturistaMasaya;component/Resource/Drawable/Image/guardar.png���� $��Guardar��$��8,0,8,0q�
�������#���  $��SemiBold"�$��Center=��� -   $
 
txtMensaje��$y�Hidden=�$��DemiBold"�$��4��$��1��$��Bottom=�$
��Left=� 
 colorMensajeVA#��� 
 $
��13.5(� � 	Resources ��%   &	       X�30Q�
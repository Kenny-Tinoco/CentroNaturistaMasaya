   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   MasayaNaturistCenterA   ;MasayaNaturistCenter.UI.VentanaProducto.agregarPresentacion   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9System&clr-namespace:System;assembly=mscorlib       � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�$	��280��$	��420��.���� 
������    colorPrimary#���   $��3q� �� CornerRadius$ 	10 10 2 2��._��   colorBlancoFondo#���   � RowDefinitions �� $��39 ��� $��11 ��� $
��auto ��� �� $��40 ��� $��10 � � ColumnDefinitions �� $��8 ��� �� $��8 �.+�� $��0��$��2��$��0��$��3��#���   .+���  �� Orientation$ 
Horizontal=�$��18 10 10 10q�.+���   width-heigthSize#���  $O��I/CentroNaturistaMasaya;component/Resource/Drawable/Image/presentacion.png���� -   $��txtTituloVentana��$��5 0 0 0q�  fontSizeVEmergente#���  $��SemiBold"�$��Center=�
��������� -    ��Name$ btnSalir��$��Right=�$��Center=�$��0,0,10,0q�  styleButtonSalir#���  .���� $H��B/CentroNaturistaMasaya;component/Resource/Drawable/Image/salir.png��$��30��$��30��� $��1��$��2��$��2��#���  .+��� $��Center=�.+��� $��Center=�.+��� $��Nombre:��
���   �  fontSizeTextBlock#���  $��SemiBold"��� -   $��	txtNombre��$��28��$	��370��$��0,5,0,0q�
���   �$��Center=�  fontSizeTextBox#���  ����  �� Path$ presentacionRecord.Nombre�	 �� Mode$	 TwoWay=��� -   $ 
btnGuardar��$��4��$��1��$��Center=�$��Center=�  styleButtonVentanaProducto#���  ${�False������ *SaveCommand+.���� $ 
Horizontal=�.+��� $��30��$J��D/CentroNaturistaMasaya;component/Resource/Drawable/Image/guardar.png���� $��Guardar��$��8,0,8,0q�
�������#���  $��SemiBold"�$��Center=��� -   
 ��Name$
 
txtMensaje��$y�Hidden=�$��DemiBold"�$��4��$��1��$��Bottom=�$
��Left=�  colorMensajeVA#���  $
��13.5(� � 	Resources ��%   &	       X�30Q�
   M S B A M L   `   `   `  ���� O  KMasayaNaturistCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:MasayaNaturistCenter.View.UserControls&MasayaNaturistCenter.View.UserControls  9    3MasayaNaturistCenter.View.ProductWindows.StockPopup   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     MuserControls4clr-namespace:MasayaNaturistCenter.View.UserControls     $	��600��  � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�.��� .+�2   ,MasayaNaturistCenter.View.UserControls.Popup  2   ,MasayaNaturistCenter.View.UserControls.Popup   	exitClick$ 
exit_Click��   titleBar$ Agregar Existencia��   iconBar$&  /View/Resource/Image/product.png��   popupContent �  � RowDefinitions �� $��5 ��� $
��auto ��� $��12 ��� $
��auto ��� $��12 ��� $
��auto ��� $��5 �.+��� $��1��$��Producto��   GroupBoxStyle#���   .��� $��5q� � ColumnDefinitions �� $
��auto ��� $��* ��� $
��auto � �� �� $��20 ��� .+��� $��0��$��0��	 �� Orientation$	 
Horizontal=�.+��� $��	Código: ��  TextBlockStyle#���  $��Center=��� 
 �� Text$
  ��  ComboBoxStyle#���  �� $��2��$��0��$	 
Horizontal=�.+��� $��Nombre: ��#���  $��Center=��� #���  
������� �� TextAlignment$ Center=�$��Center=�$	��280��$��5 0 0 0q����� *productoRecord.Nombre+ �� Mode$ TwoWay=��� $��0��$��3��$��2��.+��� $��Descripción:��#���  �� 
�������#���  $��Disabled=�$
��Auto=�$
��Wrap=�$��60��$��2q�����  �� Path$  productoRecord.Descripcion�$ TwoWay=��� $��3��$��Presentación��#���   .��� $��5q� �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��$	 
Horizontal=�.+��� $��	Código: ��#���  $��Center=��� $
  ��#���  �� $��2��$	 
Horizontal=�$��Right=�.+��� $��Nombre: ��#���  $��Center=��� 
�������$	��120��$ Center=�$��Center=�#���  $��5 0 0 0q��� $��5��$��
Existencia��#���   .��� $��5q� �� $
��auto ��� $��* ��� $
��auto � �� �� $��20 ��� .+��� $��0��$��0��$	 
Horizontal=�.+��� $��Precio: ��#���  $��0 0 5 0q�$��Center=��� 
���   �$��Normal"�  fontSizeTextBlock#���  $��Stretch=�$��Center=�$��98������ *stock.price+$ TwoWay=��� $��0��$��2��$	 
Horizontal=�.+��� $��
Cantidad: ��#���  $��Center=�4   .MasayaNaturistCenter.View.UserControls.SpinBox     value �� *stock.quantity+$ TwoWay=��� $��2��$��0��$	 
Horizontal=�$��Right=�.+��� $��	Entrada: ��#���  $��Center=�(  "System.Windows.Controls.DatePicker    DatePickerStyle#���     Text �� *stock.entryDate+$ TwoWay=��� $��2��$��2��$	 
Horizontal=�$��Right=�.+��� $��Caducidad: ��#���  $��Center=�  #���   �� *stock.expiration+$ TwoWay=� � 	Resources  �� 
TargetType �� Property �� Value��%1  &	        &	 Y     &	 �     &	 h    �� " ��.���  � ��$
 16.5(���  � ��
 �   ���  � ��$ SemiBold"��� " ��.���  � ��$ 17(���  � ��
 �   ���  � ��$ Normal"��� " ��.���  � ��$ 17(���  � ��
 �   ���  � ��$ Normal"���  � ��$ 70����  � ��$ 5 0 0 0q���  � ��$ Center=���  � ��$ Center=��� "  .���  � ��$ 17(���  � ��
 �   ���  � ��$ Normal"���  � ��$ 5 0 0 1q���  � ��$	 150����  � ��$ Center=�
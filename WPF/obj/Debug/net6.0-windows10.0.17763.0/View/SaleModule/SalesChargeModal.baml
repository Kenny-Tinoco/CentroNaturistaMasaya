   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      *    $WPF.View.SaleModule.SalesChargeModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      .��5
      -   'WPF.ViewsComponent.CustomControls.Popup      IconBar$  /Resource/Image/sale.png��5         TitleBar 5      �� *
titleBar+   ExitCommand 5      �� *exitCommand+.��5   
   � $	��240��6   $	��5 0q�5       � RowDefinitions 5      �� 5      $��5 �6    �� 5      $
��auto �6    �� 5      $��5 �6    .+�5      � $��1��6    5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��0��6   .+�5      �� $��Total a pagar:��6    $��SemiBold"�5           TextBlockStyle#���   5!       $
��Left=�5"       �� 5#      
���   � �� CornerRadius$ 3��5$      $	��0.6q�5%       �� Padding$	 5 0q�5&      ._�5'      �� #���   5(   $   $��Right=�5)   $   ��5'   $   �� *total+ �� StringFormat$ 0.0 córdobas��5)   $   5*      5+      �� 5-      $��1��6   $��	0 20 0 10q�5.      .+�5/      �� $��Monto de pago:��6    $��SemiBold"�50       #���   51       $
��Left=�52       �� 53      
���   �$ 3��54      $	��0.6q�55      $	 1 0q�56      ._�57      �� $��17(�58   "   
���   �  TextBoxStyle#���  5:   "   $��Right=�5;   "   ��57   "   �� *	payment+ �� UpdateSourceTrigger$ PropertyChanged=�$
 0.00��5;   "   5<      �� 5=      $��	Pago neto��6   $��15(�5>      $��0 4 0 0q�5?      $��Right=�5@      ��5A      �� *netPaymentCommand+��5B      ��  �� Path$ 	IsChecked�	 �� RelativeSource	 �� *Self+5D      �� 5F      $��2��6   .+�5G      �� $��Vuelto:��6    $��SemiBold"�5H       #���   5I       $
��Left=�5J       �� 5K      
���   �$ 3��5L      $	��0.6q�5M      $	 1 0q�5N      ._�5O      �� $��17(�5P   "   
 �� 
IsReadOnly$

 True��5Q   "   
������ 
���   �$��0 0 3 0q�5T   "   #���  5U   "   $��Right=�5V   "   ��5O   "   �� *change+$ 0.0 córdobas��5V   "   5W      5X      �� 5Z      $��3��6   $��Guardar venta��5\      $	��5 1q�5]      $��Center=�5^      $��0 20 0 0q�5_      $��SemiBold"�5`      $��15(�5a      ��5[      �� *
saveSale+{�5b      �� *	canCreate+5c      5d      5f       � 	Resources 5g       �� 
TargetType �� Property �� Value � ToolTip��%�  &	        �� 5h   
   " ��5i      .�5j      ��  � ��$ 17(�6)   �� 5k       � ��
 �   �6+   �� 5l       � ��$ Normal"�6+   �� 5m       �@=�ErrorTemplate 5n      �� 5o      .R�5p      ]� $
��true��6$   .+�5q      �� $��customAdorner��68   $��Center=�6M   .v�5r   "   �� ���#2196F3$��1q�6?   5s      �� 5t      ���#2196F3$��Right=�5u   %   $��18��5v   %   $��18��5w   %   $��Right=�5x   %   $ 10��5y   %    5{   "   _� 5|   &   .��5}   *   �� $��16(�6R   
���   ���64   �� *ErrorContent+6`   5~   '   ._�5�   "   �� $��!��6,   $��center=�5�   ,   $��center=�5�   ,   $
��Bold"�5�   ,   
�������6>   5�      5�      5�      5�      5�      5�      5�      
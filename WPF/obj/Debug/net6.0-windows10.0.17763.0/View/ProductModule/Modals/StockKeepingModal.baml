   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      Q-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5      .    (WPF.View.ProductModule.StockKeepingModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      FuserControls-clr-namespace:WPF.ViewsComponent.UserControls     5      .��5      -   'WPF.ViewsComponent.CustomControls.Popup      IconBar$!  /Resource/Image/product.png��5         TitleBar 5      �� *
titleBar+   ExitCommand 5      �� *exitCommand+.��5      � $	��5 0q�6	    � RowDefinitions 5      �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $��5 �6   .+�5      � $��1��6
   $	��290��5      $	��250��5       5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5"      ]� $��0��6   .+�5#      ��    TextBlockStyle#���   6   �� 5$      $�Código:��6    �� 5%      $��SemiBold"�5&      �5%      �� *	idStock+ �� Mode$ OneWay=� �� StringFormat$	 000��5&      5'      �� 5(      #���   6   $��Right=�5)      �� 5*      $�Cantidad actual: ��6    �� 5+      $��SemiBold"�5,      �5+      �� *currentQuantity+$ OneWay=�5,      5-      5.      �� 50      $��2��6   $
��0 10q�51      .+�52      �� $��Nueva cantidad: ��6   #���   53      $��Center=�54      ]� 56      $��Center=�6   .+�58      -   'WPF.ViewsComponent.UserControls.SpinBox  $��70��59      $��Center=�5:      $��0 0 40 0q�5;        ToolTipStyle#���  5<         value 58      �� *
quantity+$ TwoWay=�5<      �� 5>      .+�5?   	   	� $��Entrada��6    	� 	GroupName$ concept��5@      $��16(�5A      $��Center=�5B       d� 	IsChecked 5C      �� *	concept+	� 5D   	   $��Salida��6   $��16(�5E      $��Center=�5F      $ concept��5G      5H   	   5I      5J      � 5L      $��4��6    5M      �� 5N      $
��auto �6   �� 5O      .+�5Q      �� $��0��6   $��	Concepto:��5R      #���   5S      $��0 0 0 8q�5T      �� 5V      $��0��6   $��Right=�5W   
   $��15(�5Y   
   $��Center=�5Z   
   $	��160��5[   
   ��5X   
   �� *descriptions+	 �� Text	 5\   
   �� *selectedDescription+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5^      $��1��6   $��17(�5`   	     TextBoxStyle#���  5a   	   $��Normal"�5b   	   $	��Top=�5c   	   $��Disabled=�5d   	   $
��Auto=�5e   	    �� TextWrapping$
 Wrap=�5f   	    �� TextAlignment$ Justify=�5g   	   ��5_   	   �� *description+$
 PropertyChanged=�5g   	   5h      �� 5j      $��Guardar��6   $��5��5k      $��0 10 0 0q�5l      $��Center=�5m      $��Normal"�5n        CustomButtonStyle#���  5p      
�������$��15(�5r      $��75��5s      ��5o      �� *updateQuantityComand+{�5t      �� *	canCreate+5v      �� 5x      $��1��6   $��2��5y   	   $��12 0 0 0q�5z   	   $��Bottom=�5}   	   $��14(�5~   	   
����  ���5{   	   �� *statusMessage+y�5|   	   �� *hasStatusMessage+   BooleanToVisibilityConverter �� 	Converter# [ 5   	   5�      5�       � 	Resources 5�       �� 
TargetType �� Property �� Value��%�   &	        �� 5�      " ��5�      .�5�      ��  � ��$ 17(�5�      �� 5�       � ��
 �   �5�      �� 5�       � ��$ Normal"�5�      5�      5�      5�      
   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF.ViewComponents.UserControlsWPF.ViewComponents.UserControls  5      *    $WPF.View.ProductWindows.ProductModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      FuserControls-clr-namespace:WPF.ViewComponents.UserControls     5      .��5      � .+�5	   
   +   %WPF.ViewComponents.UserControls.Popup      iconBar$!  /Resource/Image/product.png��5         titleBar 5
      �� *
titleBar+   buttonExitCommand 5      �� *exitCommand+   popupContent 5      � 5       � RowDefinitions 5      �� 5      $��5 �6(   �� 5      $
��auto �6(   �� 5      $��5 �6(   .+�5      � $��5q�6   $��1��5      $	��350��5      $	��200��5       � ColumnDefinitions 5      �� 5      $
��auto �6/   �� 5      $��20 �6/   �� 5      $��* �6/    5       �� 5!      $
��auto �6,   �� 5"      $��* �6,   �� 5#      $��20 �6,   �� 5$      $
��auto �6,   .+�5'      �� $��0��5(   !   .+�5)      �� $��Código��5*   %      TextBlockStyle#���   5+   %   �� 5,      $��17(�5.   %    �� TextAlignment$ Center=�5/   %   ${�False��50   %   
������ ��5-   %   �� *logic.entity.idProduct+ �� Mode$ TwoWay=�51   %   52      �� 54      $��2��55   !   .+�56      �� $��Nombre��57   %   #���   58   %   �� 5:      $��17(�5<   %   $��Normal"�5=   %   $ Center=�5>   %   ��5;   %   �� *name+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�5>   %   5?      � 5A      $��1��5B      $��0��5C      $��3��5D      $��0,10,0,0q�5E       5F      �� 5G   "   $
��auto �60   �� 5H   "   .+�5J      �� $��0��5K   !   $��Descripción��5L   !   #���   5M   !   $��0 0 0 8q�5N   !   �� 5P      $��1��5Q   !   $��17(�5S   !   $��Normal"�5T   !   $	��Top=�5U   !   $��Disabled=�5V   !   $
��Auto=�5W   !   	 �� TextWrapping$
	 Wrap=�5X   !   $ Justify=�5Y   !   ��5R   !   �� *description+$ PropertyChanged=�$ TwoWay=�5Y   !   5Z      �� 5\      $��3��5]   !   $��0��5^   !   $��3��5_   !   
 �� Orientation$
 
Horizontal=�5`   !   $��Center=�5a   !   .+�5c      �� $��Guardar��5d   !   $��Normal"�5e   !     CustomButtonStyle#���  5h   !   
�������$��15(�5j   !   $��75��5k   !   ��5f   !   �� *saveCommand+��5g   !   �� *
isEditable+{�5l   !   �� *	canCreate+5m      5o      5p      5t      5u       � 	Resources 5v        GroupBoxStyle �� 
TargetType �� Property �� Value��%L  &	       &	  �     �� 5w   
   " ��5x      .�5y      ��  � ��$
 16.5(�6)   �� 5z       � ��
 �   �6,   �� 5{       � ��$ SemiBold"�6+   5|      �� 5}   
   " ��5~      .�5      ��  � ��$ 17(�6)   �� 5�       � ��
 �   �6+   �� 5�       � ��$ Normal"�6+   5�      5�      5�      
   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      )    #WPF.View.ProductModule.ProductModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      .��5      -   'WPF.ViewsComponent.CustomControls.Popup      IconBar$!  /Resource/Image/product.png��5	         TitleBar 5      �� *
titleBar+   ExitCommand 5
      �� *exitCommand+.��5      �  � RowDefinitions 5      �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $��5 �6   .+�5      � $��12q�6
   $��1��5      $	��350��5      $	��200��5       � ColumnDefinitions 5      �� 5      $
��auto �6   �� 5      $��20 �6   �� 5      $��* �6    5      �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   �� 5       $
��auto �6   .+�5#      �� $��0��6   .+�5$      �� $��Código��6      TextBlockStyle#���   5%      �� 5&      $��17(�5'   	    �� TextAlignment$ Center=�5(   	   ${�False��5)   	   
������ ��5&      �� *entity.IdProduct+5*   	   5+      �� 5-      $��2��6   .+�5.      �� $��Nombre��6   #���   5/      �� 51      $��17(�52   	   $��Normal"�53   	     TextBoxStyle#���  54   	   $ Center=�55   	   ��51      �� *name+ �� UpdateSourceTrigger$ PropertyChanged=�55   	   56      � 58      $��1��6   $��0��59      $��3��5:      $��0,10,0,0q�5;       5<      �� 5=      $
��auto �6   �� 5>      .+�5@      �� $��0��6   $��Descripción��5A      #���   5B      $��0 0 0 8q�5C      �� 5E      $��1��6   $��17(�5G   	   #���  5H   	   $��Normal"�5I   	   $	��Top=�5J   	   $��Disabled=�5K   	   $
��Auto=�5L   	    �� TextWrapping$
 Wrap=�5M   	   $ Justify=�5N   	   ��5F   	   �� *description+$ PropertyChanged=�5N   	   5O      ]� 5Q      $��3��6   $��0��5R   
   $��3��5S   
   $��Center=�5T   
   .+�5V      �� $��Guardar��6   $��Normal"�5W        CustomButtonStyle#���  5Z      
�������$��15(�5\      $��75��5]      ��5X      �� *saveCommand+��5Y      �� *
isEditable+{�5^      �� *	canCreate+�� 5_      $��30 0 0 0q�6   $��Eliminar��5`      ���#F44336  DeleteButtonStyle#���  5c      ��5a      �� *deleteCommand+y�5d      �� *
isEditable+   BooleanToVisibilityConverter �� 	Converter# [ 5e      5f      �� 5h      $��1��6   $��2��5i   	   $��12 0 0 0q�5j   	   $��Bottom=�5m   	   $��14(�5n   	   
����  ���5k   	   �� *statusMessage+y�5l   	   �� *hasStatusMessage+# [ 5o   	   5p      5r      	 � 	Resources	 5s        GroupBoxStyle
 �� 
TargetType �� Property �� Value��%d  &	       &	  �     �� 5t      "
 ��5u      .�5v      ��  � ��$
 16.5(�5w      �� 5x       � ��
 �   �5y      �� 5z       � ��$ SemiBold"�5{      5|      �� 5}      "
 ��5~      .�5      ��  � ��$ 17(�5�      �� 5�       � ��
 �   �5�      �� 5�       � ��$ Normal"�5�      5�      5�      5�      
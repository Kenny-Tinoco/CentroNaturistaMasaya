   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPF.View.EmployeeModuleWPF.View.EmployeeModule  5      U/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      +    %WPF.View.EmployeeModule.EmployeeModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WPF.View.EmployeeModule     5      JcustomControls/clr-namespace:WPF.ViewsComponent.CustomControls     5      .��5   
   -   'WPF.ViewsComponent.CustomControls.Popup      IconBar$"  /Resource/Image/employee.png��5         TitleBar 5      �� *
titleBar+   ExitCommand 5      �� *exitCommand+.��5      �  � RowDefinitions 5      �� 5      $��5 �6$   �� 5      $
��auto �6$   �� 5      $��5 �6$   .+�5      � $��10q�6   $��1��5      $	��350��5       � ColumnDefinitions 5      �� 5      $
��auto �6+   �� 5      $��20 �6+   �� 5      $��* �6+    5       �� 5!      $
��auto �6(   �� 5"      $��10 �6(   �� 5#      $
��auto �6(   �� 5$      $��10 �6(   �� 5%      $
��auto �6(   �� 5&      $��10 �6(   �� 5'      $��* �6(   �� 5(      $��20 �6(   �� 5)      $
��auto �6(   .+�5-      �� $��0��6    $��0��5.      $��	Código: ��5/   %      TextBlockStyle#���   50   %   �� 51      $��0��6   $��2��52      $��70��53      $
��Left=�54      $��17(�56   %    �� TextAlignment$ Center=�57   %   ${�False��58   %   
������ ��55   %   �� *entity.IdEmployee+59   %   �� 5<      $��Nombres:��6$   $��2��5=   $   $��0��5>      #���   5?   (   �� 5A      $��17(�5B   &   $��Normal"�5C   &   $��2��5D   "   $��2��5E        TextBoxStyle#���  5F   &   $
 Left=�5G   &   ��5A   "   �� *name+ �� UpdateSourceTrigger$ PropertyChanged=�5G   &   �� 5I      $��
Apellidos:��6$   $��4��66   $��0��5J      #���   5K   (   �� 5M      $��17(�5N   &   $��Normal"�5O   &   $��4��5P   "   $��2��5Q      #���  5R   &   $
 Left=�5S   &   ��5M   "   �� *
lastName+$ PropertyChanged=�5S   &   � 5V      $��6��6   $��0��5W      $��3��5X      $	��105��5Y       5Z      �� 5[      $
��auto �6,   �� 5\      .+�5^      �� $��0��5_   !   $��Dirección:��5`   !   #���   5a   !   $��0 0 0 8q�5b   !   �� 5d      $��1��5e   !   $��17(�5g   !   #���  5h   !   $��Normal"�5i   !   $	��Top=�5j   !   $��Disabled=�5k   !   $
��Auto=�5l   !    �� TextWrapping$
 Wrap=�5m   !   $ Justify=�5n   !   ��5f   !   �� *	address+$ PropertyChanged=�5n   !   5o      ]� 5q      $��8��5r   !   $��0��5s   !   $��3��5t   !   $��Center=�5u      .+�5w      �� $��Guardar��5x   !   $��Normal"�5y   !     CustomButtonStyle#���  5|   !   
�������$��15(�5~   !   $��75��5   !   ��5z   !   �� *saveCommand+��5{   !   �� *
isEditable+{�5�   !   �� *	canCreate+�� 5�      $��30 0 0 0q�5�   %   $��Eliminar��5�   %   ���#F44336  DeleteButtonStyle#���  5�   %   ��5�   %   �� *deleteCommand+y�5�   %   �� *
isEditable+   BooleanToVisibilityConverter �� 	Converter# [ 5�      5�      �� 5�      $��1��5�      $��2��5�      $��12 0 0 0q�5�      $��Bottom=�5�      $��14(�5�      
����  ���5�      �� *statusMessage+y�5�      �� *hasStatusMessage+# [ 5�      5�      5�      	 � 	Resources	 5�        GroupBoxStyle
 �� 
TargetType �� Property �� Value��%L  &	       &	  �     �� 5�   
   "
 ��5�      .�5�      ��  � ��$
 16.5(�6)   �� 5�       � ��
 �   �6,   �� 5�       � ��$ SemiBold"�6+   5�      �� 5�   
   "
 ��5�      .�5�      ��  � ��$ 17(�6)   �� 5�       � ��
 �   �6+   �� 5�       � ��$ Normal"�6+   5�      5�      5�      
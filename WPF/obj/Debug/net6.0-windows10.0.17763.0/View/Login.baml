   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      Q-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5          WPF.View.Login   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      JcustomControls/clr-namespace:WPF.ViewsComponent.CustomControls     5      Fusercontrols-clr-namespace:WPF.ViewsComponent.UserControls     5      .��5
      -   'WPF.ViewsComponent.CustomControls.Popup      IconBar$"  /Resource/Image/employee.png��5   	      TitleBar 5
      �� *
titleBar+   ExitCommand 5   	   �� *exitLoginCommand+.��5      �  � RowDefinitions 5      �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $��12 �6   �� 5      $��5 �6   .+�5      � $
��10 0q�6
   $��1��5      $	��280��5       5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $��20 �6   �� 5#      $
��auto �6   .+�5&      �� $��Centro Naturista Masaya��6   $��Center=�5'   
   $��0��5(   
   $��SemiBold"�5)   
      TextBlockStyle#���   5*   
   �� 5+      $��Inicio de Sesión��6   $��1��5,   
   $��Center=�5-   
   #���   5.   
   �� 50      $��Usuario:��6   $��3��51   
   $��0 0 0 5q�52   
   #���   53   
   �� 55      $��17(�56      $��Normal"�57      $��4��58        TextBoxStyle#���  59       �� TextAlignment$
 Left=�5:      ��55      �� *
userName+ �� UpdateSourceTrigger$ PropertyChanged=�5:      �� 5<      $��Contraseña:��6   $��6��5=   
   $��0 0 0 5q�5>   
   #���   5?   
   9   3WPF.ViewsComponent.UserControls.BindablePasswordBox  5A      $��7��6'   $��17(�5C      $��Normal"�5D         Password 5B      �� *
password+$ PropertyChanged=�5D      �� 5F      $��Iniciar sesión��6   $��Normal"�5G      $��9��5H       �� 	IsDefault$
 True��5I      $��Center=�5J      $��15(�5L      ��5K      �� *loginCommand+5L      5N      �� 5P      $��2��6   $��3��5Q   	   $
��10 0q�5R   	   $��Bottom=�5U   	   $��12(�5V   	   
����  ���5S   	   �� *errorMessage+y�5T   	   �� *hasErrorMessage+   BooleanToVisibilityConverter �� 	Converter# [ 5W   	   5X      5Z      	 � 	Resources	 5\        GroupBoxStyle
 �� 
TargetType �� Property �� Value��%d  &	       &	  �     �� 5]      "
 ��5^      .�5_      ��  � ��$
 16.5(�5`      �� 5a       � ��
 �   �5b      �� 5c       � ��$ SemiBold"�5d      5e      �� 5f      "
 ��5g      .�5h      ��  � ��$ 17(�5i      �� 5j       � ��
 �   �5k      �� 5l       � ��$ Normal"�5m      5n      5o      5p      
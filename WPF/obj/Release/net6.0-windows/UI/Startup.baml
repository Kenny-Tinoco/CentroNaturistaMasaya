   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  O KMasayaNaturistCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MasayaNaturistCenterMasayaNaturistCenter !   MasayaNaturistCenter.Startu   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9System&clr-namespace:System;assembly=mscorlib     4local"clr-namespace:MasayaNaturistCenter       � WindowStyle$
  None=� � 
ResizeMode$ NoResize=�$	��700��$
��1300��.���  � RowDefinitions �� $��40 ���  � ColumnDefinitions �� $	��200 ��� .+�� $	��Top=�$��40��   colorPrimary#���   $��1��$��2��.+��� -    ��Name$ btnSalir��$��Right=�$��Center=�$��0,0,10,0q�  styleButtonSalir#���  .���� $(��"/Resource/Drawable/Image/salir.png��$��30��$��30���� -   $ btnMinimizar��$��Right=�$��Center=�$��0,0,50,0q�  styleButtonMinimizar#���  .���� $,��&/Resource/Drawable/Image/minimizar.png��$��30��$��30��� $��0��$��2��  colorSecondary#���  .+��� ���#E1E2E1$��
38,40,42,0q�$	��Top=�._��� $��1q�$+��%/Resource/Drawable/Image/logo-cnm.png���� 
������ $��Center=�$��Disabled=�$��Disabled=�
������ .@��� -   $ 	btnInicio��$��Center=�  altoBML#���    anchoBML#���    styleButtonMenuLateral#���  .����  �� Orientation$ 
Horizontal=�.+��� $
��auto��$��center=�  	margenI_t#���  $'��!/Resource/Drawable/Image/home.png���� $��Inicio��
�������$��Center=�  
margenTB_t#���   	 fontSizeBML#��� 	 �� -   $ btnProducto��$��Center=�#���  #���  #���  .���� $ 
Horizontal=�.+��� $
��auto��$��center=�#���  $+��%/Resource/Drawable/Image/producto.png���� $��Producto��
�������$��Center=�#���  #��� 	 �� -   $ btnProveedor��$��Center=�#���  #���  #���  .���� $ 
Horizontal=�.+��� $
��auto��$��center=�#���  $,��&/Resource/Drawable/Image/proveedor.png���� $��	Proveedor��
�������$��Center=�#���  #��� 	 �� -   $ btnEmpleado��$��Center=�#���  #���  #���  .���� $ 
Horizontal=�.+��� $
��auto��$��center=�#���  $+��%/Resource/Drawable/Image/empleado.png���� $��Empleado��
�������$��Center=�#���  #��� 	 � -    �Name$ 	Contenido��$��2��$��2�� 
 colorBlancoFondo#��� 
  �� $
��313* ��� $
��787* �.+� � -     �Name$ PagesNavigation��  � NavigationUIVisibility$ Hidden=�$��2��	 � 	Resources	   FocusVisual
 �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Item.MouseOver.Background �� Color  Item.MouseOver.Border $  Item.SelectedInactive.Background   Item.SelectedInactive.Border " Item.SelectedActive.Background  Item.SelectedActive.Border  lvBotonesMenuLateral �� 
TargetType �� RelativeSource �� AncestorType �� 
TargetType ��Name �� Padding �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value��%  &	       &	      &	      &	 *     &	 ;     &	 �     &	 �     &	 �     &	 �     &	 �     &	 �     &	     7  7  7  7  7  7  7  X�186Q�X�60Q�u�2,2,0,2q�u�8 0 0 0q��� .��� 
 � �� �� .R��� $��2q�$
 true��#��� ��$��1��$	 1 2R��� $ 	#1F26A0DA���� $ 	#a826A0Da���� $ 	#3DDADADA���� $ 	#FFDADADA���� $ 	#3D26A0DA���� $ 	#FF26A0DA���� " ��.��� 
 �@J�SnapsToDevicePixels$
 True���� 
 � ��$	 4,1q��� 
 � �� �� *HorizontalContentAlignment+ �� " ���� 
 � �� �� *VerticalContentAlignment+ �� " ���� 
 � �� �#4f9cb2�� 
 � ��
 ���� �� 
 � ��$ 1q��� 
 �@�FocusVisualStyle8   �� 
 � �� �� " ��.R��� $ Bd��#��z��#��z��#��z��# z��$
 true��._��� #��z��# z #��z�� ]�  ��  �@J�IsMouseOver$
 True��./��� $ Bd��8  
 � ���� $ Bd��8  
 � ��]�  ��  �@��IsSelectionActive$ False����  �@��
IsSelected$
 True��./��� $ Bd��8  
 � ���� $ Bd��8  
 � ��]�  ��  �@��IsSelectionActive$
 True����  �@��
IsSelected$
 True��./��� $ Bd��8  
 � ���� $ Bd��8  
 � ��P�  � {�$ False��. ��� $ Bd��# � ��
 � ��
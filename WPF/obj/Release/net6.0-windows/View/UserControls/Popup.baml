   M S B A M L   `   `   `  ���� O  KMasayaNaturistCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:MasayaNaturistCenter.View.UserControls&MasayaNaturistCenter.View.UserControls  2    ,MasayaNaturistCenter.View.UserControls.Popup   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     MuserControls4clr-namespace:MasayaNaturistCenter.View.UserControls     -     >�Name$
  root��.���� 
������    colorPrimary#���   $��3q� �� CornerRadius$ 	10 10 2 2��._�� $
��auto��  colorBlancoFondo#���   � RowDefinitions �� $��40 ��� $��8 ��� �� $��40 ��� $��10 ��� $��8 � � ColumnDefinitions �� $��8 ��� �� $��8 �.+�� $��0��$��1��$��0��$��3��#���    �� �� $��40 �.+��� $��0�� �� Orientation$ 
Horizontal=�$��	20 5 10 5q�.+��� -   $��iconBarTitle��$��30������ *	iconBar+ �� ElementName$
 root���� -   $��
popupTitle��$��5 0 0 0q�  PopupFontSize#���  $��SemiBold"�$��Center=�
����������� *
titleBar+$
 root��;   5MasayaNaturistCenter.View.UserControls.TitleBarButton  ;   5MasayaNaturistCenter.View.UserControls.TitleBarButton   TitleBarButtonClick$ 
exit_Click��$��1��$��5q�   Icon$# /View/Resource/Image/exit.png��  CustomButtonExitStyle   styleButton# �  �� $��2��$��1������ *popupContent+$
 root��9   3MasayaNaturistCenter.View.UserControls.CustomButton  9   3MasayaNaturistCenter.View.UserControls.CustomButton	   CustomButtonClick$	 
save_Click��$��3��$��1��$	��130��
   Title$
 Guardar��   ImageSource$# /View/Resource/Image/save.png��
   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF.ViewComponents.UserControlsWPF.ViewComponents.UserControls  5      U/clr-namespace:WPF.ViewComponents.CustomControls!WPF.ViewComponents.CustomControls  5      /    )WPF.View.ProductWindows.PresentationModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I EUno.UI, Version=255.255.255.255, Culture=neutral, PublicKeyToken=nullR NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null>x,http://schemas.microsoft.com/winfx/2006/xaml       5      Nmc;http://schemas.openxmlformats.org/markup-compatibility/2006       5      Dd2http://schemas.microsoft.com/expression/blend/2008       5      JuserControls-clr-namespace:WPF.ViewComponents.UserControls       5      Fcustom/clr-namespace:WPF.ViewComponents.CustomControls       5      .��5	      � .+�5
   
   +   %WPF.ViewComponents.UserControls.Popup      iconBar$&   /Resource/Image/presentation.png��5         titleBar 5      �� *
titleBar+   buttonExitCommand 5      �� *ExitCommand+   popupContent 5      � 5       � RowDefinitions 5      �� 5      $��5 �6(   �� 5      $
��auto �6(   �� 5      $��12 �6(   �� 5      $
��auto �6(   �� 5      $��5 �6(   .+�5      �� $��1��5      $��Presentación��5         GroupBoxStyle#���   5      .��5      � $��5q�6    � ColumnDefinitions 5       �� 5!   "   $
��auto �63   �� 5"   "   $��20 �63   �� 5#   "   $��* �63    5%      �� 5&   "   �� 5'   "   $��20 �60   �� 5(   "   .+�5+      �� $��0��5,   !   $��5 0 0 0q�5-   !   .+�5.   "   �� $��Código��5/   %     TextBlockStyle#���  50   %   �� 51   "   $��17(�53   %    �� TextAlignment$ Center=�54   %   ${�False��55   %   
������ ��52   %   �� *logic.entity.idPresentation+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�56   %   57      �� 59      $��2��5:   !   $��0 0 5 0q�5;   !   .+�5<   "   �� $��Nombre��5=   %   #���  5>   %   �� 5@   "   $��17(�5B   %   $��Normal"�5C   %   $ Center=�5D   %   ��5A   %   �� *name+$ TwoWay=�$ PropertyChanged=�5D   %   5E      �� 5G      $��2��5H   !   $��0��5I   !   $��3��5J   !   	 �� Orientation$	 
Horizontal=�5K   !   $��Center=�5L   !   .+�5N   "   �� $��Guardar��5O   %   $��Normal"�5P   %     CustomButtonStyle#���  5T   %   
�������$��75��5V   %   {�5Q   %   �� *	canCreate+��5R   %   �� *SaveCommand+��5S   %   �� *_helper.isEditable+5V   %   �� 5X   "   $��30 0 0 0q�5Y   %   $��Limpiar��5Z   %   $��Normal"�5[   %   #���  5]   %   
�������$��75��5_   %   ��5\   %   �� *ResetCommand+y�5`   %   �� *_helper.isEditable+   BooleanToVisibilityConverter
 �� 	Converter#
 [ 5b      5d      5e      �� 5g      $��3��5h      $��Lista de presentación��5i      #���   5j      .��5l      � $��5q�6    5m      �� 5n   "   .+�5q      6   0WPF.ViewComponents.CustomControls.LoadingSpinner  $��0��5r   !   $��0��5s   !      Diameter$ 60Q�5t   !      	Thickness$ 5Q�5v   !      Color
 �   �   	IsLoading 5u   !   �� *	IsLoading+5w   !   � 5y      $��0��5z   !   $��0��5{   !   y�5|   !   �� *	IsLoading+ ' #InverseBooleanToVisibilityConverter#
 [ .+�5~   "   &   System.Windows.Controls.DataGrid    ElementsDataGrid#���  5�   %   $��5 20 5 5q�5�   %   $	��135��5�   %      CanUserResizeColumns$ false��5�   %   $	��380��5�   %   ��5   %   �� *_helper.catalogue+ � 	Resources 5�   &     optionsCell  ButtonStyle �� Path �� RelativeSource �� AncestorType��%�  &	       �� 5�   *   .R�5�   .   �� $��Center=�5�   1   $	 
Horizontal=�5�   1   .+�5�   2   �� $��Editar��69   #���  5�   9   ���#2196F3��5�   9   �� $ DataContext.EditCommand� �� "  ��5�   9   �� 5�   9   �� 5�   2   $��Eliminar��69   #���  5�   9   $��4 0 0 0q�5�   9   ���#F44336��5�   9   �� $ DataContext.DeleteCommand� �� "  ��5�   9   �� 5�   9   5�   /   5�   +   5�   '      Columns 5�   &   0  *System.Windows.Controls.DataGridTextColumn  5�   *   ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��6=      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   �� *idPresentation+  5�   *   $ Nombre��6=   $	 150 6M    6Y   �� *name+4  .System.Windows.Controls.DataGridTemplateColumn  5�   *   $ Opciones��6A   $ * 6S      CellTemplate# [ 6]   5�   #   5�      5�      5�      5�      5�      5�       5�       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding  J� SnapsToDevicePixels! ��Name" �� Triggers# P� Property$ P� Value% �� 
TargetName��%�  &	        &	 �     &	 8    �� 5�   
   " ��5�      .�5�      ��  � ��$
 16.5(�6)   �� 5�       � ��
 �   �6,   �� 5�       � ��$ SemiBold"�6+   5�      �� 5�   
   " ��5�      .�5�      ��  � ��$ 17(�6)   �� 5�       � ��
 �   �6+   �� 5�       � ��$ Normal"�6+   5�      �� 5�   
   " ��5�      .�5�      ��  � ��$ 15(�6)   �� 5�       � ��
 �����6+   �� 5�       � ��$ Normal"�6+   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ border��6!   #��z��5�      $ 4��5�      $ 8 0 8 0q�5�      
�������$	��0.6q�5�      $
  true��5�      ._�5�      �� $! contentPresenter��6/   $|�False��5�   +   $��Center=�5�   +   $��1q�5�   +   $
��True��5�   +   $
  True��5�   +   $��Center=�5�   +   5�      " 5�      P� 5�      # �@J�IsMouseOver$
$ true��6=   . �5�   "   �� $% border��6?    � ��
 �����6S   �� 5�   "   $% border��6@    � ��
 �   �6T   �� 5�   "    � ��
 �   �6?   5�      P� 5�      # � ��$
$ true��6;   . �5�   "   �� $% border��6?    � ��
 �����6S   �� 5�   "   $% border��6@    � ��
 �   �6T   5�      5�      5�      5�      5�      5�      
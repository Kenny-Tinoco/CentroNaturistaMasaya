   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5      U/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      2    ,WPF.View.ProductModule.ProductSelectionModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      FuserControls-clr-namespace:WPF.ViewsComponent.UserControls     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      .��5      -   'WPF.ViewsComponent.CustomControls.Popup      IconBar$!  /Resource/Image/product.png��5      $	��400��5
      $	��800��5         TitleBar 5      �� *
titleBar+   ExitCommand 5	      �� *exitCommand+.��5      �  � RowDefinitions 5      �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $��* �6   .+�5      � $��0��6
   .+�5      /   )WPF.ViewsComponent.UserControls.SearchBar  $��30��6   $	��250��5      $��0 0 20 0q�5         Text 5      �� *text+ �� Mode$ TwoWay=�5      5      � 5      $��2��6
    5      �� 5      $��* �6   �� 5      $
��auto �6   .+�5!      &   System.Windows.Controls.DataGrid     ElementsDataGrid#���   5"   	   $��0��5#   	   $��30 10q�5$   	   ��5!      �� *	listing+ � 	Resources 5&        optionsCell �� Orientation  ButtonStyle �� Path	 �� RelativeSource
 �� AncestorType��%�   &	       �� 5'      .R�5(   	   �� $��Center=�6   $ 
Horizontal=�5)      .+�5*   
   �� $��Ir��6   #���  5-      ���#2196F3��5+      �� $ DataContext.goCommand�	 �� "
  ��5,      �� 5.      5/   
   50   	   51       J� InputBindings 52      d� 53   	    d� MouseAction$ LeftDoubleClicke�6    �� Command 54      �� *	goCommand+ �� CommandParameter 55      �� *SelectedItem+	 �� "
     Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 59      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5:      �� *	IdProduct+  5;      $ Nombre��6   $	 180 5<       5=      �� *Name+  5>      $ Descripción��6   $ * 5?       5@      �� *Description+4  .System.Windows.Controls.DataGridTemplateColumn  5A      $ Opciones��6   $
 auto 5B         CellTemplate# [ 5C      5E      � 5G      $
��30 0q�6   $��1��5H   
   $��Center=�5I   
   $��Right=�5J   
   .+�5K      �� $��15(�6   ��5L      �� *listing.Count+�� 5M      $��15(�6   $��
 elementos��5N      5O      5P      5R      5T       5U       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value  �� 
TargetName��%�  &	       �� 5V      " ��5W      .�5X      ��  � ��$ 15(�5Y      �� 5Z       � ��
 �����5[      �� 5\       � ��$ Normal"�5]      �� 5^       � �� 5_      �� 5`      " ��6   .R�5b      �� $ border��6   #��z��5c   	   $ 4��5d   	   $ 8 0 8 0q�5e   	   
�������$	��0.6q�5g   	   $
 true��5h   	   ._�5i   	   �� $ contentPresenter��6   $|�False��5j      $��Center=�5k      $��1q�5l      $
��True��5m      $
 True��5n      $��Center=�5o      5p   	    5q      P� 5r   	    �@J�IsMouseOver$
 true��5s      . �5t   
   �� $  border��5u       � ��
 �����5v      �� 5w   
   $  border��5x       � ��
 �   �5y      �� 5z   
    � ��
 �   �5{      5|   
   P� 5}   	    � ��$
 true��5~      . �5   
   �� $  border��5�       � ��
 �����5�      �� 5�   
   $  border��5�       � ��
 �   �5�      5�   
   5�      5�      5�      5�      5�      
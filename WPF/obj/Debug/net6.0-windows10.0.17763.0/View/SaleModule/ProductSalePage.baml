   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPF.View.SaleModuleWPF.View.SaleModule  5      )    #WPF.View.SaleModule.ProductSalePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPF.View.SaleModule     5        N�Language$  es-ES�5       N� Title$ SellProductPage��.��5      ��  �� CornerRadius$ 6��6   
������� �� Padding$ 10q�5      ._�5      �  � ColumnDefinitions 5      �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5      �� 5      $
��auto �6   �� 5      $��* �6   .+�5      �� $��0��6   $��0��5   	   $��2��5   	   $��Venta��5   	   $��20(�5   	   $��Center=�5   	   $��SemiBold"�5   	   $
��0 10q�5    	   � 5"      $��1��6
   y�5#      �� *stockViewerIsVisible+    BooleanToVisibilityConverter �� 	Converter# [  .+�5%      %   WPF.View.SaleModule.StockViewer   � DataContext 6   �� *stockViewer+�� 5&      $��0��6   $
��Left=�5'   	   $	��Top=�5(   	   $��3q�5)   	     XCloseStyle#���  5*   	    d� 	IsChecked 5+   	   �� *stockViewerIsVisible+5,      �� 5.      $��1��6   $��1��5/      $ 8��50      
���   �$	��0.3q�52        colorBlancoFondo#��[ 53      $ 20q�54      ._�55      �  56      �� 57      $
��auto �6   �� 58      $��* �6   .+�5;      � $��0��6   $��	0 10 0 30q�5<   	    5=      �� 5>   	   $��* �6   �� 5?   	   $
��auto �6    5A      �� 5B   	   $
��auto �6   �� 5C   	   $
��auto �6   �� 5D   	   $
��auto �6   .+�5G      �� $��1��6   $��17(�5H      �� 5I      $�Dependiente��6   $��DemiBold"�5J   	   5K   	   � 5L      $��2��6   .+�5M   	   �� $��17(�6   $��0 0 40 0q�5N      �� 5O      $�Cód:��6    �� 5P      $��SemiBold"�5Q   	   �5P      �� *employee.IdEmployee+	 �� StringFormat$		 000��5Q   	   5R   
   �� 5T   	   $��17(�6   �� 5U      $�Nombre: ��6    �� 5V      $��SemiBold"�5W   	   �5V      �� *employee.Name+5W   	    �� 5X      $��SemiBold"�5Y   	   �5X      �� *employee.LastName+5Y   	   5Z   
   5[   	   � 5]      $��1��6   $��1��5^      .+�5_   	   �� $��17(�6   �� 5`      $�Fecha: ��6    �� 5a      $��SemiBold"�5b   	   �5a      �� *date+$	 dddd dd/MMMM/yyyy��
 �� ConverterCulture$
 es�� �� Mode$ OneWay=�5b   	   5c   
   5d   	   5f      � 5g      $��1��6    5h      �� 5i   	   $��* �6   �� 5j   	   $
��auto �6   .+�5m      � $��0��6    5n   	   �� 5o   
   $
��auto �6   �� 5p   
   $��* �6   �� 5q   
   $
��auto �6   �� 5r   
   $
��auto �6   .+�5u   	   �� $��0��6   $��	Ver visor��5v      $��Center=�5w      $��17(�5x      $
��Left=�5y       5z      �� *stockViewerIsVisible+&   System.Windows.Controls.DataGrid  5|   	   $��1��6   $	��0 5q�5}         AutoGenerateColumns$ False��5      $��15(�5�         CanUserAddRows$ False��5�         CanUserDeleteRows$ False��5�         
IsReadOnly$
 True��5�      
�������  DataGridGenericColumnHeader   ColumnHeaderStyle# �  5�      ��5~      �� *detailListing+ �� SelectedItem 5�      �� *detailSelected+   Columns 5�   
   0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Cant.��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 48 5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *
Quantity+  5�      $ Precio��6   $ 50 5�       5�      �� *Price+  5�      $ Subtotal��6   $ 65 5�       5�      �� *Total+  5�      $ Cód.��6      
FontWeight$ SemiBold"�5�       5�      �� *	IdStock+$		 000��5�        5�      $ Producto��6   $
 auto 5�       5�      �� *ProductName+  5�      $ Presentación��6   $
 auto 5�       5�      �� *Presentation+  5�      $ Descripción��6   $	 400 5�       5�      �� *ProductDescription+5�   
   �� 5�   	   $��2��6   $��0 2 0 12q�5�      $ 4��5�      $ 2 0 2 2q�5�      y�5�      �� *detailsEditorIsVisible+# [  ._�5�   
   � .+�5�      �� $��17(�6   $��Center=�5�      �� 5�   .   $�Cód:��62    �� 5�   .   $��SemiBold"�5�      �5�   2   �� *detailSelected.IdStock+$		 000��5�      5�      �� 5�      $��
Cantidad: ��6   $��17(�5�      $��Center=�5�      $��15 0 0 0q�5�      �� 5�      $��40��6   $��17(�5�        ToolTipStyle#��[ 5�      $��Center=�5�      $��Center=�5�      ��5�      �� *
quantity+ �� UpdateSourceTrigger$ PropertyChanged=�$	 0��5�      �� 5�      $��Guardar��6   $��15(�5�      $��25 0 0 0q�5�      $	��5 0q�5�      ��5�      �� *detailSelected+��5�      �� *
editDetail+{�5�      �� *	canCreate+5�      �� 5�      $��Eliminar��6   $	��5 0q�5�      $
��10 0q�5�      $��15(�5�      ��5�      �� *deleteDetail+��5�      �� *detailSelected+5�      5�      5�   
   � 5�   	   $��3��6   .+�5�   
   �� $��Descuento: ��6   $��17(�5�      $��Center=�5�      �� 5�   
    �� DisplayMemberPath$
 name��5�      $��17(�5�      ��5�      �� *	discounts+ 5�      �� *selectedDiscount+�� 5�   
   $��17(�5�      ${�False��5�      $��Center=�5�      $��	20 0 10 0q�5�      ��5�      �� *discountedAmount+$	 0.00 córdobas��5�      �� 5�   
   $��Aplicar��6   $��Center=�5�      $��17(�5�      $��Center=�5�       5�      �� *discountApplies+5�      5�   
   5�   	   � 5�      $��1��6   $��	20 20 0 0q�5�   
    5�   	   �� 5�   
   $
��auto �6   �� 5�   
   $
��auto �6   �� 5�   
   $
��auto �6   �� 5�   
   $
��auto �6   �� 5�   
   $��* �6   .+�5�   	   �� $��0��6   .+�5�   
   �� $��18(�6   �� 5�   "   $�Total a pagar��6&   5�      �� 5�   
   
���   �$��1q�5�      
�������$	 4 0q�5�      ._�5�      �� $��24(�6    �� TextAlignment$ Right=�5�      ��5�      �� *total+$ OneWay=�$
	 0.00��5�      5�   
   �� 5�   	   $��1��6   $
��0 10q�5�   
   $��	Finalizar��5�   
   $��15(�5�   
   {�5�   
   �� *canCreateSale+��5�   
   �� *finishSaleCommand+5�   
   �� 5   	   $��3��6   $��	0 10 0 10q�5     $��Right=�5     $��Center=�5     $��14(�5     
����  ���5     �� *statusMessage+y�5     �� *hasStatusMessage+# [  5     �� 5  	   $��4��6   $��Cancelar��5	  
   $��Bottom=�5  
   $��15(�5  
   ��5
  
   �� *backCommand+5  
   5  	   5     �� 5     $��0��6   $
��Left=�5     $	��Top=�5     #���  5     $��-18 -18q�5     ��5     �� *backCommand+5     5     5     5      � 	Resources 5       GroupBoxStyle �� 
TargetType �� Property �� Value  TextBlockStyle  ComboBoxStyle��%�  &	       &	 �     &	 P    �� 5     " ��5     .�5     ��  � ��$
 16.5(�5     �� 5       � ��
 �   �5!     �� 5"      � ��$ SemiBold"�5#     5$     �� 5&     " ��5'     .�5(     ��  � ��$ 17(�5)     �� 5*      � ��
 �   �5+     �� 5,      � ��$ Normal"�5-     5.     �� 50     " ��51     .�52     ��  � ��$ 17(�53     �� 54      � ��
 �   �55     �� 56      � ��$ Normal"�57     �� 58      � ��$ 70��59     �� 5:      � ��$ 5 0 0 0q�5;     �� 5<      � ��$ Center=�5=     �� 5>      � ��$ Center=�5?     5@     5B     5C     
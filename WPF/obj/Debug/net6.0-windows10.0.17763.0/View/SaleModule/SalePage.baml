   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      Q-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5      "    WPF.View.SaleModule.SalePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      FuserControls-clr-namespace:WPF.ViewsComponent.UserControls     5        N� Title$  SalePage��5      .��5      ��  �� CornerRadius$ 6��5      
���   �   colorBlancoFondo#���   5      ._�5      �  � ColumnDefinitions 5      �� 5      $��15 �6   �� 5      �� 5      $��15 �6    � RowDefinitions 5      �� 5      $��8 �6   �� 5      $
��auto �6   �� 5      $��40 �6   �� 5      �� 5      $��8 �6   .+�5      �� $��1��6   $
��Left=�5      $��
30,30,0,15q�5         StackPanelStyle#���  5!      .+�5"      2   ,WPF.ViewsComponent.UserControls.CustomButton     Title$ Nueva venta��6       ImageSource$ /Resource/Image/plus.png��5$         buttonCommand 5#      �� *openFormCommand+5$      5%      �� 5'      $��1��6   $��Right=�5(      $��	0,0,30,15q�5)      #���  5*      .+�5+      ��  �� Orientation$ 
Horizontal=�6   .+�5,      /   )WPF.ViewsComponent.UserControls.SearchBar  $��30��6   $	��250��5-      $��0 0 20 0q�50       � DataContext 5.      �� *listingViewModel+	   Text	 5/      �� *text+
 �� Mode$
 TwoWay=�50      51      52      �� 54      $��2��6   $��1��55   	   $��SemiBold"�56   	    �� TextAlignment$ Center=�57   	   $��Bottom=�58   	     SaleWindowTitle#���  59   	    ! ElementsDataGridTitleFontSize#���  5:   	   � 5<      $��3��6
   $��1��5=       5>      �� 5?      $��* �6   �� 5@      $
��auto �6   .+�5C      �� $��0��6   $��Center=�5D      $��Center=�5E       5F      �� *listingViewModel+.+�5G      6   0WPF.ViewsComponent.CustomControls.LoadingSpinner     Diameter$	 100Q�6      	Thickness$ 5Q�5I         Color
 �   �   	IsLoading 5H      �� *	isLoading+5J      �� 5K      
���  ��$��18(�5M      ��5K      �� *errorMessage+y�5N      �� *hasErrorMessage+   BooleanToVisibilityConverter �� 	Converter# [ 5O      � 5Q      $��0��6   $��30 10q�5R       5S      �� 5T      $��* �6   �� 5U      $
��auto �6   .+�5X      &   System.Windows.Controls.DataGrid  $��0��6     ElementsDataGrid#���  5[   
   ��5Y   
   �� *listingViewModel.listing+y�5Z   
   �� *#!listingViewModel.isListingVisible+# [  �� SelectedItem 5\   
   �� *selectedItem+   Columns 5]      0  *System.Windows.Controls.DataGridTextColumn  5^   	   ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5_      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5`      �� *IdSale+  5a   	   $ 
Cód. Dep.��6   $
 auto 5b       5c      �� *
IdEmployee+  5d   	   $ Dependiente��6   $ * 5e       5f      �� *Name+  5g   	   $ Ingreso��6   $
 auto 5h       5i      �� *Total+ �� StringFormat$
 0.00��  5j   	   $
 Hora��6   $
 auto 5k       5l      �� *Date+$ h:mm tt�� �� ConverterCulture$ es��  5m   	   $ Fecha��6   $
 auto 5n       5o      �� *Date+$ dddd dd/MMM/yyyy��$ es��5q      �� 5s      $��10 0 0 0q�5t      $��1��5u      $	��350��5v       �� Padding$ 8q�5w      $ 6��5x      
���   �$��1q�5z      y�5s      �� *anItemIsSelected+# [ ._�5{      �  5|   	   �� 5}   
   $
��auto �6   �� 5~   
   $
��auto �6   �� 5   
   $��* �6   .+�5�   	   � $��0��6   $��0 0 0 20q�5�       5�      �� *selectedItem+ 5�   
   �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�   
   �� $��0��6   $��17(�5�      $ Center=�5�        colorSecondaryDark#��[ 5�      
������� �� Padding$ 1q�5�      �� 5�   "   $�Código:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *IdSale+5�      5�      �� 5�   
   $��2��6   $
��Left=�5�      $��17(�5�      $	��0 5q�5�      �� 5�   "   $�* Dependiente:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *Name+5�      5�      �� 5�   
   $��3��6   $
��Left=�5�      $��17(�5�      �� 5�   "   $�* Hora:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *Date+$ h:mm tt��$ es��5�      5�      �� 5�   
   $��4��6   $
��Left=�5�      $��17(�5�      $	��0 5q�5�      �� 5�      $�* Fecha:��6    �� 5�      $��SemiBold"�5�      �5�      �� *Date+$ dddd dd/MMM/yyyy��$ es��5�      5�      �� 5�   
   $��5��6   $
��Left=�5�      $��17(�5�      �� 5�   "   $�* Total:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *Total+$
 0.00��5�       �� 5�   "   $�	córdobas��6&   $��SemiBold"�5�      5�      �� 5�   
   $��6��6   $
��Left=�5�      $��17(�5�      $	��0 5q�5�      �� 5�   "   $�* Descuento:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *
Discount+$ {0:P1}��5�      5�      5�   
   �� 5�   	   $��1��6   $��Center=�5�      $��17(�5�      $��Detalle de la Venta��5�      $��SemiBold"�5�      $��0 0 0 5q�5�        5�   	   $��2��6      AutoGenerateColumns$ False��5�      $��15(�5�         CanUserAddRows$ False��5�         CanUserDeleteRows$ False��5�         
IsReadOnly$
 True��5�      
�������  DataGridGenericColumnHeader   ColumnHeaderStyle# �  5�      ��5�      �� *saleDetails+ 5�   
     5�      $ Cant.��6   $ 48 5�       5�      �� *
Quantity+  5�      $ Precio��6   $ 50 5�       5�      �� *Price+  5�      $ Subtotal��6   $ 65 5�       5�      �� *Total+  5�      $ Cód.��6    5�      �� *	IdStock+$	 000��  5�      $ Producto��6   $
 auto 5�       5�      �� *ProductName+  5�      $ Presentación��6   $
 auto 5�       5�      �� *Presentation+  5�      $ Descripción��6   $	 300 5�       5�      �� *ProductDescription+5�   
   �� 5�   	   $��0��6   
�������$��Right=�5�   
   $	��Top=�5�   
     XCloseStyle#��[ 5�   
   ��5�   
   �� *closeDetails+5�   	   5�      5�      � 5�      $��1��6   $
��30 0q�5�   
   .+�5�      � $��0 0 30 0q�6   $��Center=�5�      $
��Left=�5�       5�      �� *listingViewModel+y�5�      �� *hasErrorMessage+# [ .+�5      �� $��Recargar��6   $
��10 0q�5  	   $��14(�5  	   ��5  	   �� *loadCommand+5     � 5     .+�5     �� $��16(�6    �� DisplayMemberPath$
 name��5
     $��Center=�5       �� SelectedIndex$  0��5      5     �� *periodSelected+��5	     �� *periodListing+5     �� 5     $��16(�6   $��8 0 0 0q�5     $
 name��5     $��Center=�5     $  0��5      5     �� *employeeSelected+��5     �� *employeeListing+5     5     � 5     $
��30 0q�6   $��1��5  
   $��Center=�5  
   $��Right=�5  
    5  
   �� *listingViewModel+y�5  
   �� *isListingVisible+# [ .+�5     ��  	 textBlockListViewStyle#��� 	 6   ��5     �� *listing.Count+�� 5      #��� 	 6   $�� ventas��5!     5"     5#     5$     5%     ! � 	Resources! 5&     " �� 
TargetType# �� Property$ �� Value��%�  &		       &	 �     �� 5'     "" ��6
   .�5)     �� # � ��$$ 17(�5*     �� 5+     # � ��$$ Normal"�5,     �� 5-     # � ��
$ �   �5.     5/     �� 50     "" ��51     .�52     �� # � ��$$ 2��53     �� 54     # � ��$$ 1��55     �� 56     # � ��$$ Bottom=�57     �� 58     # � ��$$ 32��59     �� 5:     # �@��Orientation$$ 
Horizontal=�5;     5<     5=     5>     
   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      Q-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5      *    $WPF.View.PurchaseModule.PurchasePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      FuserControls-clr-namespace:WPF.ViewsComponent.UserControls     5        N� Title$  PurchasePage��5      .��5      �� $��6q�6
    �� CornerRadius$ 6��5      
���   �   colorBlancoFondo#���   5      ._�5      �  � ColumnDefinitions 5      �� 5      $��15 �6   �� 5      �� 5      $��15 �6    � RowDefinitions 5      �� 5      $��8 �6   �� 5      $
��auto �6   �� 5      $��40 �6   �� 5      �� 5      $��8 �6   .+�5      �� $��2��6   $
��Left=�5       $��30,0,0,0q�5!        StackPanelStyle#���  5"      .+�5#      /   )WPF.ViewsComponent.UserControls.SearchBar  $��30��6   $	��250��5$       � DataContext 5%      �� *listingViewModel+   Text 5&      �� *text+ �� Mode$ TwoWay=�5(      �� 5*      $��2��6   $��1��5+   	   $��SemiBold"�5,   	    �� TextAlignment$ Center=�5-   	   $��Bottom=�5.   	     PurchaseWindowTitle#���  5/   	    ! ElementsDataGridTitleFontSize#���  50   	   � 52      $��3��6
   $��1��53       54      �� 55      $��* �6   �� 56      $
��auto �6   .+�59      �� $��0��6   $��Center=�5:      $��Center=�5;       5<      �� *listingViewModel+.+�5=      6   0WPF.ViewsComponent.CustomControls.LoadingSpinner     Diameter$	 100Q�6   	   	Thickness$	 5Q�5?      
   Color

 �   �   	IsLoading 5>      �� *	isLoading+5@      �� 5A      
���  ��$��18(�5C      ��5A      �� *errorMessage+y�5D      �� *hasErrorMessage+   BooleanToVisibilityConverter �� 	Converter# [ 5E      � 5G      $��0��6   $��30 10q�5H       5I      �� 5J      $��* �6   �� 5K      $
��auto �6   .+�5N      &   System.Windows.Controls.DataGrid  $��0��6     ElementsDataGrid#���  5Q   
   ��5O   
   �� *listingViewModel.listing+y�5P   
   �� *#!listingViewModel.isListingVisible+# [  �� SelectedItem 5R   
   �� *selectedItem+   Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5T   	   ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5U      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5V      �� *
IdSupply+ �� StringFormat$	 000��  5W   	   $ Cód. Prov.��6   $
 auto 5X       5Y      �� *
IdProvider+  5Z   	   $ 	Proveedor��6   $ * 5[       5\      �� *Name+  5]   	   $ Egreso��6   $
 auto 5^       5_      �� *Total+$
 0.00��  5`   	   $
 Hora��6   $
 auto 5a       5b      �� *Date+$ h:mm tt�� �� ConverterCulture$ es��  5c   	   $ Fecha��6   $
 auto 5d       5e      �� *Date+$ dddd dd/MMM/yyyy��$ es��5g      �� 5i      $��10 0 0 0q�5j      $��1��5k      $	��350��5l       �� Padding$ 8q�5m      $ 6��5n      
���   �$��1q�5p      y�5i      �� *anItemIsSelected+# [ ._�5q      �  5r   	   �� 5s   
   $
��auto �6   �� 5t   
   $
��auto �6   �� 5u   
   $��* �6   .+�5x   	   � $��0��6   $��0 0 0 20q�5y       5z      �� *selectedItem+ 5{   
   �� 5|      �� 5}      �� 5~      �� 5      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�   
   �� $��0��6   $��17(�5�      $ Center=�5�        colorSecondaryDark#��[ 5�      
������� �� Padding$ 1q�5�      �� 5�   "   $�Código:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *
IdSupply+$	 000��5�      5�      �� 5�   
   $��2��6   $
��Left=�5�      $��17(�5�      $	��0 5q�5�      �� 5�   "   $�* Proveedor:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *Name+5�      5�      �� 5�   
   $��3��6   $
��Left=�5�      $��17(�5�      �� 5�   "   $�* Hora:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *Date+$ h:mm tt��$ es��5�      5�      �� 5�   
   $��4��6   $
��Left=�5�      $��17(�5�      $	��0 5q�5�      �� 5�   "   $�* Fecha:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *Date+$ dddd dd/MMM/yyyy��$ es��5�      5�      �� 5�   
   $��5��6   $
��Left=�5�      $��17(�5�      �� 5�   "   $�* Total:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *Total+$
 0.00��5�       �� 5�   "   $�	córdobas��6&   $��SemiBold"�5�      5�      �� 5�   
   $��6��6   $
��Left=�5�      $��17(�5�      $	��0 5q�5�      �� 5�   "   $�* Descuento:��6&    �� 5�   "   $��SemiBold"�5�      �5�   &   �� *
Discount+$ {0:P0}��5�      5�      5�   
   �� 5�   	   $��1��6   $��Center=�5�      $��17(�5�      $��Detalle de la compra��5�      $��SemiBold"�5�      $��0 0 0 5q�5�        5�   	   $��2��6      AutoGenerateColumns$ False��5�      $��15(�5�         CanUserAddRows$ False��5�         CanUserDeleteRows$ False��5�         
IsReadOnly$
 True��5�      
�������  DataGridGenericColumnHeader   ColumnHeaderStyle# �  5�      ��5�      �� *supplyDetails+ 5�   
     5�      $ Cant.��6   $ 48 5�       5�      �� *
Quantity+  5�      $ Precio/Compra��6   $ 60 5�       5�      �� *Price+  5�      $ Subtotal��6   $ 65 5�       5�      �� *Total+  5�      $ Cód.��6      
FontWeight$ SemiBold"�5�       5�      �� *	IdStock+$	 000��5�        5�      $ Producto��6   $
 auto 5�       5�      �� *ProductName+  5�      $ Presentación��6   $
 auto 5�       5�      �� *Presentation+  5�      $ Descripción��6   $	 300 5�       5�      �� *ProductDescription+5�   
   �� 5�   	   $��0��6   
�������$��Right=�5�   
   $	��Top=�5�   
     XCloseStyle#��[ 5�   
   ��5�   
   �� *closeDetails+5�   	   5�      5�      � 5�      $��1��6   $
��30 0q�5�   
   .+�5�      � $��0 0 30 0q�6   $��Center=�5�      $
��Left=�5�       5�      �� *listingViewModel+y�5�      �� *hasErrorMessage+# [ .+�5�      �� $��Recargar��6   $
��10 0q�5�   	   $��14(�5�   	   ��5�   	   �� *loadCommand+5�      � 5�      .+�5�      �� $��16(�6    �� SelectedIndex$ 0��5       �� DisplayMemberPath$
 name��5     $��Center=�5      5     �� *periodSelected+��5     �� *periodListing+5     �� 5     $��16(�6   $��8 0 0 0q�5     $
 name��5     $��Center=�5     $ 0��5	      5
     �� *providerSelected+��5     �� *providerListing+5     5     � 5     $
��30 0q�6   $��1��5  
   $��Center=�5  
   $��Right=�5  
    5  
   �� *listingViewModel+y�5  
   �� *isListingVisible+# [ .+�5     ��  	 textBlockListViewStyle#��� 	 6   ��5     �� *listing.Count+�� 5     #��� 	 6   $�� compras��5     5     5     5     5      � 	Resources 5      �� 
TargetType  �� Property! �� Value��%�  &		       &	 �     �� 5     " ��6
   .�5!     ��   � ��$! 17(�5"     �� 5#       � ��$! Normal"�5$     �� 5%       � ��
! �   �5&     5'     �� 5(     " ��5)     .�5*     ��   � ��$! 2��5+     �� 5,       � ��$! 1��5-     �� 5.       � ��$! Bottom=�5/     �� 50       � ��$! 32��51     �� 52       �@��Orientation$! 
Horizontal=�53     54     55     56     
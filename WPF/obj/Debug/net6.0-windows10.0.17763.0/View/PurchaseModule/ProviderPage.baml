   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5      U/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      *    $WPF.View.PurchaseModule.ProviderPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      FuserControls-clr-namespace:WPF.ViewsComponent.UserControls     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5        N� Title$  ProviderPage��5
      .��5      �� $��6q�5       �� CornerRadius$ 6��5      
���   �   colorBlancoFondo#���   5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $��15 �6#   �� 5      �� 5      $��15 �6#    � RowDefinitions 5      �� 5      $��8 �6    �� 5      $
��auto �6    �� 5      $��40 �6    �� 5      �� 5      $��8 �6    .+�5      �� $��1��5      $
��Left=�5       $��
30,30,0,15q�5!        StackPanelStyle#���  5"      .+�5#      2   ,WPF.ViewsComponent.UserControls.CustomButton     Title$ Agregar proveedor��5$         ImageSource$ /Resource/Image/plus.png��5&         buttonCommand 5%      �� *addModalCommand+5&      5'      �� 5)      $��1��5*      $��Right=�5+      $��	0,0,30,15q�5,      #���  5-      .+�5.      ��  �� Orientation$ 
Horizontal=�6   .+�5/      /   )WPF.ViewsComponent.UserControls.SearchBar  $��30��50      $	��250��51      $��0 0 20 0q�54       � DataContext 52      �� *listingViewModel+	   Text	 53      �� *text+
 �� Mode$
 TwoWay=�54      56      57      �� 59      $��2��5:      $��1��5;      $��SemiBold"�5<       �� TextAlignment$ Center=�5=      $��Bottom=�5>        ProviderWindowTitle#���  5?       ! ElementsDataGridTitleFontSize#���  5@      � 5B      $��3��5C      $��1��5D       5E      �� 5F      $��* �6$   �� 5G      $
��auto �6$   .+�5J      �� $��0��6   $��Center=�5K      $��Center=�5L       5M      �� *listingViewModel+.+�5N      6   0WPF.ViewsComponent.CustomControls.LoadingSpinner     Diameter$	 100Q�5O         	Thickness$ 5Q�5Q         Color
 �   �   	IsLoading 5P      �� *	isLoading+5R      �� 5S      
���  ��$��18(�5U      ��5S       �� *errorMessage+y�5V      �� *hasErrorMessage+   BooleanToVisibilityConverter �� 	Converter# [ 5W      &   System.Windows.Controls.DataGrid  5Y      -   5          Name$ elementDataGrid��5Z        ElementsDataGrid#���  5]      $��30 10q�5^      $��0��5_      ��5[      �� *listingViewModel.listing+y�5\      �� *#!listingViewModel.isListingVisible+# [  � 	Resources 5a        comboBoxCell �� DisplayMemberPath �� SelectedIndex  optionsCell  ButtonStyle �� Path �� RelativeSource �� AncestorType3  -System.Windows.Controls.Ribbon.RibbonCheckBox 	 StatusCheckBoxDataGridStyle��%�  &	       &	 �     �� 5b      .R�5c      �� $��Center=�5d      $ 
Horizontal=�5e      .+�5f   "   �� $ Phone��5g   +   $ 0��5h   +   $��0 0 5 0q�5i   %   ��5f   +   �� *ProviderPhones+5i   %   5j      5k      �� 5l      .R�5m      � $��Center=�5n      $��Center=�5o   !   .+�5p   "   �� $��Editar��6)   #���  5s   %   ���#2196F3$��0 0 5 0q�5u   %   ��5q   %   �� $" DataContext.editModalCommand� �� "  ��5r   %   �� 5u   %     5v   "   #��� 	 5x   -   ��5v   1   �� $% DataContext.changeStatusCommand� �� "  ��5w   -   �� 5x   -   5y      5z      5{         Columns 5|      0  *System.Windows.Controls.DataGridTextColumn  5}      ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6H   �� *
IdProvider+  5~      $ Nombre��6-   $	 220 6=    6I   �� *Name+  5      $ 
Dirección��6-   $ * 6@    6J   �� *	Address+  5�      $	 RUC��6-   $
 auto 6:    6G   �� *Ruc+4
  .System.Windows.Controls.DataGridTemplateColumn
  5�      $ Telefono��61   $
 auto 6C      MinWidth$	 160Q�6P    
  CellTemplate# [ 6`   
  5�      $ Opciones��61   $	 160 6C   $	 155Q�6O   # [ 6^   5�      � 5�      $
��30 0q�5�      $��1��5�      $��Center=�5�      $
��Left=�5�       5�      �� *listingViewModel+y�5�      �� *hasErrorMessage+# [ .+�5�      �� $��Recargar��6   $
��10 0q�5�      $��14(�5�      ��5�      �� *loadCommand+5�      � 5�      $
��30 0q�5�      $��1��5�      $��Center=�5�      $��Right=�5�       5�      �� *listingViewModel+y�5�      �� *isListingVisible+# [ .+�5�      ��  
 textBlockListViewStyle#��� 
 5�      ��5�      �� *listing.Count+�� 5�      #��� 
 5�      $��
 elementos��5�      5�      5�      5�      5�       5�       �� 
TargetType �� Property  �� Value! �� 
TargetType" ��Name# �� Padding$ J� SnapsToDevicePixels% �� Triggers& P� Property' P� Value( �� 
TargetName��%�  &	
       &	 �     &	 �    �� 5�   
   " ��6   .�5�      ��  � ��$  17(�6)   �� 5�       � ��$  Normal"�6+   �� 5�       � ��
  �   �6+   5�      �� 5�   
   " ��5�      .�5�      ��  � ��$  2��6)   �� 5�       � ��$  1��6,   �� 5�       � ��$  Bottom=�62   �� 5�       � ��$  32��6'   �� 5�       �@��Orientation$  
Horizontal=�6,   5�      �� 5�   
   " ��5�      .�5�      ��  � ��$  15(�6)   �� 5�       � ��
  �����6+   �� 5�       � ��$  Normal"�6+   �� 5�       � ��  5�      �� 5�      "! ��6&   .R�5�      �� $" border��6!   #��z��5�      $ 4��5�      $# 8 0 8 0q�5�      
�������$	��0.6q�5�      $
$ true��5�      ._�5�      �� #��z��6-   5�      % 5�      P� 5�      & �@J�IsMouseOver$
' true��6=   . �5�   "   �� $( border��6?    � ��
  �����6S   �� 5�   "   $( border��6@    � ��
  �   �6T   �� 5�   "    � ��
  �   �6?   5�      P� 5�      & � ��$
' true��6;   . �5�   "   �� $( border��6?    � ��
  �����6S   �� 5�   "   $( border��6@    � ��
  �   �6T   5�      5�      5�      5�      5�      5�      
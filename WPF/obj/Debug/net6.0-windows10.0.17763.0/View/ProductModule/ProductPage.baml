   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      Q-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5      (    "WPF.View.ProductModule.ProductPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      FuserControls-clr-namespace:WPF.ViewsComponent.UserControls     5      -   5          N�Name$
  root��5	       N� Title$ ProductPage��5      .��5      �  � ColumnDefinitions 5      �� 5      $��15 �6   �� 5      �� 5      $��15 �6    � RowDefinitions 5      �� 5      $��8 �6   �� 5      $
��auto �6   �� 5      $��40 �6   �� 5      �� 5      $��8 �6   .+�5      �� $��1��6   $
��Left=�5      $��
30,30,0,15q�5         StackPanelStyle#���   5      .+�5       2   ,WPF.ViewsComponent.UserControls.CustomButton     Title$ Nuevo Producto��6      ImageSource$ /Resource/Image/plus.png��5"         buttonCommand 5!      �� *addModalCommand+5"      5#      �� 5%      $��1��6   $��Right=�5&      $��	0,0,30,15q�5'      #���   5(      .+�5)      ��  �� Orientation$ 
Horizontal=�6   .+�5*      /   )WPF.ViewsComponent.UserControls.SearchBar  $��30��6   $	��250��5+      $��0 0 20 0q�5.       � DataContext 5,      �� *listingViewModel+	   Text	 5-      �� *text+
 �� Mode$
 TwoWay=�5.      5/      50      �� 52      $��2��6   $��1��53      $��SemiBold"�54       �� TextAlignment$ Center=�55      $��Bottom=�56        ProductWindowTitle#���  57       ! ElementsDataGridTitleFontSize#���  58      � 5:      $��3��6	   $��1��5;       5<      �� 5=      $��* �6   �� 5>      $
��auto �6   .+�5A      �� $��0��6   $��Center=�5B      $��Center=�5C       5D      �� *listingViewModel+.+�5E      6   0WPF.ViewsComponent.CustomControls.LoadingSpinner     Diameter$	 100Q�6      	Thickness$ 5Q�5G         Color
 �   �   	IsLoading 5F      �� *	isLoading+5H      �� 5I      
���  ��$��18(�5K   
   ��5I      �� *errorMessage+y�5L   
   �� *hasErrorMessage+   BooleanToVisibilityConverter �� 	Converter# [ 5M      &   System.Windows.Controls.DataGrid  5O      -   5          Name$ elementDataGrid��5O        ElementsDataGrid#���  5R      $��30 10q�5S      $��0��5T      ��5P      �� *listingViewModel.listing+y�5Q      �� *#!listingViewModel.isListingVisible+# [  � 	Resources 5U        optionsCell  ButtonStyle �� Path �� RelativeSource �� AncestorType3  -System.Windows.Controls.Ribbon.RibbonCheckBox  StatusCheckBoxDataGridStyle��%�  &	       �� 5V      .R�5W      �� $��Center=�6   $ 
Horizontal=�5X   
   .+�5Y   	   �� $��Editar��6   #���  5\   
   ���#2196F3$��0 0 5 0q�5^   
   ��5Z   
   �� $" DataContext.editModalCommand� �� "  ��5[   
   �� 5^   
     5_   	   #���  5a      ��5_      �� $% DataContext.changeStatusCommand� �� "  ��5`      �� 5a      5b   	   5c      5d         Columns 5e      0  *System.Windows.Controls.DataGridTextColumn  5f      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5g      1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5h      �� *	IdProduct+  5i      $ Nombre��6   $	 220 5j       5k      �� *Name+  5l      $ Descripción��6   $ * 5m       5n      �� *Description+  5o      $ Cantidad total��6   $
 auto 5p       5q      �� *
Quantity+4
  .System.Windows.Controls.DataGridTemplateColumn
  5r      $ Opciones��6   $	 155 5s       
  CellTemplate# [ 5t      5v      � 5w      $
��30 0q�6   $��1��5x   	   $��Center=�5y   	   $
��Left=�5z   	    5{   	   �� *listingViewModel+y�5|   	   �� *hasErrorMessage+# [ .+�5}      �� $��Recargar��6   $
��10 0q�5~      $��14(�5      ��5�      �� *loadCommand+5�      � 5�      $
��30 0q�6   $��1��5�   	   $��Center=�5�   	   $��Right=�5�   	    5�   	   �� *listingViewModel+y�5�   	   �� *isListingVisible+# [ .+�5�      ��   textBlockListViewStyle#���  6   ��5�   
   �� *listing.Count+�� 5�      #���  6   $��
 elementos��5�   
   5�      5�      5�       5�       �� 
TargetType �� Property �� Value �� 
TargetType ��Name  �� CornerRadius! �� Padding" J� SnapsToDevicePixels# �� Triggers$ P� Property% P� Value& �� 
TargetName��%  &	       &	  �     &	 �    �� 5�      " ��6
   .�5�      ��  � ��$ 17(�5�      �� 5�       � ��$ Normal"�5�      �� 5�       � ��
 �   �5�      5�      �� 5�      " ��5�      .�5�      ��  � ��$ 2��5�      �� 5�       � ��$ 1��5�      �� 5�       � ��$ Bottom=�5�      �� 5�       � ��$ 32��5�      �� 5�       �@��Orientation$ 
Horizontal=�5�      5�      �� 5�      " ��5�      .�5�      ��  � ��$ 15(�5�      �� 5�       � ��
 �����5�      �� 5�       � ��$ Normal"�5�      �� 5�       � �� 5�      �� 5�      " ��6   .R�5�      �� $ border��6   #��z��5�   	   $  4��5�   	   $! 8 0 8 0q�5�   	   
�������$	��0.6q�5�   	   $
" true��5�   	   ._�5�   	   �� #��z��6   5�   	   # 5�      P� 5�   	   $ �@J�IsMouseOver$
% true��5�      . �5�   
   �� $& border��5�       � ��
 �����5�      �� 5�   
   $& border��5�       � ��
 �   �5�      �� 5�   
    � ��
 �   �5�      5�   
   P� 5�   	   $ � ��$
% true��5�      . �5�   
   �� $& border��5�       � ��
 �����5�      �� 5�   
   $& border��5�       � ��
 �   �5�      5�   
   5�      5�      5�      5�      5�      
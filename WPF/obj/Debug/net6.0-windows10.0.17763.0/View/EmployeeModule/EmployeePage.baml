   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5   D   U/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  6�   *    $WPF.View.EmployeeModule.EmployeePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      FuserControls-clr-namespace:WPF.ViewsComponent.UserControls     6D   Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     6�     N� Title$  EmployeePage��5      .��5
      ��  �� CornerRadius$ 6��5      
���   �   colorBlancoFondo#���   5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $��15 �6#   �� 5      �� 5      $��15 �6#    � RowDefinitions 5      �� 5      $��8 �6    �� 5      $
��auto �6    �� 5      $��40 �6    �� 5      �� 5      $��8 �6    .+�5      �� $��1��5      $
��Left=�5      $��
30,30,0,15q�5        StackPanelStyle#���  5       .+�5!      2   ,WPF.ViewsComponent.UserControls.CustomButton     Title$ Nuevo Empleado��5"         ImageSource$ /Resource/Image/plus.png��5$         buttonCommand 5#      �� *addModalCommand+5$      5%      �� 5'      $��1��5(      $��Right=�5)      $��	0,0,30,15q�5*      #���  5+      .+�5,      ��  �� Orientation$ 
Horizontal=�6   .+�5-      /   )WPF.ViewsComponent.UserControls.SearchBar  $��30��5.      $	��250��5/      $��0 0 20 0q�52       � DataContext 50      �� *listingViewModel+	   Text	 51      �� *text+
 �� Mode$
 TwoWay=�52      54      55      �� 57      $��2��58      $��1��59      $��SemiBold"�5:       �� TextAlignment$ Center=�5;      $��Bottom=�5<        EmployeeWindowTitle#���  5=       ! ElementsDataGridTitleFontSize#���  5>      � 5@      $��3��5A      $��1��5B       5C      �� 5D      $��* �6$   �� 5E      $
��auto �6$   .+�5H      �� $��0��6   $��Center=�5I      $��Center=�5J       5K      �� *listingViewModel+.+�5L      6   0WPF.ViewsComponent.CustomControls.LoadingSpinner     Diameter$	 100Q�5M         	Thickness$ 5Q�5O         Color
 �   �   	IsLoading 5N      �� *	isLoading+5P      �� 5Q      
���  ��$��18(�5S      ��5Q       �� *errorMessage+y�5T      �� *hasErrorMessage+   BooleanToVisibilityConverter �� 	Converter# [ 5U      &   System.Windows.Controls.DataGrid  5W      -   5          Name$ elementDataGrid��5X        ElementsDataGrid#���  5[      $��30 10q�5\      $��0��5]      ��5Y      �� *listingViewModel.listing+y�5Z      �� *#!listingViewModel.isListingVisible+# [  � 	Resources 5_        optionsCell  ButtonStyle �� Path �� RelativeSource �� AncestorType3  -System.Windows.Controls.Ribbon.RibbonCheckBox  StatusCheckBoxDataGridStyle��%�  &	       �� 5`      .R�5a      �� $��Center=�5b      $ 
Horizontal=�5c      .+�5d   "   �� $��Editar��6)   #���  5g   %   ���#2196F3$��0 0 5 0q�5i   %   ��5e   %   �� $" DataContext.editModalCommand� �� "  ��5f   %   �� 5i   %     5j   "   #���  5l   -   ��5j   1   �� $% DataContext.changeStatusCommand� �� "  ��5k   -   �� 5l   -   5m      5n      5o         Columns 5p      0  *System.Windows.Controls.DataGridTextColumn  5q      ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6H   �� *
IdEmployee+  5r      $ Nombres��6-   $
 auto 6>    6K   �� *Name+  5s      $ 	Apellidos��6-   $
 auto 6@    6M   �� *
LastName+  5t      $ 
Dirección��6-   $ * 6@    6J   �� *	Address+4
  .System.Windows.Controls.DataGridTemplateColumn
  5u      $ Opciones��61   $	 155 6C    
  CellTemplate# [ 6O   5w      � 5y      $
��30 0q�5z      $��1��5{      $��Center=�5|      $
��Left=�5}       5~      �� *listingViewModel+y�5      �� *hasErrorMessage+# [ .+�5�      �� $��Recargar��6   $
��10 0q�5�      $��14(�5�      ��5�      �� *loadCommand+5�      � 5�      $
��30 0q�5�      $��1��5�      $��Center=�5�      $��Right=�5�       5�      �� *listingViewModel+y�5�      �� *isListingVisible+# [ .+�5�      ��  	 textBlockListViewStyle#��� 	 5�      ��5�      �� *listing.Count+�� 5�      #��� 	 5�      $��
 elementos��5�      5�      5�      5�      5�       5�       �� 
TargetType �� Property �� Value �� 
TargetType ��Name  �� Padding! J� SnapsToDevicePixels" �� Triggers# P� Property$ P� Value% �� 
TargetName��%�  &		       &	 �     &	 �    �� 5�   
   " ��6   .�5�      ��  � ��$ 17(�6)   �� 5�       � ��$ Normal"�6+   �� 5�       � ��
 �   �6+   5�      �� 5�   
   " ��5�      .�5�      ��  � ��$ 2��6)   �� 5�       � ��$ 1��6,   �� 5�       � ��$ Bottom=�62   �� 5�       � ��$ 32��6'   �� 5�       �@��Orientation$ 
Horizontal=�6,   5�      �� 5�   
   " ��5�      .�5�      ��  � ��$ 15(�6)   �� 5�       � ��
 �����6+   �� 5�       � ��$ Normal"�6+   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ border��6!   #��z��5�      $ 4��5�      $  8 0 8 0q�5�      
�������$	��0.6q�5�      $
! true��5�      ._�5�      �� #��z��6-   5�      " 5�      P� 5�      # �@J�IsMouseOver$
$ true��6=   . �5�   "   �� $% border��6?    � ��
 �����6S   �� 5�   "   $% border��6@    � ��
 �   �6T   �� 5�   "    � ��
 �   �6?   5�      P� 5�      # � ��$
$ true��6;   . �5�   "   �� $% border��6?    � ��
 �����6S   �� 5�   "   $% border��6@    � ��
 �   �6T   5�      5�      5�      5�      5�      5�      
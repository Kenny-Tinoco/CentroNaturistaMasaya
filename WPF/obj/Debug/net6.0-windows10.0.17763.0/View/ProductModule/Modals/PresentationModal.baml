   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      .    (WPF.View.ProductModule.PresentationModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      .��5      � $	��440��6   .+�5	      -   'WPF.ViewsComponent.CustomControls.Popup      IconBar$&   /Resource/Image/presentation.png��5
         TitleBar 5	      �� *
titleBar+   ExitCommand 5      �� *closeCommand+.��5      �  � RowDefinitions 5      �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $��12 �6   �� 5      $
��auto �6   �� 5      $��5 �6   .+�5      �� $��1��6   $��Presentación��5   	      GroupBoxStyle#���   5   	   .��5      � $��5q�6    � ColumnDefinitions 5      �� 5   	   $
��auto �6   �� 5   	   $��20 �6   �� 5   	   $��* �6    5      �� 5    	   �� 5!   	   $��20 �6   �� 5"   	   .+�5%      �� $��0��6   $��5 0 0 0q�5&   
   .+�5'   	   �� $��Código��6     TextBlockStyle#���  5(      �� 5)   	   $��17(�5*       �� TextAlignment$ Center=�5+      ${�False��5,      
������ ��5)      �� *id+5-      5.   	   �� 50      $��2��6   $��0 0 5 0q�51   
   .+�52   	   �� $��Nombre��6   #���  53      �� 55   	   $��17(�56      $��Normal"�57        TextBoxStyle#���  58      $ Center=�59      ��55      �� *name+ �� UpdateSourceTrigger$ PropertyChanged=�59      5:   	   �� 5<      $��2��6   $��0��5=   
   $��3��5>   
    �� Orientation$ 
Horizontal=�5?   
   $��Center=�5@   
   .+�5B   	   �� $��Guardar��6   $��Normal"�5C   
     CustomButtonStyle#���  5G   
   
�������$��75��5I   
   {�5D   
   �� *	canCreate+��5E   
   �� *saveCommand+��5F   
   �� *
isEditable+5I   
   �� 5K   	   $��30 0 0 0q�6   $��Limpiar��5L   
   $��Normal"�5M   
   #���  5O   
   
�������$��75��5Q   
   ��5N   
   �� *resetCommand+y�5R   
   �� *
isEditable+   BooleanToVisibilityConverter �� 	Converter# [ �� 5T   	   $��30 0 0 0q�6   $��Eliminar��5U   
   ���#F44336  DeleteButtonStyle#���  5X   
   ��5V   
   �� *deleteCommand+y�5Y   
   �� *
isEditable+# [ 5[   	   5]      5^      �� 5`      $��3��6   $��Lista de presentación��5a   	   #���   5b   	   .��5c      � $��0��6   $��0��5d   	    5e      �� 5f   	   $��* �6   �� 5g   	   $
��auto �6   .+�5j      �� $��0��6   $��Center=�5k   
   $��Center=�5l   
   	 � DataContext	 5m   
   �� *listingViewModel+.+�5n   	   6   0WPF.ViewsComponent.CustomControls.LoadingSpinner  
   Diameter$
 60Q�6      	Thickness$ 5Q�5p         Color
 �   �   	IsLoading 5o      �� *	isLoading+5q      �� 5r   	   
���  ��$��18(�5t      ��5r      �� *errorMessage+y�5u      �� *hasErrorMessage+# [ 5v   	   &   System.Windows.Controls.DataGrid  5x      $��0��6     ElementsDataGrid#���  5{      $��5 10 5 5q�5|      $	��135��5}      $	��380��5~      ��5y      �� *listingViewModel.listing+y�5z      �� *#!listingViewModel.isListingVisible+# [  � 	Resources 5   	     optionsCell  ButtonStyle �� Path �� RelativeSource �� AncestorType3  -System.Windows.Controls.Ribbon.RibbonCheckBox 	 StatusCheckBoxDataGridStyle��%�  &	       �� 5�   
   .R�5�      �� $��Center=�6   $ 
Horizontal=�5�      .+�5�      �� $��Editar��6   #���  5�      ���#2196F3$��0 0 5 0q�5�      ��5�      �� $ DataContext.editCommand� �� "  ��5�      �� 5�        5�      #��� 	 5�      ��5�      �� $% DataContext.changeStatusCommand� �� "  ��5�      �� 5�      5�      5�      5�   
      Columns 5�   	   0  *System.Windows.Controls.DataGridTextColumn  5�   
   ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *IdPresentation+  5�   
   $ Nombre��6   $	 150 5�       5�      �� *Name+4	  .System.Windows.Controls.DataGridTemplateColumn	  5�   
   $ Opciones��6!   $ * 5�       	  CellTemplate# [ 5�      5�   	   � 5�      $��1��6   $	��5 0q�5�      $��Center=�5�      $��Right=�5�      	 5�      �� *listingViewModel+y�5�      �� *isListingVisible+# [ .+�5�   	   �� #���  6   $��14(�5�      ��5�      �� *listing.Count+�� 5�   	   #���  6   $��14(�5�      $��
 elementos��5�      5�   	   5�      5�      5�      5�      5�       5�       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding J� SnapsToDevicePixels �� Triggers  P� Property! P� Value" �� 
TargetName��%�  &	        &	 �     &	 P    �� 5�      " ��5�      .�5�      ��  � ��$
 16.5(�5�      �� 5�       � ��
 �   �5�      �� 5�       � ��$ SemiBold"�5�      5�      �� 5�      " ��5�      .�5�      ��  � ��$ 17(�5�      �� 5�       � ��
 �   �5�      �� 5�       � ��$ Normal"�5�      5�      �� 5�      " ��5�      .�5�      ��  � ��$ 15(�5�      �� 5�       � ��
 �����5�      �� 5�       � �� 5�      �� 5�      " ��6   .R�5�      �� $ border��6   #��z��5�   	   $ 4��5�   	   $ 8 0 8 0q�5�   	   
�������$	��0.6q�5�   	   $
 true��5�   	   ._�5�   	   �� #��z��6   5�   	    5�      P� 5�   	     �@J�IsMouseOver$
! true��5�      . �5�   
   �� $" border��5�       � ��
 �����5�      �� 5�   
   $" border��5�       � ��
 �   �5�      �� 5�   
    � ��
 �   �5�      5�   
   P� 5�   	     � ��$
! true��5�      . �5�   
   �� $" border��5�       � ��
 �����5�      �� 5�   
   $" border��5�       � ��
 �   �5�      5�   
   5�      5�      5�      5�      5�      
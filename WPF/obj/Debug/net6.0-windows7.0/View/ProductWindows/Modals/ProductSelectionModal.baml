   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF.ViewComponents.UserControlsWPF.ViewComponents.UserControls  5      3    -WPF.View.ProductWindows.ProductSelectionModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      FuserControls-clr-namespace:WPF.ViewComponents.UserControls     5      .��5      � $	��400��5   	   $	��800��5	   	   .+�5
   
   +   %WPF.ViewComponents.UserControls.Popup      iconBar$!  /Resource/Image/product.png��5         titleBar 5      �� *
titleBar+   buttonExitCommand 5      �� *exitCommand+   popupContent 5      � 5       � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      $��10 �6(   �� 5      $��* �6(   .+�5      � $��0��5      .+�5      /   )WPF.ViewComponents.UserControls.SearchBar     	BarHeight$ 30Q�5         BarWidth$	 250Q�5      $��0 0 20 0q�5         searchBarText 5      �� *
searchText+ �� Mode$ TwoWay=�5      5      � 5!      $��2��5"      .+�5$      &   System.Windows.Controls.DataGrid     ElementsDataGrid#���   5&      ��5%      �� *logic.catalogue+	 � 	Resources	 5(        optionsCell
 �� Orientation  ButtonStyle �� Path �� RelativeSource �� AncestorType��%   &	       �� 5)   "   .R�5*   &   �� $��Center=�5+   %   $
 
Horizontal=�5,   %   .+�5-   *   �� $��Ir��61   #���  50   -   ���#2196F3��5.   -   �� $ DataContext.goCommand� �� "  ��5/   -   �� 51   -   52   '   53   #   54         Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��65      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *	idProduct+  57   "   $ Nombre��65   $	 180 6E    6Q   �� *name+  58   "   $ Descripción��65   $ * 6J    6T   �� *description+4  .System.Windows.Controls.DataGridTemplateColumn  59   "   $ Opciones��69   $
 auto 6K      CellTemplate# [ 6X   5;      5<      5>      5B      5C      	 5D       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	       �� 5E   
   " ��5F      .�5G      ��  � ��$ 15(�6)   �� 5H       � ��
 �����6+   �� 5I       � ��$ Normal"�6+   �� 5J       � �� 5K      �� 5L      " ��6&   .R�5N      �� $ border��6!   #��z��5O      $ 4��5P      $ 8 0 8 0q�5Q      
�������$	��0.6q�5S      $
 true��5T      ._�5U      �� $ contentPresenter��6/   $|�False��5V   +   $��Center=�5W   +   $��1q�5X   +   $
��True��5Y   +   $
 True��5Z   +   $��Center=�5[   +   5\       5]      P� 5^       �@J�IsMouseOver$
 true��6=   . �5_   "   �� $ border��6?    � ��
 �����6S   �� 5`   "   $ border��6@    � ��
 �   �6T   �� 5a   "    � ��
 �   �6?   5b      P� 5c       � ��$
 true��6;   . �5d   "   �� $ border��6?    � ��
 �����6S   �� 5e   "   $ border��6@    � ��
 �   �6T   5f      5i      5k      5l      5m      5n      
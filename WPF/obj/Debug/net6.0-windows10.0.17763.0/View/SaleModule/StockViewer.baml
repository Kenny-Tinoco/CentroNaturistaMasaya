   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF.ViewsComponent.UserControlsWPF.ViewsComponent.UserControls  5      U/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      %    WPF.View.SaleModule.StockViewer   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      FuserControls-clr-namespace:WPF.ViewsComponent.UserControls     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5      -   5          >�Name$
  root��5      .��5      ��  �� CornerRadius$ 8��6
   
���   �$	��0.3q�5       �� Padding$
 20 0q�5         colorBlancoFondo#��[  5      $��0 0 10 0q�5      ._�5      � $	��500��6	    � RowDefinitions 5      �� 5      $��* �6   �� 5      .+�5      � $��0��6
    5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5      �� $��0��6   $��Visor de productos��5    
   $��17(�5!   
   $��SemiBold"�5"   
   $��Center=�5#   
   $��0 0 0 30q�5$   
   ]� 5&      $��1��6   .+�5'      /   )WPF.ViewsComponent.UserControls.SearchBar  $��30��6   $	��200��5(         Text 5)      �� *
searchText+ �� Mode$ TwoWay=��� 5+      $��Cargar��6   $��17(�5,      $	��5 0q�5-      $��10 0 0 0q�5/      y�5.      �� *
hasListing+ ' #InverseBooleanToVisibilityConverter �� 	Converter# [ ��50      �� *loadCommand+�� 52      $��Right=�6   $��Right=�53   
    �� DisplayMemberPath$
 Name��55   
   $��17(�56   
   ��54   
   �� *presentationListing+ �� SelectedItem 57   
   �� *presentationSelected+�� 59      $��Ver por:��6   $��17(�5:      $
��10 0q�5;      $��Right=�5<      $��Center=�5=      $��Right=�5>      5?      6   0WPF.ViewsComponent.CustomControls.LoadingSpinner  5A      	   Diameter$	 50Q�6   $��2��5B      
   	Thickness$
 2Q�5D         Color
 �   �   	IsLoading 5C      �� *	isLoading+5E      &   System.Windows.Controls.DataGrid  5F      -   5          Name$ dataGridListing��5G   	   $��2��5F         AutoGenerateColumns$ False��5I   	   $��15(�5J   	      CanUserAddRows$ False��5K   	      CanUserDeleteRows$ False��5L   	      
IsReadOnly$
 True��5M   	   
�������$	��0 5q�5O   	   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5P   	     DataGridGenericColumnHeader   ColumnHeaderStyle# �  5Q   	   ��5H   	   �� *	listing+y�5R   	   �� *
hasListing+   BooleanToVisibilityConverter# [  J� InputBindings 5S      d� 5T       d� MouseAction$ LeftDoubleClicke�6    �� Command 5U      �� *sendItemCommand+ �� CommandParameter 5V      �� *SelectedItem+ �� RelativeSource ��  �� AncestorType"     Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   Header$ Cód.��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5Z      �� *	IdStock+ �� StringFormat$	 000��  5[      $ Producto��6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5\       5]      �� *Name+  5^      $ Descripción��6   $ * 5_       5`      �� *Description+  5a      $ Presentación��6   $
 auto 5b       5c      �� *Presentation+5e      5g      � 5i      $��1��6
   y�5j      �� *
hasListing+# [  � ColumnDefinitions 5k      �� 5l      $��* �6   �� 5m      $
��auto �6   .+�5p      �� $��0��6   $
��Auto=�5q   
     � DataContext  5r   
   �� *SelectedItem+! �� ElementName$! dataGridListing��.��5t      �� .+�5v      ]� .+�5w   	   � $��Center=�6   $��0 0 10 0q�5x       5y   
   �� 5z      $��* �6   �� 5{      $
��auto �6   .+�5}   
   �� $��0��6   
���   �$��1q�5      $ 5q�5�      $ 6��5�      $	��150��5�      $	��150��5�      
�������._�5�      �� ��6   �� *Image+5�      �� 5�   
   $��1��6   $��17(�5�      $��Center=�5�      �� 5�   *   $�Código:��6.    �� 5�   *   $��SemiBold"�5�      �5�   .   �� *	IdStock+$	 000��5�      5�      5�   
   � 5�   	    5�   
   �� 5�      $
��auto �6   �� 5�      $
��auto �6   .+�5�   
   �� $��0��6   $	��0 5q�5�      .+�5�      �� $��17(�6   $��* Nombre��5�      �� 5�      " �� 
IsReadOnly$
" True��6   $��Disabled=�5�      $
��Auto=�5�      # �� TextWrapping$
# Wrap=�5�      $ �� TextAlignment$$ Justify=�5�      $��50��5�      $��17(�5�      $��SemiBold"�5�      
������ ��5�      �� *Name+5�      5�      �� 5�   
   $��1��6   $	��0 5q�5�      .+�5�      �� $��* Descripción��6   $��17(�5�      �� 5�      $
" True��6   $��Disabled=�5�      $
��Auto=�5�      $
# Wrap=�5�      $$ Justify=�5�      $��70��5�      $��17(�5�      $��SemiBold"�5�      
������ ��5�      �� *Description+5�      5�      5�   
   5�   	   � 5�      $��0 10 0 0q�6    5�   	   �� 5�   
   $��* �6   �� 5�   
   $
��auto �6    5�   	   �� 5�   
   $
��auto �6   �� 5�   
   $��5 �6   �� 5�   
   $
��auto �6   �� 5�   
   $��5 �6   �� 5�   
   $
��auto �6   .+�5�   	   �� $��0��6   $��1��5�      $��17(�5�      $��Disabled=�5�      $
��Auto=�5�      $
��Wrap=�5�      % �� TextAlignment$% Justify=�5�      �� 5�   *   �6.   �� *DataContext.priceMessage+$
! root��$ OneWay=� �� 5�   *   $��SemiBold"�5�      �5�   .   �� *Price+$ 0 córdobas��5�      5�   
   �� 5�   	   $��0��6   $	��0 5q�5�      $��0��5�      $
��Left=�5�      $��17(�5�      �� 5�   *   $�* En stock:��6.    �� 5�   *   $��SemiBold"�5�      �5�   .   �� *
Quantity+��5�      �� *
Quantity+  QuantityColorConverter# [ 5�      5�   
   �� 5�   	   $��2��6   $��17(�5�      �� 5�   *   $�* Presentación:��6.    �� 5�   *   $��SemiBold"�5�      �5�   .   �� *Presentation+5�      5�   
   �� 5�   	   $��5��6   $��2��5�      $��17(�5�      �� 5�   *   $�* Vencimiento:��6.    �� 5�   *   $��SemiBold"�5�      �5�   .   �� *
Expiration+$ dddd dd MMMM yyyy��& �� ConverterCulture$& es��5�      5�   
   5�   	   5�      5�      5�      5�      5�      ' � 	Resources' 5�        ButtonCloseStyle( �� 
TargetType) �� Property* �� Value+ �� 
TargetType, ��Name- �� Triggers. P� Property/ P� Value0 �� 
TargetName  ButtonSelectStyle  colorSecondary��%z  &	       &	 [    �� 5�      "( ��5�      .�5�      �� ) � ��* 5�      �� 5      "+ ��6   .R�5     �� $, border��6   
������ $	��0.6q�5  	   
������ $��25��5  	   $��25��5  	   $ 20��5  	   ._�5	  	   �� $��X��6   $��14(�5
     $|�False��5     $��Center=�5     $��1q�5     $��Center=�5     5  	   - 5     P� 5  	   . �@J�IsMouseOver$
/ true��5     . �5  
   �� $0 border��5     ) � ��
* �  ��5     �� 5  
   $0 border��5     ) � ��
* ���� 5     �� 5  
   ) � ��
* �����5     5  
   P� 5  	   . � ��$
/ true��5     . �5  
   �� $0 border��5     ) � ��
* ���� 5      �� 5!  
   $0 border��5"     ) � ��
* �   �5#     �� 5$  
   ) � ��
* �   �5%     5&  
   5)     5+     5,     �� 5-     "( ��5.     .�5/     �� ) � ��* 50     �� 51     "+ ��6   .R�53     �� $, border��6   
������ $	��0.6q�55  	   
������ $ 90��57  	   ._�58  	   �� $��Center=�6   $��1q�59     $��Center=�5:     #��z��5;     5<  	   - 5=     P� 5>  	   . �@J�IsMouseOver$
/ true��5?     . �5@  
   �� $0 border��5A     #* �  5B     ) � ���� 5C  
   $0 border��5D     ) � ��
* ���� 5E     �� 5F  
   ) � ��
* �����5G     5H  
   P� 5I  	   . � ��$
/ true��5J     . �5K  
   �� $0 border��5L     ) � ��
* ���� 5M     �� 5N  
   $0 border��5O     ) � ��
* �   �5P     �� 5Q  
   ) � ��
* �   �5R     5S  
   5V     5X     5Y     5[     5\     
   M S B A M L   `   `   `  ����R  NCentro Naturista Masaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.ViewsComponent.CustomControls!WPF.ViewsComponent.CustomControls  5      B    <WPF.ViewsComponent.Menus.ConsultationModuleTabControlBarMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bcustom/clr-namespace:WPF.ViewsComponent.CustomControls     5        � 	Resources  5
          BooleanToVisibilityConverter9   3WPF.ViewsComponent.CustomControls.HamburgerMenuItem �� 
TargetType �� Property �� Value  CustomButtonFontSize  colorBlancoFondo6  0System.Windows.Controls.Ribbon.RibbonRadioButton �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions	 �� TargetProperty	
 �� To g� Duration N� ExitActions P� Property P� Value��%{  &	        '       �� 5      6!   �� 5      "  6
   .�5      ��  � ��$ 20 10q�5      �� 5       � ��# �  5      �� 5       � ��
 �   �5      �� 5       � ��# �  5      �� 5       �@ CornerRadius$ 6��5       5      ]� 5       5      �� 5       �@J�IsMouseOver$
 True��5   
   �� 5       �@d�	IsChecked$ FalseY�5    
   ./�5"      ��  � ��
 �����5#       5$      �� 5%      .��5&   	   �� .��5'   
   �� $(	 "Background.(SolidColorBrush.Color)�6   
 #0c6e825(      $ 0:0:0.1D�5)      5*   
   5+   	    5-      �� 5.      .��5/   	   �� .��50   
   �� $*	 $(Background).(SolidColorBrush.Color)�6   
 #E1E2E151      $ 0:0:0.1D�52      53   
   54   	   56      ]� 58       59      �� 5:       �@J�IsMouseOver$
 True��5;   
   �� 5<       �@d�	IsChecked$
 TrueY�5=   
    5?      �� 5@      .��5A   	   �� .��5B   
   �� $(	 "Background.(SolidColorBrush.Color)�6   
 #132c335C      $ 0:0:0.1D�5D      5E   
   5F   	   5H      P� 5J       �@d�	IsChecked$
 TrueY�5K      . �5L      ��  � ��
 �����5M      �� 5N       � �� �#132c335O      5P      P� 5R       �@d�	IsChecked$ FalseY�5S      . �5T      ��  � �� �#E1E2E15U      5V      5Y      5Z      .��5\      � .+�5^      �� -   5         ��Name$ 
stackPanel��5^       �� Orientation$ 
Horizontal=�5_      .+�5a         d� 	IsChecked$
 TrueY�5b      ��5a      �� *navigatePatientConsultation+.��5c      �� $��Atender consulta��6   5d        5e      $��	10 0 10 0q�5f      ��5e      �� *navigateConsultationPage+.��5g      �� $��Registros de Consultas��6   5h        5i      ��6   �� *navigatePatientPage+.��5j      �� $��	Pacientes��6   5k      5l      5n      5o      
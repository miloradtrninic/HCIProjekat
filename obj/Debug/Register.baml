   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HCIProjekatHCIProjekat  5   	       HCIProjekat.Register   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *projclr-namespace:HCIProjekat     5   	     � Title$  Registracija��5   	   $	��450��6   $	��500��6+    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6\    � 	Resources 5         ValidationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path	 ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5	      �� $ 
Horizontal=�6   $	��Top=�66   .+�5
      � $��12��6   $��12��6&   .+�5      A� $��12��6"   $��12��6-   
���  ��$��Center=�6D   $��Center=�6a   6~   �� 5      
�������$��Heavy"�67   $��8(�6J   $��Center=�6W   $��Center=�6t   $ Center=�6�    5      �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5   Z   5      �� 5      
���  ��$��12"�61   $��2,0,0,0q�6A   ��6R   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�6�   5      �� 5      $	 ErrorAdorner��6,   6D   5      5      5      
 J� CommandBindings
 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$  proj:RoutedCommands.Accept��5      6�     5   
   -   5        $  proj:RoutedCommands.Escape��5      6   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��2* �6   6,   �� 5      $��6* �6   6,   �� 5       $��1* �6   6,    � RowDefinitions 5"   
   �� 5#      $��1* �6   6*   �� 5$      $��2* �6   6*   �� 5%      $��2* �6   6*   �� 5&      $��2* �6   6*   �� 5'      $��2* �6   6*   �� 5(      $��1* �6   6*   .+�5*   
   �� $��Center=�6   $ 
Horizontal=�62   $��0��6K   $��1��6X   $��2��6h   .+�5+      A� $��5q�6   $��30��6!   $��30��6,   
���2�2�6K   A� 5,      $��5q�6   $��30��6!   $��30��6,   ���	#FF9A8FF26L   A� 5-      $��5q�6   $��30��6!   $��30��6,   ���#FF9BA96J   5.      �� 50   
   $��1��6   $��1��6    $��Center=�6-   $��13(�6H   .��6V   Ime:6\   �� 51   
   $��2��6   $��1��6%   .+�52      �� -   5         ��Name$ NameBoxError��52      $y�Hidden=�6*   
���  ��.��6O   Korisničko ime ne postoji.6k   �� 53      -   5         ��Name$ NameBox��53      $��50��6'   $��30(�66    �� 	MaxLength$ 18��6D    =� ErrorTemplate# [  6S   .��6�   ��54      �� 55      $	 Ime�6    �� UpdateSourceTrigger$ PropertyChanged=�6)    �� ValidationRules 56      '   !HCIProjekat.EmptyStringValidation  57      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�69   6]   &    HCIProjekat.NumberCharValidation  58      $ RawProposedValue=�68   6\   5:      .��5;       5<      5=      �� 5?   
   $��1��6   $��2��6    $��Center=�6-   $��13(�6H   .��6V   
Prezime:6`   �� 5@   
   $��2��6   $��2��6%   .+�5A      �� -   5        $ LastNameBoxError��5A      $y�Hidden=�6.   
���  ��.��6S   Korisničko ime ne postoji.6o   �� 5B      -   5        $ LastNameBox��5B      $��50��6+   $��30(�6:   $ 18��6H   # [  6X   .��6�   ��5C      �� 5D      $ Prezime�6   $ PropertyChanged=�6-    5E        5F      $ RawProposedValue=�69   6]     5G      $ RawProposedValue=�68   6\   5I      .��5J       5K      5L      �� 5N   
   $��1��6   $��3��6    $��Center=�6-   $��13(�6H   .��6V   Korisničko ime:6g   �� 5O   
   $��2��6   $��3��6%   .+�5P      �� -   5        $ UserBoxError��5P      $y�Hidden=�6*   
���  ��.��6O   Korisničko ime već postoji.6l   �� 5Q      -   5        $ UserBox��5Q      $��50��6'   $��30(�66   $ 18��6D   # [  6�   .��6�   ��5R      �� 5S      $ UserName�6   $ PropertyChanged=�6.    5T        5U      $ RawProposedValue=�69   6]     5V      $ RawProposedValue=�68   6\   5X      .��5Y       5Z      5[      �� 5]   
   $��1��6   $��4��6    $��Center=�6-   $��13(�6H   .��6V   
Lozinka:6`   �� 5^   
   $��2��6   $��4��6%   .+�5_      �� -	   5        $ PassBoxError��5_      $y�Hidden=�6+   
���  ��.��6P   Lozinka neispravna.6e   G� 5`      -
   5         G�Name$ PasswordBox��5`   F   $��50��6   $��30(�6)    G� 	MaxLength$ 15��67   6]   5a      �� 5c   
   -   5        $��1��5c      $��5��6!   $��80��6.   $��16(�6:   $��5q�6H   .��6o   
Odustani6y   �� 5e   
   -   5        $��2��5e      $��5��6!   $	��100��6.   $��Right=�6:   $��5q�6V   $��16(�6c   $��Registruj me��6�   5g      5h      
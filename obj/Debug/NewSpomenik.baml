   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HCIProjekatHCIProjekat  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       HCIProjekat.NewSpomenik   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *projclr-namespace:HCIProjekat     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5          �Name$  NewSpomenikWindow��5   	    � Title$ Novi spomenik��5   	   $	��700��6   $	��750��6,    � WindowStartupLocation$ CenterOwner=�68   $��16(�6\      HCIProjekat.HelpProvider   HelpKey$ spomenikDialog��6j    � 	Resources 5	       �� 
TargetType �� Property �� Value   SingletonMain S� 
ObjectType   HCIProjekat.Main	 S� 
MethodName  ValidationErrorTemplate
 �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path ��Name��%"  '��       '�� �     &	      &	 I    �� 5
   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$ 0,15,0,0q�6'   6:   �� 5       � ��$
 30px��6*   69   �� 5       � ��$ 24(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 0,5,0,5q�6'   69   5      S� 5   
   "  63   $	 GetInstance��6S   �� 5   
   .R�5      ]� .+�5      �� $
 
Horizontal=�6   $	��Top=�66   .+�5       � $��12��6   $��12��6&   .+�5!      A� $��12��6"   $��12��6-   
���  ��$��Center=�6D   $��Center=�6a   6~   �� 5"      
�������$��Heavy"�67   $��8(�6J   $��Center=�6W   $��Center=�6t   $ Center=�6�    5#      �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5$   Z   5%      �� 5&      
���  ��$��12"�61   $��12(�6A   $��2,0,0,0q�6O   ��6`   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�6�   5'      �� 5(      $ ErrorAdorner��6,   6D   5)      5*      5,       J� CommandBindings 5-      )  #System.Windows.Input.CommandBinding  5.   
   -   5           Command$  proj:RoutedCommands.Accept��5.      6}     5/   
   -   5        $  proj:RoutedCommands.Escape��5/      6~     50   
   -   5        $ ApplicationCommands.Help��50      6<   .��55      � $��5q�6    � ColumnDefinitions 57   
   �� 58      $��1* �6   �� 59      $��2* �6   �� 5:      $��1* �6    � RowDefinitions 5<   
   �� 5=      $
��auto �6   �� 5>      $
��auto �6   �� 5?      $
��Auto �6   �� 5@      $
��auto �6   �� 5A      $
��auto �6   �� 5B      $
��auto �6   �� 5C      $
��auto �6   �� 5D      $
��auto �6   �� 5E      $��1* �6   �� 5F      $
��auto �6   �� 5G      $
��auto �6   �� 5H      $
��auto �6   �� 5I      $
��Auto �6   .+�5L   
   �� $��Center=�6   $��0��6+   $��0��6;   $��Oznaka*:��6H   6]   �� 5M   
   -   5         ��Name$ 	OznakaBox��5M      $��1��6&   $��0��66    =� ErrorTemplate# [ 6C   $ spomenikDialog_oznaka��6�   .��6�   ��5N      �� 5O      $ Oznaka�6    �� UpdateSourceTrigger$ PropertyChanged=�6(    �� ValidationRules 5P      '   !HCIProjekat.EmptyStringValidation  5Q      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�65   6Y   &    HCIProjekat.NumberCharValidation  5R      $ RawProposedValue=�64   6X   &    HCIProjekat.OznakaSpomenikUnique  5S      $ RawProposedValue=�64   6X   5U      .��5W      5X      �� 5[   
   $��Center=�6   $��0��6,   $��1��6<   $��Ime*:��6J   6\   �� 5\   
   -   5        $ ImeBox��5\      $��1��6"   $��1��62   # [ 6?   $ spomenikDialog_ime��6�   .��6�   ��5]      �� 5^      $	 Ime�6   $ PropertyChanged=�6%    5_        5`      $ RawProposedValue=�65   6Y   5b      .��5d      5e      �� 5g   
   $��Center=�6   $��0��6+   $��2��6;   $��Godišnji prihod ($)*:��6H   �� 5h   
   -   5        $ 	PrihodBox��5h      $��1��6%   $��2��65   # [ 6B   $ spomenikDialog_prihod��6�   .��6�   ��5i      �� 5j      $ Prihod�6   $ PropertyChanged=�6(    5k         HCIProjekat.ZaradaVal  5l      $ ConvertedProposedValue=�6)   6S   (	   "HCIProjekat.StringDoubleValidation	  5m      $ RawProposedValue=�66   6Z   5o      .��5q      5t      �� 5v   
   $��0��6   $��3��6    $��	Etiketa*:��6-   �� 5w   
   $��1��6   $��3��6%   $
 Vertical=�62   .+�5x   
   �� -   5         ��Name$ ErrorEtiketa��5x      $!��Odaberite bar jednu etiketu��6'   
���  ��$��12(�6^   $
��Left=�6l   $��Center=�6�   $y�	Collapsed=�6�   6�   �� 5y      -	   5         ��Name$ 
EtiketaBox��5y      $��80��6*   $��50��69    �� SelectionMode$ Multiple=�6�   $��0,5,0,0q�6�   $ spomenikDialog_etiketa��6�   ��6H   ��  �� Source# [  $ EtiketaLista���5z      �� 5{      .R�5|      �� $
 
Horizontal=�6!   .+�5}      �� $��20��6$   $��20��6/   ��6;   �� *	BojaKod+�� 5~      $
��Bold"�6<   $��Center=�6N   $��5,0,0,0q�6i   ��6$   �� *Oznaka+6i   5      5�      5�      5�      �� 5�   
   -
   5        $	��Top=�5�      $��2��6)   $��3��69   $��30��6F   $��5q�6U   $ etiketaDialog��6�   .��6�   Nova etiketa6�   �� 5�   
   $��0��6   $��4��6    $��Tip spomenika*:��6-   �� 5�   
   $��1��6   $��4��6%   $
 Vertical=�62   .+�5�      �� -   5        $ ErrorTip��5�      $��Odaberite tip��6'   
���  ��$��12(�6P   $
��Left=�6^   $��Center=�6y   $y�	Collapsed=�6�   6�   �� 5�      -   5         ��Name$ TipBox��5�      $ spomenikDialog_tip��6�   ��6'   �� # [  $ TipspomenikaLista� �� SelectedItem 6}   �� *	Spomenika+6�   5�      �� 5�   
   -   5        $��2��5�      $��4��6!   $��5q�6L   $ 	tipDialog��6W   .��6}   
Novi tip6�   �� 5�   
   $��0��6   $��5��6    $��U naseljenom mestu? *:��6-   �� 5�   
   $
 
Horizontal=�6   $��1��6.   $��5��6>   .+�5�      �� $��0, 0 ,5px, 0q�6<   $��Center=�6S   $ spomenikDialog_naselje��6n    d� 	IsChecked 6   �� *NaseljeChecked+6n   5�      �� 5�   
   $��0��6   $��6��6    $��Arheološki obrađen? *:��6-   �� 5�   
   $
 
Horizontal=�6   $��1��6.   $��6��6>   .+�5�      �� $��0, 0 ,5px, 0q�6;   $��Center=�6R   $ spomenikDialog_arheo��6m    6   �� *AreheoChecked+6m   5�      �� 5�   
   $��0��6   $��7��6    $��UNESCO zasticen?*:��6-   �� 5�   
   $
 
Horizontal=�6   $��1��6.   $��7��6>   .+�5�      �� $��0, 0 ,5px, 0q�6;   $��Center=�6R   $ spomenikDialog_unesco��6m    6   �� *UnescoChecked+6m   5�      �� 5�   
   $	��Top=�6   $��0��6(   $��8��68   $��Opis: ��6F   6Y   �� 5�   
   -   5        $ OpisBox��5�   I     �� TextWrapping$
  Wrap=�6   "! �� VerticalScrollBarVisibility$
! Auto=�6&   $��1��6w   $��8��6�   $	��100��6�   $��90��6�   $��14(�6�   
���   �$	��Top=�6�   $ spomenikDialog_opis��6�   ��6Z   �� $
 Opis�6�   �� 5�   
   $��0��6   $��9��6    $��Era porekla:��6-   �� 5�   
   -   5        $ EraBox��5�      $��1��6d   $��9��6t   $ spomenikDialog_era��6�   ��6$   �� *
EraPorekla+ 6G   �� *Era+5�      �� 5�   
   $��0��6   $��10��6    $��Turistički status:��6.   �� 5�   
   -   5        $ 	StatusBox��5�      $��1��6q   $��10��6�   $ spomenikDialog_turizam��6�   ��6&   �� *TuristickiStatus+ 6O   �� *	Turizam+6�   �� 5�   
   $��0��6   $��11��6    $��Center=�6.   .��6I   Datum otkrivanja:6\   (
  "System.Windows.Controls.DatePicker
  5�   
   -   5        " 
 Name$" Kalendar��5�      $��1��6)   $��11��69   $
��30px��6G   $ spomenikDialog_datum��6~   # 
  SelectedDate# 6U   �� *DatumOtkrivanja+ 5�      :  4System.Windows.Controls.Primitives.DatePickerTextBox��%[   '        �� 5�      "  6   .�5�      ��  �@��
IsReadOnly . 63   5�      5�      $ 
  SelectedDateFormat$ 5�      .  (System.Windows.Controls.DatePickerFormat 5�      	Short=�6*   5�      �� 5�   
   $
 
Horizontal=�6   $��Right=�6.   $��0,5,0,0q�6J   $��2��6[   $��12��6k   .+�5�      �� $
��Left=�6   $
��80px��60   $
��30px��6@   $ ��proj:RoutedCommands.Accept��6Q   .��6w   Snimi6~   �� 5�      $��Right=�6   $
��80px��61   $
��30px��6A   $ ��proj:RoutedCommands.Escape��6R   $��5,0,0,0q�6w   $��30��6�   $��Bottom=�6�   .��6�   
Odustani6�   5�      �� 5�   
   $��2��6   $��0��6%   $��3��62   $
 Vertical=�6C   .+�5�      �� $	��Top=�6   $	��150��6I   $��5q�6Y   ��6,   �� *	ImagePath+6f   �� 5�      -   5        $��Bottom=�5�      $��5q�60   $��Odaberi��6;   $ spomenikDialog_ikonica��6h   5�      5�      5�      
   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HCIProjekatHCIProjekat  5   	   !    HCIProjekat.SpomeniciTabela   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *projclr-namespace:HCIProjekat     5   	     N� Title$  SpomeniciTabela��5   	      HCIProjekat.HelpProvider   HelpKey$ tabelaSpomenika��6!   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   6,   �� 5
      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��7* �6   6,   �� 5      $��1* �6   6,   .+�5   
   �� -   5         ��Name$ Pretraga��5   M   $��0��6   $��0��6   $��24(�6_   ��6/   �� *SearchString+6�   �� 5   
   $��0��6   $��0��6!    J� IsHitTestVisible .  $��Unesite oznaku spomenika��6J   $��Center=�6j   $
��Left=�6�   $��5,0,0,0q�6�   
���������5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � y� �� Value$ 	Collapsed=�63   �� 5       � ��$ 24(�61   6>   	 �� Triggers	 5      �� 5      
 �� Binding
 6&   �� *Text+ �� ElementName$ Pretraga�� �� Value  6U   .a�5      ��  � y�$ Visible=�6;   5      5      5      �� 5   
   -   5        $��0��5      $��1��6   $��5q�6.   
���2�2�.��5       �� $ ��../resources/Search-30.png��6   $��30��68   5!      �� 5"   
   $��1��6   $��0��6%   $��2��65   $
��Auto=�6I   .��5#      &   System.Windows.Controls.DataGrid  -   5          Name$ TabelaSpomenika��5#   5   $��Stretch=�6   $��Stretch=�6N   $��Stretch=�6q   $��Stretch=�5$         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 68      CanUserReorderColumns .    CanUserResizeColumns .    CanUserResizeRows .     CanUserSortColumns .    AutoGenerateColumns .     
IsReadOnly . $	��320��5'   ^   $��14(�6n   ��6   �� *View+   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Oznaka+6R     5*      $	 Ime��6%    62   �� *Ime+6L     5+      $ Era porekla��6%    6:   �� *
EraPorekla+6[     5,      $ Godišnji prihod ($)��6%      Width$
 Auto 6B    6O   �� *GodisnjiPrihod+6t     5-      $ Turistički status��6%    6@   �� *TuristickiStatus+6g     5.      $ Tip spomenika��6%    6<   �� *Tip+6V   4  .System.Windows.Controls.DataGridCheckBoxColumn  5/      $ UNSECO��6)    69   �� *Unesco+6V     50      $ 	U naselju��6)    6<   �� *	Naselje+6Z     51      $ Areheološki obrđen��6)   $
 Auto 6E    6R   �� *	Naselje+6p     52      $ Otkriven��6%   $
 Auto 67    6D   �� *DatumOtkrivanja+ �� StringFormat$ {0:dd.MM.yyyy}��6�      RowDetailsTemplate 54      �� 55      .R�56      �  57      �� 58      $��80 �6/   �� 5:      $	��800 �60   .+�5<      �� $��0��6    $��50��60   $��0,0,5,0q�6<   ��6M   �� *IkonicaPath+�� 5=      $��1��6$   $
��Wrap=�64   ��6H   �� *Opis+6`   5>      5?      5A      5B      5C      5D      
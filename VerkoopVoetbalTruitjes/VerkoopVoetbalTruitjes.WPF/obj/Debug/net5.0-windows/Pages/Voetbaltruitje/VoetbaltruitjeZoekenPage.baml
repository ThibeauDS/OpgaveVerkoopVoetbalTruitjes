   M S B A M L   `   `   `  ����U  QVerkoopVoetbalTruitjes.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:VerkoopVoetbalTruitjes.WPF.Pages.Voetbaltruitje/VerkoopVoetbalTruitjes.WPF.Pages.Voetbaltruitje  5      N    HVerkoopVoetbalTruitjes.WPF.Pages.Voetbaltruitje.VoetbaltruitjeZoekenPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:VerkoopVoetbalTruitjes.WPF.Pages.Voetbaltruitje     5        N� Title$  VoetbaltruitjeZoekenPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��
Competitie��6   $��10q�6&   �� 5   
   -   5        $��ComboBoxCompetitie��5      $��1��6-   $��10q�6=   6�   �� 5   
   $��Ploeg��6   $��10q�6!   $��2��6-   �� 5   
   -   5        $��ComboBoxPloeg��5      $��3��6(   $��10q�68   �� 5!   
   $��Seizoen��6   $��1��6#   $��10q�60   �� 5"   
   -   5        $��Seizoen��5"      $��1��6!   $��1��6.   $��10q�6>   �� 5$   
   $��Prijs��6   $��10q�6!   $��1��6-   $��2��6:   �� 5%   
   -   5        $��Prijs��5%      $��1��6   $��3��6,   $��10q�6<   �� 5'   
   $��Id��6   $��2��6   $��10q�6+   �� 5(   
   -   5        $��Id��5(      $��2��6   $��1��6)   $��0,0,0,10q�69   � 5*   
   $��3��6   $��2��6   $��0,0,0,10q�60    5+      �� 5,      $
��Auto �6#   �� 5-      $
��Auto �6#   �� 5.      $
��Auto �6#   �� 5/      �� 50      $
��Auto �6#   �� 51      .+�54      �� -   5        $��Thuis��54      $��Thuis��6$   $��10q�64   �� 55      -   5        $	��Uit��55      $	��Uit��6"   $��10q�60   $��1��6<   �� 57      $��Versie��6   $��2��6&   $��
10,10,0,10q�66   �� 58      -   5        $��Versie��58      $��3��6$   $��10q�64   �� 5:      $
��Maat��6   $��4��6$   $��
10,10,0,10q�64   �� 5;      -	   5        $��ComboBoxMaat��5;      $��5��6+   $��10q�6X   5<      �� 5>   
   -
   5        $��	SearchBtn��5>      $��Segoe Fluent Icons)�6:   $	����6Z   $��4��6m   $��3��6z   $��25��6�   $��25��6�   $��10q�6�   $��Right=�5?      $	��Top=�61   &   System.Windows.Controls.DataGrid  5A   
   -   5        $��DataGridTruitjes��5A      $��5��6+   $��4��68   $��10q�6L      CanUserReorderColumns$ False��6X      AutoGenerateColumns$ False��6v      CanUserSortColumns$ False��5B         CanUserResizeRows$ False��6.      CanUserAddRows$ False��6H      CanUserDeleteRows$ False��6_   	 �� SelectedItem	 5A   �   �� *SelectedRow+
 �� Mode$
 OneWay=�   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      CanUserResize$ False��6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+$
 OneWay=�6U     5E      $ 
Competitie��6%    69   �� *Club.Competitie+$
 OneWay=�  5F      $ Ploeg��6%    64   �� *
Club.Ploeg+$
 OneWay=�  5G      $ Seizoen��6%    66   �� *	Seizoen+$
 OneWay=�  5H      $ Prijs��6%    64   �� *Prijs+$
 OneWay=�  5I      $ Kledingmaat��6%    6:   �� *Kledingmaat+$
 OneWay=�  5J      $ Thuis��6%    64   �� *ClubSet.Thuis+$
 OneWay=�  5K      $ Versie��6%    65   �� *ClubSet.Versie+$
 OneWay=� � 	Resources 5M         ContextMenu � DataContext �� RelativeSource��%  &	        �� 5N       62   �� *PlacementTarget.DataContext+ �� *Self+.@�5O      m� $��UpdateVoetbaltruitje��6   -   5        $��	Aanpassen��5O   ;   6N   m� 5P      $��DeleteVoetbaltruitje��6   -   5        $��Verwijderen��5P   ;   6P   5Q      5R         RowStyle 5S      �� 5T       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5U      ��  �� Property �@�ContextMenu �� Value# [  64   5V      5X      5Y      5Z      
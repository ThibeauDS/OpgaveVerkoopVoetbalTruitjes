   M S B A M L   `   `   `  ����U  QVerkoopVoetbalTruitjes.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:VerkoopVoetbalTruitjes.WPF.Pages.Bestelling+VerkoopVoetbalTruitjes.WPF.Pages.Bestelling  5      Q    KVerkoopVoetbalTruitjes.WPF.Pages.Bestelling.BestellingTruitjeSelecterenPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:VerkoopVoetbalTruitjes.WPF.Pages.Bestelling     5      -   5          N� Title$%  BestellingTruitjeSelecterenPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5        $��BackBtn��5      $��Segoe Fluent Icons)�66   $	����6V   $��25��6i   $��25��6t   $
��Left=�6�   $	��Top=�6�   $��0,0,0,10q�5      � 5   
   $��1��6   $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5       5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      .+�5&      �� $��
Competitie��6   $��0,0,5,0q�6*   �� 5'      -   5        $��ComboBoxCompetitie��5'      $��1��61   $��0,0,0,10q�6A   6�   �� 5)      $��Ploeg��6   $��10,0,5,0q�6%   $��2��67   �� 5*      -   5        $��ComboBoxPloeg��5*      $��3��6,   $��0,0,0,10q�6<   �� 5,      $��Seizoen��6   $��1��6'   �� 5-      -   5        $��Seizoen��5-      $��1��6%   $��1��62   $��0,0,0,10q�6B   �� 5/      $��Prijs��6   $��10,0,5,0q�6%   $��1��67   $��2��6D   �� 50      -   5        $��Prijs��50      $��1��6#   $��3��60   $��0,0,0,10q�6@   �� 52      $��Id��6   $��2��6"   �� 53      -   5        $��Id��53      $��2��6    $��1��6-   $��0,0,0,10q�6=   � 55      $��3��6   $��2��6    $��0,0,0,10q�64    56      �� 57      $
��Auto �6'   �� 58      $
��Auto �6'   �� 59      $
��Auto �6'   �� 5:      �� 5;      $
��Auto �6'   �� 5<      .+�5?      �� -   5        $��Thuis��5?      $��Thuis��6(   �� 5@      -	   5        $	��Uit��5@      $	��Uit��6&   $��10,0,5,0q�65   $��1��6G   �� 5B      $��Versie��6   $��2��6*   $��10,0,5,0q�6:   �� 5C      -
   5        $��Versie��5C      $��3��6(   $��0,0,0,10q�68   �� 5E      $
��Maat��6   $��4��6(   $��10,0,5,0q�68   �� 5F      -   5        $��ComboBoxMaat��5F      $��5��6/   $��0,0,0,10q�6\   5G      �� 5I      -   5        $��	SearchBtn��5I      $��Segoe Fluent Icons)�6>   $	����6^   $��4��6q   $��3��6~   $��25��6�   $��25��6�   $��Right=�5J      $	��Top=�61   $��0,0,0,10q�6I   �� 5L      -   5        $��ListViewTruitjes��5L      $��5��6/   $��4��6<    �� SelectionMode$ Single=�6P   5M      �� 5O   
   -   5        $��	SelectBtn��5O      $��Segoe Fluent Icons)�6:   $	����6Z   $��3��6m   $��5��6z   $��25��6�   $��25��6�   $��Right=�5P      $��10q�61   5Q      5R      
   M S B A M L   `   `   `  ����U  QVerkoopVoetbalTruitjes.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:VerkoopVoetbalTruitjes.WPF.Pages.Bestelling+VerkoopVoetbalTruitjes.WPF.Pages.Bestelling  5      I    CVerkoopVoetbalTruitjes.WPF.Pages.Bestelling.BestellingToevoegenPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:VerkoopVoetbalTruitjes.WPF.Pages.Bestelling     5      -   5          N� Title$  BestellingToevoegenPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Klant��6   $��0,0,5,10q�6%   �� 5       -   5        $��Customer��5        �� 
IsReadOnly$
 True��6&   $��1��68   $��2��6H   $��0,0,5,10q�6\   �� 5!      -   5        $��SelectCustomerBtn��5!      $��Selecteer klant��6.   $��3��6h   �� 5#      $��Prijs��6   $��1��6%   $��0,0,5,10q�62   �� 5$      -   5        $��Price��5$      $
 True��6#   $��1��65   $��1��6B   $��0,0,5,10q�6R   6d   �� 5%      -   5        $��IsPayed��5%      $��Betaald��6&   $��1��68   $��2��6E   $��0,0,5,10q�6U   �� 5&      -   5        $��SelectTruitjeBtn��5&      $��Selecteer truitje��6-   $��1��6h   $��3��6u   5'      &   System.Windows.Controls.DataGrid  5)   
   -   5        $��DataGridTruitjes��5)      $��1��6+   $��10q�68      AutoGenerateColumns$ False��6D      Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Truitje��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Voetbaltruitje+ �� Mode$ OneWay=�  5,      $ Aantal��6%    65   �� *Aantal+$ TwoWay=�	 � 	Resources	 5.         ContextMenu
 � DataContext �� RelativeSource��%�   &	        �� 5/      
 62   �� *PlacementTarget.DataContext+ �� *Self+.@�50      m� $��DeleteVoetbaltruitje��6   -   5        $��Verwijderen��50   ;   6P   51      52         RowStyle 53      �� 54       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�55      ��  �� Property �@�ContextMenu �� Value# [  64   56      58      �� 5:   
   -	   5        $��CreateOrder��5:      $��2��6>   $��10q�6K   .��5;      ��  �� Orientation$ 
Horizontal=�6   .+�5<      �� $��Segoe Fluent Icons)�6   $	����6<   $��Center=�6L   $��0,0,5,0q�6g   �� 5=      $��Bestelling plaatsen��6   5>      5?      5@      5A      
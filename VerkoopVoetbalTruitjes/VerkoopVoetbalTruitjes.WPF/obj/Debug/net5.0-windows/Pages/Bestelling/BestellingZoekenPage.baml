   M S B A M L   `   `   `  ����U  QVerkoopVoetbalTruitjes.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:VerkoopVoetbalTruitjes.WPF.Pages.Bestelling+VerkoopVoetbalTruitjes.WPF.Pages.Bestelling  5      F    @VerkoopVoetbalTruitjes.WPF.Pages.Bestelling.BestellingZoekenPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:VerkoopVoetbalTruitjes.WPF.Pages.Bestelling     5        N� Title$  BestellingZoekenPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   � $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    5      �� 5      �� 5      �� 5      $
��Auto �6    .+�5       �� $��Id��6   �� 5!      -   5        $��Id��5!      $��1��6    $��0,0,5,10q�60   �� 5#      $��
Startdatum��6   $��2��6*   $��	30,0,5,10q�6:   (  "System.Windows.Controls.DatePicker  5$      -   5        $��	StartDate��5$      $��3��6*   �� 5&      $��	Einddatum��6   $��4��6)   $��	30,0,5,10q�69     5'      -   5        $��EndDate��5'      $��5��6(   �� 5)      -   5        $��	SearchBtn��5)      $��Segoe Fluent Icons)�6>   $	����6^   $��6��6q   $��2��6�   $��25��6�   $��25��6�   $��Right=�5*      �� 5,      $��Klant��6   $��1��6%   $��0,0,5,10q�62   �� 5-      -   5        $��Customer��5-      $��1��6&   $��1��63   $��0,0,5,20q�6C    �� 
IsReadOnly$
 True��6U   6g   �� 5/      -   5        $��SelectTruitjeBtn��5/      $��Selecteer Klant��6-   $��1��6f   $��2��6s   $��	30,0,5,10q�6�   50      �� 52   
   -   5        $��ListViewOrders��52      $��1��6)   $��10q�66    � 	Resources 53         ItemContextMenu m� Command �� Path �� RelativeSource �� Mode	 �� AncestorType��%t  &	        �� 54      .@�55      m� $��UpdateVoetbaltruitje��6   -   5        $��	Aanpassen��55   ;    6q   �� $ DataContext.MoreInfo� �� $ FindAncestor=�	 ListViewm� 56      $��DeleteVoetbaltruitje��6   -	   5        $��Verwijderen��56   ;    6s   �� $ DataContext.MoreInfo� �� $ FindAncestor=�	 ListView57      58      ��5:      �� 5;      
 �� 
TargetType"
 ��6   .�5<      ��  �� Property �@�ContextMenu �� Value# [  64   5=      5J      5K      5L      
   M S B A M L   `   `   `  ����^  ZMemory-Card-Game____Noah_Azur_Nacar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Memory_Card_Game____Noah_Azur_Nacar#Memory_Card_Game____Noah_Azur_Nacar  5   	   ;    5Memory_Card_Game____Noah_Azur_Nacar.BestenlisteWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:Memory_Card_Game____Noah_Azur_Nacar     5   	     � Title$5  /MemoryCardGame Bestenliste - by Noah Azur Nacar��5   	   $	��500��6A   $	��600��6N    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�6   
����p��
��� ���.��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��Bestenliste��6   $��30(�5      $��Center=�5      $��
UltraBlack"�5      $��0,10,0,0q�5      �� 5   
   -   5         ��Name$ lvBestenliste��5      $��1��6*   $��16(�67   $��
UltraBlack"�6E   
����p��
��� ��� �� View 5      �� 5      .P�5      �� $��Spielername��6%    �� Width$	 190��6q    �� DisplayMemberBinding 6=   �� *Spielername+6q   �� 5      $��Leben��6%   $	 190��6q    6=   �� *VerbleibendeLeben+6q   �� 5      $
��Zeit��6%   $	 190��6q    6=   �� *Zeit+6q   5      5       �� 5"   
   -   5         ��Name$ btnSpielMenue��5"      $��3��5$      $��Zurück��5%      $��Center=�5&      $��40��5'      $	��175��5(      $��0,5,0,5q�5)      $��
UltraBlack"�5*      
�������5+      5-      5.      
   M S B A M L   `   `   `  ����D  @Stopwatch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Stopwatch	Stopwatch  5   	       Stopwatch.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Stopwatch     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��700��6)    � 	Resources 5
          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $	��350 �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��160 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��1��6   .+�5      �� -   5         ��Name$ currentSplitTime��5      $��Center=�6\   $��Center=�6y   $��48(�6�   ��62   ��  �� Path$ CurrentMeasurement�6�   5      � 5   
   $��0��6   $��2��6   .+�5      �� -   5         ��Name$ startButtonPanel��5      $��Center=�63   $	��Top=�6P   $��0, 10, 0, 0q�6h     BasicButtonPanelStyle#���  6}   y�5       �� $ IsReset� �� 	Converter# [  .+�5!      �� -   5         ��Name$ startButton��5!      $��Center=�6.   $��Center=�6K   $��0, 10, 0, 10q�6f     BasicButtonStyle#���  6|   ��5"      �� *
StartCmd+.��5#      �� $��/Resources/Icons/play.png��6   5$      5%      �� 5'      -   5        $ activeStateButtonPanel��5'      $��Center=�69   $	��Top=�6V   $��0, 10, 0, 0q�6n   #���  6�   y�5(      �� $ 	IsRunning�# [  .+�5)      � $��70��6   .+�5*      �� -   5        $ nextLapButton��5*      $
��Left=�64   $��Center=�6O   $��
30,10,0,10q�6j   #���  6~   ��5+      �� *StartNewLapCmd+.��5,      �� $��/Resources/Icons/lap.png��6    5-      �� 5.      -   5        $ pauseButton��5.      $��Right=�63   $��Center=�6P   $��120,10,30,10q�6k   #���  6�   ��5/      �� *
PauseCmd+.��50      �� $ ��/Resources/Icons/pause.png��6    51      52      53      �� 55      -   5        $ inactiveStateButtonPanel��55      $��Center=�6;   $	��Top=�6X   $��0, 10, 0, 0q�6p   #���  6�   y�56      �� $ 	IsOnPause�# [  .+�57      � $��70��6   .+�58      �� -   5        $ resetButton��58      $
��Left=�62   $��Center=�6M   $��
30,10,0,10q�6h   #���  6|   ��59      �� *
ResetCmd+.��5:      �� $��/Resources/Icons/stop.png��6    5;      �� 5<      -	   5        $ restartLapButton��5<      $��Right=�67   $��Center=�6S   $��120,10,30,10q�6n   #���  6�   ��5=      �� *
StartCmd+.��5>      �� $��/Resources/Icons/play.png��6    5?      5@      5A      5B      � 5D   
   $��1��6   .+�5E      &   System.Windows.Controls.DataGrid  $��
0,0,0,-238q�6A   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6U   
�������
������ ��6   �� $ PreviousLaps�6x   5F      5G      5H      
   M S B A M L   `   `   `  ����N  JWPFSubtitleComposer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:lab_pkt2lab_pkt2  5   	       lab_pkt2.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:lab_pkt2     5   	     � Title$  Subtitle Composer��5   	   $	��800��6#   $
��1280��60    � WindowStartupLocation$ CenterScreen=�6=   $	��480��6b   $	��640��6r    � 	Resources 5
      "   lab_pkt2.VisibilityConverter   VisibilityConverter    lab_pkt2.DurationConverter  DurationConverter   lab_pkt2.TmeSpanConverter  TmeSpanConverter��%W   &	        &	      &	 &       5   
   6$     5   
   6"     5   
   6!   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $
��File��6   .@�5      m� -   5        $
��Open��5      6)   m� 5      -   5        $
��Exit��5      6)   5      m� 5      $��	Subtitles��6   .@�5      m� $
��Open��6   m� 5       $
��Save��6   m� 5!      $��Save Translation��6   {�65   �� *	IsChecked+ �� ElementName$ Translation���� 5"      m� 5#      -   5        $��Translation��5#      $��Translation��6.    m� IsCheckable$
 True��6C    m� 	IsChecked$ False��6V   6h   5$      m� 5%      $
��Help��6   .@�5&      m� -   5        $��About��5&      6*   5'      5(      � 5*   
   $��1��6    5,      �� 5-      $	��50* �6    �� 5.      $
��Auto �6    �� 5/      $	��50* �6    �� 50      $
��Auto �6    �� 51      $	��100 �6    .+�54      � -   5        $��0��54       55      �� 56      $��* �6$   �� 57      $
��Auto �6$   .+�5:      �� $��0��6   
���   �6)   r� 5;      -   5        $��MediaPlayer��5;   ,   $��0��6    r� LoadedBehavior$ Manual=�6?   6W   �� 5<      -   5        $��SubTitleTextBox��5<   )   $��0��6   $y�Hidden=�6@   $��Center=�6T   $��Bottom=�6q   $��20(�6�    �� Padding$ 5q�6�   	 �� TextAlignment$	 Center=�6�   ��5=      �� 5>      
 �� Color$
 Black��6*    �� Opacity$	 0.5Q�68   ��5@      �� 5A      $
 White��6*   $ 1Q�68   5C      � 5E      $��1��6   $��Stretch=�6$   $��Stretch=�6B    � ColumnDefinitions 5G      �� 5H      $
��Auto �6+   �� 5I      $
��Auto �6+   �� 5J      $
��Auto �6+   �� 5K      $
��Auto �6+   �� 5L      $
��Auto �6+   �� 5M      $
��Auto �6+   �� 5N      $��8* �6+   �� 5O      $��* �6+   .+�5R      �� -   5        $��0��5R      $��3q�6-   .��5S      �� $��\Resources\play.png��6    $��22��6=   5T      �� 5U      -	   5        $��1��5U      $��3q�6-   .��5V      �� $��Resources\pause.png��6    $��22��6=   5W      �� 5X      -
   5        $��2��5X      $��3q�6-   .��5Y      �� $��\Resources\stop.png��6    $��22��6=   5Z      �� 5\      -   5        $��CurrentTimeLabel��5\   ,   $��3��6   $��00:00:00.000��6D   $��Center=�6[   �� 5^      $��4��6   $��:��6-   $��Center=�69   �� 5`      -   5        $��TotalTimeLabel��5`   ,   $��5��6   $��00:00:00.000��6B   $��Center=�6Y   �� 5b      -   5         ��Name$ videoSlider��5b   -   $��6��6    � Value$ 0Q�6B    �� IsMoveToPointEnabled$
 True��6L   $��Center=�6h   6�   � 5d      -   5        $��ProgressBarVolume��5d   2   $��7��6"   $��10q�6K   $��90��6W    � Minimum$ 0Q�6�    � Maximum$ 1Q�6�   $��Stretch=�6�    6b   �� $ MediaPlayer�� �� Path$ Volume�6�   5f      5h      �� 5j      $��1��6   $��Stretch=�6(   $��5��6F   &   System.Windows.Controls.DataGrid  5l      -   5        $��DataGrid��5l      $��2��6'      CanUserAddRows$
 True��64      AutoGenerateColumns$ False��6�      CanUserSortColumns$ False��6�   ��6J   ��  �� UpdateSourceTrigger$ PropertyChanged=� � ContextMenu 5m      �� 5n      .@�5o      m� -   5        $	��Add��5o   #   60   m� 5p      -   5        $��	Add After��5p   #   66   m� 5q      -   5        $��Delete��5q   #   63   5r         Columns 5t      0  *System.Windows.Controls.DataGridTextColumn  5v      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Show Time��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6<      SortDirection 	Ascending6I      CanUserSort$
 True��6c      SortMemberPath$ ShowTime��6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *
ShowTime+ �� 	Converter# [ $ 	LostFocus=�  5w      $ 	Hide Time��6)   $
 Auto 6<   $ False��6I    6]   �� *
HideTime+# [ $ 	LostFocus=�  5x      $
 Text��6)   $ * 67   $ False��6A    6U   �� *Text+$ PropertyChanged=�  5y      $ Translation��6)   $ * 6>       
Visibility$  	Collapsed=�6H   $ False��6_    6s   �� *Translation+$ PropertyChanged=�5|      �� 5~      $��3��6   $��Stretch=�6(   $��5��6F   � 5�      $��4��6    5�      �� 5�      $	��150 �6'   �� 5�      $��* �6'   �� 5�      $
��Auto �6'   .+�5�      �� .��5�      �  5�      �� 5�      $��* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,    5�      �� 5�      $
��Auto �6/   �� 5�      $��70 �6/   .+�5�      �� $
��Show��6    $
��Bold"�6/   �� 5�      $��1��6"   $��20��6�   ��62   �� *SelectedValue.ShowTime+$ DataGrid��! �� Mode$! TwoWay=�# [ $ PropertyChanged=�6�   �� 5�      $��1��6    $
��Hide��6-   $
��Bold"�6<   �� 5�      -   5        $��HideTextBox��5�   "   $��1��65   $��1��6E   $��20��6�   ��6R   �� *SelectedValue.HideTime+$ DataGrid��$! TwoWay=�# [ $ PropertyChanged=�6�   �� 5�      $��2��6    $��Duration��6-   $
��Bold"�6@   �� 5�      $��1��6"   $��3��62   $��20��6@   .��6L   ��5�      `� 5�   "   " `� 	Converter#" [ 6/   # `� UpdateSourceTrigger$# PropertyChanged=�6^   .1�5�   &   �� $ SelectedValue.HideTime�6.   $ DataGrid��6L   �� 5�   &   $ SelectedValue.ShowTime�6.   $ DataGrid��6L   5�   #   .��5�   ,   5�      5�      5�      �� 5�      -   5        $��TextGroupBox��5�   +   $��1��6   ��5�      �� 5�      �� 5�      $�Text: ��6"    �� 5�      �6"   �� *Text.Length+$ TextTextBox��$! OneWay=� �� 5�      $� characters��6"   5�      .��5�      �� -   5        $��TextTextBox��5�      $��Stretch=�61   $ �� TextWrapping$
$ Wrap=�6O   % �� TextAlignment$% Center=�6c   "& �� VerticalScrollBarVisibility$
& Auto=�6z   ' �� AcceptsReturn$
' True��6�   ��6�   �� *SelectedValue.Text+$ DataGrid��$ PropertyChanged=�$! TwoWay=�5�      �� 5�      -   5        $��TranslationGroupBox��5�   +   $��2��6   $y�	Collapsed=�6F   ��5�      �� 5�      �� 5�      $�Transaltion: ��6"    �� 5�      �6"   �� *Text.Length+$ TranslationTextBox��$! OneWay=� �� 5�      $� characters��6"   5�      .��5�      �� -   5        $��TranslationTextBox��5�      $��Stretch=�68   $
$ Wrap=�6V   $% Center=�6j   $
& Auto=�6�   $
' True��6�   ��6�   �� *SelectedValue.Translation+$ DataGrid��$ PropertyChanged=�$! TwoWay=�5�      5�      5�      5�      5�      
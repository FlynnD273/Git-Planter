   M S B A M L   `   `   `  ����E  AGitPlanter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GitPlanter
GitPlanter  5   	   ;"clr-namespace:GitPlanter.ViewModelGitPlanter.ViewModel  5   	   ;"clr-namespace:GitPlanter.ConverterGitPlanter.Converter  5   	       GitPlanter.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GitPlanter     5   	   1vm"clr-namespace:GitPlanter.ViewModel     5   	   0c"clr-namespace:GitPlanter.Converter     5   	     � Title$  Git Planter��5
   	   $	��450��6   $	��800��6*    � 	Resources 5      1  +GitPlanter.Converter.StatusToColorConverter   StatusToColorConverter7  1GitPlanter.Converter.ChangeStatusToColorConverter   ChangeStatusToColorConverter3  -GitPlanter.Converter.StatusToTooltipConverter  StatusToTooltipConverter.  (GitPlanter.Converter.ScaleWidthConverter  ScaleWidthConverter/  )GitPlanter.Converter.ScaleHeightConverter  ScaleHeightConverter  MyBoolToVisibilityConverter  BackgroundBrush �� ImageSource j� Stretch��%+  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r       5   
   6#     5   
   6)     5   
   6%     5   
   6      5   
   6!   �� 5   
   6'   �� 5   
   $F @pack://application:,,,/GitPlanter;component/Image/Background.png��6-   $ UniformToFill=�6|   5       � DataContext 5      $  GitPlanter.ViewModel.ViewModel  5   
   .��5      ��  �� SelectedIndex 6   �� *
TabIndex+.@�5   
   �� $��Commit Tree��6   .��5      � -   5         �Name$ 
commitTree��5      .+�5      �� ��6   �� *	Commits+��5      �� 5      .R�5      ��  K� IsItemsHost$
 True��6%   #��[ 68   5      ��5       �� 5!      .R�5"      �� 
���**����6#   �� *Width+	 �� X1 5#   %   �� 	 �� Path$	 X�
 �� 	Converter#
 [  �� ConverterParameter %  System.Windows.Markup.Reference  *
commitTree+	 �� Y1 5$   %   �� $	 Y�#
 [    *
commitTree+	 �� X2 5%   %   �� $	 X2�#
 [    *
commitTree+	 �� Y2 5&   %   �� $	 Y2�#
 [    *
commitTree+5'      5)      �� 5*      ��6   �� *	Commits+��5+      �� 5,      .R�5-      �� $
 True��6%   
������ 68   5.      ��50      �� 51      .R�52      ��  �� Orientation$ 
Horizontal=�6)   $��-10,-10,0,0q�6B   $��20��6W   z�53   "   T� 54   &    T� X 69   �� $	 X�#
 [    *
commitTree+ T� Y 55   9   �� $	 Y�#
 [    *
commitTree+.+�57   "   �� ��6)   �� *OnClickCommand+ � ToolTip 6L   �� *Status+#
 [ ��58   &   �� 59   *    �� 
TargetType" ��6:   .R�5:   .   A� $��20��66   $��20��6A   ��6M   �� *Status+#
 [  5;   +   5=   #   �� 5>   "   
������� �� Padding$	 4,0q�6c   $��5,0,0,0q�6q   ��6,   �� *Commit.Message+6q   5?      5@      5B      �� 5C      $
��🗘��6   $��20(�6&   $ Refresh changes��64   $��30��5D      $��30��6$   $
��Left=�60   $��Bottom=�6K     SecondaryColorBrush#��[ 5E      ��5C   N   �� *RefreshCommand+5E      5F      5G      �� 5H   
   $��Local Changes��6   .��5I      � #��[ 6    � ColumnDefinitions 5J      �� 5K      $��* �6'   �� 5L      $��* �6'   .+�5N      �� -   5         ��Name$ unstagedChangesList��5N   +   $��0��6    J� 	AllowDrop$
 True��5Q      
������ ��5N   H   �� *UnstagedChanges+��5S      �� 5T      .R�5U      �� $
 10,0q�6H   ��6(   �� *Entry.FilePath+��5V   (   �� *ChangeStatus+#
 [ 5W      5Y      �� 5Z      $��0��6   $
��🗘��6)   #��[ 66   $��20(�6h   $ Refresh changes��6v   $��30��5[      $��30��6$   $
��Left=�60   $��Bottom=�6K   ��5Z   �   �� *RefreshChangesCommand+5[   K   � 5\      $��1��6    � RowDefinitions 5]      �� 5^      $
��Auto �6(   �� 5_      $��3* �6(   �� 5`      $��* �6(   �� 5a      $
��Auto �6(   .+�5c      �� $��0��6   $��Staged Changes��6)     SecondaryDarkColorBrush#��[ 6B   $��Verdana)�6x   $
��Bold"�6�   $��Center=�6�   $��18(�6�   �� 5d      -   5        $ stagedChangesList��5d   ,   $��1��6    �� SelectionMode$ Single=�6m   $
 True��5g      
������ ��5d   G   �� *StagedChanges+��5i      �� 5j      .R�5k   "   �� $
 10,0q�6L   ��6,   �� *Entry.FilePath+��5l   ,   �� *ChangeStatus+#
 [ 5m      5o      �� 5p      -   5         ��Name$ commitMessageText��5p   +   $��2��6   ��6F   �� *CommitMessage+�� 5q      $��2��6   $��Enter commit message...��6)   $��0,-5,0,0q�5r      
������� J� IsHitTestVisible$ False��5s   .   y�5t      ��  �� ElementName$ commitMessageText��$	 Text.IsEmpty�#
 [ �� 5u      $��3��6   $��Commit��6*   $
��Bold"�6;    	 PrimaryColorBrush#��[	 6M   $
��10,5q�6�   $��Center=�6�   ��6}   �� *CommitCommand+6�   5v      5w      5y      5z      5{      
   M S B A M L   `   `   `  ����D  @DailyFeed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DailyFeed	DailyFeed  5          DailyFeed.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:DailyFeed     5        �� 	Resources  5         BorderedItem �� 
TargetType �� Property �� Value �� 
TargetType  ScrollThumbs �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle  placeHolder �� BasedOn ��Name K� ZIndex �� Path �� RelativeSource �� Mode �� UpdateSourceTrigger
 � Tag �� Triggers �� Binding  �� Source%  System.Windows.Markup.Reference! �� Value��%D  &	        &	 �     '��     &	 �	    7���� 5   
   " ��6%   .�5	      ��  � �� 5
      �� 5      " ��6&   .R�5      �� $��Border��6!   
�������$��1q�6B   ._�5      �� 5      5      5      5      �� 5   
   " n�6%   .�5      ��  � �� 5      �� 5      " n�6&   .R�5      � $
 Grid��6   .+�5      �� $��Stretch=�6(   $��Stretch=�6F   $
��Auto��6b   $
��Auto��6o   
������ 6}   �� 5      $ 
Rectangle1��6%   $ 5��69   $��Stretch=�6J   $��Stretch=�6h   $
��Auto��6�   $��32��6�   #��z��6�   5       5      P� 5      	 �@�Tag$
 
Horizontal��65   . �5   "   �� $ 
Rectangle1��6)    � ��$
 Auto��6R   �� 5    "   $ 
Rectangle1��6)    � ��$ 7��6S   5!      5#      5%      5&      �� 5)   
   " ��6+   .�5*      ��  �@��IsFlicksEnabled .  67   �� 5+       � �� �#8C8C8C6+   �� 5,       � ��
 ���� 6+   �� 5-       � ��$ 8��6&   �� 5.       � �� 5/      �� 50      " ��6&   .R�51      � $ GridRoot��6   $��8��61   #��z��6;    52      �� 53   "   $��0.00001* �60   .+�56      ]� $ 
PART_Track��6$   $��0��68   ��. |�.   57   "   n� 58   &   $ Thumb��6,   #��z��6;   #���  6e    5:   "   �� 5;   &   $ PageUp��63   $��ScrollBar.PageDownCommand��6C   $ 0Q�6g   |�.  6s    5=   "   �� 5>   &   $ PageDown��63   $��ScrollBar.PageUpCommand��6E   $ 0Q�6g   |�.  6s   5@      5A       5C      P� 5D      $ Thumb��6&   	 �@J�IsMouseOver
 . . �5E   "   �� # �  6)   $ Thumb��6U    � ��6h   5F      P� 5G      $ Thumb��6&   	 �@n�
IsDragging
 . . �5H   "   �� # �  6)   $ Thumb��6M    � ��6`   5I      P� 5K      	 � {�
 .  . �5L   "   �� $ Thumb��6)    � y�$ 	Collapsed=�6R   5M      P� 5N      	 �@��Orientation$
 
Horizontal=�6=   . �5O   "   �� $ GridRoot��6)    �@�LayoutTransform 5P   &   �� 5Q   *   $	 -90Q�6:   5S   #   �� 5T   "   $ 
PART_Track��6)    �@�LayoutTransform 5U   &   �� 5V   *   $	 -90Q�6:   5X   #   �� 5Y   "    � ��$
 Auto��6:   �� 5Z   "    � ��$ 8��6;   �� 5[   "   $ Thumb��6)    �@�Tag$ 
Horizontal��6K   �� 5\   "   $ PageDown��6)    � ��$ ScrollBar.PageLeftCommand��6R   �� 5]   "   $ PageUp��6)    � ��$  ScrollBar.PageRightCommand��6P   5^      5`      5b      5c      �� 5f   
   " ��6$   8   .�5g      ��  � �� 5h      �� 5i      " ��6&   .R�5j      � .+�5k      �� $ 
textSource��5o   "   
������ $ 2��5q   "   ��5k   &   �� $
 Text� �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=�5q   "   �� 5r      #��z 6&   #��z��6C   $ 1��6m   .��6~   ��5s   "   �� 5t   &   " ��6,   .�5u   *   ��  � ��
 ���� 6G    5v   *   �� 5w   .    6:   �� $
 Text�    *
textSource+!  6y   .a�5x   2   ��  � ��
 �����6O   5y   /   5{   '   .��5|   1   5}      5~      5      5�      5�      5�      5�      
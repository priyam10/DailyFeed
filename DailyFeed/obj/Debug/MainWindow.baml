   M S B A M L   `   `   `  ����b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  5   	   D @DailyFeed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DailyFeed	DailyFeed 5   	   9!clr-namespace:DailyFeed.ViewModelDailyFeed.ViewModel 5   	      DailyFeed.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DailyFeed     5   	   0ns!clr-namespace:DailyFeed.ViewModel     5   	     � Title$  
MainWindow��5
   	   $	��350��6   $	��525��6)    � WindowStyle$
 None=�66    � Topmost .  � WindowState$ 	Maximized=�6X    � AllowsTransparency .  � ShowInTaskbar .  ��5      �� 5   
    �� Opacity$	 0.5Q�6    �� Color$ Transparent��6(   .��5      � -   5         �Name$
 grid��5      	 � ColumnDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5        
 ��Name$

 rect��5      $
��Auto��6"    �� RadiusX$ 20��6/    �� RadiusY$ 20��6<   $��Stretch=�6I   ���	#99000000$y�	Collapsed=�6v   �� 5   
   -   5        $��
MainButton��5      #��[" �6#   $��32��6^   $��32��6i   $��16(�6u   $��Center=�6�   $��Right=�6�   
���   � K� ZIndex$	 100��6�   $��0,276,0,227q�6�   $��>��6
  � 5   
   -   5        $ gridCol1��5      $��0��6   .+�5      �� -   5         ��Name$ tabView��5       J� Opacity$	 0.8Q�6*   
������ $y�	Collapsed=�6Q   .@�5      �� -   5         ��Name$ 
weatherTab��5      $��Weather��6.   .��5      �� $��5q�6!   .+�5      �� $��Location��6$   $��0 0 0 5q�64   $��Center=�6E   
�������6b   �� 5      -   5         ��Name$ txtLocation��5   "   $��20��67   $��0 0 0 5q�6C   $	��100��6T   $��Center=�6`   ��6}   �� *nowWeather.currLocation+�� 5      -   5         ��Name$ currWeatherIcon��5       $��0 0 0 5q�69   $��Center=�6J   �� 5       -	   5         ��Name$ currTemp��5    $   $��0 0 0 5q�66   $��Center=�6G   
�������$��15(�6w   ��6�   �� *nowWeather.currDegrees+�� 5!      -
   5        $ currWeatherDesc��5!   $   $��0 0 0 5q�6=   $��Center=�6N   $��15(�6k   
���������6�   �� *nowWeather.currDesc+�� 5"      -   5         ��Name$ btnForecast��5"   !   $��90��6_   $��30��6j   $��5q�6v   $��Forecast��6�   ��66   �� *GetCurrWeatherClick+6�   �� 5#      $��8q�6#   $	��400��6.   $	��400��6;   
���   �$��Disabled=�6~   ��6Z   �� *weatherList+��5$      �� 5%   "   .R�5&   &   �� 
������ $	��5pxq�6J    �� Orientation$ Vertical=�6W   $	��610��6n   .+�5'   *   �� $
��Auto��6R   $
��Auto��6_   
�������$
��Wrap=�6�   ��64   �� *forecastTime+6�   �� 5(   *   
�������$
��Auto��6a   ��64   �� *
currDesc+6a   �� 5)   *   
�������$
��Auto��6e   ��64   �� *currDegrees+6e   5*   '   5+   #   5-      5.      5/      �� 50      -   5        $ 	redditTab��50   *   $��Reddit��6   .��51      �� $��5q�6!    � 	Resources 52          BooleanToVisibilityConverter��%   &	        �� 53      6;   54      .+�55      �� $��20��6$   $	��100��60   
�������$��5q�6O   
Subreddit:6f   �� 56      -   5        $ subredditBox��56   "   $��20��68   $	��100��6D   $��5q�6P   $��Center=�6[   ��6x   �� *mySubreddit+�� 57      -   5        $ btnSearchReddit��57   !   $��90��6`   $��30��6k   $	��0 2q�6w   $��Search��6�   ��6:   �� *GetSubredditClick+6�   �� 58      -   5        $ btnBack��58   !   $��90��6x   $��30��6�   $
��Back��6�   $
��10 2q�6�   $
��Left=�6�   ��62   �� *BackButtonClick+y�6V   �� *
backButton+6�   �� 59      -   5        $��	reddit_lv��59   #   $��5q�64   $	��650��6?   $	��550��6K   
���   �$��Disabled=�6�   ��6k   �� *redditPostList+y�6�   �� *	postsView+��5:      �� 5;   "   .R�5<   &   �� 
������ $��5q�6J   $ Vertical=�6U   $	��610��6l   .+�5=   *   �� $��5q�65   $ 
Horizontal=�6@   
�������.+�5>   .   �� $
��None=�6Q   $ 1Q�6`   ��64   �� *	thumbnail+y�6l   �� *showThumbnail+6�   �� 5?   .   $ Vertical=�69   .+�5@   2   �� �� 5A   2    �� TextDecorations 6<   Z�  �� Command 6W   ��  �� ElementName$ 	reddit_lv�� �� Path$  DataContext.OpenRedditPost� �� CommandParameter 6�   �� *commentsUrl+.�6�   .�5B   6   �� $��18(�6W   $	��440��6e   $
��Auto��6q    �� Padding$
 10pxq�6   
���   �$
��Wrap=�6�   ��6@   �� *title+6�   5C   3   5D   3   �� 5E   2   $
 10pxq�6T   
���   �$
��Auto��6w   ��6<   �� *author+6w   5F   /   5G   +   5H   '   5I   #   5K      �� 5M      -   5        $��comments_lv��5M   #   $��8q�66   $	��500��6A   $	��650��6N   
���   �$��Disabled=�6�   y�6m   �� *commentsView+��6�   �� *commentsList+��5N      �� 5O   "   .R�5P   &   �� 
������ $	��5pxq�6J   $ Vertical=�6W   $	��610��6n   .+�5Q   *   �� $��5q�65   $ Vertical=�6@   
�������.+�5R   .   �� $ 
Horizontal=�69   .+�5S   2   �� $��12(�6T   $��440px��6b   $
��Auto��6p   $
 10pxq�6~   
�����F�$��Oblique$�6�   $
��Wrap=�6�   ��6<   �� *writer+6�   �� 5T   2   $��12(�6R   $��440px��6`   $
��Auto��6n   $
 10pxq�6|   
�������$
��Wrap=�6�   ��6<   �� *time+6�   5U   /   �� 5V   .   $��12(�6Q   $��440px��6_   $
��Auto��6m   $
 10pxq�6{   
���   �$
��Wrap=�6�   ��68   �� *	content+6�   5W   +   5X   '   5Y   #   5[      5\      5]      �� 5^      -   5        $ mangaTab��5^   )   $��Manga��6   .��5_      �� $��5q�6!    5`      ��%   &	        �� 5a      6;   5b      .+�5c      �� $��90��6D   $��30��6O   $��5q�6[   $��Update��6f   ��6!   �� *OpenMangaList+6f   �� 5d      -   5        $��manga_lv��5d   #   $��8q�63   $	��600��6>   $	��450��6K   $	��5pxq�6W   
���   �$��Disabled=�6�   ��6x   �� *	mangaList+��5e      �� 5f   "   .R�5g   &   �� 
�������$	��5pxq�6D   $ Vertical=�6Q   $	��400��6h   .+�5h   *   �� $ 5q�64   �� 5i   2    6<   Z�  6W   �� $ manga_lv��$ DataContext.OpenMangaPage� 6�   �� *	mangaLink+.�6�   .�5j   6   �� $��14(�6[   $	��440��6i   $
��Auto��6u   
�����F�$	��0 5q�6�   $
��Wrap=�6�   ��6@   �� *	mangaName+6�   5k   3   5l   +   �� 5m   *   $ 
Horizontal=�65   .+�5n   .   �� $	��250��6U   $
��Wrap=�6a   $ 5q�6u   ��68   �� *chapterDesc+6u   �� 5o   .   $
��Auto��6Q   $��Right=�6^   $ 5q�6z   ��68   �� *	pubDate+6z   5p   +   5q   '   5r   #   5t      5x      5y      5{      5}      5~      5      
   M S B A M L   `   `   `  ����F  BMusicPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicPlayerMusicPlayer  5   	       MusicPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MusicPlayer     5   	     � Title$  Music Player��5   	   $��248.744��6   $��288.64��6/    � 
ResizeMode$ CanMinimize=�6>    � Icon$ logo.png��6W   .��5	      � .+�5
   
   �� -   5         ��Name$ 	startGomb��5
      $��▶️��6$   $
��Left=�61   $��
10,164,0,0q�6L   $	��Top=�6`   $��45��6x   6�   �� 5   
   -   5        $ stopGomb��5      $��⏹️��6#   $
��Left=�60   $��116,164,0,0q�6K   $	��Top=�6`   $��45��6x    J� RenderTransformOrigin$ 
0.493,0.45&�6�   6�   �� 5   
   -   5        $ 	pauseGomb��5      $	��⏸��6$   $
��Left=�60   $��
63,164,0,0q�6K   $	��Top=�6_   $��45��6w   6�   �� 5   
   -   5        $ backGomb��5      $	��⏪��6#   $
��Left=�6/   $��168,164,0,0q�6J   $	��Top=�6_   $��45��6w   6�   �� 5   
   -   5        $ nextGomb��5      $��⏩️��6#   $
��Left=�60   $��220,164,0,0q�6K   $	��Top=�6`   $��45��6x   6�   �� 5   
   -   5         ��Name$ timelineSlide��5      $
��Left=�6(   $��
10,135,0,0q�6C   $	��Top=�6W   $��24��6o   $	��255��6{   6�   �� 5   
   -   5         ��Name$ listBox��5      $
��Left=�6#   $	��120��6>   $��	10,10,0,0q�6K   $	��Top=�6^   $	��166��6v   �� 5   
   -   5        $ hozzaadasGomb��5      $��Hozzáadás��6(   $
��Left=�6<   $��
181,60,0,0q�6W   $	��Top=�6k   $��84��6�   6�   �� 5   
   -	   5        $ eltavolitasGomb��5      $��Eltávolítás��6*   $
��Left=�6@   $��
181,85,0,0q�6[   $	��Top=�6o   $��84��6�   6�   �� 5   
   -
   5        $ betoltesGomb��5      $��Lista betöltése��6'   $
��Left=�6A   $��
181,10,0,0q�6\   $	��Top=�6p   $��84��6�   6�   �� 5   
   -   5        $ 
mentesGomb��5      $��Lista mentése��6%   $
��Left=�6=   $��
181,35,0,0q�6X   $	��Top=�6l   $��84��6�   6�   �� 5   
   ���	#FFC1C1C1$
��Left=�6%   $��31��6@   $��	0,189,0,0q�6L   ���	#FFC1C1C1$	��Top=�6r   $	��283��6�   �� 5   
   -   5        $ volumeSlide��5      $
��Left=�6&   $��20��6A   $��
42,189,0,0q�6M   $	��Top=�6a   $	��223��6y   6�   �� 5   
   $��hangerő��6   $
��Left=�6"   $��22��6=   $��
0,188,0,-1q�6I   $	��Top=�6]   $��43��6u   $��9(�6�   �� 5   
   -   5         ��Name$ 	timeLabel��5      $��--:--:--��6#   $
��Left=�66   $��205,109,0,0q�6Q   $	��Top=�6f   $��10(�6~   5      5      
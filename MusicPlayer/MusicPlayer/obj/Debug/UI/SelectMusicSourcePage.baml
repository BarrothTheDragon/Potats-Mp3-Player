   M S B A M L   `   `   `  ����  MusicPlayer*    $MusicPlayer.UI.SelectMusicSourcePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  SelectMusicSourcePage��5      .��5
      �  � ColumnDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   ��5   
   �� 5       �� ImageSource$: 4pack://siteoforigin:,,,/Assets/WelcomeBackground.png��6    j� Stretch$ UniformToFill=�6\   .+�5   
   �� $��0��5      $��0��5      $��3��5      $��50(�5         TitleLabelStyle#��[  5      $"��Where is your music located?��5      �� 5    
   -   5        $ ��m_sourceDirectoriesListBox��5!      $��1��5"      $��1��5#      
����p��
������ $��Stretch=�5&      $y�	Collapsed=�5(      $��Visible=�5)      ��5'      �� *sourceDirectories+��5*      �� 5+      .R�5,      �  5-      �� 5.      $��70 �6/   �� 5/      $��* �6/    51      �� 52      $��50 �6,   .+�54      �� -   5        $��0��55      $��30��56      $��30��57      $��10q�58      $
��Left=�59      $��Center=�5:      $��0q�5;      
������ .��5>      �� $/��)pack://siteoforigin:,,,/Assets/Delete.png��6$   $��Uniform=�6W   6k   5?      �� 5@      $��1��5A      $��20(�5B      #��[  5C      $
��Left=�5D      ��5E      �� 5F      5G      5I      �� 5J   
   -   5        $��1��5K      $��2��5L      $��60��5M      $��60��5N      $��10q�5O      $��Center=�5P      $��Center=�5Q      $��0q�5R      
������ .��5U      �� $,��&pack://siteoforigin:,,,/Assets/Add.png��6   $��Uniform=�6D   5V      �� 5W   
   -   5        $��m_nextButton��5X      $��2��5Y      $��3��5Z      $��60��5[      $��60��5\      $��10q�5]      $��Right=�5^      $��Bottom=�5_      $��0q�5a      
������ $y�Hidden=�5c      .��5d      �� $-��'pack://siteoforigin:,,,/Assets/Next.png��6   $��Uniform=�6E   5e      5f      5g      
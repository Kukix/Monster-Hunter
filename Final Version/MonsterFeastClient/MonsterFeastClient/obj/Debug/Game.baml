   M S B A M L   `   `   `  ����  MonsterFeastClient    MonsterFeastClient.Game   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   -   5          � Title$  MonsterFeast | Lobby��5   	    � 
ResizeMode$ NoResize=�6&    � WindowStartupLocation$ CenterScreen=�6<   
���   �$��1q�6u   ���	#FF262626 � WindowStyle$
 None=�6�    � WindowState$ 	Maximized=�6�   $	��768��6�   $
��1024��6�    � 	Resources 5         CloseBtnStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName  FocusVisual �� StrokeDashArray ! RadioButton.Static.Background �� Color  RadioButton.Static.Border  OptionMarkFocusVisual $  RadioButton.MouseOver.Background   RadioButton.MouseOver.Border  RadioButton.MouseOver.Glyph # RadioButton.Disabled.Background 	 RadioButton.Disabled.Border 
 RadioButton.Disabled.Glyph " RadioButton.Pressed.Background  RadioButton.Pressed.Border  RadioButton.Pressed.Glyph  RadioButton.Static.Glyph  rbMenuStyle �Name � ColumnDefinitions ��Name �� CornerRadius F�Name �� Stretch ��Name��%  &	        &	 i    &	     &	 6    &	 Y    &	 
    &	 -    &	 P    &	 s    &		 �    &	
 �    &	 �    &	 �    &	 "    &	 E    &	 h    7  7  7  7  �� 5   
   " ��6&   .�5      ��  � �� 5	      �� 5
      "	 ��6&   .R�5      � .+�5      �� $
 	rectangle��6(   ���	#FFE2413E6;   �� 5      #��z��6/   ��. # z 6�   #��z��6�   5       5      P� 5       �@J�	IsFocused . 6;   P� 5       �@��IsDefaulted . 6=   P� 5       �@J�IsMouseOver . . �5   "   �� $ 	rectangle��69    � �� �	#FFF1514E6P   5      P� 5       � �� . . �5   "   �� $ 	rectangle��69    � �� �	#FF87201E6P   5      P� 5       � {� .  6;   5      5      5      �� 5   
   .�5      ��  � �� 5       �� 5!      .R�5"      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5#      5%      5&      �� 5'   
   $ 	#FFFFFFFF��6@   �� 5(   
   $ 	#FF707070��6<   �� 5)   
   .�5*      ��  � �� 5+      �� 5,      .R�5-      �� $��14,0,0,0q�6$    . #��� ��6Q   $��1��6�   $	 1 2R�6�   5.      50      51      �� 52   
   $ 	#FFF3F9FF��6C   �� 53   
   $ 	#FF5593FF��6?   �� 54   
   $ 	#FF212121��6>   �� 55   
   $ 	#FFE6E6E6��6B   �� 56   
   $ 	#FFBCBCBC��6>   �� 57   
   $ 	#FF707070��6=   �� 58   
   $ 	#FFD9ECFF��6A   �� 59   
   $ 	#FF3C77DD��6=   �� 5:   
   $ 	#FF212121��6<   �� 5;   
   $ 	#FF212121��6;   �� 5<   
   " 	�6$   .�5=      ��  �@�FocusVisualStyle8   61   �� 5>       � ��8  6+   �� 5?       � ��8  6,   �� 5@       � ��# � ��6+   �� 5A       � ��$ 1q�60   �� 5B       � �� 5C      �� 5D      "	 	�6&   .R�5E      � $ templateRoot��6   
������  .  5F      �� 5G   "   $
��Auto �63   �� 5H   "   $��* �63   .+�5J      �� $ radioButtonBorder��6%   #��z��6@   $	 100��6t   #��z��6�   $��1,1,2,1q�6�   #��z��6�   ._�5K   "   � $ markGrid��6'   $��2,2,0,2q�69   .+�5L   &   F� $
 path��6+   "����        �@B  � �    @B 	$��Right=�6P   $��12��6l   $��0q�6x   $
 Fill=�6�   $	��Top=�6�   $��10��6�   ��6�   Z� 5M   #   5N      �� 5O      $ contentPresenter��6/   $��1��6I   |�.  #��z��6k   #��z��6�   ��. # z 6�   #��z��6(  5P       5Q      P� 5R       � �� . . �5S   "   �� 8   �@�FocusVisualStyle6E   �� 5T   "    � ��$ 4,-1,0,0q�6<   5U      P� 5V       �@J�IsMouseOver . . �5W   "   �� $
 path��69    � ��
 �����6K   5X      P� 5Y       � {� .  . �5Z   "   �� $ contentPresenter��6@    �@J�OpacityMask
 �   �6^   5[      P� 5\       � �� . . �5]   "   �� $
 path��69    � ��
 �����6K   5^      P� 5_       �@d�	IsChecked$
 trueY�6;   . �5`   "   �� $
 path��69    � ��
 �����6K   5a      P� 5b       6;   Z�  �@d�	IsChecked5d      5f      5g      5h      .��5j      � -   5        $ 
LayoutRoot��5j       � RowDefinitions 5l   
   �� 5m      $��30 �6   �� 5n      .+�5q   
   �� $��0��6   $��0,0,0,1q�6   
���   �._�5r      �� -   5        $
 titleRectangle��5r      ���	#FF333333$ UniformToFill=�6A   5s      �� 5u   
   -   5         ��Name$ closeBtn��5u      $��X��6#   $��Right=�6/   $��25��6K   $��0,0,4,1q�6W   #���   6h   $	��Top=�6�   $��50��6�   6�   � 5x   
   $��1��6   $��0, 0,0,0q�6   ��5y      �� 5z       j� Stretch$ UniformToFill=�6    �� ImageSource$ Resources/bg.jpg��65    5|      �� 5}      �� 5~      $	��400 �6#   .+�5�      � $��0��6    5�      �� 5�      $	��400 �6$   �� 5�      .+�5�      � $��0��6   $��0,0,0,0q�6$   $��2��65   $	��600��6F    5�      �� 5�      �� 5�      .+�5�      �� ���	#FFE2413E$��5q�65   $ 20��6I   ���	#66000000$	��300��6r   $
��Left=�6~   $��99��6�   $	��Top=�6�   $��	20,10,0,0q�6�   ._�5�      ��  �� Orientation$ Vertical=�6%   $��Center=�6<   $��0,10,0,0q�6Y   $	��250��6k   .+�5�      �� -   5         ��Name$ 
tbOpponent��5�   (   $
��Left=�6<   $
��Wrap=�6W   $��Player 2��6k   $	��Top=�6{   
�������$��18.667(�6�   $��Manteka)�6�    �� Padding$ 0,0,0,20q�6�   $��24��6�   $��0,0,0,5q�6�   � 5�      -   5          �Name$  
pbOpponent��5�   *   $��13��6>   $	��180��6J   ���	#FF00FF5D$��0q�6m   $��Right=�6x   ! � Value$	! 100Q�6�   �� 5�      
�������$��14.667(�6;   $��Manteka)�6M   $��Right=�6b   $��0,5,20,0q�6~   $��Bottom=�6�   �� 6�   $�30/30��6�   6�   5�      5�      �� 5�      ���	#FFE2413E$��5q�65   $ 20��6I   ���	#66000000$	��300��6r   $��Right=�6~   $��99��6�   $��Center=�6�   $��	20,20,0,0q�6�   $��1��6�   ._�5�      �� $ Vertical=�6%   $��Center=�6<   $��0,10,0,0q�6Y   $	��250��6k   .+�5�      �� -   5        $ tbHome��5�   (   $
��Left=�68   $
��Wrap=�6S   $��Player 1��6g   $	��Top=�6w   
�������$��18.667(�6�   $��Manteka)�6�   $ 0,0,0,20q�6�   $��24��6�   $��0,0,0,5q�6�   � 5�      -   5        $  pbHome��5�   *   $��13��6:   $	��180��6F   ���	#FF00FF5D$��0q�6i   $��Right=�6t   $	! 100Q�6�   �� 5�      
�������$��14.667(�6;   $��Manteka)�6M   $��Right=�6b   $��0,5,20,0q�6~   $��Bottom=�6�   �� 6�   $�30/30��6�   6�   5�      5�      5�      � 5�      $��1��6   $��Bottom=�6$   .+�5�      �� ���	#FFE2413E$��5q�65   $ 5��6I   ���	#66000000$	��130��6q   $��Center=�6~   ._�5�      ]� $��Center=�6$   .+�5�      �� -	   5        " ��Name$" spNormalAttack��5�   )   $��Center=�6A   $��50,0,0,0q�6\   .+�5�   "   	� -
   5        # 	�Name$# rbTackle��5�   .   #���  6@   $��Tackle��6g   $��0,0,0,20q�6x   $��Manteka)�6�   
�������$��16(�6�   $��0q�6�   $ 	� 	GroupName$$ CommandFight��6�   6�   	� 5�   "   -   5        $# 	rbEndTurn��5�   .   #���  6A   $��End Turn��6h   $��0q�6{   $��Manteka)�6�   
�������$��16(�6�   $��0q�6�   $$ CommandFight��6�   6�   5�      �� 5�      -   5        $" spSkills��5�   )   $��Center=�6;   $��50,0,0,0q�6V   .+�5�   "   	� -   5        $# rbSkill1��5�   .   #���  6@   $��Skill A��6g   $��0,0,0,20q�6y   $��Manteka)�6�   
�������$��16(�6�   $��0q�6�   $$ CommandFight��6�   6�   	� 5�   "   -   5        $# rbSkillB��5�   .   #���  6@   $��Skill B��6g   $��0q�6y   $��Manteka)�6�   
�������$��16(�6�   $��0q�6�   $$ CommandFight��6�   6�   5�      �� 5�      ���	#FFE2413E$��5q�6=   $ 5��6Q   ���	#66000000$	��130��6y   $��Center=�6�   $	��216��6�   $��0,-10q�6�   $��Right=�6�   ._�5�   "   � $��Center=�6'   $
��Left=�6B   .+�5�   &   �� $��30,0,0,0q�61   $��Center=�6C   .+�5�   *   	� -   5        $# rbFight��5�   6   $��FIGHT��6G   $��0,0,0,20q�6W   $��Manteka)�6i   
�������$��16(�6�   $��0q�6�   #���  6�   $$ CommandGroup��6�   6�   	� 5�   *   -   5        $# rbGiveup��5�   6   $��GIVE UP��6H   $��0q�6Z   $��Manteka)�6e   
�������$��16(�6�   $��0q�6�   $$ CommandGroup��6�   #���  6�   6�   5�   '   5�   #   5�      �� 5�      -   5        $ lbStory��5�   (   $��50,0,0,0q�69   $
��Wrap=�6K   $��Manteka)�6_   $��16(�6t   
�������$	��380��6�   $
��Left=�6�   $��Center=�6�   5�      5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $	��650 �6$   �� 5�      $
��auto �6$   .+�5�      � $��0��6   $
��auto��6$   .+�5�      �� -   5        % ��Name$% rbChat��5�   "   $��
10,10,10,0q�62   $��2��6F   ���	#99000000$��Stretch=�6�   $��Stretch=�6�   
�������& �� 
IsReadOnly& . ' �� IsReadOnlyCaretVisible' . $��roboto)�6  ( � Cursor$( Arrow��6$  ��6n   Z� 6$  5�      � 5�      $��1��6   $��
10,10,10,0q�6$   .+�5�      �� ���	#FFE2413E$��5q�65   $ 5��6I   ���	#66000000$��70��6q   $��0q�6}   $��1��6�   ._�5�      �� $ 
Horizontal=�6%   .+�5�      �� -   5        ) ��Name$) 	tbMessage��5�   &   $
��Left=�69   $��10,12.5,0,0q�6T   * �� TextWrapping$
* Wrap=�6i   $��Enter your message��6}   $	��Top=�6�   $��35��6�   $��Center=�6�   $	��260��6�   
�������$��Roboto)�6)  ��6�   Z� ��6�   Z� 6=  �� 5�      -   5        $ tbSend��5�   %   $
��SEND��65   $��33��6D   $��10,0,0,0q�6P   $��1��6b   $��Center=�6o   $
��79.5��6�   $��Manteka)�6�   
����������	#FFE2413E��6�   Z� 6�   5�      5�      5�      5�      5�      5�      5�      
   M S B A M L   `   `   `  ����  MonsterFeastClient#    MonsterFeastClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login��5   	   $	��720��6   $
��1080��6$   ���	#FF262626 � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $# Resources\ButtonTemplate.xaml?�6%   �� 5	      $$ Resources\TextBoxTemplate.xaml?�6%   �� 5
      $( "Resources\PasswordBoxTemplate.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��Uniform=�6    $	��300��62   $��Resources/logo.png��6>   � 5   
   $��1��6   $��Center=�6   $��Center=�6<   $��	0,0,100,0q�6W    � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   .+�5      �� -   5        $��Nickname��5   L      TextBoxTemplate#��[  6   $��0��6?   6L   �� 5        J� IsHitTestVisible .  $��Nickname��61   $��Manteka)�6A   $��Center=�6V   $
��Left=�6q   $��12,0,0,0q�6�   
�������$��18(�6�   ��5!      �� 5"       �� 
TargetType" ��6   .�5#      ��  �� Property � y�	 �� Value$	 	Collapsed=�67   
 �� Triggers
 5$      �� 5%       �� Binding 6*   �� *Text+ �� ElementName$ Nickname�� �� Value  6Y   .a�5&   "   ��  � y�$	 Visible=�6?   5'      5)      5+      G� 5,      -   5        $
��Pass��5,   h    � ToolTip$ Password��6     PasswordBoxTemplate#��[ 6.   $��1��6[   6h   �� 5-       .  $��Password��61   $��Manteka)�6A   $��Center=�6V   $
��Left=�6q   $��12,0,0,0q�6�   
�������$��18(�6�   ��5.      �� 5/      " ��6   .�50      ��  � y�$	 	Collapsed=�67   
 51      �� 52       6*   �� *Text+$
 Pass��  6U   .a�53   "   ��  � y�$	 Visible=�6?   54      56      58      59      5<      5=      
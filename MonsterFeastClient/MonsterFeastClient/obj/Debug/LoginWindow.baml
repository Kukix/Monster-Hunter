   M S B A M L   `   `   `  ����  MonsterFeastClient$    MonsterFeastClient.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  MonsterFeast | Login��5   	   $	��720��6&   $
��1080��63    � WindowStartupLocation$ CenterScreen=�6@   ���	#FF262626.��5      �  � ColumnDefinitions 5   
   �� 5      $	��540 �6   6-   �� 5      $	��540 �6   6-   .+�5
   
   �� $��0��6   $��Uniform=�6    $	��300��62   $��Resources/logo.png��6>   � 5   
   $��1��6   $��Center=�6    � RowDefinitions 5      �� 5      $
��auto �6    60   .+�5      �� -   5         ��Name$ 
loginPanel��5      $��Center=�6-   .+�5      �� -   5         ��Name$ 
tbUsername��5      $��35��6.    �� TextWrapping$
 Wrap=�6:   $��Username��6N   $	��250��6^   �� 5      -   5        $ 
tbPassword��5      $��35��6.   $
 Wrap=�6:   $��Password��6N   $	��250��6^   �� 5      -   5         ��Name$ btnLogin��5      $��Login��6C   $��30��6S   $	��125��6_   �� 5      -   5         ��Name$ 
tbRegister��5      $��Register here��60   $	��250��6E   $��30��6Q   $��16(�6]   6�   5      �� 5      -   5        $ registerPanel��5      $��Center=�60   $y�	Collapsed=�6K   .+�5      �� -   5        $ tbName��5      $��35��6*   $
 Wrap=�66   $��Username��6J   $	��250��6Z   �� 5      -   5        $ tbPass��5      $��35��6*   $
 Wrap=�66   $��Password��6J   $	��250��6Z   �� 5      -	   5        $ btnRegister��5      $��Register��6F   $��30��6Y   $	��125��6e   �� 5      -
   5        $ tbLogin��5      $��
Login here��6-   $	��250��6?   $��30��6K   $��16(�6W   6�   5      5"      5$      5%      
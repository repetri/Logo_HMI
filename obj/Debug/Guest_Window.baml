   M S B A M L   `   `   `  ����S  OLock-Tech operator panel, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Lock_Tech_operator_panelLock_Tech_operator_panel  5   	   +    %Lock_Tech_operator_panel.Guest_Window   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Lock_Tech_operator_panel     5   	   -   5          �Name$  Guest_window��5   	    � Title$ Guest_Window��5   	   $��859.2��6   $��1492.8��6-    � WindowStartupLocation$ CenterScreen=�6<    � WindowState$ 	Maximized=�6a    � Icon$ Lock-Tech-Logo.ico��6y   
���   ����	#FFDADADA.��5	      � ���	#FFF7F7F7 � Cursor$ Arrow��6"   .+�5
   
   �� ���	#FFBEBEBE$
��Left=�6%   $	��114��6@   $��550,438,0,0q�6M   
���   �$	��Top=�6q   $	��280��6�   $��3��6�   o� 5   
   $
��Left=�6   $��20��6*   $	��Top=�67   $
��auto��6O   .@�5      m� $
��File��6   $ Arrow��6%   .@�5      m� -   5         m�Name$ Log_out��5      $��Log out��6,   $
��Left=�6=   $	��140��6X   $ Arrow��6d   6s   m� 5      -   5        $ Open_website��5      $��Open website��61   $
��Left=�6G   $ Arrow��6b   $	��160��6q   6}   m� 5      -   5        $ Close��5      $��Close��6*   $
��Left=�69   $	��140��6T   $ Arrow��6`   6o   5      m� 5      $��Connections��6   .@�5      m� -   5        $ Con_PLC��5      $��Connect to plc��6,   $
��left=�6D   $	��165��6_   6k   m� 5      -   5        $ 
Discon_PLC��5      $��Disconnect from plc��6/   $
��Left=�6L   $	��190��6g   6s   5      5      A� 5   
   -   5         A�Name$ LED_Standby��5      
�������$
��Left=�64   $��80��6O   $��350,250,0,0q�6[   
���   �$	��Top=�6   $��80��6�   $ Arrow��6�   $��3��6�   �� 5   
   -   5         ��Name$ BT_start��5      $��Start��6#   $
��Left=�63   $��568,479,0,0q�6N   $	��Top=�6c   $��80��6{   $��40��6�   $
��Bold"�6�   
���   �
���   �
��� � �$
 Hand��6�   $��2q�6  A� 5   
   -	   5        $ LED_Busy��5      ���	#FFFDFDFD$
��Left=�65   $��80��6P   $��550,250,0,0q�6\   
���   �$	��Top=�6�   $��80��6�   $ Arrow��6�   $��3��6�   A� 5   
   -
   5        $ 	LED_ERROR��5      ���	#FFFEFEFF$
��Left=�66   $��80��6Q   $��750,250,0,0q�6]   
���   �$	��Top=�6�   $��80��6�   $ Arrow��6�   $��3��6�   �� 5   
   -   5        $ BT_stop��5      $
��Stop��6"   $
��Left=�61   $��738,479,0,0q�6L   $	��Top=�6a   $��75��6y   $��40��6�   $
��Bold"�6�   
���   �$
 Hand��6�   $��2q�6�   
���  ��6�   �� 5   
   $��Stand-by��6   $
��Left=�6#   $��350,220,0,0q�6>   $	��Top=�6S   $��80��6k   $
��Bold"�6v   $��Center=�6�   
���   �$ Arrow��6�   �� 5   
   $��Running��6   $
��Left=�6"   $��550,220,0,0q�6=   $	��Top=�6R   $��75��6j   $
��Bold"�6u   $��Center=�6�   
���   �$ Arrow��6�   �� 5   
   $��Error��6   $
��Left=�6    $��750,220,0,0q�6;   $	��Top=�6P   $��80��6h   $��Center=�6s   $
��Bold"�6�   
���   �$ Arrow��6�   A� 5   
   -   5        $ LED_Connection��5      
�������$
��Left=�67   $��80��6R   $��938,250,0,0q�6^   
���   �$	��Top=�6�   $��80��6�   $ Arrow��6�   $��3��6�   �� 5   
   $��Connection status��6   $
��Left=�6,   $��911,220,0,0q�6G   $	��Top=�6\   $	��134��6t   $
��Bold"�6�   $��Center=�6�   
���   �$ Arrow��6�   �� 5    
   -   5        	 ��Name$	 	TB_errors��5       
 �� 
IsReadOnly
 . $
��Left=�68   $	��116��6S   $��1099,250,0,0q�6`    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��183��6�   
���   �$ Arrow��6�    �� SelectionOpacity$ 0Q�6�   * �� #IsInactiveSelectionHighlightEnabled . $��2q�6,  " �� VerticalScrollBarVisibility$
 Auto=�6@   �� SelectionBrush 6�   Z� 6c  �� 5!   
   $��Error information: ��6   $
��Left=�6.   $��1126,220,0,0q�6I   $	��Top=�6_   $	��126��6w   $
��Bold"�6�   $��Center=�6�   
���   �$ Arrow��6�   �� 5"   
   $��Cycle��6   $
��Left=�6    $��654,447,0,0q�6;   $	��Top=�6P   $��80��6h   $
��Bold"�6s   $��Center=�6�    J� RenderTransformOrigin$ -1.425,3.115&�6�   
���   ����	#FFBEBEBE6�   �� 5#   
   -   5         ��Name$ 
logo_guest��5#      $$��http://i.imgur.com/DnMSDFB.png��6$   $
��Left=�6M   $	��206��6h   $��1057,508,0,0q�6u   $	��Top=�6�   $	��292��6�   $
��Fill=�6�   5%      5&      
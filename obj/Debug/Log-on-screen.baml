   M S B A M L   `   `   `  ����S  OLock-Tech operator panel, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Lock_Tech_operator_panelLock_Tech_operator_panel  5   	   ,    &Lock_Tech_operator_panel.Log_on_screen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Lock_Tech_operator_panel     5   	   -   5          �Name$  Log_on_screen1��5   	    � Title$ Log_on_screen��5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowState$ 	Maximized=�6D    � Icon$ Lock-Tech-Logo.ico��6\    � 
ResizeMode$ CanMinimize=�6v    � Cursor$ Arrow��6�   $��940.5��6�   $��593.5��6�   .��5	      � $��0,0,0,-2q�6    � ColumnDefinitions 5
   
   �� 5      $
��691* �6   �� 5      $
��259* �6   .+�5   
   �� -   5         ��Name$
 Logo��5      $$��http://i.imgur.com/DnMSDFB.png��6   $��153,10,219,271q�6G   $
��Fill=�6_   	 J� RenderTransformOrigin$	 0.5,0.5&�6n   $��2��6�   �� 5   
   -   5        
 ��Name$
 LOGIN_BT��5      $��2��6#   $��Login��60   $��410,451,0,0q�6@   $
��Left=�6l   $��85��6�   $��30��6�   $	��Top=�6�   $
 Hand��6�   �� 5   
   -   5         ��Name$ USER_NAME_TB��5      $��0��6(   $��410,374,0,0q�65    �� TextWrapping$
 Wrap=�6J   $�� ��6^   $��23��6f   $	��Top=�6r   $
��Left=�6�   $	��224��6�   $ IBeam��6�   6�   �� 5   
   -   5         ��Name$ USER_NAME_LB��5      ��.  $��
Username: ��68   $��403,351,202,0q�6M   $��26��6d   $	��Top=�6p   $��Stretch=�6�   �� 5   
   -   5        $ PSW_LB��5      ��.  $��
Password: ��62   $��403,397,209,0q�6G   $��26��6^   $	��Top=�6j   �� 5   
   -   5        $
 RESET_BT��5      $��3��6#   $��Forgot password ?��60   $��511,451,0,0q�6L   $��30��6x   $	��Top=�6�   $
��Left=�6�   $	��102��6�   $
 Hand��6�   G� 5   
   -   5         G�Name$ PSW_BOX��5      $��1��6'   $��410,423,0,0q�64   $
��Left=�6I   $	��224��6d   $��23��6p   $	��Top=�6|   $��Center=�6�   $ IBeam��6�   o� 5   
   -	   5         o�Name$ 
Menu_strip��5      $
��Auto��6#   $��20��60   $	��Top=�6<   ��6T   Z� .@�5      m� $
��File��6   $ Arrow��6%   .@�5      m� -
   5         m�Name$ 	App_close��5      $��Close��6.   $
��Left=�6=   $	��140��6X   $ Arrow��6d   6s   5      5      �� 5   
   -   5        $ LB_CAPS_LOCK��5      $��CAPS-LOCK is on!��6&   $
��Left=�6A   $��651,397,0,0q�6\   $	��Top=�6q   $��2��6�   $	��109��6�   ���	#FFE2D924
���   �$��2q�6�   $y�	Collapsed=�6�   5      5      
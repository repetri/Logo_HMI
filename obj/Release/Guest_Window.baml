   M S B A M L   `   `   `  ���� S  OLock-Tech operator panel, Version=9.0.1.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Lock_Tech_operator_panelLock_Tech_operator_panel  +    %Lock_Tech_operator_panel.Guest_Window   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Lock_Tech_operator_panel     -     �Name$  Guest_window�� � Title$ Guest_Window��$��859.2��$��1492.8�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � Icon$ Lock-Tech-Logo.ico��
���   ����	#FFDADADA.��� ���	#FFF7F7F7 � Cursor$ Arrow��.+��� ���	#FFBEBEBE$
��Left=�$	��114��$��550,438,0,0q�
���   �$	��Top=�$	��280��$��3��o� $
��Left=�$��20��$	��Top=�$
��auto��.@�m� $
��File��$ Arrow��.@�m� -    m�Name$ Log_out��$��Log out��$
��Left=�$	��140��$ Arrow��m� -   $ Open_website��$��Open website��$
��Left=�$ Arrow��$	��160��m� -   $ Close��$��Close��$
��Left=�$	��140��$ Arrow��m� $��Connections��.@�m� -   $ Con_PLC��$��Connect to plc��$
��left=�$	��165��m� -   $ 
Discon_PLC��$��Disconnect from plc��$
��Left=�$	��190��A� -    A�Name$ LED_Standby��
�������$
��Left=�$��80��$��350,250,0,0q�
���   �$	��Top=�$��80��$ Arrow��$��3���� -    ��Name$ BT_start��$��Start��$
��Left=�$��568,479,0,0q�$	��Top=�$��80��$��40��$
��Bold"�
���   �
���   �
��� � �$
 Hand��$��2q�A� -	   $ LED_Busy�����	#FFFDFDFD$
��Left=�$��80��$��550,250,0,0q�
���   �$	��Top=�$��80��$ Arrow��$��3��A� -
   $ 	LED_ERROR�����	#FFFEFEFF$
��Left=�$��80��$��750,250,0,0q�
���   �$	��Top=�$��80��$ Arrow��$��3���� -   $ BT_stop��$
��Stop��$
��Left=�$��738,479,0,0q�$	��Top=�$��75��$��40��$
��Bold"�
���   �$
 Hand��$��2q�
���  ���� $��Stand-by��$
��Left=�$��350,220,0,0q�$	��Top=�$��80��$
��Bold"�$��Center=�
���   �$ Arrow���� $��Running��$
��Left=�$��550,220,0,0q�$	��Top=�$��75��$
��Bold"�$��Center=�
���   �$ Arrow���� $��Error��$
��Left=�$��750,220,0,0q�$	��Top=�$��80��$��Center=�$
��Bold"�
���   �$ Arrow��A� -   $ LED_Connection��
�������$
��Left=�$��80��$��938,250,0,0q�
���   �$	��Top=�$��80��$ Arrow��$��3���� $��Connection status��$
��Left=�$��911,220,0,0q�$	��Top=�$	��134��$
��Bold"�$��Center=�
���   �$ Arrow���� -   	 ��Name$	 	TB_errors��
 �� 
IsReadOnly
 . $
��Left=�$	��116��$��1099,250,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��183��
���   �$ Arrow�� �� SelectionOpacity$ 0Q�* �� #IsInactiveSelectionHighlightEnabled . $��2q�" �� VerticalScrollBarVisibility$
 Auto=� �� SelectionBrush Z� �� $��Error information: ��$
��Left=�$��1126,220,0,0q�$	��Top=�$	��126��$
��Bold"�$��Center=�
���   �$ Arrow���� $��Cycle��$
��Left=�$��654,447,0,0q�$	��Top=�$��80��$
��Bold"�$��Center=� J� RenderTransformOrigin$ -1.425,3.115&�
���   ����	#FFBEBEBE�� -    ��Name$ 
logo_guest��$$��http://i.imgur.com/DnMSDFB.png��$
��Left=�$	��206��$��1057,508,0,0q�$	��Top=�$	��292��$
��Fill=�
   M S B A M L   `   `   `  ���� S  OLock-Tech operator panel, Version=9.0.1.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Lock_Tech_operator_panelLock_Tech_operator_panel  ,    &Lock_Tech_operator_panel.Log_on_screen   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Lock_Tech_operator_panel     -     �Name$  Log_on_screen1�� � Title$ Log_on_screen�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � Icon$ Lock-Tech-Logo.ico�� � 
ResizeMode$ NoResize=� � Topmost .  � Cursor$ Arrow��$��940.5��$��593.5��.��� $��0,0,0,-2q� � ColumnDefinitions �� $
��691* ��� $
��259* �.+��� -   	 ��Name$
	 Logo��$$��http://i.imgur.com/DnMSDFB.png��$��213,10,159,271q�$
��Fill=�
 J� RenderTransformOrigin$
 0.5,0.5&�$��2���� -    ��Name$ LOGIN_BT��$��2��$��Login��$��581,460,0,0q�$
��Left=�$��85��$��30��$	��Top=�$
 Hand���� -    ��Name$ USER_NAME_TB��$��0��$��581,369,0,0q� �� TextWrapping$
 Wrap=�$�� ��$��2��$��23��$	��Top=�$
��Left=�$	��224��$ IBeam���� -    ��Name$ USER_NAME_LB����.  $��
Username: ��$��581,346,41,0q�$��26��$	��Top=�$��Stretch=��� -   $ PSW_LB����.  $��
Password: ��$��581,397,45,0q�$��26��$	��Top=��� -   $ RESET_BT��$��3��$��Forgot password ?��$��680,460,0,0q�$��2��$��30��$	��Top=�$
��Left=�$	��102��$
 Hand��G� -    G�Name$ PSW_BOX��$��1��$��581,423,0,0q�$��2��$
��Left=�$	��224��$��23��$	��Top=�$��Center=�$ IBeam��o� -	    o�Name$ 
Menu_strip��$
��Auto��$��20��$	��Top=���Z� .@�m� $
��File��$ Arrow��.@�m� -
    m�Name$ 	App_close��$��Close��$
��Left=�$	��140��$ Arrow��
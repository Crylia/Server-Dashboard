   M S B A M L   `   `   `  ����K  GServer Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:Server_Dashboard.Views.DashboardPages.ModuleCRUD0Server_Dashboard.Views.DashboardPages.ModuleCRUD  5   	   3clr-namespace:Server_DashboardServer_Dashboard  5   	   H    BServer_Dashboard.Views.DashboardPages.ModuleCRUD.CreateModulePopup   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Plocal>clr-namespace:Server_Dashboard.Views.DashboardPages.ModuleCRUD     5   	   /rootclr-namespace:Server_Dashboard     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  65     � 
ResizeMode$  NoResize=�5
   	   $	��700��5   	   $	��500��5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6      ResizeBorderThickness$ 0q�6)   .��5      �� $	��500��5   	   $	��700��5   	   ��5   
   �� 5       �� Color$ #2D2D2D��6    �� Opacity$ 1Q�6.   ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    �� 5      $��* �6    .+�5      �    BackgroundSurface_04dp#��[  5      $��0��5       *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5"      +  %Microsoft.Xaml.Behaviors.EventTrigger  5#         	EventName$ 	MouseDown��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase	   Actions.	 5$      4  .Microsoft.Xaml.Behaviors.Core.CallMethodAction  
   
MethodName$
 DragMove��6-      TargetObject 6C   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window5%       � ColumnDefinitions 5'      �� 5(      �� 5)      $��40 �6'   .+�5+      �� $��0��5,      $��Create a new Server��5-      $��5 0 0 0q�5.        DeepPurple_A100#��[ 5/      $��Center=�50      �� 52        CloseButton#��[ 53      $��2��54      $	��✕��55       � Cursor$
 Hand��56       58        59      $ Click��6)   .	 5:        $
 Close��61    6D   ��  �� $ FindAncestor=�
 Window5;      5=      5>      � 5?      #��[  5@      $��1��5A      $��20q�5B       J� Effect 5D      3  -System.Windows.Media.Effects.DropShadowEffect  5E         	Direction$ 0Q�6'      
BlurRadius$ 5Q�65      ShadowDepth$ 0Q�6D    5G      �� 5H      �� 5I      �� 5J      �� 5K      �� 5L      �� 5M      .+�5O      �� $��Center=�6   $��0��68   $��	20 0 20 0q�6E   .+�5P      ��  �� Orientation$ 
Horizontal=�6!   .+�5Q      �� $��Server Name��5R      $��24(�5S      $��0 0 0 5q�5T      ��5V      �� 5W   "   $ White��62   $
 0.87Q�6@   5Y      �� 5Z      $��*��5[        ErrorRed#��[ 5\      $��20(�5]      5_      � 5`       5a        5b      $ 0Q�6/   $ 5Q�6=   $ 0Q�6L   .+�5d      �� -   5         ��Name$ 
ServerName��5i      $��1��5f      $��40��5g      $��20(�5h      ��5e      �� *
ServerName+5i      �� 5k      $��Center=�5l      $
��Left=�5m      $��My Awesome Server��5n      $��20(�5o      $��1��5q       J� IsHitTestVisible$ False��5r      $��5 0 0 0q�5s      y�5p      ��  �� ElementName$ 
ServerName�� �� Path$ Text.IsEmpty�  UserNameVisibillity �� 	Converter# [ ��5u      �� 5v   "   $ White��62   $
 0.12Q�6@   5x      5y      5z      �� 5{      $��Center=�6   $��1��68   $��	20 0 20 0q�6E   .+�5|      �� $ 
Horizontal=�6!   .+�5}      �� $��Password��5~      $��24(�5      $��0 0 0 5q�5�      ��5�      �� 5�   "   $ White��62   $
 0.87Q�6@   5�      �� 5�      $��*��5�      #��[ 5�      $��20(�5�      5�      � 5�       5�        5�      $ 0Q�6/   $ 5Q�6=   $ 0Q�6L   .+�5�      G� -   5         G�Name$ Password��5�      $	��420��5�      $��Center=�5�      $
��Left=�5�      �   �Server_Dashboard.BaseAttachedProperty`2[[Server_Dashboard.MonitorPasswordProperty, Server Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value$
 True��5�      $��1��5�      $��20(�5�      $��40��5�      5�      �� 5�      -   5         ��Name$ PasswordHint��5�   �   $��********��5�      $��1��5�      $ False��5�      $��Center=�5�      $
��Left=�5�      $��5 0 0 0q�5�      $��20(�5�      y�5�      �� $ Password��$" (root:HasTextProperty.Value)�# [ ��5�      �� 5�   "   $ White��62   $
 0.12Q�6@   5�      5�      5�      �� 5�      $��Center=�6   $��2��68   $��	20 0 20 0q�6E   .+�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��Username��5�      $��24(�5�      $��0 0 0 5q�5�      ��5�      �� 5�   "   $ White��62   $
 0.87Q�6@   5�      �� 5�      $��*��5�      #��[ 5�      $��16(�5�      5�      � 5�       5�        5�      $ 0Q�6/   $ 5Q�6=   $ 0Q�6L   .+�5�      �� -   5        $ UserName��5�      $��1��5�      $��40��5�      $��20(�5�      ��5�      �� *
Username+5�      �� 5�      $��Center=�5�      $
��Left=�5�      $
��Name��5�      $��20(�5�      $��1��5�      $ False��5�      $��5 0 0 0q�5�      y�5�      �� $ UserName��$ Text.IsEmpty�# [ ��5�      �� 5�   "   $ White��62   $
 0.12Q�6@   5�      5�      5�      �� 5�      $��Center=�6   $��3��68   $��	20 0 20 0q�6E   .+�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��	IP Adress��5�      $��24(�5�      $��0 0 0 5q�5�      ��5�      �� 5�   "   $ White��62   $
 0.87Q�6@   5�      �� 5�      $��*��5�      #��[ 5�      $��16(�5�      5�      � 5�       5�        5�      $ 0Q�6/   $ 5Q�6=   $ 0Q�6L   .+�5�      �� -   5        $ IPAdress��5�      $��1��5�      $��40��5�      $��20(�5�      ��5�      �� *
IPAdress+5�      �� 5�      $��Center=�5�      $
��Left=�5�      $��sample.ssh.com��5�      $��20(�5�      $��1��5�      $ False��5�      $��5 0 0 0q�5�      y�5�      �� $ IPAdress��$ Text.IsEmpty�# [ ��5�      �� 5�   "   $ White��62   $
 0.12Q�6@   5      5     5     �� 5     $��Center=�6   $��4��68   $��	20 0 20 0q�6E   .+�5     �� $
��Port��5     $��24(�5     $��0 0 0 5q�5     ��5	     �� 5
     $ White��6.   $
 0.87Q�6<   5     � 5      5       5     $ 0Q�6/   $ 5Q�6=   $ 0Q�6L   .+�5     �� -   5        $
 Port��5     $��1��5     $��40��5     $��20(�5     ��5     �� *Port+5     �� 5     $��Center=�5     $
��Left=�5     $��22��5     $��20(�5     $��1��5     $ False��5     $��5 0 0 0q�5      y�5     �� $
 Port��$ Text.IsEmpty�# [ ��5"     �� 5#  "   $ White��62   $
 0.12Q�6@   5%     5&     5'     �� 5(     $��60��5)     $	��350��5*     $��5��5-     $��CREATE MODULE��5.     $��2��5/     ��5+     �� *CreateModuleCommand+��5,     �� $ CREATE_MODULE��5/     51     52     53     54     
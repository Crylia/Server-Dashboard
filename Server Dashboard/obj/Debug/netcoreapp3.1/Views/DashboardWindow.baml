   M S B A M L   `   `   `  ����K  GServer Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Server_Dashboard.ViewsServer_Dashboard.Views  5   	   3clr-namespace:Server_DashboardServer_Dashboard  5   	   ]3clr-namespace:Server_Dashboard.Views.DashboardPages%Server_Dashboard.Views.DashboardPages  5   	   ,    &Server_Dashboard.Views.DashboardWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Server_Dashboard.Views     5   	   /rootclr-namespace:Server_Dashboard     5   	   Eviews3clr-namespace:Server_Dashboard.Views.DashboardPages     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	   	   b ^SharpVectors.Converters.Wpf, Version=1.7.1.0, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/  5
   	   $
��1000��5   	   $
��Auto��5   	     � WindowStyle$
  None=�5   	   
������  � 
ResizeMode$ 	CanResize=�5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6    � DataContext 5      )  #Server_Dashboard.DashboardViewModel  5   
   .��5      �    BackgroundSurface_00dp#��[  6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5    
   �   BackgroundSurface_06dp#��[ 6   $��0��6D    � ColumnDefinitions 5!      �� 5"      $��* �6#   �� 5#      $��40 �6#   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5%      +  %Microsoft.Xaml.Behaviors.EventTrigger  5&         	EventName$ 	MouseDown��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase	   Actions.	 5'      4  .Microsoft.Xaml.Behaviors.Core.CallMethodAction  
   
MethodName$
 DragMove��6)      TargetObject 6?   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window5(      .+�5*      �� $��0��6   �� 5+        CloseButton#��[ 6   $��2��6:   $	��✕��6J    � Cursor$
 Hand��6V    5,        5-      $ Click��6%   .	 5.        $
 Close��6-    6@   ��  �� $ FindAncestor=�
 Window5/      51      52      � 54   
   -   5         �Name$ 
TopBarGrid��54   Q     BackgroundSurface_04dp#��[ 6   $��1��6D    J� Effect 55      3  -System.Windows.Media.Effects.DropShadowEffect  56         	Direction$	 270Q�6#      
BlurRadius$ 5Q�63    58      �� 59      $
��Auto �6#   �� 5:      $��* �6#   �� 5;      $
��Auto �6#   �� 5<      $
��Auto �6#   �� 5=      $
��Auto �6#   .+�5?      �� $��0��6   ��5@      �� 5A       �� 
TargetType" ��6&   .R�5B      ��  ��Name$ Border��5C       �� CornerRadius$ 4��5D       �� Padding$ 2q�5E      
������ 
������ $��0q�5H      ._�5J      (  "SharpVectors.Converters.SvgViewbox     Source$# ../Assets/Images/Settings.svg?�5K   !   $��5q�5L   !    J� IsHitTestVisible$ False��5M   !    J� Opacity$
 0.87Q�5N   !   5P       �� Triggers 5Q      P� 5R       P� Property �@J�IsMouseOver P� Value$
 True��6=   5S      P� 5T       � ��$
 True��6;   5U      5W      5Y      �� 5Z      $��4��5[      $��	10 0 10 0q�5^      $��40��5_      $
 Hand��6   ��5\      �� *OpenLinkCommand+��5]      �� *
UserName+��5a      �� 5b      " ��6&   .R�5c      �� $ Border��6!   $ 5��61   #��z��6B   #��z��6l   $��0q�6�    5d        5e   "   $ 0Q�63      ShadowDepth$ 0Q�6A   $ 5Q�6Q   ._�5g      �� $ BackgroundOverlay��6%   $ 4��6@   
������ #��z��6j   ��5h   "   �� 5i   &    �� Color$ White��66     �� Opacity$
  0.12Q�6D   ._�5k   "   �� ! �� Orientation$! 
Horizontal=�6-   .+�5l   &     $ ../Assets/Images/User.svg?�5m   )   $��5q�5n   )   $ False��5o   )   $
 0.87Q�5p   )   �� 5r   &   #��z��5s   )   " �� TextAlignment$" Center=�5t   )   # �� Padding$# 0q�5u   )   $
��Wrap=�5v   )   #��z��5w   )   #��z��5x   )   $��Center=�5y   )   $��Center=�5z   )   $��5 0 10 0q�5{   )   5}   #   5~      5       5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   �� $ �� 
TargetName$$ BackgroundOverlay��6)   % �� Property% � ��& �� Value& 5�   &   �� 5�   *   $ #B388FF��6:   $
  0.04Q�6J   5�   #   5�      P� 5�       �@J�	IsFocused$
 True��6;   5�      P� 5�       � ��$
 True��6;   . �5�   "   �� $$ BackgroundOverlay��6)   % � ��& 5�   &   �� 5�   *   $ #B388FF��6:   $
  0.12Q�6J   5�   #   �� 5�   "   $$ BackgroundOverlay��6)   % � ��& 5�   &   �� 5�   *   $ #B388FF��6:   $	  .87Q�6J   5�   #   5�      5�      5�      �� 5�      $��3��5�      $5��/https://github.com/Crylia/Server-Dashboard/wiki��5�      $
��Docs��5�      $��	10 0 10 0q�5�      $��40��5�      ��5�      �� *OpenLinkCommand+��5�      �� 5�      " ��6&   .R�5�      �� $ Border��6!   $ 5��61   #��z��6B   #��z��6l   $��0q�6�    5�        5�   "   $ 0Q�63   $ 0Q�6A   $ 5Q�6Q   ._�5�      �� $ BackgroundOverlay��6%   $ 4��6@   
������ #��z��6j   ��5�   "   �� 5�   &   $ White��66   $
  0.12Q�6D   ._�5�   "   �� $! 
Horizontal=�6-   .+�5�   &     $ ../Assets/Images/Docs.svg?�5�   )   $��5q�5�   )   $ False��5�   )   $
 0.87Q�5�   )   �� 5�   &   #��z��5�   %   $" Center=�5�   %   $# 0q�5�   %   $
��Wrap=�5�   %   #��z��5�   %   #��z��5�   %   $��Center=�5�   %   $��Center=�5�   %   $��5 0 10 0q�5�   %   5�   #   5�      5�       5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   �� $$ BackgroundOverlay��6)   % � ��& 5�   &   �� 5�   *   $ #B388FF��6:   $
  0.04Q�6J   5�   #   5�      P� 5�       �@J�	IsFocused$
 True��6;   5�      P� 5�       � ��$
 True��6;   . �5�   "   �� $$ BackgroundOverlay��6)   % � ��& 5�   &   �� 5�   *   $ #B388FF��6:   $
  0.12Q�6J   5�   #   �� 5�   "   $$ BackgroundOverlay��6)   % � ��& 5�   &   �� 5�   *   $ #B388FF��6:   $	  .87Q�6J   5�   #   5�      5�      5�      �� 5�      $��2��5�      $0��*https://github.com/Crylia/Server-Dashboard��5�      $��GitHub��5�      $��	10 0 10 0q�5�      $��40��5�      $
 0.87Q�5�      $
 Hand��6    ��5�      �� *OpenLinkCommand+��5�      �� 5�      " ��6&   .R�5�      �� $ Border��6!   $ 5��61   #��z��6B   #��z��6l   $��0q�6�    5�        5�   "   $ 0Q�63   $ 0Q�6A   $ 5Q�6Q   ._�5�      �� $ BackgroundOverlay��6%   $ 4��6@   
������ #��z��6j   ��5�   "   �� 5�   &   $ White��66   $
  0.12Q�6D   ._�5�   "   �� $! 
Horizontal=�6-   .+�5�   &   �� $&�� ../Assets/Images/GitHubLight.png��5�   )   $��5q�5�   )   �� 5�   &   #��z��5�   )   $" Center=�5�   )   $# 0q�5�   )   $
��Wrap=�5�   )   #��z��5�   )   #��z��5�   )   $��Center=�5�   )   $��Center=�5�   )   $��5 0 10 0q�5�   )   5�   #   5�      5       5     P� 5      �@J�IsMouseOver$
 True��6=   . �5  "   �� $$ BackgroundOverlay��6)   % � ��& 5  &   �� 5  *   $ #B388FF��6:   $
  0.04Q�6J   5  #   5     P� 5	      �@J�	IsFocused$
 True��6;   5
     P� 5      � ��$
 True��6;   . �5  "   �� $$ BackgroundOverlay��6)   % � ��& 5  &   �� 5  *   $ #B388FF��6:   $
  0.12Q�6J   5  #   �� 5  "   $$ BackgroundOverlay��6)   % � ��& 5  &   �� 5  *   $ #B388FF��6:   $	  .87Q�6J   5  #   5     5     5     5     >� 5  
   $��3��6   .��5     =	   7Server_Dashboard.Views.DashboardPages.MainDashboardPage	  5     5     5      
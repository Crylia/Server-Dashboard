   M S B A M L   `   `   `  ����K  GServer Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:Server_Dashboard.Controls.DoubleRoundProgressBar0Server_Dashboard.Controls.DoubleRoundProgressBar  5      3clr-namespace:Server_DashboardServer_Dashboard  5      M    GServer_Dashboard.Controls.DoubleRoundProgressBar.DoubleRoundProgressBar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:Server_Dashboard.Controls.DoubleRoundProgressBar     5      c _Microsoft.Expression.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      )rootclr-namespace:Server_Dashboard  5      -   5          >�Name$  _this��5
       � 	Resources 5      ,   &Server_Dashboard.ValueToAngleConverter   valueToAngle��%   &	          5   
   6%   5      .��5      � .+�5   
   A� -   5         A�Name$ 
Background��5      $��0q�5      ��5      ��  �� ElementName$ _this�� �� Path$ BackgroundBrush���5      �� $ _this��$ BackgroundBrush�%  Microsoft.Expression.Shapes.Arc  5   
      ArcThickness$ 8Q�5         ArcThicknessUnit$ Pixel=�5       �� Stretch$
 None=�5)         
StartAngle$ 0Q�5*      	   EndAngle	 5       �� 
 �� 	Converter#
 [  $ _this��$ 	ValueRead���5%      �� $ _this��$ ReadIndicatorBrush�5*      A� 5,   
   -   5        $ 	Seperator��5-      
������ $��7q�5/       K� ZIndex$ 1��54      ��50      �� $ _this��$ ProgressBorderBrush�54      A� 56   
   -   5        $ 
Seperator2��57      
������ $��8q�59      $ 1��5>      ��5:      �� $ _this��$ ProgressBorderBrush�5>        5@   
   $��8q�5A      $ 8Q�5B      $ Pixel=�5C      $
 None=�5M      $ 0Q�5N      	 5D      �� #
 [  $ _this��$ 
ValueWrite���5I      �� $ _this��$ WriteIndicatorBrush�5N      A� 5P   
   -   5        $ Border��5Q      $��16q�5V      ��5R      �� $ _this��$ ProgressBorderBrush���5W      �� $ _this��$ ProgressBorderBrush�5]      5^      
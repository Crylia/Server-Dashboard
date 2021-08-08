using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Server_Dashboard.Controls.HalfRoundProgressBar {

    /// <summary>
    /// Dependency Properties
    /// </summary>
    public partial class HalfRoundProgressBar : UserControl {

        //Indicator Brush Property
        public static DependencyProperty IndicatorBrushProperty = DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(HalfRoundProgressBar));

        public Brush IndicatorBrush {
            get { return (Brush)GetValue(IndicatorBrushProperty); }
            set { SetValue(IndicatorBrushProperty, value); }
        }

        //Background Brush Property
        public static DependencyProperty BackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(HalfRoundProgressBar));

        public Brush BackgroundBrush {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }

        //ProgressBorder Property
        public static DependencyProperty ProgressBorderBrushProperty = DependencyProperty.Register("ProgressBorderBrush", typeof(Brush), typeof(HalfRoundProgressBar));

        public Brush ProgressBorderBrush {
            get { return (Brush)GetValue(ProgressBorderBrushProperty); }
            set { SetValue(ProgressBorderBrushProperty, value); }
        }

        //Value
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(HalfRoundProgressBar));

        public int Value {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public HalfRoundProgressBar() {
            InitializeComponent();
        }
    }
}
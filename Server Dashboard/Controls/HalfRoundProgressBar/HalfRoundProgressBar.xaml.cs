using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Server_Dashboard.Controls.HalfRoundProgressBar {

    /// <summary>
    ///     Dependency Properties
    /// </summary>
    public partial class HalfRoundProgressBar : UserControl {

        //Indicator Brush Property
        public static readonly DependencyProperty IndicatorBrushProperty = DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(HalfRoundProgressBar));

        public Brush IndicatorBrush {
            get => (Brush)GetValue(IndicatorBrushProperty);
            set => SetValue(IndicatorBrushProperty, value);
        }

        //Background Brush Property
        public static readonly DependencyProperty BackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(HalfRoundProgressBar));

        public Brush BackgroundBrush {
            get => (Brush)GetValue(BackgroundBrushProperty);
            set => SetValue(BackgroundBrushProperty, value);
        }

        //ProgressBorder Property
        public static readonly DependencyProperty ProgressBorderBrushProperty = DependencyProperty.Register("ProgressBorderBrush", typeof(Brush), typeof(HalfRoundProgressBar));

        public Brush ProgressBorderBrush {
            get => (Brush)GetValue(ProgressBorderBrushProperty);
            set => SetValue(ProgressBorderBrushProperty, value);
        }

        //Value
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(HalfRoundProgressBar));

        public int Value {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public HalfRoundProgressBar() {
            InitializeComponent();
        }
    }
}
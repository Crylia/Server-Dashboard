using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Server_Dashboard.Controls.DoubleRoundProgressBar {

    /// <summary>
    /// DependencyProperties
    /// </summary>
    public partial class DoubleRoundProgressBar : UserControl {

        //Property for the ReadIndicatorBrush
        public static readonly DependencyProperty ReadIndicatorBrushProperty = DependencyProperty.Register("ReadIndicatorBrush", typeof(Brush), typeof(DoubleRoundProgressBar));

        public Brush ReadIndicatorBrush {
            get => (Brush)GetValue(ReadIndicatorBrushProperty);
            set => SetValue(ReadIndicatorBrushProperty, value);
        }

        //Property for the WriteIndicatorBrush
        public static readonly DependencyProperty WriteIndicatorBrushProperty = DependencyProperty.Register("WriteIndicatorBrush", typeof(Brush), typeof(DoubleRoundProgressBar));

        public Brush WriteIndicatorBrush {
            get => (Brush)GetValue(WriteIndicatorBrushProperty);
            set => SetValue(WriteIndicatorBrushProperty, value);
        }

        //Property for the BackgroundBrush
        public static readonly DependencyProperty BackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(DoubleRoundProgressBar));

        public Brush BackgroundBrush {
            get => (Brush)GetValue(BackgroundBrushProperty);
            set => SetValue(BackgroundBrushProperty, value);
        }

        //Property for the ProgressBorderBrush
        public static readonly DependencyProperty ProgressBorderBrushProperty = DependencyProperty.Register("ProgressBorderBrush", typeof(Brush), typeof(DoubleRoundProgressBar));

        public Brush ProgressBorderBrush {
            get => (Brush)GetValue(ProgressBorderBrushProperty);
            set => SetValue(ProgressBorderBrushProperty, value);
        }

        //Property for the Value Write
        public static readonly DependencyProperty ValueWriteProperty = DependencyProperty.Register("ValueWrite", typeof(int), typeof(DoubleRoundProgressBar));

        public int ValueWrite {
            get => (int)GetValue(ValueWriteProperty);
            set => SetValue(ValueWriteProperty, value);
        }

        //Property for the Value Read
        public static readonly DependencyProperty ValueReadProperty = DependencyProperty.Register("ValueRead", typeof(int), typeof(DoubleRoundProgressBar));

        public int ValueRead {
            get => (int)GetValue(ValueReadProperty);
            set => SetValue(ValueReadProperty, value);
        }

        public DoubleRoundProgressBar() {
            InitializeComponent();
        }
    }
}
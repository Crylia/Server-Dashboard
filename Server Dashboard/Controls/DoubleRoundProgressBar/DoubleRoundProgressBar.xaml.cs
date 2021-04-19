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

namespace Server_Dashboard.Controls.DoubleRoundProgressBar {
    /// <summary>
    /// Interaktionslogik für HalfRoundProgressBar.xaml
    /// </summary>
    public partial class DoubleRoundProgressBar : UserControl {

        public static DependencyProperty ReadIndicatorBrushProperty = DependencyProperty.Register("ReadIndicatorBrush", typeof(Brush), typeof(DoubleRoundProgressBar));
        public Brush ReadIndicatorBrush {
            get { return (Brush)GetValue(ReadIndicatorBrushProperty); }
            set { SetValue(ReadIndicatorBrushProperty, value); }
        }

        public static DependencyProperty WriteIndicatorBrushProperty = DependencyProperty.Register("WriteIndicatorBrush", typeof(Brush), typeof(DoubleRoundProgressBar));
        public Brush WriteIndicatorBrush {
            get { return (Brush)GetValue(WriteIndicatorBrushProperty); }
            set { SetValue(WriteIndicatorBrushProperty, value); }
        }

        public static DependencyProperty BackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(DoubleRoundProgressBar));
        public Brush BackgroundBrush {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }

        public static DependencyProperty ProgressBorderBrushProperty = DependencyProperty.Register("ProgressBorderBrush", typeof(Brush), typeof(DoubleRoundProgressBar));
        public Brush ProgressBorderBrush {
            get { return (Brush)GetValue(ProgressBorderBrushProperty); }
            set { SetValue(ProgressBorderBrushProperty, value); }
        }

        public static DependencyProperty ValueWriteProperty = DependencyProperty.Register("ValueWrite", typeof(int), typeof(DoubleRoundProgressBar));
        public int ValueWrite {
            get { return (int)GetValue(ValueWriteProperty); }
            set { SetValue(ValueWriteProperty, value); }
        }
        public static DependencyProperty ValueReadProperty = DependencyProperty.Register("ValueRead", typeof(int), typeof(DoubleRoundProgressBar));
        public int ValueRead {
            get { return (int)GetValue(ValueReadProperty); }
            set { SetValue(ValueReadProperty, value); }
        }

        public DoubleRoundProgressBar() {
            InitializeComponent();
        }
    }
}

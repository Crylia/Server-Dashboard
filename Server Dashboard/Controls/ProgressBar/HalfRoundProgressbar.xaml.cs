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

namespace Server_Dashboard.Controls.ProgressBar {
    /// <summary>
    /// Interaktionslogik für HalfRoundProgressbar.xaml
    /// </summary>
    public partial class HalfRoundProgressbar : UserControl {
        public static readonly DependencyProperty IndicatorBrushProperty = DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(HalfRoundProgressbar));
        public Brush IndicatorBrush {
            get{
                return (Brush)this.GetValue(IndicatorBrushProperty);
            }
            set{
                this.SetValue(IndicatorBrushProperty, value);
            }
        }

        public static readonly DependencyProperty BackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(HalfRoundProgressbar));
        public Brush BackgroundBrush {
            get {
                return (Brush)this.GetValue(BackgroundBrushProperty);
            }
            set {
                this.SetValue(BackgroundBrushProperty, value);
            }
        }

        public static readonly DependencyProperty ProgressBorderBrushProperty = DependencyProperty.Register("ProgressBorderBrush", typeof(Brush), typeof(HalfRoundProgressbar));
        public Brush ProgressBorderBrush {
            get {
                return (Brush)this.GetValue(ProgressBorderBrushProperty);
            }
            set {
                this.SetValue(ProgressBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(HalfRoundProgressbar));
        public int Value {
            get {
                return (int)this.GetValue(ValueProperty);
            }
            set {
                this.SetValue(ValueProperty, value);
            }
        }

        public HalfRoundProgressbar() {
            InitializeComponent();
        }
    }

    [ValueConversion(typeof(int), typeof(double))]
    public class ValueToAngle : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (double)(((int)value * 0.01) * 360);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (int)((double)value / 360) * 100;
        }
    }
}

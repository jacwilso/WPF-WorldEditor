using System.Windows;
using System.Windows.Controls;

namespace WorldEditor.Util
{
    class ResizablePanel : ContentControl
    {
        public static readonly DependencyProperty BordersProperty = DependencyProperty.Register("Borders", typeof(Thickness), typeof(ResizablePanel), new PropertyMetadata(new Thickness(5)));
        public Thickness Borders
        {
            get;
            set;
            //get { return (Thickness)GetValue(BordersProperty); }
            //set { SetValue(BordersProperty, value); }
        }
        public static DependencyProperty ValProperty = DependencyProperty.Register("Val", typeof(string), typeof(ResizablePanel));
        public string val
        {
            get { return (string)GetValue(ValProperty); }
            set { SetValue(ValProperty, value); }
        }

        static ResizablePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizablePanel), new FrameworkPropertyMetadata(typeof(ResizablePanel)));
        }
    }
}

using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WorldEditor.Util
{
    class ResizablePanel : ContentControl
    {
        public static readonly DependencyProperty BordersProperty = DependencyProperty.Register("Borders", typeof(Thickness), typeof(ResizablePanel), new PropertyMetadata(new Thickness(5)));
        public Thickness Borders
        {
            get { return (Thickness)GetValue(BordersProperty); }
            set { SetValue(BordersProperty, value); }
        }

        static ResizablePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizablePanel), new FrameworkPropertyMetadata(typeof(ResizablePanel)));
        }
    }
}

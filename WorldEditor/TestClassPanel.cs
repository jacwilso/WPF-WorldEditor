using System.Windows;
using System.Windows.Controls;

namespace WorldEditor
{
    class TestClassPanel : ContentControl
    {
        static TestClassPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TestClassPanel), new FrameworkPropertyMetadata(typeof(TestClassPanel)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace WorldEditor
{
    class TestClass : Thumb
    {
        public static readonly DependencyProperty TestMeProperty = DependencyProperty.RegisterAttached("TestMe", typeof(string), typeof(TestClass));
        public string TestMe
        {
            get { return (string)GetValue(TestMeProperty); }
            set { SetValue(TestMeProperty, value); }
        }
    }
}

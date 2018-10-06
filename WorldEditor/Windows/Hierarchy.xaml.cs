using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorldEditor.Windows
{
    /// <summary>
    /// Interaction logic for Hierarchy.xaml
    /// </summary>
    public partial class Hierarchy : UserControl
    {
        public Hierarchy()
        {
            InitializeComponent();

            //GotFocus += (object sender, RoutedEventArgs e) => { Debug.Write("heirarchy got focus\n"); };
            //LostFocus += (object sender, RoutedEventArgs e) => { Debug.Write("heirarchy lost focus\n"); };
            //MouseEnter += (object sender, MouseEventArgs e) => { Debug.Write("mouse enter\n"); };
            //MouseLeave += (object sender, MouseEventArgs e) => { Debug.Write("mouse exit\n"); };
            MouseDown += (object sender, MouseButtonEventArgs e) => { Focus(); };
        }
    }
}

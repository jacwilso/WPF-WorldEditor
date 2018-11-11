using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class Console : UserControl
    {
        public Console() : base()
        {
            InitializeComponent();
        }

        // TODO(Jacob) DUPLICATE CODE
        public void AddLog(string line)
        {
            TextBox box = new TextBox
            {
                Background = new SolidColorBrush(Colors.Transparent),
                IsReadOnly = true,
                BorderThickness = new Thickness(0),
                Text = line,
            };
            box.GotFocus += Box_GotFocus;
            box.LostFocus += Box_LostFocus;
            Log.Children.Add(box);

        }

        // TODO(Jacob) DUPLICATE CODE
        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Background = new SolidColorBrush(Colors.Blue);
        }

        // TODO(Jacob) DUPLICATE CODE
        private void Box_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            Log.Children.Clear();
        }

        private void CommandKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            e.Handled = true;
            TextBox cmdBox = sender as TextBox;
            AddLog("Cmd: " + cmdBox.Text);
            cmdBox.Clear();
        }
    }
}

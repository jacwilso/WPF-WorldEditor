using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Inspector.xaml
    /// </summary>
    public partial class Inspector : UserControl
    {
        public Inspector()
        {
            InitializeComponent();
            Grid grid = new Grid();
            TabControl tab = new TabControl();
            TabItem tItem = new TabItem();
            tItem.Header = GetType().Name;
            tab.Items.Add(tItem);
            grid.Children.Add(tab);
        }

        private void TextBlock_DragEnter(object sender, DragEventArgs e)
        {
            Debug.Write("Drag");
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DropDown_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stack = ((Grid)((Button)sender).Parent).Parent as StackPanel;
            for (int i = 1; i < stack.Children.Count; i++) stack.Children[i].Visibility = (Visibility)(Visibility.Collapsed - stack.Children[1].Visibility);
        }
    }
}

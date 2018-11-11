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
        private DependencyObject gameObjectFocused = null;

        public Hierarchy()
        {
            InitializeComponent();

            //GotFocus += (object sender, RoutedEventArgs e) => { Debug.Write("heirarchy got focus\n"); };
            //LostFocus += (object sender, RoutedEventArgs e) => { Debug.Write("heirarchy lost focus\n"); };
            //MouseEnter += (object sender, MouseEventArgs e) => { Debug.Write("mouse enter\n"); };
            //MouseLeave += (object sender, MouseEventArgs e) => { Debug.Write("mouse exit\n"); };
            MouseDown += (object sender, MouseButtonEventArgs e) => { Focus(); };
        }

        private void CreateEmpty(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            HierarchyStack.Children.Add(AddGameObject());
            e.Handled = true;
        }

        private void CreateEmptyChild(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (gameObjectFocused != null)
            {
                StackPanel stack = gameObjectFocused as StackPanel;
                Button btn = ((StackPanel)stack.Children[0]).Children[0] as Button;
                btn.Visibility = Visibility.Visible;
                stack = stack.Children[1] as StackPanel;
                stack.Children.Add(AddGameObject());
            }
            else
            {
                CreateEmpty(sender, e);
            }
        }

        private StackPanel AddGameObject()
        {
            StackPanel stackObject = new StackPanel
            {
                Orientation = Orientation.Horizontal,
            };
            Button btn = new Button
            {
                Visibility = Visibility.Hidden,
                Content = ">",
                HorizontalAlignment = HorizontalAlignment.Left
            };
            btn.Click += Btn_Click;
            stackObject.Children.Add(btn);
            // TODO(Jacob) DUPLICATE CODE
            TextBox box = new TextBox
            {
                Background = new SolidColorBrush(Colors.Transparent),
                //IsReadOnly = true,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(10, 0, 0, 0),
                Text = "GameObject",
            };
            box.GotFocus += Box_GotFocus;
            box.LostFocus += Box_LostFocus;
            stackObject.Children.Add(box);

            StackPanel stackHolder = new StackPanel
            {
                Margin = new Thickness(15, 0, 0, 0),
            };
            stackHolder.Children.Add(stackObject);
            stackHolder.Children.Add(new StackPanel());
            return stackHolder;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            StackPanel stack = (StackPanel)(((StackPanel)(btn).Parent).Parent);
            stack.Children[1].Visibility = (Visibility)(Visibility.Collapsed - stack.Children[1].Visibility);
        }

        // TODO(Jacob) DUPLICATE CODE
        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            StackPanel stack = box.Parent as StackPanel;
            stack.Background = new SolidColorBrush(Colors.DodgerBlue);
            box.Foreground = new SolidColorBrush(Colors.White);
            gameObjectFocused = stack.Parent;
        }

        // TODO(Jacob) DUPLICATE CODE
        private void Box_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            StackPanel stack = box.Parent as StackPanel;
            stack.Background = new SolidColorBrush(Colors.LightGray);
            box.Foreground = new SolidColorBrush(Colors.Black);
            gameObjectFocused = null;
        }
    }
}

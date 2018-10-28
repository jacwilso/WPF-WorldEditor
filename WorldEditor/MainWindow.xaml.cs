using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace WorldEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DirectX.Renderer renderer = new DirectX.Renderer();
            Windows.Dockable console = new Windows.Dockable(new Windows.Console(), new Thickness(0, 5, 0, 0));
            Windows.Dockable hierarchy = new Windows.Dockable(new Windows.Hierarchy(), new Thickness(0, 0, 5, 0));
            Windows.Dockable inspector = new Windows.Dockable(new Windows.Inspector(), new Thickness(5, 0, 0, 0));
            Windows.Dockable project = new Windows.Dockable(new Windows.Project(), new Thickness(0, 0, 0, 5));
            //Windows.Scene scene = new Windows.Scene();

            CenterDock.Content = renderer; // TODO replace with Scene
            LeftDock.Content = hierarchy;
            LeftDock.MinWidth = hierarchy.MinWidth;
            LeftDock.MinHeight = hierarchy.MinHeight;
            RightDock.Content = inspector;
            LeftDock.MinWidth = inspector.MinWidth;
            LeftDock.MinHeight = inspector.MinHeight;
            BottomDock.Content = console;
            BottomDock.MinWidth = console.MinWidth;
            BottomDock.MinHeight = console.MinHeight;
            TopDock.Content = project;
            TopDock.MinWidth = project.MinWidth;
            TopDock.MinHeight = project.MinHeight;

            for (int i = 0; i < windowMenu.Items.Count; i++)
            {
                MenuItem item = windowMenu.Items[i] as MenuItem;
                item.InputGestureText = "Ctrl + " + i;
                item.Click += OpenWindow;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            string typeString = ((MenuItem)sender).Tag?.ToString() ?? ((MenuItem)sender).Header.ToString();
            typeString = "WorldEditor.Windows." + typeString;
            Type type = Type.GetType(typeString);
            UserControl control = System.Activator.CreateInstance(type) as UserControl;
            // TODO change to open window
            Windows.Dockable panel = new Windows.Dockable(control, new Thickness(0, 0, 5, 0))
            {
                Width = 110,
                MinWidth = 100,
            };
            DockPanel.SetDock(panel, Dock.Left);
            dockPanel.Children.Insert(0, panel);
        }
    }
}

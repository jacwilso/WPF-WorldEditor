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
            Windows.Console console = new Windows.Console();
            Windows.Hierarchy hierarchy = new Windows.Hierarchy();
            Windows.Inspector inspector = new Windows.Inspector();
            Windows.Project project = new Windows.Project();
            //Windows.Scene scene = new Windows.Scene();

            CenterDock.Content = renderer; // TODO replace with Scene
            LeftDock.Content = hierarchy;
            RightDock.Content = inspector;
            BottomDock.Content = console;
            TopDock.Content = project;

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
            Util.ResizablePanel panel = new Util.ResizablePanel
            {
                Width = 110,
                MinWidth = 100,
                Borders = new Thickness(0, 0, 5, 0),
                Content = control
            };
            DockPanel.SetDock(panel, Dock.Left);
            dockPanel.Children.Insert(0, panel);
        }
    }
}

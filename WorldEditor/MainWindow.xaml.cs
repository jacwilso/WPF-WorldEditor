using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            Windows.Scene scene = new Windows.Scene();

            CenterDock.Content = renderer;
            LeftDock.Content = hierarchy;
            RightDock.Content = inspector;
            BottomDock.Content = console;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }
    }
}

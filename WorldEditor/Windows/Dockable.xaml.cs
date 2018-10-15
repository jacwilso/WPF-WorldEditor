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
    /// Interaction logic for Dockable.xaml
    /// </summary>
    public partial class Dockable : UserControl
    {
        private Thickness gridThickness = new Thickness(5);
        public Thickness GridThickness
        {
            get { return gridThickness; }
            set { gridThickness = value; }
        }

        public Dockable(ContentControl content, Thickness gridThickness)
        {
            InitializeComponent();
            this.DataContext = this;
            this.gridThickness = gridThickness;
            if (gridThickness.Left > 0 || gridThickness.Right > 0)
            {
                this.Width = 100;
            }
            else
            {
                this.Width = Double.NaN;
            }
            if (gridThickness.Top > 0 || gridThickness.Bottom > 0)
            {
                this.Height = 100;
            }
            else
            {
                this.Height = Double.NaN;
            }
            AddTab(content);
        }

        private void AddTab(ContentControl content)
        {
            var test = Resources["ContextMenu"];
            ContextMenu menu = Resources["ContextMenu"] as ContextMenu;
            //ContextMenu menu = new ContextMenu();
            //MenuItem maximize = new MenuItem()
            //{
            //    Header = "Maximize"
            //};
            //maximize.MouseDown += MaximizeTab;
            //menu.Items.Add(maximize);
            //menu.Items.Add(new Separator());
            //MenuItem close = new MenuItem()
            //{
            //    Header = "Close Tab"
            //};
            //close.MouseDown += CloseTab;
            //menu.Items.Add(close);
            //MenuItem add = new MenuItem()
            //{
            //    Header = "Add Tab"
            //};
            //close.MouseDown += AddTab;
            //menu.Items.Add(add);
            TabItem item = new TabItem
            {
                Header = content.GetType().Name,
                Content = content,
                ContextMenu = menu
            };
            tabControl.Items.Add(item);
        }

        private void MaximizeTab(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CloseTab(object sender, RoutedEventArgs e)
        {
            var test = e.Source;
            MenuItem item = e.Source as MenuItem;
            TabItem tabItem = ((ContextMenu)item.Parent).PlacementTarget as TabItem;
            var tabCtrl = tabItem.Parent as TabControl;
            tabCtrl.Items.Remove(tabItem);
        }

        private void AddTab(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //https://stackoverflow.com/questions/2247402/implementing-a-multidock-window-system-like-blend-visual-studio-in-wpf
        public void OnDragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Hello");
            ContentWindow win = new ContentWindow();
            win.Content = this;
            win.Left = e.GetPosition(this).X;
            win.Top = e.GetPosition(this).Y;
        }

        private void TabItem_Drag(object sender, MouseEventArgs e)
        {
            var tabItem = e.Source as TabItem;

            if (tabItem == null)
                return;

            if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
        }

        private void TabItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            TabItem tabItem = e.Source as TabItem;

            if (tabItem == null)
                return;

            if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
            }
        }


        private void TabItem_Drop(object sender, DragEventArgs e)
        {
            var test = e.Source as UserControl;
            var par = test.Parent;
            if (e.Source is TabItem)
            {
                var tabTarget = e.Source as TabItem;
                var tabSrc = e.Data.GetData(typeof(TabItem)) as TabItem;
                if (!tabTarget.Equals(tabSrc))
                {
                    var tabCtrlTarget = tabTarget.Parent as TabControl;
                    int targetIdx = tabCtrlTarget.Items.IndexOf(tabTarget);

                    var tabCtrlSrc = tabSrc.Parent as TabControl;
                    int srcIdx = tabCtrlSrc.Items.IndexOf(tabSrc);
                    tabCtrlSrc.Items.Remove(tabSrc);

                    int idx = targetIdx;
                    if (targetIdx < srcIdx)
                    {
                        idx = Math.Max(targetIdx, 0);
                    }
                    tabCtrlTarget.Items.Insert(idx, tabSrc);
                    tabCtrlTarget.SelectedIndex = idx;
                }
            }
            else if (e.Source is UserControl && ((UserControl)e.Source).Parent is TabItem)
            {
                var tabCtrlTarget = ((e.Source as UserControl).Parent as TabItem).Parent as TabControl;
                var tabSrc = e.Data.GetData(typeof(TabItem)) as TabItem;
                var tabCtrlSrc = tabSrc.Parent as TabControl;
                tabCtrlSrc.Items.Remove(tabSrc);
                int tabIdx = tabCtrlTarget.Items.Add(tabSrc);
                tabCtrlTarget.Focus();
                tabCtrlTarget.SelectedIndex = tabIdx;
            }
        }
        private void TabControl_Drop(object sender, DragEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var tabCtrlTarget = e.Source as TabControl;
                var tabSrc = e.Data.GetData(typeof(TabItem)) as TabItem;
                var tabCtrlSrc = tabSrc.Parent as TabControl;
                tabCtrlSrc.Items.Remove(tabSrc);
                int tabIdx = tabCtrlTarget.Items.Add(tabSrc);
                tabCtrlTarget.Focus();
                tabCtrlTarget.SelectedIndex = tabIdx;
            }
        }
    }
}

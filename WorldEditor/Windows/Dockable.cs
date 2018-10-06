using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WorldEditor.Windows
{
    public abstract class Dockable : UserControl
    {
        private Thread thread = null;
        private ContentWindow application;

        public Dockable(Grid mainGrid)
        {
            TabControl tab = new TabControl();
            TabItem tItem = new TabItem();
            tItem.Header = GetType().Name;
            tab.Items.Add(tItem);
            mainGrid.Children.Add(tab);

            tItem.DragEnter += OnDragEnter;

            //this.MouseEnter += MouseEnterCallback;
        }


        private void MouseEnterCallback(object sender, MouseEventArgs e)
        {

        }
        public void MouseLeaveCallback(object sender, MouseEventArgs e) { }

        //https://stackoverflow.com/questions/2247402/implementing-a-multidock-window-system-like-blend-visual-studio-in-wpf
        public void OnDragEnter(object sender, DragEventArgs e)
        {
            ContentWindow win = new ContentWindow();
            win.Content = this;
            win.Left = e.GetPosition(this).X;
            win.Top = e.GetPosition(this).Y;
        }
        //public void OnDragExit() { }
        //public void OnDragLeave() { }
        //public void OnDragDrop() { }
    }
}

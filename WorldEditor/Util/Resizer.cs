using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WorldEditor.Util
{
    class Resizer : Thumb
    {
        public static DependencyProperty ThumbDirectionProperty = DependencyProperty.Register("ThumbDirection", typeof(ResizeDirection), typeof(Resizer));

        public ResizeDirection ThumbDirection
        {
            get { return (ResizeDirection)GetValue(ThumbDirectionProperty); }
            set { SetValue(Resizer.ThumbDirectionProperty, value); }
        }

        static Resizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Resizer), new FrameworkPropertyMetadata(typeof(Resizer)));
        }

        public Resizer()
        {
            DragDelta += new DragDeltaEventHandler(DragDeltaCallback);
        }

        private void DragDeltaCallback(object sender, DragDeltaEventArgs e)
        {
            Control item = this.DataContext as Control;

            if (item != null)
            {
                double deltaX = 0, deltaY = 0;
                int x = 0, y = 0;
                if (ThumbDirection.HasFlag(ResizeDirection.Top))
                {
                    deltaY += ResizeTop(item, e);
                    y++;
                }
                if (ThumbDirection.HasFlag(ResizeDirection.Bottom))
                {
                    deltaY += ResizeBottom(item, e);
                    y++;
                }
                if (ThumbDirection.HasFlag(ResizeDirection.Left))
                {
                    deltaX += ResizeLeft(item, e);
                    x++;
                }
                if (ThumbDirection.HasFlag(ResizeDirection.Right))
                {
                    deltaX += ResizeRight(item, e);
                    x++;
                }
                deltaX /= x;
                deltaY /= y;
                e.Handled = true;
            }
        }

        private static double ResizeTop(Control item, DragDeltaEventArgs e)
        {
            double deltaY = Math.Min(e.VerticalChange, item.ActualHeight - item.MinHeight);
            Canvas.SetTop(item, Canvas.GetTop(item) + deltaY);
            item.Height -= deltaY;
            return deltaY;
        }
        private static double ResizeBottom(Control item, DragDeltaEventArgs e)
        {
            double deltaY = Math.Min(-e.VerticalChange, item.ActualHeight - item.MinHeight);
            item.Height -= deltaY;
            return deltaY;
        }
        private static double ResizeLeft(Control item, DragDeltaEventArgs e)
        {
            double deltaX = Math.Min(e.HorizontalChange, item.ActualWidth - item.MinWidth);
            Canvas.SetTop(item, Canvas.GetLeft(item) + deltaX);
            item.Width -= deltaX;
            return deltaX;
        }
        private static double ResizeRight(Control item, DragDeltaEventArgs e)
        {
            double deltaX = Math.Min(-e.HorizontalChange, item.ActualWidth - item.MinWidth);
            item.Width -= deltaX;
            return deltaX;
        }

    }

    [Flags]
    public enum ResizeDirection
    {
        Top = 1 << 0,
        Bottom = 1 << 1,
        Right = 1 << 2,
        Left = 1 << 3,
        TopLeft = Top | Left,
        TopRight = Top | Right,
        BottomLeft = Bottom | Left,
        BottomRight = Bottom | Right,
        Center = Top | Bottom | Left | Right
    }
}

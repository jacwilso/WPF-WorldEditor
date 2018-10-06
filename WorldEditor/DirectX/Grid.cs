using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Drawing;

namespace WorldEditor.DirectX
{
    class Grid
    {
        public Grid(Model3DGroup group)
        {
            const int dist = 10;
            const int resolution = 10;
            const int half = (int)(0.5 * resolution);
            for (int i = 0; i < resolution; i++)
            {
                group.Children.Add(LineGeometry3D.DrawLine(new Point3D(-dist, 0, i - half), new Point3D(dist, 0, i - half)));
                group.Children.Add(LineGeometry3D.DrawLine(new Point3D(i - half, 0, -dist), new Point3D(i - half, 0, dist)));
            }
        }
    }
}

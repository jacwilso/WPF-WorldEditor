using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WorldEditor.DirectX
{
    class LineGeometry3D
    {
        public static GeometryModel3D DrawLine(Point3D start, Point3D end)
        {
            const double thickness = 0.02;
            Vector3D to = end - start;
            Vector3D n1 = 0.5 * thickness * new Vector3D(0, 1, 0);
            Vector3D n2 = 0.5 * thickness * Vector3D.CrossProduct(to, n1);

            GeometryModel3D geometryModel = new GeometryModel3D();
            MeshGeometry3D mesh = new MeshGeometry3D();

            mesh.Positions = new Point3DCollection{
                start + n1 + n2,
                start + n1 - n2,
                start - n1 + n2,
                start - n1 - n2,
                end + n1 + n2,
                end + n1 - n2,
                end - n1 + n2,
                end - n1 - n2
            };

            mesh.TriangleIndices = new Int32Collection
            {
                0,2,6,
                0,6,4,
                0,4,5,
                0,5,1,
                1,5,7,
                1,7,3,
                3,7,6,
                3,6,2,
                0,1,3,
                0,3,2,
                4,6,7,
                4,7,5
            };

            geometryModel.Geometry = mesh;
            geometryModel.Material = new DiffuseMaterial(new SolidColorBrush(Colors.LightGray));
            return geometryModel;
        }
    }
}

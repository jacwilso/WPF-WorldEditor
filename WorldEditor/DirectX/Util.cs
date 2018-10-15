using System.Windows.Media.Media3D;

namespace WorldEditor.DirectX
{
    class Util
    {
        public static Vector3D Scale(Vector3D a, Vector3D b)
        {
            a.X *= b.X;
            a.Y *= b.Y;
            a.Z *= b.Z;
            return a;
        }
    }
}

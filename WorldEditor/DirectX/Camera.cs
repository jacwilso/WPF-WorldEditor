using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace WorldEditor.DirectX
{
    class Camera
    {
        PerspectiveCamera cam;

        static Vector3D one = new Vector3D(1, 1, 1),
            right = new Vector3D(1, 0, 0),
            up = new Vector3D(0, 1, 0),
            forward = new Vector3D(0, 0, 1);

        public Camera(Viewport3D viewport)
        {
            // Defines the camera used to view the 3D object. In order to view the 3D object,
            // the camera must be positioned and pointed such that the object is within view 
            // of the camera.
            cam = new PerspectiveCamera();
            // Specify where in the 3D scene the camera is.
            cam.Position = new Point3D(0, 2, 4);
            // Specify the direction that the camera is pointing.
            cam.LookDirection = new Vector3D(0, 0, -1);
            // Define camera's horizontal field of view in degrees.
            cam.FieldOfView = 60;
            // Asign the camera to the viewport
            viewport.Camera = cam;
        }

        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                cam.Position += cam.LookDirection;
            }
            if (e.Key == Key.S)
            {
                cam.Position -= cam.LookDirection;
            }
            if (e.Key == Key.D)
            {
                cam.Position += Vector3D.CrossProduct(cam.LookDirection, cam.UpDirection);
            }
            if (e.Key == Key.A)
            {
                cam.Position -= Vector3D.CrossProduct(cam.LookDirection, cam.UpDirection);
            }
            if (e.Key == Key.Q)
            {
                cam.Position += cam.UpDirection;
            }
            if (e.Key == Key.E)
            {
                cam.Position -= cam.UpDirection;
            }
        }
        private void OnKeyUpHandler(object sender, KeyEventArgs e)
        {

        }
    }
}

using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using System;
using System.Diagnostics;

namespace WorldEditor.DirectX
{
    class Camera
    {
        private PerspectiveCamera cam;
        private DispatcherTimer[] keyTimer = new DispatcherTimer[6];
        private double speed = .2;
        private Point3D[] cameraMarkers = new Point3D[10];

        public static Vector3D one = new Vector3D(1, 1, 1),
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

            for (int i = 0; i < 6; i++)
            {
                Vector3D direction;
                switch (i)
                {
                    case 0:
                        direction = cam.LookDirection;
                        break;
                    case 1:
                        direction = -cam.LookDirection;
                        break;
                    case 2:
                        direction = Vector3D.CrossProduct(cam.LookDirection, cam.UpDirection);
                        break;
                    case 3:
                        direction = -Vector3D.CrossProduct(cam.LookDirection, cam.UpDirection);
                        break;
                    case 4:
                        direction = cam.UpDirection;
                        break;
                    case 5:
                        direction = -cam.UpDirection;
                        break;
                    default:
                        direction = new Vector3D();
                        break;
                }
                keyTimer[i] = new DispatcherTimer(DispatcherPriority.Normal);
                keyTimer[i].Tick += new EventHandler((object sender, EventArgs e) =>
                {
                    cam.Position += direction * speed;
                });
                keyTimer[i].Interval = TimeSpan.FromMilliseconds(1);
            }
        }

        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            // Movement
            if (e.Key == Key.W)
            {
                keyTimer[0].Start();
            }
            if (e.Key == Key.S)
            {
                keyTimer[1].Start();
            }
            if (e.Key == Key.D)
            {
                keyTimer[2].Start();
            }
            if (e.Key == Key.A)
            {
                keyTimer[3].Start();
            }
            if (e.Key == Key.Q)
            {
                keyTimer[4].Start();
            }
            if (e.Key == Key.E)
            {
                keyTimer[5].Start();
            }

            // Camera Markers
            if (Keyboard.IsKeyDown(Key.C) && Key.D0 <= e.Key && e.Key <= Key.D9)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift))
                {
                    cameraMarkers[e.Key - Key.D0] = cam.Position;
                }
                else
                {
                    cam.Position = cameraMarkers[e.Key - Key.D0];
                }
            }
        }
        public void OnKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                keyTimer[0].Stop();
            }
            if (e.Key == Key.S)
            {
                keyTimer[1].Stop();
            }
            if (e.Key == Key.D)
            {
                keyTimer[2].Stop();
            }
            if (e.Key == Key.A)
            {
                keyTimer[3].Stop();
            }
            if (e.Key == Key.Q)
            {
                keyTimer[4].Stop();
            }
            if (e.Key == Key.E)
            {
                keyTimer[5].Stop();
            }
        }
    }
}

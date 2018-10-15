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
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class Console : UserControl
    {
        public Console() : base()
        {
            InitializeComponent();
            //Debug.WriteLine("type: " + Type.GetType("Console"));
            //Type t = GetType();
            //Debug.WriteLine("Name: {0}", (object)t.Name);
            //Debug.WriteLine("Full Name: {0}", (object)t.FullName);
            //Debug.WriteLine("ToString:  {0}", (object)t.ToString());
            //Debug.WriteLine("Assembly Qualified Name: {0}",
            //                  (object)t.AssemblyQualifiedName);
            //Debug.WriteLine("");
        }
    }
}

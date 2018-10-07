using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorldEditor.Util
{
    class General
    {
        public static IEnumerable<C> GetChildItems<C, P>(P parent) where P : ItemsControl where C : class
        {
            System.Diagnostics.Debug.Assert(parent.ItemContainerGenerator.Status ==
                System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated);

            int cnt = parent.Items.Count;
            for (int idx = 0; idx < cnt; ++idx)
            {
                yield return parent.ItemContainerGenerator.ContainerFromIndex(idx) as C;
            }
        }
    }
}

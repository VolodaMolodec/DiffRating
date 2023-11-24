using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.GraphsThing
{
    public partial class GraphsForm : Form
    {
        class Vertex
        {
            int value;
            Vertex lefVert;
            Vertex rightVert;
        }
        class Heap
        {
            private Vertex topVert;

            public Vertex getTop()
            {
                Vertex retVert = topVert;
            }
        }
    }
}

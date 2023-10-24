using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.GraphsThing
{
    public partial class GraphsForm : Form
    {
        class Graph_Arrays
        {
            class Vertex
            {
                public List<Edge> edges = new List<Edge>();
            }
            class Edge
            {
                public Vertex vertex1;
                public Vertex vertex2;
            }

            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();
            public void Set(Graph_Table graph)
            {
                for(int i = 0; i < graph.table.Count; i++)
                {
                    Vertex vert = new Vertex();
                    vertices.Add(vert);
                    for (int j = 0; j <= i; j++)
                    {
                        if (graph.table[i][j] != 0)
                        {
                            Edge newEdge = new Edge();
                            newEdge.vertex1 = vert;
                            newEdge.vertex2 = vertices[j];
                            vert.edges.Add(newEdge);
                            edges.Add(newEdge);
                        }
                    }
                }     
            }
        }

        class Graph_Table
        {
            public Graph_Table(List<List<int>> table)
            {
                this.table = table;
            }
            public List<List<int>> table;
        }

        class Graph_List
        {
            List<List<int>> lists = new List<List<int>>();
            public void Set(Graph_Table graph)
            {
                foreach(var iter in graph.table)
                {
                    lists.Add(iter);
                }
            }
        }
    }
}

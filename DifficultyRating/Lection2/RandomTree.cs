using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.Lection2
{
    public partial class Lection2 : Form
    {
        class RandomTree
        {
            class Node
            {
                List<Node> nodes;
                int depth;
                public int buildNode(int depth, int coefficient)
                {
                    nodes = new List<Node>();
                    this.depth = depth;
                    int number = 1;
                    if (depth > 1)
                    {
                        for (int i = 0; i < coefficient; i++)
                        {
                            nodes.Add(new Node());
                            number += nodes[i].buildNode(depth - 1, coefficient);
                        }   
                    }
                    return number;
                }
            }
            public int elements;
            Node root;

            public int buildTree(int depth, int coefficient)
            {
                root = new Node();
                elements = 1 + root.buildNode(depth, coefficient);
                return elements;
            }
        }
    }
}

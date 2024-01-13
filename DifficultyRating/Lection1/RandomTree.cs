using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifficultyRating.Lection1
{
    static class RandomTree
    {
        class Node
        {
            List<Node> nodes;
            int depth;
            public int buildNode(int depth, int coefficient)
            {
                diff.operationsCount++;
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
        static public int elements;
        static Node root;
        static DifficulityRate diff;
        static Stopwatch watch = new Stopwatch();

        static public Tuple<int,DifficulityRate> buildTree(int depth, int coefficient)
        {
            diff = new DifficulityRate();
            watch.Restart();
            root = new Node();
            elements = 1 + root.buildNode(depth, coefficient);
            diff.operationsCount++;

            watch.Stop();
            diff.totalTime = watch.ElapsedTicks;
            return new Tuple<int,DifficulityRate>(elements, diff);
        }
    }
}

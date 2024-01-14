using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating
{
    static class BinaryTree
    {
        static DifficulityRate diff;
        static Node root;
        static Random rnd = new Random();
        static Stopwatch watch = new Stopwatch();
        class Node
        {
            public int value;
            public Node leftNode;
            public Node rightNode;

        }

        static public DifficulityRate Build(List<int> arr)
        {
            
            diff = new DifficulityRate();
            watch.Restart();

            root = buildNode(arr);

            watch.Stop();
            diff.totalTime = watch.ElapsedTicks;
            return diff;
        }

        static public Tuple<bool,DifficulityRate> Find(int val)
        {
            diff = new DifficulityRate();
            watch.Restart();

            bool flag = findVal(val, root);

            watch.Stop();
            diff.totalTime = watch.ElapsedTicks;
            return new Tuple<bool,DifficulityRate>(flag, diff);
        }

        static public Tuple<int, DifficulityRate> Depth()
        {
            diff = new DifficulityRate();
            watch.Restart();

            int depth = getDepth(root);

            watch.Stop();
            diff.totalTime = watch.ElapsedTicks;
            return new Tuple<int, DifficulityRate>(depth, diff);
        }

        static private Node buildNode(List<int> array)  //Построение дерева
        {
            if (array.Count == 0)
                return new Node { value = 0 };
            if (array.Count == 1)
                return new Node { value = array[0] };
            Node node = new Node();
            int index = array.Count() / 2;
            node.value = array[index];
            List<int> leftArr = new List<int>();
            List<int> rightArr = new List<int>();
            for (int i = 0; i < array.Count; i++)
            {
                diff.operationsCount++;
                if (i == index)
                    continue;
                else if (array[i] > array[index])
                    rightArr.Add(array[i]);
                else
                    leftArr.Add(array[i]);
            }
            node.leftNode = buildNode(leftArr);
            node.rightNode = buildNode(rightArr);
            return node;
        }

        static private bool findVal(int value, Node node)
        {
            if (node == null)
                return false;
            if (value == node.value)
                return true;
            diff.operationsCount++;
            if (node.value >= value)
                return findVal(value, node.leftNode);
            else
                return findVal(value, node.rightNode);
        }

        static private int getDepth(Node node)
        {
            diff.operationsCount++;
            int depth = 1, leftDepth = 1, rightDepth = 1;
            if (node.leftNode != null)
                leftDepth = getDepth(node.leftNode);
            if (node.rightNode != null)
                rightDepth = getDepth(node.rightNode);
            return Math.Max(depth, Math.Max(leftDepth, rightDepth));
        }
    }

    //Написал тут ещё класс для дерева со случайным коэффициентов ветвления
    static class CoefficientTree
    {
        class Node
        {
            List<Node> children;
        }
    }
}

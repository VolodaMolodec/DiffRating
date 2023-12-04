using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating
{
    public partial class Algorithms : Form
    {
        
        class BinaryTree
        {
            DifficulityRate diff;
            Node root;
            Random rnd = new Random();
            class Node
            {
                public int value;
                public Node leftNode;
                public Node rightNode;

            }
            public DifficulityRate buildTreeAndGetDiff(int N)
            {
                List<int> array = new List<int>();
                for(int i = 0; i  <N; i++)
                    array.Add(rnd.Next() % 100);
                diff = new DifficulityRate();
                root = buildNode(array);
                return diff;
            }
            private Node buildNode(List<int> array)  //Построение дерева
            {
                if (array.Count <= 1)
                    return new Node { value = 0 };
                Node node = new Node();
                int index = rnd.Next() % array.Count();
                node.value = array[index];
                List<int> leftArr = new List<int>();
                List<int> rightArr = new List<int>();
                for (int i = 0; i < array.Count; i++)
                {
                    diff.operationsCount++;
                    if (i == index)
                        continue;
                    else if (array[i] >= array[index])
                        leftArr.Add(array[i]);
                    else
                        rightArr.Add(array[i]);
                }
                node.leftNode = buildNode(leftArr);
                node.rightNode = buildNode(rightArr);
                return node;
            }
            public DifficulityRate findAndGetDiff(int value)
            {
                diff = new DifficulityRate();
                findVal(value, root);
                return diff;
            }

            private bool findVal(int value, Node node)
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
            public DifficulityRate getDepthDiff()
            {
                diff = new DifficulityRate();
                getDepth(root);
                return diff;
            }

            private int getDepth(Node node)
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
    }
}

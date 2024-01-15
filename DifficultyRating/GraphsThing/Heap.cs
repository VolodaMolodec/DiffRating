using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.GraphsThing
{
    class Heap
    {
        class Node
        {
            public int value;   //Возвращаемое значение
            public int sortValue;   //Значение, по которому происходит сортировка внутри кучи
            public Node leftNode;
            public Node rightNode;
            public Node()
            {
                value = -1;
                sortValue = -1;
                leftNode = null;
                rightNode = null;
            }
            public void Init(int val, int priority)
            {
                value = val;
                sortValue = priority;
                leftNode = new Node();
                rightNode = new Node();
            }
            public bool DeepSearch(int val)
            {
                if (value == -1)
                    return false;
                else if (value == val)
                    return true;
                else if (leftNode.DeepSearch(val) || rightNode.DeepSearch(val))
                    return true;
                else
                    return false;
            }
        }

        private Node topVert = new Node();

        public int GetTop()
        {
            if (topVert.value == -1)
                return -1;
            int res = topVert.value;
            topVert.value = -1;
            topVert.sortValue = -1;
            Node currVert = topVert;
            while(true)
            {
                if(currVert.leftNode.sortValue == -1 && currVert.sortValue == -1)  //Если мы дошли до конца ветки, то выходим
                {
                    currVert.leftNode = null;
                    currVert.rightNode = null;
                    break;
                }
                else
                {
                    Node nextVert = null; //Выбираем следующую вершину для перемещения основываясь
                    if (currVert.leftNode.sortValue > currVert.rightNode.sortValue)//На более большом значении
                        nextVert = currVert.leftNode;
                    else
                        nextVert = currVert.rightNode;
                    currVert.value = nextVert.value;
                    currVert.sortValue = nextVert.sortValue;
                    nextVert.value = -1;
                    nextVert.sortValue = -1;
                    currVert = nextVert;
                }
            }
            return res;
        }

        public DifficulityRate Add(int val, int priority)    //Добавление значения в кучу
        {
            DifficulityRate diff = new DifficulityRate();
            List<Node> queue = new List<Node>   
            {
                topVert
            };
            while(queue.Count != 0)
            {
                diff.operationsCount++;
                Node currVert = queue[0];
                if (currVert.sortValue == -1)
                {
                    currVert.Init(val, priority);
                    break;
                }
                else if(currVert.sortValue < priority) 
                {
                    Node newVert = new Node();  //Неемножно сложная схема из-за C#. Если кратко, то создаём новый участок памяти, передаём ему все значения текущей области памяти
                    newVert.Init(currVert.value, currVert.sortValue);   //А текущей области памяти передаём новые значения
                    newVert.leftNode = currVert.leftNode;
                    newVert.rightNode = currVert.rightNode;
                    currVert.leftNode = newVert;
                    currVert.rightNode = new Node();
                    currVert.value = val;
                    currVert.sortValue = priority;
                    break;
                }
                else
                {
                    queue.Add(currVert.leftNode);
                    queue.Add(currVert.rightNode);
                }
                queue.RemoveAt(0);      
            }
            return diff;
        }
        public bool IsEmpty()
        {
            if (topVert.value != -1)
                return false;
            return true;
        }
        public bool Contains(int value)
        {
            if (IsEmpty())
                return true;
            else
                return topVert.DeepSearch(value);
        }
    }
}
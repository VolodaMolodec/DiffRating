using DifficultyRating.GraphsThing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating
{
    //Куча
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
            public Node(int val, int priority)
            {
                Init(val, priority);
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
            while (true)
            {
                if (currVert.leftNode.sortValue == -1 && currVert.sortValue == -1)  //Если мы дошли до конца ветки, то выходим
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

        public DifficulityRate Add(int val)
        {
            return Add(val, val);
        }

        public DifficulityRate Add(int val, int priority)    //Добавление значения в кучу
        {
            DifficulityRate diff = new DifficulityRate();
            List<Node> queue = new List<Node>
            {
                topVert
            };
            while (queue.Count != 0)
            {
                diff.operationsCount++;
                Node currVert = queue[0];
                if (currVert.sortValue == -1)
                {
                    currVert.Init(val, priority);
                    break;
                }
                else if (currVert.sortValue < priority)
                {
                    Node newVert = new Node(currVert.value, currVert.sortValue);  //Неемножно сложная схема из-за C#. Если кратко, то создаём новый участок памяти, передаём ему все значения текущей области памяти
                                                                                  //А текущей области памяти передаём новые значения
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

    //Двусвязный список
    class DoubleList
    {
        class Node
        {
            public Node(int id, int value, Node prevNode = null)
            {
                this.id = id;
                this.value = value;
                this.prevNode = prevNode;
            }
            public int id;
            public int value;
            public Node nextNode;
            public Node prevNode;
        }

        public int size;
        private Node startNode;

        public DoubleList()
        {
            size = 0;
            startNode = null;
        }
        public void Add(int input)
        {
            if (startNode == null)
                startNode = new Node(0, input);
            else
            {
                var currNode = startNode;
                while (currNode.nextNode != null)
                    currNode = currNode.nextNode;
                currNode.nextNode = new Node(size, input, currNode);
            }
            size++;
        }
        public int Get(int index)
        {
            int res = 0;
            if (index > size - 1 || index < 0)
                throw new IndexOutOfRangeException("Индекс за гранцей двусвязного списка");
            else
            {
                var currNode = startNode;
                for (int i = 0; i < index; i++)
                    currNode = currNode.nextNode;
                res = currNode.value;
                if (currNode == startNode)   //Если это первый элемент, то заменяем его
                {
                    if (startNode.nextNode == null)
                        startNode = null;
                    else
                    {
                        startNode = startNode.nextNode;
                        startNode.prevNode = null;
                    }
                }
                else if (currNode.nextNode == null) //Если следующего элемента нет, то спокойно удаляем ссылку
                {
                    currNode = currNode.prevNode;
                    currNode.nextNode = null;
                }
                else
                {
                    Node nextNodePointer = currNode.nextNode;
                    Node prevNodePointer = currNode.prevNode;
                    nextNodePointer.prevNode = prevNodePointer;
                    prevNodePointer.nextNode = nextNodePointer;
                }
            }
            size--;
            return res;
        }
    }

    //Очередь
    class Queue 
    {
        public Queue(object input)
        {
            data = input;
            size = 0;
        }
        private object data;
        private int size;

        public void Add(int input)
        {
            if (data is int[])  //Если данные представлены как статический массив, то делаем это
            {
                int[] list = data as int[];
                if (size >= list.Count())
                    throw new Exception("В массиве максимальное кол-во чисел.");
                int i = 0;
                while (list[i] != 0)
                    i++;
                list[i] = input;
                size++;
            }
            else if (data is DoubleList)
            {
                DoubleList list = data as DoubleList;
                list.Add(input);
                size++;
            }
        }

        public int Get()
        {
            int res = 0;
            if (data is int[])
            {
                int[] list = data as int[];
                int i = 0;
                res = list[0];
                while (i - 1 < list.Count() && list[i] != 0)
                {
                    list[i] = list[i + 1];
                    i++;
                }
                list[i] = 0;
                size--;
            }
            else if (data is DoubleList)
            {
                DoubleList list = data as DoubleList;
                res = list.Get(0);
                size--;
            }
            return res;
        }
    }

    //Стек
    class Stack
    {
        public Stack(object input)
        {
            data = input;
            size = 0;
        }
        private object data;
        private int size;

        public void Add(int input)
        {
            if (data is int[])  //Если данные представлены как статический массив, то делаем это
            {
                int[] list = data as int[];
                if (size >= list.Count())
                    throw new Exception("В массиве максимальное кол-во чисел.");
                int i = 0;
                while (list[i] != 0)
                    i++;
                list[i] = input;
                size++;
            }
            else if (data is DoubleList)
            {
                DoubleList list = data as DoubleList;
                list.Add(input);
                size++;
            }
        }

        public int Get()
        {
            int res = 0;
            if (data is int[])
            {
                int[] list = data as int[];
                res = list[size - 1];
                list[size - 1] = 0;
                size--;
            }
            else if (data is DoubleList)
            {
                DoubleList list = data as DoubleList;
                res = list.Get(list.size - 1);
                size--;
            }
            return res;
        }
    }

    //Система непересекающихся множеств
    class UnconnectedArrays
    {
        private class Node
        {
            public Node parent;
            public int id;
            public int rang;
            public Node(int id, Node parent = null)
            {
                this.id = id;
                rang = 0;
                if (parent == null)
                    this.parent = this;
                else
                    this.parent = parent;
            }
        }

        List<Node> nodes;

        public UnconnectedArrays(int N)
        {
            nodes = new List<Node>();
            for (int i = 0; i < N; i++)
                nodes.Add(new Node(i + 1));
        }

        private Node Find(int id)
        {
            foreach(Node node in nodes)
            {
                if (node.id == id)
                {
                    Node result = node;
                    while (result.parent != result)
                        result = result.parent;
                    return result;
                }
            }
            return null;
        }

        public bool Union(int idA, int idB)
        {
            //Ищем два родителя нод с idA и idB
            Node parentA = Find(idA);
            Node parentB = Find(idB);
            //Есди родители есть и они не равны друг другу, то объединяем
            if (parentB != parentA && parentA != null && parentB != null)
            {
                if (parentA.rang > parentB.rang)
                    parentB.parent = parentA;
                else if (parentB.rang > parentA.rang)
                    parentA.parent = parentB;
                else
                {
                    parentB.parent = parentA;
                    parentA.rang = parentB.rang + 1;
                }
                return true;
            }
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifficultyRating.Lection1
{
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
                for(int i = 0; i < index; i++)
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

    class Queue //Орчередбь
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
    class Stack //Класс стека для статческого массива и двусвязного списка
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
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DifficultyRating.GraphsThing
{
    public partial class GraphsForm : Form
    {
        class WeightGraph
        {
            private class Vertex
            {
                public List<Edge> edges = new List<Edge>();
                public bool isVisited = false;
                public int id;
                public string minPath = "";  //Хранит минимальный путь до вершины
                public int minPathVal = -1;  //Вес минимального пути
                public int priority = 0;    //Приоритет в PriorityQueue
            }
            private class Edge
            {
                public int value;
                public Vertex vertex1;
                public Vertex vertex2;

                public Edge Reverse()   //Возвращает перевёрнутую грань. Нужно для облегчения кода в дальнейшем
                {
                    Edge reverseEdge = new Edge();
                    reverseEdge.value = value;
                    reverseEdge.vertex1 = vertex2;
                    reverseEdge.vertex2 = vertex1;
                    return reverseEdge;
                }
            }

            public WeightGraph()
            {
                vertices = new List<Vertex>();
            }
            public WeightGraph(List<List<int>> table)   //Инициализация взвешенного графа через таблицу
            {
                vertices = new List<Vertex>();
                for (int y = 0; y < table.Count; y++)   //Проходим по таблице
                {
                    vertices.Add(new Vertex());
                    var newVert = vertices[y];
                    newVert.id = y + 1;
                    for (int x = 0; x < y; x++)
                    {
                        Edge edge = new Edge();
                        edge.vertex1 = newVert;
                        edge.vertex2 = vertices[x];
                        edge.value = Math.Abs(table[y][x]);
                        newVert.edges.Add(edge);
                        vertices[x].edges.Add(edge.Reverse());
                    }
                    foreach(Edge edge in newVert.edges)
                        newVert.priority += edge.value;
                    newVert.priority /= newVert.edges.Count;
                }
            }

            private List<Vertex> vertices;

            public void Generate(int N) //Генерация графа с заданным количеством вершин
            {
                vertices = new List<Vertex>();

                Random rnd = new Random();
                for (int i = 0; i < N; i++)
                {
                    Vertex newVert = new Vertex();
                    for (int j = 0; j < vertices.Count; j++)
                    {
                        Edge edge = new Edge();
                        edge.value = rnd.Next(1, 10);  //Генерируем вес ребра
                        edge.vertex1 = newVert;
                        edge.vertex2 = vertices[j];
                        newVert.edges.Add(edge);
                        vertices[j].edges.Add(edge.Reverse());
                    }
                    newVert.id = vertices.Count + 1;
                    vertices.Add(newVert);
                }
            }

            public List<List<int>> GetTable()   //Возвращает таблицу, представляющую граф
            {
                List<List<int>> table = new List<List<int>>();
                for (int y = 0; y < vertices.Count; y++)
                {
                    table.Add(new List<int>());
                    Vertex currVert = vertices[y];
                    for (int x = 0; x < currVert.edges.Count; x++)
                    {
                        if (x == y)
                            table[y].Add(0);
                        int val = currVert.edges[x].value;
                        table[y].Add(val);
                    }
                }
                table[table.Count - 1].Add(0);  //Нужно, чтобы прога не сломалась
                return table;
            }


            public Tuple<string, DifficulityRate> Search(string searchName)   //Функция для выбора алгоритма
            {
                var result = new Tuple<string, DifficulityRate>("", new DifficulityRate());  //Возвращаемое значение
                Stopwatch watch = new Stopwatch();
                Random rnd = new Random();
                Vertex goalVert = vertices[vertices.Count - 1];
                foreach (var vertex in vertices)    //Обнуляем данные о посещении
                    vertex.isVisited = false;
                watch.Start();

                switch(searchName)
                {
                    case "TreeMin":     //Дерево минимальных расстояний
                        result = TreeMin();
                        break;
                    case "Dijkstra":
                        result = Dijkstra(goalVert);
                        break;
                }

                watch.Stop();
                result.Item2.totalTime = watch.ElapsedTicks;    //Добавляем время, затраченное на выполнение алгоритмма, в результат
                return result;
            }

            private Tuple<string, DifficulityRate> TreeMin() //Поиск дерева минимальных расстояний с помощью поиска в ширину
            {
                var diff = new DifficulityRate();
                int sum = 0;
                List<Vertex> queue = new List<Vertex>   //Создаём очередь и добавляем в неё начальную вершину
                {
                    vertices[0]
                };

                while (queue.Count != 0)
                {
                    diff.operationsCount++;
                    var currVert = queue[0];
                    queue.RemoveAt(0);
                    currVert.isVisited = true;
                    int sumToAdd = -1;           //Хранит кратчайшее расстояние из текущей вершины

                    foreach(var edge in currVert.edges)
                    {
                        diff.operationsCount++;
                        if (!edge.vertex2.isVisited)   //Добавляем те вершины, в которые мы ещё не зашли
                        {
                            if(!queue.Contains(edge.vertex2))
                                queue.Add(edge.vertex2);
                            if (sumToAdd > edge.value || sumToAdd == -1)  //Если мы не заходили в вершину, то сравниваем вес ребра с найденным минимальным весом
                                sumToAdd = edge.value;
                        }
                        
                    }
                    if (sumToAdd != -1)
                        sum += sumToAdd;
                }
                return new Tuple<string, DifficulityRate>(sum.ToString(), diff);
            }

            private Tuple<string, DifficulityRate> Dijkstra(Vertex goalVert)
            {
                var diff = new DifficulityRate();
                string path = "";
                List<Vertex> queue = new List<Vertex>   //Создаём очередь и добавляем в неё начальную вершину
                {
                    vertices[0]
                };
                vertices[0].minPath = vertices[0].id.ToString();    //Нужно, чтобы первая вершина отображалась в конечном результате
                vertices[0].minPathVal = 0;
                while (queue.Count != 0) 
                {
                    diff.operationsCount++;
                    var currVert = queue[0];
                    queue.RemoveAt(0);
                    currVert.isVisited = true;
                    if (currVert == goalVert)    //Если мы пришли к искомой вершине, но не прошли остальные, то откладываем обработку искомой вершины
                    {
                        if (queue.Count > 1)
                        {
                            queue.Add(currVert);
                            continue;
                        }
                        else
                        {
                            path = currVert.minPath;
                            break;
                        }
                    }
                    foreach(var edge in currVert.edges)
                    {
                        diff.operationsCount++;
                        if(!edge.vertex2.isVisited)    
                        {
                            if (!queue.Contains(edge.vertex2))
                                queue.Add(edge.vertex2);
                            var vert = edge.vertex2;    //Вершина, с которой мы будем работать
                            if(vert.minPathVal == -1 || vert.minPathVal > currVert.minPathVal + edge.value) 
                            {
                                vert.minPathVal = currVert.minPathVal + edge.value;
                                vert.minPath = currVert.minPath + vert.id.ToString();
                            }
                        }
                    }
                }

                return new Tuple<string, DifficulityRate>(path, diff);
            }

            Tuple<string, DifficulityRate> PriorityQueue(Vertex goalVert)
            {
                DifficulityRate diff = new DifficulityRate();
                string path = "";
                Heap priorityQueue = new Heap();
                priorityQueue.Add(0, 0);
                while (!priorityQueue.IsEmpty())
                {
                    diff.operationsCount++;
                    var currVert = vertices[priorityQueue.GetTop()];
                    currVert.isVisited = true;
                    if (currVert == goalVert)
                        break;

                    foreach (var edge in currVert.edges)
                    {
                        diff.operationsCount++;
                        if (!edge.vertex2.isVisited)   //Добавляем те вершины, в которые мы ещё не зашли
                        {
                            if (!priorityQueue.Contains(edge.vertex2.id))
                            {
                                priorityQueue.Add(edge.vertex2.id, 10 - edge.value);
                            }
                        }
                    }
                }
                return new Tuple<string, DifficulityRate>(path, diff);
            }

        }

    }
}

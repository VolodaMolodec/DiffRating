using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DifficultyRating.GraphsThing
{
    
    public partial class GraphsForm : Form
    {
        class Graph_Arrays
        {
            private class Vertex
            {
                public List<Edge> edges = new List<Edge>();
                public bool isVisited = false;
                public int id;
            }
            private class Edge
            {
                public Vertex vertex1;
                public Vertex vertex2;
            }

            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();
            public string path;    //Список, в котором хранится пройденный путь в алгоритмах поиска
            public void Set(Graph_Table graph)   //Преобразование графа из матрицы смежности  
            {
                vertices.Clear();
                for(int i = 0; i < graph.table.Count; i++)
                {
                    Vertex vert = new Vertex();
                    vert.id = vertices.Count + 1;
                    vertices.Add(vert);
                    for (int j = 0; j <= i; j++)    //Проходим по таблице смежности. В каждой строке не доходим
                    {                               //до диагонали.
                        if (graph.table[i][j] != 0) //Если есть связь с помощью ребра, то соединяем вершины
                        {
                            Edge newEdge = new Edge();
                            newEdge.vertex1 = vert;
                            newEdge.vertex2 = vertices[j];
                            vert.edges.Add(newEdge);
                            vertices[j].edges.Add(newEdge);
                            edges.Add(newEdge);
                        }
                    }
                }     
            }

            public DifficulityRate Search(string name)
            {
                DifficulityRate diff = new DifficulityRate();
                Stopwatch watch = new Stopwatch();
                watch.Start();
                path = ""; //Обнуляем путь
                foreach (var vert in vertices)  //Обнуляем данные о посещении вершин
                    vert.isVisited = false;
                DateTime dateTime = new DateTime();
                Random rnd = new Random((int)dateTime.Ticks);
                var goalVert = vertices[rnd.Next(0, vertices.Count)];   //Конечная вершина
                switch(name)    //В зависимости от названия вызываем соответствующую сортировку
                {
                    case "Deep":
                        List<Vertex> stack = new List<Vertex>
                        {
                            vertices[rnd.Next(0, vertices.Count)]
                        };
                        diff = DeepSearch(stack, goalVert);
                        break;
                    case "Breadth":
                        List<Vertex> queue = new List<Vertex>
                        {
                            vertices[rnd.Next(0, vertices.Count)]
                        };
                        diff = BreadthSearch(queue, goalVert);
                        break;
                }
                watch.Stop();
                diff.totalTime = watch.ElapsedTicks;
                return diff;
            }

            private DifficulityRate DeepSearch(List<Vertex> stack, Vertex goalVert) //Алгоритм поиска в глубину
            {
                DifficulityRate diff = new DifficulityRate(); 
                while (stack.Count != 0)
                {
                    diff.operationsCount++;
                    Vertex currentVert = stack[0];
                    currentVert.isVisited = true;
                    path += currentVert.id.ToString();   //Добавляем id вершины в список пройденного пути
                    stack.RemoveAt(0);
                    if (currentVert == goalVert)    //Если текущая вершина совпадает с конечной, то останавливаемся
                        break;
                    foreach (var edge in currentVert.edges)  //Проходим по всем граням, связанным с вершиной
                    {                                       //и добавляем в стек все непройденные вершины
                        if (edge.vertex1 != currentVert && !edge.vertex1.isVisited && !stack.Contains(edge.vertex1))
                            stack.Insert(0, edge.vertex1);
                        else if (edge.vertex2 != currentVert && !edge.vertex2.isVisited && !stack.Contains(edge.vertex2))
                            stack.Insert(0, edge.vertex2);
                    }
                }
                return diff;
            }
            private DifficulityRate BreadthSearch(List<Vertex> queue, Vertex goalVert)
            {
                DifficulityRate diff = new DifficulityRate();
                while( queue.Count != 0 )
                {
                    diff.operationsCount++;
                    Vertex currentVert = queue[0];
                    currentVert.isVisited = true;
                    path += currentVert.id.ToString();
                    queue.RemoveAt(0);
                    if (currentVert == goalVert)    //Если текущая вершина совпадает с конечной, то останавливаемся
                        break;
                    foreach (var edge in currentVert.edges)  //Проходим по всем граням, связанным с вершиной
                    {                                       //и добавляем в стек все непройденные вершины
                        if (edge.vertex1 != currentVert && !edge.vertex1.isVisited && !queue.Contains(edge.vertex1))
                            queue.Add(edge.vertex1);
                        else if (edge.vertex2 != currentVert && !edge.vertex2.isVisited && !queue.Contains(edge.vertex2))
                            queue.Add(edge.vertex2);
                    }
                }
                return diff;
            }
        }

        class Graph_Table
        {
            public Graph_Table()
            {
                this.table = new List<List<int>>();
            }
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
                lists.Clear();
                foreach(var iter in graph.table)
                {
                    lists.Add(iter);
                }
            }
        }

        private Graph_Table CreateAmazingFULLGraph(int inputtttttttt)
        {
            List<List<int>> list = new List<List<int>>();
            for(int y = 0; y < inputtttttttt; y++)
            {
                list.Add(new List<int>());
                for(int x = 0; x < inputtttttttt; x++)
                {
                    if (y != x)
                        list[y].Add(1);
                    else
                        list[y].Add(0);
                }
            }
            Graph_Table graph = new Graph_Table(list);
            return graph;
        }

        private Graph_Table CreateAmazingPARTGraph(int iput)
        {
            List<List<int>> list = new List<List<int>>();
            Random rnd = new Random();
            for(int y = 0; y < iput; y++)
            {
                list.Add(new List<int>(new int[iput]));
                for(int x = 0; x <= y; x++)
                {
                    if (rnd.Next(0, 10) > 5 && x != y)
                    {
                        list[y][x] = 1;
                        list[x][y] = 1;
                    }
                    else
                    {
                        list[y][x] = 0;
                        list[x][y] = 0;
                    }
                        
                }
            }
            Graph_Table graph = new Graph_Table(list);
            return graph;
        }
    }
}

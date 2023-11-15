using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.GraphsThing
{
    public partial class GraphsForm : Form
    {
        class OrientedGraph
        {
            private class Vertex
            {
                public int id;
                public List<OrientedEdge> edges = new List<OrientedEdge>();
            }
            private class OrientedEdge
            {
                public int value;
                public Vertex outVert = new Vertex();
                public Vertex inVert = new Vertex();
            }

            private List<Vertex> vertices;
            private List<OrientedEdge> edges;
            public DifficulityRate diff;
            public string path; //Хранит минимальный путь
            public int sum; //Хранит минимальную сумму пройденного пути
            public void Init(int N) //Создание ориентированного взвешенного графа.
            {
                while(true)
                {
                    Generate(N);
                    if(CheckForCycles())
                        break;
                }
            }
            private void Generate(int N)    //Генерируем вершины и рёбра
            {
                vertices = new List<Vertex>();
                edges = new List<OrientedEdge>();

                DateTime dateTime = new DateTime();
                Random rnd = new Random((int)dateTime.Ticks);
                for(int i = 0; i < N; i++)
                {
                    Vertex newVert = new Vertex();
                    for(int j = 0; j < vertices.Count; j++)
                    {
                        OrientedEdge edge = new OrientedEdge();
                        edge.value = rnd.Next(0, 100);  //Генерируем вес ребра
                        if (rnd.Next(0, 2) == 0)    //генерируем ориентацию ребра
                        {
                            edge.outVert = newVert;
                            edge.inVert = vertices[j];
                        }
                        else
                        {
                            edge.outVert = vertices[j];
                            edge.inVert = newVert;
                        }
                        edges.Add(edge);
                        newVert.edges.Add(edge);
                        vertices[j].edges.Add(edge);
                    }
                    newVert.id = vertices.Count + 1;
                    vertices.Add(newVert);
                }
            }

            private bool CheckForCycles()   //Проверяет на наличие циклов. Возвращает 1, если циклы есть и 0 в обратном случае
            {
                return true;
            }

            public List<List<int>> GetTable()   //Возвращает таблицу, представляющую граф
            {
                List<List<int>> table = new List<List<int>>();
                int N = vertices.Count;
                for (int y = 0; y < N; y++)
                {
                    table.Add(new List<int>());
                    Vertex currVert = vertices[y];
                    for(int x = 0; x < N; x++) 
                    {
                        if (x == y)
                            table[y].Add(0);
                        int val = 0;
                        if (currVert.edges[x].outVert == currVert)  //Если ребро выходит из вершины, то в таблице значение веса будет положительно, иначе отрицательно
                            val = currVert.edges[x].value;
                        else
                            val = currVert.edges[x].value * -1;
                        table[y].Add(val);
                    }
                }
                return table;
            }

            public DifficulityRate Search(string name)  //Поиск вершины в графе. Принимает название поиска
            {
                diff = new DifficulityRate();
                Stopwatch watch = new Stopwatch();
                Random rnd = new Random((int)new DateTime().Ticks);
                Vertex goalVert = vertices[rnd.Next(0, vertices.Count)];
                Vertex startVert = vertices[rnd.Next(0, vertices.Count)];
                watch.Start();
                switch (name)
                {
                    case "Recurs":
                        var result = RecursFindPath(startVert, goalVert);
                        path = result.Item2;
                        sum = result.Item1;
                        break;
                }
                watch.Stop();
                diff.totalTime = watch.ElapsedTicks;
                return diff;
            }

            private Tuple<int,string> RecursFindPath(Vertex currVert, Vertex goalVert, int depth = 0, string path = "") //Рекурсивный поиск пути
            {   
                if (depth > vertices.Count) //Если глубина рекурсии больше кол-ва вершин, то программа идёт по кругу
                    return new Tuple<int,string>(-1, "");
                else if (currVert == goalVert)
                    return new Tuple<int,string>(0, path + currVert.id.ToString());
                List<OrientedEdge> nextEdges = new List<OrientedEdge>(); //Список рёбер, по которым можно пройти
                foreach(var edge in currVert.edges)
                    if (edge.inVert != currVert)    //Проверяем, можно ли по ребру перейти в следующую вершину. Если да, то добавляем это ребро
                        nextEdges.Add(edge);

                int valSum = -1;    //Сумма веса рёбер в кратчайшем пути
                string minPath = "";    //Сам кратчайший путь
                foreach(var edge in nextEdges)
                {
                    diff.operationsCount++;
                    path += currVert.id.ToString();
                    var result = RecursFindPath(edge.inVert, goalVert, depth + 1);
                    if (result.Item1 != -1)   //Если нашли вершину, то сравниваем сумму веса
                    {
                        if (valSum == -1 || result.Item1 + edge.value < valSum)
                        {
                            valSum = edge.value + result.Item1;
                            minPath = result.Item2;
                        }
                            
                    }
                }

                return new Tuple<int,string>(valSum,minPath);
            }
        }

    }
}

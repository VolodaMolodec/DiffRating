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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Windows.Forms.VisualStyles;

namespace DifficultyRating.GraphsThing
{
    //Класс, представляющий собой граф, записанный в виде массивов вершин и рёбер
    class Graph_Arrays
    {
        //Вершина графа будет иметь ссылки на рёбра и прочие технические данные
        private class Vertex
        {
            public List<Edge> edges = new List<Edge>();
            public bool isVisited = false;
            public int id;
        }
        //Ребро в графе. Имее ссылки на вершины, которые это ребро соединяет, переменные id и check для алгоритма поиска ребра
        private class Edge
        {
            public Vertex vertex1;
            public Vertex vertex2;
            public int id;
            public bool check = false;

            public Edge Reverse()   //Возвращает перевёрнутую грань. Нужно для облегчения кода в дальнейшем
            {
                Edge reverseEdge = new Edge();
                reverseEdge.vertex1 = vertex2;
                reverseEdge.vertex2 = vertex1;
                return reverseEdge;
            }
        }

        List<Vertex> vertices = new List<Vertex>();
        List<Edge> edges = new List<Edge>();
        //Список, в котором хранится пройденный путь в алгоритмах поиска
        public string path;
        //Компоненты связности
        public int components = 0;

        public Graph_Arrays()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }

        public Graph_Arrays(int N)
        {
            Generate(N);
        }

        public Graph_Arrays(int N, int components)
        {
            Generate(N, components);
        }

        public Graph_Arrays(Graph_Table graph)
        {
            TransformFrom(graph);
        }

        public Graph_Arrays(Graph_List graph)
        {
            TransformFrom(graph);
        }


        public static bool operator!=(Graph_Arrays a, Graph_Arrays b)
        {
            return !(a == b);
        }

        public static bool operator==(Graph_Arrays a, Graph_Arrays b)
        {
            if (a.Get() == b.Get())
                return true;
            else
                return false;
        }

        //Преобразование графа из матрицы смежности 
        public void TransformFrom(Graph_Table graph)    
        {
            vertices.Clear();
            edges.Clear();
            int N = graph.table.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                Vertex vert = new Vertex
                {
                    id = i + 1
                };
                vertices.Add(vert);
                for (int j = 0; j <= i; j++)    //Проходим по таблице смежности. В каждой строке не доходим
                {                               //до диагонали.
                    if (graph.table[i,j] != 0) //Если есть связь с помощью ребра, то соединяем вершины
                    {
                        Edge newEdge = new Edge
                        {
                            id = edges.Count - 1,
                            vertex1 = vert,
                            vertex2 = vertices[j]
                        };
                        vert.edges.Add(newEdge);
                        vertices[j].edges.Add(newEdge.Reverse());
                        edges.Add(newEdge);
                    }
                }
            }     
        }

        //Преобразование графа из списков смежности
        public void TransformFrom(Graph_List graph)
        {
            TransformFrom(graph.Get());
        }

        //Передаёт данные о графе в виде таблицы смежности
        public Graph_Table Get()
        {
            int N = vertices.Count;
            int[,] table = new int[N,N];
            
            for(int i = 0; i < N; i++)
                foreach(var edge in vertices[i].edges)
                    table[i, edge.vertex2.id - 1] = 1;
                    
            return new Graph_Table(table);
        }

        //Генерация полного графа с N вершинами
        public void Generate(int N)
        {
            vertices.Clear();
            edges.Clear();
            for(int i = 0; i < N; i++)
            {
                Vertex vert = new Vertex() 
                { 
                    id = i + 1 
                };
                for(int j = 0; j < i; j++)  //Связываем вершину с другими
                {
                    Edge newEdge = new Edge
                    {
                        id = edges.Count - 1,
                        vertex1 = vert,
                        vertex2 = vertices[j]
                    };
                    vert.edges.Add(newEdge);
                    vertices[j].edges.Add(newEdge.Reverse());
                    edges.Add(newEdge);
                }
                vertices.Add(vert);
            }
        }

        //Генерация разреженного графа с заданным числом компонент связности
        public void Generate(int N, int componentsCount)
        {
            if (N < componentsCount)
                throw new Exception("Число компонент связности больше числа вершин");
            vertices.Clear();
            edges.Clear();
            List<List<Vertex>> component = new List<List<Vertex>>();
            for (int i = 0; i < componentsCount; i++)
            {
                component.Add(new List<Vertex>());
                component[i].Add(new Vertex());
            }
            for (int i = 0; i < N - componentsCount; i++)
                component[CustomRandom.Next(componentsCount)].Add(new Vertex());
                
            //В каждой компоненте связности соединяем вершины друг с другом, а затем доабвляем в список вершин
            foreach(var comp in component)
            {
                for(int i = 0; i < comp.Count; i++)
                    for(int j = 0; j < i; j++)
                    {
                        Edge newEdge = new Edge
                        {
                            id = edges.Count - 1,
                            vertex1 = comp[i],
                            vertex2 = comp[j]
                        };
                        comp[i].edges.Add(newEdge);
                        comp[j].edges.Add(newEdge.Reverse());
                        edges.Add(newEdge);
                    }
                vertices.AddRange(comp);
            }

            for (int i = 0; i < vertices.Count; i++)
                vertices[i].id = i + 1;

        }

        //Общая функция для вызовов всех алгоритмов. Нужно для более удобного замера времени
        public DifficulityRate Search(string name)
        {
            DifficulityRate diff = new DifficulityRate();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            path = "";
            foreach (var vert in vertices)  
                vert.isVisited = false;
            //Конечная вершина
            var goalVert = vertices[CustomRandom.Next(vertices.Count)];   
            //В зависимости от названия вызываем соответствующую сортировку
            switch (name)    
            {
                case "Deep":
                    diff = DeepSearch(goalVert);
                    break;
                case "Breadth":
                    diff = BreadthSearch(goalVert);
                    break;
                case "ComponentsFind":
                    diff = ComponentsFind();
                    break;
            }
            watch.Stop();
            diff.totalTime = watch.ElapsedTicks;
            return diff;
        }

        //Алгоритм поиска в глубину
        private DifficulityRate DeepSearch(Vertex goalVert)
        {
            DifficulityRate diff = new DifficulityRate();
            List<Vertex> stack = new List<Vertex>
            {
                vertices[0]
            };
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
                    if (!edge.vertex2.isVisited && !stack.Contains(edge.vertex2))
                        stack.Insert(0, edge.vertex2);
                }
            }
            return diff;
        }

        //Поиск компонент связности
        private DifficulityRate ComponentsFind()
        {
            DifficulityRate diff = new DifficulityRate();
            List<Vertex> stack = new List<Vertex>
            { 
                vertices[0] 
            };
            //Переменная для проверки, зацепили ли мы все вершины
            int allVert = vertices.Count; 
            components = 0;
            while(allVert > 0)
            {
                while(stack.Count != 0)
                {
                    diff.operationsCount++;
                    Vertex currentVert = stack[0];
                    currentVert.isVisited = true;
                    stack.RemoveAt(0);
                    allVert--;
                    foreach (var edge in currentVert.edges)  //Проходим по всем граням, связанным с вершиной
                    {                                       //и добавляем в стек все непройденные вершины
                        if (edge.vertex1 != currentVert && !edge.vertex1.isVisited && !stack.Contains(edge.vertex1))
                            stack.Insert(0, edge.vertex1);
                        else if (edge.vertex2 != currentVert && !edge.vertex2.isVisited && !stack.Contains(edge.vertex2))
                            stack.Insert(0, edge.vertex2);
                    }
                }
                components++;
                //Если остались непройденные вершины, то значит, что они не входят в предыдущую компоненту связности.
                //Тогда добавляем первую непройденную першину в стек и повторяем 
                if (allVert >= 0)    
                    foreach(var vert in vertices)   
                        if (!vert.isVisited)
                        {
                            stack.Add(vert);
                            break;
                        }
            }

            return diff;
        }

        //Поиск в ширину
        private DifficulityRate BreadthSearch(Vertex goalVert)
        {
            DifficulityRate diff = new DifficulityRate();
            List<Vertex> queue = new List<Vertex>
            {
                vertices[0]
            };
            while ( queue.Count != 0 )
            {
                diff.operationsCount++;
                Vertex currentVert = queue[0];
                currentVert.isVisited = true;
                path += currentVert.id.ToString();
                queue.RemoveAt(0);
                if (currentVert == goalVert)    //Если текущая вершина совпадает с конечной, то останавливаемся
                    break;
                foreach (var edge in currentVert.edges)  //Проходим по всем граням, связанным с вершиной
                {                                       //и добавляем в очередь все непройденные вершины
                    if (edge.vertex1 != currentVert && !edge.vertex1.isVisited && !queue.Contains(edge.vertex1))
                        queue.Add(edge.vertex1);
                    else if (edge.vertex2 != currentVert && !edge.vertex2.isVisited && !queue.Contains(edge.vertex2))
                        queue.Add(edge.vertex2);
                }
            }
            return diff;
        }

        //Поиск ребра, соединяющего вершины с idA и idB
        public Tuple<bool, DifficulityRate> EdgeSearch(int idA, int idB)
        {
            DifficulityRate diff = new DifficulityRate();
            CustomWatch.Start();
            Vertex vertA = vertices[idA - 1], vertB = vertices[idB - 1];
            foreach(var edge in edges)
            {
                diff.operationsCount++;
                if ((edge.vertex1 == vertA && edge.vertex2 == vertB) || (edge.vertex2 == vertA && edge.vertex1 == vertB))
                {
                    CustomWatch.Stop();
                    diff.totalTime = CustomWatch.Get();
                    return new Tuple<bool, DifficulityRate>(true, diff);
                }
                    
            }
            CustomWatch.Stop();
            return new Tuple<bool, DifficulityRate>(false, diff);
        }

    }

    //Граф, представленный в виде таблице. Тут написано мало функций, поскольку для алгоритмов я его не использую
    class Graph_Table
    {
        public int[,] table;

        public Graph_Table()
        {
            this.table = new int[0, 0];
        }
        public Graph_Table(int[,] table)
        {
            this.table = table;
        }

        public Graph_Table(Graph_Arrays graph)
        {
            table = graph.Get().table;
        }

        public Graph_Table(Graph_List graph)
        {
            table = graph.Get().table;
        }

        public void Generate(int size)
        {
            table = new int[size,size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (y != x)
                        table[y,x] = 1;
                    else
                        table[y, x] = 0;
                }
            }
        }

        public static bool operator==(Graph_Table a, Graph_Table b)
        {
            int N = a.table.GetLength(1);
            if (b.table.GetLength(1) != N ) return false;
            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                    if (a.table[y, x] != b.table[y, x])
                        return false;
            return true;
        }

        public static bool operator!=(Graph_Table a, Graph_Table b)
        {
            return !(a == b);
        }

        //Преобразование из множвества вершин и рёбер
        public void TransformFrom(Graph_Arrays graph)
        {
            table = graph.Get().table;
        }

        //Преобразование из списков смежности
        public void TransformFrom(Graph_List graph)
        {
            table = graph.Get().table;
        }
    }

    //Граф, представленный в виде списков смежности. В моей программе не используется
    class Graph_List
    {
        class Vertex
        {
            public List<Vertex> vertices = new List<Vertex>();
            public int id;
        }

        private List<Vertex> vertices = new List<Vertex>();

        public Graph_List()
        {
            vertices = new List<Vertex>();
        }

        public Graph_List(Graph_Table graph)
        {
            TransformFrom(graph);
        }

        public Graph_List(Graph_Arrays graph)
        {
            TransformFrom(graph);
        }

        public static bool operator==(Graph_List a, Graph_List b)
        {
            if (a.Get() == b.Get())
                return true;
            else
                return false;
        }

        public static bool operator!=(Graph_List a, Graph_List b)
        {
            return !(a == b);
        }

        //Пререход из таблицы смежности в списки смежности
        public void TransformFrom(Graph_Table graph)
        {
            vertices.Clear();
            int N = graph.table.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                Vertex vert = new Vertex()
                {
                    id = i + 1
                };
                
                vertices.Add(vert);
                for (int j = 0; j <= i; j++)    //Проходим по таблице смежности. В каждой строке не доходим
                {                               //до диагонали.
                    if (graph.table[i,j] != 0) //Если есть связь с помощью ребра, то соединяем вершины
                    {
                        vert.vertices.Add(vertices[j]);
                        vertices[j].vertices.Add(vert);
                    }
                }
            }
        }

        //Переход из массивов вершин и рёбер к списком смежности
        public void TransformFrom(Graph_Arrays graph)
        {
            TransformFrom(graph.Get());
        }

        //Получение графа в виде таблицы смежности
        public Graph_Table Get()
        {
            int N = vertices.Count;
            int[,] table = new int[N, N];
            for (int i = 0; i < vertices.Count; i++)
                foreach (var vert in vertices[i].vertices)
                    table[i, vert.id - 1] = 1;

            return new Graph_Table(table);
        }

    }
}
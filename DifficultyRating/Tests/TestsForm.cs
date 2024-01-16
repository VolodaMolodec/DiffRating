using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DifficultyRating.GraphsThing;
using DifficultyRating.Lection1;
using DifficultyRating.Lection2;

namespace DifficultyRating.Tests
{
    public partial class TestsForm : Form
    {
        public TestsForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "";

            //Selection Sort tests
            if (Lection1.Sorts.SelectionSort(new List<int> { 1, 5, 2, 4, 3 }).Item1.SequenceEqual(new List<int> { 1, 2, 3, 4, 5 }))
                logTextBox.Text += "Тест Selection Sort 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Selection Sort 1 провален\n";
            if (Lection1.Sorts.SelectionSort(new List<int> { 1, 5, 2, 2, 3, 4, 10 }).Item1.SequenceEqual(new List<int> { 1, 2, 2, 3, 4, 5 , 10}))
                logTextBox.Text += "Тест Selection Sort 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Selection Sort 2 провален\n";

            //Merge Sort tests
            if (Lection1.Sorts.MergeSort(new List<int> { 1, 5, 2, 4, 3 }).Item1.SequenceEqual(new List<int> { 1, 2, 3, 4, 5 }))
                logTextBox.Text += "Тест Merge Sort 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Merge Sort 1 провален\n";
            if (Lection1.Sorts.MergeSort(new List<int> { 1, 5, 2, 2, 3, 4, 10 }).Item1.SequenceEqual(new List<int> { 1, 2, 2, 3, 4, 5, 10 }))
                logTextBox.Text += "Тест Merge Sort 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Merge Sort 2 провален\n";

            //Fibonnaci Slow test
            if (Fibonachi.Calc("Slow", 6).Item1 == 13)
                logTextBox.Text += "Тест Fibonnaci Slow 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Fibonnaci Slow 1 провален\n";
            if (Fibonachi.Calc("Slow", 8).Item1 == 34)
                logTextBox.Text += "Тест Fibonnaci Slow 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Fibonnaci Slow 2 провален\n";

            //Fibonnaci Advanced test
            if (Fibonachi.Calc("Advanced", 6).Item1 == 13)
                logTextBox.Text += "Тест Fibonnaci Advanced 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Fibonnaci Advanced 1 провален\n";
            if (Fibonachi.Calc("Advanced", 8).Item1 == 34)
                logTextBox.Text += "Тест Fibonnaci Advanced 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Fibonnaci Advanced 2 провален\n";

            BinaryTree.Build(new List<int> { 1, 2, 2, 3, 4, 5, 10 });
            //Binary Find test
            if(BinaryTree.Find(10).Item1 == true)
                logTextBox.Text += "Тест BinaryTree find 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест BinaryTree find 1 провален\n";
            if (BinaryTree.Find(15).Item1 == false)
                logTextBox.Text += "Тест BinaryTree find 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест BinaryTree find 2 провален\n";

            //Column Mult test
            if (Multiply.Mult("ColumnMult", 100, 200).Item1 == 200 * 100)
                logTextBox.Text += "Тест Column Multiply 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Column Multiply 1 провален\n";
            if (Multiply.Mult("ColumnMult", 128, 128).Item1 == 128 * 128)
                logTextBox.Text += "Тест Column Multiply 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Column Multiply 2 провален\n";

            //Naive Mult test
            if (Multiply.Mult("NaiveMult", 100, 200).Item1 == 200 * 100)
                logTextBox.Text += "Тест Naive Multiply 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Naive Multiply 1 провален\n";
            if (Multiply.Mult("NaiveMult", 128, 128).Item1 == 128 * 128)
                logTextBox.Text += "Тест Naive Multiply 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Naive Multiply 2 провален\n";


            //Проверка перехода представлений графов
            Graph_Arrays SevenTestGraph = new Graph_Arrays(10, 3);
            Graph_Table SevenTestTableGraph = new Graph_Table(SevenTestGraph);
            Graph_List SevenTestListGraph = new Graph_List(SevenTestTableGraph);
            Graph_Arrays SevenTestEndGraph = new Graph_Arrays(SevenTestListGraph);
            if (SevenTestGraph == SevenTestEndGraph)
                logTextBox.Text += "Тест Преобразования графа 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Преобразования графа 1 провален\n";

            //Проверка поиска ребра
            SevenTestTableGraph.table = new int[6, 6]
            {
                { 0, 1, 1, 1, 0, 0 },
                { 1, 0, 1, 1, 1, 0 },
                { 1, 1, 0, 1, 1, 1 },
                { 1, 1, 1, 0, 1, 1 },
                { 0, 1, 1, 1, 0, 1 },
                { 0, 0, 1, 1, 1, 0 },
            };
            SevenTestGraph.TransformFrom(SevenTestTableGraph);
            if (SevenTestGraph.EdgeSearch(1, 3).Item1)
                logTextBox.Text += "Тест Поиск ребра 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Поиск ребра 1 провален\n";
            if (!SevenTestGraph.EdgeSearch(1, 5).Item1)
                logTextBox.Text += "Тест Поиск ребра 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Поиск ребра 1 провален\n";


            //Random Median test
            if (Median.RandomMedian(new List<int> { 1, 5, 2, 2, 3, 4, 10 }).Item1 == 3)
                logTextBox.Text += "Тест Random Median 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Random Median 1 провален\n";
            if (Median.RandomMedian(new List<int> { 1, 5, 2, 4, 2 }).Item1 == 2)
                logTextBox.Text += "Тест Random Median 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Random Median 2 провален\n";



            //Поиск связанных компонент
            Graph_Arrays graph = new Graph_Arrays(6, 1);
            graph.Search("ComponentsFind");
            if (graph.components == 1)
                logTextBox.Text += "Тест Components Search 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Components Search 1 провален\n";
            graph.Generate(8, 3);
            graph.Search("ComponentsFind");
            if (graph.components == 3)
                logTextBox.Text += "Тест Components Search 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Components Search 2 провален\n";


            //Queue test
            Queue queue = new Queue(new int[10]);
            queue.Add(1);
            queue.Add(10);
            if (queue.Get() == 1)
                logTextBox.Text += "Тест Queue 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Queue 1 провален\n";
            if (queue.Get() == 10)
                logTextBox.Text += "Тест Queue 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Queue 2 провален\n";
            queue = new Queue(new DoubleList());
            queue.Add(1);
            queue.Add(10);
            if (queue.Get() == 1)
                logTextBox.Text += "Тест Queue 3 успешно завершён\n";
            else
                logTextBox.Text += "Тест Queue 3 провален\n";
            if (queue.Get() == 10)
                logTextBox.Text += "Тест Queue 4 успешно завершён\n";
            else
                logTextBox.Text += "Тест Queue 4 провален\n";

            //Stack test
            Stack stack = new Stack(new int[10]);
            stack.Add(1);
            stack.Add(10);
            if (stack.Get() == 10)
                logTextBox.Text += "Тест Stack 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Stack 1 провален\n";
            if (stack.Get() == 1)
                logTextBox.Text += "Тест Stack 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Stack 2 провален\n";
            stack = new Stack(new DoubleList());
            stack.Add(1);
            stack.Add(10);
            if (stack.Get() == 10)
                logTextBox.Text += "Тест Stack 3 успешно завершён\n";
            else
                logTextBox.Text += "Тест Stack 3 провален\n";
            if (stack.Get() == 1)
                logTextBox.Text += "Тест Stack 4 успешно завершён\n";
            else
                logTextBox.Text += "Тест Stack 4 провален\n";


            //Tree Min test
            WeightGraph weightGraph = new WeightGraph(new List<List<int>>()
            {
                new List<int>{ 0, 1, 5, 3 },
                new List<int>{ 1, 0, 5, 1 },
                new List<int>{ 5, 5, 0, 4 },
                new List<int>{ 3, 1, 4, 0 }
            }
            );
            if (weightGraph.TreeMin().Item1 == "6")
                logTextBox.Text += "Тест Tree Min 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Tree Min 1 провален\n";

            //Краскал тест
            if(weightGraph.Kruskal().Item1 == 6)
                logTextBox.Text += "Тест Крускал 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Крускал 1 провален\n";


            //Dijcstra test
            if (weightGraph.Dijkstra(1,4).Item1 == "124")
                logTextBox.Text += "Тест Дейкстра 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Дейкстра 1 провален\n";
            if (weightGraph.Dijkstra(2, 3).Item1 == "23")
                logTextBox.Text += "Тест Дейкстра 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Дейкстра 2 провален\n";

            //Heapsort test
            if (Sorts.HeapSort(new List<int> { 1, 5, 2, 4, 3 }).Item1.SequenceEqual(new List<int> { 1, 2, 3, 4, 5 }))
                logTextBox.Text += "Тест Heapsort 1 успешно завершён\n";
            else
                logTextBox.Text += "Тест Heapsort 1 провален\n";
            if (Sorts.HeapSort(new List<int> { 1, 5, 2, 2, 3, 4, 10 }).Item1.SequenceEqual(new List<int> { 1, 2, 2, 3, 4, 5, 10 }))
                logTextBox.Text += "Тест Heapsort 2 успешно завершён\n";
            else
                logTextBox.Text += "Тест Heapsort 2 провален\n";
        }
    }
}

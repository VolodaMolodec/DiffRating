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
using ZedGraph;
using DifficultyRating.Lection1;
using DifficultyRating.Lection2;

namespace DifficultyRating
{
    public partial class Algorithms : Form
    {
        Random rnd;
        List<DifficultyGraph> pointLists;
        bool initialized;
        int drawMode;
        public Algorithms()
        {
            InitializeComponent();
            rnd = new Random();
            pointLists = new List<DifficultyGraph>()
            {
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph(),
                new DifficultyGraph()
            };
            initialized = false;
            GraphPane pane = zedGraphControl.GraphPane;
            pane.XAxis.Title.Text = "Кол-во элементов";
            pane.YAxis.Title.Text = "Кол-во операций";
            pane.Title.Text = "График";
        }


        private void Init()
        {
            List<int> listToSort = new List<int>(); //Список для сортировок и других алгоритмов. В каждом шаге будет прибавляться новый элемент
            Random rnd = new Random();
            listToSort.Add(rnd.Next(100));

            for (int x = 0; x < 100; x++) //Вычисляем график для QUickSort, SelectionSort и крутого фибоначчи
            {
                pointLists[0].Add(x, Sorts.Sort("SelectionSort",listToSort).Item2);
                pointLists[1].Add(x, Sorts.Sort("MergeSort", listToSort).Item2);
                pointLists[3].Add(x, Fibonachi.Calc("Advanced", x).Item2);
                pointLists[4].Add(x, BinaryTree.Build(listToSort));
                pointLists[5].Add(x, BinaryTree.Find(listToSort[rnd.Next(listToSort.Count)]).Item2);
                pointLists[6].Add(x, BinaryTree.Depth().Item2);
                listToSort.Add(rnd.Next(100));
            }
            for (int x = 1; x < 20; x++)    //Вычисляем сложность для более медленных алгоритмов
            {
                pointLists[2].Add(x, Fibonachi.Calc("Slow",x).Item2);
                pointLists[7].Add(x, RandomTree.buildTree(x, 2).Item2);
                pointLists[10].Add(x, Median.RandomMedian(listToSort.GetRange(0,x)).Item2);

            }
            for(int x = 0; x < 8; x++)  //Умножения выбираем отдельно, поскольку при высоких x происходят ошибки
            {
                int num1 = rnd.Next((int)Math.Pow(10, x), (int)Math.Pow(10, x + 1));
                int num2 = rnd.Next((int)Math.Pow(10, x), (int)Math.Pow(10, x + 1));
                pointLists[8].Add(x, Multiply.Mult("ColumnMult", num1, num2).Item2);
                pointLists[9].Add(x, Multiply.Mult("NaiveMult", num1, num2).Item2);
            }
            initialized = true;
        }

        private void graphSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void DrawGraph()
        {
            if (!initialized)
                Init();

            GraphPane pane = zedGraphControl.GraphPane;
            pane.CurveList.Clear();

            if (graphSelectComboBox1.SelectedItem != null)
            {
                pane.AddCurve("Кол-во операций 1", pointLists[graphSelectComboBox1.SelectedIndex].GetGraph(drawMode), Color.Blue, SymbolType.None);
            }
            if (graphSelectComboBox2.SelectedItem != null)
            {
                pane.AddCurve("Кол-во операций 2", pointLists[graphSelectComboBox2.SelectedIndex].GetGraph(drawMode), Color.Red, SymbolType.None);
            }

            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void operationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (operationCheckBox.Checked != false)
            {
                drawMode = 0;
                timeCheckBox.Checked = false;
                DrawGraph();
            }
        }

        private void timeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (timeCheckBox.Checked != false) 
            {
                drawMode = 1;
                operationCheckBox.Checked = false;
                DrawGraph();
            }
        }
    }
}

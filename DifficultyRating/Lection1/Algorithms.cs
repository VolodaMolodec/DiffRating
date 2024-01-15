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
            int totalAlgorithms = 12;
            pointLists = new List<DifficultyGraph>();
            for (int i = 0; i < totalAlgorithms; i++)
                pointLists.Add(new DifficultyGraph());
            initialized = false;
            GraphPane pane = zedGraphControl.GraphPane;
            pane.XAxis.Title.Text = "Кол-во элементов";
            pane.YAxis.Title.Text = "Кол-во операций";
            pane.Title.Text = "График";
        }


        private List<int> RegenerateValues(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i] = CustomRandom.Next(100);
            return list;
        }

        private void Init()
        {
            //Список для сортировок и других алгоритмов. В каждом шаге будет прибавляться новый элемент
            List<int> listToSort = new List<int>
            {
                CustomRandom.Next(100)
            }; 

            for (int x = 1; x < 100; x++) //Вычисляем график для быстрых алгоритмов
            {
                DifficulityRate[] diffs = new DifficulityRate[8];
                for(int i = 0; i < 8; i++)
                    diffs[i] = new DifficulityRate();
                for(int i = 0; i < 50; i++)
                {
                    listToSort = RegenerateValues(listToSort);
                    diffs[0] += Sorts.SelectionSort(listToSort).Item2;
                    diffs[1] += Sorts.MergeSort(listToSort).Item2;
                    diffs[2] += Fibonachi.Calc("Advanced", x).Item2;
                    diffs[3] += BinaryTree.Build(listToSort);
                    diffs[4] += BinaryTree.Find(listToSort[CustomRandom.Next(listToSort.Count)]).Item2;
                    diffs[5] += BinaryTree.Depth().Item2;
                    diffs[6] += Sorts.HeapSort(listToSort).Item2;
                    CustomWatch.Start();
                    diffs[7] += Median.RandomMedian(listToSort).Item2;
                    CustomWatch.Stop();
                    diffs[7].totalTime += CustomWatch.Get();
                }
                for(int i = 0; i < 8; i++)
                {
                    diffs[i].operationsCount /= 50;
                    diffs[i].totalTime /= 50;
                }
                pointLists[0].Add(x, diffs[0]);
                pointLists[1].Add(x, diffs[1]);
                pointLists[3].Add(x, diffs[2]);
                pointLists[4].Add(x, diffs[3]);
                pointLists[5].Add(x, diffs[4]);
                pointLists[6].Add(x, diffs[5]);
                pointLists[11].Add(x, diffs[6]);
                pointLists[10].Add(x, diffs[7]);
                listToSort.Add(CustomRandom.Next(100));
            }
            for (int x = 1; x < 20; x++)    //Вычисляем сложность для более медленных алгоритмов
            {
                pointLists[2].Add(x, Fibonachi.Calc("Slow",x).Item2);
                pointLists[7].Add(x, RandomTree.buildTree(x, 2).Item2);
            }
            for(int x = 0; x < 8; x++)  //Умножения выбираем отдельно, поскольку при высоких x происходят ошибки
            {
                int num1 = CustomRandom.Next((int)Math.Pow(10, x), (int)Math.Pow(10, x + 1));
                int num2 = CustomRandom.Next((int)Math.Pow(10, x), (int)Math.Pow(10, x + 1));
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

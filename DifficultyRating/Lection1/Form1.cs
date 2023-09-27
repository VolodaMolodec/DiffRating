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

namespace DifficultyRating
{
    public partial class Form1 : Form
    {
        Random rnd;
        CoolFibonachi coolFib;
        Fibonnachi fib;
        List<PointPairList> pointLists;
        BinaryTree tree;
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            coolFib = new CoolFibonachi();
            fib = new Fibonnachi();
            tree = new BinaryTree();
            pointLists = new List<PointPairList>()
            {
                new PointPairList(),
                new PointPairList(),
                new PointPairList(),
                new PointPairList(),
                new PointPairList(),
                new PointPairList(),
                new PointPairList()
            };
            GraphPane pane = zedGraphControl.GraphPane;
            pane.XAxis.Title.Text = "Кол-во элементов";
            pane.YAxis.Title.Text = "Кол-во операций";
            pane.Title.Text = "График";
        }

        private void Init()
        {
            for(int x = 0; x < 100; x++) //Вычисляем график для QUickSort, SelectionSort и крутого фибоначчи
            {
                pointLists[0].Add(x, Sort(0, x).operationsCount);
                pointLists[1].Add(x, Sort(1, x).operationsCount);
                pointLists[3].Add(x, coolFib.CalcFiboDiff(x).operationsCount);
                pointLists[4].Add(x, tree.buildTreeAndGetDiff(x).operationsCount);
                pointLists[5].Add(x, tree.findAndGetDiff(rnd.Next() % 100).operationsCount);
                pointLists[6].Add(x, tree.getDepthDiff().operationsCount);
            }
            for(int x = 0; x < 20; x++)
            {
                pointLists[2].Add(x, fib.CalcFiboDiff(x).operationsCount);
            }
        }
        private DifficulityRate Sort(int sortId, int n) 
        {
            if (n == 0)
                return new DifficulityRate { operationsCount = 0 };
            List<int> arr = new List<int>();
            for (int i = 0; i < n; i++)
                arr.Add(rnd.Next() % 100);
            DifficulityRate diff = new DifficulityRate();
            switch (sortId)
            {
                case 0:
                    diff = SelectionSort(new List<int>(arr));
                    break;
                case 1:
                    diff = QuickSort(new List<int>(arr));
                    break;
            }
            return diff;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Int32.Parse(ElementsInputTextBox.Text);
            List<int> array = new List<int>();
            for (int i = 0; i < n; i++)
                array.Add(rnd.Next() % 100);
            DifficulityRate SelectionDiff = SelectionSort(new List<int>(array));
            DifficulityRate QuickDiff = QuickSort(new List<int>(array));
            SelectionSortOutput.Text = SelectionDiff.operationsCount.ToString();
            QuickSortOutput.Text = QuickDiff.operationsCount.ToString();
        }

        private void graphSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void DrawGraph()
        {
            GraphPane pane = zedGraphControl.GraphPane;
            pane.CurveList.Clear();
            List<Tuple<int, DifficulityRate>> valueList = new List<Tuple<int, DifficulityRate>>();

            LineItem myCurve1 = null;
            LineItem myCurve2 = null;
            if (graphSelectComboBox1.SelectedItem != null)
            {
                myCurve1 = pane.AddCurve("Кол-во операций 1", pointLists[graphSelectComboBox1.SelectedIndex], Color.Blue, SymbolType.None);
            }
            if (graphSelectComboBox2.SelectedItem != null) 
            {
                myCurve2 = pane.AddCurve("Кол-во операций 2", pointLists[graphSelectComboBox2.SelectedIndex], Color.Red, SymbolType.None);
            }

            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}

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
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            coolFib = new CoolFibonachi();
            fib = new Fibonnachi();
            pointLists = new List<PointPairList>()
            {
                new PointPairList(),
                new PointPairList(),
                new PointPairList(),
                new PointPairList()
            };
        }

        private void Init()
        {
            for(int x = 0; x < 100; x++) //Вычисляем график для QUickSort, SelectionSort и крутого фибоначчи
            {
                pointLists[0].Add(x, Sort(0, x).operationsCount);
                pointLists[1].Add(x, Sort(1, x).operationsCount);
                pointLists[3].Add(x, coolFib.CalcFiboDiff(x).operationsCount);
            }
            for(int x = 0; x < 20; x++)
            {
                pointLists[2].Add(x, fib.CalcFiboDiff(x).operationsCount);
            }
        }
        private class DifficulityRate
        {
            public DifficulityRate()
            {
                operationsCount = 0;
                totalTime = 0;
            }
            public static DifficulityRate operator +(DifficulityRate diff1, DifficulityRate diff2)
            {
                DifficulityRate newDiff = new DifficulityRate();
                newDiff.operationsCount = diff1.operationsCount + diff2.operationsCount;
                newDiff.totalTime = diff1.totalTime + diff2.totalTime;
                return newDiff;
            }
            public int operationsCount { get; set; }
            public int totalTime { get; set; }
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
            
            LineItem myCurve = pane.AddCurve("Кол-во операций", pointLists[graphSelectComboBox.SelectedIndex], 
                                            Color.Blue, SymbolType.None);
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}

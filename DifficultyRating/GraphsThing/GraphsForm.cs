using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace DifficultyRating.GraphsThing
{
    public partial class GraphsForm : Form
    {
        public GraphsForm()
        {
            InitializeComponent();
            initialazed = false;
        }

        bool initialazed;
        int drawMode = 0;
        List<DifficultyGraph> diffGraph = new List<DifficultyGraph>();


        //Измеряем затраченное время
        void InitGraph()
        {
            OrientedGraph orientedGraph = new OrientedGraph();
            Graph_Arrays graph_array = new Graph_Arrays();
            WeightGraph weightGraph = new WeightGraph();
            int totalFunctions = 7;
            diffGraph = new List<DifficultyGraph>();
            for(int i = 0; i < totalFunctions; i++)
                diffGraph.Add(new DifficultyGraph());

            //проводим замеры для более быстрых алгоритмов
            for (int x = 1; x < 50; x++) 
            {
                graph_array.Generate(x);
                orientedGraph.Init(x);
                weightGraph.Generate(x);
                List<DifficulityRate> diffs = new List<DifficulityRate>();
                for (int i = 0; i < totalFunctions; i++)
                    diffs.Add(new DifficulityRate());
                for (int i = 0; i < 50; i++)
                {
                    diffs[0] += graph_array.EdgeSearch(1, x).Item2;
                    diffs[1] += graph_array.Search("Deep");
                    diffs[2] += graph_array.Search("Breadth");
                    diffs[3] += weightGraph.Kruskal().Item2;
                    diffs[4] += weightGraph.Dijkstra(1, x).Item2;
                    diffs[5] += weightGraph.PriorityQueue(1, x).Item2;

                }
                for (int i = 0; i < totalFunctions - 1; i++)
                {
                    diffs[i].operationsCount /= 10;
                    diffs[i].totalTime /= 10;
                }
                for (int i = 0; i < totalFunctions - 1; i++)
                    diffGraph[i].Add(x, diffs[i]);
            }
            //Проводим замеры для более медленных алгоритмов
            for (int x = 1; x < 10; x++)    
            {
                orientedGraph.Init(x);
                DifficulityRate diff = new DifficulityRate();
                for (int i = 0; i < 10; i++)
                {
                    diff += orientedGraph.Search("Recurs");
                }
                diff.operationsCount /= 10;
                diff.totalTime /= 10;
                diffGraph[6].OperationsCountGraph.Add(x, diff.operationsCount);
                diffGraph[6].ExecutionTimeGraph.Add(x, diff.totalTime);
            }
        }


        //Отрисовка сгенерированных графиков зависимости времени выполнения от входных данных
        private void DrawGraph()
        {
            if (!initialazed)
            {
                InitGraph();
                initialazed = true;
            }

            if (GraphSelectComboBox.SelectedItem != null)
            {
                GraphPane pane = zedGraphControl1.GraphPane;
                pane.CurveList.Clear();
                pane.AddCurve("График",
                            diffGraph[GraphSelectComboBox.SelectedIndex].GetGraph(drawMode), //Получаем нужный граф
                            Color.Blue, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
            
        }


        //
        //Привязываем вызовы функций к нажатиям на кнопки
        //
        private void GraphSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void OperationsCount_CH_CheckedChanged(object sender, EventArgs e)
        {
            if (operationsCount_CB.Checked != false)
            {
                drawMode = 0;
                totalTime_CB.Checked = false;
                DrawGraph();
            }
        }

        private void TotalTime_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (totalTime_CB.Checked != false)
            {
                drawMode = 1;
                operationsCount_CB.Checked = false;
                DrawGraph();
            }
        }
    }
}

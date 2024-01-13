using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

        void InitGraph() //Проводим замеры по времени
        {
            OrientedGraph orientedGraph = new OrientedGraph();
            Graph_Table graph_table = new Graph_Table();
            Graph_Arrays graph_array = new Graph_Arrays();
            WeightGraph weightGraph = new WeightGraph();
            int totalFunctions = 5;
            diffGraph = new List<DifficultyGraph>();
            for(int i = 0; i < totalFunctions; i++)
                diffGraph.Add(new DifficultyGraph());

            for(int x = 1; x < 50; x++) //проводим замеры для более быстрых алгоритмов
            {
                graph_table.GenerateFullGraph(x);
                graph_array.Set(graph_table);
                orientedGraph.Init(x);
                weightGraph.Generate(x);
                List<DifficulityRate> diffs = new List<DifficulityRate>();
                for (int i = 0; i < totalFunctions; i++)
                    diffs.Add(new DifficulityRate());
                for (int i = 0; i < 10; i++)
                {
                    diffs[0] += graph_array.Search("Deep");
                    diffs[1] += graph_array.Search("Breadth");
                    diffs[2] += weightGraph.Search("TreeMin").Item2;
                    diffs[3] += weightGraph.Search("Dijkstra").Item2;
                }
                for (int i = 0; i < totalFunctions - 1; i++)
                {
                    diffs[i].operationsCount /= 10;
                    diffs[i].totalTime /= 10;
                }
                for (int i = 0; i < totalFunctions - 1; i++)
                {
                    diffGraph[i].OperationsCountGraph.Add(x, diffs[i].operationsCount);
                    diffGraph[i].ExecutionTimeGraph.Add(x, diffs[i].totalTime);
                }
            }
            for (int x = 1; x < 10; x++)    //Проводим замеры для более медленных алгоритмов
            {
                orientedGraph.Init(x);
                DifficulityRate diff = new DifficulityRate();
                for (int i = 0; i < 10; i++)
                {
                    diff += orientedGraph.Search("Recurs");
                }
                diff.operationsCount /= 10;
                diff.totalTime /= 10;
                diffGraph[4].OperationsCountGraph.Add(x, diff.operationsCount);
                diffGraph[4].ExecutionTimeGraph.Add(x, diff.totalTime);
            }
        }

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

        private void GraphSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void operationsCount_CH_CheckedChanged(object sender, EventArgs e)
        {
            if (operationsCount_CB.Checked != false)
            {
                drawMode = 0;
                totalTime_CB.Checked = false;
                DrawGraph();
            }
        }

        private void totalTime_CB_CheckedChanged(object sender, EventArgs e)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        int totalFunctions = 3;
        bool initialazed;
        List<DifficultyGraph> graph = new List<DifficultyGraph>();

        private void GraphSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!initialazed)
            {
                InitGraph();
                initialazed = true;
            }
                
            if (graphShowModeComboBox.SelectedIndex == -1 || GraphSelectComboBox.SelectedIndex == -1)
                return;
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            pane.AddCurve("График",
                        graph[GraphSelectComboBox.SelectedIndex].GetGraph(graphShowModeComboBox.SelectedIndex), //Получаем нужный граф
                        Color.Blue, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        void InitGraph() //Проводим замеры по времени
        {
            OrientedGraph orientedGraph = new OrientedGraph();
            Graph_Table graph_table = new Graph_Table();
            Graph_Arrays graph_array = new Graph_Arrays();
            graph = new List<DifficultyGraph>();
            for(int i = 0; i < totalFunctions; i++)
                graph.Add(new DifficultyGraph());

            for(int x = 1; x < 50; x++) //проводим замеры для более быстрых алгоритмов
            {
                graph_table = CreateAmazingFULLGraph(x);
                graph_array.Set(graph_table);
                orientedGraph.Init(x);
                List<DifficulityRate> diffs = new List<DifficulityRate>();
                for (int i = 0; i < totalFunctions; i++)
                    diffs.Add(new DifficulityRate());
                for (int i = 0; i < 10; i++)
                {
                    diffs[0] += graph_array.Search("Deep");
                    diffs[1] += graph_array.Search("Breadth");
                }
                for (int i = 0; i < totalFunctions - 1; i++)
                {
                    diffs[i].operationsCount /= 10;
                    diffs[i].totalTime /= 10;
                }
                for (int i = 0; i < totalFunctions - 1; i++)
                {
                    graph[i].OperationsCountGraph.Add(x, diffs[i].operationsCount);
                    graph[i].ExecutionTimeGraph.Add(x, diffs[i].totalTime);
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
                graph[2].OperationsCountGraph.Add(x, diff.operationsCount);
                graph[2].ExecutionTimeGraph.Add(x, diff.totalTime);
            }
        }
    }
}

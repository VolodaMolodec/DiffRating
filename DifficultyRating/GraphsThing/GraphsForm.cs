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
        List<DifficultyGraph> diffGraph = new List<DifficultyGraph>();

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
                        diffGraph[GraphSelectComboBox.SelectedIndex].GetGraph(graphShowModeComboBox.SelectedIndex), //Получаем нужный граф
                        Color.Blue, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

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

        private void testComboBox_SelectedIndexChanged(object sender, EventArgs e) //ПОдготовка к тестам
        {
            graphGenerateButton_Click(sender, e);
        }

        private void graphGenerateButton_Click(object sender, EventArgs e)
        {
            int size = Int32.Parse(graphSizeTextBox.Text);
            if (testComboBox.SelectedIndex == 0 || testComboBox.SelectedIndex == 1) //Генерируем нужный граф и выводим его
            {
                Graph_Table testTable = new Graph_Table();
                testTable.GenerateFullGraph(size);
                List<List<int>> table = testTable.table;
                DrawTable(table);
            }
            else if (testComboBox.SelectedIndex == 2)
            {
                OrientedGraph testGraph = new OrientedGraph();
                testGraph.Init(size);
                DrawTable(testGraph.GetTable());
            }
            else if (testComboBox.SelectedIndex == 3 || testComboBox.SelectedIndex == 4)
            {
                WeightGraph weightGraph = new WeightGraph();
                weightGraph.Generate(size);
                DrawTable(weightGraph.GetTable());
            }
        }

        private void DrawTable(List<List<int>> table)
        {
            graphGridView.RowCount = table.Count + 1;
            graphGridView.ColumnCount = table.Count;
            for (int y = 0; y < table.Count; y++)
                for (int x = 0; x < table.Count; x++)
                    graphGridView[y, x].Value = table[y][x].ToString();

            for (int column = 0; column < table.Count; column++)
                graphGridView.AutoResizeColumn(column);
        }

        private List<List<int>> readTable() //Чтение данных из таблицы и представление их в удобной форме
        {
            List<List<int>> table = new List<List<int>>();
            for(int y = 0; y < graphGridView.RowCount - 1; y++)
            {
                table.Add(new List<int>());
                for(int x = 0; x < graphGridView.ColumnCount; x++)
                    table[y].Add(Int32.Parse(graphGridView[y, x].Value.ToString()));
            }
            return table;
        }

        private void testStartButton_Click(object sender, EventArgs e)
        {
            Heap test = new Heap();
            test.Add(5);
            test.Add(6);
            test.Add(1);
            test.Add(4);
            Tuple<string, int, long> output = new Tuple<string, int, long>("", 0, 0);
            switch (testComboBox.SelectedIndex)
            {
                case 0: //Поиск в глубину
                    Graph_Arrays _graphDeep = new Graph_Arrays();
                    _graphDeep.Set(new Graph_Table(readTable()));
                    DifficulityRate diff1 = _graphDeep.Search("Deep");
                    output = new Tuple<string, int, long>(_graphDeep.path, diff1.operationsCount, diff1.totalTime);
                    break;
                case 1: //Поиск в ширину
                    Graph_Arrays graphBreadth = new Graph_Arrays();
                    graphBreadth.Set(new Graph_Table(readTable()));
                    DifficulityRate diff2 = graphBreadth.Search("Breadth");
                    output = new Tuple<string, int, long>(graphBreadth.path, diff2.operationsCount, diff2.totalTime);
                    break;
                case 2:
                    OrientedGraph orientedGraph = new OrientedGraph(readTable());
                    DifficulityRate diff3 = orientedGraph.Search("Recurs");
                    output = new Tuple<string, int, long>(orientedGraph.path, diff3.operationsCount, diff3.totalTime);
                    break;
                case 3:
                    WeightGraph treeMinGraph = new WeightGraph(readTable());
                    Tuple<string, DifficulityRate> TreeResult = treeMinGraph.Search("TreeMin");
                    output = new Tuple<string, int, long>(TreeResult.Item1, TreeResult.Item2.operationsCount, TreeResult.Item2.totalTime);
                    break;
                case 4:
                    WeightGraph dijkstraGraph = new WeightGraph(readTable());
                    Tuple<string, DifficulityRate> DijkstraResult = dijkstraGraph.Search("Dijkstra");
                    output = new Tuple<string, int, long>(DijkstraResult.Item1, DijkstraResult.Item2.operationsCount, DijkstraResult.Item2.totalTime);
                    break;
            }
            testOutput.Text = output.Item1;
            testOperationCountLabel.Text = "Операций: " + output.Item2.ToString();
            testTimeLabel.Text = "Время: " + output.Item3.ToString();
        }

        
    }
}

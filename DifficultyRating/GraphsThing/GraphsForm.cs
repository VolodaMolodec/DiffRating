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
            dataGridView1.RowCount = 1;
            graph_table = new Graph_Table();
            graph_array = new Graph_Arrays();
            graph_list = new Graph_List();
        }

        Graph_Table graph_table;
        Graph_Arrays graph_array;
        Graph_List graph_list;

        List<DifficultyGraph> graph = new List<DifficultyGraph>();

        private void GraphSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (graphShowModeComboBox.SelectedIndex == -1 || GraphSelectComboBox.SelectedIndex == -1)
                return;
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            switch(GraphSelectComboBox.SelectedIndex) 
            {
                case 0:
                    LineItem curve = pane.AddCurve("График",
                        graph[0].GetGraph(graphShowModeComboBox.SelectedIndex), 
                        Color.Blue, SymbolType.None);
                    break;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.RowCount <= 1)
                dataGridView1.ColumnCount = 1;
            else
                dataGridView1.ColumnCount = dataGridView1.RowCount - 1;
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.RowCount <= 1)
                dataGridView1.ColumnCount = 1;
            else
                dataGridView1.ColumnCount = dataGridView1.RowCount - 1;
        }

        void InitGraph()    //Инициализация и отображение графа. Вызыватся после генерации графа
        {
            int n = graph_table.table.Count;    //n - размер таблицы. Количество строк = количество колонн
            dataGridView1.ColumnCount = n + 1;
            dataGridView1.RowCount = n + 1;
            for (int y = 0; y < n; y++)
                for (int x = 0; x < n; x++)
                    dataGridView1[y, x].Value = graph_table.table[y][x];

            /* Поиск в глубину */
            DifficultyGraph currGraphs = new DifficultyGraph();
            for(int x = 1; x < 50; x++)
            {
                graph_table = CreateAmazingFULLGraph(x);
                graph_array.Set(graph_table);
                DifficulityRate diff = new DifficulityRate();
                for (int i = 0; i < 5; i++)
                     diff += graph_array.DeepSearch();
                diff.operationsCount /= 5;
                diff.totalTime /= 5;
                currGraphs.OperationsCountGraph.Add(x, diff.operationsCount);
                currGraphs.ExecutionTimeGraph.Add(x, diff.totalTime);
            }
            graph.Add(currGraphs);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            graph_table.table.Clear();
            int n;
            if (graphSizeTexBox.Text == "")
                n = 2;
            else
                n = Int32.Parse(graphSizeTexBox.Text);
            graph_table = CreateAmazingFULLGraph(n);
            InitGraph();
        }

        private void PartGraphGenerateButton_Click(object sender, EventArgs e)
        {
            graph_table.table.Clear();
            int n;
            if (graphSizeTexBox.Text == "")
                n = 2;
            else
                n = Int32.Parse(graphSizeTexBox.Text);
            graph_table = CreateAmazinPARTGraph(n);
            InitGraph();
        }
    }
}

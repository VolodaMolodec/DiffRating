using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            
        }

        Graph_Table graph_table;
        Graph_Arrays graph_array;
        Graph_List graph_list;

        List<PointPairList> points = new List<PointPairList>();

        private void InitializationButton_Click(object sender, EventArgs e)
        {
            List<List<int>> list = new List<List<int>>(dataGridView1.Columns.Count);
            for(int y = 0; y < dataGridView1.Columns.Count; y++)
            {
                list.Add(new List<int>());
                for (int x = 0; x <  dataGridView1.Rows.Count - 1; x++)
                {
                    list[y].Add(Int32.Parse(dataGridView1[x, y].Value.ToString()));
                }
                    
            }
                

            graph_table = new Graph_Table(list);
            graph_list = new Graph_List();
            graph_array = new Graph_Arrays();
            graph_array.Set(graph_table);
            graph_list.Set(graph_table);
        }

        private void GraphSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}

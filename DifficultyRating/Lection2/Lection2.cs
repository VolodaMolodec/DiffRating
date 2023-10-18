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

namespace DifficultyRating.Lection2
{
    public partial class Lection2 : Form
    {
        public Lection2()
        {
            InitializeComponent();
            zedGraphControl.GraphPane.Title.Text = "График";
        }

        private List<PointPairList> points = new List<PointPairList>()
        {
            new PointPairList(),
            new PointPairList()
        };

        private void graphSelectComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GraphPane pane = zedGraphControl.GraphPane;
            pane.CurveList.Clear();
            if (graphSelectComboBox1.SelectedIndex == 3 || graphSelectComboBox2.SelectedIndex == 3) 
            {
                coefficientTextBox.Visible = true;
                graphSelectComboBox2.Visible = false;
                graphSelectComboBox2.SelectedIndex = 0;
                graphSelectComboBox1.SelectedIndex = 3;
                
                PointPairList points = new PointPairList();
                int coefficient = Int32.Parse(coefficientTextBox.Text);
                int xmax = 10;
                RandomTree tree = new RandomTree();
                for(int x = 0; x < xmax; x++)
                    points.Add(x, tree.buildTree(x, coefficient));
                LineItem curve = pane.AddCurve("Кол-во элементов", points, Color.Blue, SymbolType.None);
                pane.XAxis.Title.Text = "Глубина";
                pane.YAxis.Title.Text = "Кол-во элементов";
            }
            else
            {
                coefficientTextBox.Visible = false;
                graphSelectComboBox2.Visible = true;
                
                LineItem curve = pane.AddCurve("Кол-во операций", 
                    points[graphSelectComboBox1.SelectedIndex - 1], Color.Blue, SymbolType.None);
                pane.XAxis.Title.Text = "Размер входных данных";
                pane.YAxis.Title.Text = "Кол-во операций";
            }
            
            
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int xmax = 10;
            points[0].Add(0, 0);
            points[1].Add(0, 0);
            for (int x = 1; x < xmax; x++)
            {
                int a = rnd.Next((int)Math.Pow(10, x - 1), (int)Math.Pow(10, x));
                int b = rnd.Next((int)Math.Pow(10, x - 1), (int)Math.Pow(10, x)); ;
                points[0].Add(x, ColumnMult(a, b).operationsCount);
                points[1].Add(x, CoolMult(a, b).operationsCount);
            }
        }
    }
}

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
            }
            
            
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }
    }
}

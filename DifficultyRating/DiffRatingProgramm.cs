﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace DifficultyRating
{
    
    public partial class DiffRatingProgramm : Form
    {
        public DiffRatingProgramm()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Algorithms form = new Algorithms();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DifficultyRating.GraphsThing.GraphsForm form = new GraphsThing.GraphsForm();
            form.ShowDialog();
        }
    }
    public class DifficulityRate
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
        public long totalTime { get; set; }
    }

    public class DifficultyGraph
    {
        public PointPairList OperationsCountGraph = new PointPairList();
        public PointPairList ExecutionTimeGraph = new PointPairList();
        public PointPairList GetGraph(int mode)
        {
            if (mode == 0)
                return OperationsCountGraph;
            else
                return ExecutionTimeGraph;
        }
        public void Add(int x, DifficulityRate diff)
        {
            OperationsCountGraph.Add(x, diff.operationsCount);
            ExecutionTimeGraph.Add(x, diff.totalTime);
        }

    }
}

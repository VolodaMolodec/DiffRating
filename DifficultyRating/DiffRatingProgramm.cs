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
            DifficultyRating.GraphsThing.GraphsForm form = new GraphsThing.GraphsForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DifficultyRating.Tests.TestsForm form = new Tests.TestsForm();
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
        public int operationsCount;
        public long totalTime;
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

    //Чтобы не создавать постоянно переменные Random, используем это.
    static class CustomRandom
    {
        private static Random rnd = new Random();

        public static int Next()
        {
            return rnd.Next();
        }

        public static int Next(int max)
        {
            return rnd.Next(max);
        }

    }


    //Класс, с помощью которого будем измерять затраченное время
    static class CustomWatch
    {
        private static Stopwatch watch = new Stopwatch();

        public static void Stop()
        {
            watch.Stop();
        }
        public static void Start()
        {
            watch.Start();
        }
        public static void Restart()
        {
            watch.Restart();
        }
        public static long Get()
        {
            return watch.ElapsedTicks;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating
{
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
        public int totalTime { get; set; }
    }
    public partial class DiffRatingProgramm : Form
    {
        public DiffRatingProgramm()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DifficultyRating.Lection2.Lection2 form = new DifficultyRating.Lection2.Lection2();
            form.ShowDialog();
        }
    }
}

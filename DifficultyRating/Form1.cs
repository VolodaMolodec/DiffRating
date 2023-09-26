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

namespace DifficultyRating
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private class DifficulityRate
        {
            public DifficulityRate()
            {
                operationsCount = 0;
                totalTime = 0;
            }
            public int operationsCount { get; set; }
            public int totalTime { get; set; }
        }

        private DifficulityRate SelectionSort(int[] _array)
        {
            DifficulityRate diff = new DifficulityRate();
            int[] arr = new int[_array.Length];
            _array.CopyTo(arr, 0);
            int maxId = 0, lastId = arr.Count() - 1;
            while(lastId != 0)
            {
                for (int i = 0; i <= lastId; i++)
                {
                    if (arr[i] > arr[maxId])
                        maxId = i;
                    diff.operationsCount++;
                }
                (arr[maxId], arr[lastId]) = (arr[lastId], arr[maxId]);
                maxId = 0;
                lastId--;
            }
            return diff;
        }

        private void DrawGraph()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Int32.Parse(ElementsInputTextBox.Text);
            int[] arr = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next() % 100;
            DifficulityRate SelectionDiff = SelectionSort(arr);
            SelectionSortOutput.Text = SelectionDiff.operationsCount.ToString();
        }
    }
}

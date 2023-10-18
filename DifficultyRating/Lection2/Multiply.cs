using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.Lection2
{
    public partial class Lection2 : Form
    {
        private DifficulityRate ColumnMult(int a, int b)
        {
            DifficulityRate diff = new DifficulityRate();
            List<int> cellsA = new List<int>();
            List<int> cellsB = new List<int>();
            while(a != 0)
            {
                cellsA.Add(a % 10);
                a /= 10;
            }
            while(b != 0)
            {
                cellsB.Add(b % 10);
                b /= 10;
            }
            int answer = 0, iter = 1;
            foreach(var cellA in cellsA)
            {
                diff.operationsCount++;
                int result = 0, p = 1;
                foreach (var cellB in cellsB)
                {
                    diff.operationsCount++;
                    result += cellA * cellB * p;
                    p *= 10;
                }
                answer += result * iter;
                iter *= 10;
            }
            return diff; 
        }

        private int countDischarge(int n)
        {
            int dischange = 0;
            while(n != 0)
            {
                n /= 10;
                dischange++;
            }
            return dischange;
        }

        private DifficulityRate CoolMult(int a, int b)
        {
            DifficulityRate diff = new DifficulityRate();

            return diff;
        }
    }
}

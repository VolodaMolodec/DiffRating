using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating
{
    class CoolFibonachi
    {
        List<int> memory;
        DifficulityRate diff;
        public DifficulityRate CalcFiboDiff(int N)  //Вызыватся из програмы.
        {
            diff = new DifficulityRate();
            memory = new List<int>( new int[N]);
            if (memory.Count == 0 || memory.Count < N)
                memory.Capacity = N;
            if (N <= 2)
                return diff;
            else if (memory[N - 1] != 0)
                return diff;
            else
            {
                diff.operationsCount++;
                int val = Calc(N - 1) + Calc(N - 2);
                return diff;
            }
        }
        private int Calc(int n) //Вызыватся внутри класса
        {
            if (n <= 2)
                return n;
            else if (memory[n - 1] != 0)
                return memory[n];
            else
            {
                diff.operationsCount++;
                int val = Calc(n - 1) + Calc(n - 2);
                memory[n] = val;
                return val;
            }
        }
    }
    class Fibonnachi
    {
        DifficulityRate diff;
        public DifficulityRate CalcFiboDiff(int N)
        {
            diff = new DifficulityRate();
            diff.operationsCount++;
            if (N <= 2)
                return diff;
            int val = Calc(N - 1) + Calc(N - 2);
            return diff;
        }
        private int Calc(int n)
        {
            if (n <= 2)
                return n;
            diff.operationsCount++;
            return Calc(n - 1) + Calc(n - 2);
        }
    }
}
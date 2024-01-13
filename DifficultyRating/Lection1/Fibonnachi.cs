using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating
{
    static class Fibonachi
    {
        private static DifficulityRate diff;
        private static List<int> memory;

        static public Tuple<int,DifficulityRate> Calc(string name, int N )
        {
            diff = new DifficulityRate();
            int res = -1;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            switch(name)
            {
                case "Advanced":
                    memory = new List<int>(new int[N]);
                    if (memory.Count == 0 || memory.Count < N)
                        memory.Capacity = N;
                    res = AdvancedFibo(N);
                    break;
                case "Slow":
                    res = SlowFibo(N);
                    break;
            }
            watch.Stop();
            diff.totalTime = watch.ElapsedTicks;
            return new Tuple<int, DifficulityRate>(res,diff);
        }

        static private int AdvancedFibo(int n)
        {
            if (n <= 2)
                return n;
            else if (memory[n - 1] != 0)
                return memory[n - 1];
            else
            {
                diff.operationsCount++;
                int val = AdvancedFibo(n - 1) + AdvancedFibo(n - 2);
                memory[n - 1] = val;
                return val;
            }
        }

        static private int SlowFibo(int n)
        {
            if (n <= 2)
                return n;
            diff.operationsCount++;
            return SlowFibo(n - 1) + SlowFibo(n - 2);
        }
    }
}
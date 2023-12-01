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
        private DifficulityRate ColumnMult(int a, int b)    //Обычное умножение столбиком
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

        private static int countDischarge(int n)   //Вычисление кол-ва разрядов
        {
            int dischange = 0;
            while(n != 0)
            {
                n /= 10;
                dischange++;
            }
            return dischange;
        }

        private Tuple<int, DifficulityRate> NaiveRecur(int a, int b)  //Наивный рекурсивный метод.  a и b - числа с одинаковым кол-вом разрядов
        {
            DifficulityRate diff = new DifficulityRate();
            int N = countDischarge(a);  //Вычисляем кол-во разрядов. Поскольку a и b имеют одинаковое ко-во разрядов, то число N будет соответствовать для a и b
            int result = 0;
            if (N <= 1)
            {
                diff.operationsCount++;
                result = a * b;
            }
            else
            {
                diff.operationsCount++;
                int d = (int)Math.Pow(10, N / 2);
                int a1 = a / d, a2 = a % d; //Делим числа на две части
                int b1 = b / d, b2 = b % d;
                var res1 = NaiveRecur(a1, b1);
                var res2 = NaiveRecur(a2, b2);
                var res3 = NaiveRecur(a1 + a2, b1 + b2);
                result = res1.Item1 * (int)Math.Pow(d, 2) //Вычисляем результат
                    + (res3.Item1 - res1.Item1 - res2.Item1) * d
                    + res2.Item1;
                diff += res1.Item2 + res2.Item2 + res3.Item2;   //Добавляем сложность от рекурсий
            }
            return new Tuple<int,DifficulityRate>(result, diff);
        }

        public class CoolMult  //Улучшенный рекурсивный метод умножения
        {
            int[,] data;   //Хранение информации о результатах умножения
            public CoolMult(int N)  //Передаём максимальное ко-во разрядов в числе
            {
                int MaxNumber = 0;
                for(int i = 0; i < N; i++)  //Вычисляем максимально возможное число
                {
                    MaxNumber *= 10;
                    MaxNumber += 9;
                }
                data = new int[MaxNumber, MaxNumber];
            }

            public Tuple<int, DifficulityRate> Mult(int a, int b)  //Наивный рекурсивный метод.  a и b - числа с одинаковым кол-вом разрядов
            {
                DifficulityRate diff = new DifficulityRate();
                int N = countDischarge(a);  //Вычисляем кол-во разрядов. Поскольку a и b имеют одинаковое ко-во разрядов, то число N будет соответствовать для a и b
                int result = 0;
                if (data[a,b] != 0)
                    result = data[a, b];
                else if (N <= 1)
                {
                    diff.operationsCount++;
                    result = a * b;
                    data[a, b] = result;
                }
                else
                {
                    diff.operationsCount++;
                    int d = (int)Math.Pow(10, N / 2);
                    int a1 = a / d, a2 = a % d; //Делим числа на две части
                    int b1 = b / d, b2 = b % d;
                    var res1 = Mult(a1, b1);
                    var res2 = Mult(a2, b2);
                    var res3 = Mult(a1 + a2, b1 + b2);
                    result = res1.Item1 * (int)Math.Pow(d, 2) //Вычисляем результат
                        + (res3.Item1 - res1.Item1 - res2.Item1) * d
                        + res2.Item1;
                    diff += res1.Item2 + res2.Item2 + res3.Item2;   //Добавляем сложность от рекурсий
                    data[a, b] = result;
                }
                return new Tuple<int, DifficulityRate>(result, diff);
            }
        }
    }
}

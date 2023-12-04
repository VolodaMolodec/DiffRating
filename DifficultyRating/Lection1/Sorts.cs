using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.Lection1
{
    static class Sorts
    {
        public static Tuple<List<int>, DifficulityRate> Sort(string name, List<int> array)
        {
            var result = new Tuple<List<int>, DifficulityRate>(new List<int>(), new DifficulityRate());
            Stopwatch watch = new Stopwatch();
            watch.Start();
            switch(name)
            {
                case "SelectionSort":
                    result = SelectionSort(array);
                    break;
                case "QuickSort":
                    result = QuickSort(array);
                    break;
            }
            watch.Stop();
            result.Item2.totalTime = watch.ElapsedTicks;
            return result;
        }

        static Tuple<List<int>, DifficulityRate> SelectionSort(List<int> array)
        {
            DifficulityRate diff = new DifficulityRate();
            int maxId = 0, lastId = array.Count() - 1;
            while (lastId != 0)
            {
                for (int i = 0; i <= lastId; i++)
                {
                    if (array[i] > array[maxId])
                        maxId = i;
                    diff.operationsCount++;
                }
                (array[maxId], array[lastId]) = (array[lastId], array[maxId]);
                maxId = 0;
                lastId--;
            }
            return new Tuple<List<int>, DifficulityRate>(array, diff);
        }
        static Tuple<List<int>, DifficulityRate> QuickSort(List<int> array)
        {
            Random rnd = new Random();
            DifficulityRate diff = new DifficulityRate();

            if (array.Count() <= 1)
                return new Tuple<List<int>, DifficulityRate>(array, new DifficulityRate());
            
            int index = rnd.Next() % array.Count(); //Получаем индекс случайного элемента
            List<int> arrLeft = new List<int>();    //Создаём списки для левой и правой части
            List<int> arrRight = new List<int>();
            for (int i = 0; i < array.Count; i++)
            {
                diff.operationsCount++;
                if (i == index)
                    continue;
                if (array[i] >= array[index])
                    arrRight.Add(array[i]);
                else
                    arrLeft.Add(array[i]);
            }
            var result1 = QuickSort(arrLeft);   //Получаем результаты от рекурсивного вызова для левой и правой части
            var result2 = QuickSort(arrRight);
            diff += result1.Item2;
            diff += result2.Item2;
            List<int> resList = result1.Item1;
            resList.AddRange(result2.Item1);
            return new Tuple<List<int>, DifficulityRate>(resList, diff);
        }
    }
}

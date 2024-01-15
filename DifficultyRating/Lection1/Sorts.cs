using DifficultyRating.GraphsThing;
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
        public static Tuple<List<int>, DifficulityRate> SelectionSort(List<int> array)
        {
            DifficulityRate diff = new DifficulityRate();
            CustomWatch.Start();
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
            CustomWatch.Stop();
            diff.totalTime = CustomWatch.Get();
            return new Tuple<List<int>, DifficulityRate>(array, diff);
        }
        public static Tuple<List<int>, DifficulityRate> MergeSort(List<int> array)
        {
            DifficulityRate diff = new DifficulityRate();
            CustomWatch.Start();

            if (array.Count() <= 1)
                return new Tuple<List<int>, DifficulityRate>(array, new DifficulityRate());
            
            int index = CustomRandom.Next() % array.Count(); //Получаем индекс случайного элемента
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
            var result1 = MergeSort(arrLeft);   //Получаем результаты от рекурсивного вызова для левой и правой части
            var result2 = MergeSort(arrRight);
            diff += result1.Item2;
            diff += result2.Item2;
            List<int> resList = result1.Item1;
            resList.Add(array[index]);
            resList.AddRange(result2.Item1);
            CustomWatch.Stop();
            diff.totalTime = CustomWatch.Get();
            return new Tuple<List<int>, DifficulityRate>(resList, diff);
        }

        static public Tuple<List<int>, DifficulityRate> HeapSort(List<int> input)
        {
            DifficulityRate diff = new DifficulityRate();
            Heap heap = new Heap();
            CustomWatch.Start();
            foreach (var x in input)    //Закидываем данные из входящего списка в кучу
            {
                diff.operationsCount++;
                diff += heap.Add(x, x); //Было лень писать отдельный метод с одним параметром, поэтому так
            }
            List<int> output = new List<int>();
            while (!heap.IsEmpty())     //Достаём из кучи данные и записываем в список
                output.Insert(0, heap.GetTop());

            CustomWatch.Stop();
            diff.totalTime = CustomWatch.Get();
            return new Tuple<List<int>, DifficulityRate>(output, diff);

        }
    }
}

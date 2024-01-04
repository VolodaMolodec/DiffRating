using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.Lection2
{
    static class Median
    {
        static Tuple<int,DifficulityRate> RandomMedianDiff(List<int> arr, int elementNum = -1)
        {
            DifficulityRate diff = new DifficulityRate();

            if (arr.Count == 1)
                return new Tuple<int,DifficulityRate>(arr[0], diff);

            if (elementNum == -1)   //Если у нас не определено местоположение медианы, то определяем его
                elementNum = arr.Count / 2;

            Random rnd = new Random();
            int val = arr[rnd.Next(0, arr.Count())];    //Берём случайное значение из массива
            List<int> Left = new List<int>(), Center = new List<int>(), Right = new List<int>();
            foreach (var iter in arr)    //Сортируем исходный массив по трём массивам
            {
                if (iter < val)
                    Left.Add(iter);
                else if (iter == val)
                    Center.Add(iter);
                else
                    Right.Add(iter);
                diff.operationsCount++;
            }

            var result = new Tuple<int, DifficulityRate>(0, new DifficulityRate());
            if (Left.Count + Center.Count < elementNum) //Вызываем функцию рукурсивно для нужного массива
                result = RandomMedianDiff(Right, elementNum - Left.Count - Center.Count);
            else if (Left.Count < elementNum)
                result = RandomMedianDiff(Center, elementNum - Left.Count);
            else
                result = RandomMedianDiff(Left, elementNum);

            return new Tuple<int,DifficulityRate>(result.Item1, result.Item2 + diff);
        }

    }
    
}

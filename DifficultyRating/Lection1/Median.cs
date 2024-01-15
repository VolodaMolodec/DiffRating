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
        //Поиск медианы 
        static public Tuple<int,DifficulityRate> RandomMedian(List<int> arr, int elementNum = -1)
        {
            DifficulityRate diff = new DifficulityRate();
            if (arr.Count == 1)
                return new Tuple<int,DifficulityRate>(arr[0], diff);

            if (elementNum == -1)   //Если у нас не определено местоположение медианы, то определяем его
                elementNum = arr.Count / 2;

            int val = arr[CustomRandom.Next(0, arr.Count())];    //Берём случайное значение из массива
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

            //Если остались только одинаковые элементы, то возвращаем любой из них дял предотвращения переполнения стека рекурсии
            if (Left.Count == 0 && Right.Count == 0 && Center.Count != 0)
                return new Tuple<int, DifficulityRate>(arr[0], diff);

            Tuple<int, DifficulityRate> result;
            if (Left.Count + Center.Count <= elementNum) //Вызываем функцию рукурсивно для нужного массива
                result = RandomMedian(Right, elementNum - Left.Count - Center.Count);
            else if (Left.Count <= elementNum)
                result = RandomMedian(Center, elementNum - Left.Count);
            else
                result = RandomMedian(Left, elementNum);

            return new Tuple<int,DifficulityRate>(result.Item1, result.Item2 + diff);
        }

    }
    
}

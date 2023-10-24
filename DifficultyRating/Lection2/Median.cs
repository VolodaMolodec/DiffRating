using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.Lection2
{
    public partial class Lection2 : Form
    {
        DifficulityRate RandomMedianDiff(List<int> arr, int elementNum = -1)
        {
            DifficulityRate diff = new DifficulityRate();

            if (arr.Count <= 1)
                return diff;

            if (elementNum == -1)   //Если у нас не определено местоположение медианы, то определяем его
                elementNum = arr.Count / 2;

            Random rnd = new Random();
            int val = arr[rnd.Next(0, arr.Count())];    //Берём случайное значение из массива
            List<int> Left = new List<int>(), Center = new List<int>(), Right = new List<int>();
            foreach(var iter in arr)    //Сортируем исходный массив по трём массивам
            {
                if (iter < val)
                    Left.Add(iter);
                else if (iter == val)
                    Center.Add(iter);
                else
                    Right.Add(iter);
                diff.operationsCount++;
            }

            if (Left.Count + Center.Count < elementNum) //Вызываем функцию рукурсивно для нужного массива
                diff += RandomMedianDiff(Right, elementNum - Left.Count - Center.Count);
            else if (Left.Count < elementNum)
                diff += RandomMedianDiff(Center, elementNum - Left.Count);
            else
                diff += RandomMedianDiff(Left, elementNum);

            return diff;
        }
    }
}

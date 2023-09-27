using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating
{
    public partial class Form1 : Form
    {
        private DifficulityRate SelectionSort(List<int> array)
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
            return diff;
        }
        private DifficulityRate QuickSort(List<int> array)
        {
            if (array.Count() <= 1)
                return new DifficulityRate { operationsCount = 0, totalTime = 0 };
            DifficulityRate diff = new DifficulityRate();
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
            diff = diff + QuickSort(arrLeft);
            diff = diff + QuickSort(arrRight);
            return diff;
        }
    }
}

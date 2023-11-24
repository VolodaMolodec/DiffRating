using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyRating.GraphsThing
{
    public partial class GraphsForm : Form
    {
        class Heap
        {
            class Vertex
            {
                public int value;
                public Vertex lefVert;
                public Vertex rightVert;
                public Vertex()
                {
                    value = -1;
                    lefVert = null;
                    rightVert = null;
                }
                public void Init(int val)
                {
                    value = val;
                    lefVert = new Vertex();
                    rightVert = new Vertex();
                }
            }

            private Vertex topVert = new Vertex();

            public int getTop()
            {
                //if (topVert.value == -1)
                //    return -1;
                //int res = topVert.value;
                //if (topVert.lefVert.value == -1) topVert = topVert.rightVert;
                //else if (topVert.rightVert.value == -1) topVert = topVert.lefVert;
                //else if(topVert.lefVert.value > topVert.rightVert.value)
                //{

                //}
              
                //return res;
            }

            public void Add(int val)    //Добавление значения в кучу
            {
                List<Vertex> queue = new List<Vertex>   
                {
                    topVert
                };
                while(queue.Count != 0)
                {
                    Vertex currVert = queue[0];
                    if (currVert.value == -1)
                    {
                        currVert.Init(val);
                        break;
                    }
                    else if(currVert.value < val) 
                    {
                        Vertex newVert = new Vertex();  //Сложная схема из-за C#. Если кратко, то создаём новый участок памяти, передаём ему все значения текущей области памяти
                        newVert.Init(currVert.value);   //А текущей области памяти передаём новые значения
                        newVert.lefVert = currVert.lefVert;
                        newVert.rightVert = currVert.rightVert;
                        currVert.lefVert = newVert;
                        currVert.rightVert = new Vertex();
                        currVert.value = val;
                        break;
                    }
                    else
                    {
                        queue.Add(currVert.lefVert);
                        queue.Add(currVert.rightVert);
                    }
                    queue.RemoveAt(0);      
                }
            }
        }
    }
}

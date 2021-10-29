
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        public static int[] array;
        public static int count;
        public static int summ;
        public static int max = 0;
        public static int max_i = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов в массиве");
            count = Convert.ToInt32(Console.ReadLine());
            array = new int[count];

            Task task1 = new Task(Generation);
            Task task2 = task1.ContinueWith(Output);
            Task task3 = task2.ContinueWith(Process);
            task1.Start();
            Console.ReadKey();
        }

        static void Generation()
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                array[i] = random.Next(-100, 100);
            }
        }

        static void Output(Task obj)
        {
            Console.WriteLine();
            Console.WriteLine($"Сформирован массив из {count} элементов:");
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void Process(Task obj)
        {
            for (int i = 0; i < count; i++)
            {
                summ += array[i];
                if (array[i] > max)
                {
                    max = array[i];
                    max_i = i;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сумма элементов массива = {0}", summ);
            Console.WriteLine($"Максимальный элемент массива = {max}, она находится на {max_i+1}-ом месте");
        }


    }
}

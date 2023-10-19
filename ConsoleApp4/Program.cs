using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        internal interface ICalc2
        {
            int CountDistinct();
            int EqualToValue(int valueToCompare);
        }

        internal class MyArray 
        {
            int[] _array;
            public MyArray(int[] array) { _array = array; }
            public MyArray() { _array = new int[0]; }
            public MyArray(int arrayLength) //конструктор с рандомайзером
            {
                if (arrayLength < 0) throw new IndexOutOfRangeException("Array length can`t be less than zero!");
                _array = new int[arrayLength];
                Random r = new Random();
                for (int i = 0; i < arrayLength; i++)
                    _array[i] = r.Next(0, 11);
            }
            public override string ToString()
            {
                StringBuilder temp = new StringBuilder();
                temp.Capacity = _array.Length;

                foreach (var item in _array)
                    temp.Append(item + "; ");
                return Convert.ToString(temp);
            }

            public int CountDistinct()
            {
                if (_array.Length == 1) return 1;
                bool isUnique;
                int count = 0;

                for (int i = 0; i < _array.Length; i++)
                {
                    isUnique = true;
                    for (int j = 0; j < _array.Length; j++)
                    {
                        if (i == j) continue;
                        if (_array[i] == _array[j])
                        {
                            isUnique = false;
                            break;
                        }
                    }
                    if (isUnique)count++; //, Console.WriteLine(_array[i]);  //Отладка для проверки корректности работы алгоритма
                }
                return count;
            }

            public int EqualToValue(int valueToCompare)
            {
                int temp = 0;
                foreach (int item in _array)
                    if (item == valueToCompare) temp++;
                return temp;
            }
        }

        static void Main(string[] args)
        {
            MyArray test = new MyArray(10);
            Console.WriteLine(test);

            Console.WriteLine("Amount of unique elements in the array is " + test.CountDistinct());
            Console.WriteLine("Amount of elements equals to the 0 is " + test.EqualToValue(0));
        }
    }
}

using System;
using System.Linq;

namespace algoritmTest
{
    class Program
    {
        static  int[][] Function(int[] values, int result)
        { int Ind = 0;
            int[][] otvet = new int[values.Length- 1][];
            foreach (var b in values)
            {
                var chislo2 = result - b;
                var num = Array.IndexOf(values, chislo2);
                if (num != -1)
                {
                    var mass = new int[2] { Array.IndexOf(values, b), num }.OrderBy(x=>x).ToArray();

                    if (Array.IndexOf(otvet, mass) == -1)
                    {
                        otvet[Ind] = mass;
                        Ind++;
                    }
                }



            }

            otvet = otvet.Where(x => x != null).ToArray();

                return (otvet);
        }

        static void Main(string[] args)
        {int[] number = new int[] { 3, 5, 8, 7,2 };
            int sum = 7;
            var otvet = Function(number,sum);
            foreach (var f in otvet)
            {
                foreach (var b in f) Console.Write($"{b} ");
                Console.WriteLine();
            }
        }
    }
}

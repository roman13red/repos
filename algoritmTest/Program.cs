using System;
using System.Linq;

namespace algoritmTest
{
    class Program
    {
        static  int[] Function(int[] values, int result)
        {
            int[] otvet = new int[1];
            foreach (var b in values)
            {
                var chislo2 = result - b;
                var num = Array.IndexOf(values, chislo2);
                if (num != -1 & Array.IndexOf(values, chislo2)!= Array.IndexOf(values, b))
                {
                     otvet = new int[2] { Array.IndexOf(values, b), num }.OrderBy(x=>x).ToArray();

                    break;
                }



            }
            
            
            return (otvet);
        }

        static void Main(string[] args)
        {int[] number = new int[] { 3, 2 ,4};
            int sum = 6;
            var otvet = Function(number,sum);
            foreach (var f in otvet)
            {
                 Console.Write($"{f} ");
                
            }
        }
    }
}

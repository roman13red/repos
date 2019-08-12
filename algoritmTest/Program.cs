using System;
using System.Collections.Generic;
using System.Linq;

namespace algoritmTest
{
    static public class Program
    {
        static public int[] Function(int[] values, int result)
        {
            int[] otvet = new int[1];
            foreach (var b in values)
            {
                var chislo2 = result - b;
                var num = Array.IndexOf(values, chislo2);
                if (num != -1 & Array.IndexOf(values, chislo2) != Array.IndexOf(values, b))
                {
                    otvet = new int[2] { Array.IndexOf(values, b), num }.OrderBy(x => x).ToArray();

                    break;
                }



            }


            return (otvet);
        }

        static public void FunctionText1(ref string s ,ref List<int> Otvet)
        {
            int x=0;
            int charCount = s.Count();
            string str = "";
            foreach (var charS in s)
            {
                x++;
                if (str.Contains(charS) == true)
                {
                    Otvet.Add(str.Count());
                    s = s.Remove(0, str.IndexOf(charS) + 1);
                    break;
                }
                else
                {
                    str = str + charS;
                }
            }
            if (x == charCount)
            {
                Otvet.Add(str.Count());
            }
            else
            {
                FunctionText1(ref s, ref Otvet);
            }

            
        }
        static public int FunctionText2(string s)
        {
            List<int>  otvet = new List<int> { };
            s=s.ToLower();
            FunctionText1(ref s, ref otvet);

            return(otvet.Max());
        }


        static void Main(string[] args)
        {
            string s = "wertywiop][op ldlf";
                 Console.Write(FunctionText2(s));
                
           
        }
    }
}

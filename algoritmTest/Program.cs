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
                var num = 0;
                //var testNotDouble = values.ToList();
                //var testDouble=testNotDouble.RemoveAt(Array.IndexOf(values, b));
                var chislo2 = result - b;
                if (chislo2 == b)
                {
                   
                  var doubleNot = values.ToList();
                  doubleNot[Array.IndexOf(doubleNot.ToArray(), b)] = 0;
                  num= Array.IndexOf(doubleNot.ToArray(), chislo2);
                  doubleNot.Clear();
                }
                else
                {
                     num = Array.IndexOf(values.ToArray(), chislo2);
                }
                if (num != -1)
                {
                    otvet = new int[2] { Array.IndexOf(values, b), num }.ToArray();

                    break;
                }



            }


            return (otvet);
        }

        static public void FunctionTextRecurs(ref string s ,ref List<int> Otvet)
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
                FunctionTextRecurs(ref s, ref Otvet);
            }

            
        }
        static public int FunctionTextAnswer(string s)
        {
            List<int>  otvet = new List<int> { };
            s=s.ToLower();
            FunctionTextRecurs(ref s, ref otvet);

            return(otvet.Max());
        }
        static public int FunctionTextWhile(string line)
        {
            line = line.ToLower();
            List<int> Otvet=new List<int>();
            string str = "";
            int x = 0;
            int countLine = line.Count();
            do
            {
                char chars = line[x];
                if (str.Contains(chars) == true)
                {
                    Otvet.Add(str.Count());
                    str = "";
                }
                else
                {
                    str = str + chars;
                    x++;
                }
                if (x == countLine)
                {
                    Otvet.Add(str.Count());
                }
            }
            while (x!= countLine);

            return(Otvet.Max());

        }


        static void Main(string[] args)
        {
            var s = "wertyWWiiop[ppiuu";
            var m = FunctionTextWhile(s);

                Console.Write(m);
            
                
                
           
        }
    }
}

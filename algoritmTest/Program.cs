﻿using System;
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

                var chislo2 = result - b;
                if (chislo2 == b)
                {

                    var doubleNot = values.ToArray();
                    doubleNot[Array.IndexOf(doubleNot, b)] = 0;
                    num = Array.IndexOf(doubleNot, chislo2);
                    Array.Clear(doubleNot, 0, doubleNot.Length);
                }
                else
                {
                    num = Array.IndexOf(values, chislo2);
                }
                if (num != -1)
                {
                    otvet = new int[2] { Array.IndexOf(values, b), num };

                    break;
                }



            }


            return (otvet);
        }
        static public int[] FunctionNumber(int[] values, int result)
        {
            int[] otvet = new int[1];

            for(int i=0;i<values.Count();i++)
            {
          

                var residue = result - values[i];

                for (int j = 0; j < values.Count(); j++)
                {
                    if (values[j] == residue & j != i)
                    {
                        otvet = new int[2] { i, j };
                    }

                }


                //    if (chislo2 == b)
                //{

                //    var doubleNot = values.ToArray();
                //    doubleNot[Array.IndexOf(doubleNot, b)] = 0;
                //    num = Array.IndexOf(doubleNot, chislo2);
                //    Array.Clear(doubleNot, 0, doubleNot.Length)
                //}
                //else
                //{
                //    num = Array.IndexOf(values.ToArray(), chislo2);
                //}
                //if (num != -1)
                //{
                //    otvet = new int[2] { Array.IndexOf(values, b), num }.ToArray();

                //    break;
                //}



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
            List<int> Otvet = new List<int>();
            string str = "";
            int x = 0;
            int countLine = line.Count();
            do
            {
                if (countLine != 0)
                {
                    if (str.Contains(line[x]) == true)
                    {
                        Otvet.Add(str.Count());
                        str = "";
                        x = line.IndexOf(line[x]) + 1;
                        for (int i = 0; i < line.IndexOf(line[x]); i++)
                        {
                            if (line[x] != '#')
                            {
                                line = line.Remove(i, 1).Insert(i, "#");
                            }
                            else
                            {
                                line = line.Remove(i, 1).Insert(i, "&");
                            }
                        }

                    }
                    else
                    {
                        str = str + line[x];
                        x++;
                    }
                    if (x == countLine)
                    {
                        Otvet.Add(str.Count());
                    }
                }
                else { Otvet.Add(0); }

            }
            while (x != countLine);

            return (Otvet.Max());

        }

        static void Main(string[] args)
        {
            var s = "abcabcbb";
            var m = FunctionTextWhile(s);

                Console.Write(m);
            
                
                
           
        }
    }
}

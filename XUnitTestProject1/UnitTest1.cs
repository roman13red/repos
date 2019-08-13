using System;
using Xunit;

using System.Linq;
using System.Collections.Generic;

namespace XUnitTestProject1
{
    public class UnitTest1
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

                    var doubleNot = values.ToList();
                    doubleNot[Array.IndexOf(doubleNot.ToArray(), b)] = 0;
                    num = Array.IndexOf(doubleNot.ToArray(), chislo2);
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


        static public int FunctionTextWhile(string line)
        {
            line = line.ToLower();
            List<int> Otvet = new List<int>();
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
            while (x != countLine);

            return (Otvet.Max());

        }

        [Theory]
        [InlineData(new int[]{1, 3, 4, 5, 6, 11,1, 8, 9, 10},2 , new int[] { 0,6})]
        [InlineData(new int[] {10,2,3,4,5,6,1,3,3,2}, 8,new int[] {1,5})]
        [InlineData(new int[] { 12, 2, 3, 4, 5, 6, 10, 8, 9, 12 }, 12, new int[] { 1, 6 })]
        public void Test1(int[] values, int result, int[] test)
        {
            Assert.Equal(test, Function(values, result));
        }


        [Theory]
        [InlineData("wertyWWiiop[ppiuu",5)]
        [InlineData("lwehqrnvoitiyweyrtytytywnfddx",11)]
        [InlineData("vnbiruycpq3I848V645RYFEYFYFIOW5642CQE[XY2VADMD",14)]


        public void Test2(string s,int maxNumber)
        {
            Assert.Equal(maxNumber, FunctionTextWhile(s));
        }
    }
}

using System;
using Xunit;
using algoritmTest;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[]{1, 2, 3, 4, 5, 6, 11, 8, 9, 10},12 )]
        [InlineData(new int[] {10,2,3,4,5,6,12}, 22)]
        [InlineData(new int[] { 90, 2, 3, 4, 5, 6, 10, 8, 9, 10 }, 100)]
        public void Test1(int[] values, int result)
        {
            Assert.Equal(new int[] {0,6}, Program.Function(values, result));
        }


        [Theory]
        [InlineData("wertyWWiiop[ppiuu")]
        [InlineData("dfghdjjlkl")]
        [InlineData("asdffgrty")]


        public void Test2(string s)
        {
            Assert.Equal(5,Program.FunctionText2(s));
        }
    }
}

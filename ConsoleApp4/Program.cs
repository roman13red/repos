using System;

namespace ConsoleApp4
{
    public class animal
    {
        public string name;
        public  animal(string name)
         {
            this.name = name;
         }

    }
    class Program
    {
        static void Main(string[] args)
        {

            var t = new animal("stor");
            Console.WriteLine(t.name);

        }
    }
}

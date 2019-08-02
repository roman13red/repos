using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new NpgsqlConnection("Server=10.179.72.206;Port=5432;Username=root;Password=1;Database=cmsdatabase;"))
            {
                string sql = "select * from data.container; ";
                var containerList = connection.Query<ContainerEntity>(sql).ToList();

                return containerList;
            }
        }
    }
}

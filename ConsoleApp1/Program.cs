using Dapper;
using Npgsql;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//using System.Linq.Expressions;
//using Dapper.Extensions.Linq.Builder;
//using Dapper.Extensions.Linq.Core;
//using Dapper.Extensions;
//using MicroOrm.Dapper.Repositories;
//using System.Data.Linq.Mapping;
//using System.Data.Linq;
namespace DapperOrm
{

    public class worker
    {

        public int id { get; set; }
        public string name { get; set; }
        public int nach { get; set; }

    }

    public class work_doc
    {

        public int id { get; set; }
        public string work { get; set; }
        public string doc { get; set; }


    }
    public class documents
    {

        public int id { get; set; }
        public string namedoc { get; set; }



    }
    class Program
    {
        //static string connectionString = "Persist Security Info=False;Integrated Security=SSPI;database=work ;server=localhost ;Connect Timeout=30";
        //"Server=localhost;Port=5432;Username=postgres;Password=246101626ROMANkutkin;Database=work;";

        static List<worker> CreateWorker()
        {
            using (NpgsqlConnection cn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=246101626ROMANkutkin;Database=work;"))
            {
                cn.Open();
                var work = cn.ExecuteReader("select top 100 * from worker where workers.id<4000 ; ");

                List<worker> workerList = new List<worker>(0);

                while (work.Read())
                {
                    workerList.Add(new worker() { id = (int)work[0], name = work[1].ToString() });
                    //Console.WriteLine($"id {worker[(int)work[0] - 1].id} Name {worker[(int)work[0] - 1].name}");

                }

                ////var selectedUsers = from worker in workerList
                ////                    where worker.id > 25
                ////                    select worker;
                foreach (worker worker in workerList)
                    Console.WriteLine("{0} - {1} - {2}", worker.id, worker.name, worker.nach);
                return workerList;
            }


        }


        static List<documents> CreateDoc()
        {
            using (NpgsqlConnection cn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=246101626ROMANkutkin;Database=work;"))
            {
                cn.Open();
                var doc = cn.ExecuteReader("select * from documents ; ");

                List<documents> docList = new List<documents>(0);

                while (doc.Read())
                {
                    docList.Add(new documents() { id = (int)doc[0], namedoc = doc[1].ToString() });
                    //Console.WriteLine($"id {worker[(int)work[0] - 1].id} Name {worker[(int)work[0] - 1].name}");

                }
                return docList;
            }


        }

        static List<work_doc> CreateDocWork()
        {
            using (NpgsqlConnection cn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=246101626ROMANkutkin;Database=work;"))
            {
                cn.Open();
                var work_doc = cn.ExecuteReader("select * from work_doc  ; ");

                List<work_doc> WorkDocList = new List<work_doc>(0);

                while (work_doc.Read())
                {
                    WorkDocList.Add(new work_doc() { id = (int)work_doc[0], work = work_doc[1].ToString(), doc = work_doc[2].ToString() });
                    //Console.WriteLine($"id {worker[(int)work[0] - 1].id} Name {worker[(int)work[0] - 1].name}");

                }
                return WorkDocList;
            }


        }



        static void Main(string[] args)
        {
            long[] times = new long[11];
            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < times.Length; i++)
            {

                List<worker> workList = CreateWorker();
                List<documents> docList = CreateDoc();
                List<work_doc> doc_work = CreateDocWork();

                watch.Start();
                var selectedUsers = (from workers in workList
                                     join docwork in doc_work on workers.id.ToString() equals docwork.work
                                     join docum in docList on docwork.doc equals docum.id.ToString()
                                     where workers.id < 100000

                                     select workers).ToList();


                watch.Stop();
                times[i] = watch.ElapsedMilliseconds;
                watch.Reset();
            }
            Console.WriteLine((times.Sum() - times[0]) / 10);
            Console.ReadKey();

        }



        //using (var conn = new NpgsqlDataAdapter("Server=localhost;Port=5432;Username=postgres;Password=246101626ROMANkutkin;Database=work;"))
        //{
        //    conn.Open();
        //    DataContext db = conn.DataSource.; 
        //    Table < worker> worker =("select * from worker ");
        //    foreach (var work in worker)
        //    {
        //        Console.WriteLine("{0} \t{1} \t{2}", work.Id, work.name);
        //    }

        //    Console.Read();
        //}
        //Console.WriteLine("Start");

        //long[] times = new long[11];

        //int cnt = 10;

        //using (var conn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=246101626ROMANkutkin;Database=work;"))
        //{
        //    Stopwatch watch = new Stopwatch();

        //    ////conn.Open();
        //    ////var select = conn.ExecuteReader("select * " +
        //    ////            "from worker " +
        //    ////            "inner join work_doc on work_doc.work= worker.id " +
        //    ////            "inner join documents on documents.id = work_doc.doc " +
        //    ////            "ORDER BY worker.id ASC LIMIT 100000;  ");
        //    ////Console.WriteLine();
        //    //for (int i = 0; i < times.Length; i++)
        //    //{
        //    //    watch.Start();

        //    //    conn.Execute("select * " +
        //    //            "from worker " +
        //    //            "inner join work_doc on work_doc.work= worker.id " +
        //    //            "inner join documents on documents.id = work_doc.doc " +
        //    //            "ORDER BY worker.id ASC LIMIT 100;  ");

        //    //    watch.Stop();

        //    //    times[i] = watch.ElapsedMilliseconds;

        //    //    watch.Reset();
        //    //}
        //}

        //Console.WriteLine((times.Sum() - times[0]) / 10);

        //Console.WriteLine("Finish");


    }
}

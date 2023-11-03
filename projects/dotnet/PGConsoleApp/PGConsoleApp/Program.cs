using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PGConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var entityFramework = true;
            if (entityFramework)
            {
                var st=DateTime.Now;
                var films = new PGDatabaseService().GetFilms();
                var et=DateTime.Now;
                var dif = (et - st).Milliseconds;
                Console.WriteLine($"dif: {dif}");
                foreach (var item in films)
                {
                    Console.WriteLine($"EF Title: {item.Title}") ;
                }
            }
            else
            {
                var sql = $"select * from film";
                var st = DateTime.Now;
                var ds = new PGDatabase().ExecuteSQLStatement(sql);
                var et = DateTime.Now;
                var dif = (et - st).Milliseconds;
                Console.WriteLine($"dif: {dif}");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var title = (dr["Title"] == DBNull.Value) ? "" : Convert.ToString(dr["Title"]);
                    Console.WriteLine($"DR Title: {title}");
                }
            }
            Console.Read();
        }
    }
}

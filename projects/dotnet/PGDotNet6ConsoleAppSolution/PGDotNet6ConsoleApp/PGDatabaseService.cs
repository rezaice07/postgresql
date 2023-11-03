using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGDotNet6ConsoleApp
{

    [Table("film")]
    public class Film
    {
        [Key]
        [Column("film_id")]
        public int Film_Id { get; set; }
        [Column("title")]
        public string Title { get; set; }

    }
    public class DvdRentalContext : DbContext //using System.Data.Entity;
    {
        public DbSet<Film> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;user id=usera; password=123; database=dvdrental;");
        }       
    }

    public class PGDatabaseService
    {
        public PGDatabaseService()
        {
        }
        public List<Film> GetFilms()
        {
            try
            {
                var db = new DvdRentalContext();
                var films = db.Films.ToList();

                return films;
            }
            catch
            {
                return new List<Film>();
            }
        }
    }
}

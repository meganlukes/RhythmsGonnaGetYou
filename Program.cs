using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RhythmsGonnaGetYou
{

    class Band
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public int ContactNumber { get; set; }
    }
    class RhythmContext : DbContext
    {
        public DbSet<Band> Band { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=Rhythm");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmContext();
            var band = context.Band;
            Console.WriteLine("Welcome to C#");
        }
    }
}

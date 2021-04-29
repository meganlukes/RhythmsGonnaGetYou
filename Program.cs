using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RhythmsGonnaGetYou
{

    class Bands
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
        public DbSet<Bands> Band { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=Rhythm");
        }
    }
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            var userInputAsNumber = int.Parse(userInput);
            return userInputAsNumber;
        }
        static void Main(string[] args)
        {
            var context = new RhythmContext();
            var band = context.Band;
            /* var quitProgram = false;
             while (quitProgram == false)
             {
                 //menu
                 Console.WriteLine("Welcome to the Rhythm database.");
                 Console.WriteLine("Would you like to (1)Add a new band, (2)View all the bands, (3)Add an album for a band,(4)Add a song to an album, (5)Let a band go, (6)Resign a band, (7)View all the albums of a band, (8)View all albums ordered by release date, (9)View all bands that are signed, (10)View all bands that are not signed, or (11)Quit?");
                 var selection = PromptForInteger("");
                 switch (selection)
                 {
                     case 1:    //Add a new band

                         break;
                     case 2:    //View all bands
                       */
            foreach (var bands in band)
            {
                Console.WriteLine(bands.Name);
            } /*
                        break;
                    case 3:    //Add an album
                        break;
                    case 4:   //Add a song
                        break;
                    case 5:   //Change IsSigned to false
                        break;
                    case 6:   //Change IsSigned to true
                        break;
                    case 7:    //View all albums for band
                        break;
                    case 8:    //View all albums ordered by release date
                        break;
                    case 9:    //View all signed bands
                        break;
                    case 10:   //View all unsigned bands
                        break;
                    case 11:   //Quit
                        quitProgram = true;
                        break; 
                }
            }
*/
        }
    }
}

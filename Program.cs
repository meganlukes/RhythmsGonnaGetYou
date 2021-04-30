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
        public float ContactNumber { get; set; }
        public List<Album> Albums { get; set; }
    }
    class Album
    {
        public int ID { get; set; }
        public int BandID { get; set; }
        public Band Band { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Song> Songs { get; set; }
    }
    class Song
    {
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public float Duration { get; set; }
    }
    class RhythmContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
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
        static float PromptForFloat(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            var userInputAsNumber = float.Parse(userInput);
            return userInputAsNumber;
        }
        static void Main(string[] args)
        {
            var context = new RhythmContext();
            var band = context.Bands;
            var album = context.Albums.Include(album => album.BandID);
            var song = context.Songs.Include(song => song.AlbumID);


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
                     
            var bandname = PromptForString("What is the new band's name?   ");
            var country = PromptForString($"What is {bandname}'s country of origin?   ");
            var members = PromptForInteger($"How many members does {bandname} have?   ");
            var website = PromptForString($"What is {bandname}'s website?   ");
            var style = PromptForString($"What style is {bandname}?   ");
            var signed = false;
            int signedint = 0;
            while (signedint != 1 && signedint != 2)
            {
                signedint = PromptForInteger($"Is {bandname} currently signed? 1 for yes, 2 for no.   ");
                if (signedint == 1)
                {
                    signed = true;
                }
                else if (signedint == 2)
                {
                    signed = false;
                }
                else
                {
                    Console.WriteLine("I'm sorry, I don't recognize that selection.");
                }
            }
            var contactname = PromptForString($"Who is the contact for {bandname}?   ");
            var contactnumber = PromptForFloat($"What is {contactname}'s phone number? Digits only    ");
            var newBand = new Band
            {
                Name = bandname,
                CountryOfOrigin = country,
                NumberOfMembers = members,
                Website = website,
                Style = style,
                IsSigned = signed,
                ContactName = contactname,
                ContactNumber = contactnumber
            };
            context.Bands.Add(newBand);
            context.SaveChanges();
            
                break;
            case 2:    //View all bands

             foreach (var bands in band)
             {
              Console.WriteLine(bands.Name);
              } 
             break;
           case 3:    //Add an album */
            var title = PromptForString("What is the album's name?   ");
            var bandName = PromptForString("What is the band's name?   ");
            var thisBand = context.Bands.FirstOrDefault(band => band.Name == bandName);
            var bandID = thisBand.ID;
            string stringExplicit = "f";
            stringExplicit = PromptForString("Is the album explicit? Y or N   ");
            bool explicit;
            if (stringExplicit == "Y")
        {
             explicit == true;
            }
            else {
               explicit == false;
           }
var year = PromptForInteger("In what year was the album released?   ");
var month = PromptForInteger("In what month was the album released? Use MM   ");
var day = PromptForInteger("On what day was the album released?   ")
           var releaseDate = new DateTime(year, month, day);
var newAlbum = new Album
{
    BandID = bandID;
Title = title;
IsExplicit = explicit;
                ReleaseDate = releaseDate;
           }
            context.Albums.Add(newAlbum);
context.SaveChanges(); 
            /*
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
               break; */
        }
   }
}
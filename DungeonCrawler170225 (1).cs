using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonCrawler
{
    class Program
    {

        
        static void Main(string[] args)
        {
            int attempt = 1;
            while (true) 
            {
                if (attempt > 1)
                {
                    Console.WriteLine("\x1b[3J");
                    Console.Clear();
                    Console.WriteLine("Would you like to play again?");
                    while (true)
                    {
                        string nextAnswer = Console.ReadLine().Trim().ToLower();
                        if (nextAnswer == "yes" || nextAnswer == "y")
                        {

                            break;

                        }
                        else if (nextAnswer == "no" || nextAnswer == "n")
                        {
                            Console.WriteLine("Thanks for playing!");
                            System.Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Please enter 'yes' or 'no'");

                        }
                    }
                }
                bool music = false;
                Game CurseBreaker = new Game($"CurseBreaker ~ game {attempt}", music, false);
                music = CurseBreaker.MusicOnOff();
                Console.WriteLine("Would you like to load a save game?");
                if (Dialogue.getYesNoResponse(true))
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string filePath = Path.Combine(path, $"CurseBreaker\\Saves");
                    if (Directory.Exists(filePath) && Directory.EnumerateFiles(filePath).Any())
                    {
                        CurseBreaker.Load = true;
                    }
                    else
                    {
                        Console.WriteLine("Error! You have no saves that you can load yet.");
                        Console.ReadKey(true);
                    }
                }
                CurseBreaker.Start(music);
                attempt++;
            }
        }
        
        
        

        
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class ArchFey : Dialogue
    {
        Player Player { get; set; }
        Monster Monster { get; set; }
        Combat Race { get; set; }
        Room Room { get; set; }
        ArchFey(Player player, Monster monster, Combat race, Room room) : base(player, room)
        {
            Player = player;
            Monster = monster;
            Race = race;
            Room = room;
        } 

        /*
        static public bool ElderArchFeyPlotPoint()
        {
            string description = "Suddenly, a voice beckons you from somewhere within the shadows! " +
                "\n\t'Oh, I wouldn't do that if I were you...' it calls, its cadence childlike in its singsong delivery from the depths of the oubliette. " +
                "Your eyes follow it to where the ribbons of runes scrawled over the ground spiral into a strange and elaborate pentagram. From somewhere within its confines you notice some speck of light, as innocuous as a firefly, flicker as a creature stirs...";
            List<string> parlances = new List<string> 
            { 
                "Your feet clap upon the cold flagstones as you cautiously approach, a distinct well of unease sitting in your gut and sending a fever of gooseflesh creeping up your arms. The creature's delightful voice both lures and welcomes you closer..." +
                "\n'...for once there was a frightfully naughty boy, \nWho with many innocent lives he liked to toy, \nfor too many years did he scheme and plan, \nas the snare of spiders' webs across desires span, \nfor the downfall of the unruled, the whimsical, the free, \nAdventurers who dare stand up to power and restore the balance, \n\tlike you, \n\t\tlike me... '",

                "", 

                ""
            };
            List<List<string>> choices = new List<List<string>> 
            {
                new List<string>
                { 
                
                },

                new List<string>
                {
                
                },

                new List<string> 
                { 
                
                }
            };
            switch (LinearParle())
            {
                case 0:
                default:
            }
            return false;
        }*/
    }
}

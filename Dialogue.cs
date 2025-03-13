using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class Dialogue
    {
        Player _player { get; set; }
        Monster _interlocutor { get; set; }
        Combat _combat { get; set; }
        Room _room { get; set; }
        public Dialogue(Player player, Monster monster, Combat combat, Room room)
        {
            _player = player;
            _interlocutor = monster;
            _combat = combat;
            _room = room;
        }
        public int Parle(string description, string parlance, List<string> responses)
        {
            Console.WriteLine(description + "\n\t" + $"'{parlance}'\nHow will you respond?");
            int option = 0;
            string message = "";
            
            while (option < responses.Count) 
            {
                message += $"[{option + 1}]. {responses[option]}\n";
                option++;
            }
            Console.WriteLine(message);
            int i = 0;
            while (true)
            {
                if (i > 0)
                {
                    Console.WriteLine($"How will you respond?\n{message}");
                    i--;
                }
                string answer = Console.ReadLine().ToLower().Trim();
                try
                {
                    int answer1 = int.Parse( answer );
                    if (answer1<1 || answer1 > responses.Count)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {option}");
                        continue;
                    }
                    if (responses[answer1 - 1].Contains("Take the initiative and attack"))
                    {
                        answer1 = 12;

                    }
                    else if (responses[answer1 - 1].Contains($"use an item on something"))
                    {
                        answer1 = 11;
                    }
                    else if (responses[answer1 - 1].Contains($"You end the"))
                    {
                        answer1 = 10;
                    }
                    
                    return answer1;

                }
                catch
                {
                    Console.WriteLine("Please enter the number corresponding to your choice of action.");
                    i++;
                }
            }
        }
        /// <summary>
        /// outcomes
        /// (false, true, true, false) ~ normal dialogue strand engenders response
        /// (false, false, true, true) ~ player ends dialogue
        /// (true, false, false, false) ~ player successfully uses item during dialogue
        /// (false, false, false, false) ~ player unsuccessfully uses item
        /// (true, true, false, false) ~ player successfully starts fire wins combat
        /// (false, true, false, false) ~ player starts fire and dies
        /// (false, false, true, false) ~ player starts fight takes initiative, wins
        /// (false, false, false, true) ~ player starts fight and dies
        /// </summary>
        /// <param name="response"></param>
        /// <param name="usesDictionaryItemItem"></param>
        /// <param name="usesDictionaryItemFeature"></param>
        /// <param name="usesDictionaryItemChar"></param>
        /// <param name="holeInCeiling"></param>
        /// <param name="specialItems"></param>
        /// <param name="rosewoodChest"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public List<bool> reaction(int response, Dictionary<Item, List<Item>> usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, Dictionary<Item, List<Player>> usesDictionaryItemChar, Feature holeInCeiling, List<Item> specialItems, Feature rosewoodChest)
        {
            List<bool> result = new List<bool> {false, false, false, false };//{used item success, started fire, there was a victorious battle/interlocutor dead, died}
            switch (response)
            {
                case 1:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 2:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 3:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 4:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 5:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 6:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 7:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 8:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 9:
                    result[1] = true;
                    result[2] = true;
                    return result;
                case 10:
                    result[2] = true;
                    result[3] = true;
                    return result;
                case 11:
                    List<bool> success;
                    success = _player.UseItemOutsideCombat(_room, specialItems[0], specialItems[1], specialItems[2], specialItems[3], specialItems[4], rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, _interlocutor, _combat);
                    result[0] = success[0];
                    result[1] = success[1];
                    return result;
                case 12:
                    if(_combat.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, _room, _player, usesDictionaryItemChar, holeInCeiling, false, true))
                    {
                        _combat.WonFight();
                        result[2] = true;
                        return result;
                    }
                    else
                    {
                        result[3] = true;
                        return result;
                    }
                default:
                    throw new InvalidOperationException("Too many dialogue choices!");

            }
        }
    }
}

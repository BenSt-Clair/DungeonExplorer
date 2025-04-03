using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Item _item { get; set; }
        Feature _feature { get; set; }
        public Dialogue(Player player, Monster monster, Combat combat, Room room)
        {
            _player = player;
            _interlocutor = monster;
            _combat = combat;
            _room = room;
        }
        public Dialogue(Player player, Monster monster) 
        {
            _player = player; 
            _interlocutor = monster;
        }
        public Dialogue(Item item)
        {
            _item = item;
        }
        public Dialogue(Feature feature)
        {
            _feature = feature;
        }
        public bool getYesNoResponse()
        {
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    continue;
                }
                else if (answer == "yes" || answer == "y")
                {
                    return true;
                }
                else if (answer == "no" || answer == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("PLease answer either 'yes' or 'no'.");
                    continue;
                }
            }
        }

        public int getIntResponse(int option)
        {
            int answer1 = 0;
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    continue;
                }
                else
                {
                    try
                    {

                        answer1 = int.Parse(answer);
                        if (answer1 < 1 || answer1 >= option)
                        {
                            Console.WriteLine($"Please enter a number between 1 and {option - 1}!");
                        }
                        else { break; }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number corresponding to your choice of action!");
                        continue;
                    }
                }
            }
            return answer1;
        }
        public List<long> getTimedIntResponse(int option)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long timeLapsed = 0;
            long answer1 = 0;
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    continue;
                }
                else
                {
                    try
                    {

                        answer1 = int.Parse(answer);
                        if (answer1 < 1 || answer1 >= option)
                        {
                            Console.WriteLine($"Please enter a number between 1 and {option - 1}!");
                        }
                        else { sw.Stop(); timeLapsed = sw.ElapsedMilliseconds; break; }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number corresponding to your choice of action!");
                        continue;
                    }
                }
            }

            List<long> output = new List<long> { answer1, timeLapsed };
            return output;
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
        public int LinearParle(Dictionary<string, string> choice_CustomResponse, List<string>parlances, List<List<string>> playerChoices, string description)
        {
            int node = 0;
            int answer1 = 0;
            Console.WriteLine($"{description}\n\t{parlances[0]}\nHow will you respond?");
            while(node < playerChoices.Count -1)
            {
                if (node > 0)
                {
                    Console.WriteLine("How will you respond?");
                }
                int option = 0;
                string message = "";
                while (option < playerChoices[node].Count)
                {
                    message += $"[{option + 1}]. {playerChoices[node][option]}\n";
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
                        answer1 = int.Parse(answer) -1;
                        if (answer1 < 0 || answer1 > playerChoices[node].Count -1)
                        {
                            Console.WriteLine($"Please enter a number between 1 and {option}");
                            continue;
                        }
                        if (choice_CustomResponse[playerChoices[node][answer1]] == "You decide to stop reading the literature for now.")
                        {
                            Console.WriteLine(choice_CustomResponse[playerChoices[node][answer1]]);
                            Console.ReadKey(true);
                            return -1;
                        }
                        else if (choice_CustomResponse[playerChoices[node][answer1]] == "Surely there's another way...?" || choice_CustomResponse[playerChoices[node][answer1]] == "No... this can't be right...")
                        {
                            Console.WriteLine(choice_CustomResponse[playerChoices[node][answer1]]);
                            Console.ReadKey(true);
                            return -1;
                        }
                        else if (choice_CustomResponse[playerChoices[node][answer1]] == "You tear yourself away from the vision, seemingly lurching out of a world of fog and vapours and long shadows cast by events out of place and time. You find yourself back in the secret chamber. It takes a moment of inertia and vertigo before you quite feel yourself again and you can piece together what all that you witnessed means...")
                        {
                            Console.WriteLine(choice_CustomResponse[playerChoices[node][answer1]]);
                            Console.ReadKey(true);
                            return -1;
                        }
                        
                        Console.WriteLine(choice_CustomResponse[playerChoices[node][answer1]] + " " + parlances[node + 1]);
                        
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter the number corresponding to your choice of action.");
                        i++;
                    }

                }
                node++;
                if (_interlocutor != null && _player != null)
                {
                    if (_interlocutor.Name.Contains("ghoul"))
                    {
                        _player.Stamina -= (3-node) * 4;
                        Console.WriteLine($"You've lost {(3 - node)*4} stamina points!");
                        if (_player.Stamina < 1)
                        {
                            return -1000;
                        }
                    }
                }
            }
            if (!(parlances.Count == 1))
            {
                Console.WriteLine("How will you respond?");
            }
            int option1 = 0;
            string message1 = "";
            while (option1 < playerChoices[node].Count)
            {
                message1 += $"[{option1 + 1}]. {playerChoices[node][option1]}\n";
                option1++;
            }
            Console.WriteLine(message1);
            int j = 0;  
            while (true)
            {
                string answer = Console.ReadLine().ToLower().Trim();
                try
                {
                    answer1 = int.Parse(answer) - 1;
                    if (answer1 < 0 || answer1 > playerChoices[node].Count - 1)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {option1}");
                        continue;
                    }
                    return answer1;
                }
                catch
                {
                    Console.WriteLine("Please enter the number corresponding to your choice of action.");
                    j++;
                }
            }
        }
        public int LoopParle(Dictionary<string, string> choice_answer, List<string> choices1, string description, string parlance, int y1, Player player = null)
        {
            Console.WriteLine($"{description}\n\t{parlance}\nHow will you respond?");

            int y = y1;
            int i = 0;
            List<string> choices = choices1;
            while (true) 
            {
                string message = "";
                int option = 0;
                while (option < choices.Count)
                {
                    message += $"[{option + 1}]. {choices[option]}\n";
                    option++;
                }


                if (i > 0)
                {
                    Console.WriteLine($"How will you respond?\n{message}");
                    i--;
                }
                else
                {
                    Console.WriteLine(message);
                }

                string answer = Console.ReadLine().ToLower().Trim();
                try
                {
                    int answer1 = int.Parse(answer) - 1;
                    if (answer1 < 0 || answer1 > choices.Count - 1)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {option}");
                        continue;
                    }
                    else if (answer1 == y)
                    {
                        Console.WriteLine(choice_answer[choices[y]]);
                        if (player != null)
                        {
                            for (int j = player.Inventory.Count - 1; j >= 0; j--)
                            {
                                if (choices[answer1].Contains(player.Inventory[j].Name))
                                {
                                    player.Inventory.Remove(player.Inventory[j]);
                                }
                            }


                        }
                        break;
                    }
                    else if (answer1 < y)
                    {
                        y--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        if (player != null)
                        {
                            for (int j = player.Inventory.Count - 1; j >= 0; j--)
                            {
                                if (choices[answer1].Contains(player.Inventory[j].Name))
                                {
                                    player.Inventory.Remove(player.Inventory[j]);
                                }
                            }


                        }
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        if (player != null)
                        {
                            for (int j = player.Inventory.Count - 1; j >= 0; j--)
                            {
                                if (choices[answer1].Contains(player.Inventory[j].Name))
                                {
                                    player.Inventory.Remove(player.Inventory[j]);
                                }
                            }


                        }
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }

                }
                catch
                {
                    Console.WriteLine("Please enter the number corresponding to your choice of action.");
                    i++;
                }
            }
            return y;
        }
        public int LoopParle(Dictionary<string, string> choice_answer, List<string> choices, string description, string parlance, int y1, int x1, Player player = null)
        {
            Console.WriteLine($"{description}\n\t{parlance}\nHow will you respond?");
            int x = x1;
            int y = y1;
            int i = 0;
            while (true)
            {
                string message = "";
                int option = 0;
                while (option < choices.Count)
                {
                    message += $"[{option + 1}]. {choices[option]}\n";
                    option++;
                }


                if (i > 0)
                {
                    Console.WriteLine($"How will you respond?\n{message}");
                    i--;
                }
                else
                {
                    Console.WriteLine(message);
                }

                string answer = Console.ReadLine().ToLower().Trim();
                try
                {
                    int answer1 = int.Parse(answer) - 1;
                    if (answer1 < 0 || answer1 > choices.Count - 1)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {option}");
                        continue;
                    }
                    else if (answer1 == y)
                    {
                        Console.WriteLine(choice_answer[choices[y]]);
                        if (player != null)
                        {
                            for (int j = player.Inventory.Count - 1; j >= 0; j--)
                            {
                                if (choices[answer1].Contains(player.Inventory[j].Name))
                                {
                                    player.Inventory.Remove(player.Inventory[j]);
                                }
                            }


                        }
                        return y;
                    }
                    else if (answer1 == x)
                    {
                        Console.WriteLine(choice_answer[choices[x]]);
                        return x;
                    }
                    else if (answer1 < x && answer1 < y)
                    {
                        y--;
                        x--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        if (player != null)
                        {
                            for(int j = player.Inventory.Count - 1; j>= 0; j--)
                            {
                                if (choices[answer1].Contains(player.Inventory[j].Name))
                                {
                                    player.Inventory.Remove(player.Inventory[j]);
                                }
                            }


                        }
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else if (answer1 < y)
                    {
                        y--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        if (player != null)
                        {
                            for (int j = player.Inventory.Count - 1; j >= 0; j--)
                            {
                                if (choices[answer1].Contains(player.Inventory[j].Name))
                                {
                                    player.Inventory.Remove(player.Inventory[j]);
                                }
                            }


                        }
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else if (answer1 < x)
                    {
                        x--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        if (player != null)
                        {
                            for (int j = player.Inventory.Count - 1; j >= 0; j--)
                            {
                                if (choices[answer1].Contains(player.Inventory[j].Name))
                                {
                                    player.Inventory.Remove(player.Inventory[j]);
                                }
                            }


                        }
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        if (player != null)
                        {
                            for (int j = player.Inventory.Count - 1; j >= 0; j--)
                            {
                                if (choices[answer1].Contains(player.Inventory[j].Name))
                                {
                                    player.Inventory.Remove(player.Inventory[j]);
                                }
                            }


                        }
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }

                }
                catch
                {
                    Console.WriteLine("Please enter the number corresponding to your choice of action.");
                    i++;
                }
            }
            
        }
        public int LoopParle(Dictionary<string, string> choice_answer, List<string> choices, string description, string parlance, int y1, int x1, int z1)
        {
            Console.WriteLine($"{description}\n\t{parlance}\nHow will you respond?");
            int x = x1;
            int y = y1;
            int z = z1;
            int i = 0;
            while (true)
            {
                string message = "";
                int option = 0;
                while (option < choices.Count)
                {
                    message += $"[{option + 1}]. {choices[option]}\n";
                    option++;
                }


                if (i > 0)
                {
                    Console.WriteLine($"How will you respond?\n{message}");
                    i--;
                }
                else
                {
                    Console.WriteLine(message);
                }

                string answer = Console.ReadLine().ToLower().Trim();
                try
                {
                    int answer1 = int.Parse(answer) - 1;
                    if (answer1 < 0 || answer1 > choices.Count - 1)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {option}");
                        continue;
                    }
                    else if (answer1 == y)
                    {
                        Console.WriteLine(choice_answer[choices[y]]);
                        return y;
                    }
                    else if (answer1 == x)
                    {
                        Console.WriteLine(choice_answer[choices[x]]);
                        return x;
                    }
                    else if (answer1 == z)
                    {
                        Console.WriteLine(choice_answer[choices[x]]);
                        return z;
                    }
                    else if (answer1 < x && answer1 < y && answer1 < z)
                    {
                        x-- ; y -- ; z -- ;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else if (answer1 < x && answer1 < y)
                    {
                        y--;
                        x--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else if (answer1 < x && answer1 < z)
                    {
                        x--; z--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else if (answer1 < y && answer1 < z)
                    {
                        y--; z--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else if (answer1 < y)
                    {
                        y--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else if (answer1 < x)
                    {
                        x--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else if (answer1 < z)
                    {
                        z--;
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(choice_answer[choices[answer1]]);
                        choices.Remove(choices[answer1]);
                        i++;
                        continue;
                    }

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
        
    }
}

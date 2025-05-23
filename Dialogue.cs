﻿using Microsoft.VisualBasic.FileIO;
using NAudio.Wave;
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
        protected Player _player { get; set; }
        protected Monster _interlocutor { get; set; }
        protected Combat _combat { get; set; }
        protected Room _room { get; set; }
        protected Item _item { get; set; }
        protected Feature _feature { get; set; }
        /// <summary>
        /// Lots of different constructors are used because dialogue may be called within
        /// all manner of different files and may require varying assortments of parameters
        /// for things such as whether an item has been studied, whether the player is disguised, etc.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="monster"></param>
        /// <param name="combat"></param>
        /// <param name="room"></param>
        public Dialogue(Player player, Monster monster, Combat combat, Room room)
        {
            _player = player;
            _interlocutor = monster;
            _combat = combat;
            _room = room;
        }
        public Dialogue(Player player, Room room)
        {
            _player = player;
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
        /// <summary>
        /// called mostly in the game file, the function asks for player
        /// input in the form of a 'yes' or a 'no' (or 'y' or 'n') and gives 
        /// instructive feedback to any erroneous input. Typing in true or false
        /// as the parameter changes the return bool value. eg. when parameter is
        /// false then player input 'yes' returns false. when true 'yes' returns true.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        static public bool getYesNoResponse(bool y)
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
                    return y;
                }
                else if (answer == "no" || answer == "n")
                {
                    return !y;
                }
                else
                {
                    Console.WriteLine("PLease answer either 'yes' or 'no'.");
                    continue;
                }
            }
        }
        /// <summary>
        /// Another example of dynamic polymorphism, this function is used most commonly
        /// within dialogue instants.
        /// </summary>
        /// <returns></returns>
        protected bool getYesNoResponse()
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
        /// <summary>
        /// The following below request player input in the form of an integer.
        /// another example of dynamic polymorphism, this one is again largely
        /// used in the game file.
        /// minimum determines the lowest number to be returned while option determines
        /// the lowest upper bound. 
        /// bool isStatic does nothing, except distinguish it from the other
        /// function below.
        /// </summary>
        /// <param name="option"></param>
        /// <param name="isStatic"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        static public int getIntResponse(int option, bool isStatic, int min)
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
                        if (answer1 < min || answer1 >= option)
                        {
                            Console.WriteLine($"Please enter a number between {min} and {option - 1}!");
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

        public int getIntResponse(int option, int min = 1)
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
                        if (answer1 < min || answer1 >= option)
                        {
                            Console.WriteLine($"Please enter a number between {min} and {option - 1}!");
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
        /// <summary>
        /// Returns a list of long integers. The first is the player response. the
        /// second is the time taken to give that response. This is mostly used for
        /// timed decisions where delays might incur consequences, such as when
        /// you're evading a patrolling monster, or else need to choose an enemy to
        /// attack during combat.
        /// </summary>
        /// <param name="option"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public List<long> getTimedIntResponse(int option, int min = 1)
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
                        if (answer1 < min || answer1 >= option)
                        {
                            Console.WriteLine($"Please enter a number between {min} and {option - 1}!");
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
        /// <summary>
        /// The most basic of building blocks for constructing dialogue in game. 
        /// It works by taking a descripiton and what the  interlocutor says, then 
        /// gives you a list of choices that can form your response.
        /// I then use Switch Case statements to capture each possible returned int
        /// value representing the player's response.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="parlance"></param>
        /// <param name="responses"></param>
        /// <returns></returns>
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
        /// A far more efficient way of constructing dialogue than the atomistic method above;
        /// This is used when you wish to customise dialogue to the player's choices but when the
        /// next list of choices are the same regardless of player input. By making special cases
        /// for certain choices that might occur, however, one can still garner the effect of a branching
        /// tree that can be terminated early or else lead down another LinearParle branch.
        /// 
        /// It works by pairing player responses with customised parlances through a dictionary,
        /// thereafter concatenating these strings with a common next question or line that leads
        /// to the next list of player choices. This can be continued indefinitely. 
        /// </summary>
        /// <param name="choice_CustomResponse"></param>
        /// <param name="parlances"></param>
        /// <param name="playerChoices"></param>
        /// <param name="description"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public int LinearParle(Dictionary<string, string> choice_CustomResponse, List<string>parlances, List<List<string>> playerChoices, string description, Player player = null)
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
                        else if (choice_CustomResponse[playerChoices[node][answer1]] == "Merigold's face darkens the moment he realises you're not joking. 'I don't know who you are, stranger,' he visibly shakes with fury, 'but you're about to find out first hand why you should never cross a wizard. It's going to be your first lesson upon the subject, and I daresay your last...'\n You leer as you relish the fight to come. Oh this is going to be fun...")
                        {
                            Console.WriteLine(choice_CustomResponse[playerChoices[node][answer1]]);
                            Console.ReadKey(true);
                            return -50;
                        }
                        else if (playerChoices[node][answer1] == "Unsheathe your weapon and prepare for the duel of your life...")
                        {
                            if (player != null)
                            {
                                player.Equip(player.WeaponInventory[0], player.WeaponInventory, player);
                            }
                        }
                        else if ((playerChoices[node][answer1] == "Tighten your grip on Merigold's staff and brace yourself..."))
                        {
                            if (player != null)
                            {
                                foreach (Weapon w in player.WeaponInventory)
                                {
                                    if (w.Name == "Marvellous Merigold's Magical Staff of Whacking")
                                    {
                                        player.Equip(w, player.WeaponInventory, player);
                                    }
                                }
                            }
                        }
                        else if ((playerChoices[node][answer1] == "Unsheathe the sword of sealed souls before the CurseBreaker..."))
                        {
                            if (player != null)
                            {
                                foreach (Weapon w in player.WeaponInventory)
                                {
                                    if (w.Name == "Sword of Sealed Souls")
                                    {
                                        player.Equip(w, player.WeaponInventory, player);
                                    }
                                }
                            }
                        }
                        if (player != null)
                        {
                            if (node == 1 && parlances[2].Contains("This report sends a jolt through you, as the name of that accursed village that'd abducted you leaps out of the page at you;"))
                            {
                                
                                if (player.UncoverSecretOfMyrovia == 1 || player.UncoverSecretOfMyrovia == 4 || player.UncoverSecretOfMyrovia == 5 || player.UncoverSecretOfMyrovia == 0)
                                {
                                    player.UncoverSecretOfMyrovia += 2;
                                }
                            }
                            else if (node == 2 && parlances[3].Contains("You watch as the guests, rather unsteadily, rise from their seats and take their leave. One of the last to do so is a figure who stirs within you some disquieting unease; an unwelcome, nauseating deja vu. The ghostly apparition is more tremulous than most as he heads for the door..."))
                            {
                                if (player.UncoverSecretOfMyrovia < 4)
                                {
                                    player.UncoverSecretOfMyrovia += 4;
                                }
                            }
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
        /// <summary>
        /// LoopParle essentially is for those dialogues in which the player poses
        /// questions to an interlocutor one by one and the interlocutor gives
        /// customised responses until an exit option is chosen. 
        /// This is another case of dynamic polymorphism, each function
        /// varied by how many exit options there are (y, x, and z).
        /// </summary>
        /// <param name="choice_answer"></param>
        /// <param name="choices1"></param>
        /// <param name="description"></param>
        /// <param name="parlance"></param>
        /// <param name="y1"></param>
        /// <param name="player"></param>
        /// <returns></returns>
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
                        return 1;
                    }
                    else if (answer1 == x)
                    {
                        Console.WriteLine(choice_answer[choices[x]]);
                        
                        return 2;
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
        public int LoopParle(bool music, Dictionary<string, string> choice_answer, List<string> choices, string description, string parlance, int y1, int x1, int z1)
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
                    if (choices[answer1] == "You remind him of what he said about only having until midnight to stop some profane ritual - you ask him to tell you everything he knows about it...")
                    {
                        _player.Fooled = false;
                    }
                    if (choices[answer1] == "You tell him that the strange innkeeper made it clear you were abducted and exchanged in the hope that the CurseBreaker might somehow break Myrovia's curse. How does this villain intend to commit such a feat?")
                    {
                        if (_player.UncoverSecretOfMyrovia == 0 || _player.UncoverSecretOfMyrovia == 2 || _player.UncoverSecretOfMyrovia == 4 || _player.UncoverSecretOfMyrovia == 6)
                        {
                            _player.UncoverSecretOfMyrovia++;
                        }
                    }
                    if (answer1 < 0 || answer1 > choices.Count - 1)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {option}");
                        continue;
                    }
                    else if (answer1 == y)
                    {
                        
                        if (choices[y] == "This is all too much. Your deception cannot last. You confess to Merigold everything. You are no adventurer like your fellow inmates. In fact, you were never anything other than a fraudster, a small-time con-artist, and general rapscallion..." 
                            || choices[y] == "You tell him frankly that while you may be an adventurer, you're no hero. You tell him you're sorry to disappoint him but all you want is a way out of here...")
                        {
                            using(var audioFile = new AudioFileReader("courage-inside-monument-music-main-version-30423-02-42.mp3"))
                            {
                                using (var outputDevice = new WaveOutEvent())
                                {
                                    if (music)
                                    {
                                        outputDevice.Init(audioFile);
                                        outputDevice.Play();
                                    }
                                    Console.WriteLine(choice_answer[choices[y]]);
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(choice_answer[choices[y]]);
                        }
                        return 1;
                    }
                    else if (answer1 == x)
                    {
                        Console.WriteLine(choice_answer[choices[x]]);
                        return 2;
                    }
                    else if (answer1 == z)
                    {
                        Console.WriteLine(choice_answer[choices[z]]);
                        return 3;
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
        
        
    }
}

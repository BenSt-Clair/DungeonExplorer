using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> ItemList { get; set; }
        public List<Feature> FeatureList { get; set; }
        public bool FirstVisit { get; set; }
        public Room(string name, string description, List<Item> itemList, List<Feature> featureList, bool firstVisit = true)
        {
            Name = name;
            Description = description;
            ItemList = itemList;
            FeatureList = featureList;
            FirstVisit = firstVisit;
        }
        public List<bool> WhichRoom(List<bool> roomList)
        {
            if (Name == "dank cell")
            {
                for (int i = 0; i < roomList.Count; i++)
                { 
                    roomList[i] = true;
                    if (i == 0)
                    {
                        roomList[i] = false;
                    }
                }
                    
                return roomList;

            }
            else if (Name == "long corridor")
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 1)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "oubliette") // occult runes holding Demon Lord of the Fey
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 2)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "antechamber")
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 3)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "eerie cell")
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 4)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "armoury")
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 5)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "mess hall") // red herring?
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 6)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "westernmost corridor")
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 7)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "empty cell")
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 8)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if(Name == "magical manufactory")// Merigold's chambers
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 9)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "broom closet")
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 10)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "highest parapet")//final boss fight
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 11)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "secret chamber")  // through hole in ceiling
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 16)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "prehistoric jungle")// friends with fairies
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 17)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "astral planes")// friends with fairies
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 18)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "ocean bottom")//friends with fairies 
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 19)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "dungeon chamber")//before oubliette, ghoul named willow
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 20)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "huge barracks")// killed by army
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 12)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "desert island") // make friends with coconut called wilson
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 13)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "bank vault") // trapped with mounds of treasure
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 14)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "dragon's lair") // fight skill 10 boon 10 stamina 999, or else dialogue answer riddle and magicked back
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 15)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "north-facing corridor") // fight skill 10 boon 10 stamina 999, or else dialogue answer riddle and magicked back
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 21)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "easternmost corridor") // fight skill 10 boon 10 stamina 999, or else dialogue answer riddle and magicked back
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 22)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "south-facing corridor") // fight skill 10 boon 10 stamina 999, or else dialogue answer riddle and magicked back
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 23)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            else if (Name == "mirror world")
            {
                for (int i = 0; i < roomList.Count; i++)
                {
                    roomList[i] = true;
                    if (i == 24)
                    {
                        roomList[i] = false;
                    }
                }

                return roomList;
            }
            return roomList;
        }
        /// <summary>
        /// Involves picking up room items, searching room features, using doors and a broad
        /// description of the room and where things are placed.
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="weaponInventory"></param>
        /// <param name="b"></param>
        /// <param name="player"></param>
        public Room Investigate(bool music, Dictionary<Item, List<Player>> usesDictionaryItemChar, Stopwatch sw, long minotaurAlertedBy, bool justStalked, List<Room> threadPath, List<Item> inventory, List<Weapon> weaponInventory, int b, Player player, Weapon yourRustyChains, List<Item> stickyItems, List<Item> specialItems, Monster minotaur, Combat mageBattle, Room secretChamber, Monster goblin, Monster gnoll, List<Item> MGItems, List<Room> destinations, Door stairwayToLower, List<Room> choiceVersusDestination = null, Feature laboratory = null, List<Room> mosaicPortal = null)
        {
            
            Dice D20 = new Dice(20);
            Dice D6 = new Dice(6);
            //string list for moving about the room
            List<string> ministryOfSillyWalks = new List<string> {
            "You blithely saunter",
            "You make your merry way",
            "You sashay up",
            "You do a jolly skip over",
            "You prance",
            "You dance your way",
            "You jog up",
            "You step over",
            "You walk over",
            "You strut your sexy stuff up",
            "You glide over",
            "You sidle up",
            "You do a leisurely stroll",
            "You titter your way over",
            "You giggle as you sidle up",
            "You flounce over",
            "You swagger up",
            "You bounce up",
            "You hop up",
            "You rollick your way up",
            "You step over",//20
            "You pace furtively up",
            "You make your way",
            "You move up",
            "You tread closer",
            "You curiously pace up",
            "You gallantly stride over",//26
            "You confidently swagger up",
            "You stroll smoothly up",
            "You courageously sidle over",
            "Flashing a grin indicative of derring do, you theatrically stroll up",
            "Armed with your dazzling smile, you strut over"
            };
            if (b < 1 && (Name !="antechamber" || FirstVisit))
            {
                if (Name == "highest parapet")
                {
                    Console.WriteLine("Will you glance over your surroundings?");
                    Console.WriteLine("[1] To the north?");
                    Console.WriteLine("[2] To the west?");
                    Console.WriteLine("[3] To the south?");
                    Console.WriteLine("[4] Above?");
                }
                else
                {
                    Console.WriteLine($"Will you investigate the {Name}'s...");
                    Console.WriteLine("[1] Northern wall?");
                    Console.WriteLine("[2] Westernmost wall?");
                    Console.WriteLine("[3] South wall?");
                    Console.WriteLine("[4] Eastern Wall?");
                }
                
                
                bool continueInvestigate = true;
                int reply2 = 0;
                while (continueInvestigate)
                {
                    string reply = "";
                    if (reply2 == 0)
                    {
                        reply = Console.ReadLine().Trim().ToLower();
                    }
                    else
                    {
                        reply = reply2.ToString();
                    }

                    ///In room description there are segments separated by \n and \t that describe each wall
                    ///by compass direction. This only happens upon the first inspection of the room.
                    if (string.IsNullOrWhiteSpace(reply))
                    {
                        Console.WriteLine($"Will you glance over the {Name}'s...");
                        Console.WriteLine("[1] Northern wall?");
                        Console.WriteLine("[2] Westernmost wall?");
                        Console.WriteLine("[3] South wall?");
                        Console.WriteLine("[4] Eastern Wall?"); continue;
                    }

                    try
                    {
                        int reply1 = int.Parse(reply);
                        if (reply1 < 1 || reply1 > 4) { Console.WriteLine("Please enter a number from 1 to 4."); reply2 = 0; continue; }
                        ///The following finds the right description of the wall within room.Description and displays it 
                        ///by truncating and finding the right substring
                        else if (reply1 == 1)
                        {
                            string message = Description.Substring(Description.IndexOf("\n") + 1, Description.IndexOf("\t") - Description.IndexOf("\n"));
                            Console.WriteLine(message);

                        }
                        else if (reply1 == 2)
                        {
                            string message = Description;
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 1, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(0, message.IndexOf("\t"));
                            Console.WriteLine(message);
                        }
                        else if (reply1 == 3)
                        {
                            string message = Description;
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 1, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(0, message.IndexOf("\t"));
                            Console.WriteLine(message);
                        }
                        else if (reply1 == 4)
                        {
                            string message = Description;
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 1, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(0, message.IndexOf("\t"));
                            Console.WriteLine(message);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter the number corresponding to a listed choice.");
                    }
                    if (Name == "highest parapet")
                    {
                        Console.WriteLine("Will you take a glance elsewhere?");
                    }
                    else
                    {
                        Console.WriteLine("Do you wish to investigate any of the other sides of the room?");
                    }
                    reply2 = 0;
                    while (true)
                    {
                        string nextAnswer = Console.ReadLine().Trim().ToLower();
                        try
                        {
                            reply2 = int.Parse(nextAnswer);
                            break;
                        }
                        catch
                        {


                            if (nextAnswer == "yes" || nextAnswer == "y")
                            {
                                continueInvestigate = true;
                                break;
                            }
                            else if (nextAnswer == "no" || nextAnswer == "n")
                            {
                                continueInvestigate = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' or 'no'");

                            }
                        }
                    }



                }
            }
            if (Name == "highest parapet")
            {
                Console.WriteLine("Would you like to peer closer at the strange totems about the CurseBreaker?");
                Dialogue totem = new Dialogue(FeatureList[0]);
                if (totem.getYesNoResponse())
                {
                    foreach (Feature feature in FeatureList)
                    {
                        Console.WriteLine($"{feature.Name}:");
                        Console.WriteLine(feature.Description);
                    }
                }
            }
            if (Name == "oubliette" || Name == "highest parapet")
            {
                return this;
            }
            ///What now follows are a list of options whereby the player can pick up
            ///items in the room, investigate features of the room, or try something else, i.e.
            ///return to main options.
            Console.WriteLine($"Would you like to perhaps make a closer inspection of the {Name}'s features, pick up some of the {Name}'s items?\nOr would you prefer a different course of action for now?");
            int k = 1;
            Dice D9 = new Dice(9);
            List<string> searchWords = new List<string> { "Search", "Scour", "Investigate", "Inspect", "Scrutinise", "Examine", "Probe", "Check", "Ransack" };
            string options = "";
            ///Creating a duplicate list for room items so that there is no
            ///out of bounds exception when items are removed
            List<Item> itemList = new List<Item>();
            if (ItemList != null)
            {
                foreach (Item x in ItemList)
                {
                    itemList.Add(x);
                }
            }
            foreach (Feature f in FeatureList) { int i = D9.Roll(D9) - 1; options += $"[{k}] {searchWords[i]} the {f.Name}.\n"; k++; }
            
            
            foreach (Item g in itemList) { options += $"[{k}] Pick up the {g.Name}\n"; k++; }
            options += $"[{k}] Try something else";
            Console.WriteLine(options);
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                List<Door> doors = new List<Door>();
                List<Room> adjacentRoom = new List<Room>();
                foreach (Feature f in FeatureList) 
                { 
                    if(f is Door)
                    {
                        doors.Add(f.CastDoor());
                    }
                }
                foreach (Door d in doors)
                {
                    foreach(Room r in d.Portal)
                    {
                        if (r != this)
                        {
                            adjacentRoom.Add(r);
                        }
                    }
                }
                sw.Stop();
                long timeout = sw.ElapsedMilliseconds;
                try
                {
                    if (!justStalked && timeout > minotaurAlertedBy && adjacentRoom.Contains(minotaur.Location) && minotaur.Path.Count == 1 && minotaur.Location.Name != "astral planes" && this.Name != "magical manufactory")
                    {
                        Console.WriteLine("You suddenly halt what you are doing...");
                        Console.ReadKey(true);
                        Console.WriteLine($"Rooted to the floor, you think you can hear the monster stirring in the {minotaur.Location.Name}. You dare not make a sound as you wait for what happens next...");
                        Console.ReadKey(true);
                        return this;
                    }
                }
                catch { }
                sw.Start();
                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Choose a number corresponding to the list above.");
                    Console.WriteLine(options); 
                    continue;
                }
                else
                {
                    try
                    {
                        int answer1 = int.Parse(answer) - 1;
                        if (answer1 < 0 || answer1 > k-1)
                        {
                            Console.WriteLine($"Please enter a number between 1 and {k}.");
                            continue;
                        }
                        else if (answer1 < FeatureList.Count)//if you wish to investigate a feature
                        {
                            ///If the player has specific traits then the comments are customised accordingly
                            if (player.Traits.ContainsKey("friends with fairies"))
                            {
                                Console.WriteLine($"\n{ministryOfSillyWalks[D20.Roll(D20) - 1]} to the {FeatureList[answer1].Name}...\n");            
                            }
                            else if (player.Traits.ContainsKey("thespian"))
                            {
                                Console.WriteLine($"\n{ministryOfSillyWalks[25+D6.Roll(D6)]} to the {FeatureList[answer1].Name}");
                            }
                            else
                            {
                                Console.WriteLine($"\n{ministryOfSillyWalks[19+D6.Roll(D6)]} to the {FeatureList[answer1].Name}...\n");
                            }
                            Console.ReadKey(true);
                            Room newRoom = FeatureList[answer1].Search(music, usesDictionaryItemChar, choiceVersusDestination, player.CarryCapacity, inventory, weaponInventory, this, player.FieryEscape, player, stairwayToLower, destinations, specialItems, mageBattle, secretChamber, goblin, gnoll, MGItems);
                            FeatureList[answer1].investigateFeature(specialItems, minotaur, player, mosaicPortal);
                            
                            if ( newRoom.Name != this.Name )
                            {
                                return newRoom;
                            }
                            if (laboratory != null)
                            {
                                if (laboratory.Description.Contains("It's been thoroughly trashed after your fight with Merigold..."))
                                {
                                    return newRoom;
                                }
                            }
                            Console.ReadKey(true);
                            Console.WriteLine(options);
                            continue;
                        }
                        else if (answer1 < k - 1) //if you wish to pick up an item in the room.
                        {
                            try
                            {
                                bool freshLoop = false;
                                foreach (Item x in inventory)
                                {
                                    if (x.Name == itemList[answer1 - FeatureList.Count].Name)
                                    {
                                        Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                        freshLoop = true;
                                        break;
                                    }
                                }

                                foreach (Weapon x in weaponInventory)
                                {
                                    if (x.Name == itemList[answer1 - FeatureList.Count].Name || (x.Name == "rusty chain-flail" && itemList[answer1 - FeatureList.Count].Name == "rusty chains"))
                                    {
                                        Console.WriteLine($"You've already taken the {x.Name}.");
                                        freshLoop = true;
                                        break;
                                    }
                                }
                                if (freshLoop) { continue; }
                                List<Item> weaponSplice = new List<Item> { itemList[answer1 - FeatureList.Count] };
                                List<Weapon> weapon1 = weaponSplice.Cast<Weapon>().ToList();
                                weapon1[0].PickUpItem( player, player.CarryCapacity, inventory, weaponInventory, 4, 0, null, weapon1[0], null, ItemList, yourRustyChains, stickyItems, null, threadPath, this);
                            }
                            catch // if not a weapon that is to be picked up...
                            {
                                bool freshLoop = false;
                                foreach (Item x in inventory)
                                {
                                    if (x.Name == itemList[answer1 - FeatureList.Count].Name)
                                    {
                                        Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                        freshLoop = true;
                                        break;
                                    }
                                }

                                foreach (Weapon x in weaponInventory)
                                {
                                    if (x.Name == itemList[answer1 - FeatureList.Count].Name)
                                    {
                                        Console.WriteLine($"You've already taken the {x.Name}.");
                                        freshLoop = true;
                                        break;
                                    }
                                }
                                if (freshLoop) { continue; }
                                itemList[answer1 - FeatureList.Count].PickUpItem( player, player.CarryCapacity, inventory, weaponInventory, 4, 0, itemList[answer1 - FeatureList.Count], null, null, ItemList, null, stickyItems, null, threadPath, this); 
                                    
                                
                            }
                        }
                        else //if player wants to return to main options...
                        {
                            return this;
                        }
                    }
                    catch (Exception e) { Console.WriteLine("Please enter the number corresponding to your choice of action."); }
                }

            }
        }
    } 
}

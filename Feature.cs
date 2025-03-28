﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Feature has five attributes. Conceptually features are static things that
    /// reside in a room. They cannot be picked up, but they can be searched. There are 
    /// also special actions that can be made upon them, potentially, by certain items. 
    /// A sword might shatter a skeleton, for example. Or you might extinguish a flaming
    /// brazier. To reflect this, features have 'Attribute' and 'Specific Attribute'.
    /// Specific Attribute is a string such as "lit" that can change to "unlit", or "locked"
    /// to "unlocked", depending on whether the boolean 'Attribute' is true or false. 
    /// Aside from these two attributes, there is the name and the description of each
    /// feature. And the ItemList is a list of items that may be found around or about the 
    /// instantiated feature.
    /// </summary>
    public class Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Attribute { get; set; }
        public string SpecificAttribute { get; set; }
        public List<Item> ItemList { get; set; }
        public Feature(string name = "", string description = "Nothing of note meets the eye.", bool attribute = true, string specificAttribute = "locked", List<Item> itemList = null)
        {

            Name = name;
            Description = description;
            Attribute = attribute;
            SpecificAttribute = specificAttribute;
            ItemList = itemList;
        }
        public Door CastDoor()
        {
            List<Door> door = new List<Door>();
            List<Feature> tobedoor = new List<Feature> { this };
            door = tobedoor.Cast<Door>().ToList();
            return door[0];
        }
        /// <summary>
        /// investigate feature prints its description to the console.
        /// </summary>
        /// <returns></returns>
        public void investigateFeature(List<Item> specialItems, Monster minotaur)
        {
            
            if (Name == "peculiar mosaic")
            {
                Console.WriteLine("The tiles finally settle and form the image of a vast non-descript face gazing placidly down at you. It's open features almost seems to invite questions from you...\n\tDo you wish to see if you can get a response out of the kaleidoscopic mosaic?");
                Dialogue mosaicTalk = new Dialogue(this);
                if (mosaicTalk.getYesNoResponse())
                {
                    if (specialItems[6].SpecifyAttribute == "read")
                    {
                        string description = "The excerpt from that book on cur'sed weapons leaps to mind. You wonder if this is the mosaic that only ever answers open questions with riddles and metaphors?\nYou have a ponder before posing your first question...";
                        string parlance = "";
                        List<string> choices = new List<string> 
                        {
                            "Step away from the mosaic...",
                            "What is the name of the Curse-Breaker?",
                            "Where did the Curse-Breaker come from?",
                            "How can I defeat the Curse-Breaker?",
                            "Where am I?",
                            "What is being done to the prisoners here?",
                            "How do I escape?"
                            
                        };
                        if (minotaur.Stamina > 0)
                        {
                            choices.Add("How might I triumph over the next trial waiting through those doors?");
                        }
                        
                        Dictionary<string, string> choice_answer = new Dictionary<string, string> 
                        {
                            {"What is the name of the Curse-Breaker?", "The lustrous tiles flutter and the visage's lips seem to move as a voice sounds through the chamber.\n\n\t'There was once a thief who stole many things. Amongst those things she often stole were the identities of those" +
                            " who'd long been deceased. She'd adopt aliases engraved on tombstones, weave lives out of their faded memories and rake riches from those who trusted her. She eluded capture for she was" +
                            " a thousand faces to ten thousand people. She was countless names to innumerable enemies. When they sought to grasp her, she sifted through their fingers like mist... \nWhat is a name but that of which we claim ownership only for others to use freely? You ask me the name" +
                            " of the Curse-Breaker, yet do you not already have your answer?'" },

                            {"Where did the Curse-Breaker come from?", "The mosaic's visage regards you solemnly, before the lustrous tiles flutter into an animated collage of past landscapes, eerie visions and disquieting memories...\n\n\t" +
                            "'Many moons and summers past, there lived a boy who resided in a village by the woods." +
                            " His parents were kind. And so when the other children were beguiled by a creature bound to the forest's heart, he refused to join them. They " +
                            " would tease him, for the creature's words tangled their tongues with thorns. They would beat him, for the creature's dreams took deep root in their minds." +
                            " They lied and isolated him, for the creature knew the art of weaving facts out of falsehoods and taught the other children well in its craft. " +
                            "When the creature's poison had fevered the minds of those children and cast its ecstatic delirium upon them, they became thralls. Their unspoken, unacknowledged" +
                            " torment of others slowly twisted into the seeds of a curse. \n" +
                            "\tThe curse took its form in a band of adventurers seeking to dispense justice and rid the world of evil. They were caught in the snare of facts woven by the creature" +
                            "; facts whose thorns fevered the mind with visions of atrocities. All the adults in the village were massacred. And when it came" +
                            " for the children to be delivered to new loving homes, they'd long since made their own home in the heart of the forest, where the Fey princes hold dominion. \nOnly one child" +
                            " remained; a boy forever scarred. A boy destined to seek out that creature in adulthood, and with it form a terrible pact.\n\t  Such are the origins of the Curse-Breaker...'" },

                            {"How can I defeat the Curse-Breaker?", "\n\n\t'A maggot devours its fill. Once it is sated it will form its chrysalis, wherein its skin is shed and its body eaten from the inside by a new form..." +
                            " \n\tThis form is one with wings. Wings are a feature of Fey denizens too, even if metamorphosis is not. That is normally where any similarities you may like to draw end. \n\tBut tonight there exists something also awaiting transformation in the dungeons far below." +
                            "\nWithin this chrysalis of stone and mortar and forbidden magic it has its own wings, whose beauty lies in their lethality. \n\n\tThe Curse-Breaker is a man. While he is a man he is vulnerable to sharp steel and poisons and fire like any other man. " +
                            "\nBut he is also a man yet to shed his skin. A man yet to transfigure those frightful wings from within another. And his ambitions inch him closer to that goal.\n\n" +
                            "You have until midnight to slay a man upon the highest parapet, or else be doomed..." },

                            {"Where am I?", "\n\n\t'An abode once loved,\nA time long lost, " +
                            "\nWith hands gloved, \nThe owner he'd accost, " +
                            "\nA spell was found, \nA pact was made, " +
                            "\nUpon the tower-top, \nwill be made a terrible trade, " +
                            "\nWhere once magic aided, \nNow it has faded, " +
                            "\nWith the sorceror's talents raided, \n For untold ambitions sated, " +
                            "\n\nOverlooking Myrovia, \nFrom atop mountain mist, " +
                            "\nYou find yourself saviour, \nShould you choose to assist.'" },
                            
                            {"What is being done to the prisoners here?", "The tiles rattle, almost sounding like a murder of crows taking flight, spooked by your question.\n\n\t" +
                            "'What occurs within these walls to those defenceless, there exists no precedent or analogy fitting. No metaphor that can conceal for polite company the foetid deed. Nor any embellishment that might smooth the telling. " +
                            "I have no words worthy to describe such atrocities. Magic born of no book but of a sick mind is imposed upon those brought here. It robs them of what they once were, that something else might be...'" },
                            
                            {"How do I escape?", "\n\n\t'There exists a portal of magicks arcane beyond this door I crown. Seek it, and it *may* teleport you down...'" },
                            
                            {"How might I triumph over the next trial waiting through those doors?", "The lustrous tiles flutter and your eyes clap sight of an ancient hero traversing many winding corridors." +
                            "\n\n\t'Theseus of old had a ball of string. With it he traversed his labyrinth. Were you to discover this unspooled string inside the maze, you could follow it one of two ways. The way of truth would lead you to Theseus and this myth's end. The way of untruth would mislead you nowhere. The threads of fate are woven by your decisions. Will your thread lead to the same battle? \nOnly the one who unspools the string and where may decide...'" },//theseus
                            
                            {"Step away from the mosaic...", "You ponder the answers you received a moment, before pensively deciding on a new course of action..." }

                        };
                        mosaicTalk.LoopParle(choice_answer, choices, description, parlance, 0);
                        return;
                    }
                    else
                    {
                        string description = "";
                        string parlance = "\x1b[3J";
                        List<string> choices = new List<string> 
                        { 
                            "Uh, are you able to talk?",
                            "Can you tell me where I am?",
                            "Can you direct me to the way out of here, please?",
                            "Can you hear me?",
                            "Do you know anything about the Curse-Breaker?",
                            "Can you help me defeat any of the enemies here?",
                            "Is there anything you're willing to tell me?",
                            "Do you have any advice on how to proceed?",
                            "Must you stare at me like that?",
                            "Are you spying on me?",
                            "Okay... so I guess I'll just be going then..."
                        };
                        Dictionary<string, string> choice_answer = new Dictionary<string, string> 
                        {
                            {"Uh, are you able to talk?", "The mosaic does not respond, though it continues to eye you expectantly..." },
                            {"Can you tell me where I am?", "The mosaic maintains its silent vigil of you..." },
                            {"Can you direct me to the way out of here, please?", "The peculiar mosaic utters not a word..." },
                            {"Can you hear me?", "The mosaic merely gazes back at you with its placid expression..." },
                            {"Do you know anything about the Curse-Breaker?", "The mosaic's lips are sealed..." },
                            { "Can you help me defeat any of the enemies here?", "The mosaic regards you expressionlessly..."},
                            {"Is there anything you're willing to tell me?", "The mosaic does not so much as blink as it continues watching you..." },
                            {"Do you have any advice on how to proceed?", "The mosaic says and does nothing that could indicate one way or another whether it possesses any such advice..." },
                            {"Must you stare at me like that?", "The mosaic continues looking, not so much as though it hadn't heard you, but as though you'd never spoken at all..." },
                            {"Are you spying on me?", "The mosaic only continues to eye your movements..." },
                            {"Okay... so I guess I'll just be going then...", "You step away from the mosaic feeling its gaze follow you even as you turn your back on it..." }
                        };
                        mosaicTalk.LoopParle(choice_answer, choices, description, parlance, 10);
                        return;
                    }
                                       
                }
                else
                {
                    Console.WriteLine("Feeling a little unsettled as the mosaic's eyes follow you across the room, you decide to do something else...");
                    return;
                }
            }
        }
        /// <summary>
        /// So far in the game only three features have itemLists and can be searched. 
        /// Due to the complex nature of one of these, where its itemlist is discoverable
        /// but not immediately available, I've had to deploy some convoluted code to
        /// reflect this. Nevertheless, search() retains a general application that can be universally
        /// applied regardless of whether the feature has an itemlist or not. 
        /// It calls another function, pickUpItem(), that can be implemented on items in itemlist.
        /// While the items listed does not change if you stash one of them in your pack, whether or not
        /// you're able to pick it up again does change. You can't if the item is already in your pack.
        /// The next time you visit the feature the stashed items around it will be gone from the list.
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="weaponInventory"></param>
        public Room Search(int carryCapacity, List<Item> inventory, List<Weapon> weaponInventory, Room room, bool fieryEscape)
        {
            Console.WriteLine($"Rummaging about the {Name}, you find the following;");
            int r = 1;
            string message = $"{Description}\n";
            if (Name == "bookcase" && ItemList.Count != 0 && room.Name == "dank cell")
            {
                message += "Your keen eye notices a lone page just underneath the collapsed shelf, snagged at the back.\n";
            }
            if (Name == "rosewood chest" && Attribute == false)
            {
                message += "You prise open the chest's lid. It yields to your firm grip with an ominous creak.\n";
            }
            if (Name == "rosewood chest" && Attribute == false && ItemList.Count != 0)
            {
                message += "Your furtive fingers scrabble at the panel at the bottom of the chest. After some effort, you manage to at last unveil a hidden compartment...\n";
            }
            /// I create a copy of ItemList for reference so that removed items do not trigger an 
            /// out of bounds exception.
            List<Item> itemList = new List<Item>();
            if (ItemList != null)
            {
                if (ItemList.Count != 0)
                {
                    foreach (Item x in ItemList)
                    {
                        itemList.Add(x);
                    }
                }
            }
            if (ItemList != null)
            {
                if (Name == "rosewood chest")
                {
                    if (ItemList.Count != 0 && !Attribute)
                    {

                        foreach (Item item in itemList)
                        {
                            message += $"[{r}] {item.Name}\n";
                            r++;
                        }





                        bool continueLoop = true;
                        int a = 0;
                        /// This loop continues while the player is given the option
                        /// to select, study or return items through the pickUpItem()
                        /// function.
                        while (continueLoop)
                        {
                            Console.WriteLine(message);

                            if (a > 0) { Console.WriteLine("Select another item from the list above or enter 'no'."); }
                            else { Console.WriteLine("\nWould you like to take a closer look at any of these items?"); }
                            string reply = Console.ReadLine().Trim().ToLower();
                            if (reply == "no" || reply == "n")
                            {



                                return room;


                            }
                            try
                            {
                                int reply1 = int.Parse(reply);
                                if (reply1 < 1 || reply1 > r - 1)
                                {
                                    Console.WriteLine($"Please enter a number between 1 and {r - 1}.");
                                    continue;
                                }
                                else
                                {
                                    try
                                    {
                                        // I seem to have this habit of not using lists for reference. Saves memory I guess...
                                        bool success = false;
                                        string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3));
                                        Console.WriteLine(objName);
                                        bool freshLoop = false;
                                        /// checking to see if item is already in pack. Each item is unique,
                                        /// so this works as a system of preventing the player from picking
                                        /// up the same item multiple times.
                                        foreach (Item x in inventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }

                                        foreach (Weapon x in weaponInventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already taken the {x.Name}.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }
                                        if (freshLoop) { continue; }
                                        foreach (Item i in itemList)
                                        {
                                            if (i.Name == objName)
                                            {
                                                try //pickupitem() can be used on weapons or items but weapons must be distinguished as such
                                                {
                                                    i.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, i, null, ItemList);

                                                }
                                                catch
                                                {
                                                    foreach (Weapon y in itemList)
                                                    {
                                                        if (y.Name == objName)
                                                        {
                                                            y.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, null, y, ItemList);

                                                        }
                                                    }
                                                }
                                                finally { success = true; }
                                            }
                                        }

                                    }// need another catch for if ItemList is left with no items inside
                                    catch//for if there is only one item in list or chosen item is at top of list
                                    {
                                        try
                                        {
                                            bool success = false;
                                            //way of retrieving objName changes if only one item in list
                                            string objName = message.Substring(message.IndexOf((r - 1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r - 1).ToString()) + 3));
                                            Console.WriteLine(objName);
                                            bool freshLoop = false;
                                            foreach (Item x in inventory)
                                            {
                                                if (x.Name == objName)
                                                {
                                                    Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                    freshLoop = true;
                                                    break;
                                                }
                                            }

                                            foreach (Weapon x in weaponInventory)
                                            {
                                                if (x.Name == objName)
                                                {
                                                    Console.WriteLine($"You've already taken the {x.Name}.");
                                                    freshLoop = true;
                                                    break;
                                                }
                                            }
                                            if (freshLoop) { continue; }
                                            try
                                            {
                                                foreach (Item i in itemList) { if (i.Name == objName) { i.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, i, null, ItemList); success = true; break; } }
                                            }
                                            catch
                                            {
                                                foreach (Weapon w in itemList) { if (w.Name == objName) { w.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, null, w, ItemList); success = true; break; } }
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine($"You've stashed the item in your pack.");
                                            return room;
                                        }
                                    }

                                }
                                Console.WriteLine(message);
                                Console.WriteLine($"Would you like to peruse another item from the {Name}?");

                                while (true)
                                {
                                    string answer = Console.ReadLine().Trim().ToLower();
                                    if (answer == "yes" || answer == "y")
                                    {
                                        continueLoop = true;
                                        break;
                                    }
                                    else if (answer == "no" || answer == "n")
                                    {

                                        continueLoop = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Please answer 'yes' or 'no'.");
                                    }
                                }
                                a++;
                            }
                            catch //if not a number entered
                            {
                                Console.WriteLine("Please enter a number corresponding to your choice of action.");
                                continue;
                            }

                        }

                    }
                    else // these are specific cases for those features that may be searched more than once.
                    {
                        if (Name == "bookcase" || (Name == "rosewood chest" && Attribute))
                        {
                            Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden about the {Name}. It has been thoroughly {SpecificAttribute}.");

                        }
                        else if (Name == "rosewood chest" && !Attribute)
                        {
                            Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden within or around the {Name}. Even though it's been {SpecificAttribute} it still yields none of its secrets... if it has any.");
                        }
                        else
                        {
                            Console.WriteLine($"{Description} \nTry as hard as you might, you find no items hidden about the {Name}. It remains {SpecificAttribute}.");
                        }
                        return room;
                    }
                }
                else if (ItemList.Count != 0) // in every other non-specific case, the same or similar code replies
                {
                    foreach (Item item in itemList)
                    {
                        message += $"[{r}] {item.Name}\n";
                        r++;
                    }





                    bool continueLoop = true;
                    int a = 0;

                    while (continueLoop)
                    {
                        Console.WriteLine(message);
                        if (a > 0) { Console.WriteLine("Select another item from the list above or enter 'no'."); }
                        else { Console.WriteLine("\nWould you like to take a closer look at any of these items?"); }

                        string reply = Console.ReadLine().Trim().ToLower();
                        if (reply == "no" || reply == "n")
                        {



                            return room;


                        }
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if (reply1 < 1 || reply1 > r - 1)
                            {
                                Console.WriteLine($"Please enter a number between 1 and {r - 1}.");
                                continue;
                            }
                            else
                            {
                                try
                                {
                                    bool success = false;
                                    string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3));
                                    Console.WriteLine(objName);
                                    bool freshLoop = false;
                                    foreach (Item x in inventory)
                                    {
                                        if (x.Name == objName)
                                        {
                                            Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                            freshLoop = true;
                                            break;
                                        }
                                    }

                                    foreach (Weapon x in weaponInventory)
                                    {
                                        if (x.Name == objName)
                                        {
                                            Console.WriteLine($"You've already taken the {x.Name}.");
                                            freshLoop = true;
                                            break;
                                        }
                                    }
                                    if (freshLoop) { continue; }
                                    foreach (Item i in itemList)
                                    {
                                        if (i.Name == objName)
                                        {
                                            try
                                            {
                                                i.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, i, null, ItemList);

                                            }
                                            catch
                                            {
                                                foreach (Weapon y in itemList)
                                                {
                                                    if (y.Name == objName)
                                                    {
                                                        y.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, null, y, ItemList);

                                                    }
                                                }
                                            }
                                            finally { success = true; }
                                        }
                                    }

                                }// need another catch for if ItemList is left with no items inside
                                catch//for if there is only one item in list or chosen item is at top of list
                                {
                                    try
                                    {
                                        bool success = false;
                                        string objName = message.Substring(message.IndexOf((r - 1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r - 1).ToString()) + 3));
                                        Console.WriteLine(objName);
                                        bool freshLoop = false;
                                        foreach (Item x in inventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }

                                        foreach (Weapon x in weaponInventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already taken the {x.Name}.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }
                                        if (freshLoop) { continue; }
                                        try
                                        {
                                            foreach (Item i in itemList) { if (i.Name == objName) { i.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, i, null, ItemList); success = true; break; } }
                                        }
                                        catch
                                        {
                                            foreach (Weapon w in itemList) { if (w.Name == objName) { w.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, null, w, ItemList); success = true; break; } }
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine($"You've stashed the item in your pack.");
                                        return room;
                                    }
                                }

                            }


                            while (true)
                            {
                                Console.WriteLine(message);
                                Console.WriteLine($"Would you like to peruse another item from the {Name}?");

                                string answer = Console.ReadLine().Trim().ToLower();
                                try
                                {
                                    reply1 = int.Parse(answer);
                                    if (reply1 < 1 || reply1 > r - 1)
                                    {
                                        Console.WriteLine("Please enter a number between 1 and 3");
                                    }
                                    try
                                    {
                                        bool success = false;
                                        string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3));
                                        Console.WriteLine(objName);
                                        bool freshLoop = false;
                                        foreach (Item x in inventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }

                                        foreach (Weapon x in weaponInventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already taken the {x.Name}.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }
                                        if (freshLoop) { continue; }
                                        foreach (Item i in itemList)
                                        {
                                            if (i.Name == objName)
                                            {
                                                try
                                                {
                                                    i.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, i, null, ItemList);

                                                }
                                                catch
                                                {
                                                    foreach (Weapon y in itemList)
                                                    {
                                                        if (y.Name == objName)
                                                        {
                                                            y.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, null, y, ItemList);

                                                        }
                                                    }
                                                }
                                                finally { success = true; }
                                            }
                                        }

                                    }// need another catch for if ItemList is left with no items inside
                                    catch//for if there is only one item in list or chosen item is at top of list
                                    {
                                        try
                                        {
                                            bool success = false;
                                            string objName = message.Substring(message.IndexOf((r - 1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r - 1).ToString()) + 3));
                                            Console.WriteLine(objName);
                                            bool freshLoop = false;
                                            foreach (Item x in inventory)
                                            {
                                                if (x.Name == objName)
                                                {
                                                    Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                    freshLoop = true;
                                                    break;
                                                }
                                            }

                                            foreach (Weapon x in weaponInventory)
                                            {
                                                if (x.Name == objName)
                                                {
                                                    Console.WriteLine($"You've already taken the {x.Name}.");
                                                    freshLoop = true;
                                                    break;
                                                }
                                            }
                                            if (freshLoop) { continue; }
                                            try
                                            {
                                                foreach (Item i in itemList) { if (i.Name == objName) { i.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, i, null, ItemList); success = true; break; } }
                                            }
                                            catch
                                            {
                                                foreach (Weapon w in itemList) { if (w.Name == objName) { w.PickUpItem(carryCapacity, inventory, weaponInventory, 6, 0, null, w, ItemList); success = true; break; } }
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine($"You've stashed the item in your pack.");
                                            return room;
                                        }
                                    }

                                }
                                catch
                                {
                                    if (answer == "yes" || answer == "y")
                                    {
                                        continueLoop = true;
                                        break;
                                    }
                                    else if (answer == "no" || answer == "n")
                                    {

                                        continueLoop = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Please answer 'yes' or 'no'.");
                                    }
                                }
                            }
                            a++;
                        }
                        catch
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action.");
                            continue;
                        }

                    }
                }
                else
                {
                    if (Name == "bookcase" || Name == "rosewood chest")
                    {
                        Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden about the {Name}. It has been thoroughly {SpecificAttribute}.");

                    }
                    else
                    {
                        Console.WriteLine($"{Description} \nTry as hard as you might, you find no items hidden about the {Name}. It remains {SpecificAttribute}.");
                    }
                    return room;
                }
            }
            // In the case of features with no itemlist
            else
            {
                if (Name == "bookcase" || Name == "rosewood chest")
                {
                    Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden about the {Name}. It has been thoroughly {SpecificAttribute}.");

                }
                else
                {
                    Console.WriteLine($"{Description} \nTry as hard as you might, you find no items hidden about the {Name}. It remains {SpecificAttribute}.");
                }
                if ((Name.Contains("door") || Name.Contains("stair") || Name.Contains("corner")) && (SpecificAttribute == "unlocked"|| SpecificAttribute == "unblocked") && !Description.Contains("smouldering"))
                {
                    List<Room> upOrDown = this.CastDoor().Portal;
                    if (Name.Contains("door") || Name.Contains("portal"))
                    {
                        Console.WriteLine($"Would you like to go through this {Name}?");
                    }
                    else if (Name.Contains("corner"))
                    {
                        Console.WriteLine($"would you like to go around the {Name}?");
                    }
                    else if (upOrDown[0].Name == room.Name)
                    {
                        Console.WriteLine($"Would you like to ascend this {Name}?");
                    }
                    else
                    {
                        Console.WriteLine($"Would you like to descend this {Name}?");
                    }
                    while (true)
                    {
                        string reply = Console.ReadLine().Trim().ToLower();
                        if (string.IsNullOrEmpty(reply))
                        {
                            continue;
                        }
                        else if (reply == "n" || reply == "no")
                        {
                            return room;
                        }
                        else if (reply == "y" || reply == "yes")
                        {
                            if(room.Name == "armoury" && room.FirstVisit && !fieryEscape)
                            {
                                Console.WriteLine("You pull away from the door suddenly!");
                                Console.ReadKey(true);
                                Console.WriteLine("Around you the weapons are rattling upon their racks. The door trembles and the ground quakes beneath your feet. You can hear something - and *feel* something - very big and very heavy stomping up the lit stairway, each heavy footfall reverberating through the door. \nYou back away slowly, your clammy hand feverishly reaching to clasp a weapon. Your breath catches in your throat as whatever approaches stops outside your door.");
                                Console.ReadKey(true);
                                Console.WriteLine("You wait with bated breath in the crackling silence. Then, ");
                                Console.ReadKey(true);
                                Console.Write("a jostle of keys, tumblers turn and a door opens wide - but not your door. You listen closely, heart galloping in your all too tight chest, as the massive beast out in the antechamber strides through the double doors under the mosaic and beyond. Those doors close shut with an eerie creak, you hear them locked again, then the heavy footfalls fade into the distance...");
                                Console.ReadKey(true);
                                Console.WriteLine("Whatever that thing was,"
                                
                                + " you sense with an icy dread that battling it would be the very last thing you do.");
                                Console.ReadKey(true);
                                room.FirstVisit = false;
                            }
                            Room newRoom = this.CastDoor().Passage(room);
                            
                            return newRoom;
                        }
                        else
                        {
                            Console.WriteLine("Please enter 'yes' or 'no'.");
                            continue;
                        }
                    }
                    
                }
                return room;
            }
            return room;

        }

    }
    public class Door : Feature
    {
        public List<Room> Portal { get; set; }
        public string Passing { get; set; }
        public bool Dark {  get; set; }
        public Door(string name = "door", string description = "It's a pretty ordinary door", bool attribute = true, string specificAttribute = "locked", List<Item> itemList = null, List<Room> portal = null, string passing = "You pass through the door and into the next room...", bool dark = false)
        {
            Name = name;
            Description = description;
            Attribute = attribute;
            SpecificAttribute = specificAttribute;
            ItemList = itemList;
            Portal = portal;
            Passing = passing;
            Dark = dark;
        }
        public Room Passage(Room room, bool message = true)
        {
            if (Portal[0].Name == room.Name)
            {
                if (message) { Console.WriteLine($"{Passing}"); }
                return Portal[1];
            }
            else if (Portal[1].Name == room.Name)
            {
                if (message) { Console.WriteLine($"{Passing}"); }
                return Portal[0];
            }
            else
            {
                Console.WriteLine("Door.Passage() has failed. Check Portal list.");
                return room;
            }
            
        }

    }
}

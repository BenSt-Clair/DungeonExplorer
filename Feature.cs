using System;
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
        public void investigateFeature(List<Item> specialItems, Monster minotaur, Player player, List<Room> mosaicPortal)
        {
            if (Name == "strange mosaic")
            {
                Console.WriteLine("The tiles form and reform the image of a face, gazing down upon you. As you are about to inquire something, it speaks, as though in answer to the question that wasn't on your lips...\n\n\t'To fulfil what you desire most from this place, then your quest is easy;\n\tBestow upon me that which I love, steer away from all that makes me uneasy... '\n\nDo you have something in mind to show the mosaic?");
                Dialogue mosaicPuzzle = new Dialogue(this);
                if (mosaicPuzzle.getYesNoResponse())
                {
                    if (specialItems[6].SpecifyAttribute == "read")
                    {
                        Console.WriteLine("The excerpt from that book on cur'sed weapons leaps to mind. It seems you've discovered one of the cursed mosaics - probably the one Merigold said conferred only madness by giving answers to questions you didn't know you wanted answered...");
                    }
                    Dice D6 = new Dice(6);
                    string description = "You ponder the mosaic's riddle for a moment, then look through your backpack for something the mosaic desires...";
                    string parlance = "";
                    List<string> choices = new List<string>();
                    int option = 1;
                    int y = -1;
                    foreach (Item item in player.Inventory) 
                    {
                        choices.Add($"Gift the mosaic your {item.Name}?");
                        if (item.Name == "assorted jars")
                        {
                            y = option;
                        }
                        option++;
                    }
                    if (y != -1)
                    {
                        if (player.Inventory.Count > 4)
                        {
                            string answer = choices[y - 1];
                            choices.Remove(choices[y - 1]);
                            choices.Insert(3, answer);
                            
                        }
                        else
                        {
                            string answer = choices[y - 1];
                            choices.Remove(choices[y - 1]);
                            choices.Insert(0, answer);
                            
                        }
                    }
                    choices.Add("Step away from the mosaic for now...");
                    option = choices.Count - 1;
                    Dictionary<string, string> choice_answers = new Dictionary<string, string>();
                    List<string> randomResponse = new List<string>
                    {
                        "'I accept your gift, given so freely, but while I am grateful, it is not something I can bring myself to love...' ",
                        "'This gift you clearly wish to make me cherish, yet I'm still not quite comfortable enough to be used as furniture, if you follow my meaning...'",
                        "'This I accept, but it is not that for which my desire shall return your own...'",
                        "'Such a gift can so inspire! But what does it sew? Alas, this is no steeple, and so not your desire...'",
                        "'Is this what I must crave to grant your desire? I think not...'",
                        "'What is it that must be open to adoration? That'll grant your wish? Alas, 'tis not this...'"
                    };
                    foreach (string choice in choices)
                    {
                        choice_answers[choice] = randomResponse[D6.Roll(D6) - 1];
                    }
                    choice_answers["Gift the mosaic your assorted jars?"] = "You make the mosaic adore a jar. Now all it needs is a little push...";
                    choice_answers["Gift the mosaic your Topics Infernal?"] = "The mosaic will admire Topics Infernal, but adding swamps to those diabolical pictures scarcely improves them... or your situation.";
                    choice_answers["Gift the mosaic your Paradise Lost?"] = "You wish the mosaic to share - to lionize characters within the book, that it might give in return. But if it shared both its lion eyes then it'd no longer be able to watch you rack your brains over this puzzle...";
                    choice_answers["Step away from the mosaic for now..."] = "The mosaic watches you leave impassively...";
                    if (player.Inventory.Count > 4 && y!=-1)
                    {
                        switch (mosaicPuzzle.LoopParle(choice_answers, choices, description, parlance, 3, option, player))
                        {
                            
                            case 1:
                                this.CastDoor().Name = "ajar mosaic door";
                                this.CastDoor().Passing = "You push the strange mosaic and it opens out into an unfamiliar corridor...";
                                this.CastDoor().Portal = mosaicPortal;
                                this.CastDoor().Attribute = false;
                                this.CastDoor().SpecificAttribute = "unlocked";
                                return;
                            
                            default:
                                Console.WriteLine("You step away. Is it just you or does your backpack feel significantly lighter?");
                                break;
                        }
                    }
                    else if (y!=-1)
                    {
                        switch (mosaicPuzzle.LoopParle(choice_answers, choices, description, parlance, 0, option, player))
                        {
                            case 1:
                                this.CastDoor().Name = "ajar mosaic door";
                                this.CastDoor().Passing = "You push the strange mosaic and it opens out into an unfamiliar corridor...";
                                this.CastDoor().Portal = mosaicPortal;
                                this.CastDoor().Attribute = false;
                                this.CastDoor().SpecificAttribute = "unlocked";
                                return;
                            default:
                                Console.WriteLine("You step away. Is it just you or does your backpack feel significantly lighter?");
                                break;
                        }
                    }
                    else
                    {
                        mosaicPuzzle.LoopParle(choice_answers, choices, description, parlance, option, player);
                        Console.WriteLine("You step away. Is it just you or does your backpack feel significantly lighter?");
                    }
                }
                return;
            }
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
                        this.Attribute = true;
                        this.SpecificAttribute = "studied";
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
        public Room Search(int carryCapacity, List<Item> inventory, List<Weapon> weaponInventory, Room room, bool fieryEscape, Player player, Door stairwayToLower, List<Room> destinations, List<Item> specialItems = null, Combat battle = null, Room secretChamber = null, Monster goblin = null, Monster gnoll = null, List<Item> MGItems = null)
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
                if (Name == "disturbing statue" && ItemList.Count == 0 && Description.Contains("You're about to turn away when, just behind the statue, you spy something else..."))
                {
                    Description = Description.Substring(0, Description.IndexOf("\n"));
                }
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
                            if ((Name.Contains("door") || Name.Contains("stair") || Name.Contains("corner") || Name.Contains("hole")) && (SpecificAttribute == "unlocked" || SpecificAttribute == "unblocked") && !Description.Contains("smouldering"))
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
                                    string reply2 = Console.ReadLine().Trim().ToLower();
                                    if (string.IsNullOrEmpty(reply2))
                                    {
                                        continue;
                                    }
                                    else if (reply2 == "n" || reply2 == "no")
                                    {
                                        return room;
                                    }
                                    else if (reply2 == "y" || reply2 == "yes")
                                    {
                                        if (room.Name == "armoury" && room.FirstVisit)
                                        {
                                            if (!fieryEscape)
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
                                            /*else
                                            {
                                                Console.WriteLine("You pull away from the door suddenly!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Around you the weapons are rattling upon their racks. The door trembles and the ground quakes beneath your feet. You can hear something - and *feel* something - very big and very heavy charging up to the double doors from the rooms beyond. Each heavy footfall reverberates through the armoury door. \nYou back away slowly, your clammy hand feverishly reaching to clasp a weapon. Your breath catches in your throat as whatever it is swings the double doors wide, enters the antechamber and stops outside your door...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("You wait with bated breath in the crackling silence, listening to it sniff the air, as though it can almost catch your scent in spite of the smoke from the flames below...");
                                                Console.ReadKey(true);
                                                Console.Write("Heart galloping, you're almost sure the beast can hear its febrile tattoo in your all too tight chest for a moment. Then, responding to the urgent yells of the CurseBreaker's forces frenziedly trying to douse the flames somewhere below, it turns. The monster storms down the fiery stairway and into the heart of the inferno...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("You feel relief flood through you, resting a hand on the table to steady yourself a moment. \nHopefully, Whatever that thing was,"

                                                + " it will be too preoccupied with the fire to get that close to finding you again.");
                                                Console.ReadKey(true);
                                                room.FirstVisit = false;
                                            }*/
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
                    if ((Name.Contains("door") || Name.Contains("stair") || Name.Contains("corner") || Name.Contains("hole")) && (SpecificAttribute == "unlocked" || SpecificAttribute == "unblocked" || SpecificAttribute == "scaled") && !Description.Contains("smouldering"))
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
                                if (room.Name == "armoury" && room.FirstVisit)
                                {
                                    if (!fieryEscape)
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
                                    /*else
                                    {
                                        Console.WriteLine("You pull away from the door suddenly!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Around you the weapons are rattling upon their racks. The door trembles and the ground quakes beneath your feet. You can hear something - and *feel* something - very big and very heavy charging up to the double doors from the rooms beyond. Each heavy footfall reverberates through the armoury door. \nYou back away slowly, your clammy hand feverishly reaching to clasp a weapon. Your breath catches in your throat as whatever it is swings the double doors wide, enters the antechamber and stops outside your door...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("You wait with bated breath in the crackling silence, listening to it sniff the air, as though it can almost catch your scent in spite of the smoke from the flames below...");
                                        Console.ReadKey(true);
                                        Console.Write("Heart galloping, you're almost sure the beast can hear its febrile tattoo in your all too tight chest for a moment. Then, responding to the urgent yells of the CurseBreaker's forces frenziedly trying to douse the flames somewhere below, it turns. The monster storms down the fiery stairway and into the heart of the inferno...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("You feel relief flood through you, resting a hand on the table to steady yourself a moment. \nHopefully, Whatever that thing was,"

                                        + " it will be too preoccupied with the fire to get that close to finding you again.");
                                        Console.ReadKey(true);
                                        room.FirstVisit = false;
                                    }*/
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
            }
            // In the case of features with no itemlist
            else
            {
                Merigold merigold = new Merigold(player, room);
                if (Name == "laboratory" && SpecificAttribute == "unapproached")
                {
                    Console.WriteLine(Description);
                    Dice D120 = new Dice(120);
                    Dice D60 = new Dice(60);
                    Dice D40 = new Dice(40);
                    Dice D30 = new Dice(30);
                    Dice D24 = new Dice(24);
                    Dice D20 = new Dice(20);
                    Dice D15 = new Dice(15);
                    Dice D10 = new Dice(10);
                    Dice D1 = new Dice(1);
                    Dice D2 = new Dice(2);
                    Dice D3 = new Dice(3);
                    Dice D4 = new Dice(4);
                    Console.WriteLine("Would you like to, perhaps, clear your throat and alert the bespectacled wizard to your presence?");
                    

                    if (merigold.getYesNoResponse())
                    {
                        List<Dice> endOfMidGameChoice = merigold.MerigoldPlotPoint(specialItems, battle, secretChamber, goblin, gnoll, MGItems, stairwayToLower);
                        Attribute = true;
                        SpecificAttribute = "dishevelled";
                        int destination = 0;
                        if (endOfMidGameChoice.Count == 1)
                        {
                            player.midnightClock = new System.Diagnostics.Stopwatch();
                            player.midnightClock.Start();
                            if (endOfMidGameChoice[0].faces == D1.faces)
                            {
                                Console.ReadKey(true);
                                Console.WriteLine("You figure your best bet is to find the route through the subterranean levels of the tower and confront this Eldritch ArchFey the CurseBreaker needs for his sordid ritual to be complete." +
                                    "\n  Without a moment to lose, and midnight fast approaching, you do what you've got to do - and quickly!");
                                return room;
                            }
                            else if (endOfMidGameChoice[0].faces == D4.faces)
                            {
                                Console.ReadKey(true);
                                Console.WriteLine("Confident for now that you can find your own way towards your goal, you leave Merigold behind...");
                                return room;
                            }
                            else
                            {
                                Console.ReadKey(true);
                                Console.WriteLine("You feverishly turn Merigold's words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                return room;
                            }
                        }
                        else
                        {
                            Merigold m = new Merigold(player, room);
                            if (endOfMidGameChoice[0].faces == D120.faces)
                            {
                                
                                Console.WriteLine("Taking no heed of Merigold's warnings you stride gallantly to the portal. You spy landscapes and settings flit past your vision through its crackling whorl of sorcery, too fast to more than glimpse as the scenes rapidly shuffle before you. \nYou tense your muscles, trust in lady luck, then gallantly dive forward...");
                                destination = 0;
                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                foreach (Dice d in endOfMidGameChoice)
                                {
                                    Console.ReadKey(true);
                                    int x = d.Roll(d);
                                    Console.WriteLine($"You rolled {x}");
                                    destination += x;
                                }
                                if(destination >115 ||  destination < 6)
                                {
                                    return destinations[10];
                                }
                                else if(destination > 110 || destination < 11)
                                {
                                    return destinations[9];
                                }
                                else if (destination > 105 || destination < 16)
                                {
                                    return destinations[11];
                                }
                                else if (destination > 100 || destination < 21)
                                {
                                    return destinations[8];
                                }
                                else if (destination > 95 || destination < 26)
                                {
                                    return destinations[7];
                                }
                                else if (destination > 90 || destination < 31)
                                {
                                    return destinations[6];
                                }
                                else if (destination > 85 || destination < 36)
                                {
                                    return destinations[5];
                                }
                                else if (destination > 80 || destination < 41)
                                {
                                    return destinations[4];
                                }
                                else if (destination > 75 || destination < 46)
                                {
                                    return destinations[3];
                                }
                                else if (destination > 70 || destination < 51)
                                {
                                    return destinations[2];
                                }
                                else if (destination > 65 || destination < 56)
                                {
                                    return destinations[1];
                                }
                                else
                                {
                                    return destinations[0];
                                }
                            }
                            else if (endOfMidGameChoice[0].faces == D60.faces)
                            {
                                Console.WriteLine("Merigold watches as you produce the artefacts you wish him to use. Though he makes an outward show of being phlegmatic, you can sense his anxiety radiating off of him." +
                                    "\nAfter you're done he peers up at you. 'Is that all?' " +
                                    "\n\n You return a tight and solemn nod." +
                                    "\n\n  The aged wizard runs a nervous hand through his wispy hair. 'I can't lie, it's less than I expected. I may not be able to steer the portal very easily with this. Are you sure you don't want to hunt for any more artefacts first?'");
                                
                                if (m.getYesNoResponse())
                                {
                                    Console.WriteLine("You tell Merigold you're prepared to take the risks...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\t'Very well then,' Merigold replies heavily, 'Where is it you'd like to go?'");
                                    if (endOfMidGameChoice[2].faces == D1.faces)//use portal to defeat CB
                                    {
                                        Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                            "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                            "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                        switch (m.getIntResponse(4))
                                        {
                                            case 1:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {
                                                    
                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[11];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[5];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[6];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[7];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[4];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[1];//oubliette
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[3];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[2];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[0];// highest parapet
                                                }
                                            case 2:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[11];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[5];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[6];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[7];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[4];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[0];// highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[1];// oubliette
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[2];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[3];// secret chamber
                                                }
                                            default:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[11];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[5];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[6];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[7];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[4];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[0];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[3];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[2];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[1];// oubliette
                                                }
                                        }
                                    }
                                    else//use portal to flee
                                    {
                                        Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                            "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                            "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                            "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                        switch (m.getIntResponse(5))
                                        {
                                            case 1:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[2];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[9];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[10];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[11];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[4];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[5];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[6];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[7];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[8];// oubliette
                                                }
                                            case 2:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[11];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[9];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[10];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[8];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[7];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[4];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[2];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[5];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[6];// oubliette
                                                }
                                            case 3:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[2];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[4];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[5];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[6];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[11];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[10];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[8];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[9];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[7];// oubliette
                                                }
                                            default:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[4];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[7];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[8];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[9];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[10];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[11];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[2];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[6];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[5];// oubliette
                                                }
                                        }
                                    }
                                }
                                else
                                {
                                    endOfMidGameChoice = new List<Dice> { D2};
                                    player.midnightClock = new System.Diagnostics.Stopwatch();
                                    player.midnightClock.Start();
                                    Console.ReadKey(true);
                                    Console.WriteLine("You feverishly turn Merigold's words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                    return room;
                                    
                                }
                                    
                            }
                            else if (endOfMidGameChoice[0].faces == D40.faces)
                            {
                                Console.WriteLine("Merigold watches as you produce the artefacts you wish him to use. Though he makes an outward show of being phlegmatic, you can sense his anxiety radiating off of him." +
                                    "\nAfter you're done he peers up at you. 'Well, it could be worse... Are you sure that's all you have?' " +
                                    "\n\n You return a tight and solemn nod." +
                                    "\n\n  The aged wizard runs a nervous hand through his wispy hair. 'I'm not going to tell you that you've the best chances in the world, but with a bit of luck, even if I don't quite manage to send you to your destination, you should end up somewhere nearby. Are you sure you don't want to hunt for any more artefacts first?'");

                                if (m.getYesNoResponse())
                                {
                                    Console.WriteLine("You tell Merigold you're prepared to take the risks...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\t'Very well then,' Merigold replies heavily, 'Where is it you'd like to go?'");
                                    if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                                    {
                                        Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                            "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                            "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                        switch (m.getIntResponse(4))
                                        {
                                            case 1:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[6];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[7];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[1];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[3];//oubliette
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[2];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[0];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[0];// highest parapet
                                                }
                                            case 2:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[6];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[7];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[0];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[1];// highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[2];// oubliette
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[3];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[3];// secret chamber
                                                }
                                            default:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[6];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[7];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[0];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[3];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[2];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[1];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[1];// oubliette
                                                }
                                        }
                                    }
                                    else//use portal to flee
                                    {
                                        Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                            "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                            "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                            "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                        switch (m.getIntResponse(5))
                                        {
                                            case 1:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[2];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[9];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[10];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[5];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[6];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[7];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[8];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[8];// oubliette
                                                }
                                            case 2:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[10];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[8];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[7];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[4];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[2];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[5];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[6];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[6];// oubliette
                                                }
                                            case 3:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[2];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[4];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[5];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[6];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[10];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[8];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[9];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[7];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[7];// oubliette
                                                }
                                            default:
                                                Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 115 || destination < 6)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 110 || destination < 11)
                                                {
                                                    return destinations[4];
                                                }
                                                else if (destination > 105 || destination < 16)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 100 || destination < 21)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 95 || destination < 26)
                                                {
                                                    return destinations[7];//dragon's lair
                                                }
                                                else if (destination > 90 || destination < 31)
                                                {
                                                    return destinations[8];//bank vault
                                                }
                                                else if (destination > 85 || destination < 36)
                                                {
                                                    return destinations[9];// desert island
                                                }
                                                else if (destination > 80 || destination < 41)
                                                {
                                                    return destinations[10];//huge barracks
                                                }
                                                else if (destination > 75 || destination < 46)
                                                {
                                                    return destinations[2];//highest parapet
                                                }
                                                else if (destination > 70 || destination < 51)
                                                {
                                                    return destinations[6];//secret chamber
                                                }
                                                else if (destination > 65 || destination < 56)
                                                {
                                                    return destinations[5];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[5];// oubliette
                                                }
                                        }
                                    }
                                }
                                else
                                {
                                    endOfMidGameChoice = new List<Dice> { D2 };
                                    player.midnightClock = new System.Diagnostics.Stopwatch();
                                    player.midnightClock.Start();
                                    Console.ReadKey(true);
                                    Console.WriteLine("You tell Merigold you'll head back when you're ready, all the while feverishly turning his words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                    return room;

                                }
                            }
                            else if (endOfMidGameChoice[0].faces == D30.faces)
                            {
                                Console.WriteLine("Merigold watches as you produce the artefacts you wish him to use. At first he seems nervous, but the more items you display before him the more evident is his relief." +
                                    "\nAfter you're done he peers up at you. 'Good... This is a good haul. Not ideal, perhaps, but I believe you have an excellent chance with this. Are you sure that's all you have?' " +
                                    "\n\n You return a confident nod." +
                                    "\n\n  The aged wizard rubs his hands together. 'With a bit of luck, even if I don't quite manage to send you to your destination, you should end up somewhere nearby. Are you sure you don't want to hunt for any more artefacts first?'");

                                if (m.getYesNoResponse())
                                {
                                    Console.WriteLine("You tell Merigold you're prepared to take the risks...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\t'Very well then,' Merigold replies heavily, 'Where is it you'd like to go?'");
                                    if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                                    {
                                        Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                            "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                            "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                        switch (m.getIntResponse(4))
                                        {
                                            case 1:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[6];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[7];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[1];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[3];//oubliette
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[2];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[0];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[0];// highest parapet
                                                }
                                            case 2:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[6];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[7];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[0];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[1];// highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[2];// oubliette
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[3];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[3];// secret chamber
                                                }
                                            default:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[8];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[6];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[7];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[0];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[3];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[2];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[1];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[1];// oubliette
                                                }
                                        }
                                    }
                                    else//use portal to flee
                                    {
                                        Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                            "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                            "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                            "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                        switch (m.getIntResponse(5))
                                        {
                                            case 1:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[2];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[9];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[10];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[5];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[6];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[7];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[8];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[8];// oubliette
                                                }
                                            case 2:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[10];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[8];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[7];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[4];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[2];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[5];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[6];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[6];// oubliette
                                                }
                                            case 3:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[2];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[4];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[5];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[6];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[10];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[8];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[9];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[7];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[7];// oubliette
                                                }
                                            default:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[4];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[7];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[8];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[9];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[10];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[2];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[6];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[5];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[5];// oubliette
                                                }
                                        }
                                    }
                                }
                                else
                                {
                                    endOfMidGameChoice = new List<Dice> { D2 };
                                    player.midnightClock = new System.Diagnostics.Stopwatch();
                                    player.midnightClock.Start();
                                    Console.ReadKey(true);
                                    Console.WriteLine("You tell Merigold you'll head back when you're ready, all the while feverishly turning his words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                    return room;

                                }
                            }
                            else if (endOfMidGameChoice[0].faces == D24.faces)
                            {
                                Console.WriteLine("Merigold watches as you produce the artefacts you wish him to use. At first he seems nervous, but the more items you display before him the more evident is his relief." +
                                    "\nAfter you're done he peers up at you. 'Good... This is a good haul. Not ideal, perhaps, but I believe you have an excellent chance with this. Are you sure that's all you have?' " +
                                    "\n\n You return a confident nod." +
                                    "\n\n  The aged wizard rubs his hands together. 'With a bit of luck, even if I don't quite manage to send you to your destination, you should end up somewhere nearby. Are you sure you don't want to hunt for any more artefacts first?'");

                                if (m.getYesNoResponse())
                                {
                                    Console.WriteLine("You tell Merigold you're prepared to take the risks...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\t'Very well then,' Merigold replies heavily, 'Where is it you'd like to go?'");
                                    if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                                    {
                                        Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                            "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                            "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                        switch (m.getIntResponse(4))
                                        {
                                            case 1:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                                destination = 0;
                                                Console.ReadKey(true);
                                                endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[6];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[7];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[4];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[1];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[3];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[2];//oubliette
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[0];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[0];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[0];// highest parapet
                                                }
                                            case 2:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[6];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[7];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[4];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[0];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[1];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[2];// highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[3];// oubliette
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[3];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[3];// secret chamber
                                                }
                                            default:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[9];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[5];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[6];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[7];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[4];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[0];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[3];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[2];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[1];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[1];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[1];// oubliette
                                                }
                                        }
                                    }
                                    else//use portal to flee
                                    {
                                        Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                            "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                            "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                            "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                        switch (m.getIntResponse(5))
                                        {
                                            case 1:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[2];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[9];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[10];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[5];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[6];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[7];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[8];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[8];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[8];// oubliette
                                                }
                                            case 2:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[10];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[8];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[7];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[4];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[2];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[5];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[6];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[6];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[6];// oubliette
                                                }
                                            case 3:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[2];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[4];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[5];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[6];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[8];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[9];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[7];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[7];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[7];// oubliette
                                                }
                                            default:
                                                Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                    "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Suddenly you lurch backwards!");
                                                Console.ReadKey(true);
                                                Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                    "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                                Console.ReadKey
                                                    (true);
                                                Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                    "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                                Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                                Console.ReadKey(true);
                                                destination = 0;
                                                Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                                foreach (Dice d in endOfMidGameChoice)
                                                {

                                                    int x = d.Roll(d);
                                                    Console.WriteLine($"You rolled {x}");
                                                    Console.ReadKey(true);
                                                    destination += x;
                                                }
                                                if (destination > 116 || destination < 7)
                                                {
                                                    return destinations[3];
                                                }
                                                else if (destination > 111 || destination < 12)
                                                {
                                                    return destinations[4];
                                                }
                                                else if (destination > 106 || destination < 17)
                                                {
                                                    return destinations[1];
                                                }
                                                else if (destination > 101 || destination < 22)
                                                {
                                                    return destinations[0];
                                                }
                                                else if (destination > 96 || destination < 27)
                                                {
                                                    return destinations[7];//dragon's lair
                                                }
                                                else if (destination > 91 || destination < 32)
                                                {
                                                    return destinations[8];//bank vault
                                                }
                                                else if (destination > 86 || destination < 37)
                                                {
                                                    return destinations[9];// desert island
                                                }
                                                else if (destination > 81 || destination < 42)
                                                {
                                                    return destinations[2];//huge barracks
                                                }
                                                else if (destination > 76 || destination < 47)
                                                {
                                                    return destinations[6];//highest parapet
                                                }
                                                else if (destination > 71 || destination < 52)
                                                {
                                                    return destinations[5];//secret chamber
                                                }
                                                else if (destination > 66 || destination < 57)
                                                {
                                                    return destinations[5];// broom closet
                                                }
                                                else
                                                {
                                                    return destinations[5];// oubliette
                                                }
                                        }
                                    }
                                }
                                else
                                {
                                    endOfMidGameChoice = new List<Dice> { D2 };
                                    player.midnightClock = new System.Diagnostics.Stopwatch();
                                    player.midnightClock.Start();
                                    Console.ReadKey(true);
                                    Console.WriteLine("You tell Merigold you'll head back when you're ready, all the while feverishly turning his words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                    return room;

                                }
                            }
                            else if (endOfMidGameChoice[0].faces == D20.faces)
                            {
                                Console.WriteLine("You display no less than ten artefacts before Merigold's astonished eyes...");
                                Console.ReadKey(true);
                                Console.WriteLine("\t'Very well then,' Merigold replies elatedly, 'Where is it you'd like to go?'");
                                if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                                {
                                    Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                        "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                        "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                    switch (m.getIntResponse(4))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[1];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[3];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[2];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[0];//oubliette
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[0];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[0];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[0];// highest parapet
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[0];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[1];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[2];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[3];// highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[3];// oubliette
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[3];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[3];// secret chamber
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[0];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[3];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[2];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[1];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[1];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[1];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[1];// oubliette
                                            }
                                    }
                                }
                                else//use portal to flee
                                {
                                    Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                        "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                        "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                        "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                    switch (m.getIntResponse(5))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[5];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[6];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[7];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[8];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[8];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[8];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[8];// oubliette
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[4];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[2];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[5];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[6];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[6];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[6];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[6];// oubliette
                                            }
                                        case 3:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[10];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[8];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[9];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[7];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[7];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[7];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[7];// oubliette
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[4];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[8];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[2];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[6];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[5];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[5];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[5];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[5];// oubliette
                                            }
                                    }
                                }
                            }
                            else if (endOfMidGameChoice[0].faces == D15.faces)
                            {
                                Console.WriteLine("You display no less than eleven artefacts before Merigold's astonished eyes...");
                                Console.ReadKey(true);
                                Console.WriteLine("\t'Very well then,' Merigold replies elatedly, 'Where is it you'd like to go?'");
                                if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                                {
                                    Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                        "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                        "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                    switch (m.getIntResponse(4))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[1];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[3];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[2];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[0];//oubliette
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[0];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[0];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[0];// highest parapet
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[0];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[1];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[2];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[3];// highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[3];// oubliette
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[3];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[3];// secret chamber
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[0];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[3];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[2];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[1];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[1];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[1];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[1];// oubliette
                                            }
                                    }
                                }
                                else//use portal to flee
                                {
                                    Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                        "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                        "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                        "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                    switch (m.getIntResponse(5))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[5];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[6];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[7];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[8];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[8];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[8];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[8];// oubliette
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[9];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[4];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[2];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[5];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[6];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[6];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[6];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[6];// oubliette
                                            }
                                        case 3:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[10];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[8];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[9];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[7];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[7];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[7];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[7];// oubliette
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 117 || destination < 8)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 112 || destination < 13)
                                            {
                                                return destinations[4];
                                            }
                                            else if (destination > 107 || destination < 18)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 102 || destination < 23)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 97 || destination < 28)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 92 || destination < 33)
                                            {
                                                return destinations[8];//bank vault
                                            }
                                            else if (destination > 87 || destination < 38)
                                            {
                                                return destinations[2];// desert island
                                            }
                                            else if (destination > 82 || destination < 43)
                                            {
                                                return destinations[6];//huge barracks
                                            }
                                            else if (destination > 77 || destination < 48)
                                            {
                                                return destinations[5];//highest parapet
                                            }
                                            else if (destination > 72 || destination < 53)
                                            {
                                                return destinations[5];//secret chamber
                                            }
                                            else if (destination > 67 || destination < 58)
                                            {
                                                return destinations[5];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[5];// oubliette
                                            }
                                    }
                                }
                            }
                            else if (endOfMidGameChoice[0].faces == D10.faces)
                            {
                                Console.WriteLine("You display all of the artefacts before Merigold's astonished eyes... 'My goodness,' he breathes disbelievingly, 'My dear fellow how did you do it? No. Don't answer. We haven't time to waste...'");
                                Console.ReadKey(true);
                                Console.WriteLine("\t'Where is it you'd like to go?'");
                                if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)
                                {
                                    Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                        "\n[2] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                    switch (m.getIntResponse(3))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            return destinations[0];
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            return destinations[1];
                                        
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                        "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                        "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                        "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                    switch (m.getIntResponse(5))
                                    {
                                        case 1 :
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            return destinations[8];
                                        case 2 :
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            return destinations[6];
                                        case 3 :
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            return destinations[7];
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            return destinations[5];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You decide you'd better leave him to focus on what he's doing. It looks important...");
                        return room;
                    }
                }
                else if (Name == "laboratory")
                {
                    Dice D120 = new Dice(120);
                    Dice D60 = new Dice(60);
                    Dice D40 = new Dice(40);
                    Dice D30 = new Dice(30);
                    Dice D24 = new Dice(24);
                    Dice D20 = new Dice(20);
                    Dice D15 = new Dice(15);
                    Dice D10 = new Dice(10);
                    Dice D1 = new Dice(1);
                    Dice D2 = new Dice(2);
                    Dice D3 = new Dice(3);
                    Dice D4 = new Dice(4);
                    List<Dice> endOfMidGameChoice = merigold.ReturnToMerigoldDialogue(specialItems, battle, secretChamber, goblin, gnoll, MGItems, stairwayToLower);
                    int destination = 0;
                    if (endOfMidGameChoice.Count == 1)
                    {
                        if (player.midnightClock == null)
                        {
                            player.midnightClock = new System.Diagnostics.Stopwatch();
                            player.midnightClock.Start();
                        }
                        if (endOfMidGameChoice[0].faces == D1.faces)
                        {
                            Console.ReadKey(true);
                            Console.WriteLine("You figure your best bet is to find the route through the subterranean levels of the tower and confront this Eldritch ArchFey the CurseBreaker needs for his sordid ritual to be complete." +
                                "\n  Without a moment to lose, and midnight fast approaching, you do what you've got to do - and quickly!");
                            return room;
                        }
                        else if (endOfMidGameChoice[0].faces == D4.faces)
                        {
                            Console.ReadKey(true);
                            Console.WriteLine("Confident for now that you can find your own way towards your goal, you leave Merigold behind...");
                            return room;
                        }
                        else
                        {
                            Console.ReadKey(true);
                            Console.WriteLine("You feverishly turn Merigold's words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                            return room;
                        }
                    }
                    else
                    {
                        Merigold m = new Merigold(player, room);
                        if (endOfMidGameChoice[0].faces == D120.faces)
                        {

                            Console.WriteLine("Taking no heed of Merigold's warnings you stride gallantly to the portal. You spy landscapes and settings flit past your vision through its crackling whorl of sorcery, too fast to more than glimpse as the scenes rapidly shuffle before you. \nYou tense your muscles, trust in lady luck, then gallantly dive forward...");
                            destination = 0;
                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                            foreach (Dice d in endOfMidGameChoice)
                            {
                                Console.ReadKey(true);
                                int x = d.Roll(d);
                                Console.WriteLine($"You rolled {x}");
                                destination += x;
                            }
                            if (destination > 115 || destination < 6)
                            {
                                return destinations[10];
                            }
                            else if (destination > 110 || destination < 11)
                            {
                                return destinations[9];
                            }
                            else if (destination > 105 || destination < 16)
                            {
                                return destinations[11];
                            }
                            else if (destination > 100 || destination < 21)
                            {
                                return destinations[8];
                            }
                            else if (destination > 95 || destination < 26)
                            {
                                return destinations[7];
                            }
                            else if (destination > 90 || destination < 31)
                            {
                                return destinations[6];
                            }
                            else if (destination > 85 || destination < 36)
                            {
                                return destinations[5];
                            }
                            else if (destination > 80 || destination < 41)
                            {
                                return destinations[4];
                            }
                            else if (destination > 75 || destination < 46)
                            {
                                return destinations[3];
                            }
                            else if (destination > 70 || destination < 51)
                            {
                                return destinations[2];
                            }
                            else if (destination > 65 || destination < 56)
                            {
                                return destinations[1];
                            }
                            else
                            {
                                return destinations[0];
                            }
                        }
                        else if (endOfMidGameChoice[0].faces == D60.faces)
                        {
                            Console.WriteLine("Merigold watches as you produce the artefacts you wish him to use. Though he makes an outward show of being phlegmatic, you can sense his anxiety radiating off of him." +
                                "\nAfter you're done he peers up at you. 'Is that all?' " +
                                "\n\n You return a tight and solemn nod." +
                                "\n\n  The aged wizard runs a nervous hand through his wispy hair. 'I can't lie, it's less than I expected. I may not be able to steer the portal very easily with this. Are you sure you don't want to hunt for any more artefacts first?'");

                            if (m.getYesNoResponse())
                            {
                                Console.WriteLine("You tell Merigold you're prepared to take the risks...");
                                Console.ReadKey(true);
                                Console.WriteLine("\t'Very well then,' Merigold replies heavily, 'Where is it you'd like to go?'");
                                if (endOfMidGameChoice[2].faces == D1.faces)//use portal to defeat CB
                                {
                                    Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                        "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                        "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                    switch (m.getIntResponse(4))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[5];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[6];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[7];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[4];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[1];//oubliette
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[3];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[2];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[0];// highest parapet
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[5];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[6];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[7];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[4];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[0];// highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[1];// oubliette
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[2];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[3];// secret chamber
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[5];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[6];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[7];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[4];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[0];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[3];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[2];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[1];// oubliette
                                            }
                                    }
                                }
                                else//use portal to flee
                                {
                                    Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                        "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                        "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                        "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                    switch (m.getIntResponse(5))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[9];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[10];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[11];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[4];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[5];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[6];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[7];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[8];// oubliette
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[11];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[9];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[10];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[8];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[7];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[4];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[2];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[5];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[6];// oubliette
                                            }
                                        case 3:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[5];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[6];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[11];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[10];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[8];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[9];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[7];// oubliette
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll two D60...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[4];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[8];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[9];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[10];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[11];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[2];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[6];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[5];// oubliette
                                            }
                                    }
                                }
                            }
                            else
                            {
                                endOfMidGameChoice = new List<Dice> { D2 };
                                player.midnightClock = new System.Diagnostics.Stopwatch();
                                player.midnightClock.Start();
                                Console.ReadKey(true);
                                Console.WriteLine("You feverishly turn Merigold's words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                return room;

                            }

                        }
                        else if (endOfMidGameChoice[0].faces == D40.faces)
                        {
                            Console.WriteLine("Merigold watches as you produce the artefacts you wish him to use. Though he makes an outward show of being phlegmatic, you can sense his anxiety radiating off of him." +
                                "\nAfter you're done he peers up at you. 'Well, it could be worse... Are you sure that's all you have?' " +
                                "\n\n You return a tight and solemn nod." +
                                "\n\n  The aged wizard runs a nervous hand through his wispy hair. 'I'm not going to tell you that you've the best chances in the world, but with a bit of luck, even if I don't quite manage to send you to your destination, you should end up somewhere nearby. Are you sure you don't want to hunt for any more artefacts first?'");

                            if (m.getYesNoResponse())
                            {
                                Console.WriteLine("You tell Merigold you're prepared to take the risks...");
                                Console.ReadKey(true);
                                Console.WriteLine("\t'Very well then,' Merigold replies heavily, 'Where is it you'd like to go?'");
                                if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                                {
                                    Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                        "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                        "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                    switch (m.getIntResponse(4))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[6];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[7];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[1];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[3];//oubliette
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[2];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[0];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[0];// highest parapet
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[6];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[7];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[0];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[1];// highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[2];// oubliette
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[3];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[3];// secret chamber
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[6];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[7];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[0];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[3];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[2];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[1];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[1];// oubliette
                                            }
                                    }
                                }
                                else//use portal to flee
                                {
                                    Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                        "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                        "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                        "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                    switch (m.getIntResponse(5))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[9];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[10];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[5];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[6];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[7];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[8];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[8];// oubliette
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[10];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[8];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[7];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[4];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[2];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[5];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[6];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[6];// oubliette
                                            }
                                        case 3:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[5];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[6];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[10];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[8];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[9];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[7];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[7];// oubliette
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates whatever meagre magic he can and then begins to weave enchantments about the portal. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll three D40...\n[you need your dice rolls to sum up to as close to 61 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 115 || destination < 6)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 110 || destination < 11)
                                            {
                                                return destinations[4];
                                            }
                                            else if (destination > 105 || destination < 16)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 100 || destination < 21)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 95 || destination < 26)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 90 || destination < 31)
                                            {
                                                return destinations[8];//bank vault
                                            }
                                            else if (destination > 85 || destination < 36)
                                            {
                                                return destinations[9];// desert island
                                            }
                                            else if (destination > 80 || destination < 41)
                                            {
                                                return destinations[10];//huge barracks
                                            }
                                            else if (destination > 75 || destination < 46)
                                            {
                                                return destinations[2];//highest parapet
                                            }
                                            else if (destination > 70 || destination < 51)
                                            {
                                                return destinations[6];//secret chamber
                                            }
                                            else if (destination > 65 || destination < 56)
                                            {
                                                return destinations[5];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[5];// oubliette
                                            }
                                    }
                                }
                            }
                            else
                            {
                                endOfMidGameChoice = new List<Dice> { D2 };
                                player.midnightClock = new System.Diagnostics.Stopwatch();
                                player.midnightClock.Start();
                                Console.ReadKey(true);
                                Console.WriteLine("You tell Merigold you'll head back when you're ready, all the while feverishly turning his words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                return room;

                            }
                        }
                        else if (endOfMidGameChoice[0].faces == D30.faces)
                        {
                            Console.WriteLine("Merigold watches as you produce the artefacts you wish him to use. At first he seems nervous, but the more items you display before him the more evident is his relief." +
                                "\nAfter you're done he peers up at you. 'Good... This is a good haul. Not ideal, perhaps, but I believe you have an excellent chance with this. Are you sure that's all you have?' " +
                                "\n\n You return a confident nod." +
                                "\n\n  The aged wizard rubs his hands together. 'With a bit of luck, even if I don't quite manage to send you to your destination, you should end up somewhere nearby. Are you sure you don't want to hunt for any more artefacts first?'");

                            if (m.getYesNoResponse())
                            {
                                Console.WriteLine("You tell Merigold you're prepared to take the risks...");
                                Console.ReadKey(true);
                                Console.WriteLine("\t'Very well then,' Merigold replies heavily, 'Where is it you'd like to go?'");
                                if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                                {
                                    Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                        "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                        "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                    switch (m.getIntResponse(4))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[6];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[7];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[1];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[3];//oubliette
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[2];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[0];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[0];// highest parapet
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[6];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[7];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[0];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[1];// highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[2];// oubliette
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[3];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[3];// secret chamber
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[8];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[6];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[7];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[0];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[3];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[2];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[1];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[1];// oubliette
                                            }
                                    }
                                }
                                else//use portal to flee
                                {
                                    Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                        "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                        "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                        "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                    switch (m.getIntResponse(5))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[9];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[10];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[5];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[6];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[7];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[8];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[8];// oubliette
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[10];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[8];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[7];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[4];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[2];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[5];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[6];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[6];// oubliette
                                            }
                                        case 3:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[5];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[6];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[10];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[8];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[9];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[7];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[7];// oubliette
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll four D30...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[4];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[8];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[9];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[10];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[2];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[6];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[5];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[5];// oubliette
                                            }
                                    }
                                }
                            }
                            else
                            {
                                endOfMidGameChoice = new List<Dice> { D2 };
                                player.midnightClock = new System.Diagnostics.Stopwatch();
                                player.midnightClock.Start();
                                Console.ReadKey(true);
                                Console.WriteLine("You tell Merigold you'll head back when you're ready, all the while feverishly turning his words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                return room;

                            }
                        }
                        else if (endOfMidGameChoice[0].faces == D24.faces)
                        {
                            Console.WriteLine("Merigold watches as you produce the artefacts you wish him to use. At first he seems nervous, but the more items you display before him the more evident is his relief." +
                                "\nAfter you're done he peers up at you. 'Good... This is a good haul. Not ideal, perhaps, but I believe you have an excellent chance with this. Are you sure that's all you have?' " +
                                "\n\n You return a confident nod." +
                                "\n\n  The aged wizard rubs his hands together. 'With a bit of luck, even if I don't quite manage to send you to your destination, you should end up somewhere nearby. Are you sure you don't want to hunt for any more artefacts first?'");

                            if (m.getYesNoResponse())
                            {
                                Console.WriteLine("You tell Merigold you're prepared to take the risks...");
                                Console.ReadKey(true);
                                Console.WriteLine("\t'Very well then,' Merigold replies heavily, 'Where is it you'd like to go?'");
                                if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                                {
                                    Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                        "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                        "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                    switch (m.getIntResponse(4))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible...");
                                            destination = 0;
                                            Console.ReadKey(true);
                                            endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[6];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[4];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[1];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[3];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[2];//oubliette
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[0];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[0];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[0];// highest parapet
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[6];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[4];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[0];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[1];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[2];// highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[3];// oubliette
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[3];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[3];// secret chamber
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[9];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[5];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[6];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[4];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[0];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[3];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[2];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[1];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[1];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[1];// oubliette
                                            }
                                    }
                                }
                                else//use portal to flee
                                {
                                    Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                        "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                        "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                        "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                    switch (m.getIntResponse(5))
                                    {
                                        case 1:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[9];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[10];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[5];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[6];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[7];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[8];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[8];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[8];// oubliette
                                            }
                                        case 2:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[10];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[8];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[7];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[4];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[2];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[5];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[6];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[6];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[6];// oubliette
                                            }
                                        case 3:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[2];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[4];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[5];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[6];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[8];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[9];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[7];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[7];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[7];// oubliette
                                            }
                                        default:
                                            Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                                "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Suddenly you lurch backwards!");
                                            Console.ReadKey(true);
                                            Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                                "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                            Console.ReadKey
                                                (true);
                                            Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                                "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                            Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                            Console.ReadKey(true);
                                            destination = 0;
                                            Console.WriteLine("Roll five D24...\n[you need your dice rolls to sum up to as close to 62 as possible..."); endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                            foreach (Dice d in endOfMidGameChoice)
                                            {

                                                int x = d.Roll(d);
                                                Console.WriteLine($"You rolled {x}");
                                                Console.ReadKey(true);
                                                destination += x;
                                            }
                                            if (destination > 116 || destination < 7)
                                            {
                                                return destinations[3];
                                            }
                                            else if (destination > 111 || destination < 12)
                                            {
                                                return destinations[4];
                                            }
                                            else if (destination > 106 || destination < 17)
                                            {
                                                return destinations[1];
                                            }
                                            else if (destination > 101 || destination < 22)
                                            {
                                                return destinations[0];
                                            }
                                            else if (destination > 96 || destination < 27)
                                            {
                                                return destinations[7];//dragon's lair
                                            }
                                            else if (destination > 91 || destination < 32)
                                            {
                                                return destinations[8];//bank vault
                                            }
                                            else if (destination > 86 || destination < 37)
                                            {
                                                return destinations[9];// desert island
                                            }
                                            else if (destination > 81 || destination < 42)
                                            {
                                                return destinations[2];//huge barracks
                                            }
                                            else if (destination > 76 || destination < 47)
                                            {
                                                return destinations[6];//highest parapet
                                            }
                                            else if (destination > 71 || destination < 52)
                                            {
                                                return destinations[5];//secret chamber
                                            }
                                            else if (destination > 66 || destination < 57)
                                            {
                                                return destinations[5];// broom closet
                                            }
                                            else
                                            {
                                                return destinations[5];// oubliette
                                            }
                                    }
                                }
                            }
                            else
                            {
                                endOfMidGameChoice = new List<Dice> { D2 };
                                player.midnightClock = new System.Diagnostics.Stopwatch();
                                player.midnightClock.Start();
                                Console.ReadKey(true);
                                Console.WriteLine("You tell Merigold you'll head back when you're ready, all the while feverishly turning his words over and over in your mind, 'twelve artefacts... twelve...'\n Do you know where to start looking for them? Because if not then you're going to have to begin frantically searching very, very quickly!");
                                return room;

                            }
                        }
                        else if (endOfMidGameChoice[0].faces == D20.faces)
                        {
                            Console.WriteLine("You display no less than ten artefacts before Merigold's astonished eyes...");
                            Console.ReadKey(true);
                            Console.WriteLine("\t'Very well then,' Merigold replies elatedly, 'Where is it you'd like to go?'");
                            if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                            {
                                Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                    "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                    "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                switch (m.getIntResponse(4))
                                {
                                    case 1:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        destination = 0;
                                        Console.ReadKey(true);
                                        endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[10];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[9];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[11];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[8];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[1];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[3];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[2];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[0];//oubliette
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[0];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[0];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[0];// highest parapet
                                        }
                                    case 2:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[10];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[9];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[11];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[8];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[0];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[1];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[2];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[3];// highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[3];// oubliette
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[3];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[3];// secret chamber
                                        }
                                    default:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[10];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[9];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[11];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[8];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[0];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[3];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[2];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[1];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[1];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[1];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[1];// oubliette
                                        }
                                }
                            }
                            else//use portal to flee
                            {
                                Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                    "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                    "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                    "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                switch (m.getIntResponse(5))
                                {
                                    case 1:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[3];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[2];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[10];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[11];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[5];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[6];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[7];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[8];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[8];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[8];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[8];// oubliette
                                        }
                                    case 2:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[0];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[9];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[10];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[8];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[7];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[4];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[2];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[5];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[6];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[6];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[6];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[6];// oubliette
                                        }
                                    case 3:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[0];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[2];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[1];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[3];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[10];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[8];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[9];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[7];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[7];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[7];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[7];// oubliette
                                        }
                                    default:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll six D20...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[3];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[4];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[1];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[0];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[7];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[8];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[2];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[6];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[5];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[5];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[5];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[5];// oubliette
                                        }
                                }
                            }
                        }
                        else if (endOfMidGameChoice[0].faces == D15.faces)
                        {
                            Console.WriteLine("You display no less than eleven artefacts before Merigold's astonished eyes...");
                            Console.ReadKey(true);
                            Console.WriteLine("\t'Very well then,' Merigold replies elatedly, 'Where is it you'd like to go?'");
                            if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)//use portal to defeat CB
                            {
                                Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                    "\n[2] Tell him you want the portal to trace where the CurseBreaker hid Merigold's staff and for it to whisk you there..." +
                                    "\n[3] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                switch (m.getIntResponse(4))
                                {
                                    case 1:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        destination = 0;
                                        Console.ReadKey(true);
                                        endOfMidGameChoice.RemoveAt(endOfMidGameChoice.Count - 1);
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[10];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[9];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[11];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[8];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[1];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[3];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[2];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[0];//oubliette
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[0];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[0];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[0];// highest parapet
                                        }
                                    case 2:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[10];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[9];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[11];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[5];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[0];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[1];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[2];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[3];// highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[3];// oubliette
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[3];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[3];// secret chamber
                                        }
                                    default:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[10];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[9];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[11];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[8];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[0];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[3];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[2];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[1];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[1];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[1];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[1];// oubliette
                                        }
                                }
                            }
                            else//use portal to flee
                            {
                                Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                    "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                    "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                    "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                switch (m.getIntResponse(5))
                                {
                                    case 1:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[3];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[2];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[1];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[0];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[5];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[6];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[7];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[8];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[8];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[8];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[8];// oubliette
                                        }
                                    case 2:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[0];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[3];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[1];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[11];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[9];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[4];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[2];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[5];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[6];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[6];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[6];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[6];// oubliette
                                        }
                                    case 3:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[0];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[2];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[1];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[3];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[4];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[10];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[8];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[9];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[7];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[7];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[7];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[7];// oubliette
                                        }
                                    default:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Suddenly you lurch backwards!");
                                        Console.ReadKey(true);
                                        Console.WriteLine("From somewhere beyond the portal there's a hideous roar as a tentacle takes a swipe at you!" +
                                            "\n\t'Sorry!' Merigold cries, 'Sorry! I forgot to carry the two... here we go, this should do it...'");
                                        Console.ReadKey
                                            (true);
                                        Console.WriteLine("He repeats some incantations as you shake your head admonishingly at him. You yell back over the roar of the portal, asking him if he's *sure* he knows what he's doing..." +
                                            "\n\n\t'Not to worry, my dear fellow!' he calls back, 'I'm almost 66% certain  you've got a 9 in ten chance of not being spaghettified by the portals tidal forces!'");
                                        Console.WriteLine("Feeling more than a knot of foreboding you face the fiercely crackling portal, brace yourself, then take the plunge...");
                                        Console.ReadKey(true);
                                        destination = 0;
                                        Console.WriteLine("Roll eight D15...\n[you need your dice rolls to sum up to as close to 63 as possible...");
                                        foreach (Dice d in endOfMidGameChoice)
                                        {

                                            int x = d.Roll(d);
                                            Console.WriteLine($"You rolled {x}");
                                            Console.ReadKey(true);
                                            destination += x;
                                        }
                                        if (destination > 117 || destination < 8)
                                        {
                                            return destinations[3];
                                        }
                                        else if (destination > 112 || destination < 13)
                                        {
                                            return destinations[4];
                                        }
                                        else if (destination > 107 || destination < 18)
                                        {
                                            return destinations[1];
                                        }
                                        else if (destination > 102 || destination < 23)
                                        {
                                            return destinations[0];
                                        }
                                        else if (destination > 97 || destination < 28)
                                        {
                                            return destinations[7];//dragon's lair
                                        }
                                        else if (destination > 92 || destination < 33)
                                        {
                                            return destinations[8];//bank vault
                                        }
                                        else if (destination > 87 || destination < 38)
                                        {
                                            return destinations[2];// desert island
                                        }
                                        else if (destination > 82 || destination < 43)
                                        {
                                            return destinations[6];//huge barracks
                                        }
                                        else if (destination > 77 || destination < 48)
                                        {
                                            return destinations[5];//highest parapet
                                        }
                                        else if (destination > 72 || destination < 53)
                                        {
                                            return destinations[5];//secret chamber
                                        }
                                        else if (destination > 67 || destination < 58)
                                        {
                                            return destinations[5];// broom closet
                                        }
                                        else
                                        {
                                            return destinations[5];// oubliette
                                        }
                                }
                            }
                        }
                        else if (endOfMidGameChoice[0].faces == D10.faces)
                        {
                            Console.WriteLine("You display all of the artefacts before Merigold's astonished eyes... 'My goodness,' he breathes disbelievingly, 'My dear fellow how did you do it? No. Don't answer. We haven't time to waste...'");
                            Console.ReadKey(true);
                            Console.WriteLine("\t'Where is it you'd like to go?'");
                            if (endOfMidGameChoice[endOfMidGameChoice.Count - 1].faces == D1.faces)
                            {
                                Console.WriteLine("[1] Tell him you've decided to take on the CurseBreaker immediately. You wish to go to the highest parapet of this tower..." +
                                    "\n[2] Tell him you want to stop any chance of this ritual from happening. With some knot of foreboding you instruct Merigold to deliver you to the oubliette and the creature lurking therein...");
                                switch (m.getIntResponse(3))
                                {
                                    case 1:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        return destinations[0];
                                    default:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        return destinations[1];

                                }
                            }
                            else
                            {
                                Console.WriteLine("[1] Tell Merigold you wish the portal to take you to somewhere the CurseBreaker can never reach you..." +
                                    "\n[2] Tell Merigold you want to escape to a place where you can be filthy rich to the end of your days..." +
                                    "\n[3] Tell Merigold you want to flee to a paradise where the CurseBreaker will never look for you..." +
                                    "\n[4] Tell Merigold you want to escape to some place with enough treasure to bargain your way out of any trouble...");
                                switch (m.getIntResponse(5))
                                {
                                    case 1:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        return destinations[8];
                                    case 2:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        return destinations[6];
                                    case 3:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        return destinations[7];
                                    default:
                                        Console.WriteLine("Merigold recuperates as much magic as he can, scrunches up his features in concentration as though doing some quick mental arithmetic and finally performs some impressive looking incantations." +
                                            "  You see his magic weave itself about the portal, altering it, smoothing it as waves might a pebble. You confidently stride forward...");
                                        return destinations[5];
                                }
                            }
                        }
                    }
                }
                
            
                if (Name == "bookcase" || Name == "rosewood chest")
                {
                    Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden about the {Name}. It has been thoroughly {SpecificAttribute}.");

                }
                else
                {
                    Console.WriteLine($"{Description} \nTry as hard as you might, you find no items hidden about the {Name}. It remains {SpecificAttribute}.");
                }
                if ((Name.Contains("door") || Name.Contains("stair") || Name.Contains("corner") || Name.Contains("hole")) && (SpecificAttribute == "unlocked"|| SpecificAttribute == "unblocked") && !Description.Contains("smouldering"))
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
                            if(room.Name == "armoury" && room.FirstVisit && secretChamber.FeatureList[8].Name != "ajar mosaic door")
                            {
                                if (!fieryEscape)
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
                                /*else
                                {
                                    Console.WriteLine("You pull away from the door suddenly!");
                                    Console.ReadKey(true);
                                    Console.WriteLine("Around you the weapons are rattling upon their racks. The door trembles and the ground quakes beneath your feet. You can hear something - and *feel* something - very big and very heavy charging up to the double doors from the rooms beyond. Each heavy footfall reverberates through the armoury door. \nYou back away slowly, your clammy hand feverishly reaching to clasp a weapon. Your breath catches in your throat as whatever it is swings the double doors wide, enters the antechamber and stops outside your door...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("You wait with bated breath in the crackling silence, listening to it sniff the air, as though it can almost catch your scent in spite of the smoke from the flames below...");
                                    Console.ReadKey(true);
                                    Console.Write("Heart galloping, you're almost sure the beast can hear its febrile tattoo in your all too tight chest for a moment. Then, responding to the urgent yells of the CurseBreaker's forces frenziedly trying to douse the flames somewhere below, it turns. The monster storms down the fiery stairway and into the heart of the inferno...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("You feel relief flood through you, resting a hand on the table to steady yourself a moment. \nHopefully, Whatever that thing was,"

                                    + " it will be too preoccupied with the fire to get that close to finding you again.");
                                    Console.ReadKey(true);
                                    room.FirstVisit = false;
                                }*/
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
                try
                {
                    if (message) { Console.WriteLine($"{Passing}"); }
                    return Portal[1];
                }
                catch
                {
                    if (message)
                    {
                        Console.WriteLine("You open the door but to your surprise, you find nothing the other side but a bare brick wall...");
                    }
                    return room;
                }
                               
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

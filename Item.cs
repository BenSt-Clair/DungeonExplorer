using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Attribute { get; set; }
        public string SpecifyAttribute { get; set; }
        public int SpecialEffect { get; set; }
        public string Special { get; set; }
        public Item(string name, string description = "Nothing of note meets the eye.", bool attribute = true, string specifyAttribute = "unshattered", int specialEffect = 0, string special = null)
        {

            Name = name;
            Description = description;
            Attribute = attribute; // true (unshattered) or false
            SpecifyAttribute = specifyAttribute; // unshattered --> shattered
            SpecialEffect = specialEffect; // alters Weapon.Boon
            Special = special;  //describes special effect on console
        }

        private void StashItem(Item item, List<Item> inventory) // player1.inventory?
        {
            inventory.Add(item);
        }
        private void StashWeapon(Weapon weapon, List<Weapon> weaponInventory)
        {
            weaponInventory.Add(weapon);
        }
        public string StudyItem(Item item)
        {
            return item.Description;
        }
        /// <summary>
        /// pickupitem can be used to pick up weapons or items, however the distinction
        /// must be made clear in the parameters beforehand. range and value work to distinguish,
        /// in effect, when and where the picking up is taking place. Are you picking up the item
        /// from within the room, around a feature, from within your pack, during battle? 
        /// While there is no explicit parameter demarcating these instances, range and/or value, do
        /// the work to ensure there's no confusion. They are primarily about customising the
        /// wording printed to the console when picking up your weapon or item. But by virtue of this
        /// they double as a means of determining the context within which items are being picked up too.
        /// 
        ///
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="weaponInventory"></param>
        /// <param name="range"></param>
        /// <param name="value"></param>
        /// <param name="item"></param>
        /// <param name="weapon"></param>
        /// <param name="featureItems"></param>
        /// <param name="roomItems"></param>
        public void PickUpItem(List<Item> inventory, List<Weapon> weaponInventory,  int range, int value = 0, Item item = null, Weapon weapon = null, List<Item> featureItems = null, List<Item> roomItems = null, Weapon yourRustyChains = null)
        {
            //the following are customised messages for when an item is picked up. 
            List<string> messages = new List<string> { $"The {Name} now rests in your hands.", $"You reach over and pick up the {Name}.", $"You grasp the {Name} in your hands.", $"The {Name} is now clasped firmly in your hands.", $"With some trepidation, your clammy hand grips the {Name}.", $"You prise the {Name} from it's resting place", $"You slide the {Name} into your hands.", $"The {Name} is now nestled in your hands." };
            if (value == 0)
            {
                var random = new Random();
                int index = random.Next(0, range + 1);
                Console.WriteLine(messages[index]);
            }
            else
            {
                int index = value;
                Console.WriteLine(messages[index]);
            }
            /// Note the change in wording depending on the value of range.
            if (range == 3 || range == 4|| range == 6)
            {
                Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?");
            }
            else if (range == 5)
            {
                Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?");
            }
            do
            {
                string answer = Console.ReadLine();
                if (answer.Trim() == "")
                {
                    Console.WriteLine("Please enter '1', '2', or '3'");
                    if (range == 3 || range == 4 || range == 6)
                    {
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?");
                    }
                    else if (range == 5)
                    {
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?");
                    }
                    continue;
                }
                /// this was incase the user typed something like 'option 2' or something
                int size = answer.Trim().Length;
                char answerChar = answer.Trim()[size - 1];
                answer = answerChar.ToString();
                try
                {
                    int answerNum = int.Parse(answer);
                    if (answerNum < 1 || answerNum > 3)
                    {
                        Console.WriteLine("Please choose option 1, 2, or 3.");
                        continue;
                    }
                    else if (answerNum == 1)//study the item
                    {
                        if (weapon == null)//if item is not a weapon
                        {
                            Console.WriteLine(StudyItem(item));
                            if (range == 3 || range == 4 || range == 6)
                            {
                                Console.WriteLine($"\nWould you now like to:\n [1]study the {Name} again \n[2]stash it upon your person \n[3]place it back where you found it?");
                            }
                            else if (range == 5)
                            {
                                Console.WriteLine($"\nWould you now like to:\n [1]study the {Name} again \n[2]stash it back in your pack \n[3]discard it?");
                            }
                            continue;
                        }
                        else//if item is a weapon
                        {
                            Console.WriteLine(StudyItem(weapon));
                            if (range == 3 || range == 4 || range == 6)
                            {
                                Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?");
                            }
                            else if (range == 5)
                            {
                                Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?");
                            }
                            continue;
                        }
                    }
                    else if (answerNum == 2)
                    {
                        if (range == 3) // monsters must always carry only things the player does not already have.
                        {
                            if (item == null)
                            {
                                StashWeapon(weapon, weaponInventory);
                                Console.WriteLine($"{Name} has been stashed in inventory.");
                                return;
                            }
                            else
                            {
                                StashItem(item, inventory);
                                Console.WriteLine($"{Name} has been stashed in inventory.");
                                return;
                            }
                        }
                        else if (range == 4)//searching room
                        {
                            if (item == null)
                            {
                                if (weapon.Name == "rusty chains")
                                {
                                    
                                    
                                    
                                    
                                    StashWeapon(yourRustyChains, weaponInventory);
                                }
                                else
                                {


                                    StashWeapon(weapon, weaponInventory);
                                }
                                if (weapon.Name != "bowl fragments" && weapon.Name != "garment")
                                {
                                    roomItems.Remove(weapon);
                                    
                                }
                                if (weapon.Name == "rusty chains") 
                                { 
                                    Item rustyChains = new Item("rusty chains", "The rest of these chains crumble underfoot. They're of no use to anyone."); 
                                    roomItems.Add(rustyChains); 
                                }
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                            else
                            {
                                StashItem(item, inventory);
                                if (item.Name != "bowl fragments" && item.Name != "rusty chains" && item.Name != "garment")
                                {
                                    roomItems.Remove(item);
                                }
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                        }
                        else if (range == 6)// searching feature
                        {
                            if (item == null)
                            {
                                StashWeapon(weapon, weaponInventory);
                                featureItems.Remove(item);
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                            else
                            {
                                StashItem(item, inventory);
                                featureItems.Remove(item);
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                        }
                        else { Console.WriteLine("You place the item back in your pack."); return; }
                    }
                    else
                    {
                        if (range == 5)//if discarding weapon/item from your pack
                        {
                            if (weapon == null)
                            {
                                inventory.Remove(item);
                                roomItems.Add(item);
                                Console.WriteLine($"You discard your {item.Name}. Who needs that old thing anyway?");
                                return;
                            }
                            else//would have to cast weapon as item to store in roomitems - possible but unnecessary given story context
                            {
                                
                                Console.WriteLine($"Erm... Upon consideration you think discarding your {weapon.Name}, or any weapon, might be a bad idea...");
                                return;
                            }
                        }
                        else
                        {
                            if (weapon == null)
                            {
                                Console.WriteLine($"You place the {item.Name} back where you found it.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"You place the {weapon.Name} back where you found it.");
                                return;
                            }
                        }
                    }
                }
                catch //if a number was not entered
                {
                    Console.WriteLine("Please enter '1', '2', or '3'");
                    if (range == 3 || range == 4 || range == 6)
                    {
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?");
                    }
                    else if (range == 5)
                    {
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?");
                    }
                    continue;
                }
            } while (true);
        }
        /// <summary>
        /// there are three functions below that essentially do the same thing. useItem is
        /// for using an item on another item. useItem1 is for using an item on a feature.
        /// useItem3 is for using an item on the player character. 
        /// A dictionary is used to determine whether an item can be used on something else. 
        /// After checking this dictionary, if successfully found, the item will cause the other object
        /// to change the value of it's attribute and specialAttribute (unless player character)
        /// Doors that were locked become unlocked, etc. 
        ///   Special commentary is added for important features or items that can be effected
        /// and that further the plot.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="feature"></param>
        /// <param name="usesDictionary"></param>
        /// <param name="inventory"></param>
        /// <param name="weaponInventory"></param>
        /// <param name="binkySkull"></param>
        /// <returns></returns>
        public bool UseItem1(Item item, Feature feature, Dictionary<Item, List<Feature>> usesDictionary, List<Item> inventory, List<Weapon> weaponInventory, Room room, Player player, Monster monster, Combat battle, Item binkySkull = null, Item musicBox = null, Item note = null, Item jailorKeys = null)
        {
            if (usesDictionary[item].Contains(feature))
            {
                feature.Attribute = !feature.Attribute; // key lock unlock, weapon intact broken, magical charm uncharmed charmed, etc
                if (feature.Attribute == false)
                {
                    feature.SpecificAttribute = "un" + feature.SpecificAttribute;
                    if (item.Name == "steel key" && feature.Name == "rosewood chest")
                    {
                        Console.WriteLine("The key slides easily into the lock. With one sharp twist the clasp comes undone");
                        Console.WriteLine("Now that the rosewood chest is unlocked, would you like to search it?");
                        while (true)
                        {
                            string answer = Console.ReadLine().Trim().ToLower();
                            if (string.IsNullOrWhiteSpace(answer))
                            {
                                Console.WriteLine("Now that the rosewood chest is unlocked, would you like to search it?");
                                continue;
                            }
                            else if (answer == "yes" || answer == "y")
                            {
                                feature.Search(inventory, weaponInventory);
                                break;
                            }
                            else if (answer == "no" || answer == "n")
                            {
                                Console.WriteLine("You decide on some other course of action for now...");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' or 'no'.");
                                continue;
                            }
                        }
                    }
                    
                    else if (item.Name == "rusty chain-flail" && feature.Name == "bookcase")
                    {
                        room.FeatureList.Remove(feature);
                        Feature debris = new Feature("debris", "The bookcase has been smashed into nothing more than a crumpled heap of wooden planks.", false, "unburned");
                        room.FeatureList.Add(debris);
                        Console.WriteLine($"You heft the rusty chain-flail and start swinging. It doesn't take much until the dilapidated feature is crushed and your {item.Name} is broken. {debris.Description} Whatever you might've found within will be destroyed now too...");
                        List<Item> weaponList = new List<Item> { item };
                        List<Weapon> weaponSplice = weaponList.Cast<Weapon>().ToList();

                        player.WeaponInventory.Remove(weaponSplice[0]);
                    }
                    else
                    {
                        feature.SpecificAttribute = feature.SpecificAttribute.Substring(2, feature.SpecificAttribute.Length - 2);
                        
                    }
                    return true;
                }
                else
                {
                    feature.SpecificAttribute = feature.SpecificAttribute.Substring(2, feature.SpecificAttribute.Length - 2);
                    if (feature.Name == "skeleton" && item.Name =="rusty chain-flail")
                    {
                        feature.ItemList.Add(binkySkull);//binkySkull in this instance is steel key
                        feature.Description = "Its empty sockets fasten you with a stern gaze. It serves as a macabre reminder of what might yet befall you...";
                        Console.WriteLine($"Using your weapon you smash the skeleton's bones from the constricting chains. You succeed, but in the process your {item.Name} shatters into pieces. Finally you can move the shattered skeleton, piece by piece, out of the way, revealing something glimmering underneath...");
                        List<Item> weaponList = new List<Item> { item };
                        List<Weapon> weaponSplice = weaponList.Cast<Weapon>().ToList();

                        weaponInventory.Remove(weaponSplice[0]);
                        Console.WriteLine("Would you now like to search the skeleton?");
                        while (true)
                        {
                            string answer = Console.ReadLine().Trim().ToLower();
                            if (string.IsNullOrWhiteSpace(answer))
                            {
                                Console.WriteLine("Would you now like to search the skeleton?");
                                continue;
                            }
                            else if (answer == "yes" || answer == "y")
                            {
                                feature.Search(inventory, weaponInventory);
                                break;
                            }
                            else if (answer == "no" || answer == "n")
                            {
                                Console.WriteLine("You decide on some other course of action for now...");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' or 'no'.");
                                continue;
                            }
                        }
                    }
                    
                    return true; }
            }
            else 
            { 
                if (item.Name=="magnifying glass")
                {
                    if (feature.Name == "skeleton" && feature.SpecificAttribute == "unshattered")
                    {
                        Console.WriteLine("You peer through the magnifying glass. You discover that the shiny thing lodged behind the chained-fast skeleton is in fact a steel key! Now if only you could... What? \nMove the skeleton out of the way? \nBreak it apart? \nSomehow reach past the tight chains and bones and purloin the key? \nYou scratch your head in contemplation...");
                    }
                    else if (feature.Name == "rosewood chest" && feature.SpecificAttribute == "unlocked" && feature.ItemList.Count == 0 && !player.Inventory.Contains(musicBox) && !room.ItemList.Contains(musicBox))
                    {
                        Console.WriteLine("You study the inside of the rosewood chest through the magnifying glass. Curiosity creases your brow as you discover scratches at the seemingly empty bottom, as though made by scrabbling fingernails...");
                        if (note.Description.Contains("blighter")) { }
                        else
                        {
                            Console.WriteLine("Test your skill (Roll a D20 below your skill score): ");
                            Dice D20 = new Dice(20);
                            Console.ReadKey(true);
                            int roll = D20.Roll(D20);
                            Console.WriteLine($"You rolled {roll}");
                            Console.ReadKey(true);
                            if (roll <= player.Skill)
                            {
                                if (!player.Inventory.Contains(musicBox) && !room.ItemList.Contains(musicBox))
                                {
                                    feature.ItemList.Add(musicBox);
                                }
                                Console.WriteLine("You discover a hidden compartment concealed beneath a panel!\nWould you like to search the rosewood chest?");
                                while (true)
                                {
                                    string answer = Console.ReadLine().Trim().ToLower();
                                    if (string.IsNullOrWhiteSpace(answer))
                                    {
                                        Console.WriteLine("Would you like to search the rosewood chest?");
                                        continue;
                                    }
                                    else if (answer == "yes" || answer == "y")
                                    {
                                        feature.Search(inventory, weaponInventory);
                                        break;
                                    }
                                    else if (answer == "no" || answer == "n")
                                    {
                                        Console.WriteLine("You decide on some other course of action for now...");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter 'yes' or 'no'.");
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You ponder what those markings could mean, but no answers leap immediately to mind. You shrug before putting the magnifying glass away...");
                            }
                        }

                    }
                    else if (feature.Name.Contains("brazier"))
                    {
                        Console.WriteLine($"You peer through the magnifying glass at the {feature.Name}, only to blink and recoil as the magical flame's light focuses into an intense beam.\nExperimentally, you swivel your magnifying glass around," +
                            $"your eyes following the tight circle of light as it flickers and dances across the opposite wall. Whatever the beam touches is left warm to the touch. \nAn idea begins to form...");
                    }
                    
                    else { Console.WriteLine($"You inspect the {feature.Name} with your magnifying glass. Were you expecting to find something?"); }
                }
                else if ((item.Name == "healing potion" || item.Name == "Elixir of Feline Guile" || item.Name == "Felix Felicis") && binkySkull != null && feature.Name == "skeleton" && !room.ItemList.Contains(binkySkull) && !player.Inventory.Contains(binkySkull) && player.Traits.ContainsKey("friends with fairies"))
                {
                    Console.WriteLine($"The {item.Name} works its magic as you gloop the elixir over the skull. You blink and before you know it the skeleton let's loose a string of delightful curses worthy of the most mischievous of pixies.\n" +
                        $"\t'I say, capital to meet you, good sir,' it remarks gaily, 'I would doff my hat, if I had one. Sadly all I've got on me is a SKULL CAP!'\n" +
                        $"It wheezes a few raspy laughs. \nThe joke flies over your head like a squadron of fairies..." +
                        $"\nYou ask if he by any chance knows a way out of this cell." +
                        $"\n\t'Well, now. I reckon that broken bowl ought to do the trick.'" +
                        $"\nYou interject, wondering how it can be useful when it's shattered in two halves..." +
                        $"\n\t'Precisely,' is the skeleton's cryptic reply. 'Besides, if that fails to " +
                        $"get the job done, then you could always play a tune. I think that's right...? My ribs make a good xylophone" +
                        $"to get you started.'\nYou say you'd love to play a ditty some time but you've got an unknown evil adversary" +
                        $" to smite and if you don't do it then who will?\n\t'Well,' the skeleton remarks drily, 'that there's no" +
                        $"laughing matter. No. Not HUMERUS at all!" +
                        $"\nAgain, this sails whooshing over your head." +
                        $"\nPerhaps you can take me with you?' the skeleton says, 'I'm great at advice.'\n" +
                        $"You thank him and ask his name. he responds, 'Binky.' you ask where he got such an unusual name. He replies that's the name the developer gave to all his trial characters. \n\t'Hmmm...' You respond.");
                    Console.WriteLine("\nYou add Binky to your pack!");

                    inventory.Add(binkySkull);


                    return true;

                }
                else if (item.Name=="rusty chain-flail" && feature.Name == "rosewood door" && !feature.Description.Contains("dent") )
                {
                    
                    Dialogue goblin_RustyChains = new Dialogue(player, monster, battle, room);
                    string description = $"You bang your {item.Name} incessantly against the {feature.Name}, clamouring for the guard's attention. Eventually, you hear footsteps pound up to your door...";
                    string parlance = $"Oi! Wot you playin' at, meatbag? You wants to be chosen next, that it?' the owner's raspy, crude dialect berates you through the door. They let loose a sardonic chuckle. 'Coz if youse don't stop interrupting my game, well there's no end to the trouble your in for...";
                    List<string> responses = new List<string> 
                    { 
                        "You demand to be released at once, or else you inform your jailor that they'll be sorry",
                        "You tell your jailor that surely they can work something out, you're a bit strapped of cash at the moment but...",
                        "You tell the jailor that there's been some sort of mistake - you're not who they're looking for...",
                        "You interrogate the jailor as to the identity of this Curse-Breaker that the innkeep mentioned...",
                        "You interrogate the jailor as to where you're being held",
                        "You interrogate the jailor as to how you got here",
                        "You interrogate the jailor as to what they're going to do to you"
                        
                    };
                    if (player.Traits.ContainsKey("thespian"))
                    {
                        responses.Add("A game? With a winning smile you gallantly inquire what game the loveable, whimsical and not-at-all-brutish creature might be partaking in.");
                    }
                    if (player.Traits.ContainsKey("jinxed"))
                    {
                        responses.Add("You plead with the jailor that unless they let you out, you fear terrible, indescribable bad fortune will befall them all, and they'll be cursed with calamity after calamity because of your jinxed nature. It's in their own best interests really...");
                    }
                    int speech = goblin_RustyChains.Parle(description, parlance, responses);
                    switch (speech) 
                    {
                        case 1:
                            description = $"You hear a snort of derisive laughter through the {feature.Name}.";
                            parlance = $"Oho! That's a good one, worgmeat! You got me all's aquiver! Bwa ha ha ha!";
                            if (player.Traits.ContainsKey("jinxed"))
                            {
                                try { responses.Remove(responses[8]); }
                                catch { responses.Remove(responses[7]); }
                            }
                            if (player.Traits.ContainsKey("thespian"))
                            {
                                responses.Remove(responses[7]);
                            }
                            responses.Remove(responses[2]);
                            responses.Remove(responses[1]);
                            responses.Remove(responses[0]);
                            if (player.Traits.ContainsKey("sadist"))
                            {
                                responses.Add("You drop your voice an octave as you recount what you had done to all the other fools who dared cross you...");
                            }
                            if (player.Traits.ContainsKey("hale, hot and hearty"))
                            {
                                responses.Add("You tense your powerful muscles and furiously slam your fist into the door");
                            }
                            speech = goblin_RustyChains.Parle(description, parlance, responses);
                            switch (speech)
                            {
                                case 1:
                                    description = "";
                                    Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                    Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                    break;
                                case 2:
                                    description = "The beastly jailor hesitates for just the slightest of moments.";
                                    parlance = "None of your damn concern, Hoo-man.' he responds coolly. 'As far as your concerned the whole world exists right in your room - you ain't ever seein' nowhere else...";
                                    responses.Remove(responses[1]);
                                    speech = goblin_RustyChains.Parle(description, parlance, responses);
                                    switch (speech)
                                    {
                                        case 1:
                                            Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                            Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                            break;
                                        case 2:
                                            Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                            Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                            break;
                                        case 3:
                                            Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                            Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                            break;
                                        default:
                                            Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                            break;
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                    Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                    break;
                                case 4:
                                    Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                    Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                    break;
                                case 5:
                                    if (player.Traits.ContainsKey("sadist"))
                                    {
                                        Console.WriteLine("Even from beyond the door you can sense the jailor's pallor turn as white as a sheet at your ghastly utterances, spoken as softly as a lullaby and with all the assurance of the most deadly sincere covenant.\n'Blimey heck,' the jailor remarks, his voice suddenly tremulous, 'I reckon we missed a trick imprisoning you. We should 'ave hired you instead!' You hear the jailor's boots pace warily backwards from the door. You imagine him wiping cold sweat from his brow. 'I ain't gonna be the one who kills you, that's fer sure - I ain't goin' anywhere near you. But I sure as hell ain't lettin' an animal like you out of 'ere...'\nWith that he stalks away, his pace quickening...");
                                        break;
                                    }
                                    else if (player.Traits.ContainsKey("hale, hot and hearty"))
                                    {
                                        Console.WriteLine("The rosewood door, despite its size and heaviness, jolts within its frame. The iron hinges holding it in place tremble, and a small cascade of stony dust breaks from the masonry of the doorway, cascading to your feet.\nThere's a yelp of surprise from the other side. You sense the jailor has nervously darted back from the door, before he recovers his composure. \n\t'You think you're tough, eh?' The jailor truculently retorts, doing his best to conceal his fright, 'well we'll just see how tough you are soon enough!'\nWith that the mysterious jailor stalks away back down what sounds like a long corridor.\nIn private, you nurse your hand. You won't be trying to break through *this* door again in a hurry...");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine("The rosewood door, despite its size and heaviness, jolts within its frame. The iron hinges holding it in place tremble, and a small cascade of stony dust breaks from the masonry of the doorway, cascading to your feet.\nThere's a yelp of surprise from the other side. You sense the jailor has nervously darted back from the door, before he recovers his composure. \n\t'You think you're tough, eh?' The jailor truculently retorts, doing his best to conceal his fright, 'well we'll just see how tough you are soon enough!'\nWith that the mysterious jailor stalks away back down what sounds like a long corridor.\nIn private, you nurse your hand. You won't be trying to break through *this* door again in a hurry...");
                                    break;
                                default:
                                    Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                    break;

                            }
                            break;
                        case 2:
                            description = $"The end of your sentence is left hanging with an expectant pause...";
                            parlance = $"Yeah?' the beastly jailor retorts at last, 'but wot?";
                            if (player.Traits.ContainsKey("jinxed"))
                            {
                                try { responses.Remove(responses[8]); }
                                catch { responses.Remove(responses[7]); }
                            }
                            if (player.Traits.ContainsKey("thespian"))
                            {
                                responses.Remove(responses[7]);
                            }
                            responses.Remove(responses[2]);
                            responses.Remove(responses[1]);
                            responses.Remove(responses[0]);
                            responses.Insert(0, "Uh, come to think of it you weren't sure how you were going to finish that sentence...");
                            speech = goblin_RustyChains.Parle(description, parlance, responses);
                            switch (speech)
                            {
                                case 1:
                                    Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                    break;
                                case 2:
                                    description = "";
                                    Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                    Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                    break;
                                case 3:
                                    description = "The beastly jailor hesitates for just the slightest of moments.";
                                    parlance = "None of your damn concern, Hoo-man.' he responds coolly. 'As far as your concerned the whole world exists right in your room - you ain't ever seein' nowhere else...";
                                    responses.Remove(responses[1]);
                                    responses.Remove(responses[0]);
                                    speech = goblin_RustyChains.Parle(description, parlance, responses);
                                    switch (speech)
                                    {
                                        case 1:
                                            Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                            Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                            break;
                                        case 2:
                                            Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                            Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                            break;
                                        case 3:
                                            Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                            Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                            break;
                                        default:
                                            Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                            break;
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                    Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                    break;
                                case 5:
                                    Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                    Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                    break;
                                default:
                                    Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                    break;

                            }
                            break;
                        case 3:
                            description = $"You hear a snort of derisive laughter through the {feature.Name}.";
                            parlance = $"But of course you don't belong here, Footwart.' the jailor's voice takes on a glib, mocking tone. He seems distracted by something as he speaks, as though fishing his nose for bogeys. 'Didn't you hear? We got the wrong end of the stick on every one of youse prisoners in here.' He hawks and spits. 'We're shipping you all back come Too-sday, so don' you go worrying your pretty head about it...";
                            if (player.Traits.ContainsKey("thespian"))
                            {
                                responses.Remove(responses[7]);
                            }
                            responses.Remove(responses[2]);
                            responses.Remove(responses[1]);
                            responses.Remove(responses[0]);
                            speech = goblin_RustyChains.Parle(description, parlance, responses);
                            switch (speech)
                            {
                                case 1:
                                    description = "";
                                    Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                    Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                    break;
                                case 2:
                                    description = "The beastly jailor hesitates for just the slightest of moments.";
                                    parlance = "None of your damn concern, Hoo-man.' he responds coolly. 'As far as your concerned the whole world exists right in your room - you ain't ever seein' nowhere else...";
                                    responses.Remove(responses[1]);
                                    speech = goblin_RustyChains.Parle(description, parlance, responses);
                                    switch (speech)
                                    {
                                        case 1:
                                            Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                            Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                            break;
                                        case 2:
                                            Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                            Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                            break;
                                        case 3:
                                            Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                            Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                            break;
                                        default:
                                            Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                            break;
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                    Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                    break;
                                case 4:
                                    Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                    Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                    break;
                                case 5:
                                    description = "Your statement is so self-assured in the sheer magnitude of your own bad luck that the jailor pauses for a doubtful moment. \nIt's a doubt that they wish they could expunge with more familiar incredulity, if only it weren't for how your words seem unshakable. Perhaps the jailor is of the superstitious type...";
                                    parlance = "Yeah?' a mote of caution laced through their words, 'Jinxed how?";
                                    responses = new List<string>
                                    {
                                        "You recount the time you mixed drinks at a party and the whole brewery exploded like a firework display...",
                                        "You reminisce when a humble bridgekeeper asked you what the air speed velocity of an unladen swallow was, and he was suddenly launched twenty feet into the air...",
                                        "You remember your first battle when you were... *ahem* ...preoccupied behind some bushes. Some bugger tried to steal your horse so you snuck up and beheaded them, only to discover it was your own king...",
                                        "You ruminate on the time you couldn't stop snickering at the name of your commander's fiend, Biggus Dicus. He had everyone executed for insubordinate giggling just after you excused yourself..."
                                    };
                                    speech = goblin_RustyChains.Parle(description, parlance, responses);
                                    switch (speech)
                                    {
                                        case 1:
                                            Console.WriteLine("The jailor sniffs.'Yeah, well, don't worry. I won't be handing you my wineskin anytime soon, so I think we'll be safe...'");
                                            Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                            break;
                                        case 2:
                                            Console.WriteLine("'That makes no sense...' the jailor responds, 'do you mean an African swallow or a European swallow?'");
                                            Console.WriteLine("You respond that the bridgekeeper didn't know that either...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("'So..?' you say.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("'Wot?' is the jailor's distracted reply.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("'Can I go,' you ask. 'You know how it is' you say. You tell him you've got places to go people to see...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("'Yeah, well, I tell's you wot,' the goblin replies, 'if I go hurtlin' through the air, maybe catapulted by one of these loose floorboards the damn carpenter should've blahdy well fixed by now, you'll be free to go. Until then...'");
                                            
                                            Console.WriteLine("Without further ado, you hear the jailor stalk away somewhere well beyond the door\nDamn! You thought you had him for a second...");
                                            Console.ReadKey(true);
                                            break;
                                        case 3:
                                            Console.WriteLine("'A regicide, eh?' the jailor remarks, 'sounds like you would fit in with half the blokes in our mercenary company...");
                                            Console.WriteLine("Without further ado, you hear the jailor stalk away somewhere well beyond the door");
                                            break;
                                        case 4:
                                            Console.WriteLine("For a moment you wonder if the jailor has tip-toed away, then you hear a stifled snicker. Soon the snicker bubbles into a muffled titter of delight. This in turn rolls into a gushing babble of laughs, before the jailor starts wheezing, clearly out of breath as his lungs ache for air amidst barks of raucous mirth.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("'Biggus...' he wheezes, collapsing to the floor just outside your cell, '...oh god...Diccus, Bwa Ha ~ can't breathe... ha!'");
                                            Console.ReadKey(true);
                                            Console.WriteLine("The jailor dies.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("You look down and find the jailor's keys are just peeping through the gap under the door. With a happy-go-lucky shrug, you manage to purloin them from your captor and open the door to escape! \nYou find the dead goblin just by the foot of your door, it's face frozen in a rictus of half way between terror and hilarity.");
                                            battle.WonFight();
                                            inventory.Add(jailorKeys);
                                            return false;
                                        default:
                                            Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                    break;

                            }
                            break;
                        case 4:
                            Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                            Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                            break;
                        case 5:
                            description = "The beastly jailor hesitates for just the slightest of moments.";
                            parlance = "None of your damn concern, Hoo-man.' he responds coolly. 'As far as your concerned the whole world exists right in your room - you ain't ever seein' nowhere else...";
                            if (player.Traits.ContainsKey("jinxed"))
                            {
                                try { responses.Remove(responses[8]); }
                                catch { responses.Remove(responses[7]); }
                            }
                            if (player.Traits.ContainsKey("thespian"))
                            {
                                responses.Remove(responses[7]);
                            }
                            responses.Remove(responses[2]);
                            responses.Remove(responses[1]);
                            responses.Remove(responses[0]);
                            responses.Remove(responses[1]);
                            speech = goblin_RustyChains.Parle(description, parlance, responses);
                            switch (speech)
                            {
                                case 1:
                                    Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                    Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                    break;
                                case 2:
                                    Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                    Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                    break;
                                case 3:
                                    Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                    Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                    break;
                                default:
                                    Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                    break;
                            }
                            break;
                        case 6:
                            Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                            Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                            break;
                        case 7:
                            Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                            Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                            break;
                        case 8:
                            if (player.Traits.ContainsKey("thespian"))
                            {
                                description = $"The jailor seems taken aback by your flattery. You can imagine them preening themselves on the other side of the rosewood door.";
                                parlance = $"Coin flipping,' the jailor sniffs. 'Lads and me are 'aving a game of it through in the armoury...";
                                responses.Clear();
                                responses.Add("Coin flipping? You scoff. You ask why they don't play with cards...");
                                responses.Add("You ponder openly about the armoury and the existence of weapons close by...");
                                responses.Add("You amiably ask if they're having any luck with it...");
                                responses.Add("Lads? Plural? You wonder aloud how many others are outside this room guarding your cell...");
                                speech = goblin_RustyChains.Parle(description , parlance, responses);
                                switch(speech)
                                {
                                    case 1:
                                        Console.WriteLine("The goblin's tone becomes icy. \n\t'Obviously we don't 'ave cards, do we, Worgmeat! You think we're some sorta fancy gentleman's club 'round 'ere?' the jailor hawks and spits. 'Why don' you go back to waiting 'til we skin yer hide. I've a feeling the master will come round for you shortly...'");
                                        Console.WriteLine("Before you can say another word, the jailor stalks away...");
                                        Console.ReadKey(true);
                                        break;
                                    case 2:
                                        description = "You imagine the rather uncouth jailor narrowing its eyes shrewdly just beyond the door.";
                                        parlance = "Oh sure!' the goblin remarks craftily, 'We've got ourselves an hooge arsenal up the stairs from 'ere. Want to see?";
                                        responses.Clear();
                                        responses.Add("You tell the wonderful jailor that his suggestion is in no uncertain terms a capital idea that you'd be sure would be mutually beneficial to all... Oh wait, he's not serious, is he?");
                                        responses.Add("You make a tentative inquiry; the jailor wouldn't be pulling your leg, would they?");
                                        speech = goblin_RustyChains.Parle(description, parlance, responses);
                                        switch (speech)
                                        {
                                            case 1:
                                                description = "The jailor bursts out laughing.";
                                                parlance = "Had you goin' there didn't I, Maggotfeed! Bwa ha ha ha!' then the jailor's tone drops like lead. 'Nah. I like youse. But it ain't my job's worth to go around fave-or-a-tizin' none of my prisoners.";
                                                responses.Clear();
                                                responses.Add("You interrogate the jailor as to the identity of this Curse-Breaker that the innkeep mentioned...");
                                                responses.Add("You interrogate the jailor as to where you're being held");
                                                responses.Add("You interrogate the jailor as to how you got here");
                                                responses.Add("You interrogate the jailor as to what they're going to do to you");
                                                speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                switch (speech)
                                                {
                                                    case 1:
                                                        Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                                        Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                                        break;
                                                    case 2:
                                                        description = "The beastly jailor hesitates for just the slightest of moments.";
                                                        parlance = "None of your damn concern, Hoo-man.' he responds coolly. 'As far as your concerned the whole world exists right in your room - you ain't ever seein' nowhere else...";
                                                        responses.Remove(responses[1]);
                                                        speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                        switch (speech)
                                                        {
                                                            case 1:
                                                                Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                                                Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                                                break;
                                                            case 2:
                                                                Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                                                Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                                                break;
                                                            case 3:
                                                                Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                                                Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                                                break;
                                                            default:
                                                                Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                                break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                                        Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                                        break;
                                                    case 4:
                                                        Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                                        Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                                        break;
                                                    default:
                                                        Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                        break;
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                break;
                                        }
                                        break;
                                    case 3:
                                        description = "The jailor perks up.";
                                        parlance = "Winnin' big I am, you betcha,' he remarks gaily. 'Wouldn' mind either way to be honest, o' course. Just so longs as I gets that music box's tune out of my head...' \nThe jailor's tone descends into an irascible grumble from which you discern only snippets of meaning, 'Damn prisoner...in that room...stashed away somewhere...when I find it I'll...SMASH! SMASH!...";
                                        responses.Clear();
                                        responses.Add("You bluff that you found this music box in question, you think the tune's delightful...");
                                        responses.Add("You claim you know the whereabouts of this music box. For a price, you'll tell him where it is... ");
                                        responses.Add("You state that you could help him look for the music box in the room, you might already have found some clues as to where it's hidden...");
                                        responses.Add("You choose to keep the strange jailor sweet and ask him how much exactly he's won so far...");
                                        speech = goblin_RustyChains.Parle(description, parlance, responses);
                                        switch (speech)
                                        {
                                            case 1:
                                                Console.WriteLine("The jailor chortles. \n\t'Trust me, Bootspittle, had you found that music box and played it, I'd 'ave already heard it, barged into that cosy cell of yours and run you through with my scimitar. Nice try though...' \nBefore you can get another word in, he's already strode away laughing... ");
                                                break;
                                            case 2:
                                                description = "The jailor shrewdly weighs your words, but they cannot detect a lie in them.";
                                                parlance = "Oh yeah?' they reply cautiously, 'and what might this price be?";
                                                responses.Clear();
                                                responses.Add("You tell the jailor that you want to fight him. If he doesn't co-operate you'll play the music box's tune until they capitulate...");
                                                responses.Add("You say you want out of this cell and you don't want any alarms raised afterwards...");
                                                responses.Add("You tell them you want to play one game; a coin flip for your freedom from this cell and the goblin's freedom from the music box's tune...");
                                                speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                switch (speech)
                                                {
                                                    case 1:
                                                        Console.WriteLine("The goblin balks. \n\t'No! Don't play that tune! Urghh, that sentimental ditty makes my ears bleed! You play that tune and your dead, Worgmeat!'");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("You ask him if that means you both have a deal. You claim you're moments away from opening the music box...");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("\t'Yes! You have a deal,' the jailor snarls. 'I hope you know what you're in for, Footwart, 'cause youse about to get it!'");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("You take a step away from the door, look to you not-so-trusty chain-flail and feel a tincture of dread as you brace yourself for the fight for your freedom. As the tumblers jostle and a boot kicks the door open, you know your very life hinges on being the warrior you'd hitherto only pretended to be...");
                                                        Console.ReadKey(true);
                                                        List<Item> weaponItems = new List<Item>();
                                                        List<Weapon> weapons = new List<Weapon>();
                                                        weaponItems.Add(item);
                                                        weapons = weaponItems.Cast<Weapon>().ToList();
                                                        player.Equip(weapons[0], player.WeaponInventory, player);
                                                        return false;
                                                    case 2:
                                                        Console.WriteLine("'Wot? You think I'm gonna let you walk out of 'ere? Just like that?' the jailor's tone suddenly becomes deadly and foreboding. 'Here's wot's goin' to happen, Worgmeat, you're goin' to sit in that cell nice and quiet-like, or else I'm gonna run you through with this 'ere sword. Got it? The moment I hear that tune, yer dead!'\nAnd with that the jailor stalks away and out of earshot...");
                                                        Console.ReadKey(true);
                                                        break;
                                                    case 3:
                                                        description = "The jailor is intrigued.";
                                                        parlance = "And just how do I know you're not goin' to mug me the moment I pass through that door?";
                                                        responses.Clear();
                                                        responses.Add("You answer that the jailor doesn't have to. You trust them to flip the coin themselves and call it honestly, after all you haven't any coins on you...");
                                                        responses.Add("You appeal to your jailor to be reasonable, after all, you're unarmed...");
                                                        responses.Add("You ask whether the jailor really thinks you'd attack him. Where's the trust?");
                                                        speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                        switch (speech)
                                                        {
                                                            case 1:
                                                                Console.WriteLine("\t'Alright then, Turnip-breath, youse gots yourself a deal,' the pleased jailor says. You can hear him slyly rubbing his hands with glee. 'Wot will it be? Heads or Tails?'");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("You casually respond that if he flips heads you'll win and if he flips tails he'll lose. Fair?");
                                                                Console.WriteLine("\t'Heh heh. Golden,' the greedy jailor replies, flipping the coin. You hear it sonorously twirl through the air before clattering upon the floor...");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("You calmly inquire how it landed as you inspect your fingernails.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("\t'TAILS!' the jailor roars with triumph. Before he has a chance to give you any commiserations you quickly remind him, 'tails he loses.'");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("\t'Eh? But... wot?' Then the jailor suddenly clamours, 'no, no, i mean heads, i mean... Ah, damnit all!'\nYou hear the tumblers of the rosewood door clinking as the jailor - a rather hideous goblin - opens your door.\n\t'Here, get out of my hair, before I change my mind! Blahdy coins!'");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("You decide not to wait for the goblin to figure out your trick, nor that you managed to purloin his jail keys from right under his nose, as he stomps moodily out of sight. Now you're free, you need to get out of here. Fast...");
                                                                Console.ReadKey(true);
                                                                player.Inventory.Add(jailorKeys);
                                                                return false;
                                                            case 2:
                                                                Console.WriteLine("The mysterious jailor only guffaws as he leaves you to your dank cell\n\t'You think I wos born yesterday?' he calls behind him...");
                                                                break;
                                                            case 3:
                                                                Console.WriteLine("The mysterious jailor only guffaws as he leaves you to your dank cell\n\t'In your dreams, Maggotfeed,' he calls as he stomps away...");
                                                                break;
                                                            default:
                                                                Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                        break;

                                                }
                                                break;

                                            case 3:
                                                Console.WriteLine("'Pfft,' the jailor scoffs. 'I've looked in that room for days before your ugly mug showed up there. If I can't find it, Wormfood, then what chance have you?'\nThe goblin strides away cackling before you can utter another word.");
                                                break;
                                            case 4:
                                                Console.WriteLine("You and the alternatively-cultivated jailor embark on a lengthy palaver, delighting in each other's company. When the jailor at last leaves, it is with a spring in his step and a song in his heart. You hear him croaking tunelessly, 'I'm in the money, i'm in the money, spend it, lend it, send it, rollin' along...' as he descends down a lengthy corridor. \nYou get a lovely warm feeling of satisfaction from cheering up your homicidal captor.");
                                                break;
                                            default:
                                                Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                break;
                                        }
                                        break;
                                    case 4:
                                        description = "The somewhat inelegant but surprisingly loquacious jailor continues absent-mindedly running their mouth.";
                                        parlance = "Yeah,' he remarks, 'They're all up the stairs, a ways from 'ere. Makes for bad company most of 'em but even with the gnoll slavering over the coins, its still better than playing with that todger, Meri-.'\nThe jailor abruptly catches themselves.\n'Oi, wots your game? None of this will help you none. Your deadmeat, trollbreath!";
                                        responses.Remove(responses[3]);
                                        responses.Remove(responses[2]);
                                        responses.Add("You deftly change topic, amiably asking if they've had any luck in their game against these characters...");
                                        speech = goblin_RustyChains.Parle(description, parlance, responses);
                                        switch (speech)
                                        {
                                            case 1:
                                                Console.WriteLine("The goblin's tone becomes icy. \n\t'Obviously we don't 'ave cards, do we, Worgmeat! You think we're some sorta fancy gentleman's club 'round 'ere?' the jailor hawks and spits. 'Why don' you go back to waiting 'til we skin yer hide. I've a feeling the master will come round for you shortly...'");
                                                Console.WriteLine("Before you can say another word, the jailor stalks away...");
                                                Console.ReadKey(true);
                                                break;
                                            case 2:
                                                description = "You imagine the rather uncouth jailor narrowing its eyes shrewdly just beyond the door.";
                                                parlance = "Oh sure!' the goblin remarks craftily, 'We've got ourselves an hooge arsenal up the stairs from 'ere. Want to see?";
                                                responses.Clear();
                                                responses.Add("You tell the wonderful jailor that his suggestion is in no uncertain terms a capital idea that you'd be sure would be mutually beneficial to all... Oh wait, he's not serious, is he?");
                                                responses.Add("You make a tentative inquiry; the jailor wouldn't be pulling your leg, would they?");
                                                speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                switch (speech)
                                                {
                                                    case 1:
                                                        description = "The jailor bursts out laughing.";
                                                        parlance = "Had you goin' there didn't I, Maggotfeed! Bwa ha ha ha!' then the jailor's tone drops like lead. 'Nah. I like youse. But it ain't my job's worth to go around fave-or-a-tizin' none of my prisoners.";
                                                        responses.Clear();
                                                        responses.Add("You interrogate the jailor as to the identity of this Curse-Breaker that the innkeep mentioned...");
                                                        responses.Add("You interrogate the jailor as to where you're being held");
                                                        responses.Add("You interrogate the jailor as to how you got here");
                                                        responses.Add("You interrogate the jailor as to what they're going to do to you");
                                                        speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                        switch (speech)
                                                        {
                                                            case 1:
                                                                Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                                                Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                                                break;
                                                            case 2:
                                                                description = "The beastly jailor hesitates for just the slightest of moments.";
                                                                parlance = "None of your damn concern, Hoo-man.' he responds coolly. 'As far as your concerned the whole world exists right in your room - you ain't ever seein' nowhere else...";
                                                                responses.Remove(responses[1]);
                                                                speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                                switch (speech)
                                                                {
                                                                    case 1:
                                                                        Console.WriteLine($"'Pfft,' the jailor responds, 'I wouldn't worry none about it, Bootspittle. The master will be around soon enough to collect you. Once he does, you'll wish you woz back 'ere...'");
                                                                        Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                                                        break;
                                                                    case 2:
                                                                        Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                                                        Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                                                        break;
                                                                    case 3:
                                                                        Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                                                        Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                                                        break;
                                                                    default:
                                                                        Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                                        break;
                                                                }
                                                                break;
                                                            case 3:
                                                                Console.WriteLine("'You flew 'ere, sunshine,' the jailor chuckles, 'on a magic carpet with all the other princes and princesses, whisked away to meet prince charming.' the jailor's chuckle rolls into barks of caustic laughter, 'Oh, he's goin' to have his way with you, and that's for sure! Bwa ha ha ha...");
                                                                Console.WriteLine("You challenge him as to what that's supposed to mean, but the jailor has already stalked away from the door and out of earshot. You're left with as few answers as you arrived with...");
                                                                break;
                                                            case 4:
                                                                Console.WriteLine("'Who? Me?' The jailor responds obtusely. 'Why nothin' at all. Not unless you try to escape - or play that damnable infernal tune the last meatbag played!' the creature snarls, momentarily breaking their flippant facade. 'I still can't get that screech out of my head! Damned fleshbag died before revealing where he stashed the thing-.' the jailor catches himself. 'Not that it matters none to you, maggotfeed. It won't be long now 'til the master comes for you.'");
                                                                Console.WriteLine($"With that, the jailor stalks away, leaving you pondering just what they'd meant by that 'tune.' You eye the skeleton in the room, the previous 'fleshbag' who'd resided and died here. You wonder what secrets it holds...");
                                                                break;
                                                            default:
                                                                Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                        break;
                                                }
                                                break;
                                            case 3:
                                                description = "The jailor perks up.";
                                                parlance = "Winnin' big I am, you betcha,' he remarks gaily. 'Wouldn' mind either way to be honest, o' course. Just so longs as I gets that music box's tune out of my head...' \nThe jailor's tone descends into an irascible grumble from which you discern only snippets of meaning, 'Damn prisoner...in that room...stashed away somewhere...when I find it I'll...SMASH! SMASH!...";
                                                responses.Clear();
                                                responses.Add("You bluff that you found this music box in question, you think the tune's delightful...");
                                                responses.Add("You claim you know the whereabouts of this music box. For a price, you'll tell him where it is... ");
                                                responses.Add("You state that you could help him look for the music box in the room, you might already have found some clues as to where it's hidden...");
                                                responses.Add("You choose to keep the strange jailor sweet and ask him how much exactly he's won so far...");
                                                speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                switch (speech)
                                                {
                                                    case 1:
                                                        Console.WriteLine("The jailor chortles. \n\t'Trust me, Bootspittle, had you found that music box and played it, I'd 'ave already heard it, barged into that cosy cell of yours and run you through with my scimitar. Nice try though...' \nBefore you can get another word in, he's already strode away laughing... ");
                                                        break;
                                                    case 2:
                                                        description = "The jailor shrewdly weighs your words, but they cannot detect a lie in them.";
                                                        parlance = "Oh yeah?' they reply cautiously, 'and what might this price be?";
                                                        responses.Clear();
                                                        responses.Add("You tell the jailor that you want to fight him. If he doesn't co-operate you'll play the music box's tune until they capitulate...");
                                                        responses.Add("You say you want out of this cell and you don't want any alarms raised afterwards...");
                                                        responses.Add("You tell them you want to play one game; a coin flip for your freedom from this cell and the goblin's freedom from the music box's tune...");
                                                        speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                        switch (speech)
                                                        {
                                                            case 1:
                                                                Console.WriteLine("The goblin balks. \n\t'No! Don't play that tune! Urghh, that sentimental ditty makes my ears bleed! You play that tune and your dead, Worgmeat!'");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("You ask him if that means you both have a deal. You claim you're moments away from opening the music box...");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("\t'Yes! You have a deal,' the jailor snarls. 'I hope you know what you're in for, Footwart, 'cause youse about to get it!'");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("You take a step away from the door, look to you not-so-trusty chain-flail and feel a tincture of dread as you brace yourself for the fight for your freedom. As the tumblers jostle and a boot kicks the door open, you know your very life hinges on being the warrior you'd hitherto only pretended to be...");
                                                                Console.ReadKey(true);
                                                                List<Item> weaponItems = new List<Item>();
                                                                List<Weapon> weapons = new List<Weapon>();
                                                                weaponItems.Add(item);
                                                                weapons = weaponItems.Cast<Weapon>().ToList();
                                                                player.Equip(weapons[0], player.WeaponInventory, player);
                                                                return false;
                                                            case 2:
                                                                Console.WriteLine("'Wot? You think I'm gonna let you walk out of 'ere? Just like that?' the jailor's tone suddenly becomes deadly and foreboding. 'Here's wot's goin' to happen, Worgmeat, you're goin' to sit in that cell nice and quiet-like, or else I'm gonna run you through with this 'ere sword. Got it? The moment I hear that tune, yer dead!'\nAnd with that the jailor stalks away and out of earshot...");
                                                                Console.ReadKey(true);
                                                                break;
                                                            case 3:
                                                                description = "The jailor is intrigued.";
                                                                parlance = "And just how do I know you're not goin' to mug me the moment I pass through that door?";
                                                                responses.Clear();
                                                                responses.Add("You answer that the jailor doesn't have to. You trust them to flip the coin themselves and call it honestly, after all you haven't any coins on you...");
                                                                responses.Add("You appeal to your jailor to be reasonable, after all, you're unarmed...");
                                                                responses.Add("You ask whether the jailor really thinks you'd attack him. Where's the trust?");
                                                                speech = goblin_RustyChains.Parle(description, parlance, responses);
                                                                switch (speech)
                                                                {
                                                                    case 1:
                                                                        Console.WriteLine("\t'Alright then, Turnip-breath, youse gots yourself a deal,' the pleased jailor says. You can hear him slyly rubbing his hands with glee. 'Wot will it be? Heads or Tails?'");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("You casually respond that if he flips heads you'll win and if he flips tails he'll lose. Fair?");
                                                                        Console.WriteLine("\t'Heh heh. Golden,' the greedy jailor replies, flipping the coin. You hear it sonorously twirl through the air before clattering upon the floor...");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("You calmly inquire how it landed as you inspect your fingernails.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("\t'TAILS!' the jailor roars with triumph. Before he has a chance to give you any commiserations you quickly remind him, 'tails he loses.'");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("\t'Eh? But... wot?' Then the jailor suddenly clamours, 'no, no, i mean heads, i mean... Ah, damnit all!'\nYou hear the tumblers of the rosewood door clinking as the jailor - a rather hideous goblin - opens your door.\n\t'Here, get out of my hair, before I change my mind! Blahdy coins!'");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("You decide not to wait for the goblin to figure out your trick, nor that you managed to purloin his jail keys from right under his nose, as he stomps moodily out of sight. Now you're free, you need to get out of here. Fast...");
                                                                        Console.ReadKey(true);
                                                                        player.Inventory.Add(jailorKeys);
                                                                        return false;
                                                                    case 2:
                                                                        Console.WriteLine("The mysterious jailor only guffaws as he leaves you to your dank cell\n\t'You think I wos born yesterday?' he calls behind him...");
                                                                        break;
                                                                    case 3:
                                                                        Console.WriteLine("The mysterious jailor only guffaws as he leaves you to your dank cell\n\t'In your dreams, Maggotfeed,' he calls as he stomps away...");
                                                                        break;
                                                                    default:
                                                                        Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                                        break;
                                                                }
                                                                break;
                                                            default:
                                                                Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                                break;

                                                        }
                                                        break;

                                                    case 3:
                                                        Console.WriteLine("'Pfft,' the jailor scoffs. 'I've looked in that room for days before your ugly mug showed up there. If I can't find it, Wormfood, then what chance have you?'\nThe goblin strides away cackling before you can utter another word.");
                                                        break;
                                                    case 4:
                                                        Console.WriteLine("You and the alternatively-cultivated jailor embark on a lengthy palaver, delighting in each other's company. When the jailor at last leaves, it is with a spring in his step and a song in his heart. You hear him croaking tunelessly, 'I'm in the money, i'm in the money, spend it, lend it, send it, rollin' along...' as he descends down a lengthy corridor. \nYou get a lovely warm feeling of satisfaction from cheering up your homicidal captor.");
                                                        break;
                                                    default:
                                                        Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                        break;
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                                break;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                        break;
                                }
                                break;
                            }
                            else
                            {
                                description = "Your statement is so self-assured in the sheer magnitude of your own bad luck that the jailor pauses for a doubtful moment. \nIt's a doubt that they wish they could expunge with a more familiar small-minded incredulity, if only it weren't for how your words seem unshakable. Perhaps the jailor is of the superstitious type...";
                                parlance = "Yeah?' a mote of caution laced through their words, 'Jinxed how?";
                                responses = new List<string> 
                                { 
                                    "You recount the time you mixed drinks at a party and the whole brewery exploded like a firework display...",
                                    "You reminisce when a humble bridgekeeper asked you what the air speed velocity of an unladen swallow was, and he was suddenly launched twenty feet into the air...",
                                    "You remember your first battle when you were... *ahem* ...preoccupied behind some bushes. Some bugger tried to steal your horse so you snuck up and beheaded them, only to discover it was your own king...",
                                    "You ruminate on the time you couldn't stop snickering at the name of your commander's fiend, Biggus Dicus. He had everyone executed for insubordinate giggling just after you excused yourself..."
                                };
                                speech = goblin_RustyChains.Parle(description, parlance, responses);
                                switch (speech)
                                {
                                    case 1:
                                        Console.WriteLine("The jailor sniffs.'Yeah, well, don't worry. I won't be handing you my wineskin anytime soon, so I think we'll be safe...'");
                                        Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                        break;
                                    case 2:
                                        Console.WriteLine("'That makes no sense...' the jailor responds, 'do you mean an African swallow or a European swallow?'");
                                        Console.WriteLine("You respond that the bridgekeeper didn't know that either...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("'So..?' you say.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("'Wot?' is the jailor's distracted reply.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("'Can I go,' you ask. 'You know how it is' you say. You tell him you've got places to go people to see...");
                                        Console.ReadKey(true);
                                        Console.WriteLine("'Yeah, well, I tell's you wot,' the goblin replies, 'if I go hurtlin' through the air, maybe catapulted by one of these loose floorboards the damn carpenter should've blahdy well fixed by now, you'll be free to go. Until then...'");
                                        Console.WriteLine("Without further ado, you hear the jailor stalk away somewhere well beyond the door\nDamn! For a moment you thought you'd had him...");
                                        Console.ReadKey(true);
                                        break;
                                    case 3:
                                        Console.WriteLine("'A regicide, eh?' the jailor remarks, 'sounds like you would fit in with half the blokes in our mercenary company...");
                                        Console.WriteLine("Without further ado, you hear the jailor stalk away somewhere well beyond the door");
                                        break;
                                    case 4:
                                        Console.WriteLine("For a moment you wonder if the jailor has tip-toed away, then you hear a stifled snicker. Soon the snicker bubbles into a muffled titter of delight. This in turn rolls into a gushing babble of laughs, before the jailor starts wheezing, clearly out of breath as his lungs ache for air amidst barks of raucous mirth.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("'Biggus...' he wheezes, collapsing to the floor just outside your cell, '...oh god...Diccus, Bwa Ha ~ can't breathe... ha!'");
                                        Console.ReadKey(true);
                                        Console.WriteLine("The jailor dies.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("You look down and find the jailor's keys are just peeping through the gap under the door. With a happy-go-lucky shrug, you manage to purloin them from your captor and open the door to escape! \nYou find the dead goblin just by the foot of your door, it's face frozen in a rictus of half way between terror and hilarity.");
                                        battle.WonFight();
                                        inventory.Add(jailorKeys);
                                        return false;
                                    default:
                                        Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                        break;
                                }
                            }
                            break;
                        case 9://jinxed
                            description = "Your statement is so self-assured in the sheer magnitude of your own bad luck that the jailor pauses for a doubtful moment. \nIt's a doubt that they wish they could expunge with more familiar incredulity, if only it weren't for how your words seem unshakable. Perhaps the jailor is of the superstitious type...";
                            parlance = "Yeah?' a mote of caution laced through their words, 'Jinxed how?";
                            responses = new List<string>
                                {
                                    "You recount the time you mixed drinks at a party and the whole brewery exploded like a firework display...",
                                    "You reminisce when a humble bridgekeeper asked you what the air speed velocity of an unladen swallow was, and he was suddenly launched twenty feet into the air...",
                                    "You remember your first battle when you were... *ahem* ...preoccupied behind some bushes. Some bugger tried to steal your horse so you snuck up and beheaded them, only to discover it was your own king...",
                                    "You ruminate on the time you couldn't stop snickering at the name of your commander's fiend, Biggus Dicus. He had everyone executed for insubordinate giggling just after you excused yourself..."
                                };
                            speech = goblin_RustyChains.Parle(description, parlance, responses);
                            switch (speech)
                            {
                                case 1:
                                    Console.WriteLine("The jailor sniffs.'Yeah, well, don't worry. I won't be handing you my wineskin anytime soon, so I think we'll be safe...'");
                                    Console.WriteLine("You make to reply but before you can get another word in the jailor has already stalked away...");
                                    break;
                                case 2:
                                    Console.WriteLine("'That makes no sense...' the jailor responds, 'do you mean an African swallow or a European swallow?'");
                                    Console.WriteLine("You respond that the bridgekeeper didn't know that either...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("'So..?' you say.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("'Wot?' is the jailor's distracted reply.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("'Can I go,' you ask. 'You know how it is' you say. You tell him you've got places to go people to see...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("'Yeah, well, I tell's you wot,' the goblin replies, 'if I go hurtlin' through the air, maybe catapulted by one of these loose floorboards the damn carpenter should've blahdy well fixed by now, you'll be free to go. Until then...");
                                    Console.WriteLine("Without further ado, you hear the jailor stalk away somewhere well beyond the door");
                                    break;
                                case 3:
                                    Console.WriteLine("'A regicide, eh?' the jailor remarks, 'sounds like you would fit in with half the blokes in our mercenary company...");
                                    Console.WriteLine("Without further ado, you hear the jailor stalk away somewhere well beyond the door");
                                    break;
                                case 4:
                                    Console.WriteLine("For a moment you wonder if the jailor has tip-toed away, then you hear a stifled snicker. Soon the snicker bubbles into a muffled titter of delight. This in turn rolls into a gushing babble of laughs, before the jailor starts wheezing, clearly out of breath as his lungs ache for air amidst barks of raucous mirth.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("'Biggus...' he wheezes, collapsing to the floor just outside your cell, '...oh god...Diccus, Bwa Ha ~ can't breathe... ha!'");
                                    Console.ReadKey(true);
                                    Console.WriteLine("The jailor dies.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("You look down and find the jailor's keys are just peeping through the gap under the door. With a happy-go-lucky shrug, you manage to purloin them from your captor and open the door to escape! \nYou find the dead goblin just by the foot of your door, it's face frozen in a rictus of half way between terror and hilarity.");
                                    battle.WonFight();
                                    inventory.Add(jailorKeys);                             
                                    return false;
                                default:
                                    Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("The mysterious jailor only guffaws as it leaves you to your dank cell...");
                            break;
                    }



                }
                return false; 
            }
        }
        public List<bool> UseItem(Item item1, Item item2, Dictionary<Item, List<Item>> usesDictionary, Feature feature = null, Item plusItem = null, Room room = null, Player player = null, Feature addFeature = null, Dictionary<Item, List<Feature>> usesDictionaryItemFeature = null, Dictionary<Item, List<Player>> usesDictionaryItemChar = null, Player player1 = null, Combat trialBattle = null)
        {
            List<bool> tlist = new List<bool> { false, false };
            if (usesDictionary[item1].Contains(item2))
            {
                item2.Attribute = !item2.Attribute; // key lock unlock, weapon intact broken, magical charm uncharmed charmed, etc
                if (item2.Attribute == false)
                {
                    item2.SpecifyAttribute = item2.SpecifyAttribute.Substring( 2, item2.SpecifyAttribute.Length-2);
                    if (item1.Name == "magnifying glass" && item2.Name == "garment" && player.Traits.ContainsKey("jinxed"))
                    {
                        Console.WriteLine("You slump to the floor, if not exactly resigned then idling in an absent minded flight of fancy. You toy with the magnifying glass, a bored expression on your face as you twist it this way and that.\nIt's minutes before an acrid scent hits your nostrils. Is that fried bacon?");
                        Console.ReadKey(true);
                        Console.WriteLine($"You look down and yelp as you realise the magnifying glass had focused the light from the brazier. The garment you'd picked up has caught fire!");
                        Console.ReadKey(true);
                        Console.WriteLine("You flail it around trying to put out the flames like a crazed whirlwind of oafishness, spreading the fire in the process. Already a pool of dark, cloying smoke billows about the ceiling as the dank cell heats up like a furnace. You throw the garment at the door, before banging on it for all your worth. \nYou yell out that there's a fire. It's not long before boots stomp their way towards your door. Tumblers turn, then a powerful kick flings it open.");
                        Console.ReadKey(true);
                        Console.WriteLine("You brace yourself for the fight of your life...");
                        Console.ReadKey(true);
                        player.Inventory.Remove(item2);
                        bool fire = true;
                        if (trialBattle.Fight(usesDictionary, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, addFeature, fire))
                        {
                            tlist[0] = true;
                            tlist[1] = true;
                            
                            return tlist;
                        }

                        
                        else { Console.ReadKey(true); tlist[1] = true; return tlist; }
                    }
                    else if(item1.Name == "magnifying glass" && item2.Name == "garment")
                    {
                        Console.WriteLine("If you can't start a fire with the naked flame, then you guess the only way will be with the magnifying glass.\nHolding it close to the brazier to capture and harness the most light, you focus its rays upon the garment, beads of nervous sweat prickling your brow as you concentrate.");
                        Console.ReadKey(true);
                        Console.WriteLine("It's not before too long that you've managed to get the garment to smoulder. Cupping it in your hands you gently breathe over it, teasing forth the flames.\nOnce its burning you tuck the blazing garment under the door, letting the smoke billow out into the corridor. Now, at last, you hammer upon the door, yelling that the room's ablaze...");
                        Console.ReadKey(true);
                        Console.WriteLine("You planned for it to burn slowly.");
                        Console.ReadKey(true);
                        Console.WriteLine("You planned for the fire to be controlled.");
                        Console.ReadKey(true);
                        Console.WriteLine("However, its not long before your feigned panic congeals into very real terror. Before your eyes, and in spite of your frantic attempts to stomp it out, the fire has spread to the other garments littered throughout the room.");
                        Console.WriteLine("You begin to scream out for help, when your yells are answered. Heavy boots stomp their way towards your door. Tumblers turn, then a powerful kick flings it wide.");
                        Console.ReadKey(true);
                        Console.WriteLine("You brace yourself for the fight of your life...");
                        Console.ReadKey(true);
                        player.Inventory.Remove(item2);
                        bool fire = true;
                        if (trialBattle.Fight(usesDictionary, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, addFeature, fire))
                        {
                            tlist[0] = true;
                            tlist[1] = true;
                            return tlist;
                        }
                        else { Console.ReadKey(true); tlist[1] = true; return tlist; }
                    }
                    else if (item2.Name == "note" && item1.Name == "magnifying glass")
                    {
                        Console.WriteLine("  You peer through the magnifying glass and suddenly the note's mysterious, tiny scrawl starts to make sense...");
                        item2.Description = "Someone has scrawled upon the note in hasty erratic cursive. It reads, 'I don't have long now. If you're reading this then you're likely another foolhardy adventurer like myself who got his'self kidnapped just as I woz. I don' have much space so mark my words. Whatever they tell you - its a lie. They're going to harm you. They're most likely going to kill you in one of their mad experiments. There's a music box. I kept it locked away and hidden from sight. It's in the chest. It may look empty but set in its bottom is a panel that can be removed. You'll find it there. If you play it the guard loses his marbles about it. Can't stand the tune, the little blighter! It's like nails on a chalkboard to 'em creatures. When it enters, subdue the loathsome thing. It's the only way out of 'ere. Hopefully, if I don't make it, at least someone else will...' The rest deteriorates into an illegible scribble at the bottom of the page.";
                        if (feature.ItemList.Count==0 && !player.Inventory.Contains(plusItem) && !room.ItemList.Contains(plusItem)) 
                        { 
                            feature.ItemList.Add(plusItem); 
                        }
                        Console.WriteLine(item2.Description);
                        Console.WriteLine($"After having finally read the note, you eye the rosewood chest with renewed interest...");
                    }
                    else if ((item2.Name == "other half of a cracked bowl" && item1.Name == "half a cracked bowl")||(item1.Name == "other half of a cracked bowl" && item2.Name == "half a cracked bowl"))
                    {
                        Console.WriteLine("Your tongue parts your lips just slightly as you pick up the two halves of the bowl, one in each hand.\nYour shrewd gaze turns from one to the other, tongue still protruding slightly in derpy concentration. Then you place the two halves together to make a (w)hole. \nYou then place this (w)hole in the ceiling creating an exit to the room above.\nWait? You catch yourself. Does this make sense? \n\t'Sure it does!' your fairy friends assure you. \nYeah...yeah, of course. Thanks guys!");
                        room.FeatureList.Add(addFeature);// feature = holeInCeiling
                        player.Inventory.Remove(item1);
                        player.Inventory.Remove(item2);
                        room.ItemList.Remove(item1);
                        room.ItemList.Remove(item2);
                        Console.WriteLine($"You now have a way out of the {room.Name}!");
                    }
                }
                else
                {
                    item2.SpecifyAttribute = "un" + item2.SpecifyAttribute;
                }
                tlist[0] = true;
                return tlist;
            }
            else { return tlist; }

        }
        public bool UseItem3(Item item1, Player player, Dictionary<Item, List<Player>> usesDictionary)
        {
            try {
                if (usesDictionary[item1].Contains(player))
                {


                    Dice D6 = new Dice(6);
                    string propString = item1.Special.Substring(0, Special.IndexOf(":"));
                    //PropertyInfo boost = typeof(int).GetProperty(propString);
                    //object value = boost.GetValue(player, null);
                    //int CharacterAttribute = Convert.ToInt32(value);
                    if (propString == "Stamina")
                    {
                        if (player.Traits.ContainsKey("medicine man"))
                        {
                            int boost = D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6);
                            if (player.Stamina == player.InitialStamina)
                            {
                                Console.WriteLine($"{item1.Name} has no effect. You're already as fit as can be.");
                            }
                            else if (player.Stamina + boost > player.InitialStamina)
                            {
                                player.Stamina = player.InitialStamina;
                                Console.WriteLine("\nYou've fully healed!");
                            }
                            else
                            {
                                player.Stamina += boost;
                                Console.WriteLine($"\nYou've healed by {boost} stamina points!");
                            }
                        }
                        else if (player.Traits.ContainsKey("friends with fairies"))
                        {
                            Dice D40 = new Dice(40);
                            Dice D4 = new Dice(4);
                            int boost = D40.Roll(D40);
                            if (player.Stamina + 2*player.Skill >= player.InitialStamina)
                            {
                                if (boost < 13)
                                {
                                    Console.WriteLine($"The {item1.Name} was super tasty, but had no effect. You are already as fit as can be. So scrumptious though... Your fairy friends urge you to drink another. Yum!");
                                }
                                else if (boost < 27)
                                {
                                    Console.WriteLine($"You feel the {item1.Name} awakening some dormant Fey magic! The world seems to whirl dizzyingly around you as you follow the fairies' dance. Your footwork and fighting stance become a bewilderingly erratic and unpredictable shuffle, scrape and stomp of feverish steps as you're swept up in the danse macabre with your pixie friends...");
                                    foreach (Weapon w in player.WeaponInventory)
                                    {


                                        w.Boon += D4.Roll(D4) - 1;


                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Urgh! That {item1.Name} didn't taste like the Fey 'magic' you've grown accustomed to... \nYou lose {boost/5} stamina points!");
                                    player.Stamina -= boost/5;
                                }
                            }
                            else if (player.Stamina + boost > player.InitialStamina)
                            {
                                player.Stamina = player.InitialStamina;
                                Console.WriteLine("\nYou've fully healed! \nAnd your chakras feel all sparkly too...");
                            }
                            else
                            {
                                player.Stamina += boost;
                                Console.WriteLine($"\nYou've healed by {boost} stamina points!");
                            }
                        }
                        else
                        {
                            int boost = D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6);
                            if (player.Stamina == player.InitialStamina)
                            {
                                Console.WriteLine("You're already at full health! But at least the potion tastes good...");
                            }
                            else if (player.Stamina + boost > player.InitialStamina)
                            {
                                player.Stamina = player.InitialStamina;
                                Console.WriteLine("\nYou've fully healed!");
                            }
                            else
                            {
                                player.Stamina += boost;
                                Console.WriteLine($"\nYou've healed by {boost} stamina points!");
                            }
                        }
                        player.Inventory.Remove(item1);
                        return true;
                    }
                    else if (propString == "Skill")
                    {
                        int boost = item1.SpecialEffect;
                        if (player.Skill + boost > 10)
                        {
                            Console.WriteLine($"{item1.Name} has no effect. You couldn't be more skilled if you tried.");
                        }
                        else
                        {
                            player.Skill += boost;
                            Console.WriteLine(player.DescribeSkill() + "Your skill has increased!");
                        }
                        player.Inventory.Remove(item1);
                        return true;
                    }
                    else if (propString == "Luck")
                    {
                        
                        

                        
                        
                        
                        foreach (Weapon w in player.WeaponInventory)
                        {


                            w.Boon += item1.SpecialEffect;


                        }
                        player.Inventory.Remove(item1); 
                        
                        return true;
                    }
                    else { Console.WriteLine($"~~{item1.Name} is an unknown quantity~~"); return false; }

                    }
                else
                {
                    Console.WriteLine("You can't use that item on yourself or anything to hand!");
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Not possible to use that item on yourself!"); return false;
            }
            }
    }
    // weapon child of item includes different types and number of dice to roll
    public class Weapon : Item
    {
        private List<Dice> Damage { get; set; }
        private List<string> CritAttack { get; }
        private List<string> GoodAttack { get; }
        public int Boon { get; set; }
        public bool Equipped { get; set; }
        public Weapon(string name, string description, List<Dice> damage, List<string> critAttack, List<string> goodAttack, int boon = 0, bool equipped = false) : base(name, description)
        {
            Name = name;
            Description = description;
            Damage = damage;
            CritAttack = critAttack;
            GoodAttack = goodAttack;
            Boon = boon;
            Equipped = equipped;

        }
        /// <summary>
        /// the following calculates the damagedealt and any other special comments to be 
        /// posted to console during one turn of combat. both monsters and players use
        /// this function.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="opponentSkill"></param>
        /// <param name="enemyStamina"></param>
        /// <param name="commentary"></param>
        /// <param name="monsterName"></param>
        /// <param name="player"></param>
        /// <param name="another"></param>
        /// <param name="room"></param>
        /// <param name="holeInCeiling"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int Attack(int skill, int opponentSkill, int enemyStamina, bool commentary, Monster monsterName, Player player, string another, Room room, Feature holeInCeiling, bool start = false)
        {
            Dice D18 = new Dice(18);
            Dice D16 = new Dice(16);
            Dice D3 = new Dice(3);
            Dice D4 = new Dice(4);
            
            List<string> jinxedMisses = new List<string>
            {
                $"The {monsterName.Name} has you now! Finally, relishing it's soon-to-be freedom from your cursed, jinxy hide, it raises its {monsterName.Items[0].Name} to strike... and gets it stuck in the {room.FeatureList[D4.Roll(D4) - 1].Name}. You scurry away as the {monsterName.Name} curses, trying to free it. \nThe {monsterName.Name} loses 1 stamina.",
                $"The ever-increasingly vexed {monsterName.Name} attacks, misses, and gets really bad tennis-elbow. Ooh! that's gotta hurt... \nThe {monsterName.Name} loses 2 stamina.",
                $"The {monsterName.Name} lunges at you! As you trip over yourself, clumsily scrambling for cover, you hear a tremendous crash. \nThe {monsterName.Name} ran into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Ow! It loses 5 Stamina.",
                $"The {monsterName.Name} at last has you pinned. It looms over you with a leer, ready to deliver the killing blow, when part of the {room.Name}'s ceiling caves in upon its head. \nThe {monsterName.Name} loses 7 stamina!",
                $"The {monsterName.Name} bellows a string of foul curses as each frenzied attack miraculously leaves you unscathed. It bites its own tongue in the process. Youch! \nAs you slip away, the {monsterName.Name} loses 1 stamina...",
                $"The {monsterName.Name} bounds after you in circles, flailing wildly. It careers into a {room.ItemList[D3.Roll(D3) - 1].Name}, grazing its knee. Oof! That's a nasty splinter! \nThe {monsterName.Name} loses 3 stamina.",
                $"You stammer as you try reasoning with the {monsterName.Name}. Surely you can just talk things out over a lovely cup of mead... The {monsterName.Name} doesn't listen. It lunges at you, only to crash into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Yikes! \nThe {monsterName.Name} loses 11 stamina.",
                $"In frustration the {monsterName.Name} hurls its {monsterName.Items[0].Name} at you! It bounces off your armour back at the {monsterName.Name}. \n The {monsterName.Name} loses 6 stamina.",
                $"The {monsterName.Name} attacks wildly, wanting nothing more than to end the whirlwind of chaos your ill-fortune brings. It trips. Ouch! That's going to need a bandage... \nThe {monsterName.Name} loses 7 stamina.",
                $"The {monsterName.Name} at last has you cornered. It looms over you with a leer, ready to at last deliver the killing blow. Then the {room.Name}'s ceiling caves in.\n The {monsterName.Name}'s engulfed by an avalanche of cascading debris. A trickle of dust takes a moment to stop. Then finally, one loose floorboard topples from the floor above and crowns the heap.",
                $"The {monsterName.Name} gets hit by a random meteorite - or was it a shooting star? Either way, what are the chances? \n The {monsterName.Name}'s head falls off as you make a wish... ",
                $"The {monsterName.Name} stubs its toe on the {room.ItemList[D3.Roll(D3) - 1].Name}...\nShortly afterwards it is crushed by the full force of the extreme probability wave generated by the Felix Felicis you drank, blasting the creature apart like an abstract nuclear device of pure mathematics. Paradoxes open and close in the underlying fabric of reality, swallowing the {monsterName.Name} whole before burping out the toe.\nHuh, you say as you take a second glance at the potion's ingredients list...",
                $"The {monsterName.Name}'s armour chafes, building up a freakish amount of static charge. A bolt of lightning strikes the {monsterName.Name} from, uh, somewhere(?)... \nThat was sure unlucky. You ponder the odds as more lightning bolts repeatedly fry the {monsterName.Name} to a crisp."
                
                
            };
            ///The above is special comments for jinxed characters, characters
            ///who drink felix felicis, or for the last three characters who
            ///have the trait 'friends with fairies' and drink felix felicis.
            int goodHit;
            bool crit = false;
            bool good = false;
            int hitThreshold = 0;// hit threshold is the number under which you need to roll on a D20 to hit an enemy
            // commentary is only true if the player is attacking
            if (commentary && player.Traits.ContainsKey("opportunist"))
            {
                hitThreshold = 18 + skill / 2 - opponentSkill / 2;
            }
            //if monster is attacking and human armadillo.
            else if (!commentary && player.Traits.ContainsKey("human armadillo"))
            {
                hitThreshold = 13 + skill / 3 - opponentSkill / 2;
            }
            else
            {
                hitThreshold = 15 + skill / 2 - opponentSkill / 2;
            }
            Dice D20 = new Dice(20);
            int hitRoll = D20.Roll(D20);

            hitRoll -= Boon;
            int damageDealt = 0;
            ///if the player/monster scores a hit...
            if (hitRoll < hitThreshold)
            {
                if (commentary) //if the player is attacking...
                {
                    Console.WriteLine($"Roll for your {Name}...");
                    foreach (Dice d in Damage)
                    {
                        Console.ReadKey(true);
                        int roll = d.Roll(d);
                        damageDealt += roll;
                        Console.WriteLine($"You rolled a {roll}");

                    }
                }
                else
                {
                    if (!start)
                    {
                        List<string> enemyCounters = new List<string>
                            {
                            $"The {monsterName.Name} recovers and launches its attack!",
                            $"The {monsterName.Name} swipes your next attack away and braces to counter!",
                            $"The {monsterName.Name} just manages to fend you off and lunges at you!",
                            $"The {monsterName.Name} reels from your attack! It attempts a counter."
                            };
                        if (hitThreshold - hitRoll > 3 * hitThreshold / 4)
                        {
                            Console.WriteLine(enemyCounters[3]);
                        }
                        else if (hitThreshold - hitRoll > hitThreshold / 2)
                        {
                            Console.WriteLine(enemyCounters[2]);
                        }
                        else if (hitThreshold - hitRoll > hitThreshold / 4)
                        {
                            Console.WriteLine(enemyCounters[0]);
                        }
                        else
                        {
                            Console.WriteLine(enemyCounters[1]);
                        }
                    }

                    foreach (Dice d in Damage)
                    {

                        int roll = d.Roll(d);
                        damageDealt += roll;


                    }

                }
                int baseDamage = damageDealt;
                string damageFlag = $"You've dealt {damageDealt} damage ";







                if ((hitThreshold - hitRoll) - 3 > opponentSkill)
                {
                    goodHit = (hitThreshold - opponentSkill);
                    good = true;
                    damageFlag += "plus a good hit bonus!";
                }
                else
                {
                    goodHit = 0;

                }
                if (hitRoll <= skill / 3 && (hitThreshold - hitRoll - 3) > opponentSkill)
                {
                    if (player.Traits.ContainsKey("sadist"))
                    {
                        damageDealt += (skill / 2) * damageDealt * 5 / 4;
                    }
                    else if (skill == 1)
                    {
                        damageDealt += damageDealt;
                    }
                    else
                    {
                        damageDealt += (skill / 2) * damageDealt;
                    }
                    crit = true;
                    damageFlag = $"Critical Hit! You've dealt {baseDamage} x (skill score)/2 + {goodHit / 2} damage!";
                }
                if (commentary)
                {
                    //Console.WriteLine($"\n {damageFlag}\n");
                    ///there are specific comments for whether a good attack or a crit attack
                    ///lands and determined by both player skill and how much relative damage they do as a proportion 
                    ///to the enemy's remaining stamina.
                    if (crit)
                    {

                        if (skill > 8)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(CritAttack[0]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[1]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[2]);
                            }
                            else
                            {
                                Console.WriteLine(CritAttack[3]);
                            }

                        }
                        else if (skill > 5)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(CritAttack[4]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[5]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[6]);
                            }
                            else
                            {
                                Console.WriteLine(CritAttack[7]);
                            }
                        }
                        else if (skill > 2)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(CritAttack[8]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[9]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[10]);
                            }
                            else
                            {
                                Console.WriteLine(CritAttack[11]);
                            }
                        }
                        else
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(CritAttack[12]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[13]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[14]);
                            }
                            else
                            {
                                Console.WriteLine(CritAttack[15]);
                            }
                        }
                        Console.WriteLine("\n");
                    }
                    else if (good)
                    {
                        Console.WriteLine("\n");
                        if (skill > 8)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(GoodAttack[0]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[1]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[2]);
                            }
                            else
                            {
                                Console.WriteLine(GoodAttack[3]);
                            }

                        }
                        else if (skill > 5)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(GoodAttack[4]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[5]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[6]);
                            }
                            else
                            {
                                Console.WriteLine(GoodAttack[7]);
                            }
                        }
                        else if (skill > 2)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(GoodAttack[8]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[9]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[10]);
                            }
                            else
                            {
                                Console.WriteLine(GoodAttack[11]);
                            }
                        }
                        else
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(GoodAttack[12]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[13]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[14]);
                                another = "another";
                            }
                            else
                            {
                                Console.WriteLine(GoodAttack[15]);
                                another = "another";
                            }
                        }
                        Console.WriteLine("\n");
                    }
                }


                if (!commentary && player.Traits.ContainsKey("thick-skinned")) { return (4 * (damageDealt + goodHit / 2) / 5); }
                else
                {
                    return (damageDealt + (goodHit / 2));
                }
            }
            else // you or the monster misses!
            {
                if (commentary)
                {
                    Console.WriteLine("Your attack misses!");
                }
                else
                {
                    int playerBoon = 0;
                    
                    if (player.Traits.ContainsKey("jinxed")) { playerBoon = 6; }
                    int o = 0;
                    foreach (Weapon w in player.WeaponInventory)
                    {
                        
                        
                        if (w.Boon > 9)
                        {
                            o++;
                        }
                        
                    }
                    if (o == player.WeaponInventory.Count && player.WeaponInventory.Count!=0)
                    {
                        playerBoon += 10; // Felix Felicis effect
                    }
                    if (20 - (10 - skill) / 3 < hitRoll + playerBoon)// ensures only boon of 5 or more (i.e. jinxed or flix drinkers) receive these events.
                    {
                        ///Jinxed critmisses for the monster, including possible instant death
                        if (player.Traits.ContainsKey("friends with fairies") && playerBoon > 9)
                        {
                            Dice D26 = new Dice(26);
                            int rollmiss = D26.Roll(D26);
                            if (rollmiss > 20) 
                            {
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);
                                damageDealt = -9999;
                            }

                            else if (rollmiss > 18 && enemyStamina < 2 * enemyStamina / 3)
                            {
                                damageDealt = -9999;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);
                                room.FeatureList.Add(holeInCeiling);
                            }
                            else if (rollmiss > 18)
                            {
                                Console.WriteLine(jinxedMisses[(rollmiss - D16.Roll(D16) - 2) / 2]);
                            }
                            else if (rollmiss > 16)
                            {
                                damageDealt = -7;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 14)
                            {
                                damageDealt = -6;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 12)
                            {
                                damageDealt = -11;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 10)
                            {
                                damageDealt = -3;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 8)
                            {
                                damageDealt = -1;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 6)
                            {
                                damageDealt = -7;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 4)
                            {
                                damageDealt = -5;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 2)
                            {
                                damageDealt = -2;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else
                            {
                                damageDealt = -1;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                        }
                        else if (player.Traits.ContainsKey("jinxed") || playerBoon>9)
                        { 
                            int rollmiss = D20.Roll(D20);
                            
                            if(rollmiss > 18 && enemyStamina < 2*enemyStamina/3)
                            {
                                damageDealt = -9999;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);
                                room.FeatureList.Add(holeInCeiling);
                            }
                            else if (rollmiss > 18)
                            {
                                Console.WriteLine(jinxedMisses[(rollmiss - D16.Roll(D16) - 2) / 2]);
                            }
                            else if (rollmiss > 16)
                            {
                                damageDealt = -7;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 14)
                            {
                                damageDealt = -6;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 12)
                            {
                                damageDealt = -11;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 10)
                            {
                                damageDealt = -3;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if(rollmiss > 8)
                            {
                                damageDealt = -1;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if(rollmiss > 6)
                            {
                                damageDealt = -7;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if(rollmiss > 4)
                            {
                                damageDealt = -5;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if(rollmiss > 2)
                            {
                                damageDealt = -2;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else
                            {
                                damageDealt = -1;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            // ~~~ code that selects effect / drop weapon, room feature falls on head, breaks item in room, crashes through door, etc. ~~~
                        }
                        else { Console.WriteLine($"The {monsterName.Name}'s attack misses!"); }
                    }
                    else { Console.WriteLine($"The {monsterName.Name}'s attack misses!"); }
                }
                return damageDealt;
            }
        }


    }
}

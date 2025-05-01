using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// This character class is an abstract one from which Monster and Player 
    /// derive Skill Stamina and also equip() and unequip(), which is typically used
    /// in combat
    /// </summary>
    public class Character: IHasStats
    {
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Stamina { get; set; }
        public List<Item> Inventory { get; set; }

        public Character(string name = "Someone", int skill = 0, int stamina = 0, List<Item> inventory = null)
        {
            Name = name;
            Skill = skill;
            Stamina = stamina;
            Inventory = inventory;

        }
        /// <summary>
        /// This function is called mostly in battle when the player wishes to
        /// change weapon. It is overrided by the Monster's equip function,
        /// which has to achieve the same effect through a slightly different means.
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="inventory"></param>
        /// <param name="player"></param>
        virtual public void Equip(Weapon weapon, List<Weapon> inventory, Player player)
        {
            foreach (Weapon x in inventory)
            {
                x.Equipped = false;
            }
            if (player.Traits.ContainsKey("jinxed")) { weapon.Boon = 6; }
            weapon.Equipped = true;
        }
        virtual public void Unequip( List<Weapon> inventory, List<Item> specialItems = null)
        {
            foreach (Weapon x in inventory)
            {
                x.Equipped = false;
            }
        }
        public string DisplayName() { return Name; }
        public int DisplaySkill() { return Skill; }
        public int DisplayStamina() { return Stamina; }
    }
    public class Player : Character
    {
        /// <summary>
        /// In addition to inventory players also have weaponInventory as something
        /// distinct for holding weapons. They also have traits and they have 
        /// initial stamina
        /// 
        /// New properties have since been added to the Player class. These include
        /// whether or not they are disguised (Masked), their CarryCapacity which
        /// limits the number of items they can carry and increases with InitialStamina,
        /// whether or not they've recently taken a potion of alacrity, whether they escaped 
        /// the prison by arson, midnightClock which times the player and begins the countdown
        /// to the ritual's completion so they have to race to fight the final boss, MGItemsDonated
        /// details how many special items have already been given to Merigold, Fooled which determines
        /// how much they know of the mysterious prisoner in the lowest levels of the tower 
        /// and finally, UncoverSecretsOfMyrovia - this determines whether a special epilogue is
        /// triggered upon completion of the game.
        ///
        /// </summary>
        public int InitialStamina { get; set; }
        public List<Weapon> WeaponInventory { get; set; }
        public Dictionary<string, string> Traits { get; set; }
        public bool Masked { get; set; }
        public int CarryCapacity { get; set; }
        public bool FieryEscape { get; set; }
        public bool Speedy { get; set; }
        public Stopwatch midnightClock { get; set; }
        public int MGItemsDonated { get; set; }
        public bool Fooled { get; set; }
        public int UncoverSecretOfMyrovia { get; set; }
        public Player(string name, int skill, int stamina, List<Weapon> weaponInventory, List<Item> inventory, Dictionary<string, string> traits, bool masked = false, bool fieryEscape = false, bool speedy = false, Stopwatch midnightClock = null, int MGItemsDonated = 0)
        {
            Name = name;
            Skill = skill;
            Stamina = stamina;
            InitialStamina = stamina;
            WeaponInventory = weaponInventory;
            Inventory = inventory;
            Traits = traits;
            Masked = masked;
            CarryCapacity = 12;
            FieryEscape = fieryEscape;
            Speedy = speedy;
            this.midnightClock = midnightClock;
            this.MGItemsDonated = MGItemsDonated;
            Fooled = true;
            UncoverSecretOfMyrovia = 0;
        }
        
        public string DescribeSkill()
        {
            if (Skill > 9)
            {
                return "Lithe as a panther, you don't walk but slink with the undulating grace and poise of a feline predator. Your reactions, like your wits, are sharper than even the keenest blade and you can move with a speed that is at once frightening and uncanny. Were there such a thing as a weapon you're not yet proficient with, your instincts and dextrous hands would achieve its mastery in mere seconds.";
            }
            else if (Skill > 7)
            {
                return "You're fast, you're skilled and you're deadly. You've an assassin's flair for marking your target and striking with such cool precision and alacrity that they've scarcely a hope of retaliating. Few can stand against you and the right blade.";
            }
            else if (Skill > 6)
            {
                return "You have admirable proficiency with more than a few basic weapons. You can feint, dodge and parry, if not elegantly, then at least with some confidence. With the right weapon in hand, you might just make it through this quest.";
            }
            else if (Skill > 5)
            {
                return "Your skills are nothing spectacular. With enough training you could accomplish a competent proficiency with any weapon, but you haven't exactly been training too hard.";
            }
            else if (Skill > 4)
            {
                return "You weren't paying attention to sparring matches or fights or even light-hearted kafuffles when you had the chance. Now you may come to regret it...";
            }
            else if (Skill > 3)
            {
                return "When you were growing up, it wasn't often you were ever entrusted with anything too sharp. In your hands, a weapon can be a lethal thing, but rarely to anyone else.";
            }
            else if (Skill > 1)
            {
                return "It is told that there exists an ancient hex in some arcane tome that when cast upon people, removes their opposable thumbs, fingers and sometimes their head... They swing a sword better than you.";
            }
            else
            {
                return "One-legged elephants can tip-toe quieter than you can. \nThey're more likely to do it without toppling over too...";
            }
        }
        public string DescribeStamina()
        {
            if (Stamina < InitialStamina / 8)
            {
                return "You've blood gushing from somewhere, your vision blurs and sharpens sporadically, and you have to drag your foot behind you in a severe limp. You're almost keeling over, your heart thumping weaker and weaker. You can feel your life hanging by a thread.";
            }
            else if (Stamina < 2 * InitialStamina / 8)
            {
                return "You might be able to muster enough strength and courage to make a gallant last stand, but it'd be a feat of exceptional luck or divine providence to come out of it alive.";
            }
            else if (Stamina < 3 * InitialStamina / 8)
            {
                return "Things are beginning to look bleak. If you don't find a way to heal yourself now you might not last.";
            }
            else if (Stamina < InitialStamina / 2)
            {
                return "Your wounds are serious. Your physical condition does not bear grave news yet, but something must be done to remedy this sooner rather than later.";
            }
            else if (Stamina < 5 * InitialStamina / 8)
            {
                return "You're struggling with the pain. It's not an exaggeration to say that you're in need of healing, but if push comes to shove, you can keep going for a while longer.";
            }
            else if (Stamina < 3 * InitialStamina / 4)
            {
                return "In addition to more than a few brazes, you've also received one or two open wounds that need tending too, but thankfully not with any urgency";
            }
            else if (Stamina < 7 * InitialStamina / 8)
            {
                return "You can spot a few cuts and brazes on your body, but hardly anything to be concerned about. You can press on without too much anxiety.";
            }
            else
            {
                return "You're as fit and lively as you've ever been. You've a spring in your step as you bound ever forward in your quest.";
            }
        }
        public string DescribeInitialStamina()
        {
            if (InitialStamina < 70)
            {
                return "It's called exercise, yeah? You should try it... Yesterday.";
            }
            else if (InitialStamina < 80)
            {
                return "You learned quickly that telling people you're an adventurer isn't the way to go. Their snorts of laughter tend to draw unwanted attention to your mission. Better to keep quiet and pass unnoticed. Stealth and quick wits aren't just a precaution for you, but a necessity.";
            }
            else if (InitialStamina < 90)
            {
                return "When you tell the gentle folk of many fantastical villages that you're an intrepid adventurer, most raise a quizzical (if not sceptical) eyebrow in response. Though they're too polite to say it, most likely mistook you for a bookish chronicler, or perhaps an underfed squire to the much burlier knight they'd been expecting.";
            }
            else if (InitialStamina < 100)
            {
                return "You may once have been lithe and well-built, but if so, you aren't now. You're far from the strongest person to champion such a cause, but you're also far from the weakest too. You may yet live to see another dawn, if you're lucky...";
            }
            else if (InitialStamina < 110)
            {
                return "You've kept active, honing your muscles from time to time. You may not be a natural athlete, but your confidence in your own endurance seems well-placed - Just so long as you're not overly confident.";
            }
            else if (InitialStamina < 120)
            {
                return "You're as strong as an ox and physically capable of most challenges thrown your way. When you're not passing the time bending horseshoes single-handed, you're scouting for beasts to fell with your mighty weapon and otherwise being a nuisance to sorcerous demagogues and warlock tyrants.";
            }
            else
            {
                return "To describe you as one of the seven wonders of the world would frankly be an understatement. Your raw, physical prowess leaves those lucky enough to clap eyes on you trembling in your wake. Your 'sweet bod' is the sort of exemplary specimen even Conan the Barbarian would grudgingly admire.";
            }
        }
        /// <summary>
        /// This returns a summary of the character's status: - health, skill, traits, whether any potion
        /// special effects are active and whether they are in a race to stop time before a 
        /// diabolical ritual is completed.
        /// </summary>
        public void CheckStatus()
        {
            Console.WriteLine($"Your stamina score is: {Stamina}/{InitialStamina}");
            Console.WriteLine(DescribeStamina());
            Console.WriteLine($"\nYour current skill is: {Skill}");
            Console.WriteLine(DescribeSkill());
            foreach(KeyValuePair<string, string> k in Traits)
            {
                Console.WriteLine("\n" + k.Value);
            }
            if (Speedy)
            {
                Console.WriteLine("\nPotion of alacrity is active!\nYou are filled with jittery energy, flitting about from one action to the next with disconcerting speed...");
            }
            int count = 0;
            foreach (Weapon w in WeaponInventory)
            {
                if (w.Boon > 9)
                {
                    count++;
                }
            }
            if (count == WeaponInventory.Count && count != 0)
            {
                Console.WriteLine("\nFelix Felicis is active! \nBuoyed with boundless optimism every action you take seems to miraculously turn out in your favour...");
            }
            if (midnightClock != null)
            {
                midnightClock.Stop();
                long timeTaken = midnightClock.ElapsedMilliseconds;
                midnightClock.Start();
                long timeToMidnight = 1800000;
                long timeLeft = (timeToMidnight - timeTaken) / 60000;
                if (timeLeft < 0)
                {
                    Console.WriteLine("\nMidnight is upon you!");
                }
                else
                {
                    Console.WriteLine($"\nYou have only {timeLeft} minutes until the clocks strike twelve!");
                }
            }
            Console.ReadKey(true);
            return;
        }
        /// <summary>
        /// The following is a similar line of code as searchFeature. It fulfills the same
        /// function, only when it uses pickUpItem we specify the range as 5, meaning
        /// the commentary and options are slightly different to normal. in any case
        /// the formula for this code is very similar to searchfeature.
        /// 
        /// I've since utilised LINQ to sort Items and Weapons by a number of useful
        /// attributes.
        /// 1. Items can be arranged by usefulness ; that is which items can be used on the 
        /// greatest number of items in the current room. (usually keys[doors, cabinets, trunks,
        /// chests] and potions[used on the player character])
        /// 2. Weapons can be ordered by the Damage they're expected to deal. Since its determined
        /// by dicerolls this is calculated by summing the total number of dice to be rolled
        /// by the total number of faces and then dividing by two.
        /// 3. Weapons can be arranged by the maximum damage they can deal. This is done by 
        /// summing the total number of faces of the dice to be rolled.
        /// 4. Weapons can be ordered by the chance they have to land a hit and land a critical.
        /// This is measured by their Boon which shifts the odds of landing a hit in the player's favour.
        ///   Incidentally, a boost to Boon is also how jinxed characters and those who drink Felix
        /// Felicis receive their effects during battles.
        /// 
        /// </summary>
        /// <param name="roomItems"></param>
        public void SearchPack(List<Item> roomItems, Room room, List<Room> threadPath, Dictionary<Item, List<Item>>usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, Dictionary<Item, List<Player>> usesDictionaryItemChar, List<Item> AllItems)
        {
            Console.WriteLine("Rummaging through your effects you find the following;");
            int r = 1;
            string message = "";
            foreach (Weapon w in WeaponInventory)
            {
                message += $"[{r}] {w.Name}\n";
                r++;
            }
            foreach (Item item in Inventory)
            {
                message += $"[{r}] {item.Name}\n";
                r++;
            }

            if (r == 1)
            {
                message = "You have no items or weapons in your pack. \nIt's as empty as the word of that mysterious innkeeper who betrayed you. Better get moving...";
                Console.WriteLine(message);
                Console.ReadKey(true);
                return;
            }
            else
            {
                message += $"[{r}] Try something else...";
            }
            

            bool continueLoop = true;
            int a = 0;
            
            while (continueLoop)
            {
                Console.WriteLine($"[A] Show all personal effects...\n[W] Show WEAPONS only...\n[I] Show ITEMS only...\n[U] Order by USEFULNESS within {room.Name}...\n[D] Review past and current weapons by AVERAGE DAMAGE they deal...\n[X] Review past and current weapons by MAX DAMAGE they can deal...\n[H] Review past and current weapons by hit chance...\n");
                Console.WriteLine(message);
                if (a > 0) 
                { 
                    
                    Console.WriteLine("Select another item from the list above."); 
                }
                else { Console.WriteLine("\nWhich of these items will you take a closer look at?"); }
                string reply = Console.ReadLine().Trim().ToLower();

                try
                {
                    int reply1 = int.Parse(reply);
                    if (reply1 < 1 || reply1 > r)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {r}.");
                        continue;
                    }
                    else
                    {
                        if (reply1 == r)
                        {
                            Console.WriteLine("closing your backpack you turn your attention elsewhere...");
                            Console.ReadKey(true);
                            return;
                        }
                        try
                        {
                            bool success = false;
                            string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3)).Trim();
                            Console.WriteLine(objName);
                            foreach (Item i in Inventory) { if (i.Name == objName) { i.PickUpItem(this, CarryCapacity, Inventory, WeaponInventory, 5, 0, i, null, null, roomItems, null, null, null, threadPath, room); success = true; break; } }
                            foreach (Weapon w in WeaponInventory) { if (w.Name == objName) { w.PickUpItem(this, CarryCapacity, Inventory, WeaponInventory, 5, 0, null, w, null, roomItems, null, null, null, threadPath, room); success = true; break; } }
                            if (!success) { Console.WriteLine($"You threw your {objName} away!"); }

                        }
                        catch
                        {
                            bool success = false;
                            string objName = message.Substring(message.IndexOf((r - 1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r - 1).ToString()) + 3)).Trim();
                            Console.WriteLine(objName);
                            foreach (Item i in Inventory) { if (i.Name == objName) { i.PickUpItem(this, CarryCapacity, Inventory, WeaponInventory, 5, 0, i, null, null, roomItems, null, null, null, threadPath, room); success = true; break; } }
                            foreach (Weapon w in WeaponInventory) { if (w.Name == objName) { w.PickUpItem(this, CarryCapacity,    Inventory, WeaponInventory, 5, 0, null, w, null, roomItems, null, null, null, threadPath, room); success = true; break; } }
                            if (!success) { Console.WriteLine($"You threw your {objName} away!"); }
                        }
                    }
                    Console.WriteLine("Would you like to peruse another item from your pack?");

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
                catch
                {
                    if (reply == "a")
                    {
                        r = 1;
                        message = "";
                        foreach (Weapon w in WeaponInventory)
                        {
                            message += $"[{r}] {w.Name}\n";
                            r++;
                        }
                        foreach (Item item in Inventory)
                        {
                            message += $"[{r}] {item.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        continue;
                    }
                    else if (reply == "w")
                    {
                        r = 1;
                        message = "";
                        foreach (Weapon w in WeaponInventory)
                        {
                            message += $"[{r}] {w.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        if (r == 1)
                        {
                            message = "";
                            Console.WriteLine("You possess no weapons! You feel as vulnerable as a wizard without his staff, a rogue without his tools or... well, an adventurer without a sword");
                            foreach (Item item in Inventory)
                            {
                                message += $"[{r}] {item.Name}\n";
                                r++;
                            }
                            message += $"[{r}] Try something else...";
                            Console.ReadKey(true);
                            
                        }
                        continue;
                    }
                    else if (reply == "i")
                    {
                        r = 1;
                        message = "";
                        foreach (Item item in Inventory)
                        {
                            message += $"[{r}] {item.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        if (r == 1)
                        {
                            message = "";
                            Console.WriteLine("You possess no items!");
                            foreach (Weapon w in WeaponInventory)
                            {
                                message += $"[{r}] {w.Name}\n";
                                r++;
                            }
                            message += $"[{r}] Try something else...";
                            Console.ReadKey(true);
                            
                        }
                        continue;
                    }
                    else if (reply == "u")
                    {
                        List<Item> usefulList = new List<Item>();
                        
                        foreach(Item w in WeaponInventory)
                        {
                            usefulList.Add((Item)w);
                        }
                        foreach (Item i in Inventory)
                        {
                            usefulList.Add(i);
                        }
                        Dictionary<Item, int> usefulness = new Dictionary<Item, int>();
                        foreach (Item item in usefulList)
                        {
                            int count = 0;
                            try
                            {
                                foreach(Item i in usesDictionaryItemItem[item])
                                {
                                    if (room.ItemList.Contains(i))
                                    {
                                        count++;
                                    }
                                    else if (Inventory.Contains(i))
                                    {
                                        count++;
                                    }
                                    
                                }

                            }
                            catch { }
                            try
                            {
                                foreach (Feature f in usesDictionaryItemFeature[item])
                                {
                                    if (room.FeatureList.Contains(f))
                                    {
                                        count++;
                                    }

                                }
                            }
                            catch { }
                            try
                            {
                                count += usesDictionaryItemChar[item].Count;
                            }
                            catch { }
                            usefulness[item] = count;
                        }
                        IEnumerable<Item> query = from item in usefulList
                                                  orderby usefulness[item] descending
                                                  select item;
                        message = "";
                        r = 1;
                        foreach (Item item in query)
                        {
                            message += $"[{r}] {item.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        continue;
                    }
                    else if (reply == "d")
                    {
                        List<Weapon> handledWeapons = new List<Weapon>();
                        Dictionary<Weapon, double> averages = new Dictionary<Weapon, double>();
                        foreach(Item i in AllItems)
                        {
                            if(i is Weapon)
                            {
                                List<Item> items = new List<Item> {i };
                                List<Weapon> weapon = items.Cast<Weapon>().ToList();
                                if (weapon[0].Handled)
                                {
                                    handledWeapons.Add(weapon[0]);
                                }
                            }
                        }
                        foreach(Weapon w in handledWeapons)
                        {
                            List<Dice> dice = w.GetDamage();
                            double average = 0;
                            foreach(Dice d in dice)
                            {
                                average += unchecked((double)(d.faces + 1)) / 2;
                            }
                            averages[w] = average;
                        }
                        IEnumerable<Weapon> query = from Weapon weapon
                                                    in handledWeapons
                                                    orderby averages[weapon] descending
                                                    select weapon;
                        message = "";
                        r = 1;
                        foreach (Weapon weapon in query)
                        {
                            message += $"[{r}] {weapon.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        continue;
                    }
                    else if (reply == "x")
                    {
                        List<Weapon> handledWeapons = new List<Weapon>();
                        Dictionary<Weapon, int> maximum = new Dictionary<Weapon, int>();
                        foreach (Item i in AllItems)
                        {
                            if (i is Weapon)
                            {
                                List<Item> items = new List<Item> { i };
                                List<Weapon> weapon = items.Cast<Weapon>().ToList();
                                if (weapon[0].Handled)
                                {
                                    handledWeapons.Add(weapon[0]);
                                }
                            }
                        }
                        foreach (Weapon w in handledWeapons)
                        {
                            List<Dice> dice = w.GetDamage();
                            int max = 0;
                            foreach (Dice d in dice)
                            {
                                max += d.faces;
                            }
                            maximum[w] = max;
                        }
                        IEnumerable<Weapon> query = from Weapon weapon
                                                    in handledWeapons
                                                    orderby maximum[weapon] descending
                                                    select weapon;
                        message = "";
                        r = 1;
                        foreach (Weapon weapon in query)
                        {
                            message += $"[{r}] {weapon.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        continue;
                    }
                    else if(reply == "h")
                    {
                        List<Weapon> handledWeapons = new List<Weapon>();
                        Dictionary<Weapon, int> hitChance = new Dictionary<Weapon, int>();
                        foreach (Item i in AllItems)
                        {
                            if (i is Weapon)
                            {
                                List<Item> items = new List<Item> { i };
                                List<Weapon> weapon = items.Cast<Weapon>().ToList();
                                if (weapon[0].Handled)
                                {
                                    handledWeapons.Add(weapon[0]);
                                }
                            }
                        }
                        foreach (Weapon w in handledWeapons)
                        {
                            
                            
                            
                            hitChance[w] = w.Boon;
                        }
                        IEnumerable<Weapon> query = from Weapon weapon
                                                    in handledWeapons
                                                    orderby hitChance[weapon] descending
                                                    select weapon;
                        message = "";
                        r = 1;
                        foreach (Weapon weapon in query)
                        {
                            message += $"[{r}] {weapon.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number or letter corresponding to your choice of action.");
                        continue;
                    }
                }

            }
        }
        /// <summary>
        /// Dynamic polymorphism is deployed here. This function is called in the first stage of the
        /// game when the player has yet to escape the room. Since there are no 'authentic' weapons
        /// at this stage I've omitted the option to use LINQ to order weapons.
        /// </summary>
        /// <param name="roomItems"></param>
        /// <param name="room"></param>
        /// <param name="threadPath"></param>
        /// <param name="usesDictionaryItemItem"></param>
        /// <param name="usesDictionaryItemFeature"></param>
        /// <param name="usesDictionaryItemChar"></param>
        public void SearchPack(List<Item> roomItems, Room room, List<Room> threadPath, Dictionary<Item, List<Item>> usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, Dictionary<Item, List<Player>> usesDictionaryItemChar)
        {
            Console.WriteLine("Rummaging through your effects you find the following;");
            int r = 1;
            string message = "";
            foreach (Weapon w in WeaponInventory)
            {
                message += $"[{r}] {w.Name}\n";
                r++;
            }
            foreach (Item item in Inventory)
            {
                message += $"[{r}] {item.Name}\n";
                r++;
            }

            if (r == 1)
            {
                message = "You have no items or weapons in your pack. \nIt's as empty as the word of that mysterious innkeeper who betrayed you. Better get moving...";
                Console.WriteLine(message);
                Console.ReadKey(true);
                return;
            }
            else
            {
                message += $"[{r}] Try something else...";
            }


            bool continueLoop = true;
            int a = 0;

            while (continueLoop)
            {
                Console.WriteLine($"[A] Show all personal effects...\n[W] Show WEAPONS only...\n[I] Show ITEMS only...\n[U] Order by USEFULNESS within {room.Name}...\n");
                Console.WriteLine(message);
                if (a > 0)
                {

                    Console.WriteLine("Select another item from the list above.");
                }
                else { Console.WriteLine("\nWhich of these items will you take a closer look at?"); }
                string reply = Console.ReadLine().Trim().ToLower();

                try
                {
                    int reply1 = int.Parse(reply);
                    if (reply1 < 1 || reply1 > r)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {r}.");
                        continue;
                    }
                    else
                    {
                        if (reply1 == r)
                        {
                            Console.WriteLine("closing your backpack you turn your attention elsewhere...");
                            Console.ReadKey(true);
                            return;
                        }
                        try
                        {
                            bool success = false;
                            string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3)).Trim();
                            Console.WriteLine(objName);
                            foreach (Item i in Inventory) { if (i.Name == objName) { i.PickUpItem(this, CarryCapacity, Inventory, WeaponInventory, 5, 0, i, null, null, roomItems, null, null, null, threadPath, room); success = true; break; } }
                            foreach (Weapon w in WeaponInventory) { if (w.Name == objName) { w.PickUpItem(this, CarryCapacity, Inventory, WeaponInventory, 5, 0, null, w, null, roomItems, null, null, null, threadPath, room); success = true; break; } }
                            if (!success) { Console.WriteLine($"You threw your {objName} away!"); }

                        }
                        catch
                        {
                            bool success = false;
                            string objName = message.Substring(message.IndexOf((r - 1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r - 1).ToString()) + 3)).Trim();
                            Console.WriteLine(objName);
                            foreach (Item i in Inventory) { if (i.Name == objName) { i.PickUpItem(this, CarryCapacity, Inventory, WeaponInventory, 5, 0, i, null, null, roomItems, null, null, null, threadPath, room); success = true; break; } }
                            foreach (Weapon w in WeaponInventory) { if (w.Name == objName) { w.PickUpItem(this, CarryCapacity, Inventory, WeaponInventory, 5, 0, null, w, null, roomItems, null, null, null, threadPath, room); success = true; break; } }
                            if (!success) { Console.WriteLine($"You threw your {objName} away!"); }
                        }
                    }
                    Console.WriteLine("Would you like to peruse another item from your pack?");

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
                catch
                {
                    if (reply == "a")
                    {
                        r = 1;
                        message = "";
                        foreach (Weapon w in WeaponInventory)
                        {
                            message += $"[{r}] {w.Name}\n";
                            r++;
                        }
                        foreach (Item item in Inventory)
                        {
                            message += $"[{r}] {item.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        continue;
                    }
                    else if (reply == "w")
                    {
                        r = 1;
                        message = "";
                        foreach (Weapon w in WeaponInventory)
                        {
                            message += $"[{r}] {w.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        if (r == 1)
                        {
                            message = "";
                            Console.WriteLine("You possess no weapons! You feel as vulnerable as a wizard without his staff, a rogue without his tools or... well, an adventurer without a sword");
                            foreach (Item item in Inventory)
                            {
                                message += $"[{r}] {item.Name}\n";
                                r++;
                            }
                            message += $"[{r}] Try something else...";
                            Console.ReadKey(true);

                        }
                        continue;
                    }
                    else if (reply == "i")
                    {
                        r = 1;
                        message = "";
                        foreach (Item item in Inventory)
                        {
                            message += $"[{r}] {item.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        if (r == 1)
                        {
                            message = "";
                            Console.WriteLine("You possess no items!");
                            foreach (Weapon w in WeaponInventory)
                            {
                                message += $"[{r}] {w.Name}\n";
                                r++;
                            }
                            message += $"[{r}] Try something else...";
                            Console.ReadKey(true);

                        }
                        continue;
                    }
                    else if (reply == "u")
                    {
                        List<Item> usefulList = new List<Item>();

                        foreach (Item w in WeaponInventory)
                        {
                            usefulList.Add((Item)w);
                        }
                        foreach (Item i in Inventory)
                        {
                            usefulList.Add(i);
                        }
                        Dictionary<Item, int> usefulness = new Dictionary<Item, int>();
                        foreach (Item item in usefulList)
                        {
                            int count = 0;
                            try
                            {
                                foreach (Item i in usesDictionaryItemItem[item])
                                {
                                    if (room.ItemList.Contains(i))
                                    {
                                        count++;
                                    }
                                    else if (Inventory.Contains(i))
                                    {
                                        count++;
                                    }

                                }

                            }
                            catch { }
                            try
                            {
                                foreach (Feature f in usesDictionaryItemFeature[item])
                                {
                                    if (room.FeatureList.Contains(f))
                                    {
                                        count++;
                                    }

                                }
                            }
                            catch { }
                            try
                            {
                                count += usesDictionaryItemChar[item].Count;
                            }
                            catch { }
                            usefulness[item] = count;
                        }
                        IEnumerable<Item> query = from item in usefulList
                                                  orderby usefulness[item] descending
                                                  select item;
                        message = "";
                        r = 1;
                        foreach (Item item in query)
                        {
                            message += $"[{r}] {item.Name}\n";
                            r++;
                        }
                        message += $"[{r}] Try something else...";
                        continue;
                    }
                    
                    else
                    {
                        Console.WriteLine("Please enter a number or letter corresponding to your choice of action.");
                        continue;
                    }
                }

            }
        }
        /// <summary>
        /// Essentially i first ask which item the player wishes to use from their pack.
        /// I then ask what they wish to use it on.
        /// The success of this action is determined by a dictionary 
        /// (usesDictionaryItemItem or usesDictionaryItemFeature) where an item may
        /// have a list of items corresponding to it. If it does, the item
        /// can be used on the feature or effected item. otherwise the usesItem function
        /// returns a false value and a stock response is given to let the user know, 
        /// the item cannot be used that way.
        /// 
        /// the usesitem function comes from the
        /// Item class and so weapons can also be used this way,
        /// as weapons inherit from items, though I've yet to implement this by
        /// upgrading the usesDictionaries accordingly.
        /// 
        /// There are 3 usesItem functions. one for effecting items,
        /// another for effecting features and lastly for effecting 
        /// the player themselves. Nestled try and catch statements are used 
        /// to determine which of these functions must be used.
        /// </summary>
        /// <param name="room"></param>
        /// <param name="musicBox"></param>
        /// <param name="binkySkull"></param>
        /// <param name="steelKey"></param>
        /// <param name="note"></param>
        /// <param name="rosewoodChest"></param>
        /// <param name="holeInCeiling"></param>
        /// <param name="usesDictionaryItemChar"></param>
        /// <param name="usesDictionaryItemItem"></param>
        /// <param name="usesDictionaryItemFeature"></param>
        /// <param name="trialBattle"></param>
        /// <returns></returns>

        public List<bool> UseItemOutsideCombat(bool music, Room room, Item musicBox, Item binkySkull, Item steelKey, Item note, Item jailorKeys, List<Item> specialItems, Feature rosewoodChest, Feature holeInCeiling, Dictionary<Item, List<Player>> usesDictionaryItemChar, Dictionary<Item, List<Item>> usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, bool masked, Monster monster, bool fieryEscape, Combat battle = null)
        {

            List<bool> success = new List<bool> { false, false }; //{successful use of item, fire}
            ///{false, false} = item used unsuccessfully
            ///{true, false} = item used successfully
            ///{true, true} = item used successfully to cause a fire and won fight.
            ///{false, true} = caused fire but died in battle
            if (Inventory.Count > 0)
            {
                Console.WriteLine("Which item in your pack do you wish to use?");
                int g = 1;
                foreach (Item item in Inventory)
                {
                    Console.WriteLine($"[{g}] {item.Name}");
                    g++;
                }
                foreach (Item weapon in WeaponInventory)
                {
                    Console.WriteLine($"[{g}] {weapon.Name}");
                    g++;
                }
                
                Item chosenItem = null;
                while (true)
                {
                    string reply2 = Console.ReadLine().Trim().ToLower();

                    try
                    {
                        int reply0 = int.Parse(reply2) - 1;
                        try
                        {
                            chosenItem = Inventory[reply0];
                            break;
                        }
                        catch 
                        {
                             
                            
                            try
                            {
                                chosenItem = WeaponInventory[reply0 - Inventory.Count];
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a number corresponding to an item listed above!");
                                continue;
                            }
                            
                            
                        }

                    }
                    catch
                    {
                        foreach (Item item in Inventory)
                        {
                            if (item.Name == reply2)
                            {
                                chosenItem = item;

                            }

                        }
                        if (chosenItem == null)
                        {
                            foreach (Item weapon in WeaponInventory)
                            {
                                if (weapon.Name == reply2)
                                {
                                    chosenItem = weapon;
                                }
                            }
                        }
                    }
                    if (chosenItem == null)
                    {
                        Console.WriteLine($"{reply2} could not be found in your backpack. Select another item.");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("What or who would you like to use it on?");


                g = 1;
                foreach (Item item in room.ItemList)
                {
                    Console.WriteLine($"[{g}] {item.Name} in the room.");
                    g++;
                }

                foreach (Item item in Inventory)
                {
                    Console.WriteLine($"[{g}] The {item.Name} in your backpack");
                    g++;
                }
                foreach (Feature feature in room.FeatureList)
                {
                    Console.WriteLine($"[{g}] {feature.Name} in the room.");
                    g++;
                }
                Console.WriteLine($"[{g}] Yourself");


                while (true)
                {
                    string effectedItemString = Console.ReadLine().Trim().ToLower();
                    try
                    {
                        int effectedItemNum = int.Parse(effectedItemString);
                        if (effectedItemNum < 1 || effectedItemNum > g) { Console.WriteLine("Please select a number that corresponds with an item listed above."); }

                        else if (effectedItemNum == g)
                        {
                            try
                            {
                                success[0] = chosenItem.UseItem3(chosenItem, this, usesDictionaryItemChar, masked);

                                if (chosenItem.Name.Trim().ToLower().Contains("healing potion"))
                                {
                                    Console.WriteLine("Liquid rejuvenation trickles down your parched throat. A warm feeling swells from your heart as you feel your wounds salved and your flesh knitting itself back together.");
                                }
                                else if (chosenItem.Name.Trim().ToLower() == "elixir of feline guile")
                                {
                                    Console.WriteLine("You glug the potent elixir down. Your stomach ties itself in knots for a moment, before you feel your instincts and reflexes sharpen.");
                                }
                                else if (chosenItem.Name.Trim().ToLower() == "potion of alacrity")
                                {
                                    Console.WriteLine("The potion tastes as bad as it looks. However, you instantly discover the rest of the world looks as though it couldn't catch up with a snail.\n You fly into action...");
                                }
                                else if (chosenItem.Name.Trim().ToLower() == "felix felicis") // luck potion grants boon to all weapons.
                                {
                                    Console.WriteLine("The sweet liquid tastes like nirvana. It's effervescent body dances on your tongue and delights the senses. Suddenly you feel like anything is possible...");
                                }
                                else if (chosenItem.Name == "soot")
                                {

                                }
                                else
                                {
                                    Console.WriteLine($"You try using the {chosenItem.Name} on yourself. Whatever results you were hoping for, sufficed to say they haven't materialised...");
                                }
                                return success;
                            }
                            catch { Console.WriteLine("Ermm...No. Upon reflection, you'd rather not use that on yourself."); return success; }

                        }
                        else if (effectedItemNum < g && effectedItemNum > room.ItemList.Count + Inventory.Count)
                        {
                            try
                            {
                                if (chosenItem.Name == "rusty chain-flail")
                                {
                                    success[0] = chosenItem.UseItem1(music, usesDictionaryItemChar, chosenItem, room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count], usesDictionaryItemFeature, Inventory, WeaponInventory, room, this, monster, battle, fieryEscape, null, steelKey, musicBox, note, jailorKeys);
                                    List<Weapon> _weapons = new List<Weapon>();
                                    List<Item> _weaponItem = new List<Item> { chosenItem};
                                    _weapons = _weaponItem.Cast<Weapon>().ToList();
                                    if (Inventory.Contains(jailorKeys))
                                    {
                                        return success;
                                    }
                                    else if (_weapons[0].Equipped)
                                    {
                                        return success;
                                    }
                                }
                                else if (chosenItem.Name == "healing potion"|| chosenItem.Name=="Felix Felicis"|| chosenItem.Name=="elixir of feline guile")
                                {
                                    success[0] = chosenItem.UseItem1(music, usesDictionaryItemChar, chosenItem, room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count], usesDictionaryItemFeature, Inventory, WeaponInventory, room, this, monster, battle, fieryEscape, null, binkySkull, musicBox, note, jailorKeys);
                                }
                                else
                                {
                                    success[0] = chosenItem.UseItem1(music, usesDictionaryItemChar, chosenItem, room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count], usesDictionaryItemFeature, Inventory, WeaponInventory, room, this, monster, battle, fieryEscape, null, binkySkull, musicBox, note, jailorKeys);
                                }
                                if (!success[0])
                                {
                                    if (chosenItem.Name == "steel key" && room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "rosewood door")
                                    {
                                        Console.WriteLine("This key clearly doesn't open *this* door...");
                                        if (Traits.ContainsKey("jinxed"))
                                        {
                                            Inventory.Remove(chosenItem);
                                            Console.ReadKey(true);
                                            Console.WriteLine("As you oafishly attempt to jostle the key free from the lock, you hear something snap!\nThe steel key has broken inside the lock. It's pieces tinkle as they fall to the bottom of the tumblers...\nOops.");
                                        }
                                    }
                                    else if ((chosenItem.Name == "garment" || chosenItem.Name == "note") && (room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "left brazier" || room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "right brazier"))
                                    {
                                        Console.WriteLine($"You rack your brains trying to come up with an escape from your prison. With a tincture of desperation you conclude the only way is to start a fire. Maybe, just maybe, you can ambush the guard when they try to put it out...\nIf they come to put it out.\nWith not a small number of misgivings winching around your tight chest, you feverishly begin trying to light the {chosenItem.Name} on fire with the brazier. However, the low flickering flame seems to burn with an unnatural frostiness. This is no ordinary flame but something magical, casting only chilly light into the room and sharing none of the heat you'd otherwise expect. The {chosenItem.Name} refuses to burn.\nIf you truly believe arson is your only means to escape, then you'll have to deploy some greater ingenuity, and do so before your time runs out...");
                                    }
                                    else if (chosenItem.Name == "magnifying glass") { }
                                    else if (chosenItem.Name == "rusty chain-flail" && room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "rosewood door" && !room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Description.Contains("dent")) { room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Description = room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Description + " You can see the dent left the last time you hammered against this door."; }
                                    else
                                    {
                                        Console.WriteLine($"You try using the {chosenItem.Name} on the {room.ItemList[effectedItemNum - 1].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised...");
                                    }
                                }
                                return success;
                            }
                            catch
                            {
                                
                                if (chosenItem.Name == "steel key" && room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "rosewood door")
                                {
                                    Console.WriteLine("This key clearly doesn't open this door.");
                                }
                                else if ((chosenItem.Name == "garment" || chosenItem.Name == "note") && (room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "left brazier" || room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "right brazier"))
                                {
                                    Console.WriteLine($"You rack your brains trying to come up with an escape from your prison. With a tincture of desperation you conclude the only way is to start a fire. Maybe, just maybe, you can ambush the guard when they try to put it out...\nIf they come to put it out.\nWith not a small number of misgivings winching around your tight chest, you feverishly begin trying to light the {chosenItem.Name} on fire with the brazier. However, the low flickering flame seems to burn with an unnatural frostiness. This is no ordinary flame but something magical, casting only chilly light into the room and sharing none of the heat you'd otherwise expect. The {chosenItem.Name} refuses to burn.\nIf you truly believe arson is your only means to escape, then you'll have to deploy some greater ingenuity, and do so before your time runs out...");
                                }
                                else if (chosenItem.Name == "magnifying glass") { }
                                else if ((chosenItem.Name == "healing potion" || chosenItem.Name == "Elixir of Feline Guile" || chosenItem.Name == "Felix Felicis") && binkySkull != null && room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "skeleton" && !room.ItemList.Contains(binkySkull) && !Inventory.Contains(binkySkull) && Traits.ContainsKey("friends with fairies"))
                                {
                                    Console.WriteLine($"The {chosenItem.Name} works its magic as you gloop the elixir over the skull. You blink and before you know it the skeleton let's loose a string of delightful curses worthy of the most mischievous of pixies.\n" +
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

                                    Inventory.Add(binkySkull);


                                    

                                }
                                else if (chosenItem.Name == "rusty chain-flail" && room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name == "rosewood door" && !room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Description.Contains("dent")) { room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Description = room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Description + " You can see the dent left the last time you hammered against this door."; }
                                else
                                {
                                    Console.WriteLine($"You try using the {chosenItem.Name} on the {room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Inventory.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised...");
                                }
                                return success;
                            }
                        }
                        else if (effectedItemNum > room.ItemList.Count)
                        {
                            if (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == chosenItem.Name)
                            {
                                Console.WriteLine($"You attempt using the {chosenItem.Name} on itself but try as hard as you might, it just doesn't seem possible. Maybe you should try this item on something else?");
                                continue;
                            }
                            try
                            {
                                success = chosenItem.UseItem(music, chosenItem, Inventory[effectedItemNum - 1 - room.ItemList.Count], usesDictionaryItemItem, specialItems, rosewoodChest, musicBox, room, this, holeInCeiling, usesDictionaryItemFeature, usesDictionaryItemChar, this, battle);
                                if (!success[0] && success[1])
                                {
                                    return success;
                                }
                                else if (!success[0])
                                {
                                    if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "dagger") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "dagger" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "estoc") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "estoc" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("While the blade is thin for a sword, you *may* find it to be a bit too unwieldy to use with the bobby pin for picking locks...");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "rusty scimitar") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "rusty scimitar" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("This blade is altogether too wide, curved and large to pick locks with the bobby pin - you won't be able to get through many doors with this...");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "Bread Knife") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "Bread Knife" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "sai-daggers") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "sai-daggers" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("These would be perfect for picking locks with the bobby pin - if it weren't for how they're so bent out of shape and dented.");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "throwing knife") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "throwing knife" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"You try using the {chosenItem.Name} on the {Inventory[effectedItemNum - 1 - room.ItemList.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised...");

                                    }
                                }
                                

                                
                                return success;
                            }
                            catch 
                            {
                                if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "dagger") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "dagger" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                {
                                    Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this...");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "estoc") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "estoc" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                {
                                    Console.WriteLine("While the blade is thin for a sword, you *may* find it to be a bit too unwieldy to use with the bobby pin for picking locks...");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "rusty scimitar") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "rusty scimitar" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                {
                                    Console.WriteLine("This blade is altogether too wide, curved and large to pick locks with the bobby pin - you won't be able to get through many doors with this...");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "Bread Knife") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "Bread Knife" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                {
                                    Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "sai-daggers") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "sai-daggers" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                {
                                    Console.WriteLine("These would be perfect for picking locks with the bobby pin - if it weren't for how they're so bent out of shape and dented.");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "throwing knife") && (Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "throwing knife" || Inventory[effectedItemNum - 1 - room.ItemList.Count].Name == "bobby pin"))
                                {
                                    Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                }
                                else
                                {
                                    Console.WriteLine($"You try using the {chosenItem.Name} on the {Inventory[effectedItemNum - 1 - room.ItemList.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised...");

                                }
                                return success; 
                            }
                        }
                        else
                        {
                            try
                            {
                                success = chosenItem.UseItem(music, chosenItem, room.ItemList[effectedItemNum - 1], usesDictionaryItemItem, specialItems, rosewoodChest, musicBox, room, this, holeInCeiling, usesDictionaryItemFeature, usesDictionaryItemChar, this, battle);
                                if (!success[0] && success[1])
                                {
                                    return success;
                                }
                                else if (!success[0])
                                {

                                    if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "dagger") && (room.ItemList[effectedItemNum - 1].Name == "dagger" || room.ItemList[effectedItemNum - 1].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this...");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "estoc") && (Inventory[effectedItemNum - 1].Name == "estoc" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("While the blade is thin for a sword, you *may* find it to be a bit too unwieldy to use with the bobby pin for picking locks...");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "rusty scimitar") && (Inventory[effectedItemNum - 1].Name == "rusty scimitar" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("This blade is altogether too wide, curved and large to pick locks with the bobby pin - you won't be able to get through many doors with this...");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "Bread Knife") && (Inventory[effectedItemNum - 1].Name == "Bread Knife" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "sai-daggers") && (Inventory[effectedItemNum - 1].Name == "sai-daggers" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("These would be perfect for picking locks with the bobby pin - if it weren't for how they're so bent out of shape and dented.");
                                    }
                                    else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "throwing knife") && (Inventory[effectedItemNum - 1].Name == "throwing knife" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                    {
                                        Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"You try using the {chosenItem.Name} on the {room.ItemList[effectedItemNum - 1].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised...");

                                    }

                                }
                                return success;
                            }
                            catch 
                            {

                                if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "dagger") && (room.ItemList[effectedItemNum - 1].Name == "dagger" || room.ItemList[effectedItemNum - 1].Name == "bobby pin"))
                                {
                                    Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this...");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "estoc") && (Inventory[effectedItemNum - 1].Name == "estoc" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                {
                                    Console.WriteLine("While the blade is thin for a sword, you *may* find it to be a bit too unwieldy to use with the bobby pin for picking locks...");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "rusty scimitar") && (Inventory[effectedItemNum - 1].Name == "rusty scimitar" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                {
                                    Console.WriteLine("This blade is altogether too wide, curved and large to pick locks with the bobby pin - you won't be able to get through many doors with this...");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "Bread Knife") && (Inventory[effectedItemNum - 1].Name == "Bread Knife" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                {
                                    Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "sai-daggers") && (Inventory[effectedItemNum - 1].Name == "sai-daggers" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                {
                                    Console.WriteLine("These would be perfect for picking locks with the bobby pin - if it weren't for how they're so bent out of shape and dented.");
                                }
                                else if ((chosenItem.Name == "bobby pin" || chosenItem.Name == "throwing knife") && (Inventory[effectedItemNum - 1].Name == "throwing knife" || Inventory[effectedItemNum - 1].Name == "bobby pin"))
                                {
                                    Console.WriteLine("This blade is altogether too wide to pick locks with the bobby pin - you won't be able to get through many doors with this.\nNow if only their was something the same length but thinner...");
                                }
                                else
                                {
                                    Console.WriteLine($"You try using the {chosenItem.Name} on the {room.ItemList[effectedItemNum - 1].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised...");

                                }

                                return success; 
                            }
                        }
                    }
                    catch { Console.WriteLine("Please enter the number corresponding to the list above!"); }
                }
            }
            else { Console.WriteLine("You've no items in your backpack!"); return success; }
        }
    }
    public class Monster : Character, INotSoCute, IInteract
    {
        /// <summary>
        /// Monsters have unique weapons, descriptions and a list of items in addition to
        /// stamina, skill and so on. They are only really for combat (maybe dialogue)
        /// and can only be searched once defeated.
        /// 
        /// Monsters exhibit multiple inheritance; from both abstract Character class
        /// and from the Interface INotSoCute. Inheriting from this interface permits 
        /// monsters that may not be armed to nevertheless have an option to attack 
        /// should the need arise.I was generally thinking of seemingly innocuous encounters with
        /// creatures that at first seem cuddly but then give the player a surprise!
        /// However, I've yet to instantiate such a monster in the game...
        /// 
        /// Static Polymorphism is used here, with two different constructors.
        /// One of them hasn't altered from assessment 1. The other is for
        /// the minotaur and gives it extra properties for the purpose of 
        /// facilitating its ability to stalk the player, patrol from room
        /// to room, and react to objects within that room on a timed basis.
        /// 
        /// It also has bool attributes (Suspicious and Rage) that determine the
        /// likelihood of it continuing to search for you and hunt you from one
        /// room to the next. 
        /// </summary>
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Weapon Veapon { get; set; }
        public Room Location { get; set; }
        public List<Room> Path { get; set; }
        public bool Rage { get; set; }
        public bool Suspicious { get; set; }
        public Stopwatch Patrol { get; set; }
        public long Time { get; set; }
        public Monster(string name, string description, List<Item> items, int stamina, int skill, Weapon weapon, bool rage = false)
        {
            Name = name;
            Description = description;
            Items = items;
            Stamina = stamina;
            Skill = skill;
            Veapon = weapon;
        }
        public Monster(string name, string description, List<Item> items, int stamina, int skill, Weapon weapon, Room location, List<Room> path, bool rage = false, bool suspicious = false, Stopwatch patrol = null)
        {
            Name = name;
            Description = description;
            Items = items;
            Stamina = stamina;
            Skill = skill;
            Veapon = weapon;
            Location = location;
            Path = path;
            Rage = rage;
            Suspicious = suspicious;
            Patrol = patrol;
            Time = (Path.Count - 1) * 20000;
        }
        public void StashItem(Item item, Room room)
        {
            Items.Add(item);
            room.ItemList.Remove(item);
            return;
        }

        int Attack(int Skill, Player player, List<Item> specialItems, Room room, Feature holeInCeiling)
        {
            List<Item> items = new List<Item> { specialItems[8] };
            List<Weapon> fisticuffs = items.Cast<Weapon>().ToList();
            List<string> emptyCrits = new List<string> 
            {
                "",
                "",
                "",
                "",

                "",
                "",
                "",
                "",

                "",
                "",
                "",
                "",

                "",
                "",
                "",
                ""
            };
            Dice D2 = new Dice(2);
            Dice D3 = new Dice(3);
            Dice D5 = new Dice(5);
            Weapon fists = fisticuffs[0];
            if (Skill < 4)
            {
                fists = new Weapon(fists.Name, fists.Description, new List<Dice> { D2, D2 }, emptyCrits, emptyCrits, fists.Boon);
            }
            else if (Skill < 7)
            {
                fists = new Weapon(fists.Name, fists.Description, new List<Dice> { D2, D2, D3 }, emptyCrits, emptyCrits, fists.Boon);
            }
            else
            {
                fists = new Weapon(fists.Name, fists.Description, new List<Dice> { D2, D2, D3, D5 }, emptyCrits, emptyCrits, fists.Boon + 1);
            }
            
            return fists.Attack(Skill, player.Skill, player.Stamina, false, this, player, "", room, holeInCeiling);
        }
        /// <summary>
        /// I meantioned before the Equip function from character would be overrided. This is 
        /// that function.
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="inventory"></param>
        /// <param name="player"></param>
        public override void Equip(Weapon weapon, List<Weapon> inventory, Player player)
        {
            for (int i = Items.Count-1; i >= 0; i--)
            { 
                if(Items[i] is Weapon && Items[i].Name != Veapon.Name)
                {
                    List<Item> weapons = new List<Item> { Items[i] };
                    List<Weapon> armedWeapon = weapons.Cast<Weapon>().ToList();
                    Items.RemoveAt(0);
                    Items.Add(Veapon);
                    Veapon = armedWeapon[0];
                    Items.Remove(Veapon);
                    Items.Insert(0, Veapon);
                    return;
                }
            }

        }
        public override void Unequip(List<Weapon> weaponInventory, List<Item> specialItems)
        {
            List<Item> items = new List<Item> { specialItems[8] };
            List<Weapon> fisticuffs = items.Cast<Weapon>().ToList();
            List<string> emptyCrits = new List<string>
            {
                "",
                "",
                "",
                "",

                "",
                "",
                "",
                "",

                "",
                "",
                "",
                "",

                "",
                "",
                "",
                ""
            };
            Dice D2 = new Dice(2);
            Dice D3 = new Dice(3);
            Dice D5 = new Dice(5);
            Weapon fists = fisticuffs[0];
            if (Skill < 4)
            {
                fists = new Weapon(fists.Name, fists.Description, new List<Dice> { D2, D2 }, emptyCrits, emptyCrits, fists.Boon);
            }
            else if (Skill < 7)
            {
                fists = new Weapon(fists.Name, fists.Description, new List<Dice> { D2, D2, D3 }, emptyCrits, emptyCrits, fists.Boon);
            }
            else
            {
                fists = new Weapon(fists.Name, fists.Description, new List<Dice> { D2, D2, D3, D5 }, emptyCrits, emptyCrits, fists.Boon + 1);
            }
            Veapon = fists;
            return;
        }
        /// <summary>
        /// The following function returns the Minotaur, room by room, to
        /// its starting position, whilst making it reactive to certain objects as well.
        /// Path is utilised as a list of rooms that led the minotaur back to its
        /// starting position all the while giving feedback to the player as to its progress
        /// </summary>
        /// <param name="room"></param>
        /// <param name="redThread"></param>
        /// <param name="musicBox"></param>
        /// <param name="threadPath"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool MinotaurReturning(Room room, Item redThread, Item musicBox, List<Room> threadPath, Player player)
        {
            this.Patrol.Stop();
            Dice D6 = new Dice(6);
            long time = this.Time - this.Patrol.ElapsedMilliseconds;
            if (player.Speedy)
            {
                time = this.Time - this.Patrol.ElapsedMilliseconds / 2;
            }
            List<string> enragedHunt = new List<string>
                {
                    "",
                    "",
                    "",
                    "",
                    "",
                    ""
                };
            try
            {
                
                enragedHunt = new List<string>
                {
                $"You overhear the monster crashing through the {Path[1].Name} in search of you...",
                $"The sound of the monster tearing the {Path[1].Name} apart as it hunts you fills you with icy foreboding. \nBetter move quickly...",
                $"The monster storms the {Path[1].Name}. You can hear the carnage wrought from the {room.Name}...",
                $"You hear the beast barrel into the {Path[1].Name}, ripping the place apart as it attempts to scare up your hiding spot...",
                $"The din of the beasts furious roars and frenzied hunting continues into the {Path[1].Name}...",
                $"You overhear the beast charge into the {Path[1].Name} as it looks for you..."
                };
            }
            catch
            {
                
            }
            List<Room> adjacentrooms = new List<Room>();
            List<Door> doors = new List<Door>();
            foreach(Feature f in Location.FeatureList)
            {
                if(f is Door)
                {
                    doors.Add(f.CastDoor());
                }
            }
            foreach(Door d in doors)
            {
                foreach(Room r in d.Portal)
                {
                    if (r != Location)
                    {
                        adjacentrooms.Add(r);
                    }
                }
            }
            foreach (Room r in adjacentrooms)
            {
                if (r.ItemList.Contains(musicBox) && musicBox.Attribute)
                {
                    this.Path.Insert(1, Location);
                    this.Path.Insert(1, r);
                }
            }
            if (Path.Count > 1)
            {
                if (this.Path[1].ItemList.Contains(musicBox) && musicBox.Attribute)
                {
                    Console.WriteLine($"You hear the monster abruptly pause as it listens to the music box's melody. \n You listen with bated breath as it's heavy footfalls enter the {Path[1].Name} to investigate...");
                    Console.ReadKey(true);
                    if (Path[1] == room)
                    {
                        Location = Path[1];
                        Path.RemoveAt(0);
                        return true;
                    }
                    Console.WriteLine("The music box continues playing. It seems the monster is momentarily captivated by it! But how long for you don't know...");
                    Console.ReadKey(true);
                    this.Location = this.Path[1];
                    this.Time += 1200000;
                    this.Items.Add(musicBox);

                    this.Path.RemoveAt(0);
                    return true;
                }
                else if (this.Location.ItemList.Contains(musicBox) && musicBox.Attribute && time > (this.Path.Count - 2) * 20000)
                {
                    Console.ReadKey(true);
                    Console.WriteLine($"You hear the music continue playing in the {Location.Name}, concealing the sound of your footsteps. So long as you keep away from that place you should go undetected...");
                    return true;
                }
                
            }
            
            if (time < (this.Path.Count - 2) * 20000 && this.Path.Count > 1)
            {
                if (Location.ItemList.Contains(musicBox))
                {
                    Console.WriteLine("The music box snaps shut!");
                    Console.ReadKey(true);
                    Console.WriteLine("It seems the monster's suspicions are roused once more, as it keeps an eye out for you...");
                    Suspicious = true;
                    Rage = false;
                    Location.ItemList.Remove(musicBox);
                }
                this.Location = this.Path[1];
                if (this.Rage)
                {
                    Console.ReadKey(true);
                    if (Location.Name == "dungeon chamber")
                    {
                        Console.WriteLine("The monster storms the dark stairwell, hunting you down. You overhear it slip and crash all the way down the steps. Ouch!");
                        Console.ReadKey(true);
                        Console.WriteLine("From the sound of the monster's lumbering footsteps and pained grunts, it seems severely injured...");
                        Stamina -= 80;
                        int g = Path.Count - 1;
                        while (g > 0)
                        {
                            if (Path[g].Name == "dungeon chamber")
                            {
                                Path.RemoveAt(g);
                            }
                            g--;
                        }
                    }
                    else
                    {
                        Console.WriteLine(enragedHunt[D6.Roll(D6) - 1]);
                    }
                    Console.ReadKey(true);
                }
                else if (((room.Name.Contains("corridor") && room.Name != "long corridor") || room.Name == "mess hall" || room.Name == "broom closet" || room.Name == "antechamber" || room.Name == "armoury") && ((Location.Name.Contains("corridor") && Location.Name != "long corridor") || Location.Name == "mess hall" || Location.Name == "broom closet" || Location.Name == "antechamber" || Location.Name == "armoury"))
                {
                    Console.ReadKey(true);
                    Console.WriteLine($"You hear the monster's lumbering footfalls as it moves into the {this.Location.Name}...");
                    Console.ReadKey(true);
                }
                else if ((room.Name == "long corridor" || room.Name == "dank cell" || room.Name == "eerie cell" || room.Name == "empty cell" || room.Name == "antechamber" || room.Name == "dungeon chamber") && (Location.Name == "long corridor" || Location.Name == "dank cell" || Location.Name == "eerie cell" || Location.Name == "empty cell" || Location.Name == "antechamber" || Location.Name == "dungeon chamber"))
                {
                    Console.ReadKey(true);
                    Console.WriteLine($"You hear the monster's lumbering footfalls as it moves into the {this.Location.Name}...");
                    Console.ReadKey(true);
                }
                this.Path.RemoveAt(0);

            }
            if ((this.Location.Name == "north-facing corridor" || this.Location.Name == "ocean bottom" || this.Location.Name == "astral planes") && this.Path.Count == 1)
            {
                this.Patrol.Stop();
                this.Patrol = new Stopwatch();
                this.Time = 0;
                if (this.Items.Contains(redThread))
                {
                    threadPath.Clear();
                }
                return false;
            }
            else
            {
                this.Patrol.Start();
            }
            return true;

        }
        public string getDescription() { return Description; }
        public string getName() { return Name; }
        /// <summary>
        /// similar to searchPack or searchFeature, once again this evokes a particular strand
        /// of pickUpItem() demarked by its own range value. something that is different here is
        /// you have to type out the name of the object you wish to pick up.
        /// 
        /// It is also used for searching your backpack when you meet Merigold and choosing
        /// to supply him with special items.
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="weaponInventory"></param>
        public void search(int carryCapacity, List<Item> inventory, List<Weapon> weaponInventory, Player player)
        {
            bool continueSearch = true;
            string message = "You find";
            int number = 1;
            List<Item> plunder = Items;
            foreach (Item x in plunder)
            {
                message += $"\n[{number}] {x.Name}";
                number++;
            }
            if (Name == "backpack")
            {
                message += $"\nwithin your pack.";
            }
            else
            {
                message += $"\nupon the {Name}.";
            }
            if (Items.Count() == 0)
            {
                message = "You find nothing of note";
                continueSearch = false;
            }
            Console.WriteLine(message);
            int i = 0;
            int turn = 0;
            string strand = "";
            if (Name == "backpack")
            {
                strand += " to give to Merigold";
            }
            if (continueSearch && plunder.Count() > 1)
            {
                
                Console.WriteLine($"Would you like to select one of these artefacts{strand}?");
            }
            else if (continueSearch)
            {
                Console.WriteLine($"Would you like to select this item{strand}?");
            }
            bool alreadyStashed = false;
            bool skip = false;
            while (continueSearch)
            {
                if (turn > 0)
                {
                    plunder = Items;
                    message = "You find";
                    number = 1;
                    foreach (Item x in plunder)
                    {
                        message += $"\n[{number}] {x.Name}";
                        number++;
                    }

                    if (Name == "backpack")
                    {
                        message += $"\nwithin your pack.";
                    }
                    else
                    {
                        message += $"\nupon the {Name}.";
                    }
                    Console.WriteLine(message, "\nWould you like to pick up another one of the above items?");
                }
                turn++;
                string answer = Console.ReadLine().Trim().ToLower();
                while (answer.ToLower() == "yes" || answer.ToLower() == "y" || answer.ToLower() == "n" || answer.ToLower() == "no")
                {
                    if (answer.ToLower() == "yes" || answer.ToLower() == "y")
                    {
                        Console.WriteLine("Please type the name of the item you wish to pick up or its corresponding number.");
                        answer = Console.ReadLine().Trim().ToLower();
                        try
                        {
                            int answer1 = int.Parse(answer);
                            if (answer1 < 1 || answer1 > plunder.Count)
                            {
                                continue;
                            }
                            else
                            {
                                answer = plunder[answer1 - 1].Name.Trim().ToLower();
                            }
                        }
                        catch {  }
                        break;
                    }
                    else
                    {
                        continueSearch = false;
                        break;
                    }
                }
                try
                {
                    int answer1 = int.Parse(answer);
                    if (answer1 < 1 || answer1 > plunder.Count)
                    {
                        Console.WriteLine("Please enter a number corresponding to the list of items.");
                        continue;
                    }
                    else
                    {
                        answer = plunder[answer1 - 1].Name.Trim().ToLower();
                    }
                }
                catch { }
                if (!continueSearch)
                {
                    Console.WriteLine($"You finish rummaging through the {Name}'s effects.");
                    return;
                }
                alreadyStashed = false;
                foreach (Item z in inventory)
                {
                    if (z.Name.ToLower() == answer && Name != "backpack")
                    {
                        alreadyStashed = true;
                    }
                }
                foreach (Weapon z in weaponInventory)
                {
                    if (z.Name.ToLower() == answer && Name != "backpack")
                    {
                        alreadyStashed = true;
                    }
                }
                if (Items.Count == 0)
                {
                    message = "You find nothing more of note";
                    continueSearch = false;
                }
                skip = false;
                List<Item> weaponSplice = new List<Item>();
                for (i = Items.Count - 1; i >= 0; i--)
                {
                    if (Items[i] is Weapon)
                    { weaponSplice.Add(plunder[i]); }
                }
                ///I have to create a separate list for weapons out of Monster.Items and then
                ///cast them as weapons afterwards
                List<Weapon> weapon1 = weaponSplice.Cast<Weapon>().ToList();
                List<string> checkWeapon = new List<string>();
                foreach (Item weapon in plunder) { checkWeapon.Add(weapon.Name.Trim().ToLower()); }
                for (i = weapon1.Count - 1; i >= 0; i--)
                {
                    Weapon x = weapon1[i]; // change monster class to having two lists, or start with reviewing all weapons throughout and construct new item from weapon details
                    if (alreadyStashed)
                    {
                        Console.WriteLine("You've already taken that item!");
                        break;
                    }
                    else if (x.Name.Trim().ToLower() == answer)
                    {
                        if (Name == "backpack")
                        {
                            inventory.Remove(x);
                            weaponInventory.Remove(x);
                            Items.Remove(x);
                            answer = "";
                            skip = true;
                        }
                        else
                        {
                            x.PickUpItem(player, carryCapacity, inventory, weaponInventory, 3, 0, null, x, null, null, null, null, this);
                            answer = "";
                            skip = true;
                        }

                        

                        break;
                    }



                }
                for (i = Items.Count - 1; i >= 0; i--)
                {
                    if (skip) { break; }
                    Item x = Items[i];
                    if (alreadyStashed)
                    {
                        Console.WriteLine("You've already taken that item!");
                        break;
                    }

                    else if (x.Name.Trim().ToLower() == answer)
                    {
                        if (Name == "backpack")
                        {
                            inventory.Remove(x);
                            
                            Items.Remove(x);
                            answer = "";
                            skip = true;
                        }
                        else
                        {
                            x.PickUpItem(player, carryCapacity, inventory, weaponInventory, 3, 0, x, null, null, null, null, null, this);
                        }
                        break;
                    }


                }
                if (Items.Count == 0)
                {
                    Console.WriteLine($"You finish searching the {Name} for items.");
                    return;
                }
                else if (!checkWeapon.Contains(answer))
                {
                    Console.WriteLine($"Please type in an item or weapon name listed above or it's corresponding number or else answer 'no' to finish your search of the {Name}.");

                }
            }
        }
    }


}

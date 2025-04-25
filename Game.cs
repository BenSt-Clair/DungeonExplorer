using DungeonCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DungeonCrawler
{
    internal class Game
    {
        string GameName { get; set; }
        bool Music { get; set; }

        public Game(string gameName, bool music)
        {
            GameName = gameName;
            Music = music;
        }
        public bool MusicOnOff()
        {
            Console.WriteLine("Would you like music during some dramatic scenes or battles?");
            Feature f = new Feature();
            Dialogue music = new Dialogue(f);
            if(music.getYesNoResponse())
            {
                return true;
            }
            return false;
        }
        private void Prologue(Room room)
        {
            Console.Write("Would you like to skip the prologue? ");
            while (true)
            {
                string response1 = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(response1))
                {
                    Console.Write("\nWould you like to skip the prologue? ");
                    continue;
                }
                else if (response1 == "yes" || response1 == "y")
                {
                    break;
                }
                else if (response1 == "no" || response1 == "n")
                {

                    
                    Console.WriteLine($"  You can't be certain what terrible events led you here" +
                        $". However as you look around the {room.Name.ToLower()} you can make a shrewd guess" +
                        $" as to why you've been held captive... and who's behind it. After all, you're not the first to be captured around these parts. \nYou're just the first to survive it.");
                    Console.ReadKey(true);
                    Console.WriteLine($"  {room.Description.Substring(0, room.Description.IndexOf("\n"))} It reminds you of no room you've seen before in your other, perhaps less-ambitious adventures." +
                        $"If you'd had a better grasp of the danger ahead of you, then perhaps that nebulous anxiety that'd conspired to turn your stomach into a roiling knot of snakes might've warded you away three nights ago. But you weren't to know then what you know now.");
                    Console.ReadKey(true);
                    Console.WriteLine("  A near-palpable sense of dread had hung over" +
                        " that village like a full moon when you'd arrived upon its " +
                        "outskirts. The steepled roofs of Myrovia rose like fingers" +
                        " towards the void of a starless sky, almost as though the" +
                        " settlement, nestled between craggy mountain peaks and" +
                        " whispering pines, itself was reaching for something elusive. " +
                        "Shutters creaked in the eerie silence as your feet clapped upon the road." +
                        " \n  You'd found yourself wondering if this really was the place that had" +
                        " sent out that call for adventurers like yourself, swords-for-hire with " +
                        "a taste for danger. There was no one to greet you. \n" +
                        "  Leaves rustled and stirred in a chill breeze, whisked up along the deserted alleyways and streets" +
                        " of what the poster had claimed to be a mountain haven and sanctuary from the other terrors gripping" +
                        " the land. \nInstantly, you could tell something was wrong.");
                    Console.ReadKey(true);
                    Console.WriteLine("\t'Hurry! Get inside!' One of the locals beseeched you from through a door half ajar. " +
                        "Their voice, an urgent whisper, nevertheless carried down the street like the grinding of deadly claws on stone. " +
                        "He hurriedly ushered you inside paying no mind to your questioning look. " +
                        "\n\t'It starts when the moon waxes its fullest,' he breathes by way of explanation, as his tremulous fingers frenziedly " +
                        "slammed the door's deadbolts back in place. 'You've arrived at the worst possible time.'" +
                        "");
                    Console.ReadKey(true);
                    Console.WriteLine("You look around the room, suddenly surprised to find other eyes watching you, gleaming in the murk. ");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "\t'This place used to be my tavern' your dubious (saviour?) informs you following your gaze as it takes in the dilapidated forest of chairs and tables, dusty disused counter and glinting bottles lining the back, long since emptied of their liquor. \n" +
                        "\t'I can still offer you board and lodgings... for a price'");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "You're about to ask him why you'd accept the steep price he ends up requesting, when a shaft of moonlight drifts through the slats of a boarded up window. Moments later blood-curdling howls shatter the eerie silence.");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "\t'Or you can always take your chances out there...' he levels you an expression at once both secretly fearful and yet implacable.");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "  You ask this innkeep just what on earth is happening out there. He responds only with a shake of his head and a finger pressed to his lips.");
                    Console.WriteLine("  You hear strange creatures prowling the streets, scuffling just outside of the door, their shadows slipping under the doorframe as they linger outside. One moment they claw for entry, panting heavily like no fell wight you've ever heard before; big - no, huge. The size of any man, at least. Then the mystery creatures slip away to the next house, ravenous." +
                        "\t'They're hunting,' the innkeep, your 'saviour', mutters to himself, 'they won't leave 'til someone saves us from them. Someone who knows how...' " +
                        "You tell him you came in answer to the poster and are ready for the challenge.");
                    Console.ReadKey(true);
                    Console.WriteLine("He slowly turns to you, eyeing you appraisingly.");
                    Console.ReadKey(true);
                    Console.WriteLine("\t'You'll need rest. We'll talk all about it in the morning. Go upstairs. Take the room left on the landing. And don't make a sound.'");
                    Console.ReadKey(true);
                    Console.WriteLine("  You do as he requests. you find the room in question and are surprised when you find the lodgings to be far cosier than what the tavern below had lead you to expect. The bed is soft, with ample duvets and pillows, and the decor invites comfort with every passing glance. You wonder for a few moments how you might ever sleep with what's going on outside. There are no windows in the room, but you can still hear the howls. Thing is, they don't sound like any wolves you've heard before...");
                    Console.WriteLine("  Then the innkeep brings you a drink to ease your mind. After that sleep comes easily.");
                    Console.ReadKey(true);
                    Console.WriteLine("  Too easily.");
                    Console.ReadKey(true);
                    Console.WriteLine("  The room had spun around you as your body staggered, collapsing to the bed in a heap. You'd just caught the innkeep's last words before darkness had lunged upon you like a predator that'd been lurking in the shadows. ");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "\t'I'm sorry friend. But there's only one who can lift this curse, and he ain't paid in gold...'");
                    Console.ReadKey(true);
                    Console.WriteLine("  Next thing you know, you're waking up in this dank cell, with only the realisation that the poster that'd sent you here had been a trap. No doubt countless adventurers before you had fallen for it too. And there's one other accompanying clue - One macabre sliver of insight that alights your mind as your thoughts race; You, and all those other adventurers...");
                    Console.ReadKey(true);
                    Console.WriteLine("  Whoever this curse-breaker is, YOU'RE the price he's demanded.");
                    Console.ReadKey(true);
                    Console.WriteLine("  Now, however, it's time to decide if you accept this fate cruelly dealt to you. \nAre" +
                        " you a fighter? A warrior? Perhaps a hero? Or could you aspire to be something else entirely? What choices will you make? \nNow is time to decide... \n");
                    Console.ReadKey(true);
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR! Please enter 'yes' or 'no'.");
                }
            }
        }
        private Player CharacterCreation()
        {
            /// These two methods below are involved when the player chooses what traits they would like.
            /// There were a number of ways I could have gone about this but this was the one that used least
            /// memory and was most efficient as opposed to creating a separate list for traits, appended
            /// to during character creation.
            /// Besides, this was more fun :D
            /// Essentially i create a list of traits to choose from in the form of a string,
            /// printed to the console. I then use the position of certain numbers and reoccurring 
            /// symbols to know where to truncate the string and isolate the key that 
            /// exists in the dictionary of traits and corresponds to the values which are its description.
            string TruncateString(string traitsString)
            {
                int index = traitsString.LastIndexOf("\n");

                string tString = traitsString.Substring(0, index);
                return tString;
            }
            string MakeKey(string traitsString)
            {
                int ind = traitsString.LastIndexOf("\n");
                int length = traitsString.Length;
                string key = traitsString.Substring(ind + 5, length - ind - 5);
                key = key.Trim().ToLower();
                return key;
            }
            int number;
            string name = ""; // name is to be the name of your hero character.
            Dice D4 = new Dice(4);
            Dice D2 = new Dice(2);
            Dice D3 = new Dice(3);
            // instantiating a few dice needed for calculating skill and stamina stats
            Dice D8 = new Dice(8);
            //these lists of dice to be thrown for titular stats
            List<Dice> skillDice = new List<Dice>();
            int skill = 0;
            List<Dice> staminaDice = new List<Dice>();
            int stamina = 0;
            List<Weapon> weaponInventory = new List<Weapon>();
            List<Item> inventory = new List<Item>();
            // separate lists for weapons and items. Even though weapons inherit from items
            // they don't work well when grouped together (they become difficult to disentangle
            // and recast as weapons). It's best to use two separate lists.
            //
            //This is the dictionary of player chosen traits.
            Dictionary<string, string> traits = new Dictionary<string, string>();
            // instantiating a 'foundation' player. to be overwritten a bit later.
            Player player1 = new Player(name, skill, stamina, weaponInventory, inventory, traits);
            bool askquestion = true; // keep asking a question until appropriate response is given.
            int n = 0; //for adding appropriate number of dice at start of character creation
            while (true)
            {
                Console.Write("Please enter your hero's name here: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    player1.Name = name;
                }
                else { continue; }
                //must enter a name, although player has free rein to make this name
                // whatever he or she chooses.
                if (n == 0)
                {
                    skillDice.Add(D4);
                    skillDice.Add(D4);
                    skillDice.Add(D4);
                }

                Console.WriteLine("Rolling your character's skill (3 4-sided dice)...");
                player1.Skill = 0;
                skill = 0;
                // By pausing with console.Readkey between dice rolls, randomness is ensured
                foreach (Dice d in skillDice) { Console.ReadKey(true); int roll = d.Roll(d); skill += roll; Console.WriteLine($"You rolled a {roll}"); }
                skill = skill - 2;
                //
                player1.Skill = skill;
                //player1.Skill = 2;
                Console.WriteLine($"Your skill is {skill + 2} - 2 = {skill}");
                //

                //
                if (n == 0)
                {
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                }
                player1.Stamina = 0;
                player1.InitialStamina = 0;
                stamina = 0;
                Console.WriteLine("Rolling your character's stamina (6 coin flips)...");
                foreach (Dice d in staminaDice) { Console.ReadKey(true); int roll = d.Roll(d); stamina += roll; Console.WriteLine($"You flipped a {roll}"); }
                stamina = stamina * 10;
                player1.Stamina = stamina;
                player1.InitialStamina = stamina;
                //Initial stamina determines the maximum health a player can have.
                Console.WriteLine($"Your stamina is {stamina}");


                Dictionary<string, string> traitList = new Dictionary<string, string>();
                traitList.Add("opportunist", "Carpe diem is your motto! You are the sort of person that strikes while the iron is hot and strikes hard. \nYour eagerness to exploit any advantage gives you a bonus in battle.");
                traitList.Add("human armadillo", "You've invested in quality steel armour and only ever take it off to polish it to a dazzling sheen. \nYour chances of being hit in combat are reduced as blows regularly bounce off you.");
                traitList.Add("thick-skinned", "Sticks and stones may break my bones, but... Well actually, no, they don't! You've a high pain tolerance and can weather trials with, if not a cool stoicism, then a devil-may-care attitude. \nThe damage you receive from enemy blows is sizeably reduced.");
                traitList.Add("diligent", "Either possessed by a hidden doubt, a desire for vengeance or perhaps simply a drive to excel, you've trained in the art of combat every day. You may not have started as a natural warrior, but you've pushed your own limits further than anyone else you know. \nYour skill is increased.");
                traitList.Add("jinxed", "When gentle folk of peaceful villages see you they cross to the other side of the street. They may even make gestures to ward away misfortune. To put it bluntly, you are a walking maelstrom of oafishness, a paragon of bad luck and a walking catastrophe the likes of which leaves everyone around you stunned. Calamities fall like rain around you as you naively blunder your merry way through every encounter.\nYour skill is reduced but you greatly increase your chance to score Critical Hits. Bring forth the maelstrom!");
                traitList.Add("hale, hot and hearty", "Regardless of whether or not you exercise regularly, or the state of your diet, you've always seemed to effortlessly stay in good shape. You find the captivated gaze of others often following you, admiring your most pleasing physique. \nYour stamina is increased.");
                traitList.Add("medicine man", "You've plenty of experience patching up many a wound, administering care and treating the sick. Even if your knowledge is limited, at least your doctorly disposition puts your patients more at ease.\nHealing potions have a greater effect on you.");
                traitList.Add("sadist", "Somewhere down the line you've secretly discovered the delectable, depraved pleasures of anguish - specifically other people's. You often find yourself relishing the thought of your next fight, and you feed your nasty fantasies by studying exactly where to strike to elicit the most exquisite pain... \nThe damage you deal from critical hits is greatly increased.");
                traitList.Add("thespian", "An actor without compare! A performer extraordinaire! And on occasion, mayhaps, the odd con, or two... or three. The future belongs to they that dares! \nAs for yourself, you *dare* to pretend to be that for which you are ill-equipped and trained, either for stolen glory, bountiful free booze or to gain company and favour with, shall we say, notable members of the opposite sex?\nYou may be lousy with a sword, but you look the part, and with a pen or a stage who needs such crude implements. Now! Where's your audience? \nYou have advantage in dialogue interactions and deception.");
                traitList.Add("friends with fairies", "For many moons you have been blessed with the extraordinary gift of being able to see and tap into the magical world of the Fey! You often converse with fairies, congregate with pixies and engage in entirely 110% meaningful philosophical discourse with your ethereal friends. Your other, more mundane friends, on the other hand, just think you're stark raving bonkers. But you know better...you think?\nWhere is the line between reality and fantasy? You decide! Prepare for strange encounters, bizarre events and your own, unique blend of logic to solve puzzles. Effects of magical potions become wild and unpredictable.");
                Console.WriteLine("You may also choose up to two of the following traits:\n");

                string traitsString = "\n[1] Opportunist\n[2] Human Armadillo\n[3] Thick-skinned\n[4] Friends With Fairies\n";
                int q = 5;
                if (skill > 5 && stamina > 80)
                {
                    traitsString += $"[{q}] Sadist\n";
                    q++;
                }
                else
                {

                    traitList.Remove("sadist");
                }
                if (skill < 6 && stamina > 90)
                {
                    traitsString += $"[{q}] Thespian\n";
                    q++;
                }
                else
                {
                    traitList.Remove("thespian");
                }

                if (skill > 4 && skill < 10)
                {
                    traitsString += $"[{q}] Diligent\n";
                    q++;
                }
                else
                {

                    traitList.Remove("diligent");
                }
                if (skill < 5 && stamina < 100)
                {
                    traitsString += $"[{q}] Jinxed\n";
                    q++;
                }
                else
                {

                    traitList.Remove("jinxed");
                }
                if (stamina < 120 && stamina > 70)
                {
                    traitsString += $"[{q}] Hale, Hot and Hearty\n";
                    q++;
                }
                else
                {

                    traitList.Remove("hale, hot and hearty");
                }
                if (skill > 5)
                {
                    traitsString += $"[{q}] Medicine Man\n";
                    q++;
                }
                else
                {

                    traitList.Remove("medicine man");
                }
                Console.WriteLine(traitsString);
                bool continueChoice = true;
                int t = 0;// t is 'traits chosen so far'
                ///I've established below a loop that allows the player to 
                ///peruse the different traits available according to rolled 
                ///skill and stamina scores. Descriptions are displayed and 
                ///then there is a check to see if the player really wants to 
                ///select this trait. There is a maximum of two that can be 
                ///chosen.
                while (continueChoice && t < 2)
                {

                    string key = "";
                    string answer = Console.ReadLine().Trim().ToLower();
                    if (int.TryParse(answer, out number)) // if number entered
                    {
                        string traitchoice = traitsString;

                        if (int.Parse(answer) < 1 || int.Parse(answer) >= q)
                        {
                            Console.WriteLine("Please enter a number corresponding to the list of traits above, or type 'done' when you are finished.");
                            continue;
                        }
                        else
                        {
                            int y = 0;
                            traitchoice = TruncateString(traitsString);
                            while (y < (q - int.Parse(answer) - 1))
                            {
                                traitchoice = TruncateString(traitchoice);
                                y++;
                            }
                            key = MakeKey(traitchoice);

                        }

                        Console.WriteLine($"{traitList[key]}\nWould you like to select this trait?");
                        while (true)
                        {
                            string nextAnswer = Console.ReadLine().Trim().ToLower();
                            if (nextAnswer == "yes" || nextAnswer == "y")
                            {
                                try // can't select same trait twice.
                                {
                                    player1.Traits.Add(key, traitList[key]);
                                    t++;
                                    break;
                                }
                                catch { Console.WriteLine("You've already chosen that trait! Choose another."); askquestion = false; break; }
                            }
                            else if (nextAnswer == "no" || nextAnswer == "n")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' or 'no'");

                            }
                        }
                        if (t < 2 && askquestion)
                        {
                            Console.WriteLine("Would you like to pick another trait for your character?");
                        }
                        askquestion = true;
                    }
                    else // if trait typed out or player does not wish to continue trait selection
                    {
                        if (!traitList.ContainsKey(answer) && answer != "done")
                        {
                            Console.WriteLine("Type in a specific trait from the list above, its corresponding number, or type 'done' when you are finished.");
                            continue;
                        }
                        else if (answer == "done")
                        {
                            continueChoice = false;
                        }
                        else
                        {
                            Console.WriteLine($"{traitList[answer]}\nWould you like to select this trait?");
                            while (true)
                            {
                                string nextAnswer = Console.ReadLine().Trim().ToLower();
                                if (nextAnswer == "yes" || nextAnswer == "y")
                                {
                                    try
                                    {
                                        player1.Traits.Add(answer, traitList[answer]);
                                        t++;
                                        break;
                                    }
                                    catch { Console.WriteLine("You've already chosen that trait! Choose another."); askquestion = false; break; }
                                }
                                else if (nextAnswer == "no" || nextAnswer == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter 'yes' or 'no'");

                                }
                            }
                            if (t < 2 && askquestion)
                            {
                                Console.WriteLine("Would you like to pick another trait for your character?");
                            }
                            askquestion = true;
                        }
                    }
                }
                string characterTrait = "";
                foreach (var k in player1.Traits)
                {
                    characterTrait += $"{player1.Traits[k.Key]}\n";
                }
                //
                if (player1.Traits.ContainsKey("opportunist"))
                {
                    // hT +3
                    //Console.WriteLine("Increase hitThreshold during combat by 2 if commentary = true");
                }
                if (player1.Traits.ContainsKey("human armadillo"))
                {
                    // enemy ht - 1 and skill/3 to hit
                    //Console.WriteLine("Decrease hitThreshold for opponent by 2 when commentary is false");
                }
                if (player1.Traits.ContainsKey("thick-skinned"))
                {
                    // 20% reduction in incoming damage
                    //Console.WriteLine("Modify incoming damageDealt by 3/4 when commentary is true.");
                }
                if (player1.Traits.ContainsKey("jinxed"))
                {
                    if (player1.Skill < 3) { player1.Skill = 1; }
                    else { player1.Skill = 2; }
                    //Console.WriteLine("Boon is +6 for all weapons, but skill is reduced to 2 or stays at 1.
                }
                if (player1.Traits.ContainsKey("diligent"))
                {
                    if (player1.Skill > 5) { player1.Skill += 1; }
                    else { player1.Skill = 7; }
                    //Console.WriteLine("if skill is 5 then +2 else +1");
                }
                if (player1.Traits.ContainsKey("hale, hot and hearty"))
                {
                    if (player1.Stamina < 110 && player1.Stamina > 80) { player1.Stamina += 20; player1.InitialStamina += 20; }
                    else if (player1.Stamina == 80) { player1.Stamina = 110; player1.InitialStamina = 110; }
                    else { player1.Stamina = 120; player1.InitialStamina = 120; }
                    //Console.WriteLine("if stamina is 80 +30, if stamina is below 110 +20, if 110 +10");
                }
                if (player1.Traits.ContainsKey("medicine man"))
                {
                    Console.WriteLine("Healing potions receive an extra dice roll");
                }
                if (player1.Traits.ContainsKey("friends with fairies"))
                {
                    // healing potions change type of dice rolled so that results vary wildly. Luck potion(felix
                    // felicis) causes new jinxed miss events. you can escape using the bowl fragments
                    // you can use healing potion on the skeleton to gain a companion and
                    // add messages with you dancing or skipping, sashaying, etc to various room items
                }
                if (player1.Traits.ContainsKey("thespian"))
                {
                    // you can talk your way out of your cell if successful dialogue 
                    // else you talk the guard into opening cell door but your con is 
                    // uncovered and you have to fight.
                }
                //Finally, a description of the character created whose composition is
                //the result of player choices and stats levels
                Console.WriteLine($"\n{name}'s details are as follows:\n{player1.DescribeSkill()}\n{player1.DescribeInitialStamina()}\n{characterTrait}");
                ///Check that player is happy with created character or wishes to start over.
                Console.WriteLine("Are you happy with this character?");
                while (true)
                {
                    string nextAnswer = Console.ReadLine().Trim().ToLower();
                    if (nextAnswer == "yes" || nextAnswer == "y")
                    {
                        
                        return player1;

                    }
                    else if (nextAnswer == "no" || nextAnswer == "n")
                    {
                        player1.Traits = new Dictionary<string, string>();
                        Console.WriteLine("\x1b[3J");
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'yes' or 'no'");

                    }
                }
                n++;
            }
            
        }
        public void Start(bool music)
        {
            this.Music = music;
            //Instantiating a six sided dice to be used for dealing damage with a particular weapon. 
            // Damage works in combat by rolling dice. Each weapon has a different set of dice. Hence,
            // one might deal a different range, with different prob distribution, of damage amounts
            // depending on choice of weapon. This has been inspired by D&D and also more directly BG3.
            Dice D6 = new Dice(6);
            Dice D3 = new Dice(3);
            Dice D12 = new Dice(12);
            List<Dice> chainDamage = new List<Dice> { D6 };
            //The following are lists of messages that might chance to appear in combat if certain, 
            //requirements are met, such as critical or good hits.
            Dice D4 = new Dice(4);
            bool masked = false;
            bool discovery = false;
            Dice D2 = new Dice(2);
            List<Dice> damage = new List<Dice> { D4, D4 };
            List<Dice> damage1 = new List<Dice> { D3, D3, D2 };
            List<Dice> vanquisherDamage = new List<Dice> { D3, D3, D3, D3 };
            List<string> defaultCritHits = new List<string>
                {
                "One instant your weapon is by your side, the next it hovers in the air, held in one still hand as blood spatters the ground beneath it. Behind you the foul enemy totters for but a moment before slumping to the ground in a cascade of guts. The only sound that fills the crackling silence is the ringing of your blade as you once again sheathe it. Your enemy was no match for your lightning reflexes, it seems. A smug smile slips upon your lips.",
                "You unleash a flurry of blows against the creature in a well-practiced staccato, so fluid as to almost be like a dance. Your enemy howls as it reels away from you, barely able to fend you off before regrouping for one final, desperate last stand...",
                "Your acrobatic prowess pays off as you weave your lithe body effortlessly past the enemy's defences in a series of spinning leaps and dives, like a leaf floating gracefully upon the wind. You pick your moment with well-timed precision. Your strike lands true and cripples your enemy.",
                "Despite your unmatched skill your enemy proves to be tough. A cold bead of sweat trickles down your brow as even your best strike has yet to slow them down. If anything, your powerful attack has only incensed them further, as they flail wildly to desperately keep you at bay.",
                "Sweat shimmers your brow as you ruggedly persevere through your opponent's defences with steely grit. Finally, they fall and you take your chance. It's not long before all that lays before you is a bloodied tangle of intestines and gore. Breathing a heavy sigh of relief, you thank your stars that it's over.",
                "You swing your weapon and manage to finally knock your opponent off balance. Before you land the killing blow, however, they roll back to their feet, cursing you as they clutch a bloody gash in their side. Time is running out for them, and they know it, but it only seems to strengthen their resolve.",
                "You parry your opponents strike and riposte. Your strike is received with a blood-curdling yowl of anguish as the enemy staggers backwards. They are momentarily fazed by your attack. But it's not long before they once again close in for the kill.",
                "It's hard to deny now that your fastidious training is falling short in this fight. The enemy is imposing, and your best strike, though damaging, hasn't stopped your adversary. They advance on you...",
                "The enemy leers ravenously as they lunge towards you. Screaming in fright, you flail wildly, your eyes shut because you can't bear to look. When you open them you find you're slashing at empty air and your enemy lies dead. \nWell, if skill won't see you through, you suppose sheer dumb luck just might...",
                "The enemy closes in but are almost as surprised as you are when you land a lucky blow. Their eyes bulge as blood gushes forth from the gaping wound delivered by your quivering hands. They glower your way. A lump catches in your throat as you realise that they're done toying with you...",
                "Your inexpert strikes and frenzied ripostes are just enough to chance a lucky hit. The enemy is caught off guard as they find themselves seriously wounded. Your hopes are buoyed as the fight continues.",
                "In a desperate bid to see another dawn you unleash a volley of desperate, febrile blows. They are mostly dodged with ease. Only one lands true, but severe as the blow is, your best effort isn't even close to bringing this beast down...",
                "Your knees knock, your heart thumps against your chest, and your hands shake so badly they're scarcely able to keep hold of the weapon in front of you. \nWho are you kidding? You're no fighter. Why didn't you just follow your heart and take up crochet? \nThe enemy bounds towards you ready to strike. You hurl away your weapon and dive for the corner, folding in on yourself and hoping the fierce enemy will just forget about you or something...\nWhen you finally chance a glance back, you find the enemy slowly rocking on their feet, an expression as if they were hang gliding over hell is etched on their face. Then you look down. \nYour weapon appears to have ricocheted to where the sun don't shine. \nThe enemy looks at you with pleading eyes, before those eyes cross, and the enemy flops backwards. \nHenceforth, word shall be told of this deed, and your enemies will shudder.",
                "In a flurry of instants so bizarre they belong in a circus, you flail your weapon losing your balance in the process and slamming into the enemy 'drunken-fist' style, before themselves tripping over you, and somehow skewering themselves on your weapon. You only just manage to retrieve it before the enemy, bleeding profusely, dizzily stumbles upright.",
                "The enemy get's over-confident. Relishing your knee-knocking terror, they attempt a display of might only to fall flat on their face.",
                "You hurl your diary at the creature. It gets a paper-cut. Critical hit."
                };
            List<string> defaultGoodHits = new List<string>
                {
                "With a mighty heave your weapon cleaves the creature in two.",
                "The enemy staggers back before your onslaught.",
                "Your expert strikes are rapidly bringing the enemy low",
                "The enemy may be tough, but you're tougher. They've been badly hurt.",
                "With a thunderous roar you finally overpower your enemy. Their head topples from their shoulders.",
                "The enemy is sent reeling from your powerful blows.",
                "The enemy is winded badly. You press the attack.",
                "The enemy is wounded but they're tougher than expected. You'll have to draw on some greater reserve of strength to best them yet.",
                "You finally land the killing blow. You're surprised you've survived this fight, but you steel yourself; there are more yet to come.",
                "Your inexpert strike somehow hits home. The enemy looks mortally wounded.",
                "You send the enemy reeling with a haymaker to the jaw. It might lack finesse, but its effective.",
                "You've hurt the enemy more than usual, but you know with some trepidation that it's no where near enough.",
                "The enemy snaps their own neck whilst fighting you. \nNo, we don't know how that happened either...",
                "The enemy somehow stabs themselves on your weapon. Then proceeds to do it nine times more...",
                "The enemy somehow stabs themselves on your weapon.",
                "The enemy gets a spontaneous nosebleed."
                };
            List<string> sabreCrits = new List<string> 
            {
                "After a flurry of ripostes and counters the CurseBreaker finally finds his opening. He bolts forward and runs you through with his sabre. Moments before the light leaves your eyes, you see a smug, satisfied smile creep across his lips, as he slowly slides the blade out of your soon-to-be corpse...",
                "The CurseBreaker nimbly sidesteps your attacks. Before you know it he's managed to dart behind you and open up a severe and nasty gash across your back. You can't help but collapse as the steel bites, and only just manage to roll out of the way before he lands the killing blow...",
                "Thunder crashes overhead as you both enter a desperate flurry of parries and ripostes amidst the biting sleet. The CurseBreaker's sabre is a blur as he slashes at your forearm, spattering blood into your anguished face...",
                "Both your feet clap upon the flagstones as your duel rages under the frightful storm. You each try to outmanoeuvre the other; a fever of feints and sidesteps and parries. Amidst it all, the CurseBreaker slices open the back of your hand...",

                "Sensing your exhaustion, the CurseBreaker finally seizes his chance. He leaves finesse behind as he hammers at your defence with his sabre, sending you staggering backwards. Back against the parapet's edge he delivers the final blow; a kick that sends you plummeting to your death...",
                "The CurseBreaker unleashes a frenzied flurry of swipes that put you on the defensive. You only just manage to roll out from under his onslaught, clutching a bloodied arm. You glance your blood-drenched garb and know instantly that your time is running out...",
                "The storm rages on as you and the CurseBreaker clash beneath the lightning strikes. You lock weapons, each gripping the others sword-arm before the CurseBreaker gets the upper hand. Stepping on your inside knee, he mashes your face with the hilt of his sabre before you jolt back from his deadly killing blow...",
                "You circle one another, clashing steel and lighting the dark towertop with showers of sparks, when the CurseBreaker slashes at your leg...",

                "After a flurry of ripostes and counters the CurseBreaker finally finds his opening. He bolts forward and runs you through with his sabre. Moments before the light leaves your eyes, you see a smug, satisfied smile creep across his lips, as he slowly slides the blade out of your soon-to-be corpse...",
                "The CurseBreaker nimbly sidesteps your attacks. Before you know it he's managed to dart behind you and open up a severe and nasty gash across your back. You can't help but collapse as the steel bites, and only just manage to roll out of the way before he lands the killing blow...",
                "Thunder crashes overhead as you both enter a desperate flurry of parries and ripostes amidst the biting sleet. The CurseBreaker's sabre is a blur as he slashes at your forearm, spattering blood into your anguished face...",
                "Both your feet clap upon the flagstones as your duel rages under the frightful storm. You each try to outmanoeuvre the other; a fever of feints and sidesteps and parries. Amidst it all, the CurseBreaker slices open the back of your hand...",

                "Sensing your exhaustion, the CurseBreaker finally seizes his chance. He leaves finesse behind as he hammers at your defence with his sabre, sending you staggering backwards. Back against the parapet's edge he delivers the final blow; a kick that sends you plummeting to your death...",
                "The CurseBreaker unleashes a frenzied flurry of swipes that put you on the defensive. You only just manage to roll out from under his onslaught, clutching a bloodied arm. You glance your blood-drenched garb and know instantly that your time is running out...",
                "The storm rages on as you and the CurseBreaker clash beneath the lightning strikes. You lock weapons, each gripping the others sword-arm before the CurseBreaker gets the upper hand. Stepping on your inside knee, he mashes your face with the hilt of his sabre before you jolt back from his deadly killing blow...",
                "You circle one another, clashing steel and lighting the dark towertop with showers of sparks, when the CurseBreaker slashes at your leg..."
            };
            List<string> sabreGoodHits = new List<string>
            {
                "The CurseBreaker breaks your defence. He finally delivers the killing blow...",
                "The CurseBreaker parries and counterstrikes. He smiles grimly at your pained anguish as his sabre bites into flesh...",
                "Your duel rages as torrents of sleet crash down upon you both. You slip upon the wet flagstones and the CurseBreaker presses his advantage...",
                "The CurseBreaker unleashes a flurry of expert strikes that you can scarcely defend against...",

                "The CurseBreaker breaks your defence before barrelling into you. He shunts you off the towertop, sending you plummeting to your death...",
                "The CurseBreaker knocks your defence to pieces before his gleaming sabre slashes at your midsection...",
                "The CurseBreaker watches you with those perturbing black eyes, probing for your weaknesses. When he strikes, you can scarcely counter him...",
                "The CurseBreaker nimbly spins a parry into a thrust. He nicks your ribs with his vicious sabre...",

                "The CurseBreaker lobs a fragment of flagstone at your face! You stagger backwards, unable to stop him from running you through...",
                "Wrestling with one another's wrists, you each struggle for the advantage, before the CurseBreaker knees your gut. His killing blow becomes a glancing strike as you scramble away...",
                "Thunder crashes as you exchange blows. The CurseBreaker is steadily getting the upper hand...",
                "Lightning flashes as blood spatters the flagstones! You look down at the gash in your leg before recovering. The CurseBreaker had struck so fast his blade could scarcely be seen. He advances on you once again... ",

                "The CurseBreaker breaks your defence. He finally delivers the killing blow...",
                "The CurseBreaker knocks your defence to pieces before his gleaming sabre slashes at your midsection...",
                "Thunder crashes as you exchange blows. The CurseBreaker is steadily getting the upper hand...",
                "The CurseBreaker unleashes a flurry of expert strikes that you can scarcely defend against..."
            };
            List<string> sizzleCrits = new List<string>
            {
                "The CurseBreaker's gloves crackle, before casting their chain lightning at you! Your skin erupts in flames but not before you are hurled off the tower. You scream as you plummet to your death, a blazing fireball lighting up the night like a flare plunging the depths of a chasm of stormclouds and thunder...",
                "The gloves' lightning cracks and snaps at you, jolting you backwards and into the parapet wall...",
                "The gloves bristle with electric charge, before unleashing a bolt your way! It sears your arm...",
                "The gloves electrify the air around you, tiny jolts snapping at you with every move...",

                "The CurseBreaker's gloves crackle, before casting their chain lightning at you! Your skin erupts in flames but not before you are hurled off the tower. You scream as you plummet to your death, a blazing fireball lighting up the night like a flare plunging the depths of a chasm of stormclouds and thunder...",
                "The gloves blast the flagstone by your feet with their fearsome charge! you reel backwards from the blast...",
                "The CurseBreaker snaps his fingers and smiles grimly as a bolt of lightning sends you staggering backwards...",
                "The gloves roar with static as you approach! You get jolted by their charge...",

                "The CurseBreaker's gloves crackle, before casting their chain lightning at you! Your skin erupts in flames but not before you are hurled off the tower. You scream as you plummet to your death, a blazing fireball lighting up the night like a flare plunging the depths of a chasm of stormclouds and thunder...",
                "The gloves' lightning cracks and snaps at you, jolting you backwards and into the parapet wall...",                     
                "The CurseBreaker snaps his fingers and smiles grimly as a bolt of lightning sends you staggering backwards...",
                "The gloves roar with static as you approach! You get jolted by their charge...",

                "The CurseBreaker's gloves crackle, before casting their chain lightning at you! Your skin erupts in flames but not before you are hurled off the tower. You scream as you plummet to your death, a blazing fireball lighting up the night like a flare plunging the depths of a chasm of stormclouds and thunder...",
                "The gloves blast the flagstone by your feet with their fearsome charge! you reel backwards from the blast...",
                "The gloves bristle with electric charge, before unleashing a bolt your way! It sears your arm...",
                "The gloves electrify the air around you, tiny jolts snapping at you with every move...",
            };
            List<string> stilettoCrits = new List<string>
                            {
                                "With brutal efficiency, the CurseBreaker plunges his stiletto blade into your heart!",
                                "The CurseBreaker stabs you in the shoulder!",
                                "The CurseBreaker slashes your hand...",
                                "The CurseBreaker makes a flurry of probing attacks...",

                                "With one vicious thrust the stiletto blade sinks between your ribs! You splutter and cough up blood before collapsing to the cold flagstones...",
                                "The CurseBreaker skewers your thigh!",
                                "The CurseBreaker's stiletto blae breaks through your armour...",
                                "The CurseBreaker grazes your leg...",

                                "The CurseBreaker finds his opening! Before you can react he lunges up close and maliciously stabs you repeatedly in the kidneys. Your body crumples into darkness...",
                                "The CurseBreaker drives his stiletto blade into your arm!",
                                "The CurseBreaker slashes your side...",
                                "The CurseBreaker kicks your shins...",

                                "The CurseBreaker breaks past your defences! Before you know it he kicks you off the edge of the parapet. You scream as you plummet to your death...",
                                "The CurseBreaker backfists you with a gloved hand!",
                                "The CurseBreaker gets around your defences!",
                                "The CurseBreaker's stiletto blade makes a glancing hit..."
                            };
            string newNote = "Someone has scrawled upon the note in hasty erratic cursive. It reads, 'I don't have long now. If you're reading this then you're likely another foolhardy adventurer like myself who got his'self kidnapped just as I woz. I don' have much space so mark my words. Whatever they tell you - its a lie. They're going to harm you. They're most likely going to kill you in one of their mad experiments. There's a music box. I kept it locked away and hidden from sight. It's in the chest. It may look empty but set in its bottom is a panel that can be removed. You'll find it there. If you play it the guard loses his marbles about it. Can't stand the tune, the little blighter! It's like nails on a chalkboard to 'em creatures. When it enters, subdue the loathsome thing. It's the only way out of 'ere. Hopefully, if I don't make it, at least someone else will...' The rest deteriorates into an illegible scribble at the bottom of the page.";
            //Items to be located somewhere in the room or upon the player character
            Item binkySkull = new Item("Binky", "~~ He's a bonafide friend in need, a bonny true soul indeed, he's brimming with revelry when you bring bonhomie, Hey! don't be a bonana, 'cause you've got a BONANZA, of a friend in me! ~~");
            Item steelKey = new Item("steel key", "You find it under the skeleton's bones. You guess whoever it was had swallowed it before death. The key itself is rather nondescript - just a humble key. You suppose it must unlock something...");
            Item healPotion = new Item("healing potion", "It has flecks of gold floating amidst a gel like suspension. The label reads; 'When you're feeling blue, down with the flu, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!'", true, "used", 0, "Stamina: When you're blue, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!");
            Item note = new Item("note", "The note is dogeared and yellowed with age.\nSomeone has scrawled upon it but the writing is too small to make out. Snatches of words, poorly spelt, unveil themselves to you when you strain your eyes. However, no coherent message can be deciphered. Something about a false bottom? If only there was some spell to enlarge letters, you muse... If only you knew any spells!", true, "unread");
            Item halfOfCrackedBowl = new Item("half a cracked bowl", "Its a cheap bowl made of clay - half of one anyway - chipped in places around the rim and bearing a hairline crack down its left side.");
            Item otherHalfOfCrackedBowl = new Item("other half of a cracked bowl", "It's not much less damaged than its counterpart");
            Item musicBox = new Item("music box", "A curious artefact with a hand-crafted rosewood exterior, inlaid with gold. It has glass panels displaying well oiled brass cogs gently whirring inside.", false, "unopened", 1, "strange lullaby");
            Weapon rustyChains = new Weapon("rusty chains", "They're so caked with rust that they're links have stiffened with age. You doubt these could hold any prisoner. Perhaps that's why they weren't used on you. Handling one of them, you figure it'd make a halfway decent, impromptu weapon - if you've really no other choice.", chainDamage, defaultCritHits, defaultGoodHits);
            Item garment = new Item("garment", "Haphazardly strewn about the rickety floor of your cell, they're worn, faded and moth-eaten. Hardly a fashion accessory.", true, "unburned");
            Item elixirFeline = new Item("Elixir of Feline Guile", "It's pungent aroma makes you recoil. Upon the label it reads, 'Is 'butter-fingers' your middle name? Do you like jumping from great heights, but don't like the dying that usually follows? Merigold's Wondrous Elixir of Feline Guile is the thing for you! Please note Merigold is not responsible for fatal falls during or after this potion takes effect. Please use responsibly. Pleasant fragrance not included.'", true, "unshattered", 1, "Skill: Boosts your skill by 1 point. Caution: excessive use may cause an over-fondness for catnip.");
            Item FelixFelicis = new Item("Felix Felicis", "It bubbles, roils and froths within its bottle. You almost sense a quiver through the glass, like the crystalline liquid inside is trying to escape. The label on the side is illegible; someone has written over it with a shaky cursive, 'Don't drink it! Whatever you do, don't drink it! For the love of all that is holy, if you care for anyone around you keep the stopper on!!! ~ Yours sincerely, Merigold.'", true, "unshattered", 10, "Luck: Drink and accomplish your wildest dreams..."); // access to 'jinxed' critmisses for 1 battle only
            Item magnifyingGlass = new Item("magnifying glass", "Peering through its slightly misted lens objects appear at least three times their size. You wonder why the skeleton had hold of it...");
            Item bowlFragments = new Item("bowl fragments", "They're sharp. You best avoid stepping on them.", false, "shattered");
            Item jailorKeys = new Item("jailor keys", "Such cast iron, heavy-duty keys and the ring they're found on seem typical of any prison worthy of the name - not that you'd know, of course.");
            List<Item> cellInventory = new List<Item> { rustyChains, halfOfCrackedBowl, otherHalfOfCrackedBowl, bowlFragments, garment };
            Item bobbyPins = new Item("bobby pin", "This is one of the few bobby pins that haven't been bent out of shape through frantic heavy-handedness.", true, "unbent");
            Item speedPotion = new Item("potion of alacrity", "It gloops up and down in its vial like a lava lamp. Upon the label it reads, 'Are you stuck in your very own wonderland? Are you tired of always running late for those very important dates? Do you wish there was a way you could make time every time and beat the clock? Well now you can! Merigold's marvellous antidote for tardiness rests in YOUR hand. With one quick sip, you'll be whizzing ahead of the crowds in no time! ~ Merigold would like to note that there are absolutely no downsides to this potion whatsoever. Nope. None. No matter what those lowlifes in the Independent Wizarding Authority have to say. They're great dirty liars and their claims that Merigold doesn't meet the code of standards for hygiene is pure liberal scaremongering, and I'll see you in wizard court!, \nYours sincerely,\n\tMerigold.'", true, "unshattered", 0, "speed: hullabaloo!");
            Item journal = new Item("worn journal", "Opening it up you find detailed accounts of various escape attempts, but only one entry in particular catches your eye;\n\n" +
                "'\tDay 6:\nI managed to purloin some artefact from one of the mercenaries when they dished out my gruel. I know it must be Merigold's because its embossed with his seal (an 'M' enveloped within a cursive capital 'G') - that means it'll be enchanted somehow. Still only an apprentice cleric, so i had to work hard to get the " +
                "damn thing to do something. Eventually I used it to cast fireballs at the two braziers. Didn't work on the door though. \nI know what this Curse-Breaker is using them for. They won't subdue me with eldritch Fey enchantments. If they" +
                "want me, they'll have to fight me! \n For now I'll keep the Merigold's ring hidden somewhere. Perhaps if I escape I'll be able to find him. \n\tFree him.\nThen we can put a stop to the evil that has befallen this place. The tragedy that is the cursebreaker " +
                "must be brought to an end. How he might be defeated though... Merigold will know the answer. If he's still alive...' \n[ink splotches the parchment here, as though a pen had been hovering above the page, waiting]\n\t'Patrol just passed my cell, they seized the poor bugger next to mine. Dear god. \n If I don't make it out of here, and you're reading this, maybe you're this cell's next occupant, or maybe - God, I hope - you've" +
                " already accomplished what has so eluded me; you've escaped. Either way, don't give up! There is more at stake than you can imagine. Even with my meagre training in the arcane, I've sensed for days now something not right within these walls - something terrible. Something with powers beyond the pale. This curse-Breaker, as he chooses to be known, MUST NOT be permitted dominion over it.\n" +
                "You have before you a crusade of inestimable import. To truly escape not just this tower but the future this evil man weaves, he must be vanquished. I can impart upon you here my own experiences, that you might learn what you're up against. But I also choose to bestow upon you these words:\n" +
                "The enemy may be mighty. But they are not invincible. The enemy may be many. But they are far fewer than all those whose hopes march with you. The eyes of the world fall upon you. You may be the best hope of securing our freedom. More importantly, of delivering us from the Curse-Breaker's designs. Know that even should these words be all that's left of me, I have full confidence, even now, in your final victory. \n" +
                "So good luck, god speed, And god bless you on this almighty undertaking. May the wardens of fate guide your hand true. Find Merigold. Find the source of the Curse-Breaker's power. Save us all...'", false, "unread");
            Item merigoldRing = new Item("ring embossed 'MG'", "It is such an innocuous thing, so unassuming that it probably wouldn't sell at a village flea market. However, there's a certain - not sheen, but... a shimmer to it, that enchants the eye. You sense the ring has powers beyond the reach of hands untrained in the arcane such as yours.");
            List<Item> trunkItems = new List<Item> { journal};
            Item redThread = new Item("ball of red thread", "Turning it over in your hands, you surmise that its been knotted together out of strand upon strand of the threads within the surrounding garments. It's been wound tight.", true, "spooled");
            Item bowl = new Item("unbroken bowl", "It's similar to the one you saw in your dank cell, had yours not been shattered in two.");
            Item shatteredPlanks = new Item("splintered planks", "They scatter the floor nearby a hole that prevents escape only thanks to thick wooden beams crisscrossing the room beneath the floorboards.", true, "unburned");
            List<Item> cell2Inventory = new List<Item> { bowl, shatteredPlanks, garment};
            // Features of the room, some with items hidden upon or within them. Both
            // Items and features can be interacted with but only items can be picked up
            // and features remain in place unless shattered or unlocked or burned depending on
            // their special attribute.
            List<Item> inRosewoodChest = new List<Item> { };
            List<Item> onSkeleton = new List<Item> { healPotion, magnifyingGlass };
            Feature skeleton = new Feature("skeleton", "Its empty sockets fasten you with a stern gaze. It's been bound by chains to the wall, making it difficult to move. Something shiny is trapped out of reach behind it.", false, "unshattered", onSkeleton);
            Feature leftbrazier = new Feature("left brazier", "If these braziers do indeed burn it is not with any normal fire. Upon closer inspection, their dim flickering glow seemingly cannot be expunged. They barely keep the looming shadows at bay.", true, "lit", null);
            Feature rightbrazier = new Feature("right brazier", "If these braziers do indeed burn it is not with any normal fire. Upon closer inspection, their dim flickering glow seemingly cannot be expunged. They barely keep the looming shadows at bay.", true, "lit", null);
            Feature anotherBrazier = new Feature("brazier", "If these braziers do indeed burn it is not with any normal fire. Upon closer inspection, their dim flickering glow seemingly cannot be expunged. They barely keep the looming shadows at bay.", true, "lit", null);
            Door rosewoodDoor = new Door("rosewood door", "It's a curiously ornate door with smooth well-polished panels. The wood's warmth is somewhat diminished by the heavy iron hinges holding it in place.");
            Feature rosewoodChest = new Feature("rosewood chest", "Its smooth, burnished surface matches the grain and style of the door and like the door its elegance is jarred by the heavy steel lock sealing it. It makes you wonder if this room hadn't always been a dank cell.", true, "locked", inRosewoodChest);
            List<Item> inBookcase = new List<Item> { note };
            Feature bookCase = new Feature("bookcase", "The ostensibly empty bookcase is a little worse for wear. One of it's shelves is lopsided. Another at the bottom has collapsed. Cobwebs span its dusty corners.", true, "searched", inBookcase);
            Door holeInCeiling = new Door("hole in the ceiling", "You gaze from the heap of debris that has buried the creature alive to the hole through the ceiling above. You bet you could climb the heap and enter the room above yours.", false, "unblocked", null, null, "You clamber up the mound of debris and heft yourself through floorboards into a new room...");
            Door stairwayToLower = new Door("dark stairwell", "The steep stone steps descend beyond the light of the braziers and into the unknown murk lurking below. Without some sort of light that can dispel the impenetrable darkness beneath your feet, you might want to think carefully before navigating this slippery and hazardous passage.", false, "unblocked", null, null, "Feeling a knot of dread tighten about your stomach, you make the descent into a shifting web of shadows and silhouettes...", true);
            Door stairwayToUpper = new Door("lit stairway", "The wide flight of stone steps slowly curves around, leading to somewhere unseen but well-lit.", false, "unblocked", null, null, "You embark along the stairs two at a time.");
            Door otherRosewoodDoor = new Door("near door", "Like your former cell's door, this one is composed of elegant rosewood panels that appear to indicate a misplaced opulence that should belong to settings far more salubrious than the one you find yourself in.", true, "locked", null, null, "The door creaks ominously as you furtively pace into the next room.");
            Door armouryDoor = new Door("RmorRee door", "Its a heavyset door studded with iron bolts and a thoroughly unwelcoming aspect.", false, "unlocked", null, null, "The door swings open with a heave and opens into the next room...");
            Door circleDoor = new Door("double doors", "An ornate and set of vast double doors with brass locks and filigreed handles. You reckon something as large as a troll could fit through that door...", true, "locked", null, null, "You open one of the doors open just a fraction and slip your way through...");
            Door emptyCellDoor = new Door("far door", "Like your former cell's door, this one is composed of elegant rosewood panels that appear to indicate a misplaced opulence that should belong to settings far more salubrious than the one you find yourself in. You notice the lock has scratches made from the inside. You surmise someone has attempted picking the lock, but unless they had something more than just a bobby pin, it's doubtful they succeeded.", true, "locked", null, null);
            Door magManDoor = new Door("rosewood door", "Identical to all the other doors in these corridors, it's ornate and has a beautiful gleam to it's burnished surface. There exists no plaque or indication as to where it leads...", true, "locked", null, null);
            List<Item> messHallDoorItems = new List<Item> { };
            Door messHallDoor = new Door("rosewood door", "Identical to all the other doors in these corridors, it's ornate and has a beautiful gleam to it's burnished surface. There exists no plaque or indication as to where it leads...", false, "unlocked", messHallDoorItems, null, "You slip through the door and into the next room...");
            Door broomClosetDoor = new Door("rosewood door", "Identical to all the other doors in these corridors, it's ornate and has a beautiful gleam to it's burnished surface. There exists no plaque or indication as to where it leads...", false, "unlocked", null);
            

            Item soot = new Item("soot", "It's black. It's burned... Yep, that's soot.", false, "unsmeared", 0, ": ");
            List<Item> rightbrazierItems = new List<Item> { merigoldRing, soot};
            List<Item> leftBrazierItems = new List<Item> { soot};
            Feature brokenRightBrazier = new Feature("right broken brazier", "It's been tampered with by magic. It seems the last occupant here knew their arcana. Looking to the scratches on the door you sense with a tot of foreboding that it didn't do them any good.\nProbing further you find a ring has been stashed inside the well where used to flicker a blue flame.", false, "unlit", rightbrazierItems);
            Feature brokenLeftBrazier = new Feature("left broken brazier", "It's been tampered with by magic. It seems the last occupant here knew their arcana. Looking to the scratches on the door you sense with a tot of foreboding that it didn't do them any good...", false, "unlit", leftBrazierItems);
            Feature trunk = new Feature("weathered old trunk", "The leather of its sides is faded and worn. Unlike the rosewood chest in your room it hasn't been looked after and there's no hidden compartment.", false, "unlocked", trunkItems);
            List<Feature> cell2features = new List<Feature> { trunk, otherRosewoodDoor, brokenLeftBrazier, brokenRightBrazier};
            ///
            ///antechamber features
            Feature mosaic = new Feature("peculiar mosaic", "You glance the mosaic's way before discovering its lustrous tiles are constantly flipping and shuffling like cards in the dextrous hands of some invisible dealer. The magical image they form is ever shifting. They seem to react to your presence.", false, "unstudied", null);
            Feature pillar = new Feature("grand pillar", "Its fluted elegance extends to the ceiling high above, flowering in stunning and intricate statuettes. Your fingers absently trace veins within the marble, admiring its opulence.", false, "unshattered");
            Feature plaque = new Feature("scorched bronze plaque", "Its engraved letters have been made illegible by the fire damage of some spell. Scribbled clumsily in the soot you can make out the scrawl, 'RMorRee'", false, "unstudied");
            ///
            /// otherBookcaseItems
            Item bookEC3 = new Item("love letter", "tear-stained, it was made out of the torn page from a book. It reads as follows in shaky script...\n\t'Dearest Willow,\n\nI find myself confronting the increasingly unshakeable certainty that my death, or something far worse," +
                "draws near. While my end looms large in these few precious minutes I have left to remember you, know that my happiness for what time we have spent together dwarfs it by a magnitude so great, that even now" +
                ", in these last moments, I feel a bitter-sweet joy basking in your memory.\nYou always told me I should hang up the adventuring life. I'm sorry that you won't get the chance to tell me once more. For I write " +
                "this in the forlorn knowledge my words might never find you, and I can only pray that if they do not that the sentiment and undying affection I bear for you and our child will prove too strong, and " +
                "altogether too large, to be bound by such a physical form as ink and paper. If I should not make it, I know it will be hard for you, but though you may wish to give up, you cannot falter. Left to you is the greatest charge of all," +
                 "that of the raising of our child. \nThat she may know love and joy without my being there fills me with a dread eclipsing that of all other terrors I've faced or have yet to face, but I steel myself in the certainty, as implacable as the sunrise and the moonfall," +
                 "that you will rise to the task in my absence and teach her the same gentleness of spirit that has always soothed and drawn forth the best in me. \nKnow that I, with all my heart and soul, will always love you, \n\n\tSandy'", false, "unread");
            Item bookEC2 = new Item("dusty tome", "Judging by the weight of the manuscript, this literary brick is crammed with useless information. Flicking through its pages though you notice someone has torn out a page...", false, "unburned");
            Item bookEC1 = new Item("leatherbound journal", "Its contents aren't very interesting except for the scrawl that inhabits the margins of several pages, penned with a feverish hand. Squinting, these passages written over the main text seem to compose a diary of the previous occupants internment.", false, "unburned");
            Item bookEC4 = new Item("vespasian newsletter", "It's a strange propaganda leaflet that seems to have been circulated around the dastardly creatures that imprisoned you and held you captive. It's written english is somewhat to be desired, with the page littered with grammatical and spelling errors. From what you can discern, it was printed by the Vespasian Mercenary Company and distributed by *ahem* Da-Freebootaz-Squigalanche squad. \nA symbol of a winged serpent proudly crests the page. It's also seen to be worn by all the mercenaries in the etchings too...", false, "unread");
            List<Item> otherBookcaseItems = new List<Item> { bookEC1, bookEC2, bookEC3, bookEC4};
            /// 
            /// armoury features
            Item circleDoorKey = new Item("brass key", "It's a filigreed but tarnished key that presumably opens something...");
            Item lockpickingSet = new Item("lockpicking set", "With a long thin blade and a pin, all kinds of new opportunities open themselves to you...", false, "unbroken");
            List<Dice> stilettoDamage = new List<Dice> { D3, D3, D3};
            List<Dice> bastardswordDamage = new List<Dice> { D6, D6};
            Weapon estoc = new Weapon("estoc", "It looks like a sword, its built like a sword, but its a spear. Don't ask...", bastardswordDamage, defaultCritHits, defaultGoodHits, 0, false);
            Weapon bastardSword = new Weapon("bastard sword", "The one and half handed sword glints with singular purpose. Wielded with any proficiency this blade would be formidable indeed.", bastardswordDamage, defaultCritHits, defaultGoodHits, 2, false);
            Weapon sai = new Weapon("sai-daggers", "They're oriental ninja weapons that, by the looks of the knocks they've received, have been used by anything other than ninjas - good ones anyway...", damage, defaultCritHits, defaultGoodHits, 1, false);
            Weapon axe = new Weapon("battle-axe", "It's a no-nonsense, true-to-its-purpose axe. If it can't cleave a goblin in two, it might at last give it something to think about...", damage1, defaultCritHits, defaultGoodHits, 1, false);
            Item throwingKnife = new Item("throwing knife", "Despite its humble appearance, it's well made, sharp, perfectly balanced and heavy enough to, I don't know, say... knock a weapon out of an enemy's hand...?", false, "unbroken");
            Item throwingKnife2 = new Item("throwing knife", "Despite its humble appearance, it's well made, sharp, perfectly balanced and heavy enough to, I don't know, say... knock a weapon out of an enemy's hand...?", false, "unbroken");
            Item throwingKnife3 = new Item("throwing knife", "Despite its humble appearance, it's well made, sharp, perfectly balanced and heavy enough to, I don't know, say... knock a weapon out of an enemy's hand...?", false, "unbroken");
            Weapon rustySword = new Weapon("rusty shortsword", "A tinge of rust traces the blade around the handle. It's been recently sharpened on a grindstone, but it probably still couldn't pierce a good set of armour worthy of the name.", damage1, defaultCritHits, defaultGoodHits);
            Weapon stiletto = new Weapon("stiletto blade", "This slender blade has a needle-like point that's sharper than a drill sergeant's tongue and a fox's wits and a bag of lemons and... \nWell, you get the idea.", stilettoDamage, defaultCritHits, defaultGoodHits, 1, false);
            Item bagOfCoins = new Item("bag of coins", "Most of the coins are scattered all over the table, with a few mounds forming the winnings of previous games. There is, however, a lovely large leather bag to stash them all in close by...", false, "unspent");
            List<Item> tableItems = new List<Item> { stiletto, bagOfCoins, circleDoorKey };
            List<Item> unlockedWeapons = new List<Item> { axe, estoc, bastardSword};
            List<Item> goodRackWeapons = new List<Item> { };
            List<Item> badRackWeapons = new List<Item> { rustySword, sai, throwingKnife};
            Feature gamblingTable = new Feature("sturdy table", "This table looks like it served a former life as a smithy's worktop with its iron plated corners, battered surface and hefty legs. It's since been used as a place to play gambling games with coins.", false, "unshattered", tableItems);
            Feature goodWeaponRack = new Feature("weapon rack", "Replete with weapons of all descriptions, their oiled and well-polished blades gleam at you.\nIt's a shame someone was foresighted enough to lock them all behind an enchanted glass panel...", true, "locked", goodRackWeapons);
            Feature worseWeaponRack = new Feature("weapon rack", "Haphazardly heaped upon it are a motley assortment of rusty implements that might on a good day be described as weapons. These appear to be the ones the mercenaries had access to.", false, "unshattered", badRackWeapons);
            Item bookA1 = new Item("book on cursed weapons", "It's a surprisingly well-kept book with the cover and pages still perfectly intact. (You expect its because few of the creatures hired as mercenaries here are avid readers). It's entitled, 'Upon ye subject of cur'sed weapons and their bless'ed destruction", false, "unread");//like with door, in pickupItem() if Name contains ' book ' then start linear dialogue, player can choose to turn to next page or leave.
            Item bookA2 = new Item("book on the history of curses", "It's an encyclopedic and thorough rendition of all the most notable curses that've arisen and passed through the known world over many centuries. It seems to have been a work in progress because the last hundred or so pages are left blank. You notice an embossed M within a G inside the front cover.", false, "unread");
            Item bookA3 = new Item("book on Fey realms and magicks", "Its a book smaller than most with elooquent script, flowing prose and fanciful descriptions that entice and excite the imagination. Its words are so gripping in fact that you wonder if their lure and speciousness isn't a form of magic itself. It's almost as if the book wants you to fall through its pages into another world...", false, "unread");
            List<Item> armouryBookcaseItems = new List<Item> { bookA1, bookA2, bookA3};
            Feature armouryBookcase = new Feature("bookcase", "A rosewood bookcase that seems to have been left behind from when this place was something other than an armoury (a library perhaps). It is still stocked with books.", false, "unshattered", armouryBookcaseItems);
            Feature normalBrazier = new Feature("fiery brazier", "Unlike the braziers in your former cell and downstairs, this one's fire radiates warmth and its soft flickering flame casts an altogether more natural light about the room", true, "lit");
            List<Feature> armouryFeatures = new List<Feature> {gamblingTable, goodWeaponRack, normalBrazier, worseWeaponRack, armouryBookcase, armouryDoor };
            Item throwingKnife1 = new Item("broken throwing knife", "It's blade has been detached from the handle. Either its been tossed aside or else someone couldn't be bothered fixing it.", false, "unfixed");
            Item clunkySabaton = new Item("sabatons", "scattered throughout the room along with other pieces of clunky armour are these armoured footwear. Spiked and brutal, you nevertheless sense they wouldn't fit you...", false, "undamaged");
            Item breastplate = new Item("breastplates", "They come in all shapes and sizes, but none that fit you it seems...", false, "undamaged");
            Item helmet = new Item ("helmets", "They're a bit tight around the... everything. Besides who wants their sight restricted by a visor anyway?", false, "undamaged");
            Item bracers = new Item("bracers", "fitting snugly around the arm, these might actually offer some much needed protection, and make you look good in the process.", false, "undamaged");
            List<Item> armouryItems = new List<Item> { throwingKnife1, clunkySabaton, breastplate, bracers, helmet };
            /// 
            ///emptyCell features
            Feature otherBookcase = new Feature("bookcase", "Unlike the bookcase in your former cell, this one is replete with a few leather-bound books and journals and its shelves are mostly intact.", false, "unshattered", otherBookcaseItems);
            
            // I instantiate a room with a list of items and features inside it and a description and room name
            List<Feature> cellfeatures = new List<Feature> { rosewoodDoor, rosewoodChest, bookCase, skeleton, leftbrazier, rightbrazier };
            List<Item> corridorItems = new List<Item> ();
            List<Feature> corridorFeatures = new List<Feature> { stairwayToLower, leftbrazier, rosewoodDoor, otherRosewoodDoor, rightbrazier, emptyCellDoor, anotherBrazier, stairwayToUpper };
            List<Feature> antechamberFeatures = new List<Feature> { stairwayToUpper, pillar, plaque, armouryDoor, pillar, mosaic, circleDoor};
            List<Item> antechamberItems = new List<Item>();
            List<Item> emptyCellItems = new List<Item> { garment, rustyChains, bobbyPins, redThread};
            List<Feature> emptyCellFeatures = new List<Feature> { leftbrazier, emptyCellDoor, rightbrazier, otherBookcase};
            ///
            ///mess hall features and items
            Item messhallBook1 = new Item("The Rogue's Pocketbook", "A rather handy guide to the illicit - *ahem*, excuse me - to the skilled art of pickpocketing, conning, disguises and lockpicking.", false, "unread");
            Item noteForJanitor = new Item("note for janitor", "Found nailed to the pantry door, the note is evidently not recently penned, but has rather, judging from the food stains and soggy texture, been up upon this door for sometime.\n There are notches hewn out of the door, as though the goblins and mercenaries had used it for target practice. \nIt reads, \n\n\tDearest Mungo, I must say that your inability to keep track of the items pertaining to your duties as custodian of my home, is becoming vexing. Keys are quite expensive to duplicate, especially the enchanted copper ones that open every cabinet and door in my home, and i simply can't be doing it every time you lose one of them! I've half a mind to just build another golem and have that do the cleaning, save for the fact that my golems have yet to master the subtle difference between opening doors and crashing through the walls next to them. While I work on instructing them of one or two of the finer points of... shall we say, manoeuvring through  polite society, perhaps you might be so kind as to not lose any more of my keys. \nP.S. And FYI I've enchanted this note so even *you* can't accidentally-on-purpose lose it... [the letter trails off into a smudged scrawl blotted out by food stains]", false, "unread");
            Item chickenBone = new Item("chicken bone", "They scatter the cobbled floor between benches. This one in particular has been well gnawed...");
            Item plate = new Item("plate", "Some shattered into pieces, others merely chipped a lot, they litter the floor. It looks like they were used as missiles during a riotous brawl.");
            Item fork = new Item("fork", "A utensil that hasn't seen much use amongst the motley recruits of the CurseBreaker's private army.");
            Item knife = new Item("knife", "A utensil that has seen much use amongst the mercenary rogues of the CurseBreaker's private army. Though rarely as intended...");
            Feature bench = new Feature("bench", "They clutter the floor. Some have been used as barricades during a food fight.", false, "unshattered");
            Feature diningTable = new Feature("table", "Looking around you can see some tables with the telltale markings of hand roulette, others with muddy bootprints. One has been smashed to smithereens.", false, "unshattered... mostly.");
            List<Item> dinnerTableItems = new List<Item> {knife, plate, messhallBook1 };
            Feature diningTable1 = new Feature("table", "Over in the far corner, this table seems to have been used by one of the more studious mercenaries of the CurseBreaker's army. A book of some description is sprawled open upon its surface. By the look of its dogeared pages, it's been well read...", false, "unshattered", dinnerTableItems);
            Item knifeMG = new Item("knife", "A utensil that has seen... wait, are they the letters 'M' and 'G' embossed in gold upon its rosewood handle?\n Huh...", false, "unbroken");
            List<Item> messHallItems = new List<Item> {chickenBone,knife, plate, fork, plate, knife, chickenBone, plate, knifeMG, fork };
            
            List<Feature> messHallFeatures = new List<Feature> { messHallDoor, bench, diningTable, bench, diningTable, diningTable1, bench, bench, diningTable};
            ///The above is for letting the player know that they can combine the bobby pin and the stiletto and that they can use the soot or warpaint to form a disguise
            ///
            /// The dragon lair
            Feature stalagmite = new Feature("stalagmite", "Like a Myrovian steeple in miniature it rises from the ground - a common feature of any self respecting cavern anywhere...", false, "unbroken");
            Feature stalactite = new Feature("stalactite", "The stalactites, unlike stalagmites, hang from the ceiling like tights - get it? Like crusty, craggy, solid, splatter-you-if-they-drop-on-your-head-in-an-earthquake tights...", false, "unbroken");
            Item ruby = new Item("fist-sized ruby", "Which kingdom should you buy first?", false, "unblemished");
            Item sapphire = new Item("dazzling sapphire", "Would you like to buy a private island? Two?", false, "unblemished");
            Item emerald = new Item("lustrous emerald", "More valuable than any other Northern Rock, even ones that don't crash economies...", false, "unblemished");
            Item goldDoubloon = new Item("gold doubloon", "~I'm in the money! \nI'm in the money! \nSpend it, \n\tLend it, \n\t\tSend it,\nRolling along!~");
            Item silverBars = new Item("silver bars", "Freshly minted and stamped, there's enough here to buy a mercenary horde, let alone an army...");
            List<Item> goldDragonItems = new List<Item> {goldDoubloon, silverBars, emerald, sapphire, ruby };
            List<Dice> dragonpocalypse = new List<Dice> {D6, D6, D6, D6, D6, D6, D6, D6, D6, D6, D6, D6, D6, D6, D6, D6, D6,D6, D6, D6 };
            Feature goldMountains = new Feature("golden mountain", "The common-man's crude rebuttal to ontological philosophers everywhere - if he's fabulously wealthy, that is...", false, "untouched", goldDragonItems);
            Feature lake = new Feature("underwater lake", "beneath its surface lies endless jewels and gold doubloons the size of pebbles! You feel like raking them with your fingertips and tossing them in the air around you...", false, "untouched", goldDragonItems);
            Weapon flameThrower = new Weapon("talons, tail, claws, teeth and fiery breath", "Nuh-uh! If you're reading this you cheated...", dragonpocalypse, defaultCritHits, defaultGoodHits, 20);
            Monster goldDragon = new Monster("golden dragon", "Ohhhhhhh... drat!", goldDragonItems, 999999999, 50, flameThrower);
            List<Feature> goldDragonFeatures = new List<Feature> {lake, goldMountains, stalactite, stalagmite, goldMountains };
            

            /// The Magical Manufactory Items and Features
            Feature copperPipes = new Feature("whistling pipes", "They rattle and shake and bounce up and down in an excitable fashion, dribbling alchemical residue amidst jets of steam.");
            Feature brassTanks = new Feature("brass tanks", "They have porthole windows bolted into their sides through which you see chains of bubbles endlessly cascade upwards through some gloopy concoction or other...");
            Feature conveyorBelts = new Feature("conveyor belts", "They form a web of pure steampunkery, rattling overhead and spanning from brass tanks to spurting pipes to the next clunky clockwork mechanism, carrying potions galore before spiralling in on some kind of magic portal to distant planes.");
            Door merigoldPortal = new Door("magic portal", "It crackles and sparks with unstable magical force. It's so large you can peer through it from where you're stood, your gaze encountering distant landscapes, foreign wonders, exotic lands and the armies of the CurseBreaker, all visions flitting from one to the next - a different delivery point for each order of elixirs...", true, "blocked", null, null, "Placing your trust in Merigold's dubious calculations and whatever magic he can muster, you take a deep breath and plunge through the swirling vortex of chaotic energy...");
            Feature teslaCoil = new Feature("tesla coil", "Crackling and sparking with tame lightning you wonder if they power this whole th- youch! You shake off the jolt you received, your zapped finger smarting. Best steer clear of that thing...");
            Feature magicalBookcase = new Feature("magic bookcase", "You can scarcely grab a book from its shelves before the entire edifice whisks up at alarming speed, more shelves rising from through the floor, and books fly from the shelves, flapping their way to the wizard at the manufactory's centre; the conductor to this mad orchestra of glooping pipes and whirling cacophony.");
            Item crumpledMissive = new Item("crumpled missives", "Littering the ground, they still seem to try and flap their way around with crumpled dishevelled page-wings. It seems they were erroneous orders...");
            Item emptyBottles = new Item("empty bottles", "stacked for the conveyer belts to shuttle away, they are waiting to be filled with any number of ointments, elixirs and potions...");
            Feature worktop = new Feature("laboratory", " Aisles of haphazardly arranged worktops, replete with conical flasks, distillation tubes, alchemical devices and round-bottom retorts bubbling with strange essences form a mismanaged maze of meticulous mayhem, presided over by a lone elderly figure in loose fitting wizardly attire, ostensibly too busy to notice your presence...", false, "unapproached");
            Item cork = new Item("stoppers", "across the floor cork stoppers are strewn here and there, a spillage from one of the many crates it seems...");
            
            
            
            /// Secret Chamber Items and features
            List<Dice> whacking = new List<Dice> { D4 };
            Weapon staffMG = new Weapon("Marvellous Merigold's Magical Staff of Whacking", "It is a very fine, very well polished rosewood quarterstaff with the letters 'M' and 'G' cursively and elegantly embossed in gold upon it. It seems to shimmer with some kind of force for a moment, but when your eye catches it properly you conclude you were maybe imagining it... ", whacking, defaultCritHits, defaultGoodHits, 0, false);
            List<Item> prometheusList = new List<Item> {staffMG };
            Feature prometheus = new Feature("disturbing statue", "Even up close and in better light this statue would be unsettling. You wonder what on earth it could mean, and why anyone would wish to procure it, though you don't ponder too long on why the ghastly thing was stowed away out of sight. Amongst the eclectic items here it is the most prominent in its sinister aspect.\nYou're about to turn away when, just behind the statue, you spy something else...", false, "unshattered", prometheusList);
            Feature plaquePrometheus = new Feature("plaque", "At the base of the statue, it reads, \n\n\t'Dedicated to the ancient God who brought fire unto man. Punished eternally for his gift, his foresight and the succour he provided'...\n\nScratched in a spidery scrawl underneath, someone clearly saw fit to add their own addendum: 'What Justice is there from gods? From nature? But that which is created by force'...", false, "unread");
            Feature portrait = new Feature("diabolic portrait", "The description upon the frame tells of the subject's name and deed; 'Azazel; who gifted war to humanity'\n\n\tYou're about to pull away when you notice someone has etched a message upon the frame. As your fingers trace it, helping you decipher the letters in the dark, you sense its acerbic tone; 'A generous gift for those that grasp it - The source for infinite revenues for sellswords, mercenaries and adventurers alike'...", false, "unexamined");
            Door mosaic2 = new Door("strange mosaic", "You glance the mosaic's way, its lustrous tiles are constantly flipping and shuffling like cards in the dextrous hands of some invisible dealer. The magical image they form is ever shifting. They seem to react to your presence.", true, "unexamined", null, new List<Room>());
            Feature northWall = new Feature("wall", "It's just a bare wall. You can search all you want but there are no secret passages to be found...", false, "unremarkable");
            Feature southWall = new Feature("wall", "It's just a bare wall. There will never be a door or window here no matter how hard you search...", false, "unremarkable");
            Feature eastWall = new Feature("wall", "It's just a bare wall. No opening, no way through, not even a single loose brick...", false, "unremarkable");
            Feature westWall = new Feature("wall", "It's just a bare wall. There's an awful lot of wall here and its pretty darn solid...", false, "unremarkable");
            Item crystalBall = new Item("crystal ball", "shadows lurk and shift inside like vapours whisked by the eddies of time. The misty glass ball, by its very mystical aspect, promises and invites your gaze to settle on what once was, what transpires, and what may yet come to pass...", false, "unexamined");
            Item bookSC1 = new Item("Majesty of the Eldritch Fey", "A self proclaimed traveller to the Faerie Kingdoms recounts their experiences in this strange tome...", false, "unread");
            Item bookSC2 = new Item("Topics Infernal", "An illustrated rendition of the nine circles of Hell and the infernal city of Dis lay within.", false, "unread");
            Item bookSC3 = new Item("Paradise Lost", "The apotheosis of all tales that tell of pride, rebellion and a fall from grace. A quote is penned in the margins of the page you opened it at; '...for the mind is itself a place, and can make a heaven out of hell, a hell out of heaven...'", false, "unread");
            Item jar = new Item("assorted jars", "They contain all sorts of ingredients that sorcerers presumably everywhere need, from pig trotters, to chiropteric (that means bat-like) wings.", false);
            Item brassTrinket = new Item("wizardly gizmo", "A whirling artefact of brass cogs and spinning gyroscopes. No matter how long you study it, you cannot divine its purpose...");
            Item copperTrinket = new Item("sorcerous gadget", "It's a copper sphere with dials and intricate tiny levers. You put it down before your fumbling hands cause it to... uh, do whatever it is it's designed to do.");
            List<Item> bookcaseSCItems = new List<Item> {bookSC2, bookSC1, bookSC3 };
            Feature bookcaseSC = new Feature("bookcase", "Judging from the grain and fine burnished finish, this bookcase is elegantly crafted rosewood and feels warm to the touch even within this chilly room. It is replete with books.", false, "unshattered", bookcaseSCItems);
            
            List<Item> secretChamberItems = new List<Item> { crystalBall, jar, brassTrinket, copperTrinket};
            List<Feature> secretChamberFeatures = new List<Feature> { holeInCeiling, northWall, prometheus, plaquePrometheus, westWall, bookcaseSC, southWall, portrait, mosaic2, eastWall };

            /// 
            /// Broom Closet Items and features
            
            List<Item> bucketItems = new List<Item> ();
            Feature bucket = new Feature("bucket", "The muddy hue of the water sloshing inside makes you wonder if much cleaning could be done with this...", false, "unbroken", bucketItems);
            Item mops = new Item("mop", "The bane of dirty floors everywhere...");
            Item brooms = new Item("broom", "Unlike other famous brooms in sorcerors' abodes, this one seems remarkably unmagical...");
            Item dustpans = new Item("dustpan", "Helps janitors and maids collect dust so, like all decent custodians, they can hide it where it can't be seen...");
            Item dusters = new Item("feather duster", "You wonder if your enemies are ticklish... No, nevermind...");
            Feature shelves = new Feature("shelf", "It's jampacked with exciting janitorial stuff. Seems the mercenaries weren't too bothered about ransacking any of this miscellanea...", false, "unshattered");
            List<Item> broomClosetItems = new List<Item> {dusters, dustpans, brooms, mops };
            List<Feature> broomClosetFeatures = new List<Feature> { broomClosetDoor, shelves, shelves, shelves, bucket};
            ///DungeonChamber Items and features
            Item femur = new Item("femur", "Upon closer inspection you find teeth marks denting the bone's length...", false);
            Item jawBone = new Item("jaw bone", "This bone is of disquietingly human origin - and is warm...", false);
            Item legBone = new Item("leg bone", "It's been gnawed until, in some places, whittled to the very marrow...", false);
            Item rib = new Item("rib", "It's not much of a find...", false);
            Door hatch = new Door("trapdoor", "It is constructed out of dwarven steel. Your hands trace the craftsmanship. However, you notice no bolts or locks keeping it shut. It's free to open - should you choose to go down it...", false, "unlocked", null, null, "You heft the heavy trapdoor open, it's clanging on the granite floor reverberating eerily within the silence. Before you lies a gaping hole of unfathomable depths; only darkness seems to lurk beneath your feet, along with an unsettling stillness that almost invites you to sink within its depths. The noise continues to reverberate as you brace against a chill whisked up from somewhere behind the darkness. \nThere's a ladder. With trepidation gnawing at your gut, you follow it down...");
            Feature aBrazier = new Feature("brazier", "If this brazier does indeed burn it is not with any normal fire. Upon closer inspection, its dim flickering glow seemingly cannot be expunged. It barely keeps the looming shadows at bay.", true, "lit", null);
            List<Item>dungeonItems = new List<Item> { femur, jawBone, legBone, rib};
            List<Feature>dungeonFeatures = new List<Feature> {stairwayToLower, aBrazier, hatch};
            Item pocketWatch = new Item("gold pocket watch", "Replete with filigree letters M and G artfully crafted inside the gleaming lid, someone somewhere must've been sorry to lose it...");
            ///
            ///SouthCorridor Items and Features
            Item box = new Item("box embossed MG", "It's a burnished rosewood box, well crafted, with golden letters M and G embossed upon the lid. Opening it, you find nothing inside.", false);
            List<Item> windowItems = new List<Item> { box};
            Feature window = new Feature("palladian window", "Through this grand window you survey a vast mountain landscape adorned with a gossamer shawl of moonlit mist. You can just see, nestled in a valley far below, the steepled rooftops of Myrovia. The full moon hangs high in the starless night sky above the huddled buildings. Moonbeams imbue the diaphanous curtains either side of you with an eerily spectral aspect, leading you to almost miss the side table concealed behind them and the delicate, opulent box stood upon it.", false, "unopened", windowItems);
            Door southeastCorner = new Door("southeastern corner", "The corner turns sharply left...", false, "unblocked", null, null, "You follow the corner around and into the easternmost corridor.");
            Door southwestCorner = new Door("southwestern corner", "The corner turns sharply right...", false, "unblocked", null, null, "You follow the corner around and into the westernmost corridor.");
            Item lantern = new Item("lantern", "It's glow radiates a soothing warmth that seems out of place here.", true, "lit");
            List<Item> alcoveItems = new List<Item> { lantern };
            Feature alcove = new Feature("alcove", "Within this alcove a lantern burns softly. Hanging within its depths you discover that you can remove the lantern if you wish. It radiates warmth", true, "filled", alcoveItems);
            List<Feature> southCorridorFeatures = new List<Feature> { southeastCorner, alcove, window, alcove, southwestCorner};
            Item rug = new Item("rug", "Several plush rugs span the hardwood floor of this corridor. They are replete with intricate patterns woven into their soft fabric. Your footsteps soften to a murmur as you step over them.", false, "unburned");
            Item splinter = new Item("wood shard", "It's decorative art-deco edge seems to indicate this belonged to part of a picture frame - one of the ones no longer hung upon these corridor walls. When these halls were ransacked all the frames must have been broken apart to get to the pictures because you spot more shards from where you are.");
            Item looseNail = new Item("loose nail", "It probably once had a painting hung from it upon the rather bare walls.");
            Item dustBunny = new Item("dust bunny", "Least cute of all the bunnys... with the possible exception of that one bunny feared by Tim the Enchanter.");
            Item penny = new Item("loose change", "You found yourself a lucky penny!");
            Item crumbs = new Item("crumbs", "The careless remains of someone's meal, these crumbs pepper the floor here and there...");
            List<Item> southCorridorItems = new List<Item> {splinter, rug, looseNail, penny, crumbs, dustBunny};
            
            ///magical manufactory lists
            List<Item> magicalManufactoryItems = new List<Item> { crumpledMissive, emptyBottles, cork, penny };
            List<Feature> magicalManufactoryFeatures = new List<Feature> { magManDoor, copperPipes, brassTanks, conveyorBelts, merigoldPortal, teslaCoil, magicalBookcase, worktop };
            ///
            /// NorthCorridor Items and Features
            Door northeastCorner = new Door("northeastern corner", "The corner turns sharply right...", false, "unblocked", null, null, "You follow the corner around and into the easternmost corridor.");
            Door northwestCorner = new Door("northwestern corner", "The corner turns sharply left...", false, "unblocked", null, null, "You follow the corner around and into the westernmost corridor.");
            List<Feature> northCorridorFeatures = new List<Feature> {northwestCorner, alcove, broomClosetDoor, magManDoor, alcove, northeastCorner };
            List<Item> northCorridorItems = new List<Item> { splinter, looseNail, penny, crumbs, dustBunny };
            ///
            /// West Corridor Items and Features
            List<Feature> westCorridorFeatures = new List<Feature> {northwestCorner, alcove, circleDoor, alcove, southwestCorner };
            List<Item> westCorridorItems = new List<Item> { splinter, looseNail, penny, crumbs, dustBunny };

            ///
            /// East corridor
            List<Feature> eastCorridorFeatures = new List<Feature> {northeastCorner, alcove, messHallDoor, alcove, southeastCorner };
            List<Item> eastCorridorItems = new List<Item> { splinter, looseNail, penny, crumbs, dustBunny };
            Item merigoldBroach = new Item("broach embossed MG", "There's a shimmer to it that draws the eye, but the moment your gaze focuses on it the shimmer is gone and you are left looking at an altogether unprepossessing broach.");
            Item merigoldMedallion = new Item("medallion embossed MG", "The medallion catches the light as you examine itt. It looks utterly worthless to your untrained eyes.");
            Item bracelet = new Item("Bracelet embossed MG", "It's a curious item to find, especially in such a place as this. It seems to shimmer with an energy beyond your understanding or ability to unlock.", false);
            Item belt = new Item("belt", "It's been made with corinthian leather. It seems altogether too affluent an effect to find upon these mercenaries. You find the letters M and G fashioned upon the gold buckle.");
            Item diadem = new Item("fancy diadem", "It's encrusted with diamonds, peppered with pearls and... hey, is that an M and G engraved on the back?");
            Item armBand = new Item("golden armband", "It's rather garish and flashy, especially with that large M and G fashioned upon it. You don't think you'll be wearing it anytime soon, even if it is solid gold...");


            List<Dice> fistDamage = new List<Dice> { D2, D2, D3 };
            Weapon fists = new Weapon("fists", "", fistDamage, defaultCritHits, defaultGoodHits, 0);

            //Highest Parapet
            Feature crystalTotem1 = new Feature("totem of shielding", "A knot of gnarled roots in the shape of a large hand clutches a gem that exudes waves of magic with its pulsating glow. Summoned through some confluence of sinister magic and Fey sorcery, it creates a protective shield about the caster and dampens any harm that might befall them...", false, "unshattered", 3);
            Feature crystalTotem2 = new Feature("totem of invincibility", "Gnarled roots extend through the flagstones in the form of a fist, clasping a gem that makes the air around it shimmer with magic. Summoned through some confluence of dark necromancy and Fey magicks, it conspires to reduce all incoming damage for its caster...", false, "unshattered", 3);
            Feature crystalTotem3 = new Feature("totem of invulnerability", "A writhing tangle of roots stretch from the cracked flagstones in the shape of a fist. Within, a strange ethereal gem pulses with light, casting a protective shield about the summoner, which absorbs most incoming damage...", false, "unshattered", 3);
            Feature crenellations = new Feature("crenellations", "Over the towertop's low battlements you survey a moonlit valley and in the distance the spires of Myrovia...", true, "imposing");
            Item brokenFlagstone = new Item("broken flagstone", "Many of the flagstones are cracked and broken. The rest have been worn down over the centuries...");
            Item crackedFlagstone = new Item("cracked flagstone", "Many of the flagstones are cracked and broken. The rest have been worn down over the centuries...");
            Item shatteredFlagstone = new Item("shattered flagstone", "Many of the flagstones are cracked and broken. The rest have been worn down over the centuries...");
            Item flagstoneShards = new Item("flagstone shards", "Sharp and heavy, they look so very throwable...");
            List<Feature> highestParapetFeatures = new List<Feature> {crenellations, crystalTotem1, crystalTotem2, crystalTotem3};
            List<Item> highestParapetItems = new List<Item> {brokenFlagstone, crackedFlagstone, flagstoneShards, shatteredFlagstone };
            List<Dice> sabreDamage = new List<Dice> {D3, D3, D2, D2 };
            Dice D7 = new Dice(7);
            List<Dice> chainLightning = new List<Dice> {D7, D7 };
            Weapon cursedGloves = new Weapon("gloves of tempest", "Cursed gloves that crackle with tame lightning, the curseBreaker uses them to direct chain lightning at those who displease him...", chainLightning, sizzleCrits, sizzleCrits, -1);
            Weapon sabre = new Weapon("sabre", "Light but deadly-sharp, it slices the air like silk.", sabreDamage, sabreCrits, sabreGoodHits, 2);
            Weapon stiletto1 = new Weapon("stiletto blade", "This slender blade has a needle-like point that's sharper than a drill sergeant's tongue and a fox's wits and a bag of lemons and... \nWell, you get the idea.", stilettoDamage, stilettoCrits, stilettoCrits, 1, false);
            List<Item> CurseBreakerPockets = new List<Item> {sabre, goldDoubloon, ruby, cursedGloves};
            Monster CurseBreaker = new Monster("CurseBreaker", "You face before you a striking young man, aged beyond his years. He fixes you with unsettling black eyes that he stole from a fell creature. You sense them probe you for weaknesses as he flourishes a vicious sabre and wields an arcane glove crackling with cursed magic. The CurseBreaker, the would-be-architect of your doom, closes in for the kill...", CurseBreakerPockets, 100, 8, sabre);
            //Special Items
            List<Item> throwables = new List<Item> {armBand, clunkySabaton, bracers, helmet, breastplate, knifeMG, musicBox, mops, brooms, emptyBottles, bookA1, bookA2, bookA3, bookEC1, bookEC2, bookSC1, bookSC2, bookSC3, messhallBook1, journal, binkySkull, box, belt, lantern, femur, legBone, rib, crystalBall, brassTrinket, copperTrinket, jar, plate, bowl, throwingKnife, throwingKnife2, throwingKnife3  };
            List<Item> stickyItems = new List<Item> { bowlFragments, garment, bobbyPins, clunkySabaton, breastplate, helmet, bracers, splinter, rug, looseNail, penny, crumbs, dustBunny, mops, dusters, brooms, dustpans, crumpledMissive, emptyBottles, cork, ruby, emerald, sapphire, goldDoubloon, silverBars };
            List<Item> specialItems = new List<Item> { musicBox, binkySkull, steelKey, note, jailorKeys, lockpickingSet, bookA1, journal, fists, stiletto1 };
            List<Item> MGItems = new List<Item> { knifeMG, staffMG, merigoldRing, pocketWatch, bracelet, merigoldMedallion, merigoldBroach, belt, diadem, armBand, box, bookA2 };

            ///Rooms
            Room room = new Room("dank cell", "The foreboding cell is bathed in the earthy glow of lit braziers, barely lighting cold stony walls, a heavy rosewood door studded with iron hinges, and only the sparsest of furnishings.\nThe door is set within the north wall, two flickering braziers casting orbs of low light either side of it so as to look like great fiery eyes watching you from the murk.\t\nTo the west wall there is a large chest, mingled with a cascade of rusted and disused iron shackles.\t\nTo the south wall is a small bookcase and some garments haphazardly strewn about you.\t\nTo the east wall is the last occupant; a skeleton with a permanent grin, bound fast to the wall by many interlocking heavy chains. It almost seems to watch you from dark wells where once there were its eyes. It holds something in its bony fist and something else glimmers from a place out of reach behind it.\t\t", cellInventory, cellfeatures);
            Room corridor = new Room("long corridor", "More of those strange braziers cast pools of frosty light within the dark corridor. Here and there they alleviate the murk within the passage of grim stone walls and rickety floorboards. It extends to the left into darkness and to the right towards a wide flight of stone stairs. \nTo the north you face another door similar to the ornate rosewood door behind you.\t\nTurning your gaze west down the shadowy passage you see the flickering braziers leading towards a dark stairwell, descending beyond the inky blackness to unknown depths.\t\nTurning your head south the ornate rosewood door to your own former cell meets your gaze.\t\nTo the east the passageway leads past more doors up to a flight of stairs, ascending to the next level of whatever building or (tower?) you find yourself in.\t\t", corridorItems, corridorFeatures);
            Room cellOpposite = new Room("eerie cell", "There are scratch marks on the inside of the rosewood door leading into this cell. Whoever was here was dragged out and taken Lord only knows where. \nAhead of you is a bare stone wall, a bowl left close by. A kind of nest has been formed out of the strewn garments - clearly where the last occupant had rested. They're still warm...\t\nYou find little of note save for a clumsy attempt to craft crude levers out of the wooden planks of the floor. You guess they were used to slip under the gap in the door and lever it out of its iron pin hinges. Judging by the snapped and splintered planks of wood around you, the attempt failed.\t\nTurning your gaze southwards you see the door through which you entered. Like your room there are braziers either side of it, but they've been bent out of shape, their unnatural frosty flames extinguished.\t\nLooking to the east wall you find a trunk made of coarse leather hide and a wooden frame.\t\t", cell2Inventory, cell2features);
            Room antechamber = new Room("antechamber", "The prodigious antechamber you now find yourself in is an architectural marvel of sweeping stone arches and a vaulted ceiling. For a few moments the sight of its extravagance, so vastly different from your previous surroundings, takes your breath away.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t", antechamberItems, antechamberFeatures);
            Room oubliette = new Room("oubliette", "You find yourself within a chamber darker than any you've come across before. It's sole faint light comes from arcane and esoteric runes, imbued with some enchanted pale blue glow. They luminate the place like distant dying stars, scrawled along a vaulted ceiling, the far walls and trailing away from you in all directions across the unnaturally cold ground. Feathers of frost fill the air in front of you with every exhale, as you begin to shiver from the cold. Suddenly, you hear something clang above you, but all you can see as your gaze darts to the ceiling are more runes. You realise that you're sealed in here with no way out...\nTo the north you notice the runes wend their way in geometric patterns and arcs towards a distant wall where their snaking paths continue upwards as though the entire room were bound in some bewitching ribbons of indecipherable symbols.\t\nYour gaze turns left, where you notice a vast portal of crackling arcane energy. The ribbons of runes trailing through this whole place feed into this vortex, where a rupture in the very space around it permits a glimpse of a terrible storm, jagged crenulations of a dark towertop and a lone silhouette braced, unfeeling, against howling wind, and biting sleet. They face away from you, seemingly beseeching  the full moon with disquieting incantations and dark utterances...\t\nTurning around you spy a ladder leading to some hatch above, but as you step towards it the rungs seem to drift farther and farther apart as though part of some optical illusion. The ladder is impossible to climb, warped by some magical anomaly that escapes your understanding.\t\nGazing to the right lies more of those runic ribbons of enchantment binding the room in great geometric arcs, they seem to spiral in on some distant pentagram, but it's too dark to see anything further...\t\t ", cellInventory, cellfeatures);
            Room emptyCell = new Room("empty cell", "Upon entering this cell you find scratch marks around the lock. The enchanted braziers cast everything in a shimmering ethereal glow, as though the light were reaching this room through some alien ocean or the underside of a glacier\nAhead of you are more garments strewn haphazardly about. Some of them have been piled against the wall, almost as though to form something to sit on.\t\nTurning your gaze left you espy more rusty chains, along with a bookcase that - like the one in your old cell - looks like its seen better days.\t\nFacing the rosewood door you came through you notice bobby pins litter the floor. They must've been something the previous occupant had brought here with them. It looks like they were used to try and unlock the door.\t\nTo the east, just peeping from under the garments, you notice a ball of red thread. It seems to have been collected by the last occupant but you've no idea what for.\t\t", emptyCellItems, emptyCellFeatures);
            Room armoury = new Room("armoury", "The instant you step inside you are greeted with a startled gnoll and goblin. Coins clatter to the table they're gathered around as they stare at you, surrounded by weapon racks and other decidedly sharp furnishings. Your presence has caused them to pause their boisterous clamouring mid-game of coins... It seems you've intruded upon a private party. Their stunned silence has yet to change into hostility, but it won't be long before it does...\nThe high walls of the 'RmorRee' extend to a vaulted ceiling and appear to have been stripped of many ladders and shelves judging by the bare patches and splintered wood panels left behind. The north wall in particular is one of the few that betrays what this room might've been before its spartan refurbishment; a rosewood bookcase, replete with tomes, greets your gaze directly ahead.\t\nThe west wall to your left is where the table is situated where the gnoll and goblin played their game of coins.\t\nFacing south you find the door you just passed through.\t\nTo your right, gazing east, you see racks fully stocked with weapons and armour.\t\t", armouryItems, armouryFeatures);
            Room messHall = new Room("mess hall", "The vast hall seems to have lived a former life as the servants cafeteria, replete with benches and a communal space for dining. It has since been transformed into a mess hall where the CurseBreaker's private army sates their gluttony and engages in regular bouts of fisticuffs and food fights. Mashed potato has spattered areas of the wall for so long that it has almost ossified. The tables are a raucous assemblage far from the neat aisles you presume they once formed. Meanwhile, you spot the open kitchen has been left in dire need of cleaning with pots and pans strewn over the floor, some sort of gruel congealing within.\nTo the north you can see the open kitchen area behind a counter. The oven is an oldfashioned copper burner, though its been dented somewhat by beer swilling pugilists.\t\nTo the west you can see the through which you entered. From this side it's been studded with knives, seemingly having been aimed at a note that's been nailed there.\t\nTo the south you espy most of the horrendously dishevelled dining area. Bones scatter the cobbled floor from previous feasts. \t\nTo the east you see the far table has an open book one of the mercenaries must've been reading through.\t\t", messHallItems, messHallFeatures);
            Room circularLanding = new Room("circular landing", "~minor tour antics~", cell2Inventory, cell2features);
            Room magicalManufactory = new Room("magical manufactory", "The moment you clasp sight of what's beyond the door, you stare about you in stunned disbelief. The first thing that strikes you is the impossibility of the vast chamber's dimensions. You're striding within a vast manufactory of some kind, one so prodigious you can scarcely see the end of it, and yet the corridor you've been circling can't possibly have run around the exterior of this whole compound. Great brass pistons boom and pump some way off to your left, conveyor belts rattle overhead in all dizzying directions, notes imbued with strange blue tinted magic flutter about your head like pixies. You manage to grab one of them and discover that they are orders for the production of more formulas, elixirs and potions; '21 bottles of Merigold's finest healing potion for the west barracks, 39 vials of Felix Felicis for some place you've never heard of, 6 jugs of god knows what for yet another far off place...' The list is endless. You gaze about you at the churning clockwork machinery, the brass tanks bubbling, the copper tubes whistling steam, the general chaos of an enchanted lab run riot. And at the centre of it all, an aged bespectacled man with long wispy silver hair and an absently vexed if not wizardly demeanour has yet to notice your stumbling upon his solitude...\nLooking back north you find the door you passed through still in place. It seems to have locked itself the moment it closed behind you, but at least it hasn't been magicked away like you'd half expected...\t\nTurning west you look past a labyrinth of copper pipes and conical flasks to a distant wall replete with rosewood bookshelves and seemingly endless troves of tomes and books and journals. The many shelves trail away and out of sight towards a ceiling that seems more distant than any horizon.\t\nDirectly ahead of you, to the south, you espy more of those enchanted orders and missives fluttering about, appearing from one lone vast crackling magic portal spanning the far wall. These enchanted missives flying into the manufactory seem to circle and zero in on the wizardly figure at their centre, distracted as he mumbles to himself and causes various flasks and vials to erupt in puffs of technicolour smoke. You sense a certain air of dottiness about this man. \t\nTo the east your gaze settles on... uh, no, it can't. There's too much going on for it to settle on anything... You take in a Gordian knot of conveyer belts, then the whooshing missives flitting between them, then the general chaos of rumbling brass tanks with dials spinning out of control and jets of steam and books soaring back and forth from the shelves. They all agglomerate into some kind of orchestrated pandemonium, one whose symphony somehow transcends the din and discord and seamlessly, almost melodically, rises and resonates towards a crescendo of mad genius efficiency.\t\t", magicalManufactoryItems, magicalManufactoryFeatures);
            Room broomCloset = new Room("broom closet", "Your eyes clap sight of an Aladdin's cave of custodian conglomerations, janitorial jumbles and maidly menageries all agglomerated within a cosy 4 foot by 4 foot room. Somewhat ironically, it's a mess. \nYou see a broom.\t\nYou see another broom.\t\nCould that be another broom?\t\nanother br- oh, wait! That's a mop.\t\t", broomClosetItems, broomClosetFeatures);
            Room highestParapet = new Room("highest parapet", "\nTo the north you glance mountaintops looming in the distance, the full moon casting a pearly glow over the dark battlements and crenellations around you.\t\nTo the west stands the CurseBreaker. He slowly unsheathes a sabre with one of his gloved hands and surveys you with pitiless black eyes wreathed by ghastly veins. They writhe beneath his pale skin to his temples like a dark briar. About him are strange totems - gnarled and knotted roots extending out of the towertop in the shape of hands, each clutching some gemstone that casts a protective aura about him. Any incoming damage he faces will likely be reduced unless they're shattered first...\t\nTo the south you see no way back. You face the CurseBreaker alone.\t\nYou gaze up to find the storm centring and circling about the tower, the looming thunderheads brought down upon the parapet by the CurseBreaker's dark utterances...\t\t", highestParapetItems, highestParapetFeatures);
            Room hugeBarracks = new Room("huge barracks", "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...\n", cell2Inventory, cell2features);
            Room desertIsland = new Room("desert island", "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...\n", cell2Inventory, cell2features);
            Room bankVault = new Room("bank vault", "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...\n", cell2Inventory, cell2features);
            Room dragonLair = new Room("dragon's lair", "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...\nLooking up you discover vast dunes of glittering treasure all stored within some strange cave. Glowing crystals form stalactites hanging from the craggy ceiling, casting the gold around you in a chilly glow. Could Merigold have sent you to heaven?\t\nYou turn your gaze left and spy an underground lake and its glassy waters, gazing through it you find not a bedrock of silt or sand but more glittering gold coins, crowns and jewels. Could Merigold have brought you to every adventurer's most fervent dreamscape?\t\nYou swivel around, dazedly looking back at mountains of rubies and emeralds and sapphires and silver and... and... and... oh yes, thank you Merigold, thank you!\t\nWith a grin dawning upon your face and lighting it like the morning sun you delight in the sight of more gold and invaluable trinkets to the right of where you landed. Yippee!\t\t", goldDragonItems, goldDragonFeatures);
            Room secretChamber = new Room("secret chamber", "You clamber into an eerie chamber of disquieting shapes imposed upon velvety darkness; a dusky landscape of sinister contours and unknown threats alleviated only slightly from the faint moon-like glow of the strange braziers below. As your eyes adjust to your new surroundings, and you can begin to make out the statues and artefacts within, you feel a cold tot of anxiety tie knots in your stomach as you realise the secret chamber has no doors or windows. Instead, as you'll come to realise, you have stumbled upon a glimpse through a keyhole into the mind of the CurseBreaker. One no one was ever meant to see...\nFacing north is some kind of statue, or perhaps a shrine. Unlit candles are arranged beneath a marble figure. Normally they'd cast it in a fiery glow, but instead the braziers' light through the hole you climbed through toss angular and tortured shadows over the chiselled face of a man crying out in anguish for all eternity. Chained to a rock, an eagle eviscerates and devours his innards as his form, frozen in stone, screams silent screams. A plaque lays at its base, while you can just detect misty jars glinting to its left. \t\nTurning your gaze westward, and squinting your eyes, you can distinguish the shape of a bookcase from within the web of shadows. \t\n To the south you find a portrait hung upon the wall of a man with chiropteric wings. \t\nLooking eastwards you discover something that seems to rattle in the darkness. Investigating further, wading through an agglomeration of arcane baubles and esoteric devices stashed and long forgotten, you find the source of the ominous rattling is a mosaic. It's tiles flip and shuffle like playing cards in the dextrous hands of an invisible dealer. They finally settle on the image of a non-descript face, gazing down upon you...\t\t", secretChamberItems, secretChamberFeatures);
            Room prehistoricJungle = new Room("prehistoric jungle", "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...\n", cell2Inventory, cell2features);
            Room astralPlanes = new Room("astral planes", "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...\n", cell2Inventory, cell2features);
            Room oceanBottom = new Room("ocean bottom", "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...\n", cell2Inventory, cell2features );
            Room dungeonChamber = new Room("dungeon chamber", "The light of a single brazier casts an eerie glow over this claustrophobic, airless dungeon and its damp stone walls. Like the faint light reaching the fathomless depths of an ocean floor, it swims over scattered bones and barely illuminates twin hulking silhouettes lurking within shadow just beyond a solitary hatch leading somewhere deeper still. You feel the hairs on the back of your neck stand on end, as from somewhere within those shadows, chains clink and scrape along the granite floor...\nTurning your gaze right to look north you see the granite wall curve away from you and into blackness. It is studded with bolts that hold chains in place, most of which dangle limply to the stone floor below.\t\nDirectly ahead, some distance before the wall of darkness, lies a heavy trapdoor, presumably leading to an oubliette below. Scattered about it are assorted bones...\t\nTurning your gaze south and to the left you see a lone brazier, its lone orb of flickering frosty light the only thing alleviating the dank darkness besieging you.\t\nLooking back there is only the passageway you just descended...\t\t", dungeonItems, dungeonFeatures);
            Room mirrorWorld = new Room("mirror world", "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...\n", cell2Inventory, cell2features);
            Room westernmostCorridor = new Room("westernmost corridor", "You enter upon the westernmost corridor of the circular landing. Opposite the antechamber through the double doors is a bare rosewood panelled wall, interrupted on occasion by rosewood doors. The corridor leads north where it turns sharply right, or you can follow it south where it veers left at another corner. Guiding both paths are rows of lanterns, casting a febrile glow...\nTo the north you see the rosewood panelled corridor end at a corner leading right.\t\nTo the west you face a pair of double doors.\t\nTurning your gaze southward the corridor ends at a corner that veers left.\t\nFacing east you find nothing of note save a blank wall bereft of portraits and the litter left behind by those who looted them.\t\t", westCorridorItems, westCorridorFeatures);
            Room northernmostCorridor = new Room("north-facing corridor", "You enter upon the north-facing corridor of the circular landing. Before you, within the glow of the dim lanterns, are two rosewood doors opposite one another. The one in the north wall and another in the south wall leading within the room you must have been circling. The corridor leads east whereupon it turns sharply right after another door, or you can follow it west where, after a similar door, it veers left at another corner...\nTo the north, in the centre of the hallway, you espy a rosewood door identical to the one in the south wall that it stands across from.\t\nTo the west the corridor ends at a corner that turns sharply left.\t\nTurning your gaze southward you espy a rosewood door, identical to the one in the north wall, and standing across from it.\t\nLooking to the east you see the corridor end at a corner that veers right.\t\t", northCorridorItems, northCorridorFeatures);
            Room easternmostCorridor = new Room("easternmost corridor", "You enter upon the easternmost corridor of the circular landing. A bare rosewood panelled wall spans the western side while some doors greet your sight some way down the eastern side of the passage. The corridor leads north where it turns sharply left, or you can follow it south where it veers right at another corner. Guiding both paths are more lanterns, throwing shadows along the walls with their dim, flickering light...\nsurveying the northern end of the hallway you see a corner that turns left.\t\nTo the west there is only bare wall and the marks left by marauders who looted the paintings.\t\nTurning your gaze south you see a corner. It turns right.\t\nTo the east is a rosewood door. There is no plaque or label to indicate where it leads...\t\t", eastCorridorItems, eastCorridorFeatures);
            Room southernmostCorridor = new Room("south-facing corridor", "You enter upon the south-facing corridor of the circular landing. There is a window in the south-facing wall some way down the passage. The corridor leads east where it turns sharply left or you can follow it west where it veers right at another corner. The lanterns within their alcoves are pockets of warm light, trailing the way down either passage. There are only two doors here, both in the north wall and one close by each corner...\nTo the north you see only bare wall illuminated by the lanterns trailing its length.\t\nTurning your gaze to the west you see the corridor end at a corner turning right and a door.\t\nLooking a the south wall, you see its much the same as the north wall, except for a floor-to-ceiling length Palladian window through which moonbeams filter through the partially drawn diaphanous curtains.\t\nGazing eastward you see the corridor end at a shadowy corner. It turns left just after a door in the north wall.\t\t", southCorridorItems, southCorridorFeatures);
            Door fakeDoorwest = new Door("rosewood door", "Identical to all the other doors in these corridors, it's ornate and has a beautiful gleam to it's burnished surface. There exists no plaque or indication as to where it leads...", false, "unlocked", null, new List<Room> { westernmostCorridor }, "");
            Door fakeDooreast = new Door("rosewood door", "Identical to all the other doors in these corridors, it's ornate and has a beautiful gleam to it's burnished surface. There exists no plaque or indication as to where it leads...", false, "unlocked", null, new List<Room> { easternmostCorridor }, "");
            Door fakeDoornorth = new Door("rosewood door", "Identical to all the other doors in these corridors, it's ornate and has a beautiful gleam to it's burnished surface. There exists no plaque or indication as to where it leads...", false, "unlocked", null, new List<Room> { northernmostCorridor }, "");
            Door fakeDoorsouth = new Door("rosewood door", "Identical to all the other doors in these corridors, it's ornate and has a beautiful gleam to it's burnished surface. There exists no plaque or indication as to where it leads...", false, "unlocked", null, new List<Room> { southernmostCorridor }, "");
            westCorridorFeatures.Insert(4, fakeDoorwest);
            westCorridorFeatures.Insert(1, fakeDoorwest);
            eastCorridorFeatures.Insert(4, fakeDooreast);
            eastCorridorFeatures.Insert(1, fakeDooreast);
            northCorridorFeatures.Insert(5, fakeDoornorth);
            northCorridorFeatures.Insert(1, fakeDoornorth);
            southCorridorFeatures.Insert(4, fakeDoorsouth);
            southCorridorFeatures.Insert(1, fakeDoorsouth);
            westernmostCorridor.FeatureList = westCorridorFeatures;
            easternmostCorridor.FeatureList = eastCorridorFeatures;
            southernmostCorridor.FeatureList = southCorridorFeatures;
            northernmostCorridor.FeatureList = northCorridorFeatures;

            List<Room> holeRooms = new List<Room> {room, secretChamber };
            List<Room> yourCellDoor = new List<Room> {room, corridor };
            List<Room> otherCellDoor = new List<Room> { corridor, cellOpposite };
            List<Room> stairwayUp = new List<Room> { corridor, antechamber};
            List<Room> stairwellDown = new List<Room> { dungeonChamber, corridor };
            List<Room> emptyCellPassage = new List<Room> { corridor, emptyCell };
            List<Room> armouryDoorway = new List<Room> { antechamber, armoury};
            List<Room> hatchPassage = new List<Room> { oubliette, dungeonChamber };
            List<Room> circleDoorPass = new List<Room> { antechamber, westernmostCorridor};
            List<Room> northwestCornerTurn = new List<Room> {westernmostCorridor, northernmostCorridor };
            List<Room> southwestCornerTurn = new List<Room> { westernmostCorridor, southernmostCorridor };
            List<Room> northeastCornerTurn = new List<Room> {easternmostCorridor, northernmostCorridor };
            List<Room> southeastCornerTurn = new List<Room> { southernmostCorridor, easternmostCorridor };
            List<Room> magManPassage = new List<Room> {northernmostCorridor, magicalManufactory };
            List<Room> messHallPassage = new List<Room> {easternmostCorridor, messHall };
            List<Room> broomClosetPassage = new List<Room> {northernmostCorridor, broomCloset };
            List<Room> mosaicPortal = new List<Room> {secretChamber, westernmostCorridor };
            rosewoodDoor.CastDoor().Portal = yourCellDoor;            
            otherRosewoodDoor.CastDoor().Portal = otherCellDoor;            
            stairwayToLower.CastDoor().Portal = stairwellDown;
            stairwayToUpper.CastDoor().Portal = stairwayUp;
            emptyCellDoor.CastDoor().Portal = emptyCellPassage;
            armouryDoor.CastDoor().Portal = armouryDoorway;
            northeastCorner.CastDoor().Portal = northeastCornerTurn;
            northwestCorner.CastDoor().Portal= northwestCornerTurn;
            southeastCorner.CastDoor().Portal = southeastCornerTurn;
            southwestCorner.CastDoor().Portal = southwestCornerTurn;
            magManDoor.CastDoor().Portal = magManPassage;
            circleDoor.CastDoor().Portal = circleDoorPass;
            broomClosetDoor.CastDoor().Portal = broomClosetPassage;
            messHallDoor.CastDoor().Portal = messHallPassage;
            holeInCeiling.CastDoor().Portal = holeRooms;
            hatch.CastDoor().Portal = hatchPassage; 
            Test test1 = new Test(room);
            test1.RunForRoom();
            List<Room> destinations = new List<Room> {highestParapet, oubliette, broomCloset, secretChamber, hugeBarracks, dragonLair, bankVault, desertIsland, oceanBottom, prehistoricJungle, astralPlanes,  mirrorWorld };
            List<Room> threadPath = new List<Room>();
            merigoldPortal.CastDoor().Portal = new List<Room> { magicalManufactory, destinations[D12.Roll(D12) - 1] };

            ///
            /// This is where the game begins for now, until i make a game class.
            /// It begins with a prologue the player can choose to skip.
            /// As such player input is required and hence the while loop that ensures a
            /// correct response is given and catches any errors. We'll see this structure a lot throughout this 
            /// program. This one below is simpler than some of the others I deployed. But they
            /// are all of the same basic formula
            ///
            Prologue(room);
            bool justStalked = false;
            string pk; // not important, it's just for the console.readline at the end of the program.

            

            Player player1 = CharacterCreation();
            Test test2 = new Test(player1, room);
            test2.RunForPlayer();
            player1.CarryCapacity += player1.InitialStamina / 10;

            bool getYesNoResponse()
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

            int getIntResponse(int option)
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
            List<long> getTimedIntResponse(int option)
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
                   
                List<long> output = new List<long> { answer1,  timeLapsed};
                return output;
            }
            char getTimedKeyResponse(int option, out long timeLapsed, List<char> KeyOptions)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                timeLapsed = 0;
                
                while (true)
                {
                    char answer = Console.ReadKey().KeyChar;
                    if (string.IsNullOrWhiteSpace(answer.ToString()))
                    {
                        continue;
                    }
                    else if (!KeyOptions.Contains(answer))
                    {
                        Console.WriteLine("You waste your time fumbling and fretting!");
                        sw.Stop();
                        timeLapsed = 20000;

                        return answer;
                    }
                    else
                    {
                        sw.Stop();
                        timeLapsed = sw.ElapsedMilliseconds;
                        return answer;
                    }
                }
            }
            List<long> minotaurStomp(int options, long timeLimit)
            {
                List<long> output = new List<long>();
                output = getTimedIntResponse(options);
                output.Add(timeLimit - output[1]);
                if (output[2] < timeLimit * 3 / 4 && timeLimit > 7500)
                {
                    
                    Console.WriteLine("\nstomp...\n");
                    Thread.Sleep(700);
                    if (timeLimit > 9000)
                    {
                        Thread.Sleep(500);
                    }
                }
                if (output[2] < timeLimit/2) 
                {
                    
                    Console.WriteLine("\n\t\tStomp...\n");
                    Thread.Sleep(700);
                    if (timeLimit > 9000)
                    {
                        Thread.Sleep(500);
                    }
                }
                if (output[2] < timeLimit / 4)
                {
                    
                    Console.WriteLine("\n\t\t\t\tSTOMP...\n");
                    Thread.Sleep(700);
                    if (timeLimit > 9000)
                    {
                        Thread.Sleep(500);
                    }
                }
                if (output[2] < 0)
                {
                    
                    Console.WriteLine("\n\t\t\t\t\t\t...STOMP!\n");
                    Thread.Sleep(700);
                    if (timeLimit > 9000)
                    {
                        Thread.Sleep(500);
                    }
                    
                }
                return output;
            }
            Room minotaurApproaches(Room room, Monster monster, bool firstTime, long timeLimit, bool oops = false, bool rage = false)
            {
                southwestCorner.Passing = "Fleet of foot, you nip around the southwest corner.";
                northwestCorner.Passing = "Feeling your heart clap in your chest, you throw yourself around the northwest corner.";
                northeastCorner.Passing = "You duck out of sight around the northeast corner.";
                southeastCorner.Passing = "You stealthily slip around the southeast corner.";
                Dice D8 = new Dice(8);
                Dice D7 = new Dice(7);
                Dice D6 = new Dice(6);
                Dice D5 = new Dice(5);
                Dice D4 = new Dice(4);
                Dice D3 = new Dice(3);
                Dice D2 = new Dice(2);
                List<string> monsterMarch = new List<string>
                {
                    $"Your actions haven't gone unheard by the monster in the {monster.Location.Name}. Once again, you here it close in...",
                    $"Your footsteps haven't been as soft as you'd hoped. You feel the tremors through the floor, reverberating from the {monster.Location.Name}, as the beast draws near...",
                    $"You pull back abruptly from what you were doing. From the {monster.Location.Name} the beast approaches...",
                    $"The monster senses something amiss - a mouse pitter-pattering where it shouldn't. It moves from the {monster.Location.Name} to investigate...",
                    $"The beast hears something. It draws forth from the {monster.Location.Name} to hunt for trespassers...",
                    $"The walls shiver once more. The beast closes in from the {monster.Location.Name}"
                };
                if (firstTime)
                {
                    Console.WriteLine($"The ground suddenly trembles beneath your feet. The corridor's lanterns shiver in their alcoves, shadows jostling along the walls before their quivering flames. From the {monster.Location.Name} something approaches...");
                    Console.ReadKey(true);

                }
                else if (oops) { }
                else
                {

                    Console.WriteLine(monsterMarch[D6.Roll(D6) - 1]);
                    Console.ReadKey(true);
                }
                
                if (rage)
                {
                    timeLimit = 3*timeLimit/5;
                }
                if (player1.Speedy && !oops)
                {
                    timeLimit *= 2; 
                }
                string strand = "";
                if (!oops)
                {
                    strand = "to decide";
                }
                else
                {
                    strand = "left";
                }
                if (player1.Speedy)
                {
                    strand += " (thanks to your potion of alacrity)";
                }
                Console.WriteLine($"What will you do?\n[You have only {timeLimit/1000} seconds {strand} after you press any key...]");
                Console.ReadKey(true);
                List<Door> doors = new List<Door>();
                foreach(Feature f in room.FeatureList)
                {
                    if (f is Door)
                    {
                        doors.Add(f.CastDoor());
                    }
                }
                long i = 1;
                string action = "";
                List<string> slipsnipsdarts = new List<string>
                {
                    "Slip", "Nip", "Dart", "Scurry", "Rush", "Slink", "Hurry", "Slip"
                };
                List<string> choices = new List<string>();
                Dictionary<long, Door> choice_door = new Dictionary<long, Door>();
                Dictionary<string, Door> tie_door = new Dictionary<string, Door>();
                foreach (Door d in doors)
                {
                    if (d.Portal.Contains(monster.Location))
                    {
                        action = $"Stride up to the {d.Name} and confront the beast...";
                    }
                    else if (d.Name.Contains("corner"))
                    {
                        
                        action = $"{slipsnipsdarts[D8.Roll(D8) - 1]} around the {d.Name}";
                    }
                    else
                    {
                        action = $"{slipsnipsdarts[D8.Roll(D8) - 1]} through the {d.Name}";
                    }
                    choices.Add(action);
                    tie_door[action] = d;
                }
                /// choices.add(action) => action = hide behind curtain if in southern corridor
                /// minotaur sees you and charges chance it falls though window when dodged
                /// tie_door[action] = d
                /// 
                if (choices.Count == 8)
                {
                    int index = D8.Roll(D8) - 1;
                    Console.WriteLine($"[{i}] {choices[index]}");
                    choice_door[i] = tie_door[choices[index]];
                    choices.Remove(choices[index]);

                    i++;
                }
                if (choices.Count == 7)
                {
                    int index = D7.Roll(D7) - 1;
                    Console.WriteLine($"[{i}] {choices[index]}");
                    choice_door[i] = tie_door[choices[index]];
                    choices.Remove(choices[index]);

                    i++;
                }
                if (choices.Count == 6)
                {
                    int index = D6.Roll(D6) - 1;
                    Console.WriteLine($"[{i}] {choices[index]}");
                    choice_door[i] = tie_door[choices[index]];
                    choices.Remove(choices[index]);

                    i++;
                }
                if (choices.Count == 5)
                {
                    int index = D5.Roll(D5) - 1;
                    Console.WriteLine($"[{i}] {choices[index]}");
                    choice_door[i] = tie_door[choices[index]];
                    choices.Remove(choices[index]);

                    i++;
                }
                if (choices.Count == 4)
                {
                    int index = D4.Roll(D4) - 1;
                    Console.WriteLine($"[{i}] {choices[index]}");
                    choice_door[i] = tie_door[choices[index]];
                    choices.Remove(choices[index]);
                    
                    i++;
                }
                if (choices.Count == 3)
                {
                    int index = D3.Roll(D3) - 1;
                    Console.WriteLine($"[{i}] {choices[index]}");
                    choice_door[i] = tie_door[choices[index]];
                    choices.Remove(choices[index]);
                    
                    i++;
                }
                if (choices.Count == 2)
                {
                    int index = D2.Roll(D2) - 1;
                    Console.WriteLine($"[{i}] {choices[index]}");
                    choice_door[i] = tie_door[choices[index]];
                    choices.Remove(choices[index]);
                    i++;
                }
                if (choices.Count == 1)
                {
                    Console.WriteLine($"[{i}] {choices[0]}");
                    choice_door[i] = tie_door[choices[0]];
                    choices.Remove(choices[0]);
                    
                    i++;
                }
                
                int x = unchecked((int)i);
                
                List<long> output = minotaurStomp(x, timeLimit);
                int index2 = unchecked((int)output[0]);
                if (output[2] < 0)
                {
                    Console.WriteLine("TOO LATE! Fixed within the monster's sights, you brace yourself for the fight of your life...");
                    Console.ReadKey(true);
                    return room;
                }
                else if (choice_door[output[0]].Passage(room, false) == monster.Location)
                {
                    Console.WriteLine($"Feeling perhaps a smidge crazy, you've the sudden overwhelming urge to face your destiny (that or a death wish...) \nYou gallantly stride up to the {choice_door[output[0]].Name} and take the fight to the monster!");
                    Console.ReadKey(true);
                    return choice_door[output[0]].Passage(room, false);
                }
                else if (output[1]<2*timeLimit/5)
                {
                    Console.WriteLine($"You manage to reach the {choice_door[output[0]].Name} with time to spare...");
                    Console.ReadKey(true);
                    if (choice_door[output[0]].Attribute)
                    {
                        
                        
                        Console.WriteLine("With dawning horror your clammy hands fumble as they try to open a locked door!");
                        Console.ReadKey(true);
                        return minotaurApproaches(room, monster, false, output[2], true, rage);

                    }
                    else if (choice_door[output[0]].CastDoor().Portal.Count==1)
                    {
                        Console.WriteLine("Feeling the monster closing in, you swing the door open - only to find no room on the other side. It's been bricked up!");
                        Console.ReadKey(true);
                        return minotaurApproaches(room, monster, false, output[2], true, rage);
                    }
                    return choice_door[output[0]].Passage(room);
                }
                else if (output[1] < 7 * timeLimit / 10)
                {
                    Console.WriteLine($"You scramble to the {choice_door[output[0]].Name}...");
                    Console.ReadKey(true); 
                    if (choice_door[output[0]].Attribute)
                    {

                        
                        Console.WriteLine("With dawning horror your clammy hands fumble as they try to open a locked door!");
                        Console.ReadKey(true);
                        return minotaurApproaches(room, monster, false, output[2], true, rage);

                    }
                    else if (choice_door[output[0]].CastDoor().Portal.Count == 1)
                    {
                        Console.WriteLine("Feeling the monster closing in, you swing the door open - only to find no room on the other side. It's been bricked up!");
                        Console.ReadKey(true);
                        return minotaurApproaches(room, monster, false, output[2], true, rage);
                    }
                    return choice_door[output[0]].Passage(room);
                }
                else
                {
                    Console.WriteLine($"You scramble to the {choice_door[output[0]].Name}...");
                    if (choice_door[output[0]].Attribute)
                    {

                        Console.ReadKey(true);
                        Console.WriteLine("With dawning horror your clammy hands fumble as they try to open the door! It's locked!");
                        Console.ReadKey(true);
                        Console.WriteLine("It's with a chill that you feel the monster's shadow fall over you. It's caught you red-handed. Feeling your stomach twist in knots, you face your foe...");
                        Console.ReadKey(true);
                        return room;

                    }
                    else if (choice_door[output[0]].CastDoor().Portal.Count == 1)
                    {
                        Console.WriteLine("Feeling the monster closing in, you swing the door open - only to find no room on the other side. It's been bricked up!");
                        Console.ReadKey(true);
                        Console.WriteLine("It's with a chill that you feel the monster's shadow fall over you. It's caught you red-handed. Feeling your stomach twist in knots, you face your foe...");
                        Console.ReadKey(true);
                        return room;
                    }
                    return choice_door[output[0]].Passage(room);
                }
                
            }
            Room minotaurStalks(Room newRoom1, Monster minotaur, long minotaurAlertedBy, long minotaurAlerted, Combat minotaurKafuffle, Dictionary<Item, List<Item>> usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, Dictionary<Item, List<Player>> usesDictionaryItemChar, List<bool> leftWhichRooms)
            {
                List<Door> doors = new List<Door>();
                foreach(Feature f in newRoom1.FeatureList)
                {
                    if(f is Door)
                    {
                        doors.Add(f.CastDoor());
                    }
                }
                List<Room> locationLocationLocation = new List<Room>();
                foreach(Door d in doors)
                {
                    foreach(Room r in d.Portal)
                    {
                        if (r != newRoom1)
                        {
                            locationLocationLocation.Add(r);
                        }
                    }
                }
                if (locationLocationLocation.Contains(minotaur.Location) && minotaur.Stamina > 0 && minotaurAlertedBy < minotaurAlerted)
                {
                    Room oldRoom = newRoom1;
                    newRoom1 = minotaurApproaches(oldRoom, minotaur, westernmostCorridor.FirstVisit, 10000, false, minotaur.Rage);
                    if (oldRoom.Name == newRoom1.Name)
                    {
                        if (player1.Traits.ContainsKey("friends with fairies"))
                        {
                            Console.WriteLine("Barrelling towards you is a minotaur flailing a greatSword, smashing everything in its path. You have but a moment to act before it's upon you.\nWill you:\n[1] Try to assure it your fairy friends and you have its best interests at heart?\n[2] Try to explain your presence here before it decapitates you?\n[3] Command your fairy friends to attack!\n[4] Brace yourself for combat!");
                            switch (getIntResponse(5))
                            {
                                case 1:
                                    Console.WriteLine("The minotaur seems to not hear you - judging by its continued wanton carnage as it closes in...\nOh well, here goes nothing...");
                                    break;
                                case 2:
                                    Console.WriteLine("The beast roars as it builds momentum into a thunderous charge\nWhatever you say, it best be good...\n[1] I just want to take a leisurely stroll through the corridors...\n[2] I only want to make a little trip around the tower... \n[3] I just want to take a minor tour of the grounds...\n[4] I only wish to take an insignificant peregrination of your accommodation...\n[5] uh... I'm looking for the bathroom..?");
                                    switch (getIntResponse(6))
                                    {
                                        case 1:
                                            Console.WriteLine("Yeah, no. The beast doesn't feel like chatting...");
                                            break;
                                        case 2:
                                            Console.WriteLine("Yeah, no. The beast doesn't feel like chatting...");
                                            break;
                                        case 3:
                                            Console.WriteLine("The minotaur abruptly freezes in front of you, its sword moments from lopping off your head.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("It seems befuddled for a moment, blinks, then is hurled upwards into the air and through some interdimensional portal. The portal burps the minotaur's effects back, then closes as abruptly as it opened.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("You dust your hands. Sometimes its all about finding the right words...");
                                            Console.ReadKey(true);
                                            minotaur.Stamina = 0;
                                            minotaur.Location = astralPlanes;
                                            minotaur.Path.Clear();
                                            minotaur.Path.Add(astralPlanes);
                                            minotaur.Rage = false;
                                            minotaur.Suspicious = false;
                                            foreach(Item item in minotaur.Items)
                                            {
                                                newRoom1.ItemList.Add(item);
                                            }
                                            
                                            return newRoom1;
                                        case 4:
                                            Console.WriteLine("Yeah, no. The beast doesn't feel like chatting...");
                                            break;
                                        case 5:
                                            Console.WriteLine("Yeah, no. The beast doesn't feel like chatting...");
                                            break;
                                        default:
                                            break;
                                        }
                                    break;
                                case 3:
                                    Console.WriteLine("You gallantly order the attack, imagining they'll swoop in like a squad of valkyries to your rescue. When no such glorious flanking manoeuvre materialises, you look about you... uh, fairy friends? ...Anyone?\nHuh, looks like they have full confidence that you've got this one covered...");
                                    break;
                                case 4:
                                    break;
                                default:
                                    Console.WriteLine("Error in switch case, check parameters of getIntResponse...");
                                    break;
                            }
                        }
                        if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, oldRoom, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                        {
                            minotaurKafuffle.WonFight(newRoom1);
                            leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                            return newRoom1;
                        }
                        else
                        {
                            Console.ReadKey(true);
                            return oceanBottom;
                        }
                    }
                    else if (minotaur.Location.Name == newRoom1.Name)
                    {
                        if (player1.Traits.ContainsKey("friends with fairies"))
                        {
                            Console.WriteLine("Barrelling towards you is a minotaur flailing a greatSword, smashing everything in its path. You have but a moment to act before it's upon you.\nWill you:\n[1] Try to assure it your fairy friends and you have its best interests at heart?\n[2] Try to explain your presence here before it decapitates you?\n[3] Command your fairy friends to attack!\n[4] Brace yourself for combat!");
                            switch (getIntResponse(5))
                            {
                                case 1:
                                    Console.WriteLine("The minotaur seems to not hear you - judging by its continued wanton carnage as it closes in...\nOh well, here goes nothing...");
                                    break;
                                case 2:
                                    Console.WriteLine("The beast roars as it builds momentum into a thunderous charge\nWhatever you say, it best be good...\n[1] I just want to take a leisurely stroll through the corridors...\n[2] I only want to make a little trip around the tower... \n[3] I just want to take a minor tour of the grounds...\n[4] I only wish to take an insignificant peregrination of your accommodation...\n[5] uh... I'm looking for the bathroom..?");
                                    switch (getIntResponse(6))
                                    {
                                        case 1:
                                            Console.WriteLine("Yeah, no. The beast doesn't feel like chatting...");
                                            break;
                                        case 2:
                                            Console.WriteLine("Yeah, no. The beast doesn't feel like chatting...");
                                            break;
                                        case 3:
                                            Console.WriteLine("The minotaur abruptly freezes in front of you, its sword moments from lopping off your head.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("It seems befuddled for a moment, blinks, then is hurled upwards into the air and through some interdimensional portal. The portal burps the minotaur's effects back, then closes as abruptly as it opened.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("You dust your hands. Sometimes its all about finding the right words...");
                                            Console.ReadKey(true);
                                            minotaur.Stamina = 0;
                                            minotaur.Location = astralPlanes;
                                            minotaur.Path.Clear();
                                            minotaur.Path.Add(astralPlanes);
                                            minotaur.Rage = false;
                                            minotaur.Suspicious = false;
                                            foreach (Item item in minotaur.Items)
                                            {
                                                newRoom1.ItemList.Add(item);
                                            }
                                            return newRoom1;
                                        case 4:
                                            Console.WriteLine("Yeah, no. The beast doesn't feel like chatting...");
                                            break;
                                        case 5:
                                            Console.WriteLine("Yeah, no. The beast doesn't feel like chatting...");
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("You gallantly order the attack, imagining they'll swoop in like a squad of valkyries to your rescue. When no such glorious flanking manoeuvre materialises, you look about you... uh, fairy friends? ...Anyone?\nHuh, looks like they have full confidence that you've got this one covered...");
                                    break;
                                case 4:
                                    break;
                                default:
                                    Console.WriteLine("Error in switch case, check parameters of getIntResponse...");
                                    break;
                            }
                        }
                        if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, minotaur.Location, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, true, player1.Masked))
                        {
                            minotaurKafuffle.WonFight(newRoom1);
                            leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                            return newRoom1;
                        }
                        else
                        {
                            Console.ReadKey(true);
                            return oceanBottom;
                        }
                    }
                    else
                    {
                        if (threadPath.Contains(oldRoom))
                        {
                            if(oldRoom == threadPath[0])
                            {
                                for(int i = 0; i<threadPath.Count;i++)
                                {
                                    minotaur.Path.Insert(0, threadPath[i]);
                                }
                                for (int i = threadPath.Count-2; i >= 0; i--)
                                {
                                    minotaur.Path.Insert(0, threadPath[i]);
                                }
                                Console.WriteLine($"The monster lumbers into the {oldRoom.Name}, whereupon it catches sight of where you dropped the spool of red thread.\nPerhaps heeding some ancient memory it begins following where it leads...");
                                Console.ReadKey(true);
                                Console.WriteLine("Hoping whatever plan you have works, you nevertheless now know for certain that the monster is aware you're here. And they're mad...");
                                foreach (Room r in threadPath)
                                {
                                    r.ItemList.Remove(redThread);
                                }
                                minotaur.Items.Add(redThread);
                                minotaur.Rage = true;
                                return newRoom1;
                            }
                            else if (oldRoom == threadPath[threadPath.Count - 1])
                            {
                                for (int i = threadPath.Count - 1; i >= 0; i--)
                                {
                                    minotaur.Path.Insert(0, threadPath[i]);
                                }
                                for (int i = 1; i < threadPath.Count; i++)
                                {
                                    minotaur.Path.Insert(0, threadPath[i]);
                                }
                                Console.WriteLine($"The monster lumbers into the {oldRoom.Name}, whereupon it catches sight of where you began unravelling the spool of red thread.\nPerhaps now would be a good time to drop it if you haven't already...");
                                Console.ReadKey(true);
                                Console.WriteLine("Hoping whatever plan you have works, you nevertheless now know for certain that the monster is aware you're here. And they're mad...");
                                foreach(Room r in threadPath)
                                {
                                    r.ItemList.Remove(redThread);
                                }
                                
                                minotaur.Items.Add(redThread);
                                minotaur.Rage = true;
                                return newRoom1;
                            }
                            else
                            {
                                int whichWay = D6.Roll(D6);
                                if(whichWay < 4)
                                {
                                    int indx = threadPath.IndexOf(oldRoom);
                                    for (int i = indx; i >= 0; i--)
                                    {
                                        minotaur.Path.Insert(0, threadPath[i]);
                                    }
                                    for (int i = 1; i <= indx; i++)
                                    {
                                        minotaur.Path.Insert(0, threadPath[i]);
                                    }
                                    Console.WriteLine($"The monster lumbers into the {oldRoom.Name}, whereupon it catches sight of the unspooled red thread leading left and right.\nThe beast seems to deliberate for a moment, before following it either to where you are or where you dropped it...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("Hoping whatever plan you have works, you nevertheless now know for certain that the monster is aware you're here. And they're mad...");
                                    foreach (Room r in threadPath)
                                    {
                                        r.ItemList.Remove(redThread);
                                    }
                                    minotaur.Items.Add(redThread);
                                    minotaur.Rage = true;
                                }
                                else
                                {
                                    int indx = threadPath.IndexOf(oldRoom);
                                    for (int i = indx; i < threadPath.Count; i++)
                                    {
                                        minotaur.Path.Insert(0, threadPath[i]);
                                    }
                                    for (int i = threadPath.Count - 2; i >= indx; i--)
                                    {
                                        minotaur.Path.Insert(0, threadPath[i]);
                                    }
                                    Console.WriteLine($"The monster lumbers into the {oldRoom.Name}, whereupon it catches sight of the unspooled red thread leading left and right.\nThe beast seems to deliberate for a moment, before following it to where you began unravelling it...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("Hoping whatever plan you have works, you nevertheless now know for certain that the monster is aware you're here. And they're mad...");
                                    oldRoom.ItemList.Remove(redThread);
                                    minotaur.Items.Add(redThread);
                                    minotaur.Rage = true;
                                }
                                return newRoom1;
                            }
                        }
                        else if (oldRoom == westernmostCorridor && westernmostCorridor.FirstVisit)
                        {
                            if (newRoom1.Name.Contains("corridor"))
                            {
                                westernmostCorridor.FirstVisit = false;
                                Console.WriteLine("Back pressed against the wall by the corner you hear the beast's heavy breathing and grunts as it scours the corridor you just left. You can almost feel its eyes linger on the corner you just turned. As it stalks a pace or two further forward, your breath catches as you see its huge shadow climb the wall opposite you...");
                                Console.ReadKey(true);
                                if (!circleDoor.Attribute && oldRoom == westernmostCorridor)
                                {
                                    Dice D8 = new Dice(8);
                                    int searching = D8.Roll(D8);
                                    
                                    if (searching > 5 && newRoom1 != antechamber)
                                    {
                                        minotaur.Location = oldRoom;
                                        minotaur.Path.Insert(0, oldRoom);
                                        Console.WriteLine("The monster is about to turn back when it notices something. You feel your pulse thumping in double time as you realise you left the double doors unlocked and slightly ajar! Now the beast knows you're here...");
                                        Console.ReadKey(true);
                                        minotaur.Rage = true;
                                        return minotaurStalks(newRoom1, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    }
                                    else
                                    {
                                        Console.WriteLine("The monster is about to turn back when it notices something. You hear the monster growl before the double doors close shut and are once again locked. You sense it's gaze scan the hallway, it's suspicion made palpable by its disquieting stare. Then, abruptly, the terrifying beast begins heading back the way it came...");
                                        Console.ReadKey(true);
                                        minotaur.Suspicious = true;
                                        circleDoor.Attribute = true;
                                        circleDoor.SpecificAttribute = "locked";
                                        return newRoom1;
                                    }
                                }
                                else
                                {
                                    
                                    Console.WriteLine("The monster pauses. Has it noticed something out of place?");
                                    Console.ReadKey(true);
                                    Console.WriteLine("Finally, the beast begins heading back the way it came...");
                                    minotaur.Suspicious = true;
                                    circleDoor.Attribute = true;
                                    circleDoor.SpecificAttribute = "locked";
                                    return newRoom1;
                                }
                            }
                            else
                            {
                                
                                Console.WriteLine("Back pressed against the door you realise you've left it unlocked! \nYour heart knocks against your chest as you hear the monster pass by. It pauses a moment, seemingly scanning the corridor...");
                                Console.ReadKey(true);
                                Console.WriteLine("Finally, you hear the monster's heavy footfalls as it begins returning from whence it came. It seems it didn't notice the door was left slightly ajar...");
                                return newRoom1;
                            }

                        }
                        else
                        {
                            minotaur.Location = oldRoom;
                            minotaur.Path.Insert(0, oldRoom);
                            if (minotaur.Suspicious || minotaur.Rage)
                            {
                                Dice D8 = new Dice(8);
                                int searching = D8.Roll(D8);
                                if (minotaur.Rage && searching > 3)
                                {
                                    
                                    return minotaurStalks(newRoom1, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    ///make into recursive function
                                }
                                else if (minotaur.Suspicious && searching > 5)
                                {
                                    return minotaurStalks(newRoom1, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                }
                                else
                                {
                                    Console.WriteLine("The beast growls as it scans for any sign of you. Finally, you hear the monster's heavy footfalls as it begins returning from whence it came.");
                                    minotaur.Time = (minotaur.Path.Count-1) * 20000;
                                    return newRoom1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("The monster sniffs the air, as though to catch some unfamiliar scent...");
                                Console.ReadKey(true);
                                Console.WriteLine("Finally, you hear the beast's heavy footfalls as it begins returning from whence it came.");
                                minotaur.Time = (minotaur.Path.Count - 1) * 20000;
                                return newRoom1;
                            }
                        }
                    }
                }
                else
                {
                    return newRoom1;
                }
            }
            
            
            //
            //
            //
            //
            //
            //

            ///Fungshui is used for ensuring 'sticky' items [items that when you pick up aren't
            ///removed from the room] only appear once in the room even when discarded from your
            ///pack. items are usually sticky when there's more than one of them - they're a multitude.
            void FungShui(string itemName)
            {
                int fungShui = 0;
                foreach (Item x in room.ItemList)
                {
                    if (x.Name == itemName)
                    {
                        fungShui++;
                    }
                }
                if (fungShui > 1)
                {

                    for (int i = room.ItemList.Count - 1; i >= 0; i--)
                    {
                        if (room.ItemList[i].Name == itemName && fungShui > 1)
                        {
                            room.ItemList.Remove(room.ItemList[i]);
                            fungShui--;
                        }
                    }
                }
            }
            //

            //


            //

            //
            
            // weapons to be used in battles
            Weapon vanquisher = new Weapon("Sword of Sealed Souls", "This sword almost seems to whisper as it slices the air like silk. You can almost imagine hearing wails off in the distance as though from the victims of some banshee haunting a blighted moor.", vanquisherDamage, defaultCritHits, defaultGoodHits, 3);
            Weapon breadKnife = new Weapon("Bread Knife", "This knife's blade is dulled with age. Any aspirations to slice anything other than very, very \nsoft butter might be met with something less than success", damage, defaultCritHits, defaultGoodHits);
            Weapon scimitar = new Weapon("rusty scimitar", "The scimitar's blade is flecked with rust. Crude and brittle, you doubt it'd last long parrying a better sword.", damage1, defaultCritHits, defaultGoodHits);
            Weapon bite = new Weapon("gnashing maw", "Sharp hook-like fangs lathered with drooling saliva, nestle within this creatures jaw, ready to draw blood.", damage1, defaultCritHits, defaultGoodHits);
            Weapon dagger = new Weapon("dagger", "The dagger's blade gleams like a crooked smile in some dubious tavern.", damage1, defaultCritHits, defaultGoodHits);
            // player1.WeaponInventory.Add(breadKnife);
            // player1.Inventory.Add(healPotion);
            player1.Inventory.Add(FelixFelicis);
            player1.Inventory.Add(elixirFeline);
            player1.Inventory.Add(speedPotion);

            ///Instantiating monsters to be fought later
            Item magManKey = new Item("copper key", "Found amongst the minotaur's possessions, this key has a tarnished look about it as though it could do with a good polish. You suppose it must unlock one of the doors in this landing. The question is, which one...", false);
            List<Item> goblinInventory = new List<Item> { scimitar };
            List<Item> gnollInventory = new List<Item> { dagger };
            
            Item mercInsignia = new Item("insignia", "The insignia depicts a serpent with feathered wings. In the form of a broach it might look rather fetching on you...");
            List<Item> minotaurInventory = new List<Item> { vanquisher, armBand, belt, diadem, magManKey };
            List<Room> minotaurPath = new List<Room> { northernmostCorridor};
            Stopwatch minotaurTimer = new Stopwatch();
            List<Item> mageinventory = new List<Item> { dagger };
            Weapon lethalspell = new Weapon("magic missile", "", stilettoDamage, defaultCritHits, defaultGoodHits, 10);
            Monster minotaur = new Monster("minotaur", "towering above you at eight feet, the minotaur levels its horns towards you, tenses its powerful muscles, and charges!", minotaurInventory, 120, 10, vanquisher, northernmostCorridor, minotaurPath, false, false, minotaurTimer);
            Monster goblin = new Monster("goblin", "The goblin's swarthy, pock-marked skin does little to lessen the effect of its ugly snarl.", goblinInventory, 50, 2, scimitar);
            Monster ghoul2 = new Monster("ghoul engaged to Willow", "", gnollInventory, 1, 1, bite);
            Monster ghoul1 = new Monster("ghoul with paladin garb", "", gnollInventory, 1, 1, bite);
            Monster mage = new Monster("elderly mage", "He totters menacingly towards you...", mageinventory, 3, 20, lethalspell);
            goblin.Items.Add(bracelet);
            goblin.Items.Add(mercInsignia);
            goblin.Items.Add(jailorKeys);
            Monster gnoll = new Monster("gnoll", "The ravenous gnoll stares at you with hungry eyes. It seeks to feast, and you would make an excellent appetiser...", gnollInventory, 50, 4, bite);
            ///Instantiating battles to be used later.
            Combat trialBattle = new Combat(goblin, player1);
            Combat toughestBattle = new Combat(minotaur, player1);
            Combat tougherBattle = new Combat(gnoll, player1);
            Combat mageBattle = new Combat(mage, player1);
            Test test3 = new Test(player1, room, trialBattle);
            // Dictionaries for items used on other effects (items or features)
            List<Dice> rustyDamage = new List<Dice> { D6 };
            Weapon yourRustyChains = new Weapon("rusty chain-flail", "Compared to the rest of the chains littered throughout the room these are relatively sturdy. A lone manacle at the end serves as an almost-effective morning-star.", rustyDamage, defaultCritHits, defaultGoodHits);
            var usesDictionaryItemItem = new Dictionary<Item, List<Item>> { [magnifyingGlass] = new List<Item> { note } };
            var usesDictionaryItemFeature = new Dictionary<Item, List<Feature>> { [magnifyingGlass] = new List<Feature>(), [steelKey] = new List<Feature> { rosewoodChest }, [yourRustyChains] = new List<Feature> { skeleton, bookCase }, [breadKnife] = new List<Feature> { skeleton, bookCase }, [scimitar] = new List<Feature> { skeleton, bookCase }, [dagger] = new List<Feature> { skeleton, bookCase }, [vanquisher] = new List<Feature> { skeleton, bookCase } };

            if (player1.Traits.ContainsKey("friends with fairies"))
            {
                usesDictionaryItemItem.Add(halfOfCrackedBowl, new List<Item> { otherHalfOfCrackedBowl });
                usesDictionaryItemItem.Add(otherHalfOfCrackedBowl, new List<Item> { halfOfCrackedBowl });
                
            }
            if (player1.Traits.ContainsKey("diligent")|| player1.Traits.ContainsKey("sadist")||player1.Traits.ContainsKey("medicine man")|| player1.Skill > 7)
            {
                
                if (player1.Traits.ContainsKey("sadist")) { mercInsignia.Description += "\nYou instantly recognise the emblem as that of a cut-throat gang you've long admired from afar. "; }
                else if (player1.Traits.ContainsKey("medicine man")) { mercInsignia.Description += "\nYou recall the emblem from the descriptions and stories their victims exchanged under the bloodied canvases of triage tents, many of whom you'd done your best to heal after many a sordid battle."; }
                else if (player1.Traits.ContainsKey("diligent")) { mercInsignia.Description += "\nYour diligent studies pay off as you recognise the emblem. "; }
                else { mercInsignia.Description += "\nYou recognise the emblem from your martial studies."; }
                mercInsignia.Description += "\nIt's the mark of the Vespasian Mercenaries, a group of infamous swords-for-hire for whom no work, no matter how bloody or deplorable, is off limits if the price is right. You reason that wearing this could prove useful if you wanted to pass yourself as a fellow merc...\nSo long, of course, that the other guards don't recognise your face, of course.";
            }
            /*
            List<string> parlances = new List<string> { "This is the first parlance", "second parlance string"};
            List<List<string>> playerChoices = new List<List<string>> { new List<string> { "This is the first player choice", "This is the second player choice: exit?", "this is the third one"}, new List<string> {"this is choice 4: start LoopParle", "this is choice 5" } };
            string description1 = "hullabaloo!";
            Dictionary<string, string> choice_CustomResponse = new Dictionary<string, string> 
            { 
                { "This is the first player choice", "1st custom response" }, 
                { "This is the second player choice: exit?", "2nd custom response" }, 
                { "this is the third one", "number 3 go!" },
                { "this is choice 4: start LoopParle", "custom response '4'?" },
                { "this is choice 5", "5 ~ the custom response of second line"}
            };
            
            Dialogue tester = new Dialogue(player1, goblin, trialBattle, room);
            if (tester.LinearParle(choice_CustomResponse, parlances, playerChoices, description1) == 0) 
            {
                tester.LoopParle(choice_CustomResponse, playerChoices[0], description1, parlances[0], 1);
            }
            */


            usesDictionaryItemItem[magnifyingGlass].Add(garment);

            Dictionary<Item, List<Player>> usesDictionaryItemChar = new Dictionary<Item, List<Player>> { [healPotion] = new List<Player> { player1 }, [FelixFelicis] = new List<Player> { player1 }, [elixirFeline] = new List<Player> { player1 }, [soot] = new List<Player> { player1}, [speedPotion] = new List<Player> { player1} };
            List<Feature> features = new List<Feature>();
            /*
            Combat tester = new Combat(goblin, gnoll, player1, null);
            tester.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, true, holeInCeiling, false, false);
            */
            
            List<Item> goblin2Inventory = new List<Item> { breadKnife, merigoldBroach};
            gnollInventory.Add(merigoldMedallion);
            
            Monster goblinCaptain = new Monster("goblin", "The goblin's swarthy, pock-marked skin does little to lessen the effect of its ugly snarl.", goblin2Inventory, 60, 0, breadKnife);
            Combat dualDuel = new Combat(goblinCaptain, gnoll, player1);
            Combat minotaurKafuffle = new Combat(minotaur, player1);
            /*
            Merigold m = new Merigold(player1, room);
            foreach (Dice d in m.MerigoldPlotPoint(specialItems, tougherBattle, secretChamber, goblin, gnoll, MGItems))
            {
                Console.WriteLine(d.Roll(d));
            }
            */
            Console.WriteLine($"You rouse yourself from your self-reflection. " +
                $"Who knows who, or what, this dubious curse-breaker is? Who knows what they have in store for you - or how their twisted designs might alleviate whatever Myrovia's curse is?");
            if (player1.Traits.ContainsKey("thespian"))
            {
                Console.WriteLine("And who, i tell you, *who* could possibly have thought your antics of feigned gallantry and cons would ever land you in this... predicament. You knew you should have stuck to stage acting.");
            }
            Console.WriteLine($" You resolve to find a way out of your predicament and this {room.Name}, and you intend to do it fast...");
            Console.ReadKey(true);
            Console.WriteLine("Will you...");
            
            Console.WriteLine("[1] Check what items are still on your person?");
            Console.WriteLine("[2] Investigate the room?");
            Console.WriteLine("[3] Try calling for help?");
            int a = 0;//tracks how many times you search your pack
            int b = 0;//tracks how many times you investigate the room
            int c = 0;//tracks how many times you try to call the guard
            int e = 0; //tracks how many items you've used. If you use too many your time runs out and you lose the game
            ///The previous choices are your base capabilities you'll keep returning to
            ///until more options open up. classes and their functions are repeatedly called 
            ///within each, making the game deeper than might first be expected.
            bool escapedRoom1 = false;
            bool escapedThroughDoor = true;
            bool fieryEscape = false;
            Stopwatch aq = new Stopwatch();
            long minotaurdoesnothing = 9999;
            bool justGrazing = true;
            while (!escapedRoom1)
            {
                /*
                player1.Inventory.Add(crystalBall);
                player1.Inventory.Add(throwingKnife);
                player1.Inventory.Add(lantern);
                player1.Inventory.Add(copperTrinket);
                player1.WeaponInventory.Add(vanquisher);
                player1.WeaponInventory.Add(stiletto);
                oubliette.FirstVisit = false;
                MGItems.Remove(staffMG);
                mosaic.SpecificAttribute = "studied";
                foreach(Item item in MGItems)
                {
                    player1.Inventory.Add(item);
                }
                escapedRoom1 = true;
                continue;
                */
                //
                //
                //
                for (int i = room.ItemList.Count - 1; i >= 0; i--)
                {
                    FungShui(room.ItemList[i].Name);
                }
                string reply = Console.ReadLine().Trim().ToLower();
                ///If player answers by typing number in list...
                try
                {

                    int reply1 = int.Parse(reply);
                    if (((a < 1 || b < 1) && (reply1 < 1 || reply1 > 3)) || (reply1 > 4) && (!player1.Inventory.Contains(musicBox) || !note.Description.Contains("blighter")) || reply1 > 5)
                    {
                        Console.WriteLine("Please enter a number corresponding to a choice of action.");
                        continue;
                    }
                    else if (reply1 == 1)
                    {
                        player1.SearchPack(room.ItemList, room, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                        a++;
                    }
                    else if (reply1 == 2)
                    {
                        ///when player discards rusty chains they may appear more than once. 
                        ///fungshui() is present to preempt that and prevent duplicates.
                        
                        room.Investigate(music, usesDictionaryItemChar, aq, minotaurdoesnothing, justGrazing, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                        b++;
                    }
                    else if (reply1 == 3)
                    {
                        c++;
                        
                        
                        
                        if (c == 1)
                        {
                            Console.WriteLine($"Somewhere not too far from beyond the confines of the {room.Name} a bestial guffaw can be heard. It seems whoever, or whatever, guards your cell cares little for your predicament. If you want their attention, you may need something louder that they can't ignore...");
                        }
                        else
                        {
                            Console.WriteLine($"Whatever creature lurks beyond the rosewood door does not respond or stir to your clamouring. They remain unconcerned.");
                        }
                        
                        Console.ReadKey(true);

                    }
                    
                    

                    else if (reply1 == 4) // for when player has searched their pack and the room at least once.
                    {
                        e++;
                        List<bool> success = new List<bool>();
                        
                        success = player1.UseItemOutsideCombat(music, room, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                        if (player1.Inventory.Contains(jailorKeys))
                        {
                            escapedThroughDoor = true;
                            escapedRoom1 = true;
                            continue;
                        }
                        
                        if (!success[0] && success[1])
                        {
                            return;
                        }
                        
                        else if (success[1])
                        {
                            Console.WriteLine("With the whole cell blazing around you, you snatch up the jailor's keys before you flee through the door. A fiery haze billows in your wake as you throw yourself into a corridor and slam the rosewood door shut behind you.");
                            if (player1.Inventory.Contains(bowlFragments)) { Console.WriteLine($"It's a moment before you realise your backpack is still smoking!\nOpening it up you scramble to save the contents, fishing out the {bowlFragments.Name} before they can burn everything, but it's too late. \nEverything inside your pack is burned and unusable!"); player1.Inventory.Clear(); Console.ReadKey(true); }
                            player1.Inventory.Add(jailorKeys);
                            escapedRoom1 = true;
                            escapedThroughDoor = true;
                            fieryEscape = true;
                            foreach (Item x in player1.Inventory) { while (x.Name.Contains("blazing") || x.Name.Contains("fiery") || x.Name.Contains("burning") || x.Name.Contains("smouldering") || x.Name.Contains("smoking")) { x.Name = x.Name.Substring(x.Name.IndexOf(" ")).Trim(); } }
                            foreach (Weapon x in player1.WeaponInventory) { while (x.Name.Contains("blazing") || x.Name.Contains("fiery") || x.Name.Contains("burning") || x.Name.Contains("smouldering") || x.Name.Contains("smoking")) { x.Name = x.Name.Substring(x.Name.IndexOf(" ")).Trim(); } }
                            continue;
                        }
                        
                        try
                        {
                            if (player1.WeaponInventory[0].Equipped)
                            {
                                if (trialBattle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false))
                                {
                                    trialBattle.WonFight(room);
                                    escapedThroughDoor = true;
                                    escapedRoom1 = true;
                                    player1.Unequip(player1.WeaponInventory);
                                    continue;
                                }
                                else
                                {
                                    Console.ReadKey(true);
                                    return;
                                }
                            }
                        }
                        catch { }
                        
                        if (room.FeatureList.Contains(holeInCeiling))
                        {
                            Console.WriteLine("Without further delay, you scramble up the mound of debris left by the hole and up into the next room.");
                            Console.ReadKey(true);
                            escapedRoom1 = true;
                            escapedThroughDoor = false;
                            continue;
                        }
                    }
                    else if (reply1 == 5) // The player solved the puzzle and must fight the goblin.
                    {
                        Console.WriteLine("You gaze at the innocuous music box nestled snugly in the palm of your hand. Biting your lip, you look to the rosewood door. The note said that whatever kept guard would be enraged by the tune this thing plays. Once opened there will be no going back...");
                        Console.WriteLine("Are you sure you wish to proceed?");
                        while (true)
                        {
                            string r3ply = Console.ReadLine();
                            if (r3ply == "no" || r3ply == "n")
                            {
                                Console.WriteLine("You gingerly place the music box back in your pack for now...");
                                break;
                            }
                            else if (r3ply == "yes" || r3ply == "y")
                            {
                                
                                Console.WriteLine("You prise open the music box. Immediately its brass cogs begin to whir as a jaunty melody fills the room. You find the tune to be lively and cheery, but it's not long before a furious, rage-filled roar erupts from beyond the door. In a flurry of instants, boots have pounded closer, someone fumbles at the lock of your door, and finally a frenzied goblin bursts inside, scimitar drawn. For a moment you think he'll smash the music box, but instead he lunges towards you...");
                                if (trialBattle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems))
                                {
                                    if (player1.Inventory.Contains(binkySkull))
                                    {
                                        Console.ReadKey(true);
                                        Console.WriteLine("\n\t'Just look at that,' Binky tuts, peering out of your backpack as you see if you've room for any more items. 'Honestly, where have all the good monsters gone these days, eh? I mean he isn't any Medusa or Circe or anything, but slouching on the job?' \n Your gaze matches his as you contemplate the sprawling bloody mess that was your foe. You answer that you're pretty sure the goblin's dead... right? As you speak a fly lands over its exposed eyeball before buzzing away. \n\t'Dead? Of course not! You're this story's hero! Hero's are never murderers, he's just bone idle!' \nYeah, you answer, you guess that makes sense... No, of course it does!\nWith your gleeful heart as light as an ever-so-teensy-bit-eccentric feather you skip over the corpse and ever onward in your quest!");
                                    }
                                    trialBattle.WonFight(room);
                                    if (room.FeatureList.Contains(holeInCeiling))
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("You now have a choice! Will you... \n[1] Escape the room through the door your goblin jailor left unlocked?\n[2] Or will you instead escape through the hole left in the ceiling? ");
                                            string answ3r = Console.ReadLine().Trim().ToLower();
                                            if (string.IsNullOrWhiteSpace
                                                (answ3r))
                                            {
                                                continue;
                                            }
                                            try
                                            {
                                                int answ3r1 = int.Parse(answ3r);
                                                if (answ3r1 < 1 || answ3r1 > 2)
                                                {
                                                    Console.WriteLine("Please enter either 1 or 2");
                                                    continue;
                                                }
                                                else if (answ3r1 == 1)
                                                {
                                                    Console.WriteLine("You rush through the door to escape!");
                                                    Console.ReadKey(true);
                                                    escapedRoom1 = true;
                                                    break;
                                                }
                                                else if (answ3r1 == 2)
                                                {
                                                    Console.WriteLine("You clamber up through the hole to escape!");
                                                    Console.ReadKey(true);
                                                    escapedRoom1 = true;
                                                    escapedThroughDoor = false;
                                                    break;
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Please enter 1 or 2");
                                                continue;
                                            }
                                            
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You rush through the door to escape!");
                                        Console.ReadKey(true);
                                        escapedRoom1 = true;
                                        break;
                                    }
                                }
                                else { return; }

                            }
                            else { Console.WriteLine("Please enter either 'yes' or 'no'."); }
                        }
                    }
                    if (e == 4)
                    {
                        e++;
                        Console.ReadKey(true);
                        Console.WriteLine("Suddenly, you hear heavy boots pound up close " +
                            "to the door of your cell. With trepidation you back away from the " +
                            "door, worrying what fate has in store for you should it open. You " +
                            "brace yourself to fight..." +
                            "\nHowever, the footsteps this time pass you by. They march into another room" +
                            ", from which issues muffled voices. Then as you strain to hear what's " +
                            " being said, a bloodcurdling scream shatters the near-silence." +
                            " \nYou shudder. You don't have long left. Best make the most of what time you have and " +
                            "escape. Fast!");
                        Console.ReadKey(true);
                    }
                    if (e > 7) // if the player fails to find an escape within a certain number of moves, then it's game over.
                    {
                        Console.ReadKey(true);
                        Console.WriteLine("You've tried as hard as you " +
                        "might to find some way out of the dank cell, but your " +
                        "time has finally run out. Heavy boots clomp outside your " +
                        "cell, a sardonic cackle sounds from the other side and" +
                        " you catch eerie, softly-spoken words; a new voice. It'" +
                        "s ominous tones state how you'll make for an excellent" +
                        " specimen. \n For a moment you hope the door to your " +
                        "cell might be opened - that you might have a chance to" +
                        " overpower the enemy. Instead an incantation is made" +
                        " and you reel from the braziers as their ethereal glow" +
                        " smoulders, plumes of dense smog erupting either side " +
                        "of the door.  The smoke fills the room, leaving you ha" +
                        "cking and choking, until you succumb to the enchanted " +
                        "gas' spell and plunge into a sleep from which you'll " +
                        "never awake. \n If there is one small mercy, it is that" +
                        " you'll be spared a species of terror utterly alien to" +
                        " you, as you'll never know how they " +
                        "defile your body.\n");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return;
                    }
                    if (!escapedRoom1)
                    {
                        Console.WriteLine("Now what will you do?");
                        Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the room?");
                        Console.WriteLine("[3] Try calling for help?");

                        if (a > 0 && b > 0)
                        {
                            Console.WriteLine("[4] Try using one of your items on something...");
                        }
                        if (player1.Inventory.Contains(musicBox) && note.Description.Contains("blighter"))
                        {
                            Console.WriteLine("[5] Open the music box?");
                        }
                    }

                }
                catch //and a check to make sure they know the correct input.
                {
                    Console.WriteLine("Please enter a number corresponding to your choice of action.");
                    continue;
                }



            }
            ///Past this point is the next room 

            if (!escapedThroughDoor)
            {
                Console.WriteLine("Finding yourself in a new room and on a new level of this perplexing (tower?), what will you decide to do next?");
                Console.ReadKey(true);

            }
            else if (escapedThroughDoor)
            {
                if (!rosewoodDoor.Description.Contains("dent"))
                {
                    rosewoodDoor.Description += " You notice a dent on the other side of the door.";
                }
                rosewoodDoor.SpecificAttribute = "unlocked";
                rosewoodDoor.Attribute = false;
            }
                int fireProgress = 0;
                if (fieryEscape)
                {
                    Console.WriteLine("Looking back, the door will only hold for so long against the flames and time is not your friend. What will you do?");
                    corridor.FeatureList[2].Description = "The smouldering rosewood door radiates intense heat as a fiery glow ominously flickers through the gap underneath. Tendrils of smoke cascade upwards and the cast iron hinges are scolding to the touch.\nYou best get away from here post haste!";                    
                    corridor.FeatureList[2].CastDoor().Portal = new List<Room> { corridor, corridor};
                    fireProgress = 1;
                    Console.ReadKey(true);
                    player1.FieryEscape = true;
                    minotaur.Location = oceanBottom;
                    minotaur.Path = new List<Room> { northernmostCorridor };
                    minotaur.Items.Remove(magManKey);
                    
                }
                else if (escapedThroughDoor)
                {
                    Console.WriteLine("With the way ahead clear, what will you do?");                    
                    Console.ReadKey(true);
                    
                }
                
                
                int FireProgress(int fireProgress, Player player1, Room newRoom1) // returns (still alive?)
                {
                    if (fireProgress > 0) 
                    {
                        fireProgress++;
                    }
                    else
                    {
                        return fireProgress;
                    }
                    if (newRoom1.Name == "long corridor")
                    {
                        switch (fireProgress)
                        {
                            case 1:
                                return fireProgress;
                            case 2:
                                Console.WriteLine("The smouldering door of your cell begins to blaze, crumbling into glowing charcoal as the flames roar behind it. Tendrils of smoke swell and stream from beneath the door, filling the corridor with an acrid haze. You begin to splutter and stagger. \nLose 3 stamina points!");
                                player1.Stamina -= 3;
                                Console.ReadKey(true);
                                if (player1.Stamina < 1)
                                {
                                    Console.ReadKey(true);
                                    Console.WriteLine("On your last legs, bleeding profusely from your battle, the smoke proves to be too much for you. \nYou pass out. Soon enough the fire will consume you.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\nYour adventure ends here...");
                                    return 1000;
                                }
                                return fireProgress;
                            case 3:
                                return fireProgress;
                            case 4:
                                return fireProgress;
                            case 5:
                                Console.WriteLine("The smouldering door of your cell collapses, a blizzard of flames suddenly blasting into the corridor. You get thrown back by the fiery gust. \nLose 10 stamina points!");
                                corridor.Description = "The light cast by those strange braziers is rapidly being overwhelmed by the haze of smoke. The fire roars from your room and is catching down the smouldering corridor. The passage of grim stone walls and rickety floorboards swells with smoke. To the left, through the haze, the blackness of the stairwell beckons, while to the right lies a wide flight of stone stairs. \nTo the north you face another door similar to the ornate rosewood door behind you.\t\nTurning your gaze west down the shadowy passage you see the flickering braziers leading towards a dark stairwell, descending beyond the inky blackness to unknown depths.\t\nTurning your head south the ornate rosewood door to your own former cell meets your gaze.\t\nTo the east the passageway leads past more doors up to a flight of stairs, ascending to the next level of whatever building or (tower?) you find yourself in.\t\t";
                                player1.Stamina -= 10;
                                Console.ReadKey(true);
                                if (player1.Stamina < 1)
                                {
                                    Console.ReadKey(true);
                                    Console.WriteLine("On your last legs, severe burns covering your body, the fire at last proves to be too much for you. \nYou pass out. Soon enough the fire will consume you.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\nYour adventure ends here...");
                                    return 1000;
                                }
                                return fireProgress;
                            case 6:
                                return fireProgress;
                            case 7:
                                Console.WriteLine("The fire rages into an inferno! Flames lick at the doors and the flames in the braziers no longer cast their frosty light - their low flames become overrun by the roaring fire rapidly devouring the entire corridor, transforming it into a hellish portal. The heat threatens to torch you alive! \nLose 12 stamina points!");
                                player1.Stamina -= 12;
                                Console.ReadKey(true);
                                if (player1.Stamina < 1)
                                {
                                    Console.ReadKey(true);
                                    Console.WriteLine("On your last legs, severe burns covering your body, the fire at last proves to be too much for you. \nYou pass out. Soon enough the fire will consume your body.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\nYour adventure ends here...");
                                    return 1000;
                                }
                                Console.WriteLine("You have only one way forward - the stairwell down and the doors to the east are cut off by the flames, you must press on ever higher up the stairs to the east!");
                                List<string> fireWords = new List<string>
                            {
                                "blazing",
                                "burning",
                                "smoking",
                                "smouldering",
                                "flaming",
                                "fiery"
                            };

                                foreach (Item item in newRoom1.ItemList)
                                {
                                    item.Name = fireWords[D6.Roll(D6) - 1] + " " + item.Name;
                                }
                                newRoom1.FeatureList.RemoveRange(0, 7);

                                return fireProgress;
                            default:
                                Console.WriteLine("You collapse amidst a swirl of smoke. Your body is consumed by the inferno you started.");
                                Console.ReadKey(true);
                                Console.WriteLine("Your adventure ends here...");
                                return 1000;
                        }
                    }
                    else if(newRoom1.Name == "antechamber")
                    {
                        switch (fireProgress)
                        {
                            case 1:
                                return fireProgress;
                            case 2:
                                Console.WriteLine("You hear the distant flames roar from atop the stairway. Tendrils of smoke swell from the corridor and begin to unfurl up the roof of those stairs. An acrid haze assaults your senses even from the antechamber.");
                                
                                Console.ReadKey(true);
                                if (player1.Stamina < 1)
                                {
                                    Console.ReadKey(true);
                                    Console.WriteLine("On your last legs, bleeding profusely from your battle, the smoke proves to be too much for you. \nYou pass out. Soon enough the fire will consume you.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\nYour adventure ends here...");
                                    return 1000;
                                }
                                return fireProgress;
                            case 3:
                                return fireProgress;
                            case 4:
                                return fireProgress;
                            case 5:
                                threadPath.RemoveAll(r => r.Name == "long corridor");
                                threadPath.RemoveAll(r => r.Name == "fiery cell");
                                threadPath.RemoveAll(r => r.Name == "dank cell");
                                threadPath.RemoveAll(r => r.Name == "empty cell");
                                threadPath.RemoveAll(r => r.Name == "eerie cell");
                                threadPath.RemoveAll(r => r.Name == "dungeon chamber");
                                threadPath.RemoveAll(r => r.Name == "secret chamber");
                                Console.WriteLine("You hear the smouldering door of your cell finally collapse, and from atop the stairway you can see a hellish red glow adorn the walls up to the antechamber. The fire has been unleashed and expanded into the corridor. As the acrid haze swells further, you begin to splutter and cough. \nLose 3 stamina points!");
                                corridor.Description = "The light cast by those strange braziers is rapidly being overwhelmed by the haze of smoke. The fire roars from your room and is catching down the smouldering corridor. The passage of grim stone walls and rickety floorboards swells with smoke. To the left, through the haze, the blackness of the stairwell beckons, while to the right lies a wide flight of stone stairs. \nTo the north you face another door similar to the ornate rosewood door behind you.\t\nTurning your gaze west down the shadowy passage you see the flickering braziers leading towards a dark stairwell, descending beyond the inky blackness to unknown depths.\t\nTurning your head south the ornate rosewood door to your own former cell meets your gaze.\t\nTo the east the passageway leads past more doors up to a flight of stairs, ascending to the next level of whatever building or (tower?) you find yourself in.\t\t";
                                player1.Stamina -= 3;
                                Console.ReadKey(true);
                                if (player1.Stamina < 1)
                                {
                                    Console.ReadKey(true);
                                    Console.WriteLine("On your last legs, the smoke suffocating you, the fire at last proves to be too much for you. \nYou pass out. Soon enough the fire will consume you.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\nYour adventure ends here...");
                                    return 1000;
                                }
                                return fireProgress;
                            case 6:
                                threadPath.RemoveAll(r => r.Name == "long corridor");
                                threadPath.RemoveAll(r => r.Name == "fiery cell");
                                threadPath.RemoveAll(r => r.Name == "dank cell");
                                threadPath.RemoveAll(r => r.Name == "empty cell");
                                threadPath.RemoveAll(r => r.Name == "eerie cell");
                                threadPath.RemoveAll(r => r.Name == "dungeon chamber");
                                threadPath.RemoveAll(r => r.Name == "secret chamber");
                                return fireProgress;
                            case 7:
                                threadPath.RemoveAll(r => r.Name == "long corridor");
                                threadPath.RemoveAll(r => r.Name == "fiery cell");
                                threadPath.RemoveAll(r => r.Name == "dank cell");
                                threadPath.RemoveAll(r => r.Name == "empty cell");
                                threadPath.RemoveAll(r => r.Name == "eerie cell");
                                threadPath.RemoveAll(r => r.Name == "dungeon chamber");
                                threadPath.RemoveAll(r => r.Name == "secret chamber");
                                Console.WriteLine("The fire rages into an inferno! Flames lick at the panelled walls up the stairway, as flurries of embers, whisked up by the ever swelling smoke, cascade into the antechamber around you. Those swirling embers steadily bloom and catch light all that's flammable, whilst the stairs below transfigure into a hellish portal of towering flames. \nLose 10 stamina points as the acrid haze stings your lungs!");
                                player1.Stamina -= 10;
                                Console.ReadKey(true);
                                if (player1.Stamina < 1)
                                {
                                    Console.ReadKey(true);
                                    Console.WriteLine("On your last legs, severe burns covering your body, the fire at last proves to be too much for you. \nYou pass out. Soon enough the fire will consume your body.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\nYour adventure ends here...");
                                    return 1000;
                                }
                                Console.WriteLine("You have only one way forward - the lit stairway down to the corridor has now been cut off by the flames. You must press on through the double doors or face certain death!");
                                List<string> fireWords = new List<string>
                            {
                                "blazing",
                                "burning",
                                "smoking",
                                "smouldering",
                                "flaming",
                                "fiery"
                            };

                                
                                
                                newRoom1.FeatureList[0].Attribute = true;
                                newRoom1.FeatureList[0].SpecificAttribute = "blocked";
                                newRoom1.FeatureList[0].Description = "The stairway down is nought but a portal spewing smoke and a blizzard of embers that torch the skin like a dragon's fiery breath. You are not getting through there...";
                                return fireProgress;
                            case 8:
                                if (player1.Inventory.Contains(redThread) && redThread.SpecifyAttribute == "unspooled")
                                {
                                    Console.WriteLine("The red thread you left behind you has been reduced to nought but ash!");
                                    Console.ReadKey(true);
                                    player1.Inventory.Remove(redThread);
                                }
                                threadPath.RemoveAll(r => r.Name == "long corridor");
                                threadPath.RemoveAll(r => r.Name == "fiery cell");
                                threadPath.RemoveAll(r => r.Name == "dank cell");
                                threadPath.RemoveAll(r => r.Name == "empty cell");
                                threadPath.RemoveAll(r => r.Name == "eerie cell");
                                threadPath.RemoveAll(r => r.Name == "dungeon chamber");
                                threadPath.RemoveAll(r => r.Name == "secret chamber");
                                newRoom1.FeatureList[0].Attribute = true;
                                newRoom1.FeatureList[0].SpecificAttribute = "blocked";
                                newRoom1.FeatureList[0].Description = "The stairway down is nought but a portal spewing smoke and a blizzard of embers that torch the skin like a dragon's fiery breath. You are not getting through there...";
                                return fireProgress;
                            case 9:
                                threadPath.RemoveAll(r => r.Name == "long corridor");
                                threadPath.RemoveAll(r => r.Name == "fiery cell");
                                threadPath.RemoveAll(r => r.Name == "dank cell");
                                threadPath.RemoveAll(r => r.Name == "empty cell");
                                threadPath.RemoveAll(r => r.Name == "eerie cell");
                                threadPath.RemoveAll(r => r.Name == "dungeon chamber");
                                threadPath.RemoveAll(r => r.Name == "secret chamber");
                                newRoom1.FeatureList[0].Attribute = true;
                                newRoom1.FeatureList[0].SpecificAttribute = "blocked";
                                newRoom1.FeatureList[0].Description = "The stairway down is nought but a portal spewing smoke and a blizzard of embers that torch the skin like a dragon's fiery breath. You are not getting through there...";
                                return fireProgress;
                            case 10:
                                threadPath.RemoveAll(r => r.Name == "antechamber");
                                threadPath.RemoveAll(r => r.Name == "armoury");
                                Console.WriteLine("Fire has tangled the antechamber like a briar whilst you tried to scare up some method of opening the double doors and racing ahead of the inferno. You find yourself winding through a hellscape of smog and blizzards of ash, almost unable to find your way as the room begins to spin. You must find some escape now, or perish...\nLose 16 stamina!");
                                Console.ReadKey(true);
                                player1.Stamina -= 16;
                                if (player1.Stamina < 1)
                                {
                                    
                                    Console.WriteLine("On your last legs, severe burns covering your body, the fire at last proves to be too much for you. \nYou pass out. Soon enough the fire will consume your body.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\nYour adventure ends here...");
                                    return 1000;
                                }
                                List<string> fireWord = new List<string>
                                {
                                    "blazing",
                                    "burning",
                                    "smoking",
                                    "smouldering",
                                    "flaming",
                                    "fiery"
                                };
                                foreach (Feature feature in newRoom1.FeatureList)
                                {
                                    feature.Name = fireWord[D6.Roll(D6) - 1] + " " + feature.Name;
                                }
                                return fireProgress;
                            case 11:
                                return fireProgress;
                            default:
                                Console.WriteLine("You collapse amidst a swirl of smoke. Your body is consumed by the inferno you started.");
                                Console.ReadKey(true);
                                Console.WriteLine("Your adventure ends here...");
                                
                                return 1000;
                        }
                    }
                    return fireProgress;
                }
                List<bool> leftWhichRooms = new List<bool> {true, false, true, true, true, true, 
                true, true, true, true, true, true, true, true, true, true, true, true, true, true, 
                true, true, true, true, true};
                List<Room> choiceVersusDestination = new List<Room>();
                Room newRoom1 = corridor;
                if (!escapedThroughDoor)
                {
                    
                    newRoom1 = secretChamber;
                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                }
                bool victorious = false;
                bool visitedRoom = true;
                bool visitedArmouryBefore = false;
                long minotaurAlerted = 0;
                int b1 = 0;
                Stopwatch fireClock = new Stopwatch();
                fireClock.Start();
                long fireTimeLapsed = 0;
                bool visitedCorridor = false;
                bool showFireMessage = true;
            //
            //
            //
            /*
            newRoom1 = highestParapet;
            leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
            */
            //
            //
            //
                while (!victorious)
                {
                    
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail);corridorItems.Add(splinter); corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    b = 0;
                    a = 0;
                    long minotaurAlertedBy = D6.Roll(D6) * 8000;
                    Stopwatch sw = new Stopwatch();
                    justStalked = false;
                    minotaurAlerted = 0;
                    if (!leftWhichRooms[1] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[1])//corridor
                    {
                        if (discovery)
                        {
                            Console.WriteLine($"Upon returning to the corridor you hastily open your pack to see what the mystery item you discovered is. To your surprise you found a pocket watch! {pocketWatch.Description}.\nYou stash it back in your backpack for safekeeping.");
                            Console.ReadKey(true);
                            discovery = false;
                        }
                        if (visitedCorridor)
                        {
                            
                            fireClock.Stop();
                            fireTimeLapsed = fireClock.ElapsedMilliseconds;
                            if(fireProgress > 0 && fireProgress < 5 && fireTimeLapsed > 360000)
                            {
                                fireProgress = 4;
                                fireProgress = FireProgress(fireProgress, player1, corridor);
                                if (fireProgress > 999)
                                {
                                    return;
                                }
                                fireClock.Start();
                            }
                            else if(fireProgress > 4 && fireProgress < 7 && fireTimeLapsed > 840000)
                            {
                                fireProgress = 6;
                                fireProgress = FireProgress(fireProgress, player1, corridor);
                                if (fireProgress > 999)
                                {
                                    return;
                                }
                            }
                            if (fireProgress < 7)
                            {
                                fireClock.Start();
                            }
                            
                        }
                        stairwayToUpper.Description = "The wide flight of stone steps slowly curves around, leading to somewhere unseen but well-lit.";
                        stairwayToLower.Description = "The steep stone steps descend beyond the light of the braziers and into the unknown murk lurking below. Without some sort of light that can dispel the impenetrable darkness beneath your feet, you might want to think carefully before navigating this slippery and hazardous passage.";
                        if (stairwayToLower.Dark)
                        {
                            stairwayToLower.Passing = "Feeling a knot of dread tighten about your stomach, you make the descent into a shifting web of shadows and silhouettes...";
                            stairwayToLower.Description = "The steep stone steps descend beyond the light of the braziers and into the unknown murk lurking below. Without some sort of light that can dispel the impenetrable darkness beneath your feet, you might want to think carefully before navigating this slippery and hazardous passage.";
                        }
                        else
                        {
                            stairwayToLower.Passing = "With Merigolds enchantment lifting the magical darkness you can see for the first time how truly treacherous these crooked stone steps really are. Knowing time is against you as midnight approaches, you throw caution to the wind and race down them...";
                            stairwayToLower.Description = "The steep stone steps, alighted by Merigold's spell, spiral down into the unknown. You still might want to think twice before navigating this slippery and hazardous passage.";
                        }
                        visitedRoom = true;
                        corridor.ItemList.Add(garment);
                        corridor.ItemList.Add(rustyChains);
                        corridor.ItemList.Add(bowlFragments);
                        corridor.ItemList.Add(looseNail);
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item>{ bobbyPins});
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto});
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    if (!usesDictionaryItemFeature.ContainsKey(jailorKeys))
                        {
                            
                            usesDictionaryItemFeature.Add(jailorKeys, new List<Feature> { emptyCellDoor, otherRosewoodDoor });
                        }
                        if (!usesDictionaryItemFeature.ContainsKey(lockpickingSet))
                        {
                            usesDictionaryItemFeature.Add(lockpickingSet, new List<Feature> { emptyCellDoor, otherRosewoodDoor, circleDoor, magManDoor });
                        }
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(corridor, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Path.Count > 1) 
                                { 
                                    if (minotaur.Path[1] == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) 
                                    { 
                                        corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; 
                                    } 
                                }
                                if (minotaur.Location == corridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, corridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(corridor);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(corridor, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != corridor) { continue; }
                            }
                            }
                            else if (minotaur.Location == corridor)
                            {
                                
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, corridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(corridor);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == corridor)
                            {
                                if (minotaur.Location.ItemList.Contains(musicBox))
                                {
                                    Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster approaches!");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a==0 && b1 == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the corridor?");
                        if (b1 > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        if (!justStalked && minotaurAlerted > minotaurAlertedBy && (minotaur.Location == cellOpposite || minotaur.Location == emptyCell || minotaur.Location == room || minotaur.Location == dungeonChamber || minotaur.Location == antechamber))
                        {


                            if (minotaur.Path.Count > 1)
                            {
                                newRoom1 = minotaurApproaches(corridor, minotaur, false, 14000, false, minotaur.Rage);
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 == corridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }
                                else if (newRoom1 == minotaur.Location)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }

                            }
                            continue;
                        }
                        try
                        {
                            int j = player1.Stamina;
                            int reply1 = int.Parse(reply);
                            if ((b1<1 && (reply1 < 1 || reply1 > 2)) || reply1<1 || reply1>3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                            corridor.ItemList.Remove(garment);
                            corridor.ItemList.Remove(rustyChains);
                            corridor.ItemList.Remove(bowlFragments);
                            corridor.ItemList.Remove(looseNail);
                            player1.SearchPack(corridor.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;
                                fireProgress = FireProgress(fireProgress, player1, corridor);
                                if (fireProgress > 999)
                                {
                                    return;
                                }
                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.
                                corridor.ItemList.Remove(garment);
                                corridor.ItemList.Remove(rustyChains);
                                corridor.ItemList.Remove(bowlFragments);
                                corridor.ItemList.Remove(looseNail);
                                Room newRoom = corridor.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b1, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != corridor.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    break;
                                }
                                else
                                {
                                    fireProgress = FireProgress(fireProgress, player1, corridor);
                                    if (fireProgress > 999)
                                    {
                                        return;
                                    }
                                }

                                b1++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                corridor.ItemList.Remove(garment);
                                corridor.ItemList.Remove(rustyChains);
                                corridor.ItemList.Remove(bowlFragments);
                                corridor.ItemList.Remove(looseNail);
                                success = player1.UseItemOutsideCombat(music, corridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                fireProgress = FireProgress(fireProgress, player1, corridor);
                                if (fireProgress > 999)
                                {
                                    return;
                                }
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            corridor.ItemList.Remove(garment);
                            corridor.ItemList.Remove(rustyChains);
                            corridor.ItemList.Remove(bowlFragments);
                            corridor.ItemList.Remove(looseNail);
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    visitedCorridor = true;
                    if (visitedRoom)
                    {
                        if (leftWhichRooms[20])
                        {
                            Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        }
                        visitedRoom = false;
                    }
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    b = 0;
                    a = 0;
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    justStalked = false;
                    sw = new Stopwatch();
                    if (!leftWhichRooms[0] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("The red thread unspools, trailing behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[0]) // your cell
                    {
                        if (room.FeatureList.Contains(holeInCeiling))
                        {
                            secretChamber.Description = "You clamber into an eerie chamber of disquieting shapes imposed upon velvety darkness; a dusky landscape of sinister contours and unknown threats alleviated only slightly from the faint moon-like glow of the strange braziers below. As your eyes adjust to your new surroundings, and you can begin to make out the statues and artefacts within, you feel a cold tot of anxiety tie knots in your stomach as you realise the secret chamber has no doors or windows. Instead, as you'll come to realise, you have stumbled upon a glimpse through a keyhole into the mind of the CurseBreaker. One no one was ever meant to see...\nFacing north is some kind of statue, or perhaps a shrine. Unlit candles are arranged beneath a marble figure. Normally they'd cast it in a fiery glow, but instead the braziers' light through the hole you climbed through toss angular and tortured shadows over the chiselled face of a man crying out in anguish for all eternity. Chained to a rock, an eagle eviscerates and devours his innards as his form, frozen in stone, screams silent screams. A plaque lays at its base, while you can just detect misty jars glinting to its left. \t\nTurning your gaze westward, and squinting your eyes, you can distinguish the shape of a bookcase from within the web of shadows. \t\n To the south you find a portrait hung upon the wall of a man with chiropteric wings. \t\nLooking eastwards you discover something that seems to rattle in the darkness. Investigating further, wading through an agglomeration of arcane baubles and esoteric devices stashed and long forgotten, you find the source of the ominous rattling is a mosaic. It's tiles flip and shuffle like playing cards in the dextrous hands of an invisible dealer. They finally settle on the image of a non-descript face, gazing down upon you...\t\t";
                        }    
                        visitedRoom = true;
                        holeInCeiling.Name = "hole in ceiling";
                        holeInCeiling.Description = "You gaze from the heap of debris that has buried the creature alive to the hole through the ceiling above. You bet you could climb the heap and enter the room above yours.";
                        holeInCeiling.Passing = "You scramble up the mound of debris, heft yourself up through the hole and into a new room...";
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    if (!usesDictionaryItemFeature.ContainsKey(lockpickingSet))
                        {
                            usesDictionaryItemFeature.Add(lockpickingSet, new List<Feature> { emptyCellDoor, otherRosewoodDoor, circleDoor, magManDoor });
                        }
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(room, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == room)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(room);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(room, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != room) { continue; }
                            }
                            }
                            else if (minotaur.Location == room)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(room);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == room)
                            {
                                if (minotaur.Location.ItemList.Contains(musicBox))
                                {
                                    Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster approaches!");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(room.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;
                                
                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = room.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != room.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, room, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    if (minotaur.Path.Count == 1)
                    {
                        justStalked = false;
                    }
                    else { justStalked = true; }
                    sw = new Stopwatch();
                    b = 0;
                    a = 0;
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[2] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("The red thread trails behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[2])//oubliette : no return through hatch!
                    {
                        ///might want to add treacherous passage here test skill fall down steps
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    // throwing knife on pentagram
                        if (!usesDictionaryItemFeature.ContainsKey(lockpickingSet))
                        {
                            usesDictionaryItemFeature.Add(lockpickingSet, new List<Feature> { emptyCellDoor, otherRosewoodDoor, circleDoor, magManDoor });
                        }
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                    ///enter new Dictionaries for item use here
                    ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                    ///red herring in room above
                    ///Specific for each room, tailored.
                    if (b != 0)
                    {
                        oubliette.FirstVisit = false;
                        ArchFey LadyOfVipers = new ArchFey(player1, goblin, trialBattle, oubliette);
                        if (LadyOfVipers.ElderArchFeyPlotPoint(magicalManufactory, mosaic))
                        {
                            List<string> LadyGoodHits = new List<string> 
                            {
                                
                                
                                "The Lady of Vipers lives up to her name as she spits steaming venom in your face, you scream for minutes before the acid finally eats away your skull...",
                                "The Lady of Vipers flails blindly, opening a gash in your arm...",
                                "The Lady of Vipers attacks blindly, slashing through your armour...",
                                "The Lady chances a glancing hit!",

                                "Flailing blindly, the dark Lady at last sends you flying into a far wall - your neck snaps as you collapse like a rag doll to the ground...",
                                "The monster tracks the sound of your breathing. She swipes in your direction, tearing into your leg with her bloody talon... ",
                                "The dark Lady cackles as she sends you crashing to the ground!",
                                "The Lady's feelers trip you up!",

                                "With one blind swipe of her talons, the monster cuts you open from hip to shoulder. You stare down at your shattered ribs as your innards gloop to the floor...",
                                "The Lady of Vipers strikes with her venom. Lucky for you its a glancing hit - you only glance it eat away at the flagstones before you dart ahead...",
                                "The Lady of Vipers attacks blindly, slashing through your armour...",
                                "The Lady lunges blindly at you, grazing you!",

                                "The Lady impales you with her hooked appendages. You're still alive and screaming as she begins eviscerating you...",
                                "The Lady of Vipers pins you to the ground! She skewers your shoulder before you manage to free yourself...",
                                "The Lady of Vipers strikes with her venom. Lucky for you its a glancing hit - you only glimpse it eat away at the flagstones before you dart ahead...",
                                "The Lady gropes for you in the dark with her many talons!"

                            };
                            Dice D80 = new Dice(80);
                            List<Dice> clawDamage = new List<Dice> { D80 };
                            Weapon deadlyClaws = new Weapon("claws", "They're going to hurt...", clawDamage, defaultCritHits, LadyGoodHits, 0);
                            Weapon venomousSting = new Weapon("venomous sting", "Youch!", clawDamage, defaultCritHits, defaultGoodHits);
                            List<Item> purse = new List<Item> { venomousSting, dustBunny };
                            Monster ArchFeyQueen = new Monster("Lady of Vipers", "Transfigured into one of her most frightful avatars, mounted on frayed bat wings that scuttle blindly towards you like a tarantula, this powerful creature will find all kinds of fun ways to make your demise slow and enjoyable... if she can catch you.", purse, 666, -10, deadlyClaws);
                            Combat LadyOfVipersRace = new Combat(ArchFeyQueen, player1);
                            if(LadyOfVipersRace.Race(music, speedPotion, throwables, oubliette, usesDictionaryItemItem, usesDictionaryItemFeature, player1, usesDictionaryItemChar, holeInCeiling, specialItems))
                            {
                                newRoom1 = highestParapet;
                                leftWhichRooms = highestParapet.WhichRoom(leftWhichRooms);
                                //Upon the highest parapet the dark figure completes their incantation, wait with bated breath, finger of god descend from skies, if fiery escape scene of fire below, dialogue
                                // add commentary on CurseBreaker completing their rite during end of race?
                                // add section of race where dark lady unleashes a flurry of attacks near portal?
                                break;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }    
                    if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");// immediately called over by trapped 'pixie'
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(oubliette.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = oubliette.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != oubliette.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, oubliette, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[3] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You track your path with the red thread...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    if (minotaur.Path.Count == 1)
                    {
                        justStalked = false;
                    }
                    else { justStalked = true; }
                    sw = new Stopwatch();
                    while (!leftWhichRooms[3])//antechamber
                    {
                        string deleteString = "For a few moments the sight of its extravagance, so vastly different from your previous surroundings, takes your breath away.";
                        if (antechamber.Description.Contains(deleteString))
                        {
                            newRoom1.Description.Remove(newRoom1.Description.IndexOf(".") + 1, deleteString.Length);
                        }

                        fireClock.Stop();
                        fireTimeLapsed = fireClock.ElapsedMilliseconds;
                        if (fireProgress > 0 && fireProgress < 5 && fireTimeLapsed > 360000)
                        {
                            fireProgress = 4;
                            fireProgress = FireProgress(fireProgress, player1, antechamber);
                            if (fireProgress > 999)
                            {
                                return;
                            }
                            fireClock.Start();
                        }
                        else if (fireProgress > 4 && fireProgress < 7 && fireTimeLapsed > 840000)
                        {
                            fireProgress = 6;
                            fireProgress = FireProgress(fireProgress, player1, antechamber);
                            if (fireProgress > 999)
                            {
                                return;
                            }
                        }
                        else if (fireProgress > 6 && fireProgress < 10 && fireTimeLapsed > 1200000)
                        {
                            threadPath.RemoveAll(r => r.Name == "long corridor");
                            threadPath.RemoveAll(r => r.Name == "fiery cell");
                            threadPath.RemoveAll(r => r.Name == "dank cell");
                            threadPath.RemoveAll(r => r.Name == "empty cell");
                            threadPath.RemoveAll(r => r.Name == "eerie cell");
                            threadPath.RemoveAll(r => r.Name == "dungeon chamber");
                            threadPath.RemoveAll(r => r.Name == "secret chamber");
                            threadPath.RemoveAll(r => r.Name == "armoury");
                            threadPath.RemoveAll(r => r.Name == "antechamber");
                            fireProgress = 9;
                            fireProgress = FireProgress(fireProgress, player1, antechamber);
                            if (fireProgress > 999)
                            {
                                return;
                            }
                        }
                        if (fireProgress < 12)
                        {
                            fireClock.Start();
                        }
                        if (fireProgress > 6)
                        {
                            stairwayToUpper.Attribute = true;
                            stairwayToUpper.SpecificAttribute = "blocked";
                            stairwayToUpper.Description = "Peering down the stairway you see a fiery glow flicker upon the opposite wall where it curves around to the corridor. A fiery haze lurks like a ravenous beast below, as intense furnace-like heat buffets against you...\nThere's no way you're getting down there.";
                        }
                        else { stairwayToUpper.Description = "The wide flight of stone steps slowly curves around, leading to the frosty light of the corridor below..."; }
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                        usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                        usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                        usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        antechamber.ItemList.Add(clunkySabaton);
                        antechamber.ItemList.Add(breastplate);
                        antechamber.ItemList.Add(helmet);
                        antechamber.ItemList.Add(bracers);
                        if (!usesDictionaryItemFeature.ContainsKey(circleDoorKey))
                        {
                            usesDictionaryItemFeature.Add(circleDoorKey, new List<Feature> { circleDoor });
                        }
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(antechamber, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Path.Count > 1)
                                {
                                    if (minotaur.Path[1] == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt."))
                                    {
                                        antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(looseNail); antechamber.ItemList.Add(splinter); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.";
                                    }
                                }
                                if (minotaur.Location == antechamber)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, antechamber, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(antechamber);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(antechamber, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != antechamber) { continue; }
                            }
                            }
                            else if (minotaur.Location == antechamber)
                            {
                                if (minotaur.Path[1] == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }

                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, antechamber, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(antechamber);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == antechamber)
                            {
                                if (minotaur.Path[1] == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }

                                if (minotaur.Location.ItemList.Contains(musicBox))
                                {
                                    Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster approaches!");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        if (!justStalked && minotaurAlerted > minotaurAlertedBy && (minotaur.Location == westernmostCorridor || minotaur.Location == armoury || minotaur.Location == corridor))
                        {


                            if (minotaur.Path.Count > 1)
                            {
                                newRoom1 = minotaurApproaches(antechamber, minotaur, false, 14000, false, minotaur.Rage);
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 == antechamber)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }
                                else if (newRoom1 == minotaur.Location)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }

                            }
                            continue;
                        }
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                            antechamber.ItemList.Remove(clunkySabaton);
                            antechamber.ItemList.Remove(breastplate);
                            antechamber.ItemList.Remove(helmet);
                            antechamber.ItemList.Remove(bracers);
                            player1.SearchPack(antechamber.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;
                                fireProgress = FireProgress(fireProgress, player1, antechamber);
                                antechamber.FirstVisit = false;
                                if (fireProgress > 999)
                                {
                                    return;
                                }
                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.
                                antechamber.ItemList.Remove(clunkySabaton);
                                antechamber.ItemList.Remove(breastplate);
                                antechamber.ItemList.Remove(helmet);
                                antechamber.ItemList.Remove(bracers);
                                Room newRoom = antechamber.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                antechamber.FirstVisit = false;
                                if (newRoom.Name != antechamber.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                fireProgress = FireProgress(fireProgress, player1, antechamber);
                                if (fireProgress > 999)
                                {
                                    return;
                                }

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                antechamber.ItemList.Remove(clunkySabaton);
                                antechamber.ItemList.Remove(breastplate);
                                antechamber.ItemList.Remove(helmet);
                                antechamber.ItemList.Remove(bracers);
                                success = player1.UseItemOutsideCombat(music, antechamber, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                fireProgress = FireProgress(fireProgress, player1, antechamber);
                                if (fireProgress > 999)
                                {
                                    return;
                                }
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            antechamber.ItemList.Remove(clunkySabaton);
                            antechamber.ItemList.Remove(breastplate);
                            antechamber.ItemList.Remove(helmet);
                            antechamber.ItemList.Remove(bracers);
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                            antechamber.ItemList.Remove(clunkySabaton);
                            antechamber.ItemList.Remove(breastplate);
                            antechamber.ItemList.Remove(helmet);
                            antechamber.ItemList.Remove(bracers);
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    if (minotaur.Path.Count == 1)
                    {
                        justStalked = false;
                    }
                    else { justStalked = true; }
                    sw = new Stopwatch();
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[4] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[4])//eerie cell
                    {
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    //usesDictionaryItemFeature[jailorKeys].Remove(otherRosewoodDoor);
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (minotaur.Stamina > 0)
                        {
                        if (!minotaur.MinotaurReturning(cellOpposite, redThread, musicBox, threadPath, player1))
                        {
                            if (minotaur.Location == cellOpposite)
                            {
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, cellOpposite, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(cellOpposite);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaurAlerted > minotaurAlertedBy)
                            {
                                justStalked = true;
                                newRoom1 = minotaurStalks(cellOpposite, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                if (newRoom1 == oceanBottom)
                                {
                                    return;
                                }
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != cellOpposite) { continue; }
                            }
                        }
                        else if (minotaur.Location == cellOpposite)
                        {
                            Console.WriteLine("The hulking monster at last locks eyes with you!");
                            Console.ReadKey(true);
                            Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                            Console.ReadKey(true);
                            if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, cellOpposite, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                            {
                                minotaurKafuffle.WonFight(cellOpposite);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else if (minotaur.Path[1] == cellOpposite)
                        {
                            if (minotaur.Location.ItemList.Contains(musicBox))
                            {
                                Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                Console.ReadKey(true);
                            }
                            else
                            {
                                Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster approaches!");
                                Console.ReadKey(true);
                            }
                        }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(cellOpposite.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = cellOpposite.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != cellOpposite.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }


                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, cellOpposite, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    justStalked = false;
                    sw = new Stopwatch();
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[5] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("The red thread unspools, trailing behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[5])//armoury 
                    {
                        
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    try
                        {
                            if (!usesDictionaryItemFeature[magManKey].Contains(goodWeaponRack)) 
                            {
                                usesDictionaryItemFeature[magManKey].Add(goodWeaponRack);
                            }
                        }
                        catch { }
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(armoury, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == armoury)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(armoury);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(armoury, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != armoury) { continue; }
                            }
                            }
                            else if (minotaur.Location == armoury)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(armoury);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == armoury)
                            {
                                if (minotaur.Location.ItemList.Contains(musicBox))
                                {
                                    Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster approaches!");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!visitedArmouryBefore)
                        {
                            Dialogue armouryTalk = new Dialogue(player1, goblinCaptain, dualDuel, armoury);
                            Console.WriteLine("How do you respond? \n[once you press any key you will have only 12 seconds to decide. Choose wisely...]");
                            string message = "";
                            int option = 4;
                            List<string> palaver = new List<string> 
                            {
                                "You try to politely excuse yourself and slip out of the door...",
                                "You try to bluster and bluff your way out - you ask them what they think they're staring at...",
                                "You ask if those weapons are for sale..."
                            };
                            message += "[1] You try to politely excuse yourself and slip out of the door..." +
                                "\n[2] You try to bluster and bluff your way out - you ask them what they think they're staring at..." +
                                "\n[3] You ask if those weapons are for sale...";
                            if (player1.Inventory.Contains(journal))
                            {
                                message += $"\n[{option}] You apologise for the interruption and explain that you're looking for, um... Merigold?";
                                option++;
                                palaver.Add("You apologise for the interruption and explain that you're looking for, um... Merigold?");
                            }
                            if (player1.Traits.ContainsKey("thespian") && player1.Masked && player1.Inventory.Contains(mercInsignia))
                            {
                                message += $"\n[{option}] You bring to life and inhabit the persona of a drill-sergeant, and set about whipping these good-for-nothing grunts into shape!";
                                option++;
                                palaver.Add("You bring to life and inhabit the persona of a drill-sergeant, and set about whipping these good-for-nothing grunts into shape!");
                            }
                            else if ((player1.Traits.ContainsKey("thespian") && player1.Masked) ||(player1.Masked && player1.Inventory.Contains(mercInsignia)) || (player1.Traits.ContainsKey("thespian") && player1.Inventory.Contains(mercInsignia)))
                            {
                                message += $"\n[{option}] You adopt the unassuming role of just another grunt and complain about the food...";
                                option++;
                                message += $"\n[{option}] You adopt the unassuming role of just another grunt and complain about the pay...";
                                option++;
                                message += $"\n[{option}] You adopt the unassuming role of just another grunt and complain about the weapons...";
                                option++;
                                palaver.Add("You adopt the unassuming role of just another grunt and complain about the food...");
                                palaver.Add("You adopt the unassuming role of just another grunt and complain about the pay...");
                                palaver.Add("You adopt the unassuming role of just another grunt and complain about the weapons...");
                            }
                            else if (player1.Masked || player1.Traits.ContainsKey("thespian") || player1.Inventory.Contains(mercInsignia))
                            {
                                message += $"\n[{option}] You adopt the role of commander-in-chief and sanctimoniously berate them for playing coins when... wait? coins? Why not cards? cards are so much better...";
                                option++;
                                palaver.Add("You adopt the role of commander-in-chief and sanctimoniously berate them for playing coins when... wait? coins? Why not cards? cards are so much better...");
                            }
                            if (fieryEscape && fireProgress > 5)
                            {
                                message += $"\n[{option}] You yell there's a fire downstairs and its rapidly threatening to burn the whole place down. They need to put it out. Now!";
                                option++;
                                palaver.Add("You yell there's a fire downstairs and its rapidly threatening to burn the whole place down. They need to put it out. Now!");
                            }
                            else if (fieryEscape)
                            {
                                message += $"\n[{option}] You yell there's a fire downstairs and they need to put it out!";
                                option++;
                                palaver.Add("You yell there's a fire downstairs and they need to put it out!");
                            }
                            if (player1.Traits.ContainsKey("jinxed"))
                            {
                                message += $"\n[{option}] You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...";
                                option++;
                                palaver.Add("You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...");
                            }
                            if (player1.Traits.ContainsKey("sadist"))
                            {
                                message += $"\n[{option}] You leer as you draw your weapon and tell them that you're going to enjoy this...";
                                option++;
                                palaver.Add("You leer as you draw your weapon and tell them that you're going to enjoy this...");
                            }
                            else if (player1.Traits.ContainsKey("opportunist"))
                            {
                                message += $"\n[{option}] You seize the initiative and attack while you have the advantage!";
                                option++;
                                palaver.Add("You seize the initiative and attack while you have the advantage!");
                            }
                            Console.ReadKey(true);
                            Console.WriteLine(message);
                            List<long> answer_and_time = getTimedIntResponse(option);
                            if (answer_and_time[1]> 12000)
                            {
                                Console.WriteLine("Tongue-tied, you're unable to give an adequate response before your enemies draw their weapons...");
                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                {
                                    dualDuel.WonFight(armoury);
                                    dualDuel.Monster = dualDuel.Monster2;
                                    dualDuel.WonFight(armoury);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                
                                long rep = answer_and_time[0] - 1;
                                switch (rep)
                                {
                                    case 0:
                                        Console.WriteLine("The two mercenaries take notice of your nervousness. Chairs scrape across the floor as the goblin and gnoll rise and draw their weapons.\nIt looks like you're going to have to fight...");
                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                        {
                                            dualDuel.WonFight(armoury);
                                            dualDuel.Monster = dualDuel.Monster2;
                                            dualDuel.WonFight(armoury);
                                            break;
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    case 1:
                                        Console.WriteLine("They are bold words, but unconvincingly delivered. The two mercenaries take notice of your nervousness. Chairs scrape across the floor as the goblin and gnoll rise and draw their weapons.\nIt looks like you're going to have to fight...");
                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                        {
                                            dualDuel.WonFight(armoury);
                                            dualDuel.Monster = dualDuel.Monster2;
                                            dualDuel.WonFight(armoury);
                                            break;
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    case 2:
                                        Console.WriteLine("It appears the answer is no, they are not, because soon after you asked chairs scrape across the floor and the goblin and gnoll rise and draw their weapons.\nDid you mistake them for merchants?...");
                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                        {
                                            dualDuel.WonFight(armoury);
                                            dualDuel.Monster = dualDuel.Monster2;
                                            dualDuel.WonFight(armoury);
                                            break;
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    case 3:
                                        try
                                        {
                                            if (palaver[3] == "You apologise for the interruption and explain that you're looking for, um... Merigold?")
                                            {
                                                Console.WriteLine("\nUpon mention of Merigold the two mercenaries' features darken. They rise from their seats, drawing their weapons. It seems they know all too well who and where Merigold is, and they also know that no friend of theirs would be traipsing through this place looking for him...\nYou shrug. Oh well, it was worth a shot. You prepare to fight...");
                                                
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[3] == "You bring to life and inhabit the persona of a drill-sergeant, and set about whipping these good-for-nothing grunts into shape!")
                                            {
                                                Dialogue drillsergeant = new Dialogue(player1, goblinCaptain, dualDuel, armoury);
                                                
                                                string description = "The goblin and the gnoll eye you suspiciously. The goblin starts to speak.";
                                                Dictionary<string, string> choice_customResponse = new Dictionary<string, string> 
                                                {
                                                    { "'Shut up, maggot! Just what in the seven hells do you think *you're* doing!'", "The goblin jumps back in surprise.\n\t'Wot? I don't...' but then he notices your Vespasian broach...\n'We're sorry, sir! Didn't realise who you was, sir..."},
                                                    {"'Silence, you worthless reprobate! My god, this must be the damn stupidest army in the whole world and I get landed with the biggest two morons in the entire damn outfit!\nWhy aren't you with your platoon, maggots!'", "'Platoon?' the two creatures look at each other, stunned. 'But, uh we're jus' s'posed to be standin' guard duty, like... We were told to wait here until further instruction, so's we reckoned we'd pass the time a bit...'" },
                                                    {"'Did you just speak to me without being spoken to? Did you even go through basic training? How do they expect me to turn scum like you into soldiers, I'll never know! Why-aren't-you-standing-to-attention-maggots?'", "The gnoll and the goblin stand to attention so fast it looks like a jolt of electricity coursed through them. 'Sorry, sir! Didn't recognise you, sir!'" },
                                                    {"'Well, if wonders never cease... I was just thinking to myself, where might I find the two lowliest, feeble, can't-share-a-brain-cell-between-them morons in this entire damned outfit so that I can break them down and chew them up for breakfast! And God must love me today because, lo-and-behold, I just found them!'", "The goblin panics. 'Sir, no sir! That's the other goblin and gnoll, sir...'" },
                                                    {"'NO! I do NOT want to play a game with you, morons! No, I do not want to play teacups and house with you two dunderkopfs! I am a sergeant, not your wet-nurse, you bootlicking chuckleheads!'", "The goblin stammers.\n'Yes, Sarge! Sorry, Sarge! uh..." },
                                                    {$"'I'm sorry, did you just call me 'sir'? I am NOT a 'sir'! I work for a living, you morons! You will address me as sergeant or sergeant {player1.Name}! Do I make myself clear?'", "The goblin stammers. \n\t'No Sarge! I mean, yes Sarge! Sorry Sarge! uh...'" },
                                                    {"'Let's get one thing straight, you dented chromosome, I do not care for a game. In fact, I do not even care for you! I care about precisely two things, grunt! The fighting fitness of the men under my command and hygiene, and that turnip you call a face is an affront to both!'", "The goblin stammers as the gnoll's gaze flits nervously between you. 'Yes, Sarge! I mean, no, Sarge! I mean... uh..." },
                                                };
                                                List<string> parlances = new List<string> 
                                                { 
                                                    "Jus' wot in the wozzname do you think yer...",
                                                    "uh...Would you care for a game, sir?",
                                                    "...was there something you wanted from us, Sarge?"
                                                };
                                                List<List< string>> playerchoices = new List<List<string>> 
                                                {
                                                    new List<string>
                                                    {
                                                        "'Shut up, maggot! Just what in the seven hells do you think *you're* doing!'",
                                                        "'Silence, you worthless reprobate! My god, this must be the damn stupidest army in the whole world and I get landed with the biggest two morons in the entire damn outfit!\nWhy aren't you with your platoon, maggots!'",
                                                        "'Did you just speak to me without being spoken to? Did you even go through basic training? How do they expect me to turn scum like you into soldiers, I'll never know! Why-aren't-you-standing-to-attention-maggots?'",
                                                        "'Well, if wonders never cease... I was just thinking to myself, where might I find the two lowliest, feeble, can't-share-a-brain-cell-between-them morons in this entire damned outfit so that I can break them down and chew them up for breakfast! And God must love me today because, lo-and-behold, I just found them!'"
                                                    },
                                                    new List<string>
                                                    {
                                                        "'NO! I do NOT want to play a game with you, morons! No, I do not want to play teacups and house with you two dunderkopfs! I am a sergeant, not your wet-nurse, you bootlicking chuckleheads!'",
                                                        $"'I'm sorry, did you just call me 'sir'? I am NOT a 'sir'! I work for a living, you morons! You will address me as sergeant or sergeant {player1.Name}! Do I make myself clear?'",
                                                        "'Let's get one thing straight, you dented chromosome, I do not care for a game. In fact, I do not even care for you! I care about precisely two things, grunt! The fighting fitness of the men under my command and hygiene, and that turnip you call a face is an affront to both!'"
                                                    },
                                                    new List<string>
                                                    {
                                                        $"'Lord help us! You might not be the dumbest creature alive, grunt, but you better hope they don't die! My - Name - Is - Sergeant - {player1.Name}! Not Sarge! And you will address me as such, or before this day is through, the other grunts will be using your ugly mug to polish my boots! Now do twenty laps down all the stairs of this building and back! MOVE IT!'",
                                                        $"'If I should ever like you, grunt, then I'll permit you to call me 'sarge.' But guess what? I don't like you! So you WILL call me Sergeant {player1.Name} or you WILL be scrubbing the latrines! The captain has orders for you. Report immediately to... wherever he's at!'"
                                                    }
                                                };
                                                switch(drillsergeant.LinearParle(choice_customResponse, parlances, playerchoices, description))
                                                {
                                                    case 0:
                                                        Console.WriteLine("Both the goblin and gnoll snap to attention!\n" +
                                                            $"Yes, sergeant {player1.Name}! Right away, sergeant {player1.Name}!\n" +
                                                            $"They both scramble out of the room, racing down the stairway and out of sight...");
                                                        break;
                                                    case 1:
                                                        Console.WriteLine("\t'Wait,' the goblin 'which captain are you-.'");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("'*The* captain, morons! Now move out!'");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("\t'But sergeant, we don't know where this captain is...'");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("'THEN YOU'D BETTER START LOOKING, MAGGOTS! NOW!!!'");
                                                        Console.WriteLine("Both the goblin and gnoll snap too attention!\n" +
                                                            $"Yes, sergeant {player1.Name}! Right away, sergeant {player1.Name}!\n" +
                                                            $"They both scramble out of the room, racing down the stairway and out of sight...");
                                                        break;
                                                    default:
                                                        Console.WriteLine("Both the goblin and gnoll snap too attention!\n" +
                                                            $"Yes, sergeant {player1.Name}! Right away, sergeant {player1.Name}!\n" +
                                                            $"They both scramble out of the room, racing down the stairway and out of sight...");
                                                        break;
                                                }
                                                break;
                                            }
                                            else if (palaver[3] == "You adopt the unassuming role of just another grunt and complain about the food...")
                                            {
                                                Console.WriteLine($"\t'What're you talkin' about?' the goblin retorts. 'Best food we've 'ad ever since workin' 'ere. We've been emptying this Merigold maggot's larder and wine cellar fer months now and it's still overflowin'!'");
                                                Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[3] == "You adopt the unassuming role of just another grunt and complain about the pay...")
                                            {
                                                
                                                string description = "\t'Pfft. Wot's there to complain about?' the goblin retorts. 'We've never 'ad it so good under the master. Raided this place first day I got 'ere. Its where I got this fancy broach from'\nHe produces a broach from somewhere, embossed with a golden M encircled by a cursive capital G. Then his suspicious nature once more comes to the fore.";
                                                string parlance = "\t''ere, what'd you say the name of your squad woz again,' he chuckles humorlessly. 'Coz for the life of me, I don' reckon I've ever seen yer face before...'\nOut of the corner of your eye you see the gnoll eye you ravenously, a glint in its eye.";
                                                List<string> responses = new List<string>
                                                {
                                                    "Ooh... you know... that one... starts with an 's'... on the tip of my tongue...",
                                                    "The kamikaze-suicide crazies",
                                                    "The knights who say 'ni'",
                                                    "Teh Ordah of deh Mega-Tyrant",
                                                    "Team Rocket",
                                                    "Squad 34529, reporting for duty!"
                                                    
                                                };
                                                if (bookEC4.SpecifyAttribute == "read")
                                                {
                                                    responses.Add("Da-Freebootaz-Squigalanche");
                                                }
                                                
                                                switch (armouryTalk.Parle(description, parlance, responses))
                                                {
                                                    case 1:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");
                                                        
                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 2:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 3:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 4:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 5:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 6:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 7:
                                                        description = "The goblin's eyes light up. Meanwhile, the gnoll gazes at you with open admiration...";
                                                        List<string> parlances = new List<string>{
                                                            "'Get outta 'ere,' the goblin exclaims, awestruck. 'Yer one of 'em mad boys? The ones who stormed the gates of the DreadPortal in the dead of night, squishin' the enemy guard with boulders and clubs? You fellas are legends!'\nThe gnoll nods its head emphatically. It has a crazed fanboy look in its eyes.",
                                                            "but I thought your squad were all trolls?'",
                                                            "'say, why don't you join us for a game of coins? It'd be an honour...'"
                                                        };
                                                        List<List<string>> playerchoices = new List<List<string>>
                                                        {
                                                            new List<string> 
                                                            {
                                                                "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...",
                                                                "You brag, recounting the many foes you felled with your bare hands...",
                                                                "You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Well, who do you think led them, you say...", 
                                                                "You tell them they made an exception for you because you're so awesome...",
                                                                "You examine your fingernails as you tell them that's the misconception most amateurs seem to have..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Say you'd love to, but the commander instructed you tell them they're needed outside...",
                                                                "Say you'll have to check your schedule, in the meantime they have orders to... um, go away. On the double!",
                                                                "Say you could but then they'll miss out on their chance to join Da-Freebootaz-Squigalanche. They're recruiting, and maybe you two might just have what it takes..."
                                                            }
                                                        };
                                                        Dictionary<string, string> choice_customResponse = new Dictionary<string, string>
                                                        {
                                                            {
                                                            "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...", "The goblin nudges the gnoll. 'ere! and see how modest he is too! That's a sign of a real, storm-thumpin' warlord, that is. Cor blimey!..."
                                                            },
                                                            { "You brag, recounting the many foes you felled with your bare hands...", "They listen avidly, eyes growing wider and wider as you recount your many exploits, even the ones on the other side of the world where the Vespasian mercenaries have never been. They are so swept up in your vivid tales they scarcely notice..."},
                                                            {"You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it...", "They seem to revere you more as they're magnetised by your coolness. 'Wow...' they sigh. The gnoll drools adoringly." },
                                                            {"Well, who do you think led them, you say...", "\t'Of course! of course!' the goblin rushes to agree. He elbows the gnoll, 'See? what'd I tell you? He's obviously the leader! 'At's what I said..." },
                                                            { "You tell them they made an exception for you because you're so awesome...", "The two knuckleheads lap it up."},
                                                            { "You examine your fingernails as you tell them that's the misconception most amateurs seem to have...", "\t'Oh! No, you got it all wrong, we're not amateurs!' the goblin stammers. The gnoll nods along, a pleading look in its eyes.'We're just repeatin' wot we heard from others... Wot fools' the goblin laughs nervously."}
                                                        };
                                                        switch (armouryTalk.LinearParle(choice_customResponse, parlances, playerchoices, description))
                                                        {
                                                            case 0:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 1:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 2:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                            default:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                }
                                            }
                                            else if (palaver[3] == "You adopt the unassuming role of just another grunt and complain about the weapons...")
                                            {
                                                Console.WriteLine("The goblin and gnoll seem to relax. \n\t'tell me about it,' the goblin mutters, 'They've kept the good weapons locked away behind enchanted glass for the elite squads.' The goblin's voice lowers to a conspiratorial whisper, 'One of our number, they tried to break the enchanted glass and steal one of the better weapons. The glass didn't shatter, but they did - right after he'd been frozen to a block of ice!' \nYou pay the weapons in question a wary glance through the strange glass. \n\t'Say,' the goblin perks up, 'You want to join us for a game?'");
                                                Console.ReadKey(true);
                                                Console.WriteLine("You play a few rounds before the gnoll and goblin say they'd better get back on patrol. They give a collegial farewell before exiting the 'RmorRee' door and through the double doors beyond...");
                                                break;
                                            }
                                            else if (palaver[3] == "You adopt the role of commander-in-chief and sanctimoniously berate them for playing coins when... wait? coins? Why not cards? cards are so much better...")
                                            {
                                                Console.WriteLine("\nHow *dare* you insult the grand and noble game of coins! The gnoll and goblin both rise from their seats to fight you...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[3] == "You yell there's a fire downstairs and its rapidly threatening to burn the whole place down. They need to put it out. Now!")
                                            {
                                                Console.WriteLine("\nThe gnoll and the goblin both peer around you, taking in the raging inferno storming up the stairway. Their gaze turns from the flaming stairs, to your soot-smeared expectant face, then finally to each other...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They both scramble for the window, plunging into some kind of moat below.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Okaaay...");
                                                break;
                                            }
                                            else if (palaver[3] == "You yell there's a fire downstairs and they need to put it out!")
                                            {
                                                Console.WriteLine("\nThey peer their heads around you and out towards the antechamber. They don't see much evidence of fire...\nYou assure them it's really, REALLY big.\n\t'Maybe so, stranger,' the goblin answers darkly. He draws his weapon and the gnoll follows suit. 'But I reckon we've got ourselves enough time to kill us some spies, or wotevers the hell you are.'\nBother! It looks like you're going to have to fight...'");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[3] == "You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...")
                                            {
                                                Console.WriteLine("\nUpon mention of Merigold the two mercenaries' features darken. They rise from their seats, drawing their weapons. It seems they know all too well who and where Merigold is, and they also know that no friend of theirs would be traipsing through this place looking for him...\nYou shrug. Oh well, it was worth a shot. You prepare to fight...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[3] == "You leer as you draw your weapon and tell them that you're going to enjoy this...")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[3] == "You seize the initiative and attack while you have the advantage!")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        catch {  }
                                        break;
                                    case 4:
                                        try
                                        {
                                            
                                            if (palaver[4] == "You bring to life and inhabit the persona of a drill-sergeant, and set about whipping these good-for-nothing grunts into shape!")
                                            {
                                                Dialogue drillsergeant = new Dialogue(player1, goblinCaptain, dualDuel, armoury);

                                                string description = "The goblin and the gnoll eye you suspiciously. The goblin starts to speak.";
                                                Dictionary<string, string> choice_customResponse = new Dictionary<string, string>
                                                {
                                                    { "'Shut up, maggot! Just what in the seven hells do you think *you're* doing!'", "The goblin jumps back in surprise.\n\t'Wot? I don't...' but then he notices your Vespasian broach...\n'We're sorry, sir! Didn't realise who you was, sir..."},
                                                    {"'Silence, you worthless reprobate! My god, this must be the damn stupidest army in the whole world and I get landed with the biggest two morons in the entire damn outfit!\nWhy aren't you with your platoon, maggots!'", "'Platoon?' the two creatures look at each other, stunned. 'But, uh we're jus' s'posed to be standin' guard duty, like... We were told to wait here until further instruction, so's we reckoned we'd pass the time a bit...'" },
                                                    {"'Did you just speak to me without being spoken to? Did you even go through basic training? How do they expect me to turn scum like you into soldiers, I'll never know! Why-aren't-you-standing-to-attention-maggots?'", "The gnoll and the goblin stand to attention so fast it looks like a jolt of electricity coursed through them. 'Sorry, sir! Didn't recognise you, sir!'" },
                                                    {"'Well, if wonders never cease... I was just thinking to myself, where might I find the two lowliest, feeble, can't-share-a-brain-cell-between-them morons in this entire damned outfit so that I can break them down and chew them up for breakfast! And God must love me today because, lo-and-behold, I just found them!'", "The goblin panics. 'Sir, no sir! That's the other goblin and gnoll, sir...'" },
                                                    {"'NO! I do NOT want to play a game with you, morons! No, I do not want to play teacups and house with you two dunderkopfs! I am a sergeant, not your wet-nurse, you bootlicking chuckleheads!'", "The goblin stammers.\n'Yes, Sarge! Sorry, Sarge! uh..." },
                                                    {$"'I'm sorry, did you just call me 'sir'? I am NOT a 'sir'! I work for a living, you morons! You will address me as sergeant or sergeant {player1.Name}! Do I make myself clear?'", "The goblin stammers. \n\t'No Sarge! I mean, yes Sarge! Sorry Sarge! uh...'" },
                                                    {"'Let's get one thing straight, you dented chromosome, I do not care for a game. In fact, I do not even care for you! I care about precisely two things, grunt! The fighting fitness of the men under my command and hygiene, and that turnip you call a face is an affront to both!'", "The goblin stammers as the gnoll's gaze flits nervously between you. 'Yes, Sarge! I mean, no, Sarge! I mean... uh..." },
                                                };
                                                List<string> parlances = new List<string>
                                                {
                                                    "Jus' wot in the wozzname do you think yer...",
                                                    "uh...Would you care for a game, sir?",
                                                    "...was there something you wanted from us, Sarge?"
                                                };
                                                List<List<string>> playerchoices = new List<List<string>>
                                                {
                                                    new List<string>
                                                    {
                                                        "'Shut up, maggot! Just what in the seven hells do you think *you're* doing!'",
                                                        "'Silence, you worthless reprobate! My god, this must be the damn stupidest army in the whole world and I get landed with the biggest two morons in the entire damn outfit!\nWhy aren't you with your platoon, maggots!'",
                                                        "'Did you just speak to me without being spoken to? Did you even go through basic training? How do they expect me to turn scum like you into soldiers, I'll never know! Why-aren't-you-standing-to-attention-maggots?'",
                                                        "'Well, if wonders never cease... I was just thinking to myself, where might I find the two lowliest, feeble, can't-share-a-brain-cell-between-them morons in this entire damned outfit so that I can break them down and chew them up for breakfast! And God must love me today because, lo-and-behold, I just found them!'"
                                                    },
                                                    new List<string>
                                                    {
                                                        "'NO! I do NOT want to play a game with you, morons! No, I do not want to play teacups and house with you two dunderkopfs! I am a sergeant, not your wet-nurse, you bootlicking chuckleheads!'",
                                                        $"'I'm sorry, did you just call me 'sir'? I am NOT a 'sir'! I work for a living, you morons! You will address me as sergeant or sergeant {player1.Name}! Do I make myself clear?'",
                                                        "'Let's get one thing straight, you dented chromosome, I do not care for a game. In fact, I do not even care for you! I care about precisely two things, grunt! The fighting fitness of the men under my command and hygiene, and that turnip you call a face is an affront to both!'"
                                                    },
                                                    new List<string>
                                                    {
                                                        $"'Lord help us! You might not be the dumbest creature alive, grunt, but you better hope they don't die! My - Name - Is - Sergeant - {player1.Name}! Not Sarge! And you will address me as such, or before this day is through, the other grunts will be using your ugly mug to polish my boots! Now do twenty laps down all the stairs of this building and back! MOVE IT!'",
                                                        $"'If I should ever like you, grunt, then I'll permit you to call me 'sarge.' But guess what? I don't like you! So you WILL call me Sergeant {player1.Name} or you WILL be scrubbing the latrines! The captain has orders for you. Report immediately to... wherever he's at!'"
                                                    }
                                                };
                                                switch (drillsergeant.LinearParle(choice_customResponse, parlances, playerchoices, description))
                                                {
                                                    case 0:
                                                        Console.WriteLine("Both the goblin and gnoll snap to attention!\n" +
                                                            $"Yes, sergeant {player1.Name}! Right away, sergeant {player1.Name}!\n" +
                                                            $"They both scramble out of the room, racing down the stairway and out of sight...");
                                                        break;
                                                    case 1:
                                                        Console.WriteLine("\t'Wait,' the goblin 'which captain are you-.'");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("'*The* captain, morons! Now move out!'");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("\t'But sergeant, we don't know where this captain is...'");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("'THEN YOU'D BETTER START LOOKING, MAGGOTS! NOW!!!'");
                                                        Console.WriteLine("Both the goblin and gnoll snap too attention!\n" +
                                                            $"Yes, sergeant {player1.Name}! Right away, sergeant {player1.Name}!\n" +
                                                            $"They both scramble out of the room, racing down the stairway and out of sight...");
                                                        break;
                                                    default:
                                                        Console.WriteLine("Both the goblin and gnoll snap too attention!\n" +
                                                            $"Yes, sergeant {player1.Name}! Right away, sergeant {player1.Name}!\n" +
                                                            $"They both scramble out of the room, racing down the stairway and out of sight...");
                                                        break;
                                                }
                                                break;
                                            }
                                            else if (palaver[4] == "You adopt the unassuming role of just another grunt and complain about the food...")
                                            {
                                                Console.WriteLine($"\t'What're you talkin' about?' the goblin retorts. 'Best food we've 'ad ever since workin' 'ere. We've been emptying this Merigold maggot's larder and wine cellar fer months now and it's still overflowin'!'");
                                                Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[4] == "You adopt the unassuming role of just another grunt and complain about the pay...")
                                            {
                                                
                                                string description = "\t'Pfft. Wot's there to complain about?' the goblin retorts. 'We've never 'ad it so good under the master. Raided this place first day I got 'ere. Its where I got this fancy broach from'\nHe produces a broach from somewhere, embossed with a golden M encircled by a cursive capital G. Then his suspicious nature once more comes to the fore.";
                                                string parlance = "\t''ere, what'd you say the name of your squad woz again,' he chuckles humorlessly. 'Coz for the life of me, I don' reckon I've ever seen yer face before...'\nOut of the corner of your eye you see the gnoll eye you ravenously, a glint in its eye.";
                                                List<string> responses = new List<string>
                                                {
                                                    "Ooh... you know... that one... starts with an 's'... on the tip of my tongue...",
                                                    "The kamikaze-suicide crazies",
                                                    "The knights who say 'ni'",
                                                    "Teh Ordah of deh Mega-Tyrant",
                                                    "Team Rocket",
                                                    "Squad 34529, reporting for duty!"

                                                };
                                                if (bookEC4.SpecifyAttribute == "read")
                                                {
                                                    responses.Add("Da-Freebootaz-Squigalanche");
                                                }

                                                switch (armouryTalk.Parle(description, parlance, responses))
                                                {
                                                    case 1:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 2:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight (armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 3:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 4:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 5:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 6:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 7:
                                                        description = "The goblin's eyes light up. Meanwhile, the gnoll gazes at you with open admiration...";
                                                        List<string> parlances = new List<string>{
                                                            "'Get outta 'ere,' the goblin exclaims, awestruck. 'Yer one of 'em mad boys? The ones who stormed the gates of the DreadPortal in the dead of night, squishin' the enemy guard with boulders and clubs? You fellas are legends!'\nThe gnoll nods its head emphatically. It has a crazed fanboy look in its eyes.",
                                                            "but I thought your squad were all trolls?'",
                                                            "'say, why don't you join us for a game of coins? It'd be an honour...'"
                                                        };
                                                        List<List<string>> playerchoices = new List<List<string>>
                                                        {
                                                            new List<string>
                                                            {
                                                                "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...",
                                                                "You brag, recounting the many foes you felled with your bare hands...",
                                                                "You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Well, who do you think led them, you say...",
                                                                "You tell them they made an exception for you because you're so awesome...",
                                                                "You examine your fingernails as you tell them that's the misconception most amateurs seem to have..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Say you'd love to, but the commander instructed you tell them they're needed outside...",
                                                                "Say you'll have to check your schedule, in the meantime they have orders to... um, go away. On the double!",
                                                                "Say you could but then they'll miss out on their chance to join Da-Freebootaz-Squigalanche. They're recruiting, and maybe you two might just have what it takes..."
                                                            }
                                                        };
                                                        Dictionary<string, string> choice_customResponse = new Dictionary<string, string>
                                                        {
                                                            {
                                                            "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...", "The goblin nudges the gnoll. 'ere! and see how modest he is too! That's a sign of a real, storm-thumpin' warlord, that is. Cor blimey!..."
                                                            },
                                                            { "You brag, recounting the many foes you felled with your bare hands...", "They listen avidly, eyes growing wider and wider as you recount your many exploits, even the ones on the other side of the world where the Vespasian mercenaries have never been. They are so swept up in your vivid tales they scarcely notice..."},
                                                            {"You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it...", "They seem to revere you more as they're magnetised by your coolness. 'Wow...' they sigh. The gnoll drools adoringly." },
                                                            {"Well, who do you think led them, you say...", "\t'Of course! of course!' the goblin rushes to agree. He elbows the gnoll, 'See? what'd I tell you? He's obviously the leader! 'At's what I said..." },
                                                            { "You tell them they made an exception for you because you're so awesome...", "The two knuckleheads lap it up."},
                                                            { "You examine your fingernails as you tell them that's the misconception most amateurs seem to have...", "\t'Oh! No, you got it all wrong, we're not amateurs!' the goblin stammers. The gnoll nods along, a pleading look in its eyes.'We're just repeatin' wot we heard from others... Wot fools' the goblin laughs nervously."}
                                                        };
                                                        switch (armouryTalk.LinearParle(choice_customResponse, parlances, playerchoices, description))
                                                        {
                                                            case 0:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 1:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 2:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                            default:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                }
                                            }
                                            else if (palaver[4] == "You adopt the unassuming role of just another grunt and complain about the weapons...")
                                            {
                                                Console.WriteLine("The goblin and gnoll seem to relax. \n\t'tell me about it,' the goblin mutters, 'They've kept the good weapons locked away behind enchanted glass for the elite squads.' The goblin's voice lowers to a conspiratorial whisper, 'One of our number, they tried to break the enchanted glass and steal one of the better weapons. The glass didn't shatter, but they did - right after he'd been frozen to a block of ice!' \nYou pay the weapons in question a wary glance through the strange glass. \n\t'Say,' the goblin perks up, 'You want to join us for a game?'");
                                                Console.ReadKey(true);
                                                Console.WriteLine("You play a few rounds before the gnoll and goblin say they'd better get back on patrol. They give a collegial farewell before exiting the 'RmorRee' door and through the double doors beyond...");
                                                break;
                                            }
                                            else if (palaver[4] == "You adopt the role of commander-in-chief and sanctimoniously berate them for playing coins when... wait? coins? Why not cards? cards are so much better...")
                                            {
                                                Console.WriteLine("\nHow *dare* you insult the grand and noble game of coins! The gnoll and goblin both rise from their seats to fight you...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[4] == "You yell there's a fire downstairs and its rapidly threatening to burn the whole place down. They need to put it out. Now!")
                                            {
                                                Console.WriteLine("\nThe gnoll and the goblin both peer around you, taking in the raging inferno storming up the stairway. Their gaze turns from the flaming stairs, to your soot-smeared expectant face, then finally to each other...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They both scramble for the window, plunging into some kind of moat below.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Okaaay...");
                                                break;
                                            }
                                            else if (palaver[4] == "You yell there's a fire downstairs and they need to put it out!")
                                            {
                                                Console.WriteLine("\nThey peer their heads around you and out towards the antechamber. They don't see much evidence of fire...\nYou assure them it's really, REALLY big.\n\t'Maybe so, stranger,' the goblin answers darkly. He draws his weapon and the gnoll follows suit. 'But I reckon we've got ourselves enough time to kill us some spies, or wotevers the hell you are.'\nBother! It looks like you're going to have to fight...'");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[4] == "You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...")
                                            {
                                                Console.WriteLine("\nThe two mercenaries each break out into a leer as they rise from their seats, drawing their weapons...\nYou shrug. Oh well. At least you tried to warn them. You prepare to fight...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[4] == "You leer as you draw your weapon and tell them that you're going to enjoy this...")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[4] == "You seize the initiative and attack while you have the advantage!")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        catch { }
                                        break;
                                    case 5:
                                        try
                                        {
                                                                                       
                                            if (palaver[5] == "You adopt the unassuming role of just another grunt and complain about the food...")
                                            {
                                                Console.WriteLine($"\t'What're you talkin' about?' the goblin retorts. 'Best food we've 'ad ever since workin' 'ere. We've been emptying this Merigold maggot's larder and wine cellar fer months now and it's still overflowin'!'");
                                                Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[5] == "You adopt the unassuming role of just another grunt and complain about the pay...")
                                            {
                                                
                                                string description = "\t'Pfft. Wot's there to complain about?' the goblin retorts. 'We've never 'ad it so good under the master. Raided this place first day I got 'ere. Its where I got this fancy broach from'\nHe produces a broach from somewhere, embossed with a golden M encircled by a cursive capital G. Then his suspicious nature once more comes to the fore.";
                                                string parlance = "\t''ere, what'd you say the name of your squad woz again,' he chuckles humorlessly. 'Coz for the life of me, I don' reckon I've ever seen yer face before...'\nOut of the corner of your eye you see the gnoll eye you ravenously, a glint in its eye.";
                                                List<string> responses = new List<string>
                                                {
                                                    "Ooh... you know... that one... starts with an 's'... on the tip of my tongue...",
                                                    "The kamikaze-suicide crazies",
                                                    "The knights who say 'ni'",
                                                    "Teh Ordah of deh Mega-Tyrant",
                                                    "Team Rocket",
                                                    "Squad 34529, reporting for duty!"

                                                };
                                                if (bookEC4.SpecifyAttribute == "read")
                                                {
                                                    responses.Add("Da-Freebootaz-Squigalanche");
                                                }

                                                switch (armouryTalk.Parle(description, parlance, responses))
                                                {
                                                    case 1:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 2:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 3:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 4:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 5:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 6:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 7:
                                                        description = "The goblin's eyes light up. Meanwhile, the gnoll gazes at you with open admiration...";
                                                        List<string> parlances = new List<string>{
                                                            "'Get outta 'ere,' the goblin exclaims, awestruck. 'Yer one of 'em mad boys? The ones who stormed the gates of the DreadPortal in the dead of night, squishin' the enemy guard with boulders and clubs? You fellas are legends!'\nThe gnoll nods its head emphatically. It has a crazed fanboy look in its eyes.",
                                                            "but I thought your squad were all trolls?'",
                                                            "'say, why don't you join us for a game of coins? It'd be an honour...'"
                                                        };
                                                        List<List<string>> playerchoices = new List<List<string>>
                                                        {
                                                            new List<string>
                                                            {
                                                                "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...",
                                                                "You brag, recounting the many foes you felled with your bare hands...",
                                                                "You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Well, who do you think led them, you say...",
                                                                "You tell them they made an exception for you because you're so awesome...",
                                                                "You examine your fingernails as you tell them that's the misconception most amateurs seem to have..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Say you'd love to, but the commander instructed you tell them they're needed outside...",
                                                                "Say you'll have to check your schedule, in the meantime they have orders to... um, go away. On the double!",
                                                                "Say you could but then they'll miss out on their chance to join Da-Freebootaz-Squigalanche. They're recruiting, and maybe you two might just have what it takes..."
                                                            }
                                                        };
                                                        Dictionary<string, string> choice_customResponse = new Dictionary<string, string>
                                                        {
                                                            {
                                                            "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...", "The goblin nudges the gnoll. 'ere! and see how modest he is too! That's a sign of a real, storm-thumpin' warlord, that is. Cor blimey!..."
                                                            },
                                                            { "You brag, recounting the many foes you felled with your bare hands...", "They listen avidly, eyes growing wider and wider as you recount your many exploits, even the ones on the other side of the world where the Vespasian mercenaries have never been. They are so swept up in your vivid tales they scarcely notice..."},
                                                            {"You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it...", "They seem to revere you more as they're magnetised by your coolness. 'Wow...' they sigh. The gnoll drools adoringly." },
                                                            {"Well, who do you think led them, you say...", "\t'Of course! of course!' the goblin rushes to agree. He elbows the gnoll, 'See? what'd I tell you? He's obviously the leader! 'At's what I said..." },
                                                            { "You tell them they made an exception for you because you're so awesome...", "The two knuckleheads lap it up."},
                                                            { "You examine your fingernails as you tell them that's the misconception most amateurs seem to have...", "\t'Oh! No, you got it all wrong, we're not amateurs!' the goblin stammers. The gnoll nods along, a pleading look in its eyes.'We're just repeatin' wot we heard from others... Wot fools' the goblin laughs nervously."}
                                                        };
                                                        switch (armouryTalk.LinearParle(choice_customResponse, parlances, playerchoices, description))
                                                        {
                                                            case 0:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 1:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 2:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                            default:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                }
                                            }
                                            else if (palaver[5] == "You adopt the unassuming role of just another grunt and complain about the weapons...")
                                            {
                                                Console.WriteLine("The goblin and gnoll seem to relax. \n\t'tell me about it,' the goblin mutters, 'They've kept the good weapons locked away behind enchanted glass for the elite squads.' The goblin's voice lowers to a conspiratorial whisper, 'One of our number, they tried to break the enchanted glass and steal one of the better weapons. The glass didn't shatter, but they did - right after he'd been frozen to a block of ice!' \nYou pay the weapons in question a wary glance through the strange glass. \n\t'Say,' the goblin perks up, 'You want to join us for a game?'");
                                                Console.ReadKey(true);
                                                Console.WriteLine("You play a few rounds before the gnoll and goblin say they'd better get back on patrol. They give a collegial farewell before exiting the 'RmorRee' door and through the double doors beyond...");
                                                break;
                                            }
                                            else if (palaver[5] == "You adopt the role of commander-in-chief and sanctimoniously berate them for playing coins when... wait? coins? Why not cards? cards are so much better...")
                                            {
                                                Console.WriteLine("\nHow *dare* you insult the grand and noble game of coins! The gnoll and goblin both rise from their seats to fight you...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[5] == "You yell there's a fire downstairs and its rapidly threatening to burn the whole place down. They need to put it out. Now!")
                                            {
                                                Console.WriteLine("\nThe gnoll and the goblin both peer around you, taking in the raging inferno storming up the stairway. Their gaze turns from the flaming stairs, to your soot-smeared expectant face, then finally to each other...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They both scramble for the window, plunging into some kind of moat below.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Okaaay...");
                                                break;
                                            }
                                            else if (palaver[5] == "You yell there's a fire downstairs and they need to put it out!")
                                            {
                                                Console.WriteLine("\nThey peer their heads around you and out towards the antechamber. They don't see much evidence of fire...\nYou assure them it's really, REALLY big.\n\t'Maybe so, stranger,' the goblin answers darkly. He draws his weapon and the gnoll follows suit. 'But I reckon we've got ourselves enough time to kill us some spies, or wotevers the hell you are.'\nBother! It looks like you're going to have to fight...'");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[5] == "You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...")
                                            {
                                                Console.WriteLine("\nThe two mercenaries each break out into a leer as they rise from their seats, drawing their weapons...\nYou shrug. Oh well. At least you tried to warn them. You prepare to fight...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[5] == "You leer as you draw your weapon and tell them that you're going to enjoy this...")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[5] == "You seize the initiative and attack while you have the advantage!")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        catch { }
                                        break;
                                    case 6:
                                        try
                                        {
                                            if (palaver[6] == "You adopt the unassuming role of just another grunt and complain about the food...")
                                            {
                                                Console.WriteLine($"\t'What're you talkin' about?' the goblin retorts. 'Best food we've 'ad ever since workin' 'ere. We've been emptying this Merigold maggot's larder and wine cellar fer months now and it's still overflowin'!'");
                                                Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[6] == "You adopt the unassuming role of just another grunt and complain about the pay...")
                                            {
                                                
                                                string description = "\t'Pfft. Wot's there to complain about?' the goblin retorts. 'We've never 'ad it so good under the master. Raided this place first day I got 'ere. Its where I got this fancy broach from'\nHe produces a broach from somewhere, embossed with a golden M encircled by a cursive capital G. Then his suspicious nature once more comes to the fore.";
                                                string parlance = "\t''ere, what'd you say the name of your squad woz again,' he chuckles humorlessly. 'Coz for the life of me, I don' reckon I've ever seen yer face before...'\nOut of the corner of your eye you see the gnoll eye you ravenously, a glint in its eye.";
                                                List<string> responses = new List<string>
                                                {
                                                    "Ooh... you know... that one... starts with an 's'... on the tip of my tongue...",
                                                    "The kamikaze-suicide crazies",
                                                    "The knights who say 'ni'",
                                                    "Teh Ordah of deh Mega-Tyrant",
                                                    "Team Rocket",
                                                    "Squad 34529, reporting for duty!"

                                                };
                                                if (bookEC4.SpecifyAttribute == "read")
                                                {
                                                    responses.Add("Da-Freebootaz-Squigalanche");
                                                }

                                                switch (armouryTalk.Parle(description, parlance, responses))
                                                {
                                                    case 1:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 2:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 3:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 4:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 5:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 6:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 7:
                                                        description = "The goblin's eyes light up. Meanwhile, the gnoll gazes at you with open admiration...";
                                                        List<string> parlances = new List<string>{
                                                            "'Get outta 'ere,' the goblin exclaims, awestruck. 'Yer one of 'em mad boys? The ones who stormed the gates of the DreadPortal in the dead of night, squishin' the enemy guard with boulders and clubs? You fellas are legends!'\nThe gnoll nods its head emphatically. It has a crazed fanboy look in its eyes.",
                                                            "but I thought your squad were all trolls?'",
                                                            "'say, why don't you join us for a game of coins? It'd be an honour...'"
                                                        };
                                                        List<List<string>> playerchoices = new List<List<string>>
                                                        {
                                                            new List<string>
                                                            {
                                                                "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...",
                                                                "You brag, recounting the many foes you felled with your bare hands...",
                                                                "You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Well, who do you think led them, you say...",
                                                                "You tell them they made an exception for you because you're so awesome...",
                                                                "You examine your fingernails as you tell them that's the misconception most amateurs seem to have..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Say you'd love to, but the commander instructed you tell them they're needed outside...",
                                                                "Say you'll have to check your schedule, in the meantime they have orders to... um, go away. On the double!",
                                                                "Say you could but then they'll miss out on their chance to join Da-Freebootaz-Squigalanche. They're recruiting, and maybe you two might just have what it takes..."
                                                            }
                                                        };
                                                        Dictionary<string, string> choice_customResponse = new Dictionary<string, string>
                                                        {
                                                            {
                                                            "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...", "The goblin nudges the gnoll. 'ere! and see how modest he is too! That's a sign of a real, storm-thumpin' warlord, that is. Cor blimey!..."
                                                            },
                                                            { "You brag, recounting the many foes you felled with your bare hands...", "They listen avidly, eyes growing wider and wider as you recount your many exploits, even the ones on the other side of the world where the Vespasian mercenaries have never been. They are so swept up in your vivid tales they scarcely notice..."},
                                                            {"You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it...", "They seem to revere you more as they're magnetised by your coolness. 'Wow...' they sigh. The gnoll drools adoringly." },
                                                            {"Well, who do you think led them, you say...", "\t'Of course! of course!' the goblin rushes to agree. He elbows the gnoll, 'See? what'd I tell you? He's obviously the leader! 'At's what I said..." },
                                                            { "You tell them they made an exception for you because you're so awesome...", "The two knuckleheads lap it up."},
                                                            { "You examine your fingernails as you tell them that's the misconception most amateurs seem to have...", "\t'Oh! No, you got it all wrong, we're not amateurs!' the goblin stammers. The gnoll nods along, a pleading look in its eyes.'We're just repeatin' wot we heard from others... Wot fools' the goblin laughs nervously."}
                                                        };
                                                        switch (armouryTalk.LinearParle(choice_customResponse, parlances, playerchoices, description))
                                                        {
                                                            case 0:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 1:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 2:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                            default:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                }
                                            }
                                            else if (palaver[6] == "You adopt the unassuming role of just another grunt and complain about the weapons...")
                                            {
                                                Console.WriteLine("The goblin and gnoll seem to relax. \n\t'tell me about it,' the goblin mutters, 'They've kept the good weapons locked away behind enchanted glass for the elite squads.' The goblin's voice lowers to a conspiratorial whisper, 'One of our number, they tried to break the enchanted glass and steal one of the better weapons. The glass didn't shatter, but they did - right after he'd been frozen to a block of ice!' \nYou pay the weapons in question a wary glance through the strange glass. \n\t'Say,' the goblin perks up, 'You want to join us for a game?'");
                                                Console.ReadKey(true);
                                                Console.WriteLine("You play a few rounds before the gnoll and goblin say they'd better get back on patrol. They give a collegial farewell before exiting the 'RmorRee' door and through the double doors beyond...");
                                                break;
                                            }
                                            else if (palaver[6] == "You adopt the role of commander-in-chief and sanctimoniously berate them for playing coins when... wait? coins? Why not cards? cards are so much better...")
                                            {
                                                Console.WriteLine("\nHow *dare* you insult the grand and noble game of coins! The gnoll and goblin both rise from their seats to fight you...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[6] == "You yell there's a fire downstairs and its rapidly threatening to burn the whole place down. They need to put it out. Now!")
                                            {
                                                Console.WriteLine("\nThe gnoll and the goblin both peer around you, taking in the raging inferno storming up the stairway. Their gaze turns from the flaming stairs, to your soot-smeared expectant face, then finally to each other...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They both scramble for the window, plunging into some kind of moat below.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Okaaay...");
                                                break;
                                            }
                                            else if (palaver[6] == "You yell there's a fire downstairs and they need to put it out!")
                                            {
                                                Console.WriteLine("\nThey peer their heads around you and out towards the antechamber. They don't see much evidence of fire...\nYou assure them it's really, REALLY big.\n\t'Maybe so, stranger,' the goblin answers darkly. He draws his weapon and the gnoll follows suit. 'But I reckon we've got ourselves enough time to kill us some spies, or wotevers the hell you are.'\nBother! It looks like you're going to have to fight...'");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[6] == "You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...")
                                            {
                                                Console.WriteLine("\nThe two mercenaries each break out into a leer as they rise from their seats, drawing their weapons...\nYou shrug. Oh well. At least you tried to warn them. You prepare to fight...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[6] == "You leer as you draw your weapon and tell them that you're going to enjoy this...")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[6] == "You seize the initiative and attack while you have the advantage!")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        catch { }
                                        break;
                                    case 7:
                                        try
                                        {
                                            
                                            if (palaver[7] == "You adopt the unassuming role of just another grunt and complain about the food...")
                                            {
                                                Console.WriteLine($"\t'What're you talkin' about?' the goblin retorts. 'Best food we've 'ad ever since workin' 'ere. We've been emptying this Merigold maggot's larder and wine cellar fer months now and it's still overflowin'!'");
                                                Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[7] == "You adopt the unassuming role of just another grunt and complain about the pay...")
                                            {
                                                string description = "\t'Pfft. Wot's there to complain about?' the goblin retorts. 'We've never 'ad it so good under the master. Raided this place first day I got 'ere. Its where I got this fancy broach from'\nHe produces a broach from somewhere, embossed with a golden M encircled by a cursive capital G. Then his suspicious nature once more comes to the fore.";
                                                string parlance = "\t''ere, what'd you say the name of your squad woz again,' he chuckles humorlessly. 'Coz for the life of me, I don' reckon I've ever seen yer face before...'\nOut of the corner of your eye you see the gnoll eye you ravenously, a glint in its eye.";
                                                List<string> responses = new List<string>
                                                {
                                                    "Ooh... you know... that one... starts with an 's'... on the tip of my tongue...",
                                                    "The kamikaze-suicide crazies",
                                                    "The knights who say 'ni'",
                                                    "Teh Ordah of deh Mega-Tyrant",
                                                    "Team Rocket",
                                                    "Squad 34529, reporting for duty!"

                                                };
                                                if (bookEC4.SpecifyAttribute == "read")
                                                {
                                                    responses.Add("Da-Freebootaz-Squigalanche");
                                                }

                                                switch (armouryTalk.Parle(description, parlance, responses))
                                                {
                                                    case 1:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 2:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 3:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 4:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 5:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 6:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    case 7:
                                                        description = "The goblin's eyes light up. Meanwhile, the gnoll gazes at you with open admiration...";
                                                        List<string> parlances = new List<string>{
                                                            "'Get outta 'ere,' the goblin exclaims, awestruck. 'Yer one of 'em mad boys? The ones who stormed the gates of the DreadPortal in the dead of night, squishin' the enemy guard with boulders and clubs? You fellas are legends!'\nThe gnoll nods its head emphatically. It has a crazed fanboy look in its eyes.",
                                                            "but I thought your squad were all trolls?'",
                                                            "'say, why don't you join us for a game of coins? It'd be an honour...'"
                                                        };
                                                        List<List<string>> playerchoices = new List<List<string>>
                                                        {
                                                            new List<string>
                                                            {
                                                                "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...",
                                                                "You brag, recounting the many foes you felled with your bare hands...",
                                                                "You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Well, who do you think led them, you say...",
                                                                "You tell them they made an exception for you because you're so awesome...",
                                                                "You examine your fingernails as you tell them that's the misconception most amateurs seem to have..."
                                                            },
                                                            new List<string>
                                                            {
                                                                "Say you'd love to, but the commander instructed you tell them they're needed outside...",
                                                                "Say you'll have to check your schedule, in the meantime they have orders to... um, go away. On the double!",
                                                                "Say you could but then they'll miss out on their chance to join Da-Freebootaz-Squigalanche. They're recruiting, and maybe you two might just have what it takes..."
                                                            }
                                                        };
                                                        Dictionary<string, string> choice_customResponse = new Dictionary<string, string>
                                                        {
                                                            {
                                                            "You respond bashfully, saying a swish of a sword here a artful riposte there and the job was done...", "The goblin nudges the gnoll. 'ere! and see how modest he is too! That's a sign of a real, storm-thumpin' warlord, that is. Cor blimey!..."
                                                            },
                                                            { "You brag, recounting the many foes you felled with your bare hands...", "They listen avidly, eyes growing wider and wider as you recount your many exploits, even the ones on the other side of the world where the Vespasian mercenaries have never been. They are so swept up in your vivid tales they scarcely notice..."},
                                                            {"You greet their reverence with a stoic silence, staring off into the distance and saying you don't like to talk about it...", "They seem to revere you more as they're magnetised by your coolness. 'Wow...' they sigh. The gnoll drools adoringly." },
                                                            {"Well, who do you think led them, you say...", "\t'Of course! of course!' the goblin rushes to agree. He elbows the gnoll, 'See? what'd I tell you? He's obviously the leader! 'At's what I said..." },
                                                            { "You tell them they made an exception for you because you're so awesome...", "The two knuckleheads lap it up."},
                                                            { "You examine your fingernails as you tell them that's the misconception most amateurs seem to have...", "\t'Oh! No, you got it all wrong, we're not amateurs!' the goblin stammers. The gnoll nods along, a pleading look in its eyes.'We're just repeatin' wot we heard from others... Wot fools' the goblin laughs nervously."}
                                                        };
                                                        switch (armouryTalk.LinearParle(choice_customResponse, parlances, playerchoices, description))
                                                        {
                                                            case 0:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 1:
                                                                Console.WriteLine("The two meatheads look at each other then immediately stand to attention.\n\t'right away, sir!' They salute. Then they scramble hastily through the 'RmorRee' door, through the double doors and beyond...");
                                                                break;
                                                            case 2:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                            default:
                                                                Console.WriteLine("The goblin and gnoll gasp and look at each other excitedly. \n\t'Thank you, sir!' The goblin gushes as he proudly salutes. 'You won't forget this, sir!' They dash out of the 'RmorRee', through the double doors and beyond...");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("The suspicion that the goblin greeted you with earlier curdles into outright hostility. Meanwhile the gnoll eyes you like your its next meal.");

                                                        Console.WriteLine("They draw their weapons. It looks like you're going to have to fight...");
                                                        if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                        {
                                                            dualDuel.WonFight(armoury);
                                                            dualDuel.Monster = dualDuel.Monster2;
                                                            dualDuel.WonFight(armoury);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                }
                                            }
                                            else if (palaver[7] == "You adopt the unassuming role of just another grunt and complain about the weapons...")
                                            {
                                                Console.WriteLine("The goblin and gnoll seem to relax. \n\t'tell me about it,' the goblin mutters, 'They've kept the good weapons locked away behind enchanted glass for the elite squads.' The goblin's voice lowers to a conspiratorial whisper, 'One of our number, they tried to break the enchanted glass and steal one of the better weapons. The glass didn't shatter, but they did - right after he'd been frozen to a block of ice!' \nYou pay the weapons in question a wary glance through the strange glass. \n\t'Say,' the goblin perks up, 'You want to join us for a game?'");
                                                Console.ReadKey(true);
                                                Console.WriteLine("You play a few rounds before the gnoll and goblin say they'd better get back on patrol. They give a collegial farewell before exiting the 'RmorRee' door and through the double doors beyond...");
                                                break;
                                            }
                                            else if (palaver[7] == "You adopt the role of commander-in-chief and sanctimoniously berate them for playing coins when... wait? coins? Why not cards? cards are so much better...")
                                            {
                                                Console.WriteLine("\nHow *dare* you insult the grand and noble game of coins! The gnoll and goblin both rise from their seats to fight you...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[7] == "You yell there's a fire downstairs and its rapidly threatening to burn the whole place down. They need to put it out. Now!")
                                            {
                                                Console.WriteLine("\nThe gnoll and the goblin both peer around you, taking in the raging inferno storming up the stairway. Their gaze turns from the flaming stairs, to your soot-smeared expectant face, then finally to each other...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They both scramble for the window, plunging into some kind of moat below.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Okaaay...");
                                                break;
                                            }
                                            else if (palaver[7] == "You yell there's a fire downstairs and they need to put it out!")
                                            {
                                                Console.WriteLine("\nThey peer their heads around you and out towards the antechamber. They don't see much evidence of fire...\nYou assure them it's really, REALLY big.\n\t'Maybe so, stranger,' the goblin answers darkly. He draws his weapon and the gnoll follows suit. 'But I reckon we've got ourselves enough time to kill us some spies, or wotevers the hell you are.'\nBother! It looks like you're going to have to fight...'");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[7] == "You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...")
                                            {
                                                Console.WriteLine("\nThe two mercenaries each break out into a leer as they rise from their seats, drawing their weapons...\nYou shrug. Oh well. At least you tried to warn them. You prepare to fight...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[7] == "You leer as you draw your weapon and tell them that you're going to enjoy this...")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[7] == "You seize the initiative and attack while you have the advantage!")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        catch { }
                                        break;
                                    case 8:
                                        try
                                        {
                                            if (palaver[8] == "You yell there's a fire downstairs and its rapidly threatening to burn the whole place down. They need to put it out. Now!")
                                            {
                                                Console.WriteLine("\nThe gnoll and the goblin both peer around you, taking in the raging inferno storming up the stairway. Their gaze turns from the flaming stairs, to your soot-smeared expectant face, then finally to each other...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("They both scramble for the window, plunging into some kind of moat below.");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Okaaay...");
                                                break;
                                            }
                                            else if (palaver[8] == "You yell there's a fire downstairs and they need to put it out!")
                                            {
                                                Console.WriteLine("\nThey peer their heads around you and out towards the antechamber. They don't see much evidence of fire...\nYou assure them it's really, REALLY big.\n\t'Maybe so, stranger,' the goblin answers darkly. He draws his weapon and the gnoll follows suit. 'But I reckon we've got ourselves enough time to kill us some spies, or wotevers the hell you are.'\nBother! It looks like you're going to have to fight...'");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[8] == "You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...")
                                            {
                                                Console.WriteLine("\nThe two mercenaries each break out into a leer as they rise from their seats, drawing their weapons...\nYou shrug. Oh well. At least you tried to warn them. You prepare to fight...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[8] == "You leer as you draw your weapon and tell them that you're going to enjoy this...")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[8] == "You seize the initiative and attack while you have the advantage!")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        catch { }
                                        break;
                                    case 9:
                                        try
                                        {
                                            if (palaver[9] == "You stammer as you beseech them both that they *really* don't want to fight you. Bad, inexplicable things always happen when you get caught in a fight...")
                                            {
                                                Console.WriteLine("\nUpon mention of Merigold the two mercenaries' features darken. They rise from their seats, drawing their weapons. It seems they know all too well who and where Merigold is, and they also know that no friend of theirs would be traipsing through this place looking for him...\nYou shrug. Oh well, it was worth a shot. You prepare to fight...");

                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[9] == "You leer as you draw your weapon and tell them that you're going to enjoy this...")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else if (palaver[9] == "You seize the initiative and attack while you have the advantage!")
                                            {
                                                if (dualDuel.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
                                                {
                                                    dualDuel.WonFight(armoury);
                                                    dualDuel.Monster = dualDuel.Monster2;
                                                    dualDuel.WonFight(armoury);
                                                    break;
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        catch { }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            
                            Console.WriteLine("You dust your hands. Now what will you do?");
                            visitedArmouryBefore = true;
                            armoury.Description = "Stepping back into the armoury you see the familiar clutter of sabatons and breastplates, bracers and helmets, all scattered about you. \nThe high walls of the 'RmorRee' extend to a vaulted ceiling and appear to have been stripped of many ladders and shelves judging by the bare patches and splintered wood panels left behind. The north wall in particular is one of the few that betrays what this room might've been before its spartan refurbishment; a rosewood bookcase, replete with tomes, greets your gaze directly ahead.\t\nThe west wall to your left is where the table is situated where the gnoll and goblin played their game of coins.\t\nFacing south you find the door you just passed through.\t\nTo your right, gazing east, you see racks fully stocked with weapons and armour.\t\t";
                        }
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(armoury.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = armoury.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != armoury.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }


                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, armoury, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                if (player1.Stamina < 1)
                                {
                                    return;
                                }
                                if(goodWeaponRack.SpecificAttribute == "unlocked" && goodWeaponRack.ItemList.Count == 0)
                                {
                                    unlockedWeapons.Add(throwingKnife2);
                                    unlockedWeapons.Add(throwingKnife3);
                                    goodWeaponRack.ItemList = unlockedWeapons;
                                
                                    unlockedWeapons = new List<Item>();
                                }
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    if (minotaur.Path.Count == 1)
                    {
                        justStalked = false;
                    }
                    else { justStalked = true; }
                    sw = new Stopwatch();
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[6] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("The red thread trails behind you, showing where you've been...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    
                    while (!leftWhichRooms[6])//mess hall
                    {
                        if (messHallDoor.ItemList.Count == 0 && !player1.Inventory.Contains(noteForJanitor))
                        {
                            messHallDoor.ItemList.Add(noteForJanitor);
                        }
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(messHall, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == messHall)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, messHall, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(messHall);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(messHall, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                    if (newRoom1 != messHall) { continue; }
                                }
                            }
                            else if (minotaur.Location == messHall)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, messHall, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(messHall);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == messHall)
                            {
                                Console.WriteLine("Up and down the corridor lanterns quiver as the monster approaches!");
                                Console.ReadKey(true);
                            }
                        }
                        
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        sw.Stop();
                        if (!justStalked && sw.ElapsedMilliseconds > minotaurAlertedBy && minotaur.Location == easternmostCorridor)
                        {
                            if (minotaur.Path.Count > 1)
                            {
                                newRoom1 = minotaurApproaches(messHall, minotaur, false, 14000, false, minotaur.Rage);
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 == messHall)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }
                                else if (newRoom1 == minotaur.Location)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }

                            }
                            continue;
                        }
                        sw.Start();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(messHall.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = messHall.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (noteForJanitor.SpecifyAttribute == "read" && bucket.ItemList.Count == 0)
                                {
                                    bucket.ItemList.Add(magManKey);
                                    bucket.Description += "\nChecking under the bucket, you find nothing. You're about to give up on finding the janitor's lost key when, as you fish through the filthy brown water, your hands clasp hold of something long and metallic.";
                                    shelves.Description += "\n No matter how much you rummage through the shelves you find nothing a janitor might've misplaced...";

                                }
                                if (newRoom.Name != messHall.Name)
                                {

                                    messHallDoor.ItemList.Remove(noteForJanitor);
                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                if (sw.ElapsedMilliseconds < minotaurAlertedBy)
                                {
                                    minotaurAlertedBy = D6.Roll(D6) * 1000;
                                    sw = new Stopwatch();
                                    justStalked = false;
                                    minotaurAlerted = 0;
                                }
                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, messHall, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                            continue;
                        }
                        Console.WriteLine("Please enter a number corresponding to your choice of action...");
                            minotaurAlertedBy = D6.Roll(D6) * 1000;
                            sw = new Stopwatch();
                            justStalked = false;
                            minotaurAlerted = 0;
                        }
                        
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[7] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    if (minotaur.Path.Count == 1 && minotaur.Location != oceanBottom)
                    {
                        justStalked = false;
                    }
                    else { justStalked = true; }
                    sw = new Stopwatch();
                    while (!leftWhichRooms[7])//circular landing : change to westernmost corridor
                    {
                        ///special room with minotaur patrolling, use of Task and time
                        ///might have to split into 4 rooms, one for each passage
                        visitedRoom = true;
                        northwestCorner.Description = "The corner turns sharply right...";
                        northwestCorner.Passing = "You follow the corner around and into the north-facing corridor.";
                        southwestCorner.Description = "The corner turns sharply left...";
                        southwestCorner.Passing = "You follow the corner around and into the south-facing corridor.";
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (usesDictionaryItemFeature.ContainsKey(magManKey))
                        {
                            if (!usesDictionaryItemFeature[magManKey].Contains(circleDoor))
                            {
                                usesDictionaryItemFeature[magManKey].Add(circleDoor);
                            }
                        }
                        else
                        {
                            usesDictionaryItemFeature[magManKey] = new List<Feature> {circleDoor, magManDoor, goodWeaponRack, otherRosewoodDoor, rosewoodDoor, emptyCellDoor };
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (player1.FieryEscape && a == 0 && b == 0 && showFireMessage)
                        {
                            Console.WriteLine("From just beyond the double doors you can hear the CurseBreaker's private army scramble and clamour somewhere below, desperately trying to put out the inferno.\nThe fire should hold off the throng of goblins and gnolls and motley assortment of petty villains for a while. But you best not tarry too long.");
                            Console.ReadKey(true);
                            Console.WriteLine("Soon enough they'll be looking for who started it...");
                            Console.ReadKey(true);
                            showFireMessage = false;
                        }
                        
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            
                            if (!minotaur.MinotaurReturning(westernmostCorridor, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == westernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, westernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(westernmostCorridor);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(westernmostCorridor, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                    westernmostCorridor.FirstVisit = false;
                                if (newRoom1 != westernmostCorridor) { continue; }
                            }
                            }
                            else if (minotaur.Location == westernmostCorridor)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, westernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1,false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(westernmostCorridor);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == westernmostCorridor)
                            {
                                Console.WriteLine("Up and down the corridor lanterns quiver as the monster approaches!");
                                Console.ReadKey(true);
                            }
                        }

                        ///
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        if (!justStalked && minotaurAlerted > minotaurAlertedBy && (minotaur.Location == northernmostCorridor || minotaur.Location == southernmostCorridor || minotaur.Location == antechamber))
                        {


                            if (minotaur.Path.Count > 1)
                            {
                                newRoom1 = minotaurApproaches(westernmostCorridor, minotaur, false, 14000, false, minotaur.Rage);
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 == westernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }
                                else if(newRoom1 == minotaur.Location)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }
                                
                            }
                            continue;
                        }
                        sw.Start();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(westernmostCorridor.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.
                                if (minotaur.Location == northernmostCorridor)
                                {
                                    northwestCorner.Description = "The corner turns sharply right.\nFrom somewhere around the other side you hear heavy footfalls as some huge beast prowls the other side...";
                                }
                                else
                                {
                                    northwestCorner.Description = "The corner turns sharply right...";
                                }
                                Room newRoom = westernmostCorridor.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, null, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != westernmostCorridor.Name)
                                {
                                    
                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                if (sw.ElapsedMilliseconds < minotaurAlertedBy)
                                {
                                    minotaurAlertedBy = D6.Roll(D6) * 1000;
                                    sw = new Stopwatch();
                                    justStalked = false;
                                    minotaurAlerted = 0;
                                }

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, westernmostCorridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                            continue;
                        }
                        Console.WriteLine("Please enter a number corresponding to your choice of action...");
                            minotaurAlertedBy = D6.Roll(D6) * 1000;
                            sw = new Stopwatch();
                            justStalked = false;
                            minotaurAlerted = 0;
                        }
                        
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[21] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("The red thread unravels and marks your trail behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    if (minotaur.Path.Count == 1 && minotaur.Location != oceanBottom)
                    {
                        justStalked = false;
                    }
                    else { justStalked = true; }
                    sw = new Stopwatch();
                    while (!leftWhichRooms[21])//north-facing corridor
                    {
                        broomCloset.Description = "Your eyes clap sight of an Aladdin's cave of custodian conglomerations, janitorial jumbles and maidly menageries all agglomerated within a cosy 4 foot by 4 foot room. Somewhat ironically, it's a mess. \nYou see a broom.\t\nYou see another broom.\t\nCould that be another broom?\t\nanother br- oh, wait! That's a mop.\t\t";
                        visitedRoom = true;
                        northwestCorner.Description = "The corner turns sharply left...";
                        northwestCorner.Passing = "You follow the corner around and into the westernmost corridor.";
                        northeastCorner.Description = "The corner turns sharply right...";
                        northeastCorner.Passing = "You follow the corner around and into the easternmost corridor.";
                        usesDictionaryItemItem.Clear();
                   
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (!usesDictionaryItemFeature.ContainsKey(magManKey))
                        {
                            usesDictionaryItemFeature[magManKey] = new List<Feature>{ magManDoor};
                        }

                        if (minotaur.Location == oceanBottom && circleDoor.SpecificAttribute == "unlocked")
                        {
                            Console.WriteLine("Suddenly, from beyond the westernmost corridor, you hear booming footfalls as something storms the stairway. Like some primal war drum they reverberate through the corridor, sending the lanterns rattling in their alcoves.");
                            Console.ReadKey(true);
                            Console.WriteLine("Before you can react, it's through the double doors. With an almighty roar, some monster has entered into the westernmost corridor whilst the CurseBreaker's forces battle the flames below.\nYou instantly know three things...");
                            Console.ReadKey(true);
                            Console.WriteLine("It's something huge.");
                            Console.ReadKey(true);
                            Console.WriteLine("It's something furious.");
                            Console.ReadKey(true);
                            Console.WriteLine("And its something out for blood - Yours!");
                            minotaur.Location = westernmostCorridor;
                            minotaur.Path = new List<Room> { westernmostCorridor, southernmostCorridor, easternmostCorridor, northernmostCorridor, broomCloset, northernmostCorridor, westernmostCorridor, northernmostCorridor, easternmostCorridor, messHall, easternmostCorridor, northernmostCorridor, easternmostCorridor, southernmostCorridor, westernmostCorridor, northernmostCorridor };
                            minotaur.Rage = true;
                            minotaur.Time = (minotaur.Path.Count - 1) * 20000;
                            minotaur.Description = "Its fur scorched and smoking, wielding a great sword that streams some spectral fire, and piercing you with its bloodshot red eyes, the looming minotaur thunders a roar as it charges towards you...";
                        }

                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(northernmostCorridor, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == northernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, northernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(northernmostCorridor);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(northernmostCorridor, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != northernmostCorridor) { continue; }
                            }
                            }
                            else if (minotaur.Location == northernmostCorridor)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, northernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(northernmostCorridor);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == northernmostCorridor)
                            {
                                Console.WriteLine("Up and down the corridor lanterns quiver as the monster approaches!");
                                Console.ReadKey(true);
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the north-facing corridor?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        sw.Stop();
                        if (!justStalked && sw.ElapsedMilliseconds > minotaurAlertedBy &&(minotaur.Location == westernmostCorridor || minotaur.Location == easternmostCorridor ))
                        {
                            if (minotaur.Path.Count > 1)
                            {
                                newRoom1 = minotaurApproaches(northernmostCorridor, minotaur, false, 14000, false, minotaur.Rage);
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 == northernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }
                                else if (newRoom1 == minotaur.Location)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }

                            }
                            continue;
                        }
                        sw.Start();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(northernmostCorridor.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = northernmostCorridor.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != northernmostCorridor.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                if (sw.ElapsedMilliseconds < minotaurAlertedBy)
                                {
                                    minotaurAlertedBy = D6.Roll(D6) * 1000;
                                    sw = new Stopwatch();
                                    justStalked = false;
                                    minotaurAlerted = 0;
                                }

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, northernmostCorridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                            continue;
                        }
                        Console.WriteLine("Please enter a number corresponding to your choice of action...");
                            minotaurAlertedBy = D6.Roll(D6) * 1000;
                            sw = new Stopwatch();
                            justStalked = false;
                            minotaurAlerted = 0;
                        }
                        northernmostCorridor.FirstVisit = false;
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    if (!leftWhichRooms[22] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("With clammy hands you unravel more of the red thread, leaving it trailing in your wake...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    b = 0;
                    a = 0;
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    sw = new Stopwatch();
                    if (minotaur.Path.Count == 1 && minotaur.Location != oceanBottom)
                    {
                        justStalked = false;
                    }
                    else { justStalked = true; }
                    minotaurAlerted = 0;
                    while (!leftWhichRooms[22])//easternmost corridor
                    {
                        if(minotaur.Location == oceanBottom && circleDoor.SpecificAttribute == "locked")
                        {
                            Console.WriteLine("Suddenly, from beyond the westernmost corridor, you hear booming footfalls as something storms the stairway. Like some primal war drum they reverberate through the corridor, sending the lanterns rattling in their alcoves.");
                            Console.ReadKey(true);
                            Console.WriteLine("Before you can react, it's at the double doors. It hurls itself at them, breaking down the locks. They barely hold but for a moment, before something smashes its way through them. With an almighty roar, some monster has entered into the corridor whilst the CurseBreaker's forces battle the flames below.\nYou instantly know three things...");
                            Console.ReadKey(true);
                            Console.WriteLine("It's something huge.");
                            Console.ReadKey(true);
                            Console.WriteLine("It's something furious.");
                            Console.ReadKey(true);
                            Console.WriteLine("And its something out for blood - Yours!");
                            minotaur.Location = westernmostCorridor;
                            minotaur.Path = new List<Room> { westernmostCorridor, southernmostCorridor, easternmostCorridor, northernmostCorridor, broomCloset, northernmostCorridor, westernmostCorridor, northernmostCorridor, easternmostCorridor, messHall, easternmostCorridor, northernmostCorridor, easternmostCorridor, southernmostCorridor, westernmostCorridor, northernmostCorridor };
                            minotaur.Rage = true;
                            minotaur.Time = (minotaur.Path.Count - 1) * 20000;
                            minotaur.Description = "Its fur scorched and smoking, wielding a great sword that streams some spectral fire, and piercing you with its bloodshot red eyes, the looming minotaur thunders a roar as it charges towards you...";
                        }
                        visitedRoom = true;
                        northeastCorner.Description = "The corner turns sharply left...";
                        northeastCorner.Passing = "You follow the corner around and into the north-facing corridor.";
                        southeastCorner.Description = "The corner turns sharply right...";
                        southeastCorner.Passing = "You follow the corner around and into the south-facing corridor.";
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(easternmostCorridor, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == easternmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, easternmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(easternmostCorridor);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(easternmostCorridor, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != easternmostCorridor) { continue; }
                            }
                            }
                            else if (minotaur.Location == easternmostCorridor)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, easternmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(easternmostCorridor);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == easternmostCorridor)
                            {
                                if (minotaur.Location.ItemList.Contains(musicBox))
                                {
                                    Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster closes in!");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the easternmost corridor?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        sw.Stop();
                        if (!justStalked && sw.ElapsedMilliseconds > minotaurAlertedBy && (minotaur.Location == messHall || minotaur.Location == northernmostCorridor || minotaur.Location == southernmostCorridor))
                        {
                            if (minotaur.Path.Count > 1)
                            {
                                newRoom1 = minotaurApproaches(easternmostCorridor, minotaur, false, 14000, false, minotaur.Rage);
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 == easternmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }
                                else if (newRoom1 == minotaur.Location)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }

                            }
                            continue;
                        }
                        sw.Start();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(easternmostCorridor.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                            else if (reply1 == 2)
                            {
                            ///when player discards rusty chains they may appear more than once. 
                            ///fungshui() is present to preempt that and prevent duplicates.
                                if (minotaur.Location == northernmostCorridor)
                                {
                                    northeastCorner.Description = "The corner turns sharply left.\nFrom somewhere around the other side you hear heavy footfalls as the huge beast prowls the other side...";
                                }
                                else
                                {
                                    northeastCorner.Description = "The corner turns sharply left...";
                                }
                                Room newRoom = easternmostCorridor.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, null, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != easternmostCorridor.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                if (sw.ElapsedMilliseconds < minotaurAlertedBy)
                                {
                                    minotaurAlertedBy = D6.Roll(D6) * 1000;
                                    sw = new Stopwatch();
                                    justStalked = false;
                                    minotaurAlerted = 0;
                                }

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                test3.RunForCombat();
                                success = player1.UseItemOutsideCombat(music, easternmostCorridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                            continue;
                        }
                        Console.WriteLine("Please enter a number corresponding to your choice of action...");
                            minotaurAlertedBy = D6.Roll(D6) * 1000;
                            sw = new Stopwatch();
                            justStalked = false;
                            minotaurAlerted = 0;
                        }
                        easternmostCorridor.FirstVisit = false;
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    if (!leftWhichRooms[23] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You unspool the red thread with feverish hands, letting it lead up to you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    b = 0;
                    a = 0;
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    sw = new Stopwatch();
                    if (minotaur.Path.Count == 1 && minotaur.Location != oceanBottom)
                    {
                        justStalked = false;
                    }
                    else { justStalked = true; }
                    minotaurAlerted = 0;
                    while (!leftWhichRooms[23])//south-facing corridor
                    {
                        visitedRoom = true;
                        southwestCorner.Description = "The corner turns sharply right...";
                        southwestCorner.Passing = "You follow the corner around and into the westernmost corridor.";
                        southeastCorner.Description = "The corner turns sharply left...";
                        southeastCorner.Passing = "You follow the corner around and into the easternmost corridor.";
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);

                        if (minotaur.Location == oceanBottom && circleDoor.SpecificAttribute == "unlocked")
                        {
                            Console.WriteLine("Suddenly, from beyond the westernmost corridor, you hear booming footfalls as something storms the stairway. Like some primal war drum they reverberate through the corridor, sending the lanterns rattling in their alcoves.");
                            Console.ReadKey(true);
                            Console.WriteLine("Before you can react, it's through the double doors. With an almighty roar, some monster has entered into the westernmost corridor whilst the CurseBreaker's forces battle the flames below.\nYou instantly know three things...");
                            Console.ReadKey(true);
                            Console.WriteLine("It's something huge.");
                            Console.ReadKey(true);
                            Console.WriteLine("It's something furious.");
                            Console.ReadKey(true);
                            Console.WriteLine("And its something out for blood - Yours!");
                            minotaur.Location = westernmostCorridor;
                            minotaur.Path = new List<Room> { westernmostCorridor, southernmostCorridor, easternmostCorridor, northernmostCorridor, broomCloset, northernmostCorridor, westernmostCorridor, northernmostCorridor, easternmostCorridor, messHall, easternmostCorridor, northernmostCorridor, easternmostCorridor, southernmostCorridor, westernmostCorridor, northernmostCorridor };
                            minotaur.Rage = true;
                            minotaur.Time = (minotaur.Path.Count - 1) * 20000;
                            minotaur.Description = "Its fur scorched and smoking, wielding a great sword that streams some spectral fire, and piercing you with its bloodshot red eyes, the looming minotaur thunders a roar as it charges towards you...";
                        }

                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(southernmostCorridor, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == southernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, southernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(southernmostCorridor);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(southernmostCorridor, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != southernmostCorridor) { continue; }
                            }
                            }
                            else if (minotaur.Location == southernmostCorridor)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, southernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(southernmostCorridor);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1]==southernmostCorridor)
                            {
                                if (minotaur.Location.ItemList.Contains(musicBox))
                                {
                                    Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster approaches!");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the south-facing corridor?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        
                        
                        string reply = Console.ReadLine().ToLower().Trim();
                        sw.Stop();
                        if (sw.ElapsedMilliseconds > minotaurAlertedBy && !justStalked && (minotaur.Location == easternmostCorridor || minotaur.Location == westernmostCorridor))
                        {
                            if (minotaur.Path.Count > 1)
                            {
                                newRoom1 = minotaurApproaches(southernmostCorridor, minotaur, false, 14000, false, minotaur.Rage);
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 == southernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }
                                else if (newRoom1 == minotaur.Location)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, newRoom1, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(newRoom1);
                                    }
                                    else
                                    {
                                        Console.ReadKey(true);
                                        return;
                                    }
                                }

                            }
                            continue;
                        }
                        sw.Start();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(southernmostCorridor.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = southernmostCorridor.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != southernmostCorridor.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                if (sw.ElapsedMilliseconds < minotaurAlertedBy)
                                {
                                    minotaurAlertedBy = D6.Roll(D6) * 1000;
                                    sw = new Stopwatch();
                                    justStalked = false;
                                    minotaurAlerted = 0;
                                }

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                success = player1.UseItemOutsideCombat(music, southernmostCorridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                            continue;
                        }
                        Console.WriteLine("Please enter a number corresponding to your choice of action...");
                            minotaurAlertedBy = D6.Roll(D6) * 1000;
                            sw = new Stopwatch();
                            justStalked = false;
                            minotaurAlerted = 0;
                        }
                        southernmostCorridor.FirstVisit = false;
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    if (!leftWhichRooms[8] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    b = 0;
                    a = 0;
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    justStalked = false;
                    sw = new Stopwatch();
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    while (!leftWhichRooms[8])//empty cell
                    {
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    //usesDictionaryItemFeature[jailorKeys].Remove(emptyCellDoor);
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(emptyCell, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == emptyCell)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, emptyCell, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(emptyCell);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(emptyCell, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != emptyCell) { continue; }
                            }
                            }
                            else if (minotaur.Location == emptyCell)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, emptyCell, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(emptyCell);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == emptyCell)
                            {
                                if (minotaur.Location.ItemList.Contains(musicBox))
                                {
                                    Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster approaches!");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(emptyCell.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = emptyCell.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != emptyCell.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }


                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, emptyCell, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    justStalked = false;
                    sw = new Stopwatch();
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    while (!leftWhichRooms[9])//magical manufactory
                    {
                        broomCloset.Description = "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speed. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not long before the vortex hurls you bodily into some dank claustrophobic and frankly smelly closet. As you stagger to your feet your eyes clap sight of an Aladdin's cave of custodian conglomerations, janitorial jumbles and maidly menageries all agglomerated within a cosy 4 foot by 4 foot room. Somewhat ironically, it's a mess. \nYou see a broom.\t\nYou see another broom.\t\nCould that be another broom?\t\nanother br- oh, wait! That's a mop.\t\t";
                        if (!room.FeatureList.Contains(holeInCeiling))
                        {
                            secretChamber.FeatureList.Remove(holeInCeiling);
                            secretChamber.Description = "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speed. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not long before the vortex hurls you bodily into a strange new chamber. You clamber uneasily to your feet, finding yourself in an eerie chamber of disquieting shapes imposed upon velvety darkness; a dusky landscape of sinister contours and unknown threats alleviated only slightly from the flickering glow of a circle of candles arranged occult-like around some kind of pentagram where you landed. As your eyes adjust to your new surroundings, and you can begin to make out the statues and artefacts within, you feel a cold tot of anxiety tie knots in your stomach as you realise the secret chamber has no doors or windows. Instead, as you'll come to realise, you have stumbled upon a glimpse through a keyhole into the mind of the CurseBreaker. One no one was ever meant to see...\nFacing north is some kind of statue, or perhaps a shrine. Lit candles are arranged beneath a marble figure. They cast it in a fiery glow, tossing angular and tortured shadows over the chiselled face of a man crying out in anguish for all eternity. Chained to a rock, an eagle eviscerates and devours his innards as his form, frozen in stone, screams silent screams. A plaque lays at its base, while you can just detect misty jars glinting to its left. \t\nTurning your gaze westward, and squinting your eyes, you can distinguish the shape of a bookcase from within the web of shadows. \t\n To the south you find a portrait hung upon the wall of a man with chiropteric wings. \t\nLooking eastwards you discover something that seems to rattle in the darkness. Investigating further, wading through an agglomeration of arcane baubles and esoteric devices stashed and long forgotten, you find the source of the ominous rattling is a mosaic. It's tiles flip and shuffle like playing cards in the dextrous hands of an invisible dealer. They finally settle on the image of a non-descript face, gazing down upon you...\t\t";
                        }
                        else
                        {
                            secretChamber.Description = "Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speed. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not long before the vortex hurls you bodily into a strange new chamber. You clamber uneasily to your feet, finding yourself in an eerie chamber of disquieting shapes imposed upon velvety darkness; a dusky landscape of sinister contours and unknown threats alleviated only slightly from the flickering glow of a circle of candles arranged occult-like around some kind of pentagram where you landed. As your eyes adjust to your new surroundings, and you can begin to make out the statues and artefacts within, you feel a cold tot of anxiety tie knots in your stomach as you realise the secret chamber has no doors or windows. Instead, as you'll come to realise, you have stumbled upon a glimpse through a keyhole into the mind of the CurseBreaker. One no one was ever meant to see...\nFacing north is some kind of statue, or perhaps a shrine. Lit candles are arranged beneath a marble figure. They cast it in a fiery glow, tossing angular and tortured shadows over the chiselled face of a man crying out in anguish for all eternity. Chained to a rock, an eagle eviscerates and devours his innards as his form, frozen in stone, screams silent screams. A plaque lays at its base, while you can just detect misty jars glinting to its left. \t\nTurning your gaze westward, and squinting your eyes, you can distinguish the shape of a bookcase from within the web of shadows. \t\n To the south you find a portrait hung upon the wall of a man with chiropteric wings. \t\nLooking eastwards you discover something that seems to rattle in the darkness. Investigating further, wading through an agglomeration of arcane baubles and esoteric devices stashed and long forgotten, you find the source of the ominous rattling is a mosaic. It's tiles flip and shuffle like playing cards in the dextrous hands of an invisible dealer. They finally settle on the image of a non-descript face, gazing down upon you...\t\t";
                        }
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(magicalManufactory.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = magicalManufactory.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower, choiceVersusDestination, worktop);
                                if (newRoom.Name != magicalManufactory.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                else if (worktop.Description.Contains("It's been thoroughly trashed after your fight with Merigold..."))
                                {
                                    if (mageBattle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature,
                                        magicalManufactory, player1, usesDictionaryItemChar, holeInCeiling, specialItems))
                                    {
                                        mageBattle.WonFight(magicalManufactory);
                                        worktop.Description = "Aisles of haphazardly arranged worktops, replete with conical flasks, distillation tubes, alchemical devices and round-bottom retorts bubbling with strange essences form a mismanaged maze of meticulous mayhem, lovingly adorned with Merigold's eviscerated corpse. MWA HA HA HA!!!";
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }


                            b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, magicalManufactory, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    justStalked = false;
                    sw = new Stopwatch();
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[10] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you and into the broom closet...\nUh, this could be bad.");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[10])//broom closet
                    {
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(broomCloset.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = broomCloset.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != broomCloset.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }


                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(music, broomCloset, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }

                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[11])//highest parapet
                    {
                    player1.Speedy = false;    
                    visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                    usesDictionaryItemFeature[vanquisher].Add(crystalTotem1);
                    usesDictionaryItemFeature[vanquisher].Add(crystalTotem2);
                    usesDictionaryItemFeature[vanquisher].Add(crystalTotem3);
                    usesDictionaryItemFeature.Add(staffMG, new List<Feature> { crystalTotem1, crystalTotem2, crystalTotem3 });
                    ///enter new Dictionaries for item use here
                    ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                    ///red herring in room above
                    ///Specific for each room, tailored.

                    if (!oubliette.FirstVisit)
                    {
                        Console.ReadKey(true);
                        highestParapet.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);

                        FinalAct denouement = new FinalAct(player1, CurseBreaker);

                        Combat climax = new Combat(CurseBreaker, player1);
                        
                        
                        if (climax.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, highestParapet, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 4, false, true))
                        {
                            Console.WriteLine("Yippee!");
                            victorious = true;
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        // if midnight clock not null then time remaining determines 
                        // how many turns you have in the fight.
                    }
                    
                    if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(highestParapet.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = highestParapet.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != highestParapet.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }


                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                success = player1.UseItemOutsideCombat(music, highestParapet, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[12])//huge barracks
                    {
                        Console.WriteLine("Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...");
                        Console.ReadKey(true);
                        Console.WriteLine("Within an exhilarating instant you feel gravity lurch back into existence. You scream your way through the portal before landing splat in the middle of a muddy field - at least that's all that can be seen of it, because you landed face first in what *feels* the swampiest bit of it. \n   Already sensing you may be somewhere other than your intended destination, you mutter a few disparaging remarks under your breath aimed at the dotty old wizard and his calculations. You grope your way to your feet and at last wipe the mud from your eyes...");
                        Console.ReadKey(true);
                        Console.WriteLine("Then you discover scores of goblins peering back at you, momentarily agog. You freeze as you take in the tents, cooking fires and palisade walls of a huge mustering ground for the CurseBreaker's army...");
                        Console.ReadKey(true);
                        Console.WriteLine("Before you can even begin to utter something - anything - by way of explanation, the goblin nearest you chucks his paltry gruel from his lap - 'Looks like meat's back on the menu, boys!' he booms and the many goblins roar with glee as they tie you up to a spit and stick an apple in your mouth. \nHad you a fist free you'd be shaking it at the sky and yelling, 'Damnit Merigold!!!' but you'll just have to settle for becoming a delectable appetiser for a gaggle of goblins instead...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                        return;
                        
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[13])// desert island
                    {
                        Console.WriteLine("Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...");
                        Console.ReadKey(true);
                        Console.WriteLine("Suddenly gravity lurches back into existence and you plunge into the warm waters of some deep blue lagoon. Wading your way to a beautiful shoreline of pearly white sand untouched by any civilisation, you yell out a hopeful greeting, calling to anyone who might hear. However, the tropical island is quite deserted.");
                        Console.ReadKey(true);
                        Console.WriteLine("With no way back, you spend your time waiting for passing vessels to flag down, drinking copious amounts of coconut milk and smoking weird mushrooms that grow under rocks. In time, you make friends with a coconut named 'Wilson'...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                        return;
                        
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[14])//bank vault
                    {
                        Console.WriteLine("Your stomach lurches the moment you find yourself consumed, sucked in, by the crackling magics of the portal. In an instant you've left gravity behind as you weightlessly float through exotic landscapes and distant places, all surging by you at breakneck speeds. Time becomes a flurry of disjointed instants, snapshots of places beheld amidst the enveloping whorl of energy. It's not before long you find yourself plummeting to a new location...");
                        Console.ReadKey(true);
                        Console.WriteLine("You crash into a vast mound of glittering coins, skittering away from you as you tumble down it like a giant golden sand dune. You look around in astonishment to find yourself in a vast chamber resplendent with untold riches, fine tapestries, mountains of gold bars, thrones, crowns, and innumerable jewels. You cheer as you run giddily through this incredible place, adorning as much jewelry as you can short of making your knees buckle and your pockets burst. Then you freeze... ");
                        Console.ReadKey(true);
                        Console.WriteLine("An icy dread fills you as you behold a vast vault door sealing the place in. You're in some kind of bank vault! You bang on the door for help, you search for other exits, but there is no way out. You are destined to be rich to the end of your days - all three of them...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                        return;
                        
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[15])//dragon's lair
                    {
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                    ///enter new Dictionaries for item use here
                    ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                    ///red herring in room above
                    ///Specific for each room, tailored.
                    if (!dragonLair.FirstVisit)
                    {
                        Console.WriteLine("You find yourself crashing once again into the dragon's lair - the *same* dragon's lair. And it's the same dragon that now fixes you with icy exasperation as you stumble to your feet...");
                        Console.ReadKey(true);
                        Console.WriteLine("You ask (rather nervously) it if it would, maybe, like to challenge you to another riddle...?\n\nIt incinerates you instead.");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return;
                    }
                    if (b > 0 || a > 0)
                    {
                        Combat goldDragonBattle = new Combat(goldDragon, player1);
                        Console.WriteLine("You suddenly halt what you're doing!");
                        Console.ReadKey(true);
                        Console.WriteLine("Around you the whole cave rumbles. The waters of the previously tranquil lake roil and froth. The mounds of glittering gold coins cascade in a tumult.\n\nFrom beneath them all something has woken...");
                        Console.ReadKey(true);
                        Console.WriteLine("You stare agog as a terrific dragon rises from underneath the treasure, streams of jewels and gold cascading from its scales as it rises to its feet and then pivots languidly to fix its smouldering eyes upon you...");
                        Console.ReadKey(true);
                        if(player1.Inventory.Contains(ruby) || player1.Inventory.Contains(emerald) || player1.Inventory.Contains(sapphire) || player1.Inventory.Contains(goldDoubloon) || player1.Inventory.Contains(silverBars))
                        {
                            Console.WriteLine("You follow its gaze as it appraises your pockets bulging with gems, your backpack bursting with gold and your armfuls of silver that you let clatter about your feet in tremulous fright." +
                                "\nYou make a clumsy attempt to explain your predicament; quavering about portals and wizards and some person called the CurseBreaker, all while the dragon stares at you with bored disdain, showing no inclination of caring about the details of your (let's face it) most-likely fatal mishap... \nThe gold dragon cuts you off with a drawl, it's sleepy, firedim eyes drooped to cynical half-mast." +
                                "\n\t'I might've indulged your pleas, ape-thing,' It's voice resonates inside your head, never spoken, but in the guise of an all-encompassing voice, 'had you not so brazenly purloined my treasure. With it untouched you might have bargained your way back from wherever you came from, but alas...' \n  It yawns before flexing its powerful wings and raking its claws languidly upon the cave wall, sharpening them to a razor-edge. 'To let a thief and liar escape and tell tale of my trove sets a bad precedent And I simply can't let that happen...'");
                            Console.ReadKey(true);
                            Console.WriteLine("You mutter something disparaging about wizards and their kooky calculations before drawing your weapon in a futile show of defiance against fate.\n\nMeanwhile, the gold dragon stretches sedately, takes a deep inhale and prepares to turn you into cinders...");
                            
                            if (goldDragonBattle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, dragonLair, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, true, false))
                            {
                                Console.WriteLine("Just kidding!\n\nThe dragon incinerates you alive...");
                                Console.ReadKey(true);
                                Console.WriteLine("Your adventure ends here");
                                Console.ReadKey(true);
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You nervously greet the dragon and desperately try to explain your situation. \n\nThe dragon, in turn, just stares at you with bored disdain, it's sleepy firedim eyes drooping to cynical half-mast. However, it also senses truth in your words.");
                            Console.ReadKey(true);
                            Console.WriteLine("After a moment's consideration, and with what you sense to be an ancient cunning rousing itself behind those frightful eyes, it chooses to indulge you...");
                            Console.ReadKey(true);
                            Console.WriteLine("\n\t'Very well, ape-thing,' it addresses you haughtily, 'you've managed to respect my treasure and leave it untouched and I detect no scent of deception about your words. Let us see if you're worthy of freedom. \n\t'Answer me this riddle,' it declares, 'and I shall use my own considerable powers to whisk you back from whence you came...'");
                            Console.ReadKey(true);
                            Console.WriteLine("You say you agree to the dragon's terms - afterall, what choice do you have...");
                            Console.ReadKey(true);
                            Console.WriteLine("\n\t'You have one guess,' it rumbles with what you assume must be a devious leer upon its draconic visage, 'try to make it a good one and listen closely...'");
                            Console.ReadKey(true);
                            List<string> riddleMeThis = new List<string> 
                            { 
                                "\nI can never be emptied, \nI can never be drained," +
                                "\nI can never be filled, \nI can never be exchanged," +
                                "\n\nI am no gold cup or glittering chalice in view, " +
                                "\n For with age they grow dull, " +
                                "\n Where as I am only dull when I am new," +
                                "\n And I am only new when I am far from full..." +
                                "\n\nThe dragon leers expectantly as it sharpens its talons. 'What am I?'\t    moon     ",

                                "\nI am drawn, but not on paper," +
                                "\nSeldom will you find my outline scrawled in ink." +
                                "\nLight is what I yield should I taper," +
                                "\nOr darkness when my two halves come to link." +
                                "\n\nThe dragon leers expectantly as it sharpens its talons. 'What am I?'\t    curtain      ",

                                "\nIf you were to ask me the answer to my riddle," +
                                "\nI would never be able to answer," +
                                "\nFor I’m tongue-tied; bound straight down the middle." +
                                "\nI could be quite the dancer," +
                                "\nI can follow your every step," +
                                "\nBe sure to find my answer," +
                                "\nOr else softly you must tread." +
                                "\n\nThe dragon leers expectantly as it sharpens its talons. 'What am I?'\t    shoe      ",

                                "\nThese keys unlock no doors of note," +
                                "\nBut do reveal a note no author ever wrote." +
                                "\nThough some wrote notes that I utter with no" +
                                " throat,\nThese notes that they wrote have no words of which they can gloat," +
                                "\nAnd it’s these notes with no words, but with sentences and phrases," +
                                "\nThat gauges which notes that no author ever wrote are revealed in phases," +
                                "\n\nThe dragon leers expectantly as it sharpens its talons. 'What am I?'\t    piano      ",

                                "\nWhen I fill a concert hall," +
                                "\nCrowds upon crowds of people I might enthral." +
                                "\nI follow every fish in the sea," +
                                "\nAlthough I cannot claim that they notice me," +
                                "\nAnd, on balance, no one would claim that I’m regal," +
                                "\nBut I am the thing that judges to make things equal." +
                                "\nI might weigh heavily on your mind," +
                                "\nFor I am seen on every map," +
                                "\nYet I am no road, no city, no place to find," +
                                "\nAnd I can be reached by no adventurer, man or indeed any chap." +
                                "\n\nThe dragon leers expectantly as it sharpens its talons. 'What am I?'\t    scale      "



                            };
                            Dice D5 = new Dice(5);
                            int index = D5.Roll(D5) - 1;
                            Console.WriteLine(riddleMeThis[index].Substring(0, riddleMeThis[index].IndexOf("\t")));
                            Console.WriteLine("Type your answer (as a single word!) below or else type 'done' if you give up...");
                            while (true)
                            {
                                string answer = Console.ReadLine().Trim().ToLower();
                                if (string.IsNullOrWhiteSpace(answer))
                                {
                                    continue;
                                }
                                //try
                                //{
                                    bool checkWord = false;
                                    StreamReader sr = new StreamReader("dictionary.txt");
                                    string line = sr.ReadLine().Trim();
                                    while (line[0] != 'z')
                                    {
                                        if (line.Trim().ToLower() == answer)
                                        {
                                            checkWord = true;
                                        }
                                        line = sr.ReadLine().Trim();
                                    }
                                    if(answer == "done")
                                    {
                                        Console.WriteLine("'You give up? So be it...' the dragon intones with relish. \n\nYou're barely able to draw your weapon before the dragon lunges at you.");
                                        if (goldDragonBattle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, dragonLair, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, false))
                                        {
                                            Console.WriteLine("Just kidding!\n\nThe dragon incinerates you alive...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Your adventure ends here");
                                            Console.ReadKey(true);
                                            return;
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else if (!checkWord)
                                    {
                                        Console.WriteLine("That's not a word the dragon's ever heard of, and they're a very loquacious dragon! Try again...");
                                        continue;
                                    }
                                    else if (riddleMeThis[index].Substring(riddleMeThis[index].IndexOf("\t") + 2, 11).Trim() == answer || riddleMeThis[index].Substring(riddleMeThis[index].IndexOf("\t") + 1, 11).Trim() + "s" == answer)
                                    {
                                        Console.WriteLine("The dragon surveys you haughtily, before conceding defeat. \n\t'Very well, ape-thing,' it says, 'take your leave.'" +
                                            "\n\nHowever, it's not as if you could've refused even if you'd tried, for with one imperious gesture of it's huge claw a portal opens beneath your feet and you plummet through it and to a new destination...");
                                        Console.ReadKey(true);
                                        dragonLair.FirstVisit = false;
                                        newRoom1 = broomCloset;
                                        leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                        break;

                                    }
                                    else if ((player1.Traits.ContainsKey("jinxed") || player1.Traits.ContainsKey("friends with fairies")) && answer == "dragon")
                                    {
                                    string description = "If the dragon's eyes were drooped to cynical half-mast before, now they're in danger of rolling all the way to the back of its draconic head.";
                                    string parlance = "'It seems the basics of riddles eludes you somewhat, ape-thing,' the dragon replies with pained exasperation. 'When I say, *what am I?*, I don't mean it literally...'";
                                    Dialogue dragon = new Dialogue(player1, dragonLair);
                                    List<string> responses = new List<string> 
                                    { 
                                        "You reply you can hardly be very literary. Afterall, there's no paper and pen down here...",
                                        "You reply by repeating the obvious; but you are a dragon, right...?",
                                        "You apologise and tell him you were always better at charades anyhow. Would they care to play charades?"
                                    };    
                                    switch(dragon.Parle(description, parlance, responses))
                                    {
                                        case 1:
                                            Console.WriteLine("The dragon's eyes narrow dangerously as it surveys you. 'You misunderstand, ape-thing,' it replies with in soft and deadly tones, 'literally means not a simile or metaphor. For example, saying you are literally paper would be wrong, but saying you are metaphorically paper would be right, seeing as you share the property of burning to ashes whenever I feel like it...'");
                                            Console.ReadKey(true);
                                            Console.WriteLine("You're about to respond when the dragon continues, 'Or perhaps you need a more *palpable* demonstration...'");
                                            if (goldDragonBattle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, dragonLair, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, false))
                                            {
                                                Console.WriteLine("Just kidding!\n\nThe dragon incinerates you alive...");
                                                Console.ReadKey(true);
                                                Console.WriteLine("Your adventure ends here");
                                                Console.ReadKey(true);
                                                return;
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        case 2:
                                            description = "The dragon glowers at you, it's disdain crystalising into a kind of baleful vexation.";
                                            parlance = "'That's hardly the point, ape-thing...' it responds with a voice as icy as the thin ice you're metaphorically walking on.";
                                            responses.Clear();
                                            responses.Add("You doggedly and cogently pursue your syllogistic inquiry to its inexorable logical conclusion: 'but you *are* a dragon, so I answered the question right, right...?'");
                                            responses.Add("You tell the dragon that you thought the point was to answer the riddle correctly, which you did and now you'd like to be whisked back tout suite...");
                                            switch (dragon.Parle(description, parlance, responses))
                                            {
                                                default:
                                                    Console.WriteLine("The dragon scowls, seems to very sincerely consider multiple methods of killing you... slowly, before finally deciding that it wouldn't be worth the effort.");
                                                    Console.WriteLine("It mumbles something about silly ape-things before imperiously gesturing with its claw and casting a portal to open up at your feet. You plummet through it and finally leave the poor dragon in peace.");
                                                    Console.ReadKey(true);
                                                    dragonLair.FirstVisit = false;
                                                    newRoom1 = broomCloset;
                                                    leftWhichRooms = newRoom1.WhichRoom (leftWhichRooms);
                                                    break;
                                            }
                                            break;
                                        default:
                                            description = "The dragon simply glowers at you, it's disdain crystalising into a baleful hostility. It seems to hold back from burning you to cinders only because it believes instant cremation would be too good for you...";
                                            parlance = "";
                                            responses.Clear();
                                            responses.Add("You get the ball rolling: 'Oh so, umm... [motion a book]... and, uh, four syllables... oops! I'm not supposed to say that...'");
                                            responses.Add("Begin an elaborate mime routine - walking down invisible stairs, trapped in a glass box, et cetera... all the while slowly inching your way to the lovely, cool, watery, not-at-all-flammable lake...");
                                            responses.Add("You make another suggestion: 'Or there's this game they play in the CurseBreaker's tower called coins...'");
                                            switch(dragon.Parle(description, parlance, responses))
                                            {
                                                case 1:
                                                    Console.WriteLine("The dragon eyes your inane antics with incredulity - incredulity at how blundersome you are. You've already obliviously given the answer away twice by the time the dragon mercifully interrupts your performance with a fireball. You are incinerated within moments...");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("Your adventure ends here...");
                                                    Console.ReadKey(true);
                                                    return;
                                                case 2:
                                                    Console.WriteLine("The dragon eyes your antics with mounting disdain. It's a beast that has survived for centuries, deployed great wit and cunning in innumerable measure to do so, and here before it prances this ape-thing who thinks it can escape by doing a silent hokey-pokey into the lake...\nThe dragon heaves a heavy sigh before swatting you with its claw...");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("Your adventure ends here...");
                                                    Console.ReadKey(true);
                                                    return;
                                                default:
                                                    Console.WriteLine("The dragon evidently thinks 'coins' sounds like a terrible game. Anyway, it has enough of them already. With one lazy flick of its claw it lops off your head before your daftness becomes infectious...");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("Your adventure ends here...");
                                                    Console.ReadKey(true);
                                                    return;
                                            }

                                    }
                                    break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("'Wrong answer...' the dragon intones with relish. \n\nYou're barely able to draw your weapon before the dragon lunges at you.");
                                        if (goldDragonBattle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, dragonLair, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, false))
                                        {
                                            Console.WriteLine("Just kidding!\n\nThe dragon incinerates you alive...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Your adventure ends here");
                                            Console.ReadKey(true);
                                            return;
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                //}
                                //catch { Console.WriteLine("dictionary dysfunctional"); }
                            }
                            break;
                        }
                    }
                    if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(dragonLair.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = dragonLair.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                                if (newRoom.Name != dragonLair.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }


                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                success = player1.UseItemOutsideCombat(music, dragonLair, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[16] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    justStalked = false;
                    sw = new Stopwatch();
                    while (!leftWhichRooms[16])//secret chamber
                    {
                        visitedRoom = true;
                    holeInCeiling.Name = "hole in floor";
                        holeInCeiling.Description = "The pale light from the strange braziers of your cell spill through the hole and barely luminate your dark surroundings, like moonbeams cresting a horizon at dusk. It leads to your cell below.";
                        holeInCeiling.Passing = "You clamber down the hole and into your cell below...";
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(secretChamber, redThread, musicBox, threadPath, player1))
                            {
                                if (minotaur.Location == secretChamber)
                                {
                                    if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, secretChamber, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                    {
                                        minotaurKafuffle.WonFight(secretChamber);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else if (minotaurAlerted > minotaurAlertedBy)
                                {
                                    justStalked = true;
                                    newRoom1 = minotaurStalks(secretChamber, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    if (newRoom1 == oceanBottom)
                                    {
                                        return;
                                    }
                                    leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                if (newRoom1 != secretChamber) { continue; }
                            }
                            }
                            else if (minotaur.Location == secretChamber)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, secretChamber, player1, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false, player1.Masked))
                                {
                                    minotaurKafuffle.WonFight(secretChamber);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (minotaur.Path[1] == secretChamber)
                            {
                                if (minotaur.Location.ItemList.Contains(musicBox))
                                {
                                    Console.WriteLine($"You tip-toe as softly as you can while the minotaur is distracted in the {minotaur.Location.Name} by the music box...");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine($"Up and down the {newRoom1.Name} braziers quiver as the monster approaches!");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine($"[2] Investigate the {newRoom1.Name}?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                            {
                                Console.WriteLine("Please enter a number corresponding to a choice of action.");
                                continue;
                            }
                            else if (reply1 == 1)
                            {
                                player1.SearchPack(secretChamber.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = secretChamber.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower, null, null, mosaicPortal);
                                if (newRoom.Name != secretChamber.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                if (mosaic2.SpecificAttribute == "unlocked")
                                {
                                    mosaic2.CastDoor().Name = "ajar mosaic door";
                                    mosaic2.CastDoor().Passing = "You push the strange mosaic and it opens out into an unfamiliar corridor, when you turn back around you find it has disappeared...";
                                    mosaic2.CastDoor().Portal = mosaicPortal;
                                    mosaic2.CastDoor().Attribute = false;
                                    mosaic2.CastDoor().SpecificAttribute = "unlocked";
                                }

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                success = player1.UseItemOutsideCombat(music, secretChamber, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[17])//prehistoric jungle
                    {
                        Console.ReadKey(true);
                        Console.WriteLine("You crash through a verdant canopy, bumping into one branch, before bouncing off the next, endlessly and oafishly tumbling down the length of a huge tree before you plummet to some forest floor. It takes you a while to pick yourself up and get your bearings...");
                        Console.ReadKey(true);
                        Console.WriteLine("You find yourself wondering just where on earth that strange wizard teleported you - this looks nothing like you're intended destination. Then something comes crashing through the trees towards you. It peers through the foliage at you, looming fifteen feet high with hungry reptilian eyes and teeth the size of sabres. Uh-oh... You manage to mutter a disparaging word or two about wizards under your breath before fleeing for your life. The tyrannosaurus rex happily stomps after you through the prehistoric jungle...");
                        Console.ReadKey(true);
                        Console.WriteLine("You're adventure ends here...");
                    Console.ReadKey(true);
                        return;
                        
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[18])//astral planes
                    {
                    Console.ReadKey(true);
                    Console.WriteLine("You are hurled out of the vortex and into the most alien place imaginable...");
                    Console.ReadKey(true);
                    Console.WriteLine("You find yourself floating through space alongside rocks the size of mountains, the atmosphere so much thinner that you're head spins. You hop from one boulder to the next before you're finally able to cling on to one and get your bearings.");
                    Console.ReadKey(true);
                    Console.WriteLine("You find yourself in the astral planes, a place of existence spanning the heavens, where all kinds of otherworldly creatures inhabit. And you scarcely able to even breathe in this wondrous habitat adorned with supernovae and the lights of alien galaxies, are perfect prey for all the nasties that make this plane of existence home. With no way back and no way out you can only futilely shake your fist and mutter a disparaging word about wizards and their calculations...");
                    Console.ReadKey(true);
                    Console.WriteLine("You're adventure ends here...");
                    Console.ReadKey(true);
                    return;
                   
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[19])//ocean bottom
                    {
                    Console.ReadKey(true);
                    Console.WriteLine("You emerge through the portal still floating - but not through air. To your horror you've been whisked to the ocean bottom, far far beneath the surface where only the faintest light reaches.");
                    Console.ReadKey(true);
                    Console.WriteLine("You already know there's no way to make it to the surface before you drown, but even if you could you feel your body struggling with the undersea pressure, somehow causing black spots to appear in your vision. You shake your fist at wizards everywhere, issuing a chain of bubbles that would've made a good rant had you not been transported somewhere underwater by that bumbling, daft - oh look, a kraken...");
                    Console.ReadKey(true);
                    Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                    return;
                    
                }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (minotaur.Location == corridor && !corridor.Description.Contains("You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you...")) { corridorItems.Add(garment); corridorItems.Add(bowlFragments); corridorItems.Add(looseNail); corridorItems.Add(splinter); corridor.ItemList = corridorItems; corridor.Description += "You see garments hurled about the corridor, braziers wrought, doors hacked. The monster has been very thorough in its search for you..."; }
                    if (minotaur.Location == antechamber && !antechamber.Description.Contains("You are struck by the carnage of the monster's obsessive hunt.")) { antechamber.ItemList.Add(breastplate); antechamber.ItemList.Add(helmet); antechamber.ItemList.Add(clunkySabaton); antechamber.Description = "You are struck by the carnage of the monster's obsessive hunt. The once wondrous and spacious antechamber is strewn with smashed breastplates and other detritus from the armoury. The monster also seems to have taken out its rage on the pillars, for you find them hacked with chunks of that fabulous marble scattered everywhere. The unscathed mosaic, high above the double doors, surveys it all.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t"; }
                    if (!leftWhichRooms[20] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you, leading it down the treacherous steps...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    bool descending = true;
                    while (!leftWhichRooms[20])//dungeon Chamber : only way in is by the stairs. can be bypassed by portal
                    {
                        bool leave = false;
                        
                        if (stairwayToLower.Dark && descending)
                        {
                            Console.ReadKey(true);
                            Console.WriteLine("Traversing these treacherous steps in the dark is no mean feat. You must continually test your skill all the way down.");
                            Dice D8 = new Dice(8);
                            int tests = 9 - player1.Skill/2;
                            List<string> slips = new List<string> 
                            { 
                                "You miss a step in the dark and take a fall...",
                                "You slip and tumble down some steps...",
                                "You lose your balance and trip...",
                                "You grope in the dark before lurching forward and plummeting several steps down...",
                                "You hit your head on something in the dark and stumble...",
                                "You crash forwards as you lose your footing...",
                                "One of the steps crumbles underfoot! You are sent careering headfirst...",
                                "You slip on the damp steps and crash on your back!"
                            };
                            
                            while (tests > 0)
                            {
                                Console.WriteLine("Test your skill:\n[You must roll a D8 under or equal to half your skill score]");
                                Console.ReadKey(true);
                                int result = D8.Roll(D8);
                                if (result > player1.Skill / 2)
                                {
                                    Thread.Sleep(93);
                                    int slip = D8.Roll(D8) - 1;
                                    Console.WriteLine($"You rolled {result}\n" + slips[slip]);
                                    slip = 0;
                                    for (int i = 0; i < 4; i++)
                                    {
                                        Thread.Sleep(27);
                                        slip += D8.Roll(D8);
                                    }
                                    player1.Stamina -= slip;
                                    Console.WriteLine($"You've lost {slip} stamina!");
                                    Console.ReadKey(true);

                                    if (player1.Stamina < 0)
                                    {
                                        Console.WriteLine("This fall is your last. Losing all footing and all purchase on the steep stairs, you plummet endlessly down them. By the time your crumpled body reaches the bottom, your neck has snapped.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Your adventure ends here...");
                                        return;
                                    }
                                    else
                                    {
                                        if (tests > 1 && tests < 3 && !player1.Inventory.Contains(pocketWatch)) 
                                        { 
                                            Console.WriteLine("As you stumble back to your feet, groping for support in the dark, your hand clasps upon something.\nAt first you think it might be a pebble, however it's surface is too smooth, too perfectly circular to be anything other than man-made. It's cool to the touch and when you hold it to your ear you notice a faint ticking emanate from inside...");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Will you stash the mystery item in your backpack?");
                                            if (getYesNoResponse())
                                            {
                                                player1.Inventory.Add(pocketWatch);
                                                Console.WriteLine("What harm could it do? You stow it away.");
                                                discovery = true;
                                                Console.ReadKey(true);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Uh, best not. You throw the mystery item away.");
                                                Console.ReadKey(true);
                                            }
                                        }
                                        Console.WriteLine("Would you like to continue down the stairs?");
                                        if (getYesNoResponse())
                                        {
                                            tests--;
                                            continue;
                                        }
                                        else
                                        {
                                            newRoom1 = stairwayToLower.CastDoor().Passage(dungeonChamber);
                                            leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                            
                                            
                                            break;
                                        }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("You gingerly take the next few steps...");
                                    Console.ReadKey(true);
                                    
                                }
                                

                                tests--;
                            } 
                        }
                        else if (descending)
                        {
                            Console.ReadKey(true);
                            Console.WriteLine("Traversing these treacherous steps even when brightly lit by Merigold's magic is no mean feat. You must continually test your skill all the way down.");
                            Dice D8 = new Dice(8);
                            int tests = 3 - player1.Skill / 3;
                            List<string> slips = new List<string>
                            {
                                "In your rush to reach the oubliette before midnight you miss a step and take a fall...",
                                "As you race down the brightly lit sheer steps you slip and tumble...",
                                "As you hurry down the steps two at a time you lose your balance and trip...",
                                "You pick up the speed before lurching forward and plummeting several steps down..."
                                
                            };

                            while (tests > 0)
                            {
                                Console.WriteLine("Test your skill:\n[You must roll a D6 under or equal to half your skill score]");
                                Console.ReadKey(true);
                                int result = D6.Roll(D6);
                                if (result > player1.Skill / 2)
                                {
                                    Thread.Sleep(result * D8.Roll(D8));
                                    int slip = (D8.Roll(D8)-1)/2;
                                    Console.WriteLine($"You rolled {result}\n" + slips[slip]);
                                    slip = 0;
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Thread.Sleep(27);
                                        slip += D8.Roll(D8);
                                    }
                                    player1.Stamina -= slip;
                                    Console.WriteLine($"You've lost {slip} stamina!");
                                    Console.ReadKey(true);
                                    if (player1.Stamina < 0)
                                    {
                                        Console.WriteLine("This fall is your last. Losing all footing and all purchase on the steep stairs, you plummet endlessly down them. By the time your crumpled body reaches the bottom, your neck has snapped.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Your adventure ends here...");
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Would you like to continue down the stairs?");
                                        if (getYesNoResponse())
                                        {
                                            tests--;
                                            continue;
                                        }
                                        else
                                        {
                                            newRoom1 = stairwayToLower.CastDoor().Passage(dungeonChamber);
                                            leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);


                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (tests == 1)
                                    {
                                        Console.WriteLine("You keep your footing, furtively racing against time as midnight looms...");
                                        Console.ReadKey(true);
                                    }
                                    if (tests == 2) 
                                    {
                                        Console.WriteLine("You press on down the steps two at a time...");
                                        Console.ReadKey(true);
                                    }
                                    if (tests == 3)
                                    {
                                        Console.WriteLine("You tentatively pick up the pace, the steps whisking under your feet as you race down...");
                                    }
                                }
                                tests--;
                            }
                        }
                        if (leftWhichRooms[20])
                        {
                            break;
                        }
                        if (discovery)
                        {
                            Console.WriteLine($"Upon stepping into the faint light near the foot of the stairwell you discover that the mystery item is in fact a pocketwatch! \n{pocketWatch.Description}");
                            Console.ReadKey(true);
                            Console.WriteLine("You descend the last few steps without issue.");
                            Console.ReadKey(true);
                            discovery = false;
                        }
                        descending = false;
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        stairwayToLower.Description = "The steep stone steps ascend beyond the faint light of the lone brazier and up towards the corridor above.";
                        stairwayToLower.Passing = "Leaving this ghastly chamber behind and whatever further horrors lurk beyond the trapdoor, you ascend the steep steps...";
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                    usesDictionaryItemItem.Add(throwingKnife, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife2, new List<Item>());
                    usesDictionaryItemItem.Add(throwingKnife3, new List<Item>());
                    usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        ///
                        if (ghoul1.Stamina == 1)
                        {
                            Console.ReadKey(true);
                            Console.WriteLine("Suddenly, from beyond the braziers enchanted light, those hulking silhouettes jerk to life. They rise, their angular and unsettling forms looming at least seven feet, and amble towards you, eyes gleaming spookily from within the shadows. You feel the hairs on your arms stand on end as yu brace yourself for what approaches...");
                            Console.ReadKey(true);
                            Console.WriteLine("The shadowy figures, upon catching your scent, suddenly lunge at you. Their bodies snap from jerky steps to disjointed lurch in the darkness, sending you pale. You think they're about to overwhelm you when the strange creatures are caught by the rusty chains that fetter them to the far wall.\nThey stop, snared, just within the faint light and standing just a step over the trapdoor.");
                            Console.ReadKey(true);
                            if (player1.Traits.ContainsKey("thespian"))
                            {
                                Console.WriteLine("Your courageous facade slips, as you recoil from the beasts before you. Never in your most fevered imaginings and tall tales have you once envisioned such gangly and frightful creatures as these.");
                            }
                            else if (player1.Traits.ContainsKey("diligent") || player1.Traits.ContainsKey("medicine man"))
                            {
                                Console.WriteLine("You recoil in shock. For you recognise what lurches before you. Ghouls - souls cleaved from their bodies through dark magic, twisted until they retain only a glimmer of who they once were, and then stitched with necromancy back to their hollow shells like strings to a vile puppet.");
                            }
                            else
                            {
                                Console.WriteLine("You recoil in fright from the horrific creatures before you. You don't need to know what they are to tell that some dark sorcery is at work behind those blank, listless eyes staring back at you.");
                            }
                            Console.ReadKey(true);
                            Console.WriteLine("They each look as though they stand upon death's door, their emaciated forms hideous to look upon. Their pale skin is taut over their bones. Their limbs are unnaturally long, as though their bodies had suffered the winching of a rack. But their eyes...\nTheir eye sockets are sunken pits from which untold and ineffable suffering lurks behind misted eyes. Tears trail their cheeks even as they savagely flail at you. It's almost as if some glimmer of what they once were, deep within some dementia, was pleading their body to hold back...\nYou make sure to keep out of their reach as you peer closer at the pitiable figures...");
                            Console.ReadKey(true);
                            Console.WriteLine("You notice that the left figure's tattered garb is that of a paladin. Its hands are grimy with soot, and its cracked fingernails seem to have something trapped under them. As for the second, it wears a wedding ring upon its finger - a gold band. As it's claw-like hand flails in front of your face, a name, engraved upon the gold, flashes before your eyes; 'Willow.'");
                            if (bookEC3.Attribute && journal.Attribute)
                            {
                                Console.ReadKey(true);
                                Console.Write(" Suddenly you remember the name from the empty cell above, one of the ones opposite your own. It's with a dawning species of horror, hitherto utterly alien to you, that you realise the creatures before you are - or were - your fellow prisoners. They've been transfigured into this form by the Curse-Breaker, that they might guard whatever lies through the trapdoor below...");
                            }
                            Console.ReadKey(true);
                            Console.WriteLine("\nIt takes a while for your feelings to turn to what must be done. \nThey both stand over the trapdoor and you won't be able to reach it, or anything else in this dungeon, without first dealing with the pitiable figures before you.");
                            Console.WriteLine("Will you put an end to these creatures?");
                            if (getYesNoResponse())
                            {
                                if (player1.WeaponInventory.Count == 0)
                                {
                                    Console.WriteLine("You search the floor for a weapon before finding a snapped femur with a deadly sharp point.");
                                    Console.ReadKey(true);
                                }
                                Console.WriteLine($"Will you attack the ghoul to your left first or the ghoul to your right?\n[1] {ghoul1.Name}\n[2] {ghoul2.Name}");
                                if (getIntResponse(3) == 1)
                                {
                                    string ghoulString = "the pitiful ghoul";
                                    if (journal.Attribute && bookEC3.Attribute)
                                    {
                                        ghoulString = "your fellow prisoner";
                                    }
                                    Dialogue sweetMurderousFun = new Dialogue(player1, ghoul1);
                                    string description = $"You take a moment to steel yourself. You take a deep breath. Then you draw your weapon and step towards the {ghoul1.Name}.";
                                    List<string> pityMePlease = new List<string>
                                {
                                    $"You see your reflection in the glassy eyes of {ghoulString} as you make your solemn approach, footsteps clapping resolutely upon the cold granite floor. Something behind those eyes gazes back at you, pleading you. But whether it's for mercy or for the release of death, you cannot say...",
                                    $" They seem to not know themselves as they claw frenziedly at you...",
                                    $" They still claw at you in pained and sluggish swings, but their efforts are more than feeble. They slowly turn their gaze up at you, a rueful hopelessness lurking somewhere behind its misted and glittering eyes..."
                                };
                                    List<List<string>> makeAToughChoice = new List<List<string>>
                                {
                                    new List<string>
                                    {
                                        "Harden your heart and do what must be done.",
                                        "Surely there's another way...?"
                                    },
                                    new List<string>
                                    {
                                        "Brush off their struggles and do what's for the best.",
                                        "No... this can't be right..."
                                    },
                                    new List<string>
                                    {
                                        "Expunge the pity in your heart and deliver the killing blow.",
                                        "I'm sorry... I'm so sorry... I can't..."
                                    }
                                };
                                    Dictionary<string, string> choice_customResponse = new Dictionary<string, string>
                                {
                                    {"Harden your heart and do what must be done.", $"You strike as best you can, but {ghoulString} struggles against you." },
                                    {"Brush off their struggles and do what's for the best.", $"{ghoulString} sinks to their knees, groaning pitiably." },
                                    {"Surely there's another way...?", $"You back away from {ghoulString}, sheathing your weapon. You'll try a different course of action for now..." },
                                    {"No... this can't be right...", $"You back away from {ghoulString}, appalled by your actions. Stammering a tearful apology, you resolve to try a different course of action for now..." }


                                };
                                    int whichChoice = sweetMurderousFun.LinearParle(choice_customResponse, pityMePlease, makeAToughChoice, description);
                                    if (whichChoice == -1)
                                    {
                                        Console.WriteLine("With the trapdoor beyond reach, you conclude that there is nothing you can do but turn back. \nYou return to the stairwell.");
                                        newRoom1 = stairwayToLower.CastDoor().Passage(dungeonChamber);
                                        leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                        break;
                                    }
                                    else if (whichChoice == -1000)
                                    {
                                        Console.WriteLine("The ghoul's claw strikes true, tearing into your neck and opening your jugular. You are still alive as the two ghouls feast on you.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Your adventure ends here...");
                                        return;
                                    }
                                    else if (whichChoice == 2)
                                    {
                                        if (!player1.Traits.ContainsKey("sadist"))
                                        {
                                            Console.WriteLine("You stare down in horror at what you've done, throwing your weapon away in disgust. You feel like you might be sick. \nYou resolve to make the Curse-Breaker pay for the crimes he's committed, but not this way. You'll find another path...");
                                            if (player1.WeaponInventory.Count > 0)
                                            {
                                                player1.WeaponInventory.RemoveAt(0);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("you can't do it... It's just no fun when they can't fight back");
                                        }
                                        Console.ReadKey(true);
                                        Console.WriteLine("With the trapdoor beyond reach, you conclude that there is nothing you can do but turn back. \nYou return to the stairwell.");
                                        newRoom1 = stairwayToLower.CastDoor().Passage(dungeonChamber);
                                        leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                        break;
                                    }
                                    else
                                    {
                                        if (journal.Attribute)
                                        {
                                            Console.WriteLine("You step over the former paladin, weapon raised. Before you release them from their suffering, you tell them you read their journal and express how grateful you were for their advice. Their words were a source of strength.\n\tThey gaze up at you, uncomprehending... defeated.\n Finally you close their eyes forever...");
                                            Console.ReadKey(true);

                                        }
                                        else
                                        {
                                            Console.WriteLine("You step over the ghoul and raise your weapon. You say a few prayers that the gods might deliver their soul complete and true to the afterlife, then tell them your sorry. \nThey gaze up at you, uncomprehending... defeated. \n Finally, you close their eyes forever.");
                                            Console.ReadKey(true);
                                        }
                                        if (!player1.Traits.ContainsKey("sadist"))
                                        {
                                            Console.WriteLine($"\nWith {ghoulString} sprawled dead before you. You repeat the act with the second. By the time you're done, blood grimes your sword and tears grit your eyes. You swear that so long as you live, you'll do everything in your power such that this act need never be repeated. \nSteeling yourself, your determined gaze latches upon the trapdoor...");
                                            Console.ReadKey(true);
                                        }
                                        else
                                        {
                                            Console.WriteLine("You dust your hands. \nWell, that was some good sport! What next?");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Having repeated the act with the second you're free to explore the dungeon.");
                                        }
                                        ghoul1.Stamina = 0;
                                        ghoul2.Stamina = 0;
                                        Item engagementRing = new Item("engagement ring", "The full inscription circling this gold band reads, 'My light in the darkness, my lodestone and north star, Willow'", false, "unbroken");
                                        List<Item> willowItems = new List<Item> { engagementRing };
                                        Feature deadGhoul1 = new Feature("ghoul in paladin garb", "The former prisoner's body lays dead before you. At least they've been released from the Curse-Breaker's cruelty...", true, "searched");
                                        Feature deadGhoul2 = new Feature("ghoul engaged to Willow", "The former prisoner's body lays dead before you. At least their suffering has come to an end...", true, "searched", willowItems);
                                        dungeonChamber.FeatureList.Add(deadGhoul1);
                                        dungeonChamber.FeatureList.Add(deadGhoul2);
                                    }
                                }
                                else
                                {
                                    string ghoulString = "the pitiable ghoul";
                                    if (journal.Attribute && bookEC3.Attribute)
                                    {
                                        ghoulString = $"Willow's soulmate";
                                    }
                                    Dialogue sweetMurderousFun = new Dialogue(player1, ghoul2);
                                    string description = $"You take a moment to steel yourself. You take a deep breath. Then you draw your weapon and step towards the {ghoul2.Name}.";
                                    List<string> pityMePlease = new List<string>
                                {
                                    $"You see your reflection in the glassy eyes of {ghoulString} as you make your solemn approach, footsteps clapping resolutely upon the cold granite floor. Something behind those eyes gazes back at you, pleading you. But whether it's for mercy or for the release of death, you cannot say...",
                                    $" They seem to not know themselves as they claw frenziedly at you...",
                                    $" They still claw at you in pained and sluggish swings, but their efforts are more than feeble. They slowly turn their gaze up at you, a rueful hopelessness lurking somewhere behind its misted and glittering eyes..."
                                };
                                    List<List<string>> makeAToughChoice = new List<List<string>>
                                {
                                    new List<string>
                                    {
                                        "Harden your heart and do what must be done.",
                                        "Surely there's another way...?"
                                    },
                                    new List<string>
                                    {
                                        "Brush off their struggles and do what's for the best.",
                                        "No... this can't be right..."
                                    },
                                    new List<string>
                                    {
                                        "Expunge the pity in your heart and deliver the killing blow.",
                                        "I'm sorry... I'm so sorry... I can't..."
                                    }
                                };
                                    Dictionary<string, string> choice_customResponse = new Dictionary<string, string>
                                {
                                    {"Harden your heart and do what must be done.", $"You strike as best you can, but the {ghoul2.Name} struggles against you." },
                                    {"Brush off their struggles and do what's for the best.", $"The {ghoul2.Name} sinks to their knees, groaning pitiably." },
                                    {"Surely there's another way...?", $"You back away from {ghoulString}, sheathing your weapon. You'll try a different course of action for now..." },
                                    {"No... this can't be right...", $"You back away from {ghoulString}, appalled by your actions. Stammering a tearful apology, you resolve to try a different course of action for now..." }


                                };
                                    int whichChoice = sweetMurderousFun.LinearParle(choice_customResponse, pityMePlease, makeAToughChoice, description);
                                    if (whichChoice == -1)
                                    {
                                        Console.WriteLine("With the trapdoor beyond reach, you conclude that there is nothing you can do but turn back. \nYou return to the stairwell.");
                                        newRoom1 = stairwayToLower.CastDoor().Passage(dungeonChamber);
                                        leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                        break;
                                    }
                                    else if (whichChoice == -1000)
                                    {
                                        Console.WriteLine("The ghoul's claw strikes true, tearing into your neck and opening your jugular. You are still alive as the two ghouls feast on you.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("Your adventure ends here...");
                                        return;
                                    }
                                    else if (whichChoice == 2)
                                    {
                                        if (!player1.Traits.ContainsKey("sadist"))
                                        {
                                            Console.WriteLine("You stare down in horror at what you've done, throwing your weapon away in disgust. You feel like you might be sick. \nYou resolve to make the Curse-Breaker pay for the crimes he's committed, but not this way. You'll find another path...");
                                            if (player1.WeaponInventory.Count > 0)
                                            {
                                                player1.WeaponInventory.RemoveAt(0);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("you can't do it... It's just no fun when they can't fight back");
                                        }
                                        Console.ReadKey(true);
                                        Console.WriteLine("With the trapdoor beyond reach, you conclude that there is nothing you can do but turn back. \nYou return to the stairwell.");
                                        newRoom1 = stairwayToLower.CastDoor().Passage(dungeonChamber);
                                        leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                        break;
                                    }
                                    else
                                    {
                                        if (bookEC3.Attribute)
                                        {
                                            Console.WriteLine("You step over Willow's lover, weapon raised. Before you release them from their suffering, you tell them you found their letter and that once this is over you'll find her and pass on your words. She and their child will want for nothing, you promise.\n\tThey gaze up at you, uncomprehending... defeated.\n Finally you close their eyes forever...");
                                            Console.ReadKey(true);

                                        }
                                        else
                                        {
                                            Console.WriteLine("You step over the ghoul and raise your weapon. You say a few prayers that the gods might deliver their soul complete and true to the afterlife, then tell them your sorry. \nThey gaze up at you, uncomprehending... defeated. \n Finally, you close their eyes forever.");
                                            Console.ReadKey(true);
                                        }
                                        if (!player1.Traits.ContainsKey("sadist"))
                                        {
                                            Console.WriteLine($"\nWith {ghoulString} sprawled dead before you. You repeat the act with the second. By the time you're done, blood grimes your sword and tears grit your eyes. You swear that so long as you live, you'll do everything in your power such that this act need never be repeated. \nSteeling yourself, your determined gaze latches upon the trapdoor...");
                                            Console.ReadKey(true);
                                        }
                                        else
                                        {
                                            Console.WriteLine("You dust your hands. \nWell, that was some good sport! What next?");
                                            Console.ReadKey(true);
                                            Console.WriteLine("Having repeated the act with the second you're free to explore the dungeon.");
                                        }
                                        ghoul1.Stamina = 0;
                                        ghoul2.Stamina = 0;
                                        Item engagementRing = new Item("engagement ring", "The full inscription circling this gold band reads, 'My light in the darkness, my lodestone and north star, Willow'", false, "unbroken");
                                        List<Item> willowItems = new List<Item> { engagementRing};
                                        Feature deadGhoul1 = new Feature("ghoul in paladin garb", "The former prisoner's body lays dead before you. At least they've been released from the Curse-Breaker's cruelty...", true, "searched");
                                        Feature deadGhoul2 = new Feature("ghoul engaged to Willow", "The former prisoner's body lays dead before you. At least their suffering has come to an end...", true, "searched", willowItems);
                                        dungeonChamber.FeatureList.Add(deadGhoul1);
                                        dungeonChamber.FeatureList.Add(deadGhoul2);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("With the trapdoor beyond reach, you reason that there is nothing you can do but turn back. \nYou return to the stairwell.");
                                newRoom1 = stairwayToLower.CastDoor().Passage(dungeonChamber);
                                leftWhichRooms = newRoom1.WhichRoom(leftWhichRooms);
                                break;
                            }
                        }
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                    Console.WriteLine("[c] Check your character's status?");
                    Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the dungeon chamber?");
                        if (b > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
                    try
                    {
                        int reply1 = int.Parse(reply);
                        if ((b < 1 && (reply1 < 1 || reply1 > 2)) || reply1 < 1 || reply1 > 3)
                        {
                            Console.WriteLine("Please enter a number corresponding to a choice of action.");
                            continue;
                        }
                        else if (reply1 == 1)
                        {
                            player1.SearchPack(dungeonChamber.ItemList, newRoom1, threadPath, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar);
                            a++;

                        }
                        else if (reply1 == 2)
                        {
                            ///when player discards rusty chains they may appear more than once. 
                            ///fungshui() is present to preempt that and prevent duplicates.

                            Room newRoom = dungeonChamber.Investigate(music, usesDictionaryItemChar, sw, minotaurAlertedBy, justStalked, threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur, mageBattle, secretChamber, goblin, gnoll, MGItems, destinations, stairwayToLower);
                            if (newRoom.Name != dungeonChamber.Name)
                            {

                                leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                newRoom1 = newRoom;
                                continue;
                            }


                            b++;
                        }
                        else
                        {
                            List<bool> success = new List<bool>();
                            test3.RunForCombat();
                            success = player1.UseItemOutsideCombat(music, dungeonChamber, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                        }
                    }
                    catch
                    {
                        if (reply == "c")
                        {
                            player1.CheckStatus();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action...");
                        }
                    }
                    }
                while (!leftWhichRooms[24])
                {
                    Console.WriteLine("You appear within some strange two dimensional plane - a prison of some kind but not like any worldly one you've ever known. You stare out of it as you might a window, slamming your fists futilely upon it as it twirls endlessly through outer space. 'Damnit Merigold!' you yell, shaking your fist as nebulae and galaxies whisk by...");
                    Console.ReadKey(true);
                    Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                    return;
                }
                    


                }

            
            


            

            pk = Console.ReadLine();
        }
    }
}

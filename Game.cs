﻿using DungeonCrawler;
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

        public Game(string gameName)
        {
            GameName = gameName;

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
        public void Start()
        {
            //Instantiating a six sided dice to be used for dealing damage with a particular weapon. 
            // Damage works in combat by rolling dice. Each weapon has a different set of dice. Hence,
            // one might deal a different range, with different prob distribution, of damage amounts
            // depending on choice of weapon. This has been inspired by D&D and also more directly BG3.
            Dice D6 = new Dice(6);
            Dice D3 = new Dice(3);
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
            string newNote = "Someone has scrawled upon the note in hasty erratic cursive. It reads, 'I don't have long now. If you're reading this then you're likely another foolhardy adventurer like myself who got his'self kidnapped just as I woz. I don' have much space so mark my words. Whatever they tell you - its a lie. They're going to harm you. They're most likely going to kill you in one of their mad experiments. There's a music box. I kept it locked away and hidden from sight. It's in the chest. It may look empty but set in its bottom is a panel that can be removed. You'll find it there. If you play it the guard loses his marbles about it. Can't stand the tune, the little blighter! It's like nails on a chalkboard to 'em creatures. When it enters, subdue the loathsome thing. It's the only way out of 'ere. Hopefully, if I don't make it, at least someone else will...' The rest deteriorates into an illegible scribble at the bottom of the page.";
            //Items to be located somewhere in the room or upon the player character
            Item binkySkull = new Item("Binky", "~~ He's a bonafide friend in need, a bonny true soul indeed, he's brimming with revelry when you bring bonhomie, Hey! don't be a bonana, 'cause you've got a BONANZA, of a friend in me! ~~");
            Item steelKey = new Item("steel key", "You find it under the skeleton's bones. You guess whoever it was had swallowed it before death. The key itself is rather nondescript - just a humble key. You suppose it must unlock something...");
            Item healPotion = new Item("healing potion", "It has flecks of gold floating amidst a gel like suspension. The label reads; 'When you're feeling blue, down with the flu, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!'", true, "used", 0, "Stamina: When you're blue, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!");
            Item note = new Item("note", "The note is dogeared and yellowed with age.\nSomeone has scrawled upon it but the writing is too small to make out. Snatches of words, poorly spelt, unveil themselves to you when you strain your eyes. However, no coherent message can be deciphered. Something about a false bottom? If only there was some spell to enlarge letters, you muse... If only you knew any spells!", true, "unread");
            Item halfOfCrackedBowl = new Item("half a cracked bowl", "Its a cheap bowl made of clay - half of one anyway - chipped in places around the rim and bearing a hairline crack down its left side.");
            Item otherHalfOfCrackedBowl = new Item("other half of a cracked bowl", "It's not much less damaged than its counterpart");
            Item musicBox = new Item("music box", "A curious artefact with a hand-crafted ebony exterior, inlaid with gold. It has glass panels displaying well oiled brass cogs gently whirring inside.", true, "unopened", 1, "strange lullaby");
            Weapon rustyChains = new Weapon("rusty chains", "They're so caked with rust that they're links have stiffened with age. You doubt these could hold any prisoner. Perhaps that's why they weren't used on you. Handling one of them, you figure it'd make a halfway decent, impromptu weapon - if you've really no other choice.", chainDamage, defaultCritHits, defaultGoodHits);
            Item garment = new Item("garment", "Haphazardly strewn about the rickety floor of your cell, they're worn, faded and moth-eaten. Hardly a fashion accessory.", true, "unburned");
            Item elixirFeline = new Item("Elixir of Feline Guile", "It's pungent aroma makes you recoil. Upon the label it reads, 'Is 'butter-fingers' your middle name? Do you like jumping from great heights, but don't like the dying that usually follows? Merigold's Wondrous Elixir of Feline Guile is the thing for you! Please note Merigold is not responsible for fatal falls during or after this potion takes effect. Please use responsibly. Pleasant fragrance not included.'", true, "unshattered", 1, "Skill: Boosts your skill by 1 point. Caution: excessive use may cause an over-fondness for catnip.");
            Item FelixFelicis = new Item("Felix Felicis", "It bubbles, roils and froths within its bottle. You almost sense a quiver through the glass, like the crystalline liquid inside is trying to escape. The label on the side is illegible; someone has written over it with a shaky cursive, 'Don't drink it! Whatever you do, don't drink it! For the love of all that is holy, if you care for anyone around you keep the stopper on!!! ~ Yours sincerely, Merigold.'", true, "unshattered", 10, "Luck: Drink and accomplish your wildest dreams..."); // access to 'jinxed' critmisses for 1 battle only
            Item magnifyingGlass = new Item("magnifying glass", "Peering through its slightly misted lens objects appear at least three times their size. You wonder why the skeleton had hold of it...");
            Item bowlFragments = new Item("bowl fragments", "They're sharp. You best avoid stepping on them.", false, "shattered");
            Item jailorKeys = new Item("jailor keys", "Such cast iron, heavy-duty keys and the ring they're found on seem typical of any prison worthy of the name - not that you'd know, of course.");
            List<Item> cellInventory = new List<Item> { rustyChains, halfOfCrackedBowl, otherHalfOfCrackedBowl, bowlFragments, garment };
            Item bobbyPins = new Item("bobby pin", "This is one of the few bobby pins that haven't been bent out of shape through frantic heavy-handedness.", true, "unbent");

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
            Feature holeInCeiling = new Feature("hole in the ceiling", "You gaze from the heap of debris that has buried the creature alive to the hole through the ceiling above. You bet you could climb the heap and enter the room above yours.");
            Door stairwayToLower = new Door("dark stairwell", "The steep stone steps descend beyond the light of the braziers and into the unknown murk lurking below. Without some sort of light that can dispel the impenetrable darkness beneath your feet, you might want to think carefully before navigating this slippery and hazardous passage.", false, "unblocked", null, null, "Feeling a knot of dread tighten about your stomach, you make the descent into a shifting web of shadows and silhouettes...", true);
            Door stairwayToUpper = new Door("lit stairway", "The wide flight of stone steps slowly curves around, leading to somewhere unseen but well-lit.", false, "unblocked", null, null, "You embark along the stairs two at a time.");
            Door otherRosewoodDoor = new Door("near door", "Like your former cell's door, this one is composed of elegant rosewood panels that appear to indicate a misplaced opulence that should belong to settings far more salubrious than the one you find yourself in.", true, "locked", null, null, "The door creaks ominously as you furtively pace into the next room.");
            Door armouryDoor = new Door("RmorRee door", "Its a heavyset door studded with iron bolts and a thoroughly unwelcoming aspect.", false, "unlocked", null, null, "The door swings open with a heave and opens into the next room...");
            Door circleDoor = new Door("double doors", "An ornate and set of vast double doors with brass locks and filigreed handles. You reckon something as large as a troll could fit through that door...", true, "locked", null, null, "You open one of the doors open just a fraction and slip your way through...");
            Door emptyCellDoor = new Door("far door", "Like your former cell's door, this one is composed of elegant rosewood panels that appear to indicate a misplaced opulence that should belong to settings far more salubrious than the one you find yourself in. You notice the lock has scratches made from the inside. You surmise someone has attempted picking the lock, but unless they had something more than just a bobby pin, it's doubtful they succeeded.", true, "locked", null, null);
            Door magManDoor = new Door();
            Door messHallDoor = new Door();
            Door broomClosetDoor = new Door();

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
            Item throwingKnife = new Item("throwing knife", "Despite its humble appearance, it's well made, sharp, and perfectly balanced.", false, "unbroken");
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
            List<Item> corridorItems = new List<Item>();
            List<Feature> corridorFeatures = new List<Feature> { stairwayToLower, leftbrazier, rosewoodDoor, otherRosewoodDoor, rightbrazier, emptyCellDoor, anotherBrazier, stairwayToUpper };
            List<Feature> antechamberFeatures = new List<Feature> { stairwayToUpper, pillar, plaque, armouryDoor, pillar, mosaic, circleDoor};
            List<Item> antechamberItems = new List<Item>();
            List<Item> emptyCellItems = new List<Item> { garment, rustyChains, bobbyPins, redThread};
            List<Feature> emptyCellFeatures = new List<Feature> { leftbrazier, emptyCellDoor, rightbrazier, otherBookcase};
            ///
            ///mess hall features and items
            Item messhallBook1 = new Item("book on thievery", "A rather handy guide to the illicit - *ahem*, excuse me - to the skilled art of pickpocketing, conning, disguises and lockpicking.", false, "unread");
            ///The above is for letting the player know that they can combine the bobby pin and the stiletto and that they can use the soot or warpaint to form a disguise
            ///
            ///DungeonChamber Items and features
            Item femur = new Item("femur", "Upon closer inspection you find teeth marks denting the bone's length...", false);
            Item jawBone = new Item("jaw bone", "This bone is of disquietingly human origin - and is warm...", false);
            Item legBone = new Item("leg bone", "It's been gnawed until, in some places, whittled to the very marrow...", false);
            Item rib = new Item("rib", "It's not much of a find...", false);
            Door hatch = new Door("trapdoor", "It is constructed out of dwarven steel. Your hands trace the craftsmanship. However, you notice no bolts or locks keeping it shut. It's free to open - should you choose to go down it...", false, "unlocked", null, null, "You heft the heavy trapdoor open, before it clangs to the granite floor. Before you lies a gaping hole of unfathomable depths; only darkness seems to lurk beneath your feet. The noise reverberates for a moment as a chill wind whisks up from the dank depths below. \nThere's a ladder. With trepidation gnawing at your gut, you follow it down...");
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

            ///
            /// NorthCorridor Items and Features
            Door northeastCorner = new Door("northeastern corner", "The corner turns sharply right...", false, "unblocked", null, null, "You follow the corner around and into the easternmost corridor.");
            Door northwestCorner = new Door("northwestern corner", "The corner turns sharply left...", false, "unblocked", null, null, "You follow the corner around and into the westernmost corridor.");
            List<Feature> northCorridorFeatures = new List<Feature> {northwestCorner, alcove, broomClosetDoor, magManDoor, alcove, northeastCorner };
            List<Item> northCorridorItems = new List<Item> { splinter, looseNail, penny, crumbs, dustBunny };
            ///
            /// West Corridor Items and Features
            List<Feature> westCorridorFeatures = new List<Feature> {northwestCorner, alcove, messHallDoor, alcove, southwestCorner };
            List<Item> westCorridorItems = new List<Item> { splinter, looseNail, penny, crumbs, dustBunny };

            ///
            /// East corridor
            List<Feature> eastCorridorFeatures = new List<Feature> {northeastCorner, alcove, circleDoor, alcove, southeastCorner };
            List<Item> eastCorridorItems = new List<Item> { splinter, looseNail, penny, crumbs, dustBunny };

            //Special Items
            List<Item> stickyItems = new List<Item> { bowlFragments, garment, bobbyPins, clunkySabaton, breastplate, helmet, bracers, splinter, rug, looseNail, penny, crumbs, dustBunny };
            List<Item> specialItems = new List<Item> { musicBox, binkySkull, steelKey, note, jailorKeys, lockpickingSet, bookA1 };

            ///Rooms
            Room room = new Room("dank cell", "The foreboding cell is bathed in the earthy glow of lit braziers, barely lighting cold stony walls, a heavy rosewood door studded with iron hinges, and only the sparsest of furnishings.\nThe door is set within the north wall, two flickering braziers casting orbs of low light either side of it so as to look like great fiery eyes watching you from the murk.\t\nTo the west wall there is a large chest, mingled with a cascade of rusted and disused iron shackles.\t\nTo the south wall is a small bookcase and some garments haphazardly strewn about you.\t\nTo the east wall is the last occupant; a skeleton with a permanent grin, bound fast to the wall by many interlocking heavy chains. It almost seems to watch you from dark wells where once there were its eyes. It holds something in its bony fist and something else glimmers from a place out of reach behind it.\t\t", cellInventory, cellfeatures);
            Room corridor = new Room("long corridor", "More of those strange braziers cast pools of frosty light within the dark corridor. Here and there they alleviate the murk within the passage of grim stone walls and rickety floorboards. It extends to the left into darkness and to the right towards a wide flight of stone stairs. \nTo the north you face another door similar to the ornate rosewood door behind you.\t\nTurning your gaze west down the shadowy passage you see the flickering braziers leading towards a dark stairwell, descending beyond the inky blackness to unknown depths.\t\nTurning your head south the ornate rosewood door to your own former cell meets your gaze.\t\nTo the east the passageway leads past more doors up to a flight of stairs, ascending to the next level of whatever building or (tower?) you find yourself in.\t\t", corridorItems, corridorFeatures);
            Room cellOpposite = new Room("eerie cell", "There are scratch marks on the inside of the rosewood door leading into this cell. Whoever was here was dragged out and taken Lord only knows where. \nAhead of you is a bare stone wall, a bowl left close by. A kind of nest has been formed out of the strewn garments - clearly where the last occupant had rested. They're still warm...\t\nYou find little of note save for a clumsy attempt to craft crude levers out of the wooden planks of the floor. You guess they were used to slip under the gap in the door and lever it out of its iron pin hinges. Judging by the snapped and splintered planks of wood around you, the attempt failed.\t\nTurning your gaze southwards you see the door through which you entered. Like your room there are braziers either side of it, but they've been bent out of shape, their unnatural frosty flames extinguished.\t\nLooking to the east wall you find a trunk made of coarse leather hide and a wooden frame.\t\t", cell2Inventory, cell2features);
            Room antechamber = new Room("antechamber", "The prodigious antechamber you now find yourself in is an architectural marvel of sweeping stone arches and a vaulted ceiling. For a few moments the sight of its extravagance, so vastly different from your previous surroundings, takes your breath away.\nGazing northwards you see a heavyset door studded with steel bolts, Above it a bronze plaque has been blackened as though blasted by some spell or fireball. \t\nTo the west you see the brightly illuminated stairway you just ascended.\t\nTurning your gaze to the south wall you find bare patches where once were probably opulent oil-paintings and portraits. Their absence adds to the ominous sense of some recent tragedy befalling this place.\t\nTo the east is another door leading out of the antechamber - this one a far more inviting set of oak-panelled double doors framed by fluted pillars and a grand archway enclosing some strange mosaic.\t\t", antechamberItems, antechamberFeatures);
            Room oubliette = new Room("oubliette", "~demon pit~", cellInventory, cellfeatures);
            Room emptyCell = new Room("empty cell", "Upon entering this cell you find scratch marks around the lock. The enchanted braziers cast everything in a shimmering ethereal glow, as though the light were reaching this room through some alien ocean or the underside of a glacier\nAhead of you are more garments strewn haphazardly about. Some of them have been piled against the wall, almost as though to form something to sit on.\t\nTurning your gaze left you espy more rusty chains, along with a bookcase that - like the one in your old cell - looks like its seen better days.\t\nFacing the rosewood door you came through you notice bobby pins litter the floor. They must've been something the previous occupant had brought here with them. It looks like they were used to try and unlock the door.\t\nTo the east, just peeping from under the garments, you notice a ball of red thread. It seems to have been collected by the last occupant but you've no idea what for.\t\t", emptyCellItems, emptyCellFeatures);
            Room armoury = new Room("armoury", "The instant you step inside you are greeted with a startled gnoll and goblin. Coins clatter to the table they're gathered around as they stare at you, surrounded by weapon racks and other decidedly sharp furnishings. Your presence has caused them to pause their boisterous clamouring mid-game of coins... It seems you've intruded upon a private party. Their stunned silence has yet to change into hostility, but it won't be long before it does...\nThe high walls of the 'RmorRee' extend to a vaulted ceiling and appear to have been stripped of many ladders and shelves judging by the bare patches and splintered wood panels left behind. The north wall in particular is one of the few that betrays what this room might've been before its spartan refurbishment; a rosewood bookcase, replete with tomes, greets your gaze directly ahead.\t\nThe west wall to your left is where the table is situated where the gnoll and goblin played their game of coins.\t\nFacing south you find the door you just passed through.\t\nTo your right, gazing east, you see racks fully stocked with weapons and armour.\t\t", armouryItems, armouryFeatures);
            Room messHall = new Room("mess hall", "~mess hall~", cell2Inventory, cell2features);
            Room circularLanding = new Room("circular landing", "~minor tour antics~", cell2Inventory, cell2features);
            Room magicalManufactory = new Room("magical manufactory", "~Merigold the Marvellous~", cell2Inventory, cell2features);
            Room broomCloset = new Room("broom closet", "~brooms, mops, dusters and other exciting things~", cell2Inventory, cell2features);
            Room highestParapet = new Room("highest parapet", "~final boss fight~", cell2Inventory, cell2features);
            Room hugeBarracks = new Room("huge barracks", "~bleh!~", cell2Inventory, cell2features);
            Room desertIsland = new Room("desert island", "~make friends with a coconut named 'Wilson'~", cell2Inventory, cell2features);
            Room bankVault = new Room("bank vault", "~you die the richest man in the world~", cell2Inventory, cell2features);
            Room dragonLair = new Room("dragon's lair", "~golden dragon burned to crisp or answer riddle to return~", cell2Inventory, cell2features);
            Room secretChamber = new Room("secret chamber", "~prometheus statue, Azazel, Topics Infernal, mosaic asking for love, jars of gory hag-related items, 4th wall, adore, cherish, admire, etc~", cell2Inventory, cell2features);
            Room prehistoricJungle = new Room("prehistoric jungle", "~dinosaurs chase you~", cell2Inventory, cell2features);
            Room astralPlanes = new Room("astral planes", "~zero g!~", cell2Inventory, cell2features);
            Room oceanBottom = new Room("ocean bottom", "~under da sea!~", cell2Inventory, cell2features );
            Room dungeonChamber = new Room("dungeon chamber", "The light of a single brazier casts an eerie glow over this claustrophobic, airless dungeon and its damp stone walls. Like the faint light reaching the fathomless depths of an ocean floor, it swims over scattered bones and barely illuminates twin hulking silhouettes lurking within shadow just beyond a solitary hatch leading somewhere deeper still. You feel the hairs on the back of your neck stand on end, as from somewhere within those shadows, chains clink and scrape along the granite floor...\nTurning your gaze right to look north you see the granite wall curve away from you and into blackness. It is studded with bolts that hold chains in place, most of which dangle limply to the stone floor below.\t\nDirectly ahead, some distance before the wall of darkness, lies a heavy trapdoor, presumably leading to an oubliette below. Scattered about it are assorted bones...\t\nTurning your gaze south and to the left you see a lone brazier, its lone orb of flickering frosty light the only thing alleviating the dank darkness besieging you.\t\nLooking back there is only the passageway you just descended...\t\t", dungeonItems, dungeonFeatures);
            
            Room westernmostCorridor = new Room("westernmost corridor", "You enter upon the westernmost corridor of the circular landing. Opposite the antechamber through the double doors is a bare rosewood panelled wall. The corridor leads north where it turns sharply right, or you can follow it south where it veers left at another corner. Guiding both paths are rows of lanterns, casting a febrile glow...\nTo the north you see the rosewood panelled corridor end at a corner leading right.\t\nTo the west you face a pair of double doors.\t\nTurning your gaze southward the corridor ends at a corner that veers left.\t\nFacing east you find nothing of note save a blank wall bereft of portraits and the litter left behind by those who looted them.\t\t", westCorridorItems, westCorridorFeatures);
            Room northernmostCorridor = new Room("north-facing corridor", "You enter upon the north-facing corridor of the circular landing. Before you, within the glow of the dim lanterns, are two rosewood doors opposite one another. The one in the north wall and another in the south wall leading within the room you must have been circling. The corridor leads east whereupon it turns sharply right, or you can follow it west where it veers left at another corner...\nTo the north, in the centre of the hallway, you espy a rosewood door identical to the one in the south wall that it stands across from.\t\nTo the west the corridor ends at a corner that turns sharply left.\t\nTurning your gaze southward you espy a rosewood door, identical to the one in the north wall, and standing across from it.\t\nLooking to the east you see the corridor end at a corner that veers right.\t\t", northCorridorItems, northCorridorFeatures);
            Room easternmostCorridor = new Room("easternmost corridor", "You enter upon the easternmost corridor of the circular landing. A bare rosewood panelled wall spans the western side while a door greets your sight some way down the eastern side of the passage. The corridor leads north where it turns sharply left, or you can follow it south where it veers right at another corner. Guiding both paths are more lanterns, throwing shadows along the walls with their dim, flickering light...\nsurveying the northern end of the hallway you see a corner that turns left.\t\nTo the west there is only bare wall and the marks left by marauders who looted the paintings.\t\nTurning your gaze south you see a corner. It turns right.\t\nTo the east is a rosewood door. There is no plaque or label to indicate where it leads...\t\t", eastCorridorItems, eastCorridorFeatures);
            Room southernmostCorridor = new Room("south-facing corridor", "You enter upon the south-facing corridor of the circular landing. There is a window in the south-facing wall some way down the passage. The corridor leads east where it turns sharply left or you can follow it west where it veers right at another corner. The lanterns within their alcoves are pockets of warm light, trailing the way down either passage. There are no doors here...\nTo the north you see only bare wall illuminated by the lanterns trailing its length.\t\nTurning your gaze to the west you see the corridor end at a corner turning right.\t\nLooking a the south wall, you see its much the same as the north wall, except for a floor-to-ceiling length Palladian window through which moonbeams filter through the partially drawn diaphanous curtains.\t\nGazing eastward you see the corridor end at a shadowy corner. It turns left.\t\t", southCorridorItems, southCorridorFeatures);

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
            Test test1 = new Test(room);
            test1.RunForRoom();

            List<Room> threadPath = new List<Room>();
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
                Dice D6 = new Dice(6);
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
                string strand = "";
                if (!oops)
                {
                    strand = "to decide!";
                }
                else
                {
                    strand = "left...";
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
                        if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, oldRoom, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                        if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, minotaur.Location, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, true, player1.Masked))
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
                                oldRoom.ItemList.Remove(redThread);
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
                                oldRoom.ItemList.Remove(redThread);
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
                                    oldRoom.ItemList.Remove(redThread);
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
                                        minotaur.Suspicious = true;
                                        return minotaurStalks(newRoom1, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You hear the monster growl before the double doors close shut and are once again locked. The beast heads back the way it came...");
                                        Console.ReadKey(true);
                                        circleDoor.Attribute = true;
                                        circleDoor.SpecificAttribute = "locked";
                                        return newRoom1;
                                    }
                                }
                                else
                                {
                                    
                                    Console.WriteLine("Back pressed against the wall by the corner you hear the beast's heavy breathing and grunts as it scours the corridor you just left. You can almost feel its eyes linger on the corner you just turned. As it stalks a pace or two further forward, your breath catches as you see its huge shadow climb the wall opposite you...");
                                    Console.ReadKey(true);
                                    Console.WriteLine("The beast heads back the way it came...");
                                    circleDoor.Attribute = true;
                                    circleDoor.SpecificAttribute = "locked";
                                    return newRoom1;
                                }
                            }
                            else
                            {
                                
                                Console.WriteLine("Back pressed against the door you realise you've left it unlocked! \nYour heart knocks against your chest as you hear the monster pass by. It pauses a moment, seemingly scanning the corridor...");
                                Console.ReadKey(true);
                                Console.WriteLine("Finally, you hear the monster's heavy footfalls as it returns from whence it came. It seems it didn't notice the door was left slightly ajar...");
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
                                if (minotaur.Rage && searching > 4)
                                {
                                    
                                    return minotaurStalks(newRoom1, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                    ///make into recursive function
                                }
                                else if (minotaur.Suspicious && searching > 6)
                                {
                                    return minotaurStalks(newRoom1, minotaur, minotaurAlertedBy, minotaurAlerted, minotaurKafuffle, usesDictionaryItemItem, usesDictionaryItemFeature, usesDictionaryItemChar, leftWhichRooms);
                                }
                                else
                                {
                                    Console.WriteLine("The beast growls as it scans for any sign of you. Finally, you hear the monster's heavy footfalls as it returns from whence it came.");
                                    minotaur.Time = (minotaur.Path.Count-1) * 20000;
                                    return newRoom1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("The monster sniffs the air, as though to catch some unfamiliar scent...");
                                Console.ReadKey(true);
                                Console.WriteLine("Finally, you hear the beast's heavy footfalls as it returns from whence it came.");
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
            Item belt = new Item("belt", "It's been made with corinthian leather. It seems altogether too affluent an effect to find upon these mercenaries. You find the letters M and G fashioned upon the gold buckle.");
            Item diadem = new Item("fancy diadem", "It's encrusted with diamonds, peppered with pearls and... hey, is that an M and G engraved on the back?");
            Item armBand = new Item("golden armband", "It's rather garish and flashy, especially with that large M and G fashioned upon it. You don't think you'll be wearing it anytime soon, even if it is solid gold...");
            
            // player1.WeaponInventory.Add(breadKnife);
            // player1.Inventory.Add(healPotion);
            player1.Inventory.Add(FelixFelicis);
            player1.Inventory.Add(elixirFeline);

            ///Instantiating monsters to be fought later
            List<Item> goblinInventory = new List<Item> { scimitar };
            List<Item> gnollInventory = new List<Item> { dagger };
            Item bracelet = new Item("Bracelet embossed MG", "It's a curious item to find, especially in such a place as this. It seems to shimmer with an energy beyond your understanding or ability to unlock.", false);
            Item mercInsignia = new Item("insignia", "The insignia depicts a serpent with feathered wings. In the form of a broach it might look rather fetching on you...");
            List<Item> minotaurInventory = new List<Item> { vanquisher, armBand, belt, diadem };
            List<Room> minotaurPath = new List<Room> { northernmostCorridor};
            Stopwatch minotaurTimer = new Stopwatch();
            Monster minotaur = new Monster("minotaur", "towering above you at eight feet, the minotaur levels its horns towards you, tenses its powerful muscles, and charges!", minotaurInventory, 120, 10, vanquisher, northernmostCorridor, minotaurPath, false, false, minotaurTimer);
            Monster goblin = new Monster("goblin", "The goblin's swarthy, pock-marked skin does little to lessen the effect of its ugly snarl.", goblinInventory, 50, 2, scimitar);
            Monster ghoul2 = new Monster("ghoul engaged to Willow", "", gnollInventory, 1, 1, bite);
            Monster ghoul1 = new Monster("ghoul with paladin garb", "", gnollInventory, 1, 1, bite);
            goblin.Items.Add(bracelet);
            goblin.Items.Add(mercInsignia);
            goblin.Items.Add(jailorKeys);
            Monster gnoll = new Monster("gnoll", "The ravenous gnoll stares at you with hungry eyes. It seeks to feast, and you would make an excellent appetiser...", gnollInventory, 50, 4, bite);
            ///Instantiating battles to be used later.
            Combat trialBattle = new Combat(goblin, player1);
            Combat toughestBattle = new Combat(minotaur, player1);
            Combat tougherBattle = new Combat(gnoll, player1);
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

            Dictionary<Item, List<Player>> usesDictionaryItemChar = new Dictionary<Item, List<Player>> { [healPotion] = new List<Player> { player1 }, [FelixFelicis] = new List<Player> { player1 }, [elixirFeline] = new List<Player> { player1 }, [soot] = new List<Player> { player1} };
            List<Feature> features = new List<Feature>();
            /*
            Combat tester = new Combat(goblin, gnoll, player1, null);
            tester.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, true, holeInCeiling, false, false);
            */
            Item merigoldBroach = new Item("broach embossed MG", "There's a shimmer to it that draws the eye, but the moment your gaze focuses on it the shimmer is gone and you are left looking at an altogether unprepossessing broach.");
            Item merigoldMedallion = new Item("medallion embossed MG", "The medallion catches the light as you examine itt. It looks utterly worthless to your untrained eyes.");
            List<Item> goblin2Inventory = new List<Item> { breadKnife, merigoldBroach};
            gnollInventory.Add(merigoldMedallion);
            
            Monster goblinCaptain = new Monster("goblin", "The goblin's swarthy, pock-marked skin does little to lessen the effect of its ugly snarl.", goblin2Inventory, 60, 0, breadKnife);
            Combat dualDuel = new Combat(goblinCaptain, gnoll, player1);
            Combat minotaurKafuffle = new Combat(minotaur, player1);


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
            while (!escapedRoom1)
            {
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
                        player1.SearchPack(room.ItemList, room, threadPath);
                        a++;
                    }
                    else if (reply1 == 2)
                    {
                        ///when player discards rusty chains they may appear more than once. 
                        ///fungshui() is present to preempt that and prevent duplicates.

                        room.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                        b++;
                    }
                    else if (reply1 == 3)
                    {
                        c++;
                        
                        
                        if (c == 1 && player1.Traits.ContainsKey("friends with fairies") && !player1.Traits.ContainsKey("thespian"))
                        {
                            Console.WriteLine("You march up to the door, put on your serious face, and set about yelling for succour. You bang on the door. You bang so hard you think eventually you might just bang your way through it. Then your jailor would be mourning the loss of this rosewood door... \nPfft... mourning...<titter>...wood. You roll on the floor in a fit of giggles. Your fairy friends nod their heads with approval.\n");
                            Console.WriteLine("You waste precious minutes!");
                            e++;

                        }
                        else if (player1.Traits.ContainsKey("friends with fairies") && !player1.Traits.ContainsKey("thespian"))
                        {
                            Console.WriteLine("You almost can't look at the door without a ripple of mirth shuddering through you. No... you must focus! You tug your own face into a grumpy frown, fighting the laughter.");
                        }
                        if (c == 1)
                        {
                            Console.WriteLine($"Somewhere not too far from beyond the confines of the {room.Name} a bestial guffaw can be heard. It seems whoever, or whatever, guards your cell cares little for your predicament.");
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
                        
                        success = player1.UseItemOutsideCombat(room, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
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
                                if (trialBattle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false))
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
                                if (trialBattle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems))
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
                                            }
                                        }
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
                return;
            }
            else if (escapedThroughDoor)
            {
                if (!rosewoodDoor.Description.Contains("dent")) 
                {
                    rosewoodDoor.Description += " You notice a dent on the other side of the door.";
                }
                rosewoodDoor.SpecificAttribute = "unlocked";
                rosewoodDoor.Attribute = false;
                int fireProgress = 0;
                if (fieryEscape)
                {
                    Console.WriteLine("Looking back, the door will only hold for so long against the flames and time is not your friend. What will you do?");
                    corridor.FeatureList[2].Description = "The smouldering rosewood door radiates intense heat as a fiery glow ominously flickers through the gap underneath. Tendrils of smoke cascade upwards and the cast iron hinges are scolding to the touch.\nYou best get away from here post haste!";                    
                    corridor.FeatureList[2].CastDoor().Portal = null;
                    fireProgress = 1;
                    Console.ReadKey(true);
                    player1.FieryEscape = true;
                    
                }
                else
                {
                    Console.WriteLine("With the way ahead clear, what will you do?");                    
                    Console.ReadKey(true);
                    
                }
                
                
                int FireProgress(int fireProgress, Player player1, Room corridor) // returns (still alive?)
                {
                    if (fireProgress > 0) 
                    {
                        fireProgress++;
                    }
                    else
                    {
                        return fireProgress;
                    }
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
                            
                            foreach (Item item in corridor.ItemList)
                            {
                                item.Name = fireWords[D6.Roll(D6) - 1] + " " + item.Name;
                            }
                            corridor.FeatureList.RemoveRange(0, 7);
                            
                            return 500;                        
                        default:
                            Console.WriteLine("You collapse amidst a swirl of smoke. Your body is consumed by the inferno you started.");
                            Console.ReadKey(true);
                            Console.WriteLine("Your adventure ends here...");
                            return 1000;
                    }
                }
                List<bool> leftWhichRooms = new List<bool> {true, false, true, true, true, true, 
                true, true, true, true, true, true, true, true, true, true, true, true, true, true, 
                true, true, true, true};
                Room newRoom1 = corridor;
                bool victorious = false;
                bool visitedRoom = true;
                bool visitedArmouryBefore = false;
                long minotaurAlerted = 0;
                int b1 = 0;
                Stopwatch fireClock = new Stopwatch();
                fireClock.Start();
                long fireTimeLapsed = 0;
                bool visitedCorridor = false;
                while (!victorious)
                {
                    
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }

                    b = 0;
                    a = 0;
                    if(!leftWhichRooms[1] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[1])//corridor
                    {
                        if (discovery)
                        {
                            Console.WriteLine("Upon returning to the corridor you hastily open your pack to see what the mystery item you discovered is. To your surprise you found a pocket watch! {pocketWatch.Description}.\nYou stash it back in your backpack for safekeeping.");
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
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item>{ bobbyPins});
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto});
                        if (!usesDictionaryItemFeature.ContainsKey(jailorKeys))
                        {
                            
                            usesDictionaryItemFeature.Add(jailorKeys, new List<Feature> { emptyCellDoor, otherRosewoodDoor });
                        }
                        if (!usesDictionaryItemFeature.ContainsKey(lockpickingSet))
                        {
                            usesDictionaryItemFeature.Add(lockpickingSet, new List<Feature> { emptyCellDoor, otherRosewoodDoor, circleDoor, goodWeaponRack, magManDoor });
                        }
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a==0 && b1 == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
                        Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the corridor?");
                        if (b1 > 0)
                        {
                            Console.WriteLine("[3] Use one of your items on something?");
                        }
                        string reply = Console.ReadLine().ToLower().Trim();
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
                                player1.SearchPack(corridor.ItemList, newRoom1, threadPath);
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

                                Room newRoom = corridor.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b1, player1, yourRustyChains, stickyItems);
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
                                
                                success = player1.UseItemOutsideCombat(corridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                fireProgress = FireProgress(fireProgress, player1, corridor);
                                if (fireProgress > 999)
                                {
                                    return;
                                }
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                    b = 0;
                    a = 0;
                    if (!leftWhichRooms[0] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("The red thread unspools, trailing behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[0]) // your cell
                    {
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                        if (!usesDictionaryItemFeature.ContainsKey(lockpickingSet))
                        {
                            usesDictionaryItemFeature.Add(lockpickingSet, new List<Feature> { emptyCellDoor, otherRosewoodDoor, circleDoor, goodWeaponRack, magManDoor });
                        }
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(room.ItemList, newRoom1, threadPath);
                                a++;
                                
                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = room.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                
                                success = player1.UseItemOutsideCombat(room, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
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
                        if (!usesDictionaryItemFeature.ContainsKey(lockpickingSet))
                        {
                            usesDictionaryItemFeature.Add(lockpickingSet, new List<Feature> { emptyCellDoor, otherRosewoodDoor, circleDoor, goodWeaponRack, magManDoor });
                        }
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(oubliette.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = oubliette.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                
                                success = player1.UseItemOutsideCombat(oubliette, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (!leftWhichRooms[3] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You track your path with the red thread...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[3])//antechamber
                    {
                        string deleteString = "For a few moments the sight of its extravagance, so vastly different from your previous surroundings, takes your breath away.";
                        if (antechamber.Description.Contains(deleteString))
                        {
                            newRoom1.Description.Remove(newRoom1.Description.IndexOf(".") + 1, deleteString.Length);
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
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        if (!usesDictionaryItemFeature.ContainsKey(circleDoorKey))
                        {
                            usesDictionaryItemFeature.Add(circleDoorKey, new List<Feature> { circleDoor });
                        }
                        
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(antechamber.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = antechamber.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems, specialItems, minotaur);
                                if (newRoom.Name != antechamber.Name)
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
                                
                                success = player1.UseItemOutsideCombat(antechamber, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
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
                        //usesDictionaryItemFeature[jailorKeys].Remove(otherRosewoodDoor);
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(cellOpposite.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = cellOpposite.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                
                                success = player1.UseItemOutsideCombat(cellOpposite, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
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
                        usesDictionaryItemFeature.Remove(yourRustyChains);
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
                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                    "Dee Hooliganz",
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                    "Dee Hooliganz",
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                    "Dee Hooliganz",
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                    "Dee Hooliganz",
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                    "Dee Hooliganz",
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                        if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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

                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, false))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                                if (dualDuel.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, armoury, player1, usesDictionaryItemChar, true, holeInCeiling, specialItems, false, true))
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
                                player1.SearchPack(armoury.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = armoury.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                
                                success = player1.UseItemOutsideCombat(armoury, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (!leftWhichRooms[6] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("The red thread trails behind you, showing where you've been...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    long minotaurAlertedBy = D6.Roll(D6) * 8000;
                    Stopwatch sw = new Stopwatch();
                    justStalked = false;
                    minotaurAlerted = 0;
                    while (!leftWhichRooms[6])//mess hall
                    {
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(messHall))
                            {
                                if (minotaur.Location == messHall)
                                {
                                    if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, messHall, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                    continue;
                                }
                            }
                            else if (minotaur.Location == messHall)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, messHall, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                player1.SearchPack(messHall.ItemList, newRoom1, threadPath);
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

                                Room newRoom = messHall.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != messHall.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(messHall, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch { 
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
                    if (!leftWhichRooms[7] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    justStalked = false;
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
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        
                        
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            
                            if (!minotaur.MinotaurReturning(westernmostCorridor))
                            {
                                if (minotaur.Location == westernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, westernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                    continue;
                                }
                            }
                            else if (minotaur.Location == westernmostCorridor)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, westernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                player1.SearchPack(westernmostCorridor.ItemList, newRoom1, threadPath);
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

                                Room newRoom = westernmostCorridor.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != westernmostCorridor.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                
                                success = player1.UseItemOutsideCombat(westernmostCorridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch { 
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
                    if (!leftWhichRooms[21] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("The red thread unravels and marks your trail behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    minotaurAlerted = 0;
                    justStalked = false;
                    sw = new Stopwatch();
                    while (!leftWhichRooms[21])//north-facing corridor
                    {
                        visitedRoom = true;
                        northwestCorner.Description = "The corner turns sharply left...";
                        northwestCorner.Passing = "You follow the corner around and into the westernmost corridor.";
                        northeastCorner.Description = "The corner turns sharply right...";
                        northeastCorner.Passing = "You follow the corner around and into the easternmost corridor.";
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(northernmostCorridor))
                            {
                                if (minotaur.Location == northernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, northernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                    continue;
                                }
                            }
                            else if (minotaur.Location == northernmostCorridor)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, northernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                player1.SearchPack(northernmostCorridor.ItemList, newRoom1, threadPath);
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

                                Room newRoom = northernmostCorridor.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != northernmostCorridor.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                test3.RunForCombat();
                                success = player1.UseItemOutsideCombat(northernmostCorridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch { 
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
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    sw = new Stopwatch();
                    justStalked = false;
                    minotaurAlerted = 0;
                    while (!leftWhichRooms[22])//easternmost corridor
                    {
                        visitedRoom = true;
                        northeastCorner.Description = "The corner turns sharply left...";
                        northeastCorner.Passing = "You follow the corner around and into the north-facing corridor.";
                        southeastCorner.Description = "The corner turns sharply right...";
                        southeastCorner.Passing = "You follow the corner around and into the south-facing corridor.";
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(easternmostCorridor))
                            {
                                if (minotaur.Location == easternmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, easternmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                    continue;
                                }
                            }
                            else if (minotaur.Location == easternmostCorridor)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, easternmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                player1.SearchPack(easternmostCorridor.ItemList, newRoom1, threadPath);
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

                                Room newRoom = easternmostCorridor.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != easternmostCorridor.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                test3.RunForCombat();
                                success = player1.UseItemOutsideCombat(easternmostCorridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch { 
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
                    minotaurAlertedBy = D6.Roll(D6) * 8000;
                    sw = new Stopwatch();
                    justStalked = false;
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
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        sw.Stop();
                        minotaurAlerted = sw.ElapsedMilliseconds;
                        sw.Start();
                        if (minotaur.Stamina > 0)
                        {
                            if (!minotaur.MinotaurReturning(southernmostCorridor))
                            {
                                if (minotaur.Location == southernmostCorridor)
                                {
                                    if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, southernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                    continue;
                                }
                            }
                            else if (minotaur.Location == southernmostCorridor)
                            {
                                Console.WriteLine("The hulking monster at last locks eyes with you!");
                                Console.ReadKey(true);
                                Console.WriteLine("With a icy jolt of dread you brace yourself for battle...");
                                Console.ReadKey(true);
                                if (minotaurKafuffle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, southernmostCorridor, player1, usesDictionaryItemChar, holeInCeiling, specialItems, false, false, player1.Masked))
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
                                player1.SearchPack(southernmostCorridor.ItemList, newRoom1, threadPath);
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

                                Room newRoom = southernmostCorridor.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != southernmostCorridor.Name)
                                {

                                    leftWhichRooms = newRoom.WhichRoom(leftWhichRooms);
                                    newRoom1 = newRoom;
                                    continue;
                                }
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;

                                b++;
                            }
                            else
                            {
                                List<bool> success = new List<bool>();
                                success = player1.UseItemOutsideCombat(southernmostCorridor, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                                minotaurAlertedBy = D6.Roll(D6) * 1000;
                                sw = new Stopwatch();
                                justStalked = false;
                                minotaurAlerted = 0;
                            }
                        }
                        catch { 
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
                    while (!leftWhichRooms[8])//empty cell
                    {
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
                        //usesDictionaryItemFeature[jailorKeys].Remove(emptyCellDoor);
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(emptyCell.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = emptyCell.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                
                                success = player1.UseItemOutsideCombat(emptyCell, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    while (!leftWhichRooms[9])//magical manufactory
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
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(magicalManufactory.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = magicalManufactory.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != magicalManufactory.Name)
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
                                
                                success = player1.UseItemOutsideCombat(magicalManufactory, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
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
                        usesDictionaryItemFeature.Remove(yourRustyChains);
                        ///enter new Dictionaries for item use here
                        ///lockpick on door, jailors keys on various doors not cell doors (prisoners taken)
                        ///red herring in room above
                        ///Specific for each room, tailored.
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(broomCloset.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = broomCloset.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                
                                success = player1.UseItemOutsideCombat(broomCloset, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                                player1.SearchPack(highestParapet.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = highestParapet.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                success = player1.UseItemOutsideCombat(highestParapet, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                                player1.SearchPack(hugeBarracks.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = hugeBarracks.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != hugeBarracks.Name)
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
                                success = player1.UseItemOutsideCombat(hugeBarracks, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                                player1.SearchPack(desertIsland.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = desertIsland.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != desertIsland.Name)
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
                                
                                success = player1.UseItemOutsideCombat(desertIsland, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                                player1.SearchPack(bankVault.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = bankVault.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != bankVault.Name)
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
                                
                                success = player1.UseItemOutsideCombat(bankVault, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(dragonLair.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = dragonLair.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                success = player1.UseItemOutsideCombat(dragonLair, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (!leftWhichRooms[16] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[16])//secret chamber
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
                        if (!(a == 0 && b == 0))
                        {
                            Console.WriteLine("Now what will you do?");
                        }
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
                                player1.SearchPack(secretChamber.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = secretChamber.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != secretChamber.Name)
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
                                success = player1.UseItemOutsideCombat(secretChamber, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                        Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the corridor?");
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
                                player1.SearchPack(prehistoricJungle.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = prehistoricJungle.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != prehistoricJungle.Name)
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
                                success = player1.UseItemOutsideCombat(prehistoricJungle, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                        Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the corridor?");
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
                                player1.SearchPack(astralPlanes.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = astralPlanes.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != astralPlanes.Name)
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
                                success = player1.UseItemOutsideCombat(astralPlanes, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
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
                        Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the corridor?");
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
                                player1.SearchPack(oceanBottom.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = oceanBottom.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
                                if (newRoom.Name != oceanBottom.Name)
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
                                success = player1.UseItemOutsideCombat(oceanBottom, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    if (visitedRoom)
                    {
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        visitedRoom = false;
                    }
                    b = 0;
                    a = 0;
                    if (!leftWhichRooms[20] && redThread.SpecifyAttribute == "unspooled" && player1.Inventory.Contains(redThread))
                    {
                        Console.WriteLine("You continue unravelling the red thread behind you, leading it down the treacherous steps...");
                        Console.ReadKey(true);
                        threadPath.Insert(0, newRoom1);
                    }
                    while (!leftWhichRooms[20])//dungeon Chamber : only way in is by the stairs. can be bypassed by portal
                    {
                        bool leave = false;
                        if (stairwayToLower.Dark)
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
                        else
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
                        Console.WriteLine(newRoom1.Description.Substring(0, newRoom1.Description.IndexOf("\n")));
                        stairwayToLower.Description = "The steep stone steps ascend beyond the faint light of the lone brazier and up towards the corridor above.";
                        stairwayToLower.Passing = "Leaving this ghastly chamber behind and whatever further horrors lurk beyond the trapdoor, you ascend the steep steps...";
                        visitedRoom = true;
                        usesDictionaryItemItem.Clear();
                        usesDictionaryItemItem.Add(stiletto, new List<Item> { bobbyPins });
                        usesDictionaryItemItem.Add(bobbyPins, new List<Item> { stiletto });
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
                                player1.SearchPack(dungeonChamber.ItemList, newRoom1, threadPath);
                                a++;

                            }
                            else if (reply1 == 2)
                            {
                                ///when player discards rusty chains they may appear more than once. 
                                ///fungshui() is present to preempt that and prevent duplicates.

                                Room newRoom = dungeonChamber.Investigate(threadPath, player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains, stickyItems);
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
                                success = player1.UseItemOutsideCombat(dungeonChamber, musicBox, binkySkull, steelKey, note, jailorKeys, specialItems, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, masked, goblin, fieryEscape, trialBattle);
                            }
                        }
                        catch { Console.WriteLine("Please enter a number corresponding to your choice of action..."); }
                    }
                    


                }

            }
            


            if (trialBattle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems))
            {
                trialBattle.WonFight(room);
                if (tougherBattle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems))
                {
                    tougherBattle.WonFight(circularLanding);
                    if (toughestBattle.Fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling, specialItems)) { tougherBattle.WonFight(highestParapet); }
                }
            }

            pk = Console.ReadLine();
        }
    }
}

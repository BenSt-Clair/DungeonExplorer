using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace DungeonCrawler
{
    public class Combat
    {
        Item SpecialItem { get; set; }
        public Monster Monster { get; set; } // monster.Veapon
        public Monster Monster2 { get; set; }
        Player Player { get; set; } // playerWeapon = null; foreach (weapon x in Player.inventory){if x.Equipped{ playerWeapon = x}} if playerWeapon = null{playerWeapon = Weapon(fists, etc.)}
        public Combat(Monster monster, Player player, Item specialItem = null)
        {
            SpecialItem = specialItem;
            Monster = monster;
            Player = player;
        }
        public Combat(Monster monster, Monster monster2, Player player, Item specialItem = null)
        {
            SpecialItem = specialItem;
            Monster = monster;
            Monster2 = monster2;
            Player = player;
        }
        /// <summary>
        /// For after the player wins a fight and wishes
        /// to search the monster for treasure
        /// </summary>
        private int AdvanceForward(int progress, List<Dice> hurry)
        {
            int result = 0;
            foreach(Dice d in hurry)
            {
                Thread.Sleep(27);
                result += d.Roll(d);
            }
            if (hurry[0].faces == 11)
            {
                result += 7;
            }
            string strand = "";
            if (progress < 65)
            {
                strand = "clasp your desperate eyes on the distant portal and push yourself forward...";
            }
            else if(progress < 100)
            {
                strand = "race away from the terror at your heels...";
            }
            else if (progress < 135)
            {
                strand = "feel your muscles burn...";

            }
            else if (progress < 170)
            {
                strand = "begin to hear the roar of the portal and the raging storm beyond...";
            }
            else
            {
                strand = "are finally only seconds away from the crackling vortex!";
            }
            List<string> commentary = new List<string>
            {
                $"\nYou lunge forward {result} feet, kicking your heels as you {strand}",
                $"\nYou dart nimbly ahead by {result} feet, throwing caution to the wind as you {strand}",
                $"\nYou bound forward {result} feet, wide-eyed as you {strand}",

                $"\nYou scramble {result} feet, struggling to keep balance as you dodge the Lady of Vipers' blind attacks! You {strand}",
                $"\nYou hurl yourself forward {result} feet, struggling to catch your breath as you stumble, right yourself, and dart forward again... \n You {strand}",
                $"\nBlood pounds in your ears, as you fling one foot in front of the other for {result} feet. You {strand}",

                $"\nYou trip! You gaze in horror as the Lady of Vipers closes in...",
                $"\nYou twist your ankle! You desperately limp forward {result} feet before pushing yourself through the pain...",
                $"\nYou slow down to catch your breath. You {strand}"
            };
            int sum = 0;
            foreach(Dice d in hurry)
            {
                sum += d.faces;
            }
            
            int range = sum - hurry.Count;
            Dice D3 = new Dice(3);
            if (hurry[0].faces != 11)
            {
                if ((result - hurry.Count) > 3 * range / 5)
                {
                    Console.WriteLine(commentary[D3.Roll(D3) - 1]);
                }
                else if ((result - hurry.Count) <= 2 * range / 5)
                {
                    Console.WriteLine(commentary[D3.Roll(D3) + 5]);
                }
                else
                {
                    Console.WriteLine(commentary[D3.Roll(D3) + 2]);
                }
            }
            else
            {
                Console.WriteLine($"\nThe Lady of Vipers advances {result} feet!");
            }
            return result;
        }
        public bool Race(bool music, Item speedPotion, List<Item> throwables, Room oubliette, Dictionary<Item, List<Item>> usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, Player player, Dictionary<Item, List<Player>> usesDictionaryItemChar, Feature holeInCeiling, List<Item> specialItems, bool fire = false, bool _initiative = false, bool masked = false)
        {
            int options = 1;
            string message = "How will you proceed?";
            int trackLength = 200;
            int playerProgress = 0;
            int monsterProgress = 0;
            List<Dice> normalSpeed = new List<Dice> { };
            List<Dice> alacritySpeed = new List<Dice> { };
            List<Dice> monsterSpeed = new List<Dice> { };
            Dice D4 = new Dice(4);
            Dice D3 = new Dice(3);
            Dice D6 = new Dice(6);
            Dice D8 = new Dice(8);
            Dice D11 = new Dice(11);
            int i = 0;
            while (i < 8)
            {
                normalSpeed.Add(D4);
                i++;
            }
            i = 0;
            while (i < 14)
            {
                alacritySpeed.Add(D3); 
                i++;
            }
            i = 0;
            while (i < 5)
            {
                monsterSpeed.Add(D11);
                i++;
            }
            if(Player.Traits.ContainsKey("hale, hot and hearty"))
            {
                normalSpeed.Add(D8);
                alacritySpeed.Add(D6);
            }
            bool throwingArm = false;
            foreach(Item t in throwables)
            {
                if (Player.Inventory.Contains(t))
                {
                    throwingArm = true;
                }
            }
            if (Player.WeaponInventory.Count != 0)
            {
                throwingArm = true;
            }
            List<string> choice = new List<string> 
            { 
                "Step over to the pentagram, brace yourself and scuff the symbols with your boot...",
                "Refuse to play the creature's game...",
                "Battle the Lady of the ArchFey..."
                
            };
            if(Player.Inventory.Count != 0 && throwingArm)
            {
                choice.Add("Lob an item to disturb the markings...");
            }
            
            if (Player.Inventory.Contains(speedPotion))
            {
                choice.Add("Take a potion of alacrity before breaking the pentagram...");
            }
            foreach(string c in choice)
            {
                message += $"\n[{options}] {choice[options - 1]}";
                options++;
            }
            Console.WriteLine(message);
            Dialogue race = new Dialogue(speedPotion);
            int answer = race.getIntResponse(options);
            int index = message.IndexOf($"{answer}") + 3;
            if (message[index] == 'S')
            {
                if (Player.Speedy)
                {
                    Console.WriteLine("Test your skill...\n[Roll a D12 under or equal to your skill score]");
                    Console.ReadKey(true);
                    Dice D12 = new Dice(12);
                    int roll = D12.Roll(D12);
                    if (Player.Traits.ContainsKey("jinxed"))
                    {
                        roll /= 3;
                    }
                    Console.WriteLine($"You rolled a {roll}");
                    if(roll <= Player.Skill)
                    {
                        Console.WriteLine("The moment your foot breaks the circle of the pentagram, you flee!\n You are too fast for the Lady's surprise attack, but she only laughs ecstatically in response. Her mania, however, soon morphs into some alien species of cackle, its blood-chilling notes electrifying the very air that surges past you as you race forward. You can hear her slowly mutate into some new form...");
                        playerProgress = 7;
                    }
                    else
                    {
                        Console.WriteLine("The potion of alacrity permits you to see, in your final moments, the Eldritch Lady of the ArchFey's glamour vanish. The moment your foot scuffs the pentagram, some sort of spindly appendage flashes from nowhere, its claw slashing open your throat before a flurry of similar attacks utterly eviscerates you...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("The moment your foot scuffs the markings is the last moment of your life...");
                    Console.ReadKey(true);
                    Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                    return false;
                }
            }
            else if (message[index] == 'R')
            {
                Console.WriteLine("You scour the oubliette for some other exit, " +
                    "some other way forward - anything you might have overlooked. " +
                    "Your search becomes feverish as midnight approaches, and all " +
                    "the while the CurseBreaker's incantations build momentum towards " +
                    "some crescendo of ghastly syllables that send chills through you... ");
                Console.ReadKey(true);
                Console.WriteLine("\nFinally midnight is upon you.");
                Console.ReadKey(true);
                Console.WriteLine("Throughout the tower all the clocks chime the hour. Even from the oubliette you hear " +
                    "them. The pale ghostly light of the runes catch your final look of fright, before all the lights go out and darkness falls." +
                    " The dark Lady disappeared with them, swept into the portal that turned, for but an instant, blood moon red, before it too vanished. " +
                    "  \n  You are left alone only for a few tense moments, dreading what is to follow, before a blood-curdling howl erupts from above" +
                    " as something new and terrible is brought into the world. Soon afterwards, the tower collapses in on you... ");
                Console.ReadKey(true);
                Console.WriteLine("At least you never caught sight of the horror your lack of urgency unleashed.");
                Console.ReadKey(true);
                Console.WriteLine("Your adventure ends here...");
                return false;
            }
            else if (message[index] == 'L')
            {
                Weapon flap = new Weapon("", "", new List<Dice> { D4 }, new List<string>(), new List<string>());
                Monster backpack = new Monster("backpack", "", new List<Item>(), 1, 1, flap);
                int numOfThrowables = 0;
                Console.ReadKey(true);
                Console.WriteLine("You search through your pack for anything the right weight and size...");

                message = "";
                foreach (Item item in throwables)
                {
                    if (Player.Inventory.Contains(item))
                    {
                        numOfThrowables++;
                        backpack.Items.Add(item);
                        message += $"[{numOfThrowables}] {item.Name}\n";
                    }
                }
                foreach (Item weapon in Player.WeaponInventory)
                {
                    numOfThrowables++;
                    backpack.Items.Add(weapon);
                    message += $"[{numOfThrowables}] {weapon.Name}\n";
                    
                }

                Console.ReadKey(true);
                if (numOfThrowables != 0)
                {
                    Console.WriteLine("The following items can be thrown. Of them, which would you like to lob at the pentagram?");
                    options = 1;
                    foreach (Item item in backpack.Items)
                    {
                        Console.WriteLine($"[{options}] {item.Name}");
                        options++;
                    }
                    answer = race.getIntResponse(options);
                    Item chosenItem = backpack.Items[answer - 1];
                    if (!Player.Inventory.Remove(chosenItem)) 
                    {
                        List<Item> weapons = new List<Item> { chosenItem };
                        List<Weapon> weapons2 = weapons.Cast<Weapon>().ToList();
                        Player.WeaponInventory.Remove(weapons2[0]); 
                    }
                    if(chosenItem.Name == "crystal ball")
                    {
                        Console.WriteLine("As you take the mystical glass orb out of your pack, the creature calls to you...");
                        Console.ReadKey(true);
                        Console.WriteLine("\t'So the little fly wishes to cheat,' she tuts." +
                            "\n\t'That'll only make its fate worse than dead meat...' \nShe grins slyly as you take as many paces back towards the portal as you can while being sure to hit the pentagram. \n[You get a head start of 40 feet]");
                        Console.ReadKey(true);
                        Console.WriteLine("'Let's play, little fly...' she trills. " +
                            "\n  Finally, you brace yourself. You take in a shuddering, nervous breath. Then you fling the crystal ball. You watch it's slow arc through the chamber, before it shatters into an explosion of glass fragments and great whorls of mist. But that's not before you clasp sight of the true horror the Lady embodies...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your transfixed gaze latches with unbridled horror upon the beginning of the Lady's transformation into some new species of terror - a towering, gaunt monster with claws and unfurling chiropteric wings. They are huge and bat-like, yet they're so frayed that only the spindly but powerful fingers remain. Her laughter transfigures into a bestial hiss as the rattling, skeletal wings loom and spread above the smoke like the hood of a cobra poised to strike.");
                        Console.ReadKey(true);
                        Console.WriteLine("The blood drains from your face. Your heart knocks in double-time. You stagger backwards as the Lady's shadow looms within the swelling smoke and fills the chamber. Slowly those spindly appendages clack upon the flagstones, elevating her - not like wings carrying a devil in flight - but like legs supporting a monstrous tarantula. Seeing for the first time what you're truly up against, you turn and scramble for the portal!  ");
                        Console.ReadKey(true);
                        playerProgress = 40;
                    }
                    else if (chosenItem.Name == "lantern")
                    {
                        Console.WriteLine($"As you take the {chosenItem.Name} out of your pack, the creature calls to you...");
                        Console.ReadKey(true);
                        Console.WriteLine("\t'So the little fly wishes to cheat,' she tuts." +
                            "\n\t'That'll only make its fate worse than dead meat...' \nShe grins slyly as you take as many paces back towards the portal as you can while being sure to hit the pentagram. \n[You get a head start of 30 feet]");
                        Console.ReadKey(true);
                        Console.WriteLine("'Let's play, little fly...' she trills. " +
                            "\n  Finally, you brace yourself. You take in a shuddering, nervous breath. Then you fling the lantern overarm. You watch it's slow arc through the chamber, before it shatters into an explosion of glass fragments and a mighty plume of flame. But that's not before you clasp sight of the true horror the Lady embodies...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your transfixed gaze latches with unbridled horror upon the beginning of the Lady's transformation into some new species of terror. Caught in the glow of the roaring flames, a towering, gaunt monster with claws and unfurling chiropteric wings reveals itself. They are huge and bat-like, yet so frayed that only the spindly but powerful fingers, hooked with talons, remain. Her laughter transfigures into a bestial hiss as the rattling, skeletal wings loom and spread above the fire like the hood of a cobra poised to strike.");
                        Console.ReadKey(true);
                        Console.WriteLine("The blood drains from your face. Your heart knocks in double-time. You stagger backwards as the Lady's terrifying form looms within the swelling smoke and fills the chamber. Slowly those spindly appendages clack upon the flagstones, elevating her - not like wings carrying a devil in flight - but like legs supporting a monstrous tarantula. Seeing for the first time what you're truly up against, you turn and scramble for the portal!  ");
                        Console.ReadKey(true);
                        playerProgress = 30;
                    }
                    else if (chosenItem.Name.Contains("throwing knife"))
                    {
                        Console.WriteLine($"As you take the {chosenItem.Name} out of your pack, the creature calls to you...");
                        Console.ReadKey(true);
                        Console.WriteLine("\t'So the little fly wishes to cheat,' she tuts." +
                            "\n\t'That'll only make its fate worse than dead meat...' \nShe grins slyly as you take as many paces back towards the portal as you can while being sure to hit the pentagram. \n[You get a head start of 60 feet]");
                        Console.ReadKey(true);
                        Console.WriteLine("'Let's play, little fly...' she trills. " +
                            $"\n  Finally, you brace yourself. You take in a shuddering, nervous breath. Then you fling the {chosenItem.Name}. You watch it's slow arc through the chamber, before it strikes true, sending all the runes to flicker in the darkness; a flurry of sporadic flashes that jolt the web of shadows around you into a frenzied quiver. But that's not before you clasp sight of the true horror the Lady embodies...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your transfixed gaze latches with unbridled horror upon the beginning of the Lady's transformation into some new species of terror. Caught in sporadic snapshots as the runes' glow sputters and flashes like lightning, a towering, gaunt monster with vicious claws and slowly unfurling chiropteric wings reveals itself. They are huge and bat-like, yet so frayed that only the spindly but powerful fingers, hooked with talons, remain. Her laughter transfigures into a bestial hiss as the rattling, skeletal wings loom and spread like the hood of a cobra poised to strike.");
                        Console.ReadKey(true);
                        Console.WriteLine("The blood drains from your face. Your heart knocks in double-time. You stagger backwards as the Lady's terrifying form looms more and more with each jerky snapshot of light, filling the dark chamber. You hear the spindly appendages clack upon the flagstones. They elevate her - not like wings carrying a devil in flight - but like legs supporting a monstrous tarantula. \n\nSeeing for the first time what you're truly up against, you turn and scramble for the portal!  ");
                        Console.ReadKey(true);
                        playerProgress = 60;
                    }
                    else if (chosenItem is Weapon)
                    {
                        Console.WriteLine($"As you take the {chosenItem.Name} out of your pack, the creature calls to you...");
                        Console.ReadKey(true);
                        Console.WriteLine("\t'So the little fly wishes to cheat,' she tuts." +
                            "\n\t'That'll only make its fate worse than dead meat...' \nShe grins slyly as you take as many paces back towards the portal as you can while being sure to hit the pentagram. \n[You get a head start of 30 feet]");
                        Console.ReadKey(true);
                        Console.WriteLine("'Let's play, little fly...' she trills. " +
                            $"\n  Finally, you brace yourself. You take in a shuddering, nervous breath. Then you fling the {chosenItem.Name}. You watch it's slow arc through the chamber, before it strikes true. All the runes suddenly flicker in the darkness; a flurry of sporadic flashes that jolt the web of shadows around you into a frenzied quiver. But that's not before you clasp sight of the true horror the Lady embodies...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your transfixed gaze latches with unbridled horror upon the beginning of the Lady's transformation into some new species of terror. Caught in sporadic snapshots as the runes' glow sputters and flashes like lightning, a towering, gaunt monster with vicious claws and slowly unfurling chiropteric wings reveals itself. They are huge and bat-like, yet so frayed that only the spindly but powerful fingers, hooked with talons, remain. Her laughter transfigures into a bestial hiss as the rattling, skeletal wings loom and spread like the hood of a cobra poised to strike.");
                        Console.ReadKey(true);
                        Console.WriteLine("The blood drains from your face. Your heart knocks in double-time. You stagger backwards as the Lady's terrifying form looms more and more with each jerky snapshot of light, filling the dark chamber. You hear the spindly appendages clack upon the flagstones. They elevate her - not like wings carrying a devil in flight - but like legs supporting a monstrous tarantula. \n\nSeeing for the first time what you're truly up against, you turn and scramble for the portal!  ");
                        Console.ReadKey(true);
                        playerProgress = 30;
                    }
                    else
                    {
                        Console.WriteLine($"As you take the {chosenItem.Name} out of your pack, the creature calls to you...");
                        Console.ReadKey(true);
                        Console.WriteLine("\t'So the little fly wishes to cheat,' she tuts." +
                            "\n\t'That'll only make its fate worse than dead meat...' \nShe grins slyly as you take as many paces back towards the portal as you can while being sure to hit the pentagram. \n[You get a head start of 20 feet]");
                        Console.ReadKey(true);
                        Console.WriteLine("'Let's play, little fly...' she trills. " +
                            $"\n  Finally, you brace yourself. You take in a shuddering, nervous breath. Then you fling the {chosenItem.Name}. You watch it's slow arc through the chamber, before it strikes true. All the runes suddenly flicker in the darkness; a flurry of sporadic flashes that jolt the web of shadows around you into a frenzied quiver. But that's not before you clasp sight of the true horror the Lady embodies...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your transfixed gaze latches with unbridled horror upon the beginning of the Lady's transformation into some new species of terror. Caught in sporadic snapshots as the runes' glow sputters and flashes like lightning, a towering, gaunt monster with vicious claws and slowly unfurling chiropteric wings reveals itself. They are huge and bat-like, yet so frayed that only the spindly but powerful fingers, hooked with talons, remain. Her laughter transfigures into a bestial hiss as the rattling, skeletal wings loom and spread like the hood of a cobra poised to strike.");
                        Console.ReadKey(true);
                        Console.WriteLine("The blood drains from your face. Your heart knocks in double-time. You stagger backwards as the Lady's terrifying form looms more and more with each jerky snapshot of light, filling the dark chamber. You hear the spindly appendages clack upon the flagstones. They elevate her - not like wings carrying a devil in flight - but like legs supporting a monstrous tarantula. \n\nSeeing for the first time what you're truly up against, you turn and scramble for the portal!  ");
                        Console.ReadKey(true);
                        playerProgress = 20;
                    }

                }
                else
                {
                    Console.WriteLine("You have nothing here that you can throw! \n\nWill you scuff the pentagram with your foot instead?");
                    if (race.getYesNoResponse())
                    {
                        if (Player.Speedy)
                        {
                            Console.WriteLine("Test your skill...\n[Roll a D12 under or equal to your skill score]");
                            Console.ReadKey(true);
                            Dice D12 = new Dice(12);
                            int roll = D12.Roll(D12);
                            if (Player.Traits.ContainsKey("jinxed"))
                            {
                                roll /= 3;
                            }
                            Console.WriteLine($"You rolled a {roll}");
                            if (roll <= Player.Skill)
                            {
                                Console.WriteLine("The moment your foot breaks the circle of the pentagram, you flee!\n You are too fast for the Lady's surprise attack, but she only laughs ecstatically in response. Her mania, however, soon morphs into some alien species of cackle, its blood-chilling notes electrifying the very air that surges past you as you race forward. You can hear her slowly mutate into some new form...");
                                playerProgress = 7;
                            }
                            else
                            {
                                Console.WriteLine("The potion of alacrity permits you to see, in your final moments, the Eldritch Lady of the ArchFey's glamour vanish. The moment your foot scuffs the pentagram, some sort of spindly appendage flashes from nowhere, its claw slashing open your throat before a flurry of similar attacks utterly eviscerates you...");
                                Console.ReadKey(true);
                                Console.WriteLine("Your adventure ends here...");
                                Console.ReadKey(true);
                                return false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The moment your foot scuffs the markings is the last moment of your life...");
                            Console.ReadKey(true);
                            Console.WriteLine("Your adventure ends here...");
                            Console.ReadKey(true);
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You scour the oubliette for some other exit, " +
                    "some other way forward - anything you might have overlooked. " +
                    "Your search becomes feverish as midnight approaches, and all " +
                    "the while the CurseBreaker's incantations build momentum towards " +
                    "some crescendo of ghastly syllables that send chills through you... ");
                        Console.ReadKey(true);
                        Console.WriteLine("\nFinally midnight is upon you.");
                        Console.ReadKey(true);
                        Console.WriteLine("Throughout the tower all the clocks chime the hour. Even from the oubliette you hear " +
                            "them. The pale ghostly light of the runes catch your final look of fright, before all the lights go out and darkness falls." +
                            " The dark Lady disappeared with them, swept into the portal that turned, for but an instant, blood moon red, before it too vanished. " +
                            "  \n  You are left alone only for a few tense moments, dreading what is to follow, before a blood-curdling howl erupts from above" +
                            " as something new and terrible is brought into the world. Soon afterwards, the tower collapses in on you... ");
                        Console.ReadKey(true);
                        Console.WriteLine("At least you never caught sight of the horror your lack of urgency unleashed.");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        return false;
                    }
                    Console.ReadKey(true);
                }
                
            }
            else if(message[index] == 'T')
            {
                Console.WriteLine("Test your skill...\n[Roll a D12 under or equal to your skill score]");
                Console.ReadKey(true);
                
                Dice D12 = new Dice(12);
                int roll = D12.Roll(D12);
                if (Player.Traits.ContainsKey("jinxed"))
                {
                    roll /= 3;
                }
                Console.WriteLine($"You rolled a {roll}");
                if (roll <= Player.Skill)
                {
                    Console.WriteLine("The moment your foot breaks the circle of the pentagram, you flee!\n You are too fast for the Lady's surprise attack, but she only laughs ecstatically in response. Her mania, however, soon morphs into some alien species of cackle, its blood-chilling notes electrifying the very air that surges past you as you race forward. You can hear her slowly mutate into some new form...");
                    playerProgress = 6;
                }
                else
                {
                    Console.WriteLine("The potion of alacrity permits you to see, in your final moments, the Eldritch Lady of the ArchFey's glamour vanish. The moment your foot scuffs the pentagram, some sort of spindly appendage flashes from nowhere, its claw slashing open your throat before a flurry of similar attacks utterly eviscerates you...");
                    Console.ReadKey(true);
                    Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                    return false;
                }
                Player.Speedy = true;
                Player.Inventory.Remove(speedPotion);
            }
            else if (message[index] == 'B')
            {
                Console.WriteLine("As you approach the pentagram, you ready yourself for anything...");
                Console
                    .ReadKey(true);
                Console.WriteLine("The moment you break the pentagram with your foot," +
                    " all the runes suddenly flicker in the darkness; a flurry of" +
                    " sporadic flashes that jolt the web of shadows around you into a" +
                    " frenzied quiver. But that's not before you clasp sight of the" +
                    " true horror the Lady embodies...");
                Console.ReadKey(true);
                Console.WriteLine("Your transfixed gaze latches with unbridled horror" +
                    " upon the beginning of the Lady's transformation into some new " +
                    "species of terror. Caught in sporadic snapshots as the runes' " +
                    "glow sputters and flashes like lightning, a towering, gaunt " +
                    "monster with vicious claws and slowly unfurling chiropteric" +
                    " wings reveals itself. They are huge and bat-like, yet so " +
                    "frayed that only the spindly but powerful fingers, hooked with " +
                    "talons, remain. Her laughter transfigures into a bestial hiss " +
                    "as the rattling, skeletal wings loom and spread like the hood " +
                    "of a cobra poised to strike.");
                Console.ReadKey(true);
                Console.WriteLine("The blood drains from your face. Your heart" +
                    " knocks in double-time. You stagger backwards as the Lady's " +
                    "terrifying form looms more and more with each jerky snapshot of " +
                    "light, filling the dark chamber. You hear the spindly appendages " +
                    "clack upon the flagstones. They elevate her - not like wings carrying a devil in flight - " +
                    "but like legs supporting a monstrous tarantula...");
                Console.ReadKey(true);
                Console.WriteLine("'So you wish to fight me, little fly?' her voice" +
                    " is the vespine buzzing of a thousand wasps, as her once bewitching smile" +
                    " becomes a jagged maw of razors. 'How I shall enjoy plucking your limbs one by one!'");
                if (Fight(music, usesDictionaryItemItem, usesDictionaryItemFeature, oubliette, Player, usesDictionaryItemChar, holeInCeiling, specialItems, 1, false, false))
                {
                    Console.WriteLine("Wasting no more time you stagger your way to the portal and finally take the plunge...");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Error locating option! Check index.");
            }
            List<Dice> playerSpeed = new List<Dice>();
            if (Player.Speedy)
            {
                playerSpeed = alacritySpeed;
            }
            else
            {
                playerSpeed = normalSpeed;
            }
            playerProgress += AdvanceForward(playerProgress, playerSpeed);
            Console.ReadKey(true);
            Console.WriteLine("\nFrom somewhere behind you hear the Lady cackle as she scuttles towards you. She stalks the sound of your clapping footfalls, closes in on each beat of your pounding heart, all while she blindly flails at you with her talons each chance she gets...");
            Console.ReadKey(true);
            List<string> afterStrike = new List<string>
                    {
                        "\nThe Lady falls behind, blindly stabbing at the flagstones with her talons... \nThen she catches your scent...",
                        "\nThe Lady falls behind, blindly flailing before she catches the sound of you running away. Laughing manically, she gives chase...",
                        "\nThe Lady blindly scours the chamber for you as you slip ahead. It's not long before she's once again on your tail... ",
                        "\nThe Lady of vipers wastes time tearing up flagstones as she seeks to bloody her talons once more. Then she hears your scrambling...",
                        "\nThe looming monster slashes blindly at the ground where you were last! She cackles before she once again zeroes in on the sound of your thumping heart...",
                        "\nYou slip past the monster, leaving her to jab wildly at the floor with her spindly appendages..."
                    };
            while (playerProgress < 160 && monsterProgress < 160)
            {
                monsterProgress += AdvanceForward(monsterProgress, monsterSpeed);
                Console.WriteLine($"\n\nplayer - {playerProgress} : {monsterProgress} - monster\n");
                Console.ReadKey(true);
                if (monsterProgress > playerProgress)
                {
                    
                    int ouch = Monster.Veapon.Attack(Monster.Skill, Player.Skill, Player.Stamina, true, Monster, Player, "", oubliette, holeInCeiling);
                    Player.Stamina -= ouch;
                    if (Player.Stamina < 1)
                    {
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }
                    Console.WriteLine($"\nYou lost {ouch} points of Stamina!");
                    if (ouch == 0)
                    {
                        monsterProgress = playerProgress - 20 - D11.Roll(D11);
                    }
                    else
                    {
                        monsterProgress = playerProgress - 10;
                    }
                    Console.ReadKey(true);
                    Console.WriteLine(afterStrike[D6.Roll(D6) - 1]);
                    Console.ReadKey(true);
                }
                
                playerProgress += AdvanceForward(playerProgress, playerSpeed);
                Console.ReadKey(true);
                

            }
            while (playerProgress < 200 || monsterProgress < 200)
            {
                monsterProgress += AdvanceForward(monsterProgress, monsterSpeed);
                Console.ReadKey(true);
                if (monsterProgress > playerProgress)
                {
                    Console.WriteLine("The terror looming above you unleashes a frenzied flurry of strikes!");
                    Console.ReadKey(true);
                    int ouch = Monster.Veapon.Attack(Monster.Skill, Player.Skill, Player.Stamina, true, Monster, Player, "", oubliette, holeInCeiling);
                    Player.Stamina -= ouch;
                    if (Player.Stamina < 1)
                    {
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }
                    Console.WriteLine($"\nYou lost {ouch} points of Stamina!");
                    Console.ReadKey(true);
                    int youch = Monster.Veapon.Attack(Monster.Skill, Player.Skill, Player.Stamina, true, Monster, Player, "", oubliette, holeInCeiling);
                    Player.Stamina -= youch;
                    if (Player.Stamina < 1)
                    {
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }
                    Console.WriteLine($"\nYou lost {youch} points of Stamina!");
                    Console.ReadKey(true);
                    int yeouch = Monster.Veapon.Attack(Monster.Skill, Player.Skill, Player.Stamina, true, Monster, Player, "", oubliette, holeInCeiling);
                    Player.Stamina -= yeouch;
                    if (Player.Stamina < 1)
                    {
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }
                    Console.WriteLine($"\nYou lost {yeouch} points of Stamina!");
                    if (yeouch == 0)
                    {
                        monsterProgress = playerProgress - 20 - D11.Roll(D11);
                    }
                    else
                    {
                        monsterProgress = playerProgress - 10;
                    }
                    Console.ReadKey(true);

                    Console.WriteLine(afterStrike[D6.Roll(D6) - 1]);
                    Console.ReadKey(true);
                }
                playerProgress += AdvanceForward(playerProgress, playerSpeed);
                Console.ReadKey(true);
            }
            string mp3FilePath = "olimpians - dive for portal.mp3";
            using (var audiofile = new AudioFileReader(mp3FilePath))
            {
                using (var outputDevice = new WaveOutEvent())
                {
                    if (music)
                    {
                        outputDevice.Init(audiofile);
                        outputDevice.Play();
                    }
                    Console.WriteLine("\x1b[3J");
                    Console.Clear();
                    Console.WriteLine("You are an instant from the portal's reach when within a breathless instant the Lady lunges forwards!");
                    monsterProgress += AdvanceForward(monsterProgress, monsterSpeed);
                    Console.ReadKey(true);
                    Console.WriteLine("As the monster's talons close around you, snatching the portal from sight, you have but one final chance - You hurl yourself through her clutches! ");
                    Console.ReadKey(true);
                    Console.WriteLine("You both dive for the prize!");
                    Console.ReadKey(true);
                    Console.WriteLine("\x1b[3J");
                    Console.Clear();
                    Console.WriteLine("Upon the highest parapet of the tower, the dark figure's" +
                        " vile dirge escalates to a powerful crescendo, resonating across the" +
                        " valleys below him. He raises his arms, beseeching an avalanche of thunderheads above" +
                        " as they begin to stir, lightning flashing from within...");
                    Console.ReadKey(true);
                    Console.WriteLine("   His voice rises above the crash of thunder. The pages of the tome he reads glow hot, " +
                        " as though its passages had been etched in fire. With each ghastly syllable, fanatically delivered to" +
                        " the storm circling above, the full moon in the distance glows brighter and brighter... ");
                    Console.ReadKey(true);
                    Console.WriteLine("\n   Slowly, as drops of blood might taint water, its glow garners" +
                        " a scarlet hue as the diabolical rite nears completion...");
                    Console.ReadKey(true);
                    Console.WriteLine("  The storm abates its thunder.");
                    Console.ReadKey(true);
                    Console.WriteLine("  The fierce wind holds back its icy fury.");
                    Console.ReadKey(true);
                    Console.WriteLine("  The very forces of nature seem to recoil and pause with bated breath as the " +
                        " CurseBreaker, with a zealous flourish, begins booming the last words of the ritual...");
                    Console.ReadKey(true);
                    Console.WriteLine("There are no interruptions.");
                    Console.ReadKey(true);
                    Console.WriteLine("The young man in black attire bellows the last verse in rapturous triumph.");
                    Console.ReadKey(true);
                    Console.WriteLine("Then he waits...");
                    Console.ReadKey(true);
                    Console.WriteLine("Nothing stirs. ");
                    Console.ReadKey(true);
                    Console.WriteLine("\n\t\tAll is silent...");
                    Console.ReadKey(true);
                    Console.WriteLine("The CurseBreaker takes a step back, uncomprehending. His arms lower to his sides as a vagary of wind sweeps back his dark hair. ");
                    Console.ReadKey(true);
                    Console.WriteLine("'What are you waiting for?' he breathes to the storm tossed heavens. 'The words are spoken. The pact is made!'");
                    Console.WriteLine("'The very fates can no longer deny me my place,' he seethes as though his voice carries to the gods themselves. " +
                        "'Humanity shall be united under one justice - under my justice!'");
                    Console.ReadKey(true);
                    Console.WriteLine("\n\t\t'BRING ME MY DESTINY!'");
                    Console.ReadKey(true);
                    Console.WriteLine("   Finally, as though heeding his words, the tumult once again stirs...");
                    Console.ReadKey(true);
                }
            }
            using (var audioFile2 = new AudioFileReader("olimpians - bring forth the vortex.mp3"))
            {
                using (var outputDevice2 = new WaveOutEvent())
                {
                    if (music)
                    {
                        outputDevice2.Init(audioFile2);
                        outputDevice2.Play();
                    }
                    Console.WriteLine("The wind and sleet snatch at the young man's dark attire, whipping them " +
                        "into a frenzy. His cloak is torn from him and whisked away by the fierce gale.");
                    Console.WriteLine("\t'Yes...' he calls out, a zealotry lighting eyes darker than black. 'YES!'");
                    Console.ReadKey(true);
                    Console.WriteLine("The stormclouds roar with almighty thunder. " +
                        "They're whisked by the wind, slowly twisting into a vortex crackling with lightning. " +
                        "\n A vortex so powerful it " +
                        "could obliterate the tower...  ");
                    Console.ReadKey(true);
                    Console.WriteLine("The CurseBreaker flings his arms open to it, tossing the book aside as though to embrace what comes." +
                        "\n\nSlowly, the vortex spins faster and faster like a vast whirlpool tearing apart stars and galaxies; a tempest of the very heavens themselves." +
                        " ");
                    Console.ReadKey(true);
                    Console.WriteLine("Then the vortex strikes. It extends outwards like the finger of god; a tornado of lightning flashes and whorling smoke that smites the towertop.");
                    Console.ReadKey(true);
                    Console.WriteLine("But it doesn't embrace the CurseBreaker...");
                    Console.ReadKey(true);
                }
            }
            if (player.Stamina < 1)
            {
                Console.WriteLine("The vortex has become a portal for the terror in the oubliette. " +
                    "");
                Console.ReadKey(true);
                Console.WriteLine("Cackling, the Lady of Vipers is unleashed upon the world. After devouring the CurseBreaker, she shall become a " +
                    "terrible shadow cast upon the land for aeons to come - A harbinger of innumerable curses that shall spread and fester like a plague." +
                    "  As for you, the portal's remaining tidal forces tore your body asunder the moment you fell " +
                    "into the portal after her. ");
                Console.ReadKey(true);
                Console.WriteLine("Your adventure ends here...");
                Console.ReadKey(true);
                return false;
            }
            else
            {
                using (var audioFile3 = new AudioFileReader("olimpians - deliverance.mp3"))
                {
                    using (var outputFile3 = new WaveOutEvent())
                    {
                        if (music)
                        {
                            outputFile3.Init(audioFile3);
                            outputFile3.Play();
                        }
                        Stopwatch musicTime = new Stopwatch();
                        musicTime.Start();
                        Console.WriteLine("It strikes feet from where he stands, forcing him to stagger back from the roaring tumult. Lightning sparks and shatters flagstones, the sheer torque of the wind throws up masonry and grinds it to dust. " +
                            "From within the eye of this storm, something stirs.");
                        Console.ReadKey(true);
                        Console.WriteLine("\t'What devilry is this...?' The CurseBreaker breathes as the vortex vanishes, leaving behind a cloud of smoke and debris. \n  The storm rages more fiercely than before. Rain spots the flagstones, the moon's bloody hue vanishes and from within the smoke and carnage a lone silhouette rises.");
                        Console.ReadKey(true);
                        Console.WriteLine("Delivered to the highest parapet of the wizard tower, you at last face the sorcerer who conspired to weave you and so many others a fate worse than death...");
                        long time = 0;
                        Console.ReadKey(true);
                        if (music)
                        {
                            Console.WriteLine("\n\t\t\t[Please wait. Music lasts for 30 seconds...]");
                            while (time < 41000)
                            {

                                musicTime.Stop();
                                time = musicTime.ElapsedMilliseconds;
                                musicTime.Start();
                                Thread.Sleep(500);
                            }
                        }
                        return true;
                    }
                }
            }
                
            
            

        }
        public void WonFight(Room room)
        {
            Console.WriteLine($"Would you like to search the {Monster.Name} for items?");

            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "yes" || answer == "y")
                {
                    Monster.search(Player.CarryCapacity, Player.Inventory, Player.WeaponInventory, Player);
                    Feature deadFoe1 = new Feature("fallen foe", "They've pockets free for the plundering...", true, "searched", Monster.Items);
                    Feature fallenFoe = null;
                    foreach(Feature f in room.FeatureList)
                    {
                        if (f.Name == "fallen foe")
                        {
                            fallenFoe = f;
                        }
                    }
                    if (fallenFoe!=null)
                    {
                        
                        Feature deadFoe2 = new Feature("dead enemy", "They've pockets available for pilfering...", true, "searched", Monster.Items);
                        room.FeatureList.Add(deadFoe2);
                        
                    }
                    else
                    {
                        room.FeatureList.Add(deadFoe1);
                    }

                    return;
                }
                else if (answer == "no" || answer == "n") 
                {
                    Feature deadFoe1 = new Feature("fallen foe", "They've pockets free for the plundering...", true, "searched", Monster.Items);
                    Feature fallenFoe = null;
                    foreach (Feature f in room.FeatureList)
                    {
                        if (f.Name == "fallen foe")
                        {
                            fallenFoe = f;
                        }
                    }
                    if (fallenFoe != null)
                    {
                        Feature deadFoe2 = new Feature("dead enemy", "They've pockets available for pilfering...", true, "searched", Monster.Items);
                        room.FeatureList.Add(deadFoe2);
                                               
                    }
                    else
                    {
                        room.FeatureList.Add(deadFoe1);
                    }
                    return; 
                }
                else { Console.WriteLine("ERROR! Please answer 'yes' or 'no'."); }
            }
        }
        /// <summary>
        /// The general idea is that combat and the fight method is turn based; the player 
        /// attacks then the monster attacks, and who goes first is determined by dice rolls
        /// whether the dice roll succeeds is based off of what skill the player and monster possesses
        /// as well as other factors such as Boon or traits such as Jinxed. 
        /// Damage is determined by dice rolls too. the dice to be rolled is determined
        /// by the weapon in question being wielded. and the damage dealt can be magnified
        /// by a 'good hit' factor or a 'crit hit' factor. The threshold for rolling these
        /// is determined by factors such as skill and Boon. each operate in different ways 
        /// to boost the probability of good and crit hits. 
        /// You can also miss! and when you're jinxed the enemy can critically miss which
        /// harms them! messages will appear in the events of good or crit hits and 
        /// provide commentary of the battle. these messages are different for the type of 
        /// weapon used.
        /// The fight method returns 'true' if player wins the fight or false otherwise. Battle
        /// continues until either player or monster stamina falls to 0. 
        /// During battle you'll have the option to equip different weapons, fight barehanded
        /// or even use an item on something in the room or on the monster during combat. 
        /// This makes for a level of strategy involved in how one might deal with monsters. 
        /// If a monster holds an amulet that grants it a Boon in combat, do you use your turn 
        /// to heal yourself, equip a more effective weapon, strike back and hope for the best, 
        /// or try to use something in your possession to counter their amulet? The most effective
        /// choice in large part depends on your own traits. Jinxed characters might do more damage
        /// by letting the monster try and fail to land a hit. MedicineMan, meanwhile, makes healing
        /// potions extra effective. And 'Friends with Fairies' can lead to some unpredictable
        /// shenanigans indeed. 'Opening up' new strategies is always fun!
        /// 
        /// </summary>
        /// <param name="usesDictionaryItemItem"></param>
        /// <param name="usesDictionaryItemFeature"></param>
        /// <param name="room"></param>
        /// <param name="player"></param>
        /// <param name="usesDictionaryItemChar"></param>
        /// <param name="holeInCeiling"></param>
        /// <returns>boolean: true or false</returns>
        public bool Fight(bool music, Dictionary<Item, List<Item>> usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, Room room, Player player, Dictionary<Item, List<Player>> usesDictionaryItemChar, Feature holeInCeiling, List<Item> specialItems, int totemCount = 1, bool fire = false, bool _initiative = false, bool masked = false)
        {
            player = Player;
            Dice D2 = new Dice(2);
            Dice D3 = new Dice(3);
            Dice D4 = new Dice(4);
            Dice D5 = new Dice(5);
            Dice D6 = new Dice(6);
            //pugilism is FormatException the players unhanded fighting capability
            List<Dice> pugilism = new List<Dice>();
            int i = 0;
            string another = "a";
            while (i < (2 + Player.Skill) / 3)
            {
                if (i < 2)
                {
                    pugilism.Add(D2);
                }
                else if (i < 3)
                {
                    pugilism.Add(D3);
                }
                else
                {
                    pugilism.Add(D5);
                }
                i++;
            }
            if (fire)
            {
                List<string> fireString = new List<string>
                    {
                        "blazing ",
                        "burning ",
                        "smouldering ",
                        "smoking ",
                        "fiery "
                    };
                int firenum = D5.Roll(D5);
                foreach (Feature x in room.FeatureList)
                {
                    firenum = D5.Roll(D5);
                    Thread.Sleep(7);
                    x.Name = $"{fireString[firenum - 1]}{x.Name}";
                }
                foreach (Item x in room.ItemList)
                {
                    firenum = D5.Roll(D5);
                    Thread.Sleep(3);
                    x.Name = $"{fireString[firenum - 1]}{x.Name}";
                }
                
                room.Name = "cell";
                room.Name = $"{fireString[firenum - 1]}{room.Name}";
            }
            List<string> jinxedMisses = new List<string>
            {
                $"The {Monster.Name} has you now! Finally, relishing it's soon-to-be freedom from your cursed, jinxy hide, it raises its {Monster.Items[0].Name} to strike... and gets it stuck in the {room.FeatureList[D4.Roll(D4) - 1].Name}. You scurry away as the {Monster.Name} curses, trying to free it. \nThe {Monster.Name} loses 1 stamina.",
                $"The ever-increasingly vexed {Monster.Name} attacks, misses, and gets really bad tennis-elbow. Ooh! that's gotta hurt... \nThe {Monster.Name} loses 2 stamina.",
                $"The {Monster.Name} lunges at you! As you trip over yourself, clumsily scrambling for cover, you hear a tremendous crash. \nThe {Monster.Name} ran into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Ow! It loses 5 Stamina.",
                $"The {Monster.Name} at last has you pinned. It looms over you with a leer, ready to deliver the killing blow, when part of the {room.Name}'s ceiling caves in upon its head. \nThe {Monster.Name} loses 7 stamina!",
                $"The {Monster.Name} bellows a string of foul curses as each frenzied attack miraculously leaves you unscathed. It bites its own tongue in the process. Youch! \nAs you slip away, the {Monster.Name} loses 1 stamina...",
                $"The {Monster.Name} bounds after you in circles, flailing wildly. It careers into a {room.ItemList[D3.Roll(D3) - 1].Name}, grazing its knee. Oof! That's a nasty splinter! \nThe {Monster.Name} loses 3 stamina.",
                $"You stammer as you try reasoning with the {Monster.Name}. Surely you can just talk things out over a lovely cup of mead... The {Monster.Name} doesn't listen. It lunges at you, only to crash into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Yikes! \nThe {Monster.Name} loses 11 stamina.",
                $"In frustration the {Monster.Name} hurls its {Monster.Items[0].Name} at you! It bounces off your armour back at the {Monster.Name}. \n The {Monster.Name} loses 6 stamina.",
                $"The {Monster.Name} attacks wildly, wanting nothing more than to end the whirlwind of chaos your ill-fortune brings. It trips. Ouch! That's going to need a bandage... \nThe {Monster.Name} loses 7 stamina.",
                $"The {Monster.Name} at last has you cornered. It looms over you with a leer, ready to at last deliver the killing blow. Then the {room.Name}'s ceiling caves in.\n The {Monster.Name}'s engulfed by an avalanche of cascading debris. A trickle of dust takes a moment to stop. Then finally, one loose floorboard topples from the floor above and crowns the heap."
            };
            List<String> pugilismCritHits = new List<String>
                {
                $"Extending your palm into a spear-like thrust, you strike the {Monster.Name}'s chest cavity. Their ribs shatter as your hand plunges deep inside. An instant later your fist is clenched around their still beating heart, held before their awed eyes just before the light leaves them forever.",
                $"The {Monster.Name} charges towards you. With cat-like reflexes you assume the 'soaring crane' position practiced by martial monks of old. You serenely close your eyes to the {Monster.Name}'s battle roar, silencing your mind. When you open them again, you've landed with uncanny grace back on your feet. Your whirlwind kick has sent the {Monster.Name} sailing through the air. They're not done yet, but it won't be long...",
                $"The {Monster.Name}'s guard is just strong enough to turn your killer karate chop, into a nevertheless brutal strike. The {Monster.Name} is left winded and greviously wounded.",
                $"A bead of cold sweat traces your brow as you're forced to admit that even your lethal hands are struggling to find any weak spot to exploit. Your best blows have yet to slow the {Monster.Name} down. It seems its anger has only increased.",
                $"After a series quick jabs to the ribs, the {Monster.Name}'s guard collapses. You seize your chance, landing a powerful blow across its jaw. There's an audible crack as the {Monster.Name}'s neck snaps. With its head twisted 180 degrees the wrong way, it collapses backwards (forwards?) as stiff as a board to the floor.",
                $"You rain haymaker after haymaker down upon the {Monster.Name}. With one dislocated limb, they still manage to somehow wheel away from you before you can land the killing blow. They stagger to their feet.",
                $"Your uppercut drives deep into the {Monster.Name}'s gut. It is left wheezing for breath. For a moment it looks like it might collapse to its knees. But slowly it rises up again to continue the fight...",
                $"You land blow after blow, but the {Monster.Name} appears to be able to tap into ever more reserves of stamina. This fight may go either way yet... ",
                $"Your flailing fists chance a lucky blow. The {Monster.Name}'s nose splinters as it charges into your fist, it's momentum rather than your own felling the creature. Its brain is pulverised as bone fragments ricochet inside its skull. A portion of its brain dribbles from its nostril, before it keels over.",
                $"Your blows are almost effortlessly deflected by the {Monster.Name}, until your elbow clobbers them over the head. The {Monster.Name} looks like it might suffer a concussion, but even this fortunate hit isn't enough to finish them yet...",
                $"You trip over your own foot, but somehow the {Monster.Name} comes out the worst for it! Their blow sails over your head, sending them off balance and toppling to the ground. You manage to land a few kicks into their back before they get up again.",
                $"You kick the {Monster.Name}'s shins as it makes to grapple you. Despite your amateurish attacks, you've caused it a lot of pain. However, it has done little to end this fight.",
                $"Cornered, you duck the {Monster.Name}'s devastating blow, before scrambling along the floor under its feet. As it scrambles for your ankles, gazing at you through its own legs, something cracks. The {Monster.Name}'s back locks in place! It topples over in a knot of limbs. You flail at it with your wimpy wrists until it expires.",
                $"Something gets stuck in your eye. Groping blindly you run into the {Monster.Name}. Somehow this turns into a devastating body slam. The {Monster.Name} staggers to its feet, rueing the day it met you...",
                $"Your oafish attacks rarely land, until you tumble. Your flailing foot clumsily connects with the {Monster.Name}'s nethers. Weapon raised, they continue to aggressively... waddle towards you.",
                $"You nip the {Monster.Name}'s fingers as it grapples you. As you slip away it trips over its own feet. Ouch! The {Monster.Name} looks more infuriated than ever as it continues scrambling after you around the room."
                };
            List<String> pugilismGoodHits = new List<String>
                {
                $"Your scissor kick finally puts the {Monster.Name}'s lights out.",
                $"You execute a flawless palm strike. {Monster.Name} is close to death.",
                $"You deliver a series of crushing hammer-fist blows to the {Monster.Name}.",
                $"You administer a flurry of lightning jabs to the {Monster.Name}'s pressure points.",
                $"Your sucker punch lifts the {Monster.Name} off their feet. They don't get back up.",
                $"A crude but powerful push kick sends the {Monster.Name} crashing to the floor.",
                $"A flurry of light jabs rearranges the {Monster.Name}'s face.",
                $"Your punches have been strong, but you'll require something better yet to defeat this foe",
                $"One final, solid punch sends the {Monster.Name} tottering over. They are finally vanquished.",
                $"Your unrefined pugilism has somehow reduced the {Monster.Name} to its final shred of life.",
                $"Your fist blow has for once wholly bypassed the {Monster.Name}'s defences.",
                $"You chance a lucky hit, but not lucky enough - the {Monster.Name} remains unfazed. You're going to have to really pull something out of the bag to win this fight...",
                $"Your jinxed nature rubs off on your adversary. The {Monster.Name} somehow clobbers itself over the noggin. It's head topples from its shoulders.",
                $"In a strange twist of fate, the {Monster.Name} injures itself with its {Monster.Veapon.Name} as it chases you around in circles.",
                $"The {Monster.Name} keeps stepping on loose floorboards... Then steps on a nail. Yeesh!",
                $"The {Monster.Name} steps on a loose floorboard. It whacks them in the face. Ouch!"
                };
            Weapon playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
            if (Player.Skill < 4)
            {
                playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else if (Player.Skill < 7)
            {
                playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else if (Player.Skill < 10)
            {
                playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else
            {
                playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            //checking to see which weapon player has equipped, otherwise uses fists
            foreach (Weapon y in Player.WeaponInventory)
            {
                if (y is Weapon)
                {
                    if (y.Equipped) { playerWeapon = y; break; }
                }
            }
            foreach (Weapon x in Player.WeaponInventory) { playerWeapon.Boon = 0; }// potion of luck, felix felicis, works for one battle only
            if (player.Traits.ContainsKey("jinxed"))
            {
                //
                ///Boon slides the probability curve to the players favour during dice rolls
                ///a boon of 6 increases the chance to hit, the chance the monster misses, and the
                ///likelihood of crit Hits by 30% or 25% (because we use a D20)
                //
                playerWeapon.Boon = 6;
                
            }
            List<String> defaultCritHits = new List<String>
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
            List<String> defaultGoodHits = new List<String>
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

            Console.WriteLine(Monster.Description);
            if (fire)
            {
                Console.ReadKey(true);
                Console.WriteLine("The goblin doesn't recoil from the heat. A veteran of many pillages and raids, the goblin is undaunted by fire and immune to the choking smoke...\nBut you aren't!\nYou'll suffer damage for each turn this fight lasts!");
                Console.ReadKey(true);
            }
            Dice D20 = new Dice(20);
            bool initiative = false;
            using (var audioFile = new AudioFileReader("thunderstorm-in-kyoto-zac-tiessen-main-version-23958-01-30.mp3"))
            {
                using (var outputFile = new WaveOutEvent())
                {
                    if (Monster.Name == "minotaur" && music)
                    {
                        outputFile.Init(audioFile);
                        outputFile.Play();
                    }
                    if ((Player.Skill + D20.Roll(D20) >= Monster.Skill + D20.Roll(D20) && !fire) || _initiative)
                    {
                        Console.WriteLine($"The {Monster.Name} is caught off guard. You take the initiative!");
                        initiative = true;
                    }
                    else
                    {
                        Console.WriteLine($"Your reactions aren't fast enough. {Monster.Name} takes the initiative!");
                    }
                    int turn = 0;
                    int round = 0;
                    if (initiative)
                    {

                        int damageDealt = playerWeapon.Attack(Player.Skill, Monster.Skill, Monster.Stamina, true, Monster, player, another, room, holeInCeiling, totemCount);
                        Monster.Stamina -= damageDealt;
                        Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");
                        turn = 1;
                        if (player.Speedy)
                        {
                            Console.WriteLine("The enemy is scarcely able to respond to your first attack when you quickly jump in with another.");
                            damageDealt = playerWeapon.Attack(Player.Skill, Monster.Skill, Monster.Stamina, true, Monster, player, another, room, holeInCeiling, totemCount);
                            Monster.Stamina -= damageDealt;
                            Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");
                        }
                        Console.ReadKey(true);
                    }

                    while (Monster.Stamina > 0 && Player.Stamina > 0)
                    {
                        bool start = false;


                        if (turn == 0)
                        {
                            start = true;
                        }
                        if (Monster.Stamina < 1) { break; }
                        bool curseBreaker = false;
                        int divisor = 1;
                        if(Monster.Name == "CurseBreaker")
                        {
                            curseBreaker = true;
                            divisor = -1;
                            if (start && Monster.Veapon.Name == "sabre")
                            {
                                Console.WriteLine("\nThe CurseBreaker slashes at you with his sabre!\n");
                            }
                            else if (start)
                            {
                                Console.WriteLine("\nThe CurseBreaker tosses his stiletto blade from hand to hand as he probes for an opening...\n");
                            }
                            Console.ReadKey(true);
                        }
                        int damageDealt = Monster.Veapon.Attack(Monster.Skill, Player.Skill, Player.Stamina, curseBreaker, Monster, player, another, room, holeInCeiling, divisor, start);
                        if (damageDealt >= 0)
                        {
                            Player.Stamina -= damageDealt;

                            Console.WriteLine($"You've lost {damageDealt} points of stamina!");
                        }
                        else if (damageDealt < 0)
                        {

                            Monster.Stamina += damageDealt;

                        }
                        if (Monster.Stamina < 1) { break; }
                        if (Player.Stamina < 1) { break; }

                        if (Monster.Name == "CurseBreaker")
                        {
                            bool protection = false;
                            foreach (Weapon w in player.WeaponInventory)
                            {
                                if ((w.Name.ToLower() == "sword of sealed souls" || w.Name == "Marvellous Merigold's Magical Staff of Whacking") && w.Equipped)
                                {
                                    protection = true;
                                }
                            }
                            if (protection)
                            {
                                List<string> expression = new List<string>
                                {
                                    "glowers",
                                    "scowls",
                                    "becomes vexed",
                                    "hisses",
                                    "seethes",
                                    "curls his lip",
                                    "becomes enraged",
                                    "fumes"
                                };
                                Dice D8 = new Dice(8);
                                Console.ReadKey(true);
                                Console.WriteLine($"The CurseBreaker {expression[D8.Roll(D8) - 1]} as his magic is negated by your weapon...");
                                
                            }
                            else
                            {
                                List<Item> gloves = new List<Item>();
                                try
                                {
                                    gloves = new List<Item> { Monster.Items[3] };
                                }
                                catch
                                {
                                    gloves = new List<Item> { Monster.Items[2] };
                                }
                                List<Weapon> cursedGloves = gloves.Cast<Weapon>().ToList();
                                Console.WriteLine("You hear electricity crackle at the CurseBreaker's fingertips as he points a gloved hand your way...");
                                damageDealt = cursedGloves[0].Attack(Monster.Skill, Player.Skill, Player.Stamina, true, Monster, player, another, room, holeInCeiling, -1, start);
                                if (damageDealt >= 0)
                                {
                                    Player.Stamina -= damageDealt;
                                    Console.ReadKey(true);
                                    Console.WriteLine($"You've lost {damageDealt} points of stamina!");
                                }
                                else if (damageDealt < 0)
                                {

                                    Monster.Stamina += damageDealt;

                                }
                                if (Monster.Stamina < 1) { break; }
                                if (Player.Stamina < 1) { break; }
                            }
                        }
                        if (round == 0 && fire)
                        {
                            round++;
                        }
                        else if (round < 2 && fire)
                        {
                            Console.WriteLine("The smouldering flames plume with smoke, stinging your eyes!");
                            int burnt = D5.Roll(D5);
                            Player.Stamina -= burnt;
                            Console.WriteLine($"You lost {burnt} stamina!");
                            round++;
                        }
                        else if (round < 3 && fire)
                        {
                            Console.WriteLine($"The {room.Name} swells with smoke. You splutter and cough as the {Monster.Name}'s {Monster.Veapon.Name} slashes at you through the swirling haze!");
                            int burnt = D5.Roll(D5) + D3.Roll(D3);
                            Player.Stamina -= burnt;
                            Console.WriteLine($"You lost {burnt} stamina!");
                            round++;
                        }
                        else if (round < 4 && fire)
                        {
                            Console.WriteLine($"The flames in the {room.Name} now begin to roar as they climb the walls!");
                            int burnt = D5.Roll(D5) + D3.Roll(D3) + D5.Roll(D5);
                            player.Stamina -= burnt;
                            Console.WriteLine($"You lost {burnt} stamina!");
                            round++;
                        }
                        else if (round < 5 && fire)
                        {
                            Console.WriteLine($"The fire shows no sign of stopping. If you don't hurry t won't matter who wins this fight - the flames will engulf you both!");
                            int burnt = D5.Roll(D5) + D3.Roll(D3) + D5.Roll(D3) + D4.Roll(D4);
                            player.Stamina -= burnt;
                            Console.WriteLine($"You lost {burnt} stamina!");
                            round++;
                        }
                        else if (round < 6 && fire)
                        {
                            Console.WriteLine("Between parries and blows you can only gaze in horror as the fire turns into a raging inferno. You hold your breath, your lungs aching for air...");
                            int burnt = D5.Roll(D5) + D3.Roll(D3) + D5.Roll(D3) + D4.Roll(D4) + D3.Roll(D3);
                            player.Stamina -= burnt;
                            Console.WriteLine($"You've lost {burnt} stamina!");
                            round++;
                        }
                        else if (round < 7 && fire)
                        {
                            Console.WriteLine("The blazing cell begins to spin around you as you fight with mounting desperation. Flames lick at your exposed skin. You feel the hairs on the back of your neck singe.");
                            int burnt = D5.Roll(D5) + D3.Roll(D3) + D5.Roll(D3) + D4.Roll(D4) + D3.Roll(D3);
                            player.Stamina -= burnt;
                            Console.WriteLine($"You've lost {burnt} stamina!");
                            round++;
                        }
                        else if (round < 8 && fire)
                        {
                            Console.WriteLine("You can hold your breath no longer! You begin inhaling the smoke only to stagger and splutter in a fit of hacking coughs. You can scarcely dodge the enemy's attacks as you double over, the furnace-like heat beating against you relentlessly from all sides.\n The end is near...");
                            int burnt = D5.Roll(D5);
                            player.Stamina -= burnt;
                            if (player.Skill > 2)
                            {
                                player.Skill -= 2;
                            }
                            Console.WriteLine($"You've lost {burnt} stamina and 2 skill points!");
                            round++;
                        }
                        else if (fire)
                        {
                            int burnt = 9999;
                            player.Stamina -= burnt;
                            if (Monster.Stamina > 0)
                            {
                                Monster.Stamina -= burnt;
                            }
                            Console.WriteLine($"The flames finally envelop and engulf your body. If there is one small mercy, it is that cremation is a far kinder fate than what your captors had in store for you, not that you'll ever know what that would've been...");
                        }
                        Console.ReadKey(true);
                        if (Monster.Stamina < 1) { break; }
                        if (Player.Stamina < 1) { break; }

                        Console.WriteLine(Player.DescribeStamina());
                        Console.Write($"Do you wish to continue attacking with your {playerWeapon.Name}? ");
                        int speedyturn = 0;
                        while (true)
                        {
                            string answer = Console.ReadLine().Trim().ToLower();
                            // attack with weapon
                            if (answer == "yes" || answer == "y")
                            {
                                pugilism = new List<Dice>();
                                i = 0;
                                while (i < (2 + Player.Skill) / 3)
                                {
                                    if (i < 2)
                                    {
                                        pugilism.Add(D2);
                                    }
                                    else if (i < 3)
                                    {
                                        pugilism.Add(D3);
                                    }
                                    else
                                    {
                                        pugilism.Add(D5);
                                    }
                                    i++;
                                }
                                if (playerWeapon.Boon > 9)
                                {
                                    if (Player.Skill < 4)
                                    {
                                        playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                    }
                                    else if (Player.Skill < 7)
                                    {
                                        playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                    }
                                    else if (Player.Skill < 10)
                                    {
                                        playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                    }
                                    else
                                    {
                                        playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                    }
                                }
                                else
                                {
                                    if (Player.Skill < 4)
                                    {
                                        playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else if (Player.Skill < 7)
                                    {
                                        playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else if (Player.Skill < 10)
                                    {
                                        playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else
                                    {
                                        playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                }
                                foreach (Weapon y in Player.WeaponInventory)
                                {
                                    if (y.Equipped) { playerWeapon = y; break; }
                                }
                                if (playerWeapon.Boon < 10 && player.Traits.ContainsKey("jinxed"))
                                {
                                    playerWeapon.Boon = 6;
                                }

                                damageDealt = playerWeapon.Attack(Player.Skill, Monster.Skill, Monster.Stamina, true, Monster, player, another, room, holeInCeiling, totemCount);
                                Monster.Stamina -= damageDealt;
                                if (player.Speedy && speedyturn == 0)
                                {
                                    Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");
                                    Console.WriteLine("The enemy is scarcely able to respond to your rapid movements when you quickly make another action.");
                                    Console.Write($"Do you wish to continue attacking with your {playerWeapon.Name}? ");
                                    speedyturn++;
                                    continue;

                                }

                                Console.WriteLine("\n");
                                if (damageDealt > 0)
                                {
                                    Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");

                                }
                                else
                                {
                                    turn = -1;
                                    Console.WriteLine($"{Monster.Name} seizes their chance to attack!");
                                }
                                Console.ReadKey(true);
                                break;
                            }
                            // try some other tactic
                            else if ((answer == "no") || (answer == "n"))
                            {
                                turn = -1;
                                Console.WriteLine("Will you spend your turn \n[1] Equipping a new weapon?\n[2] Unequipping your weapon?\n[3] Using one of your items on something or someone?\n[4]Hesitating and considering your choices in life?");
                                while (true)
                                {
                                    string answer1 = Console.ReadLine().Trim().ToLower();
                                    if (answer1 == "1" || answer1 == "one")
                                    {
                                        int j = 0;
                                        List<Weapon> availableWeapons = new List<Weapon>();
                                        foreach (Weapon h in Player.WeaponInventory)
                                        {
                                            j++;
                                            if (!h.Equipped)
                                            {
                                                availableWeapons.Add(h);
                                            }
                                        }
                                        if (j < 1)
                                        {
                                            Console.WriteLine("You waste time frenziedly rummaging through your rucksack, but you've no new weapons to choose from!");
                                            break;
                                        }
                                        string message = "You can choose from ";
                                        int numWeapons = availableWeapons.Count;
                                        int k = 1;
                                        foreach (Weapon h in availableWeapons)
                                        {
                                            message += "\n[" + k + "] " + h.Name;
                                            k++;
                                        }
                                        Console.WriteLine(message);
                                        while (true)
                                        {
                                            string response = Console.ReadLine().Trim().ToLower();
                                            try
                                            {
                                                int numResponse = int.Parse(response);
                                                Player.Equip(availableWeapons[numResponse - 1], Player.WeaponInventory, player);
                                                Console.WriteLine($"\n{availableWeapons[numResponse - 1].Description}");
                                                foreach (Weapon y in Player.WeaponInventory)
                                                {
                                                    if (y.Equipped) { playerWeapon = y; break; }
                                                }
                                                if (player.Speedy && speedyturn == 0)
                                                {
                                                    Console.WriteLine($"You admire your {availableWeapons[numResponse - 1].Name} amidst a world sluggishly moving around you in slow motion, before instantly jumping to your next action.");
                                                    break;
                                                }
                                                Console.WriteLine($"You admire your {availableWeapons[numResponse - 1].Name} for only an instant before the {Monster.Name} lunges at you...");
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine($"Please enter a number from 1 to {numWeapons}");
                                                continue;
                                            }

                                        }

                                        break;

                                    }
                                    else if (answer1 == "2" || answer1 == "two")
                                    {
                                        if (playerWeapon.Name == "fists")
                                        {
                                            Console.WriteLine($"You're not sure how you might 'unequip' your own fists, and as you contemplate this conundrum the {Monster.Name} comes in for the attack...");
                                            break;
                                        }
                                        else
                                        {
                                            Player.Unequip(Player.WeaponInventory);
                                            pugilism = new List<Dice>();
                                            i = 0;
                                            while (i < (2 + Player.Skill) / 3)
                                            {
                                                if (i < 2)
                                                {
                                                    pugilism.Add(D2);
                                                }
                                                else if (i < 3)
                                                {
                                                    pugilism.Add(D3);
                                                }
                                                else
                                                {
                                                    pugilism.Add(D5);
                                                }
                                                i++;
                                            }
                                            if (Player.Skill < 4)
                                            {
                                                playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
                                            }
                                            else if (Player.Skill < 7)
                                            {
                                                playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
                                            }
                                            else if (Player.Skill < 10)
                                            {
                                                playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
                                            }
                                            else
                                            {
                                                playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
                                            }
                                            if (player.Speedy && speedyturn == 0)
                                            {
                                                Console.WriteLine($"{playerWeapon.Description}\nYou resolve to fight bare fisted, mano e mano.");
                                                break;
                                            }
                                            Console.WriteLine($"{playerWeapon.Description}\nYou resolve to fight bare fisted, mano e mano. \n Meanwhile, the {Monster.Name} charges towards you...");
                                            break;
                                        }
                                    }
                                    ///The following is very similar to what you'll see in the game class 
                                    ///or the main method. It's the same formula for using an item on something else 
                                    ///but it lists objects the monster has too. as such it'll need to become
                                    ///its own separate method at a later date.

                                    else if (answer1 == "3" || answer1 == "three")
                                    {
                                        bool success = false;
                                        if (player.Inventory.Count > 0)
                                        {
                                            Console.WriteLine("Which item in your pack do you wish to use?");
                                            int g = 1;
                                            foreach (Item item in player.Inventory)
                                            {
                                                Console.WriteLine($"[{g}] {item.Name}");
                                                g++;
                                            }
                                            bool useWeapon = false;
                                            foreach(Weapon w in player.WeaponInventory)
                                            {
                                                if (w.Equipped)
                                                {
                                                    Console.WriteLine($"[{g}] {w.Name}");
                                                    useWeapon = true;
                                                }
                                            }
                                            Item chosenItem = null;
                                            while (true)
                                            {
                                                string reply = Console.ReadLine().Trim().ToLower();

                                                try
                                                {
                                                    int reply1 = int.Parse(reply) - 1;
                                                    try
                                                    {
                                                        chosenItem = player.Inventory[reply1];
                                                        break;
                                                    }
                                                    catch 
                                                    {
                                                        if (reply1 == g - 1 && useWeapon)
                                                        {
                                                            int count = 0;
                                                            foreach (Weapon w in player.WeaponInventory)
                                                            {
                                                                if (w.Equipped)
                                                                {
                                                                    chosenItem = player.WeaponInventory[count];
                                                                }
                                                                count++;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Please enter a number corresponding to an item listed above!");
                                                        }
                                                    }

                                                }
                                                catch
                                                {
                                                    foreach (Item item in player.Inventory)
                                                    {
                                                        if (item.Name == reply)
                                                        {
                                                            chosenItem = item;

                                                        }

                                                    }
                                                    foreach (Weapon w in player.WeaponInventory)
                                                    {
                                                        if (w.Name == reply)
                                                        {
                                                            chosenItem = w;
                                                        }
                                                    }
                                                }
                                                if (chosenItem == null)
                                                {
                                                    Console.WriteLine($"{reply} could not be found in your backpack. Select another item.");
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

                                            foreach (Item item in Monster.Items)
                                            {
                                                Console.WriteLine($"[{g}] The {Monster.Name}'s {item.Name}");
                                                g++;
                                            }
                                            foreach (Feature feature in room.FeatureList)
                                            {
                                                Console.WriteLine($"[{g}] {feature.Name} in the room.");
                                                g++;
                                            }
                                            Console.WriteLine($"[{g}] Yourself");
                                            if (playerWeapon.Name != "fists")
                                            {
                                                Console.WriteLine($"[{g + 1}] The weapon in your hand.");
                                            }

                                            while (true)
                                            {
                                                string effectedItemString = Console.ReadLine().Trim().ToLower();
                                                try
                                                {
                                                    int effectedItemNum = int.Parse(effectedItemString);
                                                    if (effectedItemNum < 1 || effectedItemNum > g + 1) { Console.WriteLine("Please select a number that corresponds with an item listed above."); }
                                                    else if (playerWeapon.Name != "fists" && effectedItemNum == g + 1)
                                                    {
                                                        try
                                                        {
                                                            foreach (Weapon w in player.WeaponInventory)
                                                            {
                                                                if (w.Equipped)
                                                                {
                                                                    success = w.UseItem(music, chosenItem, w, usesDictionaryItemItem, specialItems)[0];
                                                                    Console.WriteLine($"You coat your {playerWeapon} in the {chosenItem}");
                                                                    player.Inventory.Remove(chosenItem);
                                                                    break;
                                                                }

                                                            }
                                                            break;
                                                        }
                                                        catch { Console.WriteLine($"You can't use {chosenItem} on that!"); break; }
                                                    }
                                                    else if (effectedItemNum == g)
                                                    {
                                                        try
                                                        {
                                                            success = chosenItem.UseItem3(chosenItem, player, usesDictionaryItemChar, masked);

                                                            if (chosenItem.Name.Trim().ToLower() == "healing potion")
                                                            {
                                                                Console.WriteLine("Liquid rejuvenation trickles down your parched throat. A warm feeling swells from your heart as you feel your wounds salved and your flesh knitting itself back together.");
                                                            }
                                                            else if (chosenItem.Name.Trim().ToLower() == "elixir of feline guile")
                                                            {
                                                                Console.WriteLine("You glug the potent elixir down. Your stomach ties itself in knots for a moment, before you feel your instincts and reflexes sharpen.");
                                                            }
                                                            else if (chosenItem.Name.Trim().ToLower() == "potion of alacrity")
                                                            {
                                                                Console.WriteLine("The potion tastes as bad as it looks. However, you instantly discover the rest of the world looks as though it couldn't catch up with a snail. The enemy's lunges and attacks begin to look comically sluggish, as though they were moving through water.\n You fly into action...");
                                                            }
                                                            else if (success) // luck potion grants boon to all weapons.
                                                            {
                                                                Console.WriteLine("The sweet liquid tastes like nirvana. It's effervescent body dances on your tongue and delights the senses. Suddenly you feel like anything is possible...");
                                                                playerWeapon.Boon = 10;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Ermm...No. Upon reflection, you'd rather not use that on yourself.");
                                                            }
                                                            break;
                                                        }
                                                        catch { Console.WriteLine("Ermm...No. Upon reflection, you'd rather not use that on yourself."); break; }

                                                    }
                                                    else if (effectedItemNum < g && effectedItemNum > room.ItemList.Count + Monster.Items.Count)
                                                    {
                                                        try
                                                        {
                                                            success = chosenItem.UseItem1(music, usesDictionaryItemChar, chosenItem, room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Monster.Items.Count], usesDictionaryItemFeature, player.Inventory, player.WeaponInventory, room, player, Monster, this, false);
                                                            if ((chosenItem.Name.ToLower() == "sword of sealed souls" 
                                                                || chosenItem.Name == "Marvellous Merigold's Magical Staff of Whacking") 
                                                                && room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Monster.Items.Count].Name.Contains("totem") 
                                                                && success)
                                                            {
                                                                Feature effectedFeature = room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Monster.Items.Count];
                                                                if (effectedFeature.Stamina < 1)
                                                                {
                                                                    totemCount--;
                                                                    if (totemCount == 0) { throw new DivideByZeroException("Check to ensure the correct value for totemCount has been implemented on the Highest Parapet!"); }
                                                                }
                                                            }
                                                            break;
                                                        }
                                                        catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Monster.Items.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised..."); break; }
                                                    
                                                    }
                                                    else if (effectedItemNum > room.ItemList.Count)
                                                    {
                                                        try
                                                        {
                                                            success = chosenItem.UseItem(music, chosenItem, Monster.Items[effectedItemNum - 1 - room.ItemList.Count], usesDictionaryItemItem, specialItems, null, null, room, player, holeInCeiling, null, null, null, null, Monster)[0];
                                                            if (room.FeatureList.Contains(holeInCeiling))
                                                            {
                                                                Console.WriteLine(jinxedMisses[9]);
                                                                Monster.Stamina -= 9999;
                                                            }
                                                             
                                                            break;
                                                        }
                                                        catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {Monster.Items[effectedItemNum - 1 - room.ItemList.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised..."); break; }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            success = chosenItem.UseItem(music, chosenItem, room.ItemList[effectedItemNum - 1], usesDictionaryItemItem, specialItems, null, null, room, player, holeInCeiling)[0];
                                                            if (room.FeatureList.Contains(holeInCeiling))
                                                            {
                                                                Console.WriteLine(jinxedMisses[9]);
                                                                Monster.Stamina -= 9999;
                                                            }
                                                            break;

                                                        }
                                                        catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {room.ItemList[effectedItemNum - 1].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised..."); break; }
                                                    }
                                                }
                                                catch { Console.WriteLine("Please enter the number corresponding to the list above!"); }
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("You've no items in your backpack!");
                                        }
                                        if (player.Speedy && speedyturn == 0)
                                        {
                                            Console.WriteLine("You don't waste a moment before bounding into your next action...");
                                            break;
                                        }
                                        if (success && !room.FeatureList.Contains(holeInCeiling))
                                        {
                                            Console.WriteLine($"\nIt's not long after your actions take effect before the {Monster.Name} attacks you!");
                                            break;
                                        }
                                        else if (!success && !room.FeatureList.Contains(holeInCeiling))
                                        {
                                            Console.WriteLine($"\nYour actions have only given the {Monster.Name} the opportunity to attack again!");
                                            break;
                                        }
                                        else { break; }
                                    }


                                    // basically you lose a turn       
                                    else if (answer1 == "4" || answer1 == "four")
                                    {
                                        if (player.Speedy && speedyturn == 0)
                                        {
                                            Console.WriteLine("You marvel at how easy it is to dodge incoming attacks as the world moves languidly about you.\nIt's like everyone else is moving underwater while you dart about like a humming bird...");
                                            break;
                                        }
                                        Console.WriteLine($"The {Monster.Name} closes in for another vicious attack!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERROR! Please answer either '1', '2', '3' or '4'.");
                                        continue;
                                    }
                                }
                                if (player.Speedy && speedyturn == 0)
                                {
                                    speedyturn++;
                                    Console.WriteLine($"Do you wish to attack with your {playerWeapon.Name}? ");
                                    continue;
                                }
                            }
                            else
                            {
                                if(answer.Trim().ToLower() == "kill")
                                {
                                    Monster.Stamina = 0;
                                    break;
                                }
                                Console.WriteLine("Please enter either 'yes' or 'no'.");
                                continue;
                            }
                            break;
                        }
                        turn++;
                        continue;
                    }
                }
            }
            if (Player.Stamina > 0)
            {
                Console.WriteLine("Congratulations! You've slain the monster!");
                player.Speedy = false;
                foreach (Weapon w in player.WeaponInventory)
                {
                    if (w.Boon > 9)
                    {
                        w.Boon = 0;
                        if (w.Name == "sword of sealed souls")
                        {
                            w.Boon = 2;
                        }
                        if (player.Traits.ContainsKey("jinxed"))
                        {
                            w.Boon = 6;
                        }
                    }
                }
                return true;
            }
            else if (Monster.Stamina > 0)
            {
                if(Monster.Name == "golden dragon")
                {
                    Console.WriteLine("The dragon's fiery breath cremates you in the blink of an eye. Your smoking boots are all that remains of your folly.");
                    Console.ReadKey(true);
                    Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                    return false;
                }
                Console.WriteLine($"The {Monster.Name}'s last attack proves fatal. You collapse in shameful defeat, a trickle of blood running from your mouth as your limp body drops to its knees. The {Monster.Name} has proven too much for you. Your adventure ends here...");
                Console.ReadKey(true);
                return false;
            }
            else
            {
                Console.WriteLine("The fire consumes you both!");
                Console.ReadKey(true);
                return false;
            }
        }
        public bool Fight(bool music, Dictionary<Item, List<Item>> usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, Room room, Player player, Dictionary<Item, List<Player>> usesDictionaryItemChar, bool dualBattle, Feature holeInCeiling, List<Item> specialItems, bool fire = false, bool _initiative = false, bool masked = false)
        {
            player = Player;
            Dice D2 = new Dice(2);
            Dice D3 = new Dice(3);
            Dice D4 = new Dice(4);
            Dice D5 = new Dice(5);
            Dice D6 = new Dice(6);
            //pugilism is FormatException the players unhanded fighting capability
            List<Dice> pugilism = new List<Dice>();
            int i = 0;
            string another = "a";
            while (i < (2 + Player.Skill) / 3)
            {
                if (i < 2)
                {
                    pugilism.Add(D2);
                }
                else if (i < 3)
                {
                    pugilism.Add(D3);
                }
                else
                {
                    pugilism.Add(D5);
                }
                i++;
            }
            if (fire)
            {
                List<string> fireString = new List<string>
                    {
                        "blazing ",
                        "burning ",
                        "smouldering ",
                        "smoking ",
                        "fiery "
                    };
                int firenum = D5.Roll(D5);
                foreach (Feature x in room.FeatureList)
                {
                    firenum = D5.Roll(D5);
                    Thread.Sleep(7);
                    x.Name = $"{fireString[firenum - 1]}{x.Name}";
                }
                foreach (Item x in room.ItemList)
                {
                    firenum = D5.Roll(D5);
                    Thread.Sleep(3);
                    x.Name = $"{fireString[firenum - 1]}{x.Name}";
                }

                room.Name = "cell";
                room.Name = $"{fireString[firenum - 1]}{room.Name}";
            }
            List<string> jinxedMisses = new List<string>
            {
                $"The {Monster.Name} has you now! Finally, relishing it's soon-to-be freedom from your cursed, jinxy hide, it raises its {Monster.Items[0].Name} to strike... and gets it stuck in the {room.FeatureList[D4.Roll(D4) - 1].Name}. You scurry away as the {Monster.Name} curses, trying to free it. \nThe {Monster.Name} loses 1 stamina.",
                $"The ever-increasingly vexed {Monster.Name} attacks, misses, and gets really bad tennis-elbow. Ooh! that's gotta hurt... \nThe {Monster.Name} loses 2 stamina.",
                $"The {Monster.Name} lunges at you! As you trip over yourself, clumsily scrambling for cover, you hear a tremendous crash. \nThe {Monster.Name} ran into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Ow! It loses 5 Stamina.",
                $"The {Monster.Name} at last has you pinned. It looms over you with a leer, ready to deliver the killing blow, when part of the {room.Name}'s ceiling caves in upon its head. \nThe {Monster.Name} loses 7 stamina!",
                $"The {Monster.Name} bellows a string of foul curses as each frenzied attack miraculously leaves you unscathed. It bites its own tongue in the process. Youch! \nAs you slip away, the {Monster.Name} loses 1 stamina...",
                $"The {Monster.Name} bounds after you in circles, flailing wildly. It careers into a {room.ItemList[D3.Roll(D3) - 1].Name}, grazing its knee. Oof! That's a nasty splinter! \nThe {Monster.Name} loses 3 stamina.",
                $"You stammer as you try reasoning with the {Monster.Name}. Surely you can just talk things out over a lovely cup of mead... The {Monster.Name} doesn't listen. It lunges at you, only to crash into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Yikes! \nThe {Monster.Name} loses 11 stamina.",
                $"In frustration the {Monster.Name} hurls its {Monster.Items[0].Name} at you! It bounces off your armour back at the {Monster.Name}. \n The {Monster.Name} loses 6 stamina.",
                $"The {Monster.Name} attacks wildly, wanting nothing more than to end the whirlwind of chaos your ill-fortune brings. It trips. Ouch! That's going to need a bandage... \nThe {Monster.Name} loses 7 stamina.",
                $"The {Monster.Name} at last has you cornered. It looms over you with a leer, ready to at last deliver the killing blow. Then the {room.Name}'s ceiling caves in.\n The {Monster.Name}'s engulfed by an avalanche of cascading debris. A trickle of dust takes a moment to stop. Then finally, one loose floorboard topples from the floor above and crowns the heap."
            };
            List<String> pugilismCritHits = new List<String>
                {
                $"Extending your palm into a spear-like thrust, you strike the {Monster.Name}'s chest cavity. Their ribs shatter as your hand plunges deep inside. An instant later your fist is clenched around their still beating heart, held before their awed eyes just before the light leaves them forever.",
                $"The {Monster.Name} charges towards you. With cat-like reflexes you assume the 'soaring crane' position practiced by martial monks of old. You serenely close your eyes to the {Monster.Name}'s battle roar, silencing your mind. When you open them again, you've landed with uncanny grace back on your feet. Your whirlwind kick has sent the {Monster.Name} sailing through the air. They're not done yet, but it won't be long...",
                $"The {Monster.Name}'s guard is just strong enough to turn your killer karate chop, into a nevertheless brutal strike. The {Monster.Name} is left winded and greviously wounded.",
                $"A bead of cold sweat traces your brow as you're forced to admit that even your lethal hands are struggling to find any weak spot to exploit. Your best blows have yet to slow the {Monster.Name} down. It seems its anger has only increased.",
                $"After a series quick jabs to the ribs, the {Monster.Name}'s guard collapses. You seize your chance, landing a powerful blow across its jaw. There's an audible crack as the {Monster.Name}'s neck snaps. With its head twisted 180 degrees the wrong way, it collapses backwards (forwards?) as stiff as a board to the floor.",
                $"You rain haymaker after haymaker down upon the {Monster.Name}. With one dislocated limb, they still manage to somehow wheel away from you before you can land the killing blow. They stagger to their feet.",
                $"Your uppercut drives deep into the {Monster.Name}'s gut. It is left wheezing for breath. For a moment it looks like it might collapse to its knees. But slowly it rises up again to continue the fight...",
                $"You land blow after blow, but the {Monster.Name} appears to be able to tap into ever more reserves of stamina. This fight may go either way yet... ",
                $"Your flailing fists chance a lucky blow. The {Monster.Name}'s nose splinters as it charges into your fist, it's momentum rather than your own felling the creature. Its brain is pulverised as bone fragments ricochet inside its skull. A portion of its brain dribbles from its nostril, before it keels over.",
                $"Your blows are almost effortlessly deflected by the {Monster.Name}, until your elbow clobbers them over the head. The {Monster.Name} looks like it might suffer a concussion, but even this fortunate hit isn't enough to finish them yet...",
                $"You trip over your own foot, but somehow the {Monster.Name} comes out the worst for it! Their blow sails over your head, sending them off balance and toppling to the ground. You manage to land a few kicks into their back before they get up again.",
                $"You kick the {Monster.Name}'s shins as it makes to grapple you. Despite your amateurish attacks, you've caused it a lot of pain. However, it has done little to end this fight.",
                $"Cornered, you duck the {Monster.Name}'s devastating blow, before scrambling along the floor under its feet. As it scrambles for your ankles, gazing at you through its own legs, something cracks. The {Monster.Name}'s back locks in place! It topples over in a knot of limbs. You flail at it with your wimpy wrists until it expires.",
                $"Something gets stuck in your eye. Groping blindly you run into the {Monster.Name}. Somehow this turns into a devastating body slam. The {Monster.Name} staggers to its feet, rueing the day it met you...",
                $"Your oafish attacks rarely land, until you tumble. Your flailing foot clumsily connects with the {Monster.Name}'s nethers. Weapon raised, they continue to aggressively... waddle towards you.",
                $"You nip the {Monster.Name}'s fingers as it grapples you. As you slip away it trips over its own feet. Ouch! The {Monster.Name} looks more infuriated than ever as it continues scrambling after you around the room."
                };
            List<String> pugilismGoodHits = new List<String>
                {
                $"Your scissor kick finally puts the {Monster.Name}'s lights out.",
                $"You execute a flawless palm strike. {Monster.Name} is close to death.",
                $"You deliver a series of crushing hammer-fist blows to the {Monster.Name}.",
                $"You administer a flurry of lightning jabs to the {Monster.Name}'s pressure points.",
                $"Your sucker punch lifts the {Monster.Name} off their feet. They don't get back up.",
                $"A crude but powerful push kick sends the {Monster.Name} crashing to the floor.",
                $"A flurry of light jabs rearranges the {Monster.Name}'s face.",
                $"Your punches have been strong, but you'll require something better yet to defeat this foe",
                $"One final, solid punch sends the {Monster.Name} tottering over. They are finally vanquished.",
                $"Your unrefined pugilism has somehow reduced the {Monster.Name} to its final shred of life.",
                $"Your fist blow has for once wholly bypassed the {Monster.Name}'s defences.",
                $"You chance a lucky hit, but not lucky enough - the {Monster.Name} remains unfazed. You're going to have to really pull something out of the bag to win this fight...",
                $"Your jinxed nature rubs off on your adversary. The {Monster.Name} somehow clobbers itself over the noggin. It's head topples from its shoulders.",
                $"In a strange twist of fate, the {Monster.Name} injures itself with its {Monster.Veapon.Name} as it chases you around in circles.",
                $"The {Monster.Name} keeps stepping on loose floorboards... Then steps on a nail. Yeesh!",
                $"The {Monster.Name} steps on a loose floorboard. It whacks them in the face. Ouch!"
                };
            List<string> jinxedMisses2 = new List<string>
            {
                $"The {Monster2.Name} has you now! Finally, relishing it's soon-to-be freedom from your cursed, jinxy hide, it raises its {Monster2.Items[0].Name} to strike... and gets it stuck in the {room.FeatureList[D4.Roll(D4) - 1].Name}. You scurry away as the {Monster2.Name} curses, trying to free it. \nThe {Monster2.Name} loses 1 stamina.",
                $"The ever-increasingly vexed {Monster2.Name} attacks, misses, and gets really bad tennis-elbow. Ooh! that's gotta hurt... \nThe {Monster2.Name} loses 2 stamina.",
                $"The {Monster2.Name} lunges at you! As you trip over yourself, clumsily scrambling for cover, you hear a tremendous crash. \nThe {Monster2.Name} ran into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Ow! It loses 5 Stamina.",
                $"The {Monster2.Name} at last has you pinned. It looms over you with a leer, ready to deliver the killing blow, when part of the {room.Name}'s ceiling caves in upon its head. \nThe {Monster2.Name} loses 7 stamina!",
                $"The {Monster2.Name} bellows a string of foul curses as each frenzied attack miraculously leaves you unscathed. It bites its own tongue in the process. Youch! \nAs you slip away, the {Monster2.Name} loses 1 stamina...",
                $"The {Monster2.Name} bounds after you in circles, flailing wildly. It careers into a {room.ItemList[D3.Roll(D3) - 1].Name}, grazing its knee. Oof! That's a nasty splinter! \nThe {Monster2.Name} loses 3 stamina.",
                $"You stammer as you try reasoning with the {Monster2.Name}. Surely you can just talk things out over a lovely cup of mead... The {Monster2.Name} doesn't listen. It lunges at you, only to crash into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Yikes! \nThe {Monster2.Name} loses 11 stamina.",
                $"In frustration the {Monster2.Name} hurls its {Monster2.Items[0].Name} at you! It bounces off your armour back at the {Monster2.Name}. \n The {Monster2.Name} loses 6 stamina.",
                $"The {Monster2.Name} attacks wildly, wanting nothing more than to end the whirlwind of chaos your ill-fortune brings. It trips. Ouch! That's going to need a bandage... \nThe {Monster2.Name} loses 7 stamina.",
                $"The {Monster2.Name} at last has you cornered. It looms over you with a leer, ready to at last deliver the killing blow. Then the {room.Name}'s ceiling caves in.\n The {Monster2.Name}'s engulfed by an avalanche of cascading debris. A trickle of dust takes a moment to stop. Then finally, one loose floorboard topples from the floor above and crowns the heap."
            };
            List<String> pugilismCritHits2 = new List<String>
                {
                $"Extending your palm into a spear-like thrust, you strike the {Monster2.Name}'s chest cavity. Their ribs shatter as your hand plunges deep inside. An instant later your fist is clenched around their still beating heart, held before their awed eyes just before the light leaves them forever.",
                $"The {Monster2.Name} charges towards you. With cat-like reflexes you assume the 'soaring crane' position practiced by martial monks of old. You serenely close your eyes to the {Monster2.Name}'s battle roar, silencing your mind. When you open them again, you've landed with uncanny grace back on your feet. Your whirlwind kick has sent the {Monster2.Name} sailing through the air. They're not done yet, but it won't be long...",
                $"The {Monster2.Name}'s guard is just strong enough to turn your killer karate chop, into a nevertheless brutal strike. The {Monster2.Name} is left winded and greviously wounded.",
                $"A bead of cold sweat traces your brow as you're forced to admit that even your lethal hands are struggling to find any weak spot to exploit. Your best blows have yet to slow the {Monster2.Name} down. It seems its anger has only increased.",
                $"After a series quick jabs to the ribs, the {Monster2.Name}'s guard collapses. You seize your chance, landing a powerful blow across its jaw. There's an audible crack as the {Monster2.Name}'s neck snaps. With its head twisted 180 degrees the wrong way, it collapses backwards (forwards?) as stiff as a board to the floor.",
                $"You rain haymaker after haymaker down upon the {Monster2.Name}. With one dislocated limb, they still manage to somehow wheel away from you before you can land the killing blow. They stagger to their feet.",
                $"Your uppercut drives deep into the {Monster2.Name}'s gut. It is left wheezing for breath. For a moment it looks like it might collapse to its knees. But slowly it rises up again to continue the fight...",
                $"You land blow after blow, but the {Monster2.Name} appears to be able to tap into ever more reserves of stamina. This fight may go either way yet... ",
                $"Your flailing fists chance a lucky blow. The {Monster2.Name}'s nose splinters as it charges into your fist, it's momentum rather than your own felling the creature. Its brain is pulverised as bone fragments ricochet inside its skull. A portion of its brain dribbles from its nostril, before it keels over.",
                $"Your blows are almost effortlessly deflected by the {Monster2.Name}, until your elbow clobbers them over the head. The {Monster2.Name} looks like it might suffer a concussion, but even this fortunate hit isn't enough to finish them yet...",
                $"You trip over your own foot, but somehow the {Monster2.Name} comes out the worst for it! Their blow sails over your head, sending them off balance and toppling to the ground. You manage to land a few kicks into their back before they get up again.",
                $"You kick the {Monster2.Name}'s shins as it makes to grapple you. Despite your amateurish attacks, you've caused it a lot of pain. However, it has done little to end this fight.",
                $"Cornered, you duck the {Monster2.Name}'s devastating blow, before scrambling along the floor under its feet. As it scrambles for your ankles, gazing at you through its own legs, something cracks. The {Monster2.Name}'s back locks in place! It topples over in a knot of limbs. You flail at it with your wimpy wrists until it expires.",
                $"Something gets stuck in your eye. Groping blindly you run into the {Monster2.Name}. Somehow this turns into a devastating body slam. The {Monster2.Name} staggers to its feet, rueing the day it met you...",
                $"Your oafish attacks rarely land, until you tumble. Your flailing foot clumsily connects with the {Monster2.Name}'s nethers. Weapon raised, they continue to aggressively... waddle towards you.",
                $"You nip the {Monster2.Name}'s fingers as it grapples you. As you slip away it trips over its own feet. Ouch! The {Monster2.Name} looks more infuriated than ever as it continues scrambling after you around the room."
                };
            List<String> pugilismGoodHits2 = new List<String>
                {
                $"Your scissor kick finally puts the {Monster2.Name}'s lights out.",
                $"You execute a flawless palm strike. {Monster2.Name} is close to death.",
                $"You deliver a series of crushing hammer-fist blows to the {Monster2.Name}.",
                $"You administer a flurry of lightning jabs to the {Monster2.Name}'s pressure points.",
                $"Your sucker punch lifts the {Monster2.Name} off their feet. They don't get back up.",
                $"A crude but powerful push kick sends the {Monster2.Name} crashing to the floor.",
                $"A flurry of light jabs rearranges the {Monster2.Name}'s face.",
                $"Your punches have been strong, but you'll require something better yet to defeat this foe",
                $"One final, solid punch sends the {Monster2.Name} tottering over. They are finally vanquished.",
                $"Your unrefined pugilism has somehow reduced the {Monster2.Name} to its final shred of life.",
                $"Your fist blow has for once wholly bypassed the {Monster2.Name}'s defences.",
                $"You chance a lucky hit, but not lucky enough - the {Monster2.Name} remains unfazed. You're going to have to really pull something out of the bag to win this fight...",
                $"Your jinxed nature rubs off on your adversary. The {Monster2.Name} somehow clobbers itself over the noggin. It's head topples from its shoulders.",
                $"In a strange twist of fate, the {Monster2.Name} injures itself with its {Monster2.Veapon.Name} as it chases you around in circles.",
                $"The {Monster2.Name} keeps stepping on loose floorboards... Then steps on a nail. Yeesh!",
                $"The {Monster2.Name} steps on a loose floorboard. It whacks them in the face. Ouch!"
                };
            Weapon playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
            if (Player.Skill < 4)
            {
                playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else if (Player.Skill < 7)
            {
                playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else if (Player.Skill < 10)
            {
                playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else
            {
                playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            //checking to see which weapon player has equipped, otherwise uses fists
            foreach (Weapon y in Player.WeaponInventory)
            {
                if (y is Weapon)
                {
                    if (y.Equipped) { playerWeapon = y; break; }
                }
            }
            foreach (Weapon x in Player.WeaponInventory) { playerWeapon.Boon = 0; }// potion of luck, felix felicis, works for one battle only
            if (player.Traits.ContainsKey("jinxed"))
            {
                //
                ///Boon slides the probability curve to the players favour during dice rolls
                ///a boon of 6 increases the chance to hit, the chance the monster misses, and the
                ///likelihood of crit Hits by 30% or 25% (because we use a D20)
                //
                playerWeapon.Boon = 6;

            }
            List<String> defaultCritHits = new List<String>
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
            List<String> defaultGoodHits = new List<String>
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

            Console.WriteLine($"{Monster.Description} \nMeanwhile, {Monster2.Description}");
            if (fire)
            {
                Console.WriteLine($"The {Monster.Name} doesn't recoil from the heat. A veteran of many pillages and raids, the goblin is undaunted by fire and immune to the choking smoke...\nBut you aren't!\nYou'll suffer damage for each turn this fight lasts!");
            }
            Dice D20 = new Dice(20);
            bool initiative = false;
            if ((Player.Skill + D20.Roll(D20) >= Monster.Skill + D20.Roll(D20) && !fire && Player.Skill + D20.Roll(D20) >= Monster2.Skill + D20.Roll(D20)) || _initiative)
            {
                Console.WriteLine($"The {Monster.Name} and {Monster2.Name} are caught off guard. You take the initiative!");
                initiative = true;
            }
            else
            {
                Console.WriteLine($"Your reactions aren't fast enough. The enemy takes the initiative!");
            }
            int turn = 0;
            int round = 0;
            bool attackedMonster2 = false;
            long setTime = 2000;
            int speedyturn = 0;
            if (initiative)
            {
                int damageDealt = 0;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine($"Do you attack... \n[1] the {Monster.Name}\n[2] or the {Monster2.Name}?\n[You've only 2 seconds to decide and give your answer the moment you press any key]");
                Console.ReadKey();
                while (true)
                {
                    long timeLapsed = 0;
                    
                    if (player.Speedy)
                    {
                        setTime = 4000;
                    }
                    string answer = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(answer))
                    {
                        continue;
                    }
                    try
                    {
                        int answer1 = int.Parse(answer);
                        if (answer1 < 1 || answer1 > 2)
                        {
                            Console.WriteLine("Please enter 1 or 2...");
                            continue;
                        }
                        else if (answer1 == 1)
                        {
                            stopwatch.Stop();
                            timeLapsed = stopwatch.ElapsedMilliseconds;
                            if (timeLapsed < setTime)
                            {
                                damageDealt = playerWeapon.Attack(Player.Skill, Monster.Skill, Monster.Stamina, true, Monster, player, another, room, holeInCeiling);
                                Monster.Stamina -= damageDealt;
                                Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");
                                turn = 1;
                                attackedMonster2 = false;
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                
                                Console.WriteLine("Too late! Your enemies attack!");
                                initiative = false;
                                break;
                            }
                        }
                        else
                        {
                            stopwatch.Stop();
                            timeLapsed = stopwatch.ElapsedMilliseconds;
                            if (timeLapsed < setTime)
                            {
                                damageDealt = playerWeapon.Attack(Player.Skill, Monster2.Skill, Monster2.Stamina, true, Monster2, player, another, room, holeInCeiling);
                                Monster2.Stamina -= damageDealt;
                                Console.WriteLine($"The {Monster2.Name} lost {damageDealt} points of stamina!");
                                turn = 1;
                                attackedMonster2 = true;
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Too late! Your enemies attack!");
                                initiative = false;
                                break;
                            }
                        }

                    }
                    catch { Console.WriteLine("Please enter a number corresponding to your choice"); continue; }
                    
                    
                }
                
            }

            while ((Monster.Stamina > 0 || Monster2.Stamina >0) && Player.Stamina > 0)
            {
                bool start = false;
                

                if (turn == 0)
                {
                    start = true;
                }
                if (Monster2.Stamina < 1 && Monster.Stamina < 1)
                {
                    break;
                }
                else if (Monster2.Stamina < 1)
                {
                    attackedMonster2 = false;
                }
                else if (Monster.Stamina < 1)
                {
                    attackedMonster2 = true;
                }
                int damageDealt = 0;
                if (!attackedMonster2)
                {
                    if (Monster.Stamina > 0)
                    {

                        damageDealt = Monster.Veapon.Attack(Monster.Skill, Player.Skill, Player.Stamina, false, Monster, player, another, room, holeInCeiling, 1, start, attackedMonster2);
                        if (damageDealt >= 0)
                        {
                            Player.Stamina -= damageDealt;
                            Console.WriteLine($"You've lost {damageDealt} points of stamina!");
                        }
                        else if (damageDealt < 0)
                        {

                            Monster.Stamina += damageDealt;

                        }
                        Console.ReadKey(true);
                    }
                    if (Monster2.Stamina > 0)
                    {
                        Console.WriteLine($"While you're distracted the {Monster2.Name} attacks!");
                        damageDealt = Monster2.Veapon.Attack(Monster2.Skill, Player.Skill, Player.Stamina, false, Monster2, player, another, room, holeInCeiling, 1, start, !attackedMonster2);
                        if (damageDealt >= 0)
                        {
                            Player.Stamina -= damageDealt;
                            Console.WriteLine($"You've lost {damageDealt} points of stamina!");
                        }
                        else if (damageDealt < 0)
                        {

                            Monster2.Stamina += damageDealt;

                        }
                    }
                }
                else
                {
                    if (Monster2.Stamina > 0)
                    {
                        damageDealt = Monster2.Veapon.Attack(Monster2.Skill, Player.Skill, Player.Stamina, false, Monster2, player, another, room, holeInCeiling, 1, start, !attackedMonster2);
                        if (damageDealt >= 0)
                        {
                            Player.Stamina -= damageDealt;
                            Console.WriteLine($"You've lost {damageDealt} points of stamina!");
                        }
                        else if (damageDealt < 0)
                        {

                            Monster2.Stamina += damageDealt;

                        }
                        Console.ReadKey(true);
                    }
                    if (Monster.Stamina > 0)
                    {
                        Console.WriteLine($"While you're distracted the {Monster.Name} strikes!");
                        damageDealt = Monster.Veapon.Attack(Monster.Skill, Player.Skill, Player.Stamina, false, Monster, player, another, room, holeInCeiling, 1, start, attackedMonster2);
                        if (damageDealt >= 0)
                        {
                            Player.Stamina -= damageDealt;
                            Console.WriteLine($"You've lost {damageDealt} points of stamina!");
                        }
                        else if (damageDealt < 0)
                        {

                            Monster.Stamina += damageDealt;

                        }
                    }
                }
                if (Monster.Stamina < 1 && Monster2.Stamina < 1) { break; }
                if (Player.Stamina < 1) { break; }
                if (round == 0 && fire)
                {
                    round++;
                }
                else if (round < 2 && fire)
                {
                    Console.WriteLine("The smouldering flames plume with smoke, stinging your eyes!");
                    int burnt = D5.Roll(D5);
                    Player.Stamina -= burnt;
                    Console.WriteLine($"You lost {burnt} stamina!");
                    round++;
                }
                else if (round < 3 && fire)
                {
                    Console.WriteLine($"The {room.Name} swells with smoke. You splutter and cough as the {Monster.Name}'s {Monster.Veapon.Name} slashes at you through the swirling haze!");
                    int burnt = D5.Roll(D5) + D3.Roll(D3);
                    Player.Stamina -= burnt;
                    Console.WriteLine($"You lost {burnt} stamina!");
                    round++;
                }
                else if (round < 4 && fire)
                {
                    Console.WriteLine($"The flames in the {room.Name} now begin to roar as they climb the walls!");
                    int burnt = D5.Roll(D5) + D3.Roll(D3) + D5.Roll(D5);
                    player.Stamina -= burnt;
                    Console.WriteLine($"You lost {burnt} stamina!");
                    round++;
                }
                else if (round < 5 && fire)
                {
                    Console.WriteLine($"The fire shows no sign of stopping. If you don't hurry t won't matter who wins this fight - the flames will engulf you both!");
                    int burnt = D5.Roll(D5) + D3.Roll(D3) + D5.Roll(D3) + D4.Roll(D4);
                    player.Stamina -= burnt;
                    Console.WriteLine($"You lost {burnt} stamina!");
                    round++;
                }
                else if (round < 6 && fire)
                {
                    Console.WriteLine("Between parries and blows you can only gaze in horror as the fire turns into a raging inferno. You hold your breath, your lungs aching for air...");
                    int burnt = D5.Roll(D5) + D3.Roll(D3) + D5.Roll(D3) + D4.Roll(D4) + D3.Roll(D3);
                    player.Stamina -= burnt;
                    Console.WriteLine($"You've lost {burnt} stamina!");
                    round++;
                }
                else if (round < 7 && fire)
                {
                    Console.WriteLine("The blazing cell begins to spin around you as you fight with mounting desperation. Flames lick at your exposed skin. You feel the hairs on the back of your neck singe.");
                    int burnt = D5.Roll(D5) + D3.Roll(D3) + D5.Roll(D3) + D4.Roll(D4) + D3.Roll(D3);
                    player.Stamina -= burnt;
                    Console.WriteLine($"You've lost {burnt} stamina!");
                    round++;
                }
                else if (round < 8 && fire)
                {
                    Console.WriteLine("You can hold your breath no longer! You begin inhaling the smoke only to stagger and splutter in a fit of hacking coughs. You can scarcely dodge the enemy's attacks as you double over, the furnace-like heat beating against you relentlessly from all sides.\n The end is near...");
                    int burnt = D5.Roll(D5);
                    player.Stamina -= burnt;
                    if (player.Skill > 2)
                    {
                        player.Skill -= 2;
                    }
                    Console.WriteLine($"You've lost {burnt} stamina and 2 skill points!");
                    round++;
                }
                else if (fire)
                {
                    int burnt = 9999;
                    player.Stamina -= burnt;
                    if (Monster.Stamina > 0)
                    {
                        Monster.Stamina -= burnt;
                    }
                    Console.WriteLine($"The flames finally envelop and engulf your body. If there is one small mercy, it is that cremation is a far kinder fate than what your captors had in store for you, not that you'll ever know what that would've been...");
                }
                Console.ReadKey(true);
                if (Monster.Stamina < 1 && Monster2.Stamina < 1) { break; }
                if (Player.Stamina < 1) { break; }

                Console.WriteLine(Player.DescribeStamina());
                Console.Write($"Do you wish to continue attacking with your {playerWeapon.Name}? ");
                bool skipPlayerTurn = false;
                speedyturn = 0;
                while (true)
                {
                    string answer = Console.ReadLine().Trim().ToLower();
                    // attack with weapon
                    if (answer == "yes" || answer == "y")
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        //stopwatch.Start();
                        if (Monster.Stamina > 0 && Monster2.Stamina > 0)
                        {
                            if (!player.Speedy) 
                            { 
                                Console.WriteLine($"Do you attack... \n[1] the {Monster.Name}\n[2] or the {Monster2.Name}?\n[You've only 3 seconds to decide]");
                            }
                            else
                            {
                                Console.WriteLine($"Do you attack... \n[1] the {Monster.Name}\n[2] or the {Monster2.Name}?\n[Thanks to your potion of alacrity, you've 6 seconds to decide]");
                            }
                            setTime = 3000;
                            if (player.Speedy)
                            {
                                setTime = 6000;
                            }
                            stopwatch.Start();
                            
                            while (true)
                            {
                                long timeLapsed = 0;
                                answer = Console.ReadLine().Trim().ToLower();
                                if (string.IsNullOrWhiteSpace(answer))
                                {
                                    continue;
                                }
                                try
                                {
                                    int answer1 = int.Parse(answer);
                                    if (answer1 < 1 || answer1 > 2)
                                    {
                                        Console.WriteLine("Please enter 1 or 2...");
                                        continue;
                                    }
                                    else if (answer1 == 1)
                                    {
                                        stopwatch.Stop();
                                        timeLapsed = stopwatch.ElapsedMilliseconds;
                                        if (timeLapsed < setTime)
                                        {
                                            pugilism = new List<Dice>();
                                            i = 0;
                                            while (i < (2 + Player.Skill) / 3)
                                            {
                                                if (i < 2)
                                                {
                                                    pugilism.Add(D2);
                                                }
                                                else if (i < 3)
                                                {
                                                    pugilism.Add(D3);
                                                }
                                                else
                                                {
                                                    pugilism.Add(D5);
                                                }
                                                i++;
                                            }
                                            if (playerWeapon.Boon > 9)
                                            {
                                                if (Player.Skill < 4)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                                }
                                                else if (Player.Skill < 7)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                                }
                                                else if (Player.Skill < 10)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                                }
                                                else
                                                {
                                                    playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                                }
                                            }
                                            else
                                            {
                                                if (Player.Skill < 4)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
                                                }
                                                else if (Player.Skill < 7)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
                                                }
                                                else if (Player.Skill < 10)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
                                                }
                                                else
                                                {
                                                    playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
                                                }
                                            }
                                            foreach (Weapon y in Player.WeaponInventory)
                                            {
                                                if (y.Equipped) { playerWeapon = y; break; }
                                            }
                                            if (playerWeapon.Boon < 10 && player.Traits.ContainsKey("jinxed"))
                                            {
                                                playerWeapon.Boon = 6;
                                            }

                                            damageDealt = playerWeapon.Attack(Player.Skill, Monster.Skill, Monster.Stamina, true, Monster, player, another, room, holeInCeiling);
                                            Monster.Stamina -= damageDealt;
                                            
                                            Console.WriteLine("\n");
                                            if (damageDealt > 0)
                                            {
                                                Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");
                                                if (player.Speedy && speedyturn == 0)
                                                {
                                                    Console.WriteLine("You dart into your next speedy action!");
                                                    
                                                }
                                                attackedMonster2 = false;
                                                Console.ReadKey(true);
                                                break;
                                            }
                                            else
                                            {
                                                if (player.Speedy && speedyturn == 0)
                                                {
                                                    Console.WriteLine("You dart into your next speedy action!");
                                                    Console.ReadKey(true);
                                                    break;
                                                }
                                                turn = -1;
                                                Console.WriteLine($"{Monster.Name} seizes their chance to attack!");
                                                attackedMonster2 = false;
                                                Console.ReadKey(true);
                                                break;
                                            }
                                            
                                        }
                                        else
                                        {
                                            if (player.Speedy && speedyturn == 0)
                                            {
                                                Console.WriteLine("You take a leisurely 30 mph sprint around the room before you dart into your next speedy action!");
                                                skipPlayerTurn = true;
                                                Console.ReadKey(true);
                                                break;
                                            }
                                            Console.WriteLine("Too late! Your enemies attack!");
                                            skipPlayerTurn = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        stopwatch.Stop();
                                        timeLapsed = stopwatch.ElapsedMilliseconds;
                                        if (timeLapsed < setTime)
                                        {
                                            pugilism = new List<Dice>();
                                            i = 0;
                                            while (i < (2 + Player.Skill) / 3)
                                            {
                                                if (i < 2)
                                                {
                                                    pugilism.Add(D2);
                                                }
                                                else if (i < 3)
                                                {
                                                    pugilism.Add(D3);
                                                }
                                                else
                                                {
                                                    pugilism.Add(D5);
                                                }
                                                i++;
                                            }
                                            if (playerWeapon.Boon > 9)
                                            {
                                                if (Player.Skill < 4)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits2, pugilismGoodHits2, 10);
                                                }
                                                else if (Player.Skill < 7)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits2, pugilismGoodHits2, 10);
                                                }
                                                else if (Player.Skill < 10)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits2, pugilismGoodHits2, 10);
                                                }
                                                else
                                                {
                                                    playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits2, pugilismGoodHits2, 10);
                                                }
                                            }
                                            else
                                            {
                                                if (Player.Skill < 4)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits2, pugilismGoodHits2);
                                                }
                                                else if (Player.Skill < 7)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits2, pugilismGoodHits2);
                                                }
                                                else if (Player.Skill < 10)
                                                {
                                                    playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits2, pugilismGoodHits2);
                                                }
                                                else
                                                {
                                                    playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits2, pugilismGoodHits2);
                                                }
                                            }
                                            foreach (Weapon y in Player.WeaponInventory)
                                            {
                                                if (y.Equipped) { playerWeapon = y; break; }
                                            }
                                            if (playerWeapon.Boon < 10 && player.Traits.ContainsKey("jinxed"))
                                            {
                                                playerWeapon.Boon = 6;
                                            }
                                            
                                            damageDealt = playerWeapon.Attack(Player.Skill, Monster2.Skill, Monster2.Stamina, true, Monster2, player, another, room, holeInCeiling);
                                            Monster2.Stamina -= damageDealt;

                                            Console.WriteLine("\n");
                                            
                                            if (damageDealt > 0)
                                            {
                                                Console.WriteLine($"The {Monster2.Name} lost {damageDealt} points of stamina!");
                                                if (player.Speedy && speedyturn == 0)
                                                {
                                                    Console.WriteLine("You dart into your next speedy action!");
                                                    Console.ReadKey(true);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (player.Speedy && speedyturn == 0)
                                                {
                                                    Console.WriteLine("You dart into your next speedy action!");
                                                    Console.ReadKey(true);
                                                    break;
                                                }
                                                turn = -1;

                                                Console.WriteLine($"{Monster2.Name} seizes their chance to attack!");
                                            }
                                            attackedMonster2 = true;
                                            Console.ReadKey(true);
                                            break;
                                        }
                                        else
                                        {
                                            if (player.Speedy && speedyturn == 0)
                                            {
                                                Console.WriteLine("You take a leisurely 30 mph sprint around the room before you dart into your next speedy action!");
                                                skipPlayerTurn = true;
                                                Console.ReadKey(true);
                                                break;
                                            }
                                            Console.WriteLine("Too late! Your enemies attack!");
                                            skipPlayerTurn = true;
                                            break;
                                        }
                                    }

                                }
                                catch { Console.WriteLine("Please enter a number corresponding to your choice"); continue; }
                            }
                            if (skipPlayerTurn)
                            {
                                turn = 0;
                                break;
                            }
                        }
                        else if (Monster.Stamina > 0)
                        {
                            pugilism = new List<Dice>();
                            i = 0;
                            while (i < (2 + Player.Skill) / 3)
                            {
                                if (i < 2)
                                {
                                    pugilism.Add(D2);
                                }
                                else if (i < 3)
                                {
                                    pugilism.Add(D3);
                                }
                                else
                                {
                                    pugilism.Add(D5);
                                }
                                i++;
                            }
                            if (playerWeapon.Boon > 9)
                            {
                                if (Player.Skill < 4)
                                {
                                    playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                }
                                else if (Player.Skill < 7)
                                {
                                    playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                }
                                else if (Player.Skill < 10)
                                {
                                    playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                }
                                else
                                {
                                    playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                }
                            }
                            else
                            {
                                if (Player.Skill < 4)
                                {
                                    playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
                                }
                                else if (Player.Skill < 7)
                                {
                                    playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
                                }
                                else if (Player.Skill < 10)
                                {
                                    playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
                                }
                                else
                                {
                                    playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
                                }
                            }
                            foreach (Weapon y in Player.WeaponInventory)
                            {
                                if (y.Equipped) { playerWeapon = y; break; }
                            }
                            if (playerWeapon.Boon < 10 && player.Traits.ContainsKey("jinxed"))
                            {
                                playerWeapon.Boon = 6;
                            }

                            damageDealt = playerWeapon.Attack(Player.Skill, Monster.Skill, Monster.Stamina, true, Monster, player, another, room, holeInCeiling);
                            Monster.Stamina -= damageDealt;

                            Console.WriteLine("\n");
                            if (damageDealt > 0)
                            {
                                Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");
                                if (player.Speedy && speedyturn == 0)
                                {
                                    Console.WriteLine("Before your enemy can react you've already darted into your next action!");

                                    
                                }
                                Console.ReadKey(true);
                                break;
                            }
                            else 
                            {
                                if(player.Speedy && speedyturn == 0)
                                {
                                    Console.WriteLine("Before your enemy can react you've already darted into your next action!");

                                    Console.ReadKey(true);
                                    break;
                                }
                                turn = -1;
                                Console.WriteLine($"{Monster.Name} seizes their chance to attack!");
                                Console.ReadKey(true);
                                break;
                            }
                            
                            
                        }
                        else if (Monster2.Stamina > 0)
                        {
                            pugilism = new List<Dice>();
                            i = 0;
                            while (i < (2 + Player.Skill) / 3)
                            {
                                if (i < 2)
                                {
                                    pugilism.Add(D2);
                                }
                                else if (i < 3)
                                {
                                    pugilism.Add(D3);
                                }
                                else
                                {
                                    pugilism.Add(D5);
                                }
                                i++;
                            }
                            if (playerWeapon.Boon > 9)
                            {
                                if (Player.Skill < 4)
                                {
                                    playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                }
                                else if (Player.Skill < 7)
                                {
                                    playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                }
                                else if (Player.Skill < 10)
                                {
                                    playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                }
                                else
                                {
                                    playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                                }
                            }
                            else
                            {
                                if (Player.Skill < 4)
                                {
                                    playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
                                }
                                else if (Player.Skill < 7)
                                {
                                    playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
                                }
                                else if (Player.Skill < 10)
                                {
                                    playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
                                }
                                else
                                {
                                    playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
                                }
                            }
                            foreach (Weapon y in Player.WeaponInventory)
                            {
                                if (y.Equipped) { playerWeapon = y; break; }
                            }
                            if (playerWeapon.Boon < 10 && player.Traits.ContainsKey("jinxed"))
                            {
                                playerWeapon.Boon = 6;
                            }

                            damageDealt = playerWeapon.Attack(Player.Skill, Monster2.Skill, Monster2.Stamina, true, Monster2, player, another, room, holeInCeiling);
                            Monster2.Stamina -= damageDealt;

                            Console.WriteLine("\n");
                            if (damageDealt > 0)
                            {
                                Console.WriteLine($"The {Monster2.Name} lost {damageDealt} points of stamina!");
                                if (player.Speedy && speedyturn == 0)
                                {
                                    Console.WriteLine("Your enemy can scarcely react before you dart into your next action!");
                                                                       
                                }
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                if (player.Speedy && speedyturn == 0)
                                {
                                    Console.WriteLine("Your enemy can scarcely react before you dart into your next action!");

                                    Console.ReadKey(true);
                                    break;
                                }
                                turn = -1;

                                Console.WriteLine($"{Monster2.Name} seizes their chance to attack!");
                                Console.ReadKey(true);
                                break;
                            }
                            
                        }
                    }
                    // try some other tactic
                    else if ((answer == "no") || (answer == "n"))
                    {
                        turn = -1;
                        Console.WriteLine("Will you spend your turn \n[1] Equipping a new weapon?\n[2] Unequipping your weapon?\n[3] Using one of your items on something or someone?\n[4]Hesitating and considering your choices in life?");
                        while (true)
                        {
                            string answer1 = Console.ReadLine().Trim().ToLower();
                            if (answer1 == "1" || answer1 == "one")
                            {
                                int j = 0;
                                List<Weapon> availableWeapons = new List<Weapon>();
                                foreach (Weapon h in Player.WeaponInventory)
                                {
                                    j++;
                                    if (!h.Equipped)
                                    {
                                        availableWeapons.Add(h);
                                    }
                                }
                                if (j < 1)
                                {
                                    Console.WriteLine("You waste time frenziedly rummaging through your rucksack, but you've no new weapons to choose from!");
                                    speedyturn = 1;
                                    break;
                                }
                                string message = "You can choose from ";
                                int numWeapons = availableWeapons.Count;
                                int k = 1;
                                foreach (Weapon h in availableWeapons)
                                {
                                    message += "\n[" + k + "] " + h.Name;
                                    k++;
                                }
                                Console.WriteLine(message);
                                while (true)
                                {
                                    string response = Console.ReadLine().Trim().ToLower();
                                    try
                                    {
                                        int numResponse = int.Parse(response);
                                        Player.Equip(availableWeapons[numResponse - 1], Player.WeaponInventory, player);
                                        Console.WriteLine($"\n{availableWeapons[numResponse - 1].Description}");
                                        foreach (Weapon y in Player.WeaponInventory)
                                        {
                                            if (y.Equipped) { playerWeapon = y; break; }
                                        }
                                        if (!player.Speedy || speedyturn != 0)
                                        {
                                            Console.WriteLine($"You admire your {availableWeapons[numResponse - 1].Name} for only an instant before the {Monster.Name} lunges at you...");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"You admire your {availableWeapons[numResponse - 1].Name}, effortlessly dodging the {Monster.Name}, as the world moves sluggishly around you...");
                                            
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine($"Please enter a number from 1 to {numWeapons}");
                                        continue;
                                    }

                                }
                                break;

                            }
                            else if (answer1 == "2" || answer1 == "two")
                            {
                                if (playerWeapon.Name == "fists")
                                {
                                    if (!player.Speedy || speedyturn != 0)
                                    {
                                        Console.WriteLine($"You're not sure how you might 'unequip' your own fists, and as you contemplate this conundrum the {Monster.Name} comes in for the attack...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You can't unequip your fists!\nHas the potion of alacrity scrambled your brains?");
                                    }
                                    break;
                                }
                                else
                                {
                                    Player.Unequip(Player.WeaponInventory);
                                    pugilism = new List<Dice>();
                                    i = 0;
                                    while (i < (2 + Player.Skill) / 3)
                                    {
                                        if (i < 2)
                                        {
                                            pugilism.Add(D2);
                                        }
                                        else if (i < 3)
                                        {
                                            pugilism.Add(D3);
                                        }
                                        else
                                        {
                                            pugilism.Add(D5);
                                        }
                                        i++;
                                    }
                                    if (Player.Skill < 4)
                                    {
                                        playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else if (Player.Skill < 7)
                                    {
                                        playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else if (Player.Skill < 10)
                                    {
                                        playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else
                                    {
                                        playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    if (!player.Speedy || speedyturn != 0)
                                    {
                                        Console.WriteLine($"{playerWeapon.Description}\nYou resolve to fight bare fisted, mano e mano. \n Meanwhile, the {Monster.Name} charges towards you...");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{playerWeapon.Description}\nYou resolve to fight bare fisted, mano e mano.");
                                        
                                    }
                                    break;
                                }
                            }
                            ///The following is very similar to what you'll see in the game class 
                            ///or the main method. It's the same formula for using an item on something else 
                            ///but it lists objects the monster has too. as such it'll need to become
                            ///its own separate method at a later date.

                            else if (answer1 == "3" || answer1 == "three")
                            {
                                bool success = false;
                                if (player.Inventory.Count > 0)
                                {
                                    Console.WriteLine("Which item in your pack do you wish to use?");
                                    int g = 1;
                                    foreach (Item item in player.Inventory)
                                    {
                                        Console.WriteLine($"[{g}] {item.Name}");
                                        g++;
                                    }
                                    Item chosenItem = null;
                                    while (true)
                                    {
                                        string reply = Console.ReadLine().Trim().ToLower();

                                        try
                                        {
                                            int reply1 = int.Parse(reply) - 1;
                                            try
                                            {
                                                chosenItem = player.Inventory[reply1];
                                                break;
                                            }
                                            catch { Console.WriteLine("Please enter a number corresponding to an item listed above!"); }

                                        }
                                        catch
                                        {
                                            foreach (Item item in player.Inventory)
                                            {
                                                if (item.Name == reply)
                                                {
                                                    chosenItem = item;

                                                }

                                            }
                                        }
                                        if (chosenItem == null)
                                        {
                                            Console.WriteLine($"{reply} could not be found in your backpack. Select another item.");
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

                                    foreach (Item item in Monster.Items)
                                    {
                                        Console.WriteLine($"[{g}] The {Monster.Name}'s {item.Name}");
                                        g++;
                                    }
                                    foreach (Item item in Monster2.Items)
                                    {
                                        Console.WriteLine($"[{g}] The {Monster2.Name}'s {item.Name}");
                                        g++;
                                    }
                                    foreach (Feature feature in room.FeatureList)
                                    {
                                        Console.WriteLine($"[{g}] {feature.Name} in the room.");
                                        g++;
                                    }
                                    Console.WriteLine($"[{g}] Yourself");
                                    if (playerWeapon.Name != "fists")
                                    {
                                        Console.WriteLine($"[{g + 1}] The weapon in your hand.");
                                    }

                                    while (true)
                                    {
                                        string effectedItemString = Console.ReadLine().Trim().ToLower();
                                        try
                                        {
                                            int effectedItemNum = int.Parse(effectedItemString);
                                            if (effectedItemNum < 1 || effectedItemNum > g + 1) { Console.WriteLine("Please select a number that corresponds with an item listed above."); }
                                            else if (playerWeapon.Name != "fists" && effectedItemNum == g + 1)
                                            {
                                                try
                                                {
                                                    foreach (Weapon w in player.WeaponInventory)
                                                    {
                                                        if (w.Equipped)
                                                        {
                                                            success = w.UseItem(music, chosenItem, w, usesDictionaryItemItem, specialItems)[0];
                                                            Console.WriteLine($"You coat your {playerWeapon} in the {chosenItem}");
                                                            player.Inventory.Remove(chosenItem);
                                                            break;
                                                        }

                                                    }
                                                    break;
                                                }
                                                catch { Console.WriteLine($"You can't use {chosenItem} on that!"); break; }
                                            }
                                            else if (effectedItemNum == g)
                                            {
                                                try
                                                {
                                                    success = chosenItem.UseItem3(chosenItem, player, usesDictionaryItemChar, masked);

                                                    if (chosenItem.Name.Trim().ToLower() == "healing potion")
                                                    {
                                                        Console.WriteLine("Liquid rejuvenation trickles down your parched throat. A warm feeling swells from your heart as you feel your wounds salved and your flesh knitting itself back together.");
                                                    }
                                                    else if (chosenItem.Name.Trim().ToLower() == "elixir of feline guile")
                                                    {
                                                        Console.WriteLine("You glug the potent elixir down. Your stomach ties itself in knots for a moment, before you feel your instincts and reflexes sharpen.");
                                                    }
                                                    else if (chosenItem.Name == "potion of alacrity")
                                                    {
                                                        Console.WriteLine("It tastes as bad as it looks. However, you instantly discover that the world around you moves in slow motion...and so does your enemy.");
                                                    }
                                                    else if (success) // luck potion grants boon to all weapons.
                                                    {
                                                        Console.WriteLine("The sweet liquid tastes like nirvana. It's effervescent body dances on your tongue and delights the senses. Suddenly you feel like anything is possible...");
                                                        playerWeapon.Boon = 10;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Ermm...No. Upon reflection, you'd rather not use that on yourself.");
                                                    }
                                                    break;
                                                }
                                                catch { Console.WriteLine("Ermm...No. Upon reflection, you'd rather not use that on yourself."); break; }

                                            }
                                            else if (effectedItemNum < g && effectedItemNum > room.ItemList.Count + Monster.Items.Count + Monster2.Items.Count)
                                            {
                                                try
                                                {
                                                    success = chosenItem.UseItem1(music, usesDictionaryItemChar, chosenItem, room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Monster.Items.Count], usesDictionaryItemFeature, player.Inventory, player.WeaponInventory, room, player, Monster, this, false);
                                                    break;
                                                }
                                                catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Monster.Items.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised..."); break; }
                                            }
                                            else if (effectedItemNum > room.ItemList.Count + Monster.Items.Count)
                                            {
                                                try
                                                {
                                                    success = chosenItem.UseItem(music, chosenItem, Monster2.Items[effectedItemNum - 1 - room.ItemList.Count], usesDictionaryItemItem, specialItems, null, null, room, player, holeInCeiling)[0];
                                                    if (room.FeatureList.Contains(holeInCeiling))
                                                    {
                                                        Console.WriteLine(jinxedMisses[9]);
                                                        Monster.Stamina -= 9999;
                                                    }
                                                    break;
                                                }
                                                catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {Monster2.Items[effectedItemNum - 1 - room.ItemList.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised..."); break; }
                                            }
                                            else if (effectedItemNum > room.ItemList.Count)
                                            {
                                                try
                                                {
                                                    success = chosenItem.UseItem(music, chosenItem, Monster.Items[effectedItemNum - 1 - room.ItemList.Count], usesDictionaryItemItem, specialItems, null, null, room, player, holeInCeiling)[0];
                                                    if (room.FeatureList.Contains(holeInCeiling))
                                                    {
                                                        Console.WriteLine(jinxedMisses[9]);
                                                        Monster.Stamina -= 9999;
                                                    }
                                                    break;
                                                }
                                                catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {Monster.Items[effectedItemNum - 1 - room.ItemList.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised..."); break; }
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    success = chosenItem.UseItem(music, chosenItem, room.ItemList[effectedItemNum - 1], usesDictionaryItemItem, specialItems, null, null, room, player, holeInCeiling)[0];
                                                    if (room.FeatureList.Contains(holeInCeiling))
                                                    {
                                                        Console.WriteLine(jinxedMisses[9]);
                                                        Monster.Stamina -= 9999;
                                                    }
                                                    break;

                                                }
                                                catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {room.ItemList[effectedItemNum - 1].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised..."); break; }
                                            }
                                        }
                                        catch { Console.WriteLine("Please enter the number corresponding to the list above!"); }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("You've no items in your backpack!");
                                }
                                if (player.Speedy && speedyturn == 0)
                                {
                                    Console.WriteLine("Your adversary has scarcely time to act before you bound into your next action!");
                                    break;
                                }
                                else if (success && !room.FeatureList.Contains(holeInCeiling) && Monster.Stamina > 0 && Monster2.Stamina > 0)
                                {
                                    Console.WriteLine($"\nIt's not long after your actions take effect before both your enemies attack you!");
                                    break;
                                }
                                else if (success && !room.FeatureList.Contains(holeInCeiling) && Monster.Stamina > 0)
                                {
                                    Console.WriteLine($"\nIt's not long after your actions take effect before the {Monster.Name} attacks you!");
                                    break;
                                }
                                else if(success && !room.FeatureList.Contains(holeInCeiling) && Monster2.Stamina > 0)
                                {
                                    Console.WriteLine($"\nIt's not long after your actions take effect before the {Monster2.Name} attacks you!");
                                    break;
                                }
                                else if (!success && !room.FeatureList.Contains(holeInCeiling) && Monster.Stamina > 0 && Monster2.Stamina > 0)
                                {
                                    Console.WriteLine($"\nYour actions have only given your enemies the opportunity to attack again!");
                                    break;
                                }
                                else if (!success && !room.FeatureList.Contains(holeInCeiling) && Monster.Stamina > 0 )
                                {
                                    Console.WriteLine($"\nYour actions have only given the {Monster.Name} the opportunity to attack again!");
                                    break;
                                }
                                else if (!success && !room.FeatureList.Contains(holeInCeiling) && Monster2.Stamina > 0)
                                {
                                    Console.WriteLine($"\nYour actions have only given the {Monster2.Name} the opportunity to attack again!");
                                    break;
                                }
                                else { break; }
                            }


                            // basically you lose a turn       
                            else if (answer1 == "4" || answer1 == "four")
                            {
                                if (player.Speedy && speedyturn == 0)
                                {
                                    Console.WriteLine("You take a moment, effortlessly dodging your opponents swings, just to marvel at how slow everything feels. Remarkable!");
                                    
                                    break;
                                }
                                else if (Monster.Stamina > 0 && Monster2.Stamina > 0)
                                {
                                    Console.WriteLine($"Your enemies close in for more vicious attacks!");
                                    break;
                                }
                                else if (Monster2.Stamina > 0)
                                {
                                    Console.WriteLine($"The {Monster2.Name} closes in for another vicious attack!");
                                    break;
                                }
                                else if (Monster.Stamina > 0)
                                {
                                    Console.WriteLine($"The {Monster.Name} closes in for another vicious attack!");
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("ERROR! Please answer either '1', '2', '3' or '4'.");
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter either 'yes' or 'no'.");
                        continue;
                    }
                    if (player.Speedy && speedyturn == 0)
                    {
                        speedyturn++;
                        Console.WriteLine($"Do you wish to continue attacking with your {playerWeapon.Name}? ");
                        continue;
                    }
                    break;
                }
                turn++;
                continue;
            }
            if (Player.Stamina > 0)
            {
                Console.WriteLine("Congratulations! You've slain the monster!");
                player.Speedy = false;
                foreach(Weapon w in player.WeaponInventory)
                {
                    if (w.Boon > 9)
                    {
                        w.Boon = 0;
                        if (w.Name.ToLower() == "sword of sealed souls")
                        {
                            w.Boon = 2;
                        }
                        if (player.Traits.ContainsKey("jinxed"))
                        {
                            w.Boon = 6;
                        }
                    }
                }
                return true;
            }
            else if (Monster.Stamina > 0 || Monster2.Stamina > 0)
            {
                Console.WriteLine($"The last strike you suffered proves fatal. You collapse in shameful defeat, a trickle of blood running from your mouth as your limp body drops to its knees. This battle has proven too much for you. Your adventure ends here...");
                Console.ReadKey(true);
                return false;
            }
            else
            {
                Console.WriteLine("The fire consumes you both!");
                Console.ReadKey(true);  
                return false;
            }
        }

        //special rules
        //streamlined battle rounds
        //special moves dependent on weapon and skill
        //special messages  misses skill > oppSkill skill < oppSkill and skill = oppSkill
    }
}

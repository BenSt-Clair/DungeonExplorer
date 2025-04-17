using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class ArchFey : Dialogue
    {
        Player _player { get; set; }
        Monster Monster { get; set; }
        Combat Race { get; set; }
        Room Room { get; set; }
        public ArchFey(Player player, Monster monster, Combat race, Room room) : base(player, room)
        {
            _player = player;
            Monster = monster;
            Race = race;
            Room = room;
        } 
        public bool ElderArchFeyPlotPoint(Room magicalManufactory)
        {
            string description = "Suddenly, a voice beckons you from somewhere within the shadows! " +
                "\n\t'Oh, I wouldn't do that if I were you...' it calls, its cadence childlike in its singsong delivery from the depths of the oubliette. " +
                "Your eyes follow it to where the ribbons of runes scrawled over the ground spiral into a strange and elaborate pentagram. From somewhere within its confines you notice some speck of light, as innocuous as a firefly, flicker as a creature stirs..." +
                "\n\t'By the clack-smack cracking of my thumbs,\n\tDo I detect something wicked this way comes...?'";
            List<string> parlances = new List<string> 
            { 
                "Your feet clap upon the cold flagstones as you cautiously approach, a distinct well of unease sitting in your gut and sending a fever of gooseflesh creeping up your arms. The creature's delightful voice both lures and welcomes you closer..." +
                "\n'...for once there was a frightfully naughty boy, \nWho with many innocent lives he liked to toy, \nfor too many years did he scheme and plan, \nas the snare of spiders' webs across desires span, \nfor the downfall of the unruled, the whimsical, the free, \nAdventurers who dare stand up to power and restore the balance, \n\tlike you, \n\t\tlike me... '",

                "\n'So what do you say?' the harmless pixie chimes, 'now you know of my beastly" +
                " imprisonment, I pray,\n shall you free Flutterlyn so we can play?'\nThere is a " +
                "distinct unease sitting in the pit of your stomach as Flutterlyn addresses you. " +
                "You notice her gaze never seems to clasp sight of you, rather she seems to " +
                "follow the sound of your footsteps as you cautiously circle the pentagram. \nYou're about to " +
                "respond when FlutterLyn catches the sound of your breath. She " +
                "snaps her gaze to directly latch hold of you with her " +
                "bewitching eyes. \n  She trills coyly, 'All the adventurers *I* know *love* to save the day...'", 

                "The pixie implores you." +
                "\n'Disturbing the markings of this pentagram is all it takes," +
                "\nQuickly you should free me for both our sakes!'"
            };
            List<List<string>> choices = new List<List<string>> 
            {
                new List<string>
                { 
                    "Inching closer, you tentatively call out for the voice to identify itself...",
                    "Inching closer, you ask what it is exactly that you're being warned from doing...",
                    "Inching closer, you ask whether they are another prisoner like you...",
                    
                },

                new List<string>
                {
                    "You ask what The CurseBreaker could possibly want from a cute pixie...",
                    "You inquire about the strange symbols spanning this oubliette...",
                    "You wonder aloud how a pixie came to be trapped here..."
                },

                new List<string> 
                { 
                    "You decide a companion to help you sounds like no bad thing. You free the pixie...",
                    "You agree to free the pixie from the CurseBreaker, but only if you both go your separate ways...",
                    "You hold back. You sense something is not quite right..."
                }
            };
            if (!magicalManufactory.FirstVisit)
            {
                choices[0].Insert(2, "Inching closer, you demand that the bound creature show itself...");
                choices[0].RemoveAt(3);
            }
            if (!_player.Fooled)
            {
                choices[1].Clear();
                choices[1].Add("You tell the creature that you aren't fooled by it's disguise...");
                choices[1].Add("For now, you play along with this treacherous creature's act and ask about the symbols...");
                choices[1].Add("You interrogate the creature, nonchalantly wondering why it can't seem to see you...");
                parlances[2] = "\n'Disturbing the markings of this pentagram is all it takes," +
                    "\nYou really should consider freeing me for both our sakes...'";
                choices[2].Clear();
                choices[2].Add("You tell the creature that Merigold told you everything. You know its true form...");
                choices[2].Add("You fix the creature with a stern gaze and command it to remove the glamour it's using to conceal itself...");
                choices[2].Add("You laugh in the creature's face and mock it, delighting in how futile it's situation is...");
                choices[2].Add("Whatever this creature is, you choose to trust it over some bumbling old wizard who could scarcely control a portal...");
                choices[2].Add("You tell the creature that you know what the CurseBreaker did to it. As far as you're concerned the enemy of your enemy is your friend. You choose to free it...");
            }
            Dictionary<string, string> choices_response = new Dictionary<string, string> 
            {
                {
                    "Inching closer, you tentatively call out for the voice to identify itself...", 
                    
                    "The spark hovering above the pentagram, flares brighter, expanding minutely" +
                    " like a spring flower gingerly budding amidst the briar of glowing runes. " +
                    "You shield your eyes a moment, before you clasp sight of a tiny female body " +
                    "flitting about with the iridescent and beautiful wings of a dragonfly - a pixie, " +
                    "or perhaps a fairy. It flits within the confines of the pentagram scrawled on the " +
                    "floor as though sealing it were some vast glass jar you cannot see..." +
                    "\n\n\t'Why, but my name, of course, is FlutterLyn, " +
                    "\n\tAnd all of pixie-kind is my kin, " +
                    "\n\tThough far prettier than the other lot I do boast,"+ 
                    "\n\tIn here I'm so scared I'm as pale as a ghost," +
                    "\n\tStranger, I beseech, Would that I could be a more gracious host," +
                    "\n\t But I fear without your help soon, we will both be toast!'" 
                },
                {
                    "Inching closer, you ask what it is exactly that you're being warned from doing...",

                    "The spark hovering above the pentagram, flares brighter, expanding minutely" +
                    " like a spring flower gingerly budding amidst the briar of glowing runes. " +
                    "You shield your eyes a moment, before you clasp sight of a tiny female body " +
                    "flitting about with the iridescent and beautiful wings of a dragonfly - a pixie, or perhaps a fairy. " +
                    "It flits within the confines of the pentagram scrawled on the " +
                    "floor as though sealing it were some vast glass jar you cannot see..." +
                    "\n\n\t'That portal there you eye before thee," +
                    "\n\tCrackles and snaps with powerful magicks, you see," +
                    "\n\tDesigned through these runes to teleport *me*, " +
                    "\n\tTo anyone else lurks a danger you cannot foresee," +
                    "\n\tyour bones to snap," +
                    "\n\tyour mind to crack, " +
                    "\n\tyour body it'll spaghettify until you go splat!' " +
                    "\nIt titters delightfully at the thought, and you listen, stunned" +
                    " to find it the most lyrical laugh you ever heard; an alluring aria" +
                    " of innocent mischief."
                },
                {
                    "Inching closer, you ask whether they are another prisoner like you...",

                    "The spark hovering above the pentagram, flares brighter, expanding minutely" +
                    " like a spring flower gingerly budding amidst the briar of glowing runes. " +
                    "You shield your eyes a moment, before you clasp sight of a tiny female body " +
                    "flitting about with the iridescent and beautiful wings of a dragonfly - a pixie, or perhaps a fairy. " +
                    "It flits within the confines of the pentagram scrawled on the " +
                    "floor as though sealing it were some vast glass jar you cannot see..." +
                    "\n\n\tYes! Yes! Oh golly, yes!" +
                    "\n\tCan you not tell?" +
                    "\n\tJust like you I've been landed in this mess," +
                    "\n\tJust like you upon thoughts of freedom I dwell..."
                },
                {
                    "Inching closer, you demand that the bound creature show itself...",

                    "The spark hovering above the pentagram, flares brighter, expanding minutely" +
                    " like a spring flower gingerly budding amidst the briar of glowing runes. " +
                    "You shield your eyes a moment, before you clasp sight of a tiny female body " +
                    "flitting about with the iridescent and beautiful wings of a dragonfly - a pixie, or perhaps a fairy. " +
                    "It flits within the confines of the pentagram scrawled on the " +
                    "floor as though sealing it were some vast glass jar you cannot see..." +
                    "\n\n\t'*bound creature*? What an unprovoked discourtesy!" +
                    "\n\tI am no fell wight with beastly fangs or clacking claw, you see?" +
                    "\n\tAll *I* wish to do is laugh, make merry and play," +
                    "\n\tUnfortunately, over my current dwellings, I had no say...'"
                },

                {
                    "You ask what The CurseBreaker could possibly want from a cute pixie...", 
                    
                    "Flutterlyn bats her voluminous lashes your way." +
                    "\n\n\t'Who am I to ken the mind of such a madman?" +
                    "\n\tWhy'd he seize you and make your smiles so wan?" +
                    "\n\tAll of it, somehow, ties into some devious plan..." +
                    "\n\tHurry! He may return! Gosh golly, you must do what you can!" +
                    "\n\tDid you not see the others - what wretched end for how they began," +
                    "\n\tWould you leave poor Flutterlyn separated from her clan?" +
                    "\n\tWho wouldn't wish for my help? I'm as affectionate as a lamb...'" 
                },
                
                {
                    "You inquire about the strange symbols spanning this oubliette...",
                    
                    "Flutterlyn flits about impatiently..." +
                    "\n\n\t'Bars and rungs and chains forged from magicks of darkest lore, " +
                    "\n\tThe CurseBreaker, he formed this cage that I so abhor," +
                    "\n\tLike a robin red-breast caught, trapped, snapped within," +
                    "\n\tFor free air and to spread my wings I do sing...'" 
                },
                
                {
                    "You wonder aloud how a pixie came to be trapped here...", 
                    
                    "Flutterlyn pouts." +
                    "\n\n\t'Well, how did you get abducted and whisked here, big-kin?' she retorts sulkily, '" +
                    "If you're so hot, how come a different fate you didn't win?" +
                    "\n\t'Do you fancy you'll be able to take the CurseBreaker on alone?' she scoffs, 'Then feel welcome, over there, amongst the other fools yon' bones...'" 
                },

                {
                    "You tell the creature that you aren't fooled by it's disguise...",

                    "The 'pixie's brow creases. The 'pixie' cocks her head quizzically. Finally the 'pixie's eyes sparkle like lightning strikes upon a dark horizon." +
                    "\n\n\t'You think I'm playing pretend? How fun!" +
                    "\n\tA 'guise comes as easy as an expression for some..." +
                    "\n\n\tSmiles that flash like daggers when exchanging favours," +
                    "\n\tActors betwixt whose lines are sheathed sabres... " +
                    "\n\n\tBut these surroundings are far from bucolic," +
                    "\n\tFor that, such fun would not be any kind of tonic." +
                    "\n\tI tell you the truth, once, twice, thrice," +
                    "\n\tI just want to stretch my wings," +
                    "\n\t\tI know nought of any vice," +
                    "\n\t\t\tFree, I could get you out of this tower in a trice," +
                    "\n\tSo why not come closer and take a roll of the dice...'" 
                },
                
                {
                    "For now, you play along with this treacherous creature's act and ask about the symbols...",

                    "The 'pixie' flits about impatiently..." +
                    "\n\n\t'Bars and rungs and chains forged from magicks of darkest lore, " +
                    "\n\tThe CurseBreaker, he formed this cage that I so abhor," +
                    "\n\tLike a robin red-breast caught, trapped, snapped within," +
                    "\n\tFor free air and to spread my wings I do sing...'"
                },

                {
                    "You interrogate the creature, nonchalantly wondering why it can't seem to see you...",
                    
                    "A sly expression crosses over the sweet 'pixie's face." +
                    "\n\n\t'Why do you word that as if it's some mystery?' the creature counters, 'Is it not too dark, too murky, too misty to see?'" +
                    "\n\t'Within this pentagram magics do bind," +
                    "\n\tPerhaps also, they conspire to blind...'"
                },

            };
            if (!magicalManufactory.FirstVisit)
            {
                choices_response["Inching closer, you ask what it is exactly that you're being warned from doing..."] +=
                    "\n  Reaching a hand up to your mouth you become horrified to discover a beaming smile spread across your face - as though you too were titillated by the image of your own body torn asunder. As though someone or something else had spread your lips wide and twisted your emotions without your knowledge or say so. ";
            }
            if (_player.Fooled)
            {
                switch (LinearParle(choices_response, parlances, choices, description))
                {
                    case 2:
                        Console.WriteLine("The pixie looks upon you with carefully practiced and perfectly honed pity. It's an expression so distilled to purity that it can't help but elicit the desired response. \n" +
                            "\t'But stranger can't you tell?" +
                            "\n\tYou are trapped down here as well!" +
                            "\n\tThat stone over there, you see?" +
                            "\n\tTry to hurl it through the portal for me...'");
                        Console.ReadKey(true);
                        Console.WriteLine("Warily you do as the pixie says, only to find the stone warped and crumpled to dust as if by some invisible fist the moment it reaches the portal...");
                        Console.ReadKey(true);
                        Console.WriteLine("'Now do you not see?' the pixie trills, 'You have no choice but to listen to me." +
                            "\nThe ladder's rungs will only recede from every attempt to clasp," +
                            "\n Like the fruits of poor Tantalus they defy your grasp.'" +
                            "\nThen abruptly, Flutterlyn's voice drops it's obsessive rhyming. It's childish cadence is gone and now somehow, if it's not sinister, then it's certainly different... huskier... more sensual... more bewitching...");
                        Console.ReadKey(true);
                        Console.WriteLine("\n'You have no choice but to help me now,' the voice becomes silky, smooth and impossible to ignore. It slips beneath your skin. It's words writhe behind your eyelids and inside your mind. You feel yourself become dazed and listless, darkness cloaking the edges of your vision as you can hardly keep a grasp of your own thoughts and will. When you turn to face innocent Flutterlyn you find she's no longer there. In her place looms some new beguiling creature; tall, elegant and splendiferous, with a bewitching smile, arresting eyes and a hypnotic aspect that makes your heart shudder. " +
                            "\nThe runes around you seem to momentarily pulse with light, catching your figure in their ghostly luminescence - like a fly caught in a spider's web..." +
                            "\n\t'Now, release me...' the creature beckons you with long nails, each syllable electrifying you with a new delicious ecstasy, each one better than the last. It becomes impossible to resist. Too pleasurable to obey.");
                        Console.ReadKey(true);
                        Console.WriteLine("The moment your foot scuffs the pentagram is the last moment of your life...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    default:
                        Console.WriteLine("Flutterlyn watches on hungrily as you approach to liberate her.");
                        Console.ReadKey(true);
                        Console.WriteLine("The moment your foot scuffs the pentagram is the last moment of your life...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                }
            }
            else 
            {
                switch (LinearParle(choices_response, parlances, choices, description))
                {
                    case 0:
                    case 1:
                    case 2:
                    default:
                        Console.WriteLine("Flutterlyn watches on hungrily as you approach to liberate her.");
                        Console.ReadKey(true);
                        Console.WriteLine("The moment your foot scuffs the pentagram is the last moment of your life...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                }
            }
            return false;
        }
    }
}

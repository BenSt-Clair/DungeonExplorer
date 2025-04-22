using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
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
        public bool ElderArchFeyPlotPoint(Room magicalManufactory, Feature mosaic)
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
                int path = LinearParle(choices_response, parlances, choices, description);
                if (_player.midnightClock != null)
                {
                    _player.midnightClock.Stop();
                    long timeTaken = _player.midnightClock.ElapsedMilliseconds;
                    _player.midnightClock.Start();
                    long timeToMidnight = 1800000;
                    long timeLeft = (timeToMidnight - timeTaken) / 60000;
                    if (timeLeft < 0)
                    {
                        Console.WriteLine("\nMidnight is upon you!");
                        Console.ReadKey(true);
                        Console.WriteLine("Throughout the tower all the clocks chime the hour. Even from the oubliette you hear " +
                            "them. The pale ghostly light of the runes catch your final look of fright, before all the lights go out and darkness falls." +
                            " Your interlocutor disappeared with them, swept into the portal that turned, for but an instant, blood moon red, before it too vanished. " +
                            "  \n  You are left alone only for a few tense moments, dreading what is to follow, before a blood-curdling howl erupts from above" +
                            " as something new and terrible is brought into the world. Soon afterwards, the tower collapses in on you... ");    
                        Console.ReadKey(true);
                        Console.WriteLine("At least you never caught sight of the horror your lack of urgency unleashed.");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        return false;
                    }
                    
                }
                if (path < 2)
                {
                    string says = "";
                    if (path == 0)
                    {
                        says = "'Oh sweet thing, you know not anything,'";
                    }
                    else
                    {
                        says = "'Oh sweet thing, you know not what you ask,'";
                    }
                    description = "The 'pixie' titters delightedly, though this time there is " +
                                "an almost disembodied aspect to it, as though it were coming from an " +
                                "artful ventriloquist hidden out of sight..." +
                                $"\n\n\t{says} the creature purrs. " +
                                "The guise of a pixie vanishes and what stands before you in its place is " +
                                "something that sends your pulse racing, though whether your heart is " +
                                "jolted by awe or shudders in terror, you cannot quite say. Could it " +
                                "be both at once?" +
                                "\n\t'There is no such thing as a *true* form beneath *my* skin...' she " +
                                "continues, her words electrifying the very air around you. 'I am a " +
                                "Lady of the " +
                                "ArchFey. I am a being whose beauty is perennial.' She paces within the " +
                                "parameters of the pentagram, and her very footsteps clap in beat with your " +
                                "shuddering heart. " +
                                "'My beauty is that of the first celestial bodies and their disturbing contours. " +
                                "My allure is like the captivating dew of the youngest galaxies in bloom, " +
                                "all long since consumed by eternal eclipse. I was there, when the first " +
                                "stars formed. I will be there when they are swallowed by the void...'";
                    
                    parlances = new List<string>
                    {
                            "  Her words elicit a fever of visions before your mind," +
                            " of ebon nights cast by the glow of strange stars, " +
                            "to colliding galaxies become furnaces of creation within the void of space, " +
                            "and finally of an afterglow so intense that lances of red light extend " +
                            "through the dark vault of the heavens." +
                            "\n   Yet you are not so distracted that you do not notice one glaring " +
                            "fault in her appearance. Where her eyes should be there are instead bandages " +
                            "and gauze specked with blood." +
                            " They are wrapped around her head, over her eye sockets, and focusing on this is what" +
                            " makes you realise you'd been drawing nearer to the pentagram's edge, as though locked in trance." +
                            "\n   You back away, suddenly all too wary of the creature's tricks...",

                            "You wipe a sheen of nervous sweat from your brow, relieved only that the " +
                            "bewitching creature cannot see it. "

                    };
                    choices = new List<List<string>> 
                    { 
                        new List<string>
                        {
                            "You warn the creature that their beguiling words shan't work on you...",
                            "You tell the creature that if it wants its freedom, it shall have to earn it...",
                            "You flatter the creature and try to coax it into letting slip how to stop the ritual..."
                        },

                        new List<string>
                        {
                            "You draw forth as much self-control as you can muster and demand the creature tell you how to stop the CurseBreaker...",
                            "You surmise that if the creature likes games, then surely the most fun game would be stopping the CurseBreaker upon the cusp of his victory...",
                            "You struggle against the wondrous creature's words but the bewildering feelings and overwhelming lust it inspires are too strong. You begin to let the creature take control..."
                        }
                    };
                    choices_response = new Dictionary<string, string>
                    {
                        {
                            "You warn the creature that their beguiling words shan't work on you...",
                            
                            "'That's too bad,' the creature languidly turns towards you, " +
                            "keeping track of every one of your shallow breaths, " +
                            "each nervous scrape of boot upon flagstone, each beat of your heart." +
                            " 'The fly in the spider's web is too serious for games,' " +
                            "her pout feels so real that it draws you in, even " +
                            "draws forth a moment of disorientating sympathy" +
                            ". Then her face suddenly lights up with a bewitching smile so alluring " +
                            "it almost seems to pull on your bloodflow - As though her stunning smile were the moon " +
                            "drawing forth ocean waves of ecstasy. Around you the web of runes glows brighter and you find yourself" +
                            " caught in their sickly pale light." +
                            "\n'But I don't need eyes to tell there's a secret part of you that" +
                            " *desires* to play my games,' she purrs. 'There's a curiosity to find out just how much" +
                            "fun succumbing to my words and letting go can be...' \nAnd in response your legs stiffen." +
                            " Every primal instinct screams the danger before you. Yet all that races" +
                            " through your mind in that moment is one question; it's icy cold, so why are your hands so damn clammy?" 
                        },

                        {
                            "You tell the creature that if it wants its freedom, it shall have to earn it...",
                            
                            "  The shapely Lady titters before you; an enchanting aria of infectious delight." +
                            "\n'What grand delusions you have, little fly,' she trills, 'for you to presume" +
                            " that you're in a position to barter with me.' She surveys you appraisingly, " +
                            "regally, her head tilted back slightly so that the sickly pale glow of the runes catches her" +
                            " high cheekbones. She exudes power, authority; even as her lips part into a lazy, cat-like smile." +
                            "\n'You have no exit from here, little thing,' she purrs, her movements fluid and seductive as she tracks the shallow hitch of your breath." +
                            "'Not from this game. Our fates are already bound to each other, entwined like boa constrictor and prey, like fingers crossed...'" 
                        },

                        {
                            "You flatter the creature and try to coax it into letting slip how to stop the ritual...", 
                            
                            "  The Lady of the ArchFey smiles at your clumsy attempts to put into words" +
                            " her majesty. You find yourself becoming nervous in spite of yourself, tripping over" +
                            " your own utterances. Why are you behaving this way? What was it you wanted? " +
                            " \n   You're no longer so sure. " +
                            "\nThe way the creature makes you feel fogs your mind. " +
                            "Your voice trails off and you're left searching for how your train of thought began." +
                            "\n\t'Oh, but don't be shy, silly thing,' she purrs. 'It's only natural for a mortal " +
                            "to   bow down before me. Afterall, do not the pines bow to the breeze? Does not the harsh sun   bow to make way for the blanket of dusk?'" +
                            "\n   You only just catch yourself as your knees buckle and tremble. A thrill of terror courses through you" +
                            " as you realise just how easily the creature's words slip through your ears and arrest your mind." +
                            "  A thrill of terror that could so easily become the apex of ecstasy, if you let it..." 
                        }
                    };
                    path = LinearParle(choices_response, parlances, choices, description);
                    
                }
                else if (path == 2)
                {
                    description = "The 'pixie' surveys your laughter for a moment, head tilted as a wry smile spreads across its lips." +
                        "\n'And how, sweet thing,' it purrs, 'are you not in the exact same bind as I?'" +
                        "\n   The guise of a pixie vanishes and what stands before you in its place is something" +
                        " that makes your laughter trail away from you and sends your pulse racing, though whether your heart is jolted by awe or shudders in" +
                        " terror, you cannot quite say. Could it be both at once?" +
                        "\n   What stands before you is a Lady of the ArchFey, an eldritch creature capable of holding " +
                        "mortals captive with their transcendent allure. Though you notice one other thing beyond " +
                        "her surreal beauty, glowing like a celestial body. There, where its eyes should be, is nought but gauze and bandages, " +
                        "specked with blood. It follows the sound of your shallow breath, the nervous scrape of boot upon flagstone, perhaps even of your heart thumping against your chest, " +
                        "but it cannot see you.";
                    parlances = new List<string> 
                    {
                        "  The shapely Lady titters at your being struck dumb by her revelation, her laughter an enchanting aria of infectious delight." +
                            "\n'What grand delusions you have, little fly,' she trills, 'for you to presume" +
                            " that you're in a position to laugh at my expense.' She surveys you appraisingly, " +
                            "regally, her head tilted back slightly so that the sickly pale glow of the runes catches her" +
                            " high cheekbones. She exudes power, authority; even as her lips part into a lazy, cat-like smile." +
                            "\n'You have no exit from here, little thing,' she purrs, her movements fluid and seductive as she tracks the shallow hitch of your breath." +
                            "'Not from this game. Our fates are already bound to each other, entwined like boa constrictor and prey, like fingers crossed...'",

                        "You wipe a sheen of nervous sweat from your brow, relieved only that the " +
                            "bewitching creature cannot see it. "
                    };
                    choices = new List<List<string>> 
                    { 
                        new List<string>
                        {
                            "You warn the creature that their beguiling words shan't work on you...",
                            "You flatter the creature and try to coax it into letting slip how to stop the ritual...",
                            "You bristle, grip your sword tighter and ask why you shouldn't just run the creature through..."
                        },
                        new List<string>
                        {
                            "You draw forth as much self-control as you can muster and demand the creature tell you how to stop the CurseBreaker...",
                            "You surmise that if the creature likes games, then surely the most fun game would be stopping the CurseBreaker upon the cusp of his victory...",
                            "You struggle against the wondrous creature's words but the bewildering feelings and overwhelming lust it inspires are too strong. You begin to let the creature take control..."
                        }
                    };
                    choices_response = new Dictionary<string, string> 
                    {
                        {
                            "You bristle, grip your sword tighter and ask why you shouldn't just run the creature through...",

                            "Your attempts to menacingly brandish your weapon are made oafish under the bewitching presence" +
                            " of this monster. Her pillow-like lips only part into a wider and fuller smile than before as" +
                            " you clumsily fumble at the handle of your weapon. " +
                            "\n  Since when did your hands become so slippery with sweat?" +
                            "\n  When at last you manage to tear your own eyes away from her captivating presence, you discover with horror that it was the protruding thumb of your other hand that" +
                            " had held your weapon in place all along. And for a moment you are struck dumb by the strangest feeling, as though parts of your own" +
                            " body are acting on their own and without your knowledge, treacherously countering your rapidly crumbling resolve. All the while the" +
                            " Lady's laughter becomes as sweet and melodic as a sonata to your" +
                            " ears. You can feel it fogging your mind with feelings you can't describe. Your heart begins to thump madly" +
                            " against your chest." +
                            "\n\t'Come, adventurer,' she trills, and her voice sends icy tingles all the way up your back, stiffening your legs and rooting you to the ground, 'even your" +
                            " own body knows it. It does not wish to obey the silly ideas in your head. It wants to   listen to me instead. Dispel such desires as felling a creature such as myself," +
                            " whose grace and elegance eclipse all beauty you've hitherto seen. I am of the twilight realms, I am as a god to your kind. Do you even know why you're here any more?'" +
                            "\n  Your thoughts race, and for a horrible, lurching moment you find that the memory of Merigold, his warnings, the fate of the other prisoners and even the looming threat of " +
                            "the CurseBreaker - they'd all escaped your mind. For a moment they'd slipped away beyond the intoxicating haze of strange new feelings swelling within your mind." 
                        },

                        {
                            "You warn the creature that their beguiling words shan't work on you...",

                            "'That's too bad,' the creature languidly turns towards you, " +
                            "keeping track of every one of your shallow breaths, " +
                            "each nervous scrape of boot upon flagstone, each beat of your heart." +
                            " 'The fly in the spider's web is too serious for games,' " +
                            "her pout feels so real that it draws you in, even " +
                            "draws forth a moment of disorientating sympathy" +
                            ". Then her face suddenly lights up with a bewitching smile so alluring " +
                            "it almost seems to pull on your bloodflow - As though her stunning smile were the moon " +
                            "drawing forth ocean waves of ecstasy. Around you the web of runes glows brighter and you find yourself" +
                            " caught in their sickly pale light." +
                            "\n'But I don't need eyes to tell there's a secret part of you that" +
                            " *needs* to play my games,' she purrs. 'There's a curiosity to find out just how much" +
                            "fun succumbing to my words and letting go can be...' \nAnd in response your legs stiffen." +
                            " Every primal instinct screams the danger before you. Yet all that races" +
                            " through your mind in that moment is one question; it's icy cold, so why are your hands so damn clammy?"
                        },

                        {
                            "You flatter the creature and try to coax it into letting slip how to stop the ritual...",

                            "  The Lady of the ArchFey smiles at your clumsy attempts to put into words" +
                            " her majesty. You find yourself becoming nervous in spite of yourself, tripping over" +
                            " your own utterances. Why are you behaving this way? What was it you wanted? " +
                            " \n   You're no longer so sure. " +
                            "\nThe way the creature makes you feel fogs your mind. " +
                            "Your voice trails off and you're left searching for how your train of thought began." +
                            "\n\t'Oh, but don't be shy, silly thing,' she purrs. 'It's only natural for a mortal " +
                            "to   bow down before me. Afterall, do not the pines bow to the breeze? Does not the harsh sun   bow to make way for the blanket of dusk?'" +
                            "\n   You only just catch yourself as your knees buckle and tremble. A thrill of terror courses through you" +
                            " as you realise just how easily the creature's words slip through your ears and arrest your mind." +
                            "  A thrill of terror that could so easily become the apex of ecstasy, if you let it..."
                        }
                    };
                    path = LinearParle(choices_response, parlances, choices, description);

                }
                else 
                { 
                        Console.WriteLine("The 'pixie' watches on hungrily as you approach to liberate her.");
                        Console.ReadKey(true);
                        Console.WriteLine("The moment your foot scuffs the pentagram is the last moment of your life...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                }
                if (_player.midnightClock != null)
                {
                    _player.midnightClock.Stop();
                    long timeTaken = _player.midnightClock.ElapsedMilliseconds;
                    _player.midnightClock.Start();
                    long timeToMidnight = 1800000;
                    long timeLeft = (timeToMidnight - timeTaken) / 60000;
                    if (timeLeft < 0)
                    {
                        Console.WriteLine("\nMidnight is upon you!");
                        Console.ReadKey(true);
                        Console.WriteLine("Throughout the tower all the clocks chime the hour. Even from the oubliette you hear " +
                            "them. The pale ghostly light of the runes catch your final look of fright, before all the lights go out and darkness falls." +
                            " Your interlocutor disappeared with them, swept into the portal that turned, for but an instant, blood moon red, before it too vanished. " +
                            "  \n  You are left alone only for a few tense moments, dreading what is to follow, before a blood-curdling howl erupts from above" +
                            " as something new and terrible is brought into the world. Soon afterwards, the tower collapses in on you... ");
                        Console.ReadKey(true);
                        Console.WriteLine("At least you never caught sight of the horror your lack of urgency unleashed.");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        return false;
                    }

                }
                if (path == 0)
                {
                    description = "You realise that the Lady before you must be deploying some " +
                        "new kind of bewitching glamour. You shut your eyes for a moment pushing back at the boundaries" +
                        " of the fog filling your mind. You focus your mind away from her enchanting visage and with a steely " +
                        "resolve reopen your eyes and somehow manage to keep the creature's spell at bay.";
                    parlances = new List<string>
                    {
                        "'Hmm?' the eldritch ArchFey Lady purrs, 'has the little one rediscovered its voice?'",

                        "Your gaze latches onto the portal, even to your untrained eye you can see the runes feed into and are bound to the crackling vortex of energy. " +
                        "  Your sights fix on the lone man, back turned to you, continuing his vile chant as the storm rages, a dirge to the moon whose diabolical contents transgress any " +
                        "boundaries of translation. The esoteric words are laced with a palpable evil." +
                        "  'And if you think to try the portal, you might like to test it with a stone first,' the creature informs you, its voice smooth and soft. 'If you" +
                        " want an idea of what will happen to you - or anyone other than me - should you attempt to use it...'" +
                        "Has Merigold sent you on a fool's errand?"
                    };
                    choices = new List<List<string>>
                    {
                        new List<string>
                        {
                            "You tell the creature that the fun's over. You ask how to stop the CurseBreaker's magic or you'll leave, using the portal to face him before your time runs out...",
                            "You remember Merigold's warning that you have only until the clocks strike twelve. You leverage this knowledge to your advantage...",
                            "You challenge the creature: does it wish to succumb to the CurseBreaker's schemes?"
                        },
                        new List<string>
                        {
                            "You remember Merigold warned you of the creature's duplicity; in defiance of the Lady, you march to the portal and leap through it...",
                            "You recall Merigold foretold of the creature's treachery; in defiance of the Lady, you march up to the nearest rune between her and the portal and scuff it...",
                            "You remind yourself that Merigold urged you not to listen to the creature's lies; but just to be sure, you march up to the portal and lob a stone through it..."
                        }
                    };
                    choices_response = new Dictionary<string, string>
                    {
                        {
                            "You tell the creature that the fun's over. You ask how to stop the CurseBreaker's magic or you'll leave, using the portal to face him before your time runs out...",
                            
                            "  The creature eyes you slyly. 'Why, but by freeing me of course,' she replies silkily, 'What was it that the 'magnificent Merigold' told you, hmm? That you had to stop the ritual, no? Disrupt it somehow?" +
                            "  Look around you.' She motions to the far portal and to the runes that surround you, binding the creature - and you - inside the oubliette." +
                            " 'It is these very runes that lock us both down here. Disturb the markings and you'll close the portal, stop the ritual, but you'll still be trapped down here with me" +
                            ", little fly. The CurseBreaker would only need to return, repair the symbols and wait for the next full moon. You'd delay him, nothing more...'" 
                        },

                        {
                            "You remember Merigold's warning that you have only until the clocks strike twelve. You leverage this knowledge to your advantage...", 
                            
                            "  You tell the creature that you're not going to be beguiled so easily. You don't have" +
                            " to hold out against it forever - only until midnight when the CurseBreaker's dark ritual is complete, " +
                            " and then you'll both be done for. You emphasise your point by asking the creature if they relish the " +
                            "thought of the CurseBreaker's dark metamorphosis - of their body been ripped apart from the inside out by a new" +
                            " creature. You nonchalantly tell her that it sounds painful to you..." +
                            "\n   She does not respond as you expect. The Lady tilts her head as she faces you wryly. " +
                            "\n\t'How little you understand, sweet thing,' she trills, 'We of the Fey Realms do not experience any such thing as" +
                            " pain. The closest we feel to pain is boredom. And there's little chance of that while I have you to" +
                            " play with..." +
                            "\n\t'But fine,' she capriciously changes tack, 'let's play your game instead. Take a look around you, sweet thing.'" +
                            "  She gestures to the runes spiralling through the oubliette, binding it and zeroing in upon the crackling vortex of energy through which you nervously see the ritual pick up its pace as midnight approaches..." +
                            "\n\t'You can stop the CurseBreaker's ritual in a trice,' she tells you coyly, 'all you have to do is disturb the markings" +
                            " upon the floor. Then the portal will close, and you'll be trapped down here playing with me until the CurseBreaker comes after you die of thirst, repairs the runes and completes the ritual upon the next full moon. Sound tempting?' A smile creeps across her gorgeous face as your own pales." +
                            "'No,' she purrs, 'somehow I thought not...'" 
                        },

                        {
                            "You challenge the creature: does it wish to succumb to the CurseBreaker's schemes?",

                            "You tell her the dark metamorphosis that the CurseBreaker has planned sounds like the most agonising ordeal you've ever uncovered."+
                            "\n   She does not respond as you expect. The Lady tilts her head as she faces you wryly. " +
                            "\n\t'How little you understand, sweet thing,' she trills, 'We of the Fey Realms do not experience any such thing as" +
                            " pain. The closest we feel to pain is boredom. And there's little chance of that while I have you to" +
                            " play with..." +
                            "\n\t'But fine,' she capriciously changes track, 'Arcturas is such a serious bore. It'd be fun to spoil his plans. So let's play your game instead. Take a look around you, sweet thing.'" +
                            "  She gestures to the runes spiralling through the oubliette, binding it and zeroing in upon the crackling vortex of energy through which you nervously watch the dark ritual pick up its pace as midnight approaches..." +
                            "\n\t'You can stop the CurseBreaker's ritual in a trice,' she tells you coyly, 'all you have to do is disturb the markings" +
                            " upon the floor. Then the portal will close, and you'll be trapped down here playing with me until you either die of thirst or become my thrall, then the CurseBreaker will come repair the runes and complete the ritual upon the next full moon. Sound tempting?' A smile creeps across her gorgeous face as your own pales." +
                            "'No,' she purrs, 'somehow I thought not...'"
                        }
                    };
                    path = LinearParle(choices_response, parlances, choices, description);
                }
                else if (path == 1)
                {
                    description = "The Lady bounces on the spot and claps her hands, 'Yes! Yes! Such tricks would   fill me with glee'" +
                        "\nShe laughs delightedly, your mind momentarily clasped by a thrill of pleasure at the sight of her" +
                        " so ecstatic. However, her focus is no longer upon you. Her spell is, for the moment broken. You shrug off the shock of " +
                        "lust, if not quite easily, then more quickly than before.";
                    parlances = new List<string>
                    {
                        "She sweeps back her ethereal hair, her serene ''gaze'' locked with yours. 'So,' she trills, 'what game do you" +
                        " wish to make of it?'",

                        "Your gaze latches onto the portal, even to your untrained eye you can see the runes feed into and are bound to the crackling vortex of energy. " +
                        "  Your sights fix on the lone man, back turned to you, continuing his vile chant as the storm rages, a dirge to the moon whose diabolical contents transgress any " +
                        "boundaries of translation. The esoteric words are laced with a palpable evil." +
                        "  'And if you think to try the portal, you might like to test it with a stone first,' the creature informs you, its voice smooth and soft. 'If you" +
                        " want an idea of what will happen to you - or anyone other than me - should you attempt to use it...'" +
                        "\n\nHas Merigold sent you on a fool's errand?"
                    };
                    choices = new List<List<string>>
                    {
                        new List<string>
                        {
                            "Game? You ask the creature what it means...",
                            "You tentatively inquire what the creature has in mind?",
                            "You tell the creature you've no time for games..."
                        },
                        new List<string>
                        {
                            "With the ritual close to completion, you decide you cannot waste any more time on this capricious creature. You run through the portal...",
                            "You decide the creature is trying to trick you. You scuff one of the runes between her and the portal...",
                            "You do as she says. You pick up a stone and throw it through the portal..."
                        }
                    };
                    choices_response = new Dictionary<string, string>
                    {
                        {
                            "You tell the creature you've no time for games...",
                            
                            "  The Lady pouts coyly. 'Sweet thing, don't you know frowns only age you faster? " +
                            " Keep on like that and you'll have wizened into a corpse in no time.' She titters at the thought." +
                            " But though you can sense the tendrils of her spell attempting to lure you once again into manic ecstasy at her thrilling laugh, you" +
                            " maintain your steely stare. " +
                            "\n You repeat yourself. Midnight approaches, and if you were the creature you'd be less focused on games and more worried about the" +
                            " prospect of the agonising dark metamorphosis the CurseBreaker has planned for her. Does she really want to be devoured from the inside out by some " +
                            "foul and mutated CurseBreaker?" +
                            "\n   She does not respond as you expect. The Lady tilts her head as she eyes you wryly. " +
                            "\n\t'How little you understand, sweet thing,' she trills, 'We of the Fey Realms do not experience any such thing as" +
                            " pain. The closest we feel to pain is boredom. And there's little chance of that while I have you to" +
                            " play with..." +
                            "\n\t'But fine,' she capriciously changes track, 'Arcturas is such a serious bore. It'd be fun to spoil his plans. So let's play your game instead. Take a look around you, sweet thing.'" +
                            "  She gestures to the runes spiralling through the oubliette, binding it and zeroing in upon the crackling vortex of energy through which you nervously watch the dark ritual pick up its pace as midnight approaches..." +
                            "\n\t'You can stop the CurseBreaker's ritual in a trice,' she tells you coyly, 'all you have to do is disturb the markings" +
                            " upon the floor. Then the portal will close, and you'll be trapped down here playing with me until you either die of thirst or become my thrall, then the CurseBreaker will come repair the runes and complete the ritual upon the next full moon. Sound tempting?' A smile creeps across her gorgeous face as your own pales." +
                            "'No,' she purrs, 'somehow I thought not...'"
                        },
                        
                        {
                            "You tentatively inquire what the creature has in mind?", 
                            
                            "'Why a game, silly,' she titters delightedly. Then breathlessly addresses you. 'It'll be so much fun spoiling the CurseBreaker's plans, but so" +
                            " much more fun if we play a game to see who gets the chance to seal his fate! You see the runes around you, binding us inside this place?' She motions to the esoteric symbols -" +
                            " all arcing through the oubliette, catching you in their ghostly glow. 'Scuff them and the portal will disappear. Abracadabra! Just like that!'" +
                            " She turns coy, her expression sly, 'But do so and you'll just be trapped here with me until you die of thirst or become my thrall - and that's nowhere near as much fun as what *I* have in mind,' she giggles. " 
                        },

                        {
                            "Game? You ask the creature what it means...", 
                            
                            "Once again the Lady positively enchants you with her bubbly glee. She bounces and claps her hands. 'A game, silly!' she laughs merrily. 'a game where the stakes are higher than you can imagine! "+
                            "It'll be so much fun spoiling the CurseBreaker's plans, but so" +
                            " much more fun if we play a game to see who gets the chance to seal his fate! And the loser gets sealed away in here forever! You see the runes around you, binding us inside this place?' She motions to the esoteric symbols -" +
                            " all arcing through the oubliette, catching you in their ghostly glow. 'Scuff them and the portal will disappear. Abracadabra! Just like that!'" +
                            " She turns coy, her expression sly, 'But do so and you'll just be trapped here with me until you die of thirst or become my thrall - and that's nowhere near as much fun as what *I* have in mind,' she giggles." 
                        }
                    };
                    path = LinearParle(choices_response, parlances, choices, description);
                }
                else
                {
                    description = "You discover she is right. Your body does wish to follow her words. In fact," +
                        " your body yields to her commands so much more naturally than it does your own thoughts." +
                        " You succumb further to the intoxicating haze of bewildering emotions enrapturing your mind," +
                        " breathing a heavy and dreamy sigh as you soak in the delicate contours of her face, the arch of her" +
                        "eyebrows, the shape and fluid motions of her body, and above all the way her skin glows like a bewitching full moon.";
                    parlances = new List<string>
                    {
                        "How elated you feel to have the chance to be caught in the captivating presence of such a" +
                        " wondrous creature. What an ecstasy of sorrow you feel that it should be trapped so. How thrilling" +
                        " the anticipation - to speculate how even more beautiful, how even more enthralling, the Lady would be" +
                        " when released." +
                        "\n  All thoughts of that bumbling fool Merigold, of those loser prisoners, of the CurseBreaker - they" +
                        " all begin to fade away, as Myrovian spires fade into folds of darkness when night falls." +
                        "\n  As your heart flutters so breathlessly fast, like a frenzied bird batting its wings against its cage, you are certain of one thing." +
                        " You have never before felt so excited..."
                    };
                    choices = new List<List<string>> 
                    { 
                        new List<string>
                        {
                            "You dance around her pentagram, wishing nothing more than to delight her...",
                            "You stare moon-eyed at the lovely creature and drool longingly...",
                            "You seek to impress her. You gallantly stride through the portal and challenge the CurseBreaker to a duel for her hand in marriage..."
                        }
                    };
                    choices_response = new Dictionary<string, string>  
                    {
                        {"You dance around her pentagram, wishing nothing more than to delight her...", "" },
                        {"You stare moon-eyed at the lovely creature and drool longingly...", "" },
                        {"You seek to impress her. You gallantly stride through the portal and challenge the CurseBreaker to a duel for her hand in marriage...", "" }
                    };
                    path = LinearParle(choices_response, parlances, choices, description);
                    if(path == 0)
                    {
                        Console.WriteLine("Your enter into a fever of dizzyingly quick steps, your footfalls a flurry of clicking heels as you spin and spin and spin... The Lady truly is delighted to see it as you scuff the runes and close the portal. You succeed in ruining the CurseBreaker's plans for tonight, but by the time of the next full moon you shall have danced yourself to exhaustion - a corpse decorating the cell of the CurseBreaker's most prized prisoner.");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }
                    else if (path == 1)
                    {
                        Console.WriteLine("\n'You have no choice but to help me now,' the voice becomes silky, smooth and impossible to ignore. It slips beneath your skin. It's words writhe behind your eyelids and inside your mind. You feel yourself become dazed and listless, darkness cloaking the edges of your vision as you can hardly keep a grasp of your own thoughts and will. When you turn to face the Lady you find she's more beautiful than ever, with an hypnotic aspect that makes your heart shudder. " +
                            "\nThe runes around you seem to momentarily pulse with light, catching your figure in their ghostly luminescence - like a fly caught in a spider's web..." +
                            "\n\t'Now, release me...' the creature beckons you with long nails, each syllable electrifying you with a new delicious ecstasy, each one better than the last. It becomes impossible to resist. Too pleasurable to obey.");
                        Console.ReadKey(true);
                        Console.WriteLine("The moment your foot scuffs the pentagram is the last moment of your life...");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("You succeed in throwing off the rhythm of the Cursebreaker's dirge at least, as your spaghettified guts splatter upon his shoes. All the while the creature below laughs with naked delight.");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }

                }
                if (_player.midnightClock != null)
                {
                    _player.midnightClock.Stop();
                    long timeTaken = _player.midnightClock.ElapsedMilliseconds;
                    _player.midnightClock.Start();
                    long timeToMidnight = 1800000;
                    long timeLeft = (timeToMidnight - timeTaken) / 60000;
                    if (timeLeft < 0)
                    {
                        Console.WriteLine("\nMidnight is upon you!");
                        Console.ReadKey(true);
                        Console.WriteLine("Throughout the tower all the clocks chime the hour. Even from the oubliette you hear " +
                            "them. The pale ghostly light of the runes catch your final look of fright, before all the lights go out and darkness falls." +
                            " Your interlocutor disappeared with them, swept into the portal that turned, for but an instant, blood moon red, before it too vanished. " +
                            "  \n  You are left alone only for a few tense moments, dreading what is to follow, before a blood-curdling howl erupts from above" +
                            " as something new and terrible is brought into the world. Soon afterwards, the tower collapses in on you... ");
                        Console.ReadKey(true);
                        Console.WriteLine("At least you never caught sight of the horror your lack of urgency unleashed.");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        return false;
                    }

                }
                if (path == 0)
                {
                    Console.WriteLine("The Lady says nothing as she hears your footsteps clap away towards the portal" +
                        ". Looking back you catch her listening attentively, gleefully waiting to see if you'll do as you" +
                        " intend. Feeling a knot of dread before the swirling vortex you brace yourself to jump...");
                    Console.ReadKey(true);
                    Console.WriteLine("You do not hear the Lady's laughter. It does not follow you into death as your body" +
                        " is torn asunder in an instant of exquisite agony. If it had, you'd have thought it the most wondrous aria of mirth you'd ever heard...");
                    Console.ReadKey(true);
                    Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                    return false;
                }
                else if (path == 1) 
                {
                    Console.WriteLine("The moment your foot scuffs the symbols, near complete darkness falls. The portal does indeed disappear. But the pentagram remains locking the creature in place. You have been shown a mercy. For had you disturbed the runes within the pentagram what would've awaited you would've been a fate worse than death.");
                    Console.ReadKey(true);
                    Console.WriteLine("As it is, you shall instead die of thirst, as the ladder's enchantment and locked hatch seal your exit. The CurseBreaker's transformation shall be completed during the next full moon...");
                    Console.ReadKey(true);
                    Console.WriteLine("Your adventure ends here...");
                    Console.ReadKey(true);
                    return false;
                }
                else
                {
                    description = "Sparing the Lady a wary glance you pick up a nearby stone." +
                        " Hurling it at the portal, you watch as it's caught midair, seems" +
                        " to hover a moment, then crumples to dust as though ground by an " +
                        "invisible fist.";
                    parlances = new List<string> 
                    { 
                        "\n'Do you believe me now, little one,' the Lady's voice creeps up on" +
                        " you from behind, sending a chill all the way up your spine. 'Our fates" +
                        " are tangled. The only way to break the bond I have with that portal, " +
                        "that excludes anyone else from using it, is to break the pentagram at " +
                        "my feet. So,' she concludes, her lips parting into that arresting cat-like" +
                        " smile, as you once again draw towards her, 'will you play?'",

                        "'I have often been delighted at tales of your silly human ideas,' " +
                        "she purrs softly, her movements so wonderfully fluid and seductive" +
                        " as she paces within the pentagram, 'ethics and justice, right and wrong." +
                        " Such things seem so silly. What justice is there in a typhoon. What morals" +
                        " keep a tiger from devouring its prey, the tiny mouse from finding itself" +
                        " consumed by the snake...' her pink tongue runs along her pearly white teeth," +
                        " 'the little fly from being ensnared by the tarantula?" +
                        "\n\t'Tell me,' she inquires softly, 'what about me is so different from them?" +
                        " Are we not just all creatures of whim, of desire, of our own nature... What is it" +
                        " of my nature that so frightens you, Little one?' her cat-like smile returns and " +
                        "sends your heart racing. 'It's only natural for you to surrender to me...'",

                        "\n\t'Curses are neither good nor evil, little one,' she purrs, 'they are simply " +
                        "nature finding balance - The wheel of fortune turning, unsteered by any mortal hands." +
                        " Does not the rabbit rejoice when the fox chokes on its bones? Does the kingdom misruled by a tyrant" +
                        " care whether it is a just man that brings down the dagger or a fatal illness?" +
                        "\n'When morals become the dirge of the mighty over the weak, " +
                        "\nwhen justice is adjudicated and administered by the corrupt and venal," +
                        " \nand when mortals smother the secrets their actions wrought with silence," +
                        " \nWhat other recourse is there but the balance brought by time and chance?" +
                        " \n  What other hope is there bolstering those who suffer and keeping them waiting out the darkness, so that they might finally bask in the dawn.'" +
                        "  The eldritch creature turns to you, and for the first time you catch a glimmer of what she truly is," +
                        " the same force that turned colliding galaxies into new worlds. The cycle of creation and destruction." +
                        "\n\t'You see,' her silky voice caresses your mind, 'I told you true when I first called to you in the darkness;" +
                        " \n\t'...he schemes for the downfall of the unruled, the whimsical, the free, \nAdventurers who dare stand up to power and restore the balance, \n\tlike you, \n\t\tlike me...'" +
                        "\n\n  Her head turns from you to face the dark silhouette through the portal. His evil chant picks up the pace, as lightning flashes above him and thunder roars... \n\n  'To defeat the one who'd make himself tyrant of hope and chance, your only choice is to unleash me...'",

                        "  Every game has rules. You ask the Lady what hers are..." +
                        "\n\tShe claps her hands delightedly and gasps with glee. 'It's simple,' she replies," +
                        " 'Once you scuff the markings of this pentagram I shall no longer be bound to the portal. Within this " +
                        "chamber I shall roam free though still caught by the CurseBreaker's other enchantments - the same ones that keep you here." +
                        " However,' she continues coyly, 'the portal shall remain, only capable of transporting one of us to the highest parapet of this tower. The portal's magics were weaved such that only one may use it. Who that is depends on who should reach it first...'"
                    };
                    choices = new List<List<string>> 
                    { 
                        new List<string>
                        {
                            "You say you won't free a malignant creature such as her under any circumstances...",
                            "You openly wonder whether Merigold would ever countenance dealing with such a monster...",
                            "You tell her that the CurseBreaker may be bad, but you assert she's pure evil..."
                        },
                        new List<string>
                        {
                            "You tell her that she is pure chaos...",
                            "You say that she is remorseless and that the destruction she'd cause if free would be senseless...",
                            "You reply that she is capricious, untrustworthy and far too powerful...",
                            "You claim you do not know exactly, but you know you're right..."
                        },
                        new List<string>
                        {
                            "You ask her how you can be sure she won't just kill you the moment she's free...",
                            "You ask why she thinks she's the only one who can kill the CurseBreaker..."
                        },
                        new List<string>
                        {
                            "So you want to battle for the chance to use the portal?",
                            "So you want to race for the portal?"
                        }
                    };
                    if (mosaic.SpecificAttribute == "studied")
                    {
                        choices[1].Insert(0, "You recall the peculiar mosaic's words from the Antechamber. With a shock of recognition you realise this must be the creature from the CurseBreaker's past. You confront her with her appalling crimes...");
                    }
                    choices_response = new Dictionary<string, string>
                    {
                        {
                            "You say you won't free a malignant creature such as her under any circumstances...",
                            
                            "'Malignant?' the Lady seems bemused by the notion."
                        },
                        {
                            "You openly wonder whether Merigold would ever countenance dealing with such a monster...",
                            
                            "'Monster?' the Lady seems bemused by such a notion."
                        },
                        {
                            "You tell her that the CurseBreaker may be bad, but you assert she's pure evil...",
                            
                            "'Evil?' the Lady seems bemused by such a notion."
                        },
                        {
                            "You recall the peculiar mosaic's words from the Antechamber. With a shock of recognition you realise this must be the creature from the CurseBreaker's past. You confront her with her appalling crimes...",

                            "The Lady titters as she seems to reminisce on her first meeting with the" +
                            " CurseBreaker. 'Oh, even then Arcturas was no fun - He didn't like the games" +
                            " I taught the other children to play...'" +
                            "\n  She turns her attention back to you, tilting her head curiously. 'Those" +
                            " adventurers leapt at the chance to deliver their ''justice'' to the parents of that village. I wonder if you would too?'" +
                            "\n\n   You assert you'd never do what they did... never.\n" +
                            "\n\t'Wouldn't you?' she fixes you once again with that knowing smile. You wipe your sweaty hands down your front. 'I" +
                            " always find it *fascinating* how much more sadistic the self-righteous can be than those" +
                            " who are simply cruel. All their sanctimonious talk, all their acts in the name" +
                            " of ''what's right'', all of it is just another game played by neighbours, concealing what they'd *really*" +
                            " do to each other if given the chance. And all that's needed to unleash those darkest desires is" +
                            " to assure them that it'll be seen as ''good''. To seduce them with morals and ethics and justice.'" +
                            "\n\n  You tell her that she's worse than any curse for what she did... she's pure chaos." +
                            "'Chaos?' she breathes, delighted by the suggestion. Her laughter once" +
                            " again is in danger of enrapturing you. 'Oh, sweet thing, you do not know how" +
                            " right you are...'" +
                            "\n  You ask her to explain herself. " +
                            "\n\t'The CurseBreaker knows it,' she replies coyly, 'but I suppose Merigold " +
                            "hasn't a clue, poor fool. Years upon years he studied curses. Never has he uncovered" +
                            " more than a veneer of the truth...'"
                        },
                        {
                            "You tell her that she is pure chaos...",
                            
                            "'Chaos?' she breathes, delighted by the suggestion. Her laughter once" +
                            " again is in danger of enrapturing you. 'Oh, sweet thing, you do not know how" +
                            " right you are...'" +
                            "\n  You ask her to explain herself. " +
                            "\n\t'The CurseBreaker knows it,' she replies coyly, 'but I suppose Merigold " +
                            "hasn't a clue, poor fool. Years upon years he studied curses. Never has he uncovered" +
                            " more than a veneer of the truth...'"
                        },
                        {
                            "You say that she is remorseless and that the destruction she'd cause if free would be senseless...",
                            
                            "You surmise by telling her that her powers would be no better than a curse upon" +
                            " the good people of this world... \nYou stop to find her laughing at your words, but for once " +
                            "her laughter does not elicit anything from you other than anger. " +
                            "\n  You demand to know what you said that's so humorous." +
                            "\n\t'Oh, sweet thing,' she answers, 'you do not know how" +
                            " right you are...'" +
                            "\n  You ask her to explain herself. " +
                            "\n\t'The CurseBreaker knows it,' she replies coyly, 'but I suppose Merigold " +
                            "hasn't a clue, poor fool. Years upon years he studied curses. Never has he uncovered" +
                            " more than a veneer of the truth...'"
                        },
                        {
                            "You reply that she is capricious, untrustworthy and far too powerful...", 
                            
                            "She dishes you a coquettish and yet knowing smile, like a cat that knows its prey is already trapped." +
                            " 'But of course,' the Lady trills, 'Those are the things that are in my nature, and always shall be." +
                            " Your kind has always bestowed our twilight race with gentle names and wondrous tales, yet we are " +
                            "not so dissimilar to another force of magic in this world - one which you fear and wish to" +
                            " expunge.'" +
                            "\n  You ask her what that might be?" +
                            "\n\t'Is it not obvious,' she purrs. 'Our nature is one with curses, those that bind the threads of men's deeds to their fates." +
                            " You suppose such things to be terrible. You call them capricious and powerful and cruel. Yet those are only " +
                            "what you call them because you cannot control them.'"
                        },
                        {
                            "You claim you do not know exactly, but you know you're right...", 
                            
                            "'Oh sweet thing,' she trills, 'so very very ignorant. We are not so different " +
                            "from another entity that afflicts your world. One with which your kind has had " +
                            "intimate contact with.' She seems to sense the frown furrowing your brow, for she smiles," +
                            " delighting in the captivating anticipation she seeks to hang you with." +
                            "\n  Finally, and with more than a knot of foreboding, you ask her what that might be." +
                            "\n 'But curses, of course...'\n"
                        },
                        {
                            "You ask her how you can be sure she won't just kill you the moment she's free...",

                            "'Oh, sweet thing,' she titters, 'but of course I'm going to try to kill you." +
                            " That's what makes this game is so fun!'"
                        },
                        {
                            "You ask why she thinks she's the only one who can kill the CurseBreaker...",

                            "She tilts her head once more and dishes you a bemused grin. 'I'm not,' she purrs, 'why the" +
                            " CurseBreaker is only a man, little fly. Anyone can run him through with steel - if you hurry." +
                            "\n\n\t'Tick, tock says the clock,' she trills, 'splice and dice time into blocks," +
                            "\n\tcut and slice, don't play nice, spin their fate, set the date, cast all men into their box...'\n"
                        }
                    };
                    path = LinearParle(choices_response, parlances, choices, description);
                }
                if (_player.midnightClock != null)
                {
                    _player.midnightClock.Stop();
                    long timeTaken = _player.midnightClock.ElapsedMilliseconds;
                    _player.midnightClock.Start();
                    long timeToMidnight = 1800000;
                    long timeLeft = (timeToMidnight - timeTaken) / 60000;
                    if (timeLeft < 0)
                    {
                        Console.WriteLine("\nMidnight is upon you!");
                        Console.ReadKey(true);
                        Console.WriteLine("Throughout the tower all the clocks chime the hour. Even from the oubliette you hear " +
                            "them. The pale ghostly light of the runes catch your final look of fright, before all the lights go out and darkness falls." +
                            " Your interlocutor disappeared with them, swept into the portal that turned, for but an instant, blood moon red, before it too vanished. " +
                            "  \n  You are left alone only for a few tense moments, dreading what is to follow, before a blood-curdling howl erupts from above" +
                            " as something new and terrible is brought into the world. Soon afterwards, the tower collapses in on you... ");
                        Console.ReadKey(true);
                        Console.WriteLine("At least you never caught sight of the horror your lack of urgency unleashed.");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        return false;
                    }

                }
                if (path == 0)
                {
                    Console.WriteLine("The Lady of the ArchFey only greets your response with" +
                        " laughter. And once again you are struck by its melody. It almost seems" +
                        " to resonate and chime with every lustrous and beautiful memory you can" +
                        " conjure to mind. But there is also something else underneath that laugh" +
                        " now. Something terrible, something that turns that resonance into the" +
                        " tremors of prey about to be caught, the shiver of an animal starving" +
                        " in the dead of winter. And for once, upon the horizon of your senses," +
                        " you detect a stranger; some amorphous silhouette of " +
                        "pure, undiluted terror - distant, but" +
                        " closing in fast...");
                    Console.ReadKey(true);
                    return true;
                }
                else
                {
                    Console.WriteLine("The Lady giggles excitedly, before coyly addressing you. 'Mmm... Not much time left. Make your move, little fly...'");
                    Console.ReadKey(true);
                    return true;
                }
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class FinalAct : Dialogue
    {
        private Player _player { get; set; }
        private Monster CurseBreaker { get; set; }
        public FinalAct(Player player, Monster curseBreaker) : base(player, curseBreaker)
        {
            {
                _player = player;
                CurseBreaker = curseBreaker;
            }
        }
        /// <summary>
        /// The final confrontation with the CurseBreaker upon the highest Parapet.
        /// It's a dialogue subclass that is only three levels deep (unlike ArchFey which was twelve) but
        /// is just as long because of how customised it is to player traits and discoveries that
        /// vary what is or what can be said immensely. Thespians, jinxed and friends with fairies
        /// will all have different interactions with the CurseBreaker. LinearParle is used here.
        /// </summary>
        /// <param name="oubliette"></param>
        /// <param name="specialItems"></param>
        /// <param name="staffMG"></param>
        /// <param name="vanquisher"></param>
        /// <param name="ghoul"></param>
        /// <returns></returns>
        public int Denouement(Room oubliette, List<Item> specialItems, Weapon staffMG, Weapon vanquisher, Monster ghoul)
        {
            Dialogue denouement = new Dialogue(_player, CurseBreaker);
            if (oubliette.FirstVisit)
            {
                Console.WriteLine("Your stomach lurches the moment you find yourself consumed, " +
                    "sucked in, by the crackling magics of the portal. In an instant you've " +
                    "left gravity behind as you weightlessly float through exotic landscapes " +
                    "and distant places, all surging by you at breakneck speeds. Time becomes " +
                    "a flurry of disjointed instants, snapshots of places beheld amidst the " +
                    "enveloping whorl of energy. It's not before long you find yourself " +
                    "plummeting to a new location...");
                Console.ReadKey(true);
                Console.WriteLine("\n  You emerge upon a windswept towertop. Thunder crashes overhead as an" +
                    " avalanche of thunderheads roil in the dark skies above. The gale snatches at your garb" +
                    " and tosses your hair back. You blink in the face of this fierce storm, biting sleet " +
                    "lashing at you as you espy a lone figure facing away from you and beseeching the " +
                    "tempest with ghastly utterances that can be nothing other than the diabolical rite." +
                    "\n  Before you stands the CurseBreaker - and his ritual is already close to completion. ");
                Console.ReadKey(true);
                Console.WriteLine("Noticing you, he pauses before pivoting to face you... a look of " +
                    "disbelief on his face as he recognises you as one of his captors.");
                Console.ReadKey(true);
            }
            if (!oubliette.FirstVisit)
            {
                string description = "Slowly the disbelief on the CurseBreaker's face chills to an icy appraisal...";
                List<string> parlances = new List<string>
                {
                    "",

                    "  \n\t'Do you imagine' he intones as his unsettling darker than black eyes " +
                    "appraise you, 'that I don't know your past deeds, your regrets, your every weakness?'" +
                    $"  He leers. 'I see them all, {_player.Name}, a litany of sins laid bare before me...'",

                    "\n\t'Such an irony, then, that I should be stalled by the greatest curse of them all; adventurers and their ilk. " +
                        " And now,' the CurseBreaker scoffs, 'you dare to pontificate to *me*? Your kind are a bane unto this " +
                        "world. Your capricious meting of frontier justice and exploitation of the desperate is nothing more" +
                        " than naked vandalism of the righteous order. Like a Curse you spread. You exploit the vulnerable, impoverish them, and exacerbate feuds," +
                        $"endlessly repeating a vicious cycle of violence and chaos. " +
                        $"\n\t'No, {_player.Name},' The CurseBreaker intones icily, 'the hero of this story is not you. It's me...'",

                        "\n\n\t'Now...' the CurseBreaker hisses as he paces, 'enough of this! I shall ascend and if it has to be upon the next full moon - So be it! I'll deliver Merigold the final sentence that he deserves. Directly after I eliminate you!'" +
                        "  It is then that the CurseBreaker reveals a gloved hand - some cursed artefact that he'd been patiently charging with magic all whilst he" +
                        " bought time exchanging words with you. He booms an incantation and instantly the flagstones beneath your feet crack and crumble as three eerie totems rise out of the ground. They are each knotted roots in the shape of hands and they clutch gemstones in their vice like grip that cast a protective aura about the CurseBreaker. " +
                        "\n   Assured of his invulnerability, he leers at you as he turns that cursed glove your way and casts a lightning bolt at you!"
                };
                List<List<string>> choices = new List<List<string>>
                {
                    new List<string>
                    {
                        "Tell the CurseBreaker its all over...",
                        "State with iron resolve that you're going to make sure the CurseBreaker pays for his crimes...",
                        "You make evident your relish at a chance for vengeance...",
                        "Flippantly tell him Merigold sends his regards..."

                    },
                    new List<string>
                    {
                        "You scoff. Whatever you might've done in the past pales by comparison to the CurseBreaker's own deeds...",
                        "You rebuke his presumptive verdict - you've done nothing you're ashamed of. The CurseBreaker, on the other hand...",
                        "You threaten that you'll sin more yet, and he'll have a first-hand account of it..."
                    },
                    new List<string>
                    {
                        "You challenge him; if he's justice then why'd he rob Merigold of his home and enslave him?",
                        "You assert that taking all that power for himself would corrupt him more than any of those he deems 'wicked'...",
                        "You tell him that taking the power to gaze into people's secrets and blackmailing them won't 'prevent' evil, only inhibit them from being free to do what's right...",
                        "You argue that he's wrong. Justice is too much for any one person or group. Power to administer it needs to be shared...",
                        "You retort; how can he call what he does justice when he hires an evil mercenary company to do his bidding?",
                        "You accept that The CurseBreaker's right...",
                        "You tell him you don't give a damn about his arguments. You're just here to bring him down..."

                    },
                    new List<string>
                    {
                        "Dodge to the left...",
                        "Dive to the right...",
                        "Leap backwards...",
                        "Lunge forwards..."
                    }
                };

                if (_player.WeaponInventory.Contains(vanquisher))
                {

                    choices[0].Add("Unsheathe the sword of sealed souls before the CurseBreaker...");
                }
                else if (_player.WeaponInventory.Contains(staffMG))
                {
                    choices[0].Add("Tighten your grip on Merigold's staff and brace yourself...");
                }
                else if (_player.WeaponInventory.Count > 0)
                {
                    choices[0].Add("Unsheathe your weapon and prepare for the duel of your life...");
                }
                if (_player.Traits.ContainsKey("jinxed"))
                {
                    choices[0].Insert(0, "You coolly begin telling the CurseBreaker that its over, before you stumble over a loose flagstone...");
                    choices[0].RemoveAt(1);
                    choices[0].Insert(1, "You blearily look around; 'Excuse me, is this the highest parapet? Only I've got to be there before midnight...'");
                    choices[0].RemoveAt(2);
                    choices[0].Insert(2, "You try your best to look menacing...");
                    choices[0].RemoveAt(3);
                    choices[0].Insert(3, "Tell him Merigold says 'Sayonara'... Or is it 'konnichiwa'? You're not sure...");
                    choices[0].RemoveAt(4);
                }
                if (_player.Traits.ContainsKey("thespian"))
                {
                    choices[0].Insert(0, "Gallantly proclaim that the CurseBreaker's tyranny ends here...");
                    choices[0].RemoveAt(1);
                    choices[0].Insert(1, "With a wry smile concealing the ordeal you've just been through, you declare the CurseBreaker shall pay for his atrocities...");
                    choices[0].RemoveAt(2);
                    choices[0].Insert(3, "Nonchalantly inspect your nails as you airily give him Merigold's regards...");
                    choices[0].RemoveAt(4);
                }
                if (_player.Traits.ContainsKey("friends with fairies"))
                {
                    choices[0].Insert(1, "Rave that his transgressions against fairy-kind shall not go unanswered...");
                    choices[0].RemoveAt(2);
                    choices[0].Insert(2, "Tell him you're here with your fairy friends to place him under fairy arrest. Read him his rights...");
                    choices[0].RemoveAt(3);
                }
                if (_player.Traits.ContainsKey("sadist"))
                {
                    choices[0].Insert(2, "You leer and detail all the ways you'll make the CurseBreaker suffer...");
                    choices[0].RemoveAt(3);
                }
                Dictionary<string, string> choices_response = new Dictionary<string, string>
                {
                    {
                        "Tell the CurseBreaker its all over...",

                        "  The CurseBreaker fixes you with eyes as dark as the void between stars - eyes that once " +
                        "belonged to that monster below but that now icily appraise you. You feel his gaze on you, " +
                        "feel those eyes peer through you and beyond the present moment. You can feel his gaze crawl" +
                        " under your skin and peruse every past deed, every mistake, every regret..." +
                        "\nA chilling smile slips upon his thin lips. His bearing, even now, is one of self-assurance" +
                        ", as though he were untouchable by some divine providence." +
                        $"\n\t'Oh, {_player.Name}...' he regards you with an expression as foreboding as an endless frozen tundra," +
                        $" 'You have no clue with what it is you meddle...' "
                    },

                    {
                        "State with iron resolve that you're going to make sure the CurseBreaker pays for his crimes...",

                        "  He barks with callous laughter before your bold declaration. He never once takes his" +
                        " eyes off of you. Those twin orbs, blacker than volcanic glass, torch you with their gaze." +
                        " You can feel them probe your past, glimpse your innermost desires and lay bare your secrets" +
                        " for his cold perusal." +
                        " \n\t'My, my...' he brandishes a sabre, slicing the air like it was silk, 'The adventurer fancies" +
                        " themselves judge, jury and executioner.' He leers. 'Some things truly never change...' "
                    },

                    {
                        "You make evident your relish at a chance for vengeance...",

                        "  He responds with self-righteous vindication, tilting his head back slightly as he" +
                        " regards you with icy disdain. Those eyes, blacker than caves from which no one returns, " +
                        "scour your very soul - their gaze reaches past the present moment and clasps upon every" +
                        " past deed, every act you regretted and each one of your weaknesses. He judges you for your" +
                        " moral worth within but a moment and finds it wanting." +
                        "\n\t'You think you have a chance against me?' He intones as he glacially unsheathes his sabre," +
                        " 'I am this world's last chance for order, for justice upon the wicked. Do you truly believe I'd let" +
                        " a villain such as you throw that all away to satisfy some misguided, base revenge? No..." +
                        "\n'The days of adventurers and the crude 'justice' they mete out - of mercenaries wearing the guise of heroes - is over...'"
                    },

                    {
                        "Flippantly tell him Merigold sends his regards...",

                        "  His expression curdles into a scowl for only a moment, before his eyes narrow and he regards you" +
                        " with icy disdain. " +
                        "\n\t'So,' he breathes, his voice as smooth as dark lakes with treacherous depths, 'the old fool" +
                        " even now fails to see reason. I spare him his life, in spite of all his crimes, and this is how " +
                        "my mercy is repaid?' His expression darkens, like dusk falling into the depths of night. 'I was " +
                        "weak to not sentence him to his rightful demise - A mistake I shan't make again...' " +
                        "\n  His unsettling focus then latches upon you once again and you find yourself caught, like someone " +
                        "drowning and seized by unseen currents. Eyes" +
                        " blacker than the fathomless depths of subterranean rivers, probe you and instantly see all your weaknesses," +
                        " your regrets and your secrets - the ghosts of your past deeds laid bare as though the CurseBreaker's" +
                        " stare could creep under your skin and into your history." +
                        $"\n\t'Oh, {_player.Name}...' he regards you with an expression as foreboding as an endless frozen tundra," +
                        $" 'You have no clue with what it is you meddle...' "
                    },

                    {
                        "Unsheathe the sword of sealed souls before the CurseBreaker...",

                        "  The CurseBreaker's focus instantly shifts from you to the moonlit blade in your hand," +
                        " a spectral mist swimming along its length. He grimaces, his expression betraying an unmistakeable " +
                        "wariness of the powerful weapon in your hand." +
                        "\n\t'The Sword of Sealed Souls...' he murmurs, disquieted by the blade's gleam. Then, he scathes, 'You *have* " +
                        "been busy, haven't you...'" +
                        "\n  He fixes you once again with his eyes, all aloofness and arrogance he'd hitherto displayed" +
                        " replaced by a baleful and intense focus. With that weapon in your hands, he knows full well that" +
                        " you are beyond dangerous and he dare not underestimate you. He unsheathes his sabre as his gaze clasps sight of every one of your weaknesses and secrets." +
                        " He reads them like they were runes etched into your bones." +
                        "\n\t'You have no idea what you're doing,' he seethes. 'I am the justice that shall punish the wicked. I am this world's only hope for peace...'"
                    },

                    {
                        "Tighten your grip on Merigold's staff and brace yourself...",

                        "  The CurseBreaker's focus instantly shifts from you to the gleaming rosewood staff in your hands. " +
                        "He scoffs. " +
                        "\n\t'So,' he intones, his tone treacherously soft, 'you uncovered my secrets and found the old " +
                        "fool's staff in the process. Do you imagine this gives you the upper hand?'" +
                        "\n He unsheathes his sabre with a flourish - with the flair of a true duellist." +
                        "\n\t'Even if you can counter my magic,' he proclaims, 'you are still far from being able to match my abilities...'"
                    },

                    {
                        "Unsheathe your weapon and prepare for the duel of your life...",

                        "  He barks with callous laughter before at the sight of your crude weapon, however he never once takes his" +
                        " eyes off of you. Those twin orbs, blacker than volcanic glass, torch you with their gaze." +
                        " You can feel them probe your past, glimpse your innermost desires and lay bare your secrets" +
                        " for his cold perusal." +
                        "\n\t'Do you truly, for a single moment, think you stand a chance against me?' he jeers."
                    },

                    {
                        "You coolly begin telling the CurseBreaker that its over, before you stumble over a loose flagstone...",

                        "  The CurseBreaker watches you stumble, eyeing you with aloof disdain as you" +
                        " hastily scramble to your feet and dust yourself off. You, rather lamely, finish your bold declaration..." +
                        "  The CurseBreaker's cold eyes, darker than black, spare you a glance over. He instantly " +
                        "sees all your oafish antics, every misfortune. The near-endless parade of jinxed encounters and blunders that is your life story" +
                        " unveil themselves before his eyes. " +
                        "\n  He looks upon you with more than a tincture of derisive incredulity. " +
                        "\n\t'How,' he remarks disbelievingly, 'in all the seven hells did you, of all people, make it this far?'" +
                        "\n  Then his cold contempt congeals into a jeery laugh. For a moment, it seems, he thought he was" +
                        " in trouble. Now he unsheathes his sabre with a flourish as he arrogantly leers your way."
                    },

                    {
                        "You blearily look around; 'Excuse me, is this the highest parapet? Only I've got to be there before midnight...'",

                        "  The CurseBreaker does not reply. The answer dawns on you soon enough," +
                        " but not before he surveys you with incredulous derision." +
                        "\n\t  'Right, right...' you say, 'of course it is. No roof...' You point up " +
                        "to the raging storm above by way of explanation. 'Yep.'" +
                        "\n  Thunder crashes overhead, making you jump with fright. You accidentally " +
                        "land on a loose flagstone, which in turn catapults a stray stone the CurseBreaker's way." +
                        " He deflects it with a lazy swish of his sabre all while continuing to glower your way." +
                        "\n\t'Sorry!' you call out. 'Sorry... Didn't mean for... didn't mean to do that...' Then you" +
                        " suddenly realise who you're addressing. You gasp, 'Wait! That means you must be the CurseBreaker! - I've" +
                        " come to bring an end to your evil... uhm, evil-doing!'" +
                        "\n  The CurseBreaker glances you over with eyes darker than black, and you feel his cold disdainful " +
                        "gaze probe your past deeds and mistakes... *Many* mistakes. The mardi-gras carnival of oafish blunders" +
                        " and jinxy mayhem that compose your bewildering adventuring career are laid bare before him..." +
                        "\n\t'How,' he asks, mystified, 'in all the seven hells did you, of all people, make it this far?'" +
                        "\n  Then his cold contempt congeals into a jeery laugh. " +
                        " He arrogantly leers your way."
                    },

                    {
                        "You try your best to look menacing...",

                        "  You channel your inner adventurer spirit and make a mean face. Unfortunately, " +
                        "with your somewhat wimpy build, you look about as menacing as a tea cosy..." +
                        "\n  The CurseBreaker glances you over with eyes darker than black, and your " +
                        "attempt at intimidation chills into a shiver, as his gaze roves your past deeds and" +
                        " blunders - oh dear god, so many blunders..." +
                        "\n  The bizzarro cabaret of oafish ineptitude and jinxy pandemonium that agglomerate into" +
                        " your baffling career as an adventurer are laid bare before him..." +
                        "\n\t'How,' he asks, mystified, 'in all the seven hells did you, of all people, make it this far?'" +
                        "\n  Then his cold contempt congeals into a jeery laugh. For a moment, upon sight of the vortex, it seems he'd thought he was" +
                        " in trouble. Now he arrogantly leers your way."
                    },

                    {
                        "Tell him Merigold says 'Sayonara'... Or is it 'konnichiwa'? You're not sure...",


                        "\n\t'What?!' the CurseBreaker retorts, somehow both derisive and completely baffled." +
                        " \n  You explain its... its another language. You think..." +
                        "\n  You were trying to sound cool. Nevermind. " +
                        "\n  The CurseBreaker glances you over with eyes darker than black, and you feel his cold disdainful " +
                        "gaze probe your past deeds and mistakes... *Many* mistakes. The mardi-gras carnival of oafish blunders" +
                        " and jinxy mayhem that compose your bewildering adventuring career are laid bare before him..." +
                        "\n\t'How,' he asks, mystified, 'in all the seven hells did you, of all people, make it this far?'" +
                        "\n  Then his cold contempt congeals into a jeery laugh. " +
                        " He arrogantly leers your way."
                    },

                    {
                        "Gallantly proclaim that the CurseBreaker's tyranny ends here...",

                        "  The CurseBreaker fixes you with eyes as dark as the void between stars - eyes that once " +
                        "belonged to that monster below but that now icily appraise you. You feel his gaze on you, " +
                        "feel those eyes peer through you and beyond the present moment. You can feel his gaze crawl" +
                        " under your skin and peruse every past deed, every mistake, every regret..." +
                        "\nA chilling smile slips upon his thin lips. His bearing, even now, is one of self-assurance" +
                        ", as though he were untouchable by some divine providence." +
                        $"\n\t'Oh, {_player.Name}...' he regards you with an expression as foreboding as an endless frozen tundra," +
                        $" 'You have no clue with what it is you meddle...' "
                    },

                    {
                        "With a wry smile concealing the ordeal you've just been through, you declare the CurseBreaker shall pay for his atrocities...",

                        "  He barks with callous laughter before your bold declaration. He never once takes his" +
                        " eyes off of you. Those twin orbs, blacker than volcanic glass, torch you with their gaze." +
                        " You can feel them probe your past, glimpse your innermost desires and lay bare your secrets" +
                        " for his cold perusal." +
                        " \n\t'My, my...' he brandishes a sabre, slicing the air like it was silk, 'The adventurer fancies" +
                        " themselves judge, jury and executioner.' He leers. 'Some things truly never change...' "
                    },

                    {
                        "Nonchalantly inspect your nails as you airily give him Merigold's regards...",

                        "  His expression curdles into a scowl for only a moment, before his eyes narrow and he regards you" +
                        " with icy disdain. " +
                        "\n\t'So,' he breathes, his voice as smooth as dark lakes with treacherous depths, 'the old fool" +
                        " even now fails to see reason. I spare him his life, in spite of all his crimes, and this is how " +
                        "my mercy is repaid?' His expression darkens, like dusk falling into the depths of night. 'I was " +
                        "weak to not sentence him to his rightful demise - A mistake I shan't make again...' " +
                        "\n  His unsettling focus then latches upon you once again and you find yourself caught, like someone " +
                        "drowning and seized by unseen currents. Eyes" +
                        " blacker than the fathomless depths of subterranean rivers, probe you and instantly see all your weaknesses," +
                        " your regrets and your secrets - the ghosts of your past deeds laid bare as though the CurseBreaker's" +
                        " stare could creep under your skin and into your history." +
                        $"\n\t'Oh, {_player.Name}...' he regards you with an expression as foreboding as an endless frozen tundra," +
                        $" 'You have no clue with what it is you meddle...' "
                    },

                    {
                        "Rave that his transgressions against fairy-kind shall not go unanswered...",

                        "His cold appraisal of you morphing into some measure of bafflement, he focuses" +
                        " those black eyes, darker than volcanic glass, on you. And you can feel his sight" +
                        " extend into your mind..."
                    },

                    {
                        "Tell him you're here with your fairy friends to place him under fairy arrest. Read him his rights...",

                        "You are about to tell him he has the right to a fairy lawyer when the" +
                        " CurseBreaker focuses his black eyes. Darker than the void between stars," +
                        " he snaps his gaze upon you and peers into your mind..."
                    },

                    {
                        "You leer and detail all the ways you'll make the CurseBreaker suffer...",

                        "  He responds with self-righteous vindication, tilting his head back slightly as he" +
                        " regards you with icy disdain. Those eyes, blacker than caves from which no one returns, " +
                        "scour your very soul - their gaze reaches past the present moment and clasps upon every" +
                        " past deed, every act you regretted and each one of your weaknesses. He judges you for your" +
                        " moral worth within but a moment and not only finds it wanting, but recoils in disgust." +
                        "\n\t'You think you have a chance against me?' He intones as he glacially unsheathes his sabre," +
                        " 'I am this world's last chance for order, for justice upon wicked souls such as yours. Do you truly believe I'd let" +
                        " a villain such as you throw that all away to satisfy your debauched sadistic desires? No..." +
                        "\n'The days of adventurers and the crude 'justice' they mete out - of mercenaries wearing the guise of heroes - is over...'"
                    },

                    {
                        "You scoff. Whatever you might've done in the past pales by comparison to the CurseBreaker's own deeds...",

                        "The CurseBreaker responds with scorn. 'Spare me your mercenary morals and " +
                        "principles bandied and sold to the highest bidder!' he spits contemptuously." +
                        " 'Had you not intervened I would've ascended to such power that no one need" +
                        " ever suffer injustice again. With powers that span the Fey Realms and the " +
                        "material plane, I'd have been able to keep any and all curses at bay. And " +
                        "the world would be unified under justice, uncontested and irrefutable! No " +
                        "longer would the arbitrations and whims of the corrupt go unchecked, no longer would " +
                        "mercenaries ply their trade under the maxim of 'might makes right!' I will " +
                        "deliver the world into an age of righteous order - one where no villain can hide" +
                        " their secrets without fear, one where it is the wicked who are hunted and punished" +
                        " - not the good..."

                    },

                    {
                        "You rebuke his presumptive verdict - you've done nothing you're ashamed of. The CurseBreaker, on the other hand...",

                        "\t'You've done nothing to be ashamed of?' the CurseBreaker treats your rebuke with disdain. " +
                        "'You are scarcely any different from any of the other sellswords that plague these lands." +
                        " You all take on quests, selling your services to the highest bidder, and mete out frontier justice" +
                        " without questioning the motives of those handing out the reward. In the end your principles" +
                        " are shallow. Your morals negotiable. Something to be bartered like trinkets at a market." +
                        "\n\t'And I?' he intones. The timbre of his voice is deadly soft yet still cuts through the " +
                        "storm raging above. 'I have dedicated my life to being the justice that this world needs. A" +
                        " justice that is all-powerful. A justice that cannot be refused or compromised or escaped. A " +
                        "justice that would create a new and righteous order, where curses brought about by the selfish actions of villains" +
                        " and their unanswered abuses won't terrorise the innocent but will instead hunt down those deemed wicked. " +
                        "I seek a world where the innocent live without fear. *You* would keep the world languishing " +
                        "in anarchy..."
                    },

                    {
                        "You threaten that you'll sin more yet, and he'll have a first-hand account of it...",

                        "The CurseBreaker sneers. 'It's so refreshing to finally meet an adventurer who recognises" +
                        " their own villainy,' he says, his tone as slippery as ice. 'Most of your kind ply their trade" +
                        " under the treacherous pretence that they're heroes - delivering people from injustices and" +
                        " oppression. I'm heartened to be so vindicated by the presence of an adventurer that knows their" +
                        " brand of frontier justice is nought but arbitrary at best, hypocritical and devastating at worst, and always" +
                        " sold to the highest bidder." +
                        "\n\t'But your efforts shall be in vain,' he continues, regarding you once again with imperious derision as " +
                        "thunder crashes overhead, 'Once I've dealt with you I shall redouble my efforts. I shall rebind that creature in the Oubliette," +
                        " or else summon one anew, and the rite shall be remade upon the next full moon. You have" +
                        " merely stalled my plans. Had you but stayed in your cell, accepted your well-deserved fate, " +
                        "then I would have ascended to such power that your kind would never again be free to dish out mercenary justice at the behest " +
                        " of the highest bidder. I would've become a justice that is all-powerful and all-encompassing...'"

                    },

                    {
                        "Uhh...",

                        "\t'You're no different from every other adventurer with mercenary morals and ethics" +
                        " to be bartered for by the highest bidder,' The CurseBreaker proclaims with a haughty swish of his sabre." +
                        " 'You just happen to be, from what I can see, the very worst adventuring hero" +
                        " that I've ever met! I mean... How on earth did you ever earn any money when you've botched every quest" +
                        " you ever went on?! How is it things always just work out for you? You're a walking catastrophe!' The CurseBreaker lets out a " +
                        "cruel laugh. 'And this..!' he jeers, 'This is Merigold's champion?! Bwa ha ha... It's all" +
                        " too perfect... '" +
                        "\n  You blurt that he doesn't seem to have the upperhand to you. It looks" +
                        " like his rite has already been ruined..." +
                        "\n  Then you catch yourself as the CurseBreaker's laughter abruptly stops, his cruel black eyes chill " +
                        "you as you are fixed with the most baleful glower you've ever seen." +
                        "\n\t'That's right,' he breathes in icy tones, 'even the very worst adventurer of them all is still" +
                        " an adventurer in need of extirpation. For too long have these lands endured your kind and your" +
                        " mercenary morals bargained for and sold to the highest bidder. You make a price for your arbitrary" +
                        " brand of frontier justice and think yourselves proud without any sef-reflection for the choices you make." +
                        " Had you not intervened, for example, I would have ascended to power that would've brought true justice" +
                        " to these lands - an all-powerful justice that sees all and controls everything...' "
                    },

                    {
                        "You object! Your various 'cons' and play-pretend was just some good sport...",

                        "\t'Good sport?' the CurseBreaker treats your rebuke with disdain. " +
                        "'As far as your lack of self-reflection goes, you are scarcely any different from any of the other sellswords that plague these lands." +
                        " They all take on quests, selling their services to the highest bidder, and mete out frontier justice" +
                        " without questioning the motives of those handing out the reward. In the end *their* principles" +
                        " are shallow. *Their* morals negotiable. Something to be bartered like trinkets at a market. But yours?' " +
                        "he scoffs. 'I reckon you never had any to begin with - A trivial oddity whose theatrics belong on a cheap, backalley stageshow.'" +
                        "\n\t'And I?' he intones. The timbre of his voice is deadly soft yet still cuts through the " +
                        "storm raging above. 'I have dedicated my life to being the justice that this world needs. A" +
                        " justice that is all-powerful. A justice that cannot be refused or compromised or escaped. A " +
                        "justice that would create a new and righteous order, where curses brought about by the selfish actions of villains" +
                        " and their unanswered abuses won't terrorise the innocent but will instead hunt down those deemed wicked. " +
                        "I seek a world where the innocent live without fear. *You* would rather the world kept on languishing " +
                        "in anarchy, for so long as you could steal false glory..."
                    },

                    {
                        "What you did, who you were, may have been bad - but at least you're taking a stand now...",

                        "\t'You have no idea what you stand against,' the CurseBreaker ripostes, 'I was on the cusp" +
                        " of ascending to such power that I could administer true justice unto the world like the god" +
                        " this world needs. Yet you brandish your sword before me, once more the thespian taking up an all" +
                        " too desperate role of saviour. The only people you're saving are the wicked adventurers and those that hire them." +
                        " Those sellswords you so often mimicked who barter their principles like goods at market. Who mete" +
                        " out frontier justice and then leave others to deal with the consequences. " +
                        "\n\t'I've strived for years to deliver the world from the anarchy of adventurers and their ilk." +
                        " Had I succeeded tonight, it would've only been the villains of this world that would live " +
                        "in fear. The lies and secrets of the wicked would be the only ones to suffer the consequences of the" +
                        " curses they'd otherwise set upon the land. I would create a new and righteous order out of the old -" +
                        " a true justice that would be all-powerful and irrefutable...'"
                    },

                    {
                        "You reply that even if you're a fraud, you are closer to a hero than the CurseBreaker will ever be...",

                        "\t'You?' the CurseBreaker scoffs." +
                        "\n\t'I've strived for years to deliver the world from the anarchy of adventurers and their ilk." +
                        " Had I succeeded tonight, it would've only been the villains of this world that would live " +
                        "in fear. The lies and secrets of the wicked would be the only ones to suffer the consequences of the" +
                        " curses they'd otherwise set upon the land. I would create a new and righteous order out of the old -" +
                        " a true justice that would be all-powerful and irrefutable...'"
                    },

                    {
                        "Yessss....?",

                        "The CurseBreaker balks. 'This is madness!'"
                    },

                    {
                        "You challenge him; if he's justice then why'd he rob Merigold of his home and enslave him?",

                        "'Merigold?' The CurseBreaker huffs, a wry smile slipping upon his lips. 'Why, he committed " +
                        "the worst sin of them all,' he breathes, his voice treacherously smooth. 'He challenged me. " +
                        "And therefore he opposed justice...'"
                    },

                    {
                        "You assert that taking all that power for himself would corrupt him more than any of those he deems 'wicked'...",

                        "  You tell him that absolute power corrupts absolutely. He's already employing the most nefarious" +
                        " mercenary company who loot and pillage unopposed. Sooner or later he's going to have to choose between" +
                        " using power to do good and using power to gain more power or to destroy those who'd challenge it..." +
                        "\n  The CurseBreaker remains unfazed. 'Using power to do good and using it to destroy those who challenge it?'" +
                        " he remarks imperiously. 'Who says they can't be one and the same thing?'"
                    },

                    {
                        "You tell him that taking the power to gaze into people's secrets and blackmailing them won't 'prevent' evil, only inhibit them from being free to do what's right...",

                        "  Making people afraid someone can peer into every moment of their life won't just stop them " +
                        "from wrongdoing in secret, you assert. It will also make them actively seek to do no action that could" +
                        " be *mistaken* for wrongdoing for fear of reprisals. It would be too restrictive and destroy their autonomy. " +
                        "And without autonomy, without agency, there's no such thing as a moral choice anymore..." +
                        "\n  The CurseBreaker responds icily. 'Good,' he says. 'Freedom is the illness that permits" +
                        " adventurers to be heroes to a hundred people, whilst wreaking havoc on a thousand more. What" +
                        " I strive for is a perfect righteous order...'" +
                        "  \n  You tell him that that sounds like a sentence everyone would suffer from regardless of " +
                        "whether they're innocent or not... \n  Everyone except him." +
                        "\n  The CurseBreaker scowls. 'I don't need to explain myself to you. Your hour is already at hand...'"
                    },

                    {
                        "You argue that he's wrong. Justice is too much for any one person or group. Power to administer it needs to be shared...",

                        "  You assert that those who wield power must be kept in check to ensure they don't themselves" +
                        " become corrupt. Or even just so that they don't overlook an alternative way of seeing things. Justice" +
                        " needs to be inclusive and equitable to get it right. Who else would there be to hold tyrants to account if" +
                        " not adventurers, or those brave enough to speak out against them..." +
                        "\n\t'Power that is challenged,' the CurseBreaker asserts in acerbic tones, 'is no power " +
                        "at all. What you speak of is just anarchy and would be too weak. So weak that it'd let criminals slip through the" +
                        " cracks.'" +
                        "   \n  You ask, what if power is concentrated so much that the innocent suffer along with the guilty?" +
                        " What if, for example, the foot soldiers of justice can plunder a home unchecked, or those in charge can" +
                        " kidnap people and vanish them?" +
                        "  \n  The CurseBreaker surveys you haughtily. 'Then it'd be done in the name of justice...'"
                    },

                    {
                        "You retort; how can he call what he does justice when he hires an evil mercenary company to do his bidding?",

                        "'How else might justice enforce itself?' The CurseBreaker counters. 'When all is said and done," +
                        " only force can deliver justice. It must be imposed upon people and brought to bear upon the wicked. Power,' he asserts, '" +
                        "is necessary. Justice must be strong even if it means being tyrannical. Otherwise there is only" +
                        " anarchy, and the rule of might makes right..." +
                        "\n\t'If that means that Justice has to make exceptions to maintain the power that it - that *I* - wield, " +
                        "then so be it...'"
                    },

                    {
                        "You rebuke him; how can he think he's the hero when he spares the 'wicked' mayor for his subservience and favours?",

                        "'Ah, yes... our mayor of Myrovia...' his gaze momentarily turns to the steeples far below, caught in the raging storm." +
                        " 'His crimes are beyond heinous and unspeakable, but in so far as he collaborates with me, his is an evil that I tolerate" +
                        " for the greater purpose of bringing true justice to the world...' he then turns back to you and your skin crawls with gooseflesh as he fixes you with a chilling smile." +
                        " 'At least for the present...'"
                    },

                    {
                        "You accept that The CurseBreaker's right...",

                        "'Good,' the CurseBreaker replies silkily. 'What follows next shall be so much easier" +
                        " if you accept your fate...'"
                    },

                    {
                        "You tell him you don't give a damn about his arguments. You're just here to bring him down...",

                        "The CurseBreaker tilts his head back, regarding you coldly..."
                    }


                };
                if (_player.Traits.ContainsKey("jinxed"))
                {
                    parlances[1] = "  \n\t'Do you imagine' he intones as his unsettling darker than black eyes " +
                    "appraise you, 'that you stand a chance against me? When your very presence here is no more than some comical aberration of chance - a twist of fate..." +
                    "I see before me your every weakness. All of them. You're nothing! Not to mention another adventurer whose crimes have gone unanswered for too long.'" +
                    $"  He leers. 'Do you dare think I can't see them, {_player.Name}, the litany of your sins laid bare before me...'";

                    choices[1].Add("Uhh...");
                }
                if (_player.Traits.ContainsKey("thespian"))
                {
                    parlances[1] = "  \n\t'Do you imagine' he intones as his unsettling darker than black eyes " +
                    "appraise you, 'that I don't know your past deeds, your many cons, your every weakness?'" +
                    $"  He leers. 'I see them all, {_player.Name}. You are no adventurer. You're certainly no hero. You don't even come close. You've been scamming " +
                    $"innocent folk for years. Revelling in stolen glory for free booze, gold and copious sexual exploits. You stand" +
                    $" before me now, with your false bravado, brandishing a weapon you scarcely know how to use, and expect... what?" +
                    $"' He tilts his head bemusedly, 'that I'll be bamboozled somehow. That your tricks will once again save" +
                    $" your hide?'  The CurseBreaker lets out a cruel laugh. And for once your general air of swashbuckling derring-do slips as " +
                    $"you realise that this man cannot be lied to, cannot be deceived or beguiled and sees you for what you are; a fraud" +
                    $"\n  Have you finally met your match?" +
                    $"\n\t'So many crimes, sins stretching back your whole life with every lie you told, and each of them gone without punishment… Until now.'";

                    choices[1].Clear();
                    choices[1].Add("You object! Your various 'cons' and play-pretend was just some good sport...");
                    choices[1].Add("What you did, who you were, may have been bad - but at least you're taking a stand now...");
                    choices[1].Add("You reply that even if you're a fraud, you are closer to a hero than the CurseBreaker will ever be...");

                    parlances[2] = "\n\t'But the greatest curse? The greatest curse of them all are adventurers and their ilk. " +
                        " And now,' the CurseBreaker scoffs, 'before me stands a false pretender, a conman who profits from the mayhem " +
                        "that adventurers cause throughout the land and reaps undeserved rewards from under their shadow. And you dare to pontificate to *me*?  " +
                        "\n\t'Adventurers are a bane unto this " +
                        "world. Their capricious meting of frontier justice and exploitation of the desperate is nothing more" +
                        " than naked vandalism of the righteous order. And you are nothing more than another symptom of the Curse they spread. " +
                        "You exploit " +
                        $" the endless vicious cycle of violence and chaos adventurers cause. " +
                        $"\n\t'No, {_player.Name},' The CurseBreaker intones icily, 'the hero of this story is not you. It's me...'";
                }
                if (_player.Traits.ContainsKey("friends with fairies"))
                {
                    parlances[1] = "‘Aargh! ’ The CurseBreaker screams before clasping his " +
                        "hands over those dark eyes, ‘What..?’ he splutters, ‘What the hell " +
                        "is this..? Why..? How you got here, your journey…? None of it makes" +
                        " any sense! ’\n  You openly wonder what he’s talking about to " +
                        "your fairy friends, but they only offer shrugs in response – the " +
                        "guy’s clearly barking.\n  The CurseBreaker recovers somewhat. " +
                        "With great strain he glowers your way, a nervous tic appearing " +
                        "in his left eye. \n  ‘What sort of sorcery is this?’ he seethes. " +
                        "‘Is this Merigold’s doing? But no, I took away most of his magic… " +
                        "This is… This…’";

                    choices[1].Clear();
                    choices[1].Add("Yessss....?");
                    parlances[2] = "";

                    choices[2].Clear();
                    choices[2].Add("THIS. IS. MYROVIA! - kick the CurseBreaker off the tower...");
                    choices[2].Add("THIS. IS. OBJECT ORIENTED PROGRAMMING ASSESSMENT TWO! - send the CurseBreaker plummeting to his death...");
                    choices[2].Add("YOU DANCING FOOL!");
                    choices[2].Add("Erm... Actually, no. You'd rather just fight him...");

                    choices.RemoveAt(3);
                    parlances.RemoveAt(3);

                }
                if (_player.UncoverSecretOfMyrovia == 2 || _player.UncoverSecretOfMyrovia == 3 || _player.UncoverSecretOfMyrovia == 6 || _player.UncoverSecretOfMyrovia == 7)
                {
                    choices[3].Add("You rebuke him; how can he think he's the hero when he spares the 'wicked' mayor for his subservience and favours?");
                }

                // change parlances depending on player traits, thespian response, jinxed response, FwF response
                return denouement.LinearParle(choices_response, parlances, choices, description, _player);


            }
            else
            {
                {
                    string description = "Slowly the disbelief on the CurseBreaker's face chills to an icy appraisal...";
                    List<string> parlances = new List<string>
                {
                    "",

                    "  \n\t'Do you imagine' he intones as his unsettling darker than black eyes " +
                    "appraise you, 'that I don't know your past deeds, your regrets, your every weakness?'" +
                    $"  He leers. 'I see them all, {_player.Name}, a litany of sins laid bare before me...'",

                    "\n\t'Such an irony,' he muses, 'that I should be interrupted by the greatest curse of them all; adventurers and their ilk. " +
                        " And now,' the CurseBreaker says, 'you deign to pontificate to *me*? It's your kind who are a bane unto this " +
                        "world. Your capricious meting of frontier justice and exploitation of any opportunity is nothing more" +
                        " than naked vandalism of the righteous order. Like a Curse you spread. You exploit those in need, claim rewards from anyone without question, and exacerbate feuds," +
                        $"endlessly repeating the cycle of chaos. " +
                        $"\n\t'No, {_player.Name},' The CurseBreaker intones icily, 'the hero of this story is not you. It's me...'",

                        "\n\n\t'Now...' the CurseBreaker hisses as he paces, 'enough of this! I have a ritual to complete and a world to rule! I'll deliver Merigold the final sentence that he deserves. Directly after I ascend!'" +
                        "  It is then that the CurseBreaker reveals a gloved hand - some cursed artefact that he'd been patiently charging with magic all whilst he" +
                        " bought time exchanging words with you. He booms an incantation and instantly the flagstones beneath your feet crack and crumble as three eerie totems rise out of the ground. They are each knotted roots in the shape of hands and they clutch gemstones in their vice like grip, casting a protective aura about the CurseBreaker. " +
                        "\n   Assured of his invulnerability, he leers at you as he once again recites the foul words of his rite - all while he turns that cursed glove your way and casts a lightning bolt at you!"
                };
                    List<List<string>> choices = new List<List<string>>
                {
                    new List<string>
                    {
                        "Tell the CurseBreaker that his ritual ends here...",
                        "State with iron resolve that you're going to make sure the CurseBreaker pays for his crimes...",
                        "You make evident your relish at a chance for vengeance...",
                        "Flippantly tell him Merigold sends his regards..."

                    },
                    new List<string>
                    {
                        "You scoff. Whatever you might've done in the past pales by comparison to the CurseBreaker's own deeds...",
                        "You rebuke his presumptive verdict - you've done nothing you're ashamed of. The CurseBreaker, on the other hand...",
                        "You threaten that you'll sin more yet, and he'll have a first-hand account of it..."
                    },
                    new List<string>
                    {
                        "You challenge him; if he's justice then why'd he rob Merigold of his home and enslave him?",
                        "You assert that taking all that power for himself would corrupt him more than any of those he deems 'wicked'...",
                        "You tell him that taking the power to gaze into people's secrets and blackmailing them won't 'prevent' evil, only inhibit them from being free to do what's right...",
                        "You argue that he's wrong. Justice is too much for any one person or group. Power to administer it needs to be shared...",
                        "You retort; how can he call what he does justice when he hires an evil mercenary company to do his bidding?",
                        "You accept that The CurseBreaker's right...",
                        "You tell him you don't give a damn about his arguments. You're just here to bring him down..."

                    },
                    new List<string>
                    {
                        "Dodge to the left...",
                        "Dive to the right...",
                        "Leap backwards...",
                        "Lunge forwards..."
                    }
                };

                    if (_player.WeaponInventory.Contains(vanquisher))
                    {

                        choices[0].Add("Unsheathe the sword of sealed souls before the CurseBreaker...");
                    }
                    else if (_player.WeaponInventory.Contains(staffMG))
                    {
                        choices[0].Add("Tighten your grip on Merigold's staff and brace yourself...");
                    }
                    else if (_player.WeaponInventory.Count > 0)
                    {
                        choices[0].Add("Unsheathe your weapon and prepare for the duel of your life...");
                    }
                    if (_player.Traits.ContainsKey("jinxed"))
                    {
                        choices[0].Insert(0, "You coolly begin telling the CurseBreaker that its over, before you stumble over a loose flagstone...");
                        choices[0].RemoveAt(1);
                        choices[0].Insert(1, "You blearily look around; 'Excuse me, is this the highest parapet? Only I've got to be there before midnight...'");
                        choices[0].RemoveAt(2);
                        choices[0].Insert(2, "You try your best to look menacing...");
                        choices[0].RemoveAt(3);
                        choices[0].Insert(3, "Tell him Merigold says 'Sayonara'... Or is it 'konnichiwa'? You're not sure...");
                        choices[0].RemoveAt(4);
                    }
                    if (_player.Traits.ContainsKey("thespian"))
                    {
                        choices[0].Insert(0, "Gallantly proclaim that the CurseBreaker's tyranny ends here...");
                        choices[0].RemoveAt(1);
                        choices[0].Insert(1, "With a wry smile concealing the ordeal you've been through to get here, you declare the CurseBreaker shall pay for his atrocities...");
                        choices[0].RemoveAt(2);
                        choices[0].Insert(3, "Nonchalantly inspect your nails as you airily give him Merigold's regards...");
                        choices[0].RemoveAt(4);
                    }
                    if (_player.Traits.ContainsKey("friends with fairies"))
                    {
                        choices[0].Insert(1, "Rave that his transgressions against fairy-kind shall not go unanswered...");
                        choices[0].RemoveAt(2);
                        choices[0].Insert(2, "Tell him you're here with your fairy friends to place him under fairy arrest. Read him his fairy rights...");
                        choices[0].RemoveAt(3);
                    }
                    if (_player.Traits.ContainsKey("sadist"))
                    {
                        choices[0].Insert(2, "You leer and detail all the ways you'll make the CurseBreaker suffer...");
                        choices[0].RemoveAt(3);
                    }
                    Dictionary<string, string> choices_response = new Dictionary<string, string>
                {
                    {
                        "Tell the CurseBreaker that his ritual ends here...",

                        "  The CurseBreaker fixes you with eyes as dark as the void between stars - eyes that once " +
                        "belonged to that monster below but that now icily appraise you. You feel his gaze on you, " +
                        "feel those eyes peer through you and beyond the present moment. You can feel his gaze crawl" +
                        " under your skin and peruse every past deed, every mistake, every regret..." +
                        "\nA chilling smile slips upon his thin lips. His bearing, even now, is one of self-assurance" +
                        ", as though he were untouchable by some divine providence." +
                        $"\n\t'Oh, {_player.Name}...' he regards you with an expression as foreboding as an endless frozen tundra," +
                        $" 'You have no clue with what it is you meddle...' "
                    },

                    {
                        "State with iron resolve that you're going to make sure the CurseBreaker pays for his crimes...",

                        "  He barks with callous laughter before your bold declaration. He never once takes his" +
                        " eyes off of you. Those twin orbs, blacker than volcanic glass, torch you with their gaze." +
                        " You can feel them probe your past, glimpse your innermost desires and lay bare your secrets" +
                        " for his cold perusal." +
                        " \n\t'My, my...' he brandishes a sabre, slicing the air like it was silk, 'The adventurer fancies" +
                        " themselves judge, jury and executioner.' He leers. 'Some things truly never change...' "
                    },

                    {
                        "You make evident your relish at a chance for vengeance...",

                        "  He responds with self-righteous vindication, tilting his head back slightly as he" +
                        " regards you with icy disdain. Those eyes, blacker than caves from which no one returns, " +
                        "scour your very soul - their gaze reaches past the present moment and clasps upon every" +
                        " past deed, every act you regretted and each one of your weaknesses. He judges you for your" +
                        " moral worth within but a moment and finds it wanting." +
                        "\n\t'You think you have a chance against me?' He intones as he glacially unsheathes his sabre," +
                        " 'I am this world's last chance for order, for justice upon the wicked. Do you truly believe I'd let" +
                        " a villain such as you throw that all away to satisfy some misguided, base revenge? No..." +
                        "\n'The days of adventurers and the crude 'justice' they mete out - of mercenaries wearing the guise of heroes - is over...'"
                    },

                    {
                        "Flippantly tell him Merigold sends his regards...",

                        "  His expression curdles into a scowl for only a moment, before his eyes narrow and he regards you" +
                        " with icy disdain. " +
                        "\n\t'So,' he breathes, his voice as smooth as dark lakes with treacherous depths, 'the old fool" +
                        " even now fails to see reason. I spare him his life, in spite of all his crimes, and this is how " +
                        "my mercy is repaid?' His expression darkens, like dusk falling into the depths of night. 'I was " +
                        "weak to not sentence him to his rightful demise - A mistake I shan't make again...' " +
                        "\n  His unsettling focus then latches upon you once again and you find yourself caught, like someone " +
                        "drowning and seized by unseen currents. Eyes" +
                        " blacker than the fathomless depths of subterranean rivers, probe you and instantly see all your weaknesses," +
                        " your regrets and your secrets - the ghosts of your past deeds laid bare as though the CurseBreaker's" +
                        " stare could creep under your skin and into your history." +
                        $"\n\t'Oh, {_player.Name}...' he regards you with an expression as foreboding as an endless frozen tundra," +
                        $" 'You have no clue with what it is you meddle...' "
                    },

                    {
                        "Unsheathe the sword of sealed souls before the CurseBreaker...",

                        "  The CurseBreaker's focus instantly shifts from you to the moonlit blade in your hand," +
                        " a spectral mist swimming along its length. He grimaces, his expression betraying an unmistakeable " +
                        "wariness of the powerful weapon in your hand." +
                        "\n\t'The Sword of Sealed Souls...' he murmurs, disquieted by the blade's gleam. Then, he scathes, 'You *have* " +
                        "been busy, haven't you...'" +
                        "\n  He fixes you once again with his eyes, all aloofness and arrogance he'd hitherto displayed" +
                        " replaced by a baleful and intense focus. With that weapon in your hands, he knows full well that" +
                        " you are beyond dangerous and he dare not underestimate you. He unsheathes his sabre as his gaze clasps sight of every one of your weaknesses and secrets." +
                        " He reads them like they were runes etched into your bones." +
                        "\n\t'You have no idea what you're doing,' he seethes. 'I am the justice that shall punish the wicked. I am this world's only hope for peace...'"
                    },

                    {
                        "Tighten your grip on Merigold's staff and brace yourself...",

                        "  The CurseBreaker's focus instantly shifts from you to the gleaming rosewood staff in your hands. " +
                        "He scoffs. " +
                        "\n\t'So,' he intones, his tone treacherously soft, 'you uncovered my secrets and found the old " +
                        "fool's staff in the process. Do you imagine this gives you the upper hand?'" +
                        "\n He unsheathes his sabre with a flourish - with the flair of a true duellist." +
                        "\n\t'Even if you can counter my magic,' he proclaims, 'you are still far from being able to match my abilities...'"
                    },

                    {
                        "Unsheathe your weapon and prepare for the duel of your life...",

                        "  He barks with callous laughter at the sight of your crude weapon, however he never once takes his" +
                        " eyes off of you. Those twin orbs, blacker than volcanic glass, torch you with their gaze." +
                        " You can feel them probe your past, glimpse your innermost desires and lay bare your secrets" +
                        " for his cold perusal." +
                        "\n\t'Do you truly, for a single moment, think you stand a chance against me?' he jeers."
                    },

                    {
                        "You coolly begin telling the CurseBreaker that its over, before you stumble over a loose flagstone...",

                        "  The CurseBreaker watches you stumble, eyeing you with aloof disdain as you" +
                        " hastily scramble to your feet and dust yourself off. You, rather lamely, finish your bold declaration..." +
                        "  The CurseBreaker's cold eyes, darker than black, spare you a glance over. He instantly " +
                        "sees all your oafish antics, every misfortune. The near-endless parade of jinxed encounters and blunders that is your life story" +
                        " unveil themselves before his eyes. " +
                        "\n  He looks upon you with more than a tincture of derisive incredulity. " +
                        "\n\t'How,' he remarks disbelievingly, 'in all the seven hells did you, of all people, make it this far?'" +
                        "\n  Then his cold contempt congeals into a jeery laugh. For a moment, it seems, he thought he was" +
                        " in trouble. Now he unsheathes his sabre with a flourish as he arrogantly leers your way."
                    },

                    {
                        "You blearily look around; 'Excuse me, is this the highest parapet? Only I've got to be there before midnight...'",

                        "  The CurseBreaker does not reply. The answer dawns on you soon enough," +
                        " but not before he surveys you with incredulous derision." +
                        "\n\t  'Right, right...' you say, 'of course it is. No roof...' You point up " +
                        "to the raging storm above by way of explanation. 'Yep.'" +
                        "\n  Thunder crashes overhead, making you jump with fright. You accidentally " +
                        "land on a loose flagstone, which in turn catapults a stray stone the CurseBreaker's way." +
                        " He deflects it with a lazy swish of his sabre all while continuing to glower your way." +
                        "\n\t'Sorry!' you call out. 'Sorry... Didn't mean for... didn't mean to do that...' Then you" +
                        " suddenly realise who you're addressing. You gasp, 'Wait! That means you must be the CurseBreaker! - I've" +
                        " come to bring an end to your evil... uhm, evil-doing!'" +
                        "\n  The CurseBreaker glances you over with eyes darker than black, and you feel his cold disdainful " +
                        "gaze probe your past deeds and mistakes... *Many* mistakes. The mardi-gras carnival of oafish blunders" +
                        " and jinxy mayhem that compose your bewildering adventuring career are laid bare before him..." +
                        "\n\t'How,' he asks, mystified, 'in all the seven hells did you, of all people, make it this far?'" +
                        "\n  Then his cold contempt congeals into a jeery laugh. " +
                        " He arrogantly leers your way."
                    },

                    {
                        "You try your best to look menacing...",

                        "  You channel your inner adventurer spirit and make a mean face. Unfortunately, " +
                        "with your somewhat wimpy build, you look about as menacing as a tea cosy..." +
                        "\n  The CurseBreaker glances you over with eyes darker than black, and your " +
                        "attempt at intimidation chills into a shiver, as his gaze roves your past deeds and" +
                        " blunders - oh dear god, so many blunders..." +
                        "\n  The bizzarro cabaret of oafish ineptitude and jinxy pandemonium that agglomerate into" +
                        " your baffling career as an adventurer are laid bare before him..." +
                        "\n\t'How,' he asks, mystified, 'in all the seven hells did you, of all people, make it this far?'" +
                        "\n  Then his cold contempt congeals into a jeery laugh. For a moment, upon sight of the vortex, it seems he'd thought he was" +
                        " in trouble. Now he arrogantly leers your way."
                    },

                    {
                        "Tell him Merigold says 'Sayonara'... Or is it 'konnichiwa'? You're not sure...",


                        "\n\t'What?!' the CurseBreaker retorts, somehow both derisive and completely baffled." +
                        " \n  You explain its... its another language. You think..." +
                        "\n  You were trying to sound cool. Nevermind. " +
                        "\n  The CurseBreaker glances you over with eyes darker than black, and you feel his cold disdainful " +
                        "gaze probe your past deeds and mistakes... *Many* mistakes. The mardi-gras carnival of oafish blunders" +
                        " and jinxy mayhem that compose your bewildering adventuring career are laid bare before him..." +
                        "\n\t'How,' he asks, mystified, 'in all the seven hells did you, of all people, make it this far?'" +
                        "\n  Then his cold contempt congeals into a jeery laugh. " +
                        " He arrogantly leers your way."
                    },

                    {
                        "Gallantly proclaim that the CurseBreaker's tyranny ends here...",

                        "  The CurseBreaker fixes you with eyes as dark as the void between stars - eyes that once " +
                        "belonged to that monster below but that now icily appraise you. You feel his gaze on you, " +
                        "feel those eyes peer through you and beyond the present moment. You can feel his gaze crawl" +
                        " under your skin and peruse every past deed, every mistake, every regret..." +
                        "\nA chilling smile slips upon his thin lips. His bearing, even now, is one of self-assurance" +
                        ", as though he were untouchable by some divine providence." +
                        $"\n\t'Oh, {_player.Name}...' he regards you with an expression as foreboding as an endless frozen tundra," +
                        $" 'You have no clue with what it is you meddle...' "
                    },

                    {
                        "With a wry smile concealing the ordeal you've been through to get here, you declare the CurseBreaker shall pay for his atrocities...",

                        "  He barks with callous laughter before your bold declaration. He never once takes his" +
                        " eyes off of you. Those twin orbs, blacker than volcanic glass, torch you with their gaze." +
                        " You can feel them probe your past, glimpse your innermost desires and lay bare your secrets" +
                        " for his cold perusal." +
                        " \n\t'My, my...' he brandishes a sabre, slicing the air like it was silk, 'The adventurer fancies" +
                        " themselves judge, jury and executioner.' He leers. 'Some things truly never change...' "
                    },

                    {
                        "Nonchalantly inspect your nails as you airily give him Merigold's regards...",

                        "  His expression curdles into a scowl for only a moment, before his eyes narrow and he regards you" +
                        " with icy disdain. " +
                        "\n\t'So,' he breathes, his voice as smooth as dark lakes with treacherous depths, 'the old fool" +
                        " even now fails to see reason. I spare him his life, in spite of all his crimes, and this is how " +
                        "my mercy is repaid?' His expression darkens, like dusk falling into the depths of night. 'I was " +
                        "weak to not sentence him to his rightful demise - A mistake I shan't make again...' " +
                        "\n  His unsettling focus then latches upon you once again and you find yourself caught, like someone " +
                        "drowning and seized by unseen currents. Eyes" +
                        " blacker than the fathomless depths of subterranean rivers, probe you and instantly see all your weaknesses," +
                        " your regrets and your secrets - the ghosts of your past deeds laid bare as though the CurseBreaker's" +
                        " stare could creep under your skin and into your history." +
                        $"\n\t'Oh, {_player.Name}...' he regards you with an expression as foreboding as an endless frozen tundra," +
                        $" 'You have no clue with what it is you meddle...' "
                    },

                    {
                        "Rave that his transgressions against fairy-kind shall not go unanswered...",

                        "His cold appraisal of you morphing into some measure of bafflement, he focuses" +
                        " those black eyes, darker than volcanic glass, on you. And you can feel his sight" +
                        " extend into your mind..."
                    },

                    {
                        "Tell him you're here with your fairy friends to place him under fairy arrest. Read him his fairy rights...",

                        "You are about to tell him he has the right to a fairy lawyer when the" +
                        " CurseBreaker focuses his black eyes. Darker than the void between stars," +
                        " he snaps his gaze upon you and peers into your mind..."
                    },

                    {
                        "You leer and detail all the ways you'll make the CurseBreaker suffer...",

                        "  He responds with self-righteous vindication, tilting his head back slightly as he" +
                        " regards you with icy disdain. Those eyes, blacker than caves from which no one returns, " +
                        "scour your very soul - their gaze reaches past the present moment and clasps upon every" +
                        " past deed, every act you regretted and each one of your weaknesses. He judges you for your" +
                        " moral worth within but a moment and not only finds it wanting, but recoils in disgust." +
                        "\n\t'You think you have a chance against me?' He intones as he glacially unsheathes his sabre," +
                        " 'I am this world's last chance for order, for justice upon wicked souls such as yours. Do you truly believe I'd let" +
                        " a villain such as you throw that all away to satisfy your debauched sadistic desires? No..." +
                        "\n'The days of adventurers and the crude 'justice' they mete out - of mercenaries wearing the guise of heroes - is over...'"
                    },

                    {
                        "You scoff. Whatever you might've done in the past pales by comparison to the CurseBreaker's own deeds...",

                        "The CurseBreaker responds with scorn. 'Spare me your mercenary morals and " +
                        "principles bandied and sold to the highest bidder!' he responds icily." +
                        " 'I am on the cusp of ascending to such power that no one need" +
                        " ever suffer injustice again. With powers that span the Fey Realms and the " +
                        "material plane, I'll be able to keep any and all curses at bay. And " +
                        "the world will be unified under justice, uncontested and irrefutable. No " +
                        "longer will the arbitrations and whims of the corrupt go unchecked, no longer will " +
                        "mercenaries ply their trade under the maxim of 'might makes right.' I will " +
                        "deliver the world into an age of righteous order - one where no villain can hide" +
                        " their secrets without fear, one where it is the wicked who are hunted and punished" +
                        " and not the good..."

                    },

                    {
                        "You rebuke his presumptive verdict - you've done nothing you're ashamed of. The CurseBreaker, on the other hand...",

                        "\t'You've done nothing to be ashamed of?' the CurseBreaker treats your rebuke with disdain. " +
                        "'You are scarcely any different from any of the other sellswords that plague these lands." +
                        " You all take on quests, selling your services to the highest bidder, and mete out frontier justice" +
                        " without questioning the motives of those handing out the reward. In the end your principles" +
                        " are shallow. Your morals negotiable. Something to be bartered like goods at a market." +
                        "\n\t'And I?' he intones. The timbre of his voice is deadly soft yet still cuts through the " +
                        "storm raging above. 'I have dedicated my life to being the justice that this world needs. A" +
                        " justice that is all-powerful. A justice that cannot be refused or compromised or escaped. A " +
                        "justice that will create a new and righteous order, where curses brought about by the selfish actions of villains" +
                        " and their unanswered abuses won't terrorise the innocent but will instead hunt down those deemed wicked. " +
                        "I seek a world where the innocent live without fear. *You* would keep the world languishing " +
                        "in anarchy..."
                    },

                    {
                        "You threaten that you'll sin more yet, and he'll have a first-hand account of it...",

                        "The CurseBreaker cracks a dangerous smile. 'It's so refreshing to finally meet an adventurer who recognises" +
                        " their own villainy,' he says, his tone as slippery as ice. 'Most of your kind ply their trade" +
                        " under the treacherous pretence that they're heroes - delivering people from injustices and" +
                        " oppression. I'm heartened to be so vindicated by the presence of an adventurer that knows their" +
                        " brand of frontier justice is nought but arbitrary at best, hypocritical and devastating at worst, and always" +
                        " sold to the highest bidder." +
                        "\n\t'But your efforts shall be in vain,' he continues, regarding you once again with imperious derision as " +
                        "thunder crashes overhead, 'The ritual is already so close to completion. With the creature still bound in the Oubliette, I shall ascend to power the likes of which this world has never seen." +
                        "  You have" +
                        " done nothing to delay my plans - all I need do is speak the final words. I will become this world's true justice - one that is all-powerful and all-encompassing...'"

                    },

                    {
                        "Uhh...",

                        "\t'You're no different from every other adventurer with mercenary morals and ethics" +
                        " to be bartered for by the highest bidder,' The CurseBreaker proclaims with a haughty swish of his sabre." +
                        " 'You just happen to be, from what I can see, the very worst adventuring hero" +
                        " that I've ever met! I mean... How on earth did you ever earn any money when you've botched every quest" +
                        " you ever went on?! How is it things always just work out for you? You're a walking catastrophe!' The CurseBreaker lets out a " +
                        "cruel laugh. 'And this..!' he jeers, 'This is Merigold's champion?! Bwa ha ha... It's all" +
                        " too perfect... '" +
                        "\n  You blurt that he doesn't seem to have the upperhand to you. It looks" +
                        " like his rite has already been ruined..." +
                        "\n  The CurseBreaker positively cackles. 'Fool!' he exclaims. 'Your interrupting me here changes nothing! I am but a few words away from completing the rite and when I do, nothing and no one can stop me. Least of all you...'  " +
                        "Then you catch your breath as the CurseBreaker's laughter abruptly stops, his cruel black eyes chill " +
                        "you as they once again fix on you with the most baleful glower you've ever seen." +
                        "\n\t'But,' he breathes in icy tones, 'even a jester like you, even the very worst adventurer of them all, is still" +
                        " an adventurer in need of extirpation. For too long have these lands endured your kind and your" +
                        " mercenary morals bargained for and sold to the highest bidder. You make a price for your arbitrary" +
                        " brand of frontier justice and think yourselves proud without any sef-reflection for the choices you make." +
                        " You shall be the first to witness my ascension to the true avatar of justice - one that sees all and controls everything...' "
                    },

                    {
                        "You object! Your various 'cons' and play-pretend was just some good sport...",

                        "\t'Good sport?' the CurseBreaker treats your rebuke with disdain. " +
                        "'As far as your lack of self-reflection goes, you are scarcely any different from any of the other sellswords that plague these lands." +
                        " They all take on quests, selling their services to the highest bidder, and mete out frontier justice" +
                        " without questioning the motives of those handing out the reward. In the end *their* principles" +
                        " are shallow. *Their* morals negotiable. Something to be bartered like trinkets at a market. But yours?' " +
                        "he scoffs. 'I reckon you never had any to begin with - A trivial oddity whose theatrics belong on a cheap, backalley stageshow.'" +
                        "\n\t'And I?' he intones. The timbre of his voice is deadly soft yet still cuts through the " +
                        "storm raging above. 'I have dedicated my life to being the justice that this world needs. A" +
                        " justice that is all-powerful. A justice that cannot be refused or compromised or escaped. A " +
                        "justice that would create a new and righteous order, where curses brought about by the selfish actions of villains" +
                        " and their unanswered abuses won't terrorise the innocent but will instead hunt down those deemed wicked. " +
                        "I seek a world where the innocent live without fear. *You* would rather the world kept on languishing " +
                        "in anarchy, for so long as you could steal false glory..."
                    },

                    {
                        "What you did, who you were, may have been bad - but at least you're taking a stand now...",

                        "\t'You have no idea what you stand against,' the CurseBreaker ripostes, 'I am on the cusp" +
                        " of ascending to such power that I could administer true justice like the god" +
                        " this world needs. Yet you brandish your sword before me, once more the thespian taking up an all" +
                        " too desperate role of saviour. The only people you're saving are the anarchic adventurers and those that hire them." +
                        " Those sellswords you so often mimicked who barter their principles like goods at market. Who mete" +
                        " out frontier justice and then leave others to deal with the consequences. " +
                        "\n\t'I've strived for years to deliver the world from the anarchy of adventurers and their ilk." +
                        " When I succeed tonight, it will only be the villains of this world that live " +
                        "in fear. The lies... the secrets... The wicked shall be the only ones to suffer the consequences of the" +
                        " curses they set upon the land. I will create a new and righteous order out of the old -" +
                        " a true justice that will be all-powerful and irrefutable...'"
                    },

                    {
                        "You reply that even if you're a fraud, you are closer to a hero than the CurseBreaker will ever be...",

                        "\t'You?' the CurseBreaker scoffs." +
                        "\n\t'I've strived for years to deliver the world from the anarchy of adventurers and their ilk." +
                        " When I succeed tonight, it will only be the villains of this world that live " +
                        "in fear. The lies... the secrets... The wicked shall be the only ones to suffer the consequences of the" +
                        " curses they set upon the land. I will create a new and righteous order out of the old -" +
                        " a true justice that will be all-powerful and irrefutable...'"
                    },

                    {
                        "Yessss....?",

                        "The CurseBreaker balks. 'This is madness!'"
                    },

                    {
                        "You challenge him; if he's justice then why'd he rob Merigold of his home and enslave him?",

                        "'Merigold?' The CurseBreaker huffs, a wry smile slipping upon his lips. 'Why, he committed " +
                        "the worst sin of them all,' he breathes, his voice treacherously smooth. 'He challenged me. " +
                        "He opposed justice...'"
                    },

                    {
                        "You assert that taking all that power for himself would corrupt him more than any of those he deems 'wicked'...",

                        "  You tell him that absolute power corrupts absolutely. He's already employing the most nefarious" +
                        " mercenary company who loot and pillage unopposed. Sooner or later he's going to have to choose between" +
                        " using power to do good and using power to gain more power or to destroy those who'd challenge it..." +
                        "\n  The CurseBreaker remains unfazed. 'Using power to do good and using it to destroy those who challenge it?'" +
                        " he remarks imperiously. 'Who says they can't be one and the same thing?'"
                    },

                    {
                        "You tell him that taking the power to gaze into people's secrets and blackmailing them won't 'prevent' evil, only inhibit them from being free to do what's right...",

                        "  Making people afraid someone can peer into every moment of their life won't just stop them " +
                        "from wrongdoing in secret, you assert. It will also make them actively seek to do no action that could" +
                        " be *mistaken* for wrongdoing for fear of reprisals. It would be too restrictive and destroy their autonomy. " +
                        "And without autonomy, without agency, there's no such thing as a moral choice anymore..." +
                        "\n  The CurseBreaker responds icily. 'Good,' he says. 'Freedom is the illness that permits" +
                        " adventurers to be heroes to a hundred people, whilst wreaking havoc on a thousand more. What" +
                        " I strive for is a perfect righteous order...'" +
                        "  \n  You tell him that that sounds like a sentence everyone would suffer from regardless of " +
                        "whether they're innocent or not... \n  Everyone except him." +
                        "\n  The CurseBreaker scowls. 'I don't need to explain myself to you. Your hour is already at hand...'"
                    },

                    {
                        "You argue that he's wrong. Justice is too much for any one person or group. Power to administer it needs to be shared...",

                        "  You assert that those who wield power must be kept in check to ensure they don't themselves" +
                        " become corrupt. Or even just so that they don't overlook an alternative way of seeing things. Justice" +
                        " needs to be inclusive and equitable to get it right. Who else would there be to hold tyrants to account if" +
                        " not adventurers, or those brave enough to speak out against them..." +
                        "\n\t'Power that is challenged,' the CurseBreaker asserts in acerbic tones, 'is no power " +
                        "at all. What you speak of is just anarchy and would be too weak. So weak that it'd let criminals slip through the" +
                        " cracks.'" +
                        "   \n  You ask, what if power is concentrated so much that the innocent suffer along with the guilty?" +
                        " What if, for example, the foot soldiers of justice can plunder a home unchecked, or those in charge can" +
                        " kidnap people and vanish them?" +
                        "  \n  The CurseBreaker surveys you haughtily. 'Then it'd be done in the name of justice...'"
                    },

                    {
                        "You retort; how can he call what he does justice when he hires an evil mercenary company to do his bidding?",

                        "'How else might justice enforce itself?' The CurseBreaker counters. 'When all is said and done," +
                        " only force can deliver justice. It must be imposed upon people and brought to bear upon the wicked. Power,' he asserts, '" +
                        "is necessary. Justice must be strong even if it means being tyrannical. Otherwise there is only" +
                        " anarchy, and the rule of might makes right..." +
                        "\n\t'If that means that Justice has to make exceptions to maintain the power that it - that *I* - wield, " +
                        "then so be it...'"
                    },

                    {
                        "You rebuke him; how can he think he's the hero when he spares the 'wicked' mayor for his subservience and favours?",

                        "'Ah, yes... our mayor of Myrovia...' his gaze momentarily turns to the steeples far below, caught in the raging storm." +
                        " 'His crimes are beyond heinous and unspeakable, but in so far as he collaborates with me, his is an evil that I tolerate" +
                        " for the greater purpose of bringing true justice to the world...' he then turns back to you and your skin crawls with gooseflesh as he fixes you with a chilling smile." +
                        " 'At least for the present...'"
                    },

                    {
                        "You accept that The CurseBreaker's right...",

                        "'Good,' the CurseBreaker replies silkily. 'What follows next shall be so much easier" +
                        " if you accept your fate...'"
                    },

                    {
                        "You tell him you don't give a damn about his arguments. You're just here to bring him down...",

                        "The CurseBreaker tilts his head back, regarding you coldly..."
                    }


                };
                    if (_player.Traits.ContainsKey("jinxed"))
                    {
                        parlances[1] = "  \n\t'Do you imagine' he intones as his unsettling darker than black eyes " +
                        "appraise you, 'that you stand a chance against me? When your very presence here is no more than some comical aberration of chance - a twist of fate..." +
                        "I see before me your every weakness. All of them. You're nothing! Not to mention another adventurer whose crimes have gone unanswered for too long.'" +
                        $"  He leers. 'Do you dare think I can't see them, {_player.Name}, the litany of your sins laid bare before me...'";

                        choices[1].Add("Uhh...");
                    }
                    if (_player.Traits.ContainsKey("thespian"))
                    {
                        parlances[1] = "  \n\t'Do you imagine' he intones as his unsettling darker than black eyes " +
                        "appraise you, 'that I don't know your past deeds, your many cons, your every weakness?'" +
                        $"  He leers. 'I see them all, {_player.Name}. You are no adventurer. You're certainly no hero. You don't even come close. You've been scamming " +
                        $"innocent folk for years. Revelling in stolen glory for free booze, gold and copious sexual exploits. You stand" +
                        $" before me now, with your false bravado, brandishing a weapon you scarcely know how to use, and expect... what?" +
                        $"' He tilts his head bemusedly, 'that I'll be bamboozled somehow. That your tricks will once again save" +
                        $" your hide?'  The CurseBreaker lets out a cruel laugh. And for once your general air of swashbuckling derring-do slips as " +
                        $"you realise that this man cannot be lied to, cannot be deceived or beguiled and sees you for what you are; a fraud" +
                        $"\n  Have you finally met your match?" +
                        $"\n\t'So many crimes, sins stretching back your whole life with every lie you told, and each of them gone without punishment… Until now.'";

                        choices[1].Clear();
                        choices[1].Add("You object! Your various 'cons' and play-pretend was just some good sport...");
                        choices[1].Add("What you did, who you were, may have been bad - but at least you're taking a stand now...");
                        choices[1].Add("You reply that even if you're a fraud, you are closer to a hero than the CurseBreaker will ever be...");

                        parlances[2] = "\n\t'But the greatest curse? The greatest curse of them all are adventurers and their ilk. " +
                            " And now,' the CurseBreaker scoffs, 'before me stands a false pretender, a conman who profits from the mayhem " +
                            "that adventurers cause throughout the land and reaps undeserved rewards from under their shadow. And you dare to pontificate to *me*?  " +
                            "\n\t'Adventurers are a bane unto this " +
                            "world. Their capricious meting of frontier justice and exploitation of the desperate is nothing more" +
                            " than naked vandalism of the righteous order. And you are nothing more than another symptom of the Curse they spread. " +
                            "You exploit " +
                            $" the cycle of chaos adventurers cause. " +
                            $"\n\t'No, {_player.Name},' The CurseBreaker intones icily, 'the hero of this story is not you. It's me...'";
                    }
                    if (_player.Traits.ContainsKey("friends with fairies"))
                    {
                        parlances[1] = "‘Aargh! ’ The CurseBreaker suddenly screams before clasping his " +
                            "hands over those dark eyes, ‘What..?’ he splutters, ‘What the hell " +
                            "is this..? Why..? How you got here, your journey…? None of it makes" +
                            " any sense! ’\n  You openly wonder what he’s talking about to " +
                            "your fairy friends, but they only offer shrugs in response – the " +
                            "guy’s clearly barking.\n  The CurseBreaker recovers somewhat. " +
                            "With great strain he glowers your way, a nervous tic appearing " +
                            "in his left eye. \n  ‘What sort of sorcery is this?’ he seethes. " +
                            "‘Is this Merigold’s doing? But no, I took away most of his magic… " +
                            "This is… This…’";

                        choices[1].Clear();
                        choices[1].Add("Yessss....?");
                        parlances[2] = "";

                        choices[2].Clear();
                        choices[2].Add("THIS. IS. MYROVIA! - kick the CurseBreaker off the tower...");
                        choices[2].Add("THIS. IS. OBJECT ORIENTED PROGRAMMING ASSESSMENT TWO! - send the CurseBreaker plummeting to his death...");
                        
                        choices[2].Add("Erm... Actually, no. You'd rather just fight him...");

                        choices.RemoveAt(3);
                        parlances.RemoveAt(3);

                    }
                    if ((_player.UncoverSecretOfMyrovia == 2 || _player.UncoverSecretOfMyrovia == 3 || _player.UncoverSecretOfMyrovia == 6 || _player.UncoverSecretOfMyrovia == 7) && !_player.Traits.ContainsKey("friends with fairies"))
                    {
                        choices[3].Add("You rebuke him; how can he think he's the hero when he spares the 'wicked' mayor for his subservience and favours?");
                    }

                    // change parlances depending on player traits, thespian response, jinxed response, FwF response
                    return 10 + denouement.LinearParle(choices_response, parlances, choices, description, _player);


                }
            }
            
        }
    }
}

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
        public bool Denouement(Room oubliette, List<Item> specialItems, Weapon staffMG, Weapon vanquisher, Monster ghoul)
        {
            Dialogue denouement = new Dialogue(_player, CurseBreaker);
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
                        $"\n\t'No, {_player.Name},' The CurseBreaker intones icily, 'the hero of this story is not you. It's me...'"
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
                        
                        ""
                    },

                    {
                        "You threaten that you'll sin more yet, and he'll have a first-hand account of it...",
                        
                        ""
                    },

                    {
                        "Uhh...",

                        ""
                    },

                    {
                        "You object! Your various 'cons' and play-pretend was just some good sport...",

                        ""
                    },

                    {
                        "What you did, who you were, may have been bad - but at least you're taking a stand now...",

                        ""
                    },

                    {
                        "You reply that even if you're a fraud, you are closer to a hero than the CurseBreaker will ever be...",

                        ""
                    },

                    {
                        "Yessss....?",
                        
                        "The CurseBreaker balks. 'This is madness!'"
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
                    
                }

                // change parlances depending on player traits, thespian response, jinxed response, FwF response



            }
            return true;
        }
    }
}

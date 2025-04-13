using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class Merigold : Dialogue
    {
        public Player _player {get;set;}
        public Room _room {get;set;}
        public Merigold(Player player, Room room): base(player, room)
        {
            _player = player;
            _room = room;
        }
        public List<Dice> MerigoldPlotPoint(List<Item> specialItems, Combat battle, Room secretChamber, Monster goblin, Monster gnoll, List<Item> MGItems, Door stairwayToLower)
        {
            Dice D1 = new Dice(1);
            string message = "";
            string strand = "";
            if (_player.Traits.ContainsKey("thespian"))
            {
                strand = "Gallantly striding up to";
            }
            else if (_player.Traits.ContainsKey("jinxed"))
            {
                strand = "Stumbling clumsily up to";
            }
            else if (_player.Traits.ContainsKey("friends with fairies"))
            {
                strand = "Bunny-hopping serenely up to";
            }
            else { strand = "Approaching"; }
            string description = $"{strand} the rather eccentric figure before you, you discover a few more of his foibles that are, if not disconcerting, then perhaps make you question your first impression of him. Firstly, the spectacles that he wears have lenses so thick that it's a wonder he can see anything at all through them. They seem to magnify the slightly manic eyes that peer out from behind them. Secondly, you notice the man's hair is frazzled and unkempt. The tesla coils nearby seem to fluff it up with their static charge, making it look like a cosy nest for the ingenious ides floating about his head. Thirdly, you notice the man not only wears socks with sandals but also managed to dress with odd socks at that.\n";
            if (_player.Traits.ContainsKey("friends with fairies")&& specialItems[7].SpecifyAttribute == "read")
            {
                description += "You ponder to yourself whether this 'weirdo' could really be the great and marvellous Merigold as you hop merrily forward. But your fairy friends assure you that, yes, the man before you has an aura of wisdom surpassing even their own...\n";
            }
            else if (specialItems[7].SpecifyAttribute == "read")
            {
                description += "You begin to question whether this really could be Merigold, the great wizard you've been scouring this tower for. If not, you suppose, the strange man might nevertheless be able to direct you to him.\n";
            }
            description += " More than a little curious, you politely clear your throat and wait for the idiosyncratic fellow to acknowledge your presence";
            if (_player.Traits.ContainsKey("friends with fairies"))
            {
                description += ", discretely bunny-hopping by his shoulder.\n";
            }
            else
            {
                description += ".\n";
            }
            List<string> parlances = new List<string> 
            { 
                "\t'Yes? What? Oh, not now! Can't you mercenary oafs see that I'm busy?' he waves a hand vaguely in your direction, exasperatedly shooing you without so much as taking his eyes off of the esoteric scribblings he pores over. 'Tell your *boss*,' he says edgily, 'That if he wants these orders all filled then he's going to have to give more of my magic back. I'm scarcely able to keep going as it is...'",
                
                "\n\t'unless... but you couldn't possibly be... an escapee?'",

                "\n\t'But first, tell me,' he quizzes you, 'How on earth did you manage to slip away and escape the clutches of your captors?'",

                "\n\t'We don't have much time, so if we are to plan we must do so fast." +
                " I trust you know nothing of the CurseBreaker's schemes - there is only " +
                "so much I can tell you myself, for he was always a secretive person even when " +
                "I knew him best. Tonight, at midnight, I know he plans to perform some " +
                "profane ritual - a rite. I know because i discovered the page he tore out " +
                "of one of my books. One on summoning but also one on possession. I don't " +
                "know fully just how he intends to use this information, but I've more than " +
                "sensed a great evil lurk somewhere beneath us, in the deepest subterranean levels " +
                "of this tower. For now it appears to be contained, but should it break free... " +
                "\n  The spell the CurseBreaker " +
                "stole - it can only be cast every full moon at midnight. That's tonight! So " +
                "we have until then to find a way to reach him, to stop him, or to otherwise " +
                "sabotage his plans.' \n  He turns, motioning towards the crackling vortex of " +
                "unstable energy behind you: the portal to distant ever-changing landscapes. 'There" +
                " lies one way forward. However, it is not *my* magic that weaves this tunnel between " +
                "planes. The CurseBreaker... Before I met you now he and his private army " +
                "imprisoned me here. I couldn't resist, to do so would've meant a pointless death. " +
                "He later siphoned my powers using a pair of cursed gloves he stole from my " +
                "collection. However,' Merigold's voice lowers to a conspiratorial hush and " +
                "you lean in to listen avidly, 'before he did so, I was foresighted enough to " +
                "stash some of my powers within twelve artefacts - twelve otherwise mundane items " +
                "that were all embossed with the letters of my sigil. Unfortunately, some were " +
                "ransacked by those thugs who pilfered my home, but they can surely still be found " +
                "around this tower if you look hard enough. With these disguised caches of " +
                "magical power i can recuperate some of my lost abilities. Enough, perhaps, to " +
                "better control where that portal leads...\n\tRight now, in short, that is the " +
                "best plan I can think of for delivering you to your confrontation with the " +
                "CurseBreaker, but there may be many other dangers I've overlooked - I don't know " +
                "your strengths, your weaknesses - i cannot gauge what would be the best route " +
                "ahead. Only you can decide that.\n\tWe have so little time, but if you're to " +
                "figure out how to best defeat the CurseBreaker and the sleepless evil that stirs " +
                "within these walls, then you'll need information - as much of it as I can give. " +
                "\n\tIf you have any questions, now is the time to ask...'"

            };
            List<List<string>> playerchoices = new List<List<string>> 
            {
                new List<string>
                {
                    "You make a cordial inquiry as to who the strange man might happen to be...",
                    "You protest! You are no mercenary rogue! You're an adventurer...",
                    "You remark that the man seems to have all the magic he needs judging by this place..."
                },
                new List<string>
                { 
                    "Unsure of the strange man's allegiances, you bluster. An escapee? you? You most certainly think not!",
                    "You tentatively tell him that you *may* have perhaps found yourself wanted by a few of the less civil denizens of this place - through no fault of your own, of course...",
                    "You take a chance - informing him that he's correct, you are indeed an escapee..."
                },
                new List<string>
                { 
                    
                },
                new List<string>
                {
                    "Find out all you can from Merigold?",
                    "No, time is of the essence..."
                }

            };
            if (specialItems[7].SpecifyAttribute == "read") 
            {
                playerchoices[0].Insert(0, "You raise a sceptical eyebrow and ask incredulously if the eccentric man before you is... Merigold?");
                playerchoices[0].RemoveAt(1);
            }
            if (_player.Traits.ContainsKey("thespian"))
            {
                playerchoices[0].Add("With a dazzling smile and boundless gravitas you inform the magnificent mage that he has, in no uncertain terms, been rescued by you - just as soon as he whips up some voodoo for any monsters that, uh, might've given you the slip. *ahem*...");
            }
            if (_player.Traits.ContainsKey("jinxed"))
            {
                playerchoices[0].Insert(1, "You protest! You are no mercenary rogue! Afterall, who would hire you after your many jinxy fiascos?");
                playerchoices[0].RemoveAt(2);
            }

            if (specialItems[7].SpecifyAttribute == "read")
            {
                playerchoices[1].Insert(2, "You tell the man, who you are now confident must be Merigold, that you are an escapee and you need his help...");
                playerchoices[1].RemoveAt(3);
                playerchoices[1].Insert(0, "Dubious that this man could actually be the Merigold mentioned in that other prisoner's journal, you hesitate...");
                playerchoices[1].RemoveAt(1);
            }
            if (_player.Traits.ContainsKey("thespian") || _player.Traits.ContainsKey("opportunist"))
            {
                playerchoices[1].Add("You boldly announce that he's correct and that if you're both to survive you should help each other...");
            }

            if (_player.FieryEscape)
            {
                playerchoices[2].Add("Umm... You decide it's best not to mention the raging inferno you started within his home. You obfuscate...");
                playerchoices[2].Add("You claim that someone somewhere - you couldn't possibly relay the details because obviously you weren't there - may have started a fire somewhere that you then took advantage of...");
                if (_player.Traits.ContainsKey("jinxed"))
                {
                    playerchoices[2].Add("You nervously recount your oafish antics with the magnifying glass; 'Well, yes... err.. it's a funny story really...'");
                }
                if (_player.Traits.ContainsKey("sadist"))
                {
                    playerchoices[2].Add("You laugh in his doddery old face as you reminisce on how you set ablaze his precious tower...");
                }
                if (_player.Traits.ContainsKey("thespian"))
                {
                    playerchoices[2].Add("Placed on the spot, you spin a fanciful tale of swashbuckling duels, swinging across chandeliers and felling many mighty foes three times your size!...And, uh, oh yes, there was some minor incident with a fire...");
                }
            }
            else
            {
                playerchoices[2].Add("You claim you just got lucky and took an opportunity when it arose...");
                playerchoices[2].Add("You say you don't want to talk about it - it was a gruelling ordeal...");
                if(_player.Traits.ContainsKey("friends with fairies") )
                {
                    if (secretChamber.FeatureList[8].Name == "ajar mosaic door")
                    {
                        playerchoices[2].Add("You let your fairy friends explain everything while you bunny-hop on the spot - the two halves, the jar-loving mosaic, the whole shebang...");
                    }
                    if (_player.Inventory.Contains(specialItems[1]))
                    {
                        playerchoices[2].Add("You tell him you see dead people...");
                    }
                    
                }
                if (_player.Traits.ContainsKey("sadist"))
                {
                    playerchoices[2].Add("Graagh! You did what's best in life; you crushed your enemies, saw them driven before you, and heard the lamentation of their women...");
                }
                if (_player.Traits.ContainsKey("thespian") && goblin.Stamina > 0 && gnoll.Stamina > 0)
                {
                    playerchoices[2].Add(" Oh, you gave them the old razzle dazzle, you razzle-dazzled them!\n    You gave them an act with lots of *flash* in it, and their reaction was oh so pash-sionate... ");
                }
                if (_player.Traits.ContainsKey("diligent"))
                {
                    playerchoices[2].Add("You just kept persisting until you found something that succeeded...");
                }
            }

            Dictionary<string, string> choice_customresponse = new Dictionary<string, string>
            {
                {"You make a cordial inquiry as to who the strange man might happen to be...", "The man scoffs. 'I'm Merigold, you fool. What? Are you some green recruit enticed by the loot and plunder of my former-home? The wine cellar's not here if that's why you blundered your way in here. Unless...' he catches sight of you for the first time, studying you intensely through those huge spectacles. A sudden notion dawns on him that he's almost too frightened to let bud into hope..." },
                {"You protest! You are no mercenary rogue! You're an adventurer...", "'Yes, yes,' Merigold indulges you, 'you don't do it for the money I'm sure. You do it for the prestige and glory and free booze and bounty that comes from pilfering my abode. What a brave, strong adventurer y...' Then he catches sight of you. A frown creases his brow as he peers at you through those huge spectacles, taking in your somewhat dishevelled appearance. You see a realisation dawn on him, though one he dare not quite yet let bud into hope..." },
                {"You remark that the man seems to have all the magic he needs judging by this place...", "'Oh! I have *all* the magic I need, do I?' he raves suddenly, flailing his arms eccentrically. He inadvertently swats a fluttering missive. It issues a tiny squeak as its sent careering amongst the wobbly pipes.\n 'I *am* sorry,' he vents with hyperbolic sarcasm, 'I didn't realise I was standing in the presence of someone so clearly versed in the arcane arts. Please, I implore you, take *more* of my magic away,' he rolls his huge magnified eyes. 'I clearly have too much! Why, i bet a trained chimp could do my job, couldn't they,' he huffs, hands on hips, 'but then I suppose your all in short supply of our simian cousins, given *they'd* have enough brains to steer clear of your misfit band of knuckleheaded...'\nHe abruptly stops mid-rant the moment he catches sight of you. " },
                {"You raise a sceptical eyebrow and ask incredulously if the eccentric man before you is... Merigold?", "'Of course I'm Merigold, you fool. What? Are you some green recruit enticed by the loot and plunder of my former-home? The wine cellar's not here if that's why you blundered in here. Unless...' he catches sight of you for the first time, studying you intensely through those huge spectacles. A sudden notion dawns on him that he's almost too frightened to let bud into hope..." },
                {"With a dazzling smile and boundless gravitas you inform the magnificent mage that he has, in no uncertain terms, been rescued by you - just as soon as he whips up some voodoo for any monsters that, uh, might've given you the slip. *ahem*...", "'What is this, some trick?' the dotty man before you retorts, 'There's no one who can infiltrate this tower. No adventurer could possibly get past the CurseBreaker's defences and magical safeguards...' Then, all at once, he stops. He studies you up and down, for the first time taking in your dashing grin, your charismatic bearing, and your general air of plucky 'je ne sais quoi'. \nThankfully, as he peers through those binoculars he calls glasses, he seems not to notice the rather desperate condition of your attire, which might've otherwise shattered your impression of a risque, swashbuckling hero..." },
                {"You protest! You are no mercenary rogue! Afterall, who would hire you after your many jinxy fiascos?", "'Well if you're not one of those thugs then just who *are* you?' Merigold retorts incredulously, 'Don't tell me you somehow managed to blunder your way into this tower.' He scoffs. 'Why, the magical charms, the wardic runes... they alone would be impossible for any intruder to bypass. So why did you really blunder in here, hmm? You want to glug down an elixir to help you cheat at car- forgive me, *coins* -,  quaff a potion to unleash your inner Casanova, hmm? Or is it something even more trivial to waste my time? I may as well. Any excuse to frustrate and delay your bosses plans is fine by me so long as you take the rap for it...' Then he catches sight of you. A frown creases his brow as he peers at you through those huge spectacles, taking in your somewhat dishevelled appearance. You see a realisation dawn on him, though one he dare not quite yet let bud into hope..." },

                {"Unsure of the strange man's allegiances, you bluster. An escapee? you? You most certainly think not!", "The dotty man turns out to be shrewder than you first guessed. He isn't taken in for a second by your flimsy denial. \n\t'In most normal circumstances it would only be wise for you to deny such a thing, for what they'll do to you - what *he* will do to you should you be captured, is beyond the pale.' the man states gravely, but you espy an infectious excitement gleaming from behind those ancient eyes peering back at you over his spectacles. 'However, fear not, for I am no friend of the CurseBreaker or his confederates. My name is Merigold. I am the true proprietor of this tower. And until recently, I was this land's premier sorcerer, second to none. I dare say you have found in me a most potent ally, for I have every reason to aspire to undo the CurseBreaker's hold on this tower. However, my dear fellow, I can only do so much.  The CurseBreaker already has done much to constrain me, if not physically then by leeching from me the majority of my powers...\n'You, however...You are as yet unknown to the CurseBreaker, an unaccounted for variable in his most meticulous plans. You are the best chance yet to foiling them. And I'm afraid to say, that you have only until the stroke of midnight to stop him in his tracks...'" },
                {"You tentatively tell him that you *may* have perhaps found yourself wanted by a few of the less civil denizens of this place - through no fault of your own, of course...", "The man barks with laughter. 'Of that I have no doubt,' he chuckles. Then he eyes you again, appraisingly. 'Well, you need not fear anything from me. You shall find that I am of a wholly civilised countenance, and moreover, I have every reason to be as hostile to the CurseBreaker and his designs as you are.' An infectious excitement alights his eyes as he matches your gaze, and a smile cracks upon his lips. 'I dare say that the CurseBreaker might find his position a little more precarious than he'd hitherto thought. However, if we're to make good on the advantage of our unlikely alliance, then we must act decisively and we must act fast. First; introductions. My name is Merigold. This,' he gestures with his hand in a gracious arc, 'is my home. And though I'm sorry to say you find it in the state its in, I'm not at all sorry to say that your timing couldn't have been more fortuitous. You find yourself positioned to spoil the CurseBreaker's plans upon the cusp of their completion and I can tell you how...'" },
                {"You take a chance - informing him that he's correct, you are indeed an escapee...", "The man claps his hands together with unrestrained glee. To your surprise, before you can do anything to stop him, you find yourself embraced by the eccentric before you. He laughs exuberantly, but when he pulls back you spot a newly determined gleam in his eye as he looks off into the distance. 'Finally!' he exclaims with delight, 'finally the tide has turned...' Then he seems to catch himself. He takes a step back formally clearing his throat and adopting the courteous demeanour of a genial host. He dusts off his robe before beaming. 'But, ah, yes... introductions! My name is Merigold. This tower you find yourself in *was* my home. You may have heard of my name around these parts.' he preens himself haughtily, 'The magnificent, the magnanimous, the magnetic, the magister are all agreeable descriptors attributed to me, of course... or if you listen to those dithering old fools in the Independent Wizarding Authority, 'the magniloquent magnate...such slander!' his loquacious flow deteriorates into a staccato of mumbled ravings, 'question this... investigate that... hygiene... safety standards... WIZARD COURT!' he bellows to the room at large.\n  You jump back, raising a disconcerted eyebrow at this sudden tangential rant, but before you can get a word in, he resumes his elegant, stately speech.\n\t'I am the greatest sorcerer within these lands and though i find much of my power has been robbed from me, you have nevertheless found in me a powerful ally. Trust me when I say,' he remarks with a flourish, 'that the moment the CurseBreaker's negligence allowed our meeting, will be remembered as the instant his plans fell about him like a house of cards...'" },
                {"You tell the man, who you are now confident must be Merigold, that you are an escapee and you need his help...", "The man claps his hands together with unrestrained glee. To your surprise, before you can do anything to stop him, you find yourself embraced by the eccentric before you. He laughs exuberantly, but when he pulls back you spot a newly determined gleam in his eye as he looks off into the distance. 'Finally!' he exclaims with delight, 'finally the tide has turned...' Then he seems to catch himself. He takes a step back formally clearing his throat and adopting the courteous demeanour of a genial host. He dusts off his robe before beaming. 'But, ah, yes... introductions! My name is indeed Merigold. This tower you find yourself in *was* my home. You may have heard of my name around these parts.' he preens himself haughtily, 'The magnificent, the magnanimous, the magnetic, the magister are all sensible descriptors attributed to me, of course... or if you listen to those dithering old fools in the Independent Wizarding Authority, 'the magniloquent magnate...such slander!' his loquacious flow deteriorates into a staccato of mumbled ravings, 'question this... investigate that... hygiene... safety standards... WIZARD COURT!' he bellows to the room at large.  You jump back, raising a disconcerted eyebrow at this sudden tangential rant, but before you can get a word in, he resumes his elegant, stately speech.\n\t'I am the greatest sorcerer within these lands and though i find much of my power has been robbed from me at this present moment, you have nevertheless found in me a powerful ally. Trust me when I say,' he remarks with a flourish, 'that the moment the CurseBreaker's negligence allowed our meeting, will be remembered as the instant his plans fell about him like a house of cards...'" },
                {"Dubious that this man could actually be the Merigold mentioned in that other prisoner's journal, you hesitate...", "He seems to read your thoughts as he watches you doubt yourself.\n\t'In most normal circumstances it would only be wise for you to deny such a thing, for what they'll do to you - what *he* will do to you should you be captured, is beyond the pale.' the man states gravely, but you espy an infectious excitement gleaming from behind those ancient eyes peering back at you over his spectacles. 'However, fear not, for I am no friend of the CurseBreaker or his confederates. My name is Merigold. I am the true proprietor of this tower. And until recently, I was this land's premier sorcerer, second to none. I dare say you have found in me a most potent ally, for I have every reason to aspire to undo the CurseBreaker's hold on this tower. However, my dear fellow, I can only do so much.  The CurseBreaker already has done much to constrain me, if not physically then by leeching from me the majority of my powers...\n'You, however...You are as yet unknown to the CurseBreaker, an unaccounted for variable in his most meticulous plans. You are the best chance yet to foiling them. And I'm afraid to say, that you have only until the stroke of midnight to stop him in his tracks...'" },
                {"You boldly announce that he's correct and that if you're both to survive you should help each other...", "The man claps his hands together with unrestrained glee. To your surprise, before you can do anything to stop him, you find yourself clasped in a tight embrace by the eccentric before you. Your dashing smile falters as the oddball laughs exuberantly. When he pulls back though, you spot a newly determined gleam in his eye as he looks off into the distance. 'Finally!' he exclaims with delight, 'finally the tide has turned...' Then he seems to catch himself. He takes a step back formally clearing his throat and adopting the courteous demeanour of a genial host. He dusts off his robe before beaming. 'But, ah, yes... introductions! My name is indeed Merigold. This tower you find yourself in *was* my home. You may have heard of my name around these parts.' he preens himself haughtily, 'The magnificent, the magnanimous, the magnetic, the magister are all sensible descriptors attributed to me, of course... or if you listen to those dithering old fools in the Independent Wizarding Authority, 'the magniloquent magnate...such slander!' his loquacious flow deteriorates into a staccato of mumbled ravings, 'question this... investigate that... hygiene... safety standards... WIZARD COURT!' he bellows to the room at large.  You jump back, raising a disconcerted eyebrow at this sudden tangential rant, but before you can get a word in, he resumes his bubbly manner and bombastic speech.\n\t'I am the greatest sorcerer within these lands and though i find much of my power has been robbed from me at this present moment, you have nevertheless found in me a powerful ally. Trust me when I say,' he remarks with a flourish, 'that the moment the CurseBreaker's negligence allowed our meeting, will be remembered as the instant his plans fell about him like a house of cards...'" },

                {"Umm... You decide it's best not to mention the raging inferno you started within his home. You obfuscate...", "Merigold seems somewhat dissatisfied by your lacklustre response, but he doesn't press the issue any further. He instead tells you forthrightly, and as succinctly as he can, everything you need to know." },
                {"You claim that someone somewhere - you couldn't possibly relay the details because obviously you weren't there - may have started a fire somewhere that you then took advantage of...", "Merigold's face seems to pale at the news of the destruction of so much of his belongings, books and above all knowledge. He spares just a moment wherein he mourns the loss, before taking a deep breath... \n\t'I suppose I must count my blessings that at least such a heavy price has granted you the chance to right so many wrongs.' His face then garners a resolve that you'd hitherto not have expected of the eccentric man..." },
                {"You nervously recount your oafish antics with the magnifying glass; 'Well, yes... err.. it's a funny story really...'", "Merigold's eye seems to develop a nervous tic as he listens. You recount your tale with mounting trepidation, like someone who knows they can't dig themselves out of a hole but can't stop trying anyway with ever bigger shovels. 'You... you...' he stammers, barely containing what must be another of his tangential ravings, '...centuries worth of knowledge,' he breathes incredulously, '... ancient lore passed from generation to generation, scholar to scholar... ' he takes a steadying breath, trying to stop himself pacing up and down. 'No... no. It's fine. I can rewrite them all from memory... It'll just take time is all... I mustn't be angry with you... you're the hero... you're here to save the day~' he gurgles a near deranged babble of laughter. 'Yes... goosefraba... goosefraba...' He sits himself back down, hands delicately placed on lap, and through some seemingly monumental self-restraint faces you with a calm and patient and calm and solicitous and most of all calm expression. \nFinally he screams. \nOnce he's finished, and long after you dived behind your seat, he sits himself down again in a prim and sedate manner.\n\t'Now where were we?' he asks, 'Ah, yes..." },
                {"You laugh in his doddery old face as you reminisce on how you set ablaze his precious tower...", "Merigold's face darkens the moment he realises you're not joking. 'I don't know who you are, stranger,' he visibly shakes with fury, 'but you're about to find out first hand why you should never cross a wizard. It's going to be your first lesson upon the subject, and I daresay your last...'\n You leer as you relish the fight to come. Oh this is going to be fun..." },
                {"Placed on the spot, you spin a fanciful tale of swashbuckling duels, swinging across chandeliers and felling many mighty foes three times your size!...And, uh, oh yes, there was some minor incident with a fire...", "'Chandeliers? I don't have chandeliers...' Merigold scratches his head. \nYou say that the CurseBreaker must have brought them in to fit in with his gothic chic and inflated ego\n\t'Ah, yes,' Merigold replies dottily, 'yes, of course, of course... wait? Fire!?'\n You tell him not to worry about it, it's all under control, you *think* you saw a minotaur out there battling the flames so at least its keeping your adversaries busy... and such a small fire too, did you not mention how small it was? Tiny. Miniscule... \n  Merigold gives you a long hard stare, but ultimately let's it go..." },
                {"You claim you just got lucky and took an opportunity when it arose...", "\t'Well,' Merigold answers, 'however you pulled it off, I can only say that I'm impressed. Now..." },
                {"You say you don't want to talk about it - it was a gruelling ordeal...", "Merigold seems disappointed by your reticence, but he doesn't press you for answers. Instead he seems to get down to business..." },
                {"You let your fairy friends explain everything while you bunny-hop on the spot - the two halves, the jar-loving mosaic, the whole shebang...", "Merigold waits patiently for you to answer, but as your fairy friends explain everything in such lurid detail that their words transport your verdant imagination into new and wondrous vistas, it seems Merigold himself has little patience for them. It's almost as if he can't hear them... \n  He also reacts a bit peculiarly to your rather idiosyncratic, leporid antics. The wizard seems to seriously consider multiple courses of action, as you nibble on a lettuce leaf, before finally settling on categorising the incident as one of those awkward faux pas' that evade rational explanation. Letting it slide, he decides to simply hope for the best..." },
                {"You tell him you see dead people...", "\t'Dead people?' He responds cautiously.\n You nod your head emphatically. You have a magical friend named Binky who lives in your backpack. He tells you skeleton jokes...\n Merigold studies you warily for a moment, taking in your protuberant eyes. He seems to consider multiple possible courses of action very carefully, before finally settling on (and perhaps against his better judgement) just hoping for the best..." },
                {"Graagh! You did what's best in life; you crushed your enemies, saw them driven before you, and heard the lamentation of their women...", "\t'Well,' Merigold responds nervously, 'perhaps your method of barbar- uh, rough justice is what this situation calls for...'" },
                {" Oh, you gave them the old razzle dazzle, you razzle-dazzled them!\n    You gave them an act with lots of *flash* in it, and their reaction was oh so pash-sionate... ", "Merigold asks where you heard that catchy song before. He could've sworn he heard a shanty like it sung by a sailor, but it's been ages since he ordered any Sea Cargo..." },
                {"You just kept persisting until you found something that succeeded...", "Merigold states that your persistence is not only relatable but inspiring. 'But,' he gravely intones, 'you'll need more than that to face what comes next...'" }
            };
            switch (LinearParle(choice_customresponse, parlances, playerchoices, description))
            {
                case -50:
                    Dice DIE = new Dice(847713);
                    List<Dice> battleMerigold = new List<Dice> { DIE };
                    return battleMerigold;
                case 0:
                    //moves on to explaining you've only until midnight to succeed before asking questions...
                    string description1 = "Merigold becomes animated by boundless energy. ";
                    Item healPotion1 = new Item("healing potion", "It has flecks of gold floating amidst a gel like suspension. The label reads; 'When you're feeling blue, down with the flu, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!'", true, "used", 20, "Stamina: When you're blue, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!");
                    Item healPotion2 = new Item("healing potion", "It has flecks of gold floating amidst a gel like suspension. The label reads; 'When you're feeling blue, down with the flu, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!'", true, "used", 20, "Stamina: When you're blue, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!");
                    if (_player.Stamina < _player.InitialStamina / 2)
                    {
                        description1 += "\n\t'Well, first things first. You look frightful, dear fellow - like death warmed up. A few of my finest elixirs will mend those ghastly wounds.'\nHe rummages under the laboratory's worktop and produces a few bottles of his healing potion. You notice the hue is slightly different to the ones you've come across elsewhere in the tower. When you point this out, he taps his nose wryly. \n\t'Little does the CurseBreaker know that I've been supplying his forces with potions of a somewhat subpar standard. A small act of defiance for sure, but one I've been all too willing to make and for minimal risk... Here,' he proffers one of the bottles, 'to your health. And keep the others for later - I fear you may need them for what lies ahead...'\nYou glug it down and to your surprise, it tastes delicious. You feel incredible. Merigold waves away the compliments with faux-modesty, though you can tell he's pleased. \n";
                        _player.Stamina = _player.InitialStamina;
                        _player.Inventory.Add(healPotion1);
                        _player.Inventory.Add(healPotion2);
                    }
                    else if (_player.Stamina < 7 * _player.InitialStamina / 8)
                    {
                        description1 += "\n\t'Well, first things first. You look like you've taken a few knocks. A few of my finest elixirs will sort that out.'\nHe rummages under the laboratory's worktop and produces a few bottles of his healing potion. You notice the hue is slightly different to the ones you've come across elsewhere in the tower. When you point this out, he taps his nose wryly. \n\t'Little does the CurseBreaker know that I've been supplying his forces with potions of a somewhat subpar standard. A small act of defiance for sure, but one I've been all too willing to make and for minimal risk... Here,' he proffers one of the bottles, 'to your health. And keep the others for later - I fear you may need them for what lies ahead...'\nYou glug it down and to your surprise, it tastes delicious. You feel incredible. Merigold waves away the compliments with faux-modesty, though you can tell he's pleased. \n";
                        _player.Stamina = _player.InitialStamina;
                        _player.Inventory.Add(healPotion1);
                        _player.Inventory.Add(healPotion2);
                    }
                    string parlance = "'So then please, please, ask away dear fellow,' he implores you. He makes a theatrical flourish, 'My knowledge, whatever capabilities I still possess, are at your disposal...'";
                    List<string> playerchoices1 = new List<string>
                    {
                        "You remind him of what he said about only having until midnight to stop some profane ritual - you ask him to tell you everything he knows about it...",
                        "You inquire about these twelve artefacts, these hidden caches of magic, scattered throughout the tower; what are they, and where are you most likely to find them?",
                        "You question his claim about having no magic; if he has no magic then what on earth is powering this impressive manufactory?",
                        "You get the uneasy sense that Merigold knows more about your adversary than he's letting on. You press him to tell you just who the CurseBreaker really is...",
                        "You tell him that the strange innkeeper made it clear you were abducted and exchanged in the hope that the CurseBreaker might somehow break Myrovia's curse. How does this villain intend to commit such a feat?",
                        "You remind Merigold of what he told you regarding the CurseBreaker leeching his power... You tentatively make an inquiry into how much power, exactly, he is talking about and what your chances are against such a foe?",
                        "You query what the deal with the portal is - Couldn't Merigold have escaped at anytime?",
                        "You remind Merigold that he mentioned there may be other methods of ending the CurseBreaker's schemes. You ask him what these might be...",
                        "You tell him frankly that while you may be an adventurer, you're no hero. You tell him you're sorry to disappoint him but all you want is a way out of here...",
                        "You inform him that you're ready to take your chances with the portal...",
                        "You sincerely thank Merigold for all of his help, however upon consideration you conclude it's perhaps wiser to employ some other strategy of taking down the CurseBreaker..."
                    };
                    Dictionary<string, string> choice_answer = new Dictionary<string, string>
                    {
                        {
                            "You remind him of what he said about only having until midnight to stop some profane ritual - you ask him to tell you everything he knows about it...",

                            "'I know not the precise arrangements,' Merigold replies cautiously, 'I can only infer" +
                            " an educated guess from the materials I know the CurseBreaker has seized from my home; the two pages" +
                            " he tore from my books. One was a book on Fey Realms and Magicks. It's a beguiling read for those" +
                            " uninitiated in the arcane arts, one likely to see them lost forever amongst its pages, but " +
                            "it contains within methods for creating channels and conduits between our world and another. " +
                            "The world over which the Eldritch ArchFey hold their twilit dominion... \n  'The second page was from a cursed " +
                            "book of forbidden rites of transmutation. I kept it solely to study the curse surrounding it, you " +
                            "understand - never its wretched contents. I never for a second thought, that under my custodianship, it should be used for so" +
                            " insidious means. However, it seems, that the CurseBreaker has discovered" +
                            " something within it that has escaped these old eyes of mine. \n  From these clues, and from " +
                            "the more than sinister aura that even now creeps through the halls of my former home, I had concluded" +
                            " long ago that he had summoned a treacherous creature of immense power inside these walls, and somehow contained it. " +
                            "An Eldritch ArchLord or some Eternal Lady of the Fey Realms. Something you might like to think of as being to fairies and pixies what devils are to us humans. " +
                            "Creatures that congeal callousness with charm, mix mayhem with magnanimity, and alloy ecstasy with mania. As for the why of his risking summoning such a silver-tongued monster, well, that became clearer far later of the hour than I'd have wished..." +
                            "\n  It was only a week ago when the CurseBreaker, as he'd by now begun calling himself, deigned to visit me in my imprisonment." +
                            " When he did, I felt a dread all the way down to the very marrow of my bones. I could never have guessed..." +
                            " I'd suspected he'd been experimenting with his Fey prisoner, or perhaps bargaining with it - a perilous and foolhardy exercise, but one his ego might've " +
                            "driven him towards. But no. What he'd done surpassed the bounds of my most vile expectations. He'd... He took its eyes...\n " +
                            "  Somehow, through some dark magic I cannot begin to imagine, he took its eyes for his own - and with them!' Merigold shudders, 'With them, " +
                            "I fear, he has attained powers that are beyond the ken of mortal magicians such as I. For the Fey have their own mercurial sorcery, and I know not its bounds or caprices." +
                            "But I can tell you this; it was as though from his gaze alone he could see my very history laid bare before him, read my secrets from under my skin, clasp in his sight all of my innermost thoughts as though they were runes " +
                            "carved upon my very bones. It was all I could do to conceal the existence of the twelve artefacts from him, but perhaps he wouldn't have cared. By then, he'd far surpassed my own magicks at their height to see such meagre trinkets as a threat to him." +
                            " \n However,' Merigold's voice drops to a conspiratorial hush, 'He has since then not seized any further bodypart of this Fey Prince or Princess and absorbed it into himself. And since he is not the sort to practice " +
                            "caution or temperance when more power is available for the snatching, I can only conclude that there must've been some unforeseen setback. " +
                            "From what little I understand, Fey magic is difficult to control. A human body harbouring such gifts might incur terrible penalties." +
                            "Which leads me to why I believe he has procured for himself those pages out of the forbidden tome of transmutation." +
                            "\n  It is my belief that he seeks to perform a ritual tonight when the moon waxes its fullest" +
                            " that will bear him a new body out of the offal and sinews of two others - his own and that of the Eldritch ArchFey in the oubliette." +
                            " Such an act would make him an abomination, but one with all the powers and secret magicks of the most treacherous of demons. Should he succeed, I dare say you nor anyone else, will stand a chance against him...'"
                        },

                        {
                            "You inquire about these twelve artefacts, these hidden caches of magic, scattered throughout the tower; what are they, and where are you most likely to find them?",

                            "'I can tell you precisely of their form,' Merigold briskly informs you, 'as for telling you precisely where they are? Well, that is a tricker prospect...\n" +
                            "The tokens I imbued with my magic are as follows;\n A ring, a broach, an armband, a bracelet, a crown, a medallion, a pocketwatch, a quarterstaff, a book, a knife, a jewelry box and a belt." +
                            "\n  Of these the book, the jewelry box and the knife are the only items that weren't ransacked by those thuggish marauders who think themselves the CurseBreaker's army." +
                            " The book will be somewhere in one of my libraries, the one next to the antechamber. The thieves took everything inside the jewelry box but left the box itself - its still where I left it, outside this room and by the window. As for the knife, it must be somewhere" +
                            "  amongst the jumble of other utensils in the dining hall. \n  As for the other tokens in that list - I'm sorry to say that all nine were seized by the CurseBreaker's forces. I witnessed three goblins each take an item," +
                            " one the ring, another the bracelet, the other the broach. But they are each all jailors, so you may find them with each item still upon their person. The gnoll who took my medallion, he too regularly drools his way through this tower, " +
                            "perhaps you'll already have bumped into them on your way here? \n  As for four others, I'm afraid they were seized by the minotaur who guards this manufactory you're standing in. I presume you gave him the slip? Well, he took " +
                            "the crown, the belt, the armband and my very own pocket-watch, but given his tardiness I can only assume the beast doesn't know how to tell the time, or else lost the latter of these items somewhere..." +
                            "\n That just leaves my staff - can you believe they took a wizard's staff? The scandal! It was the CurseBreaker who ordered I be parted from it. No doubt it'll have been stashed away in some sealed-off chamber - most likely alongside all the perfidious secrets he doesn't wish" +
                            " anyone else to find. And that staff... that staff may prove useful to you, beyond helping me steer the portal to where you wish to go, I mean. It's one of the few artefacts capable of protecting you from the CurseBreaker's magic, and one of the few weapons that " +
                            "can break through any shielding enchantments. If you can find it..."
                        },

                        {
                            "You question his claim about having no magic; if he has no magic then what on earth is powering this impressive manufactory?",

                            "'Oh, Magic for sure,' he replies darkly, 'but for the most part, not mine. 'Tis the CurseBreaker's magic that is at work here -" +
                            " he co-opted my designs, yes, left me to direct it, its true, took advantage of my own ingenuity, but it is *his* magic. I merely, shall we say, orchestrate it as" +
                            " a conductor might orchestrate a... erm...' he gestures with his hands as though trying to conjure the right word, before settling " +
                            "rather lamely on, 'orchestra.'" +
                            "\n\t'I cannot bend his magic against his will no more than I could force you to flex" +
                            " your arm just by telling you to do it... Well, actually, with the right spell I could, " +
                            "but then I'd be delving into Elminster's corollaries upon charms and jinxes and no doubt" +
                            "we would be debating all day on the finer points of fundamental magical theory... '" +
                            "\n 'But regardless, I fear the headline is that I find myself stuck here without more magic of my own, " +
                            "which is rather where you and those twelve artefacts come in...'\n He peers your way expectantly."
                        },

                        {
                            "You get the uneasy sense that Merigold knows more about your adversary than he's letting on. You press him to tell you just who the CurseBreaker really is...",

                            "Merigold levels you a sombre look, before something in his expression crumples around the edges. He heaves a heavy sigh, gazing off to the side" +
                            " for a pensive moment, before gazing back at you with rueful twinkling eyes. \n\t'This was... a topic of conversation" +
                            " I had hoped would not be touched upon,' he confesses, 'but I suppose, given what you've been put through, you've a right to know" +
                            " everything. The truth is that I myself am in part to blame for your predicament. Indeed, it was my training" +
                            " that introduced your nemesis to the opportunities magic promises. In short, he was my apprentice. But as his" +
                            " teacher, as his mentor, I can only conclude that I failed him. \n\t'I was never the pastoral type, of course - teaching..." +
                            " it... it did not come easily.' he looks beseechingly up at you, almost as though you might be able to relieve him of the burden of the guilt he bears upon himself. But he only looks away before you can reply. " +
                            "\n\t'Back then,' he continues tonelessly, 'his name was Arcturas. He came into my custody after an awful incident in his home village - the place... slaughtered by adventurers turned bloodthirsty bandits it seems. " +
                            "The boy was left all alone. He somehow made his way to one of the cities, joined a gang and one day made the fateful decision to try to " +
                            "raid this place. All his life he'd only ever known petty thievery and meanness. When my janitor caught him, I found him to be starving, skin and bones..." +
                            " I took pity on him. I fed him a meal. I asked where his parents were - tried to tell him off,' Merigold scoffs as he remembers, 'He had this... deadened look in his" +
                            " eyes, as though he'd seen more of the world's cruelty than any child had a right to see. It was only when he discovered my magical talents his interest was piqued. At last his silence broken, he implored that I tell him more" +
                            " about it - theory, you understand, not flashy cantrips. With most rapscallions you show them a few whizzbangs and they cheer and that's that. But not Arcturas. No. He was a brooding, studious and assiduous child even then." +
                            " Far more interested in runes and magic circles and in particular fairy circles. \n\t'Well, given some time" +
                            " we grew to know each other better and it only seemed natural that I take him on as his mentor in the arcane. He had a talent for it..." +
                            "\n  Merigold's face turns into an ugly scowl for a moment, one levelled more at himself than anyone else. 'I was *proud* of him,' he breathes, as though sickened by the very admission." +
                            "\n\t'It would be years later when I understood that this innocuous fixation on fairy circles wasn't nearly as innocent as I'd originally thought. " +
                            "A few more years after that when I uncovered his obsession with the Lords and Ladies of the ArchFey and their lore. " +
                            "And not long afterwards I was facing the CurseBreaker. \n\t'My apprentice,' Merigold stated scathingly, 'had mutilated his own face" +
                            " in exchange for sleepless eyes. He had killed to procure for himself a private army. He had amassed wealth and power... and terror. And he'd done it all for... what? " +
                            "Revenge? Hubris? Some twisted sense of justice? Alas, it has been too long since I truly understood " +
                            "that boy. And while these aged eyes of mine lost sight of him more and more over the years, the man that boy became now has a gaze that " +
                            "pierces the very horizons of magic's frontiers, and he sets that frightful gaze upon some terrible goal and some terrifying place where I cannot follow...'"
                        },

                        {
                            "You tell him that the strange innkeeper made it clear you were abducted and exchanged in the hope that the CurseBreaker might somehow break Myrovia's curse. How does this villain intend to commit such a feat?",

                            "'The innkeeper?' Merigold raises a quizzical eyebrow. 'There is only one tavern in Myrovia" +
                            ", and it is owned by its mayor. You mean to say he too is now in cahoots with the CurseBreaker?" +
                            " Well, the mayor's past - it's a terrible business. but as for the curse itself. As far as I know... As far as *anybody* knows" +
                            " there is and has only ever been one method for exorcising a curse. To suppose a second goes beyond the reach of all previous study on the subject" +
                            "... *all* previous study. \n\t'If what you say is true, and I don't doubt it is, then the CurseBreaker has discovered" +
                            " something that has eluded mankind for millenia. Such a feat as banishing a curse without... well... the blood price... it would be unprecedented.'" +
                            "\n\nYou inquire what Merigold means by 'blood price'..." +
                            "\n\n\t'The ancient way,' he answers gravely. 'Curses are born of secrets taken to the grave and of injustices left to fester." +
                            " The way to undo a curse, is to uncover the secret or right the wrong that had been committed." +
                            " This, more often than not, means offering up the guilty to the curse's manifestation - or delivering some kind of poetic justice unto" +
                            " them. To merely kill them, you understand, it isn't enough. These acts, the one that is the curse's root and the one that brings its end " +
                            "like autumn leaves, they have to... in a sense... rhyme." +
                            " \n Wherein, of course, lies the great mystery and difficulty with curses. If the preceding stanza is a secret never told, how does one know the next verse to recite?" +
                            "  \n  So very often, curses go unresolved, and they reverberate endlessly through the centuries eternally awaiting their reprise...'"
                        },

                        {
                            "You remind Merigold of what he told you regarding the CurseBreaker leeching his power... You tentatively make an inquiry into how much power, exactly, he is talking about and what your chances are against such a foe?",

                            "'Your chances of defeating the CurseBreaker without significant help aren't zero, but there is no overstating how absurdly slim they would be,' Merigold warns you sternly." +
                            " 'He has tremendous talents in the arcane, and even without that, he is a superb duellist. Not to mention he will have taken" +
                            " precautions to ensure he can complete his ritual. However, do not despair. For his achilles heel is very much located in this tower -" +
                            " in point of fact, he has several weaknesses." +
                            "\n\t'Stopping the ritual, or somehow sabotaging it, is the most important step in evening your chances. It may do little to outright diminish the power he already has, but it will prevent him from" +
                            " achieving even more. It will widen the window of opportunity for you to strike him down. If you don't do this, then once you confront him you will be in a race against time to kill him before the ritual is complete, because" +
                            " if he finishes it, it doesn't mater how courageous or valiant your efforts - he will *end you* with absurd ease." +
                            "\n\t'As for neutralising his magic,' Merigold continues apace, 'there exist two weapons that could aid you. The first is my staff - one of the " +
                            " twelve artefacts i need to control the portal. If you choose to keep it rather than lending me its power, you can use it to nullify his arcane attacks. However, " +
                            "the problem is I don't know where it is stashed, for it was seized from me by the CurseBreaker himself and he'll no doubt have concealed it well." +
                            "\n\t'The easiest way to find it may be through the portal itself. If I rig it to trace the location of the staff it won't matter that neither of us know the destination, it will nevertheless take you there - but I should warn you, if" +
                            " the CurseBreaker chose its hiding place, he'll have chosen it well. I can get you there with the portal but you will have" +
                            " to find your own way out and either back to this manufactory, or else find another way forward..." +
                            "\n\t'As for the second weapon,' Merigold states with a grim smile and a huff, '*that* will be a lot easier to find...'" +
                            "\n\nYou tell him that sounds more promising and ask him what it is..." +
                            "\n\t'It's the sword of sealed souls,' Merigold answers, 'a cursed weapon that has the extraordinary effect of" +
                            " devouring magic due to its cursed nature. It can also, as the name suggests, steal souls... oh, don't worry! Not the wielder's!' he laughs, but it is one that has no humour to it. 'No,' he intones grimly, 'this weapon poses a far more immediate problem.'" +
                            "\n\nYou ask what this problem can possibly be if he knows where it is and there are no drawbacks to using it..." +
                            "\n\tMerigold cuts your retort short with his tight, grim smile alone. 'The problem,' he answers softly, 'is that the sword is currently being wielded by the very beast that guards this Manufactory; a minotaur. The CurseBreaker recognises the threat such a weapon poses to him, of course, but he also knows that it is one of the few weapons" +
                            " in this tower that I truly fear. So long as my monstrous captor outside those doors wields it, then he knows that I won't even think of trying to escape, for even were my powers not diminished, the minotaur would be invulnerable to my magic so long as that greatsword were his. \n\t'However, the monster is not invulnerable to sharp steel and sufficient skill. If you can outmatch it, the sword will be yours to wield against the very man who sought to hold me captive with it.\n\t'And I won't lie,' Merigold cracks a bitter smile that for once appears genuine, '*that* is a prospect that I relish..."
                        },

                        {
                            "You query what the deal with the portal is - Couldn't Merigold have escaped at anytime?",

                            "'If I could, do you really think I'd still be here?' Merigold answers. 'The portal, like most of everything else in this manufactory, is powered by" +
                            " the CurseBreaker's magic. It's purpose? To deliver the potion and elixirs I'm coerced into manufacturing to his forces all across these lands. As such I cannot, shall we say, channel it in a way that goes against his will - at least, not without" +
                            " magic of my own. The more of those twelve artefacts you can find, the more of my former arcane abilities I can recuperate" +
                            ". With all twelve, I dare say I could seize complete control of the portal and deliver you to precisely where you decide to go.\n\t'As for the door" +
                            " that you came through,' he adds wryly, 'I dare say you've already come across my guard...\n\t'In short, your best chance through that portal lies in recovering as many " +
                            "artefacts as you can. With a majority of them I'd say your chances to reach a destination of your choosing are good. Gather around half of them and, well, let's just say that if you don't make it to where you want to go you'll at least" +
                            " most probably end up somewhere in this tower. Four or less, however...' he shifts uncomfortably, his all too apparent unease more than a little unsettling before he fixes you with a stern gaze," +
                            " 'I'll do the best I can.'"
                        },

                        {
                            "You remind Merigold that he mentioned there may be other methods of ending the CurseBreaker's schemes. You ask him what these might be...",

                            "'Certainly,' Merigold says, pushing his glasses up the bridge of his nose, 'if I'm right, and I'm almost certain that I am, then the ritual the CurseBreaker is to perform must be conducted" +
                            " in the unfiltered light of the full moon - not through a window, you understand, but outside. Someplace where there is little chance of anything obstructing its celestial lure upon his magic. I have little doubt that place will be atop this very tower." +
                            "\n\t'Moreover,' Merigold continues, 'I know that his most jealously guarded prisoner, who he needs for this dark metamorphosis, is contained beneath us, down in the subterranean levels of this tower - and yet, " +
                            "he requires access to this eldritch creature, this ArchFey. I can only conclude, therefore, that if *he* is atop the tower, and that *creature* is underground, then he must have created another magical portal between them. There will undoubtedly be a way to commandeer this portal for your own purposes," +
                            " and it is at this subterranean level where you might most easily sabotage or stop the ritual - critical if you wish to buy yourself enough time to kill your adversary, but it does not come without it's own risks." +
                            "\n\t'For the creature ensnared beneath us must not be underestimated. It's cunning cannot be overstated, nor can its malice. It is a beguiling, duplicitous and above all treacherous monster. You may find yourself lured by it's specious tales and lies. It will try to trick you. Lie to you. And were it not somehow bound and fettered by the CurseBreaker's magicks, a confrontation with it would be unfathomably dangerous." +
                            "\n\t'Whether or not the risk is worth it, however, is a choice that rests in your hands...'"
                        },

                        {
                            "You tell him frankly that while you may be an adventurer, you're no hero. You tell him you're sorry to disappoint him but all you want is a way out of here...",

                            "Merigold doesn't react immediately to your excuses and explanations, his face appears implacable and stonily impassive the more you talk. Finally, once you've finished, he considers you for a moment over hands held together as though in prayer. " +
                            "'I cannot blame you for having doubts, of course,' Merigold states quite calmly, his voice measured and even, 'It is, afterall, you who is risking their life. \n\t'The truth of the matter is" +
                            ", with enough of those artefacts, there is nothing stopping me from delivering you to any place you specified - any place at all. And I mean, it's not like I can force you to endanger yourself any further. If you ae decided on the matter, I can help you escape, even if it means leaving us all, Myrovia, perhaps the whole continent, languishing under the shadow of an unstoppable CurseBreaker." +
                            " So if I can't force you, I suppose it falls upon me to persuade you as best I can. And all I can do in that regard is invite you to consider what it is you'd be risking your life for. It is not often we find ourselves, " +
                            "in a moment where everything could change, where the eyes of the world fall on us to make a stand, speak out or take action. It's far easier to look to others to make that first step, to let them be the ones to stand alone against the tide, and let them alone reap the consequences for their conscience.' \n   Merigold smiles wanly towards you. 'However, there truly is no one else,' he softly assures you. '" +
                            "The hour has arrived and the moment has fallen upon you. Every hope of every innocent caught in the CurseBreaker's " +
                            "schemes strides alongside you. Every one of his victims, their sacrifices have all been so someone where you stand right" +
                            " now might be so courageous as to stand against him and have a chance. If from what you've seen of the CurseBreaker's crimes, " +
                            "you think they're justified - fine. If from what I've told you of him, you think he's right and I'm just some old fool long " +
                            "past his usefulness - then fine. But if there is any doubt, any pang of conscience at all, any corpuscle of your being that " +
                            "revolts at the notion that a man like the CurseBreaker can get away with all the lives he's twisted, the souls he's ruptured," +
                            " the loved ones he's torn apart then don't allow yourself to regret this moment. Because it shan't arise again. And by the " +
                            "time you feel that regret - and you shall - there will be no one else to look to who'll make that stand you could've made " +
                            "when you had the chance...'" +
                            "\n\t'So,' Merigold heaves as he rises from his seat, 'the choice is yours. What shall you do?"
                        },

                        {
                            "You inform him that you're ready to take your chances with the portal...",

                            "'Marvellous,' he exclaims, jumping to his feet and cracking a few joints as " +
                            "though he were going to take a sprint. 'now - how many of my artefacts, precisely, do you have that I can use?'"
                        },

                        {
                            "You sincerely thank Merigold for all of his help, however upon consideration you conclude it's perhaps wiser to employ some other strategy of taking down the CurseBreaker...",

                            "'Then,' Merigold concludes, 'I have helped you the best I can. " +
                            "If you do not wish to pass through this portal, then the only exit is the door. " +
                            "However you dealt with the minotaur before you got here... well, I can only wish " +
                            "you the best of luck. Oh! And before I forget...' He waves his arms in the forms of some esoteric" +
                            " incantation. 'There! I believe I had just enough magic to light the stairway down to the lowest levels. " +
                            " It should no longer be quite so treacherous to traverse, but if you do change your mind, you know where to find " +
                            "me...'\n\nYou begin to stride purposefully away your gaze set on the task at hand," +
                            " when Merigold calls out to you one last time. \n\t'And remember this above all, " +
                            "you have only until the clock strikes twelve! All the gods help you if you don't " +
                            "stop him before then...'"
                        },


                        {
                            "This is all too much. Your deception cannot last. You confess to Merigold everything. You are no adventurer like your fellow inmates. In fact, you were never anything other than a fraudster, a small-time con-artist, and general rapscallion...",

                            "Merigold doesn't react immediately to your confession, his face appears implacable and stonily impassive the more you talk. Finally, once you've finished, you find yourself caught in the ensuing silence as the aged wizard considers you for a moment over hands held together as though in prayer. " +
                            "\n\t'Whoever you are,' Merigold says softly, 'whatever it is you've done in your past, one fact is inescapable.'" +
                            "\n\n In the midst of your seemingly unconsolable self-doubt, you spare him a glance to ask him what that is." +
                            "\n\nMerigold warmly smiles your way. 'You're the one who escaped,' he tells you simply. 'It is *you* who've made it this far. You who've succeeded where others have not. " +
                            "YOU are the one who stands before me despite everything. That tells me something. It tells me that there is more to you than you know. And moreover,' he asserts with infectious resolve, 'it fills me with hope. Hope!" +
                            " Because YOU are precisely what the CurseBreaker never accounted for. YOU are the unseen variable in his machinations, the factor he couldn't help but overlook. You have something all those other adventurers, " +
                            "with all their real experience, did not have and it brought you here.  I may not know what that something is. Perhaps you haven't figured it out yet either, but once you do I know one thing. The CurseBreaker will be sorry he ever " +
                            "underestimated it. So...' \n He dusts his hands before standing before you, proffering his hand. 'What do you say we make the CurseBreaker regret the day he underestimated an old wizard and his theatrical champion?'"
                        },

                        {
                            "The inferno raging down in the lower levels is still fresh in your mind. Even if its been put out, those levels will be teeming with enemies. You ask Merigold if there's any other way down?",

                            "His response is laconic - 'No'" +
                            "\n\nOh well, it was worth a try..."
                        },

                        {
                            "You remind Merigold of what he told you regarding the CurseBreaker leeching his power... You tentatively make an inquiry into how much power, exactly, he is talking about and what your chances are to defeat such a foe?",

                            "'Your chances of defeating the CurseBreaker without significant help aren't zero, but there is no overstating how absurdly slim they would be,' Merigold warns you sternly." +
                            " 'He has tremendous talents in the arcane, and even without that, he is a superb duellist. Not to mention he will have taken" +
                            " precautions to ensure he can complete his ritual. However, do not despair. For his achilles heel is very much located in this tower -" +
                            " in point of fact, he has several weaknesses." +
                            "\n\t'Stopping the ritual, or somehow sabotaging it, is the most important step in evening your chances. It may do little to outright diminish the power he already has, but it will prevent him from" +
                            " achieving even more. It will widen the window of opportunity for you to strike him down. If you don't do this, then once you confront him you will be in a race against time to kill him before the ritual is complete, because" +
                            " if he finishes it, it doesn't mater how courageous or valiant your efforts - he will *end you* with absurd ease." +
                            "\n\t'As for neutralising his magic,' Merigold continues apace, 'there exist two weapons that could aid you. The first is my staff - one of the " +
                            " twelve artefacts i need to control the portal. If you choose to keep it rather than lending me its power, you can use it to nullify his arcane attacks. However, " +
                            "the problem is I don't know where it is stashed, for it was seized from me by the CurseBreaker himself and he'll no doubt have concealed it well." +
                            "\n\t'The easiest way to find it may be through the portal itself. If I rig it to trace the location of the staff it won't matter that neither of us know the destination, it will nevertheless take you there - but I should warn you, if" +
                            " the CurseBreaker chose its hiding place, he'll have chosen it well. I can get you there with the portal but you will have" +
                            " to find your own way out and either back to this manufactory, or else find another way forward..." +
                            "\n\t'As for the second weapon,' Merigold states with a grim smile and a huff, '*that* will be a lot easier to find...'" +
                            "\n\nYou tell him that sounds more promising and ask him what it is..." +
                            "\n\t'It's the sword of sealed souls,' Merigold answers, 'a cursed weapon that has the extraordinary effect of" +
                            " devouring magic due to its cursed nature. It can also, as the name suggests, steal souls... oh, don't worry! Not the wielder's!' he laughs, but it is one that has no humour to it. 'No,' he intones grimly, 'this weapon poses a far more immediate problem.' " +
                            "\n\nYou gingerly reach to your side and unsheathe the sword there. You begin telling Merigold that you're fairly certain from his description that this may be the sword he's talking about, but you can tell immediately by his astonishment that your surmise is correct..." +
                            "\n\n\t'My dear, dear fellow,' he breathes, a grin spreading wide across his face. 'You never cease to amaze me. Yes,' he confirms, 'This is the very sword. Which means you already possess the single best means for countering the CurseBreaker's magicks...'" +
                            "\n\t'All that remains,' Merigold's voice sobers to its familiar grave tone, 'is for you to match his skill in a one and one duel.'" +
                            " \n  By the timbre of Merigold's voice, however, you can sense with a well of foreboding that that will be no small feat..."
                        }
                    };
                    if (_player.Traits.ContainsKey("thespian"))
                    {
                        playerchoices1.Insert(8, "This is all too much. Your deception cannot last. You confess to Merigold everything. You are no adventurer like your fellow inmates. In fact, you were never anything other than a fraudster, a small-time con-artist, and general rapscallion...");
                        playerchoices1.RemoveAt(9);
                    }
                    if (_player.FieryEscape)
                    {
                        playerchoices1.Insert(10, "The inferno raging down in the lower levels is still fresh in your mind. Even if its been put out, those levels will be teeming with enemies. You ask Merigold if there's any other way down?");
                        playerchoices1.RemoveAt(11);
                    }
                    bool soulSword = false;
                    foreach(Weapon w in _player.WeaponInventory)
                    {
                        if (w.Name.Trim().ToLower() == "sword of sealed souls")
                        {
                            soulSword = true;
                        }
                    }
                    if (soulSword)
                    {
                        playerchoices1.Insert(5, "You remind Merigold of what he told you regarding the CurseBreaker leeching his power... You tentatively make an inquiry into how much power, exactly, he is talking about and what your chances are to defeat such a foe?");
                        playerchoices1.RemoveAt(6);
                    }
                    Dice D120 = new Dice(120);
                    Dice D60 = new Dice(60);
                    Dice D40 = new Dice(40);
                    Dice D30 = new Dice(30);
                    Dice D24 = new Dice(24);
                    Dice D20 = new Dice(20);
                    Dice D15 = new Dice(15);
                    Dice D10 = new Dice(10);
                    int numOfMGItems = 0;
                    Dice D2 = new Dice(2);
                    Dice D3 = new Dice(3);
                    Weapon flap = new Weapon("", "", new List<Dice> { D120 }, new List<string>(), new List<string>());
                    Monster backpack = new Monster("backpack", "", new List<Item>(), 1, 1, flap);
                    if (!_player.FieryEscape)
                    {
                        switch (LoopParle(choice_answer, playerchoices1, description1, parlance, 8, 9, 10))
                        {
                            case 1:
                                Console.WriteLine("Will you accept the quest that has fallen upon you?");

                                if (getYesNoResponse())
                                {
                                    Console.WriteLine("The relief that floods through Merigold is made all too evident.\n" +
                                        "'Then,' he asks, 'how do you wish to go about this? The portal in this hall will be the fastest way to wherever " +
                                        "you decide to go, but its reliability depends on how many artefacts you have. Alternatively, you can make" +
                                        " your own way down to the subterranean levels of this tower. It's a surer route, but if you take it you'll be in a race against the clock. Midnight approaches, " +
                                        "and you haven't the luxury of any delay...'" +
                                        "\n\nWill you use the portal in the magical manufactory?");
                                    if (getYesNoResponse())
                                    {
                                        Console.WriteLine("'Then, I must ask,' Merigold inquires nervously, 'just how many of my artefacts have you collected?'");
                                        numOfMGItems = 0;
                                        Console.ReadKey(true);
                                        Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");

                                        message = "";
                                        foreach (Item item in MGItems)
                                        {
                                            if (_player.Inventory.Contains(item))
                                            {
                                                numOfMGItems++;
                                                backpack.Items.Add(item);
                                                message += $"[{numOfMGItems}] {item.Name}\n";
                                            }
                                        }
                                        foreach(Item weapon in _player.WeaponInventory)
                                        {
                                            if (MGItems.Contains(weapon))
                                            {
                                                numOfMGItems++;
                                                backpack.Items.Add(weapon);
                                                message += $"[{numOfMGItems}] {weapon.Name}\n";
                                            }
                                        }

                                        Console.ReadKey(true);
                                        if (numOfMGItems != 0)
                                        {
                                            Console.WriteLine("How many are you willing to give to Merigold?");


                                            backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Feeling a little embarrassed you confess you have no items that fit Merigold's description. You have nothing...");
                                            Console.ReadKey(true);
                                        }
                                        numOfMGItems = numOfMGItems - backpack.Items.Count;
                                        _player.MGItemsDonated = numOfMGItems;
                                        switch (numOfMGItems)
                                        {
                                            case 0:
                                                Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                                    " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                                Console.WriteLine("How will you respond?" +
                                                    "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                                    "\n[2] Tell Merigold you think he might be right...");
                                                switch (getIntResponse(3))
                                                {
                                                    case 1:
                                                        List<Dice> roulette = new List<Dice> { D120, D1 };
                                                        return roulette;
                                                    default:
                                                        Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                        List<Dice> moreArtefactsToFaceCB = new List<Dice> { D2 };
                                                        return moreArtefactsToFaceCB;
                                                }
                                            case 1:
                                                return new List<Dice> { D60, D60, D1 };
                                            case 2:
                                                return new List<Dice> { D60, D60, D1 };
                                            case 3:
                                                return new List<Dice> { D60, D60, D1 };
                                            case 4:
                                                return new List<Dice> { D40, D40, D40, D1 };
                                            case 5:
                                                return new List<Dice> { D40, D40, D40, D1 };
                                            case 6:
                                                return new List<Dice> { D40, D40, D40, D1 };
                                            case 7:
                                                return new List<Dice> { D30, D30, D30, D30, D1 };
                                            case 8:
                                                return new List<Dice> { D30, D30, D30, D30, D1 };
                                            case 9:
                                                return new List<Dice> { D24, D24, D24, D24, D24, D1 };
                                            case 10:
                                                return new List<Dice> { D20, D20, D20, D20, D20, D20, D1 };
                                            case 11:
                                                return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D1 };
                                            case 12:
                                                return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D1 };
                                            default:
                                                return new List<Dice> { D1 };
                                        }
                                    }
                                    else // no, i'll find my own way forward...
                                    {
                                        Console.WriteLine("'Then,' Merigold concludes, 'I have helped you the best I can. " +
                                            "If you do not wish to pass through this portal, then the only exit is the door. " +
                                            "However you dealt with the minotaur before you got here... well, I can only wish " +
                                            "you the best of luck. Oh! And before I forget...' He waves his arms in the forms of some esoteric" +
                                            " incantation. 'There! I believe I had just enough magic to light the stairway down to the lowest levels. " +
                                            " It should no longer be quite so treacherous to traverse, but if you do change your mind, you know where to find " +
                                            "me...'\n\nYou begin to stride purposefully away your gaze set on the task at hand," +
                                            " when Merigold calls out to you one last time. \n\t'And remember this above all, " +
                                            "you have only until the clock strikes twelve! All the gods help you if you don't " +
                                            "stop him before then...'");
                                        stairwayToLower.Name = "bright stairwell";
                                        stairwayToLower.Description = "Merigold's incantaition has illuminated these stairs. At last you can see just how dangerous they really are with jutting uneven steps, crumbling masonry and little if any handholds. Descending these stairs may still prove dangerous even when lit...";
                                        stairwayToLower.Dark = false;
                                        return new List<Dice> { D1 };

                                    }
                                }
                                else // no i wish to flee...
                                {
                                    Console.WriteLine("Merigold cannot hide how crestfallen he is. \n\t'Then I suppose all that is left for me to do is use the portal to deliver you to wherever you wish to go... \n\t'How many artefacts do you have?'");
                                    numOfMGItems = 0;
                                    Console.ReadKey(true);
                                    Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");

                                    message = "";
                                    foreach (Item item in MGItems)
                                    {
                                        if (_player.Inventory.Contains(item))
                                        {
                                            numOfMGItems++;
                                            backpack.Items.Add(item);
                                            message += $"[{numOfMGItems}] {item.Name}\n";
                                        }
                                    }
                                    foreach (Item weapon in _player.WeaponInventory)
                                    {
                                        if (MGItems.Contains(weapon))
                                        {
                                            numOfMGItems++;
                                            backpack.Items.Add(weapon);
                                            message += $"[{numOfMGItems}] {weapon.Name}\n";
                                        }
                                    }

                                    Console.ReadKey(true);
                                    if (numOfMGItems != 0)
                                    {
                                        Console.WriteLine("How many are you willing to give to Merigold?");


                                        backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                    }
                                    numOfMGItems = numOfMGItems - backpack.Items.Count;
                                    _player.MGItemsDonated = numOfMGItems;
                                    switch (numOfMGItems)
                                    {
                                        case 0:
                                            Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                                    " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                            Console.WriteLine("How will you respond?" +
                                                "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                                "\n[2] Tell Merigold you think he might be right...");
                                            switch (getIntResponse(3))
                                            {
                                                case 1:
                                                    return new List<Dice> { D120, D2 };
                                                default:
                                                    Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                    return new List<Dice> { D3 };
                                            }
                                        case 1:
                                            return new List<Dice> { D60, D60, D2 };
                                        case 2:
                                            return new List<Dice> { D60, D60, D2 };
                                        case 3:
                                            return new List<Dice> { D60, D60, D2 };
                                        case 4:
                                            return new List<Dice> { D40, D40, D40, D2 };
                                        case 5:
                                            return new List<Dice> { D40, D40, D40, D2 };
                                        case 6:
                                            return new List<Dice> { D40, D40, D40, D2 };
                                        case 7:
                                            return new List<Dice> { D30, D30, D30, D30, D2 };
                                        case 8:
                                            return new List<Dice> { D30, D30, D30, D30, D2 };
                                        case 9:
                                            return new List<Dice> { D24, D24, D24, D24, D24, D2 };
                                        case 10:
                                            return new List<Dice> { D20, D20, D20, D20, D20, D20, D2 };
                                        case 11:
                                            return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D2 };
                                        case 12:
                                            return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D2 };
                                        default:
                                            return new List<Dice> { D2 };
                                    }

                                }

                            case 2: // use the portal to defeat CurseBreaker

                                numOfMGItems = 0;
                                Console.ReadKey(true);
                                Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");

                                message = "";
                                foreach (Item item in MGItems)
                                {
                                    if (_player.Inventory.Contains(item))
                                    {
                                        numOfMGItems++;
                                        backpack.Items.Add(item);
                                        message += $"[{numOfMGItems}] {item.Name}\n";
                                    }
                                }
                                foreach (Item weapon in _player.WeaponInventory)
                                {
                                    if (MGItems.Contains(weapon))
                                    {
                                        numOfMGItems++;
                                        backpack.Items.Add(weapon);
                                        message += $"[{numOfMGItems}] {weapon.Name}\n";
                                    }
                                }

                                Console.ReadKey(true);
                                if (numOfMGItems != 0)
                                {
                                    Console.WriteLine("How many are you willing to give to Merigold?");


                                    backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                }
                                numOfMGItems = numOfMGItems - backpack.Items.Count;
                                _player.MGItemsDonated = numOfMGItems;
                                switch (numOfMGItems)
                                {
                                    case 0:
                                        Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                            " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                        Console.WriteLine("How will you respond?" +
                                            "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                            "\n[2] Tell Merigold you think he might be right...");
                                        switch (getIntResponse(3))
                                        {
                                            case 1:
                                                List<Dice> roulette = new List<Dice> { D120, D1 };
                                                return roulette;
                                            default:
                                                Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                List<Dice> moreArtefactsToFaceCB = new List<Dice> { D2 };
                                                return moreArtefactsToFaceCB;
                                        }
                                    case 1:
                                        return new List<Dice> { D60, D60, D1 };
                                    case 2:
                                        return new List<Dice> { D60, D60, D1 };
                                    case 3:
                                        return new List<Dice> { D60, D60, D1 };
                                    case 4:
                                        return new List<Dice> { D40, D40, D40, D1 };
                                    case 5:
                                        return new List<Dice> { D40, D40, D40, D1 };
                                    case 6:
                                        return new List<Dice> { D40, D40, D40, D1 };
                                    case 7:
                                        return new List<Dice> { D30, D30, D30, D30, D1 };
                                    case 8:
                                        return new List<Dice> { D30, D30, D30, D30, D1 };
                                    case 9:
                                        return new List<Dice> { D24, D24, D24, D24, D24, D1 };
                                    case 10:
                                        return new List<Dice> { D20, D20, D20, D20, D20, D20, D1 };
                                    case 11:
                                        return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D1 };
                                    case 12:
                                        return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D1 };
                                    default:
                                        return new List<Dice> { D1 };
                                }
                            case 3: // find your own way forward
                                
                                stairwayToLower.Name = "bright stairwell";
                                stairwayToLower.Description = "Merigold's incantaition has illuminated these stairs. At last you can see just how dangerous they really are with jutting uneven steps, crumbling masonry and little if any handholds. Descending these stairs may still prove dangerous even when lit...";
                                stairwayToLower.Dark = false;
                                return new List<Dice> { D1 };
                            default:
                                return new List<Dice> { D1 };
                        }
                    }
                    else
                    {
                        switch (LoopParle(choice_answer, playerchoices1, description1, parlance, 8, 9))
                        {
                            case 1: //flee
                                Console.WriteLine("Will you accept the quest that has fallen upon you?");

                                if (getYesNoResponse())
                                {
                                    Console.WriteLine("The relief that floods through Merigold is made all too evident.\n" +
                                        "'Then,' he asks, 'how do you wish to go about this? The portal in this hall will be the fastest way to wherever " +
                                        "you decide to go, but its reliability depends on how many artefacts you have. Alternatively, you can make" +
                                        " your own way down to the subterranean levels of this tower. It's a surer route, but if you take it you'll be in a race against the clock. Midnight approaches, " +
                                        "and you haven't the luxury of any delay...'" +
                                        "\n\nWill you use the portal in the magical manufactory?");
                                    if (getYesNoResponse())
                                    {
                                        Console.WriteLine("'Then, I must ask,' Merigold inquires nervously, 'just how many of my artefacts have you collected?'");
                                        numOfMGItems = 0;
                                        Console.ReadKey(true);
                                        Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");
                                        
                                        message = "";
                                        foreach (Item item in MGItems)
                                        {
                                            if (_player.Inventory.Contains(item))
                                            {
                                                numOfMGItems++;
                                                backpack.Items.Add(item);
                                                message += $"[{numOfMGItems}] {item.Name}\n";
                                            }
                                        }
                                        foreach (Item weapon in _player.WeaponInventory)
                                        {
                                            if (MGItems.Contains(weapon))
                                            {
                                                numOfMGItems++;
                                                backpack.Items.Add(weapon);
                                                message += $"[{numOfMGItems}] {weapon.Name}\n";
                                            }
                                        }

                                        Console.ReadKey(true);
                                        if (numOfMGItems != 0)
                                        {
                                            Console.WriteLine("How many are you willing to give to Merigold?");


                                            backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                        }
                                        numOfMGItems = numOfMGItems - backpack.Items.Count;
                                        _player.MGItemsDonated = numOfMGItems;
                                        
                                        switch (numOfMGItems)
                                        {
                                            case 0:
                                                Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                                    " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                                Console.WriteLine("How will you respond?" +
                                                    "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                                    "\n[2] Tell Merigold you think he might be right...");
                                                switch (getIntResponse(3))
                                                {
                                                    case 1:
                                                        List<Dice> roulette = new List<Dice> { D120, D1 };
                                                        return roulette;
                                                    default:
                                                        Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                        List<Dice> moreArtefactsToFaceCB = new List<Dice> { D2 };
                                                        return moreArtefactsToFaceCB;
                                                }
                                            case 1:
                                                return new List<Dice> { D60, D60, D1 };
                                            case 2:
                                                return new List<Dice> { D60, D60, D1 };
                                            case 3:
                                                return new List<Dice> { D60, D60, D1 };
                                            case 4:
                                                return new List<Dice> { D40, D40, D40, D1 };
                                            case 5:
                                                return new List<Dice> { D40, D40, D40, D1 };
                                            case 6:
                                                return new List<Dice> { D40, D40, D40, D1 };
                                            case 7:
                                                return new List<Dice> { D30, D30, D30, D30, D1 };
                                            case 8:
                                                return new List<Dice> { D30, D30, D30, D30, D1 };
                                            case 9:
                                                return new List<Dice> { D24, D24, D24, D24, D24, D1 };
                                            case 10:
                                                return new List<Dice> { D20, D20, D20, D20, D20, D20, D1 };
                                            case 11:
                                                return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D1 };
                                            case 12:
                                                return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D1 };
                                            default:
                                                return new List<Dice> { D1 };
                                        }
                                    }
                                    else // no, i'll find my own way forward...
                                    {
                                        Console.WriteLine("'Then,' Merigold concludes, 'I have helped you the best I can. " +
                                            "If you do not wish to pass through this portal, then the only exit is the door. " +
                                            "However you dealt with the minotaur before you got here... well, I can only wish " +
                                            "you the best of luck. Oh! And before I forget...' He waves his arms in the forms of some esoteric" +
                                            " incantation. 'There! I believe I had just enough magic to light the stairway down to the lowest levels. " +
                                            " It should no longer be quite so treacherous to traverse, but if you do change your mind, you know where to find " +
                                            "me...'\n\nYou begin to stride purposefully away your gaze set on the task at hand," +
                                            " when Merigold calls out to you one last time. \n\t'And remember this above all, " +
                                            "you have only until the clock strikes twelve! All the gods help you if you don't " +
                                            "stop him before then...'");
                                        stairwayToLower.Name = "bright stairwell";
                                        stairwayToLower.Description = "Merigold's incantaition has illuminated these stairs. At last you can see just how dangerous they really are with jutting uneven steps, crumbling masonry and little if any handholds. Descending these stairs may still prove dangerous even when lit...";
                                        stairwayToLower.Dark = false;
                                        return new List<Dice> { D1 };

                                    }
                                }
                                else // no i wish to flee...
                                {
                                    Console.WriteLine("Merigold cannot hide how crestfallen he is. \n\t'Then I suppose all that is left for me to do is use the portal to deliver you to wherever you wish to go... \n\t'How many artefacts do you have?'");
                                    numOfMGItems = 0;
                                    Console.ReadKey(true);
                                    Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");
                                    
                                    message = "";
                                    foreach (Item item in MGItems)
                                    {
                                        if (_player.Inventory.Contains(item))
                                        {
                                            numOfMGItems++;
                                            backpack.Items.Add(item);
                                            message += $"[{numOfMGItems}] {item.Name}\n";
                                        }
                                    }
                                    foreach (Item weapon in _player.WeaponInventory)
                                    {
                                        if (MGItems.Contains(weapon))
                                        {
                                            numOfMGItems++;
                                            backpack.Items.Add(weapon);
                                            message += $"[{numOfMGItems}] {weapon.Name}\n";
                                        }
                                    }

                                    Console.ReadKey(true);
                                    if (numOfMGItems != 0)
                                    {
                                        Console.WriteLine("How many are you willing to give to Merigold?");


                                        backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                    }
                                    numOfMGItems = numOfMGItems - backpack.Items.Count;
                                    _player.MGItemsDonated = numOfMGItems;
                                    switch (numOfMGItems)
                                    {
                                        case 0:
                                            Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                                    " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                            Console.WriteLine("How will you respond?" +
                                                "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                                "\n[2] Tell Merigold you think he might be right...");
                                            switch (getIntResponse(3))
                                            {
                                                case 1:
                                                    return new List<Dice> { D120, D2 };
                                                default:
                                                    Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                    return new List<Dice> { D3 };
                                            }
                                        case 1:
                                            return new List<Dice> { D60, D60, D2 };
                                        case 2:
                                            return new List<Dice> { D60, D60, D2 };
                                        case 3:
                                            return new List<Dice> { D60, D60, D2 };
                                        case 4:
                                            return new List<Dice> { D40, D40, D40, D2 };
                                        case 5:
                                            return new List<Dice> { D40, D40, D40, D2 };
                                        case 6:
                                            return new List<Dice> { D40, D40, D40, D2 };
                                        case 7:
                                            return new List<Dice> { D30, D30, D30, D30, D2 };
                                        case 8:
                                            return new List<Dice> { D30, D30, D30, D30, D2 };
                                        case 9:
                                            return new List<Dice> { D24, D24, D24, D24, D24, D2 };
                                        case 10:
                                            return new List<Dice> { D20, D20, D20, D20, D20, D20, D2 };
                                        case 11:
                                            return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D2 };
                                        case 12:
                                            return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D2 };
                                        default:
                                            return new List<Dice> { D2 };
                                    }

                                }
                            default://face CB
                                numOfMGItems = 0;
                                Console.ReadKey(true);
                                Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");
                                Console.WriteLine("You find the following:");
                                message = "";
                                foreach (Item item in MGItems)
                                {
                                    if (_player.Inventory.Contains(item))
                                    {
                                        numOfMGItems++;
                                        backpack.Items.Add(item);
                                        message += $"[{numOfMGItems}] {item.Name}\n";
                                    }
                                }
                                foreach (Item weapon in _player.WeaponInventory)
                                {
                                    if (MGItems.Contains(weapon))
                                    {
                                        numOfMGItems++;
                                        backpack.Items.Add(weapon);
                                        message += $"[{numOfMGItems}] {weapon.Name}\n";
                                    }
                                }
                                Console.WriteLine(message);
                                if (message == "")
                                {
                                    Console.WriteLine("You have none of Merigold's artefacts!");
                                }
                                
                                Console.ReadKey(true);
                                if (numOfMGItems != 0)
                                {
                                    Console.WriteLine("How many are you willing to give to Merigold?");


                                    backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                }
                                numOfMGItems = numOfMGItems - backpack.Items.Count;
                                _player.MGItemsDonated = numOfMGItems;
                                switch (numOfMGItems)
                                {
                                    case 0:
                                        Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                            " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                        Console.WriteLine("How will you respond?" +
                                            "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                            "\n[2] Tell Merigold you think he might be right...");
                                        switch (getIntResponse(3))
                                        {
                                            case 1:
                                                List<Dice> roulette = new List<Dice> { D120, D1 };
                                                return roulette;
                                            default:
                                                Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                List<Dice> moreArtefactsToFaceCB = new List<Dice> { D2 };
                                                return moreArtefactsToFaceCB;
                                        }
                                    case 1:
                                        return new List<Dice> { D60, D60, D1 };
                                    case 2:
                                        return new List<Dice> { D60, D60, D1 };
                                    case 3:
                                        return new List<Dice> { D60, D60, D1 };
                                    case 4:
                                        return new List<Dice> { D40, D40, D40, D1 };
                                    case 5:
                                        return new List<Dice> { D40, D40, D40, D1 };
                                    case 6:
                                        return new List<Dice> { D40, D40, D40, D1 };
                                    case 7:
                                        return new List<Dice> { D30, D30, D30, D30, D1 };
                                    case 8:
                                        return new List<Dice> { D30, D30, D30, D30, D1 };
                                    case 9:
                                        return new List<Dice> { D24, D24, D24, D24, D24, D1 };
                                    case 10:
                                        return new List<Dice> { D20, D20, D20, D20, D20, D20, D1 };
                                    case 11:
                                        return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D1 };
                                    case 12:
                                        return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D1 };
                                    default:
                                        return new List<Dice> { D1 };
                                }
                        }

                    }
                default:
                    Console.WriteLine("'Very well, very well,' Merigold says. 'If you have your own plan for defeating the CurseBreaker then I shall keep you no longer. Go! And godspeed!'");
                    Dice D4 = new Dice(4);
                    return new List<Dice> { D4 };

            }
            
            
        }
        public List<Dice> ReturnToMerigoldDialogue(List<Item> specialItems, Combat battle, Room secretChamber, Monster goblin, Monster gnoll, List<Item> MGItems, Door stairwayToLower)
        {
            Dice D1 = new Dice(1);
            Console.WriteLine("Upon the sight of you Merigold immediately perks up from his unruly laboratory. 'You're back,' he bursts excitably. 'Am I to understand you would like my assistance?'");
            if (getYesNoResponse())
            {
                string description1 = "Merigold becomes animated by boundless energy. ";
                string parlance = "'So then please, please, ask away dear fellow,' he implores you. He makes a theatrical flourish, 'My knowledge, whatever capabilities I still possess, are at your disposal...'";
                List<string> playerchoices1 = new List<string>
                    {
                        "You remind him of what he said about only having until midnight to stop some profane ritual - you ask him to tell you everything he knows about it...",
                        "You inquire about these twelve artefacts, these hidden caches of magic, scattered throughout the tower; what are they, and where are you most likely to find them?",
                        "You question his claim about having no magic; if he has no magic then what on earth is powering this impressive manufactory?",
                        "You get the uneasy sense that Merigold knows more about your adversary than he's letting on. You press him to tell you just who the CurseBreaker really is...",
                        "You tell him that the strange innkeeper made it clear you were abducted and exchanged in the hope that the CurseBreaker might somehow break Myrovia's curse. How does this villain intend to commit such a feat?",
                        "You remind Merigold of what he told you regarding the CurseBreaker leeching his power... You tentatively make an inquiry into how much power, exactly, he is talking about and what your chances are against such a foe?",
                        "You query what the deal with the portal is - Couldn't Merigold have escaped at anytime?",
                        "You remind Merigold that he mentioned there may be other methods of ending the CurseBreaker's schemes. You ask him what these might be...",
                        "You tell him frankly that while you may be an adventurer, you're no hero. You tell him you're sorry to disappoint him but all you want is a way out of here...",
                        "You inform him that you're ready to take your chances with the portal...",
                        "You sincerely thank Merigold for all of his help, however upon consideration you conclude it's perhaps wiser to employ some other strategy of taking down the CurseBreaker..."
                    };
                Dictionary<string, string> choice_answer = new Dictionary<string, string>
                    {
                        {
                            "You remind him of what he said about only having until midnight to stop some profane ritual - you ask him to tell you everything he knows about it...",

                            "'I know not the precise arrangements,' Merigold replies cautiously, 'I can only infer" +
                            " an educated guess from the materials I know the CurseBreaker has seized from my home; the two pages" +
                            " he tore from my books. One was a book on Fey Realms and Magicks. It's a beguiling read for those" +
                            " uninitiated in the arcane arts, one likely to see them lost forever amongst its pages, but " +
                            "it contains within methods for creating channels and conduits between our world and another. " +
                            "The world over which the Eldritch ArchFey hold their twilit dominion... \n  'The second page was from a cursed " +
                            "book of forbidden rites of transmutation. I kept it solely to study the curse surrounding it, you " +
                            "understand - never its wretched contents. I never for a second thought, that under my custodianship, it should be used for so" +
                            " insidious means. However, it seems, that the CurseBreaker has discovered" +
                            " something within it that has escaped these old eyes of mine. \n  From these clues, and from " +
                            "the more than sinister aura that even now creeps through the halls of my former home, I had concluded" +
                            " long ago that he had summoned a treacherous creature of immense power inside these walls, and somehow contained it. " +
                            "An Eldritch ArchLord or some Eternal Lady of the Fey Realms. Something you might like to think of as being to fairies and pixies what devils are to us humans. " +
                            "Creatures that congeal callousness with charm, mix mayhem with magnanimity, and alloy ecstasy with mania. As for the why of his risking summoning such a silver-tongued monster, well, that became clearer far later of the hour than I'd have wished..." +
                            "\n  It was only a week ago when the CurseBreaker, as he'd by now begun calling himself, deigned to visit me in my imprisonment." +
                            " When he did, I felt a dread all the way down to the very marrow of my bones. I could never have guessed..." +
                            " I'd suspected he'd been experimenting with his Fey prisoner, or perhaps bargaining with it - a perilous and foolhardy exercise, but one his ego might've " +
                            "driven him towards. But no. What he'd done surpassed the bounds of my most vile expectations. He'd... He took its eyes...\n " +
                            "  Somehow, through some dark magic I cannot begin to imagine, he took its eyes for his own - and with them!' Merigold shudders, 'With them, " +
                            "I fear, he has attained powers that are beyond the ken of mortal magicians such as I. For the Fey have their own mercurial sorcery, and I know not its bounds or caprices." +
                            "But I can tell you this; it was as though from his gaze alone he could see my very history laid bare before him, read my secrets from under my skin, clasp in his sight all of my innermost thoughts as though they were runes " +
                            "carved upon my very bones. It was all I could do to conceal the existence of the twelve artefacts from him, but perhaps he wouldn't have cared. By then, he'd far surpassed my own magicks at their height to see such meagre trinkets as a threat to him." +
                            " \n However,' Merigold's voice drops to a conspiratorial hush, 'He has since then not seized any further bodypart of this Fey Prince or Princess and absorbed it into himself. And since he is not the sort to practice " +
                            "caution or temperance when more power is available for the snatching, I can only conclude that there must've been some unforeseen setback. " +
                            "From what little I understand, Fey magic is difficult to control. A human body harbouring such gifts might incur terrible penalties." +
                            "Which leads me to why I believe he has procured for himself those pages out of the forbidden tome of transmutation." +
                            "\n  It is my belief that he seeks to perform a ritual tonight when the moon waxes its fullest" +
                            " that will bear him a new body out of the offal and sinews of two others - his own and that of the Eldritch ArchFey in the oubliette." +
                            " Such an act would make him an abomination, but one with all the powers and secret magicks of the most treacherous of demons. Should he succeed, I dare say you nor anyone else, will stand a chance against him...'"
                        },

                        {
                            "You inquire about these twelve artefacts, these hidden caches of magic, scattered throughout the tower; what are they, and where are you most likely to find them?",

                            "'I can tell you precisely of their form,' Merigold briskly informs you, 'as for telling you precisely where they are? Well, that is a tricker prospect...\n" +
                            "The tokens I imbued with my magic are as follows;\n A ring, a broach, an armband, a bracelet, a crown, a medallion, a pocketwatch, a quarterstaff, a book, a knife, a jewelry box and a belt." +
                            "\n  Of these the book, the jewelry box and the knife are the only items that weren't ransacked by those thuggish marauders who think themselves the CurseBreaker's army." +
                            " The book will be somewhere in one of my libraries, the one next to the antechamber. The thieves took everything inside the jewelry box but left the box itself - its still where I left it, outside this room and by the window. As for the knife, it must be somewhere" +
                            "  amongst the jumble of other utensils in the dining hall. \n  As for the other tokens in that list - I'm sorry to say that all nine were seized by the CurseBreaker's forces. I witnessed three goblins each take an item," +
                            " one the ring, another the bracelet, the other the broach. But they are each all jailors, so you may find them with each item still upon their person. The gnoll who took my medallion, he too regularly drools his way through this tower, " +
                            "perhaps you'll already have bumped into them on your way here? \n  As for four others, I'm afraid they were seized by the minotaur who guards this manufactory you're standing in. I presume you gave him the slip? Well, he took " +
                            "the crown, the belt, the armband and my very own pocket-watch, but given his tardiness I can only assume the beast doesn't know how to tell the time, or else lost the latter of these items somewhere..." +
                            "\n That just leaves my staff - can you believe they took a wizard's staff? The scandal! It was the CurseBreaker who ordered I be parted from it. No doubt it'll have been stashed away in some sealed-off chamber - most likely alongside all the perfidious secrets he doesn't wish" +
                            " anyone else to find. And that staff... that staff may prove useful to you, beyond helping me steer the portal to where you wish to go, I mean. It's one of the few artefacts capable of protecting you from the CurseBreaker's magic, and one of the few weapons that " +
                            "can break through any shielding enchantments. If you can find it..."
                        },

                        {
                            "You question his claim about having no magic; if he has no magic then what on earth is powering this impressive manufactory?",

                            "'Oh, Magic for sure,' he replies darkly, 'but for the most part, not mine. 'Tis the CurseBreaker's magic that is at work here -" +
                            " he co-opted my designs, yes, left me to direct it, its true, took advantage of my own ingenuity, but it is *his* magic. I merely, shall we say, orchestrate it as" +
                            " a conductor might orchestrate a... erm...' he gestures with his hands as though trying to conjure the right word, before settling " +
                            "rather lamely on, 'orchestra.'" +
                            "\n\t'I cannot bend his magic against his will no more than I could force you to flex" +
                            " your arm just by telling you to do it... Well, actually, with the right spell I could, " +
                            "but then I'd be delving into Elminster's corollaries upon charms and jinxes and no doubt" +
                            "we would be debating all day on the finer points of fundamental magical theory... '" +
                            "\n 'But regardless, I fear the headline is that I find myself stuck here without more magic of my own, " +
                            "which is rather where you and those twelve artefacts come in...'\n He peers your way expectantly."
                        },

                        {
                            "You get the uneasy sense that Merigold knows more about your adversary than he's letting on. You press him to tell you just who the CurseBreaker really is...",

                            "Merigold levels you a sombre look, before something in his expression crumples around the edges. He heaves a heavy sigh, gazing off to the side" +
                            " for a pensive moment, before gazing back at you with rueful twinkling eyes. \n\t'This was... a topic of conversation" +
                            " I had hoped would not be touched upon,' he confesses, 'but I suppose, given what you've been put through, you've a right to know" +
                            " everything. The truth is that I myself am in part to blame for your predicament. Indeed, it was my training" +
                            " that introduced your nemesis to the opportunities magic promises. In short, he was my apprentice. But as his" +
                            " teacher, as his mentor, I can only conclude that I failed him. \n\t'I was never the pastoral type, of course - teaching..." +
                            " it... it did not come easily.' he looks beseechingly up at you, almost as though you might be able to relieve him of the burden of the guilt he bears upon himself. But he only looks away before you can reply. " +
                            "\n\t'Back then,' he continues tonelessly, 'his name was Arcturas. He came into my custody after an awful incident in his home village - the place... slaughtered by adventurers turned bloodthirsty bandits it seems. " +
                            "The boy was left all alone. He somehow made his way to one of the cities, joined a gang and one day made the fateful decision to try to " +
                            "raid this place. All his life he'd only ever known petty thievery and meanness. When my janitor caught him, I found him to be starving, skin and bones..." +
                            " I took pity on him. I fed him a meal. I asked where his parents were - tried to tell him off,' Merigold scoffs as he remembers, 'He had this... deadened look in his" +
                            " eyes, as though he'd seen more of the world's cruelty than any child had a right to see. It was only when he discovered my magical talents his interest was piqued. At last his silence broken, he implored that I tell him more" +
                            " about it - theory, you understand, not flashy cantrips. With most rapscallions you show them a few whizzbangs and they cheer and that's that. But not Arcturas. No. He was a brooding, studious and assiduous child even then." +
                            " Far more interested in runes and magic circles and in particular fairy circles. \n\t'Well, given some time" +
                            " we grew to know each other better and it only seemed natural that I take him on as his mentor in the arcane. He had a talent for it..." +
                            "\n  Merigold's face turns into an ugly scowl for a moment, one levelled more at himself than anyone else. 'I was *proud* of him,' he breathes, as though sickened by the very admission." +
                            "\n\t'It would be years later when I understood that this innocuous fixation on fairy circles wasn't nearly as innocent as I'd originally thought. " +
                            "A few more years after that when I uncovered his obsession with the Lords and Ladies of the ArchFey and their lore. " +
                            "And not long afterwards I was facing the CurseBreaker. \n\t'My apprentice,' Merigold stated scathingly, 'had mutilated his own face" +
                            " in exchange for sleepless eyes. He had killed to procure for himself a private army. He had amassed wealth and power... and terror. And he'd done it all for... what? " +
                            "Revenge? Hubris? Some twisted sense of justice? Alas, it has been too long since I truly understood " +
                            "that boy. And while these aged eyes of mine lost sight of him more and more over the years, the man that boy became now has a gaze that " +
                            "pierces the very horizons of magic's frontiers, and he sets that frightful gaze upon some terrible goal and some terrifying place where I cannot follow...'"
                        },

                        {
                            "You tell him that the strange innkeeper made it clear you were abducted and exchanged in the hope that the CurseBreaker might somehow break Myrovia's curse. How does this villain intend to commit such a feat?",

                            "'The innkeeper?' Merigold raises a quizzical eyebrow. 'There is only one tavern in Myrovia" +
                            ", and it is owned by its mayor. You mean to say he too is now in cahoots with the CurseBreaker?" +
                            " Well, the mayor's past - it's a terrible business. but as for the curse itself. As far as I know... As far as *anybody* knows" +
                            " there is and has only ever been one method for exorcising a curse. To suppose a second goes beyond the reach of all previous study on the subject" +
                            "... *all* previous study. \n\t'If what you say is true, and I don't doubt it is, then the CurseBreaker has discovered" +
                            " something that has eluded mankind for millenia. Such a feat as banishing a curse without... well... the blood price... it would be unprecedented.'" +
                            "\n\nYou inquire what Merigold means by 'blood price'..." +
                            "\n\n\t'The ancient way,' he answers gravely. 'Curses are born of secrets taken to the grave and of injustices left to fester." +
                            " The way to undo a curse, is to uncover the secret or right the wrong that had been committed." +
                            " This, more often than not, means offering up the guilty to the curse's manifestation - or delivering some kind of poetic justice unto" +
                            " them. To merely kill them, you understand, it isn't enough. These acts, the one that is the curse's root and the one that brings its end " +
                            "like autumn leaves, they have to... in a sense... rhyme." +
                            " \n Wherein, of course, lies the great mystery and difficulty with curses. If the preceding stanza is a secret never told, how does one know the next verse to recite?" +
                            "  \n  So very often, curses go unresolved, and they reverberate endlessly through the centuries eternally awaiting their reprise...'"
                        },

                        {
                            "You remind Merigold of what he told you regarding the CurseBreaker leeching his power... You tentatively make an inquiry into how much power, exactly, he is talking about and what your chances are against such a foe?",

                            "'Your chances of defeating the CurseBreaker without significant help aren't zero, but there is no overstating how absurdly slim they would be,' Merigold warns you sternly." +
                            " 'He has tremendous talents in the arcane, and even without that, he is a superb duellist. Not to mention he will have taken" +
                            " precautions to ensure he can complete his ritual. However, do not despair. For his achilles heel is very much located in this tower -" +
                            " in point of fact, he has several weaknesses." +
                            "\n\t'Stopping the ritual, or somehow sabotaging it, is the most important step in evening your chances. It may do little to outright diminish the power he already has, but it will prevent him from" +
                            " achieving even more. It will widen the window of opportunity for you to strike him down. If you don't do this, then once you confront him you will be in a race against time to kill him before the ritual is complete, because" +
                            " if he finishes it, it doesn't mater how courageous or valiant your efforts - he will *end you* with absurd ease." +
                            "\n\t'As for neutralising his magic,' Merigold continues apace, 'there exist two weapons that could aid you. The first is my staff - one of the " +
                            " twelve artefacts i need to control the portal. If you choose to keep it rather than lending me its power, you can use it to nullify his arcane attacks. However, " +
                            "the problem is I don't know where it is stashed, for it was seized from me by the CurseBreaker himself and he'll no doubt have concealed it well." +
                            "\n\t'The easiest way to find it may be through the portal itself. If I rig it to trace the location of the staff it won't matter that neither of us know the destination, it will nevertheless take you there - but I should warn you, if" +
                            " the CurseBreaker chose its hiding place, he'll have chosen it well. I can get you there with the portal but you will have" +
                            " to find your own way out and either back to this manufactory, or else find another way forward..." +
                            "\n\t'As for the second weapon,' Merigold states with a grim smile and a huff, '*that* will be a lot easier to find...'" +
                            "\n\nYou tell him that sounds more promising and ask him what it is..." +
                            "\n\t'It's the sword of sealed souls,' Merigold answers, 'a cursed weapon that has the extraordinary effect of" +
                            " devouring magic due to its cursed nature. It can also, as the name suggests, steal souls... oh, don't worry! Not the wielder's!' he laughs, but it is one that has no humour to it. 'No,' he intones grimly, 'this weapon poses a far more immediate problem.'" +
                            "\n\nYou ask what this problem can possibly be if he knows where it is and there are no drawbacks to using it..." +
                            "\n\tMerigold cuts your retort short with his tight, grim smile alone. 'The problem,' he answers softly, 'is that the sword is currently being wielded by the very beast that guards this Manufactory; a minotaur. The CurseBreaker recognises the threat such a weapon poses to him, of course, but he also knows that it is one of the few weapons" +
                            " in this tower that I truly fear. So long as my monstrous captor outside those doors wields it, then he knows that I won't even think of trying to escape, for even were my powers not diminished, the minotaur would be invulnerable to my magic so long as that greatsword were his. \n\t'However, the monster is not invulnerable to sharp steel and sufficient skill. If you can outmatch it, the sword will be yours to wield against the very man who sought to hold me captive with it.\n\t'And I won't lie,' Merigold cracks a bitter smile that for once appears genuine, '*that* is a prospect that I relish..."
                        },

                        {
                            "You query what the deal with the portal is - Couldn't Merigold have escaped at anytime?",

                            "'If I could, do you really think I'd still be here?' Merigold answers. 'The portal, like most of everything else in this manufactory, is powered by" +
                            " the CurseBreaker's magic. It's purpose? To deliver the potion and elixirs I'm coerced into manufacturing to his forces all across these lands. As such I cannot, shall we say, channel it in a way that goes against his will - at least, not without" +
                            " magic of my own. The more of those twelve artefacts you can find, the more of my former arcane abilities I can recuperate" +
                            ". With all twelve, I dare say I could seize complete control of the portal and deliver you to precisely where you decide to go.\n\t'As for the door" +
                            " that you came through,' he adds wryly, 'I dare say you've already come across my guard...\n\t'In short, your best chance through that portal lies in recovering as many " +
                            "artefacts as you can. With a majority of them I'd say your chances to reach a destination of your choosing are good. Gather around half of them and, well, let's just say that if you don't make it to where you want to go you'll at least" +
                            " most probably end up somewhere in this tower. Four or less, however...' he shifts uncomfortably, his all too apparent unease more than a little unsettling before he fixes you with a stern gaze," +
                            " 'I'll do the best I can.'"
                        },

                        {
                            "You remind Merigold that he mentioned there may be other methods of ending the CurseBreaker's schemes. You ask him what these might be...",

                            "'Certainly,' Merigold says, pushing his glasses up the bridge of his nose, 'if I'm right, and I'm almost certain that I am, then the ritual the CurseBreaker is to perform must be conducted" +
                            " in the unfiltered light of the full moon - not through a window, you understand, but outside. Someplace where there is little chance of anything obstructing its celestial lure upon his magic. I have little doubt that place will be atop this very tower." +
                            "\n\t'Moreover,' Merigold continues, 'I know that his most jealously guarded prisoner, who he needs for this dark metamorphosis, is contained beneath us, down in the subterranean levels of this tower - and yet, " +
                            "he requires access to this eldritch creature, this ArchFey. I can only conclude, therefore, that if *he* is atop the tower, and that *creature* is underground, then he must have created another magical portal between them. There will undoubtedly be a way to commandeer this portal for your own purposes," +
                            " and it is at this subterranean level where you might most easily sabotage or stop the ritual - critical if you wish to buy yourself enough time to kill your adversary, but it does not come without it's own risks." +
                            "\n\t'For the creature ensnared beneath us must not be underestimated. It's cunning cannot be overstated, nor can its malice. It is a beguiling, duplicitous and above all treacherous monster. You may find yourself lured by it's specious tales and lies. It will try to trick you. Lie to you. And were it not somehow bound and fettered by the CurseBreaker's magicks, a confrontation with it would be unfathomably dangerous." +
                            "\n\t'Whether or not the risk is worth it, however, is a choice that rests in your hands...'"
                        },

                        {
                            "You tell him frankly that while you may be an adventurer, you're no hero. You tell him you're sorry to disappoint him but all you want is a way out of here...",

                            "Merigold doesn't react immediately to your excuses and explanations, his face appears implacable and stonily impassive the more you talk. Finally, once you've finished, he considers you for a moment over hands held together as though in prayer. " +
                            "'I cannot blame you for having doubts, of course,' Merigold states quite calmly, his voice measured and even, 'It is, afterall, you who is risking their life. \n\t'The truth of the matter is" +
                            ", with enough of those artefacts, there is nothing stopping me from delivering you to any place you specified - any place at all. And I mean, it's not like I can force you to endanger yourself any further. If you ae decided on the matter, I can help you escape, even if it means leaving us all, Myrovia, perhaps the whole continent, languishing under the shadow of an unstoppable CurseBreaker." +
                            " So if I can't force you, I suppose it falls upon me to persuade you as best I can. And all I can do in that regard is invite you to consider what it is you'd be risking your life for. It is not often we find ourselves, " +
                            "in a moment where everything could change, where the eyes of the world fall on us to make a stand, speak out or take action. It's far easier to look to others to make that first step, to let them be the ones to stand alone against the tide, and let them alone reap the consequences for their conscience.' \n   Merigold smiles wanly towards you. 'However, there truly is no one else,' he softly assures you. '" +
                            "The hour has arrived and the moment has fallen upon you. Every hope of every innocent caught in the CurseBreaker's " +
                            "schemes strides alongside you. Every one of his victims, their sacrifices have all been so someone where you stand right" +
                            " now might be so courageous as to stand against him and have a chance. If from what you've seen of the CurseBreaker's crimes, " +
                            "you think they're justified - fine. If from what I've told you of him, you think he's right and I'm just some old fool long " +
                            "past his usefulness - then fine. But if there is any doubt, any pang of conscience at all, any corpuscle of your being that " +
                            "revolts at the notion that a man like the CurseBreaker can get away with all the lives he's twisted, the souls he's ruptured," +
                            " the loved ones he's torn apart then don't allow yourself to regret this moment. Because it shan't arise again. And by the " +
                            "time you feel that regret - and you shall - there will be no one else to look to who'll make that stand you could've made " +
                            "when you had the chance...'" +
                            "\n\t'So,' Merigold heaves as he rises from his seat, 'the choice is yours. What shall you do?"
                        },

                        {
                            "You inform him that you're ready to take your chances with the portal...",

                            "'Marvellous,' he exclaims, jumping to his feet and cracking a few joints as " +
                            "though he were going to take a sprint. 'now - how many of my artefacts, precisely, do you have that I can use?'"
                        },

                        {
                            "You sincerely thank Merigold for all of his help, however upon consideration you conclude it's perhaps wiser to employ some other strategy of taking down the CurseBreaker...",

                            "'Then,' Merigold concludes, 'I have helped you the best I can. If you do not wish to pass through this portal, then the only exit is the door. " +
                            "However you dealt with the minotaur before you got here... well, I can only wish you the best of luck. If you change your mind, of course, you " +
                            "know where to find me...'\n\nYou begin to stride purposefully away your gaze set on the task at hand, when Merigold calls out to you one last " +
                            "time. 'And remember this above all, you have only until the clock strikes twelve! All the gods help you if you don't stop him before then...'"
                        },


                        {
                            "This is all too much. Your deception cannot last. You confess to Merigold everything. You are no adventurer like your fellow inmates. In fact, you were never anything other than a fraudster, a small-time con-artist, and general rapscallion...",

                            "Merigold doesn't react immediately to your confession, his face appears implacable and stonily impassive the more you talk. Finally, once you've finished, you find yourself caught in the ensuing silence as the aged wizard considers you for a moment over hands held together as though in prayer. " +
                            "\n\t'Whoever you are,' Merigold says softly, 'whatever it is you've done in your past, one fact is inescapable.'" +
                            "\n\n In the midst of your seemingly unconsolable self-doubt, you spare him a glance to ask him what that is." +
                            "\n\nMerigold warmly smiles your way. 'You're the one who escaped,' he tells you simply. 'It is *you* who've made it this far. You who've succeeded where others have not. " +
                            "YOU are the one who stands before me despite everything. That tells me something. It tells me that there is more to you than you know. And moreover,' he asserts with infectious resolve, 'it fills me with hope. Hope!" +
                            " Because YOU are precisely what the CurseBreaker never accounted for. YOU are the unseen variable in his machinations, the factor he couldn't help but overlook. You have something all those other adventurers, " +
                            "with all their real experience, did not have and it brought you here.  I may not know what that something is. Perhaps you haven't figured it out yet either, but once you do I know one thing. The CurseBreaker will be sorry he ever " +
                            "underestimated it. So...' \n He dusts his hands before standing before you, proffering his hand. 'What do you say we make the CurseBreaker regret the day he underestimated an old wizard and his theatrical champion?'"
                        },

                        {
                            "The inferno raging down in the lower levels is still fresh in your mind. Even if its been put out, those levels will be teeming with enemies. You ask Merigold if there's any other way down?",

                            "His response is laconic - 'No'" +
                            "\n\nOh well, it was worth a try..."
                        }
                    };
                if (_player.Traits.ContainsKey("thespian"))
                {
                    playerchoices1.Insert(8, "This is all too much. Your deception cannot last. You confess to Merigold everything. You are no adventurer like your fellow inmates. In fact, you were never anything other than a fraudster, a small-time con-artist, and general rapscallion...");
                    playerchoices1.RemoveAt(9);
                }
                if (_player.FieryEscape)
                {
                    playerchoices1.Insert(10, "The inferno raging down in the lower levels is still fresh in your mind. Even if its been put out, those levels will be teeming with enemies. You ask Merigold if there's any other way down?");
                    playerchoices1.RemoveAt(11);
                }
                string message = "";
                Dice D120 = new Dice(120);
                Dice D60 = new Dice(60);
                Dice D40 = new Dice(40);
                Dice D30 = new Dice(30);
                Dice D24 = new Dice(24);
                Dice D20 = new Dice(20);
                Dice D15 = new Dice(15);
                Dice D10 = new Dice(10);
                int numOfMGItems = 0;
                
                Dice D2 = new Dice(2);
                Dice D3 = new Dice(3);
                Weapon flap = new Weapon("", "", new List<Dice> { D120 }, new List<string>(), new List<string>());
                Monster backpack = new Monster("backpack", "", new List<Item>(), 1, 1, flap);
                if (!_player.FieryEscape)
                {
                    switch (LoopParle(choice_answer, playerchoices1, description1, parlance, 8, 9, 10))
                    {
                        case 1:
                            Console.WriteLine("Will you accept the quest that has fallen upon you?");

                            if (getYesNoResponse())
                            {
                                Console.WriteLine("The relief that floods through Merigold is made all too evident.\n" +
                                    "'Then,' he asks, 'how do you wish to go about this? The portal in this hall will be the fastest way to wherever " +
                                    "you decide to go, but its reliability depends on how many artefacts you have. Alternatively, you can make" +
                                    " your own way down to the subterranean levels of this tower. It's a surer route, but if you take it you'll be in a race against the clock. Midnight approaches, " +
                                    "and you haven't the luxury of any delay...'" +
                                    "\n\nWill you use the portal in the magical manufactory?");
                                if (getYesNoResponse())
                                {
                                    Console.WriteLine("'Then, I must ask,' Merigold inquires nervously, 'just how many of my artefacts have you collected?'");
                                    numOfMGItems = 0;
                                    Console.ReadKey(true);
                                    Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");

                                    message = "";
                                    foreach (Item item in MGItems)
                                    {
                                        if (_player.Inventory.Contains(item))
                                        {
                                            numOfMGItems++;
                                            backpack.Items.Add(item);
                                            message += $"[{numOfMGItems}] {item.Name}\n";
                                        }
                                    }
                                    foreach (Item weapon in _player.WeaponInventory)
                                    {
                                        if (MGItems.Contains(weapon))
                                        {
                                            numOfMGItems++;
                                            backpack.Items.Add(weapon);
                                            message += $"[{numOfMGItems}] {weapon.Name}\n";
                                        }
                                    }

                                    Console.ReadKey(true);
                                    if (numOfMGItems != 0)
                                    {
                                        Console.WriteLine("How many are you willing to give to Merigold?");


                                        backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                    }
                                    numOfMGItems = numOfMGItems - backpack.Items.Count + _player.MGItemsDonated;
                                    _player.MGItemsDonated = numOfMGItems;
                                    switch (numOfMGItems)
                                    {
                                        case 0:
                                            Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                                " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                            Console.WriteLine("How will you respond?" +
                                                "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                                "\n[2] Tell Merigold you think he might be right...");
                                            switch (getIntResponse(3))
                                            {
                                                case 1:
                                                    List<Dice> roulette = new List<Dice> { D120, D1 };
                                                    return roulette;
                                                default:
                                                    Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                    List<Dice> moreArtefactsToFaceCB = new List<Dice> { D2 };
                                                    return moreArtefactsToFaceCB;
                                            }
                                        case 1:
                                            return new List<Dice> { D60, D60, D1 };
                                        case 2:
                                            return new List<Dice> { D60, D60, D1 };
                                        case 3:
                                            return new List<Dice> { D60, D60, D1 };
                                        case 4:
                                            return new List<Dice> { D40, D40, D40, D1 };
                                        case 5:
                                            return new List<Dice> { D40, D40, D40, D1 };
                                        case 6:
                                            return new List<Dice> { D40, D40, D40, D1 };
                                        case 7:
                                            return new List<Dice> { D30, D30, D30, D30, D1 };
                                        case 8:
                                            return new List<Dice> { D30, D30, D30, D30, D1 };
                                        case 9:
                                            return new List<Dice> { D24, D24, D24, D24, D24, D1 };
                                        case 10:
                                            return new List<Dice> { D20, D20, D20, D20, D20, D20, D1 };
                                        case 11:
                                            return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D1 };
                                        case 12:
                                            return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D1 };
                                        default:
                                            return new List<Dice> { D1 };
                                    }
                                }
                                else // no, i'll find my own way forward...
                                {
                                    Console.WriteLine("'Then,' Merigold concludes, 'I have helped you the best I can. " +
                                        "If you do not wish to pass through this portal, then the only exit is the door. " +
                                        "However you dealt with the minotaur before you got here... well, I can only wish " +
                                        "you the best of luck. Oh! And before I forget...' He waves his arms in the forms of some esoteric" +
                                        " incantation. 'There! I believe I had just enough magic to light the stairway down to the lowest levels. " +
                                        " It should no longer be quite so treacherous to traverse, but if you do change your mind, you know where to find " +
                                        "me...'\n\nYou begin to stride purposefully away your gaze set on the task at hand," +
                                        " when Merigold calls out to you one last time. \n\t'And remember this above all, " +
                                        "you have only until the clock strikes twelve! All the gods help you if you don't " +
                                        "stop him before then...'");
                                    stairwayToLower.Name = "bright stairwell";
                                    stairwayToLower.Description = "Merigold's incantaition has illuminated these stairs. At last you can see just how dangerous they really are with jutting uneven steps, crumbling masonry and little if any handholds. Descending these stairs may still prove dangerous even when lit...";
                                    stairwayToLower.Dark = false;
                                    return new List<Dice> { D1 };

                                }
                            }
                            else // no i wish to flee...
                            {
                                Console.WriteLine("Merigold cannot hide how crestfallen he is. \n\t'Then I suppose all that is left for me to do is use the portal to deliver you to wherever you wish to go... \n\t'How many artefacts do you have?'");
                                numOfMGItems = 0;
                                Console.ReadKey(true);
                                Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");

                                message = "";
                                foreach (Item item in MGItems)
                                {
                                    if (_player.Inventory.Contains(item))
                                    {
                                        numOfMGItems++;
                                        backpack.Items.Add(item);
                                        message += $"[{numOfMGItems}] {item.Name}\n";
                                    }
                                }
                                foreach (Item weapon in _player.WeaponInventory)
                                {
                                    if (MGItems.Contains(weapon))
                                    {
                                        numOfMGItems++;
                                        backpack.Items.Add(weapon);
                                        message += $"[{numOfMGItems}] {weapon.Name}\n";
                                    }
                                }

                                Console.ReadKey(true);
                                if (numOfMGItems != 0)
                                {
                                    Console.WriteLine("How many are you willing to give to Merigold?");


                                    backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                }
                                numOfMGItems = numOfMGItems - backpack.Items.Count + _player.MGItemsDonated;
                                _player.MGItemsDonated = numOfMGItems;
                                switch (numOfMGItems)
                                {
                                    case 0:
                                        Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                                " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                        Console.WriteLine("How will you respond?" +
                                            "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                            "\n[2] Tell Merigold you think he might be right...");
                                        switch (getIntResponse(3))
                                        {
                                            case 1:
                                                return new List<Dice> { D120, D2 };
                                            default:
                                                Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                return new List<Dice> { D3 };
                                        }
                                    case 1:
                                        return new List<Dice> { D60, D60, D2 };
                                    case 2:
                                        return new List<Dice> { D60, D60, D2 };
                                    case 3:
                                        return new List<Dice> { D60, D60, D2 };
                                    case 4:
                                        return new List<Dice> { D40, D40, D40, D2 };
                                    case 5:
                                        return new List<Dice> { D40, D40, D40, D2 };
                                    case 6:
                                        return new List<Dice> { D40, D40, D40, D2 };
                                    case 7:
                                        return new List<Dice> { D30, D30, D30, D30, D2 };
                                    case 8:
                                        return new List<Dice> { D30, D30, D30, D30, D2 };
                                    case 9:
                                        return new List<Dice> { D24, D24, D24, D24, D24, D2 };
                                    case 10:
                                        return new List<Dice> { D20, D20, D20, D20, D20, D20, D2 };
                                    case 11:
                                        return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D2 };
                                    case 12:
                                        return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D2 };
                                    default:
                                        return new List<Dice> { D2 };
                                }

                            }

                        case 2: // use the portal to defeat CurseBreaker

                            numOfMGItems = 0;
                            Console.ReadKey(true);
                            Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");

                            message = "";
                            foreach (Item item in MGItems)
                            {
                                if (_player.Inventory.Contains(item))
                                {
                                    numOfMGItems++;
                                    backpack.Items.Add(item);
                                    message += $"[{numOfMGItems}] {item.Name}\n";
                                }
                            }
                            foreach (Item weapon in _player.WeaponInventory)
                            {
                                if (MGItems.Contains(weapon))
                                {
                                    numOfMGItems++;
                                    backpack.Items.Add(weapon);
                                    message += $"[{numOfMGItems}] {weapon.Name}\n";
                                }
                            }

                            Console.ReadKey(true);
                            if (numOfMGItems != 0)
                            {
                                Console.WriteLine("How many are you willing to give to Merigold?");


                                backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                            }
                            numOfMGItems = numOfMGItems - backpack.Items.Count + _player.MGItemsDonated;
                            _player.MGItemsDonated = numOfMGItems;
                            switch (numOfMGItems)
                            {
                                case 0:
                                    Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                        " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                    Console.WriteLine("How will you respond?" +
                                        "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                        "\n[2] Tell Merigold you think he might be right...");
                                    switch (getIntResponse(3))
                                    {
                                        case 1:
                                            List<Dice> roulette = new List<Dice> { D120, D1 };
                                            return roulette;
                                        default:
                                            Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                            List<Dice> moreArtefactsToFaceCB = new List<Dice> { D2 };
                                            return moreArtefactsToFaceCB;
                                    }
                                case 1:
                                    return new List<Dice> { D60, D60, D1 };
                                case 2:
                                    return new List<Dice> { D60, D60, D1 };
                                case 3:
                                    return new List<Dice> { D60, D60, D1 };
                                case 4:
                                    return new List<Dice> { D40, D40, D40, D1 };
                                case 5:
                                    return new List<Dice> { D40, D40, D40, D1 };
                                case 6:
                                    return new List<Dice> { D40, D40, D40, D1 };
                                case 7:
                                    return new List<Dice> { D30, D30, D30, D30, D1 };
                                case 8:
                                    return new List<Dice> { D30, D30, D30, D30, D1 };
                                case 9:
                                    return new List<Dice> { D24, D24, D24, D24, D24, D1 };
                                case 10:
                                    return new List<Dice> { D20, D20, D20, D20, D20, D20, D1 };
                                case 11:
                                    return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D1 };
                                case 12:
                                    return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D1 };
                                default:
                                    return new List<Dice> { D1 };
                            }
                        case 3: // find your own way forward
                            Console.WriteLine("'Then,' Merigold concludes, 'I have helped you the best I can. " +
                                        "If you do not wish to pass through this portal, then the only exit is the door. " +
                                        "However you dealt with the minotaur before you got here... well, I can only wish " +
                                        "you the best of luck. Oh! And before I forget...' He waves his arms in the forms of some esoteric" +
                                        " incantation. 'There! I believe I had just enough magic to light the stairway down to the lowest levels. " +
                                        " It should no longer be quite so treacherous to traverse, but if you do change your mind, you know where to find " +
                                        "me...'\n\nYou begin to stride purposefully away your gaze set on the task at hand," +
                                        " when Merigold calls out to you one last time. \n\t'And remember this above all, " +
                                        "you have only until the clock strikes twelve! All the gods help you if you don't " +
                                        "stop him before then...'");
                            stairwayToLower.Name = "bright stairwell";
                            stairwayToLower.Description = "Merigold's incantaition has illuminated these stairs. At last you can see just how dangerous they really are with jutting uneven steps, crumbling masonry and little if any handholds. Descending these stairs may still prove dangerous even when lit...";
                            stairwayToLower.Dark = false;
                            return new List<Dice> { D1 };
                        default:
                            return new List<Dice> { D1 };
                    }
                }
                else
                {
                    switch (LoopParle(choice_answer, playerchoices1, description1, parlance, 8, 9))
                    {
                        case 1: //flee
                            Console.WriteLine("Will you accept the quest that has fallen upon you?");

                            if (getYesNoResponse())
                            {
                                Console.WriteLine("The relief that floods through Merigold is made all too evident.\n" +
                                    "'Then,' he asks, 'how do you wish to go about this? The portal in this hall will be the fastest way to wherever " +
                                    "you decide to go, but its reliability depends on how many artefacts you have. Alternatively, you can make" +
                                    " your own way down to the subterranean levels of this tower. It's a surer route, but if you take it you'll be in a race against the clock. Midnight approaches, " +
                                    "and you haven't the luxury of any delay...'" +
                                    "\n\nWill you use the portal in the magical manufactory?");
                                if (getYesNoResponse())
                                {
                                    Console.WriteLine("'Then, I must ask,' Merigold inquires nervously, 'just how many of my artefacts have you collected?'");
                                    numOfMGItems = 0;
                                    Console.ReadKey(true);
                                    Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");

                                    message = "";
                                    foreach (Item item in MGItems)
                                    {
                                        if (_player.Inventory.Contains(item))
                                        {
                                            numOfMGItems++;
                                            backpack.Items.Add(item);
                                            message += $"[{numOfMGItems}] {item.Name}\n";
                                        }
                                    }
                                    foreach (Item weapon in _player.WeaponInventory)
                                    {
                                        if (MGItems.Contains(weapon))
                                        {
                                            numOfMGItems++;
                                            backpack.Items.Add(weapon);
                                            message += $"[{numOfMGItems}] {weapon.Name}\n";
                                        }
                                    }

                                    Console.ReadKey(true);
                                    if (numOfMGItems != 0)
                                    {
                                        Console.WriteLine("How many are you willing to give to Merigold?");


                                        backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                    }
                                    numOfMGItems = numOfMGItems - backpack.Items.Count + _player.MGItemsDonated;
                                    _player.MGItemsDonated = numOfMGItems;

                                    switch (numOfMGItems)
                                    {
                                        case 0:
                                            Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                                " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                            Console.WriteLine("How will you respond?" +
                                                "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                                "\n[2] Tell Merigold you think he might be right...");
                                            switch (getIntResponse(2))
                                            {
                                                case 1:
                                                    List<Dice> roulette = new List<Dice> { D120, D1 };
                                                    return roulette;
                                                default:
                                                    Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                    List<Dice> moreArtefactsToFaceCB = new List<Dice> { D2 };
                                                    return moreArtefactsToFaceCB;
                                            }
                                        case 1:
                                            return new List<Dice> { D60, D60, D1 };
                                        case 2:
                                            return new List<Dice> { D60, D60, D1 };
                                        case 3:
                                            return new List<Dice> { D60, D60, D1 };
                                        case 4:
                                            return new List<Dice> { D40, D40, D40, D1 };
                                        case 5:
                                            return new List<Dice> { D40, D40, D40, D1 };
                                        case 6:
                                            return new List<Dice> { D40, D40, D40, D1 };
                                        case 7:
                                            return new List<Dice> { D30, D30, D30, D30, D1 };
                                        case 8:
                                            return new List<Dice> { D30, D30, D30, D30, D1 };
                                        case 9:
                                            return new List<Dice> { D24, D24, D24, D24, D24, D1 };
                                        case 10:
                                            return new List<Dice> { D20, D20, D20, D20, D20, D20, D1 };
                                        case 11:
                                            return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D1 };
                                        case 12:
                                            return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D1 };
                                        default:
                                            return new List<Dice> { D1 };
                                    }
                                }
                                else // no, i'll find my own way forward...
                                {
                                    Console.WriteLine("'Then,' Merigold concludes, 'I have helped you the best I can. " +
                                        "If you do not wish to pass through this portal, then the only exit is the door. " +
                                        "However you dealt with the minotaur before you got here... well, I can only wish " +
                                        "you the best of luck. Oh! And before I forget...' He waves his arms in the forms of some esoteric" +
                                        " incantation. 'There! I believe I had just enough magic to light the stairway down to the lowest levels. " +
                                        " It should no longer be quite so treacherous to traverse, but if you do change your mind, you know where to find " +
                                        "me...'\n\nYou begin to stride purposefully away your gaze set on the task at hand," +
                                        " when Merigold calls out to you one last time. \n\t'And remember this above all, " +
                                        "you have only until the clock strikes twelve! All the gods help you if you don't " +
                                        "stop him before then...'");
                                    stairwayToLower.Name = "bright stairwell";
                                    stairwayToLower.Description = "Merigold's incantaition has illuminated these stairs. At last you can see just how dangerous they really are with jutting uneven steps, crumbling masonry and little if any handholds. Descending these stairs may still prove dangerous even when lit...";
                                    stairwayToLower.Dark = false;
                                    return new List<Dice> { D1 };

                                }
                            }
                            else // no i wish to flee...
                            {
                                Console.WriteLine("Merigold cannot hide how crestfallen he is. \n\t'Then I suppose all that is left for me to do is use the portal to deliver you to wherever you wish to go... \n\t'How many artefacts do you have?'");
                                numOfMGItems = 0;
                                Console.ReadKey(true);
                                Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");

                                message = "";
                                foreach (Item item in MGItems)
                                {
                                    if (_player.Inventory.Contains(item))
                                    {
                                        numOfMGItems++;
                                        backpack.Items.Add(item);
                                        message += $"[{numOfMGItems}] {item.Name}\n";
                                    }
                                }
                                foreach (Item weapon in _player.WeaponInventory)
                                {
                                    if (MGItems.Contains(weapon))
                                    {
                                        numOfMGItems++;
                                        backpack.Items.Add(weapon);
                                        message += $"[{numOfMGItems}] {weapon.Name}\n";
                                    }
                                }

                                Console.ReadKey(true);
                                if (numOfMGItems != 0)
                                {
                                    Console.WriteLine("How many are you willing to give to Merigold?");


                                    backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                                }
                                numOfMGItems = numOfMGItems - backpack.Items.Count + _player.MGItemsDonated;
                                _player.MGItemsDonated = numOfMGItems;
                                switch (numOfMGItems)
                                {
                                    case 0:
                                        Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                                " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                        Console.WriteLine("How will you respond?" +
                                            "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                            "\n[2] Tell Merigold you think he might be right...");
                                        switch (getIntResponse(3))
                                        {
                                            case 1:
                                                return new List<Dice> { D120, D2 };
                                            default:
                                                Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                                return new List<Dice> { D3 };
                                        }
                                    case 1:
                                        return new List<Dice> { D60, D60, D2 };
                                    case 2:
                                        return new List<Dice> { D60, D60, D2 };
                                    case 3:
                                        return new List<Dice> { D60, D60, D2 };
                                    case 4:
                                        return new List<Dice> { D40, D40, D40, D2 };
                                    case 5:
                                        return new List<Dice> { D40, D40, D40, D2 };
                                    case 6:
                                        return new List<Dice> { D40, D40, D40, D2 };
                                    case 7:
                                        return new List<Dice> { D30, D30, D30, D30, D2 };
                                    case 8:
                                        return new List<Dice> { D30, D30, D30, D30, D2 };
                                    case 9:
                                        return new List<Dice> { D24, D24, D24, D24, D24, D2 };
                                    case 10:
                                        return new List<Dice> { D20, D20, D20, D20, D20, D20, D2 };
                                    case 11:
                                        return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D2 };
                                    case 12:
                                        return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D2 };
                                    default:
                                        return new List<Dice> { D2 };
                                }

                            }
                        default://face CB
                            numOfMGItems = 0;
                            Console.ReadKey(true);
                            Console.WriteLine("You search through your pack for the artefacts you happened to pick up during your escapades...");
                            Console.WriteLine("You find the following:");
                            message = "";
                            foreach (Item item in MGItems)
                            {
                                if (_player.Inventory.Contains(item))
                                {
                                    numOfMGItems++;
                                    backpack.Items.Add(item);
                                    message += $"[{numOfMGItems}] {item.Name}\n";
                                }
                            }
                            foreach (Item weapon in _player.WeaponInventory)
                            {
                                if (MGItems.Contains(weapon))
                                {
                                    numOfMGItems++;
                                    backpack.Items.Add(weapon);
                                    message += $"[{numOfMGItems}] {weapon.Name}\n";
                                }
                            }
                            Console.WriteLine(message);
                            if (message == "")
                            {
                                Console.WriteLine("You have none of Merigold's artefacts!");
                            }

                            Console.ReadKey(true);
                            if (numOfMGItems != 0)
                            {
                                Console.WriteLine("How many are you willing to give to Merigold?");


                                backpack.search(_player.CarryCapacity, _player.Inventory, _player.WeaponInventory);
                            }
                            numOfMGItems = numOfMGItems - backpack.Items.Count + _player.MGItemsDonated;
                            _player.MGItemsDonated = numOfMGItems;
                            switch (numOfMGItems)
                            {
                                case 0:
                                    Console.WriteLine("'Nothing?!' Merigold blurts. Were he drinking tea at that moment you suspect he'd have sprayed it over your face. 'Have you been listening to a word I've said? I can't control that portal without magic! You'd be playing roulette with your life!" +
                                        " Look,' he beseeches you, 'There may still be some time to collect some artefacts, there must be a few around here. I implore you not to act recklessly...'");
                                    Console.WriteLine("How will you respond?" +
                                        "\n[1] Tell Merigold you laugh in the face of danger, take your chances and dive headfirst with a boisterous 'TALLY-HO!'" +
                                        "\n[2] Tell Merigold you think he might be right...");
                                    switch (getIntResponse(3))
                                    {
                                        case 1:
                                            List<Dice> roulette = new List<Dice> { D120, D1 };
                                            return roulette;
                                        default:
                                            Console.WriteLine("'Good,' Merigold says, relieved, 'Then you better make haste! Go! And remember you only have until midnight!'");
                                            List<Dice> moreArtefactsToFaceCB = new List<Dice> { D2 };
                                            return moreArtefactsToFaceCB;
                                    }
                                case 1:
                                    return new List<Dice> { D60, D60, D1 };
                                case 2:
                                    return new List<Dice> { D60, D60, D1 };
                                case 3:
                                    return new List<Dice> { D60, D60, D1 };
                                case 4:
                                    return new List<Dice> { D40, D40, D40, D1 };
                                case 5:
                                    return new List<Dice> { D40, D40, D40, D1 };
                                case 6:
                                    return new List<Dice> { D40, D40, D40, D1 };
                                case 7:
                                    return new List<Dice> { D30, D30, D30, D30, D1 };
                                case 8:
                                    return new List<Dice> { D30, D30, D30, D30, D1 };
                                case 9:
                                    return new List<Dice> { D24, D24, D24, D24, D24, D1 };
                                case 10:
                                    return new List<Dice> { D20, D20, D20, D20, D20, D20, D1 };
                                case 11:
                                    return new List<Dice> { D15, D15, D15, D15, D15, D15, D15, D15, D1 };
                                case 12:
                                    return new List<Dice> { D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D10, D1 };
                                default:
                                    return new List<Dice> { D1 };
                            }
                    }

                }
            }
            else 
            {
                Dice D4 = new Dice(4);
                Console.WriteLine("'Well,' Merigold seems a little deflated, 'Whatever it is you're doing I hope you hurry. Time and tide wait for no man...'");
                Console.WriteLine("You leave the aged sorcerer to his musings and get back on track...");
                Console.ReadKey(true);
                return new List<Dice> { D4 };
            }
        }
    }
}

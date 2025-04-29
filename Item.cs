using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        public void StudyItem(Item item, Player player)
        {
            if (item.Name.Contains("newsletter"))
            {
                item.Attribute = true;
                item.SpecifyAttribute = "read";
            }
            else if (item.Name == "love letter")
            {
                item.Attribute = true;
                item.SpecifyAttribute = "read";
            }
            else if (item.Name == "worn journal")
            {
                item.Attribute= true;
                item.SpecifyAttribute = "read";
            }
            else if (Name == "note for janitor")
            {
                Attribute = true;
                SpecifyAttribute = "read";
            }
            
            Console.WriteLine(item.Description);
            if (Name == "crystal ball")
            {
                Console.WriteLine("You have the unnerving sense that something within wishes to draw your focus. Will you permit yourself to see what the orb wishes to show you?");
                Dialogue crystal = new Dialogue(item);
                if (Dialogue.getYesNoResponse(true))
                {
                    string description = "You bring all of your focus upon the swirling tendrils of mist, ever shifting within the crystal ball. Suddenly, its as though your gaze is consumed by the roiling fog inside." +
                        " Your sight plummets deeper within, bearing witness to smoky figures yet unknown, past deeds as yet undiscovered, and secrets that, for now, are so nebulous they seem to luminate your mind like vast and distant constellations of meaning.";
                    List<string> parlances = new List<string> 
                    { 
                        "You're bewildered to find yourself within what you can only hope to divine must be some other quarter of this tower, if " +
                        "the rosewood decor and elegant furnishings are anything to go by. Surrounding you are a colonnade of fluted marble pillars flanking the length of a hall" +
                        " and the long rosewood table therein. Seated about the table, are blurry figures. Unlike the features of the room that are crisp and clear in their detail, the figures are spectres of fog and mist, " +
                        "their ghostly faces moulded it seems out of the vapours of the crystal ball. You catch them all in a moment of crackling silence. Though you've only just 'arrived', you sense you could cut through the suspense " +
                        "with a blade, for there is scarcely a murmur amongst the company, their nervous gazes flitting about each of the others, and their attention never far away from fixing upon a lone, imposing silhouette at the head" +
                        " of the ornate table, his back towards them all.\nSomeone, you sense with a gnawing dread, that can be none other than the CurseBreaker...",

                        "Suddenly, one of those seated phantoms bangs their fist upon the table, chair scraping as they rise belligerently from it. " +
                        "\n\t'This is an outrage!' he blusters. He looks around, what you can discern of their visage beseeching the others, 'Are you all seriously going to take this from... from *him*?' " +
                        "\nThe aggressive phantom jabs a finger at the lone silhouette of the CurseBreaker. Their back is still faced to them all, and they scarcely stir as the other man launches into his tirade." +
                        "\n\t'Only three moons ago we were the unquestioned powers that held sway over these blasted lands. Now I find you all bowing and scraping to this conjuror, this warlock's apprentice, this... this... motherless cur!'" +
                        "\n  The other spectres around you shift uneasily, their nervous gaze flitting from the angry spirit to the imposing silhouette, held captive between their fear of being seen as weak and their even greater terror of speaking out. \n" +
                        "The raging spectre scoffs in disgust. 'You, the lords of estates, mayors of powerful cities, mercenary captains and guildmasters? You would all be blackmailed by him?' In response to their stony silence, the angry spirit turns to face the focus of his fury, the CurseBreaker who's not so much as shifted the whole time. \n\t'Well, I tell you this,' the angry spirit hisses as he abruptly stalks the length of the table. " +
                        " His fist curls tight about his sword. 'You may think you can compromise *them*, but I won't be made to live my days with some sorceror's sword of Damocles hanging over my head!'\n" +
                        "Each of his footfalls punctuates the crackling silence as a full stop punctuates a sentence.His thunderous tirade builds into a martial flourish as he unsheathes his sword. He charges forward. The silhouette does not stir. It does not face them at all. In a breathless moment the charging phantom is almost upon him. \nThen he's stopped...",

                        "You watch, transfixed, as the warrior's sword clatters to the ground. They splutter, their ghostly form of vapours and mist scrabbling at their throat as they drown in their own blood. \nAnother guest, having risen from his seat, withdraws the blade from the warrior's neck and plunges it into their gut.\n" +
                        "\t'I'm sorry,' the intercedent whispers with each stab of the knife, tears gritting their eyes, 'I'm sorry... I'm sorry...'\nThey stab them over and over again, until at last their body crumples to the ground, their phantasmal form released of life.\n\t'I can't be exposed. I can't run that risk. I'm sorry...'" +
                        " \n  The murky form of the knife-wielder stands there for a moment, seemingly distraught by their own actions. The silence is only broken once their knife clatters to the floor and they slump back into their chair." +
                        "\n  Then, finally, a new voice rolls over the assembled company. \n  It's a voice as smooth and even as moonlit lakes with treacherous depths. It's the even voice of a man so self-assured, he'd never expected any different outcome. It's as though he'd somehow seen, and known, the intent of each of them all along. \n\t'I believe that concludes our business, gentlemen,' the lone silhouette, the CurseBreaker, intones at last,  'Those leaders of the Vespasian Mercenary Company who are inclined to" +
                        " see reason and adapt to their new reality will now answer to me. Don't fret. You'll have your fill of loot and plunder in the months ahead...'",

                        "You watch as the guests, rather unsteadily, rise from their seats and take their leave. One of the last to do so is a figure who stirs within you some disquieting unease; an unwelcome, nauseating deja vu. The ghostly apparition is more tremulous than most as he heads for the door..." +
                        "\n\t'Not you, *mayor*' the CurseBreaker's voice is soft, but you can sense an acerbic edge to it - one that seems to mock the very title the man holds. 'I still have a request to make of you.'" +
                        "\n\t'What...' he gulps, 'what more do you require of me?' And suddenly you recognise the man's voice. Behind the veil of mist and vapours that compose the quivering man's face is the identity of your kidnapper, or at least, the first one. \nThe phantom before you is the Innkeeper in Myrovia, the one that had you abducted. " +
                        "\nYou sense a humorless smile slip upon the CurseBreaker's lips as he continues addressing the man, still not deigning to turn and face him. 'I find myself in need of resources. Breaking your curse shall prove no small feat without the proper means for exorcising it.' his tone drops an octave. 'I need subjects for my experiments.'" +
                        "\n  You can sense, in spite of the veil of vapours obscuring his features, the mayor's face go as white as a sheet. \nThe Cursebreaker seems to sense this too, because they huff before saying, 'No need to worry yourself, mayor. The townspeople of Myrovia are innocents caught up in your dealings. You know I'm only ruthless to the wicked and unjust." +
                        " I am *merciful* to those who do no wrong. As you know...' he states the last pointedly and with some hint of an unspoken threat." +
                        "\n\t'So if not the villagers, then who...'" +
                        "\n\t'You shall make a call for adventurers,' the CurseBreaker intones, 'a call for aid against your curse. When they arrive you shall give them lodgings for the night, along with a tonic that will knock them unconscious. These shall be the subjects I will use.' His voice lowers to a deadly soft tone, 'and I shall be their justice...'",

                        "Your avid gaze is transfixed as you feel the pieces of why and how you came to be in this predicament are suddenly on the cusp of tumbling into place. Your feeling of epiphany almost threatens to pull you from the crystal ball's vision, before you jolt your focus back on the innkeeper (this mayor of Myrovia) and the CurseBreaker.\n" +
                        "\t'I'll do as you require,' the frightened mayor tries his best to muster a defiant edge to his tone, but falters as the CurseBreaker's back stiffens. 'I- I mean... for the good of my people, for Myrovia, I'll do anything...'" +
                        "\n\t'Have you already forgotten, *mayor*,' the CurseBreaker's voice turns deadly soft once again, 'the powers that I already possess...'\n" +
                        " The CurseBreaker turns for the first time, and you catch your breath as you behold eyes that are anything but human.\n" +
                        "You clasp sight of smouldering eyes, with a frightful clarity that seems out of place in this world of vapours and mist and memory. They are as pitilessly black as the void between stars, devouring any and all light that touches them. And as they fix upon the Innkeeper, you can feel their scorching stare running through him, seeing beyond him and grasping so much more." +
                        "\n\t'I see your past mayor,' the CurseBreaker breathes contemptuously, 'I clasp sight of every foetid deed of yours as though they were conducted before me in this very hall. I know all of your secrets. I can read each of them as though they were fiery runes etched under your skin." +
                        "\n\t'Don't forget, there is another way I can break this curse of yours. An older way. The ancient way. And it's a rite that's a whole lot easier to perform...'" +
                        "\n\t'No...please...' the mayor staggers backwards, all at once terrified. 'anything but that... anything...'" +
                        "\n\t'Then,' the CurseBreaker eyes him appraisingly, 'it seems your choice is clear. You will deliver unto me these adventurers and mercenaries. I shall be their justice." +
                        " And, when all is done, you shall be free of your curse, for as long as you serve my vision of a new world...'" +
                        "\n  With that the CurseBreaker turns and begins to stride away. He dismisses the innkeeper with an imperious gesture of the hand. " +
                        "\n\t'Thank you, my master,' the mayor stammers. 'It's an honour to serve, master...'" +
                        "The CurseBreaker halts in his tracks. Slowly his head pivots and he fixes the quivering mayor with a sidelong, inscrutable look. \n" +
                        "\t'Yes...' he says with a silky voice as smooth as dark lakes with unseen currents. You feel a fever of gooseflesh creep up your arms. 'I suppose I am just a master. For now...'"
                    };
                    List<List<string>> playerchoice = new List<List<string>>
                    {
                        new List<string>
                        {
                            "Keep watching?",
                            "Pull away?"
                        },
                        new List<string>
                        {
                            "Keep watching?",
                            "Pull away?"
                        },
                        new List<string>
                        {
                            "Keep watching?",
                            "Pull away?"
                        },
                        new List<string>
                        {
                            "Keep watching?",
                            "Pull away?"
                        },
                        new List<string>
                        {
                            "Pull away?"
                        }
                    };
                    Dictionary<string, string> choice_visions = new Dictionary<string, string>
                    {
                        {"Keep watching?", "" },
                        {"Pull away?", "You tear yourself away from the vision, seemingly lurching out of a world of fog and vapours and long shadows cast by events out of place and time. You find yourself back in the secret chamber. It takes a moment of inertia and vertigo before you quite feel yourself again and you can piece together what all that you witnessed means..." }
                    };
                    this.Attribute = true;
                    this.SpecifyAttribute = "examined";
                    crystal.LinearParle(choice_visions, parlances, playerchoice, description);
                    
                }
                else
                {
                    Console.WriteLine("Feeling a touch of foreboding you tear your gaze from the orb and the long shadows cast by events out of place and time...");
                    Console.ReadKey(true);
                    return;
                }
            }
            if (Name == "Majesty of the Eldritch Fey")
            {
                Console.WriteLine("Would you like to delve deeper into what this book has to say?");
                Dialogue fey = new Dialogue(item);
                if (Dialogue.getYesNoResponse(true))
                {

                    string description = "Your curiosity piqued, you browse through the books pages...";
                    List<string> pages = new List<string>
                    {
                        "This chapter lays bare the traveller's previous exploits and encounters with magic:" +
                        "\n\n\tHark, for my name is Caspian. And that be my name upon a thousand strange tongues, " +
                        "and it be known within hundreds of strange lands. Many moons have passed since my first " +
                        "voyage of discovery upon the DawnTreader, breaking the horizon of distant shores and exploring" +
                        " realms far beyond our own. \n\tAnd yet, this latest adventure that i plan will cast my heels " +
                        "off into still farther and still stranger places. For I find the sum of my experience to be of " +
                        " discovering worldly kingdoms upon the material planes, and I have yet to embark upon a journey beyond " +
                        "that. It is known for millennia there lays a world astride ours, like a mirror's reflection it lurks beyond" +
                        " most mortals grasp. It is a world of fanciful tales and impossible dreams. It is the realm of the Fey." +
                        "\n\tIt is my ambition to unlock a door into this world, dear reader, and record my findings" +
                        " for posterity. For if I'm right and the stories are true, then the fair princes and lords of this most" +
                        " magical of kingdoms will be a place of wonders, where nought exists but revelry and gaiety, " +
                        "and chalices overflow with elixirs for every possible ailment. What blessed creatures, " +
                        "so heaped in good fortune and powers, could make this terrific dominion their abode. The fairytales " +
                        "say creatures of unsurpassed beauty and generosity, fair races who chase each day away with endless" +
                        " play and delightful conviviality. Are the legends true? My hand even now shakes but to think it. " +
                        "But before I can know, I must find a passage inside...",

                        "This page details numerous failed and aborted attempts to gain entrance to the Fey Realm until your eye rests on the writer's ultimate success:" +
                        "\n\n\t...after so long, I've found it! After searching and searching... cursed mirrors that give nought but a taunting glimpse of" +
                        " the Fey Realms, doors that beckon only children through them, enchanted forests bordering their world but within which mortals cannot help but roam in circles - " +
                        "Each an alley leading from one frustrating dead-end to the next. Now, finally, I have found a portal through which" +
                        " i might gain entrance to that enchanted world of which I have received thus far only tantalising glimpses. We are so very young within this world " +
                        "of ours, and yet we find ourselves skirting another: beyond reach it hangs like a forbidden fruit of possibilities transcending our imagination. I have been told so in endless dreams. Dreams sourced, I'm sure now, from the aforementioned mirror. The mirror that i left, but that still lurks within the depths of my mind. " +
                        "At first they were maddening, these visions; an ecstasy of impossible nightmares both wondrous and haunting. But now I understand that the lords and ladies of the ArchFey weren't tormenting me, they were just helping me this whole time. It's been their way, their ancient custom, of inviting me, " +
                        "(me!), to bear witness to their world and court them within the most majestic halls of their kingdom.\n Yes! They chose me... for I am Caspian... this is Caspian's destiny...",

                        "The next few pages are a journal detailing this explorer's foray through the Faerie Realms.\nIt begins as a sober and organised list of dated entries, before tumbling into something more akin to a collage of incoherent thoughts, then a flurry of fever-filled ramblings:" +
                        "\n\n\tAfter seeing such wonders, after visiting upon my body such titillations and sensations as cannot be dreamt in our mundane world, how can I bear the thought of returning without despair. For I know now that our ArchFey friends are so superior to us in every way. " +
                        "Unlike their cohabitants, the trivial fairies, silly pixies and their sillier warnings, the very words of the eldritch ArchFey weave dreams and visions through my mind like a forest weaves vines through a crumbling wall. Their fragrance sets my heart racing through endless possibilities. Their movements, so seductively fluid and enticing and precise, make me such an oaf by comparison. " +
                        "Even now I lament for my words do not do their beauty and grace justice. I often question myself: am I truly worthy to be amongst so perfect sleepless creatures, to tread upon their twilight world? At first I thought theirs an innocent realm untouched by the sins that so beleaguer us mortals - yet, with my closed mind (my so inadequate, provincial mind) I'd dared not imagine " +
                        "the truth: that here there is simply no sin at all. No act that can't be perfected by seeking its apotheosis, no vice that can't be made virtuous by transfiguring it beyond the apex of delight. \nTomorrow I shall try once again to be more like my friends. I mustn't shame them with my presence. My aspiration to make myself as beautiful as they are has thus far made progress, but success still eludes me. Still the ArchFey titter as I pass. It's " +
                        "not their fault, of course. I'm only glad my endless shortcomings brings such innocent creatures something so delightful as their divine laughter, instead of the disgust I deserve. For I have yet to become as elegant as they. I shall return tonight to the lakeside whereupon I shall study my reflection. \nIf I can just starve myself a little more, perhaps I too will be almost as slender and fine-featured as they...",

                        "The last page's handwriting is fluid, cursive, elegant, a masterpiece in and of itself - and definitely *not* the author's;" +
                        "\n\nThe lake's a mirror we shatter, " +
                        "\nWhose splinters are all scattered," +
                        "\nPiece by piece we make this one's eyes sparkle," +
                        "\nWith the ravenous hunger of a jackal," +
                        "\nFor we fed him nought but the melody of our lyre," +
                        "\nHe feasted upon the fumes of our enchanted fire," +
                        "\nHe partook of those acts from which he'd never tire," +
                        "\nThe nightmares born of his heart's desire..."


                    };
                    List<List<string>> playerchoice = new List<List<string>>
                    {
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },

                        new List<string>
                        {
                            "Turn back to the first page?",
                            "Close the book?"
                        }
                    };
                    Dictionary<string, string> action = new Dictionary<string, string>
                    {
                        {"Turn back to the first page?", "You scour the book for the first entry you came across..."},
                        { "Turn the page?", "You leaf through a page or two more, before your eyes rest on the next intriguing excerpt." },
                        {"Close the book?", "You decide to stop reading the literature for now." }
                    };
                    int x = 0;
                    while (x == 0)
                    {
                        x = fey.LinearParle(action, pages, playerchoice, description);
                    }
                    item.Attribute = true;
                    item.SpecifyAttribute = "read";
                }
                else
                {
                    Console.WriteLine("You decide now isn't the time. You close the book.");
                    Console.ReadKey(true);
                    return;
                }
            }
            if (Name == "The Rogue's Pocketbook")
            {
                Console.WriteLine("Would you like to delve deeper into what this book has to say?");
                Dialogue thievin = new Dialogue(item);
                if (Dialogue.getYesNoResponse(true))
                {

                    string description = "Your curiosity piqued, you peruse the books rather tatty pages...";
                    List<string> pages = new List<string>
                    {
                        "This chapter lays bare the underlying rationale for this book:" +
                        "\n\n\tIf you want to become a great thief for some vainglorious purpose, reader, then " +
                        "you've entered the wrong profession.\nIf you have ambitions of being portrayed in some gallery of the " +
                        "notorious and the machiavellian, then you can place back this book now.\n\tLet it instead be found for those" +
                        "who revel in obscurity, who make the shadows their business, and subterfuge their mistress. Herein lies" +
                        " those secrets worthy only of those who follow Bhaal or Shar, whether by devoted spirit or inadvertently through deed...",

                        "This page is a how-to-guide for lockpicking, home invasion and escape artistry:" +
                        "\n\n\tNo door makes a vault impregnable. No lock can withstand the right tools. For most mundane locks" +
                        " this is all too evident. All that's needed to crack open a door is more often than not nothing more than a bobby pin to jimmy the tumblers into position and a screwdriver" +
                        " or any similar edged implement, a narrow thin blade for example, that can lever the inside mechanics within." +
                        " Combine these two items, use one along with the other, and you'll have your very own lockpicking set" +
                        " that'll work nine times out of ten...",

                        "The following excerpt examines first principles upon disguises, camouflage and espionage:" +
                        "\n\n\t... three quarters of any disguise lies in projecting the behaviour and the gestures that'll " +
                        "make you blend seamlessly with the crowd you wish to integrate into. Without confidence, if nervousness gnaws your guts, and your eyes glance whiplash quick " +
                        "at those who might already suspect you, then you're going to get caught no matter how ingenious your disguise or brilliant your plan. " +
                        "\n\tAs for the other quarter, find the right garb that won't stand out, wear the symbols and trinkets that mark your target for infiltration as one of their own," +
                        " and if you can't conceal your face, then use something to obscure it or draw attention away from memorable features. " +
                        "\n\tAs for camouflage, remember the five 'S': Shift, Shape, Shadow, Silhouette and Shine. Where 'shine' is concerned," +
                        " blacken anything that might be seen, use charcoal to smear your face and make it less visible at night...",

                        "This page goes through a detailed step by step plan on how to pick-pockets;" +
                        "\n\n1. Find your target and study their routines. Who do they know? Who do they meet? Who is likely to intercede on their behalf if things go wrong?" +
                        "\n2. Find the best spot to cross their path and perform the deed. You need a place that's public, crowded and away from any of their friends." +
                        "\n3. You need a trustworthy wingman. One you perform the act, they'll take your stash off of you, so if the militia are alerted they'll find nothing on you." +
                        "\n4. You'll need to act swiftly. Bump into them. distract them. Do it right and they won't notice you snatch what you want from their pockets, then make your exit. Plan beforehand which street corners you'll turn, which alleys you'll dart through to lose them..."

                        
                    };
                    List<List<string>> playerchoice = new List<List<string>>
                    {
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        
                        new List<string>
                        {
                            "Turn back to the first page?",
                            "Close the book?"
                        }
                    };
                    Dictionary<string, string> action = new Dictionary<string, string>
                    {
                        {"Turn back to the first page?", "You scour the book for the first entry you came across..."},
                        { "Turn the page?", "You leaf through a page or two more, before your eyes rest on the next intriguing excerpt." },
                        {"Close the book?", "You decide to stop reading the literature for now." }
                    };
                    int x = 0;
                    while (x == 0)
                    {
                        x = thievin.LinearParle(action, pages, playerchoice, description);
                    }
                    item.Attribute = true;
                    item.SpecifyAttribute = "read";
                }
                else
                {
                    Console.WriteLine("You decide now isn't the time. You close the book.");
                    Console.ReadKey(true);
                    return;
                }
            }
            if (item.Name == "book on cursed weapons")
            {
                Console.WriteLine("Would you like to delve deeper into what this book has to say?");
                Dialogue cursed_weapons = new Dialogue(item);
                if (Dialogue.getYesNoResponse(true))
                {
                    
                    string description = "With more than a tincture of curiosity you open the book and set about perusing it's many pages, until one in particular catches your eye...";
                    List<string> pages = new List<string> 
                    { 
                        "The page below details a general background surrounding curses and hexes:" +
                        "\n\n\t'Throughout the ages it has been a common misconception that curses are merely a synonym for hexes; that the two may be" +
                        "used interchangeably without any loss of meaning. Such is the ignorance of those folk who spread such" +
                        "facile falsehoods. 'Tis true that their symptoms often appear the same, in the nebulous sense that they are often cryptic in their resolution and the misfortunes and" +
                        "maladies that arise are of a wholly capricious nature. " +
                        "However, the notion of their identity with one another is not only unfounded but a dangerous presumption. " +
                        "\n\tWhere hexes are man-made, or more often than not witch-made, curses are born of unspoken secrets and injustices festered." +
                        "Where hexes are transient by nature and of limited scope in power and malice, curses by contrast seem boundless and find an infinite reservoir " +
                        "for longevity in some chaos underlying the fabric of our world. Hexes can be easily countered, dispelled or at least ameliorated." +
                        "\n\tCurses, by contrast, can linger for untold aeons, manifest in guises both terrific and terrible, and will confound even the greatest, mage, wizard, witch or sorceror." +
                        "\nThere has only ever been one way to lift a curse, and no mortal man has as of yet found a second...'",
                        
                        "This page seems to examine the weapons curses have been known to latch themselves to:" +
                        "\n\n\t'Weapons about which a curse has been afflicted is a rare occurrence. More often than not" +
                        " curses do not confine themselves to any material object." +
                        "\nThis is because of the nature of curses. Curses arise from secret, terrible deeds about which no one but the perpetrator is any the wiser. As such, when a curse finds itself bound to a weapon, " +
                        "it is often because that is the weapon that has carried out such unspoken atrocities. \n This is unusual. It's often known for curses to not confine themselves to one person" +
                        " but to afflict an entire town or kingdom. Many times it is not even restricted to a single place.\nIt is important to understand, that cursed weapons are not like enchanted weapons, whose spell will last for a relatively short while, or at most, only as" +
                        " long as the caster's life. Cursed weapons are virtually perennial entities that after years of dedicated study one might almost be tempted to say have a life of their own." +
                        " Not in the sense that they've thoughts or a mind, exactly, but their presence in one object almost seems to garner it the veneer of wicked intent. Harm has befallen me, dear reader, on more than one occasion" +
                        " due to lack of vigilance around these weapons." +
                        "\nBut before you surmise that my studies have been in vain, let me assure you otherwise! I have discovered that cursed weapons" +
                        " appear to have an innate ability to destroy or 'devour' magic - even, some indications lead me to believe, souls...'",
                        
                        "The passage below details a cursed quarter-staff:" +
                        "\n\n\t'...The Staff of Morphic Caprice has long been annihilated, but has been well documented" +
                        " by many a scholar. Summoned through an unknown ritual, it harnessed great power for those who had" +
                        " wielded it, but at a terrible price. For the staff sapped the user of their soul and sentience, and piece by piece transferred it" +
                        " to the wielder's most beloved artefact or heirloom - and not necessarily in the correct configuration. " +
                        "\n\tWhile the staff can be researched no more, destroyed by paladins of old, there are in my possession two such artefacts that were the result of this curse. " +
                        "Two mosaics, formally brothers, who had fought over the staff with increasing intensity until one slay the other. Their souls lie bound to the mosaics that are their artisan family's most prized legacy. My studies have further uncovered" +
                        " that one of these is cursed with knowing all things rational, but can not relay this knowledge, unless it is asked questions of a specific form: those that cannot be answered with a 'yes' or a 'no.' " +
                        "\n\tAs for the other mosaic, it is the antithesis of its brother. It also speaks in riddles but where the first answers questions to elucidate in its own convoluted way, the other grants answers to questions never asked save in a persons deepest desires. " +
                        "\nWhere one is decipherable, the other confers madness. \nWhere one answers the questions upon the interlocutor's mind. The other answers questions posed by those thoughts so hidden, even the interlocutor isn't aware of them." +
                        "\n\tMy apprentice has had better luck with the latter, so he says. As for myself, I favour the one that gives - if not straight answers - at least decipherable ones...'",
                        
                        "This page delves into one weapon in particular of high renown;" +
                        "\n\n\t'...The vanquisher, or as it has been known to some, the Sword of Sealed Souls, is such a weapon in my possession." +
                        " It's original owner was the victim of a curse of course - transformed into some ghast or perhaps a banshee (the sources differ) after she sewed her own lips shut that she might" +
                        " not reveal some horror that'd blighted her convent. The sword fell into my possession, naturally, through more mundane means: I bought it. " +
                        "The chap frankly had been all too happy to part with it. Said it was keeping him up all night with haunting nightmares and ghoulish dreams. Imagine my glee! " +
                        "\nI began studying it forthwith and found unmistakeable  signs of anti-magical energy fields and according to the astrological equations of Elminster's fourth law...'" +
                        "\n[The passage then trails into esoteric formulas and a pseudo-mathematical lexicon that eludes your limited knowledge of the arcane]",
                        
                        "The final page you turn to deliberates upon the forces that bring about such curses and from where they are ultimately sourced;" +
                        "\n\n\t'From the hearts of the cruel?\n\t\tFrom planes beyond our own?\n\t\t\tFrom some shadow of our own world?" +
                        "\nFrom the same place our reflections go when we aren't looking? Or mayhaps the place where there resides the sound of a cat's paws, a fish's breath, or the roots of a mountain?" +
                        "\nAlas, ultimately I know not, nor can I guess. There seems an otherworldly aspect to curses, but they escape the ken of magical artificers and mages alike. They elude control. They arise from some chaos and from somewhere no sane mind could venture." +
                        "\nI am sorry to say, that after all my years of study, I must finally include myself in the storied list of magicians who have failed to understand our chosen topic's most elusive and fundamental question..." +
                        "'"
                    };
                    List<List<string>> playerchoice = new List<List<string>>
                    {
                        new List<string>
                        { 
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        { 
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        { 
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        }, 
                        new List<string>
                        {
                            "Turn back to the first page?",
                            "Close the book?"
                        }
                    };
                    Dictionary<string, string> action = new Dictionary<string, string>
                    {
                        {"Turn back to the first page?", "You scour the book for the first entry you came across..."},
                        { "Turn the page?", "You leaf through a page or two more, before your eyes rest on the next intriguing excerpt." },
                        {"Close the book?", "You decide to stop reading the literature for now." }
                    };
                    int x = 0;
                    while(x == 0)
                    {
                        x = cursed_weapons.LinearParle(action, pages, playerchoice, description);
                    }
                    item.Attribute = true;
                    item.SpecifyAttribute = "read";
                }
                else
                {
                    Console.WriteLine("You decide now isn't the time. You close the book.");
                    Console.ReadKey(true);
                    return;
                }
            }
            else if (item.Name == "book on the history of curses")
            {
                Console.WriteLine("Would you like to delve deeper into what this book has to say?");
                Dialogue history_curses = new Dialogue(item);
                if (Dialogue.getYesNoResponse(true))
                {
                    string description = "With more than a tincture of curiosity you open the book and set about perusing it's many pages, until one in particular catches your eye...";
                    List<string> pages = new List<string>
                    {
                        "The first page you come across reads like a fairy tale:" +
                        "\n\n\t'Once upon a time," +
                        "\nthere was a midwife in a provincial town. She always wanted children of her own, alas it was not to be, " +
                        "for husbands were sought and none were found who satisfied the high expectations of her family. And every day she'd deliver children into the world with a heart bursting with love. So fit to burst" +
                        " was her heart that it tore at the seams. Her desire to bear her own children made her ache, and all could see and knew her pain. For the" +
                        " villagers sent her flowers and gifts as thanks and to ease her suffering. And they all thought, 'well that was that'. \nBut on she continued, delivering babies into the world, holding her heart's desire for one precious moment, before" +
                        " giving the child over to their mother with a bigger smile than anyone else there, because she had to keep the other feelings hidden somewhere no one would ever see. " +
                        "\n\tOne day terrible tragedies began occurring, as babies one by one were stolen from their cribs. And the midwife shared her love with the mothers who'd lost their children. For finally they knew her pain" +
                        " \nFor finally she was not alone. \nUntil, one day the villagers gave her new gifts. They bestowed upon her flowers whose bloom bore release from that pain forever. And privately, behind closed doors," +
                        " they thought, 'well that was that,' and never spoke of her again. " +
                        "\n\tNow there exists a secret door. It's the door to the abandoned home where children never laughed. It's the door to the derelict cottage where children were never heard to play. And when it wants to be found it beckons children inside. They are seen to " +
                        "pass through it, and none who do ever make it to the other side...'",

                        "This page details a creepy limerick:" +
                        "\n\n'Once there were children who cried a lot," +
                        "\nThey told their parents to go and rot," +
                        "\nThen adventurers rode in, " +
                        "\nThey made quite a din," +
                        "\nFor there'd been something in the woods," +
                        "\n\t and it'd taught them all how to plot...'",

                        "This report sends a jolt through you, as the name of that accursed village that'd abducted you leaps out of the page at you;" +
                        "\n\n\t'It's been many moons since Myrovia was first afflicted with its terrible curse. None know why it'd come about" +
                        ", for the residents of this humble sanctuary within the mountains were by most accounts perfectly contented and you could find no one more" +
                        " civil. Indeed the roots of this curse are as difficult to tell as the time it all began. " +
                        "For though it might not seem like it, Myrovia is no stranger to tragedy." +
                        "\n\tThe curse may have afflicted the mayor of Myrovia first, a man of noble heritage who'd fallen on hard times until he'd met his wife. " +
                        "She had been, by all accounts, a spirited woman with beauty beyond compare. And through her influence she" +
                        " had helped the man regain some of his riches, setting up Myrovia's only tavern. It was upon the birth of their third daughter" +
                        " that she sadly passed away." +
                        " Reports at the time state the mayor was inconsolable for years after this loss, and though eventually he'd begun searching" +
                        " for a new wife, their affections only reminded him of how they fell short of his first beloved soulmate. However, its disputed by no one" +
                        " that in spite of his loss, the mayor more than rose up to the duties of fatherhood. He was, by all accounts, dedicated to his three daughters, and his affection and devotion dwarfed that of any other father in Myrovia." +
                        "\n\t One tragedy, of course, would merely be that; a tragedy. But it's the chain of events that " +
                        "follows that truly make some wonder whether the curse had already taken hold. For after the mayor had long" +
                        " abandoned any hope of finding a new wife, the three daughters, one by one," +
                        " committed suicide in shocking ways. " +
                        "\n\tThe first had been the eldest who, before flowering into womanhood, had been vivacious and active. Many villagers had seen" +
                        " her help with the harvest, and when it'd been time to celebrate she'd delighted the crowds with her dancing. However, the villagers witnessed some sickness befall her" +
                        " - one with no physical symptoms. Days before her death, no one witnessed her smile and she spoke scarcely a word to any of her friends." +
                        "\n\tThe second daughter, before she'd come of age, had elated the tavern's convivial evenings with her singing. However, she too seemed afflicted by the same malady as her sister. " +
                        "One can only surmise that her grief was such that she could no longer bear to live, for she hanged herself by the tavern's very rafters." +
                        "\n\tThe tavern's business had begun to dwindle after such a calamity, and by all accounts the mayor was beside himself" +
                        " with grief. It was only his youngest daughter, who had grown to resemble her beautiful mother, who'd given him any comfort in these hard times. Accounts" +
                        " at this point differ in some details as to the exact chain of events that followed. Some say there was an altercation after the mayor sought to protect" +
                        " his daughter from an unworthy suitor. Others emphasise the grief she felt for her sisters along with an inexplicable fear that'd turned her ashen-faced in her last days. In either" +
                        " case, the symptoms were the same. The strange malady struck, and shortly thereafter, she'd flung herself from the tallest spire in Myrovia." +
                        "\n\tShortly afterwards, four ungodly crepuscular creatures stalk Myrovia whenever the moon waxes its fullest. Some say this is when the curse began." +
                        " Others, that the curse had begun long before, only now it splays its tendrils across all of Myrovia, morphing into some new evil. No two theories are the same. And no solution is yet to be found." +
                        "\n\tThere is only one more report of note; the autopsies that were conducted on the bodies, but little sense can be made of it. \nFor it states that though the girls were never married, and were denied contact with suitors, " +
                        "none were virgins...'",
                        
                        "The final page makes you almost jump out of your own skin! There, before your eyes, words continually fill the page as though some invisible scribe were penning them;" +
                        "\n\n\t'... and so the old lady made her pact in the woods with the Merchant of Mirrors, that she might be youthful once more and suitors would..." +
                        "\n[and so on]'"
                    };
                    List<List<string>> playerchoice = new List<List<string>>
                    {
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn back to the first page?",
                            "Close the book?"
                        }
                    };
                    Dictionary<string, string> action = new Dictionary<string, string>
                    {
                        {"Turn back to the first page?", "You scour the book for the first entry you came across..." },
                        { "Turn the page?", "You leaf through a page or two more, before your eyes rest on the next intriguing excerpt." },
                        {"Close the book?", "You decide to stop reading the literature for now." }
                    };
                    int x = 0;
                    while (x == 0)
                    {
                        x = history_curses.LinearParle(action, pages, playerchoice, description, player);
                    }
                }
                else
                {
                    Console.WriteLine("You decide now isn't the time. You close the book.");
                    Console.ReadKey(true);
                    return;
                }
            }
            else if (item.Name == "book on Fey realms and magicks")
            {
                Console.WriteLine("Would you like to delve deeper into what this book has to say?");
                Dialogue fey_realms = new Dialogue(item);
                if (Dialogue.getYesNoResponse(true))
                {
                    string description = "With more than a tincture of curiosity you open the book and set about perusing it's many pages, until one in particular catches your eye...";
                    List<string> pages = new List<string>
                    {
                        "The magnificent prose of this book holds you captivated as you begin scanning through the first page. " +
                        "\nYou become so focused you don't notice yourself drawing closer and closer to the pages as your eyes dart across the elegant script.",

                        "You become addicted to the questions raised by this book and especially those that are yet to be answered. You're" +
                        " so hooked by what's to follow in the pages ahead that you lose all sense of time. Your heart beats faster. Your hands grow sweaty. This is the most sensational read" +
                        " you've ever come across...",

                        "Suddenly, you decide you don't ever want to pull away from this book. The power it promises, the worlds it opens... You flit hungrily through the pages, " +
                        "absorbing the arcane symbols and otherworldly etchings as though in your fevered state they meant something to you..." +
                        "\nYou feel yourself becoming lost...",

                        "Finally you rifle through the pages to the book's conclusion. And suddenly you blink.\n" +
                        "The spellbinding book's allure... it's broken. The giddy feelings of intoxication that'd bubbled inside you evaporate as you stare" +
                        " down at a torn out page.\nFrowning you peruse the index, trying to discover what that page had contained, " +
                        "before learning that it was the chapter on 'Summoning'..."
                    };
                    List<List<string>> playerchoice = new List<List<string>>
                    {
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn the page?",
                            "Close the book?"
                        },
                        new List<string>
                        {
                            "Turn back to the first page?",
                            "Close the book?"
                        }
                    };
                    Dictionary<string, string> action = new Dictionary<string, string>
                    {
                        {"Turn back to the first page?", "You scour the book for the first entry you came across..." },
                        { "Turn the page?", "You leaf through a page or two more, before your eyes rest on the next intriguing excerpt." },
                        {"Close the book?", "You decide to stop reading the literature for now." }
                    };
                    int x = 0;
                    while (x == 0)
                    {
                        x = fey_realms.LinearParle(action, pages, playerchoice, description);
                    }
                }
                else
                {
                    Console.WriteLine("You decide now isn't the time. You close the book.");
                    Console.ReadKey(true);
                    return;
                }
            }
            
            return;
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
        public void PickUpItem( Player player, int carryCapacity, List<Item> inventory, List<Weapon> weaponInventory, int range, int value = 0, Item item = null, Weapon weapon = null, List<Item> featureItems = null, List<Item> roomItems = null, Weapon yourRustyChains = null, List<Item> stickyItems = null, Monster monster = null, List<Room> threadPath = null, Room room = null)
        {
            try
            {
                List<Item> weaponItemList = new List<Item> { this };
                List<Weapon> weaponList = weaponItemList.Cast<Weapon>().ToList();
                weapon = weaponList[0];
                item = null;
            }
            catch { item = this; weapon = null; }
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
            if (Name == "ball of red thread" && SpecifyAttribute == "spooled")
            {
                Console.WriteLine("[4] Begin unspooling the red thread and leave it trailing behind you from room to room?");
            }
            if (Name == "music box" && range == 5)
            {
                if (Attribute)
                {
                    Console.WriteLine("[4] Close the music box?");
                }
                else
                {
                    Console.WriteLine($"[4] Open the music box and leave it in the {room.Name} as a distraction?");
                }
            }
            do
            {
                string answer = Console.ReadLine();
                if (answer.Trim() == "")
                {
                    if (Name == "ball of red thread" && SpecifyAttribute == "spooled")
                    {
                        Console.WriteLine("Please enter '1', '2', '3' or '4'");
                        if (range == 3 || range == 4 || range == 6)
                        {
                            Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?\n[4] Take it and begin unspooling it as you proceed?");
                        }
                        else if (range == 5)
                        {
                            Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?\n[4]Begin unspooling it as you travel from room to room?");
                        }
                        continue;
                    }
                    else if (Name == "music box" && Attribute && range == 5)
                    {
                        Console.WriteLine("Please enter '1', '2', '3' or '4'");
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?\n[4] Close the music box?");
                        continue;
                    }
                    else if (Name == "music box" && range == 5)
                    {
                        Console.WriteLine("Please enter '1', '2', '3' or '4'");
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?\n[4] Open the music box and leave it in the {room.Name} as a distraction?");
                        continue;
                    }
                    else
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
                    
                }
                /// this was incase the user typed something like 'option 2' or something
                int size = answer.Trim().Length;
                char answerChar = answer.Trim()[size - 1];
                answer = answerChar.ToString();
                try
                {
                    int answerNum = int.Parse(answer);
                    if ((answerNum < 1 || answerNum > 3)&& (Name != "ball of red thread" || SpecifyAttribute != "spooled") && (range != 5 || Name != "music box"))
                    {
                        if (range != 5 || Name != "music box")
                        {
                            Console.WriteLine("Please choose option 1, 2, or 3.");
                            continue;
                        }

                        else
                        {
                            Console.WriteLine("Please choose option 1, 2, 3, or 4.");
                            continue;
                        }
                    }
                    else if (answerNum < 1 || answerNum > 4)
                    {
                        Console.WriteLine("Please choose option 1, 2, 3, or 4.");
                        continue;
                    }
                    else if (answerNum == 1)//study the item
                    {
                        if (weapon == null)//if item is not a weapon
                        {
                            StudyItem(item, player);
                            
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
                            StudyItem(weapon, player);
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
                                if (weaponInventory.Count > 1)
                                {
                                    Console.WriteLine("You can only carry two weapons at a time!\n  Would you like to exchange this weapon for another?");
                                    Dialogue exchangeWeapon = new Dialogue(weapon);
                                    if (Dialogue.getYesNoResponse(true))
                                    {
                                        Console.WriteLine($"Which weapon do you wish to exchange the {weapon.Name} for?");
                                        int weaponNumber = 1;
                                        foreach (Weapon w in weaponInventory)
                                        {
                                            Console.WriteLine($"[{weaponNumber}] {w.Name}");
                                            weaponNumber++;
                                        }
                                        if (exchangeWeapon.getIntResponse(weaponNumber) == 2)
                                        {
                                            weaponInventory.Add(weapon);
                                            monster.Items.Add(weaponInventory[1]);
                                            weaponInventory.Remove(weaponInventory[1]);
                                            monster.Items.Remove(weapon);
                                        }
                                        else
                                        {
                                            weaponInventory.Add(weapon);
                                            monster.Items.Add(weaponInventory[0]);
                                            weaponInventory.Remove(weaponInventory[0]);
                                            monster.Items.Remove(weapon);
                                        }
                                        Console.WriteLine($"{Name} has been stashed in inventory.");
                                    }
                                    else { continue; }
                                }
                                else
                                {
                                    StashWeapon(weapon, weaponInventory);
                                    monster.Items.Remove(weapon);
                                    Console.WriteLine($"{Name} has been stashed in inventory.");
                                }
                                return;
                            }
                            else
                            {
                                if (inventory.Count < carryCapacity)
                                {
                                    StashItem(item, inventory);
                                    monster.Items.Remove(item);
                                    Console.WriteLine($"{Name} has been stashed in inventory.");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("You're already struggling to heft all the gear you have! You'll have to discard some items before you can take this one with you...");
                                    return;
                                }
                            }
                        }
                        else if (range == 4)//searching room
                        {
                            if (item == null)
                            {
                                if (weapon.Name == "rusty chains")
                                {
                                    if (weaponInventory.Count < 2)
                                    {
                                        StashWeapon(yourRustyChains, weaponInventory);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You can think of no earthly reason why you'd exchange any of your deadlier weapons for a rusty chain. Who needs it?");
                                    }
                                }
                                else
                                {
                                    if (weaponInventory.Count > 1)
                                    {
                                        Console.WriteLine("You can only carry two weapons at a time!\n  Would you like to exchange this weapon for another?");
                                        Dialogue exchangeWeapon = new Dialogue(weapon);
                                        if (Dialogue.getYesNoResponse(true))
                                        {
                                            Console.WriteLine($"Which weapon do you wish to exchange the {weapon.Name} for?");
                                            int weaponNumber = 1;
                                            foreach (Weapon w in weaponInventory)
                                            {
                                                Console.WriteLine($"[{weaponNumber}] {w.Name}");
                                                weaponNumber++;
                                            }
                                            if (exchangeWeapon.getIntResponse(weaponNumber) == 2)
                                            {
                                                weaponInventory.Add(weapon);
                                                roomItems.Add(weaponInventory[1]);
                                                weaponInventory.Remove(weaponInventory[1]);
                                            }
                                            else
                                            {
                                                weaponInventory.Add(weapon);
                                                roomItems.Add(weaponInventory[0]);
                                                weaponInventory.Remove(weaponInventory[0]);
                                            }
                                            
                                        }
                                        else { continue; }
                                    }
                                    else
                                    {
                                        StashWeapon(weapon, weaponInventory);
                                        
                                    }
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
                                if (inventory.Count < carryCapacity)
                                {
                                    if (item.Name != "ball of red thread" && item.SpecifyAttribute != "unspooled") 
                                    { 
                                        StashItem(item, inventory); 
                                    }
                                    else if (item.Name == "ball of red thread" && threadPath.Count < 3)
                                    {
                                        item.Attribute = true;
                                        item.SpecifyAttribute = "spooled";
                                        threadPath.Clear();
                                        StashItem(item, inventory);
                                        Console.WriteLine("You quickly spin the spool, gathering up all the thread. It's lucky it's not spread out too far or it would've been too tangled to respool...");
                                        Console.ReadKey(true);
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("You don't have time to" +
                                            " pick up that tangled mess!");
                                        Console.ReadKey(true);
                                        return;
                                    }
                                    if (item.Name != "bowl fragments" && item.Name != "rusty chains" && item.Name != "garment" && !stickyItems.Contains(item))
                                    {
                                        roomItems.Remove(item);
                                    }
                                    Console.WriteLine($"{Name} has been stashed in inventory.");

                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("You're already buckling under the weight of your backpack! Discard some items before picking up anything more...");
                                    return;
                                }
                            }
                        }
                        else if (range == 6)// searching feature
                        {
                            if (item == null)
                            {
                                if (weaponInventory.Count > 1)
                                {
                                    Console.WriteLine("You can only carry two weapons at a time!\n  Would you like to exchange this weapon for another?");
                                    Dialogue exchangeWeapon = new Dialogue(weapon);
                                    if (Dialogue.getYesNoResponse(true))
                                    {
                                        Console.WriteLine($"Which weapon do you wish to exchange the {weapon.Name} for?");
                                        int weaponNumber = 1;
                                        foreach (Weapon w in weaponInventory)
                                        {
                                            Console.WriteLine($"[{weaponNumber}] {w.Name}");
                                            weaponNumber++;
                                        }
                                        if (exchangeWeapon.getIntResponse(weaponNumber) == 2)
                                        {
                                            weaponInventory.Add(weapon);
                                            featureItems.Add(weaponInventory[1]);
                                            weaponInventory.Remove(weaponInventory[1]);
                                            featureItems.Remove(weapon);
                                        }
                                        else
                                        {
                                            weaponInventory.Add(weapon);
                                            featureItems.Add(weaponInventory[0]);
                                            weaponInventory.Remove(weaponInventory[0]);
                                            featureItems.Remove(weapon);
                                        }

                                    }
                                    else { continue; }
                                }
                                else
                                {
                                    StashWeapon(weapon, weaponInventory);
                                    featureItems.Remove(weapon);
                                }
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                            else
                            {
                                if (inventory.Count < carryCapacity)
                                {
                                    StashItem(item, inventory);
                                    featureItems.Remove(item);
                                    Console.WriteLine($"{Name} has been stashed in inventory.");

                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("You cannot carry another item or you'll collapse under the weight! Discard some items before considering adding any more...");
                                    return;
                                }
                            }
                        }
                        else { Console.WriteLine("You place the item back in your pack."); return; }
                    }
                    else if (answerNum == 3)
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
                                
                                Console.WriteLine($"Erm... Upon consideration you think discarding your {weapon.Name}, or any weapon, might be a bad idea unless there's another readily available...");
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
                    else
                    {
                        if (item.Name == "ball of red thread")
                        {
                            Console.WriteLine("You begin unravelling the thread. It trails behind you as you move...");
                            SpecifyAttribute = "unspooled";
                            Attribute = false;
                            if (!inventory.Contains(item))
                            {
                                StashItem(item, inventory);
                            }
                            room.ItemList.Remove(item);
                            threadPath.Insert(0, room);
                            return;
                        }
                        else
                        {
                            if (!item.Attribute)
                            {
                                Console.WriteLine($"You open up the music box and let it's enchanting music fill the {room.Name}.\n You then leave it behind. If you're being followed, maybe it'll make a good distraction...");
                                item.SpecifyAttribute = "opened";
                                item.Attribute = true;
                                room.ItemList.Add(item);
                                inventory.Remove(item);
                                return;
                            }
                            else
                            {
                                Console.WriteLine("You close the lovely music box. It's melody stops at once...");
                                item.SpecifyAttribute = "unopened";
                                item.Attribute = false;
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
        public bool UseItem1(bool music, Dictionary<Item, List<Player>> usesDictionaryItemChar,Item item, Feature feature, Dictionary<Item, List<Feature>> usesDictionary, List<Item> inventory, List<Weapon> weaponInventory, Room room, Player player, Monster monster, Combat battle, bool fieryEscape, List<Room> choiceVersusDestination = null, Item binkySkull = null, Item musicBox = null, Item note = null, Item jailorKeys = null)
        {
            Door door1 = new Door();
            List<Room> roomlist = new List<Room>(); // empty lists for filling in Search function unused parameters
            if (usesDictionary[item].Contains(feature))
            {
                if (!feature.Name.Contains("totem"))
                {
                    feature.Attribute = !feature.Attribute;
                } // key lock unlock, weapon intact broken, magical charm uncharmed charmed, etc
                if (feature.Attribute == false)
                {
                    if (!feature.Name.Contains("totem"))
                    {
                        feature.SpecificAttribute = "un" + feature.SpecificAttribute;
                    }
                    if (feature.Name.Contains("totem"))
                    {
                        List<Item> weapon = new List<Item> { item};
                        List<Weapon> nowWeapon = weapon.Cast<Weapon>().ToList();
                        Weapon cursedWeapon = nowWeapon[0];
                        int sum = 0;
                        foreach (Dice dice in cursedWeapon.GetDamage())
                        {
                            sum += dice.Roll(dice);
                        }
                        feature.Stamina -= sum;
                        if (feature.Stamina < 1)
                        {
                            feature.Attribute = !feature.Attribute;
                            feature.SpecificAttribute = "blasted";
                            feature.Name = "shattered " + feature.Name;
                            Console.WriteLine("Your blow breaks the crystal! Before your eyes intense light slices through the cracks as the magic inside surges with explosive force...");
                            Console.WriteLine("Test your skill to avoid the blast!\n[Roll 3 four sided dice under your skill score + 3]");
                            Dice D4 = new Dice(4);
                            List<Dice> boom = new List<Dice> {D4, D4, D4 };
                            int score = 0;
                            Console.ReadKey(true);
                            string messae = "";
                            foreach(Dice d in boom)
                            {
                                int result = D4.Roll(D4);
                                score += result;
                                Console.WriteLine($"You rolled a {result}");
                                Console.ReadKey(true);
                            }
                            messae += $"You rolled a total of {score}";
                            string plus = "";
                            if (player.Traits.ContainsKey("jinxed"))
                            {
                                score -= 4;
                                messae += " to which 4 is subtracted because of your jinxy nature!";
                                plus = "also";
                            }
                            bool felix = false;
                            int count = 0;
                            foreach(Weapon w in player.WeaponInventory)
                            {
                                if (w.Boon > 9)
                                {
                                    count++;
                                }
                            }
                            if (count != 0 && count == player.WeaponInventory.Count)
                            {
                                felix = true;
                            }
                            if (felix)
                            {
                                score -= 6;
                                messae += $"\nYour Felix Felicis {plus} deducts 6 points from your roll!";
                            }
                            Console.WriteLine(messae);
                            Console.ReadKey(true);
                            if (player.Skill + 3 < score)
                            {
                                
                                Console.WriteLine("You're too slow!");
                                Console.ReadKey(true);
                                
                                List<string> kablam = new List<string>
                                {
                                    $"You stare transfixed as a web of cracks rapidly splinter the crystal. Before you know it you've been thrown through the air by the explosive force wrought by its destruction!\n[You lose {score} stamina!]",
                                    $"You try to wheel away but are instead launched back as the crystal erupts!\n[You lose {score} stamina!]",
                                    $"You begin to recoil but are instead lifted off your feet by the crystal's blast!\n[You lose {score} stamina!]",
                                    $"You jolt backwards but find no cover from the blast of sharp fragments. They lacerate your arms as you cover your face!\n[You lose {score} stamina!]"
                                };
                                Console.WriteLine(kablam[D4.Roll(D4) - 1]);
                                player.Stamina -= score;
                                return true;
                            }
                            else if (player.Skill + 3 >= score)
                            {
                                Console.WriteLine("You dive out of the way just before the crystal explodes!");
                                Console.ReadKey(true);
                                Console.WriteLine("fragments rain down on you. But it's not long before the CurseBreaker, brandishing his lethal sabre, closes in once more...");
                                return true;
                            }
                            
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Your {item.Name} cracks the crystal, but not with enough force to shatter it...");
                            Console.ReadKey(true);
                            return true;
                        }
                        

                    }
                    else if (item.Name == "jailor keys" && (feature.Name == "far door" || feature.Name == "near door"))
                    {
                        int index = feature.SpecificAttribute.IndexOf("ed");
                        string strand = feature.SpecificAttribute.Substring(0, index);
                        Console.WriteLine($"The key slides easily into the lock. With one sharp twist you hear the tumblers turn and the door {strand}.");
                        Console.ReadKey(true);
                        return true;
                    }
                    else if (item.Name == "brass key" && feature.Name == "double doors")
                    {
                        int index = feature.SpecificAttribute.IndexOf("ed");
                        string strand = feature.SpecificAttribute.Substring(0, index);
                        Console.WriteLine($"The key slides easily into the lock. With one sharp twist you hear the tumblers turn and the door {strand}.");
                        Console.ReadKey(true);
                        return true;
                    }
                    else if (item.Name == "lockpicking set")
                    {
                        Console.WriteLine($"You slide the stiletto's blade through the top of the keyhole and begin jostling with the tumblers with the bobby pin. Sure enough something clunks. The {feature.Name} has been unlocked.");
                        Console.ReadKey(true);
                        return true;
                    }
                    else if (item.Name == "copper key")
                    {
                        Console.WriteLine("The key slides easily into the lock. With one sharp twist you hear the tumblers turn and the door unlock");
                        Console.ReadKey(true);
                        return true;
                    }
                    else if (item.Name == "steel key" && feature.Name == "rosewood chest")
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
                                feature.Search(music, usesDictionaryItemChar, choiceVersusDestination, player.CarryCapacity, inventory, weaponInventory, room, fieryEscape, null, door1, roomlist);
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
                    if (feature.Name.Contains("totem"))
                    {
                        return false;
                    }
                    feature.SpecificAttribute = feature.SpecificAttribute.Substring(2, feature.SpecificAttribute.Length - 2);
                    if (item.Name == "jailor keys" && (feature.Name == "far door" || feature.Name == "near door"))
                    {
                        
                        Console.WriteLine("The key slides easily into the lock. With one sharp twist you hear the tumblers turn and the door lock.");
                        Console.ReadKey(true);
                        return true;
                    }
                    else if (item.Name == "brass key" && feature.Name == "double doors")
                    {
                        Console.WriteLine("The key slides easily into the lock. With one sharp twist you hear the tumblers turn and the door lock.");
                        Console.ReadKey(true);
                        return true;
                    }
                    else if (item.Name == "copper key")
                    {
                        Console.WriteLine("The key slides easily into the lock. With one sharp twist you hear the tumblers turn and the door lock");
                        Console.ReadKey(true);
                        return true;
                    }
                    else if (item.Name == "lockpicking set")
                    {
                        Console.WriteLine($"You slide the stiletto's blade through the top of the keyhole and begin jostling with the tumblers with the bobby pin. Sure enough something clunks. The {feature.Name} has been locked.");
                        Console.ReadKey(true);
                        return true;
                    }
                    else if (feature.Name == "skeleton" && item.Name =="rusty chain-flail")
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
                                feature.Search(music, usesDictionaryItemChar, choiceVersusDestination, player.CarryCapacity, inventory, weaponInventory, room, fieryEscape, null, door1, roomlist);
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
                if (feature.Name.Contains("totem"))
                {
                    if(item is Weapon)
                    {
                        
                        Console.WriteLine("Your blow is countered by some impenetrable enchanted forcefield!\n" +
                            "Mundane weapons have no effect on these totems summoned through dark Fey Sorcery...");
                        
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("That does nothing to counter the totem's magic!");
                        return false;
                    }
                }
                if (feature.Description == "Replete with weapons of all descriptions, their oiled and well-polished blades gleam at you.\nIt's a shame someone was foresighted enough to lock them all behind an enchanted glass panel...")
                {
                    if (Name == "lockpicking set" || Name.Contains(" key"))
                    {
                        Console.WriteLine("You try opening the display case, wary of the magical forcefield surrounding it but unable to resist the temptation of the glittering weapons on the other side of the glass. \n If you could just twist it a little more - YOUCH!");
                        List<string> magicRebuke = new List<string> 
                        { 
                            $"The enchanted lock flings your {item.Name} back in your face!",
                            $"You get zapped by a fierce blue bolt of magic!",
                            $"While you're distracted the enchanted display case wallops you with one it's door before quickly snapping shut again!",
                            $"The display case burns your fingers with a cantrip of frost!",
                            $"The lock suddenly comes to life and nips at your fingers!"
                        };
                        Dice D5 = new Dice(5);
                        int damage = D5.Roll(D5) * 2;
                        Console.WriteLine(magicRebuke[D5.Roll(D5) - 1] + $" You lose {damage} stamina!");
                        player.Stamina -= damage;   
                        if (player.Stamina < 1)
                        {
                            Console.WriteLine("Though you were on death's door, you nevertheless tarried on anyway. However, with this injury you have finally passed beyond its threshold...");
                            Console.ReadKey(true);
                            Console.WriteLine("Your adventure ends here...");
                            Console.ReadKey(true);
                            return false;
                        }
                        Console.ReadKey(true);
                        Console.WriteLine($"You retrieve your {item.Name} and recoil.\n This display case has got some serious attitude!");
                        Console.ReadKey(true);
                        return false;
                    }
                    else if(item is Weapon)
                    {
                        Console.WriteLine($"You heave your {item.Name}, ready to smash the display case to smithereens only to find it does not comply. With uncanny cunning it casts a freezing hex on you the moment you raise your weapon above your head. No sooner has your entire body frozen to an icicle than your weapon slips from your grip and shatters you into a thousand pieces...");
                        Console.ReadKey(true);
                        player.Stamina = -1;
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        return false;
                    }
                }
                if (item.Name=="magnifying glass")
                {
                    if (feature.Name == "skeleton" && feature.SpecificAttribute == "unshattered")
                    {
                        Console.WriteLine("You peer through the magnifying glass. You discover that the shiny thing lodged behind the chained-fast skeleton is in fact a steel key! Now if only you could... What? \nMove the skeleton out of the way? \nBreak it apart? \nSomehow reach past the tight chains and bones and purloin the key? \nYou scratch your head in contemplation...");
                    }
                    else if (feature.Name == "rosewood chest" && feature.SpecificAttribute == "unlocked" && feature.ItemList.Count == 0 && !player.Inventory.Contains(musicBox) && !room.ItemList.Contains(musicBox) && note != null)
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
                                        feature.Search(music, usesDictionaryItemChar, choiceVersusDestination, player.CarryCapacity, inventory, weaponInventory, room, fieryEscape, null, door1, roomlist);
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
                            $"your eyes following the tight circle of light as it flickers and dances across the opposite wall. Whatever the beam touches is left warm to the touch.");
                        if (room.Name == "dank cell") { Console.WriteLine("An idea begins to form..."); }
                    }
                    
                    else { Console.WriteLine($"You inspect the {feature.Name} with your magnifying glass. Were you expecting to find something?"); }
                }
                else if ((item.Name.Contains("potion") || item.Name == "Elixir of Feline Guile" || item.Name == "Felix Felicis") && binkySkull != null && feature.Name == "skeleton" && !room.ItemList.Contains(binkySkull) && !player.Inventory.Contains(binkySkull) && player.Traits.ContainsKey("friends with fairies"))
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
                                    responses.Remove(responses[2]);
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
                                        "You ruminate on the time you couldn't stop snickering at the name of your commander's friend, Biggus Diccus. He had everyone executed for insubordinate giggling just after you excused yourself..."
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
                                            battle.Monster.Items.Remove(jailorKeys);
                                            battle.WonFight(room);
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
                                        parlance = "Oh sure!' he remarks craftily, 'We've got ourselves an hooge arsenal up the stairs from 'ere. Want to see?";
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
                                                parlance = "Oh sure!' he remarks craftily, 'We've got ourselves an hooge arsenal up the stairs from 'ere. Want to see?";
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
                                    "You ruminate on the time you couldn't stop snickering at the name of your commander's friend, Biggus Diccus. He had everyone executed for insubordinate giggling just after you excused yourself..."
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
                                        battle.Monster.Items.Remove(jailorKeys);
                                        battle.WonFight(room);
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
                                    "You ruminate on the time you couldn't stop snickering at the name of your commander's friend, Biggus Diccus. He had everyone executed for insubordinate giggling just after you excused yourself..."
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
                                    battle.Monster.Items.Remove(jailorKeys);
                                    battle.WonFight(room);
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
        public List<bool> UseItem(bool music, Item item1, Item item2, Dictionary<Item, List<Item>> usesDictionary, List<Item> specialItems, Feature feature = null, Item plusItem = null, Room room = null, Player player = null, Feature addFeature = null, Dictionary<Item, List<Feature>> usesDictionaryItemFeature = null, Dictionary<Item, List<Player>> usesDictionaryItemChar = null, Player player1 = null, Combat trialBattle = null, Monster monster = null)
        {
            List<bool> tlist = new List<bool> { false, false };
            if (usesDictionary[item1].Contains(item2))
            {
                item2.Attribute = !item2.Attribute; // key lock unlock, weapon intact broken, magical charm uncharmed charmed, etc
                if (item2.Attribute == false)
                {
                    item2.SpecifyAttribute = item2.SpecifyAttribute.Substring( 2, item2.SpecifyAttribute.Length-2);
                    if ((item1.Name == "bobby pin" && item2.Name == "stiletto blade")||(item2.Name == "bobby pin" && item1.Name == "stiletto blade"))
                    {
                        Console.WriteLine("You figure the thin sturdy blade will suffice with the bobby pin to make for a serviceable lockpicking set. \nNow if only there were a lock you could try it out on...");
                        player.Inventory.Remove(item2);
                        player.Inventory.Remove(item1);
                        try
                        {
                            List<Item> stilettoItem = new List<Item> { item1 };
                            List<Weapon> stilettoWeapon = stilettoItem.Cast<Weapon>().ToList();
                            
                            player.WeaponInventory.Remove(stilettoWeapon[0]);
                        }
                        catch
                        {
                            List<Item> stilettoItem = new List<Item> { item2 };
                            List<Weapon> stilettoWeapon = stilettoItem.Cast<Weapon>().ToList();
                            
                            player.WeaponInventory.Remove(stilettoWeapon[0]);
                        }
                        player.Inventory.Add(specialItems[5]);
                        
                        
                    }
                    else if (item1.Name == "magnifying glass" && item2.Name == "garment" && player.Traits.ContainsKey("jinxed"))
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
                        if (trialBattle.Fight(music, usesDictionary, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, addFeature, specialItems, 1, fire))
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
                        if (trialBattle.Fight(music, usesDictionary, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, addFeature, specialItems, 1, fire))
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
            else 
            {
                if (monster != null)
                {
                    if (item2.Name == monster.Veapon.Name && item1.Name.Contains("throwing knife"))
                    {
                        int resultOfSkillTest = 0;
                        if (player.Skill < 7)
                        {
                            Console.WriteLine("In the heat of battle you hurl your throwing knife and pray it hits your target...");
                            Console.ReadKey(true);
                            Console.WriteLine("[Test your skill: Roll a D7 equal to or under your skill score]");
                            Console.ReadKey(true);
                            Dice D7 = new Dice(7);
                            resultOfSkillTest = D7.Roll(D7);
                            if (resultOfSkillTest > 3 && player.Traits.ContainsKey("jinxed"))
                            {
                                resultOfSkillTest -= 3;
                            }
                            Console.WriteLine($"You rolled a {resultOfSkillTest}");
                            if (resultOfSkillTest <= player.Skill)
                            {
                                Console.ReadKey(true);
                                if (monster.Name != "CurseBreaker")
                                {
                                    Console.WriteLine("You fling the throwing knife into your opponent's weapon. It is sent clattering away along the ground. Fuming, your enemy resolves to settle this fight with their bare hands...");
                                }
                                else
                                {
                                    Console.WriteLine("The CurseBreaker's sabre is sent clattering across the flagstones as your throwing knife slashes the back of his hand. Scowling, he unsheathes a stiletto blade to finish what he started...");
                                }
                            }
                            else
                            {
                                Console.ReadKey(true);
                                if (monster.Name != "CurseBreaker")
                                {
                                    Console.WriteLine("Your throwing knife misses...");
                                }
                                else
                                {
                                    Console.WriteLine("The CurseBreaker deflects your throwing knife with a flourish of his sabre. The fight continues...");
                                }
                                return tlist;
                            }
                        }
                        else
                        {
                            if (monster.Name != "CurseBreaker")
                            {
                                Console.WriteLine("With well practiced flair you fling the throwing knife into your opponent's weapon. It is sent clattering away along the ground. Fuming, your enemy resolves to settle this fight with their bare hands...");
                            }
                            else
                            {
                                Console.WriteLine("The CurseBreaker's sabre is sent clattering across the flagstones as your throwing knife slashes the back of his hand. Scowling, he unsheathes a stiletto blade to finish what he started...");
                            }
                        }

                        player.Inventory.Remove(item1);
                        room.ItemList.Add(item1);
                        monster.Items.RemoveAt(0);
                        room.ItemList.Add(item2);
                        if (monster.Name != "CurseBreaker")
                        {
                            List<Item> weaponcaster = new List<Item> { specialItems[8] };
                            List<Weapon> weaponCasted = weaponcaster.Cast<Weapon>().ToList();
                            monster.Veapon = weaponCasted[0];
                        }
                        else
                        {
                            List<Item> weaponcaster = new List<Item> { specialItems[9] };
                            List<Weapon> weaponCasted = weaponcaster.Cast<Weapon>().ToList();
                            
                            
                            monster.Veapon = weaponCasted[0];
                        }

                    }
                }
                
                return tlist; 
            }

        }
        public bool UseItem3(Item item1, Player player, Dictionary<Item, List<Player>> usesDictionary, bool masked)
        {
            try {
                if (usesDictionary[item1].Contains(player))
                {

                    string propString = "";
                    Dice D6 = new Dice(6);
                    try
                    {
                        propString = item1.Special.Substring(0, Special.IndexOf(":"));
                    }
                    catch { }
                    //PropertyInfo boost = typeof(int).GetProperty(propString);
                    //object value = boost.GetValue(player, null);
                    //int CharacterAttribute = Convert.ToInt32(value);
                    if (propString == "speed")
                    {
                        player.Speedy = true;
                        player.Inventory.Remove(item1);
                        return true;
                    }
                    else if (propString == "Stamina")
                    {
                        if (player.Traits.ContainsKey("medicine man"))
                        {
                            int boost = D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + SpecialEffect;
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
                            int boost = D40.Roll(D40) + SpecialEffect;
                            if (player.Stamina + 2 * player.Skill >= player.InitialStamina)
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
                                    Console.WriteLine($"Urgh! That {item1.Name} didn't taste like the Fey 'magic' you've grown accustomed to... \nYou lose {boost / 5} stamina points!");
                                    player.Stamina -= boost / 5;
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
                            int boost = D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + SpecialEffect;
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
                    
                    
                    else if (item1.Name == "soot")
                        {
                            Console.WriteLine("you smear the soot across your cheeks in thick black lines like warpaint, obscuring your features. \nGrr! Your enemies better watch out...");
                            player.Inventory.Remove(item1);
                            player.Masked = true;
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
    public class Weapon : Item, INotSoCute
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
        public int Attack(int skill, int opponentSkill, int enemyStamina, bool commentary, Monster monsterName, Player player, string another, Room room, Feature holeInCeiling, int totemCount = 1, bool start = false, bool attackedMonster2 = false)
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
                    if (skill == -10 || totemCount == -1)
                    {
                        foreach (Dice d in Damage)
                        {

                            int roll = d.Roll(d);
                            damageDealt += roll;


                        }
                    }
                    else
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
                }
                else
                {
                    if (!start && !attackedMonster2 && player.Skill != -10)
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







                if ((hitThreshold - hitRoll) - 3 > opponentSkill || (skill == -10))
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
                    if (!player.Traits.ContainsKey("thick-skinned"))
                    {
                        if (crit)
                        {
                            int LadyDeathStrike = 0;
                            if (skill == -10 || totemCount == -1)
                            {
                                LadyDeathStrike = D4.Roll(D4);
                            }
                            if (skill > 8 || LadyDeathStrike == 4)
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
                            else if (skill > 5 || LadyDeathStrike == 3)
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
                            else if (skill > 2 || LadyDeathStrike == 2)
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
                            int LadyDeathStrike = 0;
                            if (skill == -10 || totemCount == -1)
                            {
                                LadyDeathStrike = D4.Roll(D4);
                            }
                            Console.WriteLine("\n");
                            if (skill > 8 || LadyDeathStrike == 4)
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
                            else if (skill > 5 || LadyDeathStrike == 3)
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
                            else if (skill > 2 || LadyDeathStrike == 2)
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
                    else
                    {
                        if (crit)
                        {
                            int LadyDeathStrike = 0;
                            if (skill == -10 || totemCount == -1)
                            {
                                LadyDeathStrike = D4.Roll(D4);
                            }
                            if (skill > 8 || LadyDeathStrike == 4)
                            {
                                if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 1)
                                {
                                    Console.WriteLine(CritAttack[0]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < enemyStamina / 3)
                                {
                                    Console.WriteLine(CritAttack[1]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 2 * enemyStamina / 3)
                                {
                                    Console.WriteLine(CritAttack[2]);
                                }
                                else
                                {
                                    Console.WriteLine(CritAttack[3]);
                                }

                            }
                            else if (skill > 5 || LadyDeathStrike == 3)
                            {
                                if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 1)
                                {
                                    Console.WriteLine(CritAttack[4]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < enemyStamina / 3)
                                {
                                    Console.WriteLine(CritAttack[5]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 2 * enemyStamina / 3)
                                {
                                    Console.WriteLine(CritAttack[6]);
                                }
                                else
                                {
                                    Console.WriteLine(CritAttack[7]);
                                }
                            }
                            else if (skill > 2 || LadyDeathStrike == 2)
                            {
                                if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 1)
                                {
                                    Console.WriteLine(CritAttack[8]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < enemyStamina / 3)
                                {
                                    Console.WriteLine(CritAttack[9]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 2 * enemyStamina / 3)
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
                                if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 1)
                                {
                                    Console.WriteLine(CritAttack[12]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < enemyStamina / 3)
                                {
                                    Console.WriteLine(CritAttack[13]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 2 * enemyStamina / 3)
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
                            int LadyDeathStrike = 0;
                            if (skill == -10 || totemCount == -1)
                            {
                                LadyDeathStrike = D4.Roll(D4);
                            }
                            Console.WriteLine("\n");
                            if (skill > 8 || LadyDeathStrike == 4)
                            {
                                if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 1)
                                {
                                    Console.WriteLine(GoodAttack[0]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < enemyStamina / 3)
                                {
                                    Console.WriteLine(GoodAttack[1]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 2 * enemyStamina / 3)
                                {
                                    Console.WriteLine(GoodAttack[2]);
                                }
                                else
                                {
                                    Console.WriteLine(GoodAttack[3]);
                                }

                            }
                            else if (skill > 5 || LadyDeathStrike == 3)
                            {
                                if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 1)
                                {
                                    Console.WriteLine(GoodAttack[4]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < enemyStamina / 3)
                                {
                                    Console.WriteLine(GoodAttack[5]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 2 * enemyStamina / 3)
                                {
                                    Console.WriteLine(GoodAttack[6]);
                                }
                                else
                                {
                                    Console.WriteLine(GoodAttack[7]);
                                }
                            }
                            else if (skill > 2 || LadyDeathStrike == 2)
                            {
                                if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 1)
                                {
                                    Console.WriteLine(GoodAttack[8]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < enemyStamina / 3)
                                {
                                    Console.WriteLine(GoodAttack[9]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 2 * enemyStamina / 3)
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
                                if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 1)
                                {
                                    Console.WriteLine(GoodAttack[12]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < enemyStamina / 3)
                                {
                                    Console.WriteLine(GoodAttack[13]);
                                }
                                else if (enemyStamina - 4*(damageDealt + goodHit / 2)/5 < 2 * enemyStamina / 3)
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
                }
                

                if (!commentary && player.Traits.ContainsKey("thick-skinned"))
                {
                    return (4 * (damageDealt + goodHit / 2) / 5); 
                }
                else if ((skill == -10 || totemCount == -1) && player.Traits.ContainsKey("thick-skinned"))
                {
                    return (4 * (damageDealt + goodHit / 2) / 5);
                }
                if (totemCount == -1)
                {
                    totemCount = 1;
                }
                return ((damageDealt + goodHit / 2) / totemCount);
            }
            else // you or the monster misses!
            {
                if (commentary)
                {
                    if (skill == -10)
                    {
                        List<string> dodge = new List<string>
                        {
                            "\nYou dodge it just in time!",
                            "\nYou swerve out of the way!",
                            "\nYou dive before the blow lands!",
                            "\nYou lunge out of reach!",
                            "\nYou sidestep before the blow cleaves you in two!",
                            "\nYou nip out of the way!",
                            "\nYou duck under her flailing talons!",
                            "\nYou scramble from her clutches!"
                        };
                        Console.WriteLine("The Lady of Vipers attacks!");
                        Console.ReadKey(true);
                        Console.WriteLine(dodge[(D16.Roll(D16) - 1) / 2]);

                    }
                    else if (totemCount == -1)
                    {
                        bool felix = false;
                        int count = 0;
                        foreach (Weapon w in player.WeaponInventory)
                        {
                            if(w.Boon > 9)
                            {
                                count++;
                            }
                        }
                        if(count != 0 && count == player.WeaponInventory.Count)
                        {
                            felix = true;
                        }
                        Dice D8 = new Dice(8);
                        Dice D12 = new Dice(12);
                        List<string> CBMiss = new List<string>
                        {
                            "\nYou dart back from the CurseBreaker's attack!",
                            "\nYou duck the CurseBreaker's strike!",
                            "\nYou dodge the incoming blow by the skin of your teeth!",
                            "\nYou dive and scramble away from the CurseBreaker's onslaught!",
                            "\n You swerve left and evade the CurseBreaker's attack!",
                            "\n You sidestep right and dodge the incoming attack!",
                            "\n You duck and roll before the incoming blow strikes!",
                            "\nYou dash backwards - out of the CurseBreaker's reach!"
                        };
                        if (opponentSkill > 8)
                        {
                            CBMiss.Add("Like a leaf upon the wind, you dodge and swerve between the CurseBreaker's attacks!");
                            CBMiss.Add("Floating like a butterfly and stinging like a bee, you triple flip around the CurseBreaker's strike!");
                            CBMiss.Add("Hands held behind your back, you display your martial prowess as you parry each incoming strike with a flurry of kicks!");
                            CBMiss.Add("The CurseBreaker thrusts with his sabre! You leap and balance upon the blade before kicking him in the face!");
                        }
                        else if (player.Traits.ContainsKey("jinxed") || felix)
                        {
                            CBMiss.Add("The CurseBreaker swears as you trip him up while you scramble away!");
                            CBMiss.Add("The CurseBreaker's strikes are no match for your jinxy antics! He gets red in the face as you jig out of the way of each attack...");
                            CBMiss.Add("The CurseBreaker thrusts, parries, slashes with expert finesse, but thanks to your oafish fortune all his blows come to nought!");
                            CBMiss.Add("The CurseBreaker's sabre somehow gets stuck in your armour. He loses his temper, then loses his balance after your buffoonish attempt to help him free it...");
                        }
                        if (player.Traits.ContainsKey("jinxed") || felix)
                        {
                            Console.WriteLine($"The CurseBreaker attacks with his {this.Name}!");
                            Console.ReadKey(true);
                            Console.WriteLine(CBMiss[D12.Roll(D12) - 1]);
                        }
                        else if (skill < 9)
                        {
                            Console.WriteLine($"The CurseBreaker attacks with his {this.Name}!");
                            Console.ReadKey(true);
                            Console.WriteLine(CBMiss[D8.Roll(D8) - 1]);
                        }
                        else
                        {
                            if (Name.ToLower() == "sabre")
                            {
                                Console.WriteLine($"The CurseBreaker attacks with his {this.Name}!");
                                Console.ReadKey(true);
                                Console.WriteLine(CBMiss[D12.Roll(D12) - 1]);
                            }
                            else
                            {
                                Console.WriteLine("The CurseBreaker attacks with his cursed gloves!");
                                Console.ReadKey(true);
                                Console.WriteLine(CBMiss[D8.Roll(D8) - 1]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your attack misses!");
                    }
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
        public List<Dice> GetDamage()
        {
            return this.Damage;
        }


    }
}

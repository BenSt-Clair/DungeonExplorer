using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawler
{
	public class CoinGame
	{
		protected Dice Coin { get; }
		protected Monster Monster1 { get; set; }
		protected Monster Monster2 { get; set; }
		protected Player Player { get; set; }
		public CoinGame(Monster monster1, Monster monster2, Player player, Dice dice)
		{
			Coin = dice;
			Monster1 = monster1;
			Monster2 = monster2;
			Player = player;
		}
		public List<int> SimpleGame()
		{
			Dictionary<string, string> basic = new Dictionary<string, string>
			{
				{ "cGreat", "\u001b[38;2;34;139;34m" },  // SeaGreen
                { "cGood", "\u001b[38;2;154;205;50m" },   // YellowGreen
                { "cOkay", "\u001b[38;2;240;230;140m" },  // Khaki
                { "cBad", "\u001b[38;2;233;150;122m" },   // DarkSalmon
                { "cTerrible", "\u001b[38;2;178;34;34m" } // FireBrick
            };
			const string Slate = "\u001b[38;2;151;135;250m";
			const string BurlyWood = "\u001b[38;2;222;184;135m";
			const string Moccasin = "\u001b[38;2;255;228;181m";
			const string BlanchedAlmond = "\u001b[38;2;0;139;139m";
			const string Reset = "\u001b[0m";
			int turns = 0;
			int x = 0;
			int y = 0;
			int z = 0;
			int a = 0;
			string playerScore;
			string goblinScore;
			string gnollScore;
			int goblinWins = 0;
			int gnollWins = 0;
			int playerWins = 0;
			string minusChoice;
			string description = "You decide that its time to take your leave.";
			string parlance = "The question is, how do you go about it?";
			List<string> choices = new List<string>
					{
						"You quietly get up out of your chair whilst your opponents are distracted and sneakily take your leave...",
						"You try to politely excuse yourself...",
						"You hope to speed up the game by raising the stakes...",
						"Try to change the game to something more interesting...",
						"Exclaim that their game is boring and ask if they have cards?",
						"Claim that your commander had issued you with pressing business and... Ooh, look! Is that the time..?"

					};
			Console.WriteLine($"{BlanchedAlmond}The noble game of 'coins,' you are assured, is a challenging trial of wits and fortune, to whit many a foolhardy enthusiast before now has fallen to its addictive twists and turns, enthralling ups and downs, and maddening stratagems.\n The {Monster1.Name} and {Monster2.Name} are confident enough in their own not-inconsiderable skill to let you have the first coin flip...");
			Console.ReadKey(true);
			Console.WriteLine($"They watch on with something approximating a grandmaster's shrewd appraise, as you uncertainly reach for your coin.{Reset}");
			List<string> eagerStrings = new List<string>
			{
				"The goblin roars with triumph as he seizes his winnings...",
				"The gnoll lets loose a triumphant howl as it sweeps up the coins...",
				"With an arched eyebrow you collect your winnings...",

				"The goblin hoots and grins as he collects his coins...",
				"The gnoll sickers as it rakes in more money...",
				"The gnoll and goblin eye you expectantly. \nYou indulge them with a withering smile as you pick up your three coins...",

				"The gnoll bangs its fist on the table as the goblin cheekily sweeps up the moolah...",
				"The goblin fumes as the slavering gnoll gathers its winnings...",
				"The gnoll and goblin seem to expect some reaction from you. \nWith a heavy sigh you give a half-hearted whoop, and then painstakingly pick up *all* three of your hard won coins...",

				"The game intensifying, the goblin's clammy palms slam atop its winnings as it jealously stashes them away...",
				"As if the stakes could not be higher, the gnoll snatches up its winnings and stashes them away...",
				"The gnoll and goblin once more look to you with dumb expectant faces. \nStifling a bored groan lost on the other two chuckleheads, you stow away your coins...",

				"The goblin's fist pumps the air! It let's out a bestial yawp of (erm...) good sportsmanship, as it gloats over its winnings...",
				"Breaking the game's crackling tension, the gnoll pounds its chest and roars! It leers the distraught goblin's way as it seizes all three coins...",
				"You can sense the gnoll and goblin's avid gaze turn to you before you even raise your head from its slumped position on the table. \nYou somehow manage not to roll your eyes under their fervent and captivated watch as you select your coins and drearily place them on your pile...",

				"The goblin does a merry jig around the table while the gnoll laments. It feverishly takes the coins it won...",
				"The gnoll enters into a triumphal march around the table, parading its triumph before raking in the dough...",
				"Staring into the unceasing void, you once again pick up your prize. The gnoll and goblin eye your every movement, looking on with wide eyes as though you were the luckiest man on earth... "
			};
			List<string> result = new List<string>
			{
				$"{basic["cGood"]}heads{Reset}",
				$"{basic["cBad"]}tails{Reset}"
			};
			List<string> preFlip = new List<string>
			{
				"Feeling tension winching around its gut, the goblin flips its coin...",
				"With a tincture of trepidation, the gnoll twirls its coin through the air...",
				"You flip your coin...",

				"Sweeping a clammy hand through its wispy hair, the goblin flips its coin...",
				"The gnoll visibly trembles with excitement as it hunches over its coin. You watch its crazed eyes follow the coin through its arc with some concern...",
				"You make no fuss as you flip your coin...",

				"The goblin is feeling the pressure. Its tremulous fingers send its coin twirling...",
				"Knots of suspense twisting in the gnoll's stomach, it flips its coin...",
				"You flip your coin without much enthusiasm...",

				"The goblin bites its lip nervously before sending the coin spinning through the air...",
				"The gnoll can scarcely hold back its excitement as it flips its coin...",
				"You heave a sigh before letting your coin spin through the air...",

				"The goblin gnaws at its knuckles as its tremulous hand flips the coin...",
				"The gnoll can't keep still amidst the suspense! It flips its coin...",
				"You stifle a yawn... oh, and, uh... flip your coin...",

				"The goblin raises the coin in its shaky hand. Before its wide eyes, pleading for good fortune, it sends the coin twirling...",
				"The gnoll can't get enough of this game. It flips its coin with fanatical drive...",
				"Staring directly ahead as the gnoll and goblin jump up and down in their seats, you flip your coin..."
			};
			int heads = 0;
			bool tryLeaving = false;
			while (Player.Coins > 0 && Player.Coins < 51 && turns < 13)
			{
				Console.WriteLine("\t\t\tWINNINGS");
				Console.WriteLine($"YOU: {Player.Coins} || GOBLIN: {Monster1.Coins} || GNOLL: {Monster2.Coins}");
				Console.ReadKey(true);
				if (turns > 0 && turns < 5)
				{
					Console.WriteLine($"{Moccasin}Would you like to continue playing..?{Reset}");
					if (Dialogue.getYesNoResponse(false))
					{
						tryLeaving = true;
					}

				}
				else if (turns > 4 && turns < 8)
				{
					Console.WriteLine($"{Moccasin}Are you *really* sure you want to continue playing.......?{Reset}");
					if (Dialogue.getYesNoResponse(false))
					{
						tryLeaving = true;
					}
				}
				else if (turns > 7)
				{
					Console.WriteLine($"{Moccasin}Would you like to continue losing the will to live................?{Reset}");
					if (Dialogue.getYesNoResponse(false))
					{
						tryLeaving = true;
					}
				}
				if (tryLeaving)
				{
					Dialogue leaveGame = new Dialogue(Player, Monster1);

					if ((turns > 7 || Player.Traits.ContainsKey("sadist")) && !choices.Contains("Arrgh! This is taking too long... Sod it, just attack the blighters and end this insufferable boredom..."))
					{
						choices.Add("Arrgh! This is taking too long... Sod it, just attack the blighters and end this insufferable boredom...");
					}
					Dictionary<string, string> choices_answers = new Dictionary<string, string>
					{
						{
							"You quietly get up out of your chair whilst your opponents are distracted and sneakily take your leave...",

							"You are tip-toeing towards the RmorRee door, just within reach, when suddenly a fist bangs upon the table." +
							"\n\n\t'Oi!' the goblin's eyes burn your back, 'Jus' where in the wossname do ya think yer going?'\n" +
							"  Turning around you see the goblin has brandished a dagger, as though to emphasize its point. You begin to " +
							"explain that you were just hoping to maybe get some more coins to continue playing this delightful game with them...?" +
							"\n  However, before you can finish, the goblin interrupts. 'Nah! We don't need none of that... sit back down, hoo-man, and finish the game or we might think you don't like coins or summit...'  The horrible creature laughs, before fixing you with a sinister gaze.\n\t 'And you don't want to know what we do to people who don't like the game of coins...' He growls as he sharpens the dagger." +
							"\n  Drat! It looks like you'll just have to once again resume your riveting game of coins..."
						},
						{
							"You try to politely excuse yourself...",

							"You claim you need to go to the toilet, all the while feigning a 100% sincere eagerness to return right away..." +
							"\n\n\t'But you don't need to go nowheres for that!' the goblin fishes in its ear for wax. 'Jus' go in the bucket...'" +
							"\n  'The bucket...?' you dare to ask." +
							"\n  In response the goblin fishes out a truly grim pale from underneath the table. 'We won't look,' the goblin assures you as flies swarm about the macabre contents of the bucket, 'we promise...'" +
							"\n  You claim that, upon consideration, the game is just too exciting not to hold it in for a bit longer..." +
							"\n\n Drat! It looks like you'll just have to once again resume your riveting game of coins..."
						},
						{
							"You hope to speed up the game by raising the stakes...",

							"The goblin and gnoll stare back at you quizzically. 'But why would we wonts to do that?' the goblin blurts." +
							"\n So that you can win quicker, is your reply." +
							"\n 'But what would we do for fun, then,' the goblin rebuts, before issuing a blunt dismissal, 'Nah! We don't want to be ending our game quicker - besides, the exciting part has only just started...'" +
							"\n\n Drat! It looks like you'll just have to once again resume your riveting game of coins..."
						},
						{
							"Try to change the game to something more interesting...",

							"You claim that you might know a game even better than this one..." +
							"\n\t'Nah! no such thing,' the goblin dismisses you as it pores" +
							" over its mound of winnings. Spurred by the imminent continuation" +
							" of this terrible game and your rising desperation to exit what" +
							" you're increasingly convinced must be the ninth circle of hell," +
							" you interject." +
							"\n  You assure them that its just like 'coins' - exactly like coins," +
							" in fact - its just a... new and exciting variation of 'coins'." +
							"\n  The gnoll and goblin eye you sceptically. They seem to doubt any" +
							" game could possibly be as good as 'coins', but after a moment's curiosity, " +
							"with narrowed eyes that say 'this best be good' they choose to " +
							"indulge you..."
						},
						{
							"Exclaim that their game is boring and ask if they have cards?",

							"How *dare* you insult the grand and noble game of coins? \nThe " +
							"gnoll and goblin chuck the table aside " +
							"and attack!\n\n Ah well, at least you're not playing coins anymore..."
						},
						{
							"Claim that your commander had issued you with pressing business and... Ooh, look! Is that the time..?",

							"\n\t'Yeah?' the horrid little goblin retorts, as he picks his nose for " +
							"bogies, 'Well as far as you're concerned I'm commanding officer so long as you're" +
							" in 'ere, sunshine.' His eyes harbour a murderous and fanatical glint that" +
							" only a game of coins can inspire. 'And I say you're gonna sit there an" +
							" play until we're finished. Or else...'" +
							"\n  Drat! It looks like your stuck playing this interminable game until the ends of time..."
						},
						{
							"Arrgh! This is taking too long... Sod it, just attack the blighters and end this insufferable boredom...",

							"In a crazed frenzy dredged from some bottomless pit of boredom only this game could awaken, you upend the table and lunge at your startled foes!"
						}
					};
					minusChoice = leaveGame.LoopParle(choices_answers, choices, description, parlance);
					if (minusChoice.Contains("Arrgh!") || minusChoice.Contains("boring"))
					{
						return new List<int> { -1 };
					}
					else if (minusChoice.Contains("change the game"))
					{
						return new List<int> { Player.Coins, Monster1.Coins, Monster2.Coins };
					}
					else
					{
						choices.Remove(minusChoice);
					}
					tryLeaving = false;
				}
				heads = 0;
				Console.ReadKey(true);
				x = turns;
				y = playerWins;
				z = goblinWins;
				a = gnollWins;
				while (x > 5)
				{
					x -= 6;
				}
				while (y > 5)
				{
					y -= 6;
				}
				while (z > 5)
				{
					z -= 6;
				}
				while (a > 5)
				{
					a -= 6;
				}
				Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x + 2]}{Reset}");
				Console.ReadKey(true);
				playerScore = result[Coin.Roll(Coin) - 1];
				if (playerScore.Contains("heads"))
				{
					heads++;
				}
				Console.WriteLine($"You flipped {playerScore}...");
				Console.ReadKey(true);
				Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x]}{Reset}");
				Console.ReadKey(true);
				goblinScore = result[Coin.Roll(Coin) - 1];
				if (goblinScore.Contains("heads"))
				{
					heads++;
				}
				Console.WriteLine($"The goblin flipped {goblinScore}!");
				Console.ReadKey(true);
				Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x + 1]}{Reset}");
				Console.ReadKey(true);
				gnollScore = result[Coin.Roll(Coin) - 1];
				if (gnollScore.Contains("heads"))
				{
					heads++;
				}
				Console.WriteLine($"The gnoll flipped {gnollScore}!");
				if (heads == 1)
				{
					if (playerScore.Contains("heads"))
					{
						playerWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * y + 2]}{Reset}");
						Monster1.Coins -= 1;
						Monster2.Coins -= 1;
						Player.Coins += 2;
						turns++;
						continue;
					}
					else if (goblinScore.Contains("heads"))
					{
						goblinWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * z]}{Reset}");
						Monster1.Coins += 2;
						Monster2.Coins -= 1;
						Player.Coins -= 1;
						turns++;
						continue;
					}
					else
					{
						gnollWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * a + 1]}{Reset}");
						Monster1.Coins -= 1;
						Monster2.Coins += 2;
						Player.Coins -= 1;
						turns++;
						continue;
					}
				}
				else if (heads == 0 || heads == 3)
				{
					Console.WriteLine($"{BurlyWood}A three-way tie!");
					Console.WriteLine($"The gnoll and goblin only seem more determined, as they once more put their luck to the test. They urge you to do likewise...{Reset}");
					Console.ReadKey(true);
					Console.WriteLine("You must all flip your coins again!");
					Console.ReadKey(true);
					continue;
				}
				else if (playerScore.Contains("tails"))
				{
					Console.WriteLine($"{BurlyWood}The air crackles with electricity as the goblin and gnoll face off against one another...{Reset}");
					Console.ReadKey(true);
					while (true)
					{
						heads = 0;
						Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x]}{Reset}");
						Console.ReadKey(true);
						goblinScore = result[Coin.Roll(Coin) - 1];
						if (goblinScore.Contains("heads"))
						{
							heads++;
						}
						Console.WriteLine($"The goblin flipped {goblinScore}!");
						Console.ReadKey(true);
						Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x + 1]}{Reset}");
						Console.ReadKey(true);
						gnollScore = result[Coin.Roll(Coin) - 1];
						if (gnollScore.Contains("heads"))
						{
							heads++;
						}
						Console.WriteLine($"The gnoll flipped {gnollScore}!");
						if (heads == 0 || heads == 2)
						{
							Console.WriteLine($"{BurlyWood}Another tie! The goblin and gnoll shoot daggars at each other across the table.{Reset} \nMeanwhile, you watch on with mounting incredulity...");
							Console.ReadKey(true);
							continue;
						}
						else
						{
							break;
						}
					}
					if (gnollScore.Contains("heads"))
					{
						gnollWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * a + 1]}{Reset}");
						Monster1.Coins -= 1;
						Monster2.Coins += 2;
						Player.Coins -= 1;
						turns++;
						continue;
					}
					else
					{
						goblinWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * z]}{Reset}");
						Monster1.Coins += 2;
						Monster2.Coins -= 1;
						Player.Coins -= 1;
						turns++;
						continue;
					}
				}
				else if (goblinScore.Contains("tails"))
				{
					Console.WriteLine($"{BurlyWood}The waves of excitement radiating from the gnoll crash against your utterly deadpan regard for its enthusiasm.{Reset} \nYou face off against one another in the deciding match!");
					Console.ReadKey(true);
					while (true)
					{
						heads = 0;
						Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x + 2]}{Reset}");
						Console.ReadKey(true);
						playerScore = result[Coin.Roll(Coin) - 1];
						if (playerScore.Contains("heads"))
						{
							heads++;
						}
						Console.WriteLine($"You flipped {playerScore}!");
						Console.ReadKey(true);
						Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x + 1]}{Reset}");
						Console.ReadKey(true);
						gnollScore = result[Coin.Roll(Coin) - 1];
						if (gnollScore.Contains("heads"))
						{
							heads++;
						}
						Console.WriteLine($"The gnoll flipped {gnollScore}!");
						if (heads == 0 || heads == 2)
						{
							Console.WriteLine($"{BurlyWood}Oh, god... Not another tie! You and this crazed gnoll must flip again...{Reset} \nMeanwhile, you wryly espy the goblin watching on, quivering with excitement...");
							Console.ReadKey(true);
							continue;
						}
						else
						{
							break;
						}
					}
					if (gnollScore.Contains("heads"))
					{
						gnollWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * a + 1]}{Reset}");
						Monster1.Coins -= 1;
						Monster2.Coins += 2;
						Player.Coins -= 1;
						turns++;
						continue;
					}
					else
					{
						playerWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * y + 2]}{Reset}");
						Monster1.Coins -= 1;
						Monster2.Coins -= 1;
						Player.Coins += 2;
						turns++;
						continue;
					}
				}
				else
				{
					Console.WriteLine($"{BurlyWood}The goblin visibly jitters with suspense. You regard its excitement with cynical disdain.{Reset} \nYou face off against one another in the deciding match!");
					Console.ReadKey(true);
					while (true)
					{
						heads = 0;
						Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x + 2]}{Reset}");
						Console.ReadKey(true);
						playerScore = result[Coin.Roll(Coin) - 1];
						if (playerScore.Contains("heads"))
						{
							heads++;
						}
						Console.WriteLine($"You flipped {playerScore}!");
						Console.ReadKey(true);
						Console.WriteLine($"{BlanchedAlmond}{preFlip[3 * x]}{Reset}");
						Console.ReadKey(true);
						goblinScore = result[Coin.Roll(Coin) - 1];
						if (goblinScore.Contains("heads"))
						{
							heads++;
						}
						Console.WriteLine($"The goblin flipped {goblinScore}!");
						if (heads == 0 || heads == 2)
						{
							Console.WriteLine($"{BurlyWood}Oh, god... Not another tie! You and this strange goblin must flip again...{Reset} \nMeanwhile, you forlornly glimpse the gnoll captivated by the game...");
							Console.ReadKey(true);
							continue;
						}
						else
						{
							break;
						}
					}
					if (goblinScore.Contains("heads"))
					{
						goblinWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * z]}{Reset}");
						Monster1.Coins += 2;
						Monster2.Coins -= 1;
						Player.Coins -= 1;
						turns++;
						continue;
					}
					else
					{
						playerWins++;
						Console.WriteLine($"{Slate}{eagerStrings[3 * y + 2]}{Reset}");
						Monster1.Coins -= 1;
						Monster2.Coins -= 1;
						Player.Coins += 2;
						turns++;
						continue;
					}
				}
			}
			if (turns == 13)
			{
				Console.WriteLine($"{basic["cBad"]}Unable to leave, the game's unceasing back and forth continues long into the night.");
				Console.ReadKey(true);
				Console.WriteLine("You keep playing, buffeted endlessly by the goblin regaling you of the noble game of coins' interminable history and enduring the slavering gnoll's excitable panting, when suddenly there is a fierce tremor!");
				Console.ReadKey(true);
				Console.WriteLine("The brazier's flame sputters and dies...");
				Console.ReadKey(true);
				Console.WriteLine("You just glimpse the goblin's and gnoll's final look of fright, before all the lights go out and darkness falls." +

						"  \n  You are left in pitch blackness for a few tense moments, dreading what is to follow, before a blood-curdling howl erupts from somewhere above" +
						" as something new and terrible is brought into the world. Soon afterwards, the tower collapses in on you all... ");
				Console.ReadKey(true);
				Console.WriteLine($"At least you never caught sight of whatever horror your terrible addiction to the game of 'coins' unleashed...{Reset}");
				Console.ReadKey(true);
				Console.WriteLine("Your adventure ends here...");
				Console.ReadKey(true);
				return new List<int> { };
			}
			else if (Player.Coins == 51)
			{
				return new List<int> { 51, 0, 0 };
			}
			else
			{
				return new List<int> { 0, Monster1.Coins, Monster2.Coins };
			}
		}
		public List<int> BetterGame(Item journal, Item musicBox, Feature strangeMosaic)
		{
			Dialogue usefulTidbits = new Dialogue(Player, Monster1);
			Dictionary<string, string> basic = new Dictionary<string, string>
            {
                { "cGreat", "\u001b[38;2;34;139;34m" },  // SeaGreen
                { "cGood", "\u001b[38;2;154;205;50m" },   // YellowGreen
                { "cOkay", "\u001b[38;2;240;230;140m" },  // Khaki
                { "cBad", "\u001b[38;2;233;150;122m" },   // DarkSalmon
                { "cTerrible", "\u001b[38;2;178;34;34m" } // FireBrick
            };
            const string Slate = "\u001b[38;2;151;135;250m";
            const string BurlyWood = "\u001b[38;2;222;184;135m";
            const string Moccasin = "\u001b[38;2;255;228;181m";
            const string BlanchedAlmond = "\u001b[38;2;0;139;139m";
            const string Reset = "\u001b[0m";
            Console.ReadKey(true);
			Console.WriteLine($"{BlanchedAlmond}\nYou explain that the premise of the game is simple. ");
			Console.ReadKey(true);
			Console.WriteLine("  You each have three coins from your pile, and behind your back " +
				"you have to close your fist around some number of them - anything " +
				"from three coins to no coins at all.");
			Console.ReadKey(true);
			Console.WriteLine("  Keeping your fist closed, you then hold it out with" +
				" everyone else, concealing how many coins you are holding in your" +
				" hand.");
			Console.ReadKey(true);
			Console.WriteLine("\n  You then take it in turns to guess how many coins," +
				" in total, are being held by everyone.");
			Console.ReadKey(true);
			Console.WriteLine($"  The player who guesses correctly wins...{Reset}");
			Console.ReadKey(true);
			Console.WriteLine("The gnoll and the goblin permit you to start for the first round.");
			int turns = 0;
			int who = turns % 3;
			int playerHand = 0;
			int goblinHand = 0;
			int gnollHand = 0;
			int first = 0;
			int game = 0;
			int playerGuess = 0;
			int goblinGuess = 0;
			int gnollGuess = 0;
			int pastHand = -1;
			bool lastGame = false;
			bool end = false;
            List<string> choices = new List<string>
            {
                "Actually, you decide to keep quiet and play the game...",
                "You nonchalantly inquire if either of them has ever seen this 'CurseBreaker' they all serve...",
                "You openly wonder if there are any better weapons - other than the ones in the enchanted cabinet, you mean...",
                "You furtively question who would employ their ragtag team of swords-for-hire...",
                "You wonder aloud what they're even supposed to be doing in this place...",
                "You casually ponder where the CurseBreaker might happen to be...",
                "You ask what this whole place used to be, before it was, uh... repurposed?"
            };
            if (Player.Inventory.Contains(musicBox))
            {
                choices.Add("You airily voice your curiosity as to why the other goblin had some sort of obsessive hatred for... was it... a music box?");
            }
            if (journal.SpecifyAttribute == "read")
            {
                choices.Add("You openly wonder where they're keeping Merigold...");
            }
            if (strangeMosaic.SpecificAttribute == "unstudied")
            {
                choices.Add("You inquire where exactly they are anyway???");
            }
            while (Player.Coins > 0 && !end)
			{
                playerGuess = -1;
                goblinGuess = -1;
                gnollGuess = -1;
                who = turns % 3;
				if (who == first%3 && game != 3)
				{
					Console.WriteLine($"{BurlyWood}How many of your three coins would you like to hold in your hand?{Reset}");

					do
					{

						playerHand = Dialogue.getIntResponse(4, true, 0);
						if (playerHand == pastHand)
						{
							Console.WriteLine($"{basic["cBad"]}Sorry, you can't choose the same number twice in a row...{Reset}\nPlease select a different number of coins.");
						}
					} while (playerHand == pastHand);
                    pastHand = playerHand;
                    Console.WriteLine($"{BlanchedAlmond}\nYou slyly shift around the coins behind your back before reaching out with your fist.{Reset}");
					Console.ReadKey(true);
					game++;
					turns++;
					continue;
				}
				else if (who == (first + 1)%3 && game != 3)
				{
					Console.WriteLine($"{BlanchedAlmond}\nThe goblin slyly makes to shift around the coins behind its back, before holding out a gnarled and grotty fist... {Reset}");
					Console.ReadKey(true);
					goblinHand = Coin.Roll(Coin) - 1;
					turns++;
					game++;
					continue;
				}
				else if (who == (first + 2)%3 && game != 3)
				{
					Console.WriteLine($"{BlanchedAlmond}\nThe gnoll rather clumsily shuffles its coins behind its back before holding out a furry fist... {Reset}");
					Console.ReadKey(true);
					gnollHand = Coin.Roll(Coin) - 1;
					turns++;
					game++;
					continue;
				}
				else
				{
					int first1 = first%3;
					while (first1 < first%3 + 3)
					{
						if (first1 % 3 == 0)
						{
							Console.WriteLine($"{Slate}Its your turn to guess how many coins everyone's holding in total... {Reset}");
							bool i = false;
							while (playerGuess == gnollGuess || playerGuess == goblinGuess || playerGuess == -1)
							{
								if (i)
								{
									Console.WriteLine($"{basic["cBad"]}You must select a number the other two players haven't picked!{Reset}");
								}
								playerGuess = Dialogue.getIntResponse(10, true, 0);
								i = true;
							}
							Console.WriteLine($"\nYou call out that you think there are{basic["cGood"]} {playerGuess} coins{Reset} in play...");
							Console.ReadKey(true);
						}
						else if (first1 % 3 == 1)
						{
							Console.WriteLine($"{Slate}The sly goblin scratches its noggin as it thinks up its guess...{Reset}");
							if (playerGuess != -1 && gnollGuess != -1)
							{
								double average = 3 + goblinHand;
								double guess = 0;
								double guess1 = 0;
								string gnollString = gnollGuess.ToString();
								double.TryParse(gnollString, out guess);
								guess -= average;
								if (guess > 0.5)
								{
									average = 4 + goblinHand - (Coin.Roll(Coin) - 1) / 2;
								}
								else if (guess < -0.5)
								{
									average = 2 + goblinHand + (Coin.Roll(Coin) - 1) / 2;
								}
								else
								{
									average = 3 + goblinHand;
								}
								guess = 0;
								string playerString = playerGuess.ToString();
								double.TryParse(playerString, out guess);

								guess -= average - goblinHand + 1.5;
								if (guess > 0.5)
								{
									if (average > 5)
									{
										average = 5 + goblinHand + (Coin.Roll(Coin) - 1) / 2;
									}
									else if (average < 4)
									{
										average = 3 + goblinHand - (Coin.Roll(Coin) - 1) / 2;
									}
									else
									{
										average = 3 + goblinHand + (Coin.Roll(Coin) - 1) / 2;
									}
								}
								else if (guess < 0.5)
								{
									if (average > 5)
									{
										average = 3 + goblinHand - (Coin.Roll(Coin) - 1) / 2;
									}
									else if (average < 4)
									{
										average = 1 + goblinHand - (Coin.Roll(Coin) - 1) / 2;
									}
									else
									{
										average = 3 + goblinHand + (Coin.Roll(Coin) - 1) / 2;
									}
								}
								int answer = int.Parse(average.ToString());
								Console.ReadKey(true);
								goblinGuess = answer;
                                int t = 0;
                                while (goblinGuess == playerGuess || goblinGuess == gnollGuess)
                                {
                                    if (goblinGuess < 5 + t)
                                    {
                                        goblinGuess++;
                                        t++;
                                    }
                                    else if (goblinGuess > 4 - t)
                                    {
                                        goblinGuess--;
                                        t++;
                                    }
                                }
                                Console.WriteLine($"\nThe goblin calls out that the total in play is {basic["cGood"]}{goblinGuess} coins{Reset}!");
							}
							else if (playerGuess != -1)
							{
                                double average = 3 + goblinHand;
                                double guess = 0;
                                double guess1 = 0;
                                string playerString = playerGuess.ToString();
                                double.TryParse(playerString, out guess);
                                guess -= average;
                                if (guess > 0.5)
                                {
                                    average = 4 + goblinHand - Coin.Roll(Coin) / 2;
                                }
                                else if (guess < -0.5)
                                {
                                    average = 2 + goblinHand + Coin.Roll(Coin) / 2;
                                }
                                else
                                {
                                    average = 3 + goblinHand;
                                }
                                int answer = int.Parse(average.ToString());
                                Console.ReadKey(true);
								goblinGuess = answer;
								int t = 0;
                                while (goblinGuess == playerGuess || goblinGuess == gnollGuess)
                                {
                                    if (goblinGuess < 5 + t)
                                    {
                                        goblinGuess++;
										t++;
                                    }
                                    else if (goblinGuess > 4 - t)
                                    {
                                        goblinGuess--;
										t++;
                                    }
                                }
                                Console.WriteLine($"\nThe goblin calls out that the total in play is {basic["cGood"]}{goblinGuess} coins{Reset}!");
                            }
							else
							{
                                int average = 3 + goblinHand;
								int chance = Coin.Roll(Coin);
								if (chance < 2)
								{
									average += Coin.Roll(Coin)/2;
								}
								else
								{
									average -= Coin.Roll(Coin)/2;
								}
                                int answer = int.Parse(average.ToString());
                                Console.ReadKey(true);
								goblinGuess = answer;
                                int t = 0;
                                while (goblinGuess == playerGuess || goblinGuess == gnollGuess)
                                {
                                    if (goblinGuess < 5 + t)
                                    {
                                        goblinGuess++;
                                        t++;
                                    }
                                    else if (goblinGuess > 4 - t)
                                    {
                                        goblinGuess--;
                                        t++;
                                    }
                                }
                                Console.WriteLine($"\nThe goblin calls out that the total in play is {basic["cGood"]}{goblinGuess} coins{Reset}!");
                            }
                            
						}
						else
						{
                            Console.WriteLine($"\n{Slate}The clueless gnoll thinks up its guess...{Reset}");
                            if (playerGuess != -1 && goblinGuess != -1)
                            {
                                double average = 3 + gnollHand;
                                double guess = 0;
                                double guess1 = 0;
                                string playerString = playerGuess.ToString();
                                double.TryParse(playerString, out guess);
                                guess -= average;
                                if (guess > 0.5)
                                {
                                    average = 4 + gnollHand - (Coin.Roll(Coin) - 1) / 2;
                                }
                                else if (guess < -0.5)
                                {
                                    average = 2 + gnollHand + (Coin.Roll(Coin) - 1) / 2;
                                }
                                else
                                {
                                    average = 3 + gnollHand;
                                }
                                guess = 0;
                                string goblinString = goblinGuess.ToString();
                                double.TryParse(goblinString, out guess);

                                guess -= average - gnollHand + 1.5;
                                if (guess > 0.5)
                                {
                                    if (average > 5)
                                    {
                                        average = 5 + gnollHand + (Coin.Roll(Coin) - 1) / 2;
                                    }
                                    else if (average < 4)
                                    {
                                        average = 3 + gnollHand - (Coin.Roll(Coin)) / 2;
                                    }
                                    else
                                    {
                                        average = 3 + gnollHand + (Coin.Roll(Coin)) / 2;
                                    }
                                }
                                else if (guess < 0.5)
                                {
                                    if (average > 5)
                                    {
                                        average = 3 + gnollHand - (Coin.Roll(Coin)) / 2;
                                    }
                                    else if (average < 4)
                                    {
                                        average = 1 + gnollHand - (Coin.Roll(Coin) - 1) / 2;
                                    }
                                    else
                                    {
                                        average = 3 + gnollHand + (Coin.Roll(Coin)) / 2;
                                    }
                                }
                                int answer = int.Parse(average.ToString());
                                Console.ReadKey(true);
								gnollGuess = answer;
								int t = 0;
                                while (gnollGuess == playerGuess || gnollGuess == goblinGuess)
                                {
                                    if (gnollGuess < 5 + t)
                                    {
                                        gnollGuess++;
										t++;
                                    }
                                    else if (gnollGuess > 4 - t)
                                    {
                                        gnollGuess--;
										t++;
                                    }
                                }
								Console.WriteLine($"\nThe gnoll barks a series of gargled sounds... You look to the goblin, puzzled.");
								Console.ReadKey(true);
								Console.WriteLine($"\n\t'It says the total coins in play is{basic["cGood"]} {gnollGuess}{Reset},' the goblin translates.\n\nOh...");
                            }
                            else if (goblinGuess != -1)
                            {
                                double average = 3 + gnollHand;
                                double guess = 0;
                                double guess1 = 0;
                                string goblinString = goblinGuess.ToString();
                                double.TryParse(goblinString, out guess);
                                guess -= average;
                                if (guess > 0.5)
                                {
                                    average = 4 + gnollHand + Coin.Roll(Coin) / 2;
                                }
                                else if (guess < -0.5)
                                {
                                    average = 2 + gnollHand - Coin.Roll(Coin) / 2;
                                }
                                else
                                {
                                    average = 3 + gnollHand;
                                }
                                int answer = int.Parse(average.ToString());
                                Console.ReadKey(true);
								gnollGuess = answer;
                                int t = 0;
                                while (gnollGuess == playerGuess || gnollGuess == goblinGuess)
                                {
                                    if (gnollGuess < 5 + t)
                                    {
                                        gnollGuess++;
                                        t++;
                                    }
                                    else if (gnollGuess > 4 - t)
                                    {
                                        gnollGuess--;
                                        t++;
                                    }
                                }
								Console.WriteLine($"\nThe gnoll issues a series of incomprehensible yaps. You look to the goblin questioningly.");
								Console.ReadKey(true);
								Console.WriteLine($"\n\t'It says it thinks there are{basic["cGood"]} {gnollGuess} coins{Reset}, don't it!' the goblin answers as though it were obvious. The gnoll bobs its head in agreement.\n\nOh, alright then...");
                            }
                            else
                            {
                                int average = 3 + gnollHand;
                                int chance = Coin.Roll(Coin);
                                if (chance < 2)
                                {
                                    average += Coin.Roll(Coin) / 2 + 1;
                                }
                                else
                                {
                                    average -= Coin.Roll(Coin) / 2 + 1;
                                }
                                int answer = int.Parse(average.ToString());
                                Console.ReadKey(true);
								gnollGuess = answer;
                                int t = 0;
                                while (gnollGuess == playerGuess || gnollGuess == goblinGuess)
                                {
                                    if (gnollGuess < 5 + t)
                                    {
                                        gnollGuess++;
                                        t++;
                                    }
                                    else if (gnollGuess > 4 - t)
                                    {
                                        gnollGuess--;
                                        t++;
                                    }
                                }
								Console.WriteLine($"\nThe gnoll issues a series of incomprehensible yaps. You look to the goblin questioningly.");
								Console.ReadKey(true);
								Console.WriteLine($"\n\t'It says it thinks there are{basic["cGood"]} {gnollGuess} coins{Reset}, don't it!' the goblin answers as though it were obvious. The gnoll bobs its head in agreement.\n\nOh, alright then...");
                            
							}
                        }
						first1++;
					}
					first++;
					game = 0;

				}
				Console.ReadKey(true);
				Console.WriteLine($"\n{BurlyWood}You each unfurl your hands and show your coins...{Reset}");
				Console.ReadKey(true);
				int total = gnollHand + goblinHand + playerHand;
				Console.WriteLine($"You reveal that you had {basic["cGood"]}{playerHand} coins{Reset}...");
				Console.ReadKey(true);
				Console.WriteLine($"The goblin unfurls its fist to display{basic["cGood"]} {goblinHand} coins{Reset}...");
				Console.ReadKey(true);
				Console.WriteLine($"The gnoll's fist opens to show{basic["cGood"]} {gnollHand} coins{Reset}...");
				Console.ReadKey(true);
				if (total == playerGuess)
				{
					if (!lastGame)
					{
						Console.WriteLine($"{Slate}Congratulations! You win! {Reset}");
						Console.ReadKey(true);
						Player.Coins += goblinHand;
						Player.Coins += gnollHand;
						Monster1.Coins -= goblinHand;
						Monster2.Coins -= gnollHand;
						Console.WriteLine("\t\tWINNINGS");
						Console.WriteLine($"YOU: {Player.Coins} || GOBLIN: {Monster1.Coins} || GNOLL: {Monster2.Coins}");
						Console.ReadKey(true);
					}
					else
					{
						Console.WriteLine($"{Slate}Congratulations! You've won the goblin and gnoll's special trinkets!{Reset}");
						Console.ReadKey(true);
						Console.WriteLine($"{Slate}They are grudgingly handed over to you before the gnoll and goblin both decide they've had enough.");
						Console.ReadKey(true);
						Console.WriteLine("They depart in a murmur of mutinous grumblings, leaving you alone at last in the armoury...");
						Console.ReadKey(true);
						foreach (Item i in Monster1.Items)
						{
							if (i.Name.Contains("MG"))
							{
								i.StudyItem(i, Player);
                                Console.WriteLine("You stow it away in your backpack.");
                                Console.ReadKey(true);
								Player.Inventory.Add(i);
								break;
							}
						}
						foreach (Item i in Monster2.Items)
						{
							if (i.Name.Contains("MG"))
							{
                                i.StudyItem(i, Player);
								Console.WriteLine("You stash it in your backpack.");
                                Console.ReadKey(true);
                                Player.Inventory.Add(i);
								break;
							}
						}
						return new List<int> { Player.Coins, Monster1.Coins, Monster2.Coins };
					}
					Dictionary<string, string> choices_answers = new Dictionary<string, string> 
					{
						{
							"You nonchalantly inquire if either of them has ever seen this 'CurseBreaker' they all serve...",
						
							"The gnoll and the goblin abruptly pause, sharing looks that can only be described as darkly foreboding and secretly fearful. \n" +
							"Within the silence you ask why the long looks?\n" +
							"\t'Neither of us 'ave seen the master,' the goblin intones, its beady, glinting eyes locking with yours, 'But our commander-in-chief has.'" +
							"\n  The gnoll yips its agreement." +
							"\n  You turn from one to the other, still nonplussed as to their dark reactions, before the goblin continues with a shudder, 'the stories you hear about him... It's enough to make your blood run cold.'" +
							"\n  The gnoll whimpers. " +
							"\n  A knot of trepidation tying itself in your stomach, you nevertheless pry further." +
							"\n  The goblin whispers only, 'The master's eyes... black as coals they are, and said to see far more than normal eyes can. Far deeper. Said to see secrets...' \n" +
							"\n  The goblin says no more and you finish collecting your coins... "
						},
						{
                            "You openly wonder if there are any better weapons - other than the ones in the enchanted cabinet, you mean...",

							"\n\t'Pfft,' the goblin snorts, 'around here? not likely. Not unless you count the one that musclebound freak lugs around...'" +
							"\n  You react quizzically at mention of this 'musclebound freak'." +
							"\n\t'I mean the blahdy minotaur, don't I?' the goblin retorts exasperatedly. 'The one that stomps through this place and guards Merigold. It always gets the best weapons. The best loot an' all. Only weapons we got access to are the ones over there,' he points vaguely towards another, far more unimpressive-looking cabinet, 'Weapons in there ain't up to much mind...'" +
							"\n\n  Hmmm..."
                        },
						{
                            "You furtively question who would employ their ragtag team of swords-for-hire...",

							"'Wot you mean, who'd hire us?' the goblin retorts. 'Why the master hires us of course...'" +
							"\n You are about to briskly change topic, steering away from your blunder, but the goblin and gnoll's expressions have" +
							" already curdled into open suspicion." +
							"\n\t'Here, wots your game, eh?' the goblin interrogates, hostility crackling beneath the surface of civility. 'Wot sort of question is that?' he lets loose a mirthless laugh, one that doesn't reach his beady, murderous eyes. 'Why,' he says, 'It almost sounds like the sort of question a spy would ask..." +
							"\n  'Or maybe some clueless escapee...' the goblin shrewdly lands his suspicions upon the right answer, and your paling expression shows it." +
							"\n \n There's nothing for it.\n You're going to have to fight..."
                        },
						{
                            "You wonder aloud what they're even supposed to be doing in this place...",

							"\t'In this armoury, you mean,' the goblin grunts. 'Not much. Merigold is being guarded by that lumbering monstrosity. We're just supposed to take turns watching to make sure the prisoners don't escape...'" +
							"\n  You involuntarily let out a nervous sputtering cough. The goblin dishes you a strange look." +
							"\n\t'Anyway,' it continues as though you hadn't interrupted him, 'Our chance at glory is still to come, ain't it - so the master says.' The goblin seems to puff up his chest as he swells with pride. 'Apparently, we're instroo-mental to his schemes for this evening - says he needs brave troops like us when midnight comes...'" +
							"\n\t The gnoll issues a string of garbled grunts and barks that are indecipherable to you." +
							"\n  The goblin's rebuke is blunt. 'No, a'course the master didn't say 'dupes', he said 'troops'. 'cause that's wot we are, innit. Troops...right?'" +
							"\n You merely offer a noncommittal shrug as you finish raking in your winnings..."
                        },
						{
                            "You casually ponder where the CurseBreaker might happen to be...",

							"The goblin gives a cursory glance over its shoulder, before returning a shrug. 'Not arounds here,' he replies unhelpfully. " +
							"\n  He seems all too relieved by that fact too..."
						},
						{
                            "You ask what this whole place used to be, before it was, uh... repurposed?",

							"\t'Wot do you mean, wot did this place used to be?' the goblin retorts. 'It's Merigold's tower, ain't it - or, no, I mean to say it's the *Master's* tower now, don't I?' He peers at you quizzically, openly wondering how that fact could possibly have escaped one of their own..." +
							"\n  Feeling the penny about to drop, you quickly change the subject back to the game at hand.\n" +
							"The goblin continues to dish you some icy appraise for a moment, but soon seems distracted by the opportunity of winning more coins..." +
							"\n\n  That was too close! You determine to be more discriminating with your questions in future..."
                        },
						{
                            "You airily voice your curiosity as to why the other goblin had some sort of obsessive hatred for... was it... a music box?",

							"\t'Oh, that thing...' the goblin huffs, 'None of us like that music box's tune, but its worse than all that...'" +
							"\n  You ask what the goblin means. " +
							"\n\t'The musclebound freak yonder,' he jabs a thumb at the RmorRee door. 'That beast can't get enough of the damn tune. Wherever that music box is left playing, that lumbering thing is sure to follow and be captee-vated by it. And that beast is worse company than... well...' the goblin dishes a reproachful sideways glance at the slavering gnoll, currently vapidly drooling over its mound of coins. " +
							"\n\n  Hmmm..."
                        },
						{
                            "You openly wonder where they're keeping Merigold...",

							"The gnoll and goblin freeze, suddenly shooting daggers your way." +
							"\nIt seems every mercenary knows the answer to that question... except you." +
							"\n Muderous eyes glinting, your opponents rise from their seats and draw their weapons. " +
							"\n\nIt looks like you'll have to fight..."
                        },
						{
                            "You inquire where exactly they are anyway???",

							"The gnoll and goblin seem taken aback by how you seem to be as ignorant as... ooh, i dunno, say... one of their prisoners?" +
							"\n  It doesn't take long for that surprise to sour into open distrust. They share a knowing glance, right before they each rise from their seat and draw their weapons." +
							"\n\n Drat! It looks like you'll have to fight your way out..."
                        },
						{
                            "Actually, you decide to keep quiet and play the game...",

							""
                        }

					};
					// the minotaur's obsession with the music box, ever seen the curseBreaker?,
					// where do they keep any good weapons, merigold's location(if journal studied),
					// if not explored strange mosaic where they are, who employs mercenary company,
					// what they're doing in this place, where to find the curseBreaker,
					// what did this place used to be
					

					string description = "Taking your time to collect your coins, you decide to pose the dubious duo a question.";
					string parlance = "Just be sure, as you take this opportunity to carefully pry, to not reveal who you really are...";
					if (!lastGame)
					{
						string response = usefulTidbits.LoopParle(choices_answers, choices, description, parlance);
						if (response.Contains("Merigold") || response.Contains("???") || response.Contains("ragtag"))
						{
							return new List<int> { -1 };
						}
						else if(response.Contains("Actually, "))
						{
							
						}
						else
						{
							choices.Remove(response);
						}
					}
					
                }
                else if(total == goblinGuess)
                {
					Console.WriteLine($"{Slate}The goblin cheers as he rakes in all the coins...{Reset}");
					Console.ReadKey(true);
					Monster1.Coins += gnollHand;
					Monster1.Coins += playerHand;
					Monster2.Coins -= gnollHand;
					Player.Coins -= playerHand;
                    Console.WriteLine("\t\tWINNINGS");
                    Console.WriteLine($"YOU: {Player.Coins} || GOBLIN: {Monster1.Coins} || GNOLL: {Monster2.Coins}");
                    Console.ReadKey(true);
                }
				else if (total == gnollGuess)
				{
                    Console.WriteLine($"{Slate}The gnoll roars in triumph as it sweeps all the coins into its pile...{Reset}");
                    Console.ReadKey(true);
                    Monster2.Coins += goblinHand;
                    Monster2.Coins += playerHand;
                    Monster1.Coins -= goblinHand;
                    Player.Coins -= playerHand;
                    Console.WriteLine("\t\tWINNINGS");
                    Console.WriteLine($"YOU: {Player.Coins} || GOBLIN: {Monster1.Coins} || GNOLL: {Monster2.Coins}");
                    Console.ReadKey(true);
                }
				else
				{
					Console.WriteLine($"\n{basic["cBad"]}Nobody wins. You each play again...{Reset}");
					Console.ReadKey(true);
				}
				if((Monster1.Coins < 10 || Monster2.Coins < 10) && !lastGame)
				{
					Monster monster = Monster1;
					if(Monster2.Coins < 10)
					{
						monster = Monster2;
					}
					Item item = monster.Items[0];
					foreach (Item i in monster.Items) 
					{ 
						if (i.Name.Contains("MG"))
						{
							item = i;
						}
					}
					Console.WriteLine($"{BlanchedAlmond}With {monster.Name} strapped for cash, desperation sinks in. It fronts its {item.Name}. Following suit, it's partner does likewise with a similar trinket.\nIf you win this last round, you get to keep it. \n\nIt doesn't look like much, but some instincts stirs, telling you it is more than what it appears to be...");
					lastGame = true;
					continue;
				}
				if (lastGame)
				{
					end = true;
					continue;
				}
            }
			
			Console.WriteLine("Game end.");
			Console.ReadKey(true);
			return new List<int> { Player.Coins, Monster1.Coins, Monster2.Coins };

		}
	}
}
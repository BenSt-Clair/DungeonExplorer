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
    }
}

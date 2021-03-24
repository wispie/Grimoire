using Grimoire.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdGotoPlayer : IBotCommand
    {
        public string PlayerName
        {
            get;
            set;
        }

        public async Task Execute(IBotEngine instance)
        {
            List<string> playersInMap = World.PlayersInMap;
            Player.GoToPlayer(PlayerName);
            if (playersInMap.Any((string p) => p.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)))
            {
                await Task.Delay(500);
            }
            else
            {
                await instance.WaitUntil(() => World.PlayersInMap.Any((string p) => p.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)) && !World.IsMapLoading, null, 40);
            }
        }

        public override string ToString()
        {
            return "Goto player: " + PlayerName;
        }
    }
}
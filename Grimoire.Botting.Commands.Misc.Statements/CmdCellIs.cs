using Grimoire.Game;
using System;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdCellIs : StatementCommand, IBotCommand
    {
        public CmdCellIs()
        {
            Tag = "Map";
            Text = "Cell is";
        }

        public Task Execute(IBotEngine instance)
        {
            if (!Value1.Equals(Player.Cell, StringComparison.OrdinalIgnoreCase))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return "Cell is: " + Value1;
        }
    }
}
using Grimoire.Game;
using System;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdMapIs : StatementCommand, IBotCommand
    {
        public CmdMapIs()
        {
            Tag = "Map";
            Text = "Map is";
        }

        public Task Execute(IBotEngine instance)
        {
            if (!(Value1.Contains("-") ? Value1.Split('-')[0] : Value1).Equals(Player.Map, StringComparison.OrdinalIgnoreCase))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return "Map is: " + Value1;
        }
    }
}
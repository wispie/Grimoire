using Grimoire.Game;
using Grimoire.Game.Data;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdFactionRankLessThan : StatementCommand, IBotCommand
    {
        public CmdFactionRankLessThan()
        {
            Tag = "This player";
            Text = "Faction Rank is less than";
        }

        public Task Execute(IBotEngine instance)
        {
            if (Player.Factions.Find((Faction m) => m.Name == Value1).Rank >= int.Parse(Value2))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return $"{Value1} Rank is less than: {Value2}";
        }
    }
}
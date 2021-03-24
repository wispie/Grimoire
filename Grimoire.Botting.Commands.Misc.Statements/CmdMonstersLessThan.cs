using Grimoire.Game;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdMonstersLessThan : StatementCommand, IBotCommand
    {
        public CmdMonstersLessThan()
        {
            Tag = "Monster";
            Text = "Count is less than";
        }

        public Task Execute(IBotEngine instance)
        {
            if (World.VisibleMonsters.Count >= int.Parse(Value1))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return "Monster count is less than: " + Value1;
        }
    }
}
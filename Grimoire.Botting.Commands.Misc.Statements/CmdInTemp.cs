using Grimoire.Game;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdInTemp : StatementCommand, IBotCommand
    {
        public CmdInTemp()
        {
            Tag = "Item";
            Text = "Is in temp inventory";
        }

        public Task Execute(IBotEngine instance)
        {
            if (!Player.TempInventory.ContainsItem(Value1, Value2))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return $"Is in temp inventory: {Value1}, {Value2}";
        }
    }
}
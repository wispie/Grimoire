using Grimoire.Game;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdInInventory : StatementCommand, IBotCommand
    {
        public CmdInInventory()
        {
            Tag = "Item";
            Text = "Is in inventory";
        }

        public Task Execute(IBotEngine instance)
        {
            if (!Player.Inventory.ContainsItem(Value1, Value2))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return $"Is in inventory: {Value1}, {Value2}";
        }
    }
}
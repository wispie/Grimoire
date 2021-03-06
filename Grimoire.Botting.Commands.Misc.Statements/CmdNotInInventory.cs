using Grimoire.Game;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdNotInInventory : StatementCommand, IBotCommand
    {
        public CmdNotInInventory()
        {
            Tag = "Item";
            Text = "Is not in inventory";
        }

        public Task Execute(IBotEngine instance)
        {
            if (Player.Inventory.ContainsItem(Value1, Value2))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return "Item is not in inventory: " + Value1 + ", " + Value2;
        }
    }
}
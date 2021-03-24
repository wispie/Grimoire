using Grimoire.Game;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdIntLessThan : StatementCommand, IBotCommand
    {
        public CmdIntLessThan()
        {
            Tag = "Misc";
            Text = "Int Lesser Than";
        }

        public Task Execute(IBotEngine instance)
        {
            if (Configuration.Tempvalues[Value1] > int.Parse(Value2))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return $"{Value1} < {Value2}";
        }
    }
}
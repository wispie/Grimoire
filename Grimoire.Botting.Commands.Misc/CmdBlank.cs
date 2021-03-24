using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdBlank : IBotCommand
    {
        public async Task Execute(IBotEngine instance)
        {
        }

        public override string ToString()
        {
            return "";
        }
    }

    public class CmdBlank2 : IBotCommand
    {
        public async Task Execute(IBotEngine instance)
        {
        }

        public string Text
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
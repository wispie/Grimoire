using Grimoire.Game;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdQuestNotInProgress : StatementCommand, IBotCommand
    {
        public CmdQuestNotInProgress()
        {
            Tag = "Quest";
            Text = "Quest is not in progress";
        }

        public Task Execute(IBotEngine instance)
        {
            if (Player.Quests.IsInProgress(int.Parse(Value1)))
            {
                instance.Index++;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return "Quest is not in progress: " + Value1;
        }
    }
}
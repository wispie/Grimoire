using Grimoire.Game;
using System;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Map
{
    public class CmdMoveToCell : IBotCommand
    {
        public string Cell
        {
            get;
            set;
        }

        public string Pad
        {
            get;
            set;
        }

        public async Task Execute(IBotEngine instance)
        {
            BotData.BotState = BotData.State.Others;
            while (!Player.Cell.Equals(Cell, StringComparison.OrdinalIgnoreCase))
            {
                Player.MoveToCell(Cell, Pad);
                await Task.Delay(500);
            }
            BotData.BotCell = Cell;
            BotData.BotPad = Pad;
        }

        public override string ToString()
        {
            return "Move to cell: " + Cell + ", " + Pad;
        }
    }
}
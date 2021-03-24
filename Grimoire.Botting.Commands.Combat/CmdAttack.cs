using System;
using System.Threading.Tasks;
using Grimoire.Botting;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Combat
{
    public class CmdAttack : IBotCommand
    {
        public string Monster
        {
            get;
            set;
        }

        public async Task Execute(IBotEngine instance)
        {
            Player.AttackMonster(Monster);
        }

        // Token: 0x0600000C RID: 12 RVA: 0x000020ED File Offset: 0x000002ED
        public override string ToString()
        {
            return "Attack " + this.Monster;
        }
    }
}
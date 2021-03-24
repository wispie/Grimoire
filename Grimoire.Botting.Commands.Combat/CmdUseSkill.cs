using System;
using System.Threading.Tasks;
using Grimoire.Botting;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Combat
{
    // Token: 0x02000002 RID: 2
    public class CmdUseSkill : IBotCommand
    {
        public string Skill { get; set; }
        
        public string Index { get; set; }
        
        public int SafeHp { get; set; }
        
        public int SafeMp { get; set; }
        
        public bool Wait { get; set; }
        
        public async Task Execute(IBotEngine instance)
        {
            if (this.Wait)
            {
                await Task.Delay(Player.SkillAvailable(this.Index));
            }
            if (Player.Health / (double)Player.HealthMax * 100.0 <= SafeHp)
            {
                if (Player.Mana / (double)Player.ManaMax * 100.0 <= SafeMp)
                {
                    if (this.Index != "5")
                    {
                        Player.AttackMonster("*");
                    }
                    Player.UseSkill(this.Index);
                }
            }
        }

        // Token: 0x0600000C RID: 12 RVA: 0x000020ED File Offset: 0x000002ED
        public override string ToString()
        {
            return "Skill " + this.Skill;
        }
    }
}
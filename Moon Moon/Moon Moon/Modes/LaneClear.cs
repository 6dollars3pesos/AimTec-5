using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;


namespace Moon_Moon
{
    internal partial class Diana
    {
        public void DoLaneClear()
        {
            bool Qmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Wmana = MyHero.Mana> MyHero.SpellBook.GetSpell(SpellSlot.W).Cost;
            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(1400)))
            {
                if (minion == null || !minion.IsValid)
                {
                    return;
                }
                if (RootM["farm"]["laneclear"]["useQ"].As<MenuBool>().Enabled && Q.Ready && Qmana)
                {
                    CastQ(minion);
                }
                    if (RootM["farm"]["laneclear"]["useW"].As<MenuBool>().Enabled && W.Ready && Wmana)
                {
                    if (GameObjects.EnemyMinions.Count(t => t.IsValidTarget(W.Range, false, false,MyHero.ServerPosition)) >= RootM["farm"]["laneclear"]["wcount"].As<MenuSliderBool>().Value)
                    {
                        CastW();
                    }
                }
            }
        }
    }
}

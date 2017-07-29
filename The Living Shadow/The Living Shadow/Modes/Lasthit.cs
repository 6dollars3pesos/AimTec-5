using System;
using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;

namespace The_Living_Shadow
{
    internal partial class Zed
    {
        public void DoLastHit()
        {
            bool Qmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Emana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.E).Cost;
            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(900) && m.IsMinion))
            {
                double Qdamage = MyHero.GetSpellDamage(minion, SpellSlot.Q);
                double Edamage = MyHero.GetSpellDamage(minion, SpellSlot.E);
                if (RootM["farm"]["lasthit"]["useQ"].As<MenuBool>().Enabled && Qdamage > minion.Health && Q.Ready && Qmana)
                {
                    Q.Cast(minion);
                }
                if (RootM["farm"]["lasthit"]["useE"].As<MenuBool>().Enabled && Edamage > minion.Health && E.Ready && minion.IsValidTarget(E.Range) && Emana)
                {
                    E.Cast();
                }
            }
        }
    }
}


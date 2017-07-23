﻿using System;
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
            bool Qmana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Emana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.E).Cost;
            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(900)))
            {
                double Qdamage = MyHero.GetSpellDamage(minion, SpellSlot.Q);
                double Edamage = MyHero.GetSpellDamage(minion, SpellSlot.E);
                Console.WriteLine(Qdamage);
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

﻿using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.Util.Cache;
using System.Linq;

namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        #region Killstea part
        public void DoKillSteal()
        {
            if (!RootM["killsteal"]["ks"].As<MenuBool>().Enabled)
            {
                return;
            }
            foreach (var hptarget in GameObjects.EnemyHeroes.Where(a => a.IsValidTarget(1200) && !a.IsDead))
            {
                if (!hptarget.IsValid || hptarget.IsDead || hptarget == null)
                {
                    return;
                }
                var Health = hptarget.Health;
                var dmgE = MyHero.GetSpellDamage(hptarget, SpellSlot.E);
                if (MyHero.Distance(hptarget) < E.Range && Health < dmgE && !GlobalKeys.ComboKey.Active &&
                    RootM["killsteal"]["useE"].As<MenuBool>().Enabled)
                {
                    CastE(hptarget.ServerPosition);
                }
                var dmgQ = MyHero.GetSpellDamage(hptarget, SpellSlot.Q);
                if (MyHero.Distance(hptarget) < Q.Range && Health < dmgQ && !GlobalKeys.ComboKey.Active &&
                    RootM["killsteal"]["useQ"].As<MenuBool>().Enabled)
                {
                    CastQ(hptarget);
                }
                var dmgW = MyHero.GetSpellDamage(hptarget, SpellSlot.W);
                if (MyHero.Distance(hptarget) < W.Range && Health < dmgW && !GlobalKeys.ComboKey.Active &&
                    RootM["killsteal"]["useW"].As<MenuBool>().Enabled)
                {
                    W.Cast(hptarget);
                }
                var dmgR = MyHero.GetSpellDamage(hptarget, SpellSlot.Q);
                if (MyHero.Distance(hptarget) < Q.Range && Health < dmgR && !GlobalKeys.ComboKey.Active &&
                    RootM["killsteal"]["useR"].As<MenuBool>().Enabled)
                {
                    CastR(hptarget);
                }
                if (!IsIgnite) continue;
                var dmgI = (50 + ((MyHero.Level) * 20));
                if (MyHero.Distance(hptarget) < Q.Range && Health < dmgI && !GlobalKeys.ComboKey.Active &&
                    RootM["killsteal"]["useI"].As<MenuBool>().Enabled)
                {
                    Ignite.CastOnUnit(hptarget);
                }
                // this.DoOneShotCombo(hptarget);
            }


        }
        #endregion
    }
}

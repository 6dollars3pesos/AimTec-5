using System;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

using Aimtec.SDK.Util.Cache;
using System.Linq;
using Aimtec.SDK.Util;

namespace The_Living_Shadow
{
    internal partial class Zed
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
                if (!hptarget.IsValid || hptarget.IsDead || hptarget ==null)
                {
                    return;
                }
                var Health = hptarget.Health;
                var dmgE = MyHero.GetSpellDamage(hptarget, SpellSlot.E);
                if (MyHero.Distance(hptarget) < E.Range && Health < dmgE && !RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled &&
                    RootM["killsteal"]["useE"].As<MenuBool>().Enabled)
                {
                    this.CastE();
                }
                var dmgQ = MyHero.GetSpellDamage(hptarget, SpellSlot.Q);
                if (MyHero.Distance(hptarget) < Q.Range && Health < dmgQ && !RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled &&
                    RootM["killsteal"]["useQ"].As<MenuBool>().Enabled)
                {
                    this.CastQ(hptarget);
                }
                if (!IsIgnite) continue;
                var dmgI = (50 + ((MyHero.Level) * 20));
                if (MyHero.Distance(hptarget) < Q.Range && Health < dmgI && !RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled &&
                    RootM["killsteal"]["useI"].As<MenuBool>().Enabled)
                {
                    Ignite.CastOnUnit(hptarget);
                }
               // this.DoOneShotCombo(hptarget);
            }


        }
        #endregion
        #region oneshotcombo
        private Vector3 ShadowPosOneShotCombo;
        private double totaldamage;
        public void DoOneShotCombo(Obj_AI_Hero unit)
        {
            if (unit == null || !unit.IsValid)
            {
                return;
            }
            if (!Rpos.Equals(new Vector3()))
            {
                ShadowPosOneShotCombo = unit.ServerPosition.Extend(Rpos, 600);
            }
            double dmgQ = MyHero.GetSpellDamage(unit, SpellSlot.Q);
            double dmgW = MyHero.GetSpellDamage(unit, SpellSlot.W);
            double dmgE = MyHero.GetSpellDamage(unit, SpellSlot.E);
            double dmgR = MyHero.GetSpellDamage(unit, SpellSlot.R);
            totaldamage = dmgQ + dmgW + dmgE + dmgR;
            if (IsIgnite)
            {
                if (Ignite.Ready)
                {
                    var dmgI = (50 + ((MyHero.Level) * 20));
                    totaldamage += dmgI;
                }
            }
            if (totaldamage > unit.Health && MyHero.Mana > (MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost + MyHero.SpellBook.GetSpell(SpellSlot.W).Cost) +
                MyHero.SpellBook.GetSpell(SpellSlot.E).Cost + MyHero.SpellBook.GetSpell(SpellSlot.R).Cost &&
                RootM["killsteal"]["oneshot"]["oto"].As<MenuBool>().Enabled)
            {
                if (Q.Ready && W.Ready && E.Ready && R.Ready)
                {
                    if (RootM["killsteal"]["oneshot"]["oto"][unit.ChampionName.ToLower()].As<MenuBool>().Enabled)
                    {
                        if (MyHero.Distance(unit) < R.Range)
                        {
                            R.CastOnUnit(unit);
                        }
                        if (MyHero.Distance(unit) < W.Range)
                        {
                            if (!Rpos.Equals(new Vector3()) && Wpos.Equals(new Vector3()))
                            {
                                DelayAction.Queue(210, () => this.CastW(ShadowPosOneShotCombo));
                            }
                        }
                        if (!Wpos.Equals(new Vector3()))
                        {
                            if (MyHero.Distance(unit) < Q.Range)
                            {
                                this.CastQ(unit);
                            }
                        }
                        if (!Q.Ready && !W.Ready)
                        {
                            E.Cast();
                        }
                        if (IsIgnite && Ignite.Ready)
                        {
                            foreach (var tar in GameObjects.EnemyHeroes.Where(a => a.IsValidTarget(1200) && !a.IsDead))
                            {
                                var dmgI = (50 + ((MyHero.Level) * 20));
                                var health = tar.Health;
                                if (health < dmgI && MyHero.Distance(tar) < 600)
                                {
                                    Ignite.CastOnUnit(tar);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}

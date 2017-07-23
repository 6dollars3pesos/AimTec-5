using System;
using System.Linq;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;

namespace The_Living_Shadow
{
    internal partial class Zed
    {
        public void DoCombo()
        {
            var globalrange = RootM["combo"]["forcer"].As<MenuBool>().Enabled && R.Ready && this.IsR1() ? R.Range - 5 : Q.Range;
            if (target == null || !target.IsValid)
            {
                return;
            }
            var Wcastpos = new Vector3();

            if (!Rpos.Equals(new Vector3()))
            {
                switch (RootM["combo"]["rlogic"].As<MenuList>().Value)
                {
                    case 0:
                        Wcastpos = (target.ServerPosition + (target.ServerPosition - Rpos).Normalized() * 450);
                        break;
                    case 1:
                        Wcastpos = (target.ServerPosition + (target.ServerPosition - Rpos).Normalized() * 350).To2D().Perpendicular().To3D();
                        break;
                    case 2:
                        Wcastpos = Game.CursorPos;
                        break;
                }
            }
            if (MyHero.Distance(target) < globalrange)
            {
                if (MyHero.Distance(target) < R.Range &&
                    RootM["combo"]["useR"].As<MenuBool>().Enabled && !RootM["combo"]["blacklist"]["use" + target.ChampionName.ToLower()].As<MenuBool>().Enabled)
                {
                    this.CastR(target);
                }


                if (target.HasBuff("zedrtargetmark"))
                {
                    if (RootM["combo"]["useW"].As<MenuBool>().Enabled && MyHero.Distance(target) < W.Range)
                    {
                        this.CastW(Wcastpos);
                    }
                }
                else
                {
                    if (RootM["combo"]["useW"].As<MenuBool>().Enabled && !Rpos.Equals(new Vector3()) && MyHero.Distance(target) < W.Range && this.IsW1())
                    {
                        DelayAction.Queue(210, () => this.CastW(Wcastpos));
                    }

                    else if (MyHero.Distance(target) > W.Range && target.IsValidTarget(W.Range + Q.Range / 2) &&
                             RootM["combo"]["useW"].As<MenuBool>().Enabled)
                    {
                        var Wposition = MyHero.ServerPosition.Extend(target.ServerPosition, 700f);
                        this.CastW(Wposition);
                        if (RootM["combo"]["secondw"].As<MenuBool>().Enabled)
                        {
                            DelayAction.Queue(210, () => this.CastW2());
                        }
                    }
                }

                if (MyHero.Distance(target) < Q.Range && RootM["combo"]["useQ"].As<MenuBool>().Enabled)
                {
                    if (!Wpos.Equals(new Vector3()) && MyHero.SpellBook.GetSpell(SpellSlot.W).Name == "ZedW2")
                    {
                        this.CastQ(target);
                    }
                    else if (!W.Ready || MyHero.SpellBook.GetSpell(SpellSlot.W).Name != "ZedW2" || Wpos.Equals(new Vector3()))
                    {
                        this.CastQ(target);
                    }
                }

                if (RootM["combo"]["useE"].As<MenuBool>().Enabled)
                {
                    this.CastE();
                }

                if (W.Ready && RootM["combo"]["wgap"].As<MenuBool>().Enabled &&
                    target.IsValidTarget(1400) && !target.IsValidTarget(850)
                )
                {
                    var Wposition = MyHero.ServerPosition.Extend(target.ServerPosition, 700f);
                    W.Cast(Wposition);
                }

                if (IsIgnite)
                {
                    if (RootM["combo"]["useI"].As<MenuBool>().Enabled && RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled)
                    {
                        foreach (var tar in GameObjects.EnemyHeroes.Where(a => a.IsValidTarget(1200) && !a.IsDead))
                        {
                            var dmgI = (50 + ((MyHero.Level) * 20));
                            var health = tar.Health;
                            if (health < dmgI && MyHero.Distance(tar) < 600)
                            {
                                if (Ignite.Ready)
                                {
                                    Ignite.CastOnUnit(tar);
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}

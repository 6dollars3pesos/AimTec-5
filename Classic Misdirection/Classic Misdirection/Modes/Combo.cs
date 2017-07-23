
using System;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util;

namespace Classic_Misdirection
{
    internal partial class LB
    {
  
        public void DoCombo()
        {
            if (target == null || !target.IsValid || MyHero.ManaPercent() <
                RootM["combo"]["Mana"].As<MenuSliderBool>().Value || RootM["combo"]["blacklist"]["use" + target.ChampionName.ToLower()].As<MenuBool>().Enabled)
            {
                return;
            }

            DynamicCombo();
            ManuelCombo();
        }
        private void DynamicCombo()
        {
            bool useQ = RootM["combo"]["useQ"].As<MenuBool>().Enabled;
            bool useW = RootM["combo"]["useW"].As<MenuBool>().Enabled;
            bool useE = RootM["combo"]["useE"].As<MenuBool>().Enabled;
            bool useR = RootM["combo"]["useR"].As<MenuBool>().Enabled;
            bool Qmana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Wmana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.W).Cost;
            bool Emana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.E).Cost;
            bool Rmana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.R).Cost;
            if (RootM["combo"]["combologics"]["select"].As<MenuList>().Value != 0)
            {
                return;
            }
                if (ComboName =="W" )  //wQRE
                {
                    combostart = true;
                    if (Wmana && useW && IsW1())
                    {
                    CastW(W.GetPrediction(target).CastPosition);
                    }
                    if ((IsW2() || !W.Ready) && useQ && Qmana && IsPassive(target))
                    {
                        CastQ(target);
                    }
                    if (Rmana && useR && !Q.Ready && IsR1())
                    {
                        CastR("RQ", target);
                    }
                    if (useE && Emana && (!R.Ready && IsR2()))
                    {
                        CastE(target);
                    }
                }
                else if (ComboName == "RE")//REQEW
            {
                combostart = true;
                if (Rmana && useR && IsR1())
                    {
                    CastR("RE", target);
                    }
                    if ((IsR2() || !R.Ready) && useQ && Qmana && IsPassive(target))
                    {
                        CastQ(target);
                    }
                    if (!Q.Ready && Emana && useE)
                    {
                        CastE(target);
                    }
                    if (!E.Ready && useW && Wmana && IsW1())
                    {
                        CastW(W.GetPrediction(target).CastPosition);
                }

                }
                else if (ComboName == "Gap")//gapclose combo W-R(E)-E-Q
            {
                combostart = true;
                var pos = MyHero.ServerPosition.Extend(target.ServerPosition, W.Range);
                    if (IsW1() && useW && Wmana)
                    {
                    CastW(pos);
                    }
                    if ((IsW2() || !W.Ready) && useR && Rmana && IsR1())
                    {
                        CastR("RE", target);
                    }
                    if ((IsR2() || !R.Ready) && useQ && Qmana && IsPassive(target))
                    {
                        CastQ(target);
                    }
                    if (!Q.Ready && Emana && useE)
                    {
                        CastE(target);
                }
                }

        }

        private void ManuelCombo()
        {
            bool useQ = RootM["combo"]["useQ"].As<MenuBool>().Enabled;
            bool useW = RootM["combo"]["useW"].As<MenuBool>().Enabled;
            bool useE = RootM["combo"]["useE"].As<MenuBool>().Enabled;
            bool useR = RootM["combo"]["useR"].As<MenuBool>().Enabled;
            bool Qmana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Wmana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.W).Cost;
            bool Emana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.E).Cost;
            bool Rmana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.R).Cost;
            if (RootM["combo"]["combologics"]["select"].As<MenuList>().Value != 1)
            {
                return;
            }
            switch (RootM["combo"]["combologics"]["mCombo"].As<MenuList>().Value)
            {
                case 0:
                    if (useQ && Qmana)
                    {
                        CastQ(target);
                    }
                    if (!Q.Ready && Wmana && useW)
                    {
                        CastW(W.GetPrediction(target).CastPosition);
                    }
                    if (IsW2() && useE && Emana)
                    {
                        CastE(target);
                    }
                    if (!E.Ready && useR && Rmana && IsR1())
                    {
                        CastR("RW",target);
                    }
                    break;
                case 1:
                    if (useQ && Qmana)
                    {
                        CastQ(target);
                    }
                    if (!Q.Ready && useR && Rmana && IsPassive(target))
                    {
                        CastR("RQ",target);
                    }
                    if (useE && Emana && (IsR2() || !R.Ready))
                    {
                        CastE(target);
                    }
                    if (useW && Wmana && !E.Ready)
                    {
                        CastW(W.GetPrediction(target).CastPosition);
                    }
                    break;
                case 2:
                    if (useE && Emana)
                    {
                        CastE(target);
                    }
                    if (Qmana && useQ && !E.Ready && IsPassive(target))
                    {
                        CastQ(target);
                    }
                    if (Wmana && useW && !Q.Ready && IsW1())
                    {
                        CastW(W.GetPrediction(target).CastPosition);
                    }
                    if (IsR1() && useR && Rmana && IsW2())
                    {
                        CastR("RW",target);
                    }
                    break;
                case 3:
                    if (useE && Emana)
                    {
                        CastE(target);
                    }
                    if (Wmana && useW && !E.Ready && IsW1())
                    {
                        CastW(W.GetPrediction(target).CastPosition);
                    }
                    if ((IsW2() || !W.Ready) && useQ && Qmana && IsPassive(target))
                    {
                        CastQ(target);
                    }
                    if (!Q.Ready && useR && Rmana)
                    {
                        CastR("RQ",target);
                    }
                    break;
                case 4:
                    if (Wmana && useW  && IsW1())
                    {
                        CastW(W.GetPrediction(target).CastPosition);
                    }
                    if ((!W.Ready || IsW2()) && Rmana && useR)
                    {
                        CastR("RW",target);
                    }
                    if ((IsR2() || !R.Ready) && useQ && Qmana && IsPassive(target))
                    {
                        CastQ(target);
                    }
                    if (useE && Emana &&!Q.Ready)
                    {
                        CastE(target);
                    }
                    break;
                case 5:
                    if (Wmana && useW && IsW1())
                    {
                        CastW(W.GetPrediction(target).CastPosition);
                    }
                    if ((IsW2() || !W.Ready) && useQ && Qmana && IsPassive(target))
                    {
                        CastQ(target);
                    }
                    if (Rmana && useR && !Q.Ready && IsR1())
                    {
                        CastR("RQ",target);
                    }
                    if (useE && Emana &&( !R.Ready && IsR2()))
                    {
                        CastE(target);
                    }
                    break;
                case 6:
                    if (useQ && Qmana)
                    {
                        CastQ(target);
                    }
                    if (!Q.Ready && useR && Rmana && IsR1())
                    {
                        CastR("RQ",target);
                    }
                    if ((IsR2() || !R.Ready) && useW && Rmana && IsW1())
                    {
                        CastW(W.GetPrediction(target).CastPosition);
                    }
                    if ((IsW2() || !W.Ready) && useE && Emana)
                    {
                        DelayAction.Queue(450, () => CastE(target));
                    }
                    break;
                case 7:
                    if (!delaycheck)
                    {
                        if (useQ && Qmana)
                        {
                            CastQ(target);
                        }
                        if (!Q.Ready && Wmana && useW && IsW1())
                        {
                            CastW(W.GetPrediction(target).CastPosition);
                        }
                        if ((IsW2() || !W.Ready) && Emana && useE)
                        {
                            CastE(target);
                        }
                        if (!E.Ready && useR && Rmana && IsR1())
                        {
                            R.Cast();
                            delaycheck = true;
                            DelayAction.Queue(RootM["combo"]["combologics"]["delay"].As<MenuSliderBool>().Value, () =>
                                {
                                    this.CastE(target);
                                    delaycheck = false;
                                }
                            );
                        }
                    }
                    break;
            }
        }
    }
}

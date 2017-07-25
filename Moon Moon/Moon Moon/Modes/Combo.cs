
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace Moon_Moon
{
    internal partial class Diana
    {
        public void DoCombo()
        {
            bool useQ = RootM["combo"]["useQ"].As<MenuBool>().Enabled;
            bool useW = RootM["combo"]["useW"].As<MenuBool>().Enabled;
            bool useE = RootM["combo"]["useE"].As<MenuBool>().Enabled;
            bool useR = RootM["combo"]["useR"].As<MenuBool>().Enabled;
            bool Qmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Wmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.W).Cost;
            bool Emana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.E).Cost;
            bool Rmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.R).Cost;
            float erange = RootM["combo"]["emisc"].As<MenuBool>().Enabled ? 375 : 70;
            if (target == null || !target.IsValid || MyHero.ManaPercent() <
                RootM["combo"]["Mana"].As<MenuSliderBool>().Value || RootM["combo"]["blacklist"]["use" + target.ChampionName.ToLower()].As<MenuBool>().Enabled)
            {
                return;
            }
            double rdmg = MyHero.GetSpellDamage(target, SpellSlot.R);
            switch (RootM["combo"]["rlogic"].As<MenuList>().Value)
            {
                case 0:
                    if (useQ && Qmana)
                    {
                        CastQ(target);
                    }
                    if (useR && Rmana && !Q.Ready)
                    {
                        CastR(target);
                    }
                    if (useW && Wmana && MyHero.Distance(target) < W.Range)
                    {
                        CastW();
                    }
          
                    if (useE && Emana && MyHero.Distance(target) > erange)
                    {
                        CastE(target);
                    }
                    break;
                case 1:
                    if (useQ && Qmana)
                    {
                        CastQ(target);
                    }
                    if (useR && Rmana && (IsMarked(target) || rdmg>target.Health))
                    {
                        CastR(target);
                    }
                    if (useW && Wmana && MyHero.Distance(target) < W.Range)
                    {
                        CastW();
                    }
              
                    if (useE && Emana && MyHero.Distance(target) > erange)
                    {
                        CastE(target);
                    }
                    break;
                case 2:
                    if (useQ && Qmana)
                    {
                        CastQ(target);
                    }
                    if (useW && Wmana && MyHero.Distance(target) < W.Range)
                    {
                        CastW();
                    }
                    if (useR && Rmana)
                    {
                        CastR(target);
                    }
                    if (useE && Emana && MyHero.Distance(target) > erange)
                    {
                        CastE(target);
                    }
                    break;
            }

            if (!IsIgnite)
            {
                var dmgI = (50 + ((MyHero.Level) * 20));
                if (MyHero.Distance(target) < Q.Range && target.Health < dmgI && !RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled &&
                    RootM["killsteal"]["useI"].As<MenuBool>().Enabled)
                {
                    Ignite.CastOnUnit(target);
                }
            }
           
            // this.DoOneShotCombo(hptarget);
        }
    }
    }


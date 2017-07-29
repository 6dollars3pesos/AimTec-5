using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.Orbwalking;
using System;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public void DoCombo()
        {
            if (!target.IsValid  || MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSlider>().Value)|| RootM["combo"]["blacklist"]["use" + target.ChampionName.ToLower()].As<MenuBool>().Enabled)
            {
                return;
            }
            bool checkpassive = RootM["combo"]["useER"].As<MenuBool>().Enabled;
            bool useQ = RootM["combo"]["useQ"].As<MenuBool>().Enabled;
            bool useE = RootM["combo"]["useE"].As<MenuBool>().Enabled;
            bool useR = RootM["combo"]["useR"].As<MenuBool>().Enabled;
            int rlogic = RootM["combo"]["rlogic"].As<MenuList>().Value;
            bool useRM = RootM["combo"]["useRM"].As<MenuBool>().Enabled;
            int useRMC = RootM["combo"]["useRMC"].As<MenuSlider>().Value;
            double Qdamage = MyHero.GetSpellDamage(target, SpellSlot.Q);
            double Edamage = MyHero.GetSpellDamage(target, SpellSlot.E);
            double AAdmg = MyHero.CalculateDamage(target, DamageType.Physical, MyHero.TotalAttackDamage);
            double TotalDmg = Math.Max((2 * Qdamage + Edamage + 3 * AAdmg), (Qdamage + Edamage + 4 * AAdmg));
            if (MyHero.Distance(target) < R.Range && useR)
            {
                switch (rlogic)
                {
                    case 0:
                        if (TotalDmg > target.Health)
                        {
                            CastR();
                        }
                        break;
                    case 1:
                        if (Qdamage + Edamage + AAdmg > target.Health)
                        {
                            CastR();
                        }
                        break;
                    case 2:
                        CastR();
                        break;
                }
            }
            if(useRM && CountEnemyHeroesInRange(MyHero.ServerPosition,650f)> useRMC)
                {
                    CastR();
                }
                if (useQ)
                {
                    foreach (GameObject vital in VitalSpots)
                    {
                        if(vital == null)
                        {
                            CastQ(target);
                        }
                        else
                        {
                            CastQ(vital);
                        }
                    }
                }
                if(useE && !checkpassive && MyHero.Distance(target) < E.Range && !Orbwalker.Implementation.CanAttack())
                {
                    CastE();
                }
                if (IsIgnite)
                {
                    var dmgI = (50 + ((MyHero.Level) * 20));
                    if (MyHero.Distance(target) < Ignite.Range && target.Health < dmgI  && RootM["combo"]["useI"].As<MenuBool>().Enabled)
                    {
                      // Ignite.CastOnUnit(target);
                    }
                } 

             
            }
        }
    }

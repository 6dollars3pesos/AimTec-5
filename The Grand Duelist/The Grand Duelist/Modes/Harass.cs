

using System;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public void DoHarass()
        {
            if (!target.IsValid || target == null || MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSlider>().Value))
            {
                return;
            }
            bool checkpassive = RootM["harass"]["useER"].As<MenuBool>().Enabled;
            bool useQ = RootM["harass"]["useQ"].As<MenuBool>().Enabled;
            bool useE = RootM["harass"]["useE"].As<MenuBool>().Enabled;
            if (MyHero.Distance(target) < Q.Range)
            {
                foreach(GameObject vital in VitalSpots)
                {
                    if (useQ)
                    {
                        if (vital == null)
                        {
                            Q.Cast(target);
                        }
                        else
                        {
                            CastQ(vital);
                        }
                    }
                  
                }
                if (!checkpassive && useE)
                {
                    if(MyHero.Distance(target) < E.Range && !Orbwalker.Implementation.CanAttack())
                    {
                        CastE();
                    }
                }
            }
        }
    }
}

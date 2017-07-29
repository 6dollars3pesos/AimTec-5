using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace Orianna_by_Krystra
{
    internal partial class Ori
    {
        public void DoCombo()
        {
            if (MyHero.ManaPercent() < (RootM["combo"]["Mana"].As<MenuSlider>().Value) || target == null || !target.IsValid)
            {
                return;
            }

            bool useQ = RootM["combo"]["useQ"].As<MenuBool>().Enabled;
            int useE = RootM["combo"]["useE"].As<MenuList>().Value;
            bool useW = RootM["combo"]["useW"].As<MenuBool>().Enabled;
            bool useR = RootM["combo"]["useR"].As<MenuBool>().Enabled;
            int rlogic = RootM["combo"]["rlogic"].As<MenuList>().Value;
            double dmgR = MyHero.GetSpellDamage(target, SpellSlot.R);
            double dmgQ = MyHero.GetSpellDamage(target, SpellSlot.Q);
            double dmgW = MyHero.GetSpellDamage(target, SpellSlot.W);
            double total = dmgQ + dmgR + dmgW;
            if (useQ)
            {
                CastQ(target);
            }
            if(useW && target.Distance(Ball) < W.Range)
            {
                CastW();
            }

            if (useR && !RootM["combo"]["blacklist"]["use" + target.ChampionName.ToLower()].As<MenuBool>().Enabled)
            {
                switch (rlogic)
                {
                    case 0:
                        if(dmgQ +dmgW <target.Health && total > target.Health)
                        {
                            CastR(target);
                        }
                        break;
                    case 1:
                        if(dmgR > target.Health)
                        {
                            CastR(target);
                        }
                        break;
                    case 2:
                        CastR(target);
                        break;
                }
            }
            switch (useE)
            {
                case 0:
                    if (MyHero.HealthPercent() < 35)
                    {
                        CastE(MyHero);
                    }
                    break;
                case 1:
                    CastE(MyHero);
                    break;
            }
            if (RootM["combo"]["UseRM"].As<MenuBool>().Enabled && R.GetPrediction(target).AoeTargetsHitCount>= RootM["combo"]["rcount"].As<MenuSlider>().Value)
            {
                CastR(target);
            }
        }
    }
}

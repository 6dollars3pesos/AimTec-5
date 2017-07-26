using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public void DoCombo()
        {
            int comboEL = RootM["skill"]["Elogic"]["combo"].As<MenuList>().Value;
            int comboRL = RootM["skill"]["Rlogic"]["rlogic"].As<MenuList>().Value;
            int mVal = RootM["skill"]["Rlogic"]["rlogic2"].As<MenuList>().Value == 0 ? 2:1;
            bool comboAR = RootM["skill"]["Rlogic"]["enableautoR"].As<MenuBool>().Enabled;
            int comboRhp = RootM["skill"]["Rlogic"]["autorhp"].As<MenuSlider>().Value;
            bool useQ = RootM["combo"]["useQ"].As<MenuBool>().Enabled;
            bool useE = RootM["combo"]["useW"].As<MenuBool>().Enabled;
            bool useW = RootM["combo"]["useE"].As<MenuBool>().Enabled;
            bool useR = RootM["combo"]["useR"].As<MenuBool>().Enabled;
            if (MyHero.ManaPercent() < (RootM["combo"]["Mana"].As<MenuSliderBool>().Value) || target == null || !target.IsValid)
            {
                return;
            }

            if (useQ)
            {
                CastQ(target);
            }
            if (useE)
            {
                switch (comboEL)
                {
                    case 0:
                        CastE(E.GetPrediction(target).CastPosition, true, 1.5);
                        break;
                    case 1:
                        CastE(E.GetPrediction(target).CastPosition, true, 2);
                        break;

                }
            }
            if (useW)
            {
                CastW(target);
            }
            if (useR)
            {
                double dmgR = MyHero.GetSpellDamage(target, SpellSlot.R);
                float hp = target.Health;
                switch (comboRL)
                {
                    case 0:
                        if((UnitExtensions.CountEnemyHeroesInRange(MyHero,R.Range)>=3 || MyHero.Health < comboRhp) && comboAR)
                        {
                            CastR(MyHero);
                        }else if(dmgR* mVal > hp)
                        {
                            CastR(target);
                        }
                        break;
                    case 1:
                        if(MyHero.Health < comboRhp)
                        {
                            CastR(MyHero);
                        }
                        break;
                    case 2:
                        if(dmgR > hp)
                        {
                            CastR(target);
                        }
                        break;

                }
            }
        }
    }
}

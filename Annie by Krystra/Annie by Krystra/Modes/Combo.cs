
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        private object lSlot;

        public void DoCombo()
        {
            int rlogic = RootM["skill"]["Rlogic"]["rlogic"].As<MenuList>().Value;
            int mVal = RootM["skill"]["Rlogic"]["rlogic2"].As<MenuList>().Value == 0 ? 2 : 1;
            bool useQ = RootM["combo"]["useQ"].As<MenuBool>().Enabled;
            bool useW = RootM["combo"]["useW"].As<MenuBool>().Enabled;
            bool useR = RootM["combo"]["useR"].As<MenuBool>().Enabled;
            if (MyHero.ManaPercent() < (RootM["combo"]["Mana"].As<MenuSliderBool>().Value) || target == null || !target.IsValid)
            {
                return;
            }
            double dmgR = MyHero.GetSpellDamage(target, SpellSlot.R);
            double dmgQ = MyHero.GetSpellDamage(target, SpellSlot.Q);
            double dmgW = MyHero.GetSpellDamage(target, SpellSlot.W);
            double total = dmgQ + dmgR + dmgW;
            if (MyHero.Distance(target) < R.Range)
            {
                if (useR && total * mVal > target.Health)
                {
                    switch (rlogic)
                    {
                        case 0:
                            if (IsPassiveReady() || dmgR > target.Health)
                            {
                                CastR(target);
                            }
                            break;
                        case 2:
                            if (IsPassiveReady())
                            {
                                CastR(target);
                            }
                            break;
                        case 3:
                            CastR(target);
                            break;
                    }
                }
                if (useQ)
                {
                    CastQ(target);
                }
                if (useW)
                {
                    CastW(target);
                }
            }
            if (IsIgnite)
            {
                var dmgI = (50 + ((MyHero.Level) * 20));
                if (MyHero.Distance(target) < Ignite.Range && target.Health < dmgI)
                {
                    Ignite.CastOnUnit(target);
                }
            }
        }
    }
}

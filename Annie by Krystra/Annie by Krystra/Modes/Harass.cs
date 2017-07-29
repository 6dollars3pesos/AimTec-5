

using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public void DoHarass()
        {
            bool useQ = RootM["harass"]["useQ"].As<MenuBool>().Enabled;
            bool useW = RootM["harass"]["useW"].As<MenuBool>().Enabled;
            bool doNot = RootM["harass"]["donot"].As<MenuBool>().Enabled && IsPassiveReady() ;
            if (MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSliderBool>().Value) || target == null || !target.IsValid || doNot)
            {
                return;
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

        public void AutoQHarass()
        {
            bool useQ = RootM["harass"]["useQ"].As<MenuBool>().Value;
            bool doNot = RootM["harass"]["donot"].As<MenuBool>().Value;
            if (MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSliderBool>().Value) || target == null || !target.IsValid)
            {
                return;
            }
            if (useQ)
            {
                if (doNot)
                {
                    if (IsPassiveReady())
                    {
                        CastQ(target);
                    }
                }
                else
                {
                    CastQ(target);
                }
            }
        }
    }
}

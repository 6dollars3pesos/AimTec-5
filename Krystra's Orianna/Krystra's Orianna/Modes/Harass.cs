using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;


namespace Krystra_s_Orianna
{
    internal partial class Ori
    {
        public void DoHarass()
        {
            if(MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSliderBool>().Value) || !target.IsValid || target == null)
            {
                return;
            }
            bool useQ = RootM["harass"]["useQ"].As<MenuBool>().Enabled;
            bool useW = RootM["harass"]["useE"].As<MenuBool>().Enabled;
            if (useQ)
            {
                CastQ(target);
            }
            if (useW && target.Distance(Ball)<W.Width)
            {
                CastW();
            }
        }
        public void DoAutoQHarass()
        {
            if (MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSliderBool>().Value) || !target.IsValid || target == null)
            {
                return;
            }
            bool useQ = RootM["harass"]["useQ"].As<MenuBool>().Enabled;
            if (useQ)
            {
                CastQ(target);
            }
        }
    }
}

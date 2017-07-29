using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace The_Living_Shadow
{
    internal partial class Zed
    {
        public void DoHarass()
        {
            if (MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSliderBool>().Value) || target == null || !target.IsValid)
            {
                return;
            }
            if (RootM["harass"]["useW"].As<MenuBool>().Enabled)
            {
                if (MyHero.Distance(target) < W.Range)
                {
                    var Wposition = target.ServerPosition;
                    this.CastW(Wposition);
                }
                else if (MyHero.Distance(target) > W.Range && target.IsValidTarget(W.Range + Q.Range / 2))
                {
                    var Wposition = MyHero.ServerPosition.Extend(target.ServerPosition, 700);
                    this.CastW(Wposition);
                }
            }

            if ((RootM["harass"]["useQ"].As<MenuBool>().Enabled))
            {
                CastQ(target);
            }

            if (RootM["harass"]["useE"].As<MenuBool>().Enabled)
            {
                this.CastE();
            }
        }
    }
}

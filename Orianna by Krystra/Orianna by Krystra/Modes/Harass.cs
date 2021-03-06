﻿using System;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;


namespace Orianna_by_Krystra
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
            bool useW = RootM["harass"]["useW"].As<MenuBool>().Enabled;
            if (useQ)
            {
                CastQ(target);
            }
            if (useW  && target.Distance(Ball) <W.Range)
            {
                Console.WriteLine(W.Range);
                CastW();
            }
        }
        public void DoAutoQHarass()
        {
            if (MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSlider>().Value) ||  target == null)
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

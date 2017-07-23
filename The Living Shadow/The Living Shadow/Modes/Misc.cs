using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;


namespace The_Living_Shadow
{
    internal partial class Zed
    {
        public void ReturnSettings()
        {
            if (RootM["combo"]["turnback"]["swaphp"].As<MenuSliderBool>().Enabled &&
                RootM["combo"]["useW"].As<MenuBool>().Enabled)
            {
                if (MyHero.HealthPercent() <= RootM["combo"]["turnback"]["swaphp"].As<MenuSliderBool>().Value && MyHero.Distance(target) < 600)
                {
                    this.CastW2();
                }
            }

            if (RootM["combo"]["turnback"]["targetdied"].As<MenuBool>().Enabled)
            {
                if (target.IsDead)
                {
                    if (MyHero.SpellBook.GetSpell(SpellSlot.W).Name.ToLower() == "zedw2")
                    {
                        this.CastW2();
                    }
                    else if (MyHero.SpellBook.GetSpell(SpellSlot.R).Name.ToLower() == "zedr2")
                    {
                        R.Cast();
                    }
                }
            }
        }

        public bool IsW1()
        {
            return MyHero.SpellBook.GetSpell(SpellSlot.W).Name == "ZedW";
        }
        public bool IsW2()
        {
            return (MyHero.SpellBook.GetSpell(SpellSlot.W).Name == "ZedW2");
        }
        public bool IsR1()
        {
            return (MyHero.SpellBook.GetSpell(SpellSlot.R).Name == "ZedR");
        }
    }
}

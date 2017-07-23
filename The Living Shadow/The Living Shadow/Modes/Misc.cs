using Aimtec;
using Aimtec.SDK.Damage;
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
                if (target !=null && (target.IsDead || !target.IsValidTarget(1500)))
                {
                    double Qdamage = MyHero.GetSpellDamage(target, SpellSlot.Q);
                    double Edamage = MyHero.GetSpellDamage(target, SpellSlot.E);
                    if ((IsDie(target, Qdamage) && !Q.Ready) || (IsDie(target, Edamage) && !E.Ready))
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
        }

        public bool IsDie(Obj_AI_Base tar, double damage = 0)
        {
            if (tar.HasBuff("zedrtargetmark"))
            {
                if ((TotalRDamage + damage) * (20f + MyHero.SpellBook.GetSpell(SpellSlot.R).Level * 10) / 100f >= target.Health)
                {
                    return true;
                }
            }
            return false;
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

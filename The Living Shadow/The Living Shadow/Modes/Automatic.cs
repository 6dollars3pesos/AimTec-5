using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util;


namespace The_Living_Shadow
{
    internal partial class Zed
    {

        #region AutoQ
        private void AutoQ()
        {
            if (target == null || !target.IsValid)
            {
                return;
            }
            if (MyHero.Distance(target) < Q.Range && RootM["harass"]["useQ"].As<MenuBool>().Enabled)
            {
                this.CastQ(target);
            }
        }
        #endregion
        #region AutoE
        private void AutoE()
        {
            if (target == null || !target.IsValid)
            {
                return;
            }
            if (RootM["harass"]["useE"].As<MenuBool>().Enabled)
            {
                this.CastE();
            }
        }
        #endregion  
        #region AutoHarass
        private void AutoHarassF()
        {
            if (target == null || !target.IsValid || MyHero.ManaPercent() < RootM["harass"]["Mana"].As<MenuSliderBool>().Value)
            {
                return;
            }
            var Wposition = MyHero.ServerPosition.Extend(target.ServerPosition, 700);
            switch (RootM["harass"]["autoharass"]["harasslogic"].As<MenuList>().Value)
            {
                case 0:
                    if (Q.Ready && W.Ready && MyHero.Mana > (MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost + MyHero.SpellBook.GetSpell(SpellSlot.W).Cost))
                    {
                        if (RootM["harass"]["useW"].As<MenuBool>().Enabled)
                        {
                            if (MyHero.Distance(target) < W.Range)
                            {
                                this.CastW(target.ServerPosition);
                            }
                            else if (MyHero.Distance(target) > W.Range && target.IsValidTarget(W.Range + Q.Range / 2))
                            {
                                this.CastW(Wposition);
                            }
                        }
                        if (!Wpos.Equals(new Vector3()) && Q.Ready && RootM["harass"]["useQ"].As<MenuBool>().Enabled)
                        {
                            if (MyHero.Distance(target) < Q.Range)
                            {
                                this.CastQ(target);
                            }
                            else if (MyHero.Distance(target) > W.Range && target.IsValidTarget(W.Range + Q.Range / 2))
                            {
                                this.CastQ(target);
                            }
                        }

                    }
                    break;
                case 1:
                    if (Q.Ready && W.Ready && E.Ready && MyHero.Mana > (MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost + MyHero.SpellBook.GetSpell(SpellSlot.W).Cost + MyHero.SpellBook.GetSpell(SpellSlot.E).Cost))
                    {
                        if (MyHero.Distance(target) < W.Range && RootM["harass"]["useW"].As<MenuBool>().Enabled && W.Ready)
                        {
                            this.CastW(Wposition);
                        }
                        if (!Wpos.Equals(new Vector3()) && MyHero.Distance(target) < Q.Range && RootM["harass"]["useQ"].As<MenuBool>().Enabled)
                        {
                            DelayAction.Queue(210, () => this.CastQ(target));
                        }
                        if (E.Ready && Harass["useE"].As<MenuBool>().Enabled)
                        {
                            this.CastE();
                        }
                    }
                    break;
                case 2:
                    if (E.Ready && W.Ready && MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.E).Cost + MyHero.SpellBook.GetSpell(SpellSlot.W).Cost)
                    {
                        if (MyHero.Distance(target) < W.Range && RootM["harass"]["useW"].As<MenuBool>().Enabled)
                        {
                            this.CastW(Wposition);
                        }
                        if (Harass["useE"].As<MenuBool>().Enabled)
                        {
                            this.CastE();
                        }
                    }
                    break;
            }

        }
        #endregion
        public void LoadAutos()
        {
            if (RootM["harass"]["autoharass"]["useQ"].As<MenuBool>().Enabled)
            {
                this.AutoQ();
            }
            if (RootM["harass"]["autoharass"]["useE"].As<MenuBool>().Enabled)
            {
                this.AutoE();
            }
            if (RootM["harass"]["autoharass"]["use"].As<MenuBool>().Enabled)
            {
                this.AutoHarassF();
            }
        }
    }
}

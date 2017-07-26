using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public void DoHarass()
        {
            bool useQ = RootM["harass"]["useQ"].As<MenuBool>().Enabled;
            bool useE = RootM["harass"]["useW"].As<MenuBool>().Enabled;
            bool useW = RootM["harass"]["useE"].As<MenuBool>().Enabled;
            int harassV = RootM["skill"]["Elogic"]["harass"].As<MenuList>().Value;
            if (MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSliderBool>().Value) || target == null || !target.IsValid)
            {
                return;
            }
            if(useQ )
            {
                CastQ(target);
            }
            if(useW && MyHero.Distance(target) < W.Range)
            {
                CastW(target);
            }
            if(useE && MyHero.Distance(target) < E.Range)
            {
                switch (harassV)
                {
                    case 0:
                        CastE(target.ServerPosition, true, 1.5);
                        break;

                    case 1:
                        CastE(target.ServerPosition, true, 2);
                        break;
                }
            }
        }

        public void AutoQHarass()
        {
            if (MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSliderBool>().Value) || target == null || !target.IsValid ||
                !RootM["harass"]["autoq"].As<MenuBool>().Enabled)
            {
                return;
            }
            if(MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost && RootM["harass"]["useQ"].As<MenuBool>().Enabled)
            {
                CastQ(target);
            }
        }
    }
}

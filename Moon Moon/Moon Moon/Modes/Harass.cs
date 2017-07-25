using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Moon_Moon
{
    internal partial class Diana
    {
        public void DoHarass()
        {
            if (MyHero.ManaPercent() < (RootM["harass"]["Mana"].As<MenuSliderBool>().Value) || target == null || !target.IsValid)
            {
                return;
            }
            bool useQ = RootM["harass"]["useQ"].As<MenuBool>().Enabled;
            bool useW = RootM["harass"]["useW"].As<MenuBool>().Enabled;
            bool Qmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Wmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.W).Cost;
            if (useQ && Qmana)
            {
                CastQ(target);
            }
            if (MyHero.Distance(target)< W.Range && useW && Wmana)
            {
                CastW();
            }
        }
    }
}

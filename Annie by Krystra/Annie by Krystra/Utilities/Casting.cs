

using Aimtec;
using Aimtec.SDK.Extensions;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public void CastQ(Obj_AI_Base unit)
        {
            if (!Q.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                return;
            }
            if (MyHero.Distance(unit) < Q.Range)
            {
                Q.Cast(unit);
            }
        }
        public void CastW(Obj_AI_Base unit)
        {
            if (!W.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.W).Cost)
            {
                return;
            }
            if (MyHero.Distance(unit) < W.Range)
            {
                W.Cast(unit);
            }
        }
        public void CastE()
        {
            if (!E.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.E).Cost)
            {
                return;
            }
            E.Cast();
        }
        public void CastR(Obj_AI_Base unit)
        {
            if (!E.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.E).Cost)
            {
                return;
            }
            if (MyHero.Distance(unit) < R.Range)
            {
                R.Cast(unit);
            }
        }
    }
}

using Aimtec;
using Aimtec.SDK.Extensions;


namespace Orianna_by_Krystra
{
    internal partial class Ori
    {
        public void CastQ(Obj_AI_Base unit)
        {
            if (!Q.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                return;
            }
            if (MyHero.Distance(unit) < Q.Range)
            {
                Q.GetPredictionInput(unit).From = Ball;
                Q.Cast(Q.GetPrediction(unit).CastPosition);

            }
        }
        public void CastW()
        {
            if (!W.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.W).Cost)
            {
                return;
            }
                W.Cast();
        }
        public void CastE(Obj_AI_Base unit, bool isMe =false)
        {
            if (!E.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.E).Cost)
            {
                return;
            }
            if (!isMe)
            {
                if(unit.Distance(Ball)< E.Range)
                {
                    E.Cast(unit);
                }
            }
            else
            {
                E.Cast();
            }
        }
        public void CastR(Obj_AI_Base a)
        {
            if (!E.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.E).Cost)
            {
                return;
            }
            if(a.Distance(Ball)< R.Range)
            {
                R.Cast();
            }
        }
    }
}

using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util;

namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public void CastQ(Obj_AI_Base unit)
        {
            if (!Q.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                return;
            }
            if(MyHero.Distance(unit) < Q.Range)
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
                W.Cast();
            }
        }
        public void CastE(Vector3 pos,bool UseDelay=false, double D1 = 0)
        {
            if (!E.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.E).Cost)
            {
                return; 
            }
            if (!UseDelay)
            {
                E.Cast(pos);
            }
            else
            {
                var ticker = Game.TickCount;
                if((globalticker + D1*1000) < ticker)
                {
                    E.Cast(pos);
                    globalticker = ticker;
                    DelayAction.Queue((int)(D1*1000), () => E.Cast(pos));
                }
            }
        }
        public void CastR(Obj_AI_Base hero)
        {
            if (!R.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.R).Cost)
            {
                return;
            }
            if (hero.IsMe)
            {
                R.Cast();
            }
            else
            {
                if (MyHero.Distance(hero) < R.Range)
                {
                    R.Cast(hero);
                }
            }
        }
    }
}

using Aimtec;
using Aimtec.SDK.Extensions;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
       public void CastQ(GameObject obj )
        {
            if(!Q.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                return;
            }
            if (MyHero.Distance(obj) < Q.Range)
            {
                var pos = obj.ServerPosition;
                if (obj.Name.Contains("NE"))
                {
                    pos.Z += 200;
                    Q.Cast(pos);
                }else if (obj.Name.Contains("SW"))
                {
                    pos.Z -= 200;
                    Q.Cast(pos);
                }else if (obj.Name.Contains("SE"))
                {
                    pos.X -= 200;
                    Q.Cast(pos);
                }else if (obj.Name.Contains("NW"))
                {
                    pos.X += 200;
                    Q.Cast(pos);
                }
            }
        }
        public void CastW(Obj_AI_Base unit)
        {
            if(!W.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.W).Cost)
            {
                return;
            }
            if (MyHero.Distance(unit) < W.Range)
            {
                W.Cast(W.GetPrediction(unit).CastPosition);
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
        public void CastR()
        {
            if (!R.Ready || MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.R).Cost)
            {
                return;
            }
            R.CastOnUnit(target);
        }
    }
}

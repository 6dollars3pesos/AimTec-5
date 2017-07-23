using System;
using Aimtec;
using Aimtec.SDK.Extensions;


namespace The_Living_Shadow
{
    internal partial class Zed
    {
        public void CastQ(Obj_AI_Base unit)
        {
            if (!Q.Ready)
            {
                return;
            }
            if (!Wpos.Equals(new Vector3()))
            {
                if (Wpos.Distance(unit.ServerPosition) < Q.Range)
                {
                    Q.Cast(unit);
                }
            }
            else if (MyHero.Distance(unit) < Q.Range)
            {
                Q.Cast(unit);
            }
        }

        public void CastR(Obj_AI_Hero unit)
        {
            if (MyHero.SpellBook.GetSpell(SpellSlot.R).Name != "ZedR")
            {
                return;
            }
            if (R.Ready)
            {
                R.CastOnUnit(unit);

            }
        }
        public void CastW(Vector3 pos)
        {
            if (MyHero.SpellBook.GetSpell(SpellSlot.W).Name == "ZedW2")
            {
                return;
            }
            if (W.Ready && this.IsW1() && Game.TickCount - LastCastTime > 175)
            {
                W.Cast(pos);
                LastCastTime = Game.TickCount;


            }
        }
        public void CastW2()
        {
            if (MyHero.SpellBook.GetSpell(SpellSlot.W).Name != "ZedW2")
            {
                return;

            }
            if (W.Ready)
            {
                W.Cast();
            }
        }
        public void CastE()
        {
            if (!E.Ready)
            {
                return;
            }
            if (!Rpos.Equals(new Vector3()))
            {
                if (target.Distance(Rpos) < E.Range)
                {
                    Console.WriteLine("1");
                    E.Cast();
                }
            }
            if (!Wpos.Equals(new Vector3()))
            {
                if (target.Distance(Wpos) < E.Range)
                {
                    Console.WriteLine("2");
                    E.Cast();
                }
            }
            if (MyHero.Distance(target) < E.Range)
            {
                Console.WriteLine("3");
                E.Cast();

            }
        }
    }
}

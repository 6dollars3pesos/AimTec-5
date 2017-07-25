using Aimtec.SDK.Extensions;
using Aimtec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Moon_Moon
{
    internal partial class Diana
    {
        public void CastQ(Obj_AI_Base unit)
        {
            if (!Q.Ready)
            {
                return;
            }
            if(MyHero.Distance(unit) < Q.Range)
            {
                Q.Cast(Q.GetPrediction(unit).CastPosition);
            }
        }
        public void CastW()
        {
            if (!W.Ready)
            {
                return;
            }
            W.Cast();
        }
        public void CastE(Obj_AI_Base unit)
        {
            if (!E.Ready)
            {
                return;
            }
            if (MyHero.Distance(unit) < E.Range)
            {
                E.Cast(target);
            }
        }
        public void CastR(Obj_AI_Base unit)
        {
            if (!R.Ready)
            {
                return;
            }
            if (MyHero.Distance(unit) < R.Range)
            {
                R.Cast(target);
            }
        }
    }
}

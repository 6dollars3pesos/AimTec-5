using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public void DoLaneClear()
        {
            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(1400)))
            {
                if (minion != null)
                {
                    if (RootM["farm"]["laneclear"]["useW"].As<MenuBool>().Enabled)
                    {
                        if (GameObjects.EnemyMinions.Count(t => t.IsValidTarget(W.Range, false, false,
                                MyHero.ServerPosition)) >=
                            RootM["farm"]["laneclear"]["wcount"].As<MenuSlider>().Value)
                        {
                            CastW(minion);
                        }
                    }
                    if (RootM["farm"]["laneclear"]["useE"].As<MenuBool>().Enabled )
                    {
                        CastE(minion.ServerPosition,true,2);
                    }

                    if (RootM["farm"]["laneclear"]["useQ"].As<MenuBool>().Enabled )
                    {
                        CastQ(minion);
                    }
                    
                }

            }
        }
    }
}

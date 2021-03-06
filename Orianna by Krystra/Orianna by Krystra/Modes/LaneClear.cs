﻿using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System.Linq;
namespace Orianna_by_Krystra
{
    internal partial class Ori
    {
        public void DoLaneClear()
        {
            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(1400)))
            {
                if (minion != null)
                {
                    if (RootM["farm"]["laneclear"]["useW"].As<MenuBool>().Enabled)
                    {
                      if(CountEnemyMinions(Ball,W.Range)> RootM["farm"]["laneclear"]["wcount"].As<MenuSlider>().Value && minion.Distance(Ball)<W.Range)
                        {
                            W.Cast();
                        }
                    }

                    if (RootM["farm"]["laneclear"]["useQ"].As<MenuBool>().Enabled)
                    {
                      if(CountEnemyMinions(Q.GetPrediction(minion).CastPosition,Q.Range) >= RootM["farm"]["laneclear"]["qcount"].As<MenuSlider>().Value)
                        {
                            Q.Cast(Q.GetPrediction(minion).CastPosition);
                        }
                    }

                }

            }
        }
    }
}

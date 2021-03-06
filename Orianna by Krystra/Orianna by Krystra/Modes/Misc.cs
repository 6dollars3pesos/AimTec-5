﻿
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System.Linq;
using Aimtec.SDK.Extensions;
namespace Orianna_by_Krystra
{
    internal partial class Ori
    {
        public float CountEnemyMinions(Vector3 pos,float range)
        {
            return GameObjects.EnemyMinions.Count(h=>
                h.IsValidTarget(range,false,false,pos));
        }
        public int CountEnemyHeroesInRange(
            Vector3 vector3,
            float range,
            Obj_AI_Base dontIncludeStartingUnit = null)
        {
            return GameObjects.EnemyHeroes.Count(
                h => h.NetworkId != dontIncludeStartingUnit?.NetworkId
                    && h.IsValidTarget(range, true, false, vector3));
        }
        public void AutoCasting()
        {

            if (RootM["misc"]["auto"]["useR"].As<MenuBool>().Enabled)
            {
                if (CountEnemyHeroesInRange(Ball, R.Range) >= RootM["misc"]["auto"]["rcount"].As<MenuSlider>().Value)
                {
                    R.Cast();
                }
            }
            if (RootM["misc"]["auto"]["useW"].As<MenuBool>().Enabled)
            {
                if(CountEnemyHeroesInRange(Ball,W.Range)>= RootM["misc"]["auto"]["wcount"].As<MenuSlider>().Value)
                {
                    CastW();
                }
            }
           
        }
    }
}

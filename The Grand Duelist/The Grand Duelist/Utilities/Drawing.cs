using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aimtec.SDK.Util.Cache;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        #region Draw Spells
        public void DoDraws()
        {
            if (RootM["draw"]["disable"].As<MenuBool>().Enabled)
            {
                return;
            }
            if (RootM["draw"]["drawS"]["qdraw"].As<MenuBool>().Enabled && Q.Ready)
            {
                Render.Circle(MyHero.Position, Q.Range, 50, Color.Aquamarine);
            }
            if (RootM["draw"]["drawS"]["wdraw"].As<MenuBool>().Enabled && W.Ready)
            {
                Render.Circle(MyHero.Position, W.Range, 50, Color.Cornsilk);
            }
            if (RootM["draw"]["drawS"]["edraw"].As<MenuBool>().Enabled && E.Ready)
            {
                Render.Circle(MyHero.Position, E.Range, 50, Color.LightGreen);
            }
            if (RootM["draw"]["drawS"]["rdraw"].As<MenuBool>().Enabled && R.Ready)
            {
                Render.Circle(MyHero.Position, R.Range, 50, Color.Brown);
            }
            if (RootM["draw"]["vital"].As<MenuBool>().Enabled)
            {
                foreach(GameObject vital in VitalSpots)
                {
                    if(vital ==null || !vital.IsValid)
                    {
                        return;
                    }
                    if (target.Distance(vital) < 20)
                    {
                        if (vital.Name.Contains("NE"))
                        {
                            DrawCircleVital(vital.ServerPosition, 0, 0, 150);
                        }else if (vital.Name.Contains("SW"))
                        {
                            DrawCircleVital(vital.ServerPosition, 0, 0, -150);
                        }else if (vital.Name.Contains("SE"))
                        {
                            DrawCircleVital(vital.ServerPosition, -150, 0, 0);
                        }else if (vital.Name.Contains("NW"))
                        {
                            DrawCircleVital(vital.ServerPosition, 150, 0, 0);
                        }
                    }
                }
            }
            /*for (int i = 0; i < GameObjects.EnemyHeroes.Count(); i++)
            {
                var hero = GameObjects.EnemyHeroes.ElementAt(i);
                foreach (var sp in SpellDatabase.Spells.Where(enemy => enemy.charName == hero.ChampionName))
                {
                    
                }
            }*/
        }
        #endregion
       
        private void DrawCircleVital(Vector3 pos,int x,int y, int z)
        {
            if (MyHero.IsDead)
            {
                return;
            }
            if((Game.ClockTime - DrawC2Tick) > 0.05)
            {
                DrawCR2Tick -= 5;
                DrawC2Tick = Game.ClockTime;
            }
            if (DrawCR2Tick == 5)
            {
                    DrawCR2Tick = 50;
            }
            pos.X += x;
            pos.Y += y;
            pos.Z += z;
            Render.Circle(pos, DrawCR2Tick, 50, Color.White);

        }

    }
    
}

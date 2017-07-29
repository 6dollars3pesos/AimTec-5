using System.Drawing;
using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public void ResetAA()
        {
            Orbwalker.Implementation.ResetAutoAttackTimer();
        }

        public void DrawRectangleOutline(Vector3 startpos , Vector3 endpos,int width)
        {
            var c1 = startpos.Extend(endpos, width/2).To2D().Perpendicular().Normalized();
            var c2 = startpos.Extend(endpos, width / 2).To2D().Perpendicular(1).Normalized();
            var c3 = endpos.Extend(startpos, width / 2).To2D().Perpendicular().Normalized();
            var c4 = endpos.Extend(endpos, width / 2).To2D().Perpendicular(1).Normalized();
            Render.Line(c1,c2,Color.White);
            Render.Line(c2, c3, Color.White);
            Render.Line(c3, c4, Color.White);
            Render.Line(c1, c4, Color.White);
            var a = startpos.Extend(endpos, width ).To2D().Perpendicular().Normalized();
            var b = startpos.Extend(endpos, width ).To2D().Perpendicular(1).Normalized();
            var c = endpos.Extend(startpos, width ).To2D().Perpendicular().Normalized();
            var d = endpos.Extend(endpos, width ).To2D().Perpendicular(1).Normalized();
            Render.Line(a, b, Color.White);
            Render.Line(b, c, Color.White); 
            Render.Line(c, d, Color.White);
            Render.Line(d, a, Color.White);
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
        public double GetMyDamage(Obj_AI_Base unit)
        {
            double totaldamage = 0;
            double Qdamage = MyHero.GetSpellDamage(unit, SpellSlot.Q);
            double Wdamage = MyHero.GetSpellDamage(unit, SpellSlot.W);
            double Edamage = MyHero.GetSpellDamage(unit, SpellSlot.E);
            double Idamage = (50 + ((MyHero.Level) * 20));
            if (Q.Ready)
            {
                totaldamage += Qdamage;
            }
            if (W.Ready)
            {
                totaldamage += Wdamage;
            }
            if (E.Ready)
            {
                totaldamage += Edamage;
            }
            if (IsIgnite)
            {
                if (Ignite.Ready)
                {
                    totaldamage += Idamage;
                }
            }
            return totaldamage;
        }

        public bool IsWall(Vector3 pos)
        {
            return NavMesh.WorldToCell(pos).Flags.HasFlag(NavCellFlags.Wall);
        }

        public void DoWallJump()
        {
            var qdash = MyHero.ServerPosition.Extend(Game.CursorPos, Q.Range);
            var qdash2 = MyHero.ServerPosition.Extend(Game.CursorPos, 130);
            var qdash3 = MyHero.ServerPosition.Extend(Game.CursorPos, 25);
            if (Q.Ready)
            {
                if(RootM["keys"]["walljump"].As<MenuBool>().Enabled)
                {
                    if(!walljump && IsWall(qdash2))
                    {
                        MyHero.IssueOrder(OrderType.MoveTo, Game.CursorPos);
                    }else if (!IsWall(qdash) && IsWall(qdash2) && IsWall(qdash3))
                    {
                        walljump = true;
                        DelayAction.Queue(1000, () =>  walljump = false);
                        Q.Cast(qdash);
                    }
                }
            }
        }
    }
}

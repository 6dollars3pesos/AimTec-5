using System;
using Aimtec;
using Aimtec.SDK.Menu.Components;
using System.Drawing;
using Aimtec.SDK.Extensions;

namespace The_Living_Shadow
{
    internal partial class Zed
    {
        public void DrawSpells()
        {
            #region Draw Spells

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

            if (!Wpos.Equals(new Vector3()) && RootM["draw"]["drawshadowW"]["enable"].As<MenuBool>().Enabled)
            {
                Render.Circle(Wpos, 100, 50, Color.White);
            }
            if (!Rpos.Equals(new Vector3()) && RootM["draw"]["drawshadowR"]["enable"].As<MenuBool>().Enabled)
            {
                Render.Circle(Rpos, 100, 50, Color.White);
            }
            if (RootM["draw"]["drawshadowW"]["timer"].As<MenuBool>().Enabled)
            {
                if (!Wpos.Equals(new Vector3()))
                {
                    ;
                    var pos = Wpos.ToScreenPosition();
                    Render.Text(pos, Color.White, "Shadow Duration :" + Math.Round(StartTime - Game.ClockTime) + "s");
                }
            }
            if (RootM["draw"]["drawshadowR"]["timer"].As<MenuBool>().Enabled)
            {
                if (!Rpos.Equals(new Vector3()))
                {
                    ;
                    var pos = Rpos.ToScreenPosition();
                    Render.Text(pos, Color.White, "Shadow Duration :" + Math.Round(StartTimeR - Game.ClockTime) + "s");
                }
            }
            var drawpos = "Default";
            if (RootM["draw"]["combomode"].As<MenuBool>().Enabled)
            {
                switch (RootM["combo"]["rlogic"].As<MenuList>().Value)
                {
                    case 0:
                        drawpos = "Current Combo Mode: Line";
                        break;
                    case 1:
                        drawpos = "Current Combo Mode Rectangle";
                        break;
                    case 2:
                        drawpos = "Current Combo Mode: Mouse Position";
                        break;
                }
                var pos = MyHero.FloatingHealthBarPosition;
                pos.X += 43;
                pos.Y += 24;
                Render.Text(pos, Color.White, drawpos);
            }
            #endregion
        }
    }
}
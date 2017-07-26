﻿using System.Drawing;
using Aimtec;
using Aimtec.SDK.Menu.Components;

namespace Ice_Ice_Baby
{
    internal partial class Liss
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
        }
#endregion
    }
}

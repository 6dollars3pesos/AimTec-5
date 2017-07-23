using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Living_Shadow.General
{
   internal class Drawings
    {
        internal static void Draw()
        {
            #region Draw Spells
            if (Spells.Q.Ready && ZedMenu.DrawOptions["qdraw"].As<MenuBool>().Enabled)
            {
                Render.Circle(Player.Position ?, Spells.Q.Range, 30, Color.LightGreen);
            }
            if (Spells.W.Ready && ZedMenu.DrawOptions["wdraw"].As<MenuBool>().Enabled)
            {
                Render.Circle(Player.Position ?, Spells.W.Range, 30, Color.LightGreen);
            }
            if (Spells.E.Ready && ZedMenu.DrawOptions["edraw"].As<MenuBool>().Enabled)
            {
                Render.Circle(Player.Position ?, Spells.E.Range, 30, Color.LightGreen);
            }
            if (Spells.R.Ready && ZedMenu.DrawOptions["rdraw"].As<MenuBool>().Enabled)
            {
                Render.Circle(Player.Position ?, Spells.R.Range, 30, Color.LightGreen);
            }
            #endregion
        }
    }
}

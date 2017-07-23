using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Living_Shadow.General
{
   internal class Events
    {

        internal static void LoadEvents()
        {
            GameEvents.GameStart += OnLoad;
            Render.OnPresent += OnDraw;
        }

        internal static void LoadStuff()
        {
            #region Loadings
            General.Spells.LoadSpells();
            General.ZedMenu.LoadMenu();
            #endregion
        }
    }
}

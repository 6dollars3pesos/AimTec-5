

using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public void DoEscape()
        {
            MyHero.IssueOrder(OrderType.MoveTo, Game.CursorPos);
         
             if (RootM["escape"]["useE"].As<MenuBool>().Enabled)
            {
                CastE(Game.CursorPos, true, 1.5);
            }
            if (RootM["escape"]["useW"].As<MenuBool>().Enabled )
            {
                CastW(target);
            }
        }
    }
}


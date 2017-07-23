using Aimtec;
using Aimtec.SDK.Menu.Components;

namespace The_Living_Shadow
{
    internal partial class Zed
    {
        public void DoEscape()
        {

            if (RootM["escape"]["useW"].As<MenuBool>().Enabled && W.Ready)
            {
                W.Cast(Game.CursorPos);
            }
            else
            {
                MyHero.IssueOrder(OrderType.MoveTo, Game.CursorPos);
            }
        }
    }
}

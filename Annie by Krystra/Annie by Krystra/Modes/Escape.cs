

using Aimtec;
using Aimtec.SDK.Menu.Components;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public void DoEscape()
        {
            MyHero.IssueOrder(OrderType.MoveTo, Game.CursorPos);

            if (RootM["escape"]["useST"].As<MenuBool>().Enabled && IsPassiveReady())
            {
                if (Q.Ready)
                {
                    CastQ(target);
                }
                else if (W.Ready)
                {
                    CastW(target);
                }
            }
        }
    }
}

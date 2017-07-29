

using Aimtec;
using Aimtec.SDK.Menu.Components;

namespace Krystra_s_Orianna
{
    internal partial class Ori
    {
        public void DoEscape()
        {
            MyHero.IssueOrder(OrderType.MoveTo, Game.CursorPos);
            Escaping = true;
        }
    }
}

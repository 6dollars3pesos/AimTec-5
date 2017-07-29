

using Aimtec;
using Aimtec.SDK.Menu.Components;

namespace Orianna_by_Krystra
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

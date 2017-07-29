
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public void DoEscape()
        {
            var pos = MyHero.ServerPosition.Extend(Game.CursorPos, Q.Range);
            if (RootM["escape"]["useQ"].As<MenuBool>().Enabled && Q.Ready && MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                Q.Cast(pos);
            }
            MyHero.IssueOrder(OrderType.MoveTo, Game.CursorPos);
        }
    }
}

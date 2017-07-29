using Aimtec;

namespace The_Living_Shadow
{
    internal partial class Zed
    {

        public void LoadEvents()
        {
            Render.OnPresent += OnDraw;
            Game.OnUpdate += OnTick;
            Obj_AI_Base.OnProcessSpellCast += ProcessSpell;
            Game.OnWndProc += ClickEvent;
        }
    }
}
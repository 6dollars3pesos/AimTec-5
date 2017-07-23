
using Aimtec;

namespace Classic_Misdirection
{
    internal partial class LB
    {

        public void LoadEvents()
        {
           Render.OnPresent += OnDraw;
            Game.OnUpdate += OnTick;
            Game.OnWndProc += ClickEvent;
        }
    }
}

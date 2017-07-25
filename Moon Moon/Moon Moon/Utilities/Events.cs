using Aimtec;



namespace Moon_Moon
{
    internal partial class Diana
    {
       public void LoadEvents()
        {
            Render.OnPresent += OnDraw;
            Game.OnUpdate += OnTick;
            Game.OnWndProc += ClickEvent;
            //more event will come here
        }
    }
}

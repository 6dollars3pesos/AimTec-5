using Aimtec;


namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public void LoadEvents()
        {
            Render.OnPresent += OnDraw;
            Game.OnUpdate += OnTick;
            //more event will come here
        }
    }
}

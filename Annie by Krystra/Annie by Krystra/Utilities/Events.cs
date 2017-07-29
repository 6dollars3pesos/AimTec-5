using System;
using Aimtec;


namespace Annie_by_Krystra
{
    internal partial class Annie
    {
       public void LoadEvents()
        {
            Render.OnPresent += OnDraw;
            Game.OnUpdate += OnTick;
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpell;
            SpellBook.OnCastSpell += OnCastSpell;
            //more event will come here
        }

       
    }
}

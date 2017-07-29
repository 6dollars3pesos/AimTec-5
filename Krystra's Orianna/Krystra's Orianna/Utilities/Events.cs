using System;
using Aimtec;


namespace Krystra_s_Orianna
{
    internal partial class Ori
    {
       public void LoadEvents()
        {
            Render.OnPresent += OnDraw;
            Game.OnUpdate += OnTick;
            Obj_AI_Base.OnProcessSpellCast += ProcessSpell;
            BuffManager.OnAddBuff += UpdateBuff;
            SpellBook.OnCastSpell += OnCastSpell;
            //more event will come here
        }

       
    }
}

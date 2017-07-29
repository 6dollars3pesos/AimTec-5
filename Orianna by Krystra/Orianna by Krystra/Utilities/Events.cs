using System;
using Aimtec;


namespace Orianna_by_Krystra
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

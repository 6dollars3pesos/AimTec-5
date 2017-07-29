using System;
using Aimtec;
using Aimtec.SDK.Orbwalking;


namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
       public void LoadEvents()
        {
            Render.OnPresent += OnDraw;
            Game.OnUpdate += OnTick;
            GameObject.OnCreate += OnCreate;
            GameObject.OnDestroy += OnDestroy;
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpell;
            Orbwalker.PostAttack += PostAttack;
            //more event will come here
        }

       
    }
}

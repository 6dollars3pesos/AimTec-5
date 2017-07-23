using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Living_Shadow.General
{
    internal static class Spells
    {
        public static Spell Q, W, E, R;

        public static void LoadSpells()
        {
            Q = new Spell(SpellSlot.Q, 900f);
            W = new Spell(SpellSlot.W, 700f);
            E = new Spell(SpellSlot.E, 290f);
            R = new Spell(SpellSlot.R, 625f);

            Q.SetSkillshot(0.250f, 50f, 1700f, false, SkillType.Line);

        }
    }

    

}
}

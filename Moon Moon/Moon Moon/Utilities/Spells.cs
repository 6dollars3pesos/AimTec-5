using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spell = Aimtec.SDK.Spell;

namespace Moon_Moon
{
    internal partial class Diana
    {
        public static Spell Q, W, E, R, Ignite, Flash;
        public bool IsIgnite, IsFlash;

        public void LoadSpells()
        {
            Q = new Spell(SpellSlot.Q, 900f);
            W = new Spell(SpellSlot.W, 200f);
            E = new Spell(SpellSlot.E, 450f);
            R = new Spell(SpellSlot.R, 825f);

            // decleare if it skillshots

            Q.SetSkillshot(0.25f, 75f, 2000f, false, SkillshotType.Line);
            if (MyHero.SpellBook.GetSpell(SpellSlot.Summoner1).SpellData.Name.ToLower() == "summonerdot")
            {
                Ignite = new Spell(SpellSlot.Summoner1, 600);
                IsIgnite = true;
            }
            else if (MyHero.SpellBook.GetSpell(SpellSlot.Summoner2).SpellData.Name.ToLower() == "summonerdot")
            {
                Ignite = new Spell(SpellSlot.Summoner2, 600);
                IsIgnite = true;
            }
            if (MyHero.SpellBook.GetSpell(SpellSlot.Summoner1).SpellData.Name.ToLower() == "summonerflash")
            {
                Flash = new Spell(SpellSlot.Summoner1, 425);
                IsFlash = true;
            }
            else if (MyHero.SpellBook.GetSpell(SpellSlot.Summoner2).SpellData.Name.ToLower() == "summonerflash")
            {
                Flash = new Spell(SpellSlot.Summoner2, 425);
                IsFlash = true;
            }
        }
    }
}

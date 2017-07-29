using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spell = Aimtec.SDK.Spell;
namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public static Spell Q, W, E, R, Ignite, Flash;
        public bool IsIgnite, IsFlash;

        public void LoadSpells()
        {
            Q = new Spell(SpellSlot.Q, 625f);
            W = new Spell(SpellSlot.W, 600f);
            E = new Spell(SpellSlot.E, MyHero.BoundingRadius);
            R = new Spell(SpellSlot.R, 600f);

            // decleare if it skillshots
            W.SetSkillshot(0.25f, (float)(80 * Math.PI / 180), float.MaxValue, false, SkillshotType.Cone);
            R.SetSkillshot(0.1f, 300f, float.MaxValue, false, SkillshotType.Circle);

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

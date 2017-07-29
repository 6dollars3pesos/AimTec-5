using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;

using Spell = Aimtec.SDK.Spell;
namespace Orianna_by_Krystra
{
    internal partial class Ori
    {
        public static Spell Q, W, E, R, Ignite, Flash;
        public bool IsIgnite, IsFlash;

        public void LoadSpells()
        {
            Q = new Spell(SpellSlot.Q, 825f);
            W = new Spell(SpellSlot.W, 1050f);
            E = new Spell(SpellSlot.E, 1100f);
            R = new Spell(SpellSlot.R, 320f);

            // decleare if it skillshots
            Q.SetSkillshot(0.25f, 175f, 1150f, false, SkillshotType.Line);

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

using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using Spell = Aimtec.SDK.Spell;
namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public static Spell Q, W, E, R, Ignite, Flash;
        public bool IsIgnite, IsFlash;

        public void LoadSpells()
        {
            Q = new Spell(SpellSlot.Q, 390f);
            W = new Spell(SpellSlot.W, 759f);
            E = new Spell(SpellSlot.E, MyHero.BoundingRadius);
            R = new Spell(SpellSlot.R, 500f);

            // decleare if it skillshots

            W.SetSkillshot(0.250f, 70f, 3200f, false, SkillshotType.Line);
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

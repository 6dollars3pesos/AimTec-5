namespace The_Living_Shadow
{

    using Aimtec;
    using Aimtec.SDK.Prediction.Skillshots;
    using Spell = Aimtec.SDK.Spell;


    internal partial class Zed
    {
        public static Spell Q, W, E, R, Ignite, Flash;
        public bool IsIgnite, IsFlash;

        public void LoadSpells()
        {
            Q = new Spell(SpellSlot.Q, 900f);
            W = new Spell(SpellSlot.W, 700f);
            E = new Spell(SpellSlot.E, 290f);
            R = new Spell(SpellSlot.R, 625f);
            Q.SetSkillshot(0.250f, 50f, 1700f, false, SkillshotType.Line);
            W.SetSkillshot(0.250f, 50f, 1750f, false, SkillshotType.Circle);
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


using Aimtec.SDK.Menu.Components;
using Aimtec;
using Aimtec.SDK.Util.Cache;
using Aimtec.SDK.Extensions;
namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public void DoAutoR()
        {
            int enemycountR = RootM["misc"]["autor"]["enemycount"].As<MenuSlider>().Value;
            if (RootM["misc"]["autor"]["use"].As<MenuBool>().Enabled)
            {
                if(UnitExtensions.CountEnemyHeroesInRange(target, R.Range) >= enemycountR)
                {
                    CastR(target);
                }
               else if (UnitExtensions.CountEnemyHeroesInRange(MyHero, R.Range) >= enemycountR)
                {
                    CastR(MyHero);
                }
            }
        }

        public void DoAutoW()
        {
            int enemycountW = RootM["misc"]["autow"]["enemycount"].As<MenuSlider>().Value;
            if (RootM["misc"]["autow"]["use"].As<MenuBool>().Enabled)
            {
                if (UnitExtensions.CountEnemyHeroesInRange(MyHero, W.Range) >= enemycountW)
                {
                    CastW(target);
                }
                {

                }
            }
        }
    }
}

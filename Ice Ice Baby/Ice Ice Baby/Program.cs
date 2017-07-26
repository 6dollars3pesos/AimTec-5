

using Aimtec;
using Aimtec.SDK.Events;
using System;

namespace Ice_Ice_Baby
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }
        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Lissandra")
            {
                Console.WriteLine("Ice Ice Baby by Krystra has been loaded.");
                var Template = new Liss();

            }
        }
    }
}

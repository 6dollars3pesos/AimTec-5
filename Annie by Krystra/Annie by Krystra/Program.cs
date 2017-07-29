
using Aimtec;
using Aimtec.SDK.Events;
using System;

namespace Annie_by_Krystra
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }

        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Annie")
            {
                Console.WriteLine("Twerk for Tibbers by Krystra has been loaded.");
                var Annie = new Annie();

            }
        }
    }
}

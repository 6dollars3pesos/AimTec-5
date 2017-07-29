using System;
using Aimtec;
using Aimtec.SDK.Events;

namespace Orianna_by_Krystra
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }
        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Orianna")
            {
                Console.WriteLine("Script Name by Krystra has been loaded.");
                var Template = new Ori();

            }

        }
    }
}

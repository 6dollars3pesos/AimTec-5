using Aimtec;
using Aimtec.SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Grand_Duelist
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }
        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Fiora")
            {
                Console.WriteLine("The Grand Duelist by Krystra has been loaded.");
                var Fiora = new Fiora();

            }

        }
    }
}

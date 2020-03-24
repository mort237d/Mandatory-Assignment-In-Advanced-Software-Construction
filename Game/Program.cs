using System;
using ModelLibrary;
using ModelLibrary.AttackObjects;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Sword sword = new Sword(2, 2, 2, Rarity.COMMON);
            Console.WriteLine(sword.ToString());
        }
    }
}

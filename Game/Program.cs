using System;
using System.Collections.Generic;
using ModelLibrary;
using ModelLibrary.AttackDecorator;
using ModelLibrary.AttackObjects;
using ModelLibrary.CreatureObejcts;
using ModelLibrary.Objects;
using ModelLibrary.World;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Forest forest = new Forest(new int[10,10], new List<BaseObject>(), new List<CreatureBaseObject>());
            
            Sword sword = new Sword();
            Console.WriteLine(sword.ToString());

            Poiseneas poiseneas = new Poiseneas(sword);
            Console.WriteLine(poiseneas.ToString());

            Fiery fiery = new Fiery(sword);
            Console.WriteLine(fiery.ToString());
        }
    }
}

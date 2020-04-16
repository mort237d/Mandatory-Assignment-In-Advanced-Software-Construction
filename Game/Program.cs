using System;
using System.Collections.Generic;
using System.Threading;
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
            Console.OutputEncoding = System.Text.Encoding.Default;

            Forest forest = new Forest(new string[5,5], new List<BaseObject>(), new List<CreatureBaseObject>{new Phoenix(), new Deamon(), new Snake()});
            while (true)
            {
                Console.Clear();
                forest.CreaturesMoving();
                Thread.Sleep(700);
            }

            //Sword sword = new Sword();
            //Console.WriteLine(sword.ToString());
            //sword.Attack();

            //Poiseneas poiseneas = new Poiseneas(sword);
            //Console.WriteLine(poiseneas.ToString());

            //Fiery fiery = new Fiery(sword);
            //Console.WriteLine(fiery.ToString());
        }
    }
}

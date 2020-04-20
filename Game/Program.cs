using System;
using System.Threading;
using ModelLibrary.World;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Forest forest = new Forest();
            //Volcano volcano = new Volcano();
            while (true)
            {
                Console.Clear();
                forest.CreaturesMoving();
                //volcano.CreaturesMoving();
                Thread.Sleep(700);
            }
        }
    }
}

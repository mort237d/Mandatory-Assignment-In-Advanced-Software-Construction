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
            while (true)
            {
                Console.Clear();
                forest.CreaturesMoving();
                Thread.Sleep(700);
            }
        }
    }
}

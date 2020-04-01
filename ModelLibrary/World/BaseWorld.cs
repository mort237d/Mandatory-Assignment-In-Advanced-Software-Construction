using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using ModelLibrary.CreatureObejcts;
using ModelLibrary.Objects;

namespace ModelLibrary.World
{
    public abstract class BaseWorld
    {
        private string[,] _size;
        private List<BaseObject> _baseObjects;
        private List<CreatureBaseObject> _creatureBaseObjects;

        protected BaseWorld(string[,] size, List<BaseObject> baseObjects, List<CreatureBaseObject> creatureBaseObjects)
        {
            Size = size;
            BaseObjects = baseObjects;
            CreatureBaseObjects = creatureBaseObjects;

            GiveCreaturesCordinates();
            WorldInit(Size);
            PopulateWorld();
            DrawWorld(Size);
        }

        private void WorldInit(string[,] size)
        {
            Console.WriteLine("WorldInit " + size.GetLength(0) + " x " + size.GetLength(1));
            for (int i = 0; i < size.GetLength(0); i++)
            {
                for (int j = 0; j < size.GetLength(1); j++)
                {
                    size[i, j] = "|_|";
                }
            }
        }

        protected void PopulateWorld()
        {
            char creatureSign = '\0';

            foreach (var creature in CreatureBaseObjects)
            {
                switch (creature.Name)
                {
                    case "Phoenix":
                        creatureSign = 'P';
                        break;
                    case "Snake":
                        creatureSign = 'S';
                        break;
                    case "Deamon":
                        creatureSign = 'D';
                        break;
                }

                Size[creature.XCordinate, creature.YCordinate] = "|" + creatureSign + "|";
            }
        }

        private void GiveCreaturesCordinates()
        {
            bool creatureNotSet;
            Random random = new Random();
            foreach (var creature in CreatureBaseObjects)
            {
                int cordX = random.Next(Size.GetLength(0));
                int cordY = random.Next(Size.GetLength(1));

                creatureNotSet = true;
                while (creatureNotSet)
                {
                    if (!CreatureBaseObjects.Any(c => c.XCordinate == cordX && c.YCordinate == cordY))
                    {
                        creature.XCordinate = cordX;
                        creature.YCordinate = cordY;

                        creatureNotSet = false;
                    }
                }
            }
        }

        private void DrawWorld(string[,] size)
        {
            for (int i = 0; i < size.GetLength(0); i++)
            {
                for (int j = 0; j < size.GetLength(1); j++)
                {
                    Console.Write(size[i, j]);
                }

                Console.WriteLine();
            }
        }

        public void CreaturesMoving()
        {
            Random random = new Random();

            for (int i = 0; i < CreatureBaseObjects.Count; i++)
            {
                int moveX = random.Next(-1, 2);
                int moveY = random.Next(-1, 2);

                if (CreatureBaseObjects[i].XCordinate + moveX >= 0 && CreatureBaseObjects[i].XCordinate + moveX <= Size.GetLength(0) - 1)
                {
                    CreatureBaseObjects[i].XCordinate += moveX;
                }
                if(CreatureBaseObjects[i].YCordinate + moveY >= 0 && CreatureBaseObjects[i].YCordinate + moveY <= Size.GetLength(1) - 1)
                {
                    CreatureBaseObjects[i].YCordinate += moveY;
                }

                if (i != CreatureBaseObjects.IndexOf(CreatureBaseObjects.Find(c => c.XCordinate == CreatureBaseObjects[i].XCordinate && c.YCordinate == CreatureBaseObjects[i].YCordinate)))
                {
                    if (CreatureBaseObjects.Any(c => c.XCordinate == CreatureBaseObjects[i].XCordinate && c.YCordinate == CreatureBaseObjects[i].YCordinate))
                    {
                        List<CreatureBaseObject> creaturesInBattle = CreatureBaseObjects.FindAll(c => c.XCordinate == moveX && c.YCordinate == moveY);

                        if (creaturesInBattle.Count != 0) //TODO make it work!
                        {
                            creaturesInBattle[0].Life += creaturesInBattle[1].BaseDamage * creaturesInBattle[1].BaseSpeed;
                            creaturesInBattle[1].Life += creaturesInBattle[0].BaseDamage * creaturesInBattle[0].BaseSpeed;
                        }
                    }
                }
            }

            WorldInit(Size);
            PopulateWorld();
            DrawWorld(Size);
            WriteOutCreatures();
        }

        public void WriteOutCreatures()
        {
            string creatureNames = "| ";
            string creatureStats = "| ";

            foreach (var creature in CreatureBaseObjects)
            {
                creatureNames += $"{creature.Name} ({creature.Name.Remove(1)}) | ";
                creatureStats += $"D: {creature.BaseDamage * creature.BaseSpeed} H: {creature.Life} | ";
            }

            string lines = null;

            foreach (var w in creatureNames)
            {
                lines += "-";
            }

            Console.WriteLine(lines);
            Console.WriteLine(creatureNames);
            Console.WriteLine(lines);
            Console.WriteLine(creatureStats);
            Console.WriteLine(lines);
        }

        public string[,] Size
        {
            get => _size;
            set => _size = value;
        }

        public List<BaseObject> BaseObjects
        {
            get => _baseObjects;
            set => _baseObjects = value;
        }

        public List<CreatureBaseObject> CreatureBaseObjects
        {
            get => _creatureBaseObjects;
            set => _creatureBaseObjects = value;
        }
    }
}

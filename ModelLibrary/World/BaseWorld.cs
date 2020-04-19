using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using ModelLibrary.AttackObjects;
using ModelLibrary.CreatureObejcts;
using ModelLibrary.DefenceObjects;
using ModelLibrary.Objects;

namespace ModelLibrary.World
{
    public abstract class BaseWorld
    {
        private WorldObject[,] _size;

        private List<BaseObject> _baseObjects;
        private List<CreatureBaseObject> _creatureBaseObjects;

        protected BaseWorld(WorldObject[,] size, List<BaseObject> baseObjects, List<CreatureBaseObject> creatureBaseObjects)
        {
            Size = size;
            BaseObjects = baseObjects;
            CreatureBaseObjects = creatureBaseObjects;

            GiveObjectsCordinates();
            GiveCreaturesCordinates();
            WorldInit();
            PopulateWorld();
            DrawWorld();
        }

        private void GiveObjectsCordinates()
        {
            bool objectNotSet;
            Random random = new Random();

            foreach (var o in BaseObjects)
            {
                int cordX = random.Next(Size.GetLength(0));
                int cordY = random.Next(Size.GetLength(1));

                objectNotSet = true;

                while (objectNotSet)
                {
                    if (!BaseObjects.Any(baseObject => baseObject.XCordinate == cordX && baseObject.YCordinate == cordY))
                    {
                        o.XCordinate = cordX;
                        o.YCordinate = cordY;

                        objectNotSet = false;
                    }
                }
            }
        }

        private void WorldInit()
        {
            for (int i = 0; i < Size.GetLength(0); i++)
            {
                for (int j = 0; j < Size.GetLength(1); j++)
                {
                    Size[i, j] = new EmptyObject();
                }
            }
        }

        protected void PopulateWorld()
        {
            for (int x = 0; x < Size.GetLength(0); x++)
            {
                for (int y = 0; y < Size.GetLength(1); y++)
                {
                    if (BaseObjects.Any(baseObjects => baseObjects.XCordinate == x && baseObjects.YCordinate == y))
                    {
                        Size[x,y] = BaseObjects.Find(baseObjects => baseObjects.XCordinate == x && baseObjects.YCordinate == y);
                    }

                    if (CreatureBaseObjects.Any(creatureBaseObjects => creatureBaseObjects.XCordinate == x && creatureBaseObjects.YCordinate == y))
                    {
                        Size[x,y] = CreatureBaseObjects.Find(creatureBaseObjects => creatureBaseObjects.XCordinate == x && creatureBaseObjects.YCordinate == y);
                    }

                    //switch (Size[x,y])
                    //{
                    //    case EmptyObject emptyObject:
                    //        Console.Write("|_|"); 
                    //        break;
                    //    default:
                    //        Console.Write($"|{Size[x, y].Name.Remove(1)}|");
                    //        break;
                    //}
                }
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
                    if (!CreatureBaseObjects.Any(c => c.XCordinate == cordX && c.YCordinate == cordY) &&
                        !BaseObjects.Any(baseObject => baseObject.XCordinate == cordX && baseObject.YCordinate == cordY))
                    {
                        creature.XCordinate = cordX;
                        creature.YCordinate = cordY;

                        creatureNotSet = false;
                    }
                }
            }
        }

        private void DrawWorld()
        {
            for (int x = 0; x < Size.GetLength(0); x++)
            {
                for (int y = 0; y < Size.GetLength(1); y++)
                {
                    //if (Size[i, j].Equals("|R|")) Console.ForegroundColor = ConsoleColor.Gray;
                    //if (Size[i, j] == C) Console.ForegroundColor = ConsoleColor.Yellow;

                    switch (Size[x, y])
                    {
                        case EmptyObject emptyObject:
                            Console.Write("|_|");
                            break;
                        default:
                            Console.Write($"|{Size[x, y].Name.Remove(1)}|");
                            break;
                    }

                    //Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
        }

        public void CreaturesMoving()
        {
            Random random = new Random();

            for (int i = 0; i < CreatureBaseObjects.Count; i++)
            {
                bool notMoved = true;

                while (notMoved)
                {
                    int moveX = random.Next(-1, 2);
                    int moveY = random.Next(-1, 2);

                    int newXCordinate = CreatureBaseObjects[i].XCordinate + moveX;
                    int newYCordinate = CreatureBaseObjects[i].YCordinate + moveY;

                    if (newXCordinate >= 0 &&
                        newXCordinate <= Size.GetLength(0) - 1 &&
                        newYCordinate >= 0 &&
                        newYCordinate <= Size.GetLength(1) - 1 &&
                        Size[newXCordinate, newYCordinate].GetType() != typeof(Rock))
                    {
                        if (Size[newXCordinate, newYCordinate].GetType() == typeof(Chest))
                        {
                            Chest chest = (Chest) Size[newXCordinate, newYCordinate];
                            if (chest.AttackBaseObjectBonus != null)
                            {
                                if (CreatureBaseObjects[i].AttackBaseObjects != null)
                                {
                                    if (CreatureBaseObjects[i].AttackBaseObjects.Damage * CreatureBaseObjects[i].AttackBaseObjects.Speed < chest.AttackBaseObjectBonus.Damage * chest.AttackBaseObjectBonus.Speed)
                                    {
                                        CreatureBaseObjects[i].AttackBaseObjects = chest.AttackBaseObjectBonus;
                                    }
                                }
                                else CreatureBaseObjects[i].AttackBaseObjects = chest.AttackBaseObjectBonus;
                            }

                            if (chest.DefenceBaseObjectBonus != null)
                            {
                                if (CreatureBaseObjects[i].DefenceBaseObjects != null)
                                {
                                    if (!CreatureBaseObjects[i].DefenceBaseObjects.Any(d => d.Name.Contains(chest.DefenceBaseObjectBonus.Name)))
                                    {
                                        CreatureBaseObjects[i].DefenceBaseObjects.Add(chest.DefenceBaseObjectBonus);
                                    }
                                }
                                else CreatureBaseObjects[i].DefenceBaseObjects.Add(chest.DefenceBaseObjectBonus);

                                CreatureBaseObjects[i].CalculateDefence();
                            }

                            BaseObjects.Remove(BaseObjects.Find(baseObject => baseObject.XCordinate == newXCordinate && baseObject.YCordinate == newYCordinate));
                        }
                        CreatureBaseObjects[i].XCordinate += moveX;
                        CreatureBaseObjects[i].YCordinate += moveY;
                        notMoved = false;
                    }

                    if (i != CreatureBaseObjects.IndexOf(CreatureBaseObjects.Find(c => c.XCordinate == CreatureBaseObjects[i].XCordinate && c.YCordinate == CreatureBaseObjects[i].YCordinate)))
                    {
                        if (CreatureBaseObjects.Any(c => c.XCordinate == CreatureBaseObjects[i].XCordinate && c.YCordinate == CreatureBaseObjects[i].YCordinate))
                        {
                            List<CreatureBaseObject> creaturesInBattle = CreatureBaseObjects.FindAll(c => c.XCordinate == CreatureBaseObjects[i].XCordinate && c.YCordinate == CreatureBaseObjects[i].YCordinate);

                            if (creaturesInBattle.Count != 0)
                            {
                                if (creaturesInBattle[1].TotalDamage > creaturesInBattle[0].Defence) creaturesInBattle[0].Life -= creaturesInBattle[1].TotalDamage - creaturesInBattle[0].Defence;
                                if (creaturesInBattle[0].TotalDamage > creaturesInBattle[1].Defence) creaturesInBattle[1].Life -= creaturesInBattle[0].TotalDamage - creaturesInBattle[1].Defence;

                                CreatureBaseObjects.RemoveAll(c => c.Dead);
                            }
                        }
                    }
                }
            }

            WorldInit();
            PopulateWorld();
            DrawWorld();
            WriteOutCreatures();
        }

        public void WriteOutCreatures()
        {
            string creatureNames = "| ";
            string creatureStats = "| ";

            foreach (var creature in CreatureBaseObjects)
            {
                string name = $"{creature.Name} ({creature.Name.Remove(1)})";
                string stat = $"A: {creature.TotalDamage} H: {creature.Life} D: {creature.Defence}";
                string spaces = null;

                int differenceOfLength = stat.Length - name.Length;

                for (int i = 0; i < differenceOfLength; i++)
                {
                    spaces += " ";
                }

                creatureNames += $"{name}{spaces} | ";
                creatureStats += $"{stat} | ";
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

        public WorldObject[,] Size
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

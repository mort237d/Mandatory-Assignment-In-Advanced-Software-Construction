using ModelLibrary.CreatureObejcts;
using ModelLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ModelLibrary.World
{
    public abstract class BaseWorld
    {
        private WorldObject[,] _size;
        private int _height;
        private int _width;

        private List<BaseObject> _baseObjects;
        private List<CreatureBaseObject> _creatureBaseObjects;

        protected void EmptyWorld()
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
                }
            }
        }

        protected void GiveCordinates(List<WorldObject> list)
        {
            bool notSet;
            Random random = new Random();
            foreach (var o in list)
            {
                int cordX = random.Next(Size.GetLength(0));
                int cordY = random.Next(Size.GetLength(1));

                notSet = true;
                while (notSet)
                {
                    if (!CreatureBaseObjects.Any(c => c.XCordinate == cordX && c.YCordinate == cordY) &&
                        !BaseObjects.Any(baseObject => baseObject.XCordinate == cordX && baseObject.YCordinate == cordY))
                    {
                        o.XCordinate = cordX;
                        o.YCordinate = cordY;

                        notSet = false;
                    }
                }
            }
        }

        protected void DrawWorld()
        {
            for (int x = 0; x < Size.GetLength(0); x++)
            {
                for (int y = 0; y < Size.GetLength(1); y++)
                {
                    switch (Size[x, y])
                    {
                        case EmptyObject emptyObject:
                            Console.Write("|_|");
                            break;
                        case Chest chest:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"|{Size[x, y].Name.Remove(1)}|");
                            break;
                        case Rock rock:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"|{Size[x, y].Name.Remove(1)}|");
                            break;
                        case Tree tree:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"|{Size[x, y].Name.Remove(1)}|");
                            break;
                        case Lava lava:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"|{Size[x, y].Name.Remove(1)}|");
                            break;
                        default:
                            Console.Write($"|{Size[x, y].Name.Remove(1)}|");
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
        }

        public void CreaturesMoving()
        {
            Random random = new Random();

            for (int i = 0; i < CreatureBaseObjects.Count; i++)
            {
                CheckCreatureMovement(random, i);

                CreatureInBattle(i);
            }

            EmptyWorld();
            PopulateWorld();
            DrawWorld();
            WriteOutCreatures();
        }

        private void CreatureInBattle(int i)
        {
            if (i != CreatureBaseObjects.IndexOf(CreatureBaseObjects.Find(c =>
                c.XCordinate == CreatureBaseObjects[i].XCordinate && c.YCordinate == CreatureBaseObjects[i].YCordinate)))
            {
                if (CreatureBaseObjects.Any(c =>
                    c.XCordinate == CreatureBaseObjects[i].XCordinate && c.YCordinate == CreatureBaseObjects[i].YCordinate))
                {
                    List<CreatureBaseObject> creaturesInBattle = CreatureBaseObjects.FindAll(c =>
                        c.XCordinate == CreatureBaseObjects[i].XCordinate && c.YCordinate == CreatureBaseObjects[i].YCordinate);

                    if (creaturesInBattle.Count != 0)
                    {
                        if (creaturesInBattle[1].TotalDamage > creaturesInBattle[0].Defence)
                            creaturesInBattle[0].Life -= creaturesInBattle[1].TotalDamage - creaturesInBattle[0].Defence;
                        if (creaturesInBattle[0].TotalDamage > creaturesInBattle[1].Defence)
                            creaturesInBattle[1].Life -= creaturesInBattle[0].TotalDamage - creaturesInBattle[1].Defence;

                        if (creaturesInBattle[0].Dead) creaturesInBattle[0].AfterBattle(creaturesInBattle[1]);

                        if (creaturesInBattle[1].Dead) creaturesInBattle[1].AfterBattle(creaturesInBattle[0]);

                        CreatureBaseObjects.RemoveAll(c => c.Dead);
                    }
                }
            }
        }

        private void CheckCreatureMovement(Random random, int i)
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
                    Size[newXCordinate, newYCordinate].GetType() != typeof(Rock) &&
                    Size[newXCordinate, newYCordinate].GetType() != typeof(Tree))
                {
                    if (Size[newXCordinate, newYCordinate].GetType() == typeof(Chest))
                    {
                        Chest chest = (Chest) Size[newXCordinate, newYCordinate];
                        if (chest.AttackBaseObjectBonus != null)
                        {
                            CreatureBaseObjects[i].EquipedAttackBaseObject = chest.AttackBaseObjectBonus;
                        }

                        if (chest.DefenceBaseObjectBonus != null)
                        {
                            if (!CreatureBaseObjects[i].DefenceBaseObjects
                                .Any(d => d.Name.Contains(chest.DefenceBaseObjectBonus.Name)))
                            {
                                CreatureBaseObjects[i].DefenceBaseObjects.Add(chest.DefenceBaseObjectBonus);
                            }

                            CreatureBaseObjects[i].CalculateDefence();
                        }

                        BaseObjects.Remove(BaseObjects.Find(baseObject =>
                            baseObject.XCordinate == newXCordinate && baseObject.YCordinate == newYCordinate));
                    }
                    if (Size[newXCordinate, newYCordinate].GetType() == typeof(Lava))
                    {
                        CreatureBaseObjects[i].Life -= 1;
                        if (CreatureBaseObjects[i].Dead) CreatureBaseObjects.RemoveAt(i);
                    }

                    CreatureBaseObjects[i].XCordinate += moveX;
                    CreatureBaseObjects[i].YCordinate += moveY;
                    notMoved = false;
                }
            }
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

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public int Width
        {
            get => _width;
            set => _width = value;
        }
    }
}

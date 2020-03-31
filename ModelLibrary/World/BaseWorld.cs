using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.CreatureObejcts;
using ModelLibrary.Objects;

namespace ModelLibrary.World
{
    public abstract class BaseWorld
    {
        private int[,] _size;
        private List<BaseObject> _baseObjects;
        private List<CreatureBaseObject> _creatureBaseObjects;

        protected BaseWorld(int[,] size, List<BaseObject> baseObjects, List<CreatureBaseObject> creatureBaseObjects)
        {
            Size = size;
            BaseObjects = baseObjects;
            CreatureBaseObjects = creatureBaseObjects;

            WorldInit(Size);
            DrawWorld(Size);
        }

        private void WorldInit(int[,] size)
        {
            for (int i = 0; i < 10; i++) //TODO FIX SIZE LENGTH
            {
                for (int j = 0; j < 10; j++)
                {
                    size[i, j] = 1;
                }
            }
        }

        protected abstract void PopulateWorld();

        private void DrawWorld(int[,] size)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(size[i, j]);
                }

                Console.WriteLine();
            }
        }

        public int[,] Size
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

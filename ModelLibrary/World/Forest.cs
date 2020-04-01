using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.CreatureObejcts;
using ModelLibrary.Objects;

namespace ModelLibrary.World
{
    public class Forest : BaseWorld
    {
        public Forest(string[,] size, List<BaseObject> baseObjects, List<CreatureBaseObject> creatureBaseObjects) : base(size, baseObjects, creatureBaseObjects)
        {
            Size = size;
            BaseObjects = baseObjects;
            CreatureBaseObjects = creatureBaseObjects;
        }
    }
}

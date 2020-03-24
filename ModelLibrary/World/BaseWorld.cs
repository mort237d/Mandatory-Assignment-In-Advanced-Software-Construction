using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.CreatureObejcts;
using ModelLibrary.Objects;

namespace ModelLibrary.World
{
    internal abstract class BaseWorld
    {
        private int[,] _size;
        private List<BaseObject> _baseObjects;
        private List<CreatureBaseObject> _creatureBaseObjects;
    }
}

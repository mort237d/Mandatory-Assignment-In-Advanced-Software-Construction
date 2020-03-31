using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.DefenceObjects
{
    class Glove : DefenceBaseObject
    {
        public Glove()
        {
            Defence = 1;
            Size = 1;
            Rarity1 = Rarity.COMMON;
        }
    }
}

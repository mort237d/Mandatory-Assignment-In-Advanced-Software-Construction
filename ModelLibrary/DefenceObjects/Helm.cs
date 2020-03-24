using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.DefenceObjects
{
    class Helm : DefenceBaseObject
    {
        public Helm()
        {
            Defence = 1;
            Size = 1;
            Rarity1 = Rarity.COMMON;
        }
    }
}

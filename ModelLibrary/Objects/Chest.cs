using ModelLibrary.AttackObjects;
using ModelLibrary.DefenceObjects;

namespace ModelLibrary.Objects
{
    public class Chest : BaseObject
    {
        public Chest(AttackBaseObject attackBaseObject, DefenceBaseObject defenceBaseObject)
        {
            Breakable = true;
            AttackBaseObjectBonus = attackBaseObject;
            DefenceBaseObjectBonus = defenceBaseObject;
        }
    }
}

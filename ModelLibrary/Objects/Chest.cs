using ModelLibrary.AttackObjects;
using ModelLibrary.DefenceObjects;

namespace ModelLibrary.Objects
{
    public class Chest : BaseObject
    {
        private AttackBaseObject _attackBaseObjectBonus;
        private DefenceBaseObject _defenceBaseObjectBonus;

        public Chest(AttackBaseObject attackBaseObject, DefenceBaseObject defenceBaseObject)
        {
            Breakable = true;
            AttackBaseObjectBonus = attackBaseObject;
            DefenceBaseObjectBonus = defenceBaseObject;
        }

        public AttackBaseObject AttackBaseObjectBonus
        {
            get => _attackBaseObjectBonus;
            set => _attackBaseObjectBonus = value;
        }

        public DefenceBaseObject DefenceBaseObjectBonus
        {
            get => _defenceBaseObjectBonus;
            set => _defenceBaseObjectBonus = value;
        }
    }
}

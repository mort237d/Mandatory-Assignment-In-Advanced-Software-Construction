using ModelLibrary.AttackObjects;

namespace ModelLibrary.AttackDecorator
{
    public abstract class AttackDecorator : AttackBaseObject
    {
        protected AttackBaseObject AttackBaseObject;

        public AttackDecorator(AttackBaseObject attackBaseObject)
        {
            this.AttackBaseObject = attackBaseObject;
        }
    }
}

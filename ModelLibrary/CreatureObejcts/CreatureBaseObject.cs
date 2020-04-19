using System.Collections.Generic;
using ModelLibrary.AttackObjects;
using ModelLibrary.DefenceObjects;

namespace ModelLibrary.CreatureObejcts
{
    public abstract class CreatureBaseObject : WorldObject
    {
        private int _baseDamage;
        private int _baseSpeed;
        private int _totalDamage;
        private int _size;
        private Difficulty _difficulty;
        private AttackBaseObject _attackBaseObjects;
        private int _maxSizeOfAttackObject;
        private List<DefenceBaseObject> _defenceBaseObjects;
        private int _maxSizeOfDefenceObject;
        private int _life;
        private int _defence;
        private bool _dead;

        public CreatureBaseObject()
        {
            MaxSizeOfAttackObject = 2;
            MaxSizeOfDefenceObject = 5;
            Defence = 0;
            Dead = false;
        }

        public void CalculateDamage()
        {
            TotalDamage = BaseDamage * BaseSpeed;

            if (AttackBaseObjects != null)
            {
                TotalDamage += AttackBaseObjects.Damage * AttackBaseObjects.Speed;
            }
        }

        public void CalculateDefence()
        {
            if (DefenceBaseObjects != null)
            {
                foreach (var defenceBaseObject in DefenceBaseObjects)
                {
                    Defence += defenceBaseObject.Defence;
                }
            }
        }

        public int BaseDamage
        {
            get => _baseDamage;
            set => _baseDamage = value;
        }

        public int BaseSpeed
        {
            get => _baseSpeed;
            set => _baseSpeed = value;
        }

        public int Size
        {
            get => _size;
            set => _size = value;
        }

        public Difficulty Difficulty1
        {
            get => _difficulty;
            set => _difficulty = value;
        }

        public AttackBaseObject AttackBaseObjects
        {
            get => _attackBaseObjects;
            set => _attackBaseObjects = value;
        }

        public int MaxSizeOfAttackObject
        {
            get => _maxSizeOfAttackObject;
            set => _maxSizeOfAttackObject = value;
        }

        public List<DefenceBaseObject> DefenceBaseObjects
        {
            get => _defenceBaseObjects;
            set => _defenceBaseObjects = value;
        }

        public int MaxSizeOfDefenceObject
        {
            get => _maxSizeOfDefenceObject;
            set => _maxSizeOfDefenceObject = value;
        }

        public int Life
        {
            get => _life;
            set
            {
                _life = value;
                if (_life <= 0)
                {
                    Dead = true;
                }
            }
        }

        public bool Dead
        {
            get => _dead;
            set => _dead = value;
        }

        public int TotalDamage
        {
            get => _totalDamage;
            set => _totalDamage = value;
        }

        public int Defence
        {
            get => _defence;
            set => _defence = value;
        }
    }
}

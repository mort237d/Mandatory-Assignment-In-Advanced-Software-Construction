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
        private AttackBaseObject _equipedAttackBaseObject;
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
            DefenceBaseObjects = new List<DefenceBaseObject>();
            Dead = false;
        }

        public abstract void DeadText(CreatureBaseObject creatureBaseObject);
        public abstract void UpgradeWeapon(CreatureBaseObject creatureBaseObject);


        // The "Template method"
        public void AfterBattle(CreatureBaseObject creatureBaseObject)
        {
            DeadText(creatureBaseObject);
            UpgradeWeapon(creatureBaseObject);
        }

        public void CalculateDamage()
        {
            TotalDamage = BaseDamage * BaseSpeed;

            if (EquipedAttackBaseObject != null) TotalDamage += EquipedAttackBaseObject.Damage * EquipedAttackBaseObject.Speed;
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

        public AttackBaseObject EquipedAttackBaseObject
        {
            get => _equipedAttackBaseObject;
            set
            {
                if (_equipedAttackBaseObject == null)
                {
                    _equipedAttackBaseObject = value;
                }
                else if (_equipedAttackBaseObject.Damage * _equipedAttackBaseObject.Speed < value.Damage * value.Speed)
                {
                    _equipedAttackBaseObject = value;
                }
                CalculateDamage();
            }
        }

        public int MaxSizeOfAttackObject
        {
            get => _maxSizeOfAttackObject;
            set => _maxSizeOfAttackObject = value;
        }

        public List<DefenceBaseObject> DefenceBaseObjects
        {
            get => _defenceBaseObjects;
            set
            {
                _defenceBaseObjects = value;
                CalculateDefence();
            }
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

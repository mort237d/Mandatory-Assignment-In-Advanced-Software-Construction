using System.Collections.Generic;
using ModelLibrary.AttackObjects;
using ModelLibrary.DefenceObjects;

namespace ModelLibrary.CreatureObejcts
{
    public abstract class CreatureBaseObject
    {
        private string _name;
        private int _baseDamage;
        private int _baseSpeed;
        private int _size;
        private Difficulty _difficulty;
        private List<AttackBaseObject> _attackBaseObjects;
        private int _maxSizeOfAttackObject;
        private List<DefenceBaseObject> _defenceBaseObjects;
        private int _maxSizeOfDefenceObject;
        private int _life;
        private int _xCordinate;
        private int _yCordinate;
        private bool _dead;

        public CreatureBaseObject()
        {
            Name = this.GetType().Name;
            MaxSizeOfAttackObject = 2;
            MaxSizeOfDefenceObject = 5;
            Dead = false;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
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

        public List<AttackBaseObject> AttackBaseObjects
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

        public int XCordinate
        {
            get => _xCordinate;
            set => _xCordinate = value;
        }

        public int YCordinate
        {
            get => _yCordinate;
            set => _yCordinate = value;
        }

        public bool Dead
        {
            get => _dead;
            set => _dead = value;
        }
    }
}

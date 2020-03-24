using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.AttackObjects
{
    public abstract class AttackBaseObject
    {
        private string _name;
        private int _damage;
        private int _speed;
        private int _size;
        private Rarity _rarity;

        protected AttackBaseObject()
        {
            Name = this.GetType().Name;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public int Size
        {
            get => _size;
            set => _size = value;
        }

        public Rarity Rarity1
        {
            get => _rarity;
            set => _rarity = value;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Damage: {Damage}, Speed: {Speed}, Size: {Size}, Rarity: {Rarity1}";
        }
    }

}

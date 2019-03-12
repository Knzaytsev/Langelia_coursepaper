using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langelia
{
    class Person
    {
        private int _id;
        private string _name;
        private int _numberMove;
        private int _health;
        private int _attack;
        private int _defense;
        private enum feature { warrior = 1, settler = 2, diplomat = 3};
        private int _feature;
        private int _x;
        private int _y;
        private bool active = false;
        private string pathColor;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public int NumberMove
        {
            get { return _numberMove; }
            set { _numberMove = value; }
        }
        public int Id
        {
            get { return _id; }
        }
        public string PathColor
        {
            get { return pathColor; }
            set { pathColor = value; }
        }
        public int Feature { get { return _feature; } }
        public string Name { get { return _name; } }
        public int Health { get { return _health; } }
        public int Defense { get { return _defense; } }
        public int Attack { get { return _attack; } }

        public Person() { }

        public Person(int id, string name, int numberMove, int health, int attack, int defense, int feature, int x, int y)
        {
            _id = id;
            _name = name;
            _numberMove = numberMove;
            _health = health;
            _attack = attack;
            _defense = defense;
            _feature = feature;
            _x = x;
            _y = y;
        }

        public void Movement(int x, int y)
        {
            x /= 32;
            y /= 32;
            _x = x * 32;
            _y = y * 32;
        }
    }
}

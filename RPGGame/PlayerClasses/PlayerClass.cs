using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.PlayerClasses
{
    public class PlayerClass
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public int Strenght { get; set; }
        public int Inteligence { get; set; }
        public int Agility { get; set; }
        public char Symbol { get; set; }
        public int Range { get; set; }

        public PlayerClass()
        {

        }

        public virtual void Setup()
        {
            Health = Strenght * 5;
            Mana = Inteligence * 3;
            Damage = Agility * 2;
        }

        public void BuffStats(int str, int intel, int agl)
        {
            Strenght += str;
            Inteligence += intel;
            Agility += agl;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}

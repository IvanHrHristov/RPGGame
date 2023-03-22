using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.PlayerClasses
{
    public class Mage : PlayerClass
    {
        public Mage()
        {
            Strenght = 2;
            Inteligence = 3;
            Agility = 1;
            Range = 3;
        }

        public override void Setup()
        {
            base.Setup();
            Symbol = '*';
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.PlayerClasses
{
    public class Archer : PlayerClass
    {
        public Archer()
        {
            Strenght = 2;
            Inteligence = 0;
            Agility = 4;
            Range = 2;
        }

        public override void Setup()
        {
            base.Setup();
            Symbol = '#';
        }
    }
}

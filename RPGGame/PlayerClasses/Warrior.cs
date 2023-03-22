namespace RPGGame.PlayerClasses
{
    public class Warrior : PlayerClass
    {
        public Warrior()
        {
            Strenght = 3;
            Inteligence = 0;
            Agility = 3;
            Range = 1;
        }

        public override void Setup()
        {
            base.Setup();
            Symbol = '@';
        }
    }
}

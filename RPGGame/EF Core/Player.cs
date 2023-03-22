namespace RPGGame.EF_Core
{
    public class Player
    {
        public int Id { get; set; }

        public string Class { get; set; } = null!;

        public int Strenght { get; set; }

        public int Inteligence { get; set; }

        public int Agility { get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }

        public int Mana { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

namespace RPGGame
{
    public class Enemy
    {
        private Random random = new Random();

        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public int Strenght { get; set; }
        public int Inteligence { get; set; }
        public int Agility { get; set; }
        public char Symbol { get; set; }
        public int Range { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Enemy(int x, int y)
        {
            Strenght = random.Next(1, 3);
            Inteligence = random.Next(1, 3);
            Agility = random.Next(1, 3);
            Symbol = 'E';
            Range = 1;
            XPosition = x;
            YPosition = y;
        }

        public virtual void Setup()
        {
            Health = Strenght * 5;
            Mana = Inteligence * 3;
            Damage = Agility * 2;
        }

        public bool CheckIfNearPlayer(char[,] map)
        {
            bool check = false;

            for (int x = (XPosition - 1) < 0 ? 0 : (XPosition - 1); x <= ((XPosition + 1) > 9 ? 9 : (XPosition + 1)); x++)
            {
                for (int y = (YPosition - 1) < 0 ? 0 : (YPosition - 1); y <= ((YPosition + 1) > 9 ? 9 : (YPosition + 1)); y++)
                {
                    if (map[x, y] == '#' || map[x, y] == '@' || map[x, y] == '*')
                    {
                        check = true;
                    }
                }
            }
            return check;
        }

        public void Move(char[,] map, int playerX, int playerY)
        {
            int orgX = XPosition, orgY = YPosition;

            map[XPosition, YPosition] = '▒';

            if (playerX > XPosition)
            {
                XPosition += 1;
            }
            else if (playerX < XPosition)
            {
                XPosition -= 1;
            }

            if (playerY > YPosition)
            {
                YPosition += 1;
            }
            else if(playerY < YPosition)
            {
                YPosition -= 1;
            }

            if (map[XPosition, YPosition] == '▒')
            {
                map[XPosition, YPosition] = 'E';
            }
            else
            {
                map[orgX, orgY] = 'E';
                XPosition = orgX;
                YPosition = orgY;
            }
        }
    }
}

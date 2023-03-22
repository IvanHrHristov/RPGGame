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

        public void Attack(char[,] map, int pX, int pY, List<Enemy> enemies)
        {
            char[,] demoMap = {
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'}
            };

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (map[x, y] == 'E')
                    {
                        demoMap[x, y] = 'E';
                    }
                    if (map[x, y] == Symbol)
                    {
                        demoMap[x, y] = Symbol;
                    }
                }
            }

            int enemiesCount = 0;

            Dictionary<int, string> enemiesInRange = new Dictionary<int, string>();

            for (int x = (pX - Range) < 0 ? 0 : (pX - Range); x <= ((pX + Range) > 9 ? 9 : (pX + Range)); x++)
            {
                for (int y = (pY - Range) < 0 ? 0 : (pY - Range); y <= ((pY + Range) > 9 ? 9 : (pY + Range)); y++)
                {
                    if (demoMap[x, y] == 'E')
                    {
                        enemiesCount++;
                        demoMap[x, y] = char.Parse(enemiesCount.ToString());
                        enemiesInRange.Add(enemiesCount, $"{x},{y}");
                    }
                }
            }

            Console.Clear();

            Console.WriteLine($"Health: {Health}          Mana: {Mana}");

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Console.Write(demoMap[x, y]);
                }
                Console.WriteLine();
            }

            if (enemiesCount == 0)
            {
                Console.WriteLine("No available targets in your range");
            }
            else
            {
                Console.Write("Choose an enemy to attack: ");

                int choice = int.Parse(Console.ReadLine());

                string[] coordinatesOfEnemyChosen = enemiesInRange[choice].Split(',');

                enemies.First(e => e.XPosition == int.Parse(coordinatesOfEnemyChosen[0]) && e.YPosition == int.Parse(coordinatesOfEnemyChosen[1])).TakeDamage(Damage);
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}

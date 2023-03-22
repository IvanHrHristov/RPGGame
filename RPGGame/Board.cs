using RPGGame.PlayerClasses;
using System;

namespace RPGGame
{
    public class Board
    {
        public void Draw(char[,] map, int playerHP, int playerMana, int currX, int currY, char symbol)
        {
            Console.Clear();

            Console.WriteLine($"Health: {playerHP}          Mana: {playerMana}");

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (x == currX && y == currY)
                    {
                        map[x, y] = symbol;
                    }

                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Choose action");
            Console.WriteLine("1) Attack");
            Console.WriteLine("2) Move");
        }

        public void MovePlayer(char[,] map, ref int currX, ref int currY, char playerInput, int playerRange, char symbol)
        {
            int prevX = currX, prevY = currY;

            map[currX, currY] = '▒';

            switch (playerInput)
            {
                case 'W':
                    if ((currX - playerRange) < 0)
                    {
                        currX = 0;
                    }
                    else
                    {
                        currX -= playerRange;
                    }
                    break;
                case 'A':
                    if ((currY - playerRange) < 0)
                    {
                        currY = 0;
                    }
                    else
                    {
                        currY -= playerRange;
                    }
                    break;
                case 'S':
                    if ((currX + playerRange) < 0)
                    {
                        currX = 0;
                    }
                    else
                    {
                        currX += playerRange;
                    }
                    break;
                case 'D':
                    if ((currY + playerRange) < 0)
                    {
                        currY = 0;
                    }
                    else
                    {
                        currY += playerRange;
                    }
                    break;
                case 'Q':
                    if ((currX - playerRange) < 0)
                    {
                        currX = 0;
                    }
                    else
                    {
                        currX -= playerRange;
                    }

                    if ((currY - playerRange) < 0)
                    {
                        currY = 0;
                    }
                    else
                    {
                        currY -= playerRange;
                    }
                    break;
                case 'E':
                    if ((currX - playerRange) < 0)
                    {
                        currX = 0;
                    }
                    else
                    {
                        currX -= playerRange;
                    }

                    if ((currY + playerRange) < 0)
                    {
                        currY = 0;
                    }
                    else
                    {
                        currY += playerRange;
                    }
                    break;
                case 'Z':
                    if ((currX + playerRange) < 0)
                    {
                        currX = 0;
                    }
                    else
                    {
                        currX += playerRange;
                    }

                    if ((currY - playerRange) < 0)
                    {
                        currY = 0;
                    }
                    else
                    {
                        currY -= playerRange;
                    }
                    break;
                case 'X':
                    if ((currX + playerRange) < 0)
                    {
                        currX = 0;
                    }
                    else
                    {
                        currX += playerRange;
                    }

                    if ((currY + playerRange) < 0)
                    {
                        currY = 0;
                    }
                    else
                    {
                        currY += playerRange;
                    }
                    break;
                default:
                    break;
            }

            if(map[currX, currY] == 'E')
            {
                map[prevX, prevY] = symbol;
                currX = prevX;
                currY = prevY;
            }
            else
            {
                map[currX, currY] = symbol;
            }
        }

        public char ChooseDirection()
        {
            char chosenDirection = 'W';
            bool choiceIsCorrect = false;   

            while (!choiceIsCorrect)
            {
                Console.WriteLine("Choose a valid direction [W,A,S,D,Q,E,Z,X]: ");

                switch (Console.ReadLine())
                {
                    case "W":
                        chosenDirection = 'W';
                        choiceIsCorrect = true;
                        break;
                    case "w":
                        chosenDirection = 'W';
                        choiceIsCorrect = true;
                        break;
                    case "A":
                        chosenDirection = 'A';
                        choiceIsCorrect = true;
                        break;
                    case "a":
                        chosenDirection = 'A';
                        choiceIsCorrect = true;
                        break;
                    case "S":
                        chosenDirection = 'S';
                        choiceIsCorrect = true;
                        break;
                    case "s":
                        chosenDirection = 'S';
                        choiceIsCorrect = true;
                        break;
                    case "D":
                        chosenDirection = 'D';
                        choiceIsCorrect = true;
                        break;
                    case "d":
                        chosenDirection = 'D';
                        choiceIsCorrect = true;
                        break;
                    case "Q":
                        chosenDirection = 'Q';
                        choiceIsCorrect = true;
                        break;
                    case "q":
                        chosenDirection = 'Q';
                        choiceIsCorrect = true;
                        break;
                    case "E":
                        chosenDirection = 'E';
                        choiceIsCorrect = true;
                        break;
                    case "e":
                        chosenDirection = 'E';
                        choiceIsCorrect = true;
                        break;
                    case "Z":
                        chosenDirection = 'Z';
                        choiceIsCorrect = true;
                        break;
                    case "z":
                        chosenDirection = 'Z';
                        choiceIsCorrect = true;
                        break;
                    case "X":
                        chosenDirection = 'X';
                        choiceIsCorrect = true;
                        break;
                    case "x":
                        chosenDirection = 'X';
                        choiceIsCorrect = true;
                        break;
                    default:
                        choiceIsCorrect = false;
                        break;
                }
            }

            return chosenDirection;
        }

        public Enemy SpawnEnemy(char[,] map)
        {
            Random ran = new Random();
            int x, y;
            while (true)
            {
                x = ran.Next(0, 9);
                y = ran.Next(0, 9);
                if (map[x, y] == '▒')
                {
                    map[x, y] = 'E';
                    break;
                }
            }

            Enemy enemy = new Enemy(x, y);
            enemy.Setup();

            return enemy;
        } 
    }
}

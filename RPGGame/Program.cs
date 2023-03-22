using RPGGame;
using RPGGame.EF_Core;
using RPGGame.PlayerClasses;

char[,] map =
{
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

Board board = new Board();

bool choiceIsCorrect = false;
int charChoice = 1;

while(true)
{
    Console.WriteLine("Welcome!");
    Console.WriteLine("Press any key to play");
    Console.ReadKey();

    while (!choiceIsCorrect)
    {
        Console.Clear();
        Console.WriteLine(" Choose character type:");
        Console.WriteLine("1) Warrior");
        Console.WriteLine("2) Archer");
        Console.WriteLine("3) Mage");
        Console.Write("Your pick: ");

        switch (Console.ReadLine())
        {
            case "1":
                charChoice = 1;
                choiceIsCorrect = true;
                break;
            case "2":
                charChoice = 2;
                choiceIsCorrect = true;
                break;
            case "3":
                charChoice = 3;
                choiceIsCorrect = true;
                break;
            default:
                choiceIsCorrect = false;
                break;
        }
    }

    break;
}

PlayerClass player;

switch (charChoice)
{
    case 1:
        player = new Warrior();
        break;
    case 2:
        player = new Archer();
        break;
    case 3:
        player = new Mage();
        break;
    default:
        player = new Warrior();
        break;
}

player.Setup();

choiceIsCorrect = false;

int points = 3;

bool wantToBuff = false;

while (!choiceIsCorrect)
{
    Console.Clear();
    Console.WriteLine($"Would you like to buff up your stats before starting?        (Limit: {points} points total)");
    Console.WriteLine("Response (Y/N): ");

    switch (Console.ReadLine())
    {
        case "Y":
            wantToBuff = true;
            choiceIsCorrect = true;
            break;
        case "N":
            wantToBuff = false;
            choiceIsCorrect = true;
            break;
        case "y":
            wantToBuff = true;
            choiceIsCorrect = true;
            break;
        case "n":
            wantToBuff = false;
            choiceIsCorrect = true;
            break;
        default:
            choiceIsCorrect = false;
            break;
    }
}


if (wantToBuff)
{
    choiceIsCorrect = false;

    int pointsToAdd = 0;

    while (points > 0)
    {
        while (!choiceIsCorrect)
        {
            Console.Clear();

            Console.WriteLine($"Remaining points: {points}");
            Console.Write("Select number of points to add: ");
            if (int.TryParse(Console.ReadLine(), out pointsToAdd))
            {
                if (pointsToAdd <= points && pointsToAdd != 0)
                {
                    points -= pointsToAdd;
                    choiceIsCorrect = false;

                    Console.Clear();
                    
                    Console.WriteLine("1) Add to Strenght");
                    Console.WriteLine("2) Add to Agility");
                    Console.WriteLine("3) Add to Inteligence");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            player.BuffStats(pointsToAdd, 0, 0);
                            break;
                        case "2":
                            player.BuffStats(0, 0, pointsToAdd);
                            break;
                        case "3":
                            player.BuffStats(0, pointsToAdd, 0);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    choiceIsCorrect = true;
                }
            }
            else
            {
                choiceIsCorrect = true;
            }

            if (points == 0)
            {
                choiceIsCorrect = true;
            }
        }
    }
    player.Setup();
}

using (var context = new RPGContext())
{
    var plr = new Player()
    {
        Class = player.GetType().Name,
        Strenght = player.Strenght,
        Inteligence = player.Inteligence,
        Agility = player.Agility,
        Health = player.Health,
        Damage = player.Damage,
        Mana = player.Mana,
        CreatedOn = DateTime.UtcNow
    };

    context.Players.Add(plr);
    context.SaveChanges();
}

map[1, 1] = player.Symbol;

int currX = 1, currY = 1;
char playerMove;

List<Enemy> enemies = new List<Enemy>();

while (player.Health > 0)
{
    choiceIsCorrect = false;

    enemies.Add(board.SpawnEnemy(map));

    while (!choiceIsCorrect)
    {
        board.Draw(map, player.Health, player.Mana, currX, currY, player.Symbol);

        switch (Console.ReadLine())
        {
            case "1":
                //TODO
                choiceIsCorrect = true;
                break;
            case "2":
                playerMove = board.ChooseDirection();
                board.MovePlayer(map, ref currX, ref currY, playerMove, player.Range, player.Symbol);
                choiceIsCorrect = true;
                break;
            default:
                choiceIsCorrect = false;
                break;
        }
    }

    foreach (var enemy in enemies)
    {
        if (enemy.CheckIfNearPlayer(map))
        {
            player.TakeDamage(enemy.Damage);
        }
        else
        {
            enemy.Move(map, currX, currY);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleRun
{
    internal class Program
    {
        Random rand = new Random();
        string[] fileMap1 = File.ReadAllLines("FileMap1.txt");
        char[,] map1;
        char player;
        char bomb = '*';
        char money = '$';
        bool isGameActive = true;
        bool isMapWasReaded;
        bool isPlayerWasSpawned;
        bool isBombWasSpawned;
        bool isMoneyWasSpawned;
        int points;
        int playerPosX;
        int playerPosY;
        int health;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
        private void Start()
        {
            health = 3;
            isMapWasReaded = false;
            isPlayerWasSpawned = false;
            isBombWasSpawned = false;
            isMoneyWasSpawned = false;

            Console.Clear();
            ChangeTheStyle(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine("Добро пожаловать в ConsoleRun! Нажмите на любую кнопку, чтобы продолжить");
            Console.ReadKey();

            ChooseTheStyle();
        }
        private void ChooseTheStyle()
        {
            Console.Clear();
            Console.WriteLine("Стили для игры:\n");
            Console.WriteLine("1. Жёлтый на тёмном \n2. Синий на сером \n3. Чёрный на белом \nДругие цифры. Белый на тёмном");
            Console.Write("\nВаш выбор: ");

            int colorIndex = Convert.ToInt32(Console.ReadLine());

            switch (colorIndex)
            {
                case 1:
                    ChangeTheStyle(ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case 2:
                    ChangeTheStyle(ConsoleColor.Gray, ConsoleColor.Blue);
                    break;
                case 3:
                    ChangeTheStyle(ConsoleColor.White, ConsoleColor.Black);
                    break;
                default:
                    ChangeTheStyle(ConsoleColor.Black, ConsoleColor.White);
                    break;
            }

            Console.Write("\nВведите ОК для продолжения: ");
            string continueGame = Console.ReadLine();

            if (continueGame == "ок" || continueGame == "ОК" || continueGame == "Ок")
                StartGame();
            else
            {
                ChangeTheStyle(ConsoleColor.Black, ConsoleColor.White);
                ChooseTheStyle();
            }
        }
        private void ChangeTheStyle(ConsoleColor background, ConsoleColor text)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = text;
        }
        private void StartGame()
        {
            player = ChooseYourCharacter();
            Console.CursorVisible = false;

            while (isGameActive)
            {
                PrintWorld(ref map1, fileMap1);
                PlayerControl(map1);

                Console.Clear();
            }
        }
        private char ChooseYourCharacter()
        {
            Console.Clear();
            Console.WriteLine("Персонажи для игры:\n");
            Console.WriteLine("1. @ \n2. & \n3. X\n4. Магазин персонажей");
            Console.Write("\nВаш выбор: ");

            int characterIndex = Convert.ToInt32(Console.ReadLine());

            switch (characterIndex)
            {
                case 1:
                    return '@';
                case 2:
                    return '&';
                case 3:
                    return 'X';
                case 4:
                    Shop shop = new Shop(points);

                    return shop.GetPlayer();
                default:
                    return '@';
            }
        }
        private void PrintWorld(ref char[,] map, string[] fileMap)
        {
            if (!isMapWasReaded)
            {
                map = ReadMap(fileMap);
                isMapWasReaded = true;
            }

            RandomSpawnSimbol(bomb, ref map, 8, ref isBombWasSpawned);
            RandomSpawnSimbol(money, ref map, 1, ref isMoneyWasSpawned);

            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }

                Console.WriteLine();
            }

            if (!isPlayerWasSpawned)
            {
                RandomSpawnPlayer(map);
                isPlayerWasSpawned = true;
            }

            Console.SetCursorPosition(playerPosX, playerPosY);
            Console.Write(player);
            Console.SetCursorPosition(map.GetLength(0) + 3, 1);
            Console.Write("Ваш счёт: " + points);
            Console.SetCursorPosition(map.GetLength(0) + 3, 3);

            HealthBar(health, ConsoleColor.Green);
        }
        private char[,] ReadMap(string[] fileMap)
        {
            char[,] map = new char[fileMap[0].Length, fileMap.Length];

            for (int y = 0; y < map.GetLength(1); y++)
                for (int x = 0; x < map.GetLength(0); x++)
                    map[x, y] = fileMap[y][x];

            return map;
        }
        private void RandomSpawnSimbol(char simbol, ref char[,] map, int count, ref bool wasSpawned)
        {
            if (!wasSpawned)
            {
                int randomSpawnX = 0;
                int randomSpawnY = 0;

                if (count <= 0)
                    count = 1;

                for (int i = 0; i < count; i++)
                {
                    GetRandomPosition(ref randomSpawnX, ref randomSpawnY, map);

                    map[randomSpawnX, randomSpawnY] = simbol;
                }

                wasSpawned = true;
            }
        }
        private void RandomSpawnPlayer(char[,] map)
        {
            int randomSpawnX = 0;
            int randomSpawnY = 0;

            GetRandomPosition(ref randomSpawnX, ref randomSpawnY, map);

            playerPosX = randomSpawnX;
            playerPosY = randomSpawnY;
        }
        private void GetRandomPosition(ref int posX, ref int posY, char[,] map)
        {
            while (map[posX, posY] != ' ')
            {
                posX = rand.Next(0, map.GetLength(0));
                posY = rand.Next(0, map.GetLength(1));
            }
        }
        private void PlayerControl(char[,] map)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:

                    if (map[playerPosX, playerPosY - 1] != '#')
                    {
                        playerPosY--;
                        IsSimbolWasGot(map);
                    }

                    break;
                case ConsoleKey.DownArrow:

                    if (map[playerPosX, playerPosY + 1] != '#')
                    {
                        playerPosY++;
                        IsSimbolWasGot(map);
                    }

                    break;
                case ConsoleKey.LeftArrow:

                    if (map[playerPosX - 1, playerPosY] != '#')
                    {
                        playerPosX--;
                        IsSimbolWasGot(map);
                    }

                    break;
                case ConsoleKey.RightArrow:

                    if (map[playerPosX + 1, playerPosY] != '#')
                    {
                        playerPosX++;
                        IsSimbolWasGot(map);
                    }
                    break;
            }
        }
        private void IsSimbolWasGot(char[,] map)
        {
            if (map[playerPosX, playerPosY] == money)
            {
                map[playerPosX, playerPosY] = ' ';
                points++;
                isBombWasSpawned = false;
                isMoneyWasSpawned = false;
            }
            else if (map[playerPosX, playerPosY] == bomb)
            {
                map[playerPosX, playerPosY] = ' ';
                health -= 1;
                IsDeath(health);
            }
        }
        private void HealthBar(int health, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            string lenght = "";

            Console.Write("Количество здоровья: [");
            Console.ForegroundColor = color;

            for (int i = 0; i < health; i++)
                lenght += "+";

            Console.Write(lenght);
            Console.ForegroundColor = defaultColor;
            Console.Write(']');
        }
        private void IsDeath(int health)
        {
            if (health <= 0)
            {
                Console.CursorVisible = true;
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы проиграли!");
                Console.Write("Чтобы перезапустить игру, введите РЕСТАРТ: ");

                string continueGame = Console.ReadLine();

                if (continueGame == "рестарт" || continueGame == "РЕСТАРТ" || continueGame == "Рестарт")
                    Start();

                isGameActive = false;
            }
        }
    }

    class Shop
    {
        char defaultPlayer = '@';
        char[] players = new char[] { '☻', '♥', '☺' };
        string[] cost = new string[] { "10$", "15$", "25$" };
        int points;

        public Shop(int points)
        {
            this.points = points;
        }
        public char GetPlayer()
        {
            Console.Clear();

            for (int i = 0; i < players.Length; i++)
                Console.WriteLine($"{players[i]} - {cost[i]}");

            Console.WriteLine($"\nУ тебя: {points} долларов");

            Console.Write("\nВыберите персонажа: ");

            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    return BuyPlayer(10, 0);
                case 2:
                    return BuyPlayer(15, 1);
                case 3:
                    return BuyPlayer(25, 2);
                default:
                    return defaultPlayer;
            }
        }

        private char BuyPlayer(int cost, int playerIndex)
        {
            if (points < cost)
            {
                Console.WriteLine("\nнедостаточно средств");
                Console.ReadKey();

                return defaultPlayer;
            }
            else
            {
                return players[playerIndex];
            }
        }
    }
}
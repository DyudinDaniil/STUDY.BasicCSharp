using System;
using System.IO;

namespace GameProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = ReadMap("map.txt");
            int[] playerPositions = { 1, 1 };

            while (true)
            {
                Console.Clear();
                DrawMap(map);

                Console.SetCursorPosition(playerPositions[0], playerPositions[1]);
                Console.Write("@");
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                CharacterMovement(pressedKey, playerPositions, map);
            }

        }

        private static int GetMaxLength(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (string line in lines) 
                if (line.Length > maxLength)
                    maxLength = line.Length;

            return maxLength;
        }

        private static char[,] ReadMap(string path)
        {
            string[] lines = File.ReadAllLines(path);
            char[,] map = new char[GetMaxLength(lines), lines.Length];

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                    map[x, y] = lines[y][x];

            return map;
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

        private static void CharacterMovement(ConsoleKeyInfo pressedKey, int[] playerPositions, char[,] map)
        {
            int posX = playerPositions[0];
            int posY = playerPositions[1];

            switch (pressedKey.KeyChar)
            {
                case 'w':
                    if (map[posX, posY - 1] != '#')
                        --posY;
                    break;
                case 's':
                    if (map[posX, posY + 1] != '#')
                        ++posY;
                    break;
                case 'a':
                    if (map[posX - 1, posY] != '#')
                        --posX;
                    break;
                case 'd':
                    if (map[posX + 1, posY] != '#')
                        ++posX;
                    break;
            }
            playerPositions[0] = posX;
            playerPositions[1] = posY;
        }
    }
}

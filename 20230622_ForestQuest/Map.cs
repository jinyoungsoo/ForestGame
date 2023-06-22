using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace _20230622_ForestQuest
{
    public class Map
    {
        public int boardSize; // 보드의 크기

        public int posX; // 플레이어의 X 좌표
        public int posY; // 플레이어의 Y 좌표

        public int forestX;
        public int forestY;

        public int randomX; // 장애물의 X 좌표
        public int randomY; // 장애물의 Y 좌표


        public int randomBattle;

        int[][] board = new int[15][]; // 보드 배열

        const int FLOOR = 1; // 바닥을 나타내는 상수
        const int WALL = 0; // 벽을 나타내는 상수
        const int PLAYER = 2; //플레이어를 나타내는 상수
        const int NPC = 3;
        const int FOREST = 4;

     

        public void MapBoard()
        {
            boardSize = 15; // 보드의 크기 설정
            board = new int[boardSize][];

            Player(); // 플레이어 초기 위치 설정

            while (true)
            {
                PrintBoard(); // 보드 출력
            }
        }

        public void Player()
        {
            posX = boardSize / 2; // 플레이어의 X 좌표를 보드의 중앙으로 설정
            posY = boardSize / 2; // 플레이어의 Y 좌표를 보드의 중앙으로 설정
        }

        public void PrintBoard()
        {
            for (int y = 0; y < boardSize; y++)
            {
                board[y] = new int[boardSize * 2]; // 보드 배열 초기화
                for (int x = 0; x < boardSize * 2; x++)
                {
                    board[y][x] = 0; // 보드 배열의 모든 요소를 0으로 설정 (맵 전체 보드 생성)
                }
            }

            for (int y = 1; y < boardSize - 1; y++)
            {
                for (int x = 1; x < boardSize * 2 - 1; x++)
                {
                    board[y][x] = FLOOR; // 바닥을 나타내는 1로 설정
                }
            }


            



            board[10][22] = NPC;

            //숲 크기 및 위치 조절 부분
            for (int i = 1; i < 6; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    board[i][j] = FOREST;
                }
            }


            if (board[posY][posX] == FOREST)
            {
                Random random = new Random();
                randomBattle = random.Next(100);

                if (randomBattle <= 36)
                {
                    // 전투가 시작됩니다.
                    Console.WriteLine("전투가 시작되었습니다.");
                    ForestBattle forestBattle = new ForestBattle();
                    forestBattle.BattleGame();

                }                                                                 //위에는 출력 되는데 아래 출력이 이상함...
            }



            //플레이어 위치 표시
            board[posY][posX] = PLAYER;

            // 보드 출력
            for (int y = 0; y < boardSize; y++)
            {
                for (int x = 0; x < boardSize * 2; x++)
                {
                    if (board[y][x] == PLAYER)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("λ"); // 플레이어를 나타내는 문자 출력
                    }
                    else if (board[y][x] == WALL)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("■"); // 벽을 나타내는 문자 출력
                    }
                    else if (board[y][x] == FLOOR)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("□"); // 바닥을 나타내는 문자 출력
                    }
                    else if (board[y][x] == NPC)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("μ");   //NPC를 나타내는 문자 출력
                    }
                    else if (board[y][x] == FOREST)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("▲");
                    }
                }
                Console.WriteLine();
            }





            if (posY == 10 && posX == 23 || posY == 10 && posX == 21 || posY == 9 && posX == 22 || posY == 11 && posX == 22)
            {
                //board[10][22] = NPC;
                Console.WriteLine("NPC: 어서오세요, 여행자님! 제가 부탁할 일이 있습니다. \n");
                Console.WriteLine("NPC: 우리 마을은 위험한 몬스터로 고통받고 있습니다. \n");
                Console.WriteLine("NPC: 5마리를 처치해 주실 것을 부탁드리고 싶습니다. \n");

            }


           



            ConsoleKeyInfo userInput;
            userInput = Console.ReadKey(true);

            switch (userInput.Key)
            {
                case ConsoleKey.W:
                    if (board[posY - 1][posX] != WALL)
                    {
                        board[posY][posX] = FLOOR; // 이전 위치를 바닥으로 설정
                        posY--; // 플레이어의 위치를 위로 이동
                    }
                    break;

                case ConsoleKey.A:
                    if (board[posY][posX - 1] != WALL)
                    {
                        board[posY][posX] = FLOOR; // 이전 위치를 바닥으로 설정
                        posX--; // 플레이어의 위치를 왼쪽으로 이동
                    }
                    break;

                case ConsoleKey.S:
                    if (board[posY + 1][posX] != WALL)
                    {
                        board[posY][posX] = FLOOR; // 이전 위치를 바닥으로 설정
                        posY++; // 플레이어의 위치를 아래로 이동
                    }
                    break;

                case ConsoleKey.D:
                    if (board[posY][posX + 1] != WALL)
                    {
                        board[posY][posX] = FLOOR; // 이전 위치를 바닥으로 설정
                        posX++; // 플레이어의 위치를 오른쪽으로 이동
                    }
                    break;
            }
            
            Console.Clear(); // 콘솔 화면을 지움
        }
    }
}
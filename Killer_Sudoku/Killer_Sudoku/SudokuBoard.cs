using System;
using System.Collections.Generic;
using System.Text;

namespace Killer_Sudoku
{
    public class SudokuBoard
    {
        private int size;
        private int[,] board;

        public SudokuBoard(int s)
        {
            size = s;
            board = new int[size, size];
        }

        public void ReadInput()
        {
            for (int i = 0; i<size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = Convert.ToInt32(Console.ReadLine());
                    if(!CheckBoard())
                        Console.WriteLine("Hiba");
                }
            }
        }

        public void ShowBoard()
        {
            //4*4
            for (int i = 0; i < size; i++)
            {
                if(i == size/2)
                {
                    Console.WriteLine("---------");
                }
                for (int j = 0; j < size; j++)
                {
                    if(j == size/2)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool CheckBoard()
        {
            if (!checkRow()) return false;
            if (!checkColumn()) return false;
            if (!checkSquare()) return false;

            return true;
        }
        public int GetSize()
        {
            return size;
        }

        private void initCheck(bool[] check)
        {
            for (int j = 0; j < size; j++)
            {
                check[j] = false;
            }
        }
        private bool checkRow()
        {
            bool[] check = new bool[size];

            initCheck(check);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] != 0)
                    {
                        if (check[board[i, j] - 1]) return false;
                        else check[board[i, j] - 1] = true;
                    }
                }
                initCheck(check);
            }
            return true;
        }

        private bool checkColumn()
        {
            bool[] check = new bool[size];

            initCheck(check);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[j, i] != 0)
                    {
                        if (check[board[j, i] - 1]) return false;
                        else check[board[j, i] - 1] = true;
                    }
                }
                initCheck(check);
            }
            return true;
        }

        private bool checkSquare()
        {
            bool[] check = new bool[size];

            initCheck(check);

            for(int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (board[j, i] != 0)
                    {
                        if (check[board[j, i] - 1]) return false;
                        else check[board[j, i] - 1] = true;
                    }
                }
                if (j == 1) initCheck(check);
            }

            initCheck(check);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (board[i, j] != 0)
                    {
                        if (check[board[i, j] - 1]) return false;
                        else check[board[i, j] - 1] = true;
                    }
                }
                if (j == 1) initCheck(check);
            }
            return true;
        }
    }
}

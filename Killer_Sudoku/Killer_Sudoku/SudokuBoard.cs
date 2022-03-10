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
            bool[] check = new bool[size];
            
            for (int j = 0; j < size; j++)
            {
                check[j] = false;
            }

            for (int i = 0; i<size; i++)
            {
                for(int j = 0;j<size;j++)
                {
                    if (board[i, j] != 0)
                    {
                        if (check[board[i, j] - 1]) return false;
                        else check[board[i, j] - 1] = true;
                    }
                }
            
                for (int j = 0; j < size; j++)
                {
                    check[j] = false;
                }
            }

            return true;
        }
        public int GetSize()
        {
            return size;
        }
    }
}

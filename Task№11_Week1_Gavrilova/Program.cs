using System;

namespace Sudoku
{
    class Program
    {
        static int[,] board = new int[9, 9];
        static void Main(string[] args)
        {
            GenerateSudoku();
            PrintBoard();
            CheckingRepetition(0,0,0);
        }

        static void GenerateSudoku()
        {
            // Генерация начального решенного судоку
            // В данном случае приведен пример заполнения доски
            board = new int[,] {
                {5, 3, 4, 6, 7, 8, 9, 1, 2},
                {6, 7, 2, 1, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9}
            };
            MixSudoku();
        }

        // Перемешивание судоку
        static void MixSudoku()
        {
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {

                int col1 = rand.Next(9);
                int col2 = rand.Next(9);
                SwapCols(col1, col2);

                int row1 = rand.Next(9);
                int row2 = rand.Next(9);
                SwapRows(row1, row2);

            }
        }
        static void SwapCols(int col1, int col2)
        {
            for (int i = 0; i < 9; i++)
            {
                int temp = board[i, col1];
                board[i, col1] = board[i, col2];
                board[i, col2] = temp;
            }
        }
        static void SwapRows(int row1, int row2)
        {
            for (int j = 0; j < 9; j++)
            {
                int temp = board[row1, j];
                board[row1, j] = board[row2, j];
                board[row2, j] = temp;
            }
        }

        
        static bool CheckingRepetition(int row, int col, int num)
        {
            // Проверяем, что число num не повторяется в строке
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == num)
                {
                    return false;
                }
            }

            // Проверяем, что число num не повторяется в столбце
            for (int i = 0; i < 9; i++)
            {
                if (board[i, col] == num)
                {
                    return false;
                }
            }

            // Проверяем, что число num не повторяется в квадрате 3x3
            int startRow = row - (row % 3);
            int startCol = col - (col % 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[startRow + i, startCol + j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void PrintBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");

                    if (j == 2 || j == 5)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
                if (i == 2 || i == 5)
                {
                    Console.WriteLine("---------------------");
                }
            }
        }
    }
}

    

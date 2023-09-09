using System;

class Sudoku
{
    static int[,] board = new int[9,9];

    static void Main()
    {
        Console.WriteLine("Bienvenido a Sudoku!");

        InitializeBoard();
        PrintBoard();

        while (!IsSudokuComplete())
        {
            int row, col, value;

            Console.Write("Ingrese la fila (1-9): ");
            row = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Ingrese la columna (1-9): ");
            col = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Ingrese el número (1-9): ");
            value = int.Parse(Console.ReadLine());

            if (IsValidMove(row, col, value))
            {
                board[row, col] = value;
                PrintBoard();
            }
            else
            {
                Console.WriteLine("Movimiento inválido. Inténtelo nuevamente.");
            }
        }

        Console.WriteLine("¡Felicidades! Has completado el Sudoku.");
    }

    static void InitializeBoard()
    {
        // Aquí puedes generar un tablero válido de Sudoku 
        // O simplemente, como en este ejemplo, inicializar con ceros
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                board[i, j] = 0;
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine("Tablero:");
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static bool IsValidMove(int row, int col, int value)
    {
        if (value < 1 || value > 9 || board[row, col] != 0)
        {
            return false;
        }

        // Comprueba si el valor no se repite en la misma fila o columna
        for (int i = 0; i < 9; i++)
        {
            if (board[row, i] == value || board[i, col] == value)
            {
                return false;
            }
        }

        return true;
    }

    static bool IsSudokuComplete()
    {
        // Comprueba si todas las celdas están llenas  
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
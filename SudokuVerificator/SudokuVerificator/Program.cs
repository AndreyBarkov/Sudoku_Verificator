using System;

namespace SudokuVerificator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sudokuVerificator = new Verificator();
            do
            {
                Console.Write(
                    "==============================================================================================");
                Console.Write(
                    "\n\nPlease enter the path to your sudoku solution (Ex ./input.txt or c:/sudoku/input.txt)\nFile path:");

                var path = Console.ReadLine();

                if (sudokuVerificator.IsValidSudokuSolution(path))
                {
                    Console.Write("\n Congratulations! This is a valid sudoku solution");
                }
                else
                {
                    Console.Write("\nThis doesn't look right...\n");
                }

                Console.Write(
                    "\n\nWould you like to check another sudoku solution?\nPress any key to try again or press Esc to close the program\n");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
            } while (true);
        }
    }
}
using System;

namespace SudokuVerificator
{
    public class GridSizeException : Exception
    {
        public GridSizeException()
            : base("\nERROR: provided sudoku file doesn\'t match 9x9 grid\n")
        {
        }
    }

    public class EmptySolutionException : Exception
    {
        public EmptySolutionException()
            : base("\nERROR: provided sudoku file is empty\n")
        {
        }
    }

    public class InvalidFilePathException : Exception
    {
        public InvalidFilePathException()
            : base("\nERROR: please provide a valid path to the solution file\n")
        {
        }
    }
}
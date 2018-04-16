using System;
using System.Collections.Generic;
using System.IO;

namespace SudokuVerificator
{
    public class Verificator
    {
        private int[,] _sudokuMatrix;
        private const int NUM_COLUMNS = 9;
        private const int NUM_ROWS = 9;

        public bool IsValidSudokuSolution(string filename)
        {
            try
            {
                if (string.IsNullOrEmpty(filename))
                {
                    throw new InvalidFilePathException();
                }
                ReadSudokuFromFile(filename);
                if (!CheckMatrixCols() || !CheckMatrixRows())
                {
                    return false;
                }
                //checking 3x3 grids separately as it is a costly function
                if (!CheckThreeByThree())
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        //Parses input file and saves it's contents as 2d array
        private void ReadSudokuFromFile(string filename)
        {
            var input = File.ReadAllText(filename);
            if (string.IsNullOrEmpty(input))
            {
                throw new EmptySolutionException();
            }
            var sudoku = new int[9, 9];

            if (input.Split('\n').Length != NUM_ROWS)
                throw new GridSizeException();
            var i = 0;
            foreach (var row in input.Split('\n'))
            {
                if (row.Trim().Length != NUM_COLUMNS)
                    throw new GridSizeException();
                var j = 0;
                foreach (var col in row.Trim())
                {
                    sudoku[i, j] = (int)char.GetNumericValue(col);
                    j++;
                }
                i++;
            }
            _sudokuMatrix = sudoku;
        }

        //Checks columns of 2d array for any duplicates
        private bool CheckMatrixCols()
        {
            for (var i = 0; i < 9; i++)
            {
                var testSet = new List<int>();
                for (var j = 0; j < 9; j++)
                {
                    testSet.Add(_sudokuMatrix[j, i]);
                }
                if (ContainsDuplicates(testSet))
                {
                    return false;
                };
            }
            return true;
        }

        //Checks rows of 2d array for any duplicate
        private bool CheckMatrixRows()
        {
            for (var i = 0; i < 9; i++)
            {
               var testSet = new List<int>();
                for (var j = 0; j < 9; j++)
                {
                    testSet.Add(_sudokuMatrix[i, j]);
                }

                if (ContainsDuplicates(testSet))
                {
                    return false;
                };
            }
            return true;
        }

        private bool CheckThreeByThree()
        {
           for (var row = 0; row < 9; row+=3)
                {
                    for (var col = 0; col < 9; col += 3)
                    {
                        var testSet = new List<int>();
                        for (var i = row; i < row + 3; i++)
                        {
                            for (var j = col; j < col + 3; j++)
                            {
                                testSet.Add(_sudokuMatrix[i, j]);
                            }
                        }
                    if (ContainsDuplicates(testSet)) return false;
                    }
                }
            return true;
        }
        //returns true if duplicates found
        //Adding duplicate values to hash set would return false
        private bool ContainsDuplicates(int[] testSet)
        {
            var hashSet = new HashSet<int>();
            foreach (var t in testSet)
            {
                if (!hashSet.Add(t))
                {
                    return true;
                }
            }
            return false;
        }
        private bool ContainsDuplicates(List<int> testSet)
        {
            var hashSet = new HashSet<int>();
            foreach (var t in testSet)
            {
                if (!hashSet.Add(t))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
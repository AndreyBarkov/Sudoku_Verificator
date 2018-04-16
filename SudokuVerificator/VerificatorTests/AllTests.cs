using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuVerificator;

namespace VerificatorTests
{
    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void EmptyPath()
        {
            var verificator = new Verificator();
            var path = string.Empty;
            Assert.IsFalse(verificator.IsValidSudokuSolution(path));
        }

        [TestMethod]
        public void EmptyFile()
        {
            var verificator = new Verificator();
            var path = "./TestFile.txt";
            File.Create(path).Dispose();
            Assert.IsFalse(verificator.IsValidSudokuSolution(path));
        }

        [TestMethod]
        public void FileWithLineCharacters()
        {
            var verificator = new Verificator();
            var path = "./TestFile.txt";
            using (var sw = File.AppendText(path))
            {
                sw.WriteLine("");
            }

            Assert.IsFalse(verificator.IsValidSudokuSolution(path));
        }

        [TestMethod]
        public void FileWithNotEnoughValues()
        {
            var verificator = new Verificator();
            var path = "./TestFileNotEnoughValues.txt";
            var solution = "123456789\n" +
                           "123456789\n" +
                           "1234123456\n";
            File.WriteAllText(path, solution);
            Assert.IsFalse(verificator.IsValidSudokuSolution(path));
        }

        [TestMethod]
        public void FileWithTooManuValues()
        {
            var verificator = new Verificator();
            var path = "./TestFileTooManyValues.txt";
            var solution = "123456789\n" +
                           "123456789\n" +
                           "123456789\n" +
                           "123456789\n" +
                           "123456789\n" +
                           "123456789\n" +
                           "123456789\n" +
                           "123456789\n" +
                           "123456789\n" +
                           "123456789\n";
            File.WriteAllText(path, solution);
            Assert.IsFalse(verificator.IsValidSudokuSolution(path));
        }

        [TestMethod]
        public void FileWithValidSolution()
        {
            var verificator = new Verificator();
            var path = "./TestFileValid.txt";
            var solution = "534678912\r\r\n" +
                           "672195348\r\r\n" +
                           "198342567\r\r\n" +
                           "859761423\r\r\n" +
                           "426853791\r\r\n" +
                           "713924856\r\r\n" +
                           "961537284\r\r\n" +
                           "287419635\r\r\n" +
                           "345286179";
            File.WriteAllText(path, solution);
            Assert.IsTrue(verificator.IsValidSudokuSolution(path));
        }

        [TestMethod]
        public void FileWithValidWrongSolutionCols()
        {
            var verificator = new Verificator();
            var path = "./TestFileValid.txt";
            var solution = "534678912\r\r\n" +
                           "672195348\r\r\n" +
                           "198342567\r\r\n" +
                           "859761423\r\r\n" +
                           "426853791\r\r\n" +
                           "713924856\r\r\n" +
                           "961537284\r\r\n" +
                           "287419635\r\r\n" +
                           "345286197";
            File.WriteAllText(path, solution);
            Assert.IsFalse(verificator.IsValidSudokuSolution(path));
        }

        [TestMethod]
        public void FileWithValidWrongSolutionRows()
        {
            var verificator = new Verificator();
            var path = "./TestFileValid.txt";
            var solution = "534678912\r\r\n" +
                           "672195348\r\r\n" +
                           "198342567\r\r\n" +
                           "859761423\r\r\n" +
                           "426853791\r\r\n" +
                           "713924856\r\r\n" +
                           "961537284\r\r\n" +
                           "287419635\r\r\n" +
                           "345286177";
            File.WriteAllText(path, solution);
            Assert.IsFalse(verificator.IsValidSudokuSolution(path));
        }
    }
}
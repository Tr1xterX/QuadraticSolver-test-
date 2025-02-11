using Xunit;
using System.Collections.Generic;
using QuadraticSolver;
using System;
using System.IO;

namespace UnitTests
{
    public class FileInputReaderTests
    {
        // хранения пути к папке с файлами
        private static readonly string InputFilesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\QuadraticSolver\InputFileForTest");

        [Fact]
        public void ReadInput_ValidFile_ReturnsCorrectCoefficients()
        {
            string filePath = Path.Combine(InputFilesDirectory, "test1.txt");
            var reader = new FileInputReader(filePath);
            var coefficients = reader.ReadInput();
            Assert.Equal(new List<(double, double, double)>
            {
                (1, 0, 1),
                (2, 5, -3.5),
                (1, 1, 1),
                (1, 4, 1)
            }, coefficients);
        }

        [Fact]
        public void ReadInput_EmptyFile_ReturnsEmptyList()
        {
            string filePath = Path.Combine(InputFilesDirectory, "test3.txt");
            var reader = new FileInputReader(filePath);
            var coefficients = reader.ReadInput();
            Assert.Empty(coefficients);
        }

        [Fact]
        public void ReadInput_InvalidFile_ThrowsException()
        {
            string filePath = Path.Combine(InputFilesDirectory, "test2.txt");
            var reader = new FileInputReader(filePath);
            Assert.Throws<FormatException>(() => reader.ReadInput());
        }
    }
}

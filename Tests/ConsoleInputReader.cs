using QuadraticSolver;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace UnitTests
{
    
    public class ConsoleInputReaderTests
    {
        [Fact]
        public void ReadInput_ValidInput_ReturnsCorrectCoefficients()
        {
            // Arrange
            var input = "1 0 1\n2 5 -3.5\n1 1 1\n1 4 1\n";
            var expectedCoefficients = new List<(double, double, double)>
            {
                (1, 0, 1),
                (2, 5, -3.5),
                (1, 1, 1),
                (1, 4, 1)
            };

            using (var reader = new StringReader(input))
            {
                Console.SetIn(reader);

                
                var consoleInputReader = new ConsoleInputReader();
                var coefficients = consoleInputReader.ReadInput();

                
                Assert.Equal(expectedCoefficients, coefficients);
            }
        }

    [Fact]
        public void ReadInput_EmptyInput_ReturnsEmptyList()
        {
            
            var input = "";

            using (var reader = new StringReader(input))
            {
                Console.SetIn(reader);

                
                var consoleInputReader = new ConsoleInputReader();
                var coefficients = consoleInputReader.ReadInput();

                
                Assert.Empty(coefficients);
            }
        }

        [Fact]
        public void ReadInput_InvalidInput_HandlesGracefully()
        {
            
            var input = "1 0 1\ninvalid input\n2 5 -3.5\n";
            var expectedCoefficients = new List<(double, double, double)>
            {
                (1, 0, 1),
                (2, 5, -3.5)
            };

            using (var reader = new StringReader(input))
            {
                Console.SetIn(reader);

                
                var consoleInputReader = new ConsoleInputReader();
                var coefficients = consoleInputReader.ReadInput();

                
                Assert.Equal(expectedCoefficients, coefficients);
            }
        }
    }
}

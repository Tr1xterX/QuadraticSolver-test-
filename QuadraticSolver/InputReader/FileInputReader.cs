
using System.Collections.Generic;
using System.IO;

namespace QuadraticSolver
{
    public class FileInputReader: IInputReader
    {
        private readonly string _filePath;

        public FileInputReader(string filePath)
        { 
            _filePath = filePath;
        }

        public List<(double, double, double)> ReadInput()
        {
            var coefficients = new List<(double, double, double)> ();
            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                if (parts.Length == 3 &&
                    double.TryParse(parts[0], out double a) &&
                    double.TryParse(parts[1], out double b) &&
                    double.TryParse(parts[2], out double c))
                {
                    coefficients.Add((a, b, c));
                }
            }
            return coefficients;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
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
            try
            {
                var lines = File.ReadAllLines(_filePath);
                Console.WriteLine($"Считывание данных из файла: {_filePath}");

                if (lines.Length == 0)
                {
                    Console.WriteLine("Файл пустой.");
                    return coefficients;
                }

                //Console.WriteLine("Содержимое файла:");
                foreach (var line in lines)
                {
                    //Console.WriteLine(line); // Вывод каждой строки для отладки
                    var parts = line.Split(' ');
                    if (parts.Length == 3 &&
                        double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double a) && //отрабатываем любые стили чистлового формата (. и ,)
                        double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double b) &&
                        double.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double c))
                    {
                        coefficients.Add((a, b, c));
                        Console.WriteLine($"Считаны коэффициенты: {a}, {b}, {c}");
                    }
                    else
                    {
                         throw new FormatException($"Ошибка при чтении строки: {line}");
                    }
                }
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is UnauthorizedAccessException)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                throw;
            }

            return coefficients;
           
        }
    }
}

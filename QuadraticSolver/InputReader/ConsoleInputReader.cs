using System;
using System.Collections.Generic;
using System.Globalization;

namespace QuadraticSolver
{
    public class ConsoleInputReader : IInputReader
    {
        public List<(double, double, double)> ReadInput()
        {
            var coefficients = new List<(double, double, double)>();
            try
            {
                while (true)
                {
                    Console.WriteLine("Введите коэффициенты: a b c (через пробел каждый) или оставьте строку пустой для завершения ввода:");
                    var input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        break; // Завершаем ввод, если строка пустая
                    }

                    var parts = input.Split(' ');
                    if (parts.Length == 3 &&
                        double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double a) && //отрабатываем любые стили чистлового формата (. и ,)
                        double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double b) &&
                        double.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double c))
                    {
                        coefficients.Add((a, b, c));
                    }
                    else
                    {
                        Console.WriteLine("Введенные данные некорректны, пожалуйста, введите 3 коэффициента уравнения через пробел.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при считывании данных: {ex.Message}");
            }
            return coefficients;
        }
    }
}

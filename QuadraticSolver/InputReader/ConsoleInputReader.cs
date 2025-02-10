using System;
using System.Collections.Generic;


namespace QuadraticSolver
{
    public class ConsoleInputReader : IInputReader
    {
        public List<(double, double, double)> ReadInput()
        {
            var coefficinets = new List<(double, double, double)>();

            try
            {
                while (true)
                {
                    Console.WriteLine("Введите коэффициенты: a b c (через пробел кажджый)");
                    var input = Console.ReadLine();

                    var parts = input.Split(' '); ;
                    if (parts.Length == 3 &&
                            double.TryParse(parts[0], out double a) &&
                            double.TryParse(parts[1], out double b) &&
                            double.TryParse(parts[2], out double c))
                    {
                        coefficinets.Add((a, b, c));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введенные данные некоорректы, пожалуйста введите 3 коэффициента уравнения через пробел");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при решении: {ex.Message}");
            }
            return coefficinets;
        }
    }
}

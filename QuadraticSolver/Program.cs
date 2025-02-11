using System;
using System.Collections.Generic;

namespace QuadraticSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IInputReader inputReader;

                Console.WriteLine("Выберите способ ввода данных: 1 - Файл, 2 - Вручную");

                //Считываение данных
                while (true)
                {
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("Укажите путь к файлу:");
                        string file_path = Console.ReadLine();
                        //string file_path = @"D:\test2.txt";
                        Console.WriteLine(file_path);
                        inputReader = new FileInputReader(file_path);
                        break;
                    }
                    if (choice == "2")
                    {
                        inputReader = new ConsoleInputReader();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("вы ввели что-то не то..Попробуйте еще");
                    }
                }

                //заполнение коэффициентов
                var solver = new EquationSolver();
                List<(double, double, double)> coefficients;
                try
                {
                    coefficients = inputReader.ReadInput();
                    if (coefficients.Count == 0)
                    {
                        Console.WriteLine("Файл пустой или данные не считаны.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении данных: {ex.Message}");
                    return;
                }

                //Обработка уравения (решение и вывод)
                var processor = new EquationProcessor(solver);
                processor.ProcessEquations(coefficients);

            }
        }
    }
}

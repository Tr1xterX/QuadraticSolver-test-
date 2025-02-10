using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputReader inputReader;

            Console.WriteLine("Выберите способ ввода данных: 1 - Файл, 2 - Вручную");
            
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

            var solve = new EquationSolver();
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

            foreach (var (a, b, c) in coefficients)
            {
                try
                {
                    var (root1, root2) = solve.Solve(a, b, c);
                    Console.WriteLine($"Уравнение {a}x^2 + {b}x +{c} = 0 иммет корни: {root1} и {root2}.");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Ошибка в уравнении {a}x^2 + {b}x + {c} = 0: {ex.Message}");
                }
            }

        }
    }
}

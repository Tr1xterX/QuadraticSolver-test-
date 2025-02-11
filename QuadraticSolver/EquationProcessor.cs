using System;
using System.Collections.Generic;
using System.Numerics;

namespace QuadraticSolver
{
    public class EquationProcessor
    {
        private readonly EquationSolver _solver;

        public EquationProcessor(EquationSolver solver)
        {
            _solver = solver;
        }

        public void ProcessEquations(List<(double, double, double)> coefficients)
        {
            foreach (var (a, b, c) in coefficients)
            {
                try
                {
                    var (root1, root2, isComplex) = _solver.Solve(a, b, c);
                    Console.WriteLine($"\nУравнение {a}x^2 + {b}x + {c} = 0 имеет корни:");

                    if (isComplex)
                    {
                        Console.WriteLine("(Решение находится в комплексной плоскости)");
                    }

                    if (root1 == root2)
                    {
                        Console.WriteLine($"Корень: {root1.ToStringFormat()}");
                    }
                    else
                    {
                        Console.WriteLine($"Корень 1: {root1.ToStringFormat()}");
                        Console.WriteLine($"Корень 2: {root2.ToStringFormat()}");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Ошибка в уравнении {a}x^2 + {b}x + {c} = 0: {ex.Message}");
                }
            }
        }
    }
}
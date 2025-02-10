using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticSolver
{
    public class EquationSolver
    {
        public (double, double) Solve(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                throw new InvalidOperationException("Нет вещ. корней");//временная заглушка
            }

            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            return (root1, root2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticSolver
{
    public class EquationSolver
    {
        public (Complex, Complex, bool) Solve(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;
            bool isComplex = discriminant < 0;

            if (isComplex)
            {
                Complex sqrtDiscriminant = Complex.Sqrt(new Complex(discriminant, 0));
                Complex root1 = (-b + sqrtDiscriminant) / (2 * a);
                Complex root2 = (-b - sqrtDiscriminant) / (2 * a);
                return (root1, root2, isComplex);
            }
            else
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return ((Complex)root1, (Complex)root2, isComplex); //(для единого формата вывода)
            }
        }
    }
}

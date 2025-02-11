using System;
using System.Numerics;


namespace QuadraticSolver
{
    public static class ComplexExtensions
    {
        public static string ToStringFormat(this Complex number)
        {
            // Округляем до 5 знаков (избежание вычисл. ошибок с плав. точкой)
            double realPart = Math.Round(number.Real, 5);
            double imaginaryPart = Math.Round(number.Imaginary, 5);

            if (imaginaryPart == 0)
            {
                return $"{realPart}";
            }
            if (realPart == 0)
            {
                return $"{imaginaryPart}i";
            }
            if (imaginaryPart < 0)
            {
                return $"{realPart}{imaginaryPart}i";
            }
            else
            {
                return $"{realPart}+{imaginaryPart}i";
            }
                
        }
    }
}

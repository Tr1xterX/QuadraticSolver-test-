using System;
using System.Collections.Generic;


namespace QuadraticSolver
{
    public interface IInputReader
    {
        List<(double, double, double)> ReadInput();
    }
}

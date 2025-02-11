using Xunit;
using System.Numerics;
using QuadraticSolver;
using UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Xunit.Assert;


namespace UnitTests
{
    public class EquationSolverTests
    {
        [Fact]
        public void Solve_TwoRealRoots_ReturnsCorrectRoots()
        {
            var solver = new EquationSolver();
            var (root1, root2, isComplex) = solver.Solve(1, -3, 2);
            Assert.Equal(new Complex(2, 0), root1);
            Assert.Equal(new Complex(1, 0), root2);
            Assert.False(isComplex);
        }

        [Fact]
        public void Solve_OneRealRoot_ReturnsSameRootTwice()
        {
            var solver = new EquationSolver();
            var (root1, root2, isComplex) = solver.Solve(1, -2, 1);
            Assert.Equal(new Complex(1, 0), root1);
            Assert.Equal(new Complex(1, 0), root2);
            Assert.False(isComplex);
        }

        [Fact]
        public void Solve_NoRealRoots_ReturnsComplexRoots()
        {
            var solver = new EquationSolver();
            var (root1, root2, isComplex) = solver.Solve(1, 1, 1);
            var expectedRoot1 = new Complex(-0.5, 0.866025403784439);
            var expectedRoot2 = new Complex(-0.5, -0.866025403784439);

            //возможная погрешность крайних значнений ввиду плавающей точки
            Assert.True(Complex.Abs(root1 - expectedRoot1) < 1e-10, $"Root1 differs: expected {expectedRoot1}, but got {root1}");
            Assert.True(Complex.Abs(root2 - expectedRoot2) < 1e-10, $"Root2 differs: expected {expectedRoot2}, but got {root2}");
            Assert.True(isComplex);
        }
    }
}
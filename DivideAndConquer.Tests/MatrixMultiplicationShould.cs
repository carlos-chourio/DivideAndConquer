using DivideAndConquer.LinearAlgebra;
using NUnit.Framework;

namespace DivideAndConquer.Tests {
    public class MatrixMultiplicationShould {
        [Test]
        public void GetQuadrant() {
            var sut = new MatrixMultiplication();
            Matrix matrix1 = new Matrix(new double[,]
            { 
              { 1, 2, 3, 4},
              { 5, 6, 7, 8 },
              { 9, 10, 11, 12 },
              { 13, 14, 15, 16}
            });
            Matrix matrix2 = new Matrix(new double[,]
            { 
              { 1, 2, 3, 4},
              { 5, 6, 7, 8 },
              { 9, 10, 11, 12 },
              { 13, 14, 15, 16}
            });
            var mult = sut.MultiplyMatrices(matrix1, matrix2);
            //int m = matrix1.ColumnSize, n = matrix1.RowSize;
            //var quadrant = matrix1.SubMatrix(m/2, m, n/2, n);
        }
    }
}

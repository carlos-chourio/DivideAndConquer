using DivideAndConquer.LinearAlgebra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DivideAndConquer {
    public class MatrixMultiplication {

        public Matrix MultiplyMatrices(Matrix matrix1, Matrix matrix2) {
            if (matrix1.RowSize == 2 && matrix1.ColumnSize == 2 &&
                matrix2.RowSize == 2 && matrix2.ColumnSize == 2) {
                double a = matrix1[0, 0] * matrix2[0, 0] + matrix1[0,1] * matrix2[1,0];
                double b = matrix1[0, 0] * matrix2[0, 1] + matrix1[0, 1] * matrix2[1, 1];
                double c = matrix1[1, 0] * matrix2[0, 0] + matrix1[1, 1] * matrix2[1, 0];
                double d = matrix1[1, 0] * matrix2[0, 1] + matrix1[1, 1] * matrix2[1, 1];
                return new Matrix(new double[,] { { a, b }, { c, d } });
            }
            var xQuadrants = GetCuadrants(matrix1);
            Matrix A = xQuadrants[0];
            Matrix B = xQuadrants[1];
            Matrix C = xQuadrants[2];
            Matrix D = xQuadrants[3];
            var yQuadrants = GetCuadrants(matrix2);
            Matrix E = yQuadrants[0];
            Matrix F = yQuadrants[1];
            Matrix H = yQuadrants[2];
            Matrix G = yQuadrants[3];
            Matrix P1 = MultiplyMatrices(A, F - H);
            Matrix P2 = MultiplyMatrices(A + B, H);
            Matrix P3 = MultiplyMatrices(C + D, E);
            Matrix P4 = MultiplyMatrices(G - E, D);
            Matrix P5 = MultiplyMatrices(A + D, E + H);
            Matrix P6 = MultiplyMatrices(B - D, G + H);
            Matrix P7 = MultiplyMatrices(A - C, E + F);
            Matrix x = P5 + P4 + P6 - P2;
            Matrix y = P1 + P2;
            Matrix z = P3 + P4;
            Matrix w = P1 - P5 - P3 - P7;
            Matrix up = x.AppendHorizontally(y);
            Matrix down = z.AppendHorizontally(w);
            Matrix result = up.AppendVertically(down);
            return result;
        }

        private Matrix[] GetCuadrants(Matrix matrix) {
            int m = matrix.ColumnSize, n = matrix.RowSize;
            Matrix[] quadrants = new Matrix[4];
            quadrants[0] = matrix.SubMatrix(0, m / 2, 0, n / 2);
            quadrants[1] = matrix.SubMatrix(m / 2, m, 0, n / 2);
            quadrants[2] = matrix.SubMatrix(0, m / 2, n / 2, n);
            quadrants[3] = matrix.SubMatrix(m / 2, m, n / 2, n);
            return quadrants;
        }
    }
}

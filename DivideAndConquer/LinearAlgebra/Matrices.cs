using System;

namespace Algorithms.Mathematics.LinearAlgebra {
    public class Matrices {
        public double[,] Add(double[,] matrix1, double[,] matrix2) {
            if (matrix1.GetLength(0) == matrix2.GetLength(0) &&
                matrix1.GetLength(1) == matrix2.GetLength(1)) {
                int firstDimensionSize = matrix1.GetLength(0);
                int secondDimensionSize = matrix1.GetLength(1);
                double[,] result = new double[firstDimensionSize, secondDimensionSize];
                for (int i = 0; i < firstDimensionSize; i++) {
                    for (int j = 0; j < secondDimensionSize; j++) {
                        result[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
            }
            throw new ArgumentOutOfRangeException("The matrices don't have the same size");
        }
    }
}

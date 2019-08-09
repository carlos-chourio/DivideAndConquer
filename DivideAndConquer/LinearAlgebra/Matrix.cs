using System;

namespace DivideAndConquer.LinearAlgebra {
    public class Matrix {
        private double[,] values;
        public double this[int row, int column] {
            get {
                return values[row, column];
            }
            set {
                values[row, column] = value;
            }
        }

        public int ColumnSize {
            get { return values.GetLength(1); }
        }

        public int RowSize {
            get { return values.GetLength(0); }
        }

        public Matrix(double[,] values) {
            this.values = values;
        }

        public Matrix(int rowSize, int columnSize) {
            values = new double[rowSize,columnSize ];
        }

        public static Matrix operator + (Matrix matrix1, Matrix matrix2) {
            return Sum(matrix1, matrix2, false);
        }

        public static Matrix operator - (Matrix matrix1, Matrix matrix2) {
            return Sum(matrix1, matrix2, true);
        }

        public static Matrix operator *(Matrix matrix, int alfa) {
            if (matrix != null) {
                for (int i = 0; i < matrix.RowSize; i++) {
                    for (int j = 0; j < matrix.ColumnSize; j++) {
                        matrix[i, j] = matrix[i, j] * alfa;
                    }
                }
                return matrix;
            }
            throw new ArgumentNullException("The matrix is null");
        }

        public static Matrix Sum(Matrix matrix1, Matrix matrix2, bool isSubtraction) {
            if (matrix1 != null && matrix2 != null) {
                if (matrix1.RowSize == matrix2.ColumnSize && matrix1.RowSize == matrix2.ColumnSize) {
                    double[,] result = new double[matrix1.RowSize, matrix1.ColumnSize];
                    for (int i = 0; i < matrix1.RowSize; i++) {
                        for (int j = 0; j < matrix1.ColumnSize; j++) {
                            result[i, j] = (isSubtraction)
                                ? matrix1[i, j] - matrix2[i, j]
                                : matrix1[i, j] + matrix2[i, j];
                        }
                    }
                    return new Matrix(result);
                }
                throw new ArgumentOutOfRangeException("The Matrices are not the same size");
            }
            throw new ArgumentNullException("At least one of the matrices is null");
        }

        public Matrix Transpose() {
            Matrix resultMatrix = new Matrix(ColumnSize, RowSize);
            for (int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    resultMatrix[j, i] = this[i, j];
                }
            }
            return resultMatrix;
        }

        public Matrix SubMatrix(int startColumn, int endColumn, int startRow,  int endRow) {
            Matrix result = new Matrix(RowSize / 2, ColumnSize / 2);
            for (int i = startColumn; i < endColumn; i++) {
                for (int j = startRow; j < endRow; j++) {
                    result[j - startRow, i - startColumn] = this[j, i];
                }
            }
            return result;
        }

        //public static Matrix operator *(Matrix matrix1, Matrix matrix2) {
        //    if (matrix1 != null && matrix2 != null) {
        //        if (matrix1.columnSize == matrix2.rowSize) {
        //            Matrix resultMatrix = new Matrix(matrix1.rowSize, matrix2.columnSize);
        //            resultMatrix.Zero();
        //            for (int i = 0; i < matrix1.rowSize; i++) {
        //                for (int j = 0; j < matrix2.rowSize; j++) {
        //                    for (int k = 0; k < matrix1.rowSize; k++) {
        //                        resultMatrix[i, j] = resultMatrix[i, j] + matrix1[i, k] * matrix2[k, j]; 
        //                    }
        //                }
        //                Console.WriteLine();
        //            }
        //            return resultMatrix;
        //        }
        //        throw new ArgumentOutOfRangeException("These matrices can't be multiplied");
        //    }
        //    throw new ArgumentNullException("At least one of the matrices is null");
        //}

        public Matrix Zero() {
            for (int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    this[i, j] = 0;
                }
            }
            return this;
        }

        public Matrix AppendHorizontally(Matrix matrix) {
            if (this.RowSize != matrix.RowSize || this.ColumnSize != matrix.ColumnSize) {
                throw new ArgumentOutOfRangeException(nameof(matrix), "It's not possible to append matrices of different sizes");
            }
            Matrix result = new Matrix(RowSize, 2 * ColumnSize);
            for (int i = 0; i < result.ColumnSize; i++) {
                for (int j = 0; j < RowSize; j++) {
                    if (i<ColumnSize) {
                        result[j, i] = this[j, i];
                    } else {
                        result[j, i] = matrix[j, i - result.ColumnSize];
                    }
                }
            }
            return result;
        }

        public Matrix AppendVertically(Matrix matrix) {
            if (this.RowSize != matrix.RowSize || this.ColumnSize != matrix.ColumnSize) {
                throw new ArgumentOutOfRangeException(nameof(matrix), "It's not possible to append matrices of different sizes");
            }
            Matrix result = new Matrix(2 * RowSize, ColumnSize);
            for (int i = 0; i < ColumnSize; i++) {
                for (int j = 0; j < result.RowSize; j++) {
                    if (i<RowSize) {
                        result[j, i] = this[j, i];
                    } else {
                        result[j, i] = matrix[j - result.RowSize, i];
                    }
                }
            }
            return result;
        }
    }
}
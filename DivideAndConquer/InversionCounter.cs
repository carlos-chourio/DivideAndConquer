using DivideAndConquer.Helper;
using System;

namespace DivideAndConquer {
    public class InversionCounter {
        public int CountInversions(int[] source) {
            (int[] left, int[] right) = ArrayHelper.Split(source);
            if (source.Length <= 2)
                return MergeAndCount(left, right);
            else {

                int leftInv = CountInversions(left);
                int rightInv = CountInversions(right);
                int totalInv = leftInv + rightInv + MergeAndCount(left, right);
                return totalInv;
            }
        }

        public int MergeAndCount(int[] A, int[] B) {
            int i = 0, j = 0, lenA = A.Length, lenB = B.Length, longitudC = lenA + lenB, inversionCount = 0;
            int[] C = new int[longitudC];
            bool aExhausted = false;
            for (int k = 0; k < longitudC - 1; k++) {
                if (A[i] < B[j] && !aExhausted) {
                    C[k] = A[i];
                    if (i < lenA - 1) {
                        i++;
                    } else {
                        aExhausted = true;
                    }
                } else {
                    C[k] = B[j];
                    if (!aExhausted) {
                        inversionCount += lenA - i;
                    }
                    if (j < lenB - 1) {
                        j++;
                    }
                }
            }
            if (lenA != 0 && lenB != 0) {
                C[lenA + lenB - 1] = A[lenA - 1].CompareTo(B[lenB - 1]) > 0 ? A[lenA - 1] : B[lenB - 1];
            } else if (lenA != 0) {
                C[lenA + lenB - 1] = A[lenA - 1];
            } else if (lenB != 0) {
                C[lenA + lenB - 1] = B[lenB - 1];
            }
            return inversionCount;
        }
    }
}  

using DivideAndConquer.Helper;
using System;

namespace DivideAndConquer {
    public class MergeSort<T> where T : IComparable {
        public T[] Sort(T[] value) {
            (T[] leftArray, T[] rightArray) splittedArray = ArrayHelper.Split(value);
            if (value.Length<=2) {
                return Merge(splittedArray.leftArray, splittedArray.rightArray);
            } else {
                var x = Sort(splittedArray.leftArray);
                var y = Sort(splittedArray.rightArray);
                return Merge(x, y);
            }
        }

        public T[] Merge(T[] a, T[] b) {
            int i = 0, j = 0, lengthA = a.Length, lengthB = b.Length;
            T[] c = new T[lengthA + lengthB];
            bool reachedTheEnd = false;
            for (int k = 0; k < lengthA + lengthB - 1; k++) {
                if (a[i].CompareTo(b[j]) < 0 && !reachedTheEnd) {
                    c[k] = a[i];
                    if (i < lengthA - 1) {
                        i++;
                    } else {
                        reachedTheEnd = true;
                    }
                } else {
                    c[k] = b[j];
                    if (j < lengthB - 1) {
                        j++;
                    }
                }
            }
            if (lengthA != 0 && lengthB != 0) {
                c[lengthA + lengthB - 1] = a[lengthA - 1].CompareTo(b[lengthB - 1]) > 0 ? a[lengthA - 1] : b[lengthB - 1];
            } else if (lengthA != 0) {
                c[lengthA + lengthB - 1] = a[lengthA - 1];
            } else if (lengthB != 0) {
                c[lengthA + lengthB - 1] = b[lengthB - 1];
            }
            return c;
        }
    }
}

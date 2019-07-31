using System;

namespace DivideAndConquer {
    public class MergeSort<T> where T : IComparable { 

        public T[] Sort(T[] value) {
            var splittedValue = Split(value);
            var value1 = splittedValue.Item1;
            var value2 = splittedValue.Item2;
            return Sort(value1, value2);
        }

        private T[] Sort(T[] value1, T[] value2) {
            if (value1.Length == 2) {
                return Merge(value1, value2);
            } else {
                value1 = Sort(value1);
                value2 = Sort(value2);
                return Sort(value1, value2);
            }
        }

        public T[] Merge(T[] a, T[] b) {
            int i = 0, j = 0, lengthA = a.Length, lengthB = b.Length;
            T[] c = new T[lengthA + lengthB];
            for (int k = 0; k < lengthA + lengthB - 1 ; k++) {
                if (a[i].CompareTo(b[j]) < 0) {
                    c[k] = a[i];
                    if (i < lengthA-1) {
                        i++;
                    }
                } else {
                    c[k] = b[j];
                    if (j < lengthB-1) {
                        j++;
                    }
                }
            }
            c[lengthA + lengthB - 1] = a[lengthA - 1].CompareTo(b[lengthB - 1]) > 0 ? a[lengthA - 1] : b[lengthB - 1];
            return c;
        }

        public (T[],T[]) Split(T[] value) {
            int leftSize = value.Length / 2;
            int rightSize = value.Length - leftSize;
            T[] left = new T[leftSize];
            T[] right = new T[rightSize];
            Array.Copy(value, left, leftSize);
            Array.Copy(value, leftSize, right, 0, rightSize);
            return (left, right);
        }
    }
}

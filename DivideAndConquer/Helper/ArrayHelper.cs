using System;

namespace DivideAndConquer.Helper {
    public static class ArrayHelper{
        public static (T[], T[]) Split<T>(T[] value) {
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

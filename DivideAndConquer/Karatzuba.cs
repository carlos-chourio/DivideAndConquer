using System;

namespace DivideAndConquer {
    public class Karatzuba {
        public int Multiply(int value1, int value2) {
            int n = value1.ToString().Length;
            int m = value2.ToString().Length;
            if (n ==1 && m == 1) {
                return value1 * value2;
            } else {
                int aux1 = (int)Math.Pow(10, n / 2);
                int aux2 = (int)Math.Pow(10, m / 2);
                int a = value1 / aux1;
                int b = value1 - a * aux1;
                int c = value2 / aux2;
                int d = value2 - c * aux2;
                return aux1*aux2 * Multiply(a, c) + aux1 * Multiply(a, d) + aux2 * Multiply(b, c) + Multiply(b, d);
            }
        }
    }
}

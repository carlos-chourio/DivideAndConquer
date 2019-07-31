using DivideAndConquer;
using NUnit.Framework;
using System;

namespace DivideAndConquerTests {
    public class KaratzubaShould {
        [Test]
        public void CalculateKaratzubaMultiplication() {
            var sut = new Karatzuba();
            var random = new Random();
            for (int i = 0; i < 100; i++) {
                int value1 = random.Next();
                int value2 = random.Next();
                int result = sut.Multiply(value1, value2);
                Assert.That(result, Is.EqualTo(value1 * value2));
            }
        }
    }
}

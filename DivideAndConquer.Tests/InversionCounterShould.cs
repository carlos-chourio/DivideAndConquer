using NUnit.Framework;

namespace DivideAndConquer.Tests {
    public class InversionCounterShould {
        [Test]
        public void CountInversions() {
            var mergeSort = new MergeSort<double>();
            var sut = new InversionCounter();
            int[] testArray = { 1, 3, 5, 2, 4, 6 };
            int splitInv = sut.CountInversions(testArray);
            Assert.That(splitInv, Is.EqualTo(3));
        }
    }
}

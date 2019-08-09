using NUnit.Framework;

namespace DivideAndConquer.Tests {
    public class InversionCounterShould {
        [Test]
        public void CountInversions() {
            var mergeSort = new MergeSort<double>();
            var sut = new InversionCounter();
            //int[] testArray = { 4, 1, 2, 3 };
            int[] testArray = { 6,  5, 4, 3, 2, 1 };

            int splitInv = sut.CountInversions(testArray);
            Assert.That(splitInv, Is.EqualTo(15));
        }
    }
}

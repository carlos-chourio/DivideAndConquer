using NUnit.Framework;
using System;
using System.Linq;

namespace DivideAndConquer.Tests {
    public class MergeAndSortShould {
        private Random _Random;

        [SetUp]
        public void Setup() {
            _Random = new Random();
        }

        [Test]
        public void MergeArray() {
            var sut = new MergeSort<double>();
            int size = _Random.Next(100);
            var x = GenerateRandomArray(size).OrderBy(t => t).ToArray();
            var y = GenerateRandomArray(size).OrderBy(t => t).ToArray();
            var result = sut.Merge(x, y);
            Assert.That(result, Has.Exactly(size*2).Items);
            Assert.That(result, Is.Ordered.Ascending);
        }

        [Test]
        public void SplitArrayInTwo() {
            var sut = new MergeSort<double>();
            int sourceSize = _Random.Next(100);
            var x = GenerateRandomArray(sourceSize);
            var result = sut.Split(x);
            Assert.That(result.Item1, Has.Exactly(sourceSize/2).Items);
            Assert.That(result.Item2, Has.Exactly(sourceSize - sourceSize / 2).Items);
            Assert.That(result.Item1, Is.EqualTo(x.Take(sourceSize / 2)));
            Assert.That(result.Item2, Is.EqualTo(x.Skip(sourceSize / 2).Take(sourceSize - sourceSize / 2)));
        }

        [Test]
        public void SortArray() {
            var sut = new MergeSort<double>();
            var x = GenerateRandomArray(_Random.Next(100));
            var result = sut.Sort(x);
            Assert.That(result, Has.Exactly(x.Length).Items);
            Assert.That(result, Is.Ordered.Ascending);
        }

        private double[] GenerateRandomArray(int size, int maxValue = 500) {
            double[] result = new double[size];
            for (int i = 0; i < size; i++) {
                result[i] = _Random.NextDouble() * maxValue;
            }
            return result;
        }
    }
}

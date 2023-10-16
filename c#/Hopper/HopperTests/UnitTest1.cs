using Hopper;
namespace HopperTests
{
    [TestFixture]
    public class HopperTestSuite
    {
        [Test]
        public void MixedValuesWithValidDAndM()
        {
            int result = Program.FindLongestExplorationSequence(8, 3, 4, new int[] { -3, -2, 1, 4, 3, 2, 5, 6 });
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void SingleJumpLength()
        {
            int result = Program.FindLongestExplorationSequence(5, 1, 1, new int[] { 1, 2, 3, 4, 5 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void MultipleJumpLengths()
        {
            int result = Program.FindLongestExplorationSequence(5, 3, 1, new int[] { 1, 3, 5, 2, 4 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void MultipleValueDifferences()
        {
            int result = Program.FindLongestExplorationSequence(5, 1, 3, new int[] { 1, 3, 2, 4, 5 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void SmallestPossibleValues()
        {
            int result = Program.FindLongestExplorationSequence(1, 1, 1, new int[] { 1 });
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void NoValidJumpsAvailable()
        {
            int result = Program.FindLongestExplorationSequence(4, 1, 1, new int[] { 1, 5, 9, 13 });
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void NoValidJumpsDueToD()
        {
            int result = Program.FindLongestExplorationSequence(4, 1, 5, new int[] { 1, 5, 9, 13 });
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void AllElementsAreTheSame()
        {
            int result = Program.FindLongestExplorationSequence(4, 3, 0, new int[] { 1, 1, 1, 1 });
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void TestMaxD()
        {
            int result = Program.FindLongestExplorationSequence(10, 7, 1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void TestMaxM()
        {
            int result = Program.FindLongestExplorationSequence(3, 1, 10000, new int[] { -10000, 0, 10000 });
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void TestMaxArraySize()
        {
            int[] largeArray = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                largeArray[i] = i;
            }
            int result = Program.FindLongestExplorationSequence(1000, 7, 10000, largeArray);
            Assert.That(result, Is.EqualTo(1000));
        }

        [Test]
        public void TestMaxIntegerValue()
        {
            int result = Program.FindLongestExplorationSequence(3, 1, 2000000, new int[] { -1000000, 0, 1000000 });
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void MaxJumpsBackAndForth()
        {
            int result = Program.FindLongestExplorationSequence(5, 2, 1, new int[] { 1, 2, 3, 2, 1 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void MultipleOptimalPaths()
        {
            int result = Program.FindLongestExplorationSequence(6, 2, 2, new int[] { 1, 2, 3, 4, 3, 2 });
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void AllElementsWithinMButBeyondD()
        {
            int result = Program.FindLongestExplorationSequence(4, 1, 2, new int[] { 1, 5, 2, 6 });
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void AllElementsWithinDButBeyondM()
        {
            int result = Program.FindLongestExplorationSequence(3, 2, 1, new int[] { 1, 3, 5 });
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void SequenceNotStartingAtArrayEnds()
        {
            int result = Program.FindLongestExplorationSequence(5, 2, 1, new int[] { 2, 3, 1, 2, 3 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void AlternatingSequence()
        {
            int result = Program.FindLongestExplorationSequence(5, 2, 3, new int[] { 1, 4, 1, 4, 1 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void TestMaxDAndM()
        {
            int result = Program.FindLongestExplorationSequence(5, 7, 10000, new int[] { 1, 10001, 20001, 30001, 40001 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void MultipleIslands()
        {
            int result = Program.FindLongestExplorationSequence(9, 2, 1, new int[] { 1, 2, 3, 10, 11, 12, 20, 21, 22 });
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void NonMonotonicWithLargeGaps()
        {
            int result = Program.FindLongestExplorationSequence(5, 4, 1000, new int[] { 1, 2, 1000, 1001, 1002 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void EdgeCasesIntegerRanges()
        {
            int result = Program.FindLongestExplorationSequence(3, 1, 2000000, new int[] { -1000000, 0, 1000000 });
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void RepeatingElements()
        {
            int result = Program.FindLongestExplorationSequence(6, 2, 1, new int[] { 1, 1, 2, 2, 3, 3 });
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void SequenceNotAtEdgesAdditional()
        {
            int result = Program.FindLongestExplorationSequence(7, 3, 1, new int[] { 3, 4, 1, 2, 3, 4, 5 });
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void ReverseSequences()
        {
            int result = Program.FindLongestExplorationSequence(5, 1, 1, new int[] { 5, 4, 3, 2, 1 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void PerformanceTest()
        {
            int[] largeArray = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                largeArray[i] = i;
            }
            int result = Program.FindLongestExplorationSequence(1000, 7, 10000, largeArray);
            Assert.That(result, Is.EqualTo(1000));
        }

        [Test]
        public void NegativeNumbersOnly()
        {
            int result = Program.FindLongestExplorationSequence(5, 2, 1, new int[] { -1, -2, -3, -4, -5 });
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void MixedPositiveAndNegative()
        {
            int result = Program.FindLongestExplorationSequence(6, 2, 2, new int[] { -1, 1, -2, 2, -3, 3 });
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void AlternatingPositiveAndNegative()
        {
            int result = Program.FindLongestExplorationSequence(6, 1, 2, new int[] { 1, -1, 1, -1, 1, -1 });
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void TestMinDAndMaxM()
        {
            int result = Program.FindLongestExplorationSequence(5, 1, 10000, new int[] { -10000, 0, 9999, -9999, 10000 });
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void TestMaxDAndMinM()
        {
            int result = Program.FindLongestExplorationSequence(8, 7, 1, new int[] { 1, 2, 1, 2, 1, 2, 1, 2 });
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void NegativeValuesWithZero()
        {
            int result = Program.FindLongestExplorationSequence(4, 2, 1, new int[] { -1, 0, -1, 0 });
            Assert.That(result, Is.EqualTo(4));
        }
    }
}
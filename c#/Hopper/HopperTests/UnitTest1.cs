using Hopper;
namespace HopperTests
{
    [TestFixture]
    public class HopperTestSuite
    {
        /// <summary>
        /// Tests a mixed set of negative and positive numbers with valid D and M values.
        /// D = 3
        /// M = 4
        /// [-3, -2, 1, 4, 3, 2, 5, 6]
        /// 
        /// -3 -> -2 -> 1 -> 2 -> 3 -> 4 -> 5 -> 6
        /// [0]->[1]->[2]->[5]->[4]->[3]->[6]->[7]
        /// </summary>
        [Test]
        public void MixedValuesWithValidDAndM()
        {
            int result = Program.FindLongestExplorationSequence(8, 3, 4, new int[] { -3, -2, 1, 4, 3, 2, 5, 6 });
            Assert.That(result, Is.EqualTo(8));
        }

        /// <summary>
        /// Finds the longest sequence of jumps where maxDistance and maxDifference are both 1.
        /// D = 1
        /// M = 1
        /// [1, 2, 3, 4, 5]
        /// 
        /// 1 -> 2 -> 3 -> 4 -> 5
        /// [0]->[1]->[2]->[3]->[4]
        /// </summary>
        [Test]
        public void SingleJumpLength()
        {
            int result = Program.FindLongestExplorationSequence(5, 1, 1, new int[] { 1, 2, 3, 4, 5 });
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests multiple jump lengths for a given sequence.
        /// D = 3
        /// M = 1
        /// [1, 3, 5, 2, 4]
        ///
        /// 1 -> 2 -> 3 -> 4 -> 5
        /// [0]->[3]->[1]->[4]->[2]
        [Test]
        public void MultipleJumpLengths()
        {
            int result = Program.FindLongestExplorationSequence(5, 3, 1, new int[] { 1, 3, 5, 2, 4 });
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests a sequence with multiple differences in value between elements.
        /// D = 1
        /// M = 3
        /// [1, 3, 2, 4, 5]
        ///
        /// 1 -> 2 -> 3 -> 4 -> 5
        /// [0]->[2]->[1]->[3]->[4]
        [Test]
        public void MultipleValueDifferences()
        {
            int result = Program.FindLongestExplorationSequence(5, 1, 3, new int[] { 1, 3, 2, 4, 5 });
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests a sequence with the smallest possible values for all parameters.
        /// D = 1
        /// M = 1
        /// [1]
        ///
        /// 1
        /// [0]
        /// </summary>
        [Test]
        public void SmallestPossibleValues()
        {
            int result = Program.FindLongestExplorationSequence(1, 1, 1, new int[] { 1 });
            Assert.That(result, Is.EqualTo(1));
        }

        /// <summary>
        /// Tests a scenario where only one element is reachable due to maxDifference.
        /// D = 10
        /// M = 1
        /// [1, 20, 30, 40]
        ///
        /// 1
        /// [0]
        /// </summary>
        [Test]
        public void NoValidJumpsDueToM()
        {
            int result = Program.FindLongestExplorationSequence(4, 10, 1, new int[] { 1, 20, 30, 40 });
            Assert.That(result, Is.EqualTo(1));
        }

        /// <summary>
        /// Tests a scenario where only one element is reachable due to maxDistance.
        /// D = 1
        /// M = 5
        /// [1, 5, 9, 13]
        ///
        /// 1
        /// [0]
        /// </summary>
        [Test]
        public void NoValidJumpsDueToD()
        {
            int result = Program.FindLongestExplorationSequence(4, 1, 5, new int[] { 1, 5, 9, 13 });
            Assert.That(result, Is.EqualTo(4));
        }

        /// <summary>
        /// Tests a scenario where only one element is reachable due to both maxDistance and maxDifference.
        /// D = 1
        /// M = 1
        /// [1, 5, 9, 13]
        ///
        /// 1
        /// [0]
        /// </summary>
        [Test]
        public void NoValidJumpsDueToMAndD()
        {
            int result = Program.FindLongestExplorationSequence(4, 1, 1, new int[] { 1, 5, 9, 13 });
            Assert.That(result, Is.EqualTo(1));
        }

        /// <summary>
        /// Tests a scenario where all elements are the same value.
        /// D = 0
        /// M = 3
        /// [1, 1, 1, 1]
        ///
        /// 1 -> 1 -> 1 -> 1
        /// [0]->[1]->[2]->[3]
        /// </summary>
        [Test]
        public void AllElementsAreTheSame()
        {
            int result = Program.FindLongestExplorationSequence(4, 3, 0, new int[] { 1, 1, 1, 1 });
            Assert.That(result, Is.EqualTo(4));
        }

        /// <summary>
        /// Tests the edge case of D = 7, M = 1
        /// D = 7
        /// M = 1
        /// [1, 8, 7, 6, 5, 4, 3, 2]
        ///
        /// 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8
        /// [0]->[7]->[6]->[5]->[4]->[3]->[2]->[1]
        /// </summary>
        [Test]
        public void TestMaxD()
        {
            int result = Program.FindLongestExplorationSequence(8, 7, 1, new int[] { 1, 8, 7, 6, 5, 4, 3, 2});
            Assert.That(result, Is.EqualTo(8));
        }

        /// <summary>
        /// Tests the edge case of D = 1, M = 10 000
        /// D = 1
        /// M = 10 000
        /// [-10000, 0, 10000]
        ///
        /// -10000 -> 0 -> 10000
        /// [0]->[1]->[2]
        /// </summary>
        [Test]
        public void TestMaxM()
        {
            int result = Program.FindLongestExplorationSequence(3, 1, 10000, new int[] { -10000, 0, 10000 });
            Assert.That(result, Is.EqualTo(3));
        }

        /// <summary>
        /// Tests the edge case of n = 1 000
        /// D = 1
        /// M = 1
        /// [0...1000]
        ///
        /// 0 -> ... -> 1000
        /// [0]-> ... ->[999]
        /// </summary>
        [Test]
        public void TestMaxArraySize()
        {
            int[] largeArray = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                largeArray[i] = i;
            }
            int result = Program.FindLongestExplorationSequence(1000, 1, 1, largeArray);
            Assert.That(result, Is.EqualTo(1000));
        }

        /// <summary>
        /// Tests the edge case where the integers in the array hit the low boundary
        /// D = 1
        /// M = 10000
        /// [-1000000, -990000, -980000]
        ///
        /// -1000000 -> -990000 -> -980000
        /// [0]->[1]->[2]
        /// </summary>
        [Test]
        public void TestLowIntegerBoundary()
        {
            int result = Program.FindLongestExplorationSequence(3, 1, 10000, new int[] { -1000000, -990000, -980000 });
            Assert.That(result, Is.EqualTo(3));
        }

        /// <summary>
        /// Tests the edge case where the integers in the array hit the high boundary
        /// D = 1
        /// M = 10000
        /// [980000, 990000, 1000000]
        ///
        /// 980000 -> 990000 -> 1000000
        /// [0]->[1]->[2]
        /// </summary>
        [Test]
        public void TestHighIntegerBoundary()
        {
            int result = Program.FindLongestExplorationSequence(3, 1, 10000, new int[] { 980000, 990000, 1000000 });
            Assert.That(result, Is.EqualTo(3));
        }

        /// <summary>
        /// Tests the case where the longest sequence does not start at either of the array ends
        /// D = 2
        /// M = 1
        /// [2, 3, 1, 2, 3]
        ///
        /// 1 -> 2 -> 3 -> 2 -> 3
        /// [2]->[0]->[1]->[3]->[4]
        /// </summary>
        [Test]
        public void SequenceNotStartingAtArrayEnds()
        {
            int result = Program.FindLongestExplorationSequence(5, 2, 1, new int[] { 2, 3, 1, 2, 3 });
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests an alternating sequence of integers
        /// D = 2
        /// M = 3
        /// [1, 4, 1, 4, 1]
        ///
        /// 1 -> 4 -> 1 -> 4 -> 1
        /// [0]->[1]->[2]->[3]->[4]
        /// </summary>
        [Test]
        public void AlternatingSequence()
        {
            int result = Program.FindLongestExplorationSequence(5, 2, 3, new int[] { 1, 4, 1, 4, 1 });
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests the edge case where both maxDistance and maxDifference are at their maximum value
        /// D = 7
        /// M = 10 000
        /// [1, 70001, 60001, 50001, 40001, 30001, 20001, 10001]
        ///
        /// 1 -> 10001 -> 20001 -> 30001 -> 40001 -> 50001 -> 60001 -> 70001
        /// [0]->[7]->[6]->[5]->[4]->[3]->[2]->[1]
        /// </summary>
        [Test]
        public void TestMaxDAndM()
        {
            int result = Program.FindLongestExplorationSequence(8, 7, 10000, new int[] { 1, 70001, 60001, 50001, 40001, 30001, 20001, 10001 });
            Assert.That(result, Is.EqualTo(8));
        }

        /// <summary>
        /// Tests the edge case where there are multiple islands of sequences
        /// D = 2
        /// M = 1
        /// [1, 2, 3, 10, 11, 12, 13, 20, 21, 22]
        ///
        /// 10 -> 11 -> 12 -> 13
        /// [3]->[4]->[5]->[6]
        /// </summary>
        [Test]
        public void MultipleIslands()
        {
            int result = Program.FindLongestExplorationSequence(9, 2, 1, new int[] { 1, 2, 3, 10, 11, 12, 13, 20, 21, 22 });
            Assert.That(result, Is.EqualTo(4));
        }

        /// <summary>
        /// Tests the case where the integers are non-monotonic with a large gap
        /// D = 1
        /// M = 1000
        /// [1, 2, 1000, 1001, 1002 ]
        ///
        /// 1 -> 2 -> 1000 -> 1001 -> 1002
        /// [0]->[1]->[2]->[3]->[4]
        /// </summary>
        [Test]
        public void NonMonotonicWithLargeGaps()
        {
            int result = Program.FindLongestExplorationSequence(5, 1, 1000, new int[] { 1, 2, 1000, 1001, 1002 });
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests the case with a reverse sequence
        /// D = 1
        /// M = 1
        /// [1, 2, 3, 4, 5 ]
        ///
        /// 5 -> 4 -> 3 -> 2 -> 1
        /// [0]->[1]->[2]->[3]->[4]
        /// </summary>
        [Test]
        public void ReverseSequences()
        {
            int result = Program.FindLongestExplorationSequence(5, 1, 1, new int[] { 5, 4, 3, 2, 1 });
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests the case where all the numbers are negative
        /// D = 2
        /// M = 1
        /// [-1, -2, -3, -4, -5 ]
        ///
        /// -1 -> -2 -> -3 -> -4 -> -5
        /// [0]->[1]->[2]->[3]->[4]
        /// </summary>
        [Test]
        public void NegativeNumbersOnly()
        {
            int result = Program.FindLongestExplorationSequence(5, 2, 1, new int[] { -1, -2, -3, -4, -5 });
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests the case where half the numbers are negative and the sequence "passes 0" on the numberline
        /// D = 1
        /// M = 1
        /// [-1, 1, -2, 2, -3, 3]
        ///
        /// -3 -> -2 -> -1 -> 1 -> 2 -> 3
        /// [4]->[2]->[0]->[1]->[3]->[5]
        /// </summary>
        [Test]
        public void MixedPositiveAndNegative()
        {
            int result = Program.FindLongestExplorationSequence(6, 2, 2, new int[] { -1, 1, -2, 2, -3, 3 });
            Assert.That(result, Is.EqualTo(6));
        }

        /// <summary>
        /// Tests an alternating negative and positive sequence
        /// D = 1
        /// M = 2
        /// [1, -1, 1, -1, 1, -1]
        ///
        /// 1 -> -1 -> 1 -> -1 -> 1 -> -1
        /// [0]->[1]->[2]->[3]->[4]->[5]
        /// </summary>
        [Test]
        public void AlternatingPositiveAndNegative()
        {
            int result = Program.FindLongestExplorationSequence(6, 1, 2, new int[] { 1, -1, 1, -1, 1, -1 });
            Assert.That(result, Is.EqualTo(6));
        }

        /// <summary>
        /// Tests an alternating sequence of negative, positive and zero
        /// D = 1
        /// M = 1
        /// [-1, 0, 1, 0 ]
        ///
        /// -1 -> 0 -> 1 -> 0
        /// [0]->[1]->[2]->[3]
        /// </summary>
        [Test]
        public void ValuesWithZero()
        {
            int result = Program.FindLongestExplorationSequence(4, 1, 1, new int[] { -1, 0, 1, 0 });
            Assert.That(result, Is.EqualTo(4));
        }
    }
}
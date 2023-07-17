
using System.Collections;
using NUnit.Framework;

namespace consolidation_csharp_lesson_13;

public class TestChallenges
{
    [Test]
    [TestCase(new int[] { 12 }, 12, 0)]
    [TestCase(new int[] { 1, 3, 6, 10, 15, 21, 28 }, 15, 4)]
    public void TestBinarySearchWithTargetPresent(int[] sortedNumbers, int target, int expectedIndex)
    {
        int index = Challenges.BinarySearch(new List<int>(sortedNumbers), target);
        Assert.AreEqual(expectedIndex, index, $"{target} should have been found at index {expectedIndex}");
    }

    [Test]
    [TestCase(new int[] { }, 12, "Target not found in list")]
    [TestCase(new int[] { 1, 3, 6, 10, 15, 21 }, 16, "Target not found in list")]
    public void TestBinarySearchWithTargetAbsent(int[] sortedNumbers, int target, string expectedErrorMessage)
    {
        Assert.Throws
        (
            Is.TypeOf<InvalidOperationException>()
                .And
                .Message
                .EqualTo(expectedErrorMessage), 
            () => Challenges.BinarySearch(new List<int>(sortedNumbers), target)
        );
    }

    [Test]
    [TestCase(new int[] { }, new int[] { })]
    [TestCase(new int[] { 3 }, new int[] { 3 })]
    [TestCase(new int[] { 2, 4, 6, 8 }, new int[] { 2, 4, 6, 8 })]
    [TestCase(new int[] { 5, 1, 9, 7 }, new int[] { 1, 5, 7, 9 })]
    public void TestSelectionSort(int[] numbers, int[] expectedSortedNumbers)
    {
        var numbersList = new List<int>(numbers);
        Challenges.SelectionSort(numbersList);
        Assert.AreEqual(expectedSortedNumbers, numbersList.ToArray());
    }

    [Test]
    [TestCase(new int[] { }, new int[] { })]
    [TestCase(new int[] { 3 }, new int[] { 3 })]
    [TestCase(new int[] { 2, 4, 6, 8 }, new int[] { 2, 4, 6, 8 })]
    [TestCase(new int[] { 5, 1, 9, 7 }, new int[] { 1, 5, 7, 9 })]
    public void TestInsertionSort(int[] numbers, int[] expectedSortedNumbers)
    {
        var numbersList = new List<int>(numbers);
        Challenges.InsertionSort(numbersList);
        Assert.AreEqual(expectedSortedNumbers, numbersList.ToArray());
    }

    private static IEnumerable TwoNumberSumTestCases
    {
        get
        {
            yield return new TestCaseData(new HashSet<int>(), 6, new HashSet<HashSet<int>> { new HashSet<int>() });
            yield return new TestCaseData(new HashSet<int> { 3 }, 6, new HashSet<HashSet<int>> { new HashSet<int>() });
            yield return new TestCaseData(new HashSet<int> { 1, 3, 7, 9 }, 6, new HashSet<HashSet<int>> { new HashSet<int>() });
            yield return new TestCaseData(new HashSet<int> { 4, 2, 7, 3, 8 }, 9, new HashSet<HashSet<int>> { new HashSet<int> { 2, 7 } });
            yield return new TestCaseData(new HashSet<int> { 2, -6, 16, 8 }, 10, new HashSet<HashSet<int>> { new HashSet<int> { 2, 8 }, new HashSet<int> { -6, 16 } });
        }
    }

    [TestCaseSource(nameof(TwoNumberSumTestCases))]
    public void TestTwoNumberSum(HashSet<int> numbers, int target, HashSet<HashSet<int>> expectedPairs)
    {
        var pairs = Challenges.TwoNumberSum(numbers, target);
        CollectionAssert.AreEquivalent(expectedPairs, pairs);
    }

    private static IEnumerable ThreeNumberSumTestCases
    {
        get
        {
            yield return new TestCaseData(new HashSet<int>(), 6, new HashSet<HashSet<int>> { new HashSet<int>() });
            yield return new TestCaseData(new HashSet<int> { 2 }, 6, new HashSet<HashSet<int>> { new HashSet<int>() });
            yield return new TestCaseData(new HashSet<int> { 1, 2, 4, 8 }, 6, new HashSet<HashSet<int>> { new HashSet<int>() });
            yield return new TestCaseData(new HashSet<int> { 4, 1, 7, 3, 8 }, 8, new HashSet<HashSet<int>> { new HashSet<int> { 1, 3, 4 } });
            yield return new TestCaseData(new HashSet<int> { -4, 1, 2, 3, 6, 12 }, 10, new HashSet<HashSet<int>> { new HashSet<int> { -4, 2, 12 }, new HashSet<int> { 1, 3, 6 } });
        }
    }

    [TestCaseSource(nameof(ThreeNumberSumTestCases))]
    public void TestThreeNumberSum(HashSet<int> numbers, int target, HashSet<HashSet<int>> expectedTriples)
    {
        var triples = Challenges.ThreeNumberSum(numbers, target);
        CollectionAssert.AreEquivalent(expectedTriples, triples);
    }

    private static IEnumerable ContainsTriplesTestCases
    {
        get
        {
            yield return new TestCaseData(new List<int>(),  false );
            yield return new TestCaseData(new List<int> { 2 },  false );
            yield return new TestCaseData(new List<int> { 2, 2 },  false );
            yield return new TestCaseData(new List<int> { 2, 2, 2 },  true );
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 4, 3, 2, 1 },  false );
            yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 4, 5, 4, 3, 2, 1 },  true );
        }
    }

    [TestCaseSource(nameof(ContainsTriplesTestCases))]
    public void TestContainsTriples(List<int> numbers, bool expectedResult)
    {
        var result = Challenges.ContainsTriples(numbers);
        Assert.AreEqual(expectedResult, result);
    }

    private static IEnumerable<TestCaseData> GroupAnagramsTestCases
    {
        get
        {
            yield return new TestCaseData(new List<string>(), new HashSet<HashSet<string>>());
            yield return new TestCaseData(new List<string> { "name" }, new HashSet<HashSet<string>> { new HashSet<string> { "name" } });
            yield return new TestCaseData(new List<string> { "name", "name" }, new HashSet<HashSet<string>> { new HashSet<string> { "name" } });
            yield return new TestCaseData(new List<string> { "name", "mane" }, new HashSet<HashSet<string>> { new HashSet<string> { "name", "mane" } });
            yield return new TestCaseData(new List<string> { "name", "gnome" }, new HashSet<HashSet<string>> { new HashSet<string> { "name" }, new HashSet<string> { "gnome" } });
            yield return new TestCaseData(new List<string> { "name", "age", "city" }, new HashSet<HashSet<string>> { new HashSet<string> { "name" }, new HashSet<string> { "age" }, new HashSet<string> { "city" } });
            yield return new TestCaseData(new List<string> { "name", "age", "city", "mean" }, new HashSet<HashSet<string>> { new HashSet<string> { "name", "mean" }, new HashSet<string> { "age" }, new HashSet<string> { "city" } });
            yield return new TestCaseData(new List<string> { "name", "ages", "mane", "city", "mean", "sage", "amen" }, new HashSet<HashSet<string>> { new HashSet<string> { "name", "mane", "mean", "amen" }, new HashSet<string> { "ages", "sage" }, new HashSet<string> { "city" } });
        }
    }

    [TestCaseSource(nameof(GroupAnagramsTestCases))]
    public void TestGroupAnagrams(List<string> words, HashSet<HashSet<string>> expectedGroups)
    {
        var groups = Challenges.GroupAnagrams(words);
        CollectionAssert.AreEquivalent(expectedGroups, groups);
    }
}

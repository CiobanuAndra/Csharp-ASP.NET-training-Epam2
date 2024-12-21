using NUnit.Framework;
using static PalindromeNumberFiltering.Selector;

namespace PalindromeNumberFiltering.Tests;

[TestFixture]
public class SelectorTests
{
    public static IEnumerable<TestCaseData> TestCasesForSuccessfulResult
    {
        get
        {
            yield return new TestCaseData(new[] { 2212332, 0, 1405644, 12345, 1, -1236674, 123321, 1111111 }, new[] { 0, 1, 123321, 1111111 });
            yield return new TestCaseData(new[] { 1111111112, 987654, -24, 1234654321, 32, 1005 }, Array.Empty<int>());
            yield return new TestCaseData(new[] { -27, 987656789, 7557, int.MaxValue, 7556, 7243, 7243427, int.MinValue }, new[] { 987656789, 7557, 7243427 });
            yield return new TestCaseData(new[] { 10101, 1001001, 100001, 1000001 }, new[] { 10101, 1001001, 100001, 1000001 });
            yield return new TestCaseData(new[] { -1, 0, 111, -11, -1 }, new[] { 0, 111 });
            yield return new TestCaseData(new[] { 0, 1, 2, 3, 4 }, new[] { 0, 1, 2, 3, 4 });
        }
    }

    [TestCaseSource(nameof(TestCasesForSuccessfulResult))]
    public void GetPalindromes_ReturnNewArray(IList<int> array, IList<int> expected)
    {
        var actual = GetPalindromes(array);
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void GetPalindromes_ArrayIsNull_ThrowArgumentNullException()
    {
        _ = Assert.Throws<ArgumentNullException>(() => GetPalindromes(null!), "Array can not be null.");
    }

    [Test]
    public void GetPalindromes_LargeArray()
    {
        int sourceLength = 10_000_000;
        int palindromic = 1234554321;
        List<int> source = Enumerable.Repeat(int.MaxValue, sourceLength).ToList();
        int count = 1_000_000, step = sourceLength / count;
        for (int i = 0; i < sourceLength; i += step)
        {
            source[i] = palindromic;
        }

        IList<int> expected = Enumerable.Repeat(palindromic, count).ToList();
        var actual = GetPalindromes(source);
        Assert.That(actual, Is.EquivalentTo(expected));
    }
}

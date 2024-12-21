using System.Diagnostics;
using NUnit.Framework;
using static NumberTheory.SieveOfEratosthenes;

namespace NumberTheory.Tests;

public class SieveOfEratosthenesTests
{
    private static readonly int[][] Primes =
    [
        [2, 3, 5, 7, 11], [2, 3, 5, 7, 11, 13, 17, 19, 23, 29],
        [
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101,
            103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199,
            211, 223, 227, 229
        ],
        [
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101,
            103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199,
            211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317,
            331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443,
            449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541
        ]
    ];

    private static IEnumerable<TestCaseData> TestCasesForSuccessfulResult
    {
        get
        {
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm),
                12,
                Primes[0]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                12,
                Primes[0]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                12,
                Primes[0]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                12,
                Primes[0]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                12,
                Primes[0]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm),
                30,
                Primes[1]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                30,
                Primes[1]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                30,
                Primes[1]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                30,
                Primes[1]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                30,
                Primes[1]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm),
                230,
                Primes[2]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                230,
                Primes[2]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                230,
                Primes[2]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                230,
                Primes[2]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                230,
                Primes[2]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm),
                542,
                Primes[3]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                542,
                Primes[3]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                542,
                Primes[3]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                542,
                Primes[3]);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                542,
                Primes[3]);
        }
    }

    private static IEnumerable<TestCaseData> TestCasesForCountPrimeNumbers
    {
        get
        {
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm),
                1_000,
                168);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                1_000,
                168);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                1_000,
                168);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                1_000,
                168);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                1_000,
                168);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm),
                4_000,
                550);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                4_000,
                550);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                4_000,
                550);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                4_000,
                550);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                4_000,
                550);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm),
                1_000_000,
                78498);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                1_000_000,
                78498);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                1_000_000,
                78498);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                1_000_000,
                78498);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                1_000_000,
                78498);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm),
                2_100_000,
                155805);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                2_100_000,
                155805);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                2_100_000,
                155805);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                2_100_000,
                155805);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                2_100_000,
                155805);
        }
    }

    private static IEnumerable<TestCaseData> TestCasesForExceptionCases
    {
        get
        {
            yield return new TestCaseData(new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm), 0);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                0);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                0);
            yield return new TestCaseData(new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool), 0);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                0);
            yield return new TestCaseData(new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm), -2);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                -2);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                -2);
            yield return new TestCaseData(new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool), -2);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                -2);
            yield return new TestCaseData(new Func<int, IEnumerable<int>>(GetPrimeNumbersSequentialAlgorithm), -90);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersModifiedSequentialAlgorithm),
                -90);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentDataDecomposition),
                -90);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentWithThreadPool),
                -90);
            yield return new TestCaseData(
                new Func<int, IEnumerable<int>>(GetPrimeNumbersConcurrentBasicPrimesDecomposition),
                -90);
        }
    }

    [TestCaseSource(nameof(TestCasesForSuccessfulResult))]
    public void GetPrimeNumbersTests(Func<int, IEnumerable<int>> func, int count, int[] expected)
    {
        var actual = func(count).ToArray();
        Assert.That(expected, Is.EqualTo(actual));
    }

    [TestCaseSource(nameof(TestCasesForCountPrimeNumbers))]
    public void GetPrimeNumbers_LongSequenceTests(Func<int, IEnumerable<int>> func, int count, int expected)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var sequence = func(count).ToArray();
        stopwatch.Stop();
        Console.WriteLine($"{func.Method.Name}({count}): {stopwatch.ElapsedTicks}");
        Assert.That(sequence.Length == expected);
    }

    [TestCaseSource(nameof(TestCasesForExceptionCases))]
    public void GetPrimeNumbers_LengthOfSequenceLessThanOne_ThrowArgumentException(
        Func<int, IEnumerable<int>> func,
        int count)
        => Assert.Throws<ArgumentOutOfRangeException>(
            () => func(count),
            message: "Method throws ArgumentOutOfRangeException in case length of the sequence is less than 1.");
}

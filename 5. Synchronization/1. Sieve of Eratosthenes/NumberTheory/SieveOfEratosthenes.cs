using System.Collections.Concurrent;
using System.Globalization;

namespace NumberTheory;

public static class SieveOfEratosthenes
{
    /// <summary>
    /// Generates a sequence of prime numbers up to the specified limit using a sequential approach.
    /// </summary>
    /// <param name="n">The upper limit for generating prime numbers.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing prime numbers up to the specified limit.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the input <paramref name="n"/> is less than or equal to 0.</exception>
    public static IEnumerable<int> GetPrimeNumbersSequentialAlgorithm(int n)
    {
        // 1.Input Validation
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "The input must be greater than 0.");
        }

        // 2.Create an Array to Track Primality
        // A bool[] array isPrime is initialized with n+1 elements (to include 0 through n).
        // All values are set to true initially, assuming every number is prime.
        // Mark 0 and 1 as false because they are not prime numbers.
        bool[] isPrime = new bool[n + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;

        // 3.Iterate Over Potential Prime Numbers
        // The outer loop starts with i=2 (the first prime number).
        // The loop condition i∗i≤n ensures we only check up to sqrt(n), as any composite number x will have at least one factor less than or equal to x.​
        // Inside the loop:
        // If isPrime[i] is true, i is confirmed to be a prime number.
        // The inner loop starts at j = i∗i.Why? Multiples smaller than i ^ 2(e.g., 2i, 3i,…) are already marked as not prime by smaller prime factors.
        // The inner loop increments j by i(i.e., marks multiples of i as false because they are composite).
        for (int i = 2; i * i <= n; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    isPrime[j] = false;

                    // Transforma elementele din array-ul nostru isPrime[] care au din default atribuita valoarea "true", in "false".
                    // Astfel mai eliminam din elementele pe care le-am considerat pe nedrept (din default) prime, reducand lista.
                }
            }
        }

        // 4.Extract Prime Numbers
        // Generate a sequence of integers from 2 to n using Enumerable.Range(2, n - 1).
        // Use.Where(i => isPrime[i]) to filter only the indices in isPrime that are still marked as true(i.e., the prime numbers).
        return Enumerable.Range(2, n - 1).Where(i => isPrime[i]);

        // For n=18 => returns: new List<int> { 2, 3, 5, 7, 11, 13, 17 }
    }

    /// <summary>
    /// Generates a sequence of prime numbers up to the specified limit using a modified sequential approach.
    /// </summary>
    /// <param name="n">The upper limit for generating prime numbers.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing prime numbers up to the specified limit.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the input <paramref name="n"/> is less than or equal to 0.</exception>
    public static IEnumerable<int> GetPrimeNumbersModifiedSequentialAlgorithm(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Input must be greater than 0.");
        }

        if (n < 2)
        {
            return Enumerable.Empty<int>();
        }

        // Stage 1: Find base primes up to sqrt(n)
        int limit = (int)Math.Sqrt(n);
        bool[] isCompositeStage1 = new bool[limit + 1];

        List<int> basePrimes = [];
        for (int i = 2; i <= limit; i++)
        {
            if (!isCompositeStage1[i])
            {
                basePrimes.Add(i);
                for (int j = i * i; j <= limit; j += i)
                {
                    isCompositeStage1[j] = true;
                }
            }
        }

        // Stage 2: Use base primes to check for primes in the range [sqrt(n) + 1, n]
        List<int> primes = [.. basePrimes]; // Include base primes in the result

        for (int i = limit + 1; i <= n; i++)
        {
            bool isPrime = true;
            foreach (int prime in basePrimes)
            {
                if (prime * prime > i)
                {
                    break;
                }

                if (i % prime == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        return primes;
    }

    /// <summary>
    /// Generates a sequence of prime numbers up to the specified limit using a concurrent approach by data decomposition.
    /// </summary>
    /// <param name="n">The upper limit for generating prime numbers.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing prime numbers up to the specified limit.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the input <paramref name="n"/> is less than or equal to 0.</exception>
    public static IEnumerable<int> GetPrimeNumbersConcurrentDataDecomposition(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(n.ToString(CultureInfo.InvariantCulture));
        }

        var primeDictionary = new Dictionary<int, bool>();
        var processedPrimes = new HashSet<int>();

        var maxN = (int)Math.Ceiling(Math.Sqrt(n));
        for (int i = 2; i < n; i++)
        {
            primeDictionary[i] = true;
        }

        int currentPrime = 2;
        while (true)
        {
            _ = processedPrimes.Add(currentPrime);
            for (int i = currentPrime + currentPrime; i < n; i += currentPrime)
            {
                primeDictionary[i] = i % currentPrime != 0 && primeDictionary[i];
            }

            currentPrime = primeDictionary
                .Where(d => d.Value && !processedPrimes.Contains(d.Key) && d.Key < maxN)
                .Select(d => d.Key)
                .FirstOrDefault();
            if (currentPrime == 0)
            {
                break;
            }
        }

        var threadCount = 10;
        var numbers = n - maxN;
        var numbersForLastThread = numbers % threadCount;
        var numbersPerThread = (numbers - numbersForLastThread) / threadCount;

        List<Thread> threads = [];

        for (int i = 0; i < threadCount - 1; i++)
        {
            var min = maxN + (i * numbersPerThread);
            var max = maxN + ((i + 1) * numbersPerThread);
            threads.Add(new Thread((para) =>
            {
                (int min, int max) = ((int Min, int Max))para!;
                for (int i = min; i < max; i++)
                {
                    foreach (var prime in processedPrimes)
                    {
                        primeDictionary[i] = i % prime != 0 && primeDictionary[i];
                    }
                }
            }));
            threads[i].Start((min, max));
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        var minLast = maxN + ((threadCount - 1) * numbersPerThread);
        var maxLast = n;
        threads.Add(new Thread((para) =>
        {
            (int min, int max) = ((int Min, int Max))para!;
            for (int i = min; i < max; i++)
            {
                foreach (var prime in processedPrimes)
                {
                    primeDictionary[i] = i % prime != 0 && primeDictionary[i];
                }
            }
        }));
        threads[threadCount - 1].Start((minLast, maxLast));

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return primeDictionary.Where(d => d.Value).Select(dd => dd.Key).ToList();
    }

    /// <summary>
    /// Generates a sequence of prime numbers up to the specified limit using a concurrent approach by "basic" primes decomposition.
    /// </summary>
    /// <param name="n">The upper limit for generating prime numbers.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing prime numbers up to the specified limit.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the input <paramref name="n"/> is less than or equal to 0.</exception>
    public static IEnumerable<int> GetPrimeNumbersConcurrentBasicPrimesDecomposition(int n)
    {
        if (n < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "The input must be greater than 1.");
        }

        int sqrtN = (int)Math.Sqrt(n);
        List<int> basePrimes = GetPrimeNumbersSequentialAlgorithm(sqrtN).ToList();
        int partitionSize = (n - sqrtN) / Environment.ProcessorCount;
#pragma warning disable IDE0028 // Simplify collection initialization
        ConcurrentBag<int> primes = new ConcurrentBag<int>();
#pragma warning restore IDE0028 // Simplify collection initialization
        _ = Parallel.For(0, Environment.ProcessorCount, i =>
        {
            int start = sqrtN + 1 + (i * partitionSize);
            int end = (i == Environment.ProcessorCount - 1) ? n : start + partitionSize - 1;
            for (int number = start; number <= end; number++)
            {
                bool isPrime = true;
                foreach (int prime in basePrimes)
                {
                    if (prime * prime > number)
                    {
                        break;
                    }

                    if (number % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                // If prime, add to the concurrent collection
                if (isPrime)
                {
                    primes.Add(number);
                }
            }
        });
        foreach (var basePrime in basePrimes)
        {
            primes.Add(basePrime);
        }

        return primes.OrderBy(p => p);
    }

    /// <summary>
    /// Generates a sequence of prime numbers up to the specified limit using thread pool and signaling construct.
    /// </summary>
    /// <param name="n">The upper limit for generating prime numbers.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing prime numbers up to the specified limit.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the input <paramref name="n"/> is less than or equal to 0.</exception>
    public static IEnumerable<int> GetPrimeNumbersConcurrentWithThreadPool(int n)
    {
        if (n < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "The input must be greater than 1.");
        }

        int sqrtN = (int)Math.Sqrt(n);
        List<int> basePrimes = GetPrimeNumbersSequentialAlgorithm(sqrtN).ToList();
#pragma warning disable IDE0028 // Simplify collection initialization
        ConcurrentBag<int> primes = new ConcurrentBag<int>();
#pragma warning restore IDE0028 // Simplify collection initialization
#pragma warning disable CA2000
        CountdownEvent countdown = new CountdownEvent(basePrimes.Count);
        foreach (var basePrime in basePrimes)
        {
            _ = ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    for (int num = sqrtN + 1; num <= n; num++)
                    {
                        if (num % basePrime == 0)
                        {
                            primes.Add(num);
                        }
                    }
                }
                finally
                {
#pragma warning disable IDE0058 // Expression value is never used
                    countdown.Signal();
#pragma warning restore IDE0058 // Expression value is never used
                }
            });
        }

        countdown.Wait();
        HashSet<int> resultPrimes = new HashSet<int>(Enumerable.Range(sqrtN + 1, n - sqrtN)
                                        .Except(primes));
        resultPrimes.UnionWith(basePrimes);
        return resultPrimes.OrderBy(p => p);
    }
}

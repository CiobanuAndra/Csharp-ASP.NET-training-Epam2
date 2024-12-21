# Sieve of Eratosthenes

Advanced level task for practicing concurrent programming and synchronization.

Estimated time to complete the task - 4h.

The task requires .NET 8 SDK installed.

## Task description

Develop a parallel algorithm to implement the [Sieve of Eratosthenes](https://www.wikiwand.com/en/Sieve_of_Eratosthenes) for finding prime numbers. The algorithm should efficiently distribute the workload among multiple threads to leverage parallel processing capabilities. The goal is to enhance the performance of prime number identification by leveraging parallelism while ensuring proper synchronization and handling potential race conditions.

## Task details

To complete this task implement the following algorithms.

<details><summary>

 **Sequential Prime Number Search Algorithm**

</summary>

The algorithm involves sequentially iterating over the already known prime numbers, starting from $`2`$, and checking the divisibility of all numbers in the range $`(m, n]`$ by the found prime number $`m`$. At the first step, the number $`m = 2`$ is chosen, and divisibility of numbers in the range $`(2, n]`$ by $`2`$ is checked. Numbers divisible by $`2`$ are marked as composite and are not considered in further analysis. The next unmarked (prime) number will be $`m = 3`$, and so on.

<img src="/images/Synchronization.1.png" alt="drawing" width="900" height="170"/>

It is sufficient to check the divisibility of numbers by prime numbers in the interval $`(2,\sqrt{n}]`$. For example, in the range from $`2`$ to $`20`$, we check all numbers for divisibility by $`2`$ and $`3`$. There are no composite numbers divisible only by $`5`$ in this range.
</details>

<details><summary>

 **Modified Sequential Prime Number Search Algorithm**

</summary>

In the sequential algorithm, "base" prime numbers are determined one by one. After three, there comes five, as four is excluded when processing two. The sequence of finding prime numbers complicates the parallelization of the algorithm. In the modified algorithm, two stages are distinguished:
- 1st stage: Search for prime numbers in the range from $`2`$ to $`\sqrt{n}`$ using the classical Sieve of Eratosthenes method (base prime numbers).
- 2nd stage: Search for prime numbers in the range from $`\sqrt{n}`$ to $`n`$, involving the base prime numbers identified in the first stage.

<img src="/images/Synchronization.2.png" alt="drawing" width="500" height="150"/>

During the first stage of the algorithm, a relatively small amount of work is performed, so it is not advisable to parallelize this stage. In the second stage, the already identified base prime numbers are checked. Parallel algorithms are developed for the second stage.
</details>

<details><summary>

 **Concurrent Algorithm Using Data Decomposition**

</summary>

This algorithm is to partition the range $`\sqrt{n}`$ to $`n`$ into equal parts. Each thread processes its part of the numbers, checking for decomposability for each "basic" prime number.

<img src="/images/Synchronization.3.png" alt="drawing" width="500" height="150"/>
</details>

<details><summary>

 **Concurrent Algorithm Using Decomposition Of The "Basic" Prime Numbers**

</summary>

This algorithm separates the "basic" prime numbers. Each thread works with a limited set of primes and tests the entire range $`\sqrt{n}`$ to $`n`$.

<img src="/images/Synchronization.4.png" alt="drawing" width="500" height="160"/>
</details>

<details><summary>

 **Concurrent Algorithm Using Thread Pool**

</summary>

This implementation uses a thread pool that allows you to automate the processing of independent work items. It is proposed to use as working items the verification of all numbers in the range $`\sqrt{n}`$ to $`n`$ for decomposability with respect to one "basic" prime number.

<img src="/images/Synchronization.5.png" alt="drawing" width="500" height="170"/>

Work items are executed automatically once they are added to the thread pool.There is no built-in mechanism to wait for work items added to the thread pool to complete.Therefore, it is necessary to control completion either through synchronization means (such as signaling messages) or through shared variables and a wait loop.
</details>

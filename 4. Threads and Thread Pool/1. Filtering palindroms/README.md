# Filtering Palindromes Numbers (ThreadPool)

Intermediate level task for practicing the capabilities of the `ThreadPool` class for CPU-bound operations.

Estimated time to complete the task - 2h.

The task requires .NET 8 SDK installed.

## Task Description

Implement a `Selector` static class that contains methods for filtering palindrome numbers from a collection of integers.

Implement the following method in the `Selector` class:

- `GetPalindromes`: This method retrieves a collection of palindrome numbers from the given list of integers using concurrent filtering. The method utilizes concurrent processing with [ThreadPool](https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadpool) to filter palindrome numbers concurrently and [ConcurrentBag](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1?view=net-7.0) to store the result. It also uses the private `IsPalindrome` method to check whether a number is a palindrome.

The `Selector` class contains several private helper methods:
- `IsPalindrome`: This private method checks whether the given integer is a palindrome number. It first verifies that the number is non-negative and then uses the `IsPositiveNumberPalindrome` method to perform a recursive check on positive numbers.
- `IsPositiveNumberPalindrome`: This private method recursively checks whether a positive number is a palindrome. It compares the first digit with the last digit and proceeds with the check by removing these digits from the number until the number becomes less than 10.
- `GetDigitInDecimalPlace`: This private method extracts the digit on a specific decimal place within a given number. 
- `GetLength`: This private method calculates the number of digits in the given integer. It uses a switch statement to handle different ranges of numbers efficiently.

_Note_: To determine if a number is a palindrome, you must implement the solution without using arrays, collections, or the string class: use only basic numerical operations and logical comparisons.

### See also

- [ThreadPool Class](https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadpool)
- [ConcurrentBag<T> Class](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1?view=net-7.0)

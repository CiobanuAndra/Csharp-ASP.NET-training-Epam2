# Create table of records type of T

Beginner level tasks for practicing reflection.

Estimated time to complete the task - 3h.

The task requires .NET 8 SDK installed.

## Task Description

Implement generic `WriteTable` method to write "in table form" to the text stream a collection of elements of type `T` (`ICollection<T>`). 
- The state of each object of type `T` is described by public properties that have build-in type only (`int`, `char`, `string` etc.).
- The number of columns in the table is determined by the number of public properties of each entry. 
- The width of each column is determined by the maximum number of characters required to write an individual property to the stream. In this case, numbers and dates should be right-aligned, strings and symbols - left-aligned.

    ![](/TableRecords.png)

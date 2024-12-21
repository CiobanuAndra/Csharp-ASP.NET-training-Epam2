# Task Parallel Library

Intermediate level task for practicing Task Parallel Library.

Estimated time to complete the task - 1.0h.

The task requires .NET 8 SDK installed.


## Task Description

This task helps in better understanding of Task Parallel Library.


### 1. Check whether the status of the task is 'TaskCreated'.
Implement [TaskCreated](Tpl/StudentLogic.cs#L5) method of the *StudentLogic* class:
* Create a new task and return it.
* Return type of the method is 'task'.

### 2. Check whether the status of the task is 'WaitingForActivation'.
Implement [WaitingForActivation](Tpl/StudentLogic.cs#L11) method of the *StudentLogic* class:
* Write a code with the help of the below method in such a way that the status of the task is 'WaitingForActivation'. 

```cs
private static async Task<string> Foo(int seconds)
        {
            return await Task.Run(() =>
            {
                for (int i = 0; i < seconds; i++)
                {
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                }

                return "Foo Completed";
            });
        }
```
Paste the above code in [StudentLogic.cs](Tpl/StudentLogic.cs) file.

* Return type of the method is 'task'.

### 3. Check whether the status of the task is 'WaitingToRun'.
Implement [WaitingToRun](Tpl/StudentLogic.cs#L17) method of the *StudentLogic* class:
* Write a code in such a way that the status of the task is 'WaitingToRun'.
* Return type of the method is 'task'.

### 4. Check whether the status of the task is 'Running'.
Implement [Running](Tpl//StudentLogic.cs#L23) method of the *StudentLogic* class:
* Write a code in such a way that the status of the task is 'Running'.
* Return type of the method is 'task'.

### 5. Check whether the status of the task is 'RanToCompletion'.
Implement [RanToCompletion](Tpl//StudentLogic.cs#L29) method of the *StudentLogic* class:
* Write a code in such a way that the status of the task is 'RanToCompletion'.
* Return type of the method is 'task'.

### 6. Check whether the status of the task is 'WaitingForChildrenToComplete'.
Implement [WaitingForChildrenToComplete](Tpl//StudentLogic.cs#L35) method of the *StudentLogic* class:
* Write a code in such a way that the status of the task is 'WaitingForChildrenToComplete'.
* Return type of the method is 'task'.

### 7. Check whether the status of the task 'IsCompleted'.
Implement [IsCompleted](Tpl//StudentLogic.cs#L41) method of the *StudentLogic* class:
* Write a code in such a way that the status of the task is 'IsCompleted'.
* Return type of the method is 'task'.

### 8. Check whether the status of the task 'IsCancelled'.
Implement [IsCancelled](Tpl//StudentLogic.cs#L47) method of the *StudentLogic* class:
* Write a code in such a way that the status of the task is 'IsCancelled'.
* Return type of the method is 'task'.

### 9. Check whether the status of the task 'IsFaulted'.
Implement [IsFaulted](Tpl//StudentLogic.cs#L53) method of the *StudentLogic* class:
* Write a code in such a way that the status of the task is 'IsFaulted'.
* Return type of the method is 'task'.

### 10. Demonstrate 'ForceParallelismPlinq' execution.
Implement [ForceParallelismPlinq](Tpl//StudentLogic.cs#L59) method of the *StudentLogic* class:
* Write a code with the help of the list provided in the below code snippet, iterate parallely over 'testList' using PLINQ, store the result in a new list of type 'int' and return it.

```cs
 var testList = Enumerable.Range(1, 300).ToList();
```
* Return type of the method is list of type 'int'.
























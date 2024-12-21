namespace Tpl;

public static class StudentLogic
{
    // 1. Create a new task and return it.
    public static Task TaskCreated()
    {
        // Create and return a completed task.
        var task = new Task(() =>
        {
            Console.WriteLine("Task Created and Running...");
        });
        return task;
    }

    // 2. Implement a method to return a task with the status 'WaitingForActivation'.
    //public static Task WaitingForActivation()
    //{
    //    // Create a task but delay its execution so it remains in 'WaitingForActivation' state.
    //    var task = new Task(async () =>
    //    {
    //        string result = await Foo(6);
    //        System.Diagnostics.Debug.WriteLine(result);
    //    });

    //    // Return the task before starting it to ensure the state is 'WaitingForActivation'.
    //    return task;
    //}

    public static Task WaitingForActivation()
    {
        var task = new Task(() =>
        {
            _ = Task.Delay(1000);
        });
        task.Start();
        var task2 = task.ContinueWith(t => { }, TaskScheduler.Default);
        return task2;
    }


    // Provided Foo method.
    private static async Task<string> Foo(int seconds)
    {
        return await Task.Run(() =>
        {
            for (int i = 0; i < seconds; i++)
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            }

            System.Diagnostics.Debug.WriteLine("Foo Completed");
            return "Foo Completed";
        });
    }

    // 3. Return a task with the status 'WaitingToRun'.
    //public static Task WaitingToRun()
    //{
    //    // Create the task and defer its start
    //    var task = new Task(() =>
    //    {
    //        Console.WriteLine("Task is about to run...");
    //    });

    //    // Schedule a delayed action to start the task
    //    var delayTask = Task.Delay(500).ContinueWith(
    //        _ =>
    //    {
    //        task.Start(TaskScheduler.Default); // Explicitly use TaskScheduler.Default
    //    }, TaskScheduler.Default);

    //    return task;
    //}

    public static Task WaitingToRun()
    {
        var task = Task.Run(() => { _ = Task.Delay(1000); });
        return task;
    }

    // 4. Return a task with the status 'Running'.
    //public static Task Running()
    //{
    //    var task = Task.Run(async () =>
    //    {
    //        Console.WriteLine("Task is now running...");
    //        await Task.Delay(3000); // Simulate running state
    //    });

    //    return task;
    //}

    public static Task Running()
    {
#pragma warning disable CA2008 // Do not create tasks without passing a TaskScheduler
        Task parent = Task.Factory.StartNew(
        () =>
        {
            Thread.Sleep(200);
        });
#pragma warning restore CA2008 // Do not create tasks without passing a TaskScheduler
        Thread.Sleep(100);
        return parent;
    }

    // 5. Return a task with the status 'RanToCompletion'.
    public static Task RanToCompletion()
    {
        Task taskA = Task.Run(() => Thread.Sleep(2000));
        taskA.Wait();
        return taskA;
    }

    // 6. WaitingForChildrenToComplete: Demonstrate a parent task waiting for child tasks.
    public static Task WaitingForChildrenToComplete()
    {
        return Task.Run(() =>
        {
            var childTasks = new List<Task>
                {
                    Task.Run(() => Console.WriteLine("Child Task 1 completed")),
                    Task.Run(() => Console.WriteLine("Child Task 2 completed")),
                };

            Task.WaitAll(childTasks.ToArray()); // Parent task waits for all child tasks.
            Console.WriteLine("All child tasks completed.");
        });
    }

    // 7. IsCompleted: Return a completed task.
    public static Task IsCompleted()
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine("Task is completing...");
        });

        task.Wait(); // Wait ensures the task is marked as completed.
        return task;
    }

    // 8. IsCancelled: Demonstrate a cancelled task.
    public static Task IsCancelled()
    {
        var cts = new System.Threading.CancellationTokenSource();
        var task = Task.Run(() =>
        {
            Console.WriteLine("Task is starting...");
            cts.Token.ThrowIfCancellationRequested();
        }, cts.Token);

        cts.Cancel(); // Cancel the task.

        return task.ContinueWith(t =>
        {
            if (t.IsCanceled)
            {
                Console.WriteLine("Task was cancelled.");
            }
        });
    }

    // 9. IsFaulted: Demonstrate a faulted task.
    public static Task IsFaulted()
    {
        return Task.Run(() =>
        {
            throw new InvalidOperationException("Task encountered an error.");
        }).ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                Console.WriteLine("Task is faulted.");
            }
        });
    }

    // 10. ForceParallelismPlinq: Use PLINQ to process a list in parallel.
    public static List<int> ForceParallelismPlinq()
    {
        var testList = Enumerable.Range(1, 300).ToList();

        // Use PLINQ to process in parallel.
        var result = testList.AsParallel()
                             .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                             .Select(x => x * 2)
                             .ToList();

        return result;
    }
}

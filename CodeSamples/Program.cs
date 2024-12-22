using System.Collections.Generic;
using System.Diagnostics;

#if WINDOWS
using System.Windows.Forms;
#endif

SynchronizationContext? winFormsSyncContext = null;

var demos = new List<(string name,List<(string name, Action demo)> demos, string? comment)>
{
    ("Chapter 1", new(), "chapter does not contain code"),
    ("Chapter 2", new(){
        ("Listing 2.1 Using Lambda functions", ForeverDemo(()=>new Chapter02.LambdaDemo1().InitTimer())),
        ("Compiler transformation of listing 2.1", ForeverDemo(()=>new Chapter02.LambdaDemo2().InitTimer())),
        ("Listing 2.2 Lambda function that uses local variables", ForeverDemo(()=>new Chapter02.LambdaDemo3().InitTimer())),
        ("Compiler transformation of listing 2.2", ForeverDemo(()=>new Chapter02.LambdaDemo4().InitTimer())),
        ("Listing 2.3 Using a list", ()=>new Chapter02.YieldDemo1().UseNoYieldDemo()),
        ("Listing 2.4 Using a list", ()=>new Chapter02.YieldDemo2().UseYieldDemo()),
        ("Compiler transformation of listing 2.4", ()=>new Chapter02.YieldDemo3().UseYieldDemo()),
    }, null),
    ("Chapter 3", new(){
        ("Listing 3.1 reading BMP width, non-async version", ShowResult(()=>new Chapter03.AsyncDemo1().GetBitmapWidth("sample.bmp"))),
        ("Listing 3.2 reading BMP width, async version", ShowResult(()=>new Chapter03.AsyncDemo2().GetBitmapWidth("sample.bmp").Result)),
        ("Compiler transformation of listing 3.2", ()=>new Chapter03.AsyncDemo3().GetBitmapWidth("sample.bmp",i=>Console.WriteLine(i),ex=>Console.WriteLine(ex.ToString()))),
    }, null),
    ("Chapter 4", new(){
        ("Listing 4.1 Creating a thread", Delay(()=>new Chapter04.Listing1().RunInBackground())),
        ("Listing 4.2 Creating a thread with a parameter", Delay(()=>new Chapter04.Listing2().RunLotsOfThreads())),
        ("Listing 4.3 Wait for threads to finish", ()=>new Chapter04.Listing3().RunAndWait()),
        ("Listing 4.4 Running in the thread pool", Delay(()=>new Chapter04.Listing4().RunInBackground())),
        ("Listing 4.5 Running in the thread pool with a parameter", Delay(()=>new Chapter04.Listing5().RunInBackground())),
        ("Listing 4.6 Running in the thread pool with Task.Run", Delay(()=>new Chapter04.Listing6().RunInBackground())),
        ("Listing 4.7 Running async code with Task.Run", Delay(()=>new Chapter04.Listing7().RunInBackground())),
        ("Listing 4.8 Waiting for tasks to finish with Task.Run", ()=>new Chapter04.Listing8().RunInBackground().Wait()),
        ("Listing 4.9 Use lambdas to create a parametrized Task.Run", Delay(()=>new Chapter04.Listing9().RunInBackground())),
        ("Listing 4.10 Incorrect value when accessing shared data without locking", ()=>new Chapter04.Listing10().GetIncorrectValue()),
        ("Listing 4.11 Adding locks to avoid simultaneous access problems", ()=>new Chapter04.Listing11().GetCorrectValue()),
    }, null),
    ("Chapter 5", new(){
        ("Listing 5.1 Read 10 files", ()=>new Chapter05.Listing1().Read10Files()),
        ("Listing 5.2 Calculate 10 values", ()=>new Chapter05.Listing2().Compute10Values()),
        ("Listing 5.2 Read 10 files using multithreading", ()=>new Chapter05.Listing3().Read10Files()),
        ("Listing 5.4 Read 10 files and do something with the data", ()=>new Chapter05.Listing4().Process10Files()),
        ("Listing 5.5 Read 10 files asynchronously and do something with the data", ()=>new Chapter05.Listing5().Process10Files()),
		("Listing 5.6 Make the caller async too", ()=>new Chapter05.Listing6().Process10Files().Wait()),
		("Listing 5.7 Getting a value from a server with caching, not thread-safe", ()=>new Chapter05.Listing7().GetResult("abc").Wait()),
		("Listing 5.8 Calling GetResult from a thread created by the Thread class", ()=>new Chapter05.Listing8().Method()),
		("Listing 5.10 Releasing the lock while awaiting", ()=>new Chapter05.Listing10().GetResult("abc").Wait()),
#if WINDOWS
        ("Listing 5.11 Long calculation that freezes the UI", WinForms( new Chapter05.Listing11())),
		("Listing 5.12 The calculation doesn’t freeze the UI but throws an exception", WinForms( new Chapter05.Listing12())),
		("Listing 5.13 Running in the background from the UI code correctly", WinForms( new Chapter05.Listing13())),
#endif
    }, null),
	("Chapter 6", new(), "load-testing client and server are in other projects"),
	("Chapter 7", new(), "this code is timing sensetive and cannot be run here"),
	("Chapter 8", new(){
		("Listing 8.1 World’s simplest mail merge", ()=>new Chapter08.Listing1().MailMerge("me@example.com","Cool message","message text for {name}",new (string email, string name)[]{ ("a@example.com","Person A"), ("b@example.com", "Person B") })),
		("Listing 8.2 Mail merge with a thread per message", ()=>new Chapter08.Listing2().MailMerge("me@example.com","Cool message","message text for {name}",new (string email, string name)[]{ ("a@example.com","Person A"), ("b@example.com", "Person B") })),
		("Listing 8.3 Thread-per-message performance banchmark", ()=>new Chapter08.Listing3().Method()),
		("Listing 8.4 Mail merge with each message processed in the thread pool", ()=>new Chapter08.Listing4().MailMerge("me@example.com","Cool message","message text for {name}",new (string email, string name)[]{ ("a@example.com","Person A"), ("b@example.com", "Person B") })),
		("Listing 8.5 Thread pool performance benchmark", ()=>new Chapter08.Listing5().Method()),
		("Listing 8.6 Asynchronous mail merge using Task.Run", ()=>new Chapter08.Listing6().MailMerge("me@example.com","Cool message","message text for {name}",new (string email, string name)[]{ ("a@example.com","Person A"), ("b@example.com", "Person B") })),
		("Listing 8.7 Asynchronous performance banchmark", ()=>new Chapter08.Listing7().Method()),
		("Listing 8.8 Mail merge with the Parallel class", ()=>new Chapter08.Listing8().MailMerge("me@example.com","Cool message","message text for {name}",new (string email, string name)[]{ ("a@example.com","Person A"), ("b@example.com", "Person B") })),
		("Listing 8.9 Parallel.ForEach performance banchmark", ()=>new Chapter08.Listing9().Method()),
		("Listing 8.10 Asyncronous mail merge with the Parallel class", ()=>new Chapter08.Listing10().MailMerge("me@example.com","Cool message","message text for {name}",new (string email, string name)[]{ ("a@example.com","Person A"), ("b@example.com", "Person B") })),
		("Listing 8.11 Move the entire loop to a background thread", Delay(()=>new Chapter08.Listing11().MailMerge("me@example.com","Cool message","message text for {name}",new (string email, string name)[]{ ("a@example.com","Person A"), ("b@example.com", "Person B") }))),
		("Listing 8.12 Work queue with BlockingCollection", Delay(()=>
            {
                var merger = new Chapter08.MailMerger();
                merger.Start();
                merger.MailMerge("me@example.com","Cool message","message text for {name}",new (string email, string name)[]{ ("a@example.com","Person A"), ("b@example.com", "Person B") });
                merger.Stop();
            })),
	}, null),
	("Chapter 9", new(){
		("Listing 9.1 Run background thread forever", ForeverDemo(()=>new Chapter09.Listing1().Method())),
		("Listing 9.2 Use a flag to cancel background thread", ()=>new Chapter09.Listing2().Method()),
		("Listing 9.3 Use locks to protect the cancellation flag", ()=>new Chapter09.Listing3().Method()),
		("Listing 9.4 Wrap the cancel flag in a class", ()=>new Chapter09.Listing4().Method()),
		("Listing 9.6 Using CancellationToken", ()=>new Chapter09.Listing6().Method()),
		("Listing 9.7 Delayed cancellation with a long operation", ()=>new Chapter09.Listing7().Method()),
		("Listing 9.8 Using CancellationToken with a long operation", ()=>new Chapter09.Listing8().Method()),
		("Listing 9.9  HTTP call that can be canceled by the user", ()=>new Chapter09.Listing9().Method()),
		("Listing 9.10 HTTP call that can be canceled by the user or a timeout", ()=>new Chapter09.Listing10().Method()),
	}, null),
	("Chapter 10", new(){
		("Listing 10.2 TaskCompletionSource.TrySetResult demo", ()=>new Chapter10.Listing2().RunDemo().Wait()),
		("Listing 10.3 TaskCompletionSource.TrySetException demo", ()=>new Chapter10.Listing3().RunDemo().Wait()),
		("Listing 10.4 TaskCompletionSource.TrySetCanceled demo", ()=>new Chapter10.Listing4().RunDemo().Wait()),
		("Listing 10.5 Class with background initialization", ()=>new Chapter10.RequiresInit().Add1().Wait()),
	}, null),
	("Chapter 11", new(){
#if WINDOWS
        ("Listing 11.1 await in a UI event handler", WinForms( new Chapter11.Listing1())),
		("Listing 11.2 UI access failure with ContinueWith", WinForms( new Chapter11.Listing2())),
		("Listing 11.3 UI access with ContinueWith", WinForms( new Chapter11.Listing3())),
#endif
		("Listing 11.4 async operation is a thread created by the Thread class", ()=>new Chapter11.Listing4().Method()),
		("Listing 11.5 async operation without terminating the thread", ForeverDemo(()=>new Chapter11.Listing5().Method())),
		("Listing 11.7 Simple async operation without SingleThreadSyncContext", ()=>new Chapter11.Listing7().Method().Wait()),
		("Listing 11.8 Simple async operation with SingleThreadSyncContext", ()=>new Chapter11.Listing8().Method()),
		("Listing 11.9 Console app without ConfigureAwait(false)", ()=>new Chapter11.Listing9().Method().Wait()),
		("Listing 11.10 ConfigureAwait(false) and completed tasks", ()=>new Chapter11.Listing10().Method().Wait()),
#if WINDOWS
        ("Listing 11.11 WinForms event handler with ConfigureAwait", WinForms( new Chapter11.Listing11())),
		("Listing 11.12 async/await deadlock", WinForms( new Chapter11.Listing12())),
		("Listing 11.13 Deadlock prevented by using ConfigureAwait(false)", WinForms( new Chapter11.Listing13())),
		("Listing 11.14 Deadlock prevented by using await", WinForms( new Chapter11.Listing14())),
		("Listing 11.15 WinForms code with ConfigureAwait(false) everywhere", WinForms( new Chapter11.Listing15())),
		("Listing 11.16 WinForms code that works with ConfigureAwait(false) everywhere", WinForms( new Chapter11.Listing16())),
		("Listing 11.17 WinForms code with ConfigureAwait(false) only in non-UI methods ", WinForms( new Chapter11.Listing17())),
		("Listing 11.18 Prevent the deadlock with DoEvents", WinForms( new Chapter11.Listing18())),
		("Listing 11.19 Trying to count forever and freezing the app", WinForms( new Chapter11.Listing19())),
		("Listing 11.20 Counting forever without freezing the app", WinForms( new Chapter11.Listing20())),
		("Listing 11.21 Counting forever without freezing the app using await", WinForms( new Chapter11.Listing21())),
#endif
	}, null),
	("Chapter 12", new(), "chapter does not contain code listings"),
	("Chapter 13", new(){
		("Listing 13.1 Simple, non-thread-safe cache", ()=>new Chapter13.Listing1().Method(1)),
		("Listing 13.2 Thread-safe cache with a single lock", ()=>new Chapter13.Listing2().Method(2)),
		("Listing 13.3 Non-thread-safe cache with lock released during initialization", ()=>new Chapter13.Listing3().Method(3)),
		("Listing 13.4 Thread-safe cache with operator []", ()=>new Chapter13.Listing4().Method(4)),
		("Listing 13.5 Thread-safe cache with lock released during initialization", ()=>new Chapter13.Listing5().Method(5)),
		("Listing 13.7 Thread-safe cache with ConcurrentDictionary.TryAdd", ()=>new Chapter13.Listing7().Method(7)),
		("Listing 13.8 Thread-safe cache with ConcurrentDictioanry.GetOrAdd", ()=>new Chapter13.Listing8().Method(8)),
		("Listing 13.9 Non-thread-safe increment", ()=>new Chapter13.Listing9().Increment("9")),
		("Listing 13.10 Thread-safe increment with ConcurrentDictioanry.TryUpdate", ()=>new Chapter13.Listing10().Increment("10")),
		("Listing 13.11 BlockingCollection with 10 processing threads", ()=>new Chapter13.Listing11().Method()),
		("Listing 13.12 Async background processing with Channel<T>", ()=>new Chapter13.Listing12().Method().Wait()),
		("Listing 13.14 Test code for simple stack", ()=>new Chapter13.Listing14().Method()),
		("Listing 13.16 Test code for immutable stack", ()=>new Chapter13.Listing16().Method()),
		("Listing 13.17 Non-thread-safe stack management with ImmutableDictioanry", ()=>new Chapter13.Listing17().TryToBuyBook("C# COncurrency")),
		("Listing 13.18 Thread-safe stock management with ImmutableInterlocked", ()=>new Chapter13.Listing18().TryToBuyBook("C# COncurrency")),
		("Listing 13.19 Initilizing a FrozenSet", ()=>new Chapter13.Listing19().Method()),
		("Listing 13.20 Initilizing a FrozenDictionary from a Dictionary", ()=>new Chapter13.Listing20().Method()),
		("Listing 13.21 Initilizing a FrozenDictionary from a List", ()=>new Chapter13.Listing21().Method()),
	}, null),
	("Chapter 14", new(){
		("Listing 14.2 Async yield return example", ()=>new Chapter14.Listing2().UseAsyncYieldDemo().Wait()),
		("Listing 14.3 Code generated by the compiler from listing 14.2", ()=>new Chapter14.Listing3().UseAsyncYieldDemo().Wait()),
		("Listing 14.5 Listing 14.5 Async yield return example with cancellation", ()=>new Chapter14.Listing5().UseAsyncYieldDemo().Wait()),
		("Listing 14.6 Cancelling the iteration before the loop starts", ()=>new Chapter14.Listing6().UseYieldDemo().Wait()),
		("Listing 14.7 Reading a stream of numbers non-asynchronously", ()=>new Chapter14.Listing7().ProcessStream(File.Open("Numbers.bin", FileMode.Open))),
		("Listing 10.8 Reading a stream of numbers asynchronously", ()=>new Chapter14.Listing8().ProcessStream(File.Open("Numbers.bin", FileMode.Open)).Wait()),
		("Listing 10.10 Async work queue with 10 threads", ()=>new Chapter14.Listing10().Method().Wait()),
	}, null),
};

winFormsSyncContext = SynchronizationContext.Current;
SynchronizationContext.SetSynchronizationContext(null);

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Please type chapter number and press enter");
    Console.WriteLine("Type X and press enter to exit");
    for(int i=0;i<demos.Count;++i)
    {
        if (demos[i].demos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{i + 1} {demos[i].name} ({demos[i].comment})");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine($"{i + 1} {demos[i].name}");
        }
    }
    var line = Console.ReadLine()?.Trim();
    if (line == "X" || line == "x") return;
    if (line == null) continue;
    if (int.TryParse(line, out var number) && number > 0 && number <= demos.Count)
    {
        ShowMenuFor(demos[number-1].demos);
        Console.WriteLine();
		Console.WriteLine();
		continue;
    }

    Console.WriteLine();
    Console.WriteLine("Invalid selection, please select again");
    Console.WriteLine();


}

Action ForeverDemo(Action action)
{
    return () =>
    {
        action();
        Console.WriteLine("This code will run forever, press X to stop");
        if(Console.ReadKey().Key == ConsoleKey.X) Environment.Exit(0);
    };
}

Action Delay(Action action)
{
    return () =>
    {
        action();
        System.Threading.Thread.Sleep(1000);
    };
}


Action ShowResult<T>(Func<T> action)
{
    return () =>
    {
        Console.WriteLine(action()?.ToString());
    };

}

#if WINDOWS
Action WinForms(Form form)
{
    return () =>
    {
        Console.WriteLine("Starting WinForms UI, close window to return to menu");
        SynchronizationContext.SetSynchronizationContext(winFormsSyncContext);
        Application.EnableVisualStyles();
        Application.Run(form);
        SynchronizationContext.SetSynchronizationContext(null);
    };
}
#endif

void ShowMenuFor(List<(string name, Action demo)> demos)
{
    while (true)
    {
        for (int i = 0; i < demos.Count; ++i)
        {
            Console.WriteLine($"{i + 1} {demos[i].name}");
        }
        Console.WriteLine("X Return to main menu");
        var line = Console.ReadLine()?.Trim();
        if (line == "X" || line == "x") return;
        if (line == null) continue;
        if (int.TryParse(line, out var number) && number > 0 && number <= demos.Count)
        {
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                demos[number - 1].demo();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
			Console.WriteLine();
			Console.WriteLine("Done");
			Console.WriteLine();
            Console.WriteLine();
            continue;
        }

        Console.WriteLine();
        Console.WriteLine("Invalid selection, please select again");
        Console.WriteLine();

    }
}
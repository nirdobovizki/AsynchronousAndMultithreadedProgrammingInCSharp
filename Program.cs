using System.Collections.Generic;

var demos = new List<(string name,List<(string name, Action demo)> demos)>
{
    ("Chapter 1", new()),
    ("Chapter 2", new(){
        ("Listing 2.1 Using Lambda functions", ForeverDemo(()=>new Chapter02.LambdaDemo1().InitTimer())),
        ("Compiler transformation of listing 2.1", ForeverDemo(()=>new Chapter02.LambdaDemo2().InitTimer())),
        ("Listing 2.2 Lambda function that uses local variables", ForeverDemo(()=>new Chapter02.LambdaDemo3().InitTimer())),
        ("Compiler transformation of listing 2.2", ForeverDemo(()=>new Chapter02.LambdaDemo4().InitTimer())),
        ("Listing 2.3 Using a list", ()=>new Chapter02.YieldDemo1().UseNoYieldDemo()),
        ("Listing 2.4 Using a list", ()=>new Chapter02.YieldDemo2().UseYieldDemo()),
        ("Compiler transformation of listing 2.4", ()=>new Chapter02.YieldDemo3().UseYieldDemo()),
    }),
    ("Chapter 3", new(){
        ("Listing 3.1 reading BMP width, non-async version", ShowResult(()=>new Chapter03.AsyncDemo1().GetBitmapWidth("sample.bmp"))),
        ("Listing 3.2 reading BMP width, async version", ShowResult(()=>new Chapter03.AsyncDemo2().GetBitmapWidth("sample.bmp").Result)),
        ("Compiler transformation of listing 3.2", ()=>new Chapter03.AsyncDemo3().GetBitmapWidth("sample.bmp",i=>Console.WriteLine(i),ex=>Console.WriteLine(ex.ToString()))),
    }),
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
    }),
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
}),
};

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
            Console.WriteLine($"{i + 1} {demos[i].name} (chapter does not contain code)");
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

void ShowMenuFor(List<(string name, Action demo)> demos)
{
    while (true)
    {
        for (int i = 0; i < demos.Count; ++i)
        {
            Console.WriteLine($"{i + 1} {demos[i].name}");
        }
        var line = Console.ReadLine()?.Trim();
        if (line == "X" || line == "x") return;
        if (line == null) continue;
        if (int.TryParse(line, out var number) && number > 0 && number <= demos.Count)
        {
            Console.WriteLine();
            Console.WriteLine();
            demos[number - 1].demo();
            Console.WriteLine();
            Console.WriteLine();
            continue;
        }

        Console.WriteLine();
        Console.WriteLine("Invalid selection, please select again");
        Console.WriteLine();

    }
}
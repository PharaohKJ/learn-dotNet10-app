using MyServerJob.App;

Console.WriteLine("Hello, World!");
Console.WriteLine($"Current date and time: {DateTimeHelper.GetCurrentDateTime():yyyy-MM-dd HH:mm:ss}");
Console.WriteLine($"Current date and time (JST): {DateTimeHelper.GetCurrentJstDateTime():yyyy-MM-dd HH:mm:ss}");
Console.WriteLine($"UUID: {Guid.NewGuid()}");

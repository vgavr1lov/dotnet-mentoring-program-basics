using HelloConcatenationLibrary;

Console.Write("Provide you username: ");
string? username = Console.ReadLine();
string hellowMessage = HelloConcatenation.ConcatenateTimeAndUsername(username);
Console.WriteLine(hellowMessage);
Console.ReadLine();
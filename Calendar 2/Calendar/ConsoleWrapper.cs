using System;

public static class ConsoleWrapper
{
    public static List<string> History { get; private set; } = new List<string>();

    public static void WriteLine(object? value)
    {
        History.Add("\n" + value.ToString());
        Console.WriteLine(value);
    }
    public static void Write(object? value)
    {
        History.Add(value.ToString());
        Console.Write(value);
    }

    public static string? ReadLine()
    {
        string s = Console.ReadLine();
        History.Add("\n" + s);
        return s;
    }
}

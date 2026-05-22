namespace AutomatedTestingFramework;

public static class NumberPrinter
{
    public static string GetLine(int n)
    {
        if (n % 3 == 0 && n % 5 == 0) return "FizzBuzz";
        if (n % 3 == 0) return "Fizz";
        if (n % 5 == 0) return "Buzz";
        return n.ToString();
    }

    public static IEnumerable<string> Get100Lines() =>
        Enumerable.Range(1, 100).Select(GetLine);
}

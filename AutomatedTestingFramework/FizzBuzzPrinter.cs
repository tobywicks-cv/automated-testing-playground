
namespace AutomatedTestingFramework
{
    internal class FizzBuzzPrinter
    {
        internal static string Print(int number)
        {
            return number switch
            {
                < 1 or > 100 => string.Empty,
                _ => (number % 3) switch
                {
                    0 when number % 5 == 0 => "FizzBuzz",
                    _ => (number % 3) switch
                    {
                        0 => "Fizz",
                        _ => number % 5 == 0 ? "Buzz" : number.ToString()
                    }
                }
            };
        }
    }
}

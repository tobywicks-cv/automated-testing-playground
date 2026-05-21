namespace AutomatedTestingFramework;

public class UnitTest1
{
    private static string[] GetStringArray(int ceiling)
    {
        return Print.Program.GetNumberOrFizzOrBuzz(ceiling).ToArray();
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(4, "4")]
    [InlineData(7, "7")]
    [InlineData(11, "11")]
    [InlineData(14, "14")]
    public void PlainNumber_PrintsNumber(int number, string expected)
    {
        Assert.Equal(expected, GetStringArray(number)[number - 1]);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(12)]
    public void MultipleOfThreeOnly_PrintsFizz(int number)
    {
        Assert.Equal("Fizz", GetStringArray(number)[number - 1]);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(25)]
    public void MultipleOfFiveOnly_PrintsBuzz(int number)
    {
        Assert.Equal("Buzz", GetStringArray(number)[number - 1]);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    public void MultipleOfFifteen_PrintsFizzBuzz(int number)
    {
        Assert.Equal("FizzBuzz", GetStringArray(number)[number - 1]);
    }
}

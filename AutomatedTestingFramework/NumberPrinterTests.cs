namespace AutomatedTestingFramework;

public class NumberPrinterTests
{
    [Fact]
    public void GetLine_Returns_Number_As_String()
    {
        Assert.Equal("1", NumberPrinter.GetLine(1));
    }

    [Fact]
    public void Get100Lines_Returns_100_Lines()
    {
        var lines = NumberPrinter.Get100Lines();

        Assert.Equal(100, lines.Count());
    }

    [Fact]
    public void Get100Lines_First_Line_Is_1_And_Last_Line_Is_Buzz()
    {
        var lines = NumberPrinter.Get100Lines().ToList();

        Assert.Equal("1", lines.First());
        Assert.Equal("Buzz", lines.Last());
    }

    [Fact]
    public void GetLine_Returns_Fizz_For_Multiple_Of_3_Only()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 != 0)
                Assert.Equal("Fizz", NumberPrinter.GetLine(i));
        }
    }

    [Fact]
    public void GetLine_Returns_Buzz_For_Multiple_Of_5_Only()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 5 == 0 && i % 3 != 0)
                Assert.Equal("Buzz", NumberPrinter.GetLine(i));
        }
    }

    [Fact]
    public void GetLine_Returns_FizzBuzz_For_Multiple_Of_3_And_5()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                Assert.Equal("FizzBuzz", NumberPrinter.GetLine(i));
        }
    }
}

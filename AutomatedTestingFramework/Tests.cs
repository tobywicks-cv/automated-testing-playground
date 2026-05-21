using FluentAssertions;

namespace AutomatedTestingFramework;

public class UnitTest1
{
    [Fact]
    public void Print_WhenInputIsLessThan1_ReturnEmpty()
    {
        FizzBuzzPrinter.Print(0).Should().BeEmpty();
    }

    [Fact]
    public void Print_WhenInputIsGreaterThan100_ReturnEmpty()
    {
        FizzBuzzPrinter.Print(101).Should().BeEmpty();
    }

    [Fact]
    public void Print_WhenInputIsMultiplesOfThere_ReturnFizz()
    {
        FizzBuzzPrinter.Print(3).Should().Be("Fizz");
    }

    [Fact]
    public void Print_WhenInputIsMultiplesOfFive_ReturnBuzz()
    {
        FizzBuzzPrinter.Print(5).Should().Be("Buzz");
    }

    [Fact]
    public void Print_WhenInputIsMultiplesOfThereAndFive_ReturnNumber()
    {
        FizzBuzzPrinter.Print(15).Should().Be("FizzBuzz");
    }

    [Fact]
    public void Print_WhenInputIsNotMultiplesOfThereOrFive_ReturnNumber()
    {
        FizzBuzzPrinter.Print(2).Should().Be(2.ToString());
    }
}
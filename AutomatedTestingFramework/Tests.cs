namespace AutomatedTestingFramework;

public class UnitTest1
{
    
//     Write a program that prints one line for each number from 1 to 100
//     Usually just print the number itself.
//         For multiples of three print Fizz instead of the number
//         For the multiples of five print Buzz instead of the number
//     For numbers which are multiples of both three and five print FizzBuzz instead of the number
    
    [Fact]
    public async Task GivenNothing_WhenRunningProgram_ThenWrites1To100()
    {
        var lines = FizzBuzzProcessor.GetOutput();
        
        await Verifier.Verify(lines);
    }
}
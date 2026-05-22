namespace AutomatedTestingFramework;

public class UnitTest1
{
    public class FizzBuzz
    {
        public string GetForNumber(int number)
        {
            if (number % 15 == 0)
            {
                return "FizzBuzz";
            }

            if (number % 3 == 0)
            {
                return "Fizz";
            }

            if (number % 5 == 0)
            {
                return "Buzz";
            }

            return number.ToString();
        }
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(7, "7")]
    [InlineData(13, "13")]
    [InlineData(22, "22")]
    [InlineData(34, "34")]
    [InlineData(76, "76")]
    [InlineData(98, "98")]
    [InlineData(101, "101")]
    [InlineData(491, "491")]
    [InlineData(997, "997")]
    public void GetForNumber_ReturnsNumber(int number, string expected)
    {
        var fizzBuzz = new FizzBuzz();
        Assert.Equal(expected, fizzBuzz.GetForNumber(number));
    }

    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(9, "Fizz")]
    [InlineData(12, "Fizz")]
    [InlineData(21, "Fizz")]
    [InlineData(33, "Fizz")]
    [InlineData(57, "Fizz")]
    [InlineData(72, "Fizz")]
    [InlineData(99, "Fizz")]
    [InlineData(111, "Fizz")]
    [InlineData(213, "Fizz")]
    [InlineData(999, "Fizz")]
    public void GetForNumber_ReturnsFizz(int number, string expected)
    {
        var fizzBuzz = new FizzBuzz();
        Assert.Equal(expected, fizzBuzz.GetForNumber(number));
    }

    [Theory]
    [InlineData(5, "Buzz")]
    [InlineData(10, "Buzz")]
    [InlineData(20, "Buzz")]
    [InlineData(35, "Buzz")]
    [InlineData(40, "Buzz")]
    [InlineData(50, "Buzz")]
    [InlineData(95, "Buzz")]
    [InlineData(115, "Buzz")]
    [InlineData(470, "Buzz")]
    [InlineData(995, "Buzz")]
    public void GetForNumber_ReturnsBuzz(int number, string expected)
    {
        var fizzBuzz = new FizzBuzz();
        Assert.Equal(expected, fizzBuzz.GetForNumber(number));
    }

    [Theory]
    [InlineData(0, "FizzBuzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(30, "FizzBuzz")]
    [InlineData(45, "FizzBuzz")]
    [InlineData(60, "FizzBuzz")]
    [InlineData(75, "FizzBuzz")]
    [InlineData(90, "FizzBuzz")]
    [InlineData(105, "FizzBuzz")]
    [InlineData(120, "FizzBuzz")]
    [InlineData(300, "FizzBuzz")]
    [InlineData(990, "FizzBuzz")]
    public void GetForNumber_ReturnsFizzBuzz(int number, string expected)
    {
        var fizzBuzz = new FizzBuzz();
        Assert.Equal(expected, fizzBuzz.GetForNumber(number));
    }

    public class FixBuzz
    {
        private static readonly Dictionary<int, string> FizzBuzzValues = new Dictionary<int, string>
        {
            { 1, "1" },
            { 2, "2" },
            { 3, "Fizz" },
            { 4, "4" },
            { 5, "Buzz" },
            { 6, "Fizz" },
            { 7, "7" },
            { 8, "8" },
            { 9, "Fizz" },
            { 10, "Buzz" },
            { 11, "11" },
            { 12, "Fizz" },
            { 13, "13" },
            { 14, "14" },
            { 15, "FizzBuzz" },
            { 16, "16" },
            { 17, "17" },
            { 18, "Fizz" },
            { 19, "19" },
            { 20, "Buzz" },
            { 21, "Fizz" },
            { 22, "22" },
            { 23, "23" },
            { 24, "Fizz" },
            { 25, "Buzz" },
            { 26, "26" },
            { 27, "Fizz" },
            { 28, "28" },
            { 29, "29" },
            { 30, "FizzBuzz" },
            { 31, "31" },
            { 32, "32" },
            { 33, "Fizz" },
            { 34, "34" },
            { 35, "Buzz" },
            { 36, "Fizz" },
            { 37, "37" },
            { 38, "38" },
            { 39, "Fizz" },
            { 40, "Buzz" },
            { 41, "41" },
            { 42, "Fizz" },
            { 43, "43" },
            { 44, "44" },
            { 45, "FizzBuzz" },
            { 46, "46" },
            { 47, "47" },
            { 48, "Fizz" },
            { 49, "49" },
            { 50, "Buzz" },
            { 51, "Fizz" },
            { 52, "52" },
            { 53, "53" },
            { 54, "Fizz" },
            { 55, "Buzz" },
            { 56, "56" },
            { 57, "Fizz" },
            { 58, "58" },
            { 59, "59" },
            { 60, "FizzBuzz" },
            { 61, "61" },
            { 62, "62" },
            { 63, "Fizz" },
            { 64, "64" },
            { 65, "Buzz" },
            { 66, "Fizz" },
            { 67, "67" },
            { 68, "68" },
            { 69, "Fizz" },
            { 70, "Buzz" },
            { 71, "71" },
            { 72, "Fizz" },
            { 73, "73" },
            { 74, "74" },
            { 75, "FizzBuzz" },
            { 76, "76" },
            { 77, "77" },
            { 78, "Fizz" },
            { 79, "79" },
            { 80, "Buzz" },
            { 81, "Fizz" },
            { 82, "82" },
            { 83, "83" },
            { 84, "Fizz" },
            { 85, "Buzz" },
            { 86, "86" },
            { 87, "Fizz" },
            { 88, "88" },
            { 89, "89" },
            { 90, "FizzBuzz" },
            { 91, "91" },
            { 92, "92" },
            { 93, "Fizz" },
            { 94, "94" },
            { 95, "Buzz" },
            { 96, "Fizz" },
            { 97, "97" },
            { 98, "98" },
            { 99, "Fizz" },
            { 100, "Buzz" },
        };

        public string[] Process()
        {
            var fizzBuzz = new FizzBuzz();
            List<string> list = new List<string>(100);
            for (var i = 0; i < 100; i++)
            {
                list.Add(fizzBuzz.GetForNumber(i + 1));
            }
            return list.ToArray();
        }

        public bool Verify(string[] output)
        {
            for (int i = 0; i < output.Length; i++)
            {
                int key = i + 1;
                if (!FizzBuzzValues.ContainsKey(key))
                    return false;
                if (output[i] != FizzBuzzValues[key])
                    return false;
            }
            return true;
        }
    }
    
    [Fact]
    public void VerifyGetForNumberWorksForFirst100Numbers()
    {
        var fb = new FixBuzz();
        Assert.True(fb.Verify(fb.Process()));
    }
}
    
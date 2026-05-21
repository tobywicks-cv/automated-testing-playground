namespace AutomatedTestingFramework;

public class FizzBuzzProcessor
{
    public static string[] GetOutput()
    {
        var list = new List<string>();
        
        for (var i = 1; i <= 100; i++)
        {
            if (i % 3 == 0)
            {
                list.Add("Fizz");  
            }
            else
            {
                list.Add(i.ToString());  
            }
        }

        return list.ToArray();
    }
}
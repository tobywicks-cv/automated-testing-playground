namespace Print
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = GetNumberOrFizzOrBuzz(100);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static List<string> GetNumberOrFizzOrBuzz(int ceiling)
        {
            var list = new List<string>();

            for (int i = 1; i <= ceiling; i++)
            {
                if (i % 15 == 0)
                    list.Add("FizzBuzz");
                else if (i % 3 == 0)
                    list.Add("Fizz");
                else if (i % 5 == 0)
                    list.Add("Buzz");
                else
                    list.Add(i.ToString());
            }

            return list;
        }
    }
}

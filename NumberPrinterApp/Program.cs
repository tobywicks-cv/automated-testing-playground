foreach (var line in Enumerable.Range(1, 100).Select(n =>
    n % 3 == 0 && n % 5 == 0 ? "FizzBuzz" :
    n % 3 == 0 ? "Fizz" :
    n % 5 == 0 ? "Buzz" :
    n.ToString()))
    Console.WriteLine(line);

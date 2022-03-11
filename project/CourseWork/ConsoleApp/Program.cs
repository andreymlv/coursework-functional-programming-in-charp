using Library;

Console.WriteLine($"Recursive:\t{8 * Sum.RecursiveInvoke((x) => 1.0d / (x * (x + 2)), 1, (x) => x + 4, 10000)}");
Console.WriteLine($"Tail Recursive:\t{8 * Sum.TailRecursiveInvoke((x) => 1.0d / (x * (x + 2)), 1, (x) => x + 4, 10000)}");
Console.WriteLine($"DotNet:\t\t{8 * Sum.DotNetInvoke((x) => 1.0d / (x * (x + 2)), 1, (x) => x + 4, 10000)}");
Console.WriteLine($"Imperative:\t{8 * Sum.ImperativeInvoke((x) => 1.0d / (x * (x + 2)), 1, (x) => x + 4, 10000)}");
Console.WriteLine($"Actual:\t\t{Math.PI}");

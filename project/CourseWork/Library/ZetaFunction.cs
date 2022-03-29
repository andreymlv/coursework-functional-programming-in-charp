namespace Library;

public static class ZetaFunction
{
    /// <summary>
    ///     Проверяем, что число - простое.
    /// </summary>
    /// <param name="number">Входное число</param>
    /// <returns>Результат проверки на простоту числа</returns>
    private static bool IsPrime(int number)
    {
        // 2 и 3 - простые числа
        if (number is > 1 and < 4)
            return true;
        if (number < 2 || number % 2 != 0) // Отрицательные, 0, 1 и все чётные числа - не простые
            return false;

        return Enumerable
            .Range(3, (int) (Math.Sqrt(number) + 1) - 3) // Создаём отрезок [3 ; number^(1/2) + 1]
            .Where((_, i) => i % 2 == 0) // Удаляем из отрезка каждое второе число
            .All(i => number % i != 0); /* Если есть хотя бы одно число,
                                которое делится на наше изначальное число, то получаем false */
    }

    /// <summary>
    ///     Нахождение следующего простого числа после <paramref name="number"/>.
    /// </summary>
    /// <param name="number">Число.</param>
    /// <returns></returns>
    private static double NextPrime(double number)
    {
        var n = (int) number;
        // Loop continuously until isPrime
        // returns true for a number
        // greater than n
        while (!IsPrime(++n))
        {
        }

        return n;
    }

    public static double SumSolve(double s) => Sum.ImperativeInvoke(n => 1 / Math.Pow(n, s), 1, n => n + 1, 1000);

    public static double ProductSolve(double s) =>
        Product.ImperativeInvoke(n => 1 / (1 - Math.Pow(n, -s)), 2, NextPrime, 1000);
}
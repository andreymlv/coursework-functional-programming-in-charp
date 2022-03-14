
namespace Library;

/// <summary>
///     Вавилонский метод (метод Герона) для поиска приближенного значения корня числа.
///     https://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Babylonian_method
///     https://ru.wikipedia.org/wiki/%D0%98%D1%82%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D0%B0%D1%8F_%D1%84%D0%BE%D1%80%D0%BC%D1%83%D0%BB%D0%B0_%D0%93%D0%B5%D1%80%D0%BE%D0%BD%D0%B0
/// </summary>
public static class Sqrt
{
    /// <summary>
    ///     Точность поиска.
    ///     Чем меньше, тем точнее.
    /// </summary>
    private const double Epsilon = 0.001;

    /// <summary>
    ///     Квадрат числа.
    /// </summary>
    /// <param name="x">Число.</param>
    /// <returns>Результат умножения числа на само себя.</returns>
    private static double
        Square(double x) =>
            x * x;

    /// <summary>
    ///     Проверяем, что нашли корень числа.
    /// </summary>
    /// <param name="guess">Догадка корня числа.</param>
    /// <param name="x">Число, корень которого ищем.</param>
    /// <returns>Проверяем равенство $guess^2 = x$ с точность <see cref="Epsilon"/>.</returns>
    private static bool
        Check(double guess, double x) =>
            Math.Abs(Square(guess) - x) < Epsilon;

    /// <summary>
    //      Среднее между двумя числами.
    /// </summary>
    /// <param name="x">Первое число.</param>
    /// <param name="y">Второе число.</param>
    /// <returns>Сумма двух чисел, делённую на два.</returns>
    private static double
        Average(double x, double y) =>
            (x + y) / 2.0;

    /// <summary>
    ///     Увеличиваем точность корня числа.
    ///     Получили, применив метод Ньютона к уравнению $x^2 - S = 0$.
    /// </summary>
    /// <param name="guess">Догадка корня числа.</param>
    /// <param name="x">Число, корень которого ищем.</param>
    /// <returns>Улучшенный корень числа.</returns>
    private static double
        Improve(double guess, double x) =>
            Average(guess, x / guess);

    /// <summary>
    ///     Корень числа <paramref name="x"/>, начиная поиск с <paramref name="guess"/>.
    /// </summary>
    /// <param name="guess">Догадка корня числа.</param>
    /// <param name="x">Число, корень которого мы ищем.</param>
    /// <returns>Догадка корня числа.</returns>
    private static double
        SqrtIterate(double guess, double x) =>
            Check(guess, x) ?
                guess :
                SqrtIterate(Improve(guess, x), x);

    /// <summary>
    ///     Корень числа.
    /// </summary>
    /// <param name="x">Число, корень которого мы ищем.</param>
    /// <returns>Корень числа <paramref name="x"/>, начиная поиск с <paramref name="guess"/>.</returns>
    public static double
        RecursiveInvoke(double x) =>
            SqrtIterate(1.0, x);

    /// <summary>
    ///     Корень числа, применяя оптимизацию хвостовой рекурсии.
    /// </summary>
    /// <param name="x"></param>
    /// <returns>Корень числа <paramref name="x"/>, начиная поиск с <paramref name="guess"/>.</returns>
    public static double
        TailRecursiveInvoke(double x) =>
            TailRecursion.Execute(
                () => RecursiveInvokeHelper(1.0, x)
            );

    /// <summary>
    ///     Корень числа <paramref name="x"/>, начиная поиск с <paramref name="guess"/>.
    /// </summary>
    /// <param name="guess">Догадка корня числа.</param>
    /// <param name="x">Число, корень которого мы ищем.</param>
    /// <returns>Догадка корня числа.</returns>
    private static RecursionResult<double>
        RecursiveInvokeHelper(double guess, double x) =>
            Check(guess, x) ?
                TailRecursion.Return(guess) :
                TailRecursion.Next(
                    () => RecursiveInvokeHelper(Improve(guess, x), x)
                );
}


namespace Library;

public static class EquationSolver
{
    public static readonly double Epsilon = 0.001;

    public static bool CloseEnough(double x, double y) => Math.Abs(x - y) < Epsilon;

    public static double Average(double x, double y) => (x + y) / 2;

    public static bool Positive(double x) => x > 0;

    public static bool Negative(double x) => x < 0;

    private static double Search(Func<double, double> f, double negPoint, double posPoint)
    {
        var midpoint = Average(negPoint, posPoint);

        if (!CloseEnough(negPoint, posPoint))
        {
            var testValue = f(midpoint);

            if (Positive(testValue))
                Search(f, negPoint, midpoint);
            else if (Negative(testValue))
                Search(f, midpoint, posPoint);
        }

        return midpoint;
    }

    /// <summary>
    ///     Метод половинного деления.
    ///     Метод нахождения корней уравнения.
    ///
    ///     Идея в том, что если даны две точки a,b, что f(a) < 0 < f(b),
    ///     то между ними существует f(c) = 0.
    ///     
    ///     Тогда воспользуемся идеей бинарного поиска, чтобы найти нужную точку.
    /// </summary>
    /// <param name="f">Функция, в которой ищем корень.</param>
    /// <param name="a">Начало интервала поиска.</param>
    /// <param name="b">Конечц интервала поиска.</param>
    /// <returns>Корень уровнения между <paramref name="a"/> и <paramref name="b"/></returns>
    public static double HalfIntervalMethod(Func<double, double> f, double a, double b)
    {
        var aValue = f(a);
        var bValue = f(b);

        if (Negative(aValue) && Positive(bValue))
            return Search(f, a, b);
        else if (Negative(bValue) && Positive(aValue))
            return Search(f, b, a);
        else
            throw new ArgumentException($"Arguments don't have different signs: {nameof(a)} and {nameof(b)}");
    }
}


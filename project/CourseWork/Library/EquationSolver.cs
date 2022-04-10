
namespace Library;

public static class EquationSolver
{
    private static readonly double Epsilon = 0.0001;

    private static bool CloseEnough(double x, double y) => Math.Abs(x - y) < Epsilon;

    private static double Average(double x, double y) => (x + y) / 2;

    private static bool Positive(double x) => x > 0;

    private static bool Negative(double x) => x < 0;

    private static double Search(Func<double, double> f, double negPoint, double posPoint)
    {
        var midpoint = Average(negPoint, posPoint);

        if (!CloseEnough(negPoint, posPoint))
        {
            var testValue = f(midpoint);

            if (Positive(testValue))
                return Search(f, negPoint, midpoint);
            else if (Negative(testValue))
                return Search(f, midpoint, posPoint);
        }

        return midpoint;
    }

    /// <summary>
    ///     Метод половинного деления.
    ///     Метод нахождения корней уравнения.
    ///
    ///     Идея в том, что если даны две точки a и b, что f(a) < 0 < f(b),
    ///     то между ними существует f(c) = 0.
    ///     
    ///     Тогда воспользуемся идеей бинарного поиска, чтобы найти нужную точку.
    /// </summary>
    /// <param name="f">Функция, в которой ищем корень.</param>
    /// <param name="a">Начало интервала поиска.</param>
    /// <param name="b">Конец интервала поиска.</param>
    /// <returns>Корень уравнения между <paramref name="a"/> и <paramref name="b"/>.</returns>
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

    /// <summary>
    ///     Вычисление неподвижной точки функции.
    ///     Число x называется неподвижной точкой функции f, если оно удолетворяет f(x) = x.
    ///     Работает только для некоторых функций.
    /// </summary>
    /// <param name="f">Функция, в которой ищем неподвижную точку.</param>
    /// <param name="firstGuess">Первое приблежение, которое будет улучшаться.</param>
    /// <returns>Неподвижная точка функции <paramref name="f"/>.</returns>
    public static double FixedPoint(Func<double, double> f, double firstGuess)
    {
        var next = f(firstGuess);
        if (CloseEnough(firstGuess, next))
            return next;
        return FixedPoint(f, next);
    }

    /// <summary>
    ///     Функция высшего порядка для торможения усреднением.
    ///     Используется для нахождения неподвижной точки тех функций, которые не могут сойтись простым вызывом FixedPoint.
    /// </summary>
    /// <param name="f">Функция, в которой ищем неподвижную точку.</param>
    /// <returns>Функцию, которая вернёт усреднённое значение между входным значением <paramref name="f"/> и значением вычисления <paramref name="f"/> от входного значения.</returns>
    public static Func<double, double> AverageDamp(Func<double, double> f) => (x) => Average(x, f(x));
}

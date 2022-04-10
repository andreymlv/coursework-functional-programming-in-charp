namespace Library;

public static class EquationSolver
{
    private const double Epsilon = 0.0001;

    private static bool CloseEnough(double x, double y)
    {
        return Math.Abs(x - y) < Epsilon;
    }

    private static double Average(double x, double y)
    {
        return (x + y) / 2;
    }

    private static bool Positive(double x)
    {
        return x > 0;
    }

    private static bool Negative(double x)
    {
        return x < 0;
    }

    private static double Search(Func<double, double> f, double negPoint, double posPoint)
    {
        while (true)
        {
            var midpoint = Average(negPoint, posPoint);

            if (CloseEnough(negPoint, posPoint)) return midpoint;
            var testValue = f(midpoint);

            if (Positive(testValue))
            {
                posPoint = midpoint;
                continue;
            }

            if (!Negative(testValue)) return midpoint;
            negPoint = midpoint;
        }
    }

    /// <summary>
    ///     Метод половинного деления.
    ///     Метод нахождения корней уравнения.
    ///     Идея в том, что если даны две точки a и b, что f(a) &lt; 0 &lt; f( b) то между ними существует f( c)= 0.
    ///     Тогда воспользуемся идеей бинарного поиска, чтобы найти нужную точку.
    /// </summary>
    /// <param name="f">Функция, в которой ищем корень.</param>
    /// <param name="a">Начало интервала поиска.</param>
    /// <param name="b">Конец интервала поиска.</param>
    /// <returns>Корень уравнения между <paramref name="a" /> и <paramref name="b" />.</returns>
    /// <exception cref="ArgumentException">Если f(a) и f(b) имеют одинаковые знаки.</exception>
    public static double HalfIntervalMethod(Func<double, double> f, double a, double b)
    {
        var aValue = f(a);
        var bValue = f(b);

        if (Negative(aValue) && Positive(bValue))
            return Search(f, a, b);
        if (Negative(bValue) && Positive(aValue))
            return Search(f, b, a);
        throw new ArgumentException($"Arguments don't have different signs: {nameof(a)} and {nameof(b)}");
    }

    /// <summary>
    ///     Вычисление неподвижной точки функции.
    ///     Число x называется неподвижной точкой функции f, если оно удолетворяет f(x) = x.
    ///     Работает только для некоторых функций.
    /// </summary>
    /// <param name="f">Функция, в которой ищем неподвижную точку.</param>
    /// <param name="firstGuess">Первое приблежение, которое будет улучшаться.</param>
    /// <returns>Неподвижная точка функции <paramref name="f" />.</returns>
    public static double FixedPoint(Func<double, double> f, double firstGuess)
    {
        while (true)
        {
            var next = f(firstGuess);
            if (CloseEnough(firstGuess, next)) return next;
            firstGuess = next;
        }
    }

    /// <summary>
    ///     Функция высшего порядка для торможения усреднением.
    ///     Используется для нахождения неподвижной точки тех функций, которые не могут сойтись простым вызывом FixedPoint.
    /// </summary>
    /// <param name="f">Функция, в которой ищем неподвижную точку.</param>
    /// <returns>
    ///     Функцию, которая вернёт усреднённое значение между входным значением <paramref name="f" /> и значением
    ///     вычисления <paramref name="f" /> от входного значения.
    /// </returns>
    public static Func<double, double> AverageDamp(Func<double, double> f)
    {
        return x => Average(x, f(x));
    }
}
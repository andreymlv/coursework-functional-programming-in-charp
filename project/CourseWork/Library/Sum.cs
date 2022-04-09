namespace Library;

/// <summary>
///     Реализация оператора суммы (сигма).
/// </summary>
public static class Sum
{
    private const double Base = 0.0d;

    private static double Operator(double a, double b) => a + b;

    /// <summary>
    ///     Вычисление суммы последовательности <paramref name="term"/> от <paramref name="start"/>
    ///     до <paramref name="end"/>, где следующий элемент выбирается с помощью <paramref name="next"/>.
    ///     Стратегия вычисления выбирается с помощью функций в <see cref="Sequence"/>.
    /// </summary>
    /// <param name="invoke">Стратегия вычисления.</param>
    /// <param name="term">Общий член последовательности.</param>
    /// <param name="start">Начало последовательности.</param>
    /// <param name="next">Выбор следующего элемента.</param>
    /// <param name="end">Конец последовательности.</param>
    /// <returns>Вычисление последовательности с заданными параметрами.</returns>
    public static double Solve(Func<Func<double, double, double>, Func<double, double>, double, Func<double, double>, double, double, double> invoke, Func<double, double> term, double start, Func<double, double> next, double end) => invoke(Operator, term, start, next, end, Base);
}
namespace Library;

/// <summary>
///     Реализация оператора суммы (сигма).
/// </summary>
public static class Sum
{
    private static double Operator(double a, double b) => a + b;
    private static double _base = 0.0d;

    /// <summary>
    ///     Рекурсивный вызов оператора суммы.
    ///     Возможно переполнение стека.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу суммы.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>Сумма от <paramref name="start"/> до <paramref name="end"/> с шагом <paramref name="next"/> с
    /// применением <paramref name="term"/> для каждого элемента.</returns>
    public static double RecursiveInvoke(Func<double, double> term, double start, Func<double, double> next, double end)
    {
        return Sequence.RecursiveInvoke(Operator, term, start, next, end, _base);
    }

    /// <summary>
    ///     Рекурсивный вызов оператора суммы, применяя оптимизацию хвостовой рекурсии.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу суммы.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>Сумма от <paramref name="start"/> до <paramref name="end"/> с шагом <paramref name="next"/> с
    /// применением <paramref name="term"/> для каждого элемента.</returns>
    public static double TailRecursiveInvoke(Func<double, double> term, double start, Func<double, double> next, double end)
    {
        return Sequence.TailRecursiveInvoke(Operator, term, start, next, end, _base);
    }

    /// <summary>
    ///     Императивный вызов оператора суммы.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу суммы.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>Сумма от <paramref name="start"/> до <paramref name="end"/> с шагом <paramref name="next"/> с
    /// применением <paramref name="term"/> для каждого элемента.</returns>
    public static double ImperativeInvoke(Func<double, double> term, double start, Func<double, double> next, double end)
    {
        return Sequence.ImperativeInvoke(Operator, term, start, next, end, _base);
    }

    /// <summary>
    ///     Параллельное вычисление суммы с помощью стандартных средств DotNet.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу суммы.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>Сумма от <paramref name="start"/> до <paramref name="end"/> с шагом <paramref name="next"/> с
    /// применением <paramref name="term"/> для каждого элемента.</returns>
    public static double DotNetInvoke(Func<double, double> term, int start, Func<double, double> next, int end)
    {
        return Sequence.DotNetInvoke(Operator, term, start, next, end, _base);
    }
}
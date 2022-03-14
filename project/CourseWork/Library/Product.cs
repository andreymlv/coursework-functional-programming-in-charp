namespace Library;

public static class Product
{
    private const double Base = 1.0d;

    private static double Operator(double a, double b) => a * b;

    /// <summary>
    ///     Рекурсивный вызов оператора произведения.
    ///     Возможно переполнение стека.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу произведения.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>
    ///     Произведение от <paramref name="start" /> до <paramref name="end" /> с шагом <paramref name="next" /> с
    ///     применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    public static double
        RecursiveInvoke(Func<double, double> term, double start, Func<double, double> next, double end) =>
        Sequence.RecursiveInvoke(Operator, term, start, next, end, Base);

    /// <summary>
    ///     Рекурсивный вызов оператора произведения, применяя оптимизацию хвостовой рекурсии.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу произведения.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>
    ///     Произведение от <paramref name="start" /> до <paramref name="end" /> с шагом <paramref name="next" /> с
    ///     применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    public static double TailRecursiveInvoke(Func<double, double> term, double start, Func<double, double> next,
        double end) =>
        Sequence.TailRecursiveInvoke(Operator, term, start, next, end, Base);

    /// <summary>
    ///     Императивный вызов оператора произведения.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу произведения.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>
    ///     Произведение от <paramref name="start" /> до <paramref name="end" /> с шагом <paramref name="next" /> с
    ///     применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    public static double ImperativeInvoke(Func<double, double> term, double start, Func<double, double> next,
        double end) =>
        Sequence.ImperativeInvoke(Operator, term, start, next, end, Base);

    /// <summary>
    ///     Параллельное вычисление суммы с помощью стандартных средств DotNet.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу произведения.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>
    ///     Произведение от <paramref name="start" /> до <paramref name="end" /> с шагом <paramref name="next" /> с
    ///     применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    public static double DotNetInvoke(Func<double, double> term, int start, Func<double, double> next, int end) =>
        Sequence.DotNetInvoke(Operator, term, start, next, end, Base);
}
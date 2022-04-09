namespace Library;

/// <summary>
///     Модуль последовательности (ряд).
/// 
///     Четыре способа вычисления ряда:
///         
///         - Рекурсивное вычисление.
///         - Рекурсивное вычисление с помощью оптимизации хвостовой рекурсией.
///         - Императивное вычисление.
///         - Параллельное вычисление.
/// </summary>
public static class Sequence
{
    /// <summary>
    ///     Рекурсивный вызов оператора последовательности.
    ///     Возможно переполнение стека.
    /// </summary>
    /// <param name="op">Функция, которая будет применяться между двумя элементами последовательности.</param>
    /// <param name="term">Функция, которая будет применена к каждому элементу последовательности.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <param name="based">Основа последовательности.</param>
    /// <returns>
    ///     Вычисление последовательности от <paramref name="start" /> до <paramref name="end" /> с шагом
    ///     <paramref name="next" /> с применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    public static double RecursiveInvoke(Func<double, double, double> op, Func<double, double> term, double start,
        Func<double, double> next, double end, double based) =>
        start > end ? based : op(term(start), RecursiveInvoke(op, term, next(start), next, end, based));

    /// <summary>
    ///     Рекурсивный вызов оператора последовательности, применяя оптимизацию хвостовой рекурсии.
    ///     Утверждается, что код переобразуется в функцию вида <see cref="TailRecursiveInvoke" />
    ///     и теоретически соотвествовать функции <see cref="ImperativeInvoke"/>
    /// </summary>
    /// <param name="op">Функция, которая будет применяться между двумя элементами последовательности.</param>
    /// <param name="term">Функция, которая будет применена к каждому элементу последовательности.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <param name="based">Основа последовательности.</param>
    /// <returns>
    ///     Вычисление последовательности от <paramref name="start" /> до <paramref name="end" /> с шагом
    ///     <paramref name="next" /> с применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    public static double TailRecursiveInvoke(Func<double, double, double> op, Func<double, double> term, double start,
        Func<double, double> next, double end, double based) =>
        TailRecursion.Execute(() => RecursiveInvokeHelper(op, term, start, next, end, based));

    /// <summary>
    ///     Определение самой функции сумма с использованием аккумулятора.
    /// </summary>
    /// <param name="op">Функция, которая будет применяться между двумя элементами последовательности.</param>
    /// <param name="term">Функция, которая будет применена к каждому элементу последовательности.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <param name="based">Основа последовательности.</param>
    /// <returns>
    ///     Вычисление последовательности от <paramref name="start" /> до <paramref name="end" /> с шагом
    ///     <paramref name="next" /> с применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    private static RecursionResult<double> RecursiveInvokeHelper(Func<double, double, double> op,
        Func<double, double> term, double start, Func<double, double> next, double end, double based) =>
        start > end ? TailRecursion.Return(based) : TailRecursion.Next(() => RecursiveInvokeHelper(op, term, next(start), next, end, op(based, term(start))));

    /// <summary>
    ///     Императивный вызов оператора суммы.
    /// </summary>
    /// <param name="op">Функция, которая будет применяться между двумя элементами последовательности.</param>
    /// <param name="term">Функция, которая будет применена к каждому элементу последовательности.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <param name="based">Основа последовательности.</param>
    /// <returns>
    ///     Вычисление последовательности от <paramref name="start" /> до <paramref name="end" /> с шагом
    ///     <paramref name="next" /> с применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    public static double ImperativeInvoke(Func<double, double, double> op, Func<double, double> term, double start,
        Func<double, double> next, double end, double based)
    {
        for (var i = start; i <= end; i = next(i))
            based = op(based, term(i));
        return based;
    }

    /// <summary>
    ///     Параллельное вычисление последовательности с помощью стандартных средств DotNet.
    /// </summary>
    /// <param name="op">Функция, которая будет применяться между двумя элементами последовательности.</param>
    /// <param name="term">Функция, которая будет применена к каждому элементу последовательности.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <param name="based">Основа последовательности.</param>
    /// <returns>
    ///     Вычисление последовательности от <paramref name="start" /> до <paramref name="end" /> с шагом
    ///     <paramref name="next" /> с применением <paramref name="term" /> для каждого элемента.
    /// </returns>
    public static double DotNetInvoke(Func<double, double, double> op, Func<double, double> term, double start,
        Func<double, double> next, double end, double based) =>
        ParallelEnumerable
            .Range((int)start, (int)(end - start) + 1) // Создаём отрезок [start; end] типа int
            .Where((_, i) => i % next(0) == 0) // Фильтруем элементы с шагом next(0)
            .Select<int, double>(i => i) // Конвертируем отрезок в double
            .Select(term) // Для каждого отфильтрованного элемента применяем функцию term
            .Aggregate(based, op); // Применяем оператор последовательности
}
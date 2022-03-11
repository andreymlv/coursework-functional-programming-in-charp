namespace Library;

/// <summary>
///     Реализация оператора суммы (сигма).
/// </summary>
public static class Sum
{
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
    public static double RecursiveInvoke(Func<double, double> term,
        double start,
        Func<double, double> next,
        double end)
    {
        if (start > end)
            return 0.0d;
        return term(start) + RecursiveInvoke(term, next(start), next, end);
    }

    /// <summary>
    ///     Рекурсивный вызов оператора суммы, применяя оптимизацию хвостовой рекурсии.
    ///     Утверждается, что код переобразуется в функцию вида <see cref="TailRecursion.Execute{T}(Func{RecursionResult{T}})"/>
    ///     и теоретически соотвествовать функции <see cref="ImperativeInvoke(Func{double, double}, double, Func{double, double}, double)"/>.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу суммы.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <returns>Сумма от <paramref name="start"/> до <paramref name="end"/> с шагом <paramref name="next"/> с
    /// применением <paramref name="term"/> для каждого элемента.</returns>
    public static double TailRecursiveInvoke(Func<double, double> term,
        double start,
        Func<double, double> next,
        double end)
    {
        return TailRecursion.Execute(() => RecursiveInvokeHelper(term, start, next, end, 0.0d));
    }

    /// <summary>
    ///     Определение самой функции сумма с использованием аккумулятора.
    /// </summary>
    /// <param name="term">Функция, которая будет применена к каждому элементу суммы.</param>
    /// <param name="start">Начало отрезка.</param>
    /// <param name="next">Функция выбора следующего элемента, основываясь на предыдущем.</param>
    /// <param name="end">Конец отрезка.</param>
    /// <param name="accumulator">Аккумулятор для нашей рекурсии.</param>
    /// <returns>Сумма от <paramref name="start"/> до <paramref name="end"/> с шагом <paramref name="next"/> с
    /// применением <paramref name="term"/> для каждого элемента.</returns>
    private static RecursionResult<double> RecursiveInvokeHelper(Func<double, double> term,
        double start,
        Func<double, double> next,
        double end,
        double accumulator)
    {
        if (start > end)
            return TailRecursion.Return(accumulator);
        return TailRecursion.Next(() => RecursiveInvokeHelper(term, next(start), next, end, accumulator + term(start)));
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
    public static double ImperativeInvoke(Func<double, double> term,
        double start,
        Func<double, double> next,
        double end)
    {
        double accumulator = 0.0d;
        for (var i = start; i <= end; i = next(i))
            accumulator += term(i);
        return accumulator;
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
    public static double DotNetInvoke(Func<double, double> term,
        int start,
        Func<double, double> next,
        int end)
    {
        return ParallelEnumerable
            .Range(start, end - start + 1)          // Создаём отрезок [start; end] типа int
            .Where((_, i) => i % next(0) == 0)      // Фильтруем элементы с шагом next(0)
            .Select<int, double>(i => i)            // Конвертируем отрезок в double
            .Select(term)                           // Для каждого отфильтрованного элемента применяем функцию term
            .Sum();                                 // Суммируем
    }
}
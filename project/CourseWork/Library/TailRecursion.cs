namespace Library;

/// <summary>
///     Реализация оптимизации хвостовой рекурсии через лямбду.
/// </summary>
public static class TailRecursion
{
    /// <summary>
    ///     Запуск рекурсивной функции, превращая её в императивный стиль.
    /// </summary>
    /// <typeparam name="T">Тип данных, возвращаемой рекурсивной функции.</typeparam>
    /// <param name="func">Рекурсивная функция.</param>
    /// <returns>Результат выполнения рекурсии.</returns>
    public static T Execute<T>(Func<RecursionResult<T>> func)
    {
        while (true)
        {
            var recursionResult = func();
            if (recursionResult.IsFinalResult)
                return recursionResult.Result;
            func = recursionResult.NextStep;
        }
    }

    /// <summary>
    ///     Завершаем рекурсию, возвращаем результат выполнения.
    /// </summary>
    /// <typeparam name="T">Тип данных, возвращаемой рекурсивной функции.</typeparam>
    /// <param name="result">Сам результат.</param>
    /// <returns>Результат выполнения рекурсии.</returns>
    public static RecursionResult<T> Return<T>(T result)
    {
        return new RecursionResult<T>(true, result, null!);
    }

    /// <summary>
    ///     Выбираем следующий элемент в рекурсии.
    /// </summary>
    /// <param name="nextStep">Функция, которая выбирает следующий элемент.</param>
    /// <typeparam name="T">Тип данных, возвращаемой рекурсивной функции.</typeparam>
    /// <returns>Следующий элемент рекурсии.</returns>
    public static RecursionResult<T> Next<T>(Func<RecursionResult<T>> nextStep)
    {
        return new RecursionResult<T>(false, default!, nextStep);
    }
}
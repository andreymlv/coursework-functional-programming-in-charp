namespace Library;

/// <summary>
///     Контейнер для результата рекурсии.
/// </summary>
/// <typeparam name="T">Тип данных, которую должна вернуть рекурсивная функция</typeparam>
/// <param name="IsFinalResult">Получили ли мы конечный результат вычислений рекурсии?</param>
/// <param name="Result">Сам результат выполнения рекурсивной функции.</param>
/// <param name="NextStep">Функция, которая воспроизводит следующее значение для выполнения нашей рекурсивной функции.</param>
public readonly record struct RecursionResult<T>(bool IsFinalResult, T Result, Func<RecursionResult<T>> NextStep) { }
namespace Library;

public static class PiSeries
{
    private static double Term(double x) => 1.0d / (x * (x + 2));
    private static double Next(double x) => x + 4;
    public static double Solve() => 8 * Sum.ImperativeInvoke(Term, 1, Next, 10000);
}
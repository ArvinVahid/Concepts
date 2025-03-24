using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

public class Sample
{
    public int Multiply(int x, int y) => x * y;
}

class Program
{
    static void Main()
    {
        var sample = new Sample();
        MethodInfo methodInfo = typeof(Sample).GetMethod("Multiply");

        // تست Reflection
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 1_000_000; i++)
            methodInfo.Invoke(sample, new object[] { 5, 10 });
        sw.Stop();
        Console.WriteLine($"Reflection Time: {sw.ElapsedMilliseconds} ms");

        // تست Expression Tree
        var param1 = Expression.Parameter(typeof(int), "x");
        var param2 = Expression.Parameter(typeof(int), "y");
        var instance = Expression.Constant(sample);
        var call = Expression.Call(instance, methodInfo, param1, param2);
        var lambda = Expression.Lambda<Func<int, int, int>>(call, param1, param2).Compile();

        sw.Restart();
        for (int i = 0; i < 1000000; i++)
            lambda(5, 10);
        sw.Stop();
        Console.WriteLine($"Expression Tree Time: {sw.ElapsedMilliseconds} ms");
    }
}
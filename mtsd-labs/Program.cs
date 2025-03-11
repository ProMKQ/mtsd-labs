namespace mtsd_labs;

internal class Program
{
    private static (double, double) SolveQuadratic(double a, double b, double c)
    {
        double temp = -0.5 * (b + Math.Sign(b) * Math.Sqrt(b * b - 4 * a * c));
        double x1 = temp / a;
        double x2 = c / temp;
        return (x1, x2);
    }

    private static void Main(string[] args)
    {
        if (args.Length == 3)
        {
            double a = double.Parse(args[0]);
            double b = double.Parse(args[1]);
            double c = double.Parse(args[2]);
            (double x1, double x2) = SolveQuadratic(a, b, c);
            Console.WriteLine($"x1 = {x1}, x2 = {x2}");
        }
    }
}

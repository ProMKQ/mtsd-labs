using System.Globalization;

namespace mtsd_labs;

internal class Program
{
    private static List<double> SolveQuadratic(double a, double b, double c)
    {
        double temp = -0.5 * (b + Math.Sign(b) * Math.Sqrt(b * b - 4 * a * c));
        double x1 = temp / a;
        double x2 = c / temp;

        List<double> roots = [];
        if (double.IsFinite(x1))
        {
            roots.Add(x1);
        }
        if (double.IsFinite(x2))
        {
            roots.Add(x2);
        }

        return roots;
    }

    private static string? ReadLineStyled()
    {
        Console.Write("\x1b[32;3m");
        string? input = Console.ReadLine();
        Console.Write("\x1b[0m");

        return input;
    }

    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

        if (args.Length == 0)
        {
            Span<double> coef = stackalloc double[3];

            for (int i = 0; i < coef.Length; i++)
            {
                while (true)
                {
                    Console.Write($"{(char)('a' + i)} = ");
                    string? input = ReadLineStyled();

                    if (double.TryParse(input, out coef[i]))
                    {
                        break;
                    }
                    Console.WriteLine($"Error: '{input}' is not a valid real number.");
                }
            }

            Console.WriteLine($"Equation: ({coef[0]}) x^2 + ({coef[1]}) x + ({coef[2]}) = 0");

            List<double> roots = SolveQuadratic(coef[0], coef[1], coef[2]);
            Console.WriteLine(roots.Count == 1 ? $"There is 1 root" : $"There are {roots.Count} roots");
            for (int i = 0; i < roots.Count; i++)
            {
                Console.WriteLine($"x{i + 1} = {roots[i]}");
            }
        }
        else if (args.Length == 1)
        {
            // TODO: File mode
        }
        else
        {
            Console.WriteLine("Usage: mtsd-labs [file]");
        }
    }
}

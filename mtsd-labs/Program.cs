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

        Span<double> coef = stackalloc double[3];

        if (args.Length == 0)
        {
            for (int i = 0; i < coef.Length; i++)
            {
                while (true)
                {
                    Console.Write($"{(char)('a' + i)} = ");
                    string? input = ReadLineStyled();

                    if (double.TryParse(input, out coef[i]) && double.IsFinite(coef[i]))
                    {
                        break;
                    }
                    Console.WriteLine($"Error: '{input}' is not a valid real number.");
                }
            }
        }
        else if (args.Length == 1)
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Error: The file does not exist.");
                return;
            }

            List<string> lines = [.. File.ReadLines(args[0]).Take(2)];
            if (lines.Count != 1)
            {
                Console.WriteLine("Error: The file must contain exactly 1 line.");
                return;
            }

            string[] parts = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                Console.WriteLine("Error: The file must contain exactly 3 coefficients.");
                return;
            }

            for (int i = 0; i < coef.Length; i++)
            {
                if (!double.TryParse(parts[i], out coef[i]) || !double.IsFinite(coef[i]))
                {
                    Console.WriteLine($"Error: '{parts[i]}' is not a valid real number.");
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine("Usage: mtsd-labs [filepath]");
            return;
        }

        if (coef[0] == 0)
        {
            Console.WriteLine("Error: The coefficient 'a' must not be zero.");
            return;
        }

        Console.WriteLine($"Equation: ({coef[0]}) x^2 + ({coef[1]}) x + ({coef[2]}) = 0");

        List<double> roots = SolveQuadratic(coef[0], coef[1], coef[2]);

        Console.WriteLine(roots.Count == 1 ? $"There is 1 root" : $"There are {roots.Count} roots");
        for (int i = 0; i < roots.Count; i++)
        {
            Console.WriteLine($"x{i + 1} = {roots[i]}");
        }
    }
}

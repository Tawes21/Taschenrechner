using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Rechner2;

public class Program
{

    public static List<Basisclass> Rechenmethoden = new List<Basisclass>();

    static void Main()
    {

        FuelleRechenmethoden();


        char[] separators = new char[] { '+', ' ', '-', '/', '*' };
        char[] delimiters = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ' };

        string input;
        do
        {
            double Erg = 0;
            Console.WriteLine($"Rechenaufgabe eingeben (+,-,*,/)" +
                $"\nZum beenden des Rechners 'ende'\n");

            input = Console.ReadLine() ?? string.Empty;

            string[] Zahlen = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            char Operator = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)[0].ToCharArray()[0];

            double[] Zahl = new double[3];

            for (int i = 0; i < Zahlen.Length; i++)
            {
                double.TryParse(Zahlen[i], out double result);
                Zahl[i] = result;
            }

            Basisclass? operatoruse = Rechenmethoden.FirstOrDefault(x => x.Rechenzeichen == Operator);

            string Ergebnis = operatoruse!.Berechne(Zahl[0], Zahl[1]);

            Console.WriteLine(Ergebnis);




            //switch (Operator[0])
            //{
            //    case "+":
            //        Erg = Zahl[0] + Zahl[1];
            //        Console.WriteLine("Ergebnis: " + (Math.Round(Erg, 2)) + "\n");
            //        break;
            //    case "-":
            //        Erg = Zahl[0] - Zahl[1];
            //        Console.WriteLine("Ergebnis: " + (Math.Round(Erg, 2)) + "\n");
            //        break;
            //    case "*":
            //        Erg = Zahl[0] * Zahl[1];
            //        Console.WriteLine("Ergebnis: " + (Math.Round(Erg, 2)) + "\n");
            //        break;
            //    case "/":
            //        Erg = Zahl[0] / Zahl[1];
            //        Console.WriteLine("Ergebnis: " + (Math.Round(Erg, 2)) + "\n");
            //        break;
            //    default:
            //        Console.WriteLine("");
            //        break;
            //}

        } while (input != "ende");
    }
    private static void FuelleRechenmethoden()
    {
        Rechenmethoden.Add(new Addition());
        Rechenmethoden.Add(new Subtraktion());
        Rechenmethoden.Add(new Multiplikation());
        Rechenmethoden.Add(new Division());
    }
}


public class Basisclass
{
    public virtual char Rechenzeichen { get; set; }

    public virtual string Berechne(double a, double b)
    {
        return string.Empty;
    }
}

public class Addition : Basisclass
{
    public override char Rechenzeichen => '+';

    public override string Berechne(double a, double b)
    {
        return (a + b).ToString();
    }
}


public class Subtraktion : Basisclass
{
    public override char Rechenzeichen => '-';

    public override string Berechne(double a, double b)
    {
        return (a - b).ToString();
    }
}


public class Multiplikation : Basisclass
{
    public override char Rechenzeichen => '*';

    public override string Berechne(double a, double b)
    {
        return (a * b).ToString();
    }
}


public class Division : Basisclass
{
    public override char Rechenzeichen => '/';

    public override string Berechne(double a, double b)
    {
        return (a / b).ToString();
    }
}
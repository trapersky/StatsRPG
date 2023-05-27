// See https://aka.ms/new-console-template for more information
    AbilityScoreCalculator calculator = new AbilityScoreCalculator();
    while (true)
    {
        calculator.RollResult = ReadInt(calculator.RollResult, "Początkowy rzut 4k6");
        calculator.DivideBy = ReadDouble(calculator.DivideBy, "Dzielone przez");
        calculator.AddAmount = ReadInt(calculator.AddAmount, "Dodawana Wartość");
        calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
        calculator.CalculateAbilityScore();
        Console.WriteLine("Obliczone punkty cech: " + calculator.Score);
        Console.WriteLine("Wciśnij Q aby zakończyć działanie programu; dowolny inny klawisz, aby kontynuować");
        char KeyChar = Console.ReadKey(true).KeyChar;
        if ((KeyChar == 'Q') || (KeyChar == 'q')) return 0;
    }
    static int ReadInt(int LastUsedValue, string Prompt)
{
    Console.WriteLine(Prompt + " [" + LastUsedValue + "]: ");
    string Line = Console.ReadLine();
    if (int.TryParse(Line, out int Value))
    {
        Console.WriteLine("  użycie wartości " + Value);
        return Value;
    }
    else
    {
        Console.WriteLine("  użycie wartości domyślnej " + LastUsedValue);
        return LastUsedValue;
    }
}

static double ReadDouble(double LastUsedValue, string Prompt)
{
    Console.WriteLine(Prompt + " [" + LastUsedValue + "]: ");
    string Line = Console.ReadLine();
    if (double.TryParse(Line, out double Value))
    {
        Console.WriteLine("  użycie wartości " + Value);
        return Value;
    }
    else
    {
        Console.WriteLine("  użycie wartości domyślnej " + LastUsedValue);
        return LastUsedValue;
    }
}

class AbilityScoreCalculator
{
    public int RollResult = 14;
    public double DivideBy = 1.75;
    public int AddAmount = 2;
    public int Minimum = 3;
    public int Score;
    public void CalculateAbilityScore()
    {
        double Divided = RollResult / DivideBy;
        int Added = AddAmount + (int)Divided;

        if (Added < Minimum)
        {
            Score = Minimum;
        }
        else
        {
            Score = Added;
        }
    }
}
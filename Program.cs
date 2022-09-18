/*
Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; 
значения b1, k1, b2 и k2 задаются пользователем.
k1 = 5, b1 = 2, k2 = 9, b2 = 4 -> (-0,5; -0,5)
*/

decimal k1 = 0, b1 = 0, k2 = 0, b2 = 0;
decimal? x = 0, y = 0;

if (!InputControl("K1", "b1", ref k1, ref b1))
    return;

if (!InputControl("K2", "b2", ref k2, ref b2))
    return;

(x, y) = FindCrossPoint(k1, b1, k2, b2, out string result);

if (string.IsNullOrEmpty(result))
    result = $"({x}; {y})";

Console.WriteLine($"k1 = {k1}, b1 = {b1}, k2 = {k2}, b2 = {b2} -> {result} ");


# region methods
bool InputControl(string p0, string p1, ref decimal k, ref decimal b)
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resInputCheck = false;

    while (!resInputCheck)
    {
        Console.WriteLine($"\r\nЗадайте числовые коэффициенты {p0} и {p1} (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputKoeffs = inputStr.Split(new char[] { ' ', ';' });

        resInputCheck = inputKoeffs.Length == 2 && decimal.TryParse(inputKoeffs[0], out k) && decimal.TryParse(inputKoeffs[1], out b);

        if (!resInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

(decimal? x, decimal? y) FindCrossPoint(decimal k1, decimal b1, decimal k2, decimal b2, out string result)
{
    if ((k1 == k2) && (b1 == b2))
    {
        result = "прямые совпадают";
        return (null, null);
    }
    else
    if (k1 == k2)
    {
        result = "прямые параллельны";
        return (null, null);
    }
    else
    {
        x = (b2 - b1) / (k1 - k2);
        y = (k1 * (b2 - b1)) / (k1 - k2) + b1;
        result = string.Empty;
        return (x, y);
    }
}
#endregion
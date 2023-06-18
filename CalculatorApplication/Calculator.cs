namespace CalculatorApplication;

public class Calculator
{
    private string _str = String.Empty;
    
    private string InputNumbers()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Enter && key.KeyChar!=61)
            {
                _str += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            else break;
        }
        Console.WriteLine();
        return _str;
    }

    private bool CheckLine(string line)
    {
        foreach (var item in line)
        {
            if (!((item == '+' || item == '-' || item == '/' || item == '*') || char.IsDigit(item)))
            {
                return false;
            }
        }
        return true;
    }

    public void Start()
    {
        string str = InputNumbers();
        if (CheckLine(str))
        {
            Console.WriteLine(Calculate(str));
        }
    }

    private double Calculate(string line)
    {
        line = line.Replace(" ", "");
        System.Data.DataTable dataTable = new System.Data.DataTable();
        dataTable.Columns.Add("expression", typeof(string), line);
        System.Data.DataRow row = dataTable.NewRow();
        dataTable.Rows.Add(row);
        return double.Parse((string)row["expression"]);
    }
} 
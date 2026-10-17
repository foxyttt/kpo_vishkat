using kpo_vishkat.Models;
using kpo_vishkat.Services;
using System.Globalization;
using kpo_vishkat.Services.Implementations;

namespace kpo_vishkat.ConsoleUI;

public class ConsoleApplication
{
    private readonly ParkReplenishment _parkReplenishment;
    private readonly IEnumerable<iReportService> _reports;

    public ConsoleApplication(ParkReplenishment parkReplenishment, IEnumerable<iReportService> reports)
    {
        _parkReplenishment = parkReplenishment;
        _reports = reports;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== ВышКат ===");
            Console.WriteLine("1. Добавить велосипед");
            Console.WriteLine("2. Добавить электровелосипед");
            Console.WriteLine("3. Добавить самокат");
            Console.WriteLine("4. Добавить электросамокат");
            Console.WriteLine("5. Добавить шлем");
            Console.WriteLine("6. Добавить ДОК-станцию");
            Console.WriteLine("7. Добавить зарядную станцию");
            Console.WriteLine("8. Отчёты");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddBicycle();
                    break;
                case "2":
                    AddElectroBicycle();
                    break;
                case "3":
                    AddScooter();
                    break;
                case "4":
                    AddElectroScooter();
                    break;
                case "5":
                    AddHelmet();
                    break;
                case "6":
                    AddDocStation();
                    break;
                case "7":
                    AddChargingStation();
                    break;
                case "8":
                    ShowReports();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }

    private void AddBicycle()
    {
        string number = ReadRequired("Инвентарный номер: ");
        string name = ReadRequired("Название: ");
        int simplicity = ReadInt("Простота для новичка (1–10): ", 1, 10);

        var bicycle = new Bicycle(number, name, simplicity);
        AddTransport(bicycle);
    }

    private void AddScooter()
    {
        string number = ReadRequired("Инвентарный номер: ");
        string name = ReadRequired("Название: ");
        int simplicity = ReadInt("Простота для новичка (1–10): ", 1, 10);

        var scooter = new Scooter(number, name, simplicity);

        AddTransport(scooter);
    }

    private void AddElectroScooter()
    {
        string number = ReadRequired("Инвентарный номер: ");
        string name = ReadRequired("Название: ");
        int simplicity = ReadInt("Простота для новичка (1–10): ", 1, 10);
        double energy = ReadDouble("Суточное энергопотребление (кВт·ч): ");

        var electroScooter = new ElectroScooter(number, name, energy, simplicity);

        AddTransport(electroScooter);
    }

    private void AddElectroBicycle()
    {
        string number = ReadRequired("Инвентарный номер: ");
        string name = ReadRequired("Название: ");
        int simplicity = ReadInt("Простота для новичка (1–10): ", 1, 10);
        double energy = ReadDouble("Суточное энергопотребление (кВт·ч): ");

        var electroBicycle = new ElectroScooter(number, name, energy, simplicity);

        AddTransport(electroBicycle);
    }

    private void AddHelmet()
    {
        string number = ReadRequired("Инвентарный номер: ");
        string name = ReadRequired("Название: ");

        try
        {
            _parkReplenishment.AddItem(new Helmet(number, name));
            Console.WriteLine("Вещь добавлена на баланс.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Не удалось добавить вещь: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Некорректные данные: {ex.Message}");
        }
    }

    private void AddDocStation()
    {
        string number = ReadRequired("Инвентарный номер: ");
        string name = ReadRequired("Название: ");
        double energy = ReadDouble("Суточное энергопотребление (кВт·ч): ");

        try
        {
            _parkReplenishment.AddItem(new DocStation(number, name, energy));
            Console.WriteLine("Вещь добавлена на баланс.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Не удалось добавить вещь: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Некорректные данные: {ex.Message}");
        }
    }

    private void AddChargingStation()
    {
        string number = ReadRequired("Инвентарный номер: ");
        string name = ReadRequired("Название: ");
        double energy = ReadDouble("Суточное энергопотребление (кВт·ч): ");

        try
        {
            _parkReplenishment.AddItem(new ChargingStation(number, name, energy));
            Console.WriteLine("Вещь добавлена на баланс.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Не удалось добавить вещь: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Некорректные данные: {ex.Message}");
        }
    }

    private void AddTransport(iTransport transport)
    {
        try
        {
            bool accepted = _parkReplenishment.TryAddTransport(transport);

            Console.WriteLine(accepted ? "Транспорт прошёл техосмотр и принят в парк." : "Транспорт не прошёл техосмотр.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Не удалось добавить транспорт: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Некорректные данные: {ex.Message}");
        }
    }

    private void ShowReports()
    {
        var reports = _reports.ToList();

        while (true)
        {
            Console.WriteLine("\n=== Отчёты ===");

            for (int i = 0; i < reports.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reports[i].Name}");
            }

            Console.WriteLine("0. Назад");
            Console.Write("Выберите отчёт: ");

            string? input = Console.ReadLine();

            if (input == "0") 
            {
                return;
            }

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= reports.Count)
            {
                Console.WriteLine();
                Console.WriteLine(reports[choice - 1].generate());
            }
            else
            {
                Console.WriteLine("Некорректный номер отчёта.");
            }
        }
    }

    private static string ReadRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Trim();
            }

            Console.WriteLine("Поле не должно быть пустым.");
        }
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Введите целое число от {min} до {max}.");
        }
    }

    private static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim().Replace(',', '.');

            if (double.TryParse(input, System.Globalization.NumberStyles.AllowDecimalPoint, 
                System.Globalization.CultureInfo.InvariantCulture, out double value) && double.IsFinite(value) &&
                value >= 0)
            {
                return value;
            }

            Console.WriteLine("Введите неотрицательное число, например 1.5.");
        }
    }
}
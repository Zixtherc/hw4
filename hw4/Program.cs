class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        var teams = new List<Team>();

        while (true)
        {
            Console.WriteLine("1 - Нова команда");
            Console.WriteLine("2 - Додати співробітника");
            Console.WriteLine("3 - Коротка інформація");
            Console.WriteLine("4 - Детальна інформація");
            Console.WriteLine("0 - Вихід");
            Console.Write("Вибір: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Назва команди: ");
                    teams.Add(new Team(Console.ReadLine() ?? ""));
                    break;

                case "2":
                    AddWorkerToTeam(teams);
                    break;

                case "3":
                    foreach (var t in teams) Console.WriteLine(t.GetInfo() + "\n");
                    break;

                case "4":
                    foreach (var t in teams) Console.WriteLine(t.GetFullInfo() + "\n");
                    break;

                case "0":
                    return;
            }
        }
    }

    static void AddWorkerToTeam(List<Team> teams)
    {
        if (teams.Count == 0)
        {
            Console.WriteLine("Спочатку створіть команду");
            return;
        }

        for (int i = 0; i < teams.Count; i++)
            Console.WriteLine($"{i + 1}. {teams[i].Title}");

        Console.Write("Номер команди: ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > teams.Count)
        {
            Console.WriteLine("Невірний номер");
            return;
        }

        Console.Write("ПІБ: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Посада (1 - розробник, 2 - менеджер): ");
        Worker w = Console.ReadLine() == "1" ? new Developer(name) : new Manager(name);

        w.FillWorkDay();
        teams[idx - 1].AddWorker(w);
    }
}
class Team
{
    public string Title { get; }
    private readonly List<Worker> _workers = new();

    public Team(string title) => Title = title;

    public void AddWorker(Worker w) => _workers.Add(w);

    public string GetInfo() =>
        Title + "\n" + string.Join("\n", _workers.Select(w => w.Name));

    public string GetFullInfo() =>
        Title + "\n" + string.Join("\n",
            _workers.Select(w => $"{w.Name} - {w.Position} - {w.WorkDay.Trim()}"));
}
abstract class Worker
{
    public string Name { get; }
    public string Position { get; protected set; } = "";
    public string WorkDay { get; private set; } = "";

    protected Worker(string name) => Name = name;

    public void Call() => WorkDay += "Call ";
    public void WriteCode() => WorkDay += "WriteCode ";
    public void Relax() => WorkDay += "Relax ";

    public abstract void FillWorkDay();
}
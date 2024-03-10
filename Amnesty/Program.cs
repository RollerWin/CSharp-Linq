class Program
{
    static void Main(string[] args)
    {
        Database database = new Database();
        database.ShowPrisoners();
        Console.WriteLine();
        database.AmnestyPrisoners(Crime.Антиправительственное);
        database.ShowPrisoners();
    }
}

enum Crime
{
    Антиправительственное,
    Кража,
    Угон,
    Мошенничество,
    Наркотики
}

class Prisoner
{
    public Prisoner(string fullName, Crime crime)
    {
        FullName = fullName;
        Crime = crime;
    }

    public string FullName {get; private set;}
    public Crime Crime {get; private set;}

    public void ShowInfo() => Console.WriteLine($"ФИО: {FullName}. Преступление: {Crime}");
}

class Database
{
    private List<Prisoner> _prisoners;

    public Database()
    {
        _prisoners = new List<Prisoner>();
        AddPrisoners();
    }

    public void AmnestyPrisoners(Crime crime)
    {
        var freePrisoners = _prisoners.Where(prisoner => prisoner.Crime == crime);
        _prisoners = _prisoners.Except(freePrisoners).ToList();
    }

    public void ShowPrisoners()
    {
        foreach(var prisoner in _prisoners)
            prisoner.ShowInfo();
    }

    private void AddPrisoners()
    {
        _prisoners.Add(new Prisoner("Иван Иванов", Crime.Антиправительственное));
        _prisoners.Add(new Prisoner("Петр Петров", Crime.Кража));
        _prisoners.Add(new Prisoner("Алексей Смирнов", Crime.Антиправительственное));
        _prisoners.Add(new Prisoner("Елена Васильева", Crime.Мошенничество));
        _prisoners.Add(new Prisoner("Мария Иванова", Crime.Антиправительственное));
        _prisoners.Add(new Prisoner("Дмитрий Козлов", Crime.Наркотики));
        _prisoners.Add(new Prisoner("Ольга Николаева", Crime.Антиправительственное));
        _prisoners.Add(new Prisoner("Андрей Попов", Crime.Угон));
    }
}
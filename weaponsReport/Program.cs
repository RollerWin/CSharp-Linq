class Program
{
    static void Main(string[] args)
    {
        Database database = new Database();
        database.ShowSoldiers();
        Console.WriteLine();
        database.ShowSoldiersNameAndRank();
    }
}

class Soldier
{
    public Soldier(string name, string weapon, string rank, int serviceLife)
    {
        Name = name;
        Weapon = weapon;
        Rank = rank;
        ServiceLife = serviceLife;
    }

    public string Name {get; private set;}
    public string Weapon {get; private set;}
    public string Rank {get; private set;}
    public int ServiceLife {get; private set;}

    public void ShowInfo() => Console.WriteLine($"Имя: {Name}. Вооружение: {Weapon}. Звание: {Rank}. Срок службы: {ServiceLife} месяцев.");
}

class Database
{
    private List<Soldier> _soldiers;

    public Database()
    {
        _soldiers = new List<Soldier>();
        AddSoldiers();
    }

    public void ShowSoldiers()
    {
        foreach(var soldier in _soldiers)
            soldier.ShowInfo();
    }

    public void ShowSoldiersNameAndRank()
    {
        var selectedSoldiers = _soldiers.Select(soldier => new {soldier.Name, soldier.Rank});

        foreach(var soldier in selectedSoldiers)
            Console.WriteLine($"Имя: {soldier.Name}. Звание: {soldier.Rank}");
    }

    private void AddSoldiers()
    {
        _soldiers.Add(new Soldier("James", "M4", "Private", 2));
        _soldiers.Add(new Soldier("John", "AK-47", "Sergeant", 5));
        _soldiers.Add(new Soldier("Robert", "M16", "Corporal", 3));
        _soldiers.Add(new Soldier("Michael", "MP5", "Private", 1));
        _soldiers.Add(new Soldier("William", "SCAR", "Sergeant", 4));
        _soldiers.Add(new Soldier("David", "G36", "Corporal", 2));
        _soldiers.Add(new Soldier("Richard", "AUG", "Private", 2));
        _soldiers.Add(new Soldier("Joseph", "FAMAS", "Sergeant", 3));
        _soldiers.Add(new Soldier("Thomas", "UMP45", "Corporal", 1));
        _soldiers.Add(new Soldier("Charles", "P90", "Private", 4));
    }
}
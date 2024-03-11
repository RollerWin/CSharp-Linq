class Program
{
    static void Main(string[] args)
    {
        int currentYear = DateTime.Now.Year;

        Database database = new Database();
        database.FindExpiredCans(currentYear);
    }
}

class StewMeat
{
    public StewMeat(string name, int yearOfProduction, int expirationDate)
    {
        Name = name;
        YearOfProduction = yearOfProduction;
        ExpirationDate = expirationDate;
    }

    public string Name {get; private set;}
    public int YearOfProduction {get; private set;}
    public int ExpirationDate {get; private set;}

    public void ShowInfo() => Console.WriteLine($"Название: {Name}. Год производства: {YearOfProduction}. Срок годности: {ExpirationDate}");
}

class Database
{
    private List<StewMeat> _cannedFoods;

    public Database()
    {
        _cannedFoods = new List<StewMeat>();
        AddCans();
    }

    public void FindExpiredCans(int currentYear)
    {
        var expiredCans = _cannedFoods.Where(stewMeat => stewMeat.YearOfProduction + stewMeat.ExpirationDate < currentYear);

        foreach(var can in expiredCans)
            can.ShowInfo();
    }

    private void AddCans()
    {
        _cannedFoods.Add(new StewMeat("Кавказская", 1980, 40));
        _cannedFoods.Add(new StewMeat("Столичная", 1993, 30));
        _cannedFoods.Add(new StewMeat("Казанская", 1960, 60));
        _cannedFoods.Add(new StewMeat("Сибирская", 2000, 24));
    }
}
class Program
{
    static void Main(string[] args)
    {
        Squad squad1 = new Squad
        (
            new List<Soldier> 
            {
                new Soldier("Борис"),
                new Soldier("Булат"),
                new Soldier("Виталий"),
                new Soldier("Александр")
            }
        );

        Squad squad2 = new Squad
        (
            new List<Soldier>
            {
                new Soldier("Аретемий"),
                new Soldier("Антон"),
                new Soldier("Михаил")
            }
        );

        squad1.ShowSquad();
        squad2.ShowSquad();
        
        Console.WriteLine();
        squad2.AddSoldiers(squad1.RemoveSoldiers());

        squad1.ShowSquad();
        squad2.ShowSquad();
    }
}

class Soldier
{
    public Soldier(string name) => Name = name;

    public string Name{get; private set;}
}

class Squad
{
    private List<Soldier> _soldiers;

    public Squad(List<Soldier> soldiers) => _soldiers = soldiers;

    public List<Soldier> RemoveSoldiers()
    {
        var removedSoldiers = _soldiers.Where(soldier => soldier.Name.StartsWith("Б")).ToList();
        _soldiers = _soldiers.Except(removedSoldiers).ToList();

        return removedSoldiers;
    } 

    public void AddSoldiers(List<Soldier> newSoldiers) => _soldiers = _soldiers.Concat(newSoldiers).ToList();

    public void ShowSquad()
    {
        Console.WriteLine("Солдаты в отряде:");

        foreach(var soldier in _soldiers)
            Console.WriteLine($"Имя: {soldier.Name}");
    }
}
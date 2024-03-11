class Program
{
    static void Main(string[] args)
    {
        Database database = new Database();
        database.ShowTopPlayers(player => player.Level);
        Console.WriteLine();
        database.ShowTopPlayers(player => player.Strength);
    }
}

class Player
{
    public Player(string name, int level, int strength)
    {
        Name = name;
        Level = level;
        Strength = strength;
    }

    public string Name {get; private set;}
    public int Level {get; private set;}
    public int Strength {get; private set;}

    public void ShowInfo() => Console.WriteLine($"Имя: {Name}. Уровень: {Level}. Сила: {Strength}");
}

class Database
{
    private List<Player> _players;

    public Database()
    {
        _players = new List<Player>();
        AddPlayers();
    }

    public void ShowTopPlayers(Func<Player, int> orderBySelector)
    {
        int numberOfTakenPlayers = 3;
        var topPlayers = _players.OrderByDescending(orderBySelector).Take(numberOfTakenPlayers);

        foreach(var player in topPlayers)
            player.ShowInfo();
    }

    private void AddPlayers()
    {
        _players.Add(new Player("Stan", 40, 50));
        _players.Add(new Player("Alice", 20, 60));
        _players.Add(new Player("Bob", 80, 30));
        _players.Add(new Player("Eve", 10, 90));
        _players.Add(new Player("Charlie", 70, 40));
        _players.Add(new Player("Liam", 30, 80));
        _players.Add(new Player("Olivia", 50, 45));
        _players.Add(new Player("Noah", 60, 35));
        _players.Add(new Player("Emma", 25, 75));
        _players.Add(new Player("Lucas", 90, 20));
    }
}
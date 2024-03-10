class Program
{
    static void Main(string[] agrs)
    {
        int maxHeight = 300;
        int maxWeight = 220;
        int criminalHeight = UserUtils.ReadCorrectValue("Введите рост:", maxHeight);
        int criminalWeight = UserUtils.ReadCorrectValue("Введите вес: ", maxWeight);

        Console.Write("Введите национальность: ");
        string criminalNationality = Console.ReadLine();

        Database database = new Database();
        database.ShowFilteredCriminals(criminalHeight, criminalWeight, criminalNationality);
    }
}

class Criminal
{
    public Criminal(string fullName, bool isInCustody, int height, int weight, string nationality)
    {
        FullName = fullName;
        IsInCustody = isInCustody;
        Height = height;
        Weight = weight;
        Nationality = nationality;
    }

    public string FullName {get; private set;}
    public bool IsInCustody {get; private set;}
    public int Height {get; private set;}
    public int Weight {get; private set;}
    public string Nationality {get; private set;}

    public void ShowInfo() => Console.WriteLine($"ФИО: {FullName}. Под стражей: {IsInCustody}. Рост: {Height}. Вест: {Weight}. Национальность: {Nationality}");
}

class Database
{
    private List<Criminal> _criminals;

    public Database()
    {
        _criminals = new List<Criminal>();
        AddCriminals();
    }

    public void ShowFilteredCriminals(int height, int weight, string nationality)
    {
        var filteredCriminals = _criminals.Where(criminal => (criminal.Height == height || criminal.Weight == weight || criminal.Nationality == nationality) && criminal.IsInCustody == false).Select(criminal => criminal);
    
        foreach(var criminal in filteredCriminals)
            criminal.ShowInfo();
    }

    private void AddCriminals()
    {
        _criminals.Add(new Criminal("John Doe", true, 180, 75, "American"));
        _criminals.Add(new Criminal("Jane Smith", false, 165, 60, "British"));
        _criminals.Add(new Criminal("Иван Иванов", true, 175, 80, "Russian"));
        _criminals.Add(new Criminal("Maria Garcia", true, 170, 65, "Spanish"));
        _criminals.Add(new Criminal("Michael Johnson", true, 185, 90, "Canadian"));
        _criminals.Add(new Criminal("Elena Petrova", false, 170, 55, "Russian"));
        _criminals.Add(new Criminal("Mohammed Ali", true, 175, 70, "Saudi Arabian"));
        _criminals.Add(new Criminal("Sophie Martin", false, 160, 50, "French"));
    }
}

static class UserUtils
{
    static public int ReadCorrectValue(string prompt, int limit)
    {
        int correctValue = 0;
        bool isCorrect = false;

        while (isCorrect == false)
        {
            Console.WriteLine(prompt);

            if (int.TryParse(Console.ReadLine(), out correctValue) && correctValue > 0 && correctValue <= limit)
                isCorrect = true;
            else
                Console.WriteLine("Некорректный ввод! Попробуйте ещё раз\n");
        }

        return correctValue;
    }
}
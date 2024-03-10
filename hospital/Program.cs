class Program
{
    static void Main(string[] args)
    {
        Hospital hospital = new Hospital();
        hospital.StartWork();
    }
}

enum Disease
{
    Мигрень,
    Коронавирус,
    Грипп,
    Перелом
}

class Patient
{
    public Patient(string fullName, int age, Disease disease)
    {
        FullName = fullName;
        Age = age;
        Disease = disease;
    }

    public string FullName {get; private set;}
    public int Age {get; private set;}
    public Disease Disease {get; private set;}

    public void ShowInfo() => Console.WriteLine($"ФИО: {FullName}. Возраст: {Age}. Заболевание: {Disease}");
}

class Database
{
    private List<Patient> _patients;

    public Database()
    {
        _patients = new List<Patient>();
        AddPatients();
    }

    private void AddPatients()
    {
        _patients.Add(new Patient("Иванов Иван", 35, Disease.Мигрень));
        _patients.Add(new Patient("Петров Петр", 45, Disease.Коронавирус));
        _patients.Add(new Patient("Сидоров Сидор", 25, Disease.Грипп));
        _patients.Add(new Patient("Алексеев Алексей", 50, Disease.Перелом));
        _patients.Add(new Patient("Никитин Никита", 30, Disease.Мигрень));
        _patients.Add(new Patient("Андреев Андрей", 40, Disease.Коронавирус));
        _patients.Add(new Patient("Михайлов Михаил", 55, Disease.Грипп));
        _patients.Add(new Patient("Александров Александр", 28, Disease.Перелом));
        _patients.Add(new Patient("Дмитриев Дмитрий", 42, Disease.Мигрень));
        _patients.Add(new Patient("Степанов Степан", 38, Disease.Коронавирус));
    }

    public void FilterByDisease(Disease disease)
    {
        var filteredPatients = _patients.Where(patient => patient.Disease == disease);

        foreach(var patient in filteredPatients)
            patient.ShowInfo();
    }

    public void SortByFullName()
    {
        _patients = _patients.OrderBy(patient => patient.FullName).ToList();
        ShowPatients();
    }

    public void SortByAge()
    {
        _patients = _patients.OrderBy(patient => patient.Age).ToList();
        ShowPatients();
    }

    public void ShowPatients()
    {
        foreach(var patient in _patients)
            patient.ShowInfo();
    }
}

class Hospital
{
    private const string SortByFullName ="sort fio";
    private const string SortByAge = "sort age";
    private const string FilterByDisease = "filter";
    private const string Exit = "exit";

    private Database _database;

    public Hospital() => _database = new Database();

    public void StartWork()
    {
        bool isRun = true;

        while(isRun)
        {
            ShowMenu();

            Console.Write("Выберите команду: ");
            
            switch(Console.ReadLine())
            {
                case SortByFullName:
                    _database.SortByFullName();
                break;

                case SortByAge:
                    _database.SortByAge();
                break;

                case FilterByDisease:
                    FilterPatients();
                break;

                case Exit:
                    isRun = false;
                break;

                default:
                    Console.WriteLine("Некорректный ввод!");
                break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    private void FilterPatients()
    {
        Console.WriteLine("Выберите болезнь для фильтрации:");

        foreach (Disease disease in Enum.GetValues(typeof(Disease)))
            Console.WriteLine($"{(int)disease}. {disease}");

        Console.Write("Введите название болезни: ");

        string userInput = Console.ReadLine();
        
        if (Enum.TryParse(userInput, out Disease selectedDisease))
            _database.FilterByDisease(selectedDisease);
        else
            Console.WriteLine("Некорректный ввод!");
    }

    private void ShowMenu() => Console.WriteLine
    (
        $"{SortByFullName} - сортировка по возрастанию по фио\n" +
        $"{SortByAge} - сортировка по возрастанию по возрасту\n" +
        $"{FilterByDisease} - фильтрация по болезни\n" +
        $"{Exit} - выход\n"
    );
}
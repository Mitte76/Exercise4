using Exercise4.Models;

namespace Exercise4
{
    internal class Program
    {
        private const int MainMenuItems = 4;

        static void Main(string[] args)
        {

            bool exitProgram = false;
            int currentItem = 0;
            while (!exitProgram)
            {
                ShowMainMenu(currentItem);

                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.DownArrow:
                        currentItem++;
                        if (currentItem >= MainMenuItems)
                            currentItem = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        currentItem--;
                        if (currentItem < 0)
                            currentItem = MainMenuItems - 1;
                        break;
                    case ConsoleKey.Enter:
                        if (currentItem == MainMenuItems - 1)
                        {
                            exitProgram = true;
                            break;
                        }
                        OpenItem((currentItem + 1) % MainMenuItems);
                        break;
                    case ConsoleKey.D0:
                        exitProgram = true;
                        break;
                    case ConsoleKey.D1:
                        OpenItem(1);
                        break;
                    case ConsoleKey.D2:
                        OpenItem(2);
                        break;
                    case ConsoleKey.D3:
                        OpenItem(3);
                        break;
                    default:
                        Console.WriteLine("Incorrect input, please try again\n");
                        break;
                }

                currentItem %= MainMenuItems;
            }
        }

        static void ShowMainMenu(int currentItem)
        {
            Console.Clear();
            Console.WriteLine("MainMenu: Exersice 4");
            Console.WriteLine("----------");

            string[] items =
            [
                "Part 1: Sort by name and age",
                "Part 2: Give pay rise",
                "Part 3: Give pay rise with name and minimum wage validation",
                "Avsluta",
            ];

            for (int i = 0; i < items.Length; i++)
            {
                bool selected = i == currentItem;
                int menuNumber = (i + 1) % items.Length;
                PrintMenuItem(menuNumber, items[i], selected);
            }
        }

        static void OpenItem(int itemNumber)
        {
            switch (itemNumber)
            {
                case 1:
                    SortByFirstNameAndAge();
                    break;
                case 2:
                    CalculateSalary();
                    break;
                case 3:
                    CalculateSalaryWithValidation();
                    break;

            }

        }

        static void PrintMenuItem(int number, string text, bool selected)
        {
            Console.Write($"{number}.[");

            Console.ForegroundColor = selected
                ? ConsoleColor.Green
                : ConsoleColor.DarkGray;

            Console.Write(selected ? "#" : " ");

            Console.ResetColor();
            Console.WriteLine($"] {text}");
        }

        static void SortByFirstNameAndAge()
        {

            Console.WriteLine("Please supply a list of employees:");
            Console.WriteLine("All rows should contain: \"FirstName\" \"LastName\" \"Age\"");

            var employees = new List<Person>();

            string[] input = Console.In.ReadToEnd()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            int lines = input.Length;

            for (int i = 0; i < lines; i++)
            {
                string[] parts = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);


                if (parts.Length < 3 || !int.TryParse(parts[2], out int age))
                {
                    continue; // Hoppa över raden
                }

                employees.Add(new Person(parts[0], parts[1], age));


            }

            employees.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));

            PressAnyKey();
        }

        static void CalculateSalary()
        {
            Console.WriteLine("Please supply a list of Employes:");
            Console.WriteLine("Every row should contain: \"FirstName\" \"LastName\" \"Age\" \"Salary\"");
            Console.WriteLine("The last line should contain an int which is the pay increase in %");

            var employees = new List<Person>();

            string[] input = Console.In.ReadToEnd()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            decimal bonusMultiplier = decimal.TryParse(input[^1], out bonusMultiplier) ? bonusMultiplier / 100 : 0;

            Console.WriteLine("bonus: " + bonusMultiplier);

            for (int i = 0; i < input.Length - 1; i++)
            {
                string[] parts = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4 || !int.TryParse(parts[2], out int age) || !decimal.TryParse(parts[3].Replace(".", ","), out decimal salary))
                {
                    continue;
                }
                string firstName = parts[0];
                string lastName = parts[1];

                PersonWithSalary employee = new(firstName, lastName, age, salary);
                if (bonusMultiplier != 0)
                {
                    employee.IncreaseSalary(bonusMultiplier);
                }
                employees.Add(employee);

            }

            employees.ForEach(e => Console.WriteLine(e.ToString()));

            PressAnyKey();
        }
        static void CalculateSalaryWithValidation()
        {
            Console.WriteLine("Please supply a list of Employes:");
            Console.WriteLine("Every row should contain: \"FirstName\" \"LastName\" \"Age\" \"Salary\"");
            Console.WriteLine("The last line should contain an int which is the pay increase in %");


            var employees = new List<Person>();

            string[] input = Console.In.ReadToEnd()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            decimal bonusMultiplier = decimal.TryParse(input[^1], out bonusMultiplier) ? bonusMultiplier / 100 : 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] parts = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4 || !int.TryParse(parts[2], out int age) || !decimal.TryParse(parts[3].Replace(".", ","), out decimal salary))
                {
                    continue;
                }
                string firstName = parts[0];
                string lastName = parts[1];

                try
                {
                    ValidatedPersonWithSalary employee = new(firstName, lastName, age, salary);
                    if (bonusMultiplier != 0)
                    {
                        employee.IncreaseSalary(bonusMultiplier);
                    }
                    employees.Add(employee);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }

            }

            employees.ForEach(e => Console.WriteLine(e.ToString()));

            PressAnyKey();
        }

        static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
        }

    }

}
//Ida Svensson 65 2200
//Berit Dahl 57 3333
//Bert Lewinsson 27 600
//Anna Hamren 44 666,66
//Jacob Andersson 35 300
//20
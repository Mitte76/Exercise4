namespace Exercise4.Models
{
    public class PersonWithSalary(string firstName, string lastName, int age, decimal salary) : Person(firstName, lastName, age)
    {

        public decimal Salary
        {
            get;
            private set
            {
                field = value;
            }
        } = salary;

        public void IncreaseSalary(decimal bonus)
        {
            Salary *= 1 + (Age >= 30 ? bonus : bonus * 0.5m);

        }

        public override string? ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} dollars. ";
        }
    }
}
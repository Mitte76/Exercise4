namespace Exercise4.Models
{
    public class ValidatedPersonWithSalary(
string firstName, string lastName, int age, decimal salary) : PersonWithSalary(
    ValidateName(firstName, "First name"),
    ValidateName(lastName, "Last name"),
    ValidateAge(age),
    ValidateSalary(salary))
    {

        private static decimal ValidateSalary(decimal salary)
        {
            if (salary < 460)
            {
                throw new ArgumentException($"Salary cannot be less than 460 dollars!");
            }

            return salary;
        }
        private static string ValidateName(string name, string field)
        {
            if (name.Length < 3)
                throw new ArgumentException(
                    $"{field} cannot contain fewer than 3 symbols!");

            return name;
        }
        private static int ValidateAge(int age)
        {
            if (age <= 0)
                throw new ArgumentException(
                    "Age cannot be zero or a negative integer!");

            return age;
        }

        public override string? ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} dollars. ";
        }
    }
}
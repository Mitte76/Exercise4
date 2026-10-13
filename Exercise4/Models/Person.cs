namespace Exercise4.Models
{
    public class Person(string firstName, string lastName, int age)
    {
        public int Age
        { get; } = age;

        public string FirstName
        {
            get;
        } = firstName;

        public string LastName
        {
            get;

        } = lastName;

        public override string? ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old ";
        }
    }

}

namespace Domain.Utilities
{
    public class Name
    {
        private readonly string? name;
        private readonly string? lastName;


        public Name(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        public string FullName()
        {
            return name + " " + lastName;
        }
    }
}

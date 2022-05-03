using System.Diagnostics.Contracts;

namespace Domain.Utilities
{
    public class Name
    {
        private string name;
        private string lastName;


        public Name(string name, string lastName)
        {
            Contract.Requires(name != null && lastName != null);
            this.name = name;
            this.lastName = lastName;
        }

        public string fullName()
        {
            return name + " " + lastName;
        }
    }
}

using Domain.Utilities;
using System.Transactions;

namespace Domain.Logic
{
    public class User
    {
        public Employee _employee { get; set; }
        private Position position;
        public List<Transaction> catalogue;

        public User() { }
        public User(Employee employee)
        {
            _employee = employee;   
        }

        private bool validAge(int age)
        {
            return age > 17 && age < 100;
        }
    }
}

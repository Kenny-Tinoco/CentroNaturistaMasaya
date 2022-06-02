namespace Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string userName { get; }

        public UserNotFoundException(string _userName)
        {
            userName = _userName;
        }

        public UserNotFoundException(string message, string _userName) : base(message)
        {
            userName = _userName;
        }

        public UserNotFoundException(string message, Exception innerException, string _userName) : base(message, innerException)
        {
            userName = _userName;
        }
    }
}

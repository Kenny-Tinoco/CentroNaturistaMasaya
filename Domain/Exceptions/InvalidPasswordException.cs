namespace Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string userName { get; }
        public string password { get; }

        public InvalidPasswordException(string _userName, string _password)
        {
            userName = _userName;
            password = _password;
        }

        public InvalidPasswordException(string message, string _userName, string _password) : base(message)
        {
            userName = _userName;
            password = _password;
        }
        
        public InvalidPasswordException(string message, Exception innerException, string _userName, string _password) : base(message, innerException)
        {
            userName = _userName;
            password = _password;
        }
    }
}

namespace StoreAPI.Domain.Exceptions
{
    public class UniqueException : Exception
    {
        public UniqueException(string message) : base(message) { }
    }
}

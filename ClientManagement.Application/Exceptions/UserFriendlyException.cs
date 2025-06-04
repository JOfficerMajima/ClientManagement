namespace ClientManagement.Application.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public string ErrorCode { get; }

        public Dictionary<string, object> AdditionalData { get; private set; }

        public UserFriendlyException(string message)
            : base(message)
        {

        }

        public UserFriendlyException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public UserFriendlyException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public UserFriendlyException(string message, string errorCode, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        public UserFriendlyException WithData(string key, object value)
        {
            AdditionalData ??= new Dictionary<string, object>();
            AdditionalData[key] = value;
            return this;
        }

        public Dictionary<string, object> GetAdditionalData()
        {
            return AdditionalData ?? new Dictionary<string, object>();
        }
    }
}

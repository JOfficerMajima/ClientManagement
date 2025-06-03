namespace ClientManagement.Application.Exceptions
{
    public class UserFriendlyException : Exception
    {
        /// <summary>
        /// Код ошибки для машинной обработки
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Дополнительные данные об ошибке
        /// </summary>
        public Dictionary<string, object> AdditionalData { get; private set; }

        /// <summary>
        /// Создает новое исключение с понятным сообщением
        /// </summary>
        public UserFriendlyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Создает новое исключение с понятным сообщением и кодом ошибки
        /// </summary>
        public UserFriendlyException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Создает новое исключение с понятным сообщением и внутренним исключением
        /// </summary>
        public UserFriendlyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Создает новое исключение с понятным сообщением, кодом ошибки и внутренним исключением
        /// </summary>
        public UserFriendlyException(string message, string errorCode, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Добавляет дополнительные данные об ошибке
        /// </summary>
        public UserFriendlyException WithData(string key, object value)
        {
            AdditionalData ??= new Dictionary<string, object>();
            AdditionalData[key] = value;
            return this;
        }

        /// <summary>
        /// Возвращает дополнительные данные об ошибке (гарантированно не null)
        /// </summary>
        public Dictionary<string, object> GetAdditionalData()
        {
            return AdditionalData ?? new Dictionary<string, object>();
        }
    }
}

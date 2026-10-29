using System;

namespace SmartKitchen
{
    // === ВЕРСІЯ 3: ВИКЛЮЧНІ СИТУАЦІЇ (Exceptions) ===
    public class SmartKitchenException : Exception
    {
        // 1. Закрите приватне поле (Backing Field)
        private string _errorType;

        // 2. Класичний аксесор
        public string ErrorType
        {
            get
            {
                return _errorType;
            }
            set
            {
                _errorType = value;
            }
        }

        // 3. Конструктор (передає message базовому класу Exception через : base)
        public SmartKitchenException(string message, string errorType) : base(message)
        {
            ErrorType = errorType;
        }
    }
}
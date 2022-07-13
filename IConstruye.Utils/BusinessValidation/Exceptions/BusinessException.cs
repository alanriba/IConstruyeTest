using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace IConstruye.Utils.BusinessValidation.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class BusinessException : Exception
    {
        private class BusinessExceptionInternal
        {
            public string Message { get; }
            public object Obj { get; }

            public BusinessExceptionInternal(object obj, string message)
            {
                this.Obj = obj;
                this.Message = message;
            }

        }
        public int BusinessExceptionId { get; }

        public BusinessException()
        {

        }

        public BusinessException(object obj, string message, int businessExceptionId)
            : base(JsonSerializer.Serialize(new BusinessExceptionInternal(obj, message)))
        {
            this.BusinessExceptionId = businessExceptionId;
        }
    }
}

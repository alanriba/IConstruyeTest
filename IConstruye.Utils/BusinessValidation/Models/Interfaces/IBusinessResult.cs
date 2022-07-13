namespace IConstruye.Utils.BusinessValidation.Models.Interfaces
{
    public interface IBusinessResult<T>
    {
        bool IsValid();
        bool HasValue();
        void AddError(string errorMessage, int? errorTypeId = null);
        void AddErrors(IEnumerable<string> errorMessages);
        void AddErrors(IEnumerable<ValidationError> errors);
        IBusinessResult<T> SetValue(T newValue);
        T Value();
        IEnumerable<string> Errors();
        IEnumerable<ValidationError> FullErrors();
    }
}

namespace IConstruye.Utils.BusinessValidation.Models
{
    public class BusinessResult : BusinessResult<Void>
    {
        public new BusinessResult SetValue(Void newValue)
        {
            throw new InvalidOperationException("No se puede asignar un valor vacío.");
        }
    }
}

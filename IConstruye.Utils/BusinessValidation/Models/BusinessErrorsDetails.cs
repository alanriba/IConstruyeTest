using IConstruye.Utils.Enums;

namespace IConstruye.Utils.Models
{
    public class BusinessErrorsDetails
    {
        public TipoServicio TipoServicio { get; set; }
        public IEnumerable<ActionParameter> InputData { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}

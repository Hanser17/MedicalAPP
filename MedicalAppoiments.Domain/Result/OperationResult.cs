

namespace MedicalAppoiments.Domain.Result
{
    public class OperationResult
    {
        public OperationResult()
        {
            this.success = true;

        }
        public string? message { get; set; }
        public bool success { get; set; }
        public dynamic? Data { get; set; }

    }
}

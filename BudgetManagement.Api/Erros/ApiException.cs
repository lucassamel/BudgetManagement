namespace BudgetManagement.Api.Erros
{
    public class ApiException(string statusCode, string message, string details)
    {
        public string StatusCode { get; set; } = statusCode;
        public string Message { get; set; } = message;
        public string Details { get; set; } = details;
    }
}

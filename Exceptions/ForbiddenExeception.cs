namespace FinanceFlowAPI.Exceptions
{
    public class ForbiddenExeception : BaseException
    {
        public ForbiddenExeception(string message) 
            : base(message, 403)
        {
            
        }
    }
}

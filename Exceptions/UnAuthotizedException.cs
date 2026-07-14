namespace FinanceFlowAPI.Exceptions
{
    public class UnAuthotizedException : BaseException
    {
        public UnAuthotizedException(string message)
            : base(message, 401)
        {
            
        }
    }
}

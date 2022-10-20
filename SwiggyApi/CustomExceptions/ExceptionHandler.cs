namespace SwiggyApi.CustomExceptions
{
    public class ExceptionHandler: Exception
    {
        public ExceptionHandler(): base(string.Format("Connection Error!")) {
        
        }

    }
}

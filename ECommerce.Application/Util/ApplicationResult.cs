namespace ECommerce.Application.Util
{
    public class ApplicationResult
    {
        public bool Success { get; private set; }
        public object? Data { get; private set; }
        public List<string> Errors { get; private set; } = new();

        private ApplicationResult() { }

        public static ApplicationResult SuccessResult(object data)
        {
            return new ApplicationResult
            {
                Success = true,
                Data = data
            };
        }

        public static ApplicationResult FailureResult(params string[] errors)
        {
            return new ApplicationResult
            {
                Success = false,
                Errors = errors.ToList()
            };
        }
    }
}

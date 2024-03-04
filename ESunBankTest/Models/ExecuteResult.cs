namespace ESunBankTest.Models
{
    public class ExecuteResult
    {
        public ExecuteResult()
        {
            Success = false;
            Title = "Execute Result";
            Message = "This is an empty execute result.";
            Data = new List<object>();
        }

        public bool Success { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public List<object> Data { get; set; }
    }
}

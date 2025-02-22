namespace Common
{
    public class Result<T>
    {
        public T Value { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
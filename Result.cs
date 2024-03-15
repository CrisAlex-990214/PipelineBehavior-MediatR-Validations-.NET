namespace PipelineBehavior
{
    public class Result<T> : IResult
    {
        public T? Value { get; set; }
        public bool IsSuccess { get; set; } = true;
        public IEnumerable<string> Messages { get; set; } = [];
    }

    public interface IResult
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}

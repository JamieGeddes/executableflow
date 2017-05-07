namespace ExecutableFlow.Core
{
    public interface IActionStep<T> : IExecutableStep<T>
    {
        IExecutableStep<T> NextStep { get; set; }
    }
}

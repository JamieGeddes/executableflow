namespace ExecutableFlow.Core
{
    public interface IConditionalStep<T> : IExecutableStep<T>
    {
        IExecutableStep<T> PositiveStep { get; set; }
        IExecutableStep<T> NegativeStep { get; set; }
    }
}

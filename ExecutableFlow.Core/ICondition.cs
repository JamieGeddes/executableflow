namespace ExecutableFlow.Core
{
    public interface ICondition<T>
    {
        bool Evaluate(T context);
    }
}

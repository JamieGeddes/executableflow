namespace ExecutableFlow.Core
{
    public interface IExecutableAction<T>
    {
        void Execute(T context);
    }
}

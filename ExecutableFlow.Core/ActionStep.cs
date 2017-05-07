namespace ExecutableFlow.Core
{
    public class ActionStep<T> : IActionStep<T>
    {
        private readonly IExecutableAction<T> action;

        public ActionStep(IExecutableAction<T> action)
        {
            this.action = action;
        }

        public void Execute(T context)
        {
            action.Execute(context);

            NextStep?.Execute(context);
        }

        public IExecutableStep<T> NextStep { get; set; }
    }
}

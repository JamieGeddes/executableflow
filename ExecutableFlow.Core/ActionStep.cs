namespace ExecutableFlow.Core
{
    public class ActionStep<T> : IExecutableStep<T>
    {
        private readonly IExecutableAction<T> action;
        private readonly IExecutableStep<T> nextStep;

        public ActionStep(IExecutableAction<T> action, IExecutableStep<T> nextStep)
        {
            this.action = action;
            this.nextStep = nextStep;
        }

        public void Execute(T context)
        {
            action.Execute(context);

            if (nextStep != null) nextStep.Execute(context);
        }
    }
}

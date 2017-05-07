namespace ExecutableFlow.Core
{
    public class ConditionalStep<T> : IExecutableStep<T>
    {
        private readonly ICondition<T> condition;
        private readonly IExecutableStep<T> positiveStep;
        private readonly IExecutableStep<T> negativeStep;

        public ConditionalStep(ICondition<T> condition, IExecutableStep<T> positiveStep, IExecutableStep<T> negativeStep)
        {
            this.condition = condition;
            this.positiveStep = positiveStep;
            this.negativeStep = negativeStep;
        }

        public void Execute(T context)
        {
            if(condition.Evaluate(context))
            {
                positiveStep?.Execute(context);
            }
            else
            {
                negativeStep?.Execute(context);
            }
        }
    }
}

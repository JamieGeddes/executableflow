namespace ExecutableFlow.Core
{
    public class ConditionalStep<T> : IConditionalStep<T>
    {
        private readonly ICondition<T> condition;

        public ConditionalStep(ICondition<T> condition)
        {
            this.condition = condition;
        }

        public void Execute(T context)
        {
            if(condition.Evaluate(context))
            {
                PositiveStep?.Execute(context);
            }
            else
            {
                NegativeStep?.Execute(context);
            }
        }

        public IExecutableStep<T> PositiveStep { get; set; }
        public IExecutableStep<T> NegativeStep { get; set; }
    }
}

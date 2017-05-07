namespace ExecutableFlow.Core
{
    using System.Collections.Generic;

    public class ExecutionFlow<T>
    {
        public ExecutionFlow()
        {
            Steps = new Dictionary<string, IExecutableStep<T>>();
        }

        public void RegisterStep(string stepName, IExecutableStep<T> step)
        {
            Steps.Add(stepName, step);
        }

        public void Execute(T context)
        {
            FirstStep.Execute(context);
        }

        public IDictionary<string, IExecutableStep<T>> Steps { get; set; }

        public IExecutableStep<T> FirstStep { get; set; }
    }
}

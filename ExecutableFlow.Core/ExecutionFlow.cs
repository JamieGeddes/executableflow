namespace ExecutableFlow.Core
{
    using System.Collections.Generic;

    public class ExecutionFlow<T>
    {
        public ExecutionFlow()
        {
            Steps = new Dictionary<string, IExecutableStep<T>>();
        }

        public IDictionary<string, IExecutableStep<T>> Steps { get; set; }
    }
}

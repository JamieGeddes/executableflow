﻿namespace ExecutableFlow.Core
{
    public interface IExecutableStep<T>
    {
        void Execute(T context);
    }
}

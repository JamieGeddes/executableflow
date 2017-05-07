namespace ExecutableFlow.Tests
{
    using ExecutableFlow.Core;
    using NSubstitute;
    using NUnit.Framework;

    public class ExecutionFlowTests
    {
        [Test]
        public void ExecutesStepsInExpectedOrder()
        {
            var action1 = Substitute.For<IExecutableAction<TestContext>>();
            var firstStep = new ActionStep<TestContext>(action1);

            var action2 = Substitute.For<IExecutableAction<TestContext>>();
            var secondStep = new ActionStep<TestContext>(action2);

            firstStep.NextStep = secondStep;

            var flow = new ExecutionFlow<TestContext>();

            flow.RegisterStep("first", firstStep);
            flow.RegisterStep("second", secondStep);

            flow.FirstStep = firstStep;

            var context = new TestContext();

            flow.Execute(context);

            action1.Received().Execute(context);
            action2.Received().Execute(context);
        }

    }
}

namespace ExecutableFlow.Tests
{
    using ExecutableFlow.Core;
    using NUnit.Framework;
    using NSubstitute;

    public class ActionStepTests
    {
        [Test]
        public void CallsNextStep()
        {
            var action = Substitute.For<IExecutableAction<TestContext>>();

            var step = new ActionStep<TestContext>(action, null);

            var context = new TestContext();

            step.Execute(context);

            action.Received().Execute(context);
        }
    }
}

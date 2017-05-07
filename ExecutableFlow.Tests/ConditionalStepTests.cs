namespace ExecutableFlow.Tests
{
    using ExecutableFlow.Core;
    using NSubstitute;
    using NUnit.Framework;

    public class ConditionalStepTests
    {
        [Test]
        public void CallsPositiveStepOnSuccessOfCondition()
        {
            var context = new TestContext();

            var condition = AnyConditionThatReturns(true);

            var positiveStep = Substitute.For<IExecutableStep<TestContext>>();
            var negativeStep = Substitute.For<IExecutableStep<TestContext>>();

            var step = new ConditionalStep<TestContext>(condition, positiveStep, negativeStep);

            step.Execute(context);

            positiveStep.Received().Execute(context);
            negativeStep.DidNotReceive().Execute(context);
        }

        [Test]
        public void CallsNegativeStepOnFailureOfCondition()
        {
            var context = new TestContext();

            var condition = AnyConditionThatReturns(false);

            var positiveStep = Substitute.For<IExecutableStep<TestContext>>();
            var negativeStep = Substitute.For<IExecutableStep<TestContext>>();

            var step = new ConditionalStep<TestContext>(condition, positiveStep, negativeStep);

            step.Execute(context);

            negativeStep.Received().Execute(context);
            positiveStep.DidNotReceive().Execute(context);
        }

        private ICondition<TestContext> AnyConditionThatReturns(bool expectedResult)
        {
            var condition = Substitute.For<ICondition<TestContext>>();
            condition.Evaluate(Arg.Any<TestContext>()).Returns(expectedResult);

            return condition;
        }

    }
}

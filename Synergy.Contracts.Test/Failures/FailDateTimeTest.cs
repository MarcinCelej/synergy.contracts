using System;
using NUnit.Framework;
using Synergy.Contracts.Samples;

namespace Synergy.Contracts.Test.Failures
{
    [TestFixture]
    public class FailDateTimeTest
    {
        [Test]
        public void IfNotMidnight()
        {
            // ARRANGE
            DateTime notMidnight = DateTime.Today.AddSeconds(1000);

            // ACT
            var exception = Assert.Throws<DesignByContractViolationException>(
                () => Fail.IfNotMidnight(notMidnight, "date should have no hour nor second")
                );

            // ASSERT
            Assert.That(exception.Message, Is.EqualTo("date should have no hour nor second"));
        }

        [Test]
        public void IfNotMidnightSuccess()
        {
            // ACT
            Fail.IfNotMidnight(DateTime.Today, "date should have no hour nor second");
        }

        [Test]
        public void IfNotMidnightSuccessWithNull()
        {
            // ACT
            Fail.IfNotMidnight(null, "date should have no hour nor second");
        }

        [Test]
        public void IfNotMidnightSample()
        {
            // ARRANGE
            IContractorRepository contractorRepository = new ContractorRepository();
            var ratherNotMidnight = DateTime.Now;

            // ACT
            var exception = Assert.Throws<DesignByContractViolationException>(
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                () => contractorRepository.GetContractorsAged(minDate: ratherNotMidnight, maxDate: null));

            // ASSERT
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("minDate must be a midnight"));
        }
    }
}
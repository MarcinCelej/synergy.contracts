using System;
using System.Collections;
using JetBrains.Annotations;
using NUnit.Framework;
using Synergy.Contracts.Samples;

namespace Synergy.Contracts.Test.Failures
{
    [TestFixture]
    public class FailGuidTest
    {
        #region Fail.IfArgumentEmpty

        [TestCaseSource(nameof(FailGuidTest.GetEmptyGuid))]
        public void IfArgumentEmpty(Guid someEmptyGuid)
        {
            // ACT
            var exception = Assert.Throws<DesignByContractViolationException>(
                () => Fail.IfArgumentEmpty(someEmptyGuid, nameof(someEmptyGuid))
            );

            // ASSERT
            Assert.That(exception.Message, Is.EqualTo("Argument 'someEmptyGuid' is an empty Guid."));
        }

        [TestCaseSource(nameof(FailGuidTest.GetNewGuid))]
        public void IfArgumentEmptySuccess(Guid someGuid)
        {
            // ACT
            Fail.IfArgumentEmpty(someGuid, nameof(someGuid));
        }

        [TestCaseSource(nameof(FailGuidTest.GetEmptyGuid))]
        public void IfArgumentEmptySample(Guid id)
        {
            // ARRANGE
            IContractorRepository contractorRepository = new ContractorRepository();

            // ACT
            var exception = Assert.Throws<DesignByContractViolationException>(
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                () => contractorRepository.FindContractorByGuid(id: id)
            );

            // ASSERT
            Assert.That(exception.Message, Is.EqualTo($"Argument '{nameof(id)}' is an empty Guid."));
        }

        #endregion

        #region Fail.IfEmpty

        [Test]
        public void IfEmpty()
        {
            // ACT
            var exception = Assert.Throws<DesignByContractViolationException>(
                () => Fail.IfEmpty(Guid.Empty, "guid is empty and it shouldn't be")
            );

            // ASSERT
            Assert.That(exception.Message, Is.EqualTo("guid is empty and it shouldn't be"));
        }

        [Test]
        public void IfEmptySuccess()
        {
            // ARRANGE
            Guid notEmptyGuid = Guid.NewGuid();

            // ACT
            Fail.IfEmpty(notEmptyGuid, "guid is empty and it shouldn't be");
        }

        #endregion

        [ItemNotNull, NotNull]
        private static IEnumerable GetEmptyGuid()
        {
            yield return Guid.Empty;
        }

        [ItemNotNull, NotNull]
        private static IEnumerable GetNewGuid()
        {
            yield return Guid.NewGuid();
        }

        [Explicit, Test]
        public void WriteEmptyGuidsToConsole()
        {
            Console.WriteLine("Guid.Empty = " + Guid.Empty);
            Console.WriteLine("new Guid() = " + new Guid());
        }
    }
}
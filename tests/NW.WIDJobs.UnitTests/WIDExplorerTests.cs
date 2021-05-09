using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDExplorerTests
    {

        // Fields
        private static TestCaseData[] exploreTestCasesException =
        {

            new TestCaseData(null)
                .SetName(nameof(Explorer_ShouldThrowAnException_WhenComponentsAreNull) + " {01}"),

            new TestCaseData(
                    new WIDExplorerComponents(WIDExplorerComponents.DefaultLoggingAction, null, new GetRequestManager()))
                .SetName(nameof(Explorer_ShouldThrowAnException_WhenComponentsAreNull) + " {02}")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(exploreTestCasesException))]
        public void Explorer_ShouldThrowAnException_WhenComponentsAreNull
            (WIDExplorerComponents components)
        {

            // Arrange
            // Act
            // Assert
            Assert.Throws<Exception>(
                () => new WIDExplorer(components, new WIDExplorerSettings()));

        }

        // TearDown
        // Utility methods

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/
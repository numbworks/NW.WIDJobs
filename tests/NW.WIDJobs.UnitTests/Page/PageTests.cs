using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageTests
    {

        // Fields
        private static TestCaseData[] pageExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new Page(
                                null,
                                ObjectMother.Shared_Page01.PageNumber,
                                ObjectMother.Shared_Page01.Content
                        )
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(pageExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new Page(
                                ObjectMother.Shared_Page01.RunId,
                                0,
                                ObjectMother.Shared_Page01.Content
                        )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageNumber")
            ).SetArgDisplayNames($"{nameof(pageExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new Page(
                                ObjectMother.Shared_Page01.RunId,
                                ObjectMother.Shared_Page01.PageNumber,
                                null
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("content").Message
            ).SetArgDisplayNames($"{nameof(pageExceptionTestCases)}_03")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageExceptionTestCases))]
        public void Page_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void Page_ShouldInitializeANewPageObject_WhenProperArguments()
        {

            // Arrange
            // Act
            Page actual 
                = new Page(
                        ObjectMother.Shared_Page01.RunId,
                        ObjectMother.Shared_Page01.PageNumber,
                        ObjectMother.Shared_Page01.Content
                        );

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(ObjectMother.Shared_Page01, actual)    
                );

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/

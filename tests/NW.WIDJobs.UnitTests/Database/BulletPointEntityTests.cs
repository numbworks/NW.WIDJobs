using NUnit.Framework;
using System;
using NW.WIDJobs.Database;
using NW.WIDJobs.JobPostingsExtended;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class BulletPointEntityTests
    {

        // Fields
        private static TestCaseData[] bulletPointEntityTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_FakeRunId,
                    "Some bullet point",
                    new BulletPointEntity(
                            ObjectMother.Shared_FakeRunId,
                            new BulletPoint("Some bullet point", null)
                        )
                ).SetArgDisplayNames($"{nameof(bulletPointEntityTestCases)}_01")

        };
        private static TestCaseData[] bulletPointEntityExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new BulletPointEntity(null, new BulletPoint("Some bullet point", null))
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingId").Message
            ).SetArgDisplayNames($"{nameof(bulletPointEntityExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new BulletPointEntity(ObjectMother.Shared_FakeRunId, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("bulletPoint").Message
            ).SetArgDisplayNames($"{nameof(bulletPointEntityExceptionTestCases)}_02")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(bulletPointEntityTestCases))]
        public void BulletPointEntity_ShouldInstantiateObject_WhenPropertArguments
            (string jobPostingId, string bulletPoint, BulletPointEntity expected)
        {

            // Arrange
            // Act
            BulletPointEntity actual = new BulletPointEntity(jobPostingId, new BulletPoint("Some bullet point", null));

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual)
                );

        }
        
        [TestCaseSource(nameof(bulletPointEntityExceptionTestCases))]
        public void BulletPointEntity_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void BulletPointEntity_ShouldCreateAnObjectOfTypeBulletPointEntity_WhenInvoked()
        {

            // Arrange
            // Act
            BulletPointEntity actual = new BulletPointEntity();

            // Assert
            Assert.IsInstanceOf<BulletPointEntity>(actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.09.2021
*/

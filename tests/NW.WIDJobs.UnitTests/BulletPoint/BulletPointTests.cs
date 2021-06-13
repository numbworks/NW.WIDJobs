using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class BulletPointTests
    {

        // Fields
        private static TestCaseData[] bulletPointTestCases =
        {

            new TestCaseData(
                    "some label",
                    "some text",
                    new BulletPoint("some label", "some text")
                ).SetArgDisplayNames($"{nameof(bulletPointTestCases)}_01")

        };
        private static TestCaseData[] bulletPointExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new BulletPoint(null, "some text")
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("label").Message
            ).SetArgDisplayNames($"{nameof(bulletPointExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new BulletPoint("some label", null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("text").Message
            ).SetArgDisplayNames($"{nameof(bulletPointExceptionTestCases)}_02")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(bulletPointTestCases))]
        public void BulletPoint_ShouldInitializeANewBulletPointObject_WhenProperArguments
            (string label, string text, BulletPoint expected)
        {

            // Arrange
            // Act
            BulletPoint actual = new BulletPoint(label, text);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }
        [TestCaseSource(nameof(bulletPointExceptionTestCases))]
        public void BulletPoint_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void BulletPoint_ShouldInitializeANewBulletPointObject_WhenBulletPointLabels()
        {

            // Arrange
            BulletPoint expected = new BulletPoint(BulletPointLabels.JobDuty.ToString(), "some text");

            // Act
            BulletPoint actual = new BulletPoint(BulletPointLabels.JobDuty, "some text");

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/
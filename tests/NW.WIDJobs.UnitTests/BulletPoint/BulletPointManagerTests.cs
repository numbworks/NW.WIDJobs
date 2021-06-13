using NUnit.Framework;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class BulletPointManagerTests
    {

        // Fields
        // SetUp
        // Tests
        [Test]
        public void GetPreLabeledExamples_ShouldReturnExpectedListOfBulletPoints_WhenInvoked()
        {

            // Arrange
            List<BulletPoint> expected = new List<BulletPoint>();
            expected.AddRange(
                        ObjectMother.CallPrivateMethod<BulletPointManager, List<BulletPoint>>(new BulletPointManager(), "GetJobRequirementBulletPoints", null));
            expected.AddRange(
                        ObjectMother.CallPrivateMethod<BulletPointManager, List<BulletPoint>>(new BulletPointManager(), "GetJobDutyBulletPoints", null));

            // Act
            List <BulletPoint> actual = new BulletPointManager().GetPreLabeledExamples();

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

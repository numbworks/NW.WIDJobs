using NUnit.Framework;
using System;
using NW.WIDJobs.Classification;
using System.Collections.Generic;
using NW.NGramTextClassification.LabeledExamples;
using NW.NGramTextClassification;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class ClassificationManagerTests
    {

        #region Fields

        private static TestCaseData[] classificationManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new ClassificationManager((ITextClassifier)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("textClassifier").Message
            ).SetArgDisplayNames($"{nameof(classificationManagerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new ClassificationManager((Action<string>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("textClassifierLoggingAction").Message
            ).SetArgDisplayNames($"{nameof(classificationManagerExceptionTestCases)}_02")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(classificationManagerExceptionTestCases))]
        public void ClassificationManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void ClassificationManager_ShouldCreateAnObjectOfTypeClassificationManager_WhenInvoked()
        {

            // Arrange
            // Act
            ClassificationManager actual = new ClassificationManager();

            // Assert
            Assert.IsInstanceOf<ClassificationManager>(actual);

        }

        [Test]
        public void GetPreLabeledExamplesForLanguage_ShouldCreateAnObjectOfTypeListLabeledExample_WhenInvoked()
        {

            // Arrange
            // Act
            List<LabeledExample> actual = new ClassificationManager().GetPreLabeledExamplesForLanguage();

            // Assert
            Assert.IsInstanceOf<List<LabeledExample>>(actual);

        }

        [Test]
        public void GetPreLabeledExamplesForBulletPointType_ShouldCreateAnObjectOfTypeListLabeledExample_WhenInvoked()
        {

            // Arrange
            // Act
            List<LabeledExample> actual = new ClassificationManager().GetPreLabeledExamplesForBulletPointType();

            // Assert
            Assert.IsInstanceOf<List<LabeledExample>>(actual);

        }

        [Test]
        public void TryPredictLanguage_ShouldReturnExpectedString_WhenInvoked()
        {

            // Arrange
            ClassificationManager classificationManager = new ClassificationManager();
            LabeledExample labeledExample = classificationManager.GetPreLabeledExamplesForLanguage()[0];
            string text = labeledExample.Text;
            string expected = labeledExample.Label;

            // Act
            string actual = classificationManager.TryPredictLanguage(text);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TryPredictBulletPointType_ShouldReturnExpectedString_WhenInvoked()
        {

            // Arrange
            ClassificationManager classificationManager = new ClassificationManager();
            LabeledExample labeledExample = classificationManager.GetPreLabeledExamplesForBulletPointType()[1];
            string text = labeledExample.Text;
            string expected = labeledExample.Label;

            // Act
            string actual = classificationManager.TryPredictBulletPointType(text);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/
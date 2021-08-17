using NUnit.Framework;
using System;
using System.Collections.Generic;
using NW.WIDJobs.XPath;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class XPathManagerTests
    {

        // Fields
        private static TestCaseData[] getInnerTextsTestCases =
        {

            new TestCaseData(
                    ObjectMother.XPathManager_HTML,
                    ObjectMother.XPathManager_GetInnerTexts_XPath,
                    ObjectMother.XPathManager_GetInnerTexts_Results
                ).SetArgDisplayNames($"{nameof(getInnerTextsTestCases)}_01")

        };
        private static TestCaseData[] getInnerTextTestCases =
        {

            new TestCaseData(
                    ObjectMother.XPathManager_HTML,
                    ObjectMother.XPathManager_GetInnerTexts_XPath,
                    (uint)0,
                    ObjectMother.XPathManager_GetInnerTexts_Results[0]
                ).SetArgDisplayNames($"{nameof(getInnerTextTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.XPathManager_HTML,
                    ObjectMother.XPathManager_GetInnerTexts_XPath,
                    (uint)1,
                    ObjectMother.XPathManager_GetInnerTexts_Results[1]
                ).SetArgDisplayNames($"{nameof(getInnerTextTestCases)}_02")

        };
        private static TestCaseData[] tryGetInnerTextTestCases =
 {

            new TestCaseData(
                    ObjectMother.XPathManager_HTML,
                    ObjectMother.XPathManager_TryGetInnerText_XPath,
                    (uint)0,
                    null
                ).SetArgDisplayNames($"{nameof(tryGetInnerTextTestCases)}_01")

        };
        private static TestCaseData[] getAttributeValuesTestCases =
        {

            new TestCaseData(
                    ObjectMother.XPathManager_HTML,
                    ObjectMother.XPathManager_GetAttributeValues_XPath,
                    ObjectMother.XPathManager_GetAttributeValues_Results
                ).SetArgDisplayNames($"{nameof(getAttributeValuesTestCases)}_01")

        };
        private static TestCaseData[] getFirstAttributeValueTestCases =
        {

            new TestCaseData(
                    ObjectMother.XPathManager_HTML,
                    ObjectMother.XPathManager_GetAttributeValues_XPath,
                    ObjectMother.XPathManager_GetAttributeValues_Results[0]
                ).SetArgDisplayNames($"{nameof(getFirstAttributeValueTestCases)}_01")

        };
        private static TestCaseData[] tryGetFirstAttributeValueTestCases =
 {

            new TestCaseData(
                    ObjectMother.XPathManager_HTML,
                    ObjectMother.XPathManager_TryGetFirstAttributeValue_XPath,
                    null
                ).SetArgDisplayNames($"{nameof(tryGetFirstAttributeValueTestCases)}_01")

        };
        private static TestCaseData[] xpathManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new XPathManager(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("htmlDocumentAdapter").Message
            ).SetArgDisplayNames($"{nameof(xpathManagerExceptionTestCases)}_01")

        };
        private static TestCaseData[] getInnerTextsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new XPathManager().GetInnerTexts(null, "some_xpath")
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("html").Message
            ).SetArgDisplayNames($"{nameof(getInnerTextsExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new XPathManager().GetInnerTexts("some_html", null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpath").Message
            ).SetArgDisplayNames($"{nameof(getInnerTextsExceptionTestCases)}_02")

        };
        private static TestCaseData[] getAttributeValuesExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new XPathManager().GetAttributeValues(null, "some_xpath")
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("html").Message
            ).SetArgDisplayNames($"{nameof(getAttributeValuesExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new XPathManager().GetAttributeValues("some_html", null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpath").Message
            ).SetArgDisplayNames($"{nameof(getAttributeValuesExceptionTestCases)}_02")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(getInnerTextsTestCases))]
        public void GetInnerTexts_ShouldReturnACollectionOfInnerTexts_WhenInvoked
            (string html, string xpath, List<string> expected)
        {

            // Arrange
            // Act
            List<string> actual = new XPathManager().GetInnerTexts(html, xpath);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

        [TestCaseSource(nameof(getInnerTextTestCases))]
        public void GetInnerText_ShouldReturnInnerText_WhenInvoked
            (string html, string xpath, uint valueNr, string expected)
        {

            // Arrange
            // Act
            string actual = new XPathManager().GetInnerText(html, xpath, valueNr);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(tryGetInnerTextTestCases))]
        public void TryGetInnerText_ShouldReturnInnerTextOrNull_WhenInvoked
            (string html, string xpath, uint valueNr, string expected)
        {

            // Arrange
            // Act
            string actual = new XPathManager().TryGetInnerText(html, xpath, valueNr);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(getAttributeValuesTestCases))]
        public void GetAttributeValues_ShouldReturnACollectionOfAttributeValues_WhenInvoked
            (string html, string xpath, List<string> expected)
        {

            // Arrange
            // Act
            List<string> actual = new XPathManager().GetAttributeValues(html, xpath);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

        [TestCaseSource(nameof(getFirstAttributeValueTestCases))]
        public void GetFirstAttributeValue_ShouldReturnFirstAttributeValue_WhenInvoked
            (string html, string xpath, string expected)
        {

            // Arrange
            // Act
            string actual = new XPathManager().GetFirstAttributeValue(html, xpath);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(tryGetFirstAttributeValueTestCases))]
        public void TryGetFirstAttributeValue_ShouldReturnFirstAttributeValueOrNull_WhenInvoked
            (string html, string xpath, string expected)
        {

            // Arrange
            // Act
            string actual = new XPathManager().TryGetFirstAttributeValue(html, xpath);

            // Assert
            Assert.AreEqual(expected, actual);

        }


        [TestCaseSource(nameof(xpathManagerExceptionTestCases))]
        public void XPathManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getInnerTextsExceptionTestCases))]
        public void GetInnerTexts_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getAttributeValuesExceptionTestCases))]
        public void GetAttributeValues_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/

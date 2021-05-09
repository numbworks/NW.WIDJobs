using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NSubstitute;

namespace NW.WIDJobs.UnitTests
{
    public static class ObjectMother
    {

        // ValidatorTests
        internal static string[] Validator_Array1 = new[] { "Dodge", "Datsun", "Jaguar", "DeLorean" };
        internal static Car Validator_Object1 = new Car()
        {
            Brand = "Dodge",
            Model = "Charger",
            Year = 1966,
            Price = 13500,
            Currency = "USD"
        };
        internal static uint Validator_Length1 = 3;
        internal static string Validator_VariableName_Variable = "variable";
        internal static string Validator_VariableName_Length = "length";
        internal static string Validator_VariableName_N1 = "n1";
        internal static string Validator_VariableName_N2 = "n2";
        internal static List<string> List1 = Validator_Array1.ToList();
        internal static uint Validator_Value = Validator_Length1;
        internal static string Validator_String1 = "Dodge";
        internal static string Validator_StringOnlyWhiteSpaces = "   ";

        // PageItemScraperTests ?
        internal static Func<IGetRequestManager> PageItemScraper_FuncEmptyHTML
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>()).Returns("<html></<html>");
                return fakeGetRequest;
            });

        // Methods
        internal static void Method_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception actual = Assert.Throws(expectedType, del);
            Assert.AreEqual(expectedMessage, actual.Message);

        }

        internal static List<PageItem> RemoveItems(List<PageItem> pageItems, int index, int count)
        {

            List<PageItem> result = new List<PageItem>(pageItems);
            result.RemoveRange(index, count);

            return result;

        }
        internal static bool AreEqual(PageItem pageItem1, PageItem pageItem2)
            => throw new NotImplementedException();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/
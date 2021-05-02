using System;
using NUnit.Framework;
using RUBN.Shared;

namespace NW.WebsiteExploration.UnitTests
{
    [TestFixture]
    public class AWebsiteExplorerTests
    {

        // Fields
        // SetUp
        // Tests
        [Test]
        public void AWebsiteExplorer_ShouldThrowAnException_WhenDerivedClassProvidesEmptyWebsiteName()
        {

            // Arrange
            // Act           
            try
            {

                FakeExplorerOne fakeExplorer = new FakeExplorerOne();

            }
            // Assert
            catch (Exception e)
            {

                Assert.IsInstanceOf<Exception>(e);
                Assert.AreEqual("The website name can't be empty or null.", e.Message);

            }

        }

        [Test]
        public void AWebsiteExplorer_ShouldThrowAnException_WhenDerivedClassProvidesLowResultsPerPage()
        {

            // Arrange
            // Act           
            try
            {

                FakeExplorerTwo fakeExplorer = new FakeExplorerTwo();

            }
            // Assert
            catch (Exception e)
            {

                Assert.IsInstanceOf<Exception>(e);
                Assert.AreEqual("The ResultsPerPage can't be less than one.", e.Message);

            }

        }


        // TearDown

    }

    // Fake classes
    public class FakeExplorerOne : AWebsiteExplorer
    {

        // Constructors
        public FakeExplorerOne() : base(null, 20) { }

        // Methods
        protected override Outcome GetTotalResults(string strResponse)
            => OutcomeBuilder.CreateSuccess("somemessage", null).Get();
        protected override UInt16 GetTotalPagesExpected(UInt32 uintTotalResults)
            => 64;
        protected override string GetPageAbsoluteUrl(UInt16 uintPageNumber)
            => "http://someurl.com";
        protected override Outcome GetItems(string strResponse)
            => OutcomeBuilder.CreateSuccess("somemessage", null).Get();
        protected override Outcome RemoveAlreadyImportedItems(ResultsPage objPage, string strConnectionString)
            => OutcomeBuilder.CreateSuccess("somemessage", null).Get();

    }
    public class FakeExplorerTwo : AWebsiteExplorer
    {

        // Constructors
        public FakeExplorerTwo() : base("somewebsite", 0) { }

        // Methods
        protected override Outcome GetTotalResults(string strResponse)
            => OutcomeBuilder.CreateSuccess("somemessage", null).Get();
        protected override UInt16 GetTotalPagesExpected(UInt32 uintTotalResults)
            => 64;
        protected override string GetPageAbsoluteUrl(UInt16 uintPageNumber)
            => "http://someurl.com";
        protected override Outcome GetItems(string strResponse)
            => OutcomeBuilder.CreateSuccess("somemessage", null).Get();
        protected override Outcome RemoveAlreadyImportedItems(ResultsPage objPage, string strConnectionString)
            => OutcomeBuilder.CreateSuccess("somemessage", null).Get();

    }

}

/*

    Author: numbworks@gmail.com
    Last Update: 23.09.2018

*/
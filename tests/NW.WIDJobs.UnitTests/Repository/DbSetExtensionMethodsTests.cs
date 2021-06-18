using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class DbSetExtensionMethodsTests
    {

        // Fields
        private static TestCaseData[] addOrUpdateExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .PageItems
                                    .AddOrUpdate((IEnumerable<PageItemEntity>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entities").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .PageItems
                                    .AddOrUpdate((PageItemEntity)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entity").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .PageItems
                                    .AddOrUpdate(
                                        (IEnumerable<PageItemEntity>)null, 
                                        ref ObjectMother.DbSetExtensionMethods_NotExistingPageItemEntities)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entities").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .PageItems
                                    .AddOrUpdate(
                                        (PageItemEntity)null,
                                        ref ObjectMother.DbSetExtensionMethods_NotExistingPageItemEntities)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entity").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_04")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(addOrUpdateExceptionTestCases))]
        public void AddOrUpdate_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.06.2021
*/

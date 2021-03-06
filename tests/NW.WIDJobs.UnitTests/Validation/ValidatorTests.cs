using System;
using System.Collections.Generic;
using NUnit.Framework;
using NW.WIDJobs.Messages;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class ValidatorTests
    {

        #region Fields

        private static TestCaseData[] validateLengthExceptionTestCases =
        {

            // ValidateLength<T>
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateLength<Exception>(0)
                    ),
                typeof(Exception),
                new Exception(
                        MessageCollection.Validator_VariableCantBeLessThanOne.Invoke(ObjectMother.Validator_VariableName_Length)).Message
                ).SetArgDisplayNames($"{nameof(validateLengthExceptionTestCases)}_01"),

            // ValidateLength
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateLength(0)
                    ),
                typeof(ArgumentException),
                new ArgumentException(
                        MessageCollection.Validator_VariableCantBeLessThanOne.Invoke(ObjectMother.Validator_VariableName_Length)).Message
                ).SetArgDisplayNames($"{nameof(validateLengthExceptionTestCases)}_02")

        };
        private static TestCaseData[] validateObjectExceptionTestCases =
        {

            // ValidateObject<T>
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateObject<ArgumentException>(null, ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentException),
                new ArgumentException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateObjectExceptionTestCases)}_01"),

            // ValidateObject
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateObject(null, ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateObjectExceptionTestCases)}_02")

        };
        private static TestCaseData[] validateArrayExceptionTestCases =
        {

            // ValidateArrayNull
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateArray<string>(
                                null,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateArrayExceptionTestCases)}_01"),

            // ValidateArrayEmpty
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateArray(
                                Array.Empty<string>(),
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableContainsZeroItems.Invoke(ObjectMother.Validator_VariableName_Variable)
                ).SetArgDisplayNames($"{nameof(validateArrayExceptionTestCases)}_02")

        };
        private static TestCaseData[] validateListExceptionTestCases =
        {

            // ValidateListNull
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateList(
                                (List<string>)null,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateListExceptionTestCases)}_01"),

            // ValidateListEmpty
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateList(
                                new List<string>() { },
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableContainsZeroItems.Invoke(ObjectMother.Validator_VariableName_Variable)
                ).SetArgDisplayNames($"{nameof(validateListExceptionTestCases)}_02"),

        };
        private static TestCaseData[] validateStringNullOrWhiteSpaceExceptionTestCases =
        {

            // ValidateStringNullOrWhiteSpace<T>
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateStringNullOrWhiteSpace<Exception>(
                                null,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(Exception),
                new Exception(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateStringNullOrWhiteSpaceExceptionTestCases)}_01"),

            // ValidateStringNullOrWhiteSpace
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateStringNullOrWhiteSpace(
                                null,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateStringNullOrWhiteSpaceExceptionTestCases)}_02"),

            // ValidateStringNullOrWhiteSpace
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateStringNullOrWhiteSpace(
                                string.Empty,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateStringNullOrWhiteSpaceExceptionTestCases)}_03"),

            // ValidateStringNullOrWhiteSpace
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateStringNullOrWhiteSpace(
                                ObjectMother.Validator_StringOnlyWhiteSpaces,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateStringNullOrWhiteSpaceExceptionTestCases)}_04")

        };
        private static TestCaseData[] validateStringNullOrEmptyExceptionTestCases =
        {

            // ValidateStringNullOrEmpty<T>
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateStringNullOrEmpty<Exception>(
                                null,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(Exception),
                new Exception(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateStringNullOrEmptyExceptionTestCases)}_01"),

            // ValidateStringNullOrEmpty
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateStringNullOrEmpty(
                                null,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateStringNullOrEmptyExceptionTestCases)}_02"),

            // ValidateStringNullOrEmpty
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ValidateStringNullOrEmpty(
                                string.Empty,
                                ObjectMother.Validator_VariableName_Variable)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException(ObjectMother.Validator_VariableName_Variable).Message
                ).SetArgDisplayNames($"{nameof(validateStringNullOrEmptyExceptionTestCases)}_03")

        };
        private static TestCaseData[] validateStringNullOrEmptyTestCases =
        {

            new TestCaseData(
                    ObjectMother.Validator_String1
                ).SetArgDisplayNames($"{nameof(validateStringNullOrEmptyTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Validator_StringOnlyWhiteSpaces
                ).SetArgDisplayNames($"{nameof(validateStringNullOrEmptyTestCases)}_02")

        };
        private static TestCaseData[] throwIfLessThanOneExceptionTestCases =
        {

            // ThrowIfLessThanOne<T>
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfLessThanOne<Exception>(0, ObjectMother.Validator_VariableName_N1)
                    ),
                typeof(Exception),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke(ObjectMother.Validator_VariableName_N1)
                ).SetArgDisplayNames($"{nameof(throwIfLessThanOneExceptionTestCases)}_01"),

            // ThrowIfLessThanOne
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfLessThanOne(0, ObjectMother.Validator_VariableName_N1)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke(ObjectMother.Validator_VariableName_N1)
                ).SetArgDisplayNames($"{nameof(throwIfLessThanOneExceptionTestCases)}_02")

        };
        private static TestCaseData[] throwIfFirstIsGreaterExceptionTestCases =
        {

            // ThrowIfFirstIsGreater<T>
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfFirstIsGreater<Exception>(
                                4,
                                ObjectMother.Validator_VariableName_N1,
                                1,
                                ObjectMother.Validator_VariableName_N2)
                    ),
                typeof(Exception),
                MessageCollection.Validator_FirstValueIsGreaterThanSecondValue.Invoke(
                                        ObjectMother.Validator_VariableName_N1,
                                        ObjectMother.Validator_VariableName_N2
                                    )
                ).SetArgDisplayNames($"{nameof(throwIfFirstIsGreaterExceptionTestCases)}_01"),

            // ThrowIfFirstIsGreater
            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfFirstIsGreater(
                                4,
                                ObjectMother.Validator_VariableName_N1,
                                1,
                                ObjectMother.Validator_VariableName_N2)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_FirstValueIsGreaterThanSecondValue.Invoke(
                                        ObjectMother.Validator_VariableName_N1,
                                        ObjectMother.Validator_VariableName_N2
                                    )
                ).SetArgDisplayNames($"{nameof(throwIfFirstIsGreaterExceptionTestCases)}_02")

        };
        private static TestCaseData[] throwIfFirstIsGreaterOrEqualExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfFirstIsGreaterOrEqual<Exception>(
                                4,
                                ObjectMother.Validator_VariableName_N1,
                                1,
                                ObjectMother.Validator_VariableName_N2)
                    ),
                typeof(Exception),
                MessageCollection.Validator_FirstValueIsGreaterOrEqualThanSecondValue.Invoke(
                                        ObjectMother.Validator_VariableName_N1,
                                        ObjectMother.Validator_VariableName_N2
                                    )
                ).SetArgDisplayNames($"{nameof(throwIfFirstIsGreaterOrEqualExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfFirstIsGreaterOrEqual(
                                4,
                                ObjectMother.Validator_VariableName_N1,
                                1,
                                ObjectMother.Validator_VariableName_N2)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_FirstValueIsGreaterOrEqualThanSecondValue.Invoke(
                                        ObjectMother.Validator_VariableName_N1,
                                        ObjectMother.Validator_VariableName_N2
                                    )
                ).SetArgDisplayNames($"{nameof(throwIfFirstIsGreaterOrEqualExceptionTestCases)}_02")

        };
        private static TestCaseData[] throwIfCountsAreNotEqualExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfCountsAreNotEqual<Exception>(
                                            ObjectMother.Validator_SubScrapers_Wrong
                            )),
                typeof(Exception),
                MessageCollection.Validator_AtLeastOneSubScraper.Invoke(
                                        ObjectMother.Validator_SubScrapers_Wrong
                                    )
                ).SetArgDisplayNames($"{nameof(throwIfCountsAreNotEqualExceptionTestCases)}_01")

        };
        private static TestCaseData[] throwIfModuloIsNotZeroExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfModuloIsNotZero(
                                            4,
                                            ObjectMother.Validator_VariableName_N1,
                                            3,
                                            ObjectMother.Validator_VariableName_N2
                            )),
                typeof(ArgumentException),
                MessageCollection.Validator_DividingMustReturnWholeNumber.Invoke(
                                        ObjectMother.Validator_VariableName_N1,
                                        ObjectMother.Validator_VariableName_N2
                                    )
                ).SetArgDisplayNames($"{nameof(throwIfModuloIsNotZeroExceptionTestCases)}_01")

        };
        private static TestCaseData[] throwIfFirstIsOlderOrEqualExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => Validator.ThrowIfFirstIsOlderOrEqual(
                                            ObjectMother.Validator_DateTimeOlder,
                                            nameof(ObjectMother.Validator_DateTimeOlder),
                                            ObjectMother.Validator_DateTimeNewer,
                                            nameof(ObjectMother.Validator_DateTimeNewer)
                            )),
                typeof(ArgumentException),
                MessageCollection.Validator_FirstDateIsOlderOrEqual.Invoke(
                                        nameof(ObjectMother.Validator_DateTimeOlder),
                                        nameof(ObjectMother.Validator_DateTimeNewer)
                                    )
                ).SetArgDisplayNames($"{nameof(throwIfFirstIsOlderOrEqualExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp
        #endregion

        #region Tests

        [TestCaseSource(nameof(validateLengthExceptionTestCases))]
        public void ValidateLength_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(validateObjectExceptionTestCases))]
        public void ValidateObject_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(validateArrayExceptionTestCases))]
        public void ValidateArray_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(validateListExceptionTestCases))]
        public void ValidateList_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(validateStringNullOrWhiteSpaceExceptionTestCases))]
        public void ValidateStringNullOrWhiteSpace_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(validateStringNullOrEmptyExceptionTestCases))]
        public void ValidateStringNullOrEmpty_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(throwIfLessThanOneExceptionTestCases))]
        public void ThrowIfLessThanOne_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(throwIfFirstIsGreaterExceptionTestCases))]
        public void ThrowIfFirstIsGreater_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(throwIfFirstIsGreaterOrEqualExceptionTestCases))]
        public void ThrowIfFirstIsGreaterOrEqual_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(throwIfCountsAreNotEqualExceptionTestCases))]
        public void ThrowIfCountsAreNotEqual_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(throwIfModuloIsNotZeroExceptionTestCases))]
        public void ThrowIfModuloIsNotZero_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(throwIfFirstIsOlderOrEqualExceptionTestCases))]
        public void ThrowIfFirstIsOlderOrEqual_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void ValidateLength_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ValidateLength(ObjectMother.Validator_Length1),
                        () => Validator.ValidateLength<ArgumentException>(ObjectMother.Validator_Length1)
                    });

        [Test]
        public void ValidateObject_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ValidateObject(ObjectMother.Validator_Object1, ObjectMother.Validator_VariableName_Variable),
                        () => Validator.ValidateObject<ArgumentException>(ObjectMother.Validator_Object1, ObjectMother.Validator_VariableName_Variable)
                    });

        [Test]
        public void ValidateArray_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ValidateArray(ObjectMother.Validator_Array1, ObjectMother.Validator_VariableName_Variable)
                    });

        [Test]
        public void ValidateList_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ValidateList(ObjectMother.List1, ObjectMother.Validator_VariableName_Variable)
                    });

        [Test]
        public void ValidateStringNullOrWhiteSpace_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ValidateStringNullOrWhiteSpace(ObjectMother.Validator_String1, ObjectMother.Validator_VariableName_Variable)
                    });

        [TestCaseSource(nameof(validateStringNullOrEmptyTestCases))]
        public void ValidateStringNullOrEmpty_ShouldDoNothing_WhenProperArgument(string str)
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ValidateStringNullOrEmpty(str, ObjectMother.Validator_VariableName_Variable)
                    });

        [Test]
        public void ThrowIfFirstIsGreaterOrEqual_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ThrowIfFirstIsGreaterOrEqual(4, "n1", 5, "n2")
                    });

        [Test]
        public void ThrowIfFirstIsGreater_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ThrowIfFirstIsGreater(3, "n1", 4, "n2")
                    });

        [Test]
        public void ThrowIfLessThanOne_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ThrowIfLessThanOne(ObjectMother.Validator_Value, nameof(ObjectMother.Validator_Value))
                    });

        [Test]
        public void ThrowIfCountsAreNotEqual_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ThrowIfCountsAreNotEqual<Exception>(ObjectMother.Validator_SubScrapers_Proper)
                    });

        [Test]
        public void ThrowIfModuloIsNotZero_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ThrowIfModuloIsNotZero(
                                2,
                                ObjectMother.Validator_VariableName_N1,
                                1,
                                ObjectMother.Validator_VariableName_N2
                            )
                    });

        [Test]
        public void ThrowIfFirstIsOlderOrEqual_ShouldDoNothing_WhenProperArgument()
            => Method_ShouldDoNothing_WhenProperArgument(
                    new Action[] {
                        () => Validator.ThrowIfFirstIsOlderOrEqual(
                                ObjectMother.Validator_DateTimeNewer,
                                nameof(ObjectMother.Validator_DateTimeNewer),
                                ObjectMother.Validator_DateTimeOlder,
                                nameof(ObjectMother.Validator_DateTimeOlder)
                            )
                    });

        #endregion

        #region TearDown
        #endregion

        #region Support_methods
        
        public void Method_ShouldDoNothing_WhenProperArgument(Action[] actions)
        {

            try
            {

                // Arrange
                // Act
                foreach (Action action in actions)
                    action.Invoke();

            }
            catch (Exception ex)
            {

                // Assert
                Assert.Fail(ex.Message);

            }

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/
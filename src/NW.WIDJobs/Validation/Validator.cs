using System;
using System.Collections.Generic;
using System.Linq;
using NW.WIDJobs.Files;

namespace NW.WIDJobs
{
    /// <summary>Collects all the validation methods.</summary>
    public static class Validator
    {

        #region Methods_public

        public static void ValidateLength<T>(uint length) where T : Exception
        {

            if (length < 1)
                throw CreateException<T>(MessageCollection.Validator_VariableCantBeLessThanOne.Invoke(nameof(length)));

        }
        public static void ValidateLength(uint length)
            => ValidateLength<ArgumentException>(length);

        public static void ValidateObject<T>(object obj, string variableName) where T : Exception
        {

            if (obj == null)
                throw CreateException<T>(variableName);

        }
        public static void ValidateObject(object obj, string variableName)
            => ValidateObject<ArgumentNullException>(obj, variableName);

        public static void ValidateArray<U>(U[] arr, string variableName)
        {

            ValidateArrayNull<ArgumentNullException, U>(arr, variableName);
            ValidateArrayEmpty<ArgumentException, U>(arr, variableName);

        }
        public static void ValidateArrayNull<T, U>(U[] arr, string variableName) where T : Exception
        {

            if (arr == null)
                throw CreateException<T>(variableName);

        }
        public static void ValidateArrayEmpty<T, U>(U[] arr, string variableName) where T : Exception
        {

            if (arr.Length == 0)
                throw CreateException<T>(MessageCollection.Validator_VariableContainsZeroItems.Invoke(variableName));

        }

        public static void ValidateList<U>(List<U> list, string variableName)
        {

            ValidateListNull<ArgumentNullException, U>(list, variableName);
            ValidateListEmpty<ArgumentException, U>(list, variableName);

        }
        public static void ValidateListNull<T, U>(List<U> list, string variableName) where T : Exception
        {

            if (list == null)
                throw CreateException<ArgumentNullException>(variableName);

        }
        public static void ValidateListEmpty<T, U>(List<U> list, string variableName) where T : Exception
        {

            if (list.Count == 0)
                throw CreateException<ArgumentException>(MessageCollection.Validator_VariableContainsZeroItems.Invoke(variableName));

        }

        public static void ValidateStringNullOrWhiteSpace<T>(string str, string variableName) where T : Exception
        {

            if (string.IsNullOrWhiteSpace(str))
                throw CreateException<T>(variableName);

        }
        public static void ValidateStringNullOrWhiteSpace(string str, string variableName)
            => ValidateStringNullOrWhiteSpace<ArgumentNullException>(str, variableName);
        public static void ValidateStringNullOrEmpty<T>(string str, string variableName) where T : Exception
        {

            if (string.IsNullOrEmpty(str))
                throw CreateException<T>(variableName);

        }
        public static void ValidateStringNullOrEmpty(string str, string variableName)
            => ValidateStringNullOrEmpty<ArgumentNullException>(str, variableName);

        public static void ThrowIfFirstIsGreaterOrEqual<T>(int value1, string variableName1, int value2, string variableName2) where T : Exception
        {

            if (value1 >= value2)
                throw CreateException<T>(MessageCollection.Validator_FirstValueIsGreaterOrEqualThanSecondValue.Invoke(variableName1, variableName2));

        }
        public static void ThrowIfFirstIsGreaterOrEqual(int value1, string variableName1, int value2, string variableName2)
            => ThrowIfFirstIsGreaterOrEqual<ArgumentException>(value1, variableName1, value2, variableName2);
        public static void ThrowIfFirstIsGreater<T>(int value1, string variableName1, int value2, string variableName2) where T : Exception
        {

            if (value1 > value2)
                throw CreateException<T>(MessageCollection.Validator_FirstValueIsGreaterThanSecondValue.Invoke(variableName1, variableName2));

        }
        public static void ThrowIfFirstIsGreater(int value1, string variableName1, int value2, string variableName2)
            => ThrowIfFirstIsGreater<ArgumentException>(value1, variableName1, value2, variableName2);
        public static void ThrowIfLessThanOne<T>(uint value, string variableName) where T : Exception
        {

            if (value < 1)
                throw CreateException<T>(MessageCollection.Validator_VariableCantBeLessThanOne.Invoke(variableName));

        }
        public static void ThrowIfLessThanOne(uint value, string variableName)
            => ThrowIfLessThanOne<ArgumentException>(value, variableName);
        public static void ThrowIfModuloIsNotZero<T>(uint value1, string variableName1, uint value2, string variableName2) where T : Exception
        {

            if (value1 % value2 != 0)
                throw CreateException<T>(MessageCollection.Validator_DividingMustReturnWholeNumber.Invoke(variableName1, variableName2));

        }
        public static void ThrowIfModuloIsNotZero(uint value1, string variableName1, uint value2, string variableName2)
            => ThrowIfModuloIsNotZero<ArgumentException>(value1, variableName1, value2, variableName2);

        public static void ThrowIfCountsAreNotEqual<T>(Dictionary<string, int> lists) where T : Exception
        {

            int[] counts = lists.Select(item => item.Value).ToArray();
            bool status = AreAllEqual(counts);

            if (status == false)
                throw CreateException<T>(MessageCollection.Validator_AtLeastOneSubScraper.Invoke(lists));

        }
        public static void ThrowIfFirstIsOlderOrEqual<T>(DateTime dt1, string variableName1, DateTime dt2, string variableName2) where T : Exception
        {

            if (dt1 <= dt2)
                throw CreateException<T>(MessageCollection.Validator_FirstDateIsOlderOrEqual.Invoke(variableName1, variableName2));

        }
        public static void ThrowIfFirstIsOlderOrEqual(DateTime dt1, string variableName1, DateTime dt2, string variableName2)
            => ThrowIfFirstIsOlderOrEqual<ArgumentException>(dt1, variableName1, dt2, variableName2);

        public static void ValidateFileExistance<T>(IFileInfoAdapter file) where T : Exception
        {

            if (!file.Exists)
                throw CreateException<T>(MessageCollection.Validator_ProvidedPathDoesntExist.Invoke(file));

        }
        public static void ValidateFileExistance(IFileInfoAdapter file)
            => ValidateFileExistance<ArgumentException>(file);

        #endregion

        #region Methods_private

        private static T CreateException<T>(string message) where T : Exception
            => (T)Activator.CreateInstance(typeof(T), message);
        private static bool AreAllEqual(int[] integers)
            => Array.TrueForAll(integers, val => (integers[0] == val));

        #endregion

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 10.05.2021

*/
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NW.WIDJobsClient.UnitTests
{

    public static class ObjectMother
    {




        #region Mthod

        internal static void Method_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception objActual = Assert.Throws(expectedType, del);
            Assert.AreEqual(expectedMessage, objActual.Message);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 29.08.2021
*/
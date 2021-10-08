using NUnit.Framework;
using NW.WIDJobs.Database;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class RepositoryFactoryTests
    {

        #region Fields
        #endregion

        #region SetUp
        #endregion

        #region Tests

        [Test]
        public void RepositoryFactory_ShouldCreateAnObjectOfTypeRepositoryFactory_WhenInvoked()
        {

            // Arrange
            // Act
            RepositoryFactory actual = new RepositoryFactory();

            // Assert
            Assert.IsInstanceOf<RepositoryFactory>(actual);

        }

        [Test]
        public void Create_ShouldCreateAnObjectOfTypeIRepository_WhenInvoked()
        {

            // Arrange
            // Act
            IRepository actual
                = new RepositoryFactory()
                    .Create(
                        ObjectMother.DatabaseContext_DatabasePath,
                        ObjectMother.DatabaseContext_DatabaseName01,
                        false); // "false" because using "true" would attempt to create the database file.

            // Assert
            Assert.IsInstanceOf<IRepository>(actual);

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
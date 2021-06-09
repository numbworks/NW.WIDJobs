using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class RepositoryFactoryTests
    {

        // Fields
        // SetUp
        // Tests
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
                        ObjectMother.DatabaseContext_DatabaseName,
                        false); // "false" because using "true" would attempt to create the database file.

            // Assert
            Assert.IsInstanceOf<IRepository>(actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.06.2021
*/
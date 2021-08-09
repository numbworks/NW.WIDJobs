using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class MetricCollectionTests
    {

        // Fields
        private static TestCaseData[] metricCollectionExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollectionForJobPage01_RunId,
                                totalJobPages: ObjectMother.MetricCollectionForJobPage01_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollectionForJobPage01_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollectionForJobPage01_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollectionForJobPage01_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollectionForJobPage01_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollectionForJobPage01_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollectionForJobPage01_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollectionForJobPage01_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollectionForJobPage01_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollectionForJobPage01_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollectionForJobPage01_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceCityWithoutZone,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollectionForJobPage01_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollectionForJobPage01_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollectionForJobPage01_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollectionForJobPage01_JobPostingsByBulletPointScenario,
                                responseLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_PresentationLengthByJobPostingId,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollectionForJobPage01_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.MetricCollectionForJobPage01_TotalBulletPoints
                            )
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(metricCollectionExceptionTestCases))]
        public void MetricCollection_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void MetricCollection_ShouldInitializeANewMetricCollectionObject_WhenProperArguments()
        {

            // Arrange
            MetricCollection expected =
                new MetricCollection(
                        runId: ObjectMother.MetricCollectionForJobPage01_RunId,
                        totalJobPages: ObjectMother.MetricCollectionForJobPage01_TotalJobPages,
                        totalJobPostings: ObjectMother.MetricCollectionForJobPage01_TotalJobPostings,
                        jobPostingsByHiringOrgName: ObjectMother.MetricCollectionForJobPage01_JobPostingsByHiringOrgName,
                        jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceAddress,
                        jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlacePostalCode,
                        jobPostingsByWorkPlaceCity: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceCity,
                        jobPostingsByPostingCreated: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPostingCreated,
                        jobPostingsByLastDateApplication: ObjectMother.MetricCollectionForJobPage01_JobPostingsByLastDateApplication,
                        jobPostingsByRegion: ObjectMother.MetricCollectionForJobPage01_JobPostingsByRegion,
                        jobPostingsByMunicipality: ObjectMother.MetricCollectionForJobPage01_JobPostingsByMunicipality,
                        jobPostingsByCountry: ObjectMother.MetricCollectionForJobPage01_JobPostingsByCountry,
                        jobPostingsByEmploymentType: ObjectMother.MetricCollectionForJobPage01_JobPostingsByEmploymentType,
                        jobPostingsByWorkHours: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkHours,
                        jobPostingsByOccupation: ObjectMother.MetricCollectionForJobPage01_JobPostingsByOccupation,
                        jobPostingsByWorkplaceId: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkplaceId,
                        jobPostingsByOrganisationId: ObjectMother.MetricCollectionForJobPage01_JobPostingsByOrganisationId,
                        jobPostingsByHiringOrgCVR: ObjectMother.MetricCollectionForJobPage01_JobPostingsByHiringOrgCVR,
                        jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceCityWithoutZone,
                        jobPostingsByPublicationStartDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPublicationStartDate,
                        jobPostingsByPublicationEndDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPublicationEndDate,
                        jobPostingsByNumberToFill: ObjectMother.MetricCollectionForJobPage01_JobPostingsByNumberToFill,
                        jobPostingsByContactEmail: ObjectMother.MetricCollectionForJobPage01_JobPostingsByContactEmail,
                        jobPostingsByContactPersonName: ObjectMother.MetricCollectionForJobPage01_JobPostingsByContactPersonName,
                        jobPostingsByEmploymentDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByEmploymentDate,
                        jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByApplicationDeadlineDate,
                        jobPostingsByBulletPointScenario: ObjectMother.MetricCollectionForJobPage01_JobPostingsByBulletPointScenario,
                        responseLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_ResponseLengthByJobPostingId,
                        presentationLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_PresentationLengthByJobPostingId,
                        extendedResponseLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_ExtendedResponseLengthByJobPostingId,
                        hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_HiringOrgDescriptionLengthByJobPostingId,
                        purposeLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_PurposeLengthByJobPostingId,
                        bulletPointsByJobPostingId: ObjectMother.MetricCollectionForJobPage01_BulletPointsByJobPostingId,
                        totalBulletPoints: ObjectMother.MetricCollectionForJobPage01_TotalBulletPoints
                    );

            // Act
            MetricCollection actual =
                new MetricCollection(
                        runId: ObjectMother.MetricCollectionForJobPage01_RunId,
                        totalJobPages: ObjectMother.MetricCollectionForJobPage01_TotalJobPages,
                        totalJobPostings: ObjectMother.MetricCollectionForJobPage01_TotalJobPostings,
                        jobPostingsByHiringOrgName: ObjectMother.MetricCollectionForJobPage01_JobPostingsByHiringOrgName,
                        jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceAddress,
                        jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlacePostalCode,
                        jobPostingsByWorkPlaceCity: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceCity,
                        jobPostingsByPostingCreated: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPostingCreated,
                        jobPostingsByLastDateApplication: ObjectMother.MetricCollectionForJobPage01_JobPostingsByLastDateApplication,
                        jobPostingsByRegion: ObjectMother.MetricCollectionForJobPage01_JobPostingsByRegion,
                        jobPostingsByMunicipality: ObjectMother.MetricCollectionForJobPage01_JobPostingsByMunicipality,
                        jobPostingsByCountry: ObjectMother.MetricCollectionForJobPage01_JobPostingsByCountry,
                        jobPostingsByEmploymentType: ObjectMother.MetricCollectionForJobPage01_JobPostingsByEmploymentType,
                        jobPostingsByWorkHours: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkHours,
                        jobPostingsByOccupation: ObjectMother.MetricCollectionForJobPage01_JobPostingsByOccupation,
                        jobPostingsByWorkplaceId: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkplaceId,
                        jobPostingsByOrganisationId: ObjectMother.MetricCollectionForJobPage01_JobPostingsByOrganisationId,
                        jobPostingsByHiringOrgCVR: ObjectMother.MetricCollectionForJobPage01_JobPostingsByHiringOrgCVR,
                        jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollectionForJobPage01_JobPostingsByWorkPlaceCityWithoutZone,
                        jobPostingsByPublicationStartDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPublicationStartDate,
                        jobPostingsByPublicationEndDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByPublicationEndDate,
                        jobPostingsByNumberToFill: ObjectMother.MetricCollectionForJobPage01_JobPostingsByNumberToFill,
                        jobPostingsByContactEmail: ObjectMother.MetricCollectionForJobPage01_JobPostingsByContactEmail,
                        jobPostingsByContactPersonName: ObjectMother.MetricCollectionForJobPage01_JobPostingsByContactPersonName,
                        jobPostingsByEmploymentDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByEmploymentDate,
                        jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollectionForJobPage01_JobPostingsByApplicationDeadlineDate,
                        jobPostingsByBulletPointScenario: ObjectMother.MetricCollectionForJobPage01_JobPostingsByBulletPointScenario,
                        responseLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_ResponseLengthByJobPostingId,
                        presentationLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_PresentationLengthByJobPostingId,
                        extendedResponseLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_ExtendedResponseLengthByJobPostingId,
                        hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_HiringOrgDescriptionLengthByJobPostingId,
                        purposeLengthByJobPostingId: ObjectMother.MetricCollectionForJobPage01_PurposeLengthByJobPostingId,
                        bulletPointsByJobPostingId: ObjectMother.MetricCollectionForJobPage01_BulletPointsByJobPostingId,
                        totalBulletPoints: ObjectMother.MetricCollectionForJobPage01_TotalBulletPoints
                    );

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.08.2021
*/
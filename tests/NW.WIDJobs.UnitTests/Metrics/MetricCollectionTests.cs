using NUnit.Framework;
using System;
using NW.WIDJobs.Messages;
using NW.WIDJobs.Metrics;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class MetricCollectionTests
    {

        #region Fields

        private static TestCaseData[] metricCollectionExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: null,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: 0,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("totalJobPages")
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: 0,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("totalJobPostings")
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: null,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByHiringOrgName").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_04"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: null,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByWorkPlaceAddress").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_05"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: null,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByWorkPlacePostalCode").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_06"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: null,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByWorkPlaceCity").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_07"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: null,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByPostingCreated").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_08"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: null,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByLastDateApplication").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_09"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: null,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByRegion").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_10"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: null,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByMunicipality").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_11"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: null,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByCountry").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_12"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: null,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByEmploymentType").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_13"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: null,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByWorkHours").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_14"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: null,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByOccupation").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_15"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: null,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByWorkplaceId").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_16"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: null,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByOrganisationId").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_17"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: null,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByHiringOrgCVR").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_18"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: null,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsByWorkPlaceCityWithoutZone").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_19"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: null,
                                presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("responseLengthByJobPostingId").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_20"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollection(
                                runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                                totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                                totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                                jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                                jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                                jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                                jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                                jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                                jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                                jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                                jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                                jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                                jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                                jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                                jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                                jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                                jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                                jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                                jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                                responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                                presentationLengthByJobPostingId: null,
                                jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                                jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                                jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                                jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                                jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                                jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                                jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                                jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                                extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                                hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                                purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                                bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                                totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("presentationLengthByJobPostingId").Message
            ).SetArgDisplayNames($"{nameof(metricCollectionExceptionTestCases)}_21")

        };

        #endregion

        #region SetUp
        #endregion

        #region Tests

        [TestCaseSource(nameof(metricCollectionExceptionTestCases))]
        public void MetricCollection_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void MetricCollection_ShouldInitializeANewMetricCollectionObject_WhenBothRequiredAndOptionalArguments()
        {

            // Arrange
            // Act
            MetricCollection actual =
                new MetricCollection(
                        runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                        totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                        totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                        jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                        jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                        jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                        jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                        jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                        jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                        jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                        jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                        jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                        jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                        jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                        jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                        jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                        jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                        jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                        jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                        responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                        presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                        jobPostingsByPublicationStartDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                        jobPostingsByPublicationEndDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                        jobPostingsByNumberToFill: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                        jobPostingsByContactEmail: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                        jobPostingsByContactPersonName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                        jobPostingsByEmploymentDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                        jobPostingsByApplicationDeadlineDate: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                        jobPostingsByBulletPointScenario: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                        extendedResponseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                        hiringOrgDescriptionLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                        purposeLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                        bulletPointsByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                        totalBulletPoints: ObjectMother.Shared_ExplorationStage3_TotalBulletPoints
                    );

            // Assert
            Assert.IsInstanceOf<MetricCollection>(actual);

        }

        [Test]
        public void MetricCollection_ShouldInitializeANewMetricCollectionObject_WhenOnlyRequiredArguments()
        {

            // Arrange
            // Act
            MetricCollection actual =
                new MetricCollection(
                        runId: ObjectMother.MetricCollection_ExplorationStage3_RunId,
                        totalJobPages: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPages,
                        totalJobPostings: ObjectMother.MetricCollection_ExplorationStage3_TotalJobPostings,
                        jobPostingsByHiringOrgName: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                        jobPostingsByWorkPlaceAddress: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                        jobPostingsByWorkPlacePostalCode: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                        jobPostingsByWorkPlaceCity: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                        jobPostingsByPostingCreated: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                        jobPostingsByLastDateApplication: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                        jobPostingsByRegion: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByRegion,
                        jobPostingsByMunicipality: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                        jobPostingsByCountry: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByCountry,
                        jobPostingsByEmploymentType: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                        jobPostingsByWorkHours: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                        jobPostingsByOccupation: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                        jobPostingsByWorkplaceId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                        jobPostingsByOrganisationId: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                        jobPostingsByHiringOrgCVR: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                        jobPostingsByWorkPlaceCityWithoutZone: ObjectMother.MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                        responseLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                        presentationLengthByJobPostingId: ObjectMother.MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId
                    );

            // Assert
            Assert.IsInstanceOf<MetricCollection>(actual);

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
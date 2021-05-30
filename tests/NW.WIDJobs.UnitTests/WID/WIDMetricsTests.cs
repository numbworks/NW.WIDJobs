using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDMetricsTests
    {

        // Fields
        private static TestCaseData[] widMetricsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                null,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                0,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("totalPages")
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                0,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("totalItems")
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByWorkAreaWithoutZone").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_04"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByCreateDate").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_05"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByApplicationDate").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_06"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByEmployerName").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_07"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByEmployerName").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_08"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByNumberOfOpenings").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_09"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByAdvertisementPublishDate").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_10"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByAdvertisementPublishDate").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_11"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByApplicationDeadline").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_12"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByApplicationDeadline").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_13"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByStartDateOfEmployment").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_14"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByReference").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_15"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByPosition").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_16"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByTypeOfEmployment").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_17"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByContact").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_18"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                null,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByEmployerAddress").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_19"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                null,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("itemsByHowToApply").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_20"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                null,
                                ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("descriptionLengthByPageItemId").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_21"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                ObjectMother.Shared_FakeRunId,
                                2,
                                (uint)ObjectMother.Shared_Page01_PageItems.Count,
                                ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                                ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                                ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                                ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                                ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                                ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByReference,
                                ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                                ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                                ObjectMother.WIDMetrics_Page01_ItemsByContact,
                                ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                                ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                                ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                                null,
                                ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("bulletPointsByPageItemId").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_22")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(widMetricsExceptionTestCases))]
        public void WIDMetrics_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 30.05.2021
*/
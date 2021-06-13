using System.Collections.Generic;
using System.Linq;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IBulletPointManager"/>
    public class BulletPointManager : IBulletPointManager
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="BulletPointManager"/> instance.</summary>
        public BulletPointManager() { }

        #endregion

        #region Methods_public

        public List<BulletPoint> GetPreLabeledExamples()
        {

            List<BulletPoint> bulletPoints = new List<BulletPoint>();

            bulletPoints.AddRange(GetJobRequirementBulletPoints());
            bulletPoints.AddRange(GetJobDutyBulletPoints());

            return bulletPoints;

        }

        #endregion

        #region Methods_private

        private List<BulletPoint> GetJobRequirementBulletPoints()
        {

            List<string> texts = new List<string>();

            texts.Add("Engineering degree within acoustics & vibration");
            texts.Add("Detailed knowledge of material testing and dynamic vibration testing");
            texts.Add("Detailed knowledge within NVH data acquisition systems and electrodynamic test equipment");
            texts.Add("Detailed knowledge within test data analysis");
            texts.Add("Detailed knowledge in the field of signal analysis, material fatigue & sound transmission");
            texts.Add("Mechatronic experience is an advantage");
            texts.Add("Good English skills both written and oral");
            texts.Add("Ability to apply creative problem solving");
            texts.Add("Agile, customer-focused, and result-oriented");
            texts.Add("Good level with MS Office package");
            texts.Add("Able to keep agreements and stick to deadlines");
            texts.Add("Proactive and wants to make a difference");
            texts.Add("Organized and systematic mindset with great attention to detail");
            texts.Add("Team player");

            List<BulletPoint> bulletPoints
                = ConvertToBulletPoint(BulletPointLabels.JobRequirement, texts);

            return bulletPoints;

        }
        private List<BulletPoint> GetJobDutyBulletPoints()
        {

            List<string> texts = new List<string>();

            texts.Add("Flexible working hours are occasionally required");
            texts.Add("Setting up tests and data acquisition for NVH testing.");
            texts.Add("Carry out hot vibration testing on exhaust aftertreatment systems.");
            texts.Add("Analyze road load data and extract vibration profiles for subsequent use in vibration testing.");
            texts.Add("Continuous improvement and standardization of hot vibration testing.");
            texts.Add("Carry out various tests on heater/blower setup");
            texts.Add("Maintenance of hot shake test cell, flow rig and all related measuring equipment and hardware.");
            texts.Add("High focus on securing safety and usage of PPE (personal protective equipment)");
            texts.Add("Responsible for 5S and cleanliness in selected areas");
            texts.Add("Hourly registration");
            texts.Add("Be a good representative of the Test Center in relation to customers");
            texts.Add("Travel to Dinex test centres, customers, and engine test cell suppliers and field vehicle testing 5-10 days per year");

            List<BulletPoint> bulletPoints 
                = ConvertToBulletPoint(BulletPointLabels.JobDuty, texts);

            return bulletPoints;

        }
        private List<BulletPoint> ConvertToBulletPoint(BulletPointLabels label, List<string> texts)
        {

            List<BulletPoint> bulletPoints
                = texts.Select(
                    text => new BulletPoint(label.ToString(), text)).ToList();

            return bulletPoints;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/
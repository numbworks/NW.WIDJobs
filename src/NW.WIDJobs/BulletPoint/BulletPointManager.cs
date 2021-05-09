using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class BulletPointManager : IBulletPointManager
    {

        // Fields
        // Properties
        // Constructors
        public BulletPointManager() { }

        // Methods (public)
        public List<BulletPoint> GetLabeledBulletPoints()
        {

            List<BulletPoint> bulletPoints = new List<BulletPoint>();

            bulletPoints.Add(new BulletPoint("JobRequirement", "Engineering degree within acoustics & vibration"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Detailed knowledge of material testing and dynamic vibration testing"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Detailed knowledge within NVH data acquisition systems and electrodynamic test equipment"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Detailed knowledge within test data analysis"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Detailed knowledge in the field of signal analysis, material fatigue & sound transmission"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Mechatronic experience is an advantage"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Good English skills both written and oral"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Ability to apply creative problem solving"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Agile, customer-focused, and result-oriented"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Good level with MS Office package"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Able to keep agreements and stick to deadlines"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Proactive and wants to make a difference"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Organized and systematic mindset with great attention to detail"));
            bulletPoints.Add(new BulletPoint("JobRequirement", "Team player"));
            bulletPoints.Add(new BulletPoint("JobDuty", "Flexible working hours are occasionally required"));
            bulletPoints.Add(new BulletPoint("JobDuty", "Setting up tests and data acquisition for NVH testing."));
            bulletPoints.Add(new BulletPoint("JobDuty", "Carry out hot vibration testing on exhaust aftertreatment systems."));
            bulletPoints.Add(new BulletPoint("JobDuty", "Analyze road load data and extract vibration profiles for subsequent use in vibration testing."));
            bulletPoints.Add(new BulletPoint("JobDuty", "Continuous improvement and standardization of hot vibration testing."));
            bulletPoints.Add(new BulletPoint("JobDuty", "Carry out various tests on heater/blower setup"));
            bulletPoints.Add(new BulletPoint("JobDuty", "Maintenance of hot shake test cell, flow rig and all related measuring equipment and hardware."));
            bulletPoints.Add(new BulletPoint("JobDuty", "High focus on securing safety and usage of PPE (personal protective equipment)"));
            bulletPoints.Add(new BulletPoint("JobDuty", "Responsible for 5S and cleanliness in selected areas"));
            bulletPoints.Add(new BulletPoint("JobDuty", "Hourly registration"));
            bulletPoints.Add(new BulletPoint("JobDuty", "Be a good representative of the Test Center in relation to customers"));
            bulletPoints.Add(new BulletPoint("JobDuty", "Travel to Dinex test centres, customers, and engine test cell suppliers and field vehicle testing 5-10 days per year"));

            return bulletPoints;

        }

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/
using System.Collections.Generic;

namespace NW.WIDJobs.JobPostings
{
    /// <inheritdoc cref="IOccupationTranslator"/>
    public class OccupationTranslator : IOccupationTranslator
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="OccupationTranslator"/> instance.</summary>	
        public OccupationTranslator() { }

        #endregion

        #region Methods_public

        public string Translate(string occupation)
        {

            Dictionary<string, string> dict = InitializeDictionary();
            string translated = TryTranslate(occupation, dict);

            return translated;

        }

        #endregion

        #region Methods_private

        private Dictionary<string, string> InitializeDictionary()
        {

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {

                { "Ph.d., naturvidenskab og teknik", "PhD, science and engineering" },
                { "Kok", "Chef" },
                { "Rengøringsassistent", "Cleaning Assistent" },
                { "Lager- og logistikmedarbejder", "Warehouse and Logistics Employee" },
                { "Ph.d., sundhedsvidenskab", "PhD, Health Sciences" },
                { "Programmør og systemudvikler", "Programmer and Systems Developer" },
                { "Forsker, sundhedsvidenskab", "Researcher, Health Science" },
                { "Forsker, naturvidenskab og teknik", "Researcher, Science and Technology" },
                { "Rengøringsassistent, hotel", "Cleaning assistant, Hotel" },
                { "Tjener", "Serving" },
                { "Ph.d., samfundsvidenskab", "PhD, Social Sciences" },
                { "Studentermedhjælp", "Student Assistant" },
                { "Køkkenmedhjælper", "Kitchen Assistant" },
                { "Opvasker", "Dishwasher" },
                { "Produktionsmedarbejder", "Production Worker" },
                { "Kundeservicemedarbejder", "Customer Service Employee" },
                { "Forsker, samfundsvidenskab", "Researcher, Social Sciences" },
                { "Adjunkt, naturvidenskab og teknik", "Assistant Professor, Science and Technology" },
                { "Lektor", "Lecturer" },
                { "Professor, sundhedsvidenskab", "Professor, Health Sciences" },
                { "Adjunkt, samfundsvidenskab", "Assistant Professor, Social Sciences" },
                { "Projektleder", "Project Manager" },
                { "Restaurantchef", "Restaurant Manager" },
                { "Truckfører", "Truck Driver" },
                { "Marketingmedarbejder", "Marketing Employee" },
                { "Salgs- og kundeansvarlig", "Sales and Customer Manager" },
                { "Interviewer", "Interviewer" },
                { "Bartender", "Bartender" },
                { "Salgschef", "Sales Manager" },
                { "Salgskonsulent", "Sales Consultant" },
                { "Chauffør, fragt, distribution, blandet kørsel", "Chauffeur, Shipping, Distribution, Mixed Driving" },
                { "Seniorforsker, sundhedsvidenskab", "Senior Researcher, Health Sciences" },
                { "Omdeler", "Flyer Delivery" },
                { "Professor, naturvidenskab og teknik", "Professor, Science and Engineering" },
                { "Serveringsmedarbejder", "Serving Employee" },
                { "IT-ingeniør", "IT Engineer" },
                { "Testingeniør", "Test Engineer" },
                { "Specialkonsulent", "Special Consultant" },
                { "Kemiingeniør", "Chemical Engineer" },
                { "Køkkenchef", "Chef" },
                { "Butiksmedhjælper", "Shop Assistant" },
                { "IT-chef", "IT Manager" },
                { "Oldfrue", "Head Housekeeper" },
                { "Massør", "Masseuse" },
                { "Maskiningeniør", "Mechanical Engineer" },
                { "Laborant", "Laboratory Technician" },
                { "CNC-operatør", "CNC operator" },
                { "Cykelbud", "Bicycle Delivery" },
                { "IT-konsulent", "IT Consultant" },
                { "Forskningsassistent, samfundsvidenskab", "Research Assistant, Social Sciences" },
                { "Ekstern lektor, samfundsvidenskab", "External Associate Professor, Social Sciences" },
                { "Flyttearbejder", "Relocation Worker" },
                { "Chauffør, budtransport, køretøj under 3½ ton", "Driver, Courier Transport, Vehicle Under 3½ Tons" },
                { "Hotelmedarbejder", "Hotel Employee" },
                { "Afdelingsleder", "Department Manager" },
                { "Svejser", "Welder" },
                { "Automekaniker", "Car Mechanic" },
                { "Webudvikler", "Web Developer" },
                { "Civilingeniør", "Civil Engineer" },
                { "Post doc., naturvidenskab og teknik", "Post Doc., Science and Engineering" },
                { "Bygningsingeniør", "Construction Engineer" },
                { "Handicaphjælper", "Disability Helps" },
                { "Kvalitetsingeniør", "Quality Engineer" },
                { "Bageriarbejder", "Bakery Worker" },
                { "Bager", "Baker" },
                { "Rejsemontør, industri", "Construction Worker, Industry" },
                { "IT-projektleder", "IT Project Manager" },
                { "Assistant professor, naturvidenskab og teknik", "Assistant Professor, Science and Engineering" },
                { "Elektrotekniker", "Electrical Engineer" },
                { "Entreprenørmaskinemekaniker", "Construction Machine Mechanic" },
                { "Researcher, rekruttering", "Researcher, Recruitment" },
                { "Rengøringsassistent, industri", "Cleaning Assistant, Industry" },
                { "Renovationsarbejder", "Renovation Worker" },
                { "Eventtekniker", "Event Technician" },
                { "Servicetekniker", "Service Technician" },
                { "Servicetekniker, rengøring og ejendomsservice", "Service Technician, Cleaning and Real Estate Service" },
                { "Fuldmægtig", "Clerk" },
                { "Forskningsassistent, sundhedsvidenskab", "Research Assistant, Health Sciences" },
                { "Fotograf", "Photographer" },
                { "Projektmedarbejder", "Project Employee" },
                { "Receptionist, hotel", "Receptionist, Hotel" },
                { "Datakonsulent", "Computer Consultant" },
                { "Chauffør, specialtransport", "Driver, Special Transport" },
                { "Projektkoordinator", "Project Coordinator" },
                { "Receptionschef, hotel", "Reception Manager, Hotel" },
                { "Rengøringsassistent, hospital", "Cleaning Assistant, Hospital" },
                { "Elektroingeniør", "Electrical Engineer" },
                { "Rengøringsassistent i transportmidler", "Cleaning Assistant, Transport Industry" },
                { "Dækmontør", "Tire Fitter" },
                { "Ekspedient", "Clerk" },
                { "Shippingassistent", "Shipping Assistant" },
                { "Indkøber", "Purchasing" },
                { "Industritekniker", "Industrial Technician" },
                { "HR-konsulent", "HR Consultant" },
                { "Tandlæge", "Dentist" },
                { "Teknisk chef", "Technical Manager" },
                { "Tømrer", "Carpenter" },
                { "Webmaster", "Webmaster" },
                { "Smed", "Blacksmith" },
                { "Videnskabelig assistent, sundhedsvidenskab", "Scientific Assistant, Health Sciences" },
                { "Uddannelsesleder", "Head of Education" },
                { "Videnskabelig assistent, naturvidenskab og teknik", "Scientific Assistant, Science and Engineering" },
                { "Softwareudvikler, frontend", "Software Developer, Frontend" },
                { "Specialarbejder, medicinal", "Specialist, Medicinal" },
                { "Landmand", "Farmer" },
                { "Sikkerhedsmedarbejder, vagt, sikkerhed og overvågning,", "Security Guard, Guard, Security and Surveillance," },
                { "Slagteriarbejder", "Slaughterhouse Worker" },
                { "Fundraiser", "Fundraiser" },
                { "Systemadministrator", "System Administrator" },
                { "Tandklinikassistent", "Dental Clinic Assistant" },
                { "HR-assistent", "HR Assistant" },
                { "Speditør", "Freight forwarder" },
                { "Fysiker", "Physicist" },
                { "Logistikchef", "Logistics Manager" },
                { "Læge", "Doctor" },
                { "Lektor, samfundsvidenskab", "Associate Professor, Social Sciences" },
                { "Bryggeriarbejder", "Brewery worker" },
                { "Account manager", "Account manager" },
                { "Marketingchef", "Marketing Manager" },
                { "Maskinmester", "Engineer" },
                { "Afdelingschef", "Head of Department" },
                { "Adjunkt, sundhedsvidenskab", "Assistant Professor, Health Sciences" },
                { "Adjunkt", "Assistant Professor" },
                { "Maskinfører", "Machine Operator" },
                { "IT-supporter", "IT Support" },
                { "IT-tekniker", "IT Technician" },
                { "IT-sikkerhedskonsulent", "IT Security Consultant" },
                { "IT-arkitekt", "IT Architect" },
                { "IT-kvalitetsmedarbejder", "IT Quality Assurance" },
                { "Jurist", "Lawyer" },
                { "Landbrugselev", "Agricultural Student" },
                { "Landbrugsmedhjælper", "Agricultural assistant" },
                { "Lagerekspedient", "Warehouse Clerk" },
                { "Kommunikationsmedarbejder", "Communication Employee" },
                { "Kvalitetsmedarbejder", "Quality Employee" },
                { "Multimediedesigner", "Multimedia Designer" },
                { "Procesingeniør", "Process Engineer" },
                { "Businesscontroller", "Business Controller" },
                { "Post doc., sundhedsvidenskab", "Post Doc., Health Sciences" },
                { "Brolæggerarbejde", "Paving Work" },
                { "Post doc., samfundsvidenskab", "Post Doc., Social Sciences" },
                { "Produktionstekniker", "Production Technician" },
                { "Professor, samfundsvidenskab", "Professor, Social Sciences" },
                { "Chauffør, dyretransport", "Driver, Animal Transport" },
                { "Byggeleder", "Construction Manager" },
                { "Produktionsteknolog", "Production Technologist" },
                { "Professor", "Professor" },
                { "Pakkerimedarbejder", "Packaging Worker" },
                { "Pedelmedhjælper", "Caretaker Assistant" },
                { "Associate professor, samfundsvidenskab", "Associate Professor, Social Sciences" },
                { "Assistant professor, humaniora", "Assistant Professor, Humanities" },
                { "Associate professor, naturvidenskab og teknik", "Associate Professor, Science and Engineering" },
                { "Personalechef", "Personnel Manager" },
                { "Biolog", "Biologist" },
                { "Pizzabager", "Pizza Baker" },
                { "Av tekniker", "AV Technician" },
                { "Automationsingeniør", "Automation Engineer" },
                { "Ph.d., professionshøjskole og erhvervsakademi", "PhD, Vocational College and Business Academy " }

            };

            return dict;

        }
        private string TryTranslate(string occupation, Dictionary<string, string> dict)
        {

            try
            {

                return dict[occupation];

            }
            catch
            {

                return occupation;

            }

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.09.2021
*/
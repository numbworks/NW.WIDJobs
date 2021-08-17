using System.Collections.Generic;
using System.Linq;

namespace NW.WIDJobs.BulletPoints
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

            bulletPoints.AddRange(GetJobDutyBulletPoints());
            bulletPoints.AddRange(GetJobRequirementBulletPoints());
            bulletPoints.AddRange(GetJobTechnologyBulletPoints());
            bulletPoints.AddRange(GetJobBenefitBulletPoints());

            return bulletPoints;

        }

        #endregion

        #region Methods_private

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
            texts.Add("Development of IT-solutions and -systems.");
            texts.Add("Identifying and implementing solutions for specific requirements that support the business development of Rains globally.");
            texts.Add("Experience working with standard systems, still understanding the need for internal programming adjustments - both for the general system setup and programming / coding of internal utilities / helping programs for specific tasks.");
            texts.Add("Finding the right solutions with internal stakeholders and external cooperation partners.");
            texts.Add("Project management, operational support, optimization and integration of systems.");
            texts.Add("IT support, including solving technical IT issues.");
            texts.Add("to design banners, mailer kits and the like related to the aforementioned");
            texts.Add("designing and setting up websites and new concepts");
            texts.Add("to some extend; SoMe initiatives, launch and manage them");
            texts.Add("Assist customers with front-end design and implementation of Queue-it customer queue pages (for web/mobile/tablets) using HTML5, responsive design, and mobile experience (Check out examples at:queue-it.com/waiting-room-gallery)");
            texts.Add("Collaborate with other technology and sales team members to deliver on customer design, vision, and implementation");
            texts.Add("Engage directly with customers regarding front-end design projects");
            texts.Add("Collaborate with the team to continuously improve our design toolbox");
            texts.Add("Establish the programming vision for the entire project, in line with the Game Director’s vision");
            texts.Add("Throughout the duration of the project you will update and adjust the roadmap according to project progress and changes, with the aim of keeping agreed scope and deadlines. Your goal is to ensure the technology roadmap is successfully implemented – and you will reach this by setting the group of Technical Team Leads up for success.");
            texts.Add("Provide and updatehigh-level estimates for all areas of the game to theExecutive Producer and help with prioritization");
            texts.Add("Ensure the tech vision for the project is aligned with the studio’s overall tech vision, by coordinating with the CTO and Tech Directors for other projects");
            texts.Add("Evangelize the technical direction of the entire project internally as well as externally");
            texts.Add("Coordinate the technical direction of the individual development teams with the Technical Team Leads");
            texts.Add("Establish coding best practices and follow up with lead and senior programmers to make sure that these requirements are met");
            texts.Add("Use your analytical mind and ability to synthesize ideas and requirements to develop solutions");
            texts.Add("Provide clear direction and feedback to the employees working on the programming areas of the project (for example, through task force sprint kick-off and review meetings)");
            texts.Add("Work in collaboration with directors and leads of other disciplines to determine the technological needs of the project in conjunction with constraints and project requirements");
            texts.Add("Provide coaching and mentoring for the programming team");
            texts.Add("Participate in the interview process for the programming team");
            texts.Add("Bring input to employees’ performance review process");
            texts.Add("As a member of the Tools and Engine team, you will get responsibility for a part of our toolset and pipelines.");
            texts.Add("Glacier includes a WYSIWIG editor that allows content creators to set up the game efficiently. As part of the team, you will design and implement (C++ and C#) improvements to this editor and the associated tools.");
            texts.Add("Support in developing the protein production platform in yeast ");
            texts.Add("Support the downstream processing from the yeast platform ");
            texts.Add("Support and maintenance of yeast fermentation processes, and resolve arising technical issues ");
            texts.Add("Support in developing, installing, and maintaining analytical equipment ");
            texts.Add("Train project students and new employees on sample preparation, protocols and use of equipment. ");
            texts.Add("Resolve forthcoming problems and ensure the lab is in a good condition ");
            texts.Add("Improve our core billing system according to the needs of the Management team, the Finance department, and the controlling function");
            texts.Add("Ongoing development of the solution to fit our strategic needs, with a focus on relevant reporting and support of key customer lifetime workflows");
            texts.Add("Deliver features according to agreed content and timeline while ensuring high quality code");
            texts.Add("Support developing reports for sales, marketing, and customer experience");
            texts.Add("Support relevant functionality by coding standard reports for international parts of the organisation");
            texts.Add("Document new system features");
            texts.Add("Ensure high system performance");
            texts.Add("Make it easy for users to access relevant information in the solution");
            texts.Add("Collaborate with designers and testers to ensure high quality in UI and data validity");
            texts.Add("Share technical knowledge internally in the development team");
            texts.Add("Full-stack developer");
            texts.Add("Establishment of SW architecture, design specifications and other documentation for this platform.");
            texts.Add("Developing Linux drivers for Comcores system designs");
            texts.Add("Create Interfaces to FPGA");
            texts.Add("Create test environment with scripts");
            texts.Add("Assist in partner integration and customer support");
            texts.Add("Improve the quality of Noie’s customer-facing platform as well as work with analytics and other internal tools");
            texts.Add("Improve current tech stack and tools");
            texts.Add("Automated testing");
            texts.Add("Improve application performance");
            texts.Add("Design mobile-based features");
            texts.Add("Get feedback from, and build solutions for, users and customers");
            texts.Add("Stay up-to-date on emerging technologies");
            texts.Add("Creating and using wide variety of API integrations");
            texts.Add("Improving the quality of Noie’s customer-facing platform as well as work with analytics and other internal tools");
            texts.Add("Automated testing, Continues Delivery and Continuous Integration strategies and implementation");
            texts.Add("Improving the application performance");
            texts.Add("Getting feedback from, and building solutions for, users and customers");
            texts.Add("Container orchestration in embedded devices");
            texts.Add("Cyber security");
            texts.Add("Reading hardware diagrams, perform hardware bring-up and debugging");
            texts.Add("Work closely with the project management team, UI team and other developers to design, prototype, test and improve the application");
            texts.Add("Write unit and e2e tests for new functionality");
            texts.Add("Participate in our GAN UI shared components library development");
            texts.Add("Be part of our Frontend bi-weekly meeting where you can contribute solving current challenges and propose new and better ways of doing things and improve the project");
            texts.Add("Agree with the Backend team on the REST API contracts");
            texts.Add("Play an important role in promoting and implementing best practices");
            texts.Add("Optimize the application for maximum performance");
            texts.Add("Sparring and peer-reviewing of code with colleagues in the R&D team");
            texts.Add("Setting up technical plans and contribute to our technical architecture");
            texts.Add("Starting and building a public API that developers around the world will use");
            texts.Add("Setting high standards for testing en setup best practices");
            texts.Add("Develop contribution guidelines for other engineers");
            texts.Add("Settings up a continuous integration pipeline to be able to ship code as often as possible");
            texts.Add("Continue developing and facilitating training and certification programs for Bizzkit Academy by producing PowerPoint slide decks, sample code, tutorials etc.");
            texts.Add("Work with a combination of workshops, classroom training and e-learning to engage the developers and architects from our solution partners");
            texts.Add("Create documentation, tutorials, videos etc. for our documentation space");
            texts.Add("Keep track on the architecture, workflow and development of the platform products and adjust training material accordingly");
            texts.Add("Support sales regarding the functionality of the products in Bizzkit Academy");
            texts.Add("Collaborate with product management, developers, technical support and sales.");
            texts.Add("Play a key role in defining architecture for our Ethernet switching solutions for TSN and make sure that it all adds up to solutions with the right market attractiveness.");
            texts.Add("Design and architect IP, systems and demo platforms solutions that will enable us to show new technology applications in various verticals.");
            texts.Add("Responsible for providing input for roadmap priorities covering all aspects of required IP as well SW requirements.");
            texts.Add("Translate customer challenges into technical solution proposals and on that basis secure that we develop the exact right thing.");
            texts.Add("Technical guru participating in sales interaction with customers and partners, demonstrating reference platforms and working with our sales people and customers at both technical and business level to show how Comcores´ TSN Ethernet solutions can provide value to customers organization.");
            texts.Add("The opportunity to extend and improve the user interface and user experience of our web applications");
            texts.Add("Create mockups, collect usage data, analyse and discuss options with peers and stakeholders");
            texts.Add("Help out with backend tasks if you need a distraction from the UI");
            texts.Add("Work with a diverse group of passionate, professional, and agile software engineers");
            texts.Add("Introduce customers to the product and its capabilities through demo and technical Q&A");
            texts.Add("Provide technical guidance for integrating and optimizing product use");
            texts.Add("Translate complex use cases and apply an in-depth understanding of various technology platforms and languages to prescribe the best integration strategy");
            texts.Add("Collaborate with customers and external technology partners, as well as our team of Solutions Architects, Designers, Developers, and Account Executives to ensure successful delivery and integration of our product");

            List<BulletPoint> bulletPoints
                = ConvertToBulletPoints(BulletPointLabels.JobDuty, texts);

            return bulletPoints;

        }
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
            texts.Add("Able to keep agreements and stick to deadlines");
            texts.Add("Proactive and wants to make a difference");
            texts.Add("Organized and systematic mindset with great attention to detail");
            texts.Add("Team player");
            texts.Add("Some years of experience working as a system developer.");
            texts.Add("Programming and most likely with a relevant IT educational background.");
            texts.Add("Preferable experience from a position with similar tasks.");
            texts.Add("You have technical and IT skills making it easy to acquire knowledge and overview regarding various systems and system setups.");
            texts.Add("Written and spoken Danish and English fluently.");
            texts.Add("You are a team player with strong communication skills.");
            texts.Add("You are structured and self-driven.");
            texts.Add("You are informal, easy going, persistent and with a high energy level.");
            texts.Add("You must be able to deep dive into technical and business details, still focused on the big picture.");
            texts.Add("An attractive and very interesting job in a young and fast-growing company.");
            texts.Add("A job where you will play a central role on the growth journey of the company.");
            texts.Add("is currently pursuing an education in Web Design, Computer Science, Multimedia Design, Information Technology or already educated in similar industries");
            texts.Add("is a quick learner, efficient and agile in any area of ​​IT and understands that all tasks are urgent and with short deadlines");
            texts.Add("can work with many different types of tasks, even outside normal work areas");
            texts.Add("has any in-depth knowledge of frontend and backend technologies");
            texts.Add("have knowledge of Online Marketing in general");
            texts.Add("has a little experience with SoMe");
            texts.Add("be able to speak, write and understand high level English");
            texts.Add("be flexible enough to be able to access tasks within 24 hours on normal workdays");
            texts.Add("behighly efficientand produce high volume of material,whilst keeping to a min. quality standard");
            texts.Add("spend more than 50 (efficient) hours working each month");
            texts.Add("Documented experience with creating design solutions with a high visual impact");
            texts.Add("A portfolio that showcases your excellent graphic design skills");
            texts.Add("Strong and creative graphic design skills.");
            texts.Add("UI/UX is your true passion, and you are an expert within the field");
            texts.Add("Proactive, self-starter, flexible, and results-oriented");
            texts.Add("Excited about the web, new technology, and design trends");
            texts.Add("A natural when it comes to engaging with customers");
            texts.Add("Identify and design business processes for automation with the Product Owner and other stakeholders");
            texts.Add("Setting up, testing and monitoring automated workflows to ensure that business processes function at optimum efficiency without risk of error");
            texts.Add("Monitoring and maintaining automation post-implementation and resolving any potential issues to ensure smooth business operations");
            texts.Add("Producing process documentation in order to outline mistakes and successes and refine processes going forward");
            texts.Add("Ensure quality automation using Quality Assurance (QA) processes and prevent any potential bugs");
            texts.Add("Willingness to learn and become an expert in RPA and other automation technologies");
            texts.Add("Comfortable interacting with business stakeholders and external clients");
            texts.Add("Ability to work to deadlines and manage expectations");
            texts.Add("Strong analytical and problem-solving skills");
            texts.Add("Excellent written and verbal communication");
            texts.Add("Attention to detail");
            texts.Add("A Ph.D. in molecular biology, immunology or similar ");
            texts.Add("Solid hands-on experience with molecular and immunological techniques such as immune-based assays, LFA development, SPR, RT-qPCR and sequencing ");
            texts.Add("Several years of experience with method development, assay optimization, validation and implementation ");
            texts.Add("A strong mindset for working quality assured ");
            texts.Add("Experience with independent project coordination and budgeting ");
            texts.Add("Experience with coordinating the work of laboratory technicians ");
            texts.Add("Excellent collaboration skills ");
            texts.Add("Efficient and solution-oriented ");
            texts.Add("Excellent oral and written English communication skills");
            texts.Add("You have at least 5 years of experience as a lead programmer or a comparable technical leadership role");
            texts.Add("Thorough experience working on at least one multiplayer, AAA title");
            texts.Add("Proven track record of game programming experience from various projects");
            texts.Add("Provide leadership and cultivate a strong sense of ownership and accountability");
            texts.Add("Profound knowledge of technological constraints on various platforms");
            texts.Add("Experienced with general and platform specific game and engine optimizations");
            texts.Add("You need to be very proactive, support the rest of game management to establish systems for planning, reporting, and controlling various aspects of programming, and willing to work hands-on to achieve goals in time");
            texts.Add("Cross-platform development experience");
            texts.Add("Strong communication skills");
            texts.Add("Multiplayer/networking programming experience on a AAA title");
            texts.Add("University diploma in programming, computer engineering, software engineering or equivalent");
            texts.Add("Ability to break down, estimate own tasks, and take part in assessing other tasks as well.");
            texts.Add("Good collaboration skills and the ability to figure out what users “really” want.");
            texts.Add("Bachelor in Computer Science or equivalent. A Master’s degree will be an advantage.");
            texts.Add("Professional tools programming experience on AAA title(s).");
            texts.Add("Understanding of content pipelines for game production.");
            texts.Add("Experience with agile methodologies.");
            texts.Add("Have good basic knowledge of biotechnology and bioprocesses. ");
            texts.Add("Have experience with fermentation processes ");
            texts.Add("Some experience with protein purification systems is an advantage ");
            texts.Add("Are service-minded, flexible and thrive by conveying knowledge and good practices to others. ");
            texts.Add("Have good sense of order and like to help with the daily maintenance, ensuring the (GMO certified) laboratory is in nice and tidy condition. ");
            texts.Add("Are a person with a positive mindset and with very good planning, prioritizing and organizational skills. ");
            texts.Add("High level in English");
            texts.Add("3 years of experience in development");
            texts.Add("You have a high proficiency in English, both written and spoken");
            texts.Add("A university degree");
            texts.Add("You are good at math and love number");
            texts.Add("Azure, cloud programming, and integrations");
            texts.Add("Financial applications, such as billing systems and processes in a SaaS business");
            texts.Add("You willbecomea valuedpart of our Product Development team inCopenhagen");
            texts.Add("A dynamic high growth environment");
            texts.Add("We prioritise work-life balance including health initiatives and flexible work structures");
            texts.Add("Company-wide & team building activities, optional mindfulness at work, and more");
            texts.Add("Career development and growth");
            texts.Add("Competitive benefits and 6 weeks of holiday");
            texts.Add("Online onboarding- due to Corona you will work from home until restrictions change");
            texts.Add("Master or BSc in Software Engineering, Computer Science, Network Technology or equivalent");
            texts.Add("More than 7-10 years of working experience as a software developer");
            texts.Add("Knowledge about computer networking technologies is an advantage,");
            texts.Add("Personally, you are focused, systematic and solution-oriented person that manage to transform your skills into action");
            texts.Add("You feel motivated by being the best within your field and like to work with the newest technologies");
            texts.Add("Written and spoken English at high level.");
            texts.Add("Familiarity with automated testing from a front-end perspective");
            texts.Add("In-depth understanding of the process of web development (design, development and deployment)");
            texts.Add("Knowledge of SEO principles");
            texts.Add("An ability to perform well in a fast-paced environment");
            texts.Add("Have extensive experience with embedded software development");
            texts.Add("Have experience with software architecture, design documentation and development complying to relevant standards");
            texts.Add("Can write requirement and test specifications");
            texts.Add("Have working knowledge of medical device software standards (IEC 62304 and IEC 82304)");
            texts.Add("Have an academic degree in Computer Science, Electrical Engineering, or equivalent");
            texts.Add("The ability to adapt to a rapidly growing business in an emerging space");
            texts.Add("Be an awesome team-mate in a multicultural team");
            texts.Add("A best practices promoter and advocate, not accepting an “It works for me” attitude");
            texts.Add("Experience with client-side compatibility and performance considerations");
            texts.Add("Being a team player is a must, but you should also be comfortable with working independently on delivering and shipping code");
            texts.Add("Superior communication and listening skills");
            texts.Add("High ethical standards and demonstrate transparency about everything you do");
            texts.Add("Values consistent with ours i.e. we expect individuals to work hard, have integrity, be a team player and be an authentic contributor to our team");
            texts.Add("A natural curiosity and the ability to see and help to resolve issues");
            texts.Add("A level of self-awareness which enables you to positively collaborate with both your GAN colleagues and customers");
            texts.Add("You have 4+ years of industry experience in a software engineering role");
            texts.Add("You have practical experience of automatic testing concepts and setting up a good iOS test suite");
            texts.Add("You are a natural at working collaboratively, listening to others, and voicing your own ideas");
            texts.Add("You are curious, like to experiment with new ideas, and enjoy solving problems");
            texts.Add("You appreciate the same core values as us: Transparency, Inclusion, and Encouragement");
            texts.Add("You are supportive and encouraging by nature, strive to be the best version of yourself and lift those around you up");
            texts.Add("Working in a team comes naturally to you, you are easy to work with and value others' input");
            texts.Add("You want to make a difference where you work. You are eager to contribute to a positive and productive work environment, and grow your career in a hyper-growth company!");
            texts.Add("ES6+ syntax and best practises");
            texts.Add("Component design practises");
            texts.Add("Strong analytical and problem-solving skills");
            texts.Add("Great leadership and mentoring skills");
            texts.Add("Excellent English communication skills");
            texts.Add("Are a dedicated gamer like us");
            texts.Add("Have experience with subscription-based applications/businesses");
            texts.Add("Have experience with automated testing suites");
            texts.Add("Like playing video games with your friends and colleagues");
            texts.Add("Master or BSc in Engineering with a Network Technology profile or equivalent");
            texts.Add("More than 10 years of working experience as a VHDL/Verilog designer");
            texts.Add("You work with Ethernet technologies today and have a solid insight into Ethernet standards such as IEEE 802.3 and IEEE802.1Q");
            texts.Add("Knowledge about wireless systems and technologies is an advantage");
            texts.Add("Personally, you are focused, systematic and solution-oriented person that manage to transform your skills into action");
            texts.Add("You feel motivated by being the best within your field and like to work with the newest technologies");
            texts.Add("Experience with, customer interaction is an advantage");
            texts.Add("Written and spoken English at high level.");
            texts.Add("Minimum 4 years experience in software development");
            texts.Add("Solid English communication skills, both written and verbal (Danish not required)");
            texts.Add("You like taking initiative and bring tasks to completion");
            texts.Add("Excited about agile software development and cloud computing");
            texts.Add("Can work independently, but know that it is a team effort");
            texts.Add("Technical education or bachelor’s degree (in engineering, for example) would be an advantage");
            texts.Add("10+ years’ of working with extensive web application development or architecture");
            texts.Add("Experience with CDNs such as Akamai, CloudFlare and CloudFRont considered a plus");
            texts.Add("In-depth knowledge of high-performance website optimization techniques commonly used in ecommerce platforms and/or ticketing software, such as caching, load balancing, etc.");
            texts.Add("Experience with large strategic enterprise clients and market leaders considered a plus");
            texts.Add("Ability to interface at all levels in an organization, particularly at the Executive level from Marketing, Sales, IT and Development");
            texts.Add("Great troubleshooting and analytical skills");
            texts.Add("Project management skills and proficiency in handling multiple projects and customers simultaneously");
            texts.Add("Excellent written and verbal communication skills in English (Danish not required)");
            texts.Add("Bachelor’s degree (or equivalent education or experience)");
            texts.Add("Genuine excitement to help customers and solve problems");
            texts.Add("You are energized by teamwork and are committed to delivering a world-class customer experience");

            List<BulletPoint> bulletPoints
                = ConvertToBulletPoints(BulletPointLabels.JobRequirement, texts);

            return bulletPoints;

        }
        private List<BulletPoint> GetJobTechnologyBulletPoints()
        {

            List<string> texts = new List<string>();

            texts.Add("Good level with MS Office package");
            texts.Add("is an expert in HTML/CSS");
            texts.Add("have a min 8/10experience with Photoshop");
            texts.Add("is an expert inHTML5, CSS3");
            texts.Add("knows a little Javascript (JS)");
            texts.Add("familiar with Google Suite (docs, sheets, etc.)");
            texts.Add("3+ years experience with HTML, CSS, and graphic design");
            texts.Add("1+ years experience with JavaScript / jQuery and MS Visual Studio");
            texts.Add("2-3 years experience from a similar position");
            texts.Add("High proficiency in Adobe CC (XD, Photoshop, Illustrator), Figma and/or other interfacedesign tools.");
            texts.Add("Mastery of Automation tools, such as UiPath, Kyron. Blue Prism, UI Automation");
            texts.Add("Proficiency in scripting languages, such as Python, Perl, VB");
            texts.Add("Experience with Databases, such as Postgres SQL and NoSQL");
            texts.Add("Deep knowledge in C++ and C# languages and system architecture");
            texts.Add("Strong knowledge of C++, but also knowledge of C/C#and code design.");
            texts.Add("C#, ASP.Net, Web API, Typescript, Javascript, Knockout js, HTML, CSS, Microsoft SQL, Entity Framework");
            texts.Add("Several years of experience with software development in C");
            texts.Add("Experience developing software in for Linux environment");
            texts.Add("Great knowledge and experience with Javascript, CSS and HTML in general");
            texts.Add("Good knowledge of VUE, NodeJS, React or other frameworks of the same nature that could be applicable when scaling Noie going forward - we currently use VUE in our setup");
            texts.Add("Knowledge of Continuous Integration, Continuous Delivery, Git and Docker is a definite plus");
            texts.Add("AWS Lambda and AWS in general");
            texts.Add("Database design, currently PostgreSQL");
            texts.Add("Are an experienced C/C++ programmer");
            texts.Add("BSP development and cross-compiling in systems like Yocto.");
            texts.Add("Linux kernel and driver development");
            texts.Add("Linux application development and use of the GNU toolchain");
            texts.Add("Bootloaders like U-Boot, barebox, EFI etc.");
            texts.Add("5+ years of experience with Javascript");
            texts.Add("Experience with Typescript");
            texts.Add("Experience with Rxjs and withngrx is a plus");
            texts.Add("Experience in working with REST APIs and JSON");
            texts.Add("Good knowledge of testing frameworks for JavaScript and testing in general");
            texts.Add("Develop new features using Angular 10");
            texts.Add("Proficient understanding of code versioning tools such as Git");
            texts.Add("Building the foundation for an iOS SDK that other developers will use");
            texts.Add("Adding new features and APIs to a new iOS Messenger SDK");
            texts.Add("You have a solid knowledge of Swift or Objective-C and iOS APIs");
            texts.Add("Python");
            texts.Add("Javascript");
            texts.Add("React-native");
            texts.Add("React.js");
            texts.Add("PostgreSQL");
            texts.Add("Chef");
            texts.Add("Docker");
            texts.Add("HTML/CSS");
            texts.Add("React Native");
            texts.Add("JavaScript/TypeScript");
            texts.Add("Redux");
            texts.Add("Axios");
            texts.Add("Git / Github");
            texts.Add("Native build tools, like XCode & Android Studio");
            texts.Add("Have experience with Node.js");
            texts.Add("Have experience with GraphQL as we want to transition our API(s) into GraphQL");
            texts.Add("Frontend: Vue.js / Nuxt.js");
            texts.Add("Backend: Laravel / Eloquent");
            texts.Add("Database: MySQL / MariaDB");
            texts.Add("Infrastructure: AWS/Laravel Vapor (Serverless)");
            texts.Add("Small projects: Discord bot built in Node.js (Hosted on Heroku)");
            texts.Add("Native App: React Native");
            texts.Add("Storefront / Landing Pages: WordPress/Gatsby.js");
            texts.Add("Use the best tool for the job and work with a broad range of best-in-class technologies such as Angular, TypeScript, CSS, HTML, .Net Core and more (see our stack)");
            texts.Add("Minimum 3 years experience with Angular, or similar framework");
            texts.Add("Ability to work in such tools as TypeScript, C#,Extreme Programming, Test Driven Development (TDD) and agile processes");
            texts.Add("Experience with programming frameworks in general is preferred (specifically, JavaScript and .NET, JAVA or PHP skills will be an advantage)");
            texts.Add("Experience with ecommerce platforms, such as SAP Hybris, Magento, Shopify etc. and/or ticketing technology considered a plus");

            List<BulletPoint> bulletPoints
                = ConvertToBulletPoints(BulletPointLabels.JobTechnology, texts);

            return bulletPoints;

        }
        private List<BulletPoint> GetJobBenefitBulletPoints()
        {

            List<string> texts = new List<string>();

            texts.Add("insight into an innovative company that is passionate about many different online industries");
            texts.Add("a lot of young and social colleagues, in an extremely laissez faire -work environment");
            texts.Add("the opportunity to work from home as well as in the office in the center of Aalborg");
            texts.Add("Competitive salary, plus share/stock options.");
            texts.Add("Excellent growth opportunities.");
            texts.Add("Work with an amazing team of talented and motivated people who love their work.");
            texts.Add("Flexible working hours.");
            texts.Add("Contribute to a truly important cause - work with purpose.");
            texts.Add("A real impact on the company’s growth and evolution.");
            texts.Add("Great office space and central location in the heart of Copenhagen near Kgs. Have.");
            texts.Add("Social activities: quizzes, movie nights, DHL run, Friday bars, office parties and much, much more (well - some of this currently somewhat modified to be COVID-19 safe!)");
            texts.Add("Amazing lunch, free soft drinks, fruit, snacks and great coffee.");
            texts.Add("We offer a versatile and challenging job opportunity in an international work environment.");
            texts.Add("We have a flat organizational structure with room for entrepreneurship, initiative and creativity.");
            texts.Add("Our benefits are competitive.");
            texts.Add("Comcores is growing fast and internationally, which will give you the unique possibility to work with an international talent pool.");
            texts.Add("A great team to work with that consists of highly educated technology and software engineering enthusiasts.");
            texts.Add("Opportunity to influence a unique growth story and work with well-known global blue-chip customers");
            texts.Add("A workplace dedicated to embedded systems");
            texts.Add("Participation in teams with people from both software, hardware and mechanics");
            texts.Add("Interesting and versatile tasks in many different industries");
            texts.Add("An informal work environment and a flat hierarchy");
            texts.Add("Competent and friendly colleagues with an active Hobby Club and social events");
            texts.Add("Competitive salary, plus share/stock options.");
            texts.Add("Excellent growth opportunities.");
            texts.Add("Work with an amazing team of talented and motivated people who love their work.");
            texts.Add("Flexible working hours.");
            texts.Add("Contribute to a truly important cause - work with purpose.");
            texts.Add("A real impact on the company’s growth and evolution.");
            texts.Add("Great office space and central location in the heart of Copenhagen near Kgs. Have.");
            texts.Add("Social activities: quizzes, movie nights, DHL run, Friday bars, office parties and much, much more (well - some of this currently somewhat modified to be COVID-19 safe!)");
            texts.Add("Amazing lunch, free soft drinks, fruit, snacks and great coffee.");
            texts.Add("Time is precious. Make it count. Morning person or night owl, this job is for you.");
            texts.Add("Easy access and treehugger friendly workplace");
            texts.Add("Social gatherings and games; hang out with your colleagues");
            texts.Add("Break a leg! Seriously, we got you covered in our company healthcare plan");
            texts.Add("Friday is something special, let's enjoy a beverage together");
            texts.Add("Great opportunity to advance your own career. We hold staff development interviews twice a year, as we believe in a closer interaction with you and your development.");
            texts.Add("Tailored development plans instead of a predefined career paths.");
            texts.Add("Family friendly and flexible working hours.");
            texts.Add("Parental leave with good conditions.");
            texts.Add("Free health insurance.");
            texts.Add("Free Danish lessons in-house.");
            texts.Add("Company lunch program and possibility to buy dinner for the whole family.");
            texts.Add("Beautiful premises located centrally at the harbour in Odense (3rd biggest city in Denmark).");
            texts.Add("Extensive discount program including LogBuy.");
            texts.Add("We have a flat organizational structure with room for entrepreneurship, initiative and creativity.");
            texts.Add("Our benefits are competitive.");
            texts.Add("Comcores is growing fast and internationally, which will give you the unique possibility to work with an international talent pool.");
            texts.Add("A great team to work with that consists of highly educated technology engineering enthusiasts.");
            texts.Add("Opportunity to influence a unique growth story and work with well-known global blue-chip customers.");
            texts.Add("Work in an international company and culture where you impact the online experience of millions of global end-users");
            texts.Add("Freedom and time to work on your own ideas, learn new technologies and, stay current with the latest development trends");
            texts.Add("Benefit from a flexible work day, where you plan and handle your own time and tasks, so you can enjoy a balanced work-life");
            texts.Add("Take advantage of a flexible workday, in line with our customers’ needs, where you plan and organize your own time and tasks so you can enjoy a work-life balance");

            List<BulletPoint> bulletPoints
                = ConvertToBulletPoints(BulletPointLabels.JobBenefit, texts);

            return bulletPoints;

        }

        private List<BulletPoint> ConvertToBulletPoints(BulletPointLabels label, List<string> texts)
        {

            // While adding more bullet points to this class, a duplicate may happen.
            // Let's do some pro-active cleaning before.
            HashSet<string> removeDuplicates = new HashSet<string>(texts);

            List<BulletPoint> bulletPoints
                = removeDuplicates.Select(
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
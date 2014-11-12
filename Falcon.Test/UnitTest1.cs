using System;
using Falcon.Domain.Models;
using Falcon.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Falcon.Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        [Ignore]
        public void TestMethod1()
        {
            var c = new CV
            {
                languages = "French English Arabic",
                personalStatement = "I'm a great developer",
                targetJobs = "Web Developer",
                workExperience = "1 Year"
            };
            var m = new Member
            {
                firstname = "Chaker",
                lastname = "Laribi",
                username = "chackero",
                password = "251090",
                BankAccount = new BankAccount {balance = 200.0}
            };
            var freelancer = new Freelancer
            {
                Member = m,
                CV = c
            };

            var service = new FalconService();
            service.AddFreelancer(freelancer);
        }

        [TestMethod]
        [Ignore]
        public void TestMissions()
        {
            var m = new Member
            {
                username = "owner1",
                password = "123456"
            };
            var o = new Owner
            {
                Member = m,
                companyName = "My Company2"
            };
            var mission = new Mission
            {
                title = "My 1st Mission",
                Owner = o
            };
            var service = new FalconService();
            var freelancer=service.GetFreelancerById(1);
           // var freelancer2 = service.GetFreelancerById(2);
            mission.Freelancers.Add(freelancer); 
            //mission.Freelancers.Add(freelancer2);
            mission.Freelancer = freelancer;
            service.AddMission(mission);
            TestContext.WriteLine("Mission Title : " + o.Missions.First().title);
            foreach (var fr in o.Missions.First().Freelancers)
            {
                TestContext.WriteLine("Freelancer Name : " + fr.Member.username);                
            }
        }

        [TestMethod]
        [Ignore]
        public void AddCategoryToMissionWithDetails()
        {
            //Category category= new Category();
            //category.name = "Web";

            //Category category1 = new Category();
            //category.name = "JEE";

            //Category category2 = new Category();
            //category.name = ".NET";

            //Category category3 = new Category();
            //category.name = "HTML5";

            //Category category4 = new Category();
            //category.name = "Jomla";

            //Category category5 = new Category();
            //category.name = "JBOSS";

            var service = new FalconService();
            //service.AddCategory(category);
            //service.AddCategory(category1);
            //service.AddCategory(category2);
            //service.AddCategory(category3);
            //service.AddCategory(category4);
            //service.AddCategory(category5);

            //category.Category11.Add(category3);
            //category.Category11.Add(category4);

            //service.EditCategry(category);

            Category category = service.GetCategoryById(1);
            Category category2 = service.GetCategoryById(3);
            Category category3 = service.GetCategoryById(4);
            Category category4 = service.GetCategoryById(5);
            Category category5 = service.GetCategoryById(6);
            category.name = "Web";
            category2.name = ".NET";
            category3.name = "JEE";
            category4.name = "JOMLA";
            category5.name = "HTML";

            service.EditCategry(category);
            service.EditCategry(category2);
            service.EditCategry(category3);
            service.EditCategry(category4);
            service.EditCategry(category5);
            var m = new Member
            {
                username = "Mounir",
                password = "123456"
            };
            var m2 = new Member
            {
                username = "Talelo",
                password = "123456"
            };
            var o = new Owner
            {
                Member = m,
                companyName = "HP Company"
            };
            var mission = new Mission
            {
                title = "Creation d'automate",
                Owner = o
            };
            var freelancer = new Freelancer()
            {
                Member = m2,
            };
            mission.Freelancer = freelancer;
            mission.Owner = o;
            mission.Category = category2;

            service.AddMission(mission);

        }
        [TestMethod]
        [Ignore]
        public void AddMission()
        {
            var service= new FalconService();
            var m = new Member
            {
                username = "Abdo",
                password = "123456"
            };
            var m2 = new Member
            {
                username = "Azza",
                password = "123456"
            };
            var o = new Owner
            {
                Member = m,
                companyName = "HP Company"
            };
            
            var freelancer = new Freelancer()
            {
                Member = m2
            };
            Console.WriteLine("11111");
            var mission = new Mission()
            {   title = "JEE mission : project Managment",
                description = "Project management is the process and activity of planning",
                budget = 5000.0,
                duration = "3 Months",
                
            };
            Console.WriteLine("222");
            mission.Freelancer = freelancer;
            mission.Owner = o;
            Console.WriteLine("3333");
            service.AddMission(mission);
            Console.WriteLine("444");


            //mission.deadline = new DateTime().AddMonths(3);
            //mission.postDate = new DateTime();
             

        }


        [TestMethod]
        public void AddFreelancerToMission()
        {
            var service = new FalconService();
            var mission = new Mission()
            {
                budget = 5000.0,
                description =" Good management is essential for any enterprise",
                duration = "6 months",
                status = "free"

            };

            var m = new Member()
            {
                username = "ZITA1",
                firstname = "Mounir",
                lastname = "Zitouni",
                password = "0123",
                country = "Tunisia",
                city = "Tunis",

            };

            var m1 = new Member()
            {
                username = "Talelovesky1",
                firstname = "Talel",
                lastname = "karoui",
                password = "0123",
                country = "Tunisia",
                city = "Tunis",

            };
            var m2 = new Member()
            {
                username = "Abdo1",
                firstname = "Abdelhak",
                lastname = "boussarsar",
                password = "0123",
                country = "Tunisia",
                city = "Tunis",

            };

            var m3 = new Member()
            {
                username = "Chakero1",
                firstname = "Chaker",
                lastname = "Laribi",
                password = "0123",
                country = "Tunisia",
                city = "Tunis",

            };
            var m4 = new Member()
            {
                username = "AZZOUZ1",
                firstname = "AZZA",
                lastname = "BH",
                password = "0123",
                country = "Tunisia",
                city = "Tunis",

            };

            var m5 = new Member()
            {
                username = "SAROURRA1",
                firstname = "SARRA",
                lastname = "karoui",
                password = "0123",
                country = "Tunisia",
                city = "Tunis",

            };
            var m6 = new Member()
            {
                username = "Tarek1",
                firstname = "Tarek",
                lastname = "BEn Mloukka",
                password = "0123",
                country = "Tunisia",
                city = "Tunis",

            };

            

            var f1 = new Freelancer()
            {
                Member = m,
                
            };
            var f2 = new Freelancer()
            {
                Member = m1,
                
            };
            var f3 = new Freelancer()
            {
                Member = m2,
                
            };
            var f4 = new Freelancer()
            {
                Member = m4,
                
            };
            var f5 = new Freelancer()
            {
                Member = m5,
                
            };
            var f6 = new Freelancer()
            {
                Member = m3,
                            };
            var o = new Owner()
            {
                Member = m6,
                companyName = "SILICON VALLEY",
                companyDescription = "Silicon Valley is a nickname for the southern"
                
            };
            //Console.WriteLine("1111");
            //service.AddCv(cv);
            //service.AddCv(cv2);
            //service.AddCv(cv3);

            TestContext.WriteLine("2222");
            service.AddFreelancer(f1);
            service.AddFreelancer(f2); 
            service.AddFreelancer(f3); 
            service.AddFreelancer(f4); 
            service.AddFreelancer(f5); 
            service.AddFreelancer(f6);
            var cv = new CV()
            {
                skills = "JEE  .NET JBOSS DEVELOPER HTML ",
                languages = "Arabic , French , English",
                workExperience = "3 years",
                targetJobs = "JEE",
                
            };
            var cv2 = new CV()
            {
                skills = "UML  SOA JBOSS DEVELOPER HTML5 CSS3 ",
                languages = "Arabic , French , English ,Deutch ,Russian",
                workExperience = "8 years",
                targetJobs = "JBOSS DEVELOPER"
            };
            var cv3 = new CV()
            {
                skills = "Photoshop Video Montage ",
                languages = "Arabic , French , English ,Deutch ,Russian",
                workExperience = "8 years",
                targetJobs = "Photoshop"
            };

            service.AddCv(cv);
            service.AddCv(cv2);
            service.AddCv(cv3);

            f1.CV = cv;
            f2.CV = cv2;
            f3.CV = cv3;
            f4.CV = cv;
            f5.CV = cv2;
            f6.CV = cv3;
            service.EditFreelancer(f1);
            service.EditFreelancer(f2);
            service.EditFreelancer(f3);
            service.EditFreelancer(f4);
            service.EditFreelancer(f5);
            service.EditFreelancer(f6);

            TestContext.WriteLine("33333");
            service.AddOwner(o);
            TestContext.WriteLine("4444  freelancer apply for mission ");
            mission.Owner = o;


            mission.Freelancers.Add(f1);
            mission.Freelancers.Add(f2);
            mission.Freelancers.Add(f3);
            mission.Freelancers.Add(f4);
            mission.Freelancers.Add(f5);
            mission.Freelancers.Add(f6);
            TestContext.WriteLine("55555");
            service.AddMission(mission);



        }
    }
}

using System;
using System.Linq;
using Falcon.Domain.Models;
using Falcon.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var freelancer=service.GetFreelancerById(4);
            var freelancer2 = service.GetFreelancerById(5);
            mission.Freelancers.Add(freelancer); mission.Freelancers.Add(freelancer2);
            mission.Freelancer = freelancer;
            service.AddMission(mission);
            TestContext.WriteLine("Mission Title : " + o.Missions.First().title);
            foreach (var fr in o.Missions.First().Freelancers)
            {
                TestContext.WriteLine("Freelancer Name : " + fr.Member.username);                
            }
        }
    }
}

using System;
using Falcon.Domain.Models;
using Falcon.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Falcon.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
    }
}

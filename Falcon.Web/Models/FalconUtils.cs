using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Falcon.Data;
using Falcon.Domain.Models;
using Falcon.Service;

namespace Falcon.Web.Models
{
    public class FalconUtils
    {
        public static void UploadToFtp(string path,string source)
        {
            const string ftpServer = "ftp://localhost";
            const string userName = "falcon";
            const string password = "falcon";
            using (var client = new WebClient())
            {
                Console.WriteLine(path);
                var filename = new FileInfo(source).Name;
                client.Credentials = new System.Net.NetworkCredential(userName, password);
                client.UploadFile(ftpServer + path + filename , source);
                File.Delete(source);
            }
        }

        public static Freelancer GetRandomFreelancer()
        {
            var service = new FalconService();
            Freelancer freelancer=null;
            if (service.UnitOfWork.FreelancerRepository.GetAll().Any())
            {
                freelancer = service.UnitOfWork.FreelancerRepository.GetAll().OrderBy(fr => Guid.NewGuid()).Take(1).First();
            }
            if (freelancer == null)
            {
                freelancer = new Freelancer
                {
                    Member = new Member
                    {
                        username = "auser",
                        firstname = "first name",
                        city = "some city"

                    }
                };
            }
            return freelancer;
        }

    }
}
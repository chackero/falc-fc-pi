using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Service
{
    interface IFalconService
    {
       
        //Freelancers
        void AddFreelancer(Freelancer freelancer);
        /*
        void EditFreelancer(Freelancer freelancer);
        Freelancer GetFreelancerById(int id);
        Freelancer GetFreelancerByUsername(String username);
        void AddCv(Freelancer freelancer, CV cv);
        void EditCv(Freelancer freelancer, CV cv);
        void AddCircle(Freelancer freelancer,Circle circle);
        void EditCirlce(Freelancer freelancer, Circle circle);
        void JoinCirlce(Freelancer freelancer, Circle circle);
        */

    }
}

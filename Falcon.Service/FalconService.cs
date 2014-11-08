using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Service
{
    public class FalconService : IFalconService
    {
        private IDatabaseFactory dbFactory;
        private IUnitOfWork unitOfWork;

        public FalconService()
        {
            dbFactory = new DatabaseFactory();
            unitOfWork = new UnitOfWork(dbFactory);
        }
        public void AddFreelancer(Freelancer freelancer)
        {
            unitOfWork.FreelancerRepository.Add(freelancer);
            //freelancer.role = "Freelancer";
            //unitOfWork.MemberRepository.Add(freelancer);
            unitOfWork.Commit();
        }

        public void EditFreelancer(Freelancer freelancer)
        {
            unitOfWork.FreelancerRepository.Update(freelancer);
            unitOfWork.Commit();
        }

        public Freelancer GetFreelancerById(int id)
        {
            return unitOfWork.FreelancerRepository.Get(f => f.idMember.Equals(id));
        }

        public Freelancer GetFreelancerByUsername(string username)
        {
            return unitOfWork.FreelancerRepository.Get(f => f.Member.username.Equals(username));
        }

        public void AddCv(Freelancer freelancer, CV cv)
        {
            freelancer.CV = cv;
            unitOfWork.Commit();
        }

        public void EditCv(Freelancer freelancer, CV cv)
        {
            freelancer.CV = cv;
            unitOfWork.Commit();
        }
    }
}

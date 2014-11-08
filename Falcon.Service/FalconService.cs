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
    }
}

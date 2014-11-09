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

        //Freelancers Region

        #region freelancers
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

        public void ApplyForMission(Freelancer freelancer, Mission mission)
        {
            mission.Freelancers.Add(freelancer);
            unitOfWork.Commit();
        }

        public void UnApplyForMission(Freelancer freelancer, Mission mission)
        {
            mission.Freelancers.Remove(freelancer);
            unitOfWork.Commit();
        }

        public void AddCircle(Freelancer freelancer, Circle circle)
        {
            unitOfWork.CircleRepository.Add(circle);
            unitOfWork.Commit();
        }

        public void EditCirlce(Freelancer freelancer, Circle circle)
        {
            unitOfWork.CircleRepository.Update(circle);
            unitOfWork.Commit();
        }

        public void JoinCirlce(Freelancer freelancer, Circle circle)
        {
            circle.Freelancers.Add(freelancer);
            freelancer.Circles1.Add(circle);
            unitOfWork.Commit();
        }

        

        #endregion

        //Owner Region
        #region

        public void AddOwner(Owner owner)
        {
            unitOfWork.OwnerRepository.Add(owner);
            unitOfWork.Commit();
        }

        public void EditOwner(Owner owner)
        {
            unitOfWork.OwnerRepository.Update(owner);
            unitOfWork.Commit();
        }

        public Owner GetOwnerById(int idOwner)
        {
            return unitOfWork.OwnerRepository.GetById(idOwner);
        }

        public Owner GetOwnerByUsername(string username)
        {
            return unitOfWork.OwnerRepository.Get(o => o.Member.username.Equals(username));
        }

        public void AddMission(Mission mission)
        {
            unitOfWork.MissionRepository.Add(mission);
            unitOfWork.Commit();
        }

        public void EditMission(Mission mission)
        {
            unitOfWork.MissionRepository.Update(mission);
            unitOfWork.Commit();
        }

        public void PickAFreelancer(Mission mission, Freelancer freelancer)
        {
            mission.Freelancer = freelancer;
            freelancer.Missions.Add(mission);
            unitOfWork.Commit();
        }

        #endregion
    }
}

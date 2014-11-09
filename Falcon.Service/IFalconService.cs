using Falcon.Domain.Models;
using System;

namespace Falcon.Service
{
    interface IFalconService
    {

        //Freelancers
        #region freelancers
        void AddFreelancer(Freelancer freelancer);
        
        void EditFreelancer(Freelancer freelancer);
        
        Freelancer GetFreelancerById(int id);
        Freelancer GetFreelancerByUsername(String username);
        void AddCv(Freelancer freelancer, CV cv);
        void EditCv(Freelancer freelancer, CV cv);
        void ApplyForMission(Freelancer freelancer, Mission mission);
        void UnApplyForMission(Freelancer freelancer, Mission mission);
        void AddCircle(Freelancer freelancer,Circle circle);
        void EditCirlce(Freelancer freelancer, Circle circle);
        void JoinCirlce(Freelancer freelancer, Circle circle);
        #endregion

        #region owners

        void AddOwner(Owner owner);
        void EditOwner(Owner owner);
        Owner GetOwnerById(int idOwner);
        Owner GetOwnerByUsername(String username);
        void AddMission(Mission mission);
        void EditMission(Mission mission);
        void PickAFreelancer(Mission mission, Freelancer freelancer);

        #endregion
    }
}

﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Service
{
    public class FalconService : IFalconService
    {
        private IDatabaseFactory dbFactory;
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }
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

        public Mission getMissionById(int id)
        {
            return unitOfWork.MissionRepository.GetById(id);
        }

        #endregion

        //Category Region
        #region
        

        public void AddCategory(Category category)
        {
         unitOfWork.CategoryRepository.Add(category);
         unitOfWork.Commit();
        }

        public void EditCategry(Category category)
        {
            unitOfWork.CategoryRepository.Update(category);
            unitOfWork.Commit();
        }

        public Category GetCategoryById(int idCategory)
        {
            return unitOfWork.CategoryRepository.Get(p => p.idCategory == idCategory);
        }

        public void DeleteCategory(Category category)
        {
            unitOfWork.CategoryRepository.Delete(category);
        }

        public List<Category> GetCategories()
        {
            return unitOfWork.CategoryRepository.GetAll().ToList();
        }

        public List<Category> GetCategoriesByName(string name)
        {
            return unitOfWork.CategoryRepository.GetMany(p => p.name == name).ToList();
        }

        public Category GetCategoryByName(string name)
        {
            return unitOfWork.CategoryRepository.Get(c => c.name.Equals(name));
        }

        #endregion

        //CV Region
        #region

        public void AddCv(CV cv)
        {
            unitOfWork.CvRepository.Add(cv);
            unitOfWork.Commit();
        }
        #endregion

        //Mission Region
        #region

        public List<Mission> GetMissions()
        {
            return unitOfWork.MissionRepository.GetAll().ToList();
        }

        public List<Mission> GetMissionsByCategory(string categoryName)
        {
            return unitOfWork.MissionRepository.GetMany(m => m.Category.name == categoryName).ToList();
        }
        public List<Mission> GetMissionsByBudget(double budget)
        {
            return unitOfWork.MissionRepository.GetMany(m => m.budget > budget).ToList();
        }
        public List<Mission> GetMissionsByCategoryNameAndBudget(string categoryName, double budget)
        {

            return unitOfWork.MissionRepository.GetMany(m => m.Category.name == categoryName && m.budget > budget).ToList();
        }

        #endregion
    }
}

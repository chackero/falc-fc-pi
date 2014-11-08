using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Freelancer
    {
        public Freelancer()
        {
            this.Circles = new List<Circle>();
            this.Complaints = new List<Complaint>();
            this.Events = new List<Event>();
            this.Missions = new List<Mission>();
            this.PrivateMessages = new List<PrivateMessage>();
            this.PrivateMessages1 = new List<PrivateMessage>();
            this.Circles1 = new List<Circle>();
            this.Events1 = new List<Event>();
            this.Freelancer1 = new List<Freelancer>();
            this.Freelancers = new List<Freelancer>();
            this.Missions1 = new List<Mission>();
        }

        public int idMember { get; set; }
        public int activation { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string username { get; set; }
        public Nullable<int> bankaccount_fk { get; set; }
        public Nullable<int> profilepic_fk { get; set; }
        public Nullable<int> curriculum_idCV { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public virtual ICollection<Circle> Circles { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual CV CV { get; set; }
        public virtual Document Document { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessages { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessages1 { get; set; }
        public virtual ICollection<Circle> Circles1 { get; set; }
        public virtual ICollection<Event> Events1 { get; set; }
        public virtual ICollection<Freelancer> Freelancer1 { get; set; }
        public virtual ICollection<Freelancer> Freelancers { get; set; }
        public virtual ICollection<Mission> Missions1 { get; set; }
    }
}

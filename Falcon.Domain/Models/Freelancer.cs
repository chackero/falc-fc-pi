using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
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
        public virtual Member Member { get; set; }
        public Nullable<int> curriculum_idCV { get; set; }
        public virtual ICollection<Circle> Circles { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual CV CV { get; set; }
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

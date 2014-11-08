using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class Mission
    {
        public Mission()
        {
            this.Complaints = new List<Complaint>();
            this.Freelancers = new List<Freelancer>();
            this.Posts = new List<Post>();
        }

        public int idMission { get; set; }
        public Nullable<double> budget { get; set; }
        public Nullable<System.DateTime> deadline { get; set; }
        public string description { get; set; }
        public string duration { get; set; }
        public Nullable<System.DateTime> plannedStart { get; set; }
        public Nullable<System.DateTime> postDate { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public Nullable<int> category_idCategory { get; set; }
        public Nullable<int> evaluation_idEval { get; set; }
        public Nullable<int> owner_fk { get; set; }
        public Nullable<int> worker_id { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual Evaluation Evaluation { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<Freelancer> Freelancers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

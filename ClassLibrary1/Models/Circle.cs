using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Circle
    {
        public Circle()
        {
            this.Freelancers = new List<Freelancer>();
            this.Posts = new List<Post>();
        }

        public int idCircle { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Nullable<int> creator_fk { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual ICollection<Freelancer> Freelancers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

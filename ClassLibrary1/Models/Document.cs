using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Document
    {
        public Document()
        {
            this.Admins = new List<Admin>();
            this.CVs = new List<CV>();
            this.Owners = new List<Owner>();
            this.Members = new List<Member>();
            this.Owners1 = new List<Owner>();
            this.Freelancers = new List<Freelancer>();
        }

        public int idDocument { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public Nullable<int> attach_id { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<CV> CVs { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Owner> Owners1 { get; set; }
        public virtual ICollection<Freelancer> Freelancers { get; set; }
    }
}

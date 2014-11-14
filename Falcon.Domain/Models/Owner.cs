using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class Owner
    {
        public Owner()
        {
            this.Complaints = new List<Complaint>();
            this.Missions = new List<Mission>();
        }

        public string companyDescription { get; set; }
        public string companyName { get; set; }
        public int idMember { get; set; }
        public virtual Member Member { get; set; }
        public Nullable<int> c_logo_fk { get; set; }
        public virtual Document Document { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}

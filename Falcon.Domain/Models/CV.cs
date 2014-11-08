using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class CV
    {
        public CV()
        {
            this.Freelancers = new List<Freelancer>();
        }

        public int idCV { get; set; }
        public string languages { get; set; }
        public Nullable<System.DateTime> lastUpdate { get; set; }
        public string personalStatement { get; set; }
        public string skills { get; set; }
        public string targetJobs { get; set; }
        public string workExperience { get; set; }
        public Nullable<int> document_idDocument { get; set; }
        public virtual ICollection<Freelancer> Freelancers { get; set; }
        public virtual Document Document { get; set; }
    }
}

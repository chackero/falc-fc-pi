using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class Document
    {
        public Document()
        {
            this.CVs = new List<CV>();
            this.Owners = new List<Owner>();
            this.Members = new List<Member>();
        }

        public int idDocument { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public Nullable<int> attach_id { get; set; }
        public virtual ICollection<CV> CVs { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}

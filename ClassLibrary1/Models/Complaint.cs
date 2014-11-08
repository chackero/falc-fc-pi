using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Complaint
    {
        public int idComplaint { get; set; }
        public string body { get; set; }
        public Nullable<System.DateTime> sendDate { get; set; }
        public string status { get; set; }
        public string subject { get; set; }
        public Nullable<int> defendant_fk { get; set; }
        public Nullable<int> mission_fk { get; set; }
        public Nullable<int> plaintiff_fk { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Mission Mission { get; set; }
    }
}

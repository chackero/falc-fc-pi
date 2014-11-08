using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            this.Admins = new List<Admin>();
            this.Members = new List<Member>();
            this.Owners = new List<Owner>();
            this.Freelancers = new List<Freelancer>();
        }

        public int idAccount { get; set; }
        public Nullable<double> balance { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
        public virtual ICollection<Freelancer> Freelancers { get; set; }
    }
}

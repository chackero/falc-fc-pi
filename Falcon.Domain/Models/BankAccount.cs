using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            this.Members = new List<Member>();
        }

        public int idAccount { get; set; }
        public Nullable<double> balance { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}

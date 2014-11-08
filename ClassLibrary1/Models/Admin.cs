using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Admin
    {
        public int idMember { get; set; }
        public int activation { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string username { get; set; }
        public Nullable<int> bankaccount_fk { get; set; }
        public Nullable<int> profilepic_fk { get; set; }
        public virtual Document Document { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class PrivateMessage
    {
        public int idPM { get; set; }
        public string body { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> receiver_fk { get; set; }
        public Nullable<int> sender_fk { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual Freelancer Freelancer1 { get; set; }
    }
}

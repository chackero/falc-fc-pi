using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class Admin
    {
        public int idMember { get; set; }
        public virtual Member Member { get; set; }
    }
}

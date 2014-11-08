using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class hibernate_sequences
    {
        public string sequence_name { get; set; }
        public Nullable<decimal> next_val { get; set; }
    }
}

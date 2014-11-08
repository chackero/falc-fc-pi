using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Evaluation
    {
        public Evaluation()
        {
            this.Missions = new List<Mission>();
        }

        public int idEval { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string feedback { get; set; }
        public double score { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}

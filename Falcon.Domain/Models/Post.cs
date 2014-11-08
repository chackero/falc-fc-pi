using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class Post
    {
        public Post()
        {
            this.Documents = new List<Document>();
            this.Circles = new List<Circle>();
            this.Events = new List<Event>();
            this.Missions = new List<Mission>();
        }

        public int idPost { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> poster_idMember { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Circle> Circles { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}

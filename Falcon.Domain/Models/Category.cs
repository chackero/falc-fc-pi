using System;
using System.Collections.Generic;

namespace Falcon.Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Category1 = new List<Category>();
            this.Missions = new List<Mission>();
            this.Category11 = new List<Category>();
            this.Categories = new List<Category>();
        }

        public int idCategory { get; set; }
        public string name { get; set; }
        public Nullable<int> parent_idCategory { get; set; }
        public virtual ICollection<Category> Category1 { get; set; }
        public virtual Category Category2 { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<Category> Category11 { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}

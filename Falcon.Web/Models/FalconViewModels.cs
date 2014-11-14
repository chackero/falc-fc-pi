using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falcon.Web.Models
{
    public class FalconViewModels
    {
    }

    public class FreelancerProfileViewModel
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }

        public string City { get; set; }
    }
    public class OwnerProfileViewModel
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string CompanyDescription { get; set; }

        [DataType(DataType.Url)]
        [DefaultValue("www.falcon.com")]
        public string Website { get; set; }

        [DefaultValue("unknown")]
        public string CompanyAddress { get; set; }
    }
    public class CreateMissionViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public double Budget { get; set; }

        public DateTime plannedStart { get; set; }

        public DateTime deadline { get; set; }
        public string duration { get; set; }
    }
}
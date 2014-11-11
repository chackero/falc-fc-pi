using System;
using System.Collections.Generic;
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
}
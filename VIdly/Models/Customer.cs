using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIdly.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Please enter cutomer's name!")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribedToNewsletter { get; set;  }

        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership")]
        public byte MembershipTypeId { get; set;  }
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }



    }
}
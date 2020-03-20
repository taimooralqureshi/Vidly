using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VIdly.Models;

namespace VIdly.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribedToNewsletter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

    }
}
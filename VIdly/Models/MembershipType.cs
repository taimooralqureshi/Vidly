using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIdly.Models
{
    public class MembershipType
    {
        public byte id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}
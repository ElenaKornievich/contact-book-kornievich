using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WCFContactBook
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int ContactID { get; set; }

        [DataMember]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter name")]
        [MaxLength(50, ErrorMessage = "Max length - 50 symbols")]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Enter surname")]
        [MaxLength(50, ErrorMessage = "Max length - 50 symbols")]
        public string Surname { get; set; }

        [DataMember]
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Enter phone number")]
        [MaxLength(50, ErrorMessage = "Max length - 50 symbols")]
        public string PhoneNumber { get; set; }

        [DataMember]
        public int GroupID { get; set; }

        [DataMember]
        public Group Group { get; set; }
    }
}
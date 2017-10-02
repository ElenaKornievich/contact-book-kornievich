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
    public class Group
    {
        [DataMember]
        public int GroupID { get; set; }

        [DataMember]
        [Display(Name = "Group name")]
        [Required(ErrorMessage = "Enter group name")]
        [MaxLength(50, ErrorMessage = "Max length - 50 symbols")]
        public string GroupName { get; set; }
    }
}
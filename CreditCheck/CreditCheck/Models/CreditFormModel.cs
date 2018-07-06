using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CreditCheck.Models
{
    public class CreditFormModel
    {
        [Required(ErrorMessage="Please insert your First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please insert letters only")]
        public string fname { get; set; }

        [Required(ErrorMessage="Please insert your Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please insert letters only")]
        public string lname { get; set; }

        [Required(ErrorMessage = "Please insert your Annual Income")]
        [RegularExpression("^[0-9]*$", ErrorMessage="Please insert only positive numbers")]
        public int income { get; set; }
     
        [Required(ErrorMessage = "Please insert your Date of Birth")]
        [RegularExpression("^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\\d\\d$", ErrorMessage="Please insert correct Date of Birth format")]
        public string dob { get; set; }

    }
}
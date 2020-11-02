using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiquorStore.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [Display(Name = "Geboorteplaats")]
        public string HomeTown { get; set; }

        [Display(Name = "Leeftijd")]
        public DateTime Age { get; set; }
    }
}

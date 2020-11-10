using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiquerStore.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [Display(Name = "Geboorteplaats")]
        public string HomeTown { get; set; }

        [Required]
        [Display(Name = "Geboortedatum")]
        public DateTime Age { get; set; }

        [EmailAddress]
        public override string Email { get; set; }
    }
}

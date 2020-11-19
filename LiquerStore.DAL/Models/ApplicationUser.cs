using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LiquerStore.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Naam
        [Required]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [NotMapped] public string FullName => $"{FirstName} {LastName}";

        // Geboorte velden
        [Required]
        [Display(Name = "Geboorteplaats")]
        public string HomeTown { get; set; }

        [Required]
        [Display(Name = "Geboortedatum")]
        public DateTime Age { get; set; }

        // Mail
        [EmailAddress] public override string Email { get; set; }
    }
}
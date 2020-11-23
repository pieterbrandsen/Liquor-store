using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiquerStore.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Full name
        [Required]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [NotMapped] public string FullName => $"{FirstName} {LastName}";

        // Birth fields
        [Required]
        [Display(Name = "Geboorteplaats")]
        public string HomeTown { get; set; }

        [Required]
        [Display(Name = "Geboortedatum")]
        public DateTime Age { get; set; }

        // Roles
        [Required]
        [Display(Name = "Rollen")]
        public Roles Role { get; set; }

        // Email
        [EmailAddress] public override string Email { get; set; }
    }

    // All roles
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Roles {
        [Display(Name = "Werknemer")] [EnumMember(Value = "Employee")]
        Employee, 
        [Display(Name = "Klant")] [EnumMember(Value = "Customer")]
        Customer
    }
}
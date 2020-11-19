using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiquerStore.DAL.Models
{
    public class WhiskyModel
    {
        // Id (Key)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Name of whisky
        [Display(Name = "Naam")] public string Name { get; set; }

        // Known years since it was made
        [Display(Name = "Leeftijd")] public int Age { get; set; }

        // Where it is produced
        [Display(Name = "Productiegebied")] public string ProductionArea { get; set; }

        // How much alchol is in the whisky
        [Display(Name = "Alcoholpercentage")] public decimal AlcoholPercentage { get; set; }

        // What kind of whisky is it
        [Display(Name = "Soort")] public WhiskyKind Kind { get; set; }

        // File linked
        [Display(Name = "Afbeelding locatie")] public string LabelPath { get; set; }
    }

    // Whisky kinds
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WhiskyKind
    {
        [Display(Name = "Blend")] [EnumMember(Value = "Blend")]
        Blend,
        [Display(Name = "Single Malt")] [EnumMember(Value = "Single Malt")]
        SingleMalt
    }
}
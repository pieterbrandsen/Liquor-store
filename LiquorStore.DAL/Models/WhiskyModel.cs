using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace LiquorStore.DAL.Models
{
    public class WhiskyModel
    {
        [Key]
        public string Id { get; set; }
        
        [Display(Name = "Naam")]
        public string Name { get; set; }
        
        [Display(Name = "Leeftijd")]
        public int Age { get; set; }

        [Display(Name = "Productiegebied")]
        public string ProductionArea { get; set; }

        [Display(Name = "Alcoholpercentage")]
        public decimal AlcoholPercentage { get; set; }

        [Display(Name = "Soort")]
        public WhiskyKind Kind { get; set; }
        public string LabelPath { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WhiskyKind
    {
        Blend,
        [Display(Name = "Single Malt"), EnumMember(Value = "Single Malt")] SingleMalt
    }
}

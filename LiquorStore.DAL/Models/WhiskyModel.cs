using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiquorStore.DAL.Models
{
    public class WhiskyModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ProductionArea { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public WhiskyKind Kind { get; set; }
        public string LabelPath { get; set; }
    }

    public enum WhiskyKind
    {
        Blend,
        [Display(Name = "Single Malt")] SingleMalt
    }
}

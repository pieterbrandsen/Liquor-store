using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiquerStore.DAL.Models
{
    public class StorageModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Aantal beschikbaar")]
        public int Available { get; set; }
        [Display(Name = "Aantal gereserveerd")]
        public int Reserved { get; set; }
        public int WhiskyId { get; set; }
        public virtual WhiskyModel Whisky { get; set; }
        public bool SoftDeleted { get; set; }
    }
}

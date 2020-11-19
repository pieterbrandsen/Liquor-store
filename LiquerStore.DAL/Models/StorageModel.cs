using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquerStore.DAL.Models
{
    public class StorageModel
    {
        // Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Amount stored
        [Display(Name = "Aantal beschikbaar")] 
        public int Available { get; set; }

        // Amount reserved
        [Display(Name = "Aantal gereserveerd")]
        public int Reserved { get; set; }

        // Whisky linked
        public int WhiskyId { get; set; }
        public virtual WhiskyModel Whisky { get; set; }
        // Should this whisky be shown to customers?
        public bool SoftDeleted { get; set; }
    }
}
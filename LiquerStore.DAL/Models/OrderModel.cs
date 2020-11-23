using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquerStore.DAL.Models
{
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ApplicationUser Customer { get; set; }
        public virtual WhiskyModel Whisky { get; set; }
        public bool Completed { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LiquerStore.DAL.Models
{
    public class UserToWhisky
    {
        [Key]
        public string UserId { get; set; }
        public int WhiskyId { get; set; }
        public bool Reserved { get; set; }
    }
}

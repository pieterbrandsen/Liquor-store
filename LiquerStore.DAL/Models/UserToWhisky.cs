﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LiquerStore.DAL.Models
{
    class UserToWhisky
    {
        public string UserId { get; set; }
        public int WhiskyId { get; set; }
        public bool Reserved { get; set; }
    }
}
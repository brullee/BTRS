﻿using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Passengers
    {
        [Key]
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        

    }
}

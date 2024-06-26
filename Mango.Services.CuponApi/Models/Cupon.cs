﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CuponApi.Models
{
    public class Cupon
    {
        [Key]
        public int CuponId { get; set; }
        [Required]
        public string CuponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}

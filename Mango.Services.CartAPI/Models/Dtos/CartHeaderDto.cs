﻿namespace Mango.Services.CartAPI.Models.Dtos
{
    public class CartHeaderDto
    {
        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? Coupon { get; set; }
        public double Discount { get; set; }
        public double CartTotal { get; set; }
    }
}
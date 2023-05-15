﻿namespace WebApp.Models.dto
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Rating { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateProductDTO
{
      [Required]
      public  string Name { get; set; } = string.Empty;

      [Required]
      public  string Description { get; set; } = string.Empty;

      [Range(0.01, double.MaxValue, ErrorMessage = "Price Must be greater than zero")]
      public decimal Price { get; set; }
      
      [Required]
      public  string PictureUrl { get; set; } = string.Empty;

      [Required]
      public  string Type { get; set; } = string.Empty;

      [Required]
      public  string Brand { get; set; } = string.Empty;

      [Range(0.01, int.MaxValue, ErrorMessage = "Quantity in stock Must be greater than zero")]
      public int QuantityInStock { get; set; }
}

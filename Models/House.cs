using System;
using System.ComponentModel.DataAnnotations;

namespace fullstack_gregslist.Models
{
  public class House
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    [Required]
    public string description { get; set; }
    [Required]
    public int rooms { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int Price { get; set; }
    [Required]
    public string ImgUrl { get; set; }
    [Required]
    public string Body { get; set; }

  }
}
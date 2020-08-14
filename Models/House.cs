

using System.ComponentModel.DataAnnotations;

namespace fullstack_gregslist.Models
{
  public class House
  {
    public int Id { get; set; }
    [Required]
    public int Price { get; set; }
    public string UserId { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Bathrooms { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int SquareFeet { get; set; }
    [Required]
    public int Bedrooms { get; set; }
    public string ImgUrl { get; set; }

  }
  public class ViewModelHouseFavorites : House
  {
    public int FavoriteId { get; set; }
  }
}
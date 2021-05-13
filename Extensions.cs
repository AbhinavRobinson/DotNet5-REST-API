using DotNet5_REST_API.Entities;
using DotNet5_REST_API.Dtos;

namespace DotNet5_REST_API
{
  public static class Extensions
  {
    public static ItemDto AsDto(this Item item)
    {
      return new ItemDto
      {
        Id = item.Id,
        Name = item.Name,
        Price = item.Price,
        CreatedDate = item.CreatedDate
      };
    }
  }
}
using System.Linq;
using System;
using DotNet5_REST_API.Repositories;
using DotNet5_REST_API.Dtos;
using DotNet5_REST_API.Entities;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DotNet5_REST_API.Controllers
{
  [ApiController]
  [Route("items")]
  public class ItemsController : ControllerBase
  {
    private readonly IItemsRepository repository;

    public ItemsController(IItemsRepository repository)
    {
      this.repository = repository;
    }

    // GET /items
    [HttpGet]
    public ActionResult<IEnumerable<ItemDto>> GetItems()
    {
      var items = repository.GetItems().Select(item => item.AsDto());

      if (items is null)
      {
        return NotFound();
      }


      return Ok(items);
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
      var item = repository.GetItem(id);

      if (item is null)
      {
        return NotFound();
      }

      return Ok(item.AsDto());
    }

    // POST /items
    [HttpPost]
    public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
    {
      Item item = new()
      {
        Id = Guid.NewGuid(),
        Name = itemDto.Name,
        Price = itemDto.Price,
        CreatedDate = DateTimeOffset.UtcNow
      };

      repository.CreateItem(item);
      return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
    }
  }
}
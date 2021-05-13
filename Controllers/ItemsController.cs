using System;
using DotNet5_REST_API.Repositories;
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
    public ActionResult<IEnumerable<Item>> GetItems()
    {
      var items = repository.GetItems();

      if (items is null)
      {
        return NotFound();
      }


      return Ok(items);
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(Guid id)
    {
      var item = repository.GetItem(id);

      if (item is null)
      {
        return NotFound();
      }

      return item;
    }
  }
}
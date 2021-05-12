using DotNet5_REST_API.Repositories;
using DotNet5_REST_API.Entities;

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DotNet5_REST_API.Controllers
{
  [ApiController]
  [Route("items")]
  public class ItemsController : ControllerBase
  {
    private readonly InMemItemsRepository repository;

    public ItemsController()
    {
      repository = new InMemItemsRepository();
    }

    // GET /items
    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
      var items = repository.GetItems();
      return items;
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
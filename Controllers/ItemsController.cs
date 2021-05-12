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
  }
}
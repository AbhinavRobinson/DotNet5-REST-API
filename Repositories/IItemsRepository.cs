using System;
using System.Collections.Generic;
using DotNet5_REST_API.Entities;

namespace DotNet5_REST_API.Repositories
{
  public interface IItemsRepository
  {
    Item GetItem(Guid id);
    IEnumerable<Item> GetItems();
  }
}
using System;
using System.Collections.Generic;
using fullstack_gregslist.Models;
using fullstack_gregslist.Repositories;

namespace fullstack_gregslist
{
  public class HousesService
  {
    private readonly HousesRepository _repo;

    HousesService(HousesRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<House> GetAll()
    {
      return _repo.GetAll();
    }

    internal IEnumerable<House> GetByUserId(string userId)
    {
      return _repo.GetHousesByUserId(userId);
    }

    internal House GetByHouseId(int id)
    {
      House foundHouse = _repo.GetByHouseId(id);
      if (foundHouse == null)
      {
        throw new Exception("Bad Id");
      }
      return foundHouse;
    }

    internal House Creat(House newHouse)
    {
      return _repo.Creat(newHouse);
    }

    internal House edit(House houseToUpdate, string userId)
    {
      House foundHouse = GetByHouseId(houseToUpdate.Id);
      if (foundHouse.UserId != userId && foundHouse.Price < houseToUpdate.Price)
      {
        if (_repo.BidOnHouse(houseToUpdate))
        {
          foundHouse.Price = houseToUpdate.Price;
          return foundHouse;
        }
        throw new Exception("Can't bid on that house");
      }
      if (foundHouse.UserId == userId && _repo.edit(houseToUpdate, userId))
      {
        return houseToUpdate;
      }
      throw new Exception("that is not your house");
    }

    internal object delete(int id, string userId)
    {
      throw new NotImplementedException();
    }
  }
}
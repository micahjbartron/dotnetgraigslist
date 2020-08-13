using System;
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

    internal object GetAll()
    {
      throw new NotImplementedException();
    }

    internal object GetByUserId(string userId)
    {
      throw new NotImplementedException();
    }

    internal object GetByHouseId(int id)
    {
      throw new NotImplementedException();
    }
  }
}
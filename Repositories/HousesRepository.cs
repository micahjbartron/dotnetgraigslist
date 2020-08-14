
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using fullstack_gregslist.Models;

namespace fullstack_gregslist.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;
    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<House> GetAll()
    {
      string sql = "SELECT * FROM houses";
      return _db.Query<House>(sql);
    }

    internal IEnumerable<House> GetHousesByUserId(string userId)
    {
      string sql = "SELECT * FROM houses userId = @userId";
      return _db.Query<House>(sql, new { userId });
    }

    internal House GetByHouseId(int id)
    {
      throw new NotImplementedException();
    }

    internal House Creat(House newHouse)
    {
      throw new NotImplementedException();
    }

    internal bool BidOnHouse(House houseToUpdate)
    {
      throw new NotImplementedException();
    }

    internal bool edit(House houseToUpdate, string userId)
    {
      throw new NotImplementedException();
    }
  }
}
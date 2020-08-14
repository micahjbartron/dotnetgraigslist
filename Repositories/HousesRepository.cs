
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
      string sql = "SELECT * FROM houses id = @id";
      return _db.QueryFirstOrDefault<House>(sql, new { id });
    }

    internal House Creat(House newHouse)
    {
      string sql = @"
      INSERT INTO houses
      (price, userId, description, barthrooms, year, squareFeet, bedrooms, imgUrl)
      VALUES
      (@Price, @UserId, @Description, @Bathrooms, @year, @SquareFeet, @Bedrooms, @ImgUrl);
      SELECT LAST_INSERT_ID()";
      newHouse.Id = _db.ExecuteScalar<int>(sql, newHouse);
      return newHouse;
    }

    internal bool BidOnHouse(House houseToBidOn)
    {
      string sql = @"
      UPDATE houses
      SET
      price = @Price
      WHERE id = @Id";
      int affectedRows = _db.Execute(sql, houseToBidOn);
      return affectedRows == 1;
    }

    internal bool edit(House houseToUpdate, string userId)
    {
      houseToUpdate.UserId = userId;
      string sql = @"
      UPDATE houses
      SET
          price = @Price,
          description = @Description,
          bathrooms = @Bathrooms,
          year = @Year,
          squareFeet = @SquareFeet,
          bathrooms = @Bathrooms,
          imgUrl = @ImgUrl
      WHERE id = @Id
      AND userId = @UserId";
      int affectedRows = _db.Execute(sql, houseToUpdate);
      return affectedRows == 1;
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM houses WHERE id = @Id AND userId = @UserId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}
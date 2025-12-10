using Calculator.Calculations.Business;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculations.Repository
{
    public class ProductRepository:IProduct
    {
        private readonly IDbConnection _connection;
        public ProductRepository(IDbConnection db) {
        _connection = db;

        }

        public async Task<int> Create(CreateProductDto payload)
        {

            var sql = @"INSERT INTO Product (Name, Description, Category, Price, Stock)
                VALUES (@Name, @Description, @Category, @Price, @Stock)";

            return await _connection.ExecuteAsync(sql, payload);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {

                var sql = "select * from product";
                return await _connection.QueryAsync<Product>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get", ex);
            }
        }

        public async Task<int> GetCount()
        {
            var sql = "SELECT COUNT(*) FROM product";
            return await _connection.ExecuteAsync(sql);

        }

       

    }
}

using Calculator.Model.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Calculator.Model.Models;
namespace Calculator.Calculations.Business
{
    public class HomeRepository : IHome
    {
        private readonly string _connectionString;

        public HomeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(_connectionString);
            var sql = @"
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Home' AND xtype='U')
        CREATE TABLE Home
        (
            Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
            Name NVARCHAR(100) NOT NULL,
            Description NVARCHAR(MAX) NULL
        );";
            connection.Execute(sql);
        }


        public async Task<IEnumerable<Home>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Home";
            return await connection.QueryAsync<Home>(sql);
        }

        public async Task<Home> GetByIdAsync(string id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Home WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Home>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(HomePayload payload)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Home (Name, Description) VALUES (@Name, @Description)";
            return await connection.ExecuteAsync(sql, payload);
        }

        public async Task<int> UpdateAsync(string id, HomePayload payload)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE Home SET Name = @Name, Description = @Description WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, new { payload.Name, payload.Description, Id = id });
        }

        public async Task<int> DeleteAsync(string id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Home WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}

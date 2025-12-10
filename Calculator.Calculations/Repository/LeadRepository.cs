using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Calculator.Model.Models;
using Dapper;
using Calculator.Calculations.Business;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Data;

namespace Calculator.Calculations.Repository
{
    public class LeadRepository:ILeads
    {
        private readonly IDbConnection _db;
        public LeadRepository(IDbConnection db) {
            _db = db;
        }

        public async Task<IEnumerable<Leads>> GetLeads()
        {
                var query = "select * from leads";
                var response = await _db.QueryAsync<Leads>(query);
                return response;
        }

        public async Task<int> Create(ICreateLead lead)
        {
            try
            {
                var query = "insert into leads (FullName, Remarks) values (@FullName, @Remarks)";
                return await _db.ExecuteAsync(query, lead);
            }
            catch (Exception ex)
            {
                throw new Exception("ex",ex);
            }
        }

        public async Task<int> Delete(Guid id)
        {
            try
            {
                var sql = "delete from leads where id = @Id ";
                return await _db.ExecuteAsync(sql,new {Id=id});
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not delete {ex.Message}",ex);
            }
        }
    }
}

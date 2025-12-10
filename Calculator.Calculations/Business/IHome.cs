using Calculator.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Calculator.Calculations.Business
{
    public interface IHome
    {
        Task<IEnumerable<Home>> GetAllAsync();
        Task<Home> GetByIdAsync(string id);
        Task<int> CreateAsync(HomePayload payload);
        Task<int> UpdateAsync(string id, HomePayload payload);
        Task<int> DeleteAsync(string id);
    }
}

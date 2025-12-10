
using Calculator.Model.Models;

namespace Calculator.Calculations.Business
{
    public  interface IProduct
    {
         Task<IEnumerable<Product>> GetAll();

        Task<int> GetCount();
        Task<int> Create(CreateProductDto payload);
    }
}

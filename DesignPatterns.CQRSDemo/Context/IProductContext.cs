using DesignPatterns.CQRSDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Context
{
    public interface IProductContext
    {
        Task<int> Add(Product product);
        Task<bool> Remove(int id);
        Task<bool> Update(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
    }
}

using DesignPatterns.CQRSDemo.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Context
{
    public class ProductContext : IProductContext
    {
        readonly string _connectionString;

        public ProductContext(string connectionString)
        {
            _connectionString = connectionString;
        }
                
        public async Task<int> Add(Product product)
        {
            Object commandExecutionResult = null;
            var connection = new SqlConnection(_connectionString);
            try
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Products (" +
                    $"{nameof(Product.Name)}, " +
                    $"{nameof(Product.QuantityPerUnit)}, " +
                    $"{nameof(Product.Description)}, " +
                    $"{nameof(Product.UnitPrice)}, " +
                    $"{nameof(Product.UnitsInStock)}, " +
                    $"{nameof(Product.UnitsOnOrder)}, " +
                    $"{nameof(Product.ReorderLevel)}, " +
                    $"{nameof(Product.Discontinued)}) " +
                    "values (@Name, @QuantityPerUnit, @Description, @UnitPrice, " +
                    "@UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued);" +
                    "select @@Identity";

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return commandExecutionResult == null ? -1 : Convert.ToInt32(commandExecutionResult);
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

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
            using var connection = new SqlConnection(_connectionString);
            try
            {
                using var command = connection.CreateCommand();
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
                    "select @@Identity;";

                SetSqlParameters(command.Parameters, product);
                await connection.OpenAsync();
                commandExecutionResult = await command.ExecuteScalarAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return commandExecutionResult == null ? -1 : Convert.ToInt32(commandExecutionResult);
        }

        private void SetSqlParameters(SqlParameterCollection parameters, Product product)
        {
            parameters.AddWithValue($"@{nameof(Product.Name)}", product.Name);
            parameters.AddWithValue($"@{nameof(Product.QuantityPerUnit)}", product.QuantityPerUnit);
            parameters.AddWithValue($"@{nameof(Product.Description)}", product.Description);
            parameters.AddWithValue($"@{nameof(Product.UnitPrice)}", product.UnitPrice);
            parameters.AddWithValue($"@{nameof(Product.UnitsInStock)}", product.UnitsInStock);
            parameters.AddWithValue($"@{nameof(Product.UnitsOnOrder)}", product.UnitsOnOrder);
            parameters.AddWithValue($"@{nameof(Product.ReorderLevel)}", product.ReorderLevel);
            parameters.AddWithValue($"@{nameof(Product.Discontinued)}", product.Discontinued);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            List<Product> products = null;
            var connection = new SqlConnection(_connectionString);
            
            try
            {
                using var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Products;";

                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                if (reader != null)
                {
                    products = new List<Product>();
                    while (await reader.ReadAsync())
                    {
                        products.Add(GetProduct(reader));
                    }
                    await reader.DisposeAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            await connection.DisposeAsync();
            return products;
        }

        private Product GetProduct(SqlDataReader reader)
        {
            return new Product
            { 
                Id = reader.GetInt32(reader.GetOrdinal(nameof(Product.Id))),
                Name = reader.GetString(reader.GetOrdinal(nameof(Product.Name))),
                QuantityPerUnit = reader.GetString(reader.GetOrdinal(nameof(Product.QuantityPerUnit))),
                Description = reader.GetString(reader.GetOrdinal(nameof(Product.Description))),
                UnitPrice = reader.GetDecimal(reader.GetOrdinal(nameof(Product.UnitPrice))),
                UnitsInStock = reader.GetInt32(reader.GetOrdinal(nameof(Product.UnitsInStock))),
                ReorderLevel = reader.GetInt32(reader.GetOrdinal(nameof(Product.ReorderLevel))),
                Discontinued = reader.GetBoolean(reader.GetOrdinal(nameof(Product.Discontinued)))
            };
        }

        public async Task<Product> GetById(int id)
        {
            Product product = null;
            var connection = new SqlConnection(_connectionString);

            try
            {
                using var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Products where Id = @Id;";
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                if (reader != null)
                {
                    await reader.ReadAsync();
                    product = GetProduct(reader);
                    await reader.DisposeAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            await connection.DisposeAsync();
            return product;
        }

        public async Task<bool> Remove(int id)
        {
            Object commandExecutionResult = null;
            var connection = new SqlConnection(_connectionString);
            try
            {
                using var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Products where Id = @Id;";
                command.Parameters.AddWithValue("@Id", id);                

                await connection.OpenAsync();
                commandExecutionResult = await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            await connection.DisposeAsync();
            return commandExecutionResult == null ? false : ((int)commandExecutionResult == 1);
        }

        public async Task<bool> Update(Product product)
        {
            Object commandExecutionResult = null;
            var connection = new SqlConnection(_connectionString);
            try
            {
                using var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Update Products set " +
                    $"{nameof(Product.Name)} = @Name, " +
                    $"{nameof(Product.QuantityPerUnit)} = @QuantityPerUnit, " +
                    $"{nameof(Product.Description)} = @Description, " +
                    $"{nameof(Product.UnitPrice)} = @UnitPrice, " +
                    $"{nameof(Product.UnitsInStock)} = @UnitsInStock, " +
                    $"{nameof(Product.UnitsOnOrder)} = @UnitsOnOrder, " +
                    $"{nameof(Product.ReorderLevel)} = @ReorderLevel, " +
                    $"{nameof(Product.Discontinued)} = @Discontinued " +
                    $"where Id = {product.Id}";

                SetSqlParameters(command.Parameters, product);
                await connection.OpenAsync();
                commandExecutionResult = await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            await connection.DisposeAsync();
            return commandExecutionResult == null ? false : ((int)commandExecutionResult == 1);
        }
    }
}

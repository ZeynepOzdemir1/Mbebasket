using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using mbe.Models.Product;
using Microsoft.Extensions.Configuration;

namespace mbe.Models
{

    public class ProductProvider : IProductRepository
    {
        private readonly IConfiguration config;

        public ProductProvider(IConfiguration config)
        {
            this.config = config;
        }

        public bool Create(ProductEntity entity)
        {
            string sql = "INSERT INTO Product (ProductId, ProductName, ProductPrice) Values (@ProductId, @ProductName, @ProductPrice);";

            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                var affectedRows = connection.Execute(sql, entity);
             
            }
            return true;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE Product WHERE ProductId =@id";
            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                connection.Execute(sql, new { id = id });
                //var affectedRows = connection.Execute(sql);
                // var result = connection.Query(@"DELETE FROM Student WHERE StudentID=@id", new { StudentID = id });

            }
            return true;
        }

        public ProductEntity Get(int id)
        {
            ProductEntity product;
            using (
                var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                product = connection.Query<ProductEntity>("select ProductId as ProductId, ProductName as ProductName, ProductPrice as ProductPrice from Product where productId = @id", new { id }).FirstOrDefault();
            }
            return product;

        }

        public bool Update(ProductEntity entity)
        {
            string sql = "UPDATE[Product] SET [ProductName] = @ProductName , [ProductPrice] = @ProductPrice  WHERE ProductId = " + entity.ProductId;

            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                var affectedRows = connection.Execute(sql, entity);
            }

            return true;
        }
    }






}

        

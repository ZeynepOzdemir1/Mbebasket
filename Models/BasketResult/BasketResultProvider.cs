using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace mbe.Models.BasketResult
{
    public class BasketResultProvider : IBasketResultRepositorty
    {
        private readonly IConfiguration config;

        public BasketResultProvider(IConfiguration config)
        {
            this.config = config;
        }
        public bool Create(BasketResultEntity entity)
        {
            string sql = "INSERT INTO Basket (BasketId, CustomerId, ProductId, Quantity) Values (@BasketId, @CustomerId, @ProductId, @Quantity);";

            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                var affectedRows = connection.Execute(sql, entity);

            }
            return true;
        }

        public bool Delete(int id)
        {

            string sql = "DELETE Basket WHERE BasketId =@id";
            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                connection.Execute(sql, new { id = id });

            }
            return true;
        }

        public BasketResultEntity Get(int id)
        {
            BasketResultEntity result;

            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                result = connection.Query<BasketResultEntity>("select BasketId as BasketId, b.CustomerId as CustomerId, CustomerName as CustomerName, CustomerSurname as CustomerSurname, ProductName as ProductName, ProductPrice as ProductPrice, Quantity as Quantity from Basket as b left join Customer as c on b.CustomerId = c.CustomerId left join Product as p on b.ProductId = p.ProductId where basketId =  @id", new { id }).FirstOrDefault();
                   
            }
                return result;
        }

        public List<BasketResultEntity> GetCustomerBasket(int id)
        {
            List<BasketResultEntity> result;

            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                result = connection.Query<BasketResultEntity>("select BasketId as BasketId, b.CustomerId as CustomerId, CustomerName as CustomerName, CustomerSurname as CustomerSurname, ProductName as ProductName, ProductPrice as ProductPrice, Quantity as Quantity from Basket as b left join Customer as c on b.CustomerId = c.CustomerId left join Product as p on b.ProductId = p.ProductId where b.customerId =  @id", new { id }).ToList();

            }
            return result;
        }



        public bool Update(BasketResultEntity entity)
        {
            string sql = "UPDATE[Basket] SET[BasketId] = @BasketId ,[CustomerId] = @CustomerId , [ProductId] = @ProductId , [Quantity] = @Quantity  WHERE BasketId = " + entity.BasketId;

            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                var affectedRows = connection.Execute(sql, entity);
            }

            return true;
        }
    }
}

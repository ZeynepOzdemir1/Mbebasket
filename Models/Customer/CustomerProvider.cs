using System;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using mbe.Models.Customer;

namespace mbe.Models
{
    public class CustomerProvider : ICustomerRepository
    {
        private readonly IConfiguration config;

        public CustomerProvider(IConfiguration config)
        {
            this.config = config;
        }

        public bool Create(CustomerEntity entity)
        {

            string sql = "INSERT INTO Customer (CustomerId, CustomerName, CustomerSurname, CustomerPhone, CustomerMail) Values (@CustomerId, @CustomerName, @CustomerSurname, @CustomerPhone, @CustomerMail);";

            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                var affectedRows = connection.Execute(sql, entity);

            }
            return true;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE Customer WHERE CustomerId =@id";
            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                connection.Execute(sql, new { id = id });
                //var affectedRows = connection.Execute(sql);
                // var result = connection.Query(@"DELETE FROM Student WHERE StudentID=@id", new { StudentID = id });

            }
            return true;
        }

        public CustomerEntity Get(int id)
        {
            CustomerEntity customer;
            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                customer = connection.Query<CustomerEntity>("select CustomerId as CustomerId, CustomerName as CustomerName, CustomerSurname as CustomerSurname, CustomerPhone as CustomerPhone, CustomerMail as CustomerMail from Customer where customerId = @id", new { id }).FirstOrDefault();
            }
            return customer;

        }

        public bool Update(CustomerEntity entity)
        {
            string sql = "UPDATE[Customer] SET[CustomerId] = @CustomerId ,[CustomerName] = @CustomerName , [CustomerSurname] = @CustomerSurname , [CustomerPhone] = @CustomerPhone , [CustomerMail] = @CustomerMail WHERE CustomerId = " + entity.CustomerId;

            using (var connection = new SqlConnection(config.GetValue<string>("Conn")))
            {
                var affectedRows = connection.Execute(sql, entity);
            }

            return true;
        }
    }
}

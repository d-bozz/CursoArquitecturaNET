using Dapper;
using Dominio.Entity;
using Infraestructura.Data;
using Infraestructura.Interface;
using System.Data;
using Transversal.Common;

namespace Infraestructura.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        #region Properties and Fields

        private readonly DapperContext _context;

        public CustomersRepository(DapperContext context)
        {
            _context = context;
        }

        #endregion

        #region Metodos Sincronos
        public bool Insert(Customers customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID",customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customers customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customers Get(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerGetById";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var customer = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerGetAll";
               
                var customers = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var customers = connection.Query<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return customers;
        }

        public int Count()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Customers";

            var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
            return count;
        }

        #endregion

        #region Metodos Asincronos
        public async Task<bool> InsertAsync(Customers customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        
        public async Task<bool> UpdateAsync(Customers customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        
        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        
        public async Task<Customers> GetAsync(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerGetById";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var customer = await connection.QuerySingleAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerGetAll";

                var customers = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var customers = await connection.QueryAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return customers;
        }

        public async Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Customers";

            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }

        #endregion
    }
}
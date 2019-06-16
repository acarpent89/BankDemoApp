using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankWebApp.Model;


namespace BankWebApp.Controllers
{
    [Route("api/")]
    public class CustomerController : Controller
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private string sql_con_string = "Data Source=BankDb;Version=3;New=False;Compress=True;";


        [HttpGet("initialize")]
        public String InitialzeDb()
        {
            using (SQLiteConnection c = new SQLiteConnection(sql_con_string))
            {
                c.Open();
                string sql = "create table CUSTOMERS (customerId INTEGER PRIMARY KEY, name string(50), password string(50), address string(50), email string(50), createdDate string(15), activeFlag string(1), comments string(100))";
                string sql2 = "create table ACCOUNT (accountId INTEGER PRIMARY KEY,  type string(15), comments string(100), employeeId int(32), activeFlag string(1), createdDate string(15), creditLimit int(32), customerId int(32))";
                string sql3 = "create table TRANSACTIONS (transactionId INTEGER PRIMARY KEY, type string(15), comments string(100), amount int(15), errorFlag string(1), createdDate string(15), accountId int(32))";
                SQLiteCommand command = new SQLiteCommand(sql, c);
                command.ExecuteNonQuery();
                SQLiteCommand command2 = new SQLiteCommand(sql2, c);
                command2.ExecuteNonQuery();
                SQLiteCommand command3 = new SQLiteCommand(sql3, c);
                command3.ExecuteNonQuery();
            }
            return "Success";
        }

        [HttpPost("customer/create")]

        public String createCustomer([FromBody]Customer cus)
        {

            using (SQLiteConnection c = new SQLiteConnection(sql_con_string))
            {
                c.Open();
                using (SQLiteCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CUSTOMERS (address, email, name, createdDate, comments)" +
                    " VALUES (@address,@email,@name,@time, @comments)";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@address", cus.Address);
                    cmd.Parameters.AddWithValue("@email", cus.Email);
                    cmd.Parameters.AddWithValue("@name", cus.Name);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yy'-'MM'-'dd'T'HH':'mm':'ss"));
                    cmd.Parameters.AddWithValue("@comments", cus.Comments);

                    int rows = cmd.ExecuteNonQuery();
                }
            }
            return "Success ";
        }

        [HttpPost("customer/update")]
        public String updateCustomer([FromBody]Customer cus)
        {

            using (SQLiteConnection c = new SQLiteConnection(sql_con_string))
            {
                c.Open();
                using (SQLiteCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CUSTOMERS SET address = @address, email = @email, name = @name, " +
                    " comments =  @comments Where customerId = @customerId";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@address", cus.Address);
                    cmd.Parameters.AddWithValue("@email", cus.Email);
                    cmd.Parameters.AddWithValue("@name", cus.Name);
                    cmd.Parameters.AddWithValue("@comments", cus.Comments);
                    cmd.Parameters.AddWithValue("@customerId", cus.CustomerId);

                    int rows = cmd.ExecuteNonQuery();

                }
            }
            return "Success ";
        }

        [HttpGet("customers")]
        public List<Customer> getCustomers()
        {

            List<Customer> customers = new List<Customer>();
            using (SQLiteConnection c = new SQLiteConnection(sql_con_string))
            {
                c.Open();
                try
                {
                    using (SQLiteCommand cmd = c.CreateCommand())
                    {
                        cmd.CommandText = "select customerId, address, name, email, createdDate, comments from customers";
                        cmd.CommandType = System.Data.CommandType.Text;

                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                var data = new Customer();
                                data.CustomerId = rdr.GetInt32(0);
                                data.Address = rdr.GetString(1);
                                data.Name = rdr.GetString(2);
                                data.Email = rdr.GetString(3);
                                data.CreatedDate = rdr.GetString(4);
                                data.Comments = rdr.GetString(5);
                                customers.Add(data);
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine("{0} Exception caught.", exc);
                }
            }
            return customers;
        }

        [HttpGet("customer/{id}")]
        public Customer getCustomerById(int id)
        {
            var data = new Customer();
            List<Customer> customers = new List<Customer>();
            using (SQLiteConnection c = new SQLiteConnection(sql_con_string))
            {
                c.Open();

                try
                {
                    using (SQLiteCommand cmd = c.CreateCommand())
                    {
                        cmd.CommandText = "select customerId, address, name, email, createdDate, comments from customers where customerId = @customerId";
                        cmd.Parameters.Add(new SQLiteParameter("@customerId") { Value = id });
                        cmd.CommandType = System.Data.CommandType.Text;

                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                data.CustomerId = rdr.GetInt32(0);
                                data.Address = rdr.GetString(1);
                                data.Name = rdr.GetString(2);
                                data.Email = rdr.GetString(3);
                                data.CreatedDate = rdr.GetString(4);
                                data.Comments = rdr.GetString(5);
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine("{0} Exception caught.", exc);
                }

            }
            return data;
        }
    }
}
